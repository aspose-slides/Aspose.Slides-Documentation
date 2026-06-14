---
title: Chuyển đổi bản trình bày PowerPoint sang video trong C++
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/cpp/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bản trình bày sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bản trình bày sang MP4
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
description: "Tìm hiểu cách chuyển đổi bản trình bày PowerPoint sang video trong C++. Khám phá mã mẫu và các kỹ thuật tự động hoá để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bản trình bày PowerPoint sang video, bạn sẽ có  

* **Tăng khả năng tiếp cận:** Tất cả các thiết bị (bất kể nền tảng) đều được cài sẵn trình phát video theo mặc định so với các ứng dụng mở bản trình bày, vì vậy người dùng thấy dễ dàng hơn khi mở hoặc phát video.  
* **Mở rộng phạm vi:** Thông qua video, bạn có thể tiếp cận một lượng lớn khán giả và truyền đạt thông tin có thể sẽ gây nhàm chán nếu chỉ dùng bản trình bày. Hầu hết các khảo sát và thống kê cho thấy mọi người xem và tiêu thụ video nhiều hơn các dạng nội dung khác, và họ thường ưu tiên dạng nội dung này.  

Trong [Aspose.Slides 22.11](https://docs.aspose.com/slides/vi/cpp/aspose-slides-for-cpp-22-11-release-notes/), chúng tôi đã triển khai hỗ trợ chuyển đổi bản trình bày sang video.  

* Sử dụng Aspose.Slides để tạo một tập các khung hình (từ các slide của bản trình bày) tương ứng với một FPS (khung hình mỗi giây) nhất định  
* Sử dụng công cụ bên thứ ba như `ffmpeg` để tạo video dựa trên các khung hình đó.  

## **Chuyển đổi bản trình bày PowerPoint sang Video**

1. Tải ffmpeg [tại đây](https://ffmpeg.org/download.html).  
2. Thêm đường dẫn tới `ffmpeg.exe` vào biến môi trường `PATH`.  
3. Chạy đoạn mã chuyển PowerPoint sang video.  

Đoạn mã C++ sau cho thấy cách chuyển đổi một bản trình bày (gồm một hình và hai hiệu ứng hoạt ảnh) sang video:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một hình cười và sau đó tạo hoạt ảnh cho nó
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Hiệu Ứng Video**

Bạn có thể áp dụng hoạt ảnh cho các đối tượng trên slide và sử dụng chuyển cảnh giữa các slide.  

{{% alert color="primary" %}} 

Bạn có thể muốn xem các bài viết sau: [PowerPoint Animation](https://docs.aspose.com/slides/vi/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/vi/cpp/shape-animation/), và [Shape Effect](https://docs.aspose.com/slides/vi/cpp/shape-effect/).  

{{% /alert %}} 

Hoạt ảnh và chuyển cảnh làm cho slide trình chiếu trở nên hấp dẫn và thú vị hơn — và chúng cũng làm điều tương tự cho video. Hãy thêm một slide và chuyển cảnh nữa vào mã của bản trình bày trước:

```c++
// Thêm một hình cười và tạo hoạt ảnh cho nó

// ...

// Thêm một slide mới và chuyển cảnh có hoạt ảnh

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

    // Chuyển các khung hình thành video
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Các Lớp Chuyển Đổi Video**

Để cho phép bạn thực hiện các tác vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_animations_generator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_player/).  

PresentationAnimationsGenerator cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau này) thông qua hàm khởi tạo. Nếu bạn truyền một thể hiện của bản trình bày, `Presentation.SlideSize` sẽ được sử dụng và nó sẽ tạo ra các hoạt ảnh mà [PresentationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_player/) sử dụng.  

Khi các hoạt ảnh được tạo, một sự kiện `NewAnimation` sẽ được sinh ra cho mỗi hoạt ảnh tiếp theo, kèm theo tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player/). Tham số này là một lớp đại diện cho trình phát một hoạt ảnh riêng biệt.  

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player/), thuộc tính [get_Duration](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (thời lượng đầy đủ của hoạt ảnh) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) được sử dụng. Mỗi vị trí hoạt ảnh được đặt trong khoảng *0 đến duration*, sau đó phương thức `GetFrame` sẽ trả về một Bitmap tương ứng với trạng thái hoạt ảnh tại thời điểm đó.  

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // trạng thái hoạt ảnh ban đầu
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap trạng thái hoạt ảnh ban đầu

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // trạng thái cuối cùng của hoạt ảnh
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // khung hình cuối cùng của hoạt ảnh
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một hình cười và tạo hoạt ảnh cho nó
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

Để cho tất cả các hoạt ảnh trong một bản trình bày phát đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_player/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.presentation_animations_generator/) và FPS cho các hiệu ứng trong hàm khởi tạo, sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt ảnh để chúng được phát:  

```c++
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

Sau đó các khung hình đã tạo có thể được biên dịch thành video. Xem phần [Convert PowerPoint to Video](https://docs.aspose.com/slides/vi/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).  

## **Các Hoạt Ảnh và Hiệu Ứng Được Hỗ Trợ**

**Đầu vào**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
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

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
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

**Kết thúc**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
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

**Đường dẫn chuyển động**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Có thể chuyển đổi các bản trình bày được bảo mật bằng mật khẩu không?**  

Có, Aspose.Slides cho phép làm việc với [password-protected presentations](/slides/vi/cpp/password-protected-presentation/). Khi xử lý các tệp như vậy, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bản trình bày.  

**Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?**  

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt tệp.  

**Có giới hạn kích thước nào cho bản trình bày khi chuyển đổi không?**  

Aspose.Slides có khả năng xử lý các bản trình bày có kích thước gần như không giới hạn. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống và đôi khi nên tối ưu hóa bản trình bày để cải thiện hiệu suất.