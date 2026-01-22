---
title: Android で PowerPoint プレゼンテーションをビデオに変換
linktitle: PowerPoint をビデオへ
type: docs
weight: 130
url: /ja/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Java で PowerPoint プレゼンテーションをビデオに変換する方法を学びます。サンプルコードと自動化手法を活用してワークフローを効率化しましょう。"
---

PowerPoint プレゼンテーションをビデオに変換すると、次のメリットがあります

* **アクセシビリティの向上:** すべてのデバイス（プラットフォームに関係なく）はデフォルトでビデオプレーヤーを備えているため、プレゼンテーションアプリケーションよりも動画の再生や開封が容易です。
* **リーチの拡大:** ビデオを通じて多くの視聴者に情報を届けられ、プレゼンテーションでは退屈に感じられる内容でも伝えることができます。ほとんどの調査や統計は、人々が他のコンテンツ形態よりもビデオを視聴・消費する傾向が強く、そういったコンテンツを好むことを示しています。

{{% alert color="primary" %}} 

以下の [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) をご確認ください。ここでは、本稿で説明したプロセスのライブかつ効果的な実装をご紹介しています。

{{% /alert %}} 

## **Aspose.Slides における PowerPoint からビデオへの変換**

Aspose.Slides はプレゼンテーションからビデオへの変換をサポートします。

* **Aspose.Slides** を使用して、プレゼンテーションスライドから一定の FPS（1 秒あたりのフレーム数）に対応するフレームのセットを生成します
* **ffmpeg** などのサードパーティユーティリティ（[java 用](https://github.com/bramp/ffmpeg-cli-wrapper)）を使用して、フレームからビデオを作成します。 

### **PowerPoint をビデオに変換する**

1. POM ファイルに以下を追加します:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```


2. ffmpeg を [こちら](https://ffmpeg.org/download.html) からダウンロードします。

4. PowerPoint からビデオへの Java コードを実行します。

以下の Java コードは、図と 2 つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています:
```java
Presentation presentation = new Presentation();
try {
    // スマイル形状を追加し、アニメーションを付けます
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg バイナリフォルダーを設定します。こちらのページをご覧ください: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```


## **ビデオ エフェクト**

スライド上のオブジェクトにアニメーションを適用したり、スライド間のトランジションを使用したりできます。 

{{% alert color="primary" %}} 

以下の記事もご参照ください: [PowerPoint Animation](https://docs.aspose.com/slides/androidjava/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/androidjava/shape-animation/)、[Shape Effect](https://docs.aspose.com/slides/androidjava/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的にし、ビデオにも同様の効果をもたらします。前述のプレゼンテーションにもう 1 枚スライドとトランジションを追加したコードは次のとおりです:
```java
// スマイル形状を追加し、アニメーションを付けます

// ...

// 新しいスライドを追加し、アニメーション付きのトランジションを設定します

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```


Aspose.Slides はテキストのアニメーションもサポートしています。したがって、オブジェクト上の段落をアニメーション化し、1 秒の遅延で順に表示させます:
```java
Presentation presentation = new Presentation();
try {
    // テキストとアニメーションを追加
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg バイナリフォルダーを設定します。こちらのページをご覧ください: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```


## **ビデオ変換クラス**

PowerPoint からビデオへの変換タスクを実行できるように、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) および [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) はコンストラクタでビデオのフレームサイズを設定できます（後で作成されます）。プレゼンテーションのインスタンスを渡すと `Presentation.SlideSize` が使用され、生成されたアニメーションは [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) で使用されます。

アニメーションが生成されると、各後続アニメーションに対して `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) パラメータが渡されます。後者は個別アニメーション用のプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/) を操作するには、[Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（アニメーションの合計時間）プロパティと [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) メソッドを使用します。各アニメーション位置は *0 から duration* の範囲内で設定され、`GetFrame` メソッドはその瞬間のアニメーション状態に対応する BufferedImage を返します:
```java
Presentation presentation = new Presentation();
try {
    // 笑顔の形状を追加し、アニメーションを付けます
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // 初期アニメーション状態
            try {
                // 初期アニメーション状態のビットマップ
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // アニメーションの最終状態
            try {
                // アニメーションの最後のフレーム
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


すべてのアニメーションを同時に再生させるには、[PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) クラスを使用します。このクラスは [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) インスタンスと FPS をコンストラクタで受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


生成されたフレームはビデオにコンパイルできます。詳細は [Convert PowerPoint to Video](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**

**Entrance**:

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

**Emphasis**:

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

**Exit**:

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

**Motion Paths**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides は [パスワードで保護されたプレゼンテーション](/slides/ja/androidjava/password-protected-presentation/) の取り扱いをサポートしています。このようなファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにしてください。

**Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合可能です。このライブラリはサーバー環境での動作を前提に設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを提供します。

**変換時のプレゼンテーションサイズに制限はありますか？**

Aspose.Slides は実質的に任意のサイズのプレゼンテーションを処理できます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨される場合があります。