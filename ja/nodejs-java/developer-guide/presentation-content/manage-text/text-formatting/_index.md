---
title: JavaScript でプレゼンテーション テキストをフォーマット
linktitle: テキスト フォーマット
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキスト スタイル
- テキスト 背景
- テキスト 透過性
- 文字間隔
- フォント プロパティ
- フォント ファミリ
- テキスト 回転
- 回転角度
- テキスト フレーム
- 行間
- オートフィット プロパティ
- テキスト フレーム アンカー
- テキスト タブ設定
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

この記事では、Node.js 用 Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。ハイライト、背景色、透過性、文字間隔、フォント プロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブ位置、言語設定について取り上げています。

以下の例では、最初のスライドに単一のテキスト ボックスがあり、次のテキストが含まれる「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

テキスト フレーム内で特定のサンプルに一致するテキストをハイライトする必要がある場合は、[TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) メソッドを使用します。このメソッドは一致するテキスト フラグメントにハイライト色を適用し、[TextSearchOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/) と組み合わせて検索方法を制御できます（例: 完全一致のみ）。

以下のコード例は、文字列 **"try"** のすべての出現箇所にハイライトを付け、次に単語全体 **"to"** のみをハイライトします。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // シェイプ内の単語 "try" をハイライトします。
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // シェイプ内の単語 "to" をハイライトします。
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現によるテキストのハイライト**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) メソッドは、正規表現で見つかったテキスト一致にハイライトを付けます。Node.js via Java では、この API は [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) 上で提供されます。

以下のコード例は、**7 文字以上** の単語すべてにハイライトを付けます。

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // 7 文字以上の単語すべてをハイライトします。
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![正規表現を使用したハイライトされたテキスト](highlighted_text_using_regex.png)

## **テキストの背景色を設定**

段落全体のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を、個々のテキスト ポーションに対しては [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) を使用します。

以下のコード例は、**段落全体** の背景色を設定する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![灰色の段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション** に背景色を設定する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト ポーションのハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![灰色のテキスト ポーション](gray_text_portions.png)

## **テキスト段落の配置**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) を使用して、テキスト フレーム内の段落配置を設定できます。値は中央、左寄せ、右寄せ、両端揃えなどがあります。

以下のコード例は、段落を **中央** に揃える方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![揃えられた段落](aligned_paragraph.png)

## **テキストの透過性を設定**

テキストの透過性は、[PortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファ値であり、透過率ではありません。

以下のコード例は、**段落全体** に透過性を適用する方法を示します。

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![透過された段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション** に透過性を適用する方法を示します。

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // テキスト ポーションの透過性を設定します。
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

![透過されたテキスト ポーション](transparent_text_portions.png)

## **テキストの文字間隔を設定**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) を使用して、テキスト ボックス内の文字間隔を拡大または縮小できます。

以下の JavaScript コードは、**段落全体** の文字間隔を拡大する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション** の文字間隔を拡大する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注: 文字間隔を縮めるには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡張します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト ポーション内の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示されるテキストよりもやや詰まって見えることがあります。これは、PowerPoint が特定のフォントのカーニング データを無視することが原因で、フォント自体に有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても起こります。

このようなケースで PowerPoint に近い出力にするには、影響を受けるフォントを使用するテキスト ポーションのカーニングを無効にできます。実際のフォント サイズよりはるかに大きい値を [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) に設定してください。

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この設定により、該当するテキスト ポーションへのカーニング適用が防止され、PowerPoint 特有の動作の影響を受けるフォントで Aspose.Slides のレンダリングを PowerPoint のビジュアル出力に近づけることができます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を介して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) を介して個々のポーションで設定できます。

以下のコードは、段落全体にフォントとテキスト スタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべてのポーションに適用します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // 段落のフォント プロパティを設定します。
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

![段落のフォント プロパティ](font_properties_for_paragraph.png)

以下のコード例は、**太字フォントのテキスト ポーション** に同様のプロパティを適用します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // テキスト ポーションのフォント プロパティを設定します。
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

![テキスト ポーションのフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用して、シェイプ内のテキストの事前定義された向きを設定できます。

以下のコード例は、シェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **90 度反時計回り** に回転させます。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキストの回転](text_rotation.png)

## **テキスト フレームのカスタム回転を設定**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) の任意の回転角度を設定できます。

以下のコード例は、シェイプ内のテキスト フレームを時計回りに 3 度回転させます。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![カスタム テキスト回転](custom_text_rotation.png)

## **段落の行間を設定**

Aspose.Slides は、[ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-)、および [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間が行の高さのパーセンテージとして指定されます。
* 負の値を使用すると、行間がポイント単位で指定されます。

以下のコード例は、段落内の行間を指定する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の行間](line_spacing.png)

## **テキスト フレームのオートフィット タイプを設定**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキスト フレームのアンカーを設定**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) は、テキストがシェイプ内で垂直方向にどの位置に配置されるか（上部、中央、下部など）を定義します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストのタブ位置を設定**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getTabs--) を使用して、段落内のタブ ストップを構成します。

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **校正言語を設定**

Aspose.Slides は [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト ポーションの校正言語を設定できます。校正言語は、PowerPoint でのスペルチェックと文法チェックに使用される言語を決定します。

以下のコード例は、テキスト ポーションの校正言語を設定する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 校正言語の Id を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルト言語を設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // テキスト付きの新しい長方形シェイプを追加します。
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初のポーションの言語をチェックします。
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **デフォルト テキスト スタイルを設定**

プレゼンテーション レベルでデフォルトのテキスト書式設定を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) を使用します。

以下のコード例は、新規プレゼンテーションのすべてのスライドで、太字かつサイズ 14 pt のデフォルトフォントを設定する方法を示します。

```javascript
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

## **全大文字効果でテキストを抽出**

PowerPoint で **All Caps** フォント効果を適用すると、元は小文字で入力されていてもスライド上で大文字で表示されます。Aspose.Slides でそのテキスト ポーションを取得すると、ライブラリは入力されたままの文字列を返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合に返された文字列を大文字に変換します。

例として、sample2.pptx の最初のスライドに次のテキスト ボックスがあるとします。

![全大文字効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

テーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) を使用します。セルを反復処理し、[Cell.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/#getTextFrame--) で各セルのテキスト フレームを取得し、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) で段落書式を更新します。

**PowerPoint スライドのテキストにグラデーション カラーを適用するには？**

テキストにグラデーション カラーを適用するには、[PortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getFillFormat--) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透過性を構成します。