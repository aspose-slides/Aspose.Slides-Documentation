---
title: PHPでプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/php-java/presentation-theme/
keywords:
- PowerPointテーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマ設定
- テーマ変更
- テーマ管理
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
description: "Aspose.Slides for PHP via Javaを使用して、ブランド一貫性のあるPowerPointファイルを作成、カスタマイズ、変換するためのマスターテーマ管理。"
---
## **概要**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトといった調和の取れたセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として格納するのではなく、これらの共有定義を参照するため、テーマの変更により多くのオブジェクトを一度に更新できます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) で取得できます。プレゼンテーションは低レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個別スライドは [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) によって継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクトスタイルの更新、そして継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)、[MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)、[MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) を介してテーマのカラー スキーム、フォント スキーム、フォーマット スキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイル エントリの数と内容はファイルごとに異なる可能性があります。

以下の例は、メインテーマ プロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクト スタイルの数を報告します：

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマ フローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 列挙体から論理色を参照できます。対応するエントリを [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) で変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新の影響を受けません。

以下のエンドツーエンド例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存、再度開き、実際の塗りつぶし色を出力します：

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

矩形が `Accent4` にリンクされたままであるため、テーマが変更されると表示色は赤になります。シェイプ上でスキーム色を直接の色に置き換えると、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマ色から明るい・暗いバリエーションを生成するためにカラー変換を適用します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![追加パレットから生成されたメインテーマカラーと明暗のバリエーション](additional-palette-colors.png)

**1** - メインテーマカラー。  
**2** - メインテーマカラーから生成された明るい・暗いバリエーション。

以下の例は、`Accent4` に基づく 6 つの矩形を作成し、うち 5 つに明度変換を適用し、結果を保存します：

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

### **`SchemeColor` 値を `ColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、ある形式から別の形式へ動的に変換される値ではありません。

## **テーマフォントの変更**

テーマ フォント スキームは見出し用のメジャー フォント セットと本文用のマイナー フォント セットを含みます。[FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) と [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント 識別子はテキスト書式設定で使用できます：

* `+mn-lt` - 本文フォント ラテン (Minor Latin Font)  
* `+mj-lt` - 見出しフォント ラテン (Major Latin Font)  
* `+mn-ea` - 本文フォント 東アジア (Minor East Asian Font)  
* `+mj-ea` - 見出しフォント 東アジア (Major East Asian Font)  
* `+mn-cs` - 本文フォント 複合文字 (Minor Complex Script Font)  
* `+mj-cs` - 見出しフォント 複合文字 (Major Complex Script Font)

以下の例は、メジャー ラテン テーマフォントを使用した見出しと、マイナー ラテン テーマフォントを使用した本文行を作成し、その後テーマフォントを変更して結果を保存します：

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

見出しはメジャー フォントに、本文はマイナー フォントに従います。明示的にフォント名が指定されているテキストは、テーマ フォント スキームが変更されても自動的に切り替わりません。

メジャー とマイナー のフォント コレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個別の書字システム向けのフォント マッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法は、[Script-Specific Theme Fonts](/slides/ja/php-java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint フォント](/slides/ja/php-java/powerpoint-fonts/) を参照してください。
{{% /alert %}}

### **テーマフォント参照の解決**

テキストを検査する際、[FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) はフォント ファミリ名の代わりに `+mn-lt` などのテーマ参照を返すことがあります。対象テキストが属するオブジェクトの有効テーマ データを使用して [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) を呼び出すことで、その参照を解決できます。`+mj` と `+mn` プレフィックスはそれぞれメジャー・マイナー フォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはラテン、東アジア、複合文字フォントを選択します。

対象テキストが属するオブジェクトに対して [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) を呼び出し、スライドの継承テーマとローカル オーバーライドを含むコンテキストを取得します。レイアウトやマスター自体を検査する場合は、そのオブジェクト自身の有効テーマを使用してください。最初のマスターのテーマがすべてのスライドに適用されると仮定しないでください。

以下の例は、マイナー ラテン フォントを明示的に参照するテキスト部分を作成し、[OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) でスライド フォント スキームを初期化し、メジャー とマイナー のラテン ファミリをそれぞれ `Arial` と `Calibri` に設定して、入力ファイルが不要な再現性のある結果を得ます：

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

出力は `+mn-lt -> Calibri` に続いて `Verdana -> Verdana` となります。保存された参照は変更されず、明示的なファミリ名はそのまま返されます。もし `+mj-lt` が使用されていれば、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマが指定したフォント ファミリを特定しますが、フォントの可用性チェックや、レンダリング時の代替フォントやグリフ フォールバックによって最終的に使用されるフォント ファイルの決定は行いません。これらの別ステップについては、[Font Selection Sequence](/slides/ja/php-java/font-selection-sequence/) と [Font Substitution](/slides/ja/php-java/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のフローは、さまざまなテーマ関連の課題を解決します。

### **Apply an External Theme to a Master's Dependent Slides**

PowerPoint テーマ ファイル (`.thmx`) があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) を使用します。対象マスターは [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) コレクション ( [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) で表現) から選択し、テーマ ファイル パスをメソッドに渡します。

メソッドは次の操作を実行します：

1. 選択したマスターを基に新しいマスター スライドを作成します。  
1. 外部テーマを新しいマスターに適用します。  
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
1. 新しく作成された [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) を返します。

以下の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します：

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

無効、破損、またはサポートされていないテーマを使用すると [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) が発生する可能性があります。ユーザーが提供するパスは検証し、ファイルシステムへのアクセス失敗を処理し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに紐付くスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、エフェクトは外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りつぶし、その他の明示的書式設定は変更されないことがあります。レイアウト レベルおよびスライド レベルのオーバーライドは、新しいマスターから継承された値よりも優先される場合があります。

テーマは実行環境に存在しないフォントを参照することがあります。一定のレンダリングとエクスポートを保証するには、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/php-java/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/php-java/font-substitution/) を構成してください。

これは直接的なマスター レベルのフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライド レベルやレイアウト レベルのテーマ オーバーライドを手動で作成する必要はありません。

### **Apply Different External Themes in a Multi-Master Presentation**

対象マスターが事前に分からない場合は、[Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) と [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) を使用して代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスター を作成します。

以下の例は、2 つのセクションのスライドからそれぞれのマスターを取得し、各グループに別々の外部テーマを適用します：

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

### **Preserve a Source Theme When Moving Slides**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) でソースマスターをターゲットにクローンし、続いて [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、および関連テーマが一緒にコピーされます。

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

この方法は、ソース スライドが宛先でも同一の外観を保つ必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わる可能性があります。

### **Apply Theme Values to an Existing Slide**

対象スライドを現在のマスターやレイアウトのままにしたい場合は、ソーステーマからスライド レベルのオーバーライドを初期化します。[OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)、[OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)、[OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマ コンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカル オーバーライドを削除して継承値に戻すには、[OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) を呼び出してください。

### **Apply a Theme Override to a Layout**

レイアウト レベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（特定のスライドが独自のオーバーライドを持っていない限り）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) を通じても使用できます：

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーション レベルのテーマを使用し、特定のレイアウト ファミリだけが異なるスタイリングを必要とする場合はレイアウト オーバーライドを、例外的なケースだけはスライド オーバーライドを使用してください。過度なスライド レベルのオーバーライドは、後続のグローバル テーマ変更予測を困難にします。

## **Update Theme Background Styles**

テーマの背景塗りつぶしは [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) に保存されます。PowerPoint の UI では、コレクションに実際に保存されている塗りつぶし定義よりも多くの背景選択肢が提示されます。これは UI がテーマ塗りつぶしとテーマカラー、その他のスタイル参照を組み合わせられるためです。

![プレゼンテーションテーマの PowerPoint 背景スタイルギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されたコレクションと現在の [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/) を検査してください。`0` のスタイル インデックスはテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイル参照です。これは PHP コレクションのインデックスとは異なり、`get_Item(0)` が最初に保存されたアイテムを指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを保持しているとは限りません。

以下の例は利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します：

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

表示結果はマスターが参照するテーマ エントリと、レイアウトまたはスライド レベルでの背景オーバーライドに依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変化しないことがあります。継承後の最終背景を知りたいときは [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイル インデックスをゼロベースのコレクション インデックスとして扱わないでください。また、あるファイルから取得したスタイル番号を別のファイルでハードコーディングして同じ外観になると期待しないでください。テーマ スタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/php-java/presentation-background/) を参照してください。
{{% /alert %}}

## **Update Theme Effects**

テーマ フォーマット スキームは、[FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)、[FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)、[FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) を介してそれぞれ塗りつぶし、線、エフェクト スタイル コレクションを公開します。一般的な Office テーマは、微妙、標準、強烈なフォーマットに対応する 3 つの主要スタイル エントリを含むことが多いですが、コードは固定数を仮定せず各コレクションを検査すべきです。

![同一シェイプに適用された微妙、標準、強烈なテーマエフェクト](presentation-design_10.png)

PHP でこれらのコレクションにアクセスする際、インデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) に公開されています。テーマ スタイルを変更すると、そのテーマ スタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

以下の例は、必要なスタイル エントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目のエフェクト スタイルに外側の影を有効にして結果を保存します：

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

該当スロットを参照しているシェイプでは、最初のテーマ 線スタイルが赤に、3 番目のテーマ 塗りつぶしスタイルが濃い森林緑に、3 番目のエフェクト スタイルに距離 10 ポイントの外側の影が追加されます。最終的なビジュアルは、各シェイプがどのスロットを参照しているか、また直接書式設定がテーマを上書きしているかに依存します。

![線、塗り、影設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **Select Theme Fill and Line Styles for a Shape**

シェイプは [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) と [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) を使用して、塗りつぶしとアウトラインを独立に選択できます。どちらのメソッドも、インデックス `1` が対応するテーマコレクションの最初のエントリ (`get_Item(0)`)、インデックス `2` が 2 番目のエントリ (`get_Item(1)`) を選択します。

以下の例は、新規プレゼンテーションのデフォルトテーマに 2 つの塗りつぶしスタイル（金色と空色）と 2 つの線スタイル（6 pt の濃い青、12 pt の濃い赤）を設定し、結果を 3 段階で保存して PowerPoint で比較できるようにします：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 初期スタイル | 右側のアウトラインを変更 | 最初のテーマ塗りつぶしを編集 |
|:---:|:---:|:---:|
| ![金色と空色の矩形、細い濃い青のアウトラインが一致](theme-style-initial.png) | ![空色の矩形が太い濃い赤のアウトラインに変更](theme-style-line-changed.png) | ![左側の矩形が緑に変わり、両方のアウトラインは変更なし](theme-style-fill-changed.png) |

異なる線スタイルを選択すると、右側の矩形のアウトラインだけが変わります。最初のテーマ塗りつぶしを編集すると、それを使用しているすべてのシェイプが更新されます。この例では左側の矩形だけが緑に変わります。

既存のシェイプでは、ローカルの塗りつぶし色、線色、線幅がテーマ スタイルのその部分を上書きできます。スタイル インデックスを変更しても効果が見えない場合は、シェイプの [direct formatting](/slides/ja/php-java/shape-formatting/) を確認してください。

## **Determine Whether an Effective Solid Fill Uses a Theme Color**

塗りつぶしはオブジェクト上に直接保存されることも、段落、レイアウト、マスター、テーマ スタイル、または別の書式レベルから継承されることもあります。`[FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)` を呼び出して階層を解決し、イミュータブルな有効塗りつぶしデータを取得します。まず `getFillType` の結果を確認してください。`FillType::Solid` の場合にのみ、実体の塗りつぶしプロパティを読み取ります。

実体の塗りつぶしが固体の場合、`getSolidFillColor` は継承、テーマ参照、カラー変換が適用された最終的な RGB 値を返します。`getSolidFillSchemeColor` は対応する論理 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) スロット（例：`Text1`、`Accent6`）を返します。`SchemeColor::NotDefined` は、実体の固体塗りつぶしがスキーム カラーに基づいていないことを意味します。テーマ色か直接 RGB 色のいずれかだけを使用するフローでは、この値が直接 RGB 塗りつぶしを識別します。

ローカルの [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) のみを使用して塗りつぶしを分類しないでください。たとえば、テキスト部分がローカルでスキーム カラーを定義していない場合、ローカル値は `NotDefined` ですが、実体の塗りつぶしはテーマ カラーを継承して `Text1` や `Accent6` に解決されることがあります。逆に、`getSolidFillSchemeColor` は実体色を生成した論理テーマ スロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別の階層から来たかは示しません。

以下の例はプレゼンテーションを読み込み、シェイプの塗りつぶしとテキスト部分の塗りつぶしを監査し、最終的な RGB 値と関連スキーム カラーを出力し、テーマ カラー変更に追従しない固体塗りつぶしをフラグ付けします：

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

`NotDefined` ブランチは、テーマ カラー スロットの変更に応答しない固体塗りつぶしの監査リストを提供します。ブランド パレットへの変更が必要なときにこれらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム 値はその外観がテーマに接続されているかどうかを説明します。

有効書式オブジェクトはスナップショットです。プレゼンテーション テーマ、テーマ オーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出して新しい有効塗りつぶしデータを取得し、比較または報告に使用してください。

## **Read Effective Theme Values**

生のテーマ オブジェクトは特定レベルで定義されている内容を示します。継承とローカル オーバーライドが解決された後にスライドやシェイプが実際に使用する値は有効値です。スライドの場合は [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)、塗りつぶしの場合は [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) を使用します。

以下の例はスライドから有効テーマ、背景、最初のシェイプ塗りつぶしを取得して読み取ります：

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

有効データはレンダリング診断、検証、比較に使用してください。単に [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドによって最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) は、選択したマスターに依存しているスライドのみを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) を使用し、そのオーバーライド テーマを初期化します。変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む最善の方法は何ですか？**

スライドを移動して元の外観を保持したい場合は、[MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) でソース マスターを宛先にクローンし、続いて [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) でそのマスターを使用してスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効な値を確認するにはどうすればよいですか？**

スライドまたはレイアウトのテーマについては [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) を使用し、[Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) や [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) などの対応する有効データ メソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。