---
title: 组
type: docs
weight: 40
url: /java/group/
---

## **添加组形状**
Aspose.Slides 支持在幻灯片上使用组形状。此功能帮助开发人员支持更丰富的演示文稿。Aspose.Slides for Java 支持添加或访问组形状。可以向添加的组形状中添加形状以填充它，或访问组形状的任何属性。使用 Aspose.Slides for Java 向幻灯片添加组形状的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 向幻灯片添加组形状。
1. 向添加的组形状中添加形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加一个组形状。

```java
// 实例化 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 访问幻灯片的形状集合
    IShapeCollection slideShapes = sld.getShapes();

    // 向幻灯片添加一个组形状
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 在添加的组形状内添加形状
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

## **访问 AltText 属性**
本主题展示了简单的步骤，包含代码示例，用于添加组形状和访问幻灯片上组形状的 AltText 属性。使用 Aspose.Slides for Java 访问幻灯片中组形状的 AltText 的步骤如下：

1. 实例化表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类。
1. 通过使用其索引获取幻灯片的引用。
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