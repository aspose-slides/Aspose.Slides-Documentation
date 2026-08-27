---
title: Android のプレゼンテーションでテキストボックスを管理する
linktitle: テキストボックスを管理
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
description: "Aspose.Slides for Android via Java を使用すると、PowerPoint および OpenDocument ファイル内でテキストボックスの作成、編集、複製が簡単になり、プレゼンテーションの自動化が向上します。"
---
## **導入**

スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキストボックスを追加し、そのテキストボックスにテキストを入れる必要があります。Aspose.Slides for Android via Java は、テキストを含むシェイプを追加できる[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape)インターフェイスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides は、スライドにシェイプを追加できる[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShape)インターフェイスも提供します。しかし、`IShape`インターフェイスを通して追加されたすべてのシェイプがテキストを保持できるわけではありません。ただし、[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape)インターフェイスを通して追加されたシェイプはテキストを含むことができます。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合、そのシェイプが`IAutoShape`インターフェイスにキャストされているか確認する必要があります。そうで初めて、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/TextFrame)を操作できます。このページの[Update Text](https://docs.aspose.com/slides/ja/androidjava/manage-textbox/#update-text)セクションをご覧ください。
{{% /alert %}}

## **スライド上にテキストボックスを作成する**

テキストボックスをスライドに作成する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に、`Rectangle`に設定された[ShapeType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-)を持つ[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape)オブジェクトを追加し、新しく追加された`IAutoShape`オブジェクトへの参照を取得します。  
4. `IAutoShape`オブジェクトにテキストを含む`TextFrame`プロパティを追加します。以下の例では、*Aspose TextBox*というテキストを追加しています。  
5. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き出します。  

このJavaコード—上記手順の実装例—は、スライドにテキストを追加する方法を示しています：

```java
import com.aspose.slides.*;

// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // タイプが Rectangle に設定された AutoShape を追加
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

## **テキストボックスシェイプの確認**

Aspose.Slidesは、[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/)インターフェイスの[isTextBox](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#isTextBox--)メソッドを提供しており、シェイプを調べてテキストボックスかどうかを判別できます。

![Text box and shape](istextbox.png)

このJavaコードは、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示しています：

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

`addAutoShape`メソッド（[IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/)インターフェイス）で自動シェイプを追加した場合、`isTextBox`メソッドは`false`を返します。ただし、`addTextFrame`メソッドまたは`setText`メソッドで自動シェイプにテキストを追加すると、`isTextBox`プロパティは`true`を返します。

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

## **テキストフレームを所有するシェイプの取得**

汎用的なテキスト処理コードでは、どのプレゼンテーションオブジェクトが[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/)を所有しているか事前に分からないことがあります。所有する[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/)へ戻るには、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--)メソッドを使用します。

[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/)やその他のテキストを含むシェイプに属するテキストフレームの場合、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--)は所有シェイプを返し、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--)は`null`を返します。両メソッドは読み取り専用のナビゲーションを提供するため、呼び出しても所有権は変わりません。シェイプにアクセスする前に、返された値が`null`でないことを必ず確認してください。

SmartArtノードに関連付けられたシェイプを含む、シェイプとテーブルセルの所有者を特定する完全な例については、[Search and Replace Text](/slides/ja/androidjava/search-and-replace-text/)をご覧ください。

## **テキストボックスに列を追加する**

Aspose.Slidesは、[ITextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat)インターフェイスおよび[TextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/TextFrameFormat)クラスから提供される[ColumnCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)および[ColumnSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-)プロパティを使用して、テキストボックスに列を追加できます。列数と列間のポイント単位の間隔を指定できます。

このJavaコードは、上述の操作を実演しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプが Rectangle に設定された AutoShape を追加
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle に TextFrame を追加
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame のテキストフォーマットを取得
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

## **テキストフレームに列を追加する**

Aspose.Slides for Android via Java は、[ITextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat)インターフェイスから提供される[ColumnCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)プロパティを使用して、テキストフレーム内に列を追加できます。このプロパティを介して、希望する列数を指定できます。

このJavaコードは、テキストフレーム内に列を追加する方法を示しています：

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
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

Aspose.Slides を使用すると、テキストボックス内のテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

以下のJavaコードは、プレゼンテーション内のすべてのテキストを更新（変更）する操作をデモンストレーションしています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //シェイプがテキストフレーム (IAutoShape) をサポートしているか確認します。
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //テキストフレーム内の段落を反復処理します
                {
                    for (IPortion portion : paragraph.getPortions()) //段落内の各ポーションを反復処理します
                    {
                        portion.setText(portion.getText().replace("years", "months")); //テキストを変更します
                        portion.getPortionFormat().setFontBold(NullableBool.True); //書式を変更します
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

## **ハイパーリンク付きテキストボックスの追加**

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはそのリンク先へ移動します。

ハイパーリンクを含むテキストボックスを追加する手順は以下の通りです。

1. `Presentation`クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に、`Rectangle`に設定された`ShapeType`を持つ`AutoShape`オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトへの参照を取得します。  
4. `AutoShape`オブジェクトに`TextFrame`を追加し、最初のポーションのテキストを設定します。以下の例では、*Aspose.Slides*というテキストを使用しています。  
5. `TextFrame`内の目的のポーションの`PortionFormat`から[IHyperlinkManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/)オブジェクトを取得します。  
6. 取得したオブジェクトの[setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)メソッドを呼び出し、テキストがクリックされたときに開くリンクを設定します。  
7. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き出します。  

このJavaコード—上記手順の実装例—は、ハイパーリンク付きテキストボックスをスライドに追加する方法を示しています：

```java
import com.aspose.slides.*;

// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // タイプが Rectangle に設定された AutoShape オブジェクトを追加
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // シェイプを AutoShape にキャスト
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape に関連付けられた ITextFrame プロパティにアクセス
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // フレームにテキストを追加
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ポーションテキストのハイパーリンクを設定
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

**マスタースライドで作業するとき、テキストボックスとテキストプレースホルダーの違いは何ですか？**

プレースホルダーは[master](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterslide/)からスタイルと位置を継承し、[layouts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslide/)で上書き可能です。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを変更しても影響を受けません。

**チャート、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体で一括テキスト置換を行うにはどうすればよいですか？**

テキストフレームを持つ自動シェイプだけを反復対象とし、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/smartart/)）はそれぞれのコレクションを別途走査するか、対象タイプをスキップして除外してください。