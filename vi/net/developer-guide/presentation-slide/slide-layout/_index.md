---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong .NET
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/net/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- phần giữ chỗ
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
- slide tiêu đề
- tiêu đề và nội dung
- đầu mục phần
- hai nội dung
- so sánh
- chỉ tiêu đề
- bố cục trống
- nội dung có chú thích
- hình ảnh có chú thích
- tiêu đề và văn bản dọc
- tiêu đề dọc và văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- C#
- .NET
- Aspose.Slides
description: "Quản lý và tùy chỉnh bố cục slide trong Aspose.Slides cho .NET. Khám phá các loại bố cục, kiểm soát phần giữ chỗ và hiển thị chân trang thông qua các ví dụ mã C#."
---
## **Giới thiệu**

Một bố cục slide định nghĩa cách sắp xếp các hộp giữ chỗ và định dạng cho nội dung trên một slide. Nó kiểm soát những hộp giữ chỗ nào có sẵn và chúng xuất hiện ở đâu. Bố cục slide giúp bạn thiết kế bài thuyết trình nhanh chóng và nhất quán—cho dù bạn đang tạo một thứ đơn giản hay phức tạp hơn. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Bố cục Trang Tiêu đề** – Bao gồm hai hộp giữ chỗ văn bản: một cho tiêu đề và một cho phụ đề.

**Bố cục Tiêu Đề và Nội Dung** – Có một hộp giữ chỗ tiêu đề nhỏ hơn ở phía trên và một hộp lớn hơn phía dưới cho nội dung chính (như văn bản, dấu đầu dòng, biểu đồ, hình ảnh, và hơn thế nữa).

**Bố cục Trống** – Không chứa hộp giữ chỗ nào, cho phép bạn tự do thiết kế slide từ đầu.

Bố cục slide là một phần của slide master, là slide cấp cao nhất định nghĩa các kiểu bố cục cho toàn bộ bài thuyết trình. Bạn có thể truy cập và sửa đổi các slide bố cục thông qua slide master—bằng loại, tên hoặc ID duy nhất của chúng. Ngoài ra, bạn cũng có thể chỉnh sửa một slide bố cục cụ thể trực tiếp trong bài thuyết trình.

Để làm việc với bố cục slide trong Aspose.Slides for .NET, bạn có thể sử dụng:

