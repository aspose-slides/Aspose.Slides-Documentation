---
title: Android で PowerPoint テキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/androidjava/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間隔
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---

## **テキストのハイライト**
Method [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) が [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) クラスに追加されました。

テキストサンプルを使用して背景色でテキスト部分をハイライトでき、PowerPoint 2019 のテキストハイライトカラー ツールと同様です。

以下のコードスニペットはこの機能の使用方法を示しています:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // すべての単語 'important' をハイライト
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// すべての個別の 'the' の出現箇所をハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose はシンプルな、[無料オンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています
{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**
Method [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) が [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) クラスに追加されました。

正規表現を使用して背景色でテキスト部分をハイライトでき、PowerPoint 2019 のテキストハイライトカラー ツールと同様です。

以下のコードスニペットはこの機能の使用方法を示しています:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // 10文字以上のすべての単語をハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの背景色の設定**
Aspose.Slides ではテキストの背景色を任意に指定できます。

この Java コードはテキスト全体の背景色を設定する方法を示しています:
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


この Java コードはテキストの一部だけの背景色を設定する方法を示しています:
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
テキストの書式設定は文書やプレゼンテーション作成時の重要な要素です。Aspose.Slides for Android via Java はスライドへのテキスト追加をサポートしますが、本項ではスライド上のテキスト段落の配置方法を解説します。以下の手順でテキスト段落を配置してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドにある Placeholder 形状にアクセスし、[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) に型変換します。
4. [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) が公開する [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) から配置対象の Paragraph を取得します。
5. Paragraph を右揃え・左揃え・中央揃え・両端揃えのいずれかに設定します。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下の通りです。
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

    // テキスト段落を中央揃えにする
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // プレゼンテーションを PPTX ファイルとして書き込む
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの透明度の設定**
本記事では Aspose.Slides for Android via Java を使用してテキスト形状の透明度プロパティを設定する方法を示します。以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下の通りです。
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // 透明度を 0% に設定
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの文字間隔の設定**
Aspose.Slides ではテキストボックス内の文字間隔を設定できます。これにより、行やブロックの視覚的密度を文字間隔の拡大・縮小で調整できます。

この Java コードは 1 行目の文字間隔を拡大し、別の行の文字間隔を縮小する方法を示しています:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 間隔を拡げる
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 間隔を縮める

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **段落のフォントプロパティの管理**
プレゼンテーションはテキストと画像の両方を含むことが多く、テキストはハイライトや企業スタイルへの適合など様々な書式設定が可能です。Aspose.Slides for Android via Java を使用してスライド上の段落のフォントプロパティを構成する方法を紹介します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の Placeholder 形状にアクセスし、[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に型変換します。
1. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) が公開する [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) から [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) を取得します。
1. 段落を両端揃えにします。
1. 段落のテキスト Portion にアクセスします。
1. FontData でフォントを定義し、Portion のフォントに設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) オブジェクトが公開する [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォント色を設定します。
1. 変更したプレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順の実装例です。未装飾のプレゼンテーションを取得し、1 枚のスライド上のフォントを整形します。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // スライドの位置を使ってスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 最初の Paragraph にアクセスする
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

    // PPTX をディスクに書き込む
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのフォントファミリの管理**
Portion は同一書式スタイルのテキストを段落内で保持するために使用されます。本記事では Aspose.Slides for Android via Java を使用してテキストボックスを作成し、特定のフォントとフォントファミリカテゴリの各種プロパティを設定する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) 種類の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられた Portion オブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) に使用するフォントを定義します。
9. 太字、斜体、下線、色、高さなど、Portion オブジェクトが公開する関連プロパティでその他のフォント属性を設定します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例です。
```java
// Presentationをインスタンス化する
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // RectangleタイプのAutoShapeを追加する
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // AutoShapeに関連付けられた塗りつぶしスタイルを削除する
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // AutoShapeに関連付けられたTextFrameにアクセスする
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // TextFrameに関連付けられたPortionにアクセスする
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Portionのフォントを設定する
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // フォントの太字プロパティを設定する
    port.getPortionFormat().setFontBold(NullableBool.True);

    // フォントの斜体プロパティを設定する
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの下線プロパティを設定する
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // フォントの高さを設定する
    port.getPortionFormat().setFontHeight(25);

    // フォントの色を設定する
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTXをディスクに書き込む
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのフォントサイズの設定**
Aspose.Slides では段落内の既存テキストや後から追加されるテキストのフォントサイズを任意に設定できます。

この Java コードは段落内のテキストのフォントサイズを設定する方法を示しています:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 最初のシェイプを取得します（例）。
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // 最初の段落を取得します（例）。
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


## **テキストの回転の設定**
Aspose.Slides for Android via Java はテキストの回転をサポートします。テキストは [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) に設定できます。任意の TextFrame のテキストを回転させる手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意の Shape をスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストを回転させます([setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-))。
6. ファイルをディスクに保存します。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Rectangle タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Rectangle に TextFrame を追加する
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


## **TextFrame のカスタム回転角度の設定**
Aspose.Slides for Android via Java はテキストフレームのカスタム回転角度設定をサポートします。本項では例を交えて RotationAngle プロパティの設定方法を示します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) が [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) と [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) インターフェイスに追加され、テキストフレームのカスタム回転角度を設定できるようになりました。RotationAngle を設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. RotationAngle プロパティを設定します([setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-))。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では RotationAngle プロパティを設定しています。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Rectangle に TextFrame を追加する
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


## **段落の行間隔の設定**
Aspose.Slides は [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat) の `SpaceAfter`、`SpaceBefore`、`SpaceWithin` プロパティを提供し、段落の行間隔を管理できます。プロパティの使用方法は次のとおりです。

* パーセンテージで行間隔を指定する場合は正の値を使用します。  
* ポイントで行間隔を指定する場合は負の値を使用します。

たとえば、`SpaceBefore` プロパティを -16 に設定すると、段落の行間隔は 16pt になります。

特定の段落の行間隔を指定する手順:

1. テキストを含む AutoShape があるプレゼンテーションを読み込みます。
2. インデックスでスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

この Java コードは段落の行間隔を指定する方法を示しています:
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


## **TextFrame の AutofitType プロパティの設定**
本項ではテキストフレームのさまざまな書式プロパティを解説します。この記事では TextFrame の AutofitType プロパティ、テキストのアンカー、テキストの回転設定方法を取り上げます。Aspose.Slides for Android via Java は任意のテキストフレームの AutofitType プロパティを設定できます。AutofitType は [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) または [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) に設定できます。[Normal] に設定すると形状は変わらず、テキストだけが調整されます。[Shape] に設定すると形状が変更され、必要なテキストだけが収まります。TextFrame の AutofitType プロパティを設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意の Shape をスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の AutofitType を設定します([setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-))。
6. ファイルをディスクに保存します。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Rectangle に TextFrame を追加する
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


## **TextFrame のアンカー設定**
Aspose.Slides for Android via Java は任意の TextFrame のアンカー設定をサポートします。TextAnchorType はテキストが形状内のどこに配置されるかを指定します。アンカーは [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) または [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed) に設定できます。TextFrame のアンカーを設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意の Shape をスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の TextAnchorType を設定します([setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-))。
6. ファイルをディスクに保存します。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Rectangle タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Rectangle に TextFrame を追加する
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
すべてのテキストタブはピクセル単位で表されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図: 2つの明示的タブと2つのデフォルトタブ**|

- EffectiveTabs.ExplicitTabCount (本例では 2) は Tabs.Count と同じです。
- EffectiveTabs コレクションにはすべてのタブ (Tabs コレクションとデフォルトタブ) が含まれます。
- EffectiveTabs.ExplicitTabCount (本例では 2) は Tabs.Count と同じです。
- EffectiveTabs.DefaultTabSize (294) はデフォルトタブ間の距離を示します (例の 3 と 4)。
- EffectiveTabs.GetTabByIndex(index) で index=0 は最初の明示的タブ (Position = 731)、index=1 は2番目のタブ (Position = 1241)。index=2 で次のタブを取得しようとすると最初のデフォルトタブ (Position = 1470) が返されます。
- EffectiveTabs.GetTabAfterPosition(pos) はテキストの後に続くタブ位置を取得します。例: テキスト "Hello World!" がある場合、"world!" の描画開始位置を知る必要があります。まず "Hello" のピクセル長さを計算し、その値で GetTabAfterPosition を呼び出すと、"world!" を描画する次のタブ位置が得られます。

## **デフォルトテキストスタイルの設定**
プレゼンテーション内のすべてのテキスト要素に同一のデフォルト書式を一括で適用したい場合は、[IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) インターフェイスの `getDefaultTextStyle` メソッドを使用して好みの書式を設定できます。下のコード例は新規プレゼンテーションのすべてのスライド上のテキストにデフォルトの太字フォント (14pt) を設定する方法を示しています。
```java
Presentation presentation = new Presentation();
try {
    // トップレベルの段落書式を取得します。
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


## **All‑Caps 効果を持つテキストの抽出**
PowerPoint では **All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されますが、元の入力は小文字のままです。Aspose.Slides でその Portion を取得すると、入力通りのテキストが返されます。対策として、[TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) が `All` を示す場合は、取得した文字列を大文字に変換して出力をスライド上の表示と一致させます。

サンプル2.pptx ファイルの最初のスライドに次のテキストボックスがあるとします。

![The All Caps effect](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています:
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


出力:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**スライド上のテーブル内のテキストを変更する方法は？**

スライド上のテーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) インターフェイスを使用します。テーブル内のすべてのセルを走査し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

テキストにグラデーションカラーを適用するには、[BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/) の `getFillFormat` メソッドを使用します。`FillFormat` を `Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを定義してテキストにグラデーション効果を作成します。