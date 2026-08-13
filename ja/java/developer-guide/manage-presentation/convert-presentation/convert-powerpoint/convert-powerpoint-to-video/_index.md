---
title: JavaでPowerPointプレゼンテーションをビデオに変換
linktitle: PowerPointからビデオへ
type: docs
weight: 130
url: /ja/java/convert-powerpoint-to-video/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PPTを変換
- PPTXを変換
- PowerPointからビデオへ
- プレゼンテーションをビデオへ
- PPTをビデオへ
- PPTXをビデオへ
- PowerPointからMP4へ
- プレゼンテーションをMP4へ
- PPTをMP4へ
- PPTXをMP4へ
- PPTをMP4として保存
- PPTXをMP4として保存
- PPTをMP4にエクスポート
- PPTXをMP4にエクスポート
- ビデオ変換
- PowerPoint
- Java
- Aspose.Slides
description: "JavaでPowerPointプレゼンテーションをビデオに変換する方法を学びます。サンプルコードと自動化テクニックを活用して作業フローを効率化しましょう。"
---
## **概要**

PowerPoint または OpenDocument プレゼンテーションをビデオに変換することで、次のメリットがあります：

**アクセシビリティの向上:** プラットフォームに関係なく、すべてのデバイスにはデフォルトでビデオプレーヤーが搭載されており、従来のプレゼンテーションアプリケーションに比べてユーザーがビデオを開いたり再生したりしやすくなります。

**到達範囲の拡大:** ビデオは、より多くの視聴者にリーチし、情報をより魅力的な形式で提示できるようにします。調査や統計によれば、人々は他の形式よりもビデオコンテンツを視聴・消費することを好むため、メッセージのインパクトが高まります。

{{% alert color="info" %}} 

このプロセスの実装例として、実際に利用可能な[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/ja/video)をご確認いただくことをおすすめします。

{{% /alert %}} 

## **Aspose.Slides における PowerPoint からビデオへの変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/ja/java/aspose-slides-for-java-22-11-release-notes/) では、プレゼンテーションからビデオへの変換機能を実装しました。 

* **Aspose.Slides** を使用して、特定の FPS（1 秒あたりのフレーム数）に対応したフレームのセット（プレゼンテーションスライドから）を生成します
* フレームを基にビデオを作成するために、**ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）などのサードパーティユーティリティを使用します。 

### **PowerPoint をビデオに変換**

1. POM ファイルに以下を追加します:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg を[こちら](https://ffmpeg.org/download.html)からダウンロードします。

4. PowerPoint をビデオに変換する Java コードを実行します。

この Java コードは、図と 2 つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // スマイルシェイプを追加し、アニメーションさせます
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

    // ffmpeg バイナリ フォルダーを設定します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

{{% alert color="info" %}} 

以下の記事をご覧ください: [PowerPoint Animation](https://docs.aspose.com/slides/ja/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ja/java/shape-animation/), および [Shape Effect](https://docs.aspose.com/slides/ja/java/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションは、スライドショーをより魅力的で面白くし、ビデオにも同様の効果をもたらします。前回のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // スマイルシェイプを追加し、アニメーションさせます

    // ...

    // 新しいスライドを追加し、アニメーション付きトランジションを設定します

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides はテキストのアニメーションもサポートしています。そこで、オブジェクト上の段落にアニメーションを付け、1 秒の遅延で順に表示させます:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // テキストとアニメーションを追加します
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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // ffmpeg バイナリ フォルダーを設定します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

PowerPoint からビデオへの変換タスクを実行できるように、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationplayer/) クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationanimationsgenerator/) は、コンストラクタでビデオ（後で作成される）のフレームサイズを設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationplayer/) が使用するアニメーションが生成されます。 

アニメーションが生成されると、各アニメーションに対して `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationanimationplayer/) パラメータが渡されます。後者は個別のアニメーション用プレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationanimationplayer/) を操作するには、アニメーションの総時間を表す [Duration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) プロパティと、位置を設定する [SetTimePosition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`getFrame` メソッドはその時点のアニメーション状態に対応する [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) を返します:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // スマイルシェイプを追加し、アニメーションさせます
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
            // 初期アニメーション状態のビットマップ
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // アニメーションの最終状態
            // アニメーションの最後のフレーム
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // アニメーションを生成します - これは上記で処理されたイベントを発生させるものです
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

すべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationplayer/) クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationanimationsgenerator/) のインスタンスと FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

生成されたフレームはビデオにコンパイルできます。詳細は [Convert PowerPoint to Video](https://docs.aspose.com/slides/ja/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご参照ください。

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

**モーション パス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### パスワードで保護されたプレゼンテーションの変換は可能ですか？

はい、Aspose.Slides は [パスワードで保護されたプレゼンテーション](/slides/ja/java/password-protected-presentation/) の操作をサポートします。これらのファイルを処理する際は、ライブラリがプレゼンテーションの内容にアクセスできるよう正しいパスワードを指定してください。

### Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合可能です。サーバー環境での動作を前提に設計されており、バッチ処理において高いパフォーマンスとスケーラビリティを提供します。

### 変換時にプレゼンテーションのサイズ制限はありますか？

Aspose.Slides は実質的に任意のサイズのプレゼンテーションを処理できます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。