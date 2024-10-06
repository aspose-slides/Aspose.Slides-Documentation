---
title: PowerPointをビデオに変換する
type: docs
weight: 130
url: /ja/java/convert-powerpoint-to-video/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, ビデオ, MP4, PPTをビデオに, PPTをMP4に, Java, Aspose.Slides"
description: "JavaでPowerPointをビデオに変換する"
---

PowerPointプレゼンテーションをビデオに変換すると、次のような利点があります。

* **アクセシビリティの向上:** すべてのデバイス（プラットフォームに関係なく）は、プレゼンテーションを開くアプリケーションと比べてデフォルトでビデオプレーヤーを備えているため、ユーザーはビデオを開いたり再生したりするのが簡単です。
* **リーチの拡大:** ビデオを通じて、多くのオーディエンスに情報を届けることができ、プレゼンテーションでは退屈に思えるかもしれない情報をターゲットにできます。ほとんどの調査や統計は、人々が他の形式のコンテンツよりもビデオをより多く視聴し消費することを示しており、一般的にこのようなコンテンツを好む傾向があります。

{{% alert color="primary" %}} 

ここで説明されているプロセスのライブで効果的な実装である[**PowerPointをビデオに変換するオンラインコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-word)をチェックすることをお勧めします。

{{% /alert %}} 

## **Aspose.SlidesでのPowerPointからビデオへの変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/)では、プレゼンテーションからビデオへの変換のサポートを実装しました。

* **Aspose.Slides**を使用して、特定のFPS（フレーム毎秒）に対応するスライドからのフレームセットを生成します。
* **ffmpeg**のようなサードパーティユーティリティを使用して、そのフレームに基づいてビデオを作成します。

### **PowerPointをビデオに変換する**

