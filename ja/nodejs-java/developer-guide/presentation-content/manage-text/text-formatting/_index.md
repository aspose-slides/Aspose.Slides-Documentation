---
title: JavaScriptでプレゼンテーションテキストをフォーマットする
linktitle: テキストの書式設定
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
- 段落の整列
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキストの回転
- 回転角度
- テキストフレーム
- 行間隔
- 自動サイズ調整プロパティ
- テキストフレームアンカー
- テキストのタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットし、スタイルを設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Node.js via Java を使用して PowerPoint と OpenDocument のプレゼンテーションでテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、AutoFit 動作、テキストのアンカー、タブストップ、言語設定などをカバーします。

特に記載がない限り、例は [sample.pptx](sample.pptx) を使用します。最初のスライドの最初の図形はテキストボックスで、最初の段落に以下のテキストが含まれています。スライドと図形のインデックスは 0 から始まります。太字部分を選択する例は、継承された太字書式を含む有効な書式を使用します。

![サンプルテキスト](sample_text.png)

文字列や正規表現の一致を検索してハイライトする方法は、[Search and Replace Text](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定する**

段落のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) を使用します。

次の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分で明示的に設定されたハイライト色はこのデフォルトより優先されます:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グレーの段落](gray_paragraph.png)

以下のコード例は **太字フォント** のテキスト部分の背景色を設定する方法を示します:

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
            // テキスト部分のハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グレーのテキスト部分](gray_text_portions.png)

## **テキスト段落を揃える**

テキストフレーム内の段落の配置を設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) を使用します。値には中央揃え、左揃え、右揃え、均等割り付けなどがあります。

次のコード例は段落を **中央** に揃える方法を示します:

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

結果:

![揃えた段落](aligned_paragraph.png)

## **テキストの透明度を設定する**

テキストの透明度は [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) に割り当てられた色のアルファコンポーネントで制御します。以下の例では `alpha = 50` は 0～255 のスケールの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

次のコード例は **段落全体** に透明度を適用する方法を示します:

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

    // テキストの塗りつぶし色を透明色に設定します。
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明な段落](transparent_paragraph.png)

次のコード例は **太字フォント** のテキスト部分に透明度を適用する方法を示します:

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

結果:

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定する**

テキストボックス内の文字間隔を拡大または縮小するには [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) を使用します。例では 3 ポイントの間隔を追加しています。負の値はテキストを縮めます。

次の JavaScript コードは **段落全体** の文字間隔を拡大する方法を示します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を広げます。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

次のコード例は **太字フォント** のテキスト部分の文字間隔を拡大する方法を示します:

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
            // 注: 文字間隔を縮めるには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を広げます。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定のフォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示より若干詰まって見えることがあります。これは PowerPoint が特定のフォントのカーニングデータを無視するためです（フォントに有効なカーニング情報があり、PowerPoint の設定でカーニングが有効になっていても）。

このような場合、該当フォントを使用するテキスト部分のカーニングを無効にできます。実際のフォントサイズより大きい値を [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) に設定します。この例は最初のスライドの最初の図形がテキストボックスである "presentation.pptx" を前提とします。効果的なフォント名（継承されたフォントも含む）をチェックし、Roboto を使用する部分に対して 100 ポイントの閾値を設定します。これにより、100 ポイント未満のフォントサイズの該当部分のカーニングが無効になります:

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

閾値以下の該当テキストに対して、この設定はカーニングを防止し、PowerPoint 固有の動作の影響を受けるフォントの表示結果を Aspose.Slides のレンダリングとより近づけることができます。

## **テキストフォントプロパティを管理する**

フォントプロパティは [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を介して段落レベルで、または個々の部分に対して [PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) を介して設定できます。

次の例は最初の段落のデフォルトフォントを 12 ポイント Times New Roman、太字、斜体、点線下線に設定します。個々の部分で明示的に設定された書式はこれらのデフォルトより優先されます:

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

結果:

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次の例は効果的な書式が太字である部分に対して、13 ポイント Times New Roman、斜体、点線下線を適用します:

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

結果:

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定する**

テキストの向きを事前定義されたものに設定するには [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用します。

次のコード例はテキストの向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textverticaltype/) に設定し、テキストを **90 度反時計回り** に回転させます:

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

結果:

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転を設定する**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) のカスタム回転角度を設定できます。

