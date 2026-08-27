---
title: JavaScript を使用したプレゼンテーションでのテキスト ボックス管理
linktitle: テキスト ボックスの管理
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
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js は、PowerPoint および OpenDocument ファイル内のテキスト ボックスの作成、編集、複製を簡単にし、プレゼンテーションの自動化を強化します。"
---
## **概要**

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。したがって、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックス内にテキストを配置する必要があります。Aspose.Slides for Node.js via Java は、テキストを含むシェイプを追加できる[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/AutoShape)クラスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides は、スライドにシェイプを追加できる[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Shape)クラスも提供します。ただし、`Shape` クラスで追加したすべてのシェイプがテキストを保持できるわけではありません。一方、[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/AutoShape) クラスで追加したシェイプはテキストを含むことができます。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合は、`AutoShape` クラスとしてキャストされていることを確認したほうがよいでしょう。そうすれば、`AutoShape` のプロパティである[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrame)を操作できます。このページの[Update Text](https://docs.aspose.com/slides/ja/nodejs-java/manage-textbox/#update-text)セクションをご参照ください。
{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

テキスト ボックスをスライドに作成する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `Rectangle` として `ShapeType` を設定した[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/AutoShape) オブジェクトを追加し、追加された `AutoShape` オブジェクトへの参照を取得します。  
4. テキストを格納する `TextFrame` プロパティを `AutoShape` オブジェクトに追加します。下記の例では、*Aspose TextBox* というテキストを追加しています。  
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

この JavaScript コード（上記手順の実装例）は、スライドにテキストを追加する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiates Presentation
// プレゼンテーションのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide in the presentation
    // プレゼンテーションの最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // Adds an AutoShape with type set as Rectangle
    // タイプを Rectangle に設定した AutoShape を追加
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adds TextFrame to the Rectangle
    // Rectangle に TextFrame を追加
    ashp.addTextFrame(" ");
    // Accesses the text frame
    // テキスト フレームにアクセス
    var txtFrame = ashp.getTextFrame();
    // Creates the Paragraph object for text frame
    // テキスト フレーム用の Paragraph オブジェクトを作成
    var para = txtFrame.getParagraphs().get_Item(0);
    // Creates a Portion object for paragraph
    // Paragraph 用の Portion オブジェクトを作成
    var portion = para.getPortions().get_Item(0);
    // Sets Text
    // テキストを設定
    portion.setText("Aspose TextBox");
    // Saves the presentation to disk
    // プレゼンテーションをディスクに保存
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テキスト ボックス シェイプかどうかの判定**

Aspose.Slides は、[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) クラスの[isTextBox](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#isTextBox) メソッドを提供しており、シェイプを調べてテキスト ボックスかどうかを識別できます。

![Text box and shape](istextbox.png)

この JavaScript コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`ShapeCollection` クラスの `addAutoShape` メソッドで単にオートシェイプを追加しただけの場合、オートシェイプの `isTextBox` メソッドは `false` を返します。ただし、`addTextFrame` メソッドまたは `setText` メソッドでオートシェイプにテキストを追加した後は、`isTextBox` プロパティは `true` を返します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() は false を返します
shape1.addTextFrame("shape 1");
// shape1.isTextBox() は true を返します

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() は false を返します
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() は true を返します

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() は false を返します
shape3.addTextFrame("");
// shape3.isTextBox() は false を返します

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() は false を返します
shape4.getTextFrame().setText("");
// shape4.isTextBox() は false を返します
```

## **TextFrame を所有するシェイプの取得**

汎用的なテキスト処理コードでは、どのプレゼンテーション オブジェクトが所有しているか分からないまま [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を受け取ることがあります。その場合は、[TextFrame.getParentShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentShape--) メソッドを使用して、所有している [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) に遡ります。

[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) や他のテキストを含むシェイプに属するテキスト フレームの場合、`TextFrame.getParentShape` は所有シェイプを返し、`TextFrame.getParentCell` は `null` を返します。両メソッドは読み取り専用のナビゲーションを提供するため、呼び出しても所有権は変更されません。シェイプにアクセスする前に、返された値が `null` でないことを必ず確認してください。

シェイプおよびテーブル セルの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全なサンプルは、[Search and Replace Text](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加する**

Aspose.Slides は、[TextFrameFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrameFormat) クラスの[setColumnCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) と[setColumnSpacing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) メソッドを提供しており、テキスト ボックスに列を追加できます。列数と列間のポイント単位の間隔を指定できます。

以下の JavaScript コードは、上記の操作を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // タイプを Rectangle に設定した AutoShape を追加
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle に TextFrame を追加
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame のテキスト フォーマットを取得
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame の列数を指定
    format.setColumnCount(3);
    // 列間の間隔を指定
    format.setColumnSpacing(10);
    // プレゼンテーションを保存
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テキスト フレームに列を追加する**

Aspose.Slides for Node.js via Java は、[TextFrameFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrameFormat) クラスの[setColumnCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) メソッドを提供しており、テキスト フレーム内に列を追加できます。このプロパティを使用して、テキスト フレーム内の希望する列数を指定できます。

この JavaScript コードは、テキスト フレーム内に列を追加する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // 列間隔は設定されていなかったため、NaN として報告されます。
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テキストの更新**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション全体に含まれるすべてのテキストを変更または更新できます。

以下の JavaScript コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // シェイプがテキスト フレーム (IAutoShape) をサポートしているかチェックします。
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // テキスト フレーム内の段落を反復処理します
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // 段落内の各ポーションを反復処理します
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// テキストを変更します
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 書式を変更します
                    }
                }
            }
        }
    }
    // 変更されたプレゼンテーションを保存します
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ハイパーリンク付きテキスト ボックスの追加**

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはそのリンク先を開きます。

ハイパーリンクを含むテキスト ボックスを追加する手順は以下の通りです。

1. `Presentation` クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `Rectangle` として `ShapeType` を設定した `AutoShape` オブジェクトを追加し、追加された AutoShape オブジェクトへの参照を取得します。  
4. `AutoShape` オブジェクトに `TextFrame` を追加し、最初の Portion のテキストを設定します。下記の例では *Aspose.Slides* というテキストを使用しています。  
5. その Portion の `PortionFormat` から `HyperlinkManager` を取得します。  
6. `HyperlinkManager` の `setExternalHyperlinkClick` を呼び出して、リンクを Portion に付与します。  
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

この JavaScript コード（上記手順の実装例）は、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // タイプを Rectangle に設定した AutoShape オブジェクトを追加
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // シェイプを AutoShape にキャスト
    var pptxAutoShape = shape;
    // AutoShape に関連付けられた ITextFrame プロパティにアクセス
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // フレームにテキストを追加
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // ポーション テキストにハイパーリンクを設定
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX プレゼンテーションを保存
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**マスタースライドを使用する際、テキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

プレースホルダー（[/slides/ja/nodejs-java/manage-placeholder/]）は[マスター](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/)からスタイルと位置を継承し、[レイアウト](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/)で上書き可能です。一方、通常のテキスト ボックスは特定のスライド上に配置された独立したオブジェクトであり、レイアウトを切り替えても変わりません。

**グラフ、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体で一括テキスト置換を行うにはどうすればよいですか？**

テキスト フレームを持つオートシェイプだけを対象に反復処理し、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/)、[テーブル](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartart/)）は別個にコレクションを走査するか、該当オブジェクトタイプをスキップすることで実現できます。