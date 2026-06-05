---
title: Android でプレゼンテーションテキストをフォーマットする
linktitle: テキストフォーマット
type: docs
weight: 50
url: /ja/androidjava/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキスト透過性
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java 経由で使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、カラー、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java 経由で Android 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。ハイライト、背景色、透過性、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定などをカバーします。

以下の例では、最初のスライドに単一のテキスト ボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

特定のサンプルに一致するテキストをハイライトする必要がある場合は、[ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) メソッドを使用します。このメソッドは一致するテキスト フラグメントにハイライト色を適用し、[ITextSearchOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextSearchOptions) と組み合わせて検索方法を制御できます（例: 完全一致語のみ）。

以下のコード例は、文字列 **"try"** のすべての出現をハイライトし、続いて単語 **"to"** のみをハイライトします。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 最初のスライドから最初のシェイプを取得します。
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // シェイプ内の単語 "try" をハイライトします。
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // シェイプ内の単語 "to" をハイライトします。
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) メソッドは、正規表現で見つかったテキストの一致箇所をハイライトします。

以下のコード例は、**7 文字以上の単語** をすべてハイライトします。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // 七文字以上のすべての単語をハイライトします。
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **テキストの背景色を設定する**

段落全体のデフォルトハイライト色を設定するには [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) を使用します。

次のコード例は、**段落全体** の背景色を設定する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![灰色の段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の背景色を設定する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) を使用して、テキスト フレーム内の段落配置を設定します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は、段落を **中央** に配置する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![配置された段落](aligned_paragraph.png)

## **テキストの透過性を設定する**

テキストの透過性は、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) に割り当てられた色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 スケールの ARGB アルファ値であり、透過率のパーセンテージではありません。

次のコード例は、**段落全体** に透過性を適用する方法を示します。

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // テキストの塗りつぶし色を透過色に設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透過段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に透過性を適用する方法を示します。

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分の透過性を設定します。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透過テキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定する**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) を使用して、テキスト ボックス内の文字間隔を拡張または縮小できます。

次の Java コードは、**段落全体** の文字間隔を拡張する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡張する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注: 文字間隔を圧縮するには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡張します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides が描画するテキストが PowerPoint の表示より若干詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニング データを無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても）。

このような場合、影響を受けるフォントを使用するテキスト部分のカーニングを無効にすると、PowerPoint の描画に近づけられます。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) を実際のフォントサイズよりかなり大きい値に設定します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この設定により、該当テキスト部分へのカーニング適用が防止され、PowerPoint 固有の動作で影響を受けるフォントの視覚的出力を Aspose.Slides の描画と合わせることができます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) を使用して段落レベルで、または [IPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPortionFormat) を使用して個々の部分で設定できます。

次のコードは、段落全体にフォントとテキスト スタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落のフォントプロパティを設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落のフォント プロパティ](font_properties_for_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に同様のプロパティを適用します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のフォントプロパティを設定します。
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定する**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) を使用して、シェイプ内のテキストの事前定義された向きを設定します。

次のコード例は、シェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **時計回りに 90 度** 回転させます。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト回転](text_rotation.png)

## **テキスト フレームのカスタム回転を設定する**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrame) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキスト フレームを時計回りに 3 度回転させます。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間を設定する**

Aspose.Slides は、[IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-)、および [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用して、行間を行の高さの割合として指定します。
* 負の値を使用して、行間をポイントで指定します。

次のコード例は、段落内の行間を指定する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の行間](line_spacing.png)

## **テキスト フレームのオートフィット タイプを設定する**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキスト フレームのアンカーを設定する**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) は、シェイプ内でテキストが垂直方向に配置される位置（上部、中央、下部など）を定義します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストのタブ設定を行う**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) および [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) を使用して、段落内のタブストップを構成します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落のタブ](paragraph_tabs.png)

## **校正言語を設定する**

Aspose.Slides は [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) を提供しており、テキスト部分の校正言語を設定できます。校正言語は、PowerPoint のスペルチェックおよび文法チェックに使用される言語を決定します。

次のコード例は、テキスト部分の校正言語を設定する方法を示します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 校正言語の ID を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルト言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // テキスト付きの新しい長方形シェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初のテキスト部分の言語を確認します。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **デフォルトテキスト スタイルを設定する**

プレゼンテーション レベルでデフォルトのテキスト書式設定を適用するには、[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--) を使用します。

次のコード例は、新しいプレゼンテーションのすべてのスライドで、サイズ 14 pt の太字フォントをデフォルトとして設定する方法を示します。

```java
Presentation presentation = new Presentation();
try {
    // トップレベルの段落フォーマットを取得します。
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **オールキャップス効果付きテキストの抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字として表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままの文字列を返します。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/TextCapType) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

以下は、sample2.pptx の最初のスライドにあるテキスト ボックスを例にしたものです。

![オールキャップス効果](all_caps_effect.png)

次のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

**スライド上のテーブル内のテキストを変更するには？**

テーブル内のテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITable) を使用します。セルを反復処理し、各セルを [ICell.getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICell#getTextFrame--) と段落書式設定を [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--) で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

グラデーションカラーを適用するには、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FillType) に設定し、グラデーション ストップ、方向、透過性を構成します。