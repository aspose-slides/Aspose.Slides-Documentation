---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/java/examples/elements/text-box/
keywords:
- 程式碼範例
- 文字方塊
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中處理文字方塊：使用 Java 為 PPT、PPTX 和 ODP 簡報新增、格式化、對齊、換行、自動調整大小並設定文字樣式。"
---
在 Aspose.Slides 中，**文字方塊** 由 `AutoShape` 表示。幾乎任何形狀都可以包含文字，但典型的文字方塊沒有填充或邊框，只顯示文字。

本指南說明如何以程式方式新增、存取和移除文字方塊。

## **新增文字方塊**

文字方塊僅是沒有填充或邊框且帶有格式化文字的 `AutoShape`。以下是建立方式：

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 建立一個矩形形狀（預設為有填充、邊框且無文字）。
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // 移除填充和邊框，使其看起來像典型的文字方塊。
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // 設定文字格式。
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // 指派實際的文字內容。
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 任何包含非空 `TextFrame` 的 `AutoShape` 都可作為文字方塊使用。

## **依內容存取文字方塊**

若要找出所有包含特定關鍵字（例如「Slide」）的文字方塊，請遍歷形狀並檢查其文字：

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // 僅 AutoShape 可以包含可編輯的文字。
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // 對符合條件的文字方塊執行某些操作。
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **依內容移除文字方塊**

此範例會找出並刪除第一張投影片中所有包含特定關鍵字的文字方塊：

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

> 💡 **提示:** 在迭代過程中修改形狀集合前，請先建立其副本，以避免集合修改錯誤。