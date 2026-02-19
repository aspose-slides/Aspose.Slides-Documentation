---
title: テキスト ボックス
type: docs
weight: 40
url: /ja/nodejs-java/examples/elements/text-box/
keywords:
- コード例
- テキストボックス
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js 用 Aspose.Slides でテキスト ボックスを操作します。JavaScript を使用して PPT、PPTX、ODP プレゼンテーションのテキストを追加、書式設定、配置、折り返し、自動調整、スタイル設定します。"
---
Aspose.Slidesでは、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべてのシェイプはテキストを含めることができますが、通常のテキスト ボックスは塗りつぶしや枠線がなく、テキストだけが表示されます。

このガイドでは、テキスト ボックスの追加、取得、および削除をプログラムで行う方法を説明します。

## **テキスト ボックスを追加**

テキスト ボックスは、塗りつぶしや枠線がなく、書式設定されたテキストを持つ `AutoShape` にすぎません。以下はその作成方法です:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 矩形シェイプを作成します（デフォルトでは枠線があり塗りつぶしがあり、テキストはありません）。
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // 塗りつぶしと枠線を削除して、典型的なテキストボックスのように見せます。
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // テキストの書式設定を行います。
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // 実際のテキスト内容を割り当てます。
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注:** 空でない `TextFrame` を含むすべての `AutoShape` はテキスト ボックスとして機能します。

## **テキスト ボックスにアクセス**

スライドから最初のテキスト ボックスを取得します。

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // AutoShape のみが編集可能なテキストを含めることができます。
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **内容でテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索して削除します:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ヒント:** イテレーション中に変更を加える前に、必ずシェイプ コレクションのコピーを作成して、コレクション変更エラーを回避してください。