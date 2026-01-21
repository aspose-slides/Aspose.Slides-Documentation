---
title: 使用 Java 在演示文稿中管理文本片段
linktitle: 文本片段
type: docs
weight: 70
url: /zh/java/portion/
keywords:
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中管理文本片段，提升性能和自定义能力。"
---

## **获取文本片段的坐标**
[**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) 方法已添加到 [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) 和 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 类，可检索片段起始位置的坐标。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 重塑演示文稿的上下文
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

**我可以在单个段落中仅对文本的部分应用超链接吗？**

是的，您可以 [分配超链接](/slides/zh/java/manage-hyperlinks/) 到单个片段；只有该片段是可点击的，而不是整段。

**样式继承如何工作：Portion 覆盖哪些属性，哪些属性来自 Paragraph 或 TextFrame？**

Portion 级别的属性具有最高优先级。如果属性未在 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 上设置，渲染引擎将从 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 获取；如果在那里也未设置，则从 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/java/com.aspose.slides/theme/) 样式获取。

**如果为 Portion 指定的字体在目标机器/服务器上缺失，会发生什么？**

[字体替代规则](/slides/zh/java/font-selection-sequence/) 生效。文本可能会重新排版：度量、连字符和宽度可能会变化，这会影响精确定位。

**我可以为单独的 Portion 设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

是的，在 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 级别可以设置文本颜色、填充和透明度，使其与相邻片段不同。