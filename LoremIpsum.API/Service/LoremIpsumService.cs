using System;
using System.Collections.Generic;
using LoremIpsumService;
using LoremIpsumService.Generators;

namespace LoremIpsum.API.Service
{
    class LoremIpsumService:ILoremIpsumService
    {
        public IEnumerable<string> GenerateText(LoremIpsumGeneratorType generator, int length, int count)
        {
            for (var i = 0; i < count; i++)
            {
                switch (generator)
                {
                    case LoremIpsumGeneratorType.Static:
                        yield return new StaticExampleGenerator().GenerateText(length);
                        break;
                    case LoremIpsumGeneratorType.Dynamic:
                        yield return new DynamicExampleGenerator().GenerateText(length);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