次のコード例は図形内のテキストフレームを時計回りに 3 度回転させます:

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

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間を設定する**

Aspose.Slides は [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-)、および [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行間を行の高さの割合で指定します。
* 負の値は行間をポイントで指定します。

次の例は最初の段落の内部間隔を行の高さの 200%（二重行間）に設定します:

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

結果:

![段落内の行間](line_spacing.png)

## **改行を制御する**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。次のメソッドは [ParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) は東アジア文字の改行規則を制御し、行頭や行末の文字に対する制限を含みます。

これらの規則は [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) を置き換えるものではなく、テキストフレーム内の自動折り返しを有効にします。折り返しが発生したときのレイアウトに影響しますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能幅に関係なく段落内で新しい行を強制します。

次の単体例は中国語とラテン文字を含む狭いテキストブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" として保存します。ルールを試すには、もう一方の設定を固定したまま該当値を変更します。この例は 24 ポイント Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白ゼロで作成しています。[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) は [TextAutofitType.None](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textautofittype/) に設定し、テキストサイズとフレームサイズを固定しています。

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

## **ハンギング句読点を制御する**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) により、対象の句読点がテキスト行の右端を超えて伸びることができます（次の行に占めさせない）。段落全体に適用され、ハンギングインデントとは異なります。

次の単体例は幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイント Arial、水平余白ゼロの設定で、最終的な句点は "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効で、AutoFit は無効にして利用可能幅を固定しています。

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

すべての句読点がハンギングできるわけではありません。可視結果はフォントの可用性やレイアウトに依存します。フォント、利用可能幅、余白、AutoFit 設定を変更すると可視差が消えることがあります。

## **テキストフレームの AutoFit タイプを設定する**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) はテキストがコンテナの境界を超えたときの挙動を決定します。テキストを縮小するか、はみ出すか、形状を自動的にリサイズするかを制御できます。次の例は形状をテキストに合わせてリサイズし、結果を "autofit_type.pptx" として保存します。

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

自動折り返し後の行数をカウントし、テキストまたは形状幅の変化が結果に与える影響を確認するには、[Count Rendered Lines](/slides/ja/nodejs-java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかは判断できません。

## **テキストフレームのアンカーを設定する**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) はテキストが形状内で垂直方向にどこに配置されるか（上部、中央、下部など）を定義します。次の例はテキストを最初の図形の下部にアンカーし、結果を "text_anchor.pptx" として保存します。

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

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getTabs--) を使用して段落のタブストップを構成します。次の例はデフォルトタブ間隔を 100 ポイントに設定し、30 ポイントに左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

結果:

![段落のタブ](paragraph_tabs.png)

## **校正言語を設定する**

Aspose.Slides は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

次の例は最初のスライドの最初の図形がテキストボックスである "presentation.pptx" を前提とし、最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は "proofing_language.pptx" として保存されます:

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

## **既定言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストの既定言語を定義します。次の例は既定テキスト言語を米国英語 (US English) に設定したプレゼンテーションを作成し、テキストボックスを追加し、最初のテキスト部分の言語として `en-US` を出力します。

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

## **既定テキストスタイルを設定する**

プレゼンテーションレベルで既定のテキスト書式を適用するには [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) を使用します。

次の例は新しいプレゼンテーションの上位段落に対して 14 ポイント太字フォントを既定として設定し、"default_text_style.pptx" として保存します。テキストはこれらの既定を継承しますが、より具体的な書式が上書きします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // トップレベルの段落フォーマットを取得します。
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

## **All-Caps 効果でテキストを抽出する**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、実際に入力されたテキストは小文字のままです。Aspose.Slides でそのようなテキスト部分を取得すると、入力時の文字列がそのまま返されます。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

この例は最初のスライドの最初の図形がテキストボックスである "sample2.pptx" を使用します。その最初の段落の最初の部分は **All Caps** 効果が適用された "Hello, Aspose!" です。以下の画像をご参照ください。

![All-Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します:

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

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更するには？**

テーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) を使用します。セルを反復処理し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/#getTextFrame--) と [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) を介して更新します。

**PowerPoint のスライド上のテキストにグラデーションカラーを適用するには？**

テキストにグラデーションカラーを適用するには、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。