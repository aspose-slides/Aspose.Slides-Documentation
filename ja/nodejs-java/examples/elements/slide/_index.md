---
title: スライド
type: docs
weight: 10
url: /ja/nodejs-java/examples/elements/slide/
keywords:
- コード例
- スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でスライドを制御します：PPT、PPTX、ODP プレゼンテーションの作成、クローン、並べ替え、サイズ変更、背景設定、トランジションの適用を行います。"
---
このドキュメントでは、**Aspose.Slides for Node.js via Java** を使用してスライドを操作する一連の例を示します。`Presentation` クラスを使ってスライドの追加、取得、クローン、並び替え、削除を学びます。

以下の各例は簡単な説明と、JavaScript のコードスニペットで構成されています。

## **スライドの追加**

スライドを新規に追加するには、まずレイアウトを選択する必要があります。この例では `Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注:** 各スライドレイアウトはマスタースライドから派生しており、全体的なデザインとプレースホルダー構造が定義されています。下の画像は、PowerPoint におけるマスタースライドとそれに関連付けられたレイアウトの構成を示しています。

![マスタースライドとレイアウトの関係](master-layout-slide.png)

## **インデックスでスライドにアクセス**

インデックスを使用してスライドにアクセスできます。これは、特定のスライドを反復処理したり変更したりする際に便利です。

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // インデックスでスライドにアクセスします。
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **スライドのクローン**

この例では既存のスライドをクローンする方法を示します。クローンされたスライドは自動的にスライドコレクションの末尾に追加されます。

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **スライドの並べ替え**

スライドを新しいインデックスに移動させることで順序を変更できます。この例では、スライドを最初の位置に移動します。

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 2番目のスライドを最初の位置に移動してスライドを並べ替えます。
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **スライドの削除**

`remove` を呼び出すだけでスライドを削除できます。この例では、2枚目のスライドを追加し、元のスライドを削除して新しいスライドだけが残ります。

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```