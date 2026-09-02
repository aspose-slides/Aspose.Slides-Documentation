---
title: JavaScript でプレゼンテーションテーマを管理する
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
description: "Aspose.Slides for Node.js を使用して JavaScript でプレゼンテーションテーマを管理し、PowerPoint ファイルを作成、カスタマイズ、変換し、一貫したブランド化を実現します。"
---
## **はじめに**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の調和の取れたセットを定義します。テーマ対応オブジェクトは個々の視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slidesでは、プレゼンテーション レベルのテーマは[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/)で取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスターは[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterthememanager/)でプレゼンテーションテーマを上書きでき、レイアウトや個々のスライドは[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/)で継承されたテーマを上書きできます。実際には、スライドの実効テーマは次の継承チェーンで解決されます。プレゼンテーションテーマ → マスター オーバーライド → レイアウト オーバーライド → スライド オーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の実効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/)オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mastertheme/)を介してテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。これらのコレクションを変更前に検査することは、外部ソースから取得したプレゼンテーションで、スタイル項目の数や内容が変わる可能性があるため特に有用です。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、および効果スタイルの数をレポートします。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ実効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の実効テーマフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは[SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/)列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/)で該当エントリを変更すると、そのテーマカラーを参照しているすべてのオブジェクトが新しい値に解決されます。直接RGBカラーを使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、実効塗りつぶしカラーを出力します。

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

矩形は `Accent4` にリンクされたままなので、テーマが変更されると表示色が赤になります。シェイプ上でスキームカラーを直接カラーに置き換えると、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPointはテーマカラーから明るい・暗いバリエーションを色変換で派生させます。Aspose.Slidesはこれらの変換を[ColorTransformOperation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colortransformoperation/)列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗いカラー](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るい・暗いバリエーション。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換されたカラーは新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/)列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/)は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームには見出し用のメジャーフォントセットと本文用のマイナーフォントセットが含まれます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン文字（Minor Latin Font）
* `+mj-lt` – 見出しフォント ラテン文字（Major Latin Font）
* `+mn-ea` – 本文フォント 東アジア文字（Minor East Asian Font）
* `+mj-ea` – 見出しフォント 東アジア文字（Major East Asian Font）

次の例は、メジャー ラテンテーマフォントを使用した見出しと、マイナー ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャー／マイナーフォントコレクションには、キリル文字、アラビア文字、和文、ジョージア文字、ターナ文字など、個別の文字体系向けのフォントマッピングも含められます。これらのマッピングを検査、追加、置換、削除する方法は[Script-Specific Theme Fonts](/slides/ja/nodejs-java/script-specific-font-mappings/)をご参照ください。

{{% alert color="info" title="ヒント" %}}
プレゼンテーション フォントの詳細については、[PowerPoint Fonts](/slides/ja/nodejs-java/powerpoint-fonts/)をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

2 つの一般的なワークフローがあり、解決すべき問題が異なります。

### **スライドを移動する際に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslidecollection/)でソースマスターをターゲットプレゼンテーションにクローンし、続いて[SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/)でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、および関連テーマが一緒に持ち運ばれます。

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

この方法は、ソーススライドが宛先でも同じ外観になる必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動のカラー、フォント、背景、効果が変更される可能性があります。

### **既存スライドにテーマ値を適用する**

ターゲットスライドが現在のマスターとレイアウトに留まる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、そのスライドで使用されるテーマが変更され、他のスライドが継承しているテーマはそのままです。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/overridetheme/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されますが、個別スライドが独自のオーバーライドを持つ場合はそちらが優先されます。同じ初期化メソッドは[LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslidethememanager/)を介して使用できます。

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

多くのレイアウトとスライドが同一のベースデザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリで異なるスタイリングが必要な場合はレイアウトオーバーライドを、例外的なケースだけはスライドオーバーライドを使用してください。スライドレベルのオーバーライドが過剰になると、後のグローバルテーマ変更の予測が困難になります。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)に格納されています。PowerPoint の UI では、このコレクションに実際に格納されている塗りつぶし定義の数以上の背景選択肢を提示できるのは、テーマ塗りつぶしとテーマカラー、その他のスタイル参照を組み合わせられるためです。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されているコレクションと現在の[Background.getStyleIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りつぶしが無いことを意味し、正の値はテーマ背景スタイル参照です。これは JavaScript コレクションのインデックスとは異なり、インデックス `0` が最初の項目を指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は利用可能な背景塗りつぶし数をレポートし、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果はマスターが参照しているテーマエントリと、レイアウトやスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変化しません。継承後の最終背景を知りたいときは[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) を使用してください。

{{% alert color="warning" title="警告" %}}
スタイルインデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルから取得したスタイル番号をハードコーディングして別ファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="ヒント" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/nodejs-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/formatscheme/) で公開される個別の塗りつぶし、線、効果スタイルコレクションを含みます。典型的な Office テーマは、視覚的に微妙、標準、強い書式設定に対応する 3 つの主要スタイルエントリを含むことが多いですが、コードは固定数を仮定せず各コレクションを検査すべきです。

![同一シェイプに適用された微妙、標準、強いテーマ効果](presentation-design_10.png)

JavaScript でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです。インデックス `0` が最初のスタイル、インデックス `2` が3番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響し、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、1 番目の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側の影（距離 10 ポイント）を有効化して結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに外側の影が追加されます。最終的なビジュアルは各シェイプが参照するスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![線、塗りつぶし、影設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **実効テーマ値の読み取り**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。実効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。スライドの場合は[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/)、塗りつぶしの場合は[FillFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/) を使用します。

次の例は、スライドから実効テーマ、背景、および最初のシェイプの塗りつぶしを読み取ります。

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

実効データはレンダリングの診断、検証、比較に使用します。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/) のみを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっていることを見逃す可能性があります。

## **FAQ**

**単一スライドに対してマスターを変更せずにテーマを適用できますか？**

はい。スライドの[SlideThemeManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化してください。変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち運ぶ最善の方法は何ですか？**

スライドを移動して元の外観を保つ場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslidecollection/) でソースマスターを宛先にクローンし、続いて[SlideCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/) でそのマスターを使用してスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の実効値はどのように確認できますか？**

スライドまたはレイアウトテーマに対しては[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseoverridethememanager/) を、フォーマットオブジェクトに対しては[Background.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/background/) や[FillFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/) などの実効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。