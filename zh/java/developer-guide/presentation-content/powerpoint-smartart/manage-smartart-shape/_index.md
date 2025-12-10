---
title: 使用 Java 管理演示文稿中的 SmartArt 图形
linktitle: SmartArt 图形
type: docs
weight: 20
url: /zh/java/manage-smartart-shape/
keywords:
- SmartArt 对象
- SmartArt 图形
- SmartArt 样式
- SmartArt 颜色
- 创建 SmartArt
- 添加 SmartArt
- 编辑 SmartArt
- 更改 SmartArt
- 访问 SmartArt
- SmartArt 布局类型
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中实现 PowerPoint SmartArt 的创建、编辑和样式设置，提供简明代码示例和注重性能的指导。"
---

## **创建 SmartArt 形状**
Aspose.Slides for Java 提供了用于创建 SmartArt 形状的 API。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 通过设置它的 [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType) 来 [Add a SmartArt shape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
1. 将修改后的演示文稿保存为 PPTX 文件。
```java
// 实例化 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加 Smart Art 形状
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // 保存演示文稿
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已添加到幻灯片的 SmartArt 形状**|

## **访问幻灯片上的 SmartArt 形状**
以下代码用于访问已添加到演示文稿幻灯片中的 SmartArt 形状。在示例代码中，我们将遍历幻灯片中的每个形状并检查它是否是 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 形状。如果形状的类型是 SmartArt，则我们会将其强制转换为 [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 实例。
```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **使用特定布局类型访问 SmartArt 形状**
以下示例代码可帮助访问具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 形状。请注意，SmartArt 的 LayoutType 是只读的，且只能在添加 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 形状时设置，之后无法更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 类型，如果是 SmartArt，则将选定的形状强制转换为 SmartArt。
1. 检查具有特定 LayoutType 的 SmartArt 形状，并在之后执行所需的操作。
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // 检查 SmartArt 布局
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **更改 SmartArt 形状样式**
在本例中，我们将学习如何更改任意 SmartArt 形状的快速样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 类型，如果是 SmartArt，则将选定的形状强制转换为 SmartArt。
1. 查找具有特定 Style 的 SmartArt 形状。
1. 为该 SmartArt 形状设置新的 Style。
1. 保存演示文稿。
```java
// 实例化 Presentation 类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 检查 SmartArt 样式
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // 更改 SmartArt 样式
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 保存演示文稿
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已更改 Style 的 SmartArt 形状**|

## **更改 SmartArt 形状颜色样式**
在本例中，我们将学习如何更改任意 SmartArt 形状的颜色样式。在下面的示例代码中，将访问具有特定颜色样式的 SmartArt 形状并更改其样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 使用索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的所有形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 类型，如果是 SmartArt，则将选定的形状强制转换为 SmartArt。
1. 查找具有特定颜色样式的 SmartArt 形状。
1. 为该 SmartArt 形状设置新的颜色样式。
1. 保存演示文稿。
```java
// 实例化 Presentation 类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 检查 SmartArt 颜色类型
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // 更改 SmartArt 颜色类型
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 保存演示文稿
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**图：已更改颜色样式的 SmartArt 形状**|

## **FAQ**

**我可以将 SmartArt 作为单个对象进行动画处理吗？**

可以。SmartArt 本身是一个形状，因此您可以像对其他形状一样通过动画 API 应用 [standard animations](/slides/zh/java/powerpoint-animation/)（进入、退出、强调、运动路径）等标准动画。

**如果我不知道内部 ID，如何在幻灯片上找到特定的 SmartArt？**

设置并使用替代文本（AltText），并通过该值搜索形状——这是定位目标形状的推荐方法。

**我可以将 SmartArt 与其他形状分组吗？**

可以。您可以将 SmartArt 与其他形状（图片、表格等）分组，然后 [manipulate the group](/slides/zh/java/group/)。

**如何获取特定 SmartArt 的图像（例如用于预览或报告）？**

导出该形状的缩略图/图像；库能够将单个形状 [render individual shapes](/slides/zh/java/create-shape-thumbnails/) 为光栅文件（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

会。渲染引擎在 [PDF export](/slides/zh/java/convert-powerpoint-to-pdf/) 时追求高保真度，并提供多种质量和兼容性选项。