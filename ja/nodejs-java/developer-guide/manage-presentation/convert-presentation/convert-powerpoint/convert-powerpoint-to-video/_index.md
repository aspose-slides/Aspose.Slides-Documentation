---
title: JavaScriptでPowerPointプレゼンテーションを動画に変換する
linktitle: PowerPointから動画へ
type: docs
weight: 130
url: /ja/nodejs-java/convert-powerpoint-to-video/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PPTを変換
- PPTXを変換
- PowerPointから動画へ
- プレゼンテーションから動画へ
- PPTから動画へ
- PPTXから動画へ
- PowerPointからMP4へ
- プレゼンテーションからMP4へ
- PPTからMP4へ
- PPTXからMP4へ
- PPTをMP4として保存
- PPTXをMP4として保存
- PPTをMP4へエクスポート
- PPTXをMP4へエクスポート
- 動画変換
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScriptでPowerPointプレゼンテーションを動画に変換する方法を学びます。サンプルコードと自動化技術を活用してワークフローを効率化しましょう。"
---

PowerPointプレゼンテーションを動画に変換することで、以下のメリットが得られます

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションに比べ、すべてのデバイス（プラットフォームを問わず）にはデフォルトで動画プレーヤーが搭載されているため、ユーザーは動画の再生や開封が容易です。
* **リーチの拡大:** 動画を通じて大規模なオーディエンスに情報を届けることができ、プレゼンテーションでは退屈に感じられるかもしれない情報も効果的に伝えられます。多くの調査や統計は、動画が他のコンテンツ形態よりも視聴・消費されやすく、一般的に好まれることを示しています。

{{% alert color="primary" %}} 

以下の[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) をご確認ください。こちらは本稿で説明したプロセスの実装例です。

{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

Aspose.Slides はプレゼンテーションから動画への変換をサポートします。

* **Aspose.Slides** を使用して、プレゼンテーションのスライドから特定の FPS（1 秒あたりフレーム数）に対応するフレームセットを生成します
* **ffmpeg** などのサードパーティユーティリティ（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）を使用して、フレームから動画を作成します。

### **Convert PowerPoint to Video**

1. ffmpeg を[こちら](https://ffmpeg.org/download.html)からダウンロードします。

2. PowerPoint to video 用の JavaScript コードを実行します。

この JavaScript コードは、図と 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 笑顔のシェイプを追加し、アニメーションを付けます
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg バイナリーフォルダーを設定します。こちらのページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Video Effects**

スライド上のオブジェクトにアニメーションを適用したり、スライド間でトランジションを使用したりできます。

{{% alert color="primary" %}} 

以下の記事をご参照ください: [PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/)、および [Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/)。

{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的で興味深いものにし、動画でも同様の効果があります。前述のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```javascript
// 笑顔のシェイプを追加し、アニメーションを付けます
// ...
// 新しいスライドを追加し、アニメーション付きトランジションを設定します
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides はテキストのアニメーションもサポートしています。オブジェクト上の段落をアニメーションさせ、1 秒の遅延で順に表示させます:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // テキストとアニメーションを追加します
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg バイナリーフォルダーを設定します。こちらのページをご覧ください: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Video Conversion Classes**

PowerPoint から動画への変換タスクを実行できるように、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) は、コンストラクタで動画（後で作成される）のフレームサイズを設定できます。プレゼンテーションのインスタンスを渡すと `Presentation.getSlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) が使用するアニメーションを生成します。

アニメーションが生成されると、各後続アニメーションごとに `NewAnimation` イベントが生成され、プレゼンテーションアニメーションプレーヤー パラメータが渡されます。後者は個別アニメーションのプレーヤーを表すクラスです。

プレゼンテーションアニメーションプレーヤーを操作するには、`getDuration`（アニメーションの全期間）メソッドと `setTimePosition` メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`getFrame` メソッドはその時点のアニメーション状態に対応する BufferedImage を返します:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 笑顔のシェイプを追加し、アニメーションを付けます
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// 初期アニメーション状態
            try {
                // 初期アニメーション状態のビットマップ
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// アニメーションの最終状態
            try {
                // アニメーションの最後のフレーム
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


プレゼンテーション内のすべてのアニメーションを同時に再生させるには、[PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) インスタンスと FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


その後、生成されたフレームをコンパイルして動画を作成できます。詳しくは [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご参照ください。

## **Supported Animations and Effects**

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

**プレゼンテーションがパスワードで保護されている場合、変換は可能ですか？**

はい、Aspose.Slides はパスワード保護されたプレゼンテーションの取り扱いをサポートしています。そのようなファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにしてください。

**Aspose.Slides はクラウドソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides はクラウドアプリケーションやサービスに統合可能です。このライブラリはサーバー環境での動作を前提に設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを提供します。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides は実質的にあらゆるサイズのプレゼンテーションを処理できます。ただし、非常に大容量のファイルを扱う場合は、追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションの最適化が推奨されることがあります。