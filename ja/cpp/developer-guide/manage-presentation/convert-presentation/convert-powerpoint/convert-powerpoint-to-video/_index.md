---
title: PowerPointを動画に変換
type: docs
weight: 130
url: /ja/cpp/convert-powerpoint-to-video/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, 動画, MP4, PPTを動画に, PPTをMP4に, C++, Aspose.Slides"
description: "Aspose.Slides for C++ APIを使用してPowerPointを動画に変換"
---

PowerPointプレゼンテーションを動画に変換することで、以下のような利点があります。

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションと比較して、すべてのデバイス（プラットフォームに関係なく）がデフォルトで動画プレーヤーを備えているため、ユーザーは動画を開いたり再生したりするのが簡単です。
* **より多くのリーチ:** 動画を通じて、大規模なオーディエンスに情報を提供でき、プレゼンテーションでは退屈に感じるかもしれない情報を伝えることができます。ほとんどの調査や統計は、人々がその他の形式のコンテンツよりも動画を視聴し消費することを示唆しており、一般的にそのようなコンテンツを好む傾向があります。

## **Aspose.SlidesにおけるPowerPointから動画への変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)では、プレゼンテーションを動画に変換するサポートを実装しました。

* Aspose.Slidesを使用して、特定のFPS（1秒あたりのフレーム数）に対応するフレームのセットを生成します。
* `ffmpeg`などのサードパーティユーティリティを使用して、フレームに基づいて動画を作成します。

### **PowerPointを動画に変換する**

1. ffmpegを[こちら](https://ffmpeg.org/download.html)からダウンロードします。
2. `ffmpeg.exe`のパスを環境変数`PATH`に追加します。
3. PowerPointから動画へのコードを実行します。

以下のC++コードは、図形と2つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています。

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

    // 笑顔の図形を追加し、その後アニメーションを適用
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

## **動画効果**

スライド上のオブジェクトにアニメーションを適用し、スライド間のトランジションを使用できます。

{{% alert color="primary" %}} 

これらの記事もご覧ください: [PowerPointアニメーション](https://docs.aspose.com/slides/cpp/powerpoint-animation/)、[形状アニメーション](https://docs.aspose.com/slides/cpp/shape-animation/)、および[形状効果](https://docs.aspose.com/slides/cpp/shape-effect/)。

{{% /alert %}} 

アニメーションやトランジションにより、スライドショーや動画はより魅力的で興味深くなります。前回のプレゼンテーションのコードにもう1つのスライドとトランジションを追加しましょう。

```c++
// 笑顔の図形を追加し、その後アニメーションを適用

// ...

// 新しいスライドを追加し、アニメーショントランジションを適用

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slidesは、テキストのアニメーションもサポートしています。したがって、オブジェクト上の段落が1つずつ表示されるようにアニメーションを適用します（遅延は1秒に設定されています）。

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

    // テキストとアニメーションを追加
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"テキストを含むPowerPointプレゼンテーションを動画に変換"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"段落ごとに"));
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **動画変換クラス**

PowerPointから動画への変換タスクを実行できるように、Aspose.Slidesは[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/)と[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/)クラスを提供します。

PresentationAnimationsGeneratorは、動画のためにフレームサイズを設定することを可能にし、そのコンストラクターを通じてそれを行います。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize`が使用され、[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/)が使用するアニメーションが生成されます。

アニメーションが生成されると、各後続のアニメーションのために`NewAnimation`イベントが生成され、これが[IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)パラメーターを持ちます。後者は、個別のアニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)を使用するには、[get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91)（アニメーションの全体の持続時間）プロパティと[SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0)メソッドが使用されます。各アニメーション位置は*0から持続時間*の範囲内で設定され、`GetFrame`メソッドはその瞬間のアニメーション状態に対応するBitmapを返します。

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"アニメーションの総持続時間: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // 初期アニメーション状態
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // 初期アニメーション状態のビットマップ

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // アニメーションの最終状態
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // アニメーションの最後のフレーム
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 笑顔の図形を追加し、その後アニメーションを適用
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

プレゼンテーション内のすべてのアニメーションを一度に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/)クラスが使用されます。このクラスは、[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/)インスタンスとエフェクトのFPSをコンストラクターに取り入れ、すべてのアニメーションを再生するために`FrameTick`イベントを呼び出します。

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

生成されたフレームはまとめて動画としてコンパイルされます。[PowerPointを動画に変換する](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video)セクションを参照してください。

## **サポートされるアニメーションと効果**


**登場**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **シェイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ホイール** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **成長と回転** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スイベル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンド** | ![サポートされています](v.png) | ![サポートされています](v.png) |


**強調**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **パルス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **カラーパルス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ティーター** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スピン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **成長/縮小** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **デサチュレート** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ダークン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ライトン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **透明度** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **オブジェクトカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **補完色** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ラインカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フィルカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |

**退出**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **シェイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **縮小と回転** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スイベル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンド** | ![サポートされています](v.png) | ![サポートされています](v.png) |

**モーションパス:**

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **ライン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **アーク** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ターン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **シェイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ループ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **カスタムパス** | ![サポートされています](v.png) | ![サポートされています](v.png) |