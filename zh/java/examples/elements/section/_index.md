---
title: 章节
type: docs
weight: 90
url: /zh/java/examples/elements/section/
keywords:
- 代码示例
- 章节
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理幻灯片章节：创建、重命名、重新排序和分组幻灯片，提供 PPT、PPTX 和 ODP 的 Java 示例。"
---
使用 **Aspose.Slides for Java** 以编程方式管理演示文稿章节的示例——添加、访问、删除和重命名它们。

## **添加章节**

创建一个从特定幻灯片开始的章节。

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 指定标记章节开头的幻灯片。
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **访问章节**

从演示文稿中读取章节信息。

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // 通过索引访问章节。
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **删除章节**

删除先前添加的章节。

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // 删除第一个章节。
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **重命名章节**

更改现有章节的名称。

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```