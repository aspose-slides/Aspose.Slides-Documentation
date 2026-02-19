---
title: インク
type: docs
weight: 180
url: /ja/nodejs-java/examples/elements/ink/
keywords:
- コード例
- インク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でインクを操作します：ストロークを描画、インポート、編集し、色と幅を調整し、例を使用して PPT、PPTX、ODP にエクスポートします。"
---
この記事では、既存のインク形状へのアクセスとそれらの削除の例を **Aspose.Slides for Node.js via Java** を使用して示します。

> ❗ **注意:** インク形状は特殊デバイスからのユーザー入力を表します。Aspose.Slides はプログラムで新しいインクストロークを作成できませんが、既存のインクを読み取ったり変更したりできます。

## **インクにアクセス**

スライド上の最初のインク形状を取得します。

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **インクの削除**

スライドからインク形状を削除します。

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // インク形状がスライド上の最初の形状であると想定しています。
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```