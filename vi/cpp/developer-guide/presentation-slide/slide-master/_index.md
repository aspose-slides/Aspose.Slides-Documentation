---
title: Quản lý Slide Master trong Bài thuyết trình bằng C++
linktitle: Slide Master
type: docs
weight: 80
url: /vi/cpp/slide-master/
keywords:
- bố cục slide
- slide chính
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- trình giữ chỗ
- sao chép slide master
- chép slide master
- nhân bản slide master
- slide master không dùng
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho C++: truy cập, chỉnh sửa, sao chép, so sánh và xóa các slide master trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** xác định các cài đặt thiết kế chung cho một nhóm slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, cài đặt chủ đề và cài đặt chân trang. Trong PowerPoint, chỉnh sửa một slide master là cách thường dùng để giữ cho bản trình bày nhất quán mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for C++ hỗ trợ cùng mô hình này. Một bản trình bày có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số slide layout. Các slide bình thường thường không tham chiếu trực tiếp đến slide master. Thay vào đó, một slide bình thường sử dụng một slide layout, và slide layout đó thuộc về một slide master.

Cây phân cấp như sau:

1. **Slide master** – xác định thiết kế và chủ đề chung.
1. **Layout slide** – xác định một bố cục cụ thể của các placeholder và định dạng cấp layout.
1. **Normal slide** – chứa nội dung thực tế của bản trình bày và sử dụng một layout slide.

![Cây phân cấp của slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được đại diện bởi giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/). Tất cả các slide master trong một bản trình bày có thể truy cập qua bộ sưu tập [Presentation::get_Masters](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_masters/), bộ sưu tập này triển khai [IMasterSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Khi cùng một thuộc tính được định nghĩa ở hơn một cấp, cấp độ cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Apply or Change Slide Layouts](/slides/vi/cpp/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `get_Masters()` để truy cập các slide master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Bạn cũng có thể lấy slide master được sử dụng bởi một slide bình thường thông qua layout của nó:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Nội dung của một Slide Master**

Một slide master là một đối tượng giống như slide. Nó triển khai [IBaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/), do đó nó cung cấp nhiều thuộc tính slide giống như slide bình thường và layout. Các thành viên đặc thù của master được liệt kê trên trang API [IMasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/).

Các thành viên master thường dùng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `get_Background()` | Đặt nền slide ở mức độ master. |
| `get_Shapes()` | Lưu trữ các hình dạng đặt trên master, như logo, khung hình ảnh và văn bản chung. |
| `get_LayoutSlides()` | Lưu trữ các layout slide thuộc về master. |
| `get_ThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề của master. |
| `get_HeaderFooterManager()` | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con của nó. |
| `GetDependingSlides()` | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một slide master, hình ảnh sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào slide master đầu tiên:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để biết thêm thông tin về khung ảnh, xem [Picture Frame](/slides/vi/cpp/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Slide master cung cấp kiểu dáng và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào khả dụng và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ Slide Master view.

![Lệnh Insert Placeholder trong chế độ Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên slide master. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu nền gradient tuyến tính:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Placeholder tiêu đề đã định dạng kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/slides/vi/cpp/manage-placeholder/) và [Text Formatting](/slides/vi/cpp/text-formatting/).

## **Thay đổi nền của Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền rắn cho slide master đầu tiên:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Đối với các chủ đề liên quan, xem [Presentation Background](/slides/vi/cpp/presentation-background/) và [Presentation Theme](/slides/vi/cpp/presentation-theme/).

## **Sao chép Slide Master sang Bản Trình Bày Khác**

Sử dụng [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/addclone/) để sao chép một slide master vào bản trình bày khác. Slide master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản trình bày đích.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Nếu bạn cần sao chép cả các slide bình thường cùng với master của chúng, xem [Clone Slides](/slides/vi/cpp/clone-slides/).

## **Thêm Nhiều Slide Master**

Một bản trình bày có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt chủ đề khác nhau.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đổi nền cho bản sao, tạo một layout dưới master đã sao chép và thêm một slide mới dựa trên layout đó:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **So sánh Slide Masters**

Slide master có thể được so sánh bằng phương thức `Equals` kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/). Việc so sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn như hình dạng, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất như slide ID, hay các giá trị placeholder động như ngày hiện tại.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Để biết thêm thông tin, xem [Compare Presentation Slides](/slides/vi/cpp/compare-slides/).

## **Đặt Slide Master View làm chế độ xem mặc định**

Sử dụng phương thức `set_LastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) để kiểm soát chế độ xem mà PowerPoint mở đầu tiên. Ví dụ sau mở bản trình bày ở chế độ Slide Master view:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để biết thêm các cài đặt chế độ xem, xem [Save Presentation](/slides/vi/cpp/save-presentation/).

## **Xóa các Slide Master không dùng**

Đôi khi bản trình bày chứa các slide master không còn được bất kỳ slide bình thường nào sử dụng. Việc xóa các master không dùng có thể giảm kích thước tập tin và đơn giản hoá việc bảo trì mẫu.

Sử dụng [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/vi/cpp/aspose.slides/masterslidecollection/removeunused/) để xóa các master không dùng khỏi bộ sưu tập `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bạn cũng có thể dùng phương thức low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master xác định các cài đặt thiết kế chung như chủ đề, nền, hình dạng chung và kiểu chữ. Layout slide thuộc về một slide master và xác định một bố cục cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, vì vậy nó kế thừa cả từ layout và master.

**Một bản trình bày có thể chứa nhiều slide master không?**

Có. Một bản trình bày có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống trực quan hoặc thương hiệu khác nhau.

**Nên thêm placeholder vào slide master hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố trực quan chung và định dạng chung trên slide master, sau đó đặt các placeholder nội dung trên các layout mà slide bình thường sẽ sử dụng.

**Tôi có thể xóa một slide master vẫn đang được sử dụng không?**

Không. Một slide master có các slide phụ thuộc không thể bị xóa trực tiếp một cách an toàn. Trước tiên hãy di chuyển các slide đó sang layout dưới một master khác, hoặc dùng phương pháp dọn dẹp master không dùng chỉ xóa các master không còn được sử dụng.