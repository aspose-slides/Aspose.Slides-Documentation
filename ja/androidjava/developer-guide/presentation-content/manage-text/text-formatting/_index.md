---
title: Android で PowerPoint テキストをフォーマット
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
- 行間
- Autofit プロパティ
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
メソッド [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) が [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) クラスに追加されました。

テキストのサンプルを使用して、背景色でテキストの一部をハイライトできるようになり、PowerPoint 2019 の「テキストハイライトカラー」ツールと同様です。

以下のコードスニペットはこの機能の使用方法を示しています。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // 「important」のすべての単語をハイライト
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// 「the」のすべての個別出現をハイライト
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Aspose はシンプルな、[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています
{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**
メソッド [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) が [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) クラスに追加されました。

正規表現を使用して、背景色でテキストの一部をハイライトでき、PowerPoint 2019 の「テキストハイライトカラー」ツールと同様です。

以下のコードスニペットはこの機能の使用方法を示しています。
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
Aspose.Slides では、テキストの背景色を任意の色に指定できます。

この Java コードは、テキスト全体の背景色を設定する方法を示しています。
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


この Java コードは、テキストの一部だけの背景色を設定する方法を示しています。
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
テキストの書式設定は、文書やプレゼンテーション作成時の重要な要素です。Aspose.Slides for Android via Java はスライドへのテキスト追加をサポートしていますが、本項ではスライド内のテキスト段落の配置方法を紹介します。以下の手順でテキスト段落を配置してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに存在するプレースホルダーシェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) に型変換します。
4. [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) が公開している [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) から、配置したい [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) を取得します。
5. 段落を配置します。段落は右揃え、左揃え、中央揃え、両端揃えに設定できます。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と二番目のプレースホルダーにアクセスし、AutoShape に型変換
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 両方のプレースホルダーのテキストを変更
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // プレースホルダーの最初の段落を取得
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // テキスト段落を中央揃えに設定
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //PPTX ファイルとしてプレゼンテーションを書き出し
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストの透明度の設定**
本記事では、Aspose.Slides for Android via Java を使用して任意のテキストシェイプの透明度プロパティを設定する方法を示します。テキストの透明度を設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
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


## **テキストの文字間隔の設定**
Aspose.Slides では、テキストボックス内の文字間隔を設定できます。これにより、文字間のスペースを拡張または縮小して、行やテキストブロックの視覚的密度を調整できます。

この Java コードは、1 行の文字間隔を拡張し、別の行の文字間隔を縮小する方法を示しています。
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 拡張
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 縮小

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **段落のフォントプロパティの管理**
プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストはハイライトや企業スタイルへの適合など、さまざまな方法で書式設定できます。テキスト書式設定は、プレゼンテーションコンテンツの外観を変える手段です。本記事では、Aspose.Slides for Android via Java を使用してスライド上のテキスト段落のフォントプロパティを構成する方法を紹介します。段落のフォントプロパティを管理する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内のプレースホルダーシェイプにアクセスし、[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に型変換します。
1. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) が公開している [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) から [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) を取得します。
1. 段落を両端揃えにします。
1. 段落のテキスト Portion にアクセスします。
1. FontData を使用してフォントを定義し、テキスト Portion のフォントを設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) オブジェクトが公開している [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォント色を設定します。
1. 変更したプレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順の実装例は以下のとおりです。未装飾のプレゼンテーションを取得し、スライドの一つのフォントをフォーマットします。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // スライド位置でスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型変換
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

    // 新しいフォントをポーションに割り当て
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

    // PPTX をディスクに書き出す
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのフォントファミリの管理**
Portion は、段落内で同じ書式スタイルのテキストを保持するために使用されます。本記事では、Aspose.Slides for Android via Java を使用してテキストボックスを作成し、特定のフォントおよびフォントファミリカテゴリのさまざまなプロパティを定義する方法を示します。テキストボックスを作成し、テキストのフォントプロパティを設定する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) 種類の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられた Portion オブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) に使用するフォントを定義します。
9. 太字、斜体、下線、色、高さなど、Portion オブジェクトが公開している関連プロパティを使用してその他のフォントプロパティを設定します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
```java
// Presentation のインスタンスを作成
Presentation pres = new Presentation();
try {

    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // AutoShape に関連付けられた塗りつぶしスタイルを削除
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // AutoShape に関連付けられた TextFrame にアクセス
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // TextFrame に関連付けられた Portion にアクセス
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Portion のフォントを設定
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

    // PPTX をディスクに書き出す 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのフォントサイズの設定**
Aspose.Slides は、段落内の既存テキストや後から追加されるテキストのフォントサイズを任意に選択できるようにします。

この Java コードは、段落に含まれるテキストのフォントサイズを設定する方法を示しています。
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

        // 段落内のすべてのテキストポーションの既定フォントサイズを 20 pt に設定します。 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // 段落内の現在のテキストポーションのフォントサイズを 20 pt に設定します。 
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
Aspose.Slides for Android via Java は、開発者がテキストを回転させることを可能にします。テキストは以下のいずれかに設定できます: [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)。任意の TextFrame のテキストを回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. テキストを回転させます(例: [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-))。
6. ファイルをディスクに保存します。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 矩形に TextFrame を追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // テキストフレーム用の Paragraph オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用の Portion オブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **TextFrame のカスタム回転角度の設定**
Aspose.Slides for Android via Java は、TextFrame のカスタム回転角度の設定をサポートします。本項では、例を交えて RotationAngle プロパティの設定方法を示します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) が [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) と [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) インターフェイスに追加され、TextFrame のカスタム回転角度を設定できるようになりました。RotationAngle を設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [RotationAngle プロパティを設定](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-)します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、RotationAngle プロパティを設定しています。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // 矩形に TextFrame を追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // テキストフレーム用の Paragraph オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用の Portion オブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落の行間設定**
Aspose.Slides は、[`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat) の `SpaceAfter`、`SpaceBefore`、`SpaceWithin` プロパティを提供し、段落の行間を管理できます。これらのプロパティは次のように使用します。

