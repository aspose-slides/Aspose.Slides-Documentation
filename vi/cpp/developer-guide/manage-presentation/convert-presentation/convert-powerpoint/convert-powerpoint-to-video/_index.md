---
title: Chuyển Đổi Bài Thuyết Trình PowerPoint Sang Video trong C++
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/cpp/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bài thuyết trình sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bài thuyết trình sang MP4
- PPT sang MP4
- PPTX sang MP4
- lưu PPT dưới dạng MP4
- lưu PPTX dưới dạng MP4
- xuất PPT sang MP4
- xuất PPTX sang MP4
- chuyển đổi video
- PowerPoint
- C++
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bài thuyết trình PowerPoint sang video trong C++. Khám phá mã mẫu và các kỹ thuật tự động hóa để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bài thuyết trình PowerPoint sang video, bạn sẽ được 

* **Tăng khả năng tiếp cận:** Tất cả các thiết bị (bất kể nền tảng) đều được trang bị trình phát video theo mặc định so với các ứng dụng mở bài thuyết trình, vì vậy người dùng dễ dàng mở hoặc phát video hơn.
* **Mở rộng phạm vi tiếp cận:** Thông qua video, bạn có thể tiếp cận một lượng lớn khán giả và truyền tải thông tin mà nếu dùng bài thuyết trình có thể sẽ khiến người xem cảm thấy nhàm chán. Hầu hết các khảo sát và thống kê cho thấy mọi người xem và tiêu thụ video nhiều hơn các dạng nội dung khác, và họ thường ưu tiên nội dung dạng này.

Trong [Aspose.Slides 22.11](https://docs.aspose.com/slides/vi/cpp/aspose-slides-for-cpp-22-11-release-notes/), chúng tôi đã triển khai hỗ trợ chuyển đổi bài thuyết trình sang video. 

* Sử dụng Aspose.Slides để tạo một tập khung hình (từ các slide của bài thuyết trình) tương ứng với một tốc độ FPS (khung hình mỗi giây) nhất định
* Sử dụng công cụ của bên thứ ba như `ffmpeg` để tạo video dựa trên các khung hình.

## **Chuyển đổi PowerPoint sang Video**

1. Tải ffmpeg [tại đây](https://ffmpeg.org/download.html).
2. Thêm đường dẫn đến `ffmpeg.exe` vào biến môi trường `PATH`.
3. Chạy mã chuyển đổi PowerPoint sang video.

Đoạn mã C++ này cho bạn thấy cách chuyển một bài thuyết trình (có hình ảnh và hai hiệu ứng hoạt ảnh) sang video:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một hình mặt cười và sau đó tạo hoạt ảnh cho nó
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Hiệu ứng video**

Bạn có thể áp dụng hoạt ảnh cho các đối tượng trên slide và sử dụng chuyển tiếp giữa các slide.

{{% alert color="info" %}} 

Bạn có thể muốn xem các bài viết sau: [Hoạt ảnh PowerPoint](https://docs.aspose.com/slides/vi/cpp/powerpoint-animation/), [Hoạt ảnh Hình dạng](https://docs.aspose.com/slides/vi/cpp/shape-animation/), và [Hiệu ứng Hình dạng](https://docs.aspose.com/slides/vi/cpp/shape-effect/).

{{% /alert %}} 

Hoạt ảnh và chuyển tiếp làm cho slideshow trở nên hấp dẫn và thú vị hơn — và chúng cũng có tác dụng tương tự đối với video. Hãy thêm một slide và chuyển tiếp nữa vào mã của bài thuyết trình trước:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// Thêm một hình mặt cười và tạo hoạt ảnh cho nó như được hiển thị ở trên
auto presentation = System::MakeObject<Presentation>();

// Thêm một slide mới và chuyển tiếp hoạt ảnh

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides cũng hỗ trợ hoạt ảnh cho văn bản. Vì vậy chúng tôi sẽ tạo hoạt ảnh cho các đoạn văn bản trên đối tượng, các đoạn sẽ xuất hiện lần lượt (với độ trễ được đặt là một giây):

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm văn bản và hoạt ảnh
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Chuyển đổi các khung hình thành video
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Các lớp chuyển đổi video**

Để cho phép bạn thực hiện các tác vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_animations_generator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator cho phép bạn đặt kích thước khung hình cho video (sẽ được tạo sau) thông qua constructor của nó. Nếu bạn truyền một thể hiện của bài thuyết trình, `Presentation.SlideSize` sẽ được sử dụng và nó tạo ra các hoạt ảnh mà [PresentationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_player/) sử dụng. 

Khi các hoạt ảnh được tạo, một sự kiện `NewAnimation` sẽ được tạo cho mỗi hoạt ảnh tiếp theo, với tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player/). Lớp này đại diện cho một trình phát cho một hoạt ảnh riêng biệt.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player/), thuộc tính [get_Duration](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (thời lượng đầy đủ của hoạt ảnh) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) được sử dụng. Mỗi vị trí hoạt ảnh được đặt trong khoảng *0 đến duration*, và sau đó phương thức `GetFrame` sẽ trả về một Bitmap tương ứng với trạng thái hoạt ảnh tại thời điểm đó.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // trạng thái ban đầu của hoạt ảnh
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // bitmap trạng thái ban đầu của hoạt ảnh

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // trạng thái cuối cùng của hoạt ảnh
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // khung hình cuối cùng của hoạt ảnh
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một hình mặt cười và tạo hoạt ảnh cho nó
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

Để tất cả các hoạt ảnh trong một bài thuyết trình phát đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_player/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_animations_generator/) và FPS cho các hiệu ứng trong constructor và sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt ảnh để chúng được phát:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

Sau đó các khung hình đã tạo có thể được biên dịch lại để tạo thành video. Xem phần [Convert PowerPoint to Video](https://docs.aspose.com/slides/vi/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các hoạt ảnh và hiệu ứng được hỗ trợ**


**Vào**:

| Loại hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**Nhấn mạnh**:

| Loại hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Thoát**:

| Loại hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Đường di chuyển**:

| Loại hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Câu hỏi thường gặp**

### Có thể chuyển đổi các bài thuyết trình được bảo vệ bằng mật khẩu không?

Có, Aspose.Slides cho phép làm việc với [bài thuyết trình được bảo vệ bằng mật khẩu](/slides/vi/cpp/password-protected-presentation/). Khi xử lý các tệp này, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bài thuyết trình.

### Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu suất cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

### Có giới hạn kích thước nào cho bài thuyết trình khi chuyển đổi không?

Aspose.Slides có khả năng xử lý các bài thuyết trình có kích thước gần như bất kỳ. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống, và đôi khi nên tối ưu hoá bài thuyết trình để cải thiện hiệu năng.