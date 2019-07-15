﻿using MumbleSharp.Audio.Codecs;
using MumbleSharp.Audio.Codecs.CeltAlpha;
using MumbleSharp.Audio.Codecs.CeltBeta;
using MumbleSharp.Audio.Codecs.Opus;
using MumbleSharp.Audio.Codecs.Speex;
using System;

namespace MumbleSharp.Audio
{
    public class CodecSet
    {
        private readonly Lazy<CeltAlphaCodec> _alpha;
        private readonly Lazy<CeltBetaCodec> _beta;
        private readonly Lazy<SpeexCodec> _speex;
        private readonly Lazy<OpusCodec> _opus;

        public CodecSet(int sampleRate = Constants.DEFAULT_AUDIO_SAMPLE_RATE, byte sampleBits = Constants.DEFAULT_AUDIO_SAMPLE_BITS, byte sampleChannels = Constants.DEFAULT_AUDIO_SAMPLE_CHANNELS, float frameSize = Constants.DEFAULT_AUDIO_FRAME_SIZE)
        {
            _alpha = new Lazy<CeltAlphaCodec>();
            _beta = new Lazy<CeltBetaCodec>();
            _speex = new Lazy<SpeexCodec>();
            _opus = new Lazy<OpusCodec>(() => new OpusCodec(sampleRate, sampleBits, sampleChannels, frameSize));
        }

        protected internal IVoiceCodec GetCodec(SpeechCodecs codec)
        {
            switch (codec)
            {
                case SpeechCodecs.CeltAlpha:
                    return _alpha.Value;
                case SpeechCodecs.Speex:
                    return _speex.Value;
                case SpeechCodecs.CeltBeta:
                    return _beta.Value;
                case SpeechCodecs.Opus:
                    return _opus.Value;
                default:
                    throw new ArgumentOutOfRangeException("codec");
            }
        }
    }
}
