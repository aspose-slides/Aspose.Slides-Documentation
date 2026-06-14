---
title: Thêm các slide Layout vào bản trình chiếu
type: docs
weight: 20
url: /vi/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET cho phép các nhà phát triển thêm các slide Layout mới vào bản trình chiếu. Để thêm một Layout Slide, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp Presentation
- Truy cập bộ sưu tập Master Slide
- Tìm các Layout slide hiện có để xem slide cần thiết đã có trong bộ sưu tập Layout Slide chưa
- Thêm một Layout slide mới nếu layout mong muốn không có
- Thêm một slide trống với Layout slide vừa được thêm
- Cuối cùng, ghi file bản trình chiếu bằng đối tượng Presentation
## **Ví dụ**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu

using (Presentation p = new Presentation(FileName))

{

    // Thử tìm kiếm theo loại slide layout

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Trường hợp bản trình chiếu không chứa một số loại layout.

        // Bản trình chiếu Technographics.pptx chỉ chứa các loại layout Blank và Custom.

        // Nhưng các slide layout với loại Custom có các tên slide khác nhau,

        // như "Title", "Title and Content", v.v. Và có thể sử dụng chúng

        // làm tên để lựa chọn slide layout.

        // Ngoài ra cũng có thể sử dụng tập hợp các loại hình placeholder. Ví dụ,

        // Slide tiêu đề chỉ nên có loại placeholder Title, v.v.

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

    //Thêm slide trống với layout slide đã thêm

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Lưu bản trình chiếu    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Tải về Mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Tải về Ví dụ chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Để biết thêm chi tiết, truy cập [Áp dụng hoặc Thay đổi Bố cục Slide trong .NET](/slides/vi/net/slide-layout/).

{{% /alert %}}