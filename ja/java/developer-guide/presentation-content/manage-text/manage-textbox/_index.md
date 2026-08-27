---
title: Java を使用したプレゼンテーションでのテキストボックスの管理
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用すると、PowerPoint および OpenDocument ファイルでテキストボックスの作成、編集、クローン作成が簡単になり、プレゼンテーションの自動化が向上します。"
---
## **概要**

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックスにテキストを入れる必要があります。Aspose.Slides for Java は、テキストを含むシェイプを追加できる [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) インターフェイスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides は、スライドにシェイプを追加できる [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShape) インターフェイスも提供します。ただし、`IShape` インターフェイスで追加されたすべてのシェイプがテキストを保持できるわけではありません。[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) インターフェイスで追加されたシェイプはテキストを含むことができます。 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合、そのシェイプが `IAutoShape` インターフェイスにキャストされているか確認する必要があります。そうして初めて `IAutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/TextFrame) を操作できます。このページの [Update Text](https://docs.aspose.com/slides/ja/java/manage-textbox/#update-text) セクションをご参照ください。 
{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

スライドにテキスト ボックスを作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. スライド上の指定位置に `Rectangle` に設定された [ShapeType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IGeometryShape#setShapeType-int-) を持つ [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトへの参照を取得します。 
4. `IAutoShape` オブジェクトにテキストを含む `TextFrame` プロパティを追加します。以下の例では、*Aspose TextBox* というテキストを追加しています。 
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き込みます。 

上記の手順を実装したこの Java コードは、スライドにテキストを追加する方法を示しています：

```java
import com.aspose.slides.*;

// プレゼンテーションのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // タイプが Rectangle に設定された AutoShape を追加します
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加します
    ashp.addTextFrame(" ");

    // テキストフレームにアクセスします
    ITextFrame txtFrame = ashp.getTextFrame();

    // テキストフレーム用の Paragraph オブジェクトを作成します
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Paragraph 用の Portion オブジェクトを作成します
    IPortion portion = para.getPortions().get_Item(0);

    // テキストを設定します
    portion.setText("Aspose TextBox");

    // プレゼンテーションをディスクに保存します
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキスト ボックス シェイプの確認**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) インターフェイスの [isTextBox](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/#isTextBox--) メソッドを提供し、シェイプを調べてテキスト ボックスかどうかを識別できます。

![テキスト ボックスとシェイプ](istextbox.png)

この Java コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示しています：

```java
import com.aspose.slides.*;

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

`addAutoShape` メソッド（[IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/) インターフェイス）で単にオートシェイプを追加した場合、そのオートシェイプの `isTextBox` メソッドは `false` を返します。しかし、`addTextFrame` メソッドまたは `setText` メソッドでオートシェイプにテキストを追加すると、`isTextBox` プロパティは `true` を返します。

```java
import com.aspose.slides.*;

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

## **テキスト フレームを所有するシェイプの取得**

一般的なテキスト処理コードでは、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を取得した際に、それがどのプレゼンテーションオブジェクトに含まれているか事前に分かっていないことがあります。所有する [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) に戻るには、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentShape--) メソッドを使用します。

[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) または他のテキストを含むシェイプに属するテキスト フレームの場合、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentShape--) は所有者を返し、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentCell--) は `null` を返します。両メソッドは参照専用のナビゲーションを提供するため、呼び出しても所有権は変更されません。シェイプにアクセスする前に、返された値が `null` でないことを必ず確認してください。

シェイプやテーブルセルの所有者、SmartArt ノードに関連付けられたシェイプを特定する完全な例については、[Search and Replace Text](/slides/ja/java/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加する**

Aspose.Slides は、テキスト ボックスに列を追加できる [ColumnCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) および [ColumnSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormat) インターフェイスと [TextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/TextFrameFormat) クラス）を提供します。テキスト ボックスの列数を指定し、列間のポイント単位の間隔を設定できます。

この Java のコードは、上記の操作を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプが Rectangle に設定された AutoShape を追加します
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

## **テキスト フレームに列を追加する**

Aspose.Slides for Java は、テキスト フレームに列を追加できる [ColumnCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormat) インターフェイス）を提供します。このプロパティを使用して、テキスト フレームの希望する列数を指定できます。

この Java のコードは、テキスト フレーム内に列を追加する方法を示しています：

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストの更新**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション内のすべてのテキストを変更または更新できます。

この Java のコードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //シェイプがテキストフレーム（IAutoShape）をサポートしているかチェックします。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //テキストフレーム内の段落を反復処理します
                {
                    for (IPortion portion : paragraph.getPortions()) //段落内の各ポーションを反復処理します
                    {
                        portion.setText(portion.getText().replace("years", "months")); //テキストを変更します
                        portion.getPortionFormat().setFontBold(NullableBool.True); //書式設定を変更します
                    }
                }
            }
        }
    }

    //変更されたプレゼンテーションを保存します
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ハイパーリンク付きテキスト ボックスの追加**

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはリンク先を開きます。

リンクを含むテキスト ボックスを追加するには、次の手順を実行します：

1. `Presentation` クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. スライド上の指定位置に `ShapeType` が `Rectangle` に設定された `AutoShape` オブジェクトを追加し、新しく追加された AutoShape オブジェクトへの参照を取得します。 
4. `AutoShape` オブジェクトに、デフォルトテキストとして *Aspose TextBox* を含む `TextFrame` を追加します。 
5. `IHyperlinkManager` クラスのインスタンスを作成します。 
6. `IHyperlinkManager` オブジェクトを、`TextFrame` の任意の部分に関連付けられた [HyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Shape#getHyperlinkClick--) プロパティに割り当てます。 
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き込みます。 

上記の手順を実装したこの Java のコードは、スライドにハイパーリンク付きテキスト ボックスを追加する方法を示しています：

```java
import com.aspose.slides.*;

// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプが Rectangle に設定された AutoShape オブジェクトを追加します
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // シェイプを AutoShape にキャストします
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape に関連付けられた ITextFrame プロパティにアクセスします
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // フレームにテキストを追加します
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ポーションテキストのハイパーリンクを設定します
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

**マスタースライドで作業するときのテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/java/manage-placeholder/) は、[master](https://reference.aspose.com/slides/ja/java/com.aspose.slides/masterslide/) からスタイルと位置を継承し、[layouts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslide/) で上書きできます。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトで、レイアウトを切り替えても変更されません。

**チャート、テーブル、SmartArt 内のテキストに影響を与えずに、プレゼンテーション全体で大量のテキスト置換を実行するにはどうすればよいですか？**

テキスト フレームを持つオートシェイプのみにイテレーションを限定し、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/ja/java/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/smartart/)）はそれぞれのコレクションを別々に走査するか、対象のオブジェクトタイプをスキップすることで、チャート、テーブル、SmartArt 内のテキストに触れずにプレゼンテーション全体のテキスト置換を行えます。