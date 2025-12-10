---
title: C++ で PowerPoint プレゼンテーションをビデオに変換する
linktitle: PowerPoint をビデオに変換
type: docs
weight: 130
url: /ja/cpp/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint をビデオに変換
- プレゼンテーションをビデオに変換
- PPT をビデオに変換
- PPTX をビデオに変換
- PowerPoint を MP4 に変換
- プレゼンテーションを MP4 に変換
- PPT を MP4 に変換
- PPTX を MP4 に変換
- PPT を MP4 として保存
- PPTX を MP4 として保存
- PPT を MP4 にエクスポート
- PPTX を MP4 にエクスポート
- ビデオ変換
- PowerPoint
- C++
- Aspose.Slides
description: "C++ で PowerPoint プレゼンテーションをビデオに変換する方法を学びます。サンプルコードと自動化手法を活用してワークフローを効率化しましょう。"
---

## **概要**

PowerPoint プレゼンテーションをビデオに変換することで、次のメリットが得られます

* **アクセシビリティの向上:** すべてのデバイス（プラットフォームに関係なく）はデフォルトでビデオプレーヤーが搭載されており、プレゼンテーションを開くアプリケーションに比べて、ユーザーはビデオの再生や開くことが容易です。
* **リーチの拡大:** ビデオを通じて多くの視聴者にリーチでき、プレゼンテーションでは退屈に感じられる情報でも効果的に伝えられます。ほとんどの調査や統計は、人々が他のコンテンツ形態よりもビデオを視聴・消費する傾向があり、一般的にそのようなコンテンツを好むことを示しています。

Aspose.Slides 22.11 のリリース([Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/))で、プレゼンテーションからビデオへの変換サポートを実装しました。

* Aspose.Slides を使用して、特定の FPS（フレーム/秒）に対応するフレームのセット（プレゼンテーション スライドから）を生成します
* `ffmpeg` のようなサードパーティユーティリティを使用して、フレームに基づくビデオを作成します

## **PowerPoint プレゼンテーションをビデオに変換する**

1. ffmpeg を [こちら](https://ffmpeg.org/download.html) からダウンロードします。
2. `ffmpeg.exe` のパスを環境変数 `PATH` に追加します。
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

    // スマイルのシェイプを追加し、アニメーションします
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

スライド上のオブジェクトにアニメーションを適用したり、スライド間でトランジションを使用したりできます。

{{% alert color="primary" %}} 

以下の記事もご覧ください: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/)、[Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的で面白くし、ビデオにも同様の効果をもたらします。前のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```c++
// スマイルシェイプを追加し、アニメーションさせます

// ...

// 新しいスライドを追加し、アニメーション付きトランジションを設定します

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides はテキストのアニメーションもサポートしています。オブジェクト上の段落をアニメーションさせ、1 秒の遅延で順番に表示させます:
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

PowerPoint からビデオへの変換タスクを実行できるように、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) と [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) クラスを提供します。

PresentationAnimationsGenerator はコンストラクターでビデオ（後で作成される）のフレームサイズを設定でき、プレゼンテーション インスタンスを渡すと `Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) が使用するアニメーションを生成します。

アニメーションが生成されると、各連続アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) パラメーターが渡されます。後者は個別アニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/) を使用するには、[get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（アニメーションの総時間）プロパティと [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態に対応する Bitmap を返します。
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

    // スマイル形状を追加し、アニメーションさせます
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


すべてのアニメーションを同時に再生させるには、[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) クラスを使用します。このクラスはコンストラクターで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) インスタンスと FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
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


生成されたフレームはビデオにコンパイルできます。[Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**


**エントランス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Fade** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Fly In** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Float In** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Split** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Wipe** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Shape** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Wheel** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Random Bars** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Grow & Turn** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Zoom** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Swivel** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Bounce** | ![サポート済み](v.png) | ![サポート済み](v.png) |


**強調**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Color Pulse** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Teeter** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Spin** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Grow/Shrink** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Desaturate** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Darken** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Lighten** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Transparency** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Object Color** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Complementary Color** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Line Color** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Fill Color** | ![未サポート](x.png) | ![サポート済み](v.png) |


**終了**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Fade** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Fly Out** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Float Out** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Split** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Wipe** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Shape** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Random Bars** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Shrink & Turn** | ![未サポート](x.png) | ![サポート済み](v.png) |
| **Zoom** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Swivel** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Bounce** | ![サポート済み](v.png) | ![サポート済み](v.png) |


**モーション パス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Arcs** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Turns** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Shapes** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Loops** | ![サポート済み](v.png) | ![サポート済み](v.png) |
| **Custom Path** | ![サポート済み](v.png) | ![サポート済み](v.png) |

## **FAQ**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides は [password-protected presentations](/slides/ja/cpp/password-protected-presentation/) の操作をサポートしています。このようなファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにしてください。

**Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合できます。ライブラリはサーバー環境での動作を前提に設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを提供します。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides は実質的に任意のサイズのプレゼンテーションを処理できます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。