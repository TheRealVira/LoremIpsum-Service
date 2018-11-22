using System;
using System.Collections.Generic;
using LoremIpsum.API.Service;
using LoremIpsumService;

namespace LoremIpsum.API.Tests
{
    class LoremIpsumServiceFake:ILoremIpsumService
    {
        public IEnumerable<string> GenerateText(LoremIpsumGeneratorType generator, int length, int count)
        {
            switch (generator)
            {
                    case LoremIpsumGeneratorType.Dynamic:
                        yield return "Dynamic";
                        break;
                    case LoremIpsumGeneratorType.Static:
                        yield return "Static";
                        break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(generator), generator, null);
            }
        }
    }
}
