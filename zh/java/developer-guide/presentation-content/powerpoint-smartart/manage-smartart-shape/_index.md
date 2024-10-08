---
title: 管理SmartArt形状
type: docs
weight: 20
url: /java/manage-smartart-shape/
---

## **创建SmartArt形状**
Aspose.Slides for Java提供了一个API来创建SmartArt形状。要在幻灯片中创建SmartArt形状，请遵循以下步骤：

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. [添加一个SmartArt形状](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)并设置[LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType)。
1. 将修改后的演示文稿保存为PPTX文件。

```java
// 实例化Presentation类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加SmartArt形状
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // 保存演示文稿
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：添加到幻灯片的SmartArt形状**|

## **访问幻灯片中的SmartArt形状**
以下代码将用于访问添加到演示文稿幻灯片中的SmartArt形状。在示例代码中，我们将遍历幻灯片中的每个形状，并检查它是否是[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)形状。如果形状是SmartArt类型，则我们将其强制转换为[**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)实例。

```java
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 检查形状是否是SmartArt类型
        if (shape instanceof ISmartArt)
        {
            // 将形状强制转换为SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("形状名称:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问具有特定布局类型的SmartArt形状**
以下示例代码将帮助访问具有特定LayoutType的[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)形状。请注意，您不能更改SmartArt的LayoutType，因为它是只读的，并且只在[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)形状被添加时设置。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例并加载具有SmartArt形状的演示文稿。
1. 通过使用其索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否是[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)类型，并如果是SmartArt则将所选形状强制转换为SmartArt。
1. 检查具有特定LayoutType的SmartArt形状并执行后续所需操作。

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 检查形状是否是SmartArt类型
        if (shape instanceof ISmartArt)
        {
            // 将形状强制转换为SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // 检查SmartArt布局
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("在这里做一些事情....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改SmartArt形状样式**
在这个例子中，我们将学习如何更改任何SmartArt形状的快速样式。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例并加载具有SmartArt形状的演示文稿。
1. 通过使用其索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否是[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)类型，并如果是SmartArt则将所选形状强制转换为SmartArt。
1. 找到具有特定样式的SmartArt形状。
1. 为SmartArt形状设置新的样式。
1. 保存演示文稿。

```java
// 实例化Presentation类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否是SmartArt类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 检查SmartArt样式
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // 更改SmartArt样式
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
|**图：样式已更改的SmartArt形状**|

## **更改SmartArt形状颜色样式**
在这个例子中，我们将学习如何更改任何SmartArt形状的颜色样式。在以下示例代码中，将访问具有特定颜色样式的SmartArt形状并更改其样式。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例并加载具有SmartArt形状的演示文稿。
1. 通过使用其索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片中的每个形状。
1. 检查形状是否是[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt)类型，并如果是SmartArt则将所选形状强制转换为SmartArt。
1. 找到具有特定颜色样式的SmartArt形状。
1. 为SmartArt形状设置新的颜色样式。
1. 保存演示文稿。

```java
// 实例化Presentation类
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 遍历第一张幻灯片中的每个形状
    for (IShape shape : slide.getShapes()) 
    {
        // 检查形状是否是SmartArt类型
        if (shape instanceof ISmartArt) 
        {
            // 将形状强制转换为SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // 检查SmartArt颜色类型
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // 更改SmartArt颜色类型
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
|**图：颜色样式已更改的SmartArt形状**|