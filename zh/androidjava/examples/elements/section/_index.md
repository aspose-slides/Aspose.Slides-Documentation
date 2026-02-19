---
title: 章节
type: docs
weight: 90
url: /zh/androidjava/examples/elements/section/
keywords:
- 代码示例
- 章节
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中管理幻灯片章节：使用 Java 示例创建、重命名、重新排序和分组幻灯片，适用于 PPT、PPTX 和 ODP。"
---
使用 **Aspose.Slides for Android via Java** 以编程方式管理演示文稿章节——添加、访问、删除和重命名的示例。

## **Add a Section**
创建从特定幻灯片开始的章节。

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 指定标记章节开始的幻灯片。
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Section**
读取演示文稿中的章节信息。

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

## **Remove a Section**
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

## **Rename a Section**
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