---
title: JavaScriptでプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、JavaScript でプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗り、線、効果という調整されたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持する代わりに、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/) で取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterthememanager/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/) によって継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作を示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の実効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。これらのコレクションを変更前に検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイルエントリの数や内容は変わる可能性があります。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、効果スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗り、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/) の該当エントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実効的な塗りの色を出力します。

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

矩形は `Accent4` にリンクされたままなので、テーマが変更されると可視色は赤になります。シェイプ上でスキームカラーを直接の色に置き換えると、以降の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマカラーから明るい・暗いバリエーションを色変換で生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colortransformoperation/) 列挙体で公開します。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – メインテーマカラー。

**2** – メインテーマカラーから生成された明るい・暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに明度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。後で `Accent4` が変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。`[FontScheme.getMajor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/)` と `[FontScheme.getMinor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/)` メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` – 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` – 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` – 見出しフォント East Asian（メジャー East Asian フォント）

次の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。明示的にフォント名が指定されているテキストは、テーマフォントスキームが変わっても自動的には切り替わりません。

メジャー・マイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個別の書字システム向けマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除するには、[Script-Specific Theme Fonts](/slides/ja/nodejs-java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/nodejs-java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint のテーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) を使用します。対象のマスターは [Presentation.getMasters](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) コレクション（[MasterSlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslidecollection/) が表します）から選択し、メソッドにテーマファイルのパスを渡します。

メソッドは次の操作を行います。

1. 選択したマスターを基に新しいマスタースライドを作成します。
2. 外部テーマを新しいマスターに適用します。
3. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
4. 新しく作成された [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) を返します。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

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

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxreadexception/) をスローすることがあります。ユーザーから提供されたパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、効果は外部テーマに対して再解決されます。直接割り当てられた色、フォント、塗りなどの明示的書式は変更されないことがあります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先される場合があります。

テーマが実行時環境に存在しないフォントを参照することがあります。一貫したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/nodejs-java/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/nodejs-java/font-substitution/) を構成してください。

これは直接的なマスターレベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[Slide.getLayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/) と [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) で代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスターが作成されます。

次の例は、2 つのセクションのスライドからそれぞれのマスターを取得し、各グループに別々の外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドだけに影響し、2 回目は `secondGroupMaster` に依存するスライドだけに影響します。他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時に元テーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、および関連テーマが一緒に持ち込まれます。

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

この方法は、ソーススライドが宛先でも同じ外観で表示される必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスターとレイアウトのままである必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。`[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)`、`[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)`、`[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)` メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、`[OverrideTheme.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)` を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（ただし個別スライドが独自のオーバーライドを持つ場合は除く）。同じ初期化メソッドは `[LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslidethememanager/)` を介して使用できます。

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

多数のレイアウトとスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ異なるスタイリングが必要な場合はレイアウトオーバーライドを、真の例外だけにスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後のグローバルテーマ変更を予測しにくくします。

## **テーマの背景スタイルの更新**

テーマの背景塗りは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/) に格納されています。PowerPoint の UI は、テーマ塗りとテーマカラーや他のスタイル参照を組み合わせて、実際にコレクションに物理的に保存されている数以上の背景選択肢を提示できます。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りなしを意味し、正の値はテーマ背景スタイル参照です。これは JavaScript コレクションのインデックスとは異なり、インデックス `0` が最初の格納項目を指します。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限りません。

次の例は利用可能な背景塗り数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

可視結果はマスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは、[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルから取得したスタイル番号を別のファイルでハードコーディングして同じ外観になると期待しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/nodejs-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/) で公開される個別の塗り、線、効果スタイルコレクションを含みます。一般的な Office テーマは、微妙、適度、強烈という視覚的な 3 つの主要スタイルエントリを含むことが多いですが、コード側ではコレクションのサイズを固定で想定せず、必ず検査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

JavaScript でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：インデックス `0` が最初の格納スタイル、インデックス `2` が3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響し、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りスタイルを変更し、3 番目の効果スタイルに外側のシャドウを有効化して結果を保存します。

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

これらのスロットを参照しているシェイプに対して、最初のテーマ線スタイルは赤に、3 番目のテーマ塗りスタイルは濃い森林緑に、3 番目の効果スタイルは距離 10 ポイントの外側シャドウが付加されます。最終的なビジュアルは、各シェイプがどのスロットを参照しているか、または直接書式設定がテーマを上書きしているかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **実効テーマ値の読み取り**

生のテーマオブジェクトは特定レベルで定義された内容を示します。実効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。スライドの場合は `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/)` を呼び出します。背景の場合は `[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/)`、塗りの場合は `[FillFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/)` を使用してください。

次の例は、スライドから実効テーマ、実効背景、最初のシェイプの塗りを読み取ります。

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

実効データはレンダリング診断、検証、比較に利用してください。`[Presentation.getMasterTheme]` だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっているケースを見落とす可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。`[MasterSlide.applyExternalThemeToDependingSlides]` は選択したマスターに依存するスライドのみを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの `[SlideThemeManager]` を使用し、オーバーライドテーマを初期化してください。変更はそのスライドにローカルに留まり、他のスライドは既存テーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち運ぶ方法は？**

スライドを移動して元の外観を保持したい場合は、`[MasterSlideCollection.addClone]` でソースマスターを宛先にクローンし、`[SlideCollection.addClone]` でそのマスターとともにスライドをクローンします。これによりマスター、レイアウト、およびテーマが一緒に保持されます。

**継承とオーバーライドの後の実効値はどのように確認できますか？**

スライドまたはレイアウトテーマに対して `[BaseOverrideThemeManager.createThemeEffective]` を使用し、フォーマットオブジェクト（例：`[Background.getEffective]`、`[FillFormat.getEffective]`）に対して対応する実効データメソッドを使用してください。これらの API は継承とオーバーライド適用後の解決された値を返します。