---
title: C++でPowerPointプレゼンテーションを動画に変換する
linktitle: PowerPoint を動画に変換
type: docs
weight: 130
url: /ja/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint を動画に変換
- プレゼンテーションを動画に変換
- PPT を動画に変換
- PPTX を動画に変換
- PowerPoint を MP4 に変換
- プレゼンテーションを MP4 に変換
- PPT を MP4 に変換
- PPTX を MP4 に変換
- PPT を MP4 として保存
- PPTX を MP4 として保存
- PPT を MP4 にエクスポート
- PPTX を MP4 にエクスポート
- 動画変換
- PowerPoint
- C++
- Aspose.Slides
description: C++でPowerPointプレゼンテーションを動画に変換する方法を学びましょう。サンプルコードと自動化手法を活用して、ワークフローを効率化できます。
---
## **はじめに**

PowerPoint プレゼンテーションを動画に変換することで、次のメリットがあります

* **アクセシビリティの向上:** すべてのデバイス（プラットフォームに関係なく）はデフォルトで動画プレーヤーを搭載しているため、プレゼンテーションを開くアプリケーションに比べ、ユーザーは動画の再生や開くことが容易です。
* **リーチの拡大:** 動画を通じて多くの視聴者にリーチでき、プレゼンテーションでは退屈に感じられる情報も効果的に伝えられます。ほとんどの調査や統計では、動画が他のコンテンツ形態よりも多く視聴・消費され、一般的に好まれることが示されています。

[Aspose.Slides 22.11](https://docs.aspose.com/slides/ja/cpp/aspose-slides-for-cpp-22-11-release-notes/) では、プレゼンテーションから動画への変換サポートを実装しました。

* Aspose.Slides を使用して、プレゼンテーションスライドから一定の FPS（1 秒あたりフレーム数）に対応するフレームのセットを生成します
* `ffmpeg` などのサードパーティ製ユーティリティを使用して、フレームから動画を作成します

## **PowerPoint プレゼンテーションを動画に変換する**

1. ffmpeg を [here](https://ffmpeg.org/download.html) からダウンロードしてください。
2. `ffmpeg.exe` のパスを環境変数 `PATH` に追加します。
3. PowerPoint から動画への変換コードを実行します。

以下の C++ コードは、図と 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています:

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

    // スマイル形状を追加し、次にアニメーションを付けます
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

## **動画エフェクト**

スライド上のオブジェクトにアニメーションを適用したり、スライド間のトランジションを使用したりできます。

{{% alert color="info" %}} 

以下の記事をご覧ください: [PowerPoint Animation](https://docs.aspose.com/slides/ja/cpp/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/ja/cpp/shape-animation/)、および [Shape Effect](https://docs.aspose.com/slides/ja/cpp/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションは、スライドショーをより魅力的で面白くし、動画にも同様の効果があります。前のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:

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

// 上記のようにスマイルシェイプを追加し、アニメーションを付けます
// 新しいスライドを追加し、アニメーション付きトランジションを設定します

auto presentation = System::MakeObject<Presentation>();

// Adds a new slide and animated transition

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides はテキストのアニメーションもサポートしています。オブジェクト上の段落にアニメーションを付けると、1 秒の遅延で順に表示されます:

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

    // テキストとアニメーションを追加
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

    // フレームを動画に変換
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

## **動画変換クラス**

PowerPoint から動画への変換タスクを実行できるように、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.presentation_animations_generator/) と [PresentationPlayer](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.presentation_player/) クラスを提供します。

PresentationAnimationsGenerator はコンストラクターで動画（後で作成される）のフレームサイズを設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.presentation_player/) が使用するアニメーションが生成されます。

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.i_presentation_animation_player/) パラメーターが渡されます。後者は個別のアニメーション用プレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.i_presentation_animation_player/) を操作するには、[get_Duration](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（アニメーションの全期間）プロパティと [SetTimePosition](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態に対応する Bitmap を返します。

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
    // 初期アニメーション状態
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // 初期アニメーション状態のビットマップ

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // アニメーションの最終状態
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // アニメーションの最終フレーム
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // スマイルシェイプを追加し、アニメーションを付けます
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

プレゼンテーション内のすべてのアニメーションを同時に再生させるには、[PresentationPlayer](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.presentation_player/) クラスを使用します。このクラスはコンストラクターで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.export.presentation_animations_generator/) インスタンスと FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:

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

生成されたフレームは動画にコンパイルできます。詳細は [Convert PowerPoint to Video](https://docs.aspose.com/slides/ja/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**


**入口**:

| Animation Type | Aspose.Slides | PowerPoint |
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


**強調**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**終了**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**モーション パス**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### パスワードで保護されたプレゼンテーションを変換できますか？

はい、Aspose.Slides は [password-protected presentations](/slides/ja/cpp/password-protected-presentation/) の取り扱いをサポートしています。このようなファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにしてください。

### Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合できます。このライブラリはサーバー環境での動作を想定して設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを提供します。

### 変換時にプレゼンテーションのサイズ制限はありますか？

Aspose.Slides は実質的に任意のサイズのプレゼンテーションを処理できます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。