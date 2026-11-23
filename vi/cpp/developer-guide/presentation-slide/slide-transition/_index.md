---
title: Quản lý hiệu ứng chuyển slide trong bản trình bày bằng C++
linktitle: Hiệu ứng chuyển slide
type: docs
weight: 80
url: /vi/cpp/slide-transition/
keywords:
- hiệu ứng chuyển slide
- thêm hiệu ứng chuyển slide
- áp dụng hiệu ứng chuyển slide
- hiệu ứng chuyển slide nâng cao
- hiệu ứng Morph
- kiểu chuyển
- hiệu ứng chuyển
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Áp dụng hiệu ứng chuyển slide, cấu hình tự động chuyển tiếp slide, và tùy chỉnh Morph và các hiệu ứng chuyển khác với Aspose.Slides cho C++."
---
## **Tổng quan**

Hiệu ứng chuyển slide kiểm soát cách các slide xuất hiện trong một buổi chiếu slide. Với Aspose.Slides cho C++, bạn có thể chọn một hiệu ứng chuyển cho mỗi slide, cấu hình việc chuyển tiếp bằng nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ C++ để áp dụng hiệu ứng chuyển, đặt thời gian chuyển chính xác, quản lý thời gian slide, và tạo một hiệu ứng Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu cài đặt vào tệp PPTX.

## **Thêm hiệu ứng chuyển slide**

Để áp dụng một hiệu ứng chuyển, tải một bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và truy cập cài đặt chuyển của slide thông qua [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Gọi [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) với một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), sau đó lưu bản trình bày.

Ví dụ dưới đây áp dụng hiệu ứng Circle cho slide đầu tiên và hiệu ứng Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Hiệu ứng Wheel**

Phương thức [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) của [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) kiểm soát số sector tia radial sẽ tiết lộ slide đích. Gọi [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) với Wheel từ [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) trước khi truy cập [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) như [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

Ví dụ này tạo hai cặp slide giống hệt nhau: một slide đen sau đó là một slide có hình chữ nhật màu vàng. Các slide đích sử dụng số spoke là 1 và 8, với tốc độ giống nhau được đặt qua [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) và thời lượng rõ ràng 8.000 miligiây được đặt qua [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) để dễ quan sát sự khác biệt.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Mở bản trình bày đầu ra trong PowerPoint và chạy buổi chiếu slide. Tiến từ slide 1 đến slide 2, sau đó từ slide 3 đến slide 4. Trong chế độ phát PowerPoint, số spoke đã xác nhận là 1 sẽ tiết lộ slide bằng một vòng quay theo chiều kim đồng hồ; số 8 sẽ tiết lộ nó qua tám sector radial đồng thời. Nội dung đích và thời gian chuyển đều giống nhau, vì vậy sự khác biệt chỉ là số sector tiết lộ.

## **Fade Through Black với hiệu ứng Reveal**

Đặt kiểu chuyển của slide đích thành Reveal, sau đó gọi [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) trên giao diện [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/). Ví dụ tạo một slide nguồn màu xanh ngọc và một slide đích màu san hô, sau đó sao chép cả hai để bạn có thể so sánh cùng một hiệu ứng hai giây với việc làm mờ qua màu đen bị tắt và bật.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Trong một buổi chiếu slide PowerPoint, tiến từ slide 1 đến slide 2. Màu xanh ngọc mờ trực tiếp sang màu san hô. Sau đó tiến từ slide 3 đến slide 4. Màn hình tạm thời tối gần đen trước khi slide màu san hô xuất hiện. Cả hai slide đều giữ nguyên màu nền gốc.

Các hàng bên dưới hiển thị các khung hình từ PowerPoint mỗi nửa giây. So sánh khung hình ở giữa mỗi hàng để thấy hiệu ứng của cài đặt.

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Thêm hiệu ứng chuyển slide nâng cao**

Bạn có thể cấu hình thời gian một slide ở lại trên màn hình và liệu một cú nhấp chuột có chuyển tiếp buổi chiếu slide hay không. Các phương thức sau kiểm soát hành vi này:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) cho phép người xem tiến bằng cách nhấp chuột.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) bật chuyển tiếp tự động.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) chỉ định độ trễ trước khi chuyển tiếp tự động, tính bằng miligiây.

