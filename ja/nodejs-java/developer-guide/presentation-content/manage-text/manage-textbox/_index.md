---
title: JavaScript を使用してプレゼンテーションのテキスト ボックスを管理する
linktitle: テキスト ボックスを管理する
type: docs
weight: 20
url: /ja/nodejs-java/manage-textbox/
keywords:
- テキスト ボックス
- テキスト フレーム
- テキストの追加
- テキストの更新
- テキスト ボックスの作成
- テキスト ボックスの確認
- テキスト 列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーション内のテキスト ボックスを作成、識別、書式設定、更新します。"
---
## **はじめに**

Aspose.Slides for Node.js via Java では、スライドのテキストはシェイプに属するテキストフレームに格納されます。 [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) クラスは、最も一般的なテキストを保持するシェイプを表し、そのテキストを [AutoShape.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#getTextFrame) メソッドで取得できます。

{{% alert color="info" title="Note" %}}
すべての AutoShape は [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) から派生しますが、すべてのシェイプが AutoShape であるわけでも、テキストフレームをサポートしているわけでもありません。既存のプレゼンテーションを処理する際は、テキストにアクセスする前にシェイプが [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) のインスタンスかどうかを確認してください。
{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

テキスト ボックスを作成するには、スライドに AutoShape を追加し、そのテキストフレームにテキストを設定して、プレゼンテーションを保存します。以下の例は矩形のテキスト ボックスを作成します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addAutoShape) に渡す座標とサイズはポイント単位です。 [AutoShape.addTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#addTextFrame) は、指定されたテキストでテキストフレームを初期化します。

## **テキスト ボックス シェイプかどうかを確認する**

[AutoShape.isTextBox](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#isTextBox) メソッドを使用して、AutoShape がテキスト ボックスとして扱われるかどうかを判定できます。これは、プレゼンテーションにテキストを保持するシェイプと純粋なグラフィック シェイプの両方が含まれる場合に便利です。

![テキスト ボックスとシェイプ](istextbox.png)

次の例は、プレゼンテーション内のすべての AutoShape を調べます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

新しく追加された AutoShape は、空でないテキストが含まれるまでテキスト ボックスとは見なされません。テキストは [AutoShape.addTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#addTextFrame) または [TextFrame.setText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#setText) で設定できます。空文字列を設定すると、[AutoShape.isTextBox](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#isTextBox) は `false` を返します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

最初の 2 回の呼び出しは `true`、後の 2 回は `false` を出力します。

## **テキスト フレームを所有するシェイプを見つける**

汎用的なテキスト処理コードは、どのプレゼンテーション オブジェクトが所有しているか分からないまま [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を受け取ることがあります。読み取り専用の [TextFrame.getParentShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentShape) メソッドを使用して、所有シェイプへ遡ることができます。

AutoShape や他のテキストを保持するシェイプが所有するテキストフレームの場合、[TextFrame.getParentShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentShape) は所有者シェイプを返し、[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentCell) は `null` を返します。取得した値が `null` でないことを確認してから使用してください。シェイプとテーブル セルの両方の所有者、さらに SmartArt ノードに関連付けられたシェイプを特定する方法は、[Search and Replace Text](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加する**

[TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setColumnCount) メソッドはテキストフレームを列に分割し、[TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) は列間の間隔（ポイント）を設定します。これらの設定はすべて [TextFrameFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/) に属し、既存のテキスト ボックスのテキストフレームを通じて変更できます。列間でテキストが再配置されますが、テキストは別のシェイプへは流れません。

次の例は、列数 3、列間 10 ポイントのテキスト ボックスを作成し、プレゼンテーションを保存してから設定を読み込み直します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **個々の列からテキストを抽出する**

[TextFrame.splitTextByColumns](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#splitTextByColumns) を使用すると、既存のテキストフレーム内で視覚的に分割された各列に割り当てられたテキストを取得できます。このメソッドは列ごとに 1 つの文字列を返し、列ベースの読み取り順になります。単一列のテキストフレームは要素が 1 つの配列を返し、空の列は空文字列で表されます。返される文字列はプレーンテキストのみで、部分レベルの書式情報は保持されません。

この機能は次のようなシナリオで役立ちます。

- 列ベースの読み取り順を保ったままテキストを抽出したい場合  
- マルチ列スライドの内容をインデックス化または比較したい場合  
- 各列を個別のファイル、データベース フィールド、または他の宛先にエクスポートしたい場合  
- [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setColumnCount)、[TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing)、フォント、テキストフレームのサイズを変更したときにテキストがどのように再配置されるかを検証したい場合  

このメソッドは現在の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) 内に配置されたテキストを報告するだけで、別々のシェイプやテキスト ボックス間で自動的にテキストを流しません。列の分布は利用可能なフォントやその他のレイアウト設定に依存するため、結果の一貫性が重要な場合は必要なフォントが利用可能であることを確認してください。

次の例はプレゼンテーションを読み込み、テキストフレームを持つ最初のマルチ列 AutoShape を見つけ、設定された列数を取得し、各列のテキストを個別のファイルに書き出します。テキストフレームを提供しないシェイプはスキップされます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **テキストの更新**

プレゼンテーション全体のテキストを更新するには、スライドとシェイプを反復処理し、AutoShape を選択してテキスト部分を編集します。部分レベルで操作することで、テキストだけでなく文字書式も変更できます。

次の例は、AutoShape のテキスト中の `years` をすべて `months` に置換し、該当する部分を太字にします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この走査は AutoShape のみのテキストを更新します。テーブル、チャート、SmartArt、グループ化シェイプ内のテキストは、それらオブジェクト固有のコレクションを走査しない限り変更されません。

## **ハイパーリンク付きテキスト ボックスを追加する**

ハイパーリンクは特定のテキスト部分に割り当てられ、その部分だけがクリック可能になります。外部 URL と結びつけるには、[HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) を使用します。

次の例はリンク付きテキストを作成し、プレゼンテーションに保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**テキスト ボックスとマスターまたはレイアウト スライド上のテキスト プレースホルダーの違いは何ですか？**

[プレースホルダー](/slides/ja/nodejs-java/manage-placeholder/) は、[マスタースライド](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) または [レイアウトスライド](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) から位置と書式を継承できます。通常のテキスト ボックスは作成されたスライド上の独立したシェイプであり、レイアウトが変更されてもプレースホルダーの動作を取得しません。

**チャート、テーブル、SmartArt のテキストを変更せずにテキストだけを置換するにはどうすればよいですか？**

Update Text の例のように、[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) のインスタンスであるシェイプだけを走査対象に限定してください。チャート、テーブル、SmartArt はそれぞれ独自のオブジェクトモデルでテキストを保持しているため、このループでは変更されません。