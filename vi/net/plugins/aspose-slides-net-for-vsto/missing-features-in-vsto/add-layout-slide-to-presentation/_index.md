---
title: Thêm Slide Bố cục vào Bài thuyết trình
type: docs
weight: 10
url: /vi/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET cho phép các nhà phát triển thêm các slide Bố cục mới vào bài thuyết trình. Để thêm một Slide Bố cục, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation
- Truy cập bộ sưu tập Master Slide
- Cố gắng tìm các Slide Bố cục hiện có để xem slide cần thiết đã có trong bộ sưu tập Layout Slide chưa
- Thêm một Slide Bố cục mới nếu bố cục mong muốn không có sẵn
- Thêm một slide trống sử dụng Layout slide vừa được thêm
- Cuối cùng, ghi tệp bài thuyết trình bằng đối tượng Presentation.

## **Ví dụ**
``` csharp

 //Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình

using (Presentation p = new Presentation("Test.pptx"))

{

   // Thử tìm kiếm theo loại slide bố cục

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Trường hợp khi một bài thuyết trình không chứa một số loại bố cục.

     // Bài thuyết trình Technographics.pptx chỉ chứa các loại bố cục Blank và Custom.

     // Tuy nhiên các slide bố cục loại Custom có tên slide khác nhau,

     // chẳng hạn như "Title", "Title and Content", v.v. và có thể sử dụng những

     // tên này để chọn slide bố cục.

     // Ngoài ra, có thể sử dụng tập hợp các loại hình placeholder. Ví dụ,

     // Slide Title chỉ nên có loại placeholder Title, v.v.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Title and Object")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Title")

            {

                layoutSlide = titleLayoutSlide;

                break;

            }

          }

          if (layoutSlide == null)

          {

             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

             if (layoutSlide == null)

             {

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

             }

          }

      }

  }

  // Thêm slide trống với slide bố cục đã thêm

  p.Slides.InsertEmptySlide(0, layoutSlide);

  // Lưu bài thuyết trình

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Tải về Ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Tải về Mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Áp dụng hoặc Thay đổi Bố cục Slide trong .NET](/slides/vi/net/slide-layout/).
{{% /alert %}}