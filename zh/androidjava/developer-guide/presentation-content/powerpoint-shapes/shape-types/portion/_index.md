---
title: 部分
type: docs
weight: 70
url: /androidjava/portion/
---

## **获取部分的位置坐标**
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) 方法已添加到 [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) 和 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 类中，允许检索部分开始的坐标。

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