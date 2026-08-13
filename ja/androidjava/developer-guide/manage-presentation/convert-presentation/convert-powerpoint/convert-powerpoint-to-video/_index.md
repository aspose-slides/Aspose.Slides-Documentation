---
title: Android で PowerPoint プレゼンテーションをビデオに変換
linktitle: PowerPoint からビデオへ
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
description: "Java で PowerPoint プレゼンテーションをビデオに変換する方法を学びます。サンプルコードと自動化テクニックを活用してワークフローを効率化しましょう。"
---
## **はじめに**

PowerPoint プレゼンテーションをビデオに変換することで、次のメリットが得られます

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションに比べ、すべてのデバイス（プラットフォームに関係なく）はデフォルトでビデオプレーヤーが搭載されているため、ユーザーはビデオを開いたり再生したりしやすくなります。
* **リーチの拡大:** ビデオを通じて多くの視聴者にリーチし、プレゼンテーションでは退屈に感じられるかもしれない情報を提供できます。ほとんどの調査や統計は、動画が他のコンテンツ形態よりも視聴・消費されやすく、一般的に好まれていることを示しています。

## **Aspose.Slides における PowerPoint からビデオへの変換**

Aspose.Slides はプレゼンテーションからビデオへの変換をサポートしています。

* **Aspose.Slides** を使用して、特定の FPS（フレーム/秒）に対応するフレームセット（プレゼンテーションのスライドから）を生成します
* **ffmpeg** のようなサードパーティユーティリティ（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）を使用して、フレームを元にビデオを作成します。 

### **PowerPoint をビデオに変換**

