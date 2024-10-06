---
title: テキストボックスの管理
type: docs
weight: 20
url: /ja/java/manage-textbox/
description: Javaを使用してPowerPointスライドにテキストボックスを作成します。Javaを使用してPowerPointスライドにテキストボックスまたはテキストフレームに列を追加します。Javaを使用してPowerPointスライドにハイパーリンク付きのテキストボックスを追加します。
---

スライドのテキストは通常、テキストボックスや図形に存在します。したがって、スライドにテキストを追加するには、テキストボックスを追加し、その中にテキストを入力する必要があります。Aspose.Slides for Javaは、テキストを含む図形を追加するための[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)インターフェースを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slidesは、スライドに図形を追加するための[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)インターフェースも提供します。しかし、`IShape`インターフェースを通じて追加されたすべての図形がテキストを保持できるわけではありません。しかし、[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)インターフェースを介して追加された図形はテキストを含む可能性があります。 

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

したがって、テキストを追加したい図形を扱う際には、それが`IAutoShape`インターフェースを通じてキャストされたことを確認する必要があります。そうしなければ、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)を使用することができません。このページの[テキストの更新](https://docs.aspose.com/slides/java/manage-textbox/#update-text)セクションを参照してください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

スライドにテキストボックスを作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. スライド上の指定された位置に`ShapeType`が`Rectangle`に設定された[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)オブジェクトを追加し、新たに追加した`IAutoShape`オブジェクトへの参照を取得します。 
4. テキストを含む`TextFrame`プロパティを`IAutoShape`オブジェクトに追加します。以下の例では、次のテキストを追加しました： *Aspose TextBox*
5. 最後に、`Presentation`オブジェクトを介してPPTXファイルを書き込みます。

次のJavaコードは、上記の手順の実装例で、スライドにテキストを追加する方法を示しています：

```java
// Presentationをインスタンス化します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangleとして型を設定したAutoShapeを追加します
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // RectangleにTextFrameを追加します
    ashp.addTextFrame(" ");

    // テキストフレームにアクセスします
    ITextFrame txtFrame = ashp.getTextFrame();

    // テキストフレーム用のParagraphオブジェクトを作成します
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落用のPortionオブジェクトを作成します
    IPortion portion = para.getPortions().get_Item(0);

    // テキストを設定します
    portion.setText("Aspose TextBox");

    // プレゼンテーションをディスクに保存します
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストボックスの形状を確認する**

Aspose.Slidesは、[isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--)プロパティ（[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)クラスから）を提供しており、図形を調べてテキストボックスを見つけることができます。

![テキストボックスと図形](istextbox.png)

このJavaコードは、図形がテキストボックスとして作成されたかどうかを確認する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "shape is text box" : "shape is text not box");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストボックスに列を追加する**

Aspose.Slidesは、テキストボックスに列を追加できる[ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)および[ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)インターフェースおよび[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスから）を提供します。このプロパティを使用すると、テキストボックス内の列数を指定し、列間のスペーシングをポイント単位で設定できます。

次のJavaコードは、記述された操作を示しています：

```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangleとして型を設定したAutoShapeを追加します
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // RectangleにTextFrameを追加します
    aShape.addTextFrame("これらのすべての列は、単一のテキストコンテナ内に制限されています -- " +
            "テキストを追加または削除でき、新しいまたは残りのテキストが自動的に調整されて " +
            "コンテナ内に流れるようにします。一つのコンテナから他のコンテナにテキストを流すことはできませんが -- " +
            "PowerPointのテキストの列オプションは限られていることをお知らせしました！");

    // TextFrameのテキストフォーマットを取得します
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrameにおける列の数を指定します
    format.setColumnCount(3);

    // 列間のスペーシングを指定します
    format.setColumnSpacing(10);

    // プレゼンテーションを保存します
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストフレームに列を追加する**

Aspose.Slides for Javaは、テキストフレームに列を追加できる[ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)インターフェースから）を提供しています。このプロパティを使用して、テキストフレーム内の好みの列数を指定できます。

次のJavaコードは、テキストフレーム内に列を追加する方法を示しています：

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("これらのすべての列は、単一のテキストコンテナの内部に留まるように強制されています -- " +
            "テキストを追加または削除できます - 新しいまたは残りのテキストは自動的に調整されて " +
            "コンテナ内に留まります。一つのコンテナから他のコンテナにテキストがあふれることはありませんが -- " +
            "PowerPointのテキストの列オプションは限られています！");
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

## **テキストを更新する**

Aspose.Slidesを使用すると、テキストボックス内のテキストやプレゼンテーション内のすべてのテキストを変更または更新できます。

このJavaコードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています：

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //図形がテキストフレーム（IAutoShape）をサポートしているかどうかを確認します。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //テキストフレーム内の段落を繰り返します
                {
                    for (IPortion portion : paragraph.getPortions()) //段落内の各部分を繰り返します
                    {
                        portion.setText(portion.getText().replace("years", "months")); //テキストを変更します
                        portion.getPortionFormat().setFontBold(NullableBool.True); //フォーマットを変更します
                    }
                }
            }
        }
    }

    //変更したプレゼンテーションを保存します
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ハイパーリンク付きのテキストボックスを追加する** 

テキストボックス内にリンクを挿入できます。テキストボックスをクリックすると、ユーザーはリンクを開くように指示されます。

ハイパーリンクを含むテキストボックスを追加するには、次の手順を実行します。

1. `Presentation`クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. スライド上の指定された位置に`ShapeType`が`Rectangle`に設定された`AutoShape`オブジェクトを追加し、新たに追加したAutoShapeオブジェクトへの参照を取得します。
4. *Aspose TextBox*をデフォルトテキストとして持つ`AutoShape`オブジェクトに`TextFrame`を追加します。 
5. `IHyperlinkManager`クラスをインスタンス化します。 
6. `IHyperlinkManager`オブジェクトを、`TextFrame`の好みの部分に関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--)プロパティに割り当てます。 
7. 最後に、`Presentation`オブジェクトを介してPPTXファイルを書き込みます。 

次のJavaコードは、ハイパーリンクを含むテキストボックスをスライドに追加する方法を示しています：

```java
// PPTXを表すPresentationクラスをインスタンス化します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // 型をRectangleに設定したAutoShapeオブジェクトを追加します
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 図形をAutoShapeにキャストします
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShapeに関連付けられたITextFrameプロパティにアクセスします
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // フレームにテキストを追加します
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 部分テキストに対するハイパーリンクを設定します
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTXプレゼンテーションを保存します
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```