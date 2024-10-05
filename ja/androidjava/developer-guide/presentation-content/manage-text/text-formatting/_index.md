---
title: テキストフォーマット
type: docs
weight: 50
url: /androidjava/text-formatting/
keywords:
- ハイライトテキスト
- 正規表現
- テキスト段落の整列
- テキストの透明度
- 段落のフォントプロパティ
- フォントファミリ
- テキストの回転
- カスタム角度の回転
- テキストフレーム
- 行間
- 自動フィットプロパティ
- テキストフレームのアンカー
- テキストのタブ設定
- デフォルトのテキストスタイル
- Java
- Java経由のAspose.Slides for Android
description: "Javaでテキストおよびテキストフレームのプロパティを管理および操作する"
---

## **ハイライトテキスト**
メソッド [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) が [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) クラスに追加されました。

これは、テキストサンプルを使用して背景色でテキスト部分をハイライトします。これは、PowerPoint 2019のテキストハイライトカラーツールに似ています。

以下のコードスニペットは、この機能の使用方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // 'important'のすべての単語をハイライト
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// 'the'のすべての異なる出現をハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Asposeは、シンプルな [無料のオンラインPowerPoint編集サービス](https://products.aspose.app/slides/editor)を提供しています。

{{% /alert %}} 

## **正規表現を使用したハイライトテキスト**

メソッド [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) が [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) クラスに追加されました。

これは、正規表現を使用して背景色でテキスト部分をハイライトします。これは、PowerPoint 2019のテキストハイライトカラーツールに似ています。

以下のコードスニペットは、この機能の使用方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // 10シンボル以上のすべての単語をハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキスト背景色の設定**

Aspose.Slidesでは、テキストの背景に好みの色を指定できます。

このJavaコードは、全テキストの背景色を設定する方法を示しています：

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

このJavaコードは、テキストの一部の背景色を設定する方法を示しています：

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

## **テキスト段落の整列**

テキストフォーマットは、さまざまな文書やプレゼンテーションを作成する際の重要な要素の一つです。Aspose.Slides for Android via Javaでは、スライドにテキストを追加することをサポートしていますが、このトピックでは、スライド内のテキスト段落の整列をどのように制御できるかを見ていきます。以下の手順に従って、Aspose.Slides for Android via Javaを使用してテキスト段落を整列してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダーシェイプにアクセスし、それを [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) として型キャストします。
4. [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) が公開している [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getTextFrame--) から整列する必要のある段落を取得します。
5. 段落を整列します。段落は右揃え、左揃え、中央揃え、および均等揃えが可能です。
6. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

上記の手順の実装を以下に示します。

```java
// PPTXファイルを表すPresentationオブジェクトのインスタンスを作成
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初および二番目のプレースホルダーにアクセスし、AutoShapeとして型キャスト
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 両方のプレースホルダーのテキストを変更
    tf1.setText("Asposeによる中央揃え");
    tf2.setText("Asposeによる中央揃え");

    // プレースホルダーの最初の段落を取得
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // テキスト段落を中央に整列
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // PPTXファイルとしてプレゼンテーションを書き出す
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストの透明度を設定**

この記事では、Aspose.Slides for Android via Javaを使用して任意のテキストシェープに対して透明度プロパティを設定する方法を示しています。テキストに透明度を設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. シャドウカラーを設定します。
4. プレゼンテーションをPPTXファイルとして書き出します。

上記の手順の実装を以下に示します。

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

Aspose.Slidesでは、テキストボックス内の文字間のスペースを設定できます。これにより、文字間の間隔を拡大または縮小することで、行やテキストブロックの視覚的密度を調整できます。

このJavaコードは、1行のテキストの間隔を拡大し、別の行の間隔を縮小する方法を示しています：

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 拡大
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 縮小

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **段落のフォントプロパティを管理**

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは、特定のセクションや単語を強調したり、企業スタイルに合うようにさまざまな方法でフォーマットできます。テキストフォーマットは、ユーザーがプレゼンテーションコンテンツの見た目を変えるのに役立ちます。この記事では、Aspose.Slides for Android via Javaを使用して、スライド上のテキスト段落のフォントプロパティを構成する方法を示します。Aspose.Slides for Android via Javaを使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内のプレースホルダーシェイプにアクセスし、それを [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に型キャストします。
1. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に公開されている [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) からパラグラフを取得します。
1. 段落を均等揃えします。
1. 段落のテキストポーションにアクセスします。
1. FontDataを使用してフォントを定義し、テキストポーションのフォントを設定します。
   1. フォントを太字に設定します。
   1. フォントをイタリックに設定します。
1. [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォントの色を設定します。
1. 修正されたプレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルに書き出します。

上記の手順の実装を以下に示します。それは、装飾されていないプレゼンテーションを受け取り、スライドの1つのフォントをフォーマットします。

```java
// PPTXファイルを表すPresentationオブジェクトのインスタンスを作成
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // スライドの位置を使用してスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初および二番目のプレースホルダーにアクセスし、AutoShapeとして型キャスト
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 最初の段落にアクセス
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 最初のポーションにアクセス
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // 新しいフォントを定義
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // ポーションに新しいフォントを割り当てる
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // フォントを太字に設定
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // フォントをイタリックに設定
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの色を設定
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // PPTXをディスクに書き出す
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストのフォントファミリを管理**

