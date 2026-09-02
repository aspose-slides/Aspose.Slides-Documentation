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
- 外部テーマ
- THMX
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
description: "Java を介した Aspose.Slides for PHP でマスタープレゼンテーションテーマを作成、カスタマイズ、変換し、一貫したブランディングを実現します。"
---
## **概要**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗り、線、効果の統合されたセットを定義します。テーマ対応オブジェクトは、各視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) で取得できます。プレゼンテーションには下位レベルでテーマのオーバーライドを含めることもできます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterthememanager/) を使用してプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を使用して継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます。プレゼンテーションテーマ → マスター オーバーライド → レイアウト オーバーライド → スライド オーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効な値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) を通じてテーマのカラー スキーム、フォント スキーム、フォーマット スキームを公開します。変更前にこれらのコレクションを検査することは、プレゼンテーションが外部ソースから取得された場合に特に有用です。スタイル エントリの数や内容は変わる可能性があります。

次の例は、メイン テーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、効果のスタイル数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマ ワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗り、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) の該当エントリを変更すると、そのテーマ色を参照しているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存、再度開き、実際の塗り色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色は赤になります。シェイプ上のスキーム色を直接の色に置き換えると、以降の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint は、テーマ色に対して色変換を適用することで、明るいバリエーションおよび暗いバリエーションを導出します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メイン テーマ色と追加パレットから生成された明るい色と暗い色](additional-palette-colors.png)

**1** - メイン テーマ色。

