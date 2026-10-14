---
title: PHP で PowerPoint スライドを PNG に変換
linktitle: PowerPoint から PNG へ
type: docs
weight: 30
url: /ja/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を確保します。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用してプレゼンテーションスライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションを読み込み、各スライドをレンダリングし、個別の PNG 画像として保存できます。

以下の例では、デフォルトスケールでのレンダリング、スケールの拡大、出力サイズをピクセル単位で指定する方法、およびグラデーション描画スタイルの選択を示しています。

## **PowerPoint を PNG に変換**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションをロードし、[Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) コレクションからスライドにアクセスします。この例では、パラメーターなしで [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) を呼び出してサムネイルを作成し、[IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) に [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) を指定して各スライドを PNG 画像として保存します。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
パラメーターなしの [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルになります。出力サイズを制御するには、スケール係数を使用するオーバーロードまたは以下に示す明示的な画像サイズを使用してください。
{{% /alert %}}

## **PowerPoint を PNG に変換（カスタム寸法）**

[Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) に水平および垂直のスケール係数を渡してレンダリング寸法を制御します。この例では両方の係数が 2 で、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像になります。等しいスケール係数はスライドのアスペクト比を保持します。各画像は [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) で PNG 形式で保存されます。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **PowerPoint を PNG に変換（カスタムサイズ）**

ピクセル単位で出力サイズを指定する場合は、スケール係数の代わりにサイズを [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) に渡します。この例ではすべてのスライドを 960 × 720 ピクセルでレンダリングし、[IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) で結果を保存します。画像が伸びるのを防ぐため、スライドのアスペクト比に合った寸法を選択してください。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **グラデーション描画スタイルの選択**

スライドにグラデーション塗りが含まれていても、エクスポートされた PNG の色の遷移が PowerPoint で見えるものと比べて明るすぎる、あるいは異なる場合があります。その場合は、[RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) が継承する [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) メソッドを使用して、グラデーションの描画方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドには、上部がシアンからオレンジ、下部が青から黄色への 2 つの線形グラデーションが含まれています。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例では、このプレゼンテーションを読み込み、[Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) を使用して同じ最初のスライドを両モードでレンダリングします。

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![デフォルトでレンダリングされたシアンからオレンジ、青から黄色へのグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色が明るくなり、`PowerPointUI` は中間色が暗くなります。差はグラデーションの色とストップ位置に依存します。

標準の Aspose.Slides 出力が目的に合う場合は `Default` を選択してください。PowerPoint の外観に合わせたい場合は `PowerPointUI` を試してください。両方の出力を比較し、目的の結果に最も近い方を選びましょう。どちらのモードが常に優れているわけではありません。

## **よくある質問**

**特定の図形（チャートや画像など）だけをエクスポートしたい場合、スライド全体ではなくどうすればよいですか？**

Aspose.Slides は [個々の図形のサムネイル生成](/slides/ja/php-java/create-shape-thumbnails/) をサポートしており、図形を PNG 画像としてレンダリングできます。

**サーバー上で並列変換はサポートされていますか？**

はい。スレッドまたはプロセスごとに別々のプレゼンテーションインスタンスを使用してください。[スレッド間で単一インスタンスを共有しない](/slides/ja/php-java/multithreading/)。

**PNG エクスポート時の評価版の制限は何ですか？**

評価版モードでは出力画像に透かしが付加され、[その他の制限](/slides/ja/php-java/licensing/) が適用されます。ライセンスを適用するとこれらの制限は解除されます。