- Các thuộc tính như [LayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/layoutslides/) và [Masters](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/masters/) dưới lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/)
- Các kiểu như [ILayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutplaceholdermanager/), và [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Để tìm hiểu thêm về cách làm việc với slide master, hãy xem bài viết [Slide Master](/slides/vi/net/slide-master/) .

{{% /alert %}}

## **Thêm Bố Cục Slide vào Bản Trình Bày**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các slide bố cục mới vào một bản trình bày. Aspose.Slides for .NET cho phép bạn kiểm tra xem một bố cục cụ thể đã tồn tại chưa, thêm một bố cục mới nếu cần, và sử dụng nó để chèn slide dựa trên bố cục đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Truy cập vào [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterlayoutslidecollection/).
3. Kiểm tra xem slide bố cục mong muốn đã tồn tại trong bộ sưu tập chưa. Nếu chưa, thêm slide bố cục bạn cần.
4. Thêm một slide trống dựa trên slide bố cục mới.
5. Lưu bản trình bày.

Mã C# sau đây minh họa cách thêm một bố cục slide vào bản trình bày PowerPoint:

```cs
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Duyệt các loại slide bố cục để chọn một slide bố cục.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Trường hợp bản trình bày không chứa tất cả các loại bố cục.
        // Tệp bản trình bày chỉ chứa các loại bố cục Trống và Tùy chỉnh.
        // Tuy nhiên, các slide bố cục có loại tùy chỉnh có thể có tên nhận dạng,
        // như "Title", "Title and Content", v.v., có thể được sử dụng để chọn slide bố cục.
        // Bạn cũng có thể dựa vào một tập hợp các loại hình dạng giữ chỗ.
        // Ví dụ, một slide Tiêu đề chỉ nên có loại giữ chỗ Title, và tương tự.
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

    // Thêm một slide trống sử dụng slide bố cục đã thêm.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Lưu bản trình bày vào đĩa.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Xóa Các Bố Cục Slide Không Sử Dụng**

Aspose.Slides cung cấp phương thức [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) trong lớp [Compress](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/) để cho phép bạn xóa các slide bố cục không mong muốn và không được sử dụng.

Mã C# dưới đây cho thấy cách xóa một slide bố cục khỏi bản trình bày PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Thêm Phần Giữ Chỗ Vào Bố Cục Slide**

Aspose.Slides cung cấp thuộc tính [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/placeholdermanager/) cho phép bạn thêm các hộp giữ chỗ mới vào một slide bố cục.

Trình quản lý này chứa các phương thức cho các loại hộp giữ chỗ sau:

| PowerPoint Placeholder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutplaceholdermanager/) Method |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Mã C# sau đây minh họa cách thêm các hình dạng hộp giữ chỗ mới vào slide bố cục Trống:

```cs
using (var presentation = new Presentation())
{
    // Lấy slide bố cục Trống.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Lấy trình quản lý phần giữ chỗ của slide bố cục.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Thêm các phần giữ chỗ khác nhau vào slide bố cục Trống.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Thêm một slide mới với bố cục Trống.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các hộp giữ chỗ trên slide bố cục](add_placeholders.png)

## **Đặt Khả Năng Hiển Thị Chân Trang Cho Bố Cục Slide**

Trong các bản trình bày PowerPoint, các thành phần chân trang như ngày tháng, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy thuộc vào bố cục slide. Aspose.Slides for .NET cho phép bạn kiểm soát khả năng hiển thị của các hộp giữ chỗ chân trang này. Điều này hữu ích khi bạn muốn một số bố cục hiển thị thông tin chân trang trong khi các bố cục khác giữ sạch sẽ và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bố cục bằng chỉ mục của nó.
3. Đặt hộp giữ chỗ chân trang slide thành hiện thị.
4. Đặt hộp giữ chỗ số slide thành hiện thị.
5. Đặt hộp giữ chỗ ngày‑giờ thành hiện thị.
6. Lưu bản trình bày.

Mã C# dưới đây cho thấy cách đặt khả năng hiển thị của chân trang slide và thực hiện các thao tác liên quan:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Đặt Khả Năng Hiển Thị Chân Trang Con Cho Slide**

​Trong các bản trình bày PowerPoint, các thành phần chân trang như ngày tháng, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức slide master để đảm bảo tính nhất quán trên tất cả các slide bố cục. Aspose.Slides for .NET cho phép bạn đặt khả năng hiển thị và nội dung của các hộp giữ chỗ chân trang này trên slide master và truyền các thiết lập này tới tất cả các slide bố cục con. Cách tiếp cận này đảm bảo thông tin chân trang đồng nhất trong toàn bộ bài thuyết trình.​

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide master bằng chỉ mục của nó.
3. Đặt tất cả các hộp giữ chỗ chân trang của master và các slide con thành hiện thị.
4. Đặt tất cả các hộp giữ chỗ số slide của master và các slide con thành hiện thị.
5. Đặt tất cả các hộp giữ chỗ ngày‑giờ của master và các slide con thành hiện thị.
6. Lưu bản trình bày.

Mã C# dưới đây minh họa thao tác này:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Sự khác nhau giữa slide master và slide bố cục là gì?**

Slide master định nghĩa chủ đề chung và định dạng mặc định, trong khi slide bố cục xác định cách sắp xếp cụ thể của các hộp giữ chỗ cho các loại nội dung khác nhau.

**Tôi có thể sao chép một slide bố cục từ bản trình bày này sang bản trình bày khác không?**

Có, bạn có thể sao chép một slide bố cục từ bộ sưu tập [LayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/layoutslides/) của một bản trình bày và chèn nó vào bản trình bày khác bằng phương thức `AddClone`.

**Điều gì sẽ xảy ra nếu tôi xóa một slide bố cục mà vẫn đang được một slide sử dụng?**

Nếu bạn cố gắng xóa một slide bố cục mà vẫn được ít nhất một slide tham chiếu trong bản trình bày, Aspose.Slides sẽ ném ra một ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/). Để tránh điều này, hãy sử dụng [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để an toàn xóa chỉ những slide bố cục không được sử dụng.