**2** - メイン テーマ色から生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` に基づく 6 つの矩形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマ色に基づいたままです。後で `Accent4` が変更されると、変換された色は新しい `Accent4` 値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマップする**

[SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォント スキームは、見出し用のメジャー フォント セットと本文用のマイナー フォント セットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) および [FontScheme.getMinor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマ フォント 識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン文字 (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン文字 (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア文字 (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、メジャー ラテン テーマ フォントを使用した見出しと、マイナー ラテン テーマ フォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャー フォントに従い、本文はマイナー フォントに従います。テーマ識別子ではなく明示的なフォント名が設定されているテキストは、テーマ フォント スキームが変更されても自動的に切り替わりません。

メジャー とマイナー のフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個々の文字体系向けのマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法は、[Script-Specific Theme Fonts](/slides/ja/php-java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="ヒント" %}}

プレゼンテーション フォントの詳細については、[PowerPoint Fonts](/slides/ja/php-java/powerpoint-fonts/) を参照してください。

{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマを特定マスターに依存するスライドに適用する**

`.thmx` 形式の PowerPoint テーマ ファイルがあり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) を使用します。対象のマスターは [Presentation::getMasters](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コレクション（[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) で表現）から選択し、テーマ ファイルのパスをメソッドに渡します。

このメソッドは次の操作を行います。

1. 選択したマスターを基に新しいマスタースライドを作成します。
1. 外部テーマを新しいマスターに適用します。
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
1. 新しく作成された [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) を返します。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが指定したパスを検証し、ファイルシステムへのアクセス失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、効果は外部テーマに対して解決されます。直接割り当てられた色、フォント、塗り、その他の明示的な書式設定は変更されない場合があります。レイアウト レベルおよびスライド レベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマは実行環境に存在しないフォントを参照することがあります。レンダリングとエクスポートの一貫性を保つために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/php-java/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/php-java/font-substitution/) を構成してください。

これは、メソッドが `.thmx` ファイルへのパスを受け取り、スライド レベルまたはレイアウト レベルのテーマ オーバーライドを手動で作成する必要がない、直接的なマスター レベルのワークフローです。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[Slide::getLayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) と [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) を通じて代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスターが作成されます。

次の例は、2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに異なる外部テーマを適用します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

最初の呼び出しは `$firstGroupMaster` に依存するスライドだけに影響し、2 番目の呼び出しは `$secondGroupMaster` に依存するスライドだけに影響します。他のマスターに所属するスライドは再スタイルされません。

### **スライドを移動するときに元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスターをターゲット プレゼンテーションにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) とクローンしたマスターでスライドをクローンします。これによりマスター、レイアウト、関連テーマが一緒にコピーされます。

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

これは、ソーススライドが宛先でも同じ外観になることが必要な場合に推奨されるワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

ターゲット スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライド レベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) メソッドは、3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカル オーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマ オーバーライドを適用する**

レイアウト レベルのオーバーライドは、そのレイアウトを使用しているスライドに適用されます（ただし、個々のスライドに独自のオーバーライドがある場合は除く）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslidethememanager/) を介して使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーション レベルのテーマを使用し、特定のレイアウトファミリだけが別のスタイリングを必要とする場合はレイアウト オーバーライドを、真に例外的なケースだけはスライド オーバーライドを使用してください。過剰なスライド レベル オーバーライドは、後のグローバル テーマ変更を予測しにくくします。

## **テーマの背景スタイルの更新**

テーマの背景塗りは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) に格納されています。PowerPoint の UI では、このコレクションに実際に格納されている塗り定義以上の背景オプションを提示できることがあります。これは UI がテーマ塗りとテーマ色や他のスタイル参照を組み合わせられるためです。

![プレゼンテーション テーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を検査してください。`0` のスタイル インデックスはテーマ塗りがないことを意味し、正の値はテーマ背景スタイル参照です。これは PHP コレクションのインデックスとは異なり、`get_Item(0)` は最初に格納されたアイテムを指します。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限りません。

次の例は利用可能な背景塗りの個数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果はマスターが参照するテーマ エントリと、レイアウトまたはスライド レベルの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わらないことがあります。継承後の最終背景が必要な場合は、[Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="警告" %}}

スタイル インデックスをゼロベースのコレクション インデックスとみなさないでください。また、あるファイルでハードコーディングしたスタイル番号を別のファイルでも同じ外観と想定しないでください。テーマ スタイル定義はプレゼンテーション固有です。

{{% /alert %}}

{{% alert color="info" title="ヒント" %}}

直接的な背景書式設定と背景の継承については、[Presentation Background](/slides/ja/php-java/presentation-background/) を参照してください。

{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマット スキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) を介してそれぞれ塗り、線、効果スタイルのコレクションを公開します。一般的な Office テーマは、視覚的に微妙、適度、強烈な書式設定に対応する 3 つの主要スタイル エントリを含むことが多いですが、コードは固定数を前提にせず、各コレクションを検査すべきです。

![同じシェイプに適用された微妙、適度、強烈なテーマ効果](presentation-design_10.png)

PHP でこれらのコレクションにアクセスする場合、コレクション インデックスはゼロベースです。`get_Item(0)` が最初に格納されたスタイル、`get_Item(2)` が 3 番目のスタイルを指します。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapestyle/) を通じて取得します。テーマ スタイルを変更すると、そのテーマ スタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されない可能性があります。

次の例は、必要なスタイル エントリが存在することを確認し、最初の線スタイル、3 番目の塗りスタイルを変更し、3 番目の効果スタイルに外部シャドウを有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森林緑に、3 番目の効果スタイルに距離 10 ポイントの外部シャドウが追加されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、また直接書式設定がテーマを上書きしているかによって変わります。

![線、塗り、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効なテーマ値の取得**

生のテーマ オブジェクトは特定レベルで定義されている内容を示しますが、有効値は継承とローカル オーバーライドが解決された後にスライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/)、塗りの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、および最初のシェイプの塗りを読み取ります。

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

有効データはレンダリング診断、検証、比較に使用します。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終的な外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) は、選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにのみローカルに適用され、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は何ですか？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスターを宛先にクローンし、[SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) とそのクローンマスターでスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどうやって確認できますか？**

スライドまたはレイアウトのテーマに対しては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を使用し、[Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) などの対応する有効データ メソッドを使用します。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。