---
title: テキストボックスの管理
type: docs
weight: 20
url: /ja/nodejs-java/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキストを追加
- テキストを更新
- ハイパーリンク付きテキストボックス
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "JavaScript を使用して PowerPoint プレゼンテーションのテキストボックスまたはテキストフレームを管理する"
---

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、テキスト ボックス内にテキストを配置する必要があります。Aspose.Slides for Node.js via Java は、テキストを含むシェイプを追加できる[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)クラスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides では、スライドにシェイプを追加できる[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)クラスも提供しています。ただし、`Shape`クラスを使用して追加されたすべてのシェイプがテキストを保持できるわけではありません。`AutoShape`クラスを使用して追加されたシェイプはテキストを含む場合があります。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合は、`AutoShape`クラスを通じてキャストされたかどうかを確認したい場合があります。`AutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)を使用できるようになるのはそのときだけです。このページの[Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text)セクションをご覧ください。
{{% /alert %}}

## **スライド上にテキスト ボックスを作成**

スライド上にテキスト ボックスを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. 新しく作成されたプレゼンテーションの最初のスライドへの参照を取得します。 
3. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)オブジェクトを追加し、[ShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-)を`Rectangle`に設定してスライド上の指定位置に配置し、新しく追加された`AutoShape`オブジェクトへの参照を取得します。
4. `AutoShape`オブジェクトにテキストを含む`TextFrame`プロパティを追加します。以下の例では、このテキストを追加しました：*Aspose TextBox*
5. 最後に、`Presentation`オブジェクトを使用して PPTX ファイルを書き出します。 

上記の手順を実装したこの JavaScript コードは、スライドにテキストを追加する方法を示しています：
```javascript
// プレゼンテーションをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // タイプがRectangleに設定されたAutoShapeを追加
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // RectangleにTextFrameを追加
    ashp.addTextFrame(" ");
    // テキストフレームにアクセス
    var txtFrame = ashp.getTextFrame();
    // テキストフレーム用のParagraphオブジェクトを作成
    var para = txtFrame.getParagraphs().get_Item(0);
    // パラグラフ用のPortionオブジェクトを作成
    var portion = para.getPortions().get_Item(0);
    // テキストを設定
    portion.setText("Aspose TextBox");
    // プレゼンテーションをディスクに保存
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキスト ボックス シェイプの確認**

Aspose.Slides は、[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)クラスの[isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox)メソッドを提供し、シェイプを調べてテキスト ボックスを識別できるようにします。

![テキスト ボックスとシェイプ](istextbox.png)

この JavaScript コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示します：
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


単に[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)クラスの`addAutoShape`メソッドで AutoShape を追加しただけでは、その AutoShape の`isTextBox`メソッドは`false`を返します。ただし、`addTextFrame`メソッドや`setText`メソッドで AutoShape にテキストを追加すると、`isTextBox`プロパティは`true`を返すようになります。
```javascript
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


## **テキスト ボックスに列を追加**

Aspose.Slides は、[TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)クラスの[setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)および[setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-)メソッドを提供し、テキスト ボックスに列を追加できるようにします。テキスト ボックスの列数を指定し、列間のスペースをポイント単位で設定できます。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーション内の最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // タイプを Rectangle に設定した AutoShape を追加
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle に TextFrame を追加
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame のテキスト書式を取得
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


## **テキスト フレームに列を追加**

Aspose.Slides for Node.js via Java は、[TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)クラスの[setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)メソッドを提供し、テキスト フレームに列を追加できます。このプロパティを使用して、テキスト フレーム内の希望する列数を指定できます。

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

この JavaScript コードは、プレゼンテーション内のすべてのテキストが更新または変更される操作を示しています：
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // シェイプがテキストフレーム（IAutoShape）をサポートしているか確認します。
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // テキストフレーム内の段落を反復処理します
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

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはリンクを開くように誘導されます。 

リンクを含むテキスト ボックスを追加するには、次の手順を実行します：

1. `Presentation`クラスのインスタンスを作成します。 
2. 新しく作成されたプレゼンテーションの最初のスライドへの参照を取得します。 
3. `ShapeType`を`Rectangle`に設定した`AutoShape`オブジェクトをスライド上の指定位置に追加し、新しく追加された AutoShape オブジェクトへの参照を取得します。
4. `AutoShape`オブジェクトに、デフォルトテキストとして*Aspose TextBox*を含む`TextFrame`を追加します。 
5. `HyperlinkManager`クラスのインスタンスを作成します。 
6. 希望する`TextFrame`の部分に関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--)プロパティに`HyperlinkManager`オブジェクトを割り当てます。
7. 最後に、`Presentation`オブジェクトを使用して PPTX ファイルを書き出します。 

上記の手順を実装したこの JavaScript コードは、スライドにハイパーリンク付きテキスト ボックスを追加する方法を示しています：
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの最初のスライドを取得します
    var slide = pres.getSlides().get_Item(0);
    // タイプを Rectangle に設定した AutoShape オブジェクトを追加します
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // シェイプを AutoShape にキャストします
    var pptxAutoShape = shape;
    // AutoShape に関連付けられた ITextFrame プロパティにアクセスします
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // フレームにテキストを追加します
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // ポーションテキストのハイパーリンクを設定します
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX プレゼンテーションを保存します
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**マスタースライドで作業する際のテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/nodejs-java/manage-placeholder/)は[master](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)からスタイル/位置を継承し、[layouts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)で上書きできます。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトで、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストに影響を与えずに、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキスト フレームを持つ AutoShape のみを対象に反復処理し、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)）はそれぞれのコレレクションを別々に走査するか、これらのオブジェクトタイプをスキップして除外します。