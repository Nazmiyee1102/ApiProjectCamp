namespace ApiProjectCamp.WebApi.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
    }
}
