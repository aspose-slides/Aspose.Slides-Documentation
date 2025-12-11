---
title: Androidでのプレゼンテーションにおけるテキストボックスの管理
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/androidjava/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキストの追加
- テキストの更新
- テキストボックスの作成
- テキストボックスの確認
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用すると、PowerPoint および OpenDocument ファイル内のテキストボックスの作成、編集、クローン作成が簡単になり、プレゼンテーションの自動化が向上します。"
---

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックスにテキストを入れる必要があります。Aspose.Slides for Android via Java は、テキストを含むシェイプを追加できる [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) インターフェイスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides には、スライドにシェイプを追加できる [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) インターフェイスも用意されています。ただし、`IShape` インターフェイスを介して追加されたすべてのシェイプがテキストを保持できるわけではありません。一方、[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) インターフェイスを介して追加されたシェイプはテキストを含めることができます。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合は、`IAutoShape` インターフェイスにキャストされていることを確認する必要があります。`IAutoShape` であることが確認できて初めて、`IAutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) を使用できます。このページの [Update Text](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) セクションを参照してください。
{{% /alert %}}

## **Create a Text Box on a Slide**

テキスト ボックスをスライドに作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `Rectangle` に設定した [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) を持つ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトへの参照を取得します。  
4. テキストを保持する `TextFrame` プロパティを `IAutoShape` オブジェクトに追加します。以下の例では、*Aspose TextBox* というテキストを追加しました。  
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

この Java コードは、上記手順の実装例であり、スライドにテキストを追加する方法を示しています:
```java
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 四角形に TextFrame を追加
    ashp.addTextFrame(" ");

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();

    // テキストフレーム用の Paragraph オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Paragraph 用の Portion オブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);

    // テキストを設定
    portion.setText("Aspose TextBox");

    // プレゼンテーションをディスクに保存
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Check for a Text Box Shape**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) インターフェイスから [isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) メソッドを提供し、シェイプを調べてテキスト ボックスかどうかを判別できます。

![テキスト ボックスとシェイプ](istextbox.png)

この Java コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示しています: 
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


単に [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) インターフェイスの `addAutoShape` メソッドでオートシェイプを追加した場合、`isTextBox` メソッドは `false` を返します。ただし、`addTextFrame` メソッドまたは `setText` メソッドでオートシェイプにテキストを追加すると、`isTextBox` プロパティは `true` を返します。
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() は false を返します
shape1.addTextFrame("shape 1");
// shape1.isTextBox() は true を返します

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() は false を返します
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() は true を返します

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() は false を返します
shape3.addTextFrame("");
// shape3.isTextBox() は false を返します

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() は false を返します
shape4.getTextFrame().setText("");
// shape4.isTextBox() は false を返します
```


## **Add Columns to a Text Box**

Aspose.Slides は、テキスト ボックスに列を追加できるように、[ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) インターフェイスと [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスから [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) および [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) プロパティを提供します。これにより、テキスト ボックス内の列数と列間のポイント単位の間隔を指定できます。

以下の Java コードは、説明した操作を実演しています: 
```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape を追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 四角形に TextFrame を追加
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame のテキスト形式を取得
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame の列数を指定
    format.setColumnCount(3);

    // 列間の間隔を指定
    format.setColumnSpacing(10);

    // プレゼンテーションを保存
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Add Columns to a Text Frame**
Aspose.Slides for Android via Java は、[ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) インターフェイスから取得できる [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) プロパティを提供し、テキスト フレーム内に列を追加できます。このプロパティを使用して、テキスト フレーム内の希望する列数を指定できます。

この Java コードは、テキスト フレーム内に列を追加する方法を示しています:
```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Update Text**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

以下の Java コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています:
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //シェイプがテキストフレーム (IAutoShape) をサポートしているか確認します。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //テキストフレーム内の段落を繰り返し処理します。
                {
                    for (IPortion portion : paragraph.getPortions()) //段落内の各ポーションを繰り返し処理します。
                    {
                        portion.setText(portion.getText().replace("years", "months")); //テキストを変更します。
                        portion.getPortionFormat().setFontBold(NullableBool.True); //書式設定を変更します。
                    }
                }
            }
        }
    }

    //変更したプレゼンテーションを保存します。
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Add a Text Box with a Hyperlink** 

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはリンク先を開きます。

テキスト ボックスにリンクを含めるには、次の手順を実行します。

1. `Presentation` クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `Rectangle` に設定した `ShapeType` を持つ `AutoShape` オブジェクトを追加し、新しく追加された AutoShape オブジェクトへの参照を取得します。  
4. デフォルト テキストとして *Aspose TextBox* を含む `TextFrame` を `AutoShape` オブジェクトに追加します。  
5. `IHyperlinkManager` クラスのインスタンスを作成します。  
6. `TextFrame` の目的の部分に関連付けられた [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) プロパティに `IHyperlinkManager` オブジェクトを割り当てます。  
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

この Java コードは、上記手順の実装例であり、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています:
```java
// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape オブジェクトを追加します
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // シェイプを AutoShape にキャストします
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape に関連付けられた ITextFrame プロパティにアクセスします
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // フレームにテキストを追加します
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ポーションのテキストにハイパーリンクを設定します
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX プレゼンテーションを保存します
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**マスタースライドで作業する際、テキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

A [placeholder](/slides/ja/androidjava/manage-placeholder/) は [master](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) からスタイル/位置を継承し、[layouts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) で上書き可能です。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体で一括テキスト置換を行うにはどうすればよいですか？**

テキスト フレームを持つオートシェイプに対してのみ反復処理を行い、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)）はそれぞれのコレクションを別途走査するか、該当オブジェクトタイプをスキップしてください。