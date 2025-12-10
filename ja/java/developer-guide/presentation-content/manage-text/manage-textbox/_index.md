---
title: Javaでプレゼンテーションのテキストボックスを管理する
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/java/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキスト追加
- テキスト更新
- テキストボックス作成
- テキストボックスチェック
- テキスト列追加
- ハイパーリンク追加
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用すると、PowerPoint や OpenDocument ファイル内のテキストボックスの作成、編集、複製が簡単になり、プレゼンテーションの自動化が向上します。"
---

スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキストボックスを追加し、そのテキストボックス内にテキストを入れる必要があります。Aspose.Slides for Java は、テキストを含むシェイプを追加できる[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)インターフェイスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides は、スライドにシェイプを追加できる[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)インターフェイスも提供します。ただし、`IShape`インターフェイスを通じて追加されたすべてのシェイプがテキストを保持できるわけではありません。[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)インターフェイスを通じて追加されたシェイプはテキストを含む場合があります。 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う際には、`IAutoShape`インターフェイスにキャストされているか確認した方が良いでしょう。そうすれば、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)を使用できます。このページの[Update Text](https://docs.aspose.com/slides/java/manage-textbox/#update-text)セクションを参照してください。 
{{% /alert %}}

## **スライド上にテキストボックスを作成する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に`Rectangle`に設定された[ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-)を持つ[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)オブジェクトを追加し、新しく追加された`IAutoShape`オブジェクトへの参照を取得します。  
4. テキストを含む`IAutoShape`オブジェクトに`TextFrame`プロパティを追加します。以下の例では、*Aspose TextBox*というテキストを追加しました。  
5. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き出します。  

このJavaコード（上記手順の実装）は、スライドにテキストを追加する方法を示しています。  
```java
// プレゼンテーションをインスタンス化します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape を追加します
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加します
    ashp.addTextFrame(" ");

    // テキストフレームにアクセスします
    ITextFrame txtFrame = ashp.getTextFrame();

    // テキストフレームの Paragraph オブジェクトを作成します
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Paragraph の Portion オブジェクトを作成します
    IPortion portion = para.getPortions().get_Item(0);

    // テキストを設定します
    portion.setText("Aspose TextBox");

    // プレゼンテーションをディスクに保存します
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストボックス形状のチェック**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)インターフェイスの[isTextBox](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--)メソッドを提供し、シェイプを調べてテキストボックスかどうかを判別できます。

![Text box and shape](istextbox.png)

このJavaコードは、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示しています。  
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


`addAutoShape`メソッド（[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/)インターフェイス）を使用して単にオートシェイプを追加した場合、オートシェイプの`isTextBox`メソッドは`false`を返します。ただし、`addTextFrame`メソッドまたは`setText`メソッドでオートシェイプにテキストを追加すると、`isTextBox`プロパティは`true`を返します。  
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


## **テキストボックスに列を追加する**

Aspose.Slides は、テキストボックスに列を追加できる[ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)および[ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)インターフェイスおよび[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスから）を提供します。テキストボックスの列数を指定し、列間のポイント単位の間隔を設定できます。

このJavaコードは、上記の操作を示しています。  
```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプを Rectangle に設定した AutoShape を追加します
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle に TextFrame を追加します
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame のテキストフォーマットを取得します
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame の列数を指定します
    format.setColumnCount(3);

    // 列間の間隔を指定します
    format.setColumnSpacing(10);

    // プレゼンテーションを保存します
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストフレームに列を追加する**

Aspose.Slides for Java は、テキストフレームに列を追加できる[ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)インターフェイス）を提供します。このプロパティを使用して、テキストフレーム内の列数を指定できます。

このJavaコードは、テキストフレーム内に列を追加する方法を示しています。  
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

Aspose.Slides を使用すると、テキストボックス内のテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

このJavaコードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています。  
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // シェイプがテキストフレーム（IAutoShape）をサポートしているかチェックします。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // テキストフレーム内の段落を反復処理します。
                {
                    for (IPortion portion : paragraph.getPortions()) // 段落内の各ポーションを反復処理します。
                    {
                        portion.setText(portion.getText().replace("years", "months")); // テキストを変更します。
                        portion.getPortionFormat().setFontBold(NullableBool.True); // 書式設定を変更します。
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


## **ハイパーリンク付きテキストボックスの追加**

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはリンク先を開きます。

1. `Presentation`クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に`ShapeType`が`Rectangle`に設定された`AutoShape`オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトへの参照を取得します。  
4. デフォルトテキストとして*Aspose TextBox*を含む`TextFrame`を`AutoShape`オブジェクトに追加します。  
5. `IHyperlinkManager`クラスのインスタンスを作成します。  
6. `TextFrame`の対象部分に関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--)プロパティに`IHyperlinkManager`オブジェクトを割り当てます。  
7. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き出します。  

このJavaコード（上記手順の実装）は、ハイパーリンク付きテキストボックスをスライドに追加する方法を示しています。  
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

    // ポーションテキストにハイパーリンクを設定します
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

**マスタースライドでテキストボックスとテキストプレースホルダーの違いは何ですか？**

プレースホルダー([placeholder](/slides/ja/java/manage-placeholder/))は、[マスタースライド](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/)からスタイルと位置を継承し、[レイアウト](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/)で上書きできます。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変更されません。

**チャート、テーブル、SmartArt 内のテキストを変更せずに、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキストフレームを持つオートシェイプのみを対象に反復処理し、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)、[テーブル](https://reference.aspose.com/slides/java/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)）を除外するために、これらのコレクションを別々に走査するか、該当オブジェクトタイプをスキップしてください。