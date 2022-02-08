using PeterHan.PLib.Options;

namespace SightNotIncluded
{
    public enum DuplicantSightRange
    {
        [Option("SightNotIncluded.STRINGS.STRING_OPTION_VALUE_MINIMAL")]
        Minimal = 0,
        [Option("SightNotIncluded.STRINGS.STRING_OPTION_VALUE_SMALL")]
        Small = 1,
        [Option("SightNotIncluded.STRINGS.STRING_OPTION_VALUE_MEDIUM")]
        Medium = 2,
        [Option("SightNotIncluded.STRINGS.STRING_OPTION_VALUE_ALMOST_ORIGINAL")]
        AlmostOriginal = 3,
        [Option("SightNotIncluded.STRINGS.STRING_OPTION_VALUE_ORIGINAL")]
        Original = 4
    }
    
    public class SightNotIncludedConfig
    {
        [Option("SightNotIncluded.STRINGS.STRING_OPTION_SIGHT_RANGE",
            "SightNotIncluded.STRINGS.STRING_OPTION_SIGHT_RANGE_TOOLTIP")]
        public DuplicantSightRange SightRange { get; set; } = DuplicantSightRange.Medium;
    }
}