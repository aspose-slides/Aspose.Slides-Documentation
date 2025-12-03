---
title: "JavaでPowerPointのテキストをフォーマット"
linktitle: "テキスト書式設定"
type: docs
weight: 50
url: /ja/java/text-formatting/
keywords:
- "ハイライトテキスト"
- "正規表現"
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
- "テキストタブ"
- "デフォルト言語"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---

## **テキストのハイライト**

Method [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) class.

テキストサンプルを使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキストハイライト カラー ツールと同様です。

以下のコードスニペットはこの機能の使用方法を示しています：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // すべての 'important' 単語をハイライト
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// すべての個別の 'the' 出現箇所をハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose はシンプルな、[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています
{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**

Method [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) has been added to [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) class.

正規表現を使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキストハイライト カラー ツールと同様です。

以下のコードスニペットはこの機能の使用方法を示しています：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // 10文字以上の単語すべてをハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの背景色を設定**

Aspose.Slides を使用すると、テキストの背景色を好みの色に指定できます。

This Java code shows you how to set the background color for an entire text:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


This Java code shows you how to set the background color for only a portion of a text:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **テキスト段落の配置**

Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Java supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for Java:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドにあるプレースホルダー シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) に型変換します。
4. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) が公開する [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) から、配置する必要のある Paragraph を取得します。
5. Paragraph を配置します。段落は右揃え、左揃え、中央揃え、両端揃えに設定できます。
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

The implementation of the above steps is given below.
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 両方のプレースホルダーのテキストを変更する
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // プレースホルダーの最初の段落を取得する
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // テキスト段落を中央揃えに設定する
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの透明度を設定**

This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Java. In order to set the transparency to text. Please follow the steps below:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. シャドウの色を設定します。
4. プレゼンテーションを PPTX ファイルとして書き出します。

The implementation of the above steps is given below.
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // 透明度を0％に設定
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの文字間隔を設定**

Aspose.Slides allows you to set the space between letters in a textbox. This way, you get to adjust the visual density of a line or block of text by expanding or condensing the spacing between characters.

This Java code shows you how to expand the spacing for one line of text and condense the spacing for another line:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 拡張
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 縮小

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **段落のフォントプロパティを管理**

Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Java to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for Java:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダー シェイプにアクセスし、[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に型変換します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) が公開する [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) を取得します。
5. 段落を両端揃えにします。
6. 段落のテキスト Portion にアクセスします。
7. FontData を使用してフォントを定義し、テキスト Portion のフォントを設定します。
   - フォントを太字に設定します。
   - フォントを斜体に設定します。
8. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion) オブジェクトが公開する [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォントの色を設定します。
9. [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとしてプレゼンテーションを書き出します。

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // スライド位置を使用してスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 最初の段落にアクセスする
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 最初の Portion にアクセスする
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // 新しいフォントを定義する
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // 新しいフォントを Portion に割り当てる
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // フォントを太字に設定する
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // フォントを斜体に設定する
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの色を設定する
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // PPTX をディスクに保存する
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのフォント ファミリーを管理**

A portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Java to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) が公開する Portion オブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion) に使用するフォントを定義します。
9. 太字、斜体、下線、色、高さなど、Portion オブジェクトが公開する関連プロパティを使用して他のフォントプロパティを設定します。
10. PPTX ファイルとしてプレゼンテーションを書き出します。

```java
// Presentation をインスタンス化する
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // AutoShape に関連付けられた塗りつぶしスタイルを削除する
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // AutoShape に関連付けられた TextFrame にアクセスする
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // TextFrame に関連付けられた Portion にアクセスする
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Portion のフォントを設定する
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // フォントの太字プロパティを設定する
    port.getPortionFormat().setFontBold(NullableBool.True);

    // フォントの斜体プロパティを設定する
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの下線プロパティを設定する
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // フォントのサイズを設定する
    port.getPortionFormat().setFontHeight(25);

    // フォントの色を設定する
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX をディスクに書き込む
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのフォントサイズを設定**

Aspose.Slides allows you to choose your preferred font size for existing text in a paragraph and other texts that may be added to the paragraph later.

This Java code shows you how to set the font size for texts contained in a paragraph:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 例として最初のシェイプを取得します。
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // 例として最初の段落を取得します。
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // 段落内のすべてのテキスト Portion のデフォルトフォントサイズを 20 pt に設定します。 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // 段落内の現在のテキスト Portion のフォントサイズを 20 pt に設定します。 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **テキストの回転を設定**

Aspose.Slides for Java allows developers to rotate the text. Text could be set to appear as [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) or [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). To rotate the text of any TextFrame, please follow the steps below:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意の Shape を追加します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストを回転させます。
6. ファイルをディスクに保存します。

```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 矩形に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセスする
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // テキストフレーム用の Paragraph オブジェクトを作成する
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用の Portion オブジェクトを作成する
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存する
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **TextFrame のカスタム回転角度を設定**

