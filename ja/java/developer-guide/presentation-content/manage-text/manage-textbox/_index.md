---
title: Java を使用してプレゼンテーションのテキスト ボックスを管理する
linktitle: テキスト ボックスの管理
type: docs
weight: 20
url: /ja/java/manage-textbox/
keywords:
  - テキスト ボックス
  - テキスト フレーム
  - テキストの追加
  - テキストの更新
  - テキスト ボックスの作成
  - テキスト ボックスの確認
  - テキスト列の追加
  - ハイパーリンクの追加
  - PowerPoint
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキスト ボックスを作成、識別、書式設定、更新します。"
---
## **Introduction**

Aspose.Slides for Java では、スライドのテキストはシェイプに属するテキスト フレームに格納されます。最も一般的なテキストを保持するシェイプを表すインターフェイスが [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) で、テキストは [IAutoShape.getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#getTextFrame--) メソッドで取得できます。

{{% alert color="info" title="Note" %}}
すべてのオートシェイプは [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) を実装していますが、すべてのシェイプがオートシェイプであるわけでも、テキスト フレームをサポートしているわけでもありません。既存のプレゼンテーションを処理する際は、シェイプが [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を実装していることを確認してからテキストにアクセスしてください。
{{% /alert %}}

## **Create a Text Box on a Slide**

テキスト ボックスを作成するには、スライドにオートシェイプを追加し、そのテキスト フレームにテキストを設定してからプレゼンテーションを保存します。次の例は、長方形のテキスト ボックスを作成します。

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

[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) に渡す座標と寸法はポイント単位です。[IAutoShape.addTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) は指定したテキストでテキスト フレームを初期化します。

## **Check for a Text Box Shape**

[IAutoShape.isTextBox](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#isTextBox--) メソッドを使用して、オートシェイプがテキスト ボックスとして扱われるかどうかを判定できます。プレゼンテーションにテキストを保持するシェイプと純粋なグラフィック シェイプの両方が含まれる場合に便利です。

![A text box and a shape](istextbox.png)

次の例は、プレゼンテーション内のすべてのオートシェイプを調べます。

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

新たに追加したオートシェイプは、空でないテキストが含まれるまでテキスト ボックスとはみなされません。テキストは [IAutoShape.addTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) または [ITextFrame.setText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#setText-java.lang.String-) で設定できます。空文字列を追加または割り当てた場合、[IAutoShape.isTextBox](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/#isTextBox--) は `false` を返します。

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

## **Find the Shape That Owns a Text Frame**

汎用的なテキスト処理コードは、テキスト フレームがどのプレゼンテーション オブジェクトに属しているか分からないまま [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を受け取ることがあります。その所有者である [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) に戻るには、読み取り専用の [ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentShape--) メソッドを使用します。

オートシェイプや他のテキストを保持するシェイプが所有するテキスト フレームの場合、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentShape--) は所有シェイプを返し、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentCell--) は `null` を返します。アクセスする前に返された値を必ず確認してください。シェイプとテーブル セルの両方の所有者、さらに SmartArt ノードに関連付けられたシェイプを特定したい場合は、[Search and Replace Text](/slides/ja/java/search-and-replace-text/) を参照してください。

## **Add Columns to a Text Box**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) メソッドでテキスト フレームを列に分割し、[ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) で列間の間隔（ポイント）を設定します。これらの設定はすべて [ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/) に属し、既存のテキスト ボックスのテキスト フレームを介して変更できます。テキストは同一シェイプ内の列間で折り返され、別のシェイプへは流れません。

次の例は、列数 3、列間 10 ポイントのテキスト ボックスを作成し、プレゼンテーションを保存した後、出力ファイルから設定を読み戻します。

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

## **Extract Text from Individual Columns**

[ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#splitTextByColumns--) を使用すると、既存のテキスト フレーム内の各視覚的列に割り当てられたテキストを取得できます。このメソッドは列ごとに 1 つの文字列を返し、列ベースの読み取り順序に従います。単一列のテキスト フレームは要素が 1 つの配列を返し、空の列は空文字列で表されます。返される文字列はプレーン テキストのみで、部分レベルの書式情報は保持されません。

この機能は次のようなシナリオで役立ちます。

- 列ベースの読み取り順序を保持したままテキストを抽出したい。
- マルチ列スライドの内容をインデックス化または比較したい。
- 各列を別々のファイル、データベース フィールド、または他の宛先にエクスポートしたい。
- [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) や [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 、フォント、テキスト フレームのサイズを変更したときにテキストがどのように再配置されるか確認したい。

このメソッドは現在の [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) 内に分布しているテキストを返すだけで、別個のシェイプやテキスト ボックス間で自動的にテキストが流れることはありません。列の分布は使用可能なフォントや他のレイアウト設定に依存するため、結果の一貫性が重要な場合は必要なフォントが環境に揃っていることを確認してください。

次の例はプレゼンテーションを読み込み、テキスト フレームを持つ最初のマルチ列オートシェイプを見つけ、設定された列数を取得し、各列のテキストを別々のファイルに書き出します。テキスト フレームを提供しないシェイプはスキップされます。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Update Text**

プレゼンテーション全体のテキストを更新するには、スライドとシェイプを走査し、オートシェイプを選択してからテキストの部分を編集します。部分レベルで作業すると、テキストと文字書式の両方を変更できます。

次の例は、オートシェイプのテキスト内にあるすべての `years` を `months` に置換し、対象となった部分を太字にします。

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

この走査はオートシェイプ内のテキストのみを更新します。テーブル、チャート、SmartArt、グループ化シェイプに格納されたテキストを変更するには、これらオブジェクト独自のコレクションを走査する必要があります。

## **Add a Text Box with a Hyperlink**

ハイパーリンクは特定のテキスト部分に割り当てられるため、その部分だけがクリック可能なリンクになります。外部 URL と部分を関連付けるには [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) を使用します。

次の例はハイパーリンク付きテキストを作成し、プレゼンテーションに保存します。

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

**What is the difference between a text box and a text placeholder on a master or layout slide?**

プレースホルダー ([placeholder](/slides/ja/java/manage-placeholder/)) は、[マスタースライド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/masterslide/) または [レイアウトスライド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslide/) から位置と書式を継承できます。通常のテキスト ボックスは作成されたスライド上の独立したシェイプであり、レイアウトが変更されてもプレースホルダーのような振る舞いは取得しません。

**How can I replace text without changing text in charts, tables, or SmartArt?**

Update Text の例に示したように、[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を実装しているシェイプだけを走査対象としてください。チャート、テーブル、SmartArt はそれぞれ独自のオブジェクトモデルにテキストを保持しているため、このループでは変更されません。