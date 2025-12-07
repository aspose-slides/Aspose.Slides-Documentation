---
title: C++ で PowerPoint プレゼンテーションをビデオに変換する
linktitle: PowerPoint をビデオに変換
type: docs
weight: 130
url: /ja/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- PPT を変換
- PPTX を変換
- PowerPoint からビデオへ
- プレゼンテーション からビデオへ
- PPT からビデオへ
- PPTX からビデオへ
- PowerPoint から MP4 へ
- プレゼンテーション から MP4 へ
- PPT から MP4 へ
- PPTX から MP4 へ
- PPT を MP4 として保存
- PPTX を MP4 として保存
- PPT を MP4 にエクスポート
- PPTX を MP4 にエクスポート
- ビデオ変換
- PowerPoint
- C++
- Aspose.Slides
description: "C++ で PowerPoint プレゼンテーションをビデオに変換する方法を学びます。サンプルコードと自動化手法を活用して、ワークフローを効率化しましょう。"
---

## **概要**

PowerPointプレゼンテーションをビデオに変換することで、次のメリットが得られます

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションに比べ、すべてのデバイス（プラットフォームを問わず）にはデフォルトでビデオプレーヤーが搭載されているため、ユーザーはビデオの再生や開くことが容易になります。
* **リーチの拡大:** ビデオを通じて大規模な視聴者にリーチし、プレゼンテーションでは退屈に感じられる情報も効果的に伝えることができます。調査や統計によれば、人々は他のコンテンツ形態よりもビデオを視聴・消費する傾向が強く、一般的にビデオコンテンツを好みます。

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), we implemented support for presentation to video conversion. 

* Aspose.Slides を使用して、特定の FPS（フレーム/秒）に対応するフレームセット（プレゼンテーションのスライドから）を生成します
* `ffmpeg` のようなサードパーティユーティリティを使用して、フレームからビデオを作成します。

## **PowerPoint プレゼンテーションをビデオに変換する**

1. ffmpeg を[こちら](https://ffmpeg.org/download.html)からダウンロードします。
2. 環境変数 `PATH` に `ffmpeg.exe` のパスを追加します。
3. PowerPoint からビデオへの変換コードを実行します。

この C++ コードは、図と 2 つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています:
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

    // 笑顔のシェイプを追加し、その後アニメーションを付けます
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


## **ビデオ効果**

スライド上のオブジェクトにアニメーションを適用し、スライド間のトランジションを使用できます。

{{% alert color="primary" %}} 

以下の記事をご覧ください: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), および [Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的で面白くします—ビデオでも同様です。前回のプレゼンテーションのコードにもう一枚のスライドとトランジションを追加しましょう:
```c++
// 笑顔のシェイプを追加し、アニメーションを付けます

// ...

// 新しいスライドとアニメーション付きのトランジションを追加します

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides はテキストのアニメーションもサポートしています。そのため、オブジェクト上の段落をアニメーションさせ、1 秒の遅延で順番に表示させます:
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

    // テキストとアニメーションを追加します
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

    // フレームをビデオに変換します
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


## **ビデオ変換クラス**

PowerPoint からビデオへの変換タスクを実行できるよう、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) と [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) クラスを提供します。

PresentationAnimationsGenerator は、コンストラクタでビデオのフレームサイズ（後で作成される）を設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize` が使用され、[PresentationPlayer] が使用するアニメーションが生成されます。 

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer] パラメータが渡されます。後者は個別アニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer] を操作するには、[get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（アニメーションの全期間）プロパティと [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態に対応する Bitmap を返します。
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // 初期アニメーション状態
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // 初期アニメーション状態のビットマップ

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // アニメーションの最終状態
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // アニメーションの最終フレーム
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 笑顔のシェイプを追加し、アニメーションを付けます
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


プレゼンテーション内のすべてのアニメーションを同時に再生するには、[PresentationPlayer] クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator] のインスタンスとエフェクトの FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
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


生成されたフレームはビデオにコンパイルできます。[Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご覧ください。

## **サポートされているアニメーションとエフェクト**


**開始**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
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

| アニメーションタイプ | Aspose.Slides | PowerPoint |
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

| アニメーションタイプ | Aspose.Slides | PowerPoint |
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


**動作パス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |


## **よくある質問**

**パスワードで保護されたプレゼンテーションを変換することは可能ですか？**

はい、Aspose.Slides は[パスワード保護されたプレゼンテーション](/slides/ja/cpp/password-protected-presentation/)の操作をサポートしています。これらのファイルを処理する際は、プレゼンテーションの内容にアクセスできるよう正しいパスワードを提供する必要があります。

**Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合できます。このライブラリはサーバー環境での動作を想定して設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを確保します。

**変換時にプレゼンテーションのサイズに制限はありますか？**

Aspose.Slides は事実上任意のサイズのプレゼンテーションを処理できます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。