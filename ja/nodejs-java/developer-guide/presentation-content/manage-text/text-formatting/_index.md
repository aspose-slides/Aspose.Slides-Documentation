---
title: "JavaScriptでプレゼンテーションテキストをフォーマット"
linktitle: "テキストフォーマット"
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
  - "段落の配置"
  - "テキストスタイル"
  - "テキスト背景"
  - "テキスト透明度"
  - "文字間隔"
  - "フォントプロパティ"
  - "フォントファミリー"
  - "テキスト回転"
  - "回転角度"
  - "テキストフレーム"
  - "行間"
  - "オートフィットプロパティ"
  - "テキストフレームアンカー"
  - "テキストタブ設定"
  - "デフォルト言語"
  - "PowerPoint"
  - "OpenDocument"
  - "プレゼンテーション"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java 経由で Node.js 用 Aspose.Slides を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について説明します。

以下の例では、最初のスライドに単一のテキストボックスが含まれる「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストまたは正規表現の一致を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分には [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) を使用します。

以下のコード例は **段落全体** の背景色を設定する方法を示しています。

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

![灰色の段落](gray_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示しています。

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

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の整列**

テキストフレーム内の段落整列を設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) を使用します。値は中央、左揃え、右揃え、両端揃えなどが指定できます。

以下のコード例は段落を **中央** に整列する方法を示しています。

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

![整列された段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明度のパーセンテージではありません。

以下のコード例は **段落全体** に透明度を適用する方法を示しています。

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

以下のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示しています。

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

## **テキストの文字間隔の設定**

テキストボックス内の文字間隔を拡大または縮小するには [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) を使用します。

以下の JavaScript コードは **段落全体** の文字間隔を拡大する方法を示しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。

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
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡大します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニング無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示される同じテキストよりもわずかに詰まって見えることがあります。これは、PowerPoint が特定のフォントに対してカーニングデータを無視することが原因である場合があります（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても）。

このようなケースで PowerPoint に近い出力にするには、該当フォントを使用するテキスト部分のカーニングを無効にできます。[BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) を実際のフォントサイズよりかなり大きな値に設定してください。

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

この設定により、該当テキスト部分にカーニングが適用されず、PowerPoint 固有の挙動によって影響を受けるフォントの表示を Aspose.Slides と合わせることができます。

## **テキストのフォントプロパティの管理**

フォントプロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

以下のコードは段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman を段落内のすべての部分に適用します。

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

以下のコード例は **太字フォントのテキスト部分** に同様のプロパティを適用します。

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

## **テキストの回転設定**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用して、シェイプ内の事前定義されたテキスト向きを設定します。

以下のコード例はシェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **反時計回りに 90 度** 回転させます。

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

## **テキストフレームのカスタム回転設定**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

以下のコード例はシェイプ内でテキストフレームを時計回りに 3 度回転させます。

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

## **段落の行間設定**

Aspose.Slides は [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-)、[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイント単位で指定します。

以下のコード例は段落内の行間を指定する方法を示しています。

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

## **テキストフレームのオートフィットタイプ設定**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。

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

## **テキストフレームのアンカーポジション設定**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) は、テキストがシェイプ内で垂直方向にどの位置に配置されるか（上部、中央、下部など）を定義します。

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

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getTabs--) を使用して、段落内のタブストップを構成します。

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

## **校正言語の設定**

Aspose.Slides は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックで使用される言語を決定します。

以下のコード例はテキスト部分の校正言語を設定する方法を示しています。

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

    // 校正言語の ID を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルト言語の設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

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

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) を使用します。

以下のコード例は新しいプレゼンテーション内のすべてのスライドに対して、サイズ 14pt の太字フォントをデフォルトとして設定する方法を示しています。

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

## **全て大文字効果でテキストを抽出**

PowerPoint で **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は取得した文字列を大文字に変換してください。

例えば、sample2.pptx の最初のスライドに以下のテキストボックスがあるとします。

![全大文字効果](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。

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

**スライド上のテーブルのテキストを変更する方法は？**

テーブルのテキストを変更するには [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) を使用します。セルを列挙し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/#getTextFrame--) で取得したテキストフレームと、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) で取得した段落書式で更新します。

**PowerPoint スライドのテキストにグラデーション色を適用する方法は？**

グラデーション色をテキストに適用するには [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。