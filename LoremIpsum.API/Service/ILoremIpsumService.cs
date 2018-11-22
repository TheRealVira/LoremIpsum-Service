using System.Collections.Generic;
using LoremIpsumService;

namespace LoremIpsum.API.Service
{
    public interface ILoremIpsumService
    {
        IEnumerable<string> GenerateText(LoremIpsumGeneratorType generator, int length, int count);
    }
}
