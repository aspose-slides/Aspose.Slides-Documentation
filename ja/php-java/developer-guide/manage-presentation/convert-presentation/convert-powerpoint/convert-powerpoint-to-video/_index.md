---
title: PHP で PowerPoint プレゼンテーションをビデオに変換する
linktitle: PowerPoint からビデオへ
type: docs
weight: 130
url: /ja/php-java/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint からビデオへ
- プレゼンテーションをビデオに変換
- PPT からビデオへ
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して PowerPoint プレゼンテーションをビデオに変換する方法を学びます。サンプルコードと自動化テクニックを紹介し、ワークフローを効率化します。"
---

PowerPoint プレゼンテーションをビデオに変換することで、次のメリットが得られます

* **アクセシビリティの向上:** すべてのデバイス（プラットフォームに関係なく）は、プレゼンテーションを開くアプリケーションに比べてデフォルトでビデオプレーヤーが装備されているため、ユーザーはビデオの開封や再生が容易になります。
* **リーチの拡大:** ビデオを通じて、多くの視聴者にリーチし、プレゼンテーションでは退屈に感じられる情報を提供できます。ほとんどの調査や統計では、人々は他のコンテンツ形態よりもビデオを見る・消費する傾向があり、一般的にビデオコンテンツを好むことが示されています。

{{% alert color="primary" %}} 
このプロセスの実装例として、ライブで効果的な[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word)をご確認いただくことをおすすめします。
{{% /alert %}} 

## **Aspose.Slides の PowerPoint からビデオへの変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/)で、プレゼンテーションからビデオへの変換サポートを実装しました。

* **Aspose.Slides** を使用して、特定の FPS（フレーム/秒）に対応するフレームセット（プレゼンテーションのスライドから）を生成します
* **ffmpeg** のようなサードパーティユーティリティ（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）を使用して、フレームからビデオを作成します

### **PowerPoint をビデオに変換**

1. POM ファイルに以下を追加します:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```


2. ffmpeg を[here](https://ffmpeg.org/download.html)からダウンロードします。

4. PowerPoint からビデオへの PHP コードを実行します。

この PHP コードは、図と 2 つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています。
```php
  $presentation = new Presentation();
  try {
    # 笑顔のシェイプを追加し、アニメーションを付けます
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
    # ffmpeg バイナリフォルダを設定します。このページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **ビデオ エフェクト**

スライド上のオブジェクトにアニメーションを適用したり、スライド間の遷移を使用したりできます。

{{% alert color="primary" %}} 
これらの記事をご覧いただくことをおすすめします: [PowerPoint Animation](https://docs.aspose.com/slides/php-java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/php-java/shape-animation/)、および[Shape Effect](https://docs.aspose.com/slides/php-java/shape-effect/)。
{{% /alert %}} 

アニメーションと遷移は、スライドショーをより魅力的で面白くし、ビデオでも同様の効果があります。前回のプレゼンテーションのコードにもう一枚のスライドと遷移を追加してみましょう:
```php
  # 笑顔のシェイプを追加してアニメーションします
  # ...
  # 新しいスライドを追加し、アニメーション遷移を設定します
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


Aspose.Slides はテキストのアニメーションもサポートしています。オブジェクト上の段落をアニメーションさせ、1 秒の遅延で順次表示されるようにします:
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
    # ffmpeg バイナリフォルダを設定します。このページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **ビデオ変換クラス**

PowerPoint からビデオへの変換タスクを実行できるように、Aspose.Slides は[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/)と[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/)クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) は、コンストラクタでビデオのフレームサイズ（後で作成される）を設定できるようにします。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) が使用するアニメーションが生成されます。

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントが生成され、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/) パラメータが渡されます。後者は、個別のアニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/) を使用するには、アニメーションの全長を示す[Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--)プロパティと[SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-)メソッドを使用します。各アニメーション位置は*0 から duration*の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態に対応する BufferedImage を返します:
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
            # 初期アニメーション状態ビットマップ
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
    # 笑顔のシェイプを追加し、アニメーションを付けます
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


プレゼンテーション内のすべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) クラスを使用します。このクラスは、[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) のインスタンスとエフェクト用の FPS をコンストラクタに渡し、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生させます:
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


生成されたフレームは、ビデオを作成するためにコンパイルできます。詳細は[Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video)セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**

**Entrance**:

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

**Emphasis**:

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

**Exit**:

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

**Motion Paths**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **よくある質問**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides では[password-protected presentations](/slides/ja/php-java/password-protected-presentation/)を扱うことができます。このようなファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにする必要があります。

**Aspose.Slides はクラウドソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides はクラウドアプリケーションやサービスに統合できます。このライブラリはサーバー環境で動作するよう設計されており、ファイルのバッチ処理において高いパフォーマンスとスケーラビリティを保証します。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides は事実上あらゆるサイズのプレゼンテーションを扱うことができます。ただし、非常に大きなファイルを処理する場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨される場合があります。