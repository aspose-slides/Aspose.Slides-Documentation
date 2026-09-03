---
title: Quản lý chuyển đổi slide trong bản trình chiếu bằng C++
linktitle: Chuyển đổi slide
type: docs
weight: 80
url: /vi/cpp/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tiến tới slide tự động, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho C++."
---
## **Tổng quan**

Chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi chiếu slide. Với Aspose.Slides for C++, bạn có thể chọn hiệu ứng chuyển đổi cho từng slide, cấu hình việc tiến tới bằng nhấp chuột hoặc hẹn giờ, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ C++ để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và truy cập cài đặt chuyển đổi của slide thông qua [get_SlideShowTransition](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Gọi [set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_type/) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ dưới đây áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và việc nhấp chuột có tiến tới buổi chiếu hay không. Các phương thức sau kiểm soát hành vi này:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) cho phép người xem tiến tới bằng cách nhấp chuột.
- [set_AdvanceAfter](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_advanceafter/) bật tiến tới tự động.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) chỉ định độ trễ trước khi tiến tới tự động, tính bằng mili giây.

Kích hoạt cả nhấp chuột và tiến tới theo thời gian để cho phép người xem chuyển tiếp bằng nhấp chuột hoặc chờ hẹn giờ. Để chỉ dùng hẹn giờ, gọi [set_AdvanceOnClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) với `false`. Độ trễ điều khiển thời điểm buổi chiếu tiến tới; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến tới tự động sau 3, 5 và 7 giây, tương ứng. Nhấp chuột cũng có thể tiến tới các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem tiến tới theo thời gian có được bật hay không, gọi [get_AdvanceAfter](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Một độ trễ đã lưu không có nghĩa là hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi hẹn giờ đã bật, và tắt tiến tới tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide đó và lưu các cài đặt đã cập nhật.

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

## **Kiểm soát thời gian chuyển đổi một cách chính xác**

Sử dụng [set_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_duration/) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Phương thức [get_SlideShowTransition](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) của slide cung cấp các cài đặt này qua [ISlideShowTransition](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/):

| Phương pháp | Mục đích |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_duration/) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Đặt độ trễ trước khi slide tiến tới tự động, tính bằng mili giây. Gọi [set_AdvanceAfter](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_advanceafter/) với `true` để kích hoạt hẹn giờ này. |
| [set_Speed](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_speed/) | Chọn một danh mục tốc độ đã định trước từ [TransitionSpeed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium hoặc Fast. Được dùng khi không có thời lượng cụ thể được chỉ định. |

[set_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_duration/) chỉ điều khiển hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tiến tới tự động riêng biệt. Khi không đặt thời lượng cụ thể, Aspose.Slides tính thời lượng hiệu ứng dựa trên kiểu chuyển đổi và giá trị trả về bởi [get_Speed](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Áp dụng cùng thời lượng cho mọi slide**

Để duy trì tốc độ đồng bộ, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitiontype/), và đặt thời lượng mỗi chuyển đổi là 750 mili giây. Nó cũng bật tiến tới tự động sau 5.000 mili giây và tắt tiến tới bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

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

    // Cấu hình tiến tới tự động độc lập với thời lượng hiệu ứng.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Đặt thời lượng khác nhau cho từng slide**

Các slide khác nhau có thể dùng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển đổi ngắn cho slide tiêu đề và chuyển đổi dài hơn cho phần giới thiệu mục. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển đổi với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/cpp/export-to-html5/), hoặc [video](/slides/vi/cpp/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để phù hợp với nhịp điệu mong muốn. Ví dụ, dùng hiệu ứng fade 600 mili giây giữa các cảnh, và điều chỉnh độ trễ tiến tới của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, đồng bộ tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở tốc độ 30 khung hình/giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian mà định dạng xuất hỗ trợ, và xem trước đầu ra để xác nhận sự đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [get_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_duration/) trước khi chỉnh sửa chuyển đổi để xác định liệu có giá trị cụ thể nào được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng; giá trị không âm chỉ thời lượng đã lưu tính bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính: Aspose.Slides sử dụng kiểu chuyển đổi và giá trị trả về bởi [get_Speed](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_speed/) để xác định thời lượng đó. Đặt kiểu chuyển đổi có thể khởi tạo một thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

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

## **Chuyển đổi Morph**

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo một hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng được hoạt ảnh giữa trạng thái gốc và đã chỉnh sửa.

Ví dụ dưới đây tạo một slide chứa một hình chữ nhật văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

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

## **Các loại chuyển đổi Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionmorphtype/) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionmorphtype/) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionmorphtype/) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Gọi [set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_type/) với Morph trước khi truy cập [get_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_value/). Giá trị sau đó cung cấp giao diện [IMorphTransition](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/imorphtransition/), phương thức [set_MorphType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo trong phần trước và cấu hình slide thứ hai sử dụng hoạt ảnh Morph dựa trên từ.

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

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn khả dụng phụ thuộc vào kiểu chuyển đổi đã chọn. Đặt loại trước, sau đó sử dụng giao diện thích hợp được trả về bởi [get_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_value/).

Ví dụ dưới đây áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [set_FromBlack](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) với `true` thông qua [IOptionalBlackTransition](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/ioptionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Có. Ưu tiên sử dụng [set_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_duration/) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Dùng [set_Speed](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_speed/) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionspeed/) đã định trước—Slow, Medium hoặc Fast—đủ và không cần đặt thời lượng cụ thể. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ tiến tới tự động.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại không?**

Có. Gán âm thanh nhúng bằng [set_Sound](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_sound/), gọi [set_SoundMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_soundmode/) với StartSound từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionsoundmode/), và bật lặp lại bằng [set_SoundLoop](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_soundloop/). Âm thanh sẽ lặp lại cho tới khi có sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập trả về bởi phương thức [get_Slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_slides/) của bản trình chiếu và gọi [set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/set_type/) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm sao tôi kiểm tra chuyển đổi hiện tại đã được đặt trên một slide?**

Gọi [get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islideshowtransition/get_type/) trên đối tượng chuyển đổi được trả về bởi phương thức [get_SlideShowTransition](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.