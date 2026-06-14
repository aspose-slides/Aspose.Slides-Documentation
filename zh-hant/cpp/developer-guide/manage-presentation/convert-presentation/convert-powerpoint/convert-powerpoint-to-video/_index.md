---
title: 在 C++ 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/cpp/convert-powerpoint-to-video/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉影片
- 簡報轉影片
- PPT 轉影片
- PPTX 轉影片
- PowerPoint 轉 MP4
- 簡報轉 MP4
- PPT 轉 MP4
- PPTX 轉 MP4
- 將 PPT 儲存為 MP4
- 將 PPTX 儲存為 MP4
- 匯出 PPT 為 MP4
- 匯出 PPTX 為 MP4
- 影片轉換
- PowerPoint
- C++
- Aspose.Slides
description: "了解如何在 C++ 中將 PowerPoint 簡報轉換為影片。探索範例程式碼與自動化技術，以簡化您的工作流程。"
---
## **簡介**

將您的 PowerPoint 簡報轉換為影片，可獲得 

* **提升可存取性:** 所有裝置（不論平台）預設皆內建影片播放器，相較於簡報開啟程式，使用者更容易開啟或播放影片。
* **更廣的觸及:** 透過影片，您可以觸及大量受眾，並向他們傳遞在簡報中可能顯得枯燥的資訊。大多數調查與統計顯示，人們觀看與消費影片的比例高於其他內容形式，且普遍較偏好此類內容。

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/zh-hant/cpp/aspose-slides-for-cpp-22-11-release-notes/)，我們實作了簡報轉影片的支援。 

* 使用 Aspose.Slides 產生一組對應特定 FPS（每秒影格數）的影格（取自簡報投影片）
* 使用第三方工具（如 `ffmpeg`）依據這些影格建立影片。

## **將 PowerPoint 簡報轉換為影片**

1. 從此處下載 ffmpeg [here](https://ffmpeg.org/download.html)。
2. 將 `ffmpeg.exe` 的路徑加入環境變數 `PATH`。
3. 執行 PowerPoint 轉影片程式碼。

以下 C++ 程式碼示範如何將包含圖形與兩個動畫效果的簡報轉換為影片：

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

    // 添加笑臉圖形，然後為其設定動畫
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

## **影片特效**

您可以對投影片中的物件套用動畫，並使用投影片間的轉場。

{{% alert color="primary" %}} 

您可能想參考以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/zh-hant/cpp/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/zh-hant/cpp/shape-animation/)，以及 [Shape Effect](https://docs.aspose.com/slides/zh-hant/cpp/shape-effect/)。

{{% /alert %}} 

動畫與轉場使簡報更具吸引力與趣味——對影片亦同。讓我們在先前簡報的程式碼中加入另一張投影片及轉場：

```c++
// 添加笑臉圖形並為其設定動畫

// ...

// 添加新投影片並設定動畫過渡

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides 亦支援文字動畫。因此我們對物件上的段落進行動畫，使其依序出現（延遲設定為 1 秒）：

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

    // 添加文字和動畫
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

    // 將影格轉換為影片
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

## **影片轉換類別**

為了讓您執行 PowerPoint 轉影片的任務，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.presentation_animations_generator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.presentation_player/) 類別。

PresentationAnimationsGenerator 允許您透過建構函式設定稍後將建立的影片之影格尺寸。若傳入簡報實例，將使用 `Presentation.SlideSize`，並產生供 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.presentation_player/) 使用的動畫。

產生動畫時，會為每個後續動畫觸發 `NewAnimation` 事件，該事件帶有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.i_presentation_animation_player/) 參數。後者是代表單一動畫播放器的類別。

若要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.i_presentation_animation_player/)，使用 `get_Duration`（動畫完整持續時間）屬性與 `SetTimePosition` 方法。每個動畫位置設定於 *0 到 duration* 範圍內，然後 `GetFrame` 方法會回傳對應該時刻動畫狀態的 Bitmap。

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // 初始動畫狀態
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // 初始動畫狀態位圖

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // 動畫的最終狀態
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // 動畫的最後影格
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 新增笑臉圖形並為其設定動畫
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

若要讓簡報中的所有動畫同時播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.presentation_player/) 類別。此類別在建構函式中接受一個 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.presentation_animations_generator/) 實例與特效的 FPS，然後對所有動畫呼叫 `FrameTick` 事件以播放它們：

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

接著可將產生的影格編譯成影片。請參閱 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh-hant/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) 章節。

## **支援的動畫與特效**

**進入**：

| 動畫類型 | Aspose.Slides | PowerPoint |
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

**強調**：

| 動畫類型 | Aspose.Slides | PowerPoint |
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

**退出**：

| 動畫類型 | Aspose.Slides | PowerPoint |
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

**運動路徑：**

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **常見問題**

**是否可以轉換受密碼保護的簡報？**

是的，Aspose.Slides 支援操作[受密碼保護的簡報](/slides/zh-hant/cpp/password-protected-presentation/)。在處理此類檔案時，您需要提供正確的密碼，以便程式庫能存取簡報內容。

**Aspose.Slides 是否支援在雲端解決方案中使用？**

是的，Aspose.Slides 可整合至雲端應用程式與服務。程式庫設計可在伺服器環境中執行，確保高效能與可擴充性，適合批次處理檔案。

**在轉換過程中，簡報的大小是否有限制？**

Aspose.Slides 能處理實質上任意大小的簡報。然而，處理極大檔案時可能需要額外的系統資源，建議視需要最佳化簡報以提升效能。