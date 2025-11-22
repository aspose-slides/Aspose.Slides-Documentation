---
title: 管理 SmartArt 形状
type: docs
weight: 20
url: /zh/nodejs-java/manage-smartart-shape/
---

## **创建 SmartArt 形状**
Aspose.Slides for Node.js via Java 已提供用于创建 SmartArt 形状的 API。要在幻灯片中创建 SmartArt 形状，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 通过使用索引获取幻灯片的引用。  
1. [添加 SmartArt 形状](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)，并设置其 [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType)。  
1. 将修改后的演示文稿保存为 PPTX 文件。  
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加 Smart Art 形状
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // 保存演示文稿
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已添加到幻灯片的 SmartArt 形状**|

## **访问 幻灯片 中的 SmartArt 形状**
以下代码用于访问已在演示文稿幻灯片中添加的 SmartArt 形状。在示例代码中，我们将遍历幻灯片中的每个形状，并检查它是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 形状。如果形状是 SmartArt 类型，则将其强制转换为 [**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 实例。  
```javascript
// 加载所需的演示文稿
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **使用特定布局类型访问 SmartArt 形状**
以下示例代码可帮助访问具有特定 LayoutType 的 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 形状。请注意，SmartArt 的 LayoutType 为只读，且仅在添加 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 形状时设置，无法更改。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
1. 通过使用索引获取第一张幻灯片的引用。  
1. 遍历第一张幻灯片中的每个形状。  
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 SmartArt。  
1. 检查具有特定 LayoutType 的 SmartArt 形状，并在之后执行所需的操作。  
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArtEx
            var smart = shape;
            // 检查 SmartArt 布局
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改 SmartArt 形状样式**
在本例中，我们将学习如何更改任意 SmartArt 形状的快速样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
1. 通过使用索引获取第一张幻灯片的引用。  
1. 遍历第一张幻灯片中的每个形状。  
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 SmartArt。  
1. 查找具有特定 Style 的 SmartArt 形状。  
1. 为 SmartArt 形状设置新 Style。  
1. 保存演示文稿。  
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArtEx
            var smart = shape;
            // 检查 SmartArt 样式
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // 更改 SmartArt 样式
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 保存演示文稿
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已更改 Style 的 SmartArt 形状**|

## **更改 SmartArt 形状颜色样式**
在本例中，我们将学习如何更改任意 SmartArt 形状的颜色样式。以下示例代码将访问具有特定颜色样式的 SmartArt 形状并更改其样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。  
1. 通过使用索引获取第一张幻灯片的引用。  
1. 遍历第一张幻灯片中的每个形状。  
1. 检查形状是否为 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) 类型，如果是，则将选定的形状强制转换为 SmartArt。  
1. 查找具有特定 Color Style 的 SmartArt 形状。  
1. 为 SmartArt 形状设置新的 Color Style。  
1. 保存演示文稿。  
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 遍历第一张幻灯片中的每个形状
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 检查形状是否为 SmartArt 类型
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 将形状强制转换为 SmartArtEx
            var smart = shape;
            // 检查 SmartArt 颜色类型
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // 更改 SmartArt 颜色类型
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 保存演示文稿
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**图：已更改 Color Style 的 SmartArt 形状**|

## **常见问题**

**我可以将 SmartArt 作为单个对象进行动画处理吗？**

是的。SmartArt 是一种形状，因此您可以通过动画 API（入口、退出、强调、运动路径）像其他形状一样应用 [standard animations](/slides/zh/nodejs-java/powerpoint-animation/)。

**如果我不知道内部 ID，如何在幻灯片中找到特定的 SmartArt？**

设置并使用替代文本（AltText），并通过该值搜索形状——这是定位目标形状的推荐方法。

**我可以将 SmartArt 与其他形状分组吗？**

是的。您可以将 SmartArt 与其他形状（图片、表格等）分组，然后 [manipulate the group](/slides/zh/nodejs-java/group/)。

**如何获取特定 SmartArt 的图像（例如用于预览或报告）？**

导出形状的缩略图/图像；该库可以将单个形状 [render individual shapes](/slides/zh/nodejs-java/create-shape-thumbnails/) 为光栅文件（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

是的。渲染引擎针对 [PDF export](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/) 实现高保真度，并提供多种质量和兼容性选项。