1. これをPOMファイルに追加します：
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpegを[こちら](https://ffmpeg.org/download.html)からダウンロードします。

4. PowerPointをビデオに変換するJavaコードを実行します。

このJavaコードは、図と2つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    // 笑顔の形状を追加し、それをアニメーション化する
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

    // ffmpegバイナリフォルダを設定します。詳細については、こちらのページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **ビデオ効果**

スライド上のオブジェクトにアニメーションを適用したり、スライド間の遷移を使用したりできます。

{{% alert color="primary" %}} 

以下の記事もご覧になることをお勧めします: [PowerPointアニメーション](https://docs.aspose.com/slides/java/powerpoint-animation/)、[形状アニメーション](https://docs.aspose.com/slides/java/shape-animation/)、および[形状効果](https://docs.aspose.com/slides/java/shape-effect/)。

{{% /alert %}} 

アニメーションや遷移は、スライドショーをより魅力的で面白くし、ビデオでも同様の効果を持たせます。以前のプレゼンテーションのコードに別のスライドと遷移を追加しましょう：

```java
// 笑顔の形状を追加し、それをアニメーション化する

// ...

// 新しいスライドを追加し、アニメーション遷移を行う

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slidesは、テキストのアニメーションもサポートしています。したがって、オブジェクトの段落をアニメーション化し、段落が1つずつ（1秒の遅延を設定して）表示されます：

```java
Presentation presentation = new Presentation();
try {
    // テキストとアニメーションを追加します
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("テキストを含むPowerPointプレゼンテーションをビデオに変換"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("段落ごとに"));
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

    // ffmpegバイナリフォルダを設定します。詳細については、こちらのページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

PowerPointからビデオへの変換タスクを実行できるように、Aspose.Slidesは[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/)および[PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/)クラスを提供しています。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/)は、後で作成されるビデオのフレームサイズをそのコンストラクターを通じて設定することを許可します。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize`が使用され、[PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/)が使用するアニメーションが生成されます。

アニメーションが生成されると、各アニメーションごとに`NewAnimation`イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/)パラメーターが付けられます。後者は、別のアニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/)を操作するには、[Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（アニメーションの全体の長さ）プロパティと、[SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-)メソッドが使用されます。各アニメーション位置は*0からduration*の範囲内に設定され、その後`GetFrame`メソッドがその瞬間のアニメーション状態に対応するBufferedImageを返します：

```java
Presentation presentation = new Presentation();
try {
    // 笑顔の形状を追加し、それをアニメーション化する
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
            System.out.println(String.format("アニメーションの総期間: %f", animationPlayer.getDuration()));
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

プレゼンテーション中のすべてのアニメーションを一度に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/)クラスが使用されます。このクラスは、アニメーションの生成器[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/)インスタンスと、効果のFPSをコンストラクターで受け取り、すべてのアニメーションを再生するために`FrameTick`イベントを呼び出します：

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

生成されたフレームは、ビデオを生成するためにコンパイルできます。詳細については、[PowerPointをビデオに変換する](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video)セクションをご覧ください。

## **サポートされているアニメーションと効果**

**入口**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![未サポート](x.png) | ![サポート](v.png) |
| **フェード** | ![サポート](v.png) | ![サポート](v.png) |
| **飛び込む** | ![サポート](v.png) | ![サポート](v.png) |
| **浮いて入る** | ![サポート](v.png) | ![サポート](v.png) |
| **分割** | ![サポート](v.png) | ![サポート](v.png) |
| **ワイプ** | ![サポート](v.png) | ![サポート](v.png) |
| **形状** | ![サポート](v.png) | ![サポート](v.png) |
| **ホイール** | ![サポート](v.png) | ![サポート](v.png) |
| **ランダムバー** | ![サポート](v.png) | ![サポート](v.png) |
| **成長と回転** | ![未サポート](x.png) | ![サポート](v.png) |
| **ズーム** | ![サポート](v.png) | ![サポート](v.png) |
| **スウィベル** | ![サポート](v.png) | ![サポート](v.png) |
| **バウンス** | ![サポート](v.png) | ![サポート](v.png) |

**強調**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **脈動** | ![未サポート](x.png) | ![サポート](v.png) |
| **色の脈動** | ![未サポート](x.png) | ![サポート](v.png) |
| **ティーター** | ![サポート](v.png) | ![サポート](v.png) |
| **スピン** | ![サポート](v.png) | ![サポート](v.png) |
| **成長/縮小** | ![未サポート](x.png) | ![サポート](v.png) |
| **脱色** | ![未サポート](x.png) | ![サポート](v.png) |
| **暗くする** | ![未サポート](x.png) | ![サポート](v.png) |
| **明るくする** | ![未サポート](x.png) | ![サポート](v.png) |
| **透明度** | ![未サポート](x.png) | ![サポート](v.png) |
| **オブジェクトの色** | ![未サポート](x.png) | ![サポート](v.png) |
| **補色** | ![未サポート](x.png) | ![サポート](v.png) |
| **線の色** | ![未サポート](x.png) | ![サポート](v.png) |
| **塗りつぶしの色** | ![未サポート](x.png) | ![サポート](v.png) |

**出口**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![未サポート](x.png) | ![サポート](v.png) |
| **フェード** | ![サポート](v.png) | ![サポート](v.png) |
| **飛び出す** | ![サポート](v.png) | ![サポート](v.png) |
| **浮いて出る** | ![サポート](v.png) | ![サポート](v.png) |
| **分割** | ![サポート](v.png) | ![サポート](v.png) |
| **ワイプ** | ![サポート](v.png) | ![サポート](v.png) |
| **形状** | ![サポート](v.png) | ![サポート](v.png) |
| **ランダムバー** | ![サポート](v.png) | ![サポート](v.png) |
| **縮小して回転** | ![未サポート](x.png) | ![サポート](v.png) |
| **ズーム** | ![サポート](v.png) | ![サポート](v.png) |
| **スウィベル** | ![サポート](v.png) | ![サポート](v.png) |
| **バウンス** | ![サポート](v.png) | ![サポート](v.png) |

**モーションパス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **ライン** | ![サポート](v.png) | ![サポート](v.png) |
| **アーク** | ![サポート](v.png) | ![サポート](v.png) |
| **ターン** | ![サポート](v.png) | ![サポート](v.png) |
| **形状** | ![サポート](v.png) | ![サポート](v.png) |
| **ループ** | ![サポート](v.png) | ![サポート](v.png) |
| **カスタムパス** | ![サポート](v.png) | ![サポート](v.png) |