Bật cả chuyển tiếp bằng nhấp chuột và bằng thời gian để người xem có thể tiến tiếp bằng nhấp chuột hoặc chờ bộ hẹn giờ. Để chỉ dùng bộ hẹn giờ, gọi [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) với `false`. Độ trễ kiểm soát thời điểm buổi chiếu slide chuyển tiếp; nó không đặt thời lượng của hiệu ứng chuyển hình.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu và bật chuyển tiếp tự động sau 3, 5, và 7 giây tương ứng. Các slide cũng có thể được tiến bằng nhấp chuột. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Để kiểm tra xem chuyển tiếp tự động có được bật hay không, gọi [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Một độ trễ được lưu riêng không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ đã bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide đó và lưu lại cài đặt đã cập nhật.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Kiểm soát thời gian chuyển một cách chính xác**

Sử dụng [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) để chỉ định độ dài chính xác của một hiệu ứng chuyển tính bằng miligiây. Phương thức [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) của slide cung cấp các cài đặt này qua [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | Đặt thời lượng của chính hiệu ứng chuyển, tính bằng miligiây. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng miligiây. Gọi [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) với `true` để kích hoạt bộ hẹn giờ này. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | Chọn một danh mục tốc độ định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium, hoặc Fast. Được sử dụng khi không có thời lượng rõ ràng được chỉ định. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) chỉ kiểm soát hiệu ứng chuyển; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tự động chuyển riêng biệt. Khi không đặt thời lượng cụ thể, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên kiểu chuyển và giá trị trả về của [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì tốc độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/), và đặt thời lượng 750 miligiây cho mỗi chuyển. Nó cũng bật chuyển tiếp tự động sau 5.000 miligiây và tắt chuyển tiếp bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Cấu hình tự động tiến tiếp độc lập với thời lượng hiệu ứng.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Đặt thời lượng khác nhau cho từng slide**

Các slide khác nhau có thể dùng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng một chuyển ngắn cho slide tiêu đề và một chuyển dài hơn cho phần giới thiệu chương. Ví dụ này đặt 500 miligiây cho slide đầu và 1.200 miligiây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Phối hợp chuyển với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/cpp/export-to-html5/), hoặc [video](/slides/vi/cpp/convert-powerpoint-to-video/), đặt thời lượng chuyển chính xác trước khi xuất để khớp với tốc độ mong muốn. Ví dụ, sử dụng chuyển fade 600 miligiây giữa các cảnh, và điều chỉnh độ trễ chuyển của mỗi slide riêng biệt để cho phép thời gian cho phần thuyết minh hoặc nội dung.

Đối với GIF và video, đồng bộ tốc độ khung ảnh đầu ra với thời lượng hiệu ứng: 600 miligiây tương đương 18 khung ở 30 fps. Trong HTML5, bật chuyển động hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ của định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đã tồn tại**

Gọi [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) trước khi sửa đổi chuyển để xác định liệu có giá trị rõ ràng được lưu không. Giá trị `-1` nghĩa là không có thời lượng cụ thể; giá trị không âm chỉ thời lượng đã lưu tính bằng miligiây. Giá trị chưa đặt không phải là thời gian phát thực tế: Aspose.Slides sử dụng kiểu chuyển và giá trị trả về của [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) để xác định thời lượng đó. Đặt kiểu chuyển có thể khởi tạo thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Hiệu ứng Morph**

Hiệu ứng Morph hoạt hình các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo một hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng hiệu ứng Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng được hoạt hình từ trạng thái gốc sang trạng thái đã chỉnh sửa.

Ví dụ sau tạo một slide có hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình bày hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Các loại Morph Transition**

Enumeration [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt hình nội dung:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) hoạt hình văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) hoạt hình văn bản bằng cách khớp các ký tự khi có thể.

Gọi [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) với Morph trước khi truy cập [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). Giá trị trả về sẽ cung cấp giao diện [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/), trong đó phương thức [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) chọn chế độ khớp.

Ví dụ này mở bản trình bày được tạo trong phần trước và cấu hình slide thứ hai sử dụng hoạt hình Morph dựa trên từ.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Đặt các hiệu ứng chuyển**

Một số chuyển cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn khả dụng phụ thuộc vào kiểu chuyển đã chọn. Đặt kiểu trước, sau đó sử dụng giao diện thích hợp trả về bởi [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

Ví dụ dưới áp dụng chuyển Cut cho slide đầu tiên của `input.pptx`. Nó gọi [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) với `true` qua [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) để chuyển bắt đầu từ màn hình đen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của một hiệu ứng chuyển slide không?**

Có. Ưu tiên sử dụng [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) khi bạn cần thời lượng hiệu ứng chính xác tính bằng miligiây. Sử dụng [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) đã định — Slow, Medium, hoặc Fast — là đủ và không có thời lượng rõ ràng được đặt. Các cài đặt này điều khiển hiệu ứng chuyển riêng biệt với độ trễ tự động chuyển.

**Tôi có thể gắn âm thanh vào một hiệu ứng chuyển và lặp lại nó không?**

Có. Gán âm thanh nhúng bằng [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), gọi [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) với StartSound từ enumeration [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/), và bật lặp lại bằng [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một hiệu ứng chuyển cho mọi slide là gì?**

Duyệt qua bộ sưu tập trả về bởi phương thức [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) của bản trình bày và gọi [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) với cùng một giá trị cho mỗi slide. Đặt bất kỳ thời gian và tùy chọn hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm sao tôi kiểm tra được hiệu ứng chuyển hiện đang được đặt trên một slide?**

Gọi [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) trên đối tượng chuyển trả về bởi phương thức [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) của slide. Nó trả về một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); None có nghĩa là không có hiệu ứng chuyển nào được áp dụng.