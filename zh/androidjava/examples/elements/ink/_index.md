---
title: 墨迹
type: docs
weight: 180
url: /zh/androidjava/examples/elements/ink/
keywords:
- 代码示例
- 墨迹
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中使用 Ink：绘制、导入和编辑笔画，调整颜色和宽度，并使用 Java 示例导出为 PPT、PPTX 和 ODP。"
---
本文提供了使用 **Aspose.Slides for Android via Java** 访问现有 Ink 形状并将其删除的示例。

> ❗ **注意：** Ink 形状表示来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的 Ink 笔画，但您可以读取和修改现有 Ink。

## **访问 Ink**

读取幻灯片上第一个 Ink 形状的标签。

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
                // 根据需要使用 tagName。
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **删除 Ink**

如果存在 Ink 形状，则将其从幻灯片中删除。

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