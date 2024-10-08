---
title: 管理 SmartArt 形状
type: docs
weight: 20
url: /androidjava/manage-smartart-shape/
---

## **创建 SmartArt 形状**
Aspose.Slides for Android via Java 提供了一个 API 用于创建 SmartArt 形状。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 通过设置 [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType) 来 [添加 SmartArt 形状](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
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
|**图：添加到幻灯片的 SmartArt 形状**|

## **访问幻灯片中的 SmartArt 形状**
以下代码将用于访问添加到演示文稿幻灯片中的 SmartArt 形状。在示例代码中，我们将遍历幻灯片内部的每个形状，并检查它是否是 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 形状。如果形状是 SmartArt 类型，则将其强制转换为 [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 实例。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片内部的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 检查形状是否为 SmartArt 类型
        if (shape instanceof ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("形状名称：" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用特定布局类型访问 SmartArt 形状**
以下示例代码将帮助访问具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 形状。请注意，您无法更改 SmartArt 的 LayoutType，因为它是只读的，只有在添加 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 形状时才会设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例并加载与 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片内部的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 类型，如果是，则将所选形状强制转换为 SmartArt。
1. 检查具有特定 LayoutType 的 SmartArt 形状，并执行后续所需的操作。

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片内部的每个形状
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
                System.out.println("在这里执行一些操作....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改 SmartArt 形状样式**
在此示例中，我们将学习如何更改任何 SmartArt 形状的快速样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例并加载与 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片内部的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 类型，如果是，则将所选形状强制转换为 SmartArt。
1. 找到具有特定样式的 SmartArt 形状。
1. 为 SmartArt 形状设置新的样式。
1. 保存演示文稿。

```java
// 实例化 Presentation 类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片内部的每个形状
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
|**图：已更改样式的 SmartArt 形状**|

## **更改 SmartArt 形状颜色样式**
在此示例中，我们将学习如何更改任何 SmartArt 形状的颜色样式。在以下示例代码中，将访问具有特定颜色样式的 SmartArt 形状并更改其样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例并加载与 SmartArt 形状的演示文稿。
1. 通过使用其索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片内部的每个形状。
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) 类型，如果是，则将所选形状强制转换为 SmartArt。
1. 找到具有特定颜色样式的 SmartArt 形状。
1. 为 SmartArt 形状设置新的颜色样式。
1. 保存演示文稿。

```java
// 实例化 Presentation 类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片内部的每个形状
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