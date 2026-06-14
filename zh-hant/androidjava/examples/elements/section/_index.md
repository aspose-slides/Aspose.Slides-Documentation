---
title: 節
type: docs
weight: 90
url: /zh-hant/androidjava/examples/elements/section/
keywords:
- 程式碼範例
- 節
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中管理投影片節：使用 Java 範例建立、重新命名、重新排序與分組投影片，支援 PPT、PPTX 與 ODP。"
---
示範如何以程式方式使用 **Aspose.Slides for Android via Java** 來管理簡報的節——新增、存取、移除與重新命名。

## **新增節**

建立一個從特定投影片開始的節。

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 指定標示此節開始的投影片。
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **存取節**

從簡報中讀取節的資訊。

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // 使用索引存取節。
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **移除節**

刪除先前新增的節。

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // 移除第一個節。
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **重新命名節**

變更現有節的名稱。

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