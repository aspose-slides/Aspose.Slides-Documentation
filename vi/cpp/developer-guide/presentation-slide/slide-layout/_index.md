---
title: Áp dụng hoặc Thay đổi bố cục slide trong C++
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/cpp/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bản trình bày
- thiết kế slide
- bố cục không sử dụng
- hiển thị footer
- slide tiêu đề
- tiêu đề và nội dung
- tiêu đề phần
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
- bản trình bày
- C++
- Aspose.Slides
description: "Quản lý và tùy chỉnh bố cục slide trong Aspose.Slides cho C++. Khám phá các loại bố cục, kiểm soát trình giữ chỗ và khả năng hiển thị footer qua các ví dụ mã C++."
---
## **Giới thiệu**

Một bố cục slide xác định cách sắp xếp các hộp placeholder và định dạng cho nội dung trên một slide. Nó kiểm soát các placeholder nào có sẵn và chúng xuất hiện ở đâu. Bố cục slide giúp bạn thiết kế bài thuyết trình nhanh chóng và nhất quán—cho dù bạn đang tạo một thứ đơn giản hay phức tạp hơn. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Title Slide layout** – Bao gồm hai placeholder văn bản: một cho tiêu đề và một cho phụ đề.

**Title and Content layout** – Có một placeholder tiêu đề nhỏ hơn ở phía trên và một placeholder lớn hơn ở phía dưới cho nội dung chính (chẳng hạn như văn bản, danh sách gạch đầu dòng, biểu đồ, hình ảnh, và hơn nữa).

**Blank layout** – Không chứa bất kỳ placeholder nào, cho phép bạn toàn quyền thiết kế slide từ đầu.

Bố cục slide là một phần của slide master, là slide cấp cao nhất định nghĩa phong cách bố cục cho bản trình bày. Bạn có thể truy cập và chỉnh sửa các layout slide thông qua slide master—bằng cách dựa trên loại, tên hoặc ID duy nhất của chúng. Ngoài ra, bạn có thể chỉnh sửa một layout slide cụ thể trực tiếp trong bản trình bày.

Để làm việc với layout slide trong Aspose.Slides for Android, bạn có thể sử dụng:

- Các phương thức như [get_LayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_layoutslides/) và [get_Masters](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_masters/) trong lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) 
- Các kiểu như [ILayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutplaceholdermanager/), và [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Để tìm hiểu thêm về cách làm việc với master slide, hãy xem bài viết [Slide Master](/slides/vi/cpp/slide-master/).
{{% /alert %}}

## **Thêm Layout Slide vào Bản Trình Bày**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các layout slide mới vào bản trình bày. Aspose.Slides for Android cho phép bạn kiểm tra xem một layout cụ thể đã tồn tại chưa, thêm mới nếu cần, và sử dụng nó để chèn các slide dựa trên layout đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Truy cập [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Kiểm tra xem layout slide mong muốn đã tồn tại trong bộ sưu tập chưa. Nếu chưa, thêm layout slide bạn cần.
1. Thêm một slide trống dựa trên layout slide mới.
1. Lưu bản trình bày.

Mã C++ sau đây minh họa cách thêm một layout slide vào bản trình bày PowerPoint:

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Trường hợp bản trình bày không chứa tất cả các loại bố cục.
    // Tệp bản trình bày chỉ chứa các loại bố cục Blank và Custom.
    // Tuy nhiên, các layout slide có loại tùy chỉnh có thể có những tên nhận dạng,
    // chẳng hạn như "Title", "Title and Content", v.v., có thể được sử dụng để chọn layout slide.
    // Bạn cũng có thể dựa vào một tập hợp các loại hình dạng placeholder.
    // Ví dụ, một slide Title nên chỉ có kiểu placeholder Title, và tương tự.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Thêm một slide trống sử dụng layout slide đã thêm.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Lưu bản trình bày vào đĩa.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Xóa Layout Slide Không Sử Dụng**

Aspose.Slides cung cấp phương thức [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) từ lớp [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) để cho phép bạn xoá các layout slide không mong muốn và không được sử dụng.

Mã C++ sau đây cho thấy cách xoá một layout slide khỏi bản trình bày PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Placeholder Vào Layout Slide**

Aspose.Slides cung cấp phương thức [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) cho phép bạn thêm các placeholder mới vào một layout slide.

Trình quản lý này chứa các phương thức cho các loại placeholder sau:

| Placeholder PowerPoint | Phương thức [ILayoutPlaceholderManager] |
| ---------------------- | ---------------------------------------- |
| ![Nội dung](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Nội dung (Dọc)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Văn bản](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Văn bản (Dọc)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Hình ảnh](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Biểu đồ](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Bảng](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Phương tiện](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Hình ảnh trực tuyến](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Mã C++ sau đây minh họa cách thêm các hình dạng placeholder mới vào layout slide Blank:

```cpp
auto presentation = MakeObject<Presentation>();

// Lấy layout slide Blank.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Lấy trình quản lý placeholder của layout slide.
auto placeholderManager = layout->get_PlaceholderManager();

// Thêm các placeholder khác nhau vào layout slide Blank.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Thêm một slide mới với layout Blank.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các placeholder trên layout slide](add_placeholders.png)

## **Đặt Hiển Thị Footer cho Layout Slide**

Trong bản trình bày PowerPoint, các phần footer như ngày, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy theo layout slide. Aspose.Slides for Android cho phép bạn kiểm soát việc hiển thị của các placeholder footer này. Điều này hữu ích khi bạn muốn một số layout hiển thị thông tin footer trong khi các layout khác vẫn sạch sẽ và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu layout slide theo chỉ số của nó.
1. Đặt placeholder footer của slide thành hiển thị.
1. Đặt placeholder số slide thành hiển thị.
1. Đặt placeholder ngày‑giờ thành hiển thị.
1. Lưu bản trình bày.

Mã C++ sau đây cho thấy cách đặt hiển thị của footer slide và thực hiện các tác vụ liên quan:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Hiển Thị Footer Con cho Slide**

Trong bản trình bày PowerPoint, các phần footer như ngày, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức master slide để đảm bảo tính nhất quán trên tất cả các layout slide. Aspose.Slides cho Android cho phép bạn đặt hiển thị và nội dung của các placeholder footer này trên master slide và lan truyền các cài đặt này tới tất cả các layout slide con. Cách tiếp cận này đảm bảo thông tin footer đồng nhất trong toàn bộ bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu tới master slide theo chỉ số của nó.
1. Đặt các placeholder footer của master và tất cả các layout con thành hiển thị.
1. Đặt các placeholder số slide của master và tất cả các layout con thành hiển thị.
1. Đặt các placeholder ngày‑giờ của master và tất cả các layout con thành hiển thị.
1. Lưu bản trình bày.

Mã C++ sau đây minh họa thao tác này:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Sự khác nhau giữa master slide và layout slide là gì?**

Master slide định nghĩa chủ đề tổng thể và định dạng mặc định, trong khi layout slide xác định cách sắp xếp cụ thể các placeholder cho các loại nội dung khác nhau.

**Tôi có thể sao chép một layout slide từ bản trình bày này sang bản khác không?**

Có, bạn có thể sao chép (clone) một layout slide từ bộ sưu tập layout slide của một bản trình bày, có thể truy cập qua phương thức [get_LayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_layoutslides/), và chèn nó vào bản trình bày khác bằng phương thức `AddClone`.

**Điều gì xảy ra nếu tôi xóa một layout slide vẫn còn được một slide khác sử dụng?**

Nếu bạn cố gắng xóa một layout slide mà vẫn được ít nhất một slide trong bản trình bày tham chiếu, Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxeditexception/). Để tránh điều này, hãy sử dụng [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để xóa an toàn chỉ các layout slide không được sử dụng.