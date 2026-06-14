---
title: 章節
type: docs
weight: 90
url: /zh-hant/nodejs-java/examples/elements/section/
keywords:
- 程式碼範例
- 章節
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中管理投影片章節：使用 JavaScript 範例建立、重新命名、重新排序和分組 PPT、PPTX 與 ODP 投影片。"
---
示範如何以程式方式使用 **Aspose.Slides for Node.js via Java** 來管理簡報的章節—新增、存取、移除和重新命名。

## **新增章節**

在特定投影片上建立一個章節。

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 指定標記章節開始的投影片。
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取章節**

從簡報中讀取章節資訊。

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 依索引存取章節。
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **移除章節**

刪除先前新增的章節。

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 移除第一個章節。
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **重新命名章節**

變更現有章節的名稱。

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