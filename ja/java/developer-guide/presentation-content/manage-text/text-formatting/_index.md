---
title: Javaでプレゼンテーションテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
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
- テキストフレームのアンカー
- テキストのタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

本記事では、Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。ハイライト、背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー、タブ位置、言語設定などをカバーします。

以下の例では、最初のスライドに 1 つのテキストボックスがあり、次のテキストが含まれる "sample.pptx" というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

テキストフレーム内で特定のサンプルに一致するテキストをハイライトする必要がある場合は、[ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) メソッドを使用します。このメソッドは一致したテキストフラグメントにハイライト色を適用し、[TextSearchOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/) を使用して検索方法を制御できます。例えば、単語全体にのみ一致させることができます。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、次に単語全体 **"to"** のみをハイライトします。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 最初のスライドから最初のシェイプを取得します。
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // シェイプ内の単語 "try" をハイライトします。
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // シェイプ内の単語 "to" をハイライトします。
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) メソッドは正規表現で見つかったテキストの一致箇所をハイライトします。Java では、この API は [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) で利用できます。

以下のコード例は、**7 文字以上** を含むすべての単語をハイライトします。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // 7文字以上の単語をすべてハイライトします。
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **テキストの背景色の設定**

段落のデフォルトハイライト色を設定するには [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分には [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

次のコード例は、**段落全体** の背景色を設定する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![灰色の段落](gray_paragraph.png)

次のコード例は、**太字フォントのテキスト部分** の背景色を設定する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキストフレーム内の段落配置を設定するには、[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は、段落を **中央** に揃える方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![揃えられた段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御されます。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明度のパーセンテージではありません。

次のコード例は、**段落全体** に透明度を適用する方法を示します。

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // テキストの塗りつぶし色を透明色に設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![透明な段落](transparent_paragraph.png)

次のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示します。

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分の透明度を設定します。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

テキストボックス内の文字間隔を拡大または縮小するには、[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用します。

次の Java コードは、**段落全体** の文字間隔を拡大する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![段落の文字間隔](character_spacing_in_paragraph.png)

次のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注: 文字間隔を圧縮するには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡大します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングするテキストが PowerPoint で表示される同じテキストよりもわずかに詰まって見えることがあります。これは、フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても、PowerPoint が特定のフォントのカーニングデータを無視するために起こります。

このような場合にレンダリング結果を PowerPoint に近づけるには、対象フォントを使用しているテキスト部分のカーニングを無効化できます。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に実際のフォントサイズよりはるかに大きな値を設定します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この設定により、該当するテキスト部分にカーニングが適用されなくなり、PowerPoint 固有のこの動作の影響を受けるフォントに対して Aspose.Slides のレンダリングを PowerPoint のビジュアル出力に合わせるのに役立ちます。

## **テキストフォントプロパティの管理**

フォントプロパティは、段落レベルでは [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用して、個別の部分では [IPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/) を使用して設定できます。

次のコードは、段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次のコード例は、**太字フォントのテキスト部分** に同様のプロパティを適用します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転設定**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用して、シェイプ内の事前定義されたテキスト方向を設定します。

次のコード例は、シェイプ内のテキスト方向を `Vertical270` に設定します。これによりテキストは **90 度反時計回り** に回転します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転設定**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) のカスタム回転角度を設定します。

次のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間設定**

Aspose.Slides は、段落間隔を制御するために [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), および [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供します。これらのプロパティは以下のように使用します：

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイントで指定します。

次のコード例は、段落内の行間を指定する方法を示します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![段落内の行間](line_spacing.png)

## **テキストフレームのオートフィットタイプ設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナーの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御するために使用します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストフレームのアンカー設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、シェイプ内でテキストが垂直方向に配置される方法（上部、中央、下部など）を定義します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストのタブ設定**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getTabs--) を使用して、段落内のタブ位置を設定します。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は、テキスト部分の校正言語を設定できる [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供します。校正言語は、PowerPoint でのスペルチェックと文法チェックに使用される言語を決定します。

次のコード例は、テキスト部分の校正言語を設定する方法を示します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 校正言語の ID を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルト言語の設定**

プレゼンテーションの読み込みまたは作成時に生成されるテキストのデフォルト言語を定義するには、[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用します。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // テキスト付きの新しい矩形シェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初の部分の言語を確認します。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには、[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

次のコード例は、新規プレゼンテーションのすべてのスライドのテキストに対して、デフォルトで太字フォント、サイズ 14 pt を設定する方法を示します。

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

## **全大文字効果付きテキストの抽出**

PowerPoint で **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字として表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示テキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

例として、sample2.pptx ファイルの最初のスライドに次のテキストボックスがあるとします。

![全大文字効果](all_caps_effect.png)

次のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

スライド上のテーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itable/) を使用します。セルを列挙し、各セルを [ICell.getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icell/#getTextFrame--) で取得したテキストフレームと、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getParagraphFormat--) で取得した段落書式で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

グラデーションカラーをテキストに適用するには、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。