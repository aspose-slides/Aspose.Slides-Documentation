---
title: テキストの書式設定
type: docs
weight: 50
url: /java/text-formatting/
keywords:
- テキストを強調表示
- 正規表現
- テキスト段落の整列
- テキストの透過性
- 段落のフォントプロパティ
- フォントファミリー
- テキストの回転
- カスタム角度の回転
- テキストフレーム
- 行間
- 自動調整プロパティ
- テキストフレームのアンカー
- テキストのタブ設定
- デフォルトのテキストスタイル
- Java
- Aspose.Slides for Java
description: "Javaでテキストとテキストフレームのプロパティを管理および操作する"
---

## **テキストを強調表示**
メソッド [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) が [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) クラスに追加されました。

これは、PowerPoint 2019のテキスト強調表示ツールに似て、テキストサンプルを使用して背景色でテキスト部分を強調表示することを許可します。

以下のコードスニペットは、この機能を使用する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // 'important'というすべての単語を強調表示
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// 'the'のすべての出現を強調表示
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Asposeは、シンプルな[無料のオンラインPowerPoint編集サービス](https://products.aspose.app/slides/editor)を提供しています。

{{% /alert %}} 

## **正規表現を使用してテキストを強調表示**

メソッド [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) が [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) クラスに追加されました。

これは、PowerPoint 2019のテキスト強調表示ツールに似て、正規表現を使用して背景色でテキスト部分を強調表示することを許可します。

以下のコードスニペットは、この機能を使用する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // 10文字以上のすべての単語を強調表示
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストの背景色を設定**

Aspose.Slidesを使用すると、テキストの背景色を指定できます。

このJavaコードは、テキスト全体の背景色を設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("ブラック");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" 赤 ");

    Portion portion3 = new Portion("ブラック");
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

