---
title: テキストボックスの管理
type: docs
weight: 20
url: /ja/androidjava/manage-textbox/
description: Javaを使用してPowerPointスライドにテキストボックスを作成します。Javaを使用してPowerPointスライドのテキストボックスまたはテキストフレームに列を追加します。Javaを使用してPowerPointスライドにハイパーリンク付きのテキストボックスを追加します。
---

スライド上のテキストは通常、テキストボックスまたは図形に存在します。したがって、スライドにテキストを追加するには、テキストボックスを追加し、その中にテキストを入れる必要があります。Aspose.Slides for Android via Javaは、テキストを含む図形を追加できる[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)インターフェイスを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slidesは、スライドに図形を追加できる[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)インターフェイスも提供します。ただし、`IShape`インターフェイスを介して追加されたすべての図形がテキストを保持できるわけではありません。しかし、[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)インターフェイスを介して追加された図形にはテキストを含むことができます。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

したがって、テキストを追加したい図形を扱うときは、それが`IAutoShape`インターフェイスを介してキャストされたことを確認してください。そうでなければ、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)を操作することはできません。このページの[テキストの更新](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text)セクションを参照してください。

{{% /alert %}}

## **スライドにテキストボックスを作成**

スライドにテキストボックスを作成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しく作成されたプレゼンテーションの最初のスライドへの参照を取得します。 
3. 指定された位置に`Rectangle`として`ShapeType`が設定された[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)オブジェクトを追加し、新しく追加された`IAutoShape`オブジェクトの参照を取得します。
4. テキストを含む`TextFrame`プロパティを`IAutoShape`オブジェクトに追加します。以下の例では、次のテキストを追加しました: *Aspose TextBox*
5. 最後に、`Presentation`オブジェクトを介してPPTXファイルを作成します。 

このJavaコードは、上記の手順の実装であり、スライドにテキストを追加する方法を示しています：

```java
// Presentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangleとしてタイプ設定されたAutoShapeを追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // RectangleにTextFrameを追加
    ashp.addTextFrame(" ");

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();

    // テキストフレームのための段落オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 段落のためのポーションオブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);

    // テキストを設定
    portion.setText("Aspose TextBox");

    // プレゼンテーションをディスクに保存
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストボックス形状をチェック**

Aspose.Slidesは、テキストボックスを見つけるために図形を調べることを可能にする[isTextBox()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#isTextBox--)プロパティ（[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/)クラスから）を提供します。

![テキストボックスと図形](istextbox.png)

このJavaコードは、図形がテキストボックスとして作成されたかどうかを確認する方法を示します：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "形状はテキストボックスです" : "形状はテキストボックスではありません");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストボックスに列を追加**

Aspose.Slidesは、テキストボックスに列を追加するための[ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)および[ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)インターフェイスおよび[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)クラスによる）を提供します。これにより、テキストボックス内の列の数を指定して、列間の間隔をポイントで設定できます。

このJavaコードは、前述の操作を実演します：

```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangleとしてタイプ指定されたAutoShapeを追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // RectangleにTextFrameを追加
    aShape.addTextFrame("これらのすべての列は単一のテキストコンテナ内に制限されています -- " +
            "テキストを追加または削除でき、残っているテキストは自動的に" +
            "コンテナ内に流れるように調整されます。しかし、テキストは1つのコンテナから他のものへと流れることはできません -- PowerPointのテキストの列設定オプションは限られています！");

    // TextFrameのテキストフォーマットを取得
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame内の列の数を指定
    format.setColumnCount(3);

    // 列間の間隔を指定
    format.setColumnSpacing(10);

    // プレゼンテーションを保存
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストフレームに列を追加**

Aspose.Slides for Android via Javaは、テキストフレームに列を追加するための[ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)インターフェイスから）を提供します。このプロパティを介して、テキストフレーム内の希望の列数を指定できます。

このJavaコードは、テキストフレーム内に列を追加する方法を示します：

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("これらのすべての列は単一のテキストコンテナ内に強制されているため -- " +
            "テキストを追加または削除できます - 新しいテキストや残りのテキストは通常、" +
            "コンテナ内に留まるように自動的に調整されます。テキストが1つのコンテナから他に流れることはありませんが、PowerPointのテキストの列オプションは限られているためです！");
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

## **テキストの更新**

Aspose.Slidesを使用すると、テキストボックスに含まれるテキストやプレゼンテーション内のすべてのテキストを変更または更新できます。 

このJavaコードは、プレゼンテーション内のすべてのテキストが更新または変更される操作を示しています：

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // 図形がテキストフレーム（IAutoShape）をサポートしているか確認
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // テキストフレーム内の段落を繰り返す
                {
                    for (IPortion portion : paragraph.getPortions()) // 段落内の各ポーションを繰り返す
                    {
                        portion.setText(portion.getText().replace("years", "months")); // テキストを変更
                        portion.getPortionFormat().setFontBold(NullableBool.True); // 書式を変更
                    }
                }
            }
        }
    }

    // 修正されたプレゼンテーションを保存
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ハイパーリンク付きテキストボックスの追加** 

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはリンクを開くように指示されます。

ハイパーリンクを含むテキストボックスを追加するには、以下の手順を実行します。

1. `Presentation`クラスのインスタンスを作成します。 
2. 新しく作成されたプレゼンテーションの最初のスライドへの参照を取得します。 
3. 指定された位置に`Rectangle`として`ShapeType`が設定された`AutoShape`オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトの参照を取得します。
4. デフォルトのテキストとして*Aspose TextBox*を含む`TextFrame`を`AutoShape`オブジェクトに追加します。 
5. `IHyperlinkManager`クラスをインスタンス化します。 
6. `IHyperlinkManager`オブジェクトを`TextFrame`の希望の部分に関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--)プロパティに割り当てます。
7. 最後に、`Presentation`オブジェクトを介してPPTXファイルを作成します。 

このJavaコードは、ハイパーリンク付きのテキストボックスをスライドに追加する方法を示しています：

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプがRectangleに設定されたAutoShapeオブジェクトを追加
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // AutoShapeにキャスト
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShapeに関連するITextFrameプロパティにアクセス
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // フレームにテキストを追加
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ポーションのテキストにハイパーリンクを設定
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTXプレゼンテーションを保存
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```