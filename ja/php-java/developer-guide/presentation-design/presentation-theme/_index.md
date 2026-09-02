---
title: PHPでプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/php-java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
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
description: "Aspose.Slides for PHP (Java 経由) でプレゼンテーションテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **導入**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果という調和したセットを定義します。テーマ対応オブジェクトは、各視覚プロパティを固定値として保存するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) を通じて利用できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることも可能です。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterthememanager/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトや個別スライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) によって継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンを通じて解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、テーマの最も一般的なワークフローを示します：テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) を介してテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。これらのコレクションを変更前に検査することは、外部ソースからのプレゼンテーションの場合に特に有用です。なぜなら、スタイルエントリの数や内容が変わり得るからです。

次の例は、メインテーマプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマワークフローを使用してください。

## **テーマカラーの変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体の論理カラーを参照できます。対応するエントリを [ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) で変更すると、まだそのテーマカラーを参照しているすべてのオブジェクトが新しい値に基づいて解決されます。直接 RGB カラーを使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶしカラーを出力します。

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

矩形が `Accent4` にリンクされたままであるため、テーマを変更すると表示色は赤になります。シェイプ上でスキームカラーを直接カラーに置き換えた場合、後続の `Accent4` の変更はその塗りつぶしに影響しません。

### **追加パレットからのカラー使用**

PowerPoint はテーマカラーから明度変換を適用して、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換されたカラーは新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマップする**

[SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン文字 (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン文字 (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア文字 (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、メジャー ラテンテーマフォントを使用した見出しと、マイナー ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーフォントコレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、サナ文字など、個別の文字体系に対するフォントマッピングも含められます。これらのマッピングの検査、追加、置換、削除については、[Script-Specific Theme Fonts](/slides/ja/php-java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/php-java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローは 2 種類あり、解決すべき課題が異なります。

### **スライドを移動する際に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) でそのクローンマスターを使用してスライドをクローンします。これにより、マスター、レイアウト、および関連テーマが一緒に転送されます。

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

この方法は、ソーススライドが宛先でも同一に見える必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまう可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスターとレイアウトに留まる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマはそのままに、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されますが、個別スライドが独自のオーバーライドを持つ場合は例外となります。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslidethememanager/) を通じて使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ異なるスタイリングが必要な場合はレイアウトオーバーライドを、真の例外のみの場合はスライドオーバーライドを利用してください。過剰なスライドレベルのオーバーライドは、後の全体テーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) に格納されています。PowerPoint の UI では、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせることで、実際にコレクションに保存されている以上の背景選択肢を提示できます。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、保存されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイル参照を表します。これは PHP コレクションのインデックス (`get_Item(0)` が最初のアイテム) とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当ててプレゼンテーションを保存します。

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

見た目の結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドには反映されません。最終的な背景を取得する必要があるときは、[Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号をハードコーディングして別ファイルでも同じ外観になると期待しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景継承については、[Presentation Background](/slides/ja/php-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) を介してそれぞれ塗りつぶし、線、効果スタイルのコレクションを公開します。典型的な Office テーマは、微妙、適度、強烈という視覚的なフォーマットに対応する 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

PHP でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が3番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapestyle/) を通じて取得します。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響し、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3番目の塗りつぶしスタイルを変更し、3番目の効果スタイルに外側の影を有効化して結果を保存します。

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

これらのスロットを参照しているシェイプについては、最初のテーマ線スタイルが赤に、3番目のテーマ塗りつぶしスタイルが実線のフォレストグリーンに、3番目の効果スタイルが距離 10 ポイントの外側シャドウを持つようになります。最終的な視覚結果は、各シェイプが参照しているスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を呼び、背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります。

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

有効データは、レンダリング診断、検証、比較に使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドにより最終的な外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**単一スライドにのみテーマを適用し、マスターを変更しない方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最善の方法は？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスターを宛先にクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) でそのマスターを使用してスライドをクローンします。これにより、マスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどのように確認できますか？**

スライドまたはレイアウトテーマについては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を使用し、[Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) などのフォーマットオブジェクト向け有効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。