1. POM ファイルに以下を追加してください:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg を [ここ](https://ffmpeg.org/download.html) からダウンロードしてください。

3. PowerPoint をビデオに変換する Java コードを実行します。

この Java コードは、図と 2 つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // スマイル形状を追加し、次にアニメーションを適用します
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

    // ffmpeg バイナリのフォルダを設定します。こちらのページをご参照ください: https://github.com/bramp/ffmpeg-cli-wrapper
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
以下の記事もご覧ください: [PowerPoint アニメーション](https://docs.aspose.com/slides/ja/androidjava/powerpoint-animation/)、[シェイプ アニメーション](https://docs.aspose.com/slides/ja/androidjava/shape-animation/)、および [シェイプ エフェクト](https://docs.aspose.com/slides/ja/androidjava/shape-effect/)。
{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的で面白くします—ビデオでも同様です。前のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```java
import com.aspose.slides.*;
import java.awt.Color;

// 上記で作成したアニメーション付きスマイル形状を含むプレゼンテーション。
Presentation presentation = new Presentation();
try {
    // 新しいスライドとアニメーション付きトランジションを追加

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides はテキストのアニメーションもサポートしています。オブジェクト上の段落にアニメーションを付け、1 秒の遅延で順に表示されるようにします:
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

    // ffmpeg バイナリ フォルダを設定します。こちらのページをご参照ください: https://github.com/bramp/ffmpeg-cli-wrapper
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

PowerPoint をビデオに変換するタスクを実行できるように、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationplayer/) クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationanimationsgenerator/) は、コンストラクタを通じてビデオのフレームサイズ（後で作成される）を設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationplayer/) が使用するアニメーションが生成されます。

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationanimationplayer/) パラメータが渡されます。後者は、個別のアニメーション用プレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationanimationplayer/) を使用するには、[Duration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（アニメーションの全体時間）プロパティと [SetTimePosition](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`getFrame` メソッドはその時点のアニメーション状態に対応する [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) を返します:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // スマイル形状を追加し、アニメーションを適用します
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
            // アニメーションの最終フレーム
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // アニメーションを生成します。上記のコールバックはそれぞれに対して実行されます。
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

プレゼンテーション内のすべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationplayer/) クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationanimationsgenerator/) のインスタンスとエフェクト用の FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
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

生成されたフレームはビデオにコンパイルできます。詳しくは [PowerPoint をビデオに変換](https://docs.aspose.com/slides/ja/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) のセクションをご覧ください。

## **サポートされているアニメーションとエフェクト**

**開始**:

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![not supported](x.png) | ![supported](v.png) |
| **フェード** | ![supported](v.png) | ![supported](v.png) |
| **フライ イン** | ![supported](v.png) | ![supported](v.png) |
| **フロート イン** | ![supported](v.png) | ![supported](v.png) |
| **スプリット** | ![supported](v.png) | ![supported](v.png) |
| **ワイプ** | ![supported](v.png) | ![supported](v.png) |
| **シェイプ** | ![supported](v.png) | ![supported](v.png) |
| **ホイール** | ![supported](v.png) | ![supported](v.png) |
| **ランダム バー** | ![supported](v.png) | ![supported](v.png) |
| **成長と回転** | ![not supported](x.png) | ![supported](v.png) |
| **ズーム** | ![supported](v.png) | ![supported](v.png) |
| **スイベル** | ![supported](v.png) | ![supported](v.png) |
| **バウンス** | ![supported](v.png) | ![supported](v.png) |

**強調**:

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **パルス** | ![not supported](x.png) | ![supported](v.png) |
| **カラー パルス** | ![not supported](x.png) | ![supported](v.png) |
| **テータ** | ![supported](v.png) | ![supported](v.png) |
| **スピン** | ![supported](v.png) | ![supported](v.png) |
| **拡大/縮小** | ![not supported](x.png) | ![supported](v.png) |
| **彩度低下** | ![not supported](x.png) | ![supported](v.png) |
| **暗くする** | ![not supported](x.png) | ![supported](v.png) |
| **明るくする** | ![not supported](x.png) | ![supported](v.png) |
| **透明度** | ![not supported](x.png) | ![supported](v.png) |
| **オブジェクト カラー** | ![not supported](x.png) | ![supported](v.png) |
| **補色** | ![not supported](x.png) | ![supported](v.png) |
| **ライン カラー** | ![not supported](x.png) | ![supported](v.png) |
| **塗りつぶし カラー** | ![not supported](x.png) | ![supported](v.png) |

**終了**:

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![not supported](x.png) | ![supported](v.png) |
| **フェード** | ![supported](v.png) | ![supported](v.png) |
| **フライ アウト** | ![supported](v.png) | ![supported](v.png) |
| **フロート アウト** | ![supported](v.png) | ![supported](v.png) |
| **スプリット** | ![supported](v.png) | ![supported](v.png) |
| **ワイプ** | ![supported](v.png) | ![supported](v.png) |
| **シェイプ** | ![supported](v.png) | ![supported](v.png) |
| **ランダム バー** | ![supported](v.png) | ![supported](v.png) |
| **縮小と回転** | ![not supported](x.png) | ![supported](v.png) |
| **ズーム** | ![supported](v.png) | ![supported](v.png) |
| **スイベル** | ![supported](v.png) | ![supported](v.png) |
| **バウンス** | ![supported](v.png) | ![supported](v.png) |

**モーション パス**:

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **ライン** | ![supported](v.png) | ![supported](v.png) |
| **アーク** | ![supported](v.png) | ![supported](v.png) |
| **ターン** | ![supported](v.png) | ![supported](v.png) |
| **シェイプ** | ![supported](v.png) | ![supported](v.png) |
| **ループ** | ![supported](v.png) | ![supported](v.png) |
| **カスタム パス** | ![supported](v.png) | ![supported](v.png) |

## **よくある質問**

### パスワードで保護されたプレゼンテーションを変換できますか？

はい、Aspose.Slides は [パスワードで保護されたプレゼンテーション](/slides/ja/androidjava/password-protected-presentation/) の取り扱いをサポートしています。そのようなファイルを処理する際は、正しいパスワードを指定してライブラリがプレゼンテーションの内容にアクセスできるようにする必要があります。

### Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合できます。このライブラリはサーバー環境で動作するよう設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを実現します。

### 変換時にプレゼンテーションのサイズ制限はありますか？

Aspose.Slides は事実上あらゆるサイズのプレゼンテーションを扱うことができます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。