Aspose.Slides for Java now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new methods [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) and [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) have been added to [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) and [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle, Please follow the steps below:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [RotationAngle プロパティ](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) を設定します。
4. PPTX ファイルとしてプレゼンテーションを書き出します。

In the example given below, we set the RotationAngle property.
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // 矩形に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセスする
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // テキストフレーム用の Paragraph オブジェクトを作成する
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用の Portion オブジェクトを作成する
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存する
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落の行間**

Aspose.Slides provides properties under [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` and `SpaceWithin`—that allow you to manage the line spacing for a paragraph. The three properties are used this way:

* 段落の行間をパーセンテージで指定する場合は、正の値を使用します。 
* 段落の行間をポイントで指定する場合は、負の値を使用します。

例えば、`SpaceBefore` プロパティを -16 に設定することで、段落に 16pt の行間を適用できます。

This is how you specify the line spacing for a specific paragraph:

1. テキストが含まれる AutoShape を含むプレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

This Java code shows you how to specify the line spacing for a paragraph:
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("Fonts.pptx");
try {
    // インデックスでスライドの参照を取得する
    ISlide sld = pres.getSlides().get_Item(0);
    
    // TextFrame にアクセスする
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Paragraph にアクセスする
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Paragraph のプロパティを設定する
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // プレゼンテーションを保存する
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **TextFrame の AutofitType プロパティを設定**

In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for Java allows developers to set AutofitType property of any text frame. AutofitType could be set to [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) or [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). If set to [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class のインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の AutofitType を設定します。
6. ファイルをディスクに保存します。

```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // 矩形に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセスする
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // テキストフレーム用の Paragraph オブジェクトを作成する
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用の Portion オブジェクトを作成する
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存する
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **TextFrame のアンカーを設定**

Aspose.Slides for Java allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. AnchorType could be set to [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) or [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). To set Anchor of any TextFrame, please follow the steps below:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の TextAnchorType を設定します。
6. ファイルをディスクに保存します。

```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 矩形に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセスする
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // テキストフレーム用の Paragraph オブジェクトを作成する
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用の Portion オブジェクトを作成する
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存する
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレゼンテーションのタブと EffectiveTabs**

All text tabulations are given in pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|

- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs).
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Hello World!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".

## **デフォルト テキスト スタイルを設定**

If you need to apply the same default text formatting to all text elements of a presentation at once, then you can use the `getDefaultTextStyle` method from the [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) interface and set the preferred formatting. The code example below shows how to set the default bold font (14 pt) for the text on all slides in a new presentation.
```java
Presentation presentation = new Presentation();
try {
    // トップレベルの段落フォーマットを取得する。
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **All-Caps 効果でテキストを抽出**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To handle this, check [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/)—if it indicates `All`, simply convert the returned string to uppercase so that your output matches what users see on the slide.

Let’s say we have the following text box on the first slide of the sample2.pptx file.

![All Caps 効果](all_caps_effect.png)

The code example below shows how to extract the text with the **All Caps** effect aplyied:
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

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


出力：
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**How to modify text in a table on a slide?**

スライド上のテーブル内のテキストを変更するには、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) インターフェイスを使用します。テーブル内のすべてのセルを反復処理し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**How to apply gradient color to text in a PowerPoint slide?**

テキストにグラデーションカラーを適用するには、[BasePortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/) の `getFillFormat` メソッドを使用します。`FillFormat` を `Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを定義して、テキストにグラデーション効果を作成します。