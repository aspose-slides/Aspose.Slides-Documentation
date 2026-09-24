---
title: JavaScript でプレゼンテーション テキストをフォーマットする
linktitle: テキスト フォーマット
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
- 段落の配置
- テキスト スタイル
- テキスト 背景
- テキスト 透明度
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
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この文章では、Node.js 用 Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定などを取り上げています。

以下の例では、最初のスライドに単一のテキスト ボックスがあり、次のテキストが含まれている「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラル テキストや正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/nodejs-java/search-and-replace-text/)をご覧ください。

## **テキストの背景色を設定**

段落全体のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分に対しては [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) を使用します。

次のコード例は **段落全体** の背景色を設定する方法を示しています。

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

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどが指定できます。

次のコード例は段落を **中央** に配置する方法を示しています。

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

![配置された段落](aligned_paragraph.png)

## **テキストの透明度を設定**

テキストの透明度は、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御します。下記例の `alpha = 50` は 0〜255 のスケールでの ARGB アルファ値であり、透過率のパーセンテージではありません。

次のコード例は **段落全体** に透明度を適用する方法を示しています。

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

## **テキストの文字間隔を設定**

テキスト ボックス内の文字間隔を拡張または縮小するには [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) を使用します。

次の JavaScript コードは **段落全体** の文字間隔を拡張する方法を示しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

以下のコード例は **太字フォントのテキスト部分** の文字間隔を拡張する方法を示しています。

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
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡張します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示される同じテキストよりやや詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング データを無視するために発生します（フォントに有効なカーニング情報が含まれていても、PowerPoint 設定でカーニングが有効になっている場合でも）。

このようなケースで PowerPoint の表示に近づけるには、影響を受けたフォントを使用しているテキスト部分のカーニングを無効化します。 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) に実際のフォント サイズよりはるかに大きい値を設定します。

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

この設定により、該当テキスト部分へのカーニング適用が防止され、PowerPoint 固有の動作の影響を受けるフォントで Aspose.Slides のレンダリングを PowerPoint の視覚的出力に合わせることができます。

## **テキストのフォント プロパティを管理**

フォント プロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) を使用して段落レベルで、または [PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

次のコードは段落全体のフォントとテキスト スタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

            // テキスト部分のフォント プロパティを設定します。
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

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定**

テキストの向きを事前定義されたものに設定するには、[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用します。

次のコード例はシェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **90 度反時計回り** に回転させます。

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

## **テキスト フレームのカスタム回転を設定**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

次のコード例はシェイプ内のテキスト フレームを時計回りに 3 度回転させます。

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

![カスタム テキスト回転](custom_text_rotation.png)

## **段落の行間を設定**

Aspose.Slides は [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-)、および [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間が行の高さのパーセンテージとして指定されます。
* 負の値を使用すると、行間がポイントで指定されます。

次のコード例は段落内の行間を指定する方法を示します。

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

## **テキスト フレームのオートフィット タイプを設定**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小するか、はみ出すか、シェイプが自動的にサイズ変更されるかを制御できます。

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

自動折り返し後の行数をカウントし、テキストやシェイプの幅が結果にどのように影響するかを確認するには、[レンダリングされた行のカウント](/slides/ja/nodejs-java/manage-paragraph/)をご覧ください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカーを設定**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) は、シェイプ内でテキストが上下方向に配置される位置（上部、中央、下部など）を定義します。

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

段落のタブストップを構成するには、[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getTabs--) を使用します。

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

## **校正言語を設定**

Aspose.Slides は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックおよび文法チェックで使用される言語を決定します。

次のコード例はテキスト部分の校正言語を設定する方法を示します。

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

## **既定言語を設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストの既定言語を定義します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // テキストを含む新しい長方形シェイプを追加します。
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初のテキスト部分の言語を確認します。
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **既定テキスト スタイルを設定**

プレゼンテーション レベルで既定のテキスト書式設定を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) を使用します。

次のコード例は新しいプレゼンテーションのすべてのスライドで、太字フォントかつ 14pt のサイズを既定テキスト スタイルとして設定する方法を示します。

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

## **全角効果（All Caps）でテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上では大文字として表示されます。Aspose.Slides でそのテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

例として、sample2.pptx の最初のスライドに次のテキスト ボックスがあるとします。

![All Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

**スライド上の表のテキストを変更するにはどうすればよいですか？**

スライド上の表のテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) を使用します。セルを走査し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/#getTextFrame--) で取得したテキストフレームと、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) で取得した段落書式で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

グラデーションカラーをテキストに適用するには、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。