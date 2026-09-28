---
title: Quản lý Slide Master trong Bản trình bày bằng C++
linktitle: Slide Master
type: docs
weight: 80
url: /vi/cpp/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- trình giữ chỗ
- sao chép slide master
- sao chép slide master
- nhân đôi slide master
- slide master không dùng
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho C++: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** xác định các thiết lập thiết kế chia sẻ cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, thiết lập chủ đề và thiết lập chân trang. Trong PowerPoint, chỉnh sửa một slide master là cách thông thường để giữ cho bản trình bày nhất quán mà không cần lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for C++ hỗ trợ cùng mô hình. Một bản trình bày có thể chứa một hoặc nhiều master slide, và mỗi master slide có thể chứa một số layout slide. Các slide bình thường thường không tham chiếu trực tiếp đến master slide. Thay vào đó, một slide bình thường sử dụng một layout slide, và layout slide đó thuộc về một master slide.

Cấu trúc phân cấp là:

1. **Slide master** - xác định thiết kế và chủ đề chung.
2. **Layout slide** - xác định một sắp xếp cụ thể của các placeholder và định dạng mức layout.
3. **Normal slide** - chứa nội dung trình bày thực tế và sử dụng một layout slide.

![Cấu trúc của master slides, layout slides và normal slides](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được đại diện bởi giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/) . Tất cả các master slide trong một bản trình bày có sẵn thông qua bộ sưu tập [Presentation::get_Masters](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_masters/) , mà triển khai [IMasterSlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Khi cùng một thuộc tính được định nghĩa ở hơn một mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một master slide và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slides, xem [Apply or Change Slide Layouts](/slides/vi/cpp/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `get_Masters()` để truy cập master slides:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Bạn cũng có thể lấy master slide được sử dụng bởi một slide bình thường thông qua layout của nó:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Nội dung của Slide Master**

Một master slide là một đối tượng giống slide. Nó triển khai [IBaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/) , vì vậy nó cung cấp nhiều thuộc tính slide giống như các slide bình thường và layout. Các thành viên đặc thù của master được liệt kê trên trang API [IMasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslide/) .

Các thành viên master slide thường dùng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `get_Background()` | Đặt nền slide ở mức master. |
| `get_Shapes()` | Lưu trữ các shape đặt trên master, như logo, khung hình, và văn bản chia sẻ. |
| `get_LayoutSlides()` | Lưu trữ các layout slide thuộc về master. |
| `get_ThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề master. |
| `get_HeaderFooterManager()` | Điều khiển header, footer, ngày tháng và số slide cho master và các layout con. |
| `GetDependingSlides()` | Trả về các slide bình thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm một hình ảnh vào master slide, nó sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào master slide đầu tiên:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

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

Để biết thêm thông tin về khung hình, xem [Picture Frame](/slides/vi/cpp/picture-frame/).

## **Kiểm soát hiển thị đồ họa Master**

Sử dụng [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/set_showmastershapes/) để ẩn đồ họa master kế thừa, chẳng hạn logo hoặc shape trang trí, mà không xóa chúng khỏi master. Gửi `false` tới [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/set_showmastershapes/) trên slide cần bỏ các đồ họa và `true` trên các slide cần hiển thị chúng.

Ví dụ tự chứa sau tạo một dải trang trí màu xanh trên master và hai slide sử dụng cùng layout trống. Dải này hiển thị trên slide đầu tiên và ẩn trên slide thứ hai. Không cần bản trình bày hoặc hình ảnh đầu vào.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ví dụ này sử dụng layout **Blank** được cung cấp cùng một bản trình bày mới và loại bỏ các placeholder riêng của slide đầu tiên.

### **Chọn phạm vi cài đặt**

Một slide bình thường sử dụng master của nó thông qua [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/get_layoutslide/) và [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilayoutslide/get_masterslide/). Đặt thuộc tính trên một slide riêng chỉ ảnh hưởng tới slide đó. Gửi `false` tới [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/set_showmastershapes/) sẽ ẩn đồ họa master cho các slide sử dụng layout chung đó, ngay cả khi cài đặt riêng của chúng là `true`. Để ẩn đồ họa trên một slide duy nhất, thay đổi thuộc tính slide và giữ layout chung không thay đổi.

Cài đặt này không được hỗ trợ làm điều khiển hiển thị trên chính master slide. Trên master nó luôn trả về `false`, và gán `true` sẽ gây ra `System::NotSupportedException`. Áp dụng nó cho một slide bình thường hoặc một layout thay vì master.

### **Phân biệt đồ họa với nền**

| Hoạt động | Hiệu quả |
| --- | --- |
| Ẩn đồ họa master | Kiểm soát khả năng hiển thị của các shape master kế thừa mà không xóa chúng hoặc thay đổi các shape của slide. |
| Thay đổi nền slide | Thay đổi màu nền, gradient hoặc hình ảnh. Đồ họa master là các shape riêng biệt và có thể vẫn hiển thị trên nền đó. Xem [Presentation Background](/slides/vi/cpp/presentation-background/). |
| Xóa shape khỏi master | Xóa shape nguồn chia sẻ, do đó không còn khả dụng cho bất kỳ slide nào sử dụng master đó. |

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slides. Master slide cung cấp phong cách và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào khả dụng và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ xem Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên master slide. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu gradient tuyến tính:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

![Placeholder tiêu đề đã định dạng được kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn placeholder và định dạng văn bản, xem [Set Prompt Text in Placeholder](/slides/vi/cpp/manage-placeholder/) và [Text Formatting](/slides/vi/cpp/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền đặc cho master slide đầu tiên:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để biết các chủ đề liên quan, xem [Presentation Background](/slides/vi/cpp/presentation-background/) và [Presentation Theme](/slides/vi/cpp/presentation-theme/).

## **Sao chép Slide Master sang Bản trình bày khác**

Sử dụng [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/addclone/) để sao chép một master slide vào bản trình bày khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản đích.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Nếu bạn cần sao chép các slide bình thường cùng với master của chúng, xem [Clone Slides](/slides/vi/cpp/clone-slides/).

## **Thêm nhiều Slide Masters**

Một bản trình bày có thể chứa nhiều master slides. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc thiết lập chủ đề khác nhau.

![Các lệnh PowerPoint để chèn và quản lý master slides](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép và thêm một slide mới dựa trên layout đó:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

Slide master có thể được so sánh bằng phương thức `Equals` kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/) . So sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn shape, văn bản, định dạng, hoạt ảnh và các thiết lập slide khác. Nó không so sánh các định danh duy nhất, như slide ID, hay các giá trị placeholder động, như ngày hiện tại.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

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

Sử dụng phương thức `set_LastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/) để điều khiển chế độ xem mà PowerPoint mở đầu tiên. Ví dụ sau mở bản trình bày trong chế độ Slide Master view:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để biết thêm các cài đặt chế độ xem, xem [Save Presentation](/slides/vi/cpp/save-presentation/).

## **Xóa các Master Slides không dùng**

Đôi khi bản trình bày chứa các master slide không còn được bất kỳ slide bình thường nào sử dụng. Loại bỏ các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/vi/cpp/aspose.slides/masterslidecollection/removeunused/) để xóa các master không dùng khỏi bộ sưu tập `get_Masters()` :

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bạn cũng có thể sử dụng phương thức low-code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Sự khác biệt giữa slide master và layout slide là gì?**

Một slide master xác định các thiết lập thiết kế chung như chủ đề, nền, shape chung và kiểu chữ. Một layout slide thuộc về một master slide và xác định một sắp xếp cụ thể của các placeholder. Một slide bình thường sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bản trình bày có thể chứa nhiều slide master không?**

Có. Một bản trình bày có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Tôi nên thêm placeholder vào master slide hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh và định dạng chung trên master slide, sau đó đặt các placeholder nội dung trên các layout mà các slide bình thường sẽ dùng.

**Tôi có thể xóa một master slide đang được sử dụng không?**

Không. Một master slide có các slide phụ thuộc không thể bị xóa an toàn trực tiếp. Trước tiên hãy chuyển các slide đó sang layout dưới một master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng chỉ loại bỏ các master không có slide phụ thuộc.