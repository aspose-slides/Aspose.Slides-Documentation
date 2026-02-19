---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/nodejs-java/examples/elements/hyperlink/
keywords:
- コード例
- ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でハイパーリンクを追加および管理します：テキスト、図形、画像へのリンク、PPT、PPTX、ODP のターゲットとアクションを設定し、サンプルを示します。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用して、図形上のハイパーリンクの追加、アクセス、削除、更新方法を示します。

## **ハイパーリンクの追加**

外部ウェブサイトへリンクするハイパーリンクを持つ長方形の図形を作成します。

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ハイパーリンクへのアクセス**

図形のテキスト部分からハイパーリンクを読み取ります。

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがハイパーリンク付きテキストを含んでいると仮定します。
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **ハイパーリンクの削除**

図形のテキストからハイパーリンクをクリアします。

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがハイパーリンク付きテキストを含んでいると仮定します。
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ハイパーリンクの更新**

既存のハイパーリンクのターゲットを変更します。`HyperlinkManager` を使用して、すでにハイパーリンクを含むテキストを変更し、PowerPoint がハイパーリンクを安全に更新する方法を模倣します。

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプがハイパーリンク付きテキストを含んでいると仮定します。
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // 既存のテキスト内のハイパーリンクを変更するには、
        // HyperlinkManager を使用し、プロパティを直接設定するのではなく行うべきです。
        // これは PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```