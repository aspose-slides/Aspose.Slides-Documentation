---
title: 區段
type: docs
weight: 90
url: /zh-hant/java/examples/elements/section/
keywords:
- 程式碼範例
- 區段
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理投影片區段：建立、重新命名、重新排序，以及以 Java 範例對 PPT、PPTX 和 ODP 進行投影片分組。"
---
示例說明如何以程式方式使用 **Aspose.Slides for Java** 來管理簡報區段──新增、存取、移除和重新命名。

## **新增區段**

建立從特定投影片開始的區段。

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 指定標記區段開始的投影片。
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **存取區段**

從簡報中讀取區段資訊。

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // 依索引存取區段。
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **移除區段**

刪除先前新增的區段。

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // 移除第一個區段。
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **重新命名區段**

變更現有區段的名稱。

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