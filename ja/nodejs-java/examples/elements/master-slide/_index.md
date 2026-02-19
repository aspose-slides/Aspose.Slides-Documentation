---
title: マスタースライド
type: docs
weight: 30
url: /ja/nodejs-java/examples/elements/master-slide/
keywords:
- コード例
- マスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js のマスタースライド例を探求し、PPT、PPTX、ODP でマスター、プレースホルダー、テーマを作成、編集、スタイル設定できるコードを示します。"
---
マスタースライドは、PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド**は、背景、ロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウトスライド**はマスタースライドから継承し、**標準スライド**はレイアウトスライドから継承します。

この記事では、Aspose.Slides for Node.js via Java を使用してマスタースライドの作成、変更、管理方法を示します。

## **マスタースライドの追加**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。その後、レイアウト継承を通じてすべてのスライドに会社名バナーを追加します。

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // デフォルトのマスタースライドをクローンします。
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // マスタースライドの上部に会社名バナーを追加します。
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // 新しいマスタースライドをレイアウトスライドに割り当てます。
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // レイアウトスライドをプレゼンテーションの最初のスライドに割り当てます。
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注 1:** マスタースライドは、すべてのスライドに一貫したブランディングや共有デザイン要素を適用する方法を提供します。マスターに加えた変更は、依存するレイアウトスライドと標準スライドに自動的に反映されます。

> 💡 **注 2:** マスタースライドに追加された形状や書式設定はレイアウトスライドに継承され、さらにそれらのレイアウトを使用するすべての標準スライドにも継承されます。以下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に表示される様子を示しています。

![マスター継承例](master-slide-banner.png)

## **マスタースライドにアクセス**

プレゼンテーションのマスターコレクションを使用してマスタースライドにアクセスできます。以下は、それらを取得し操作する方法です。

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // 背景のタイプを変更します。
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **マスタースライドの削除**

マスタースライドは、インデックスまたは参照によって削除できます。

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // インデックスでマスタースライドを削除します。
        presentation.getMasters().removeAt(0);

        // 参照でマスタースライドを削除します。
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **未使用のマスタースライドの削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 未使用のマスタースライドをすべて削除します（Preserve とマークされたものも含みます）。
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```