---
title: Java 中的组演示形状
linktitle: 形状组
type: docs
weight: 40
url: /zh/java/group/
keywords:
- 组形状
- 形状组
- 添加组
- 替代文本
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "学习使用 Aspose.Slides for Java 对 PowerPoint 幻灯片进行形状分组和取消分组——快速、一步步的指南，附带免费 Java 代码。"
---

## **Add a Group Shape**
Aspose.Slides 支持在幻灯片上使用组形状。此功能帮助开发人员创建更丰富的演示文稿。Aspose.Slides for Java 支持添加或访问组形状。您可以向已添加的组形状中添加形状以填充它，或访问组形状的任何属性。使用 Aspose.Slides for Java 向幻灯片添加组形状的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 向幻灯片添加组形状。
1. 向已添加的组形状中添加形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加组形状。
```java
// 实例化 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 访问幻灯片的形状集合
    IShapeCollection slideShapes = sld.getShapes();

    // 向幻灯片添加组形状
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 在已添加的组形状内部添加形状
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 添加组形状框架
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // 将 PPTX 文件写入磁盘
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Access the AltText Property**
本主题展示了添加组形状并访问幻灯片上组形状的 AltText 属性的简要步骤和代码示例。使用 Aspose.Slides for Java 在幻灯片中访问组形状的 AltText 的步骤如下：

1. 实例化表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类。
1. 使用索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 访问 [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) 属性。

下面的示例访问组形状的替代文本。
```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation("AltText.pptx");
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // 访问幻灯片的形状集合
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // 访问组形状。
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // 访问 AltText 属性
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Is nested grouping (a group inside a group) supported?**

是。[GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) 提供 [getParentGroup](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getParentGroup--) 方法，直接表明支持层级结构（组可以是另一个组的子组）。

**How do I control the group’s z-order relative to other objects on the slide?**

使用 [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) 方法检查其在显示堆栈中的位置。

**Can I prevent moving/editing/ungrouping?**

是。组的锁定部分通过 [GroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/#getGroupShapeLock--) 暴露，可用于限制对该对象的操作。