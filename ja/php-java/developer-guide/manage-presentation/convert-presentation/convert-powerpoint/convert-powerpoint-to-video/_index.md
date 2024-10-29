---
title: PowerPointを動画に変換
type: docs
weight: 130
url: /ja/php-java/convert-powerpoint-to-video/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, 動画, MP4, PPTを動画に, PPTをMP4に, Java, Aspose.Slides"
description: "PowerPointを動画に変換"
---

PowerPointプレゼンテーションを動画に変換することで、次の利点があります。

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションと比べて、すべてのデバイス（プラットフォームに関係なく）はデフォルトで動画プレーヤーを搭載しているため、ユーザーは動画を開いたり再生したりするのが容易になります。
* **リーチの拡大:** 動画を通じて、多くの視聴者に情報を届けることができ、プレゼンテーションで退屈に思える情報をターゲットにすることができます。多くの調査や統計によると、人々は他の形式のコンテンツよりも動画を視聴し消費することが多く、通常はそのようなコンテンツを好みます。

{{% alert color="primary" %}} 

私たちの[**PowerPointを動画に変換するオンラインコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-word)をチェックすると良いでしょう。これは、ここで説明したプロセスのライブで効果的な実装です。

{{% /alert %}} 

## **Aspose.SlidesにおけるPowerPointから動画への変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/)では、プレゼンテーションを動画に変換する機能を実装しました。

* **Aspose.Slides**を使用して、特定のFPS（フレーム毎秒）に対応するプレゼンテーションスライドからフレームのセットを生成します。
* **ffmpeg**のようなサードパーティユーティリティを使用して、フレームに基づいて動画を作成します。

### **PowerPointを動画に変換**

1. POMファイルに次の内容を追加してください:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```

2. ffmpegを[こちら](https://ffmpeg.org/download.html)からダウンロードします。

4. PowerPointを動画に変換するPHPコードを実行します。

このPHPコードは、図と2つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています：

```php
  $presentation = new Presentation();
  try {
    # 笑顔の形を追加してアニメーションさせる
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
    # ffmpegバイナリフォルダーを構成します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **動画効果**

スライド上のオブジェクトにアニメーションを適用したり、スライド間の遷移を使用したりすることができます。 

{{% alert color="primary" %}} 

これらの記事を参照すると良いでしょう: [PowerPointアニメーション](https://docs.aspose.com/slides/php-java/powerpoint-animation/)、[形状アニメーション](https://docs.aspose.com/slides/php-java/shape-animation/)、および[形状効果](https://docs.aspose.com/slides/php-java/shape-effect/)。

{{% /alert %}} 

アニメーションと遷移により、スライドショーがより魅力的で面白くなり、動画にも同様の効果を与えます。前述のプレゼンテーションのコードに新しいスライドと遷移を追加しましょう：

```php
  # 笑顔の形を追加し、アニメーションさせる
  # ...
  # 新しいスライドとアニメーション遷移を追加
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);

```

Aspose.Slidesはテキスト用のアニメーションもサポートしています。つまり、オブジェクト上の段落をアニメーションさせ、次々と表示させることができます（遅延は1秒に設定されています）：

```php
  $presentation = new Presentation();
  try {
    # テキストとアニメーションを追加
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides for Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("テキスト付きのPowerPointプレゼンテーションを動画に変換"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("段落ごとに"));
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
    # ffmpegバイナリフォルダーを構成します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
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

PowerPointから動画への変換タスクを実行できるように、Aspose.Slidesは[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/)および[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/)クラスを提供します。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/)は、動画のフレームサイズを設定することを可能にします（後で作成されるものに対して）。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize`が使用され、[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/)が使用するアニメーションを生成します。

アニメーションが生成されると、各後続のアニメーションに対して`NewAnimation`イベントが生成され、これには[IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/)パラメーターが含まれます。後者は、別々のアニメーションのプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/)と連携するには、[Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--)（アニメーションの総持続時間）プロパティと、[SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-)メソッドが使用されます。各アニメーションの位置は*0からduration*の範囲内に設定され、その後`GetFrame`メソッドは、その時点でのアニメーションの状態に対応するBufferedImageを返します：

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
        echo(sprintf("アニメーションの総持続時間: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// 初期アニメーション状態
        try {
            # 初期アニメーション状態のビットマップ
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// アニメーションの最終状態
        try {
            # アニメーションの最後のフレーム
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # 笑顔の形を追加してアニメーションさせる
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

プレゼンテーション内のすべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/)クラスを使用します。このクラスは、[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/)インスタンスとFPSを効果のためにコンストラクタで受け取り、すべてのアニメーションを再生するために`FrameTick`イベントを呼び出します：

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

その後、生成されたフレームをコンパイルして動画を作成できます。詳細は[PowerPointを動画に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video)セクションを参照してください。

## **サポートされているアニメーションと効果**

**登場**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **分割** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ホイール** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **成長＆ターン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スウィベル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
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
| **ラインカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **塗りつぶしカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |

**退場**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **分割** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **縮小＆ターン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スウィベル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンス** | ![サポートされています](v.png) | ![サポートされています](v.png) |

**モーションパス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **ライン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **アーク** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ターン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ループ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **カスタムパス** | ![サポートされています](v.png) | ![サポートされています](v.png) |