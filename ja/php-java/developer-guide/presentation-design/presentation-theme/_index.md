---
title: PHP でプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/php-java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマ設定
- テーマ変更
- テーマ管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、ブランド一貫性のある PowerPoint ファイルを作成、カスタマイズ、変換するためのマスタープレゼンテーションテーマ。"
---
## **概要**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果という調整されたセットを定義します。テーマ対応オブジェクトは、各視覚プロパティを固定値として保持する代わりに、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) で取得できます。プレゼンテーションには下位レベルでテーマのオーバーライドを含めることもできます。マスタは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterthememanager/) でプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) で継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ、マスタオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の読み取りです。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、特に外部ソースから取得したプレゼンテーションの場合に有用です。スタイルエントリの数と内容は変わる可能性があります。

次の例は、主要なテーマプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

ファイルが複数のマスタを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスタを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) の対応エントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマカラーの更新によって変更されません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

長方形は `Accent4` にリンクされたままであるため、テーマが変更されると可視色が赤になります。シェイプ上で直接色に置き換えると、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーから明るい・暗いバリエーションを色変換で生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗いカラー](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るい・暗いバリエーション。

次の例は `Accent4` を基にした 6 つの長方形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` 値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) メソッドでそれらのセットが取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます：

* `+mn-lt` - 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` - 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` - 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` - 見出しフォント East Asian（メジャー East Asian フォント）

次の例は、メジャー Latin テーマフォントを使用する見出しと、マイナー Latin テーマフォントを使用する本文行を作成し、テーマフォントを変更して結果を保存します。

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

見出しはメジャーフォントに、本文テキストはマイナーフォントに従います。明示的にフォント名が指定されているテキストは、テーマフォントスキームが変わっても自動的に切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/php-java/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローが 2 つあり、解決すべき問題が異なります。

### **スライドを移動するときに元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスタをターゲットプレゼンテーションにクローンし、次に [SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) とクローンしたマスタでスライドをクローンします。これにより、マスタ、そのレイアウト、および関連テーマが一緒にコピーされます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

この方法は、ソーススライドが宛先でも同じ外観である必要がある場合に推奨されます。無関係な宛先マスタにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまうことがあります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスタとレイアウトに留まる必要がある場合、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

これにより、そのスライドだけのテーマが変更され、他のスライドが継承しているテーマは変わりません。ローカルオーバーライドを削除し継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されますが、個別スライドが独自のオーバーライドを持つ場合は例外となります。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslidethememanager/) を通じて使用できます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスタまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリが異なるスタイリングを必要とする場合はレイアウトオーバーライドを、真の例外のみスライドオーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後続のグローバルテーマ変更を予測しにくくします。

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) に保存されています。PowerPoint の UI では、このコレクションに物理的に保存されている塗りつぶし定義よりも多くの背景選択肢が表示されます。これは UI がテーマ塗りつぶしとテーマカラー、他のスタイル参照を組み合わせられるためです。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りつぶしがないことを意味し、正の値はテーマ背景スタイル参照です。これは PHP コレクションのインデックス (`get_Item(0)` が最初の項目) とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

次の例は利用可能な背景塗りつぶし数を報告し、最初のマスタにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

表示結果はマスタが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドに依存します。スライドが独自の背景を使用している場合、マスタ背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスとみなさないでください。また、あるファイルから取得したスタイル番号をハードコーディングして別のファイルでも同じ外観になると期待しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/php-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) を通じて個別の塗りつぶし、線、効果スタイルコレクションを公開します。一般的な Office テーマは、微妙、標準、強調という視覚的な 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を前提にせず各コレクションを検査してください。

![同一シェイプに適用された微妙、標準、強調のテーマ効果](presentation-design_10.png)

PHP でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapestyle/) によって公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されないままです。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外部シャドウ（距離 10 ポイント）を有効にして結果を保存します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

これらのスロットを参照するシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに外部シャドウが追加されます。最終的な視覚結果は、各シェイプがどのスタイルスロットを参照しているか、また直接書式設定がテーマを上書きしているかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義された内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/)、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、および最初のシェイプ塗りつぶしを取得します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

描画診断、検証、比較には有効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) だけを検査すると、最終的な外観を変えるマスタ、レイアウト、スライド、シェイプのオーバーライドを見逃す可能性があります。

## **FAQ**

**単一スライドにテーマを適用し、マスタを変更せずに済む方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidethememanager/) を使用し、そのオーバーライドテーマを初期化します。変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち運ぶ方法は？**

スライドを移動して元の外観を保持する場合、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスタを宛先にクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) でそのマスタを使用してスライドをクローンしてください。これによりマスタ、レイアウト、テーマが一体となって保持されます。

**継承とオーバーライド後の有効値を確認するには？**

スライドまたはレイアウトテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を、フォーマットオブジェクト（例: [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/)）には対応する有効データ取得メソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。