* パーセンテージで行間を指定する場合は正の値を使用します。  
* ポイントで行間を指定する場合は負の値を使用します。

たとえば、`SpaceBefore` プロパティを -16 に設定すると、段落に 16pt の行間が適用されます。

特定の段落の行間を指定する手順は次のとおりです。

1. テキストを含む AutoShape があるプレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

この Java コードは、段落の行間を指定する方法を示しています。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("Fonts.pptx");
try {
    // インデックスでスライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // TextFrame にアクセス
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Paragraph にアクセス
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Paragraph のプロパティを設定
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // プレゼンテーションを保存
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **TextFrame の AutofitType プロパティの設定**
本項では、テキストフレームのさまざまな書式プロパティを検討します。この記事では、テキストフレームの AutofitType プロパティ、テキストのアンカー、およびテキストの回転設定方法を説明します。Aspose.Slides for Android via Java は、任意のテキストフレームの AutofitType プロパティを設定できます。AutofitType は [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) または [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape) に設定できます。Normal に設定するとシェイプはそのままでテキストが調整され、Shape に設定するとシェイプが変更されテキストが収まります。テキストフレームの AutofitType プロパティを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の AutofitType を設定します(例: [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-))。
6. ファイルをディスクに保存します。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // 矩形に TextFrame を追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // テキストフレーム用の Paragraph オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用の Portion オブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // プレゼンテーションを保存
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **TextFrame のアンカーの設定**
Aspose.Slides for Android via Java は、任意の TextFrame のアンカー設定をサポートします。TextAnchorType はテキストがシェイプ内のどこに配置されるかを指定します。アンカーは [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) または [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed) に設定できます。TextFrame のアンカーを設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の TextAnchorType を設定します(例: [setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-))。
6. ファイルをディスクに保存します。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 矩形に TextFrame を追加
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // テキストフレーム用の Paragraph オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 段落用の Portion オブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // プレゼンテーションを保存
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレゼンテーションのタブと EffectiveTabs**
すべてのテキストタブはピクセル単位で指定されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図: 2 つの明示的タブ と 2 つのデフォルトタブ**|

- EffectiveTabs.ExplicitTabCount (本例では 2) プロパティは Tabs.Count と等しいです。
- EffectiveTabs コレクションには、Tabs コレクションとデフォルトタブの両方が含まれます。
- EffectiveTabs.ExplicitTabCount (本例では 2) プロパティは Tabs.Count と等しいです。
- EffectiveTabs.DefaultTabSize (294) プロパティはデフォルトタブ間の距離を示します (例の 3 と 4)。
- EffectiveTabs.GetTabByIndex(index) で index = 0 は最初の明示的タブ (Position = 731)、index = 1 は2番目のタブ (Position = 1241) を返します。index = 2 で呼び出すと最初のデフォルトタブ (Position = 1470) が返ります。
- EffectiveTabs.GetTabAfterPosition(pos) は、テキストの後続タブ位置を取得します。例: テキスト「Hello World!」がある場合、"Hello" のピクセル長を計算し、その値で GetTabAfterPosition を呼び出すと、"world!" を描画すべき次のタブ位置が得られます。

## **デフォルトテキストスタイルの設定**
プレゼンテーション全体のテキスト要素に同一のデフォルト書式を一括適用したい場合は、[IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) インターフェイスの `getDefaultTextStyle` メソッドを使用して好みの書式を設定できます。以下のコード例は、新規プレゼンテーションのすべてのスライド上のテキストにデフォルトで太字フォント (14pt) を設定する方法を示しています。
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


## **All-Caps 効果でテキストを抽出する**
PowerPoint では、**All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されますが、元のテキストは小文字のままです。Aspose.Slides でその Portion を取得すると、入力通りの文字列が返されます。これを処理するには、[TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) が `All` を示すか確認し、返された文字列を大文字に変換してスライド上の表示と一致させます。

サンプル2.pptx の最初のスライドに次のテキストボックスがあるとします。

![The All Caps effect](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。
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

**スライド上のテーブルのテキストを変更する方法は？**

テーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) インターフェイスを使用します。テーブル内のすべてのセルを反復処理し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

グラデーションカラーをテキストに適用するには、[BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/) の `getFillFormat` メソッドを使用します。`FillFormat` を `Gradient` に設定し、開始色・終了色、方向、透明度などのプロパティを定義してテキストにグラデーション効果を作成します。