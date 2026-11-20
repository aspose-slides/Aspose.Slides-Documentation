---
title: JavaScriptでプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキストの回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java 経由で Node.js 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーション内のテキストの書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブ位置、言語設定について解説します。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、最初の段落には以下のテキストが含まれています。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例では、継承された太字書式を含む有効な書式設定を使用します：

![Sample text](sample_text.png)

リテラルテキストまたは正規表現の一致箇所を検索してハイライトする方法については、[Search and Replace Text](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

段落のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用し、個々のテキスト部分のハイライト色を設定するには [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) を使用します。

以下の例では、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分で明示的に設定したハイライト色は、このデフォルトよりも優先されます：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライトカラーを設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The gray paragraph](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のハイライトカラーを設定します。
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The gray text portions](gray_text_portions.png)

## **テキスト段落の配置**

テキストフレーム内の段落の配置を設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどが指定できます。

以下のコード例は、段落を **中央** に揃える方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The aligned paragraph](aligned_paragraph.png)

## **行内のフォントの配置**

行内でサイズが異なるフォントのテキスト部分を垂直に揃えるには [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) を使用します。この設定は段落全体に適用され、各行内での配置を制御します。

以下の単一スライドの自己完結型例では、4つのラベル付きテキストボックスを作成します。各段落は 18、36、54 ポイントの同じテキストを含み、異なるフォント配置が適用されています。Arial を使用し、オートフィットと折り返しを無効にして、テキストフレームが単一行に収まるようにしています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

フォント配置はフォントメトリクスに基づくため、個々の文字の見た目の端が必ずしも正確に揃うわけではありません。例では大文字とディセンダーの両方を含め、ベースラインと下端の配置の違いを示しています。フォントの利用可否や代替、使用する文字、フォントサイズの違いが結果に影響します。また、フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較する際は同じフォントとレイアウト設定を使用してください。

この設定は、水平の段落配置を制御する [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) と、シェイプ内でテキストブロックを垂直に位置付ける [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) とは異なります。上付き・下付き文字の書式設定は [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) によって個々の部分をベースラインに対してシフトさせるもので、段落の行全体のフォント配置を設定するものではありません。

## **テキストの透明度を設定**

テキストの透明度は、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) に割り当てられた色のアルファ成分で制御します。以下の例で `alpha = 50` は 0〜255 のスケールでの ARGB アルファチャンネル値であり、透明率ではありません。

以下のコード例は、**段落全体**に透明度を適用する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // テキストの塗りつぶし色を透明に設定します。
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The transparent paragraph](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**に透明度を適用する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // テキスト部分の透明度を設定します。
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The transparent text portions](transparent_text_portions.png)

## **テキストの文字間隔を設定**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) を使用して、テキストボックス内の文字間の間隔を拡大または縮小します。例では 3 ポイントの間隔を追加しています。負の値は文字を詰めます。

以下の JavaScript コードは、**段落全体**の文字間隔を拡大する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の文字間隔を拡大する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注: 文字間隔を圧縮するには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡大します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

Aspose.Slides で描画されたテキストが、PowerPoint で表示される同じテキストよりも若干詰まって見えることがあります。これは、PowerPoint が特定のフォントのカーニング情報を無視する場合があり、フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても起こり得ます。

このような場合に、レンダリング結果を PowerPoint に近づけるには、影響を受けたフォントを使用しているテキスト部分のカーニングを無効にできます。[BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) に実際のフォントサイズより大きい値を設定します。この例では、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" が必要です。継承されたフォントを含む有効フォント名を確認し、Roboto を使用する部分に対して 100 ポイントの閾値を設定します。これにより、フォントサイズが 100 ポイント未満の該当部分のカーニングが無効になります：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

閾値未満の該当テキストに対しては、この設定によりカーニングが無効になり、PowerPoint 固有の挙動で影響を受けるフォントの Aspose.Slides の描画を PowerPoint の視覚的出力に近づけるのに役立ちます。

## **テキストのフォントプロパティを管理**

フォントプロパティは、段落レベルでは [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を、個々の部分では [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) を使用して設定できます。

以下の例では、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線の書式を適用します。個々の部分で明示的に設定された書式は、これらのデフォルトよりも優先されます：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // 段落のフォントプロパティを設定します。
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The font properties for the paragraph](font_properties_for_paragraph.png)

以下の例では、実効書式が太字である部分に対して、13 ポイントの Times New Roman、斜体、点線下線を適用します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // テキスト部分のフォントプロパティを設定します。
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The font properties for text portions](font_properties_for_text_portions.png)

