---
title: PHPでプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/php-java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーション テーマ
- スライド テーマ
- テーマの設定
- テーマの変更
- テーマの管理
- 外部テーマ
- THMX
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides のマスタープレゼンテーションテーマを使用し、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗り、線、エフェクトの調和したセットを定義します。テーマ対応オブジェクトは、これらの共有定義を参照し、すべての視覚プロパティを固定値として保持しないため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) で取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterthememanager/) でプレゼンテーションテーマを上書きでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) で継承されたテーマを上書きできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます: プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクト スタイルの更新、継承とオーバーライドが解決された後の実効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイル エントリの数や内容は変わる可能性があります。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、エフェクト スタイルの数をレポートします。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ実効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライド オーバーライドが存在する可能性がある場合は、後述の実効テーマ ワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗り、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) の該当エントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマ色の更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存、再度開き、実効塗り色を出力します。

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

矩形は `Accent4` にリンクされたままなので、テーマが変更された後に可視色は赤になります。シェイプ上で直接色に置き換えると、以降の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットから色を使用**

PowerPoint はテーマ色に対して色変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマ色と追加パレットから生成された明るい色・暗い色](additional-palette-colors.png)

**1** – メインテーマ色。

**2** – メインテーマ色から生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマ色に基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` の値を `ColorScheme` スロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン語 (Minor Latin Font)
* `+mj-lt` – 見出しフォント ラテン語 (Major Latin Font)
* `+mn-ea` – 本文フォント 東アジア語 (Minor East Asian Font)
* `+mj-ea` – 見出しフォント 東アジア語 (Major East Asian Font)

次の例は、メジャー ラテン テーマフォントを使用する見出しと、マイナー ラテン テーマフォントを使用する本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。明示的にフォント名を指定したテキストは、テーマフォントスキームが変更されても自動的には切り替わりません。

メジャー・マイナーのフォント コレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、タナ文字など、個々の記述体系向けのフォント マッピングを含めることもできます。これらのマッピングの検査、追加、置換、削除については、[スクリプト固有テーマフォント](/slides/ja/php-java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}

プレゼンテーション フォントの詳細については、[PowerPoint フォント](/slides/ja/php-java/powerpoint-fonts/) をご覧ください。

{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマを特定マスター依存スライドに適用**

PowerPoint テーマ ファイル (`.thmx`) があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) を使用します。対象マスターは [Presentation::getMasters](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コレクション ( [MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) で表現) から選択し、テーマ ファイル パスをメソッドに渡します。

メソッドは次の操作を実行します。

1. 選択したマスターを基に新しいマスタースライドを作成します。  
1. 外部テーマを新しいマスターに適用します。  
1. 従来そのマスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
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

無効・破損・未対応のテーマは [PptxReadException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが提供したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに紐付くスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、エフェクトは外部テーマに対して解決されます。直接割り当てられた色やフォント、塗りなどの明示的書式は変更されない場合があります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマがランタイム環境に存在しないフォントを参照することがあります。一貫した描画とエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/php-java/custom-font/) から提供するか、[フォント置換](/slides/ja/php-java/font-substitution/) を構成してください。

これは直接的なマスターレベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマ オーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用**

対象マスターが事前に分からない場合は、[Slide::getLayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) と [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) を使用して代表的なスライドから取得します。テーマ適用前に元のマスター参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスターが作成されます。

次の例は、2 つのセクションのスライドからそれぞれのマスターを取得し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `$firstGroupMaster` に依存するスライドのみを対象とし、2 回目の呼び出しは `$secondGroupMaster` に依存するスライドのみを対象とします。他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時に元テーマを保持**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) とクローンしたマスターでスライドをクローンします。これによりマスター、レイアウト、関連テーマが一緒にコピーされます。

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

このワークフローは、ソーススライドが宛先でも同一に見える必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わる可能性があります。

### **既存スライドにテーマ値を適用**

対象スライドを現在のマスター・レイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承するテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除し、継承値に戻すには [OverrideTheme.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマ オーバーライドを適用**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されますが、個別スライドに独自オーバーライドがある場合はそちらが優先されます。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslidethememanager/) から使用できます。

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

多くのレイアウトやスライドが同一のベース デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウト ファミリーに別スタイルが必要な場合はレイアウトオーバーライドを、例外的なスライドだけに適用したい場合はスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後続のグローバルテーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) に格納されています。PowerPoint の UI では、このコレクションに物理的に保存されている塗り定義の数以上の背景選択肢を提示できます。これは、テーマ塗りをテーマ色や他のスタイル参照と組み合わせて表示できるためです。

![プレゼンテーション テーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を検査してください。インデックスが `0` の場合はテーマ塗りなしを意味し、正の値はテーマ背景スタイル参照です。これは PHP コレクションのインデックス (`get_Item(0)` が最初の項目) とは異なります。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限りません。

次の例は、利用可能な背景塗り数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わらないことがあります。継承後の最終背景を知りたいときは [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}

スタイルインデックスをゼロベースのコレクションインデックスとみなさないでください。また、あるファイルでのスタイル番号をハードコーディングし、別ファイルでも同じ外観になると期待しないでください。テーマスタイル定義はプレゼンテーション固有です。

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/php-java/presentation-background/) を参照してください。

{{% /alert %}}

## **テーマエフェクトの更新**

テーマのフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/formatscheme/) を通じて個別の塗り、線、エフェクト スタイル コレクションを公開します。典型的な Office テーマは、微妙、標準、強調という 3 つの主要スタイル エントリを持つことが多いですが、コード側では固定数を前提にせず、各コレクションを検査すべきです。

![同一シェイプに適用された微妙、標準、強調のテーマエフェクト](presentation-design_10.png)

PHP でこれらのコレクションへアクセスする際、コレクション インデックスはゼロベースです: `get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変わらない場合があります。

次の例は、必要なスタイル エントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りスタイルを変更し、3 番目のエフェクトスタイルに外側のシャドウを有効化して結果を保存します。

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

これらのスロットを参照するシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森林緑に、3 番目のエフェクトスタイルに距離 10 ポイントの外側シャドウが付与されます。最終的なビジュアルは、各シェイプが参照しているスタイル スロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![線、塗り、シャドウ設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **実効的な単色塗りがテーマ色を使用しているかの判定**

塗りはオブジェクトに直接格納されるか、段落、レイアウト、マスター、テーマスタイル、その他の書式レベルから継承されることがあります。`FillFormat::getEffective` を呼び出して階層を解決し、変更不可の実効塗りデータを取得します。まず `getFillType` の結果を確認してください。`FillType::Solid` の場合にのみ、単色塗りプロパティを読み取ります。

単色塗りの場合、`getSolidFillColor` は継承、テーマ参照、色変換が適用された後の最終 RGB 値を返します。`getSolidFillSchemeColor` は対応する論理 [SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) スロット (例: `Text1`、`Accent6`) を返します。`SchemeColor::NotDefined` は、実効単色塗りがスキーム色に基づいていないことを意味します。この値は、塗りが直接 RGB 色であることを示す指標として使用できます。

ローカルの [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorformat/) のみで塗りを分類しないでください。たとえば、テキストの一部はローカルでスキーム色が未定義 (`NotDefined`) でも、実効塗りはテーマ色を継承し `Text1` や `Accent6` に解決されることがあります。逆に、`getSolidFillSchemeColor` は実効色を生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別のレベルから来たかは示しません。

次の例は、プレゼンテーションを読み込み、シェイプ塗りとテキスト部分塗りの両方を監査し、各最終 RGB 値と関連スキーム色を出力し、テーマ色の変更に追従しない単色塗りをフラグします。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`NotDefined` の分岐は、テーマカラー スロットの変更に反応しない単色塗りの監査リストを提供します。新しいブランド パレットに合わせてプレゼンテーションを調整する際に、これらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

実効書式オブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出し、新しい実効塗りデータを取得してから比較またはレポートしてください。

## **実効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。実効値は、継承とローカル オーバーライドが解決された後、スライドやシェイプが実際に使用している内容を示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/)、塗りの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) を使用します。

次の例は、スライドから実効テーマ、背景、最初のシェイプ塗りを読み取ります。

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

レンダリング診断、検証、比較には実効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のみを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わるケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に移行する方法は？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) でソースマスターを宛先にクローンし、[SlideCollection.addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/) でそのマスターと共にスライドをクローンしてください。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の実効値はどうやって確認できますか？**

スライドまたはレイアウトのテーマについては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseoverridethememanager/) を、フォーマット オブジェクト (例: [Background.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/)) については対応する実効データ メソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。