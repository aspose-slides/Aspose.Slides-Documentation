---
title: PHPでPowerPointプレゼンテーションを動画に変換する
linktitle: PowerPointから動画へ
type: docs
weight: 130
url: /ja/php-java/convert-powerpoint-to-video/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PPTを変換
- PPTXを変換
- PowerPointから動画へ
- プレゼンテーションから動画へ
- PPTを動画へ
- PPTXを動画へ
- PowerPointからMP4へ
- プレゼンテーションからMP4へ
- PPTをMP4へ
- PPTXをMP4へ
- PPTをMP4として保存
- PPTXをMP4として保存
- PPTをMP4にエクスポート
- PPTXをMP4にエクスポート
- 動画変換
- PowerPoint
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して PowerPoint プレゼンテーションを動画に変換する方法を学びます。サンプルコードと自動化技術を活用してワークフローを効率化しましょう。"
---

PowerPoint プレゼンテーションを動画に変換することで、次のメリットが得られます

* **アクセシビリティの向上:** プレゼンテーション閲覧アプリに比べ、すべてのデバイス（プラットフォームに関係なく）はデフォルトで動画プレーヤーが搭載されているため、ユーザーは動画の開封や再生が容易です。
* **リーチの拡大:** 動画を通じて多くの視聴者に情報を届けることができ、プレゼンテーションでは退屈に感じられる情報でも効果的に伝えられます。調査や統計では、動画が他のコンテンツ形態よりも視聴・消費されやすく、一般的に好まれることが示されています。

{{% alert color="primary" %}} 
こちらのプロセスの実装例として、ライブかつ効果的な [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) をご確認いただくことをおすすめします。
{{% /alert %}} 

## **Aspose.Slides における PowerPoint から Video への変換**

Aspose.Slides はプレゼンテーションから動画への変換をサポートしています。

* **Aspose.Slides** を使用して、特定の FPS（フレーム/秒）に対応するフレームセット（プレゼンテーションスライドから）を生成します
* **ffmpeg** のようなサードパーティユーティリティ（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）を使用して、フレームを元に動画を作成します。

### **PowerPoint を Video に変換**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```


2. Download ffmpeg [here](https://ffmpeg.org/download.html).

4. PowerPoint から video への PHP コードを実行します。

この PHP コードは、図と 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています:
```php
  $presentation = new Presentation();
  try {
    # 笑顔シェイプを追加し、アニメーションさせます
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # ffmpeg バイナリーフォルダーを設定します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **動画エフェクト**

スライド上のオブジェクトにアニメーションを適用し、スライド間でトランジションを使用できます。

{{% alert color="primary" %}} 
以下の記事もご参照ください: [PowerPoint Animation](https://docs.aspose.com/slides/php-java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/php-java/shape-animation/)、および [Shape Effect](https://docs.aspose.com/slides/php-java/shape-effect/)。
{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的で面白くし、動画でも同様の効果があります。前回のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```php
  # 笑顔のシェイプを追加し、アニメーションさせます
  # ...
  # 新しいスライドを追加し、アニメーション遷移を設定します
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


Aspose.Slides はテキストのアニメーションもサポートしています。オブジェクト上の段落をアニメーションさせ、1 秒の遅延で順に表示させます:
```php
  $presentation = new Presentation();
  try {
    # テキストとアニメーションを追加します
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides for Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("convert PowerPoint Presentation with text to video"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("paragraph by paragraph"));
    $paragraphCollection = $autoShape->getTextFrame()->getParagraphs();
    $paragraphCollection->add($para1);
    $paragraphCollection->add($para2);
    $paragraphCollection->add($para3);
    $paragraphCollection->add(new Paragraph());
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effect1 = $mainSequence->addEffect($para1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect2 = $mainSequence->addEffect($para2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect3 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect4 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect1->getTiming()->setTriggerDelayTime(1.0);
    $effect2->getTiming()->setTriggerDelayTime(1.0);
    $effect3->getTiming()->setTriggerDelayTime(1.0);
    $effect4->getTiming()->setTriggerDelayTime(1.0);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # ffmpeg バイナリーフォルダーを設定します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **動画変換クラス**

PowerPoint から video への変換タスクを実行できるよう、Aspose.Slides は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) クラスを提供します。

[PresentationAnimationsGenerator] はコンストラクタで動画のフレームサイズ（後で作成される）を設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation::getSlideSize` が使用され、[PresentationPlayer] が使用するアニメーションが生成されます。

アニメーションが生成されると、各次のアニメーションごとに `NewAnimation` イベントが発生し、プレゼンテーション アニメーション プレーヤー パラメータが付与されます。後者は個別アニメーション用のプレーヤーを表すクラスです。

プレゼンテーション アニメーション プレーヤーを操作するには、`getDuration`（アニメーションの全期間）と `setTimePosition` メソッドを使用します。各アニメーション位置は *0 から duration* の範囲で設定され、`getFrame` メソッドはその時点のアニメーション状態に対応する BufferedImage を返します：
```php
use aspose\slides\Presentation;
use aspose\slides\PresentationPlayer;
use aspose\slides\PresentationAnimationsGenerator;
use aspose\slides\ImageFormat;
use aspose\slides\ShapeType;
use aspose\slides\EffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectPresetClassType;

class PresentationAnimationPlayer {
    function invoke($animationPlayer) {
        echo(sprintf("Animation total duration: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// 初期アニメーション状態
        try {
            # 初期アニメーション状態のビットマップ
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// アニメーションの最終状態
        try {
            # アニメーションの最終フレーム
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # 笑顔シェイプを追加し、アニメーションさせます
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    $presentationAnimation=java_closure(new PresentationAnimationPlayer(), null, java("com.aspose.slides.PresentationAnimationsGeneratorNewAnimation"));
    try {
        $animationsGenerator->setNewAnimation($presentationAnimation);
    } finally {
        if (!java_is_null($animationsGenerator)) {
            $animationsGenerator->dispose();
        }
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


プレゼンテーション内のすべてのアニメーションを同時に再生するには、[PresentationPlayer] クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator] インスタンスとエフェクトの FPS を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます：
```php

class FrameTick {
      function invoke($sender, $arg) {
            try {
                $arguments->getFrame()->save("frame_" . $sender->getFrameIndex() . ".png", ImageFormat::Png);
                } catch (JavaException $e) {
                  }
             }
    }

  $presentation = new Presentation("animated.pptx");
  try {
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, 33);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


生成されたフレームは動画にコンパイルでき、詳しくは [Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) セクションをご覧ください。

## **サポートされているアニメーションとエフェクト**

**開始**:

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

## **よくある質問**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides は [password-protected presentations](/slides/ja/php-java/password-protected-presentation/) の操作をサポートしています。そのようなファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにする必要があります。

**Aspose.Slides はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides はクラウド アプリケーションやサービスに統合可能です。このライブラリはサーバー環境で動作するよう設計されており、ファイルのバッチ処理において高性能とスケーラビリティを提供します。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides は実質的に任意のサイズのプレゼンテーションを扱うことができます。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨される場合があります。