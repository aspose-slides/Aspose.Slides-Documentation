---
title: Androidでのプレゼンテーションにおけるテキストボックスの管理
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/androidjava/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキスト追加
- テキスト更新
- テキストボックス作成
- テキストボックス確認
- テキスト列追加
- ハイパーリンク追加
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用すると、PowerPoint および OpenDocument ファイル内でテキストボックスを簡単に作成、編集、複製でき、プレゼンテーションの自動化が向上します。"
---

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックスにテキストを入れる必要があります。Aspose.Slides for Android via Java は、テキストを含むシェイプを追加できる [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) インターフェイスを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slides は、スライドにシェイプを追加できる [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) インターフェイスも提供します。ただし、`IShape` インターフェイスを通じて追加されたすべてのシェイプがテキストを保持できるわけではありません。`IAutoShape` インターフェイスを通じて追加されたシェイプは、テキストを含む場合があります。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

したがって、テキストを追加したいシェイプを扱う場合は、`IAutoShape` インターフェイスにキャストされているか確認することをお勧めします。その後でのみ、`IAutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) を操作できます。このページの [Update Text](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) セクションをご参照ください。

{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

テキスト ボックスをスライドに作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. スライド上の指定位置に `Rectangle` として設定された [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) を持つ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトへの参照を取得します。
4. テキストを含む `TextFrame` プロパティを `IAutoShape` オブジェクトに追加します。以下の例では、*Aspose TextBox* というテキストを追加しました。
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。 

この Java コード（上記手順の実装）は、スライドにテキストを追加する方法を示しています:
```java
// Presentation をインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加
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


## **テキスト ボックス シェイプの確認**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) インターフェイスの [isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) メソッドを提供しており、シェイプを調べてテキスト ボックスかどうかを判別できます。

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


`addAutoShape` メソッドを使用して [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) インターフェイスから単にオートシェイプを追加した場合、オートシェイプの `isTextBox` メソッドは `false` を返します。ただし、`addTextFrame` メソッドまたは `setText` メソッドでオートシェイプにテキストを追加すると、`isTextBox` プロパティは `true` を返すようになります。
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() は false を返す
shape1.addTextFrame("shape 1");
// shape1.isTextBox() は true を返す

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() は false を返す
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() は true を返す

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() は false を返す
shape3.addTextFrame("");
// shape3.isTextBox() は false を返す

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() は false を返す
shape4.getTextFrame().setText("");
// shape4.isTextBox() は false を返す
```


## **テキスト ボックスに列を追加する**

Aspose.Slides は、[ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) インターフェイスおよび [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスから、テキスト ボックスに列を追加できる [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) と [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) プロパティを提供します。テキスト ボックスの列数と、列間のポイント単位の間隔を指定できます。

このコードは、上記操作を Java で実演しています: 
```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape を追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle に TextFrame を追加
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame のテキスト書式を取得
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


## **テキスト フレームに列を追加する**
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


## **テキストの更新**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション全体に含まれるすべてのテキストを変更または更新できます。

この Java コードは、プレゼンテーション内のすべてのテキストを更新（変更）する操作を示しています:
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // 形状がテキストフレーム（IAutoShape）をサポートしているか確認します。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // テキストフレーム内の段落を繰り返し処理します。
                {
                    for (IPortion portion : paragraph.getPortions()) // 段落内の各ポーションを繰り返し処理します。
                    {
                        portion.setText(portion.getText().replace("years", "months")); // テキストを変更します。
                        portion.getPortionFormat().setFontBold(NullableBool.True); // 書式を変更します。
                    }
                }
            }
        }
    }

    // 変更されたプレゼンテーションを保存します。
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ハイパーリンク付きテキスト ボックスの追加** 

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはそのリンク先を開きます。

ハイパーリンクを含むテキスト ボックスを追加するには、次の手順を実行します。

1. `Presentation` クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. スライド上の指定位置に `Rectangle` として設定された `ShapeType` を持つ `AutoShape` オブジェクトを追加し、新しく追加された AutoShape オブジェクトへの参照を取得します。
4. デフォルトテキストとして *Aspose TextBox* を含む `TextFrame` を `AutoShape` オブジェクトに追加します。 
5. `IHyperlinkManager` クラスのインスタンスを作成します。 
6. `IHyperlinkManager` オブジェクトを、`TextFrame` の任意の部分に関連付けられた [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) プロパティに割り当てます。 
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。 

この Java コード（上記手順の実装）は、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています:
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape オブジェクトを追加
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // シェイプを AutoShape にキャスト
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape に関連付けられた ITextFrame プロパティにアクセス
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // フレームにテキストを追加
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ポーションテキストにハイパーリンクを設定
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX プレゼンテーションを保存
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**マスタースライドで作業するときのテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/androidjava/manage-placeholder/) は [master](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) からスタイル/位置を継承し、[layouts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) で上書きできます。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変化しません。

**チャート、テーブル、SmartArt 内のテキストに影響を与えずに、プレゼンテーション全体で大量のテキスト置換を実行するにはどうすればよいですか？**

テキスト フレームを持つオートシェイプだけを反復対象とし、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)）は別々にコレクションを走査するか、これらのオブジェクトタイプをスキップして除外してください。