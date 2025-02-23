namespace ApiProjectCamp.WebApi.Dtos.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Videourl { get; set; }
        public string Imageurl { get; set; }

    }
}