このJavaコードは、テキストの一部分のみの背景色を設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("ブラック");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" 赤 ");

    Portion portion3 = new Portion("ブラック");
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
            .filter(p -> p.getText().contains("赤"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **テキスト段落の整列**

テキストの書式設定は、あらゆる種類の文書やプレゼンテーションを作成する際の重要な要素の1つです。Aspose.Slides for Java がスライドにテキストを追加することをサポートしていますが、このトピックでは、スライド内のテキスト段落の整列を制御する方法を見ていきます。以下の手順に従って、Aspose.Slides for Java を使用してテキスト段落を整列してください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダーシェイプにアクセスし、それを [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) としてキャストします。
4. [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) によって公開される [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) から整列が必要な段落を取得します。
5. 段落を整列します。段落は右、左、中央、均等に整列できます。
6. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

上記の手順の実装は以下の通りです。

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShapeとしてキャストする
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 両方のプレースホルダーのテキストを変更する
    tf1.setText("中央揃え by Aspose");
    tf2.setText("中央揃え by Aspose");

    // プレースホルダーの最初の段落を取得
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // テキスト段落を中央に整列
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // PPTXファイルとしてプレゼンテーションを書き出し
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストの透明度を設定**

この記事では、Aspose.Slides for Java を使用して任意のテキストシェイプに透明度プロパティを設定する方法を示しています。テキストに透明度を設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションを PPTX ファイルとして書き込みます。

上記の手順の実装は以下の通りです。

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - 透明度は: "+ (shadowColor.getAlpha() / 255f) * 100);

    // 透明度をゼロパーセントに設定
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストの文字間隔を設定**

Aspose.Slides を使用すると、テキストボックス内の文字間隔を設定することができます。この方法で、文字間を拡大または縮小することで、行またはテキストブロックの視覚密度を調整できます。

この Java コードは、テキストの1行の間隔を拡大し、別の行の間隔を凝縮する方法を示しています：

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 拡大
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 縮小

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **段落のフォントプロパティを管理**

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは特定のセクションや単語を強調表示するため、または企業スタイルに準拠するために、さまざまな方法で書式設定できます。テキストの書式設定は、プレゼンテーションの内容の外観や感触を変えるのに役立ちます。この記事では、Aspose.Slides for Java を使用してスライド上のテキストの段落のフォントプロパティを構成する方法を示します。Aspose.Slides for Java を使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内のプレースホルダーシェイプにアクセスし、それを [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にキャストします。
1. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) によって公開される [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) から [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) を取得します。
1. 段落を均等に整えます。
1. 段落のテキストポーションにアクセスします。
1. FontData を使用してフォントを定義し、テキストポーションのフォントをそれに応じて設定します。
   1. フォントを太字に設定します。
   2. フォントを斜体に設定します。
1. [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォントの色を設定します。
1. 修正されたプレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

上記の手順の実装は以下の通りです。それは、装飾のないプレゼンテーションを受け取り、スライドの1つにフォントをフォーマットします。

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // スライドの位置を使用してスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShapeとしてキャストする
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 最初の段落にアクセス
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 最初のポーションにアクセス
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // 新しいフォントを定義
    FontData fd1 = new FontData("エレファント");
    FontData fd2 = new FontData("カステラ");

    // ポーションに新しいフォントを割り当てる
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // フォントを太字に設定
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // フォントを斜体に設定
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの色を設定
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // PPTXを書き込む
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストのフォントファミリーを管理**

ポーションは、段落内で同じ書式設定スタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for Java を使用してテキストボックスを作成し、特定のフォントとフォントファミリーカテゴリのさまざまなプロパティを定義する方法を示します。テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) 型の [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に関連付けられたポーションオブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion) に対して使用するフォントを定義します。
9. 太字、斜体、下線、色、高さなどの他のフォントプロパティを、ポーションオブジェクトによって公開された関連プロパティを使用して設定します。
10. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

上記の手順の実装は以下の通りです。

```java
// Presentationをインスタンス化
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 四角形型のAutoShapeを追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // AutoShapeに関連付けられた塗りつぶしスタイルを削除
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // AutoShapeに関連付けられたTextFrameにアクセス
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // TextFrame に関連付けられたポーションにアクセス
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // ポーションのフォントを設定
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // フォントの太字プロパティを設定
    port.getPortionFormat().setFontBold(NullableBool.True);

    // フォントの斜体プロパティを設定
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの下線プロパティを設定
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // フォントの高さを設定
    port.getPortionFormat().setFontHeight(25);

    // フォントの色を設定
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTXを書き込む 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **テキストのフォントサイズを設定**

Aspose.Slides では、段落内の既存のテキストや後で追加される他のテキストに対して好みのフォントサイズを選択できます。

この Java コードは、段落内のテキストに対してフォントサイズを設定する方法を示しています：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 最初のシェイプを取得
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // 最初の段落を取得
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // 段落内のすべてのテキストポーションに対してデフォルトのフォントサイズを20ptに設定
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // 段落内の現在のテキストポーションに対してフォントサイズを20ptに設定
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

Aspose.Slides for Java は、開発者がテキストを回転させることを可能にします。テキストは [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) のいずれかとして表示されるように設定できます。テキストフレームのテキストを回転させるには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストを[回転させます](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-)。
6. ファイルをディスクに保存します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 四角形型のAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 四角形にテキストフレームを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // テキストフレーム用の段落オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("素早い茶色の狐が怠けた犬を飛び越えます。素早い茶色の狐が怠けた犬を飛び越えます。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **TextFrame のカスタム回転角度を設定**

Aspose.Slides for Java は、テキストフレームのカスタム回転角度を設定することをサポートしました。このトピックでは、Aspose.Slides で RotationAngle プロパティを設定する方法を示す例を見ていきます。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) が [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) と [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) インターフェイスに追加され、テキストフレームのカスタム回転角度を設定できます。RotationAngle を設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [RotationAngle プロパティを設定](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-)します。
4. プレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、RotationAngle プロパティを設定します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 四角形型のAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // 四角形にテキストフレームを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // テキストフレーム用の段落オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("テキストの回転例。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落の行間を設定**

Aspose.Slidesは、[`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat) の下にあるプロパティ `SpaceAfter`、`SpaceBefore`、`SpaceWithin` を提供しており、段落の行間を管理できます。これらの3つのプロパティは、次のように使用されます：

* 段落の行間をパーセンテージで指定するには、正の値を使用します。
* 段落の行間をポイントで指定するには、負の値を使用します。

例えば、段落に16ptの行間隔を適用するには、`SpaceBefore` プロパティを -16 に設定します。

特定の段落の行間隔を指定する方法は以下の通りです：

1. テキストを含むAutoShapeがあるプレゼンテーションをロードします。
2. インデックスを通じてスライドの参照を取得します。
3. TextFrame にアクセスします。
4. 段落にアクセスします。
5. 段落のプロパティを設定します。
6. プレゼンテーションを保存します。

以下の Java コードは、段落の行間を指定する方法を示しています：

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("Fonts.pptx");
try {
    // インデックスによってスライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // TextFrame にアクセス
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // 段落にアクセス
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // 段落のプロパティを設定
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // プレゼンテーションを保存
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **TextFrame の AutofitType プロパティを設定**

このトピックでは、テキストフレームのさまざまな書式設定プロパティを探ります。この記事では、テキストフレームの AutofitType プロパティ、テキストのアンカー、およびプレゼンテーション内のテキストを回転させる方法について説明します。Aspose.Slides for Java は、任意のテキストフレームの AutofitType プロパティを設定できるようにします。AutofitType は [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) または [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape) に設定できます。[Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) に設定すると、シェイプは同じままの状態で、テキストはシェイプの形を変更せずに調整されます。一方、AutofitType が [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape) に設定されると、シェイプは変更され、必要なテキストのみが収容されます。テキストフレームの AutofitType プロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストフレームの [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) を設定します。
6. ファイルをディスクに保存します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 四角形型のAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // 四角形にテキストフレームを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // テキストフレーム用の段落オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("素早い茶色の狐が怠けた犬を飛び越えます。素早い茶色の狐が怠けた犬を飛び越えます。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **TextFrame のアンカーを設定**

Aspose.Slides for Java は、どの TextFrame のアンカーも設定できます。TextAnchorType は、そのテキストがシェイプ内のどこに配置されているかを指定します。AnchorType は [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) または [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed) に設定できます。任意の TextFrame のアンカーを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストフレームの [TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) を設定します。
6. ファイルをディスクに保存します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 四角形型のAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 四角形にテキストフレームを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // テキストフレーム用の段落オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("素早い茶色の狐が怠けた犬を飛び越えます。素早い茶色の狐が怠けた犬を飛び越えます。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションのタブと EffectiveTabs**

すべてのテキストタブは、ピクセル単位で設定されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図: 2つの明示的タブと2つのデフォルトタブ**|
- EffectiveTabs.ExplicitTabCount (この場合は2) プロパティは Tabs.Count と等しい。
- EffectiveTabs コレクションには、すべてのタブ (Tabs コレクションとデフォルトタブ) が含まれます。
- EffectiveTabs.ExplicitTabCount (この場合は2) プロパティは Tabs.Count と等しい。
- EffectiveTabs.DefaultTabSize (294) プロパティは、デフォルトタブ間の距離 (例では3と4) を示します。
- EffectiveTabs.GetTabByIndex(index) で index = 0 は最初の明示的タブ (Position = 731) を返し、index = 1 では2番目のタブ (Position = 1241) を返します。index = 2 で次のタブを取得しようとすると、最初のデフォルトタブ (Position = 1470) が返されます。
- EffectiveTabs.GetTabAfterPosition(pos) は、特定のテキストの後の次のタブ設定を取得するために使用されます。例えば、テキスト "Hello World!" があった場合、そのテキストを描画する開始位置を知っている必要があります。最初に "Hello" の長さをピクセル単位で計算し、GetTabAfterPosition をその値で呼び出します。これにより、"world!" を描画するための次のタブ位置が得られます。

## **デフォルトのテキストスタイルを設定**

プレゼンテーションのすべてのテキスト要素に一度に同じデフォルトの書式設定を適用する必要がある場合は、[IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) インターフェイスの `getDefaultTextStyle` メソッドを使用して、希望の書式設定を設定できます。以下のコード例では、プレゼンテーション内のすべてのスライドのテキストに対してデフォルトの太字フォント (14 pt) を設定する方法を示します。

```java
Presentation presentation = new Presentation();
try {
    // トップレベルの段落フォーマットを取得
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