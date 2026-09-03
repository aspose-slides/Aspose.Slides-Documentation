---
title: Android でプレゼンテーションのテキストボックスを管理する
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストボックスを作成、識別、書式設定、更新します。"
---
## **概要**

Aspose.Slides for Android via Java では、スライドのテキストはシェイプに属するテキストフレームに格納されます。 [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) インターフェイスは最も一般的なテキストを保持するシェイプを表し、そのテキストは [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) メソッドで取得できます。

{{% alert color="info" title="Note" %}}
すべてのオートシェイプは [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) を実装しますが、すべてのシェイプがオートシェイプであるわけでもテキストフレームをサポートしているわけでもありません。既存のプレゼンテーションを処理する際は、テキストにアクセスする前にシェイプが [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を実装していることを確認してください。
{{% /alert %}}

## **スライド上にテキストボックスを作成する**

テキストボックスを作成するには、スライドにオートシェイプを追加し、そのテキストフレームにテキストを追加してプレゼンテーションを保存します。以下の例は矩形のテキストボックスを作成します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) に渡す座標とサイズはポイント単位で測定されます。 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) は指定されたテキストでテキストフレームを初期化します。

## **テキストボックス シェイプの確認**

[IAutoShape.isTextBox](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#isTextBox--) メソッドを使用して、オートシェイプがテキストボックスとして扱われるかどうかを判断します。プレゼンテーションにテキストを保持するシェイプと純粋にグラフィックだけのオートシェイプの両方が含まれている場合に便利です。

![テキストボックスとシェイプ](istextbox.png)

以下の例はプレゼンテーション内のすべてのオートシェイプを調査します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

新しく追加されたオートシェイプは、空でないテキストを含むまでテキストボックスとは見なされません。テキストは [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) または [ITextFrame.setText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) で設定できます。空文字列を追加または代入すると、[IAutoShape.isTextBox](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/#isTextBox--) は `false` を返します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

最初の 2 回の呼び出しは `true` を出力し、最後の 2 回は `false` を出力します。

## **テキストフレームを所有するシェイプの取得**

汎用的なテキスト処理コードは、どのプレゼンテーションオブジェクトが所有しているか分からない [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を受け取ることがあります。読み取り専用の [ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--) メソッドを使用して、所有する [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) に遡ります。

オートシェイプまたは他のテキストを保持するシェイプが所有するテキストフレームの場合、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--) は所有者を返し、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--) は `null` を返します。アクセスする前に返された値を確認してください。シェイプとテーブルセルの両方の所有者、ならびに SmartArt ノードに関連付けられたシェイプを特定するには、[Search and Replace Text](/slides/ja/androidjava/search-and-replace-text/) を参照してください。

## **テキストボックスに列を追加する**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) メソッドはテキストフレームを列に分割し、[ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) は列間の間隔をポイントで設定します。両方の設定は [ITextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/) に属し、既存のテキストボックスのテキストフレームを介して変更できます。テキストは同一シェイプ内の列間で再フローされ、別のシェイプへは続きません。

以下の例は 3 列のテキストボックスを作成し、列間を 10 ポイントに設定してプレゼンテーションを保存し、出力ファイルから設定を読み戻します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **個別列からテキストを抽出する**

[ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) を使用して、既存のテキストフレーム内の各視覚的列に割り当てられたテキストを取得します。このメソッドは列ごとに 1 つの文字列を返し、列ベースの読み取り順序で並びます。単一列のテキストフレームは要素が 1 つの配列を生成し、空の列は空文字列で表されます。返される文字列はプレーンテキストのみで、部分レベルの書式設定は保持されません。

この機能は次のようなケースで有用です。

- 列ベースの読み取り順序を保持したままテキストを抽出したい。
- マルチ列スライドの内容をインデックス化または比較したい。
- 各列を別々のファイル、データベースフィールド、または他の宛先にエクスポートしたい。
- [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) や [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 、フォント、テキストフレームサイズを変更したときにテキストがどのように再配分されるかを検査したい。

このメソッドは現在の [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) 内に分布したテキストを報告するだけで、別々のシェイプやテキストボックス間で自動的にテキストを流すことはありません。列の分布は利用可能なフォントやその他のテキストレイアウト設定に依存するため、結果の一貫性が重要な場合は必要なフォントが利用可能であることを確認してください。

以下の例はプレゼンテーションを読み込み、テキストフレームを持つ最初のマルチ列オートシェイプを見つけ、設定された列数を取得し、各列のテキストを別々のファイルに書き出します。テキストフレームを提供しないシェイプはスキップされます。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **テキストの更新**

プレゼンテーション全体のテキストを更新するには、スライドとシェイプを反復処理し、オートシェイプを選択してからテキスト部分を編集します。部分レベルで作業することで、テキストと文字書式の両方を変更できます。

以下の例は、オートシェイプのテキスト内の `years` をすべて `months` に置換し、影響を受けた部分を太字にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この走査はオートシェイプ内のテキストのみを更新します。テーブル、チャート、SmartArt、またはグループ化されたシェイプに格納されたテキストを更新するには、それらオブジェクト独自のコレクションを走査する必要があります。

## **ハイパーリンク付きテキストボックスの追加**

ハイパーリンクは特定のテキスト部分に割り当てることができ、その部分だけがクリック可能なリンクとして機能します。外部 URL と部分を関連付けるには [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) を使用します。

以下の例はリンク付きテキストを作成し、プレゼンテーションに保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**テキストボックスとマスターまたはレイアウトスライド上のテキスト プレースホルダーの違いは何ですか？**

[プレースホルダー](/slides/ja/androidjava/manage-placeholder/) は [マスタースライド](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterslide/) や [レイアウトスライド](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslide/) から位置と書式を継承できます。通常のテキストボックスは作成されたスライド上の独立したシェイプであり、レイアウトが変更されてもプレースホルダーの動作を取得しません。

**チャート、テーブル、SmartArt のテキストを変更せずにテキストを置換するにはどうすればよいですか？**

Update Text の例に示すように、[IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を実装しているシェイプにのみ走査を限定してください。チャート、テーブル、SmartArt はそれぞれ独自のオブジェクトモデルにテキストを保持しているため、そのループでは変更されません。