---
title: 使用 Java 创建 PowerPoint 演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/androidjava/create-presentation/
keywords: 创建 ppt java, 创建 ppt 演示文稿, 创建 pptx java
description: 学习如何使用 Java 从头开始创建 PowerPoint 演示文稿，例如 PPT、PPTX。
---

## **创建 PowerPoint 演示文稿**
要在演示文稿的选定幻灯片上添加简单的纯线条，请按照以下步骤操作：

1. 创建 Presentation 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 Shapes 对象暴露的 addAutoShape 方法添加一种类型为线的 AutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们在演示文稿的第一张幻灯片上添加了一条线。

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一种类型为线的自动形状
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```