---
title: PHPでスライドショーを管理する
linktitle: スライドショー
type: docs
weight: 90
url: /ja/php-java/manage-slide-show/
keywords:
- ショータイプ
- スピーカーによる提示
- 個人閲覧
- キオスク閲覧
- ショーオプション
- 連続ループ
- ナレーションなしのショー
- アニメーションなしのショー
- ペンカラー
- スライド表示
- カスタムショー
- スライド進行
- 手動で
- タイミング使用
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介して PHP 用 Aspose.Slides のスライドショー管理方法を学びます。PPT、PPTX、ODP 形式のスライド遷移、タイミングなどを簡単にコントロールできます。"
---

Microsoft PowerPoint では、**スライドショー**設定は、プロフェッショナルなプレゼンテーションを準備し実施するための重要なツールです。このセクションで最も重要な機能のひとつが **Set Up Show** で、プレゼンテーションを特定の条件や対象者に合わせて調整でき、柔軟性と利便性を確保します。この機能を使用すると、ショーのタイプ（例: スピーカーが提示、個人が閲覧、キオスクで閲覧）を選択したり、ループの有無を設定したり、表示するスライドを指定したり、タイミングを利用したりできます。この準備段階は、プレゼンテーションをより効果的かつ専門的にするために不可欠です。

`getSlideShowSettings` は、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのメソッドで、[SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/) 型のオブジェクトを返し、PowerPoint プレゼンテーションのスライドショー設定を管理できます。本記事では、このメソッドを使用してスライドショー設定のさまざまな側面を構成および制御する方法を紹介します。

## **Select Show Type**

`SlideShowSettings->setSlideShowType` は、スライドショーのタイプを定義し、次のクラスのいずれかのインスタンスを指定できます: [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/), または [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/)。このメソッドを使用すると、自動キオスクや手動プレゼンテーションなど、さまざまな利用シナリオに合わせてプレゼンテーションを調整できます。

以下のコード例は、新しいプレゼンテーションを作成し、スクロールバーを表示せずに「個人が閲覧」モードに設定します。
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Enable Show Options**

`SlideShowSettings->setLoop` は、スライドショーを手動で停止するまでループさせるかどうかを決定します。これは、継続的に実行する必要がある自動プレゼンテーションに便利です。`SlideShowSettings->setShowNarration` は、スライドショー中に音声ナレーションを再生するかどうかを決定します。音声ガイダンスを含む自動プレゼンテーションに役立ちます。`SlideShowSettings->setShowAnimation` は、スライドオブジェクトに追加されたアニメーションを再生するかどうかを決定します。プレゼンテーションの視覚効果を完全に表現するために有用です。

以下のコード例は、新しいプレゼンテーションを作成し、スライドショーをループさせます。
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Select Slides to Show**

`SlideShowSettings->setSlides` メソッドは、プレゼンテーション中に表示するスライドの範囲を選択できます。これは、全スライドではなくプレゼンテーションの一部だけを表示したい場合に便利です。以下のコード例は、新しいプレゼンテーションを作成し、スライド範囲を `2` から `9` に設定します。
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Use Advance Slides**

`SlideShowSettings->setUseTimings` メソッドは、各スライドの事前設定されたタイミングの使用を有効化または無効化します。これは、事前に定義された表示時間でスライドを自動的に切り替える場合に便利です。以下のコード例は、新しいプレゼンテーションを作成し、タイミングの使用を無効にします。
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Show Media Controls**

`SlideShowSettings->setShowMediaControls` メソッドは、マルチメディアコンテンツ（例: ビデオやオーディオ）が再生される際に、スライドショー中にメディアコントロール（再生、停止、ポーズなど）を表示するかどうかを決定します。これにより、プレゼンテーション中にメディアの再生を制御したい場合に便利です。

以下のコード例は、新しいプレゼンテーションを作成し、メディアコントロールの表示を有効にします。
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **FAQ**

**プレゼンテーションを保存すると、スライドショーモードで直接開くことはできますか？**

はい。ファイルを PPSX または PPSM として保存すると、PowerPoint で開いたときにスライドショーが直接起動します。Aspose.Slides では、エクスポート時に対応する保存形式を選択してください。[保存時の形式](/slides/ja/php-java/save-presentation/)

**個々のスライドをファイルから削除せずにショーから除外できますか？**

はい。スライドを [hidden]((https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/)) としてマークします。非表示スライドはプレゼンテーションに残りますが、スライドショー中には表示されません。

**Aspose.Slides はスライドショーを再生したり、画面上でリアルタイムにプレゼンテーションを制御したりできますか？**

できません。Aspose.Slides はプレゼンテーションファイルの編集、分析、変換を行うものであり、実際の再生は PowerPoint などのビューアアプリケーションが担当します。