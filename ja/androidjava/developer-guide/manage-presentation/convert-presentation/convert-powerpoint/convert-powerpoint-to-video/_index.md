---
title: PowerPointを動画に変換する
type: docs
weight: 130
url: /ja/androidjava/convert-powerpoint-to-video/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, 動画, MP4, PPTから動画, PPTからMP4, Java, Aspose.Slides"
description: "JavaでPowerPointを動画に変換する"
---

PowerPointプレゼンテーションを動画に変換することで、次のようなメリットがあります。

* **アクセシビリティの向上:** すべてのデバイス（プラットフォームに関係なく）は、プレゼンテーション用アプリケーションと比べてデフォルトで動画プレーヤーを備えているため、ユーザーは動画を簡単に開いたり再生したりできます。
* **リーチの拡大:** 動画を通じて、大規模なオーディエンスに情報を届けることができ、プレゼンテーションでは退屈に見えるかもしれない情報も対象にできます。ほとんどの調査や統計は、人々が他のコンテンツ形式よりも動画を視聴し消費することを示しており、一般的に彼らはそのようなコンテンツを好みます。

{{% alert color="primary" %}} 

ここで説明されているプロセスのライブで効果的な実装である[**PowerPointから動画へのオンライン変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-word)を確認することをお勧めします。

{{% /alert %}} 

## **Aspose.SlidesにおけるPowerPointから動画への変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/) では、プレゼンテーションから動画への変換をサポートしました。

* **Aspose.Slides**を使用して、特定のFPS（フレーム毎秒）に対応するフレームのセット（プレゼンテーションスライドから）を生成します。
* **ffmpeg**（[Java用](https://github.com/bramp/ffmpeg-cli-wrapper)）のようなサードパーティのユーティリティを使用して、フレームに基づいて動画を作成します。

### **PowerPointを動画に変換する**

1. POMファイルにこれを追加します:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpegを[ここ](https://ffmpeg.org/download.html)からダウンロードします。

4. PowerPointから動画へのJavaコードを実行します。

このJavaコードは、図と2つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    // 笑顔の形状を追加し、アニメーションを設定
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

    // ffmpegバイナリフォルダーを設定します。 このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **動画効果**

スライド上のオブジェクトにアニメーションを適用し、スライド間のトランジションを使用できます。 

{{% alert color="primary" %}} 

これらの記事もご覧ください: [PowerPointアニメーション](https://docs.aspose.com/slides/androidjava/powerpoint-animation/)、[形状アニメーション](https://docs.aspose.com/slides/androidjava/shape-animation/)、および[形状効果](https://docs.aspose.com/slides/androidjava/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的で興味深いものにし、動画にも同じ効果をもたらします。前のプレゼンテーションのコードに別のスライドとトランジションを追加しましょう：

```java
// 笑顔の形状を追加し、アニメーションを設定

// ...

// 新しいスライドとアニメーションされたトランジションを追加

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slidesはテキストのアニメーションもサポートしています。したがって、オブジェクトの段落をアニメーションさせることができ、これらは1秒の遅延で順番に表示されます：

```java
Presentation presentation = new Presentation();
try {
    // テキストとアニメーションを追加
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("テキストを含むPowerPointプレゼンテーションを動画に変換する"));

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

    // ffmpegバイナリフォルダーを設定します。 このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **動画変換クラス**

PowerPointから動画への変換タスクを実行できるように、Aspose.Slidesは、[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/)および[PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/)クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/)は、そのコンストラクタを通じて動画（後で作成される）用のフレームサイズを設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize`が使用され、[PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/)が使用するアニメーションが生成されます。

アニメーションが生成されると、各後続のアニメーションに対して`NewAnimation`イベントが生成され、これには[IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/)パラメーターがあります。後者は、別のアニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/)で作業するには、[Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（アニメーションの総持続時間）プロパティと[SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-)メソッドが使用されます。各アニメーション位置は*0からduration*の範囲内で設定され、その後、`GetFrame`メソッドはその時点でのアニメーション状態に対応するBufferedImageを返します：

```java
Presentation presentation = new Presentation();
try {
    // 笑顔の形状を追加し、アニメーションを設定
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
            System.out.println(String.format("アニメーションの総持続時間: %f", animationPlayer.getDuration()));
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

プレゼンテーション内のすべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/)クラスを使用します。このクラスは、[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/)インスタンスと効果のFPSをそのコンストラクタに取り、すべてのアニメーションを再生するために`FrameTick`イベントを呼び出します：

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

生成されたフレームは、動画を作成するためにコンパイルできます。 [PowerPointを動画に変換する](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video)セクションを参照してください。

## **サポートされているアニメーションと効果**

**登場**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ホイール** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **成長と回転** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スウィブル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンス** | ![サポートされています](v.png) | ![サポートされています](v.png) |

**強調**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **パルス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **カラー パルス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ティータ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スピン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **成長/縮小** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **脱色** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **暗くする** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **明るくする** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **透明度** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **オブジェクトカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **補色** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **線の色** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **塗りつぶしの色** | ![サポートされていません](x.png) | ![サポートされています](v.png) |

**退出**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **縮小と回転** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スウィブル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンス** | ![サポートされています](v.png) | ![サポートされています](v.png) |

**モーションパス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **線** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **弧** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ターン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ループ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **カスタムパス** | ![サポートされています](v.png) | ![サポートされています](v.png) |