---
title: セクション
type: docs
weight: 90
url: /ja/nodejs-java/examples/elements/section/
keywords:
- コード例
- セクション
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Javaでスライドセクションを管理します。JavaScriptの例を使用して、PPT、PPTX、ODPのスライドを作成、名前変更、並び替え、グループ化します。"
---
**Aspose.Slides for Node.js via Java** を使用して、プレゼンテーションのセクションをプログラムで管理（追加、アクセス、削除、名前変更）する例。

## **セクションの追加**

特定のスライドから始まるセクションを作成します。

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // セクションの開始地点となるスライドを指定します。
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **セクションへのアクセス**

プレゼンテーションからセクション情報を取得します。

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // インデックスでセクションにアクセスします。
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **セクションの削除**

以前に追加したセクションを削除します。

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のセクションを削除します。
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **セクションの名前変更**

既存のセクションの名前を変更します。

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```