ポーションは、段落内の同じフォーマットスタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for Android via Javaを使用して、テキストボックスを作成し、特定のフォントおよびフォントファミリカテゴリのさまざまなプロパティを定義する方法を示します。テキストボックスを作成し、そのテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) をスライドに追加します。
4. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連する塗りつぶしスタイルを削除します。
5. AutoShapeのTextFrameにアクセスします。
6. TextFrameにいくつかのテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられたポーションオブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) に使用するフォントを定義します。
9. 太字、イタリック、下線、色、高さなどのフォントプロパティを、ポーションオブジェクトによって公開される関連するプロパティを使用して設定します。
10. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

上記の手順の実装を以下に示します。

```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // AutoShapeに関連付けられた塗りつぶしスタイルを削除
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // AutoShapeに関連付けられたTextFrameにアクセス
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // TextFrameに関連付けられたポーションにアクセス
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // ポーションのフォントを設定
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // フォントの太字プロパティを設定
    port.getPortionFormat().setFontBold(NullableBool.True);

    // フォントのイタリックプロパティを設定
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // フォントの下線プロパティを設定
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // フォントの高さを設定
    port.getPortionFormat().setFontHeight(25);

    // フォントの色を設定
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTXをディスクに書き出す 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **テキストのフォントサイズを設定**

Aspose.Slidesでは、段落内の既存のテキストに対して好みのフォントサイズを選択し、後で段落に追加される他のテキストにも適用できます。

このJavaコードは、段落内のテキストに対してフォントサイズを設定する方法を示しています：

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

        // 段落内のすべてのテキストポーションに対してデフォルトのフォントサイズを20ポイントに設定
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // 現在の段落内のテキストポーションに対してフォントサイズを20ポイントに設定
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

Aspose.Slides for Android via Javaは、開発者がテキストを回転させることを可能にします。テキストは [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical)または[WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)として表示されます。テキストフレームのテキストを回転させるには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. [テキストを回転させます](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-)。
6. ファイルをディスクに保存します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 矩形にTextFrameを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // テキストフレーム用のパラグラフオブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // パラグラフ用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("素早い茶色の狐が怠け者の犬を飛び越える。素早い茶色の狐が怠け者の犬を飛び越える。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストフレームのカスタム回転角度を設定**

Aspose.Slides for Android via Javaは、テキストフレームのカスタム回転角度を設定することをサポートします。このトピックでは、Aspose.Slides内でRotationAngleプロパティを設定する方法を例示します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) が [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) および [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) インターフェイスに追加され、テキストフレームのカスタム回転角度を設定できます。RotationAngleを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [RotationAngleプロパティを設定します](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-)。
4. プレゼンテーションをPPTXファイルとして書き出します。

以下の例では、RotationAngleプロパティを設定します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // 矩形にTextFrameを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // テキストフレーム用のパラグラフオブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // パラグラフ用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("テキスト回転の例。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落の行間**

Aspose.Slidesは、段落の行間を管理するために `ParagraphFormat` 下のプロパティ—`SpaceAfter`、`SpaceBefore`および`SpaceWithin`を提供します。これらの3つのプロパティは次のように使用されます：

* 行間をパーセントで指定するには、正の値を使用します。
* 行間をポイントで指定するには、負の値を使用します。

たとえば、段落に16ポイントの行間を適用するには、`SpaceBefore`プロパティを-16に設定します。

特定の段落の行間を指定する方法は次のとおりです：

1. いくつかのテキストが含まれるAutoShapeを持つプレゼンテーションをロードします。
2. インデックスを介してスライドの参照を取得します。
3. TextFrameにアクセスします。
4. 段落にアクセスします。
5. 段落のプロパティを設定します。
6. プレゼンテーションを保存します。

このJavaコードは、段落の行間を指定する方法を示しています：

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("Fonts.pptx");
try {
    // インデックスを使用してスライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // TextFrameにアクセス
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

## **TextFrameのAutofitTypeプロパティを設定**

このトピックでは、テキストフレームのさまざまなフォーマットプロパティを探ります。この記事では、テキストフレームのAutofitTypeプロパティを設定し、テキストのアンカーを設定し、プレゼンテーションでテキストを回転させる方法を説明します。Aspose.Slides for Android via Javaでは、任意のテキストフレームのAutofitTypeプロパティを設定できます。AutofitTypeは [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) または [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) に設定できます。 [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) に設定すると、シェイプはそのままにしておき、テキストはシェイプそのものに影響を与えることなく調整されますが、AutofitTypeが [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) に設定されると、必要なテキストのみが含まれるようにシェイプは変更されます。テキストフレームのAutofitTypeプロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストフレームのAutofitTypeを[設定します](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-)。
6. ファイルをディスクに保存します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // 矩形にTextFrameを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // テキストフレーム用のパラグラフオブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // パラグラフ用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("素早い茶色の狐が怠け者の犬を飛び越える。素早い茶色の狐が怠け者の犬を飛び越える。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **TextFrameのアンカーを設定**

Aspose.Slides for Android via Javaでは、開発者が任意のTextFrameのアンカーを設定できます。TextAnchorTypeは、そのテキストがシェイプ内のどこに置かれているかを指定します。AnchorTypeは、[Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) または [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed) にセットできます。任意のTextFrameのアンカーを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. [TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-)を設定します。
6. ファイルをディスクに保存します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 矩形にTextFrameを追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // テキストフレーム用のパラグラフオブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // パラグラフ用のポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("素早い茶色の狐が怠け者の犬を飛び越える。素早い茶色の狐が怠け者の犬を飛び越える。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーション内のタブとEffectiveTabs**

すべてのテキストタブ設定はピクセルで指定されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図：2つの明示的タブと2つのデフォルトタブ**|
- EffectiveTabs.ExplicitTabCount (我々のケースでは2)プロパティはTabs.Countに等しい。
- EffectiveTabsコレクションには、すべてのタブ（Tabsコレクションおよびデフォルトタブ）が含まれます。
- EffectiveTabs.ExplicitTabCount (我々のケースでは2)プロパティはTabs.Countに等しい。
- EffectiveTabs.DefaultTabSize (294)プロパティは、デフォルトタブ間の距離を示します（例では3と4）。
- EffectiveTabs.GetTabByIndex(index) を用いてindex = 0では最初の明示的タブ (位置 = 731) が返され、index = 1 では2番目のタブ (位置 = 1241) が返されます。index = 2の次のタブを取得しようとすると、最初のデフォルトタブ (位置 = 1470) が返され、続けていきます。
- EffectiveTabs.GetTabAfterPosition(pos) は、一部のテキストの後の次のタブ設定を取得するために使用されます。たとえば、"Hello World!"というテキストがあります。このテキストを描画するには、"world!"を描き始める場所を知っている必要があります。最初に、"Hello" の長さをピクセルで計算し、その値でGetTabAfterPositionを呼び出す必要があります。次のタブ位置が返され、"world!"を描画することができます。

## **デフォルトのテキストスタイルを設定**

プレゼンテーション内のすべてのテキスト要素に一度に同じデフォルトのテキストフォーマットを適用する必要がある場合は、[IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) インターフェイスの `getDefaultTextStyle` メソッドを使用して、好みのフォーマッティングを設定できます。以下のコード例は、新しいプレゼンテーションのすべてのスライドのテキストにデフォルトの太字フォント（14 pt）を設定する方法を示します。

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