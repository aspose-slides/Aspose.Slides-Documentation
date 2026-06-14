---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/java/examples/elements/ink/
keywords:
- 程式碼範例
- 墨跡
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中處理墨跡：繪製、匯入與編輯筆劃，調整顏色與寬度，並使用 Java 範例將其匯出為 PPT、PPTX 與 ODP。"
---
本篇文章提供使用 **Aspose.Slides for Java** 存取現有墨跡形狀並將其移除的範例。

> ❗ **注意:** 墨跡形狀代表來自專用裝置的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆劃，但您可以讀取並修改現有的墨跡。

## **存取墨跡**

從投影片上的第一個墨跡形狀讀取標記。

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // 按需要使用 tagName。
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除墨跡**

如果投影片中存在墨跡形狀，將其刪除。

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```