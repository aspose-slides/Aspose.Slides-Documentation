---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/androidjava/examples/elements/text-box/
keywords:
- 程式碼範例
- 文字方塊
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中使用文字方塊：使用 Java 為 PPT、PPTX 與 ODP 簡報新增、格式化、對齊、換行、自動調整大小及樣式文字。"
---
在 Aspose.Slides 中，**文字方塊** 以 `AutoShape` 來表示。幾乎所有形狀都可以包含文字，但一般的文字方塊沒有填充或邊框，僅顯示文字。

本指南說明如何以程式方式新增、存取和移除文字方塊。

## **新增文字方塊**

文字方塊只是沒有限填或邊框且帶有格式化文字的 `AutoShape`。以下說明如何建立它：

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 建立一個矩形形狀（預設為填充且有邊框，且無文字）。
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // 移除填充與邊框，使其看起來像一般的文字方塊。
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // 設定文字格式。
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // 指定實際的文字內容。
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 任何包含非空 `TextFrame` 的 `AutoShape` 都能充當文字方塊。

## **依內容存取文字方塊**

若要找出所有包含特定關鍵字（例如「Slide」）的文字方塊，請遍歷形狀並檢查其文字：

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // 只有 AutoShape 能包含可編輯的文字。
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // 對符合的文字方塊執行某些操作。
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **依內容移除文字方塊**

此範例會在第一張投影片中找出並刪除所有包含特定關鍵字的文字方塊：

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **提示:** 在迭代期間修改形狀集合時，請務必先建立該集合的副本，以避免集合修改錯誤。