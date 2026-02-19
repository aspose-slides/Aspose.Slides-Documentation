---
title: 章节
type: docs
weight: 90
url: /zh/nodejs-java/examples/elements/section/
keywords:
- 代码示例
- 章节
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中管理幻灯片章节：创建、重命名、重新排序和分组幻灯片，并提供 PPT、PPTX 和 ODP 的 JavaScript 示例。"
---
使用 **Aspose.Slides for Node.js via Java** 以编程方式管理演示文稿章节——添加、访问、删除和重命名的示例。

## **添加章节**

创建一个从特定幻灯片开始的章节。

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 指定标记章节开始的幻灯片。
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **访问章节**

从演示文稿读取章节信息。

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 通过索引访问章节。
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **删除章节**

删除先前添加的章节。

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 删除第一个章节。
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **重命名章节**

更改现有章节的名称。

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