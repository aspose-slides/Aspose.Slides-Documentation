---
title: JavaScriptでプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/nodejs-java/presentation-theme/
keywords:
- PowerPointテーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、JavaScript でプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **概要**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調和したセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/) で取得できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることも可能です。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterthememanager/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/) で継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景・エフェクトスタイルの更新、継承とオーバーライドが解決された後の実際の値の取得です。

## **テーマを検査する**

[MasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/) 、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/) 、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイルエントリの数や内容は変わり得るからです。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクトスタイルの数をレポートします。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色を変更する**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/) の該当エントリを変更すると、まだそのテーマ色を参照しているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

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

矩形が `Accent4` にリンクされたままであるため、テーマが変更されると表示色は赤になります。シェイプ上でスキームカラーを直接の色に置き換えると、以後の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーに対し、色変換を適用して明るいバリアントと暗いバリアントを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るいバリアントと暗いバリアント。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリアントはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントを変更する**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/) メソッドでそれぞれのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン文字 (Minor Latin Font)  
* `+mj-lt` – 見出しフォント ラテン文字 (Major Latin Font)  
* `+mn-ea` – 本文フォント 東アジア文字 (Minor East Asian Font)  
* `+mj-ea` – 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、メジャーラテンテーマフォントを使用した見出しと、マイナ―ラテンテーマフォントを使用した本文行をそれぞれ作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的にフォント名が指定されたテキストは、テーマフォントスキームが変更されても自動的には切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/nodejs-java/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマをコピーまたは適用する**

典型的なワークフローは 2 つあり、解決すべき課題が異なります。

### **スライドを移動するときに元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) でクローンしたマスターと共にスライドをクローンします。これにより、マスター、レイアウト、関連テーマが一緒にコピーされます。

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

ソーススライドが宛先でも同じ外観である必要がある場合の推奨フローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わってしまう可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままにしたい場合、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

これにより、そのスライドだけがテーマを変更でき、他のスライドが継承しているテーマはそのままです。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（ただし、個々のスライドが独自のオーバーライドを持っている場合は除く）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslidethememanager/) 経由でも使用できます。

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

多くのレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ別のスタイリングが必要な場合はレイアウトオーバーライドを、例外的なケースだけにスライドオーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後の全体テーマ変更を予測しにくくします。

## **テーマの背景スタイルを更新する**

テーマの背景塗りつぶしは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/) に格納されています。PowerPoint の UI では、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせることで、実際にコレクションに格納されている数以上の背景オプションを提示できます。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) を確認してください。`0` のスタイルインデックスはテーマ塗りつぶしが無いことを示し、正の値はテーマ背景スタイル参照を表します。これは、JavaScript コレクションのインデックスが `0` で最初の項目を指すのとは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数をレポートし、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無によって変わります。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドの見た目は変わりません。継承後の最終背景を知りたいときは、[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号をハードコーディングして別のファイルでも同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景継承については、[Presentation Background](/slides/ja/nodejs-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトを更新する**

テーマのフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/) でそれぞれ塗りつぶし、線、エフェクトスタイルのコレクションを公開します。一般的な Office テーマは、視覚的に「控えめ」「中程度」「強烈」の 3 つの主要スタイルエントリを含むことが多いですが、固定数を前提にせずコレクション全体を検査すべきです。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

JavaScript でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：インデックス `0` が最初のスタイル、インデックス `2` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapestyle/) で取得できます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在するか確認し、最初の線スタイルを変更、3 番目の塗りつぶしスタイルを変更、3 番目のエフェクトスタイルに外側の影（距離 10 ポイント）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目のエフェクトスタイルに外側の影が追加されます。最終的なビジュアルは、シェイプが参照しているスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効なテーマ値を取得する**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/)、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプの塗りつぶしを取得します。

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

レンダリング診断、検証、比較のために有効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/) だけを検査すると、最終的な外観を変更するマスター、レイアウト、スライド、またはシェイプのオーバーライドを見逃す可能性があります。

## **FAQ**

**単一スライドにだけテーマを適用し、マスターを変更しない方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドだけにローカルに適用され、他のスライドは既存のテーマを継承し続けます。

**プレゼンテーション間でテーマを安全に持ち運ぶ最良の方法は何ですか？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslidecollection/) と [SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) を使って、ソースマスターとそのスライドを宛先にクローンします。これにより、マスター、レイアウト、テーマが一体で保持されます。

**継承とオーバーライドの後の有効値を確認するには？**

スライドまたはレイアウトテーマに対しては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/) を使用し、[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/) といったフォーマットオブジェクトの有効データ取得メソッドを利用してください。これらの API は、継承とオーバーライドが適用された後の解決済み値を返します。