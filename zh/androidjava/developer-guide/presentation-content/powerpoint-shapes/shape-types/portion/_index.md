---
title: 在 Android 上管理演示文稿中的文本片段
linktitle: 文本片段
type: docs
weight: 70
url: /zh/androidjava/portion/
keywords:
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android（通过 Java）在 PowerPoint 演示文稿中管理文本片段，以提升性能和自定义能力。"
---

## **获取文本片段的坐标**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) 方法已添加到 [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) 和 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) 类中，允许检索片段起始位置的坐标。
```java
// 实例化表示 PPTX 的 Prseetation 类
Presentation pres = new Presentation();
try {
    // 重新塑造演示文稿的上下文
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我可以只对单个段落中的部分文本应用超链接吗？**

是的，您可以 [分配超链接](/slides/zh/androidjava/manage-hyperlinks/) 给单独的片段；只有该片段可点击，而不是整段文字。

**样式继承是如何工作的：Portion 覆盖了什么，什么又来自 Paragraph/TextFrame？**

Portion 级别的属性优先级最高。如果在 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) 上未设置属性，引擎会从 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 获取；如果那里也未设置，则从 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/) 样式中获取。

**如果在目标机器/服务器上缺少为 Portion 指定的字体会怎样？**

会应用 [字体替换规则](/slides/zh/androidjava/font-selection-sequence/)。文本可能会重新排版：度量、连字和宽度都会变化，这对精确定位至关重要。

**我可以为特定 Portion 设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

可以，位于 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) 级别的文本颜色、填充和透明度可以与相邻片段不同。