## **テキストの高さ正規化を制御**

テンプレートのタイポグラフィを再現したり、文字高さの差異を調査したりする場合は、[BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) を使用します。PowerPoint では、正規化を有効にすると、テキスト部分内の文字が垂直に伸縮され、見た目の高さが均一になります。ただし、フォントが異なる場合に文字高さが同一になることは保証されません。

プロパティを [NullableBool.True または False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) に設定すると、正規化を明示的に有効または無効にできます。`NullableBool.NotDefined` はローカル設定を未定義のままにし、たとえば段落の [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) から継承させます。これは `False` を意味するわけではありません。解決されたブール値を取得するには、[PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) を使用し、[IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) を参照してください。

以下の自己完結型例では、**Arial** がインストールされていることが必要です。54 ポイントで同じ大文字、小文字、ディセンダー、アクセント文字を含む2つのテキストブロックを作成します。両方の段落はデフォルトで正規化が有効です。上部の部分は明示的に無効にし、下部の部分は継承します。フレームサイズ、余白、段落間隔は同一で、比較を一貫させるために折り返しとオートフィットは無効にしています。例は `False: false` と `NotDefined: true` を出力し、"text_height_normalization.pptx" として保存します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は保存したプレゼンテーションからエクスポートしたものです。上段は正規化が無効 (`False`) で、下段は有効設定を継承しています (`NotDefined` → `True`)。この外観を再現するには Arial をインストールしたままにしてください。

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

正規化は、フォントサイズをポイントで指定する [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) の値を変更せずに文字の高さを変えます。段落の [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) は行間を制御し、テキストフレームの [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) はテキストやコンテナのフィット方法を制御します。これらの設定は目的が異なり、レイアウト全体に独立して影響します。段落書式設定と継承の詳細については、[Manage Paragraph](/slides/ja/nodejs-java/manage-paragraph/) を参照してください。

## **取り消し線の適用と削除**

テキスト部分に [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) を使用すると、元のテキストを削除せずに訂正やキャンセルされた用語、以前の価格などに取り消し線を表示できます。取り消し線を1本または2本表示するには、[TextStrikethroughType.Single または Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) を設定します。

取り消し線を削除するには、[TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None) を渡します。これにより、周囲の書式で取り消し線が指定されていても効果が明示的に無効化されます。対照的に、[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) はローカル設定を未定義のままにし、たとえば段落から書式を継承させます。これでは必ず取り消し線が削除されるとは限りません。結果の書式（継承値を含む）を取得するには、[PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) を使用してください。

以下の自己完結型例では、3つの価格比較を作成します。各段落はラベル、以前の価格、現在の価格の部分に分かれているため、影響を受けるのは以前の価格のみです。1 行目では取り消し線を適用した後に削除し、他の行はシングルとダブルの取り消し線を保持します。この設定を変更しても、テキストと他の書式（太字の以前価格を含む）は保持されます：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // 取り消し線を適用し、最初の以前の価格から明示的に取り消し線を除去します。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（上から順に）：取り消し線なし、シングル取り消し線、ダブル取り消し線。

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **テキストの回転を設定**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) を使用して、シェイプ内の定義済みテキスト方向を設定します。

以下のコード例は、シェイプ内のテキスト方向を [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) に設定します。これにより、テキストが **反時計回りに 90 度** 回転します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The text rotation](text_rotation.png)

## **テキストフレームのカスタム回転を設定**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The custom text rotation](custom_text_rotation.png)

## **段落の行間を設定**

Aspose.Slides は、段落間隔を制御するために [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore)、[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供します。これらのプロパティの使用例は以下の通りです：

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイントで指定します。

以下の例では、最初の段落の内部間隔を行の高さの 200%（2 倍の行間）に設定します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The line spacing within the paragraph](line_spacing.png)

## **行分割の制御**

段落の行分割ルールは、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで役立ちます。以下のメソッドは [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) に属し、段落全体に適用されます：

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) はラテン文字の行分割ルールを制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) は東アジア文字の行分割ルールを制御し、行頭・行末の文字に関する制限を含みます。

これらのルールは、テキストフレーム内で自動折り返しを有効にする [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText) の代わりになるものではありません。折り返しが発生した際のレイアウトに影響を与えますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能な幅に関係なく段落内で新しい行を強制します。

以下の自己完結型例では、中国語とラテン文字を含む狭いテキストブロックを作成します。両方の行分割オプションを明示的に設定し、"line_breaking.pptx" として保存します。どちらかのルールを試すには、他方の設定を固定したまま該当する値を変更してください。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白 0 に設定しています。[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) は [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) で呼び出され、テキストサイズとフレーム寸法が固定されたままになります：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ハンギング句読点の制御**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) は、対象となる句読点が次の行に回り込むのではなく、テキスト行の右端を超えてはみ出すことを可能にします。段落全体に適用され、ハンギングインデントとは異なります。

以下の自己完結型例では、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial と水平テキストフレーム余白 0 の設定では、最後のピリオドが "sentence" の後に残り、右端を超えてはみ出します。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) に設定すると、ピリオドが別の行に配置されます。折り返しを有効にし、オートフィットを無効にして利用可能幅を固定しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

すべての句読点がハンギングできるわけではありません。上記の [フォントとレイアウト条件](#control-line-breaking) もこの比較に適用され、フォント、利用可能幅、余白、またはオートフィット設定を変更すると見た目の差がなくなることがあります。

## **テキストフレームのオートフィットタイプを設定**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの挙動を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にサイズ変更するかを制御できます。以下の例では、シェイプがテキストに合わせてサイズ変更するように設定し、結果を "autofit_type.pptx" として保存します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

自動折り返し後の行数を数え、テキストまたはシェイプの幅が結果にどのように影響するかを確認するには、[Count Rendered Lines](/slides/ja/nodejs-java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **テキストフレームのアンカーを設定**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) は、シェイプ内でテキストの垂直位置を定義します（例：上部、中央、下部）。以下の例では、最初のシェイプのテキストを下部に固定し、結果を "text_anchor.pptx" として保存します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストのタブ設定**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) を使用して、段落内のタブ位置を設定します。以下の例では、デフォルトタブ間隔を 100 ポイントにし、30 ポイントに左揃えタブ位置を追加しています。これらの設定は、タブ文字を含むテキストに影響します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The paragraph tabs](paragraph_tabs.png)

## **校正言語を設定**

Aspose.Slides は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) を提供し、テキスト部分の校正言語を設定できます。校正言語は、PowerPoint でのスペルチェックや文法チェックに使用される言語を決定します。

以下の例では、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" が必要で、少なくとも1つの段落が存在します。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は "proofing_language.pptx" として保存されます：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 校正言語の Id を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **言語メタデータのコピー**

テンプレートから多言語テキストをコピーする際は、[BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) と [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) の両方を保持してください。以下の自己完結型例では、ソース部分の言語を米英、代替言語をフランス語に設定し、テキストと識別子を新しいプレゼンテーションの部分にコピーします：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // ソースに代替言語がない場合、null は宛先の値をクリアします。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

代替言語がないソースを試すには、`"fr-FR"` の割り当てを省略してください。その場合、代替識別子は `null` となり、コピー文はデフォルト値を挿入せずにその欠如を保持します。たとえ宛先側に以前代替言語が設定されていても同様です。

これらの識別子は言語メタデータとして保存されます。保持しても、PowerPoint がどの辞書をスペルチェックや文法チェックに使用するかは決定されません。

## **デフォルト言語を設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、プレゼンテーションの読み込みまたは作成時に生成されるテキストのデフォルト言語を定義します。以下の例では、デフォルトテキスト言語を米英に設定したプレゼンテーションを作成し、テキストボックスを追加して、最初のテキスト部分の言語として `en-US` を出力します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // テキスト付きの新しい矩形シェイプを追加します。
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初の部分の言語を確認します。
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **デフォルトテキストスタイルを設定**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

以下の例では、新しいプレゼンテーションのトップレベル段落のデフォルトとして、14 ポイントの太字フォントを設定し、"default_text_style.pptx" として保存します。テキストは、より具体的な書式設定が上書きしない限り、これらのデフォルトを継承できます：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // トップレベルの段落書式を取得します。
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **All-Caps 効果でテキストを取得**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されているテキストに合わせるには、[TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は取得した文字列を大文字に変換します。

この例では、最初のスライドの最初のシェイプがテキストボックスである "sample2.pptx" が必要です。最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれます（下図参照）。

![The All Caps effect](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを取得する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

出力：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

スライド上のテーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) を使用します。セルを走査し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) で取得してテキストフレームを更新し、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat) で段落の書式設定を行います。

**PowerPoint のスライド上のテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) を [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) に設定し、グラデーションのストップ、方向、透明度を構成します。