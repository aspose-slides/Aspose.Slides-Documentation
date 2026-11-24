---
title: "JavaScript でプレゼンテーションテーマを管理する"
linktitle: "プレゼンテーションテーマ"
type: docs
weight: 10
url: /ja/nodejs-java/presentation-theme/
keywords:
- "PowerPoint テーマ"
- "プレゼンテーションテーマ"
- "スライドテーマ"
- "テーマの設定"
- "テーマの変更"
- "テーマの管理"
- "外部テーマ"
- "THMX"
- "テーマカラー"
- "追加パレット"
- "テーマフォント"
- "テーマスタイル"
- "テーマエフェクト"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js を使用して JavaScript でプレゼンテーションテーマを管理し、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **導入**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調整されたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保存する代わりに、これらの共有定義を参照するため、テーマの変更で多数のオブジェクトを一度に更新できます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) で取得できます。プレゼンテーションは、下位レベルでテーマのオーバーライドを含むこともできます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/) を通じてプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) を通じて継承されたテーマをオーバーライドできます。実際には、スライドの実効テーマは次の継承チェーンを通して解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景およびエフェクトスタイルの更新、継承とオーバーライドが解決された後の実効値の読み取りです。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、プレゼンテーションが外部ソースから来た場合に特に有用です。スタイルエントリの数と内容は変わる可能性があります。

以下の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクトスタイルの数を報告します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ実効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、この記事後半に示す実効テーマワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。 [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) の対応エントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用するオブジェクトはテーマカラーの更新の影響を受けません。

以下のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実効塗りつぶし色を出力します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);

    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

矩形は `Accent4` にリンクされたままであるため、テーマが変更された後に表示色が赤になります。シェイプ上でスキームカラーを直接の色に置き換えると、後の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーに変換を適用して、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) 列挙体を通じて公開します。

![メインテーマカラーと追加パレットから生成された明るい色と暗い色](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るい色と暗い色。

以下の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` 値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマップする**

[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、ある形態から別の形態へ動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。 [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) と [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) メソッドがそれらのセットを公開します。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます：

* `+mn-lt` - 本文フォント Latin (Minor Latin Font)
* `+mj-lt` - 見出しフォント Latin (Major Latin Font)
* `+mn-ea` - 本文フォント East Asian (Minor East Asian Font)
* `+mj-ea` - 見出しフォント East Asian (Major East Asian Font)
* `+mn-cs` - 本文フォント Complex Script (Minor Complex Script Font)
* `+mj-cs` - 見出しフォント Complex Script (Major Complex Script Font)

以下の例は、メジャー Latin テーマフォントを使用する見出しと、マイナー Latin テーマフォントを使用する本文行をそれぞれ作成し、テーマフォントを変更して結果を保存します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));

    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーフォントコレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、Thaana など、個別の書字システム向けのフォントマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除するには、[Script-Specific Theme Fonts](/slides/ja/nodejs-java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細情報は、[PowerPoint Fonts](/slides/ja/nodejs-java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

### **テーマフォント参照の解決**

テキストを検査するとき、[FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) はフォントファミリ名の代わりに `+mn-lt` などのテーマ参照を返すことがあります。適切な実効テーマを使用してその参照を解決するには、[FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) を呼び出します。`+mj` と `+mn` プレフィックスはメジャーとマイナーのフォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれ Latin、East Asian、Complex Script のフォントを選択します。

対象テキストが属するオブジェクトに対して [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) を呼び出して実効テーマを取得します。スライド上の普通のテキストの場合は、スライド自体でこのメソッドを呼び出すと、そのスライドの継承テーマとローカルオーバーライドが含まれたコンテキストが得られます。レイアウトやマスター自体を検査する場合は、それ自身の実効テーマを使用してください。最初のマスターのテーマがすべてのスライドに適用されると決めつけてはいけません。

以下の例は、マイナー Latin フォントを明示的に参照するテキスト部分を作成し、[OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) でスライドフォントスキームを初期化し、メジャーとマイナーの Latin ファミリを `Arial` と `Calibri` に設定して、入力ファイルなしでも再現可能な結果を生成します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

出力は `+mn-lt -> Calibri` に続いて `Verdana -> Verdana` となります。保存された参照は変更されず、明示的なファミリ名はそのまま返されます。もし部分が `+mj-lt` を使用していた場合、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマによって指定されたフォントファミリを特定しますが、フォントの可用性をチェックしたり、レンダリング時の代替やグリフフォールバック後に実際に使用されるフォントファイルを決定したりはしません。これらの別ステップについては、[Font Selection Sequence](/slides/ja/nodejs-java/font-selection-sequence/) と [Font Substitution](/slides/ja/nodejs-java/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスターの依存スライドに適用する**

PowerPoint テーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) を使用します。対象マスターは [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) コレクション（[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) が表す）から選択し、テーマファイルのパスをメソッドに渡します。

メソッドは次の操作を実行します：

1. 選択したマスターを基に新しいマスタースライドを作成します。
1. 外部テーマを新しいマスターに適用します。
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
1. 新しく作成された [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) を返します。

以下の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが提供するパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、エフェクトは外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りつぶし、その他の明示的な書式設定は変更されないまま残ることがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値に優先することがあります。

テーマは実行環境に存在しないフォントを参照する可能性があります。レンダリングやエクスポートの一貫性を保つには、必要なフォントをインストールするか、[custom font sources](/slides/ja/nodejs-java/custom-font/) を通じて提供するか、[font substitution](/slides/ja/nodejs-java/font-substitution/) を構成してください。

これは直接的なマスター レベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) と [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) を使用して代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスターが作成されます。

以下の例は、2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに別々の外部テーマを適用します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

最初の呼び出しは `firstGroupMaster` に依存するスライドのみ、2 番目の呼び出しは `secondGroupMaster` に依存するスライドのみを対象とします。他のマスターに属するスライドは再スタイル化されません。

### **スライドを移動するときにソーステーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、次に [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) とクローンしたマスターでスライドをクローンします。これによりマスター、レイアウト、および関連テーマが一緒にコピーされます。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);

        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

この方法は、ソーススライドが宛先でも同一に見える必要がある場合に推奨されるワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変化する可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスターとレイアウトに留まる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

この操作により、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（ただし、個別スライドが独自のオーバーライドを持つ場合は除く）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/) を通じても使用できます：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);

        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());

        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

多くのレイアウトとスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリーにだけ異なるスタイルが必要な場合はレイアウトオーバーライドを、真の例外だけにスライドオーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後の全体テーマ変更を予測しにくくします。

<!-- visual-explanation:presentation-theme:start -->
[![マスターテーマが2つのレイアウトに供給され、レイアウトオーバーライドはそのスライドに影響しますが、よりローカルなオーバーライドを持つスライドは除外されます。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

* レイアウトオーバーライドは、そのレイアウトを使用するスライドに適用されますが、スライドが独自のオーバーライドを提供している場合は除外されます。テーマベースの値は解決済みスキームに従い、明示的に書式設定されたオブジェクトはローカルの外観を保持できます。オーバーライドは意図したデザイン例外と同程度に限定して保持してください。
<!-- visual-explanation:presentation-theme:end -->

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) に格納されます。PowerPoint の UI は、このコレクションに実際に格納されている塗りつぶし定義の数以上の背景オプションを提示できます。これは、テーマ塗りつぶしとテーマカラーやその他のスタイル参照を組み合わせて表示できるためです。

![プレゼンテーションテーマの PowerPoint 背景スタイルギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) を検査してください。`0` のスタイルインデックスはテーマ塗りつぶしがないことを意味し、正の値はテーマ背景スタイル参照です。これは JavaScript コレクションのインデックスとは異なり、インデックス `0` が最初の項目を指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つと想定しないでください。

以下の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターバックグラウンドだけを変更してもそのスライドは変わらない可能性があります。継承後の最終背景を知りたい場合は、[Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルから取得したスタイル番号をハードコードして別のファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定および背景継承については、[Presentation Background](/slides/ja/nodejs-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトの更新**

テーマフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) で公開される個別の塗りつぶし、線、エフェクトスタイルコレクションを含みます。典型的な Office テーマは、微妙、適度、強烈な 3 つの主要スタイルエントリを視覚的に持ちますが、コード側では固定数を想定せず、各コレクションを検査すべきです。

![同一シェイプに適用された微妙、適度、強烈なテーマエフェクト](presentation-design_10.png)

JavaScript でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：インデックス `0` が最初の格納スタイル、インデックス `2` が3番目です。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/) が公開します。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

以下の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目のエフェクトスタイルに外側の影（距離 10 pt）を有効にして結果を保存します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);

    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

これらのスロットを参照するシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルがソリッドのフォレストグリーンに、3 番目のエフェクトスタイルが距離 10 ポイントの外側シャドウを取得します。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、直接書式設定がテーマを上書きしているかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **シェイプのテーマ塗りつぶしと線スタイルの選択**

シェイプは [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) と [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/) を使用して、塗りつぶしと輪郭を独立して選択できます。いずれのメソッドでも、インデックス `1` は対応するテーマコレクションの最初のエントリ（`get_Item(0)`）を選択し、インデックス `2` は2番目（`get_Item(1)`）を選択します。

以下の例は、新しいプレゼンテーションのデフォルトテーマで、2 つの塗りつぶしスタイル（金色と空色）と 2 つの線スタイル（6 pt の濃い青、12 pt の濃い赤）を設定し、3 段階でスライドを保存して PowerPoint で結果を比較できるようにします：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初期スタイル | 右側の輪郭を変更 | 最初のテーマ塗りつぶしを編集 |
|:---:|:---:|:---:|
| ![金色と空色の矩形が細い濃い青の輪郭で一致](theme-style-initial.png) | ![空色の矩形が太い濃い赤の輪郭に変更](theme-style-line-changed.png) | ![左側の矩形が緑に変わり、両方の輪郭は変更なし](theme-style-fill-changed.png) |

異なる線スタイルを選択すると、右側の矩形の輪郭だけが変わります。最初のテーマ塗りつぶしを編集すると、それを使用しているすべてのシェイプが更新されます。この例では左側の矩形だけが緑に変わります。

既存のシェイプでは、ローカルな塗りつぶし色、線色、線幅がテーマスタイルのその部分を上書きできます。スタイルインデックスを変更しても見た目に変化がない場合は、シェイプの [direct formatting](/slides/ja/nodejs-java/shape-formatting/) を確認してください。

## **実効的な単色塗りつぶしがテーマカラーを使用しているかの判定**

塗りつぶしはオブジェクトに直接格納されるか、段落、レイアウト、マスター、テーマスタイル、または別の書式レベルから継承されます。[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) を呼び出して、その階層を不変の実効塗りつぶしスナップショットに解決します。まず `getFillType` の値を確認してください。`FillType.Solid` の場合にのみ、単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、`getSolidFillColor` は継承、テーマ参照、カラー変換が適用された後の最終的な RGB 値を返します。`getSolidFillSchemeColor` メソッドは対応する論理 [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) スロット（例: `Text1` や `Accent6`）を返します。`SchemeColor.NotDefined` は実効単色塗りつぶしがスキームカラーに基づいていないことを意味します。テーマカラーか直接 RGB 色かで分けるワークフローでは、この値が直接 RGB 塗りつぶしを識別します。

ローカルの [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) のみを使用して塗りつぶしを分類しないでください。たとえば、テキスト部分がローカルでスキームカラーを定義していない場合、ローカル値は `NotDefined` ですが、実効塗りつぶしはテーマカラーを継承して `Text1` や `Accent6` に解決されることがあります。逆に、`getSolidFillSchemeColor` はどの論理テーマスロットが実効色を生成したかを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別のレベルから来たかは示しません。

以下の例はプレゼンテーションを読み込み、シェイプ塗りつぶしとテキスト部分塗りつぶしの両方を監査し、最終 RGB 値と関連スキームカラーを出力し、テーマカラーの変更に追従しない単色塗りつぶしをフラグ付けします：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` ブランチは、テーマカラーのスロット変更に応答しない単色塗りつぶしの監査リストを提供します。新しいブランド パレットに従う必要があるプレゼンテーションでは、これらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

実効フォーマット オブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または継承書式設定を変更した後は、再度 `getEffective` を呼び出して新しい実効塗りつぶしオブジェクトを取得し、色を比較または報告してください。

## **実効テーマ値の読み取り**

生のテーマオブジェクトは特定レベルで定義された内容を示します。実効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) を使用します。

以下の例はスライドから実効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();

    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

レンダリング診断、検証、比較には実効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) のみを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドによって最終外観が変わっていることを見落とす可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一のスライドにテーマを適用できますか？**

できます。スライドの [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) を使用してオーバーライドテーマを初期化してください。変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最善の方法は何ですか？**

スライドを移動して元の外観を保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) でソースマスターを宛先にクローンし、[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) でそのマスターを使用してスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の実効値をどのように確認できますか？**

スライドやレイアウトテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) を使用し、[Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) などの対応する実効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。