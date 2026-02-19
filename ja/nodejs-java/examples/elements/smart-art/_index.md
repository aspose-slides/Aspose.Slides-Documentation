---
title: SmartArt
type: docs
weight: 140
url: /ja/nodejs-java/examples/elements/smart-art/
keywords:
- コード例
- SmartArt
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js で SmartArt を操作します。PowerPoint および OpenDocument プレゼンテーション用に、JavaScript で図表の作成、編集、変換、スタイル設定を行います。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用して SmartArt グラフィックの追加、アクセス、削除、レイアウト変更の方法を示します。

## **SmartArt の追加**

組み込みのレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt へのアクセス**

スライド上の最初の SmartArt オブジェクトを取得します。

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt の削除**

スライドから SmartArt シェイプを削除します。

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプが SmartArt であると仮定しています。
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt レイアウトの変更**

既存の SmartArt グラフィックのレイアウトタイプを更新します。

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプが SmartArt であると仮定しています。
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```