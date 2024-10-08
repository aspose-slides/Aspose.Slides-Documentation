---
title: 使用 Java 创建 PowerPoint 演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /java/create-presentation/
keywords: 创建 ppt java, 创建 ppt 演示文稿, 创建 pptx java
description: 学习如何使用 Java 从头创建 PowerPoint 演示文稿，例如 PPT、PPTX。
---

## **创建 PowerPoint 演示文稿**
要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤操作：

1. 创建 Presentation 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 使用 Shapes 对象公开的 addAutoShape 方法添加一条类型为线的自动形状。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们向演示文稿的第一张幻灯片添加了一条直线。

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个类型为线的自动形状
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```