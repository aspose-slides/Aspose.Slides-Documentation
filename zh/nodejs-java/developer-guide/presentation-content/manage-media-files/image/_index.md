---
title: 使用 JavaScript 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/nodejs-java/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并自动化工作流。"
---

## **演示文稿中幻灯片的图像**

图像使演示文稿更加生动有趣。在 Microsoft PowerPoint 中，您可以从文件、网络或其他位置将图片插入到幻灯片上。类似地，Aspose.Slides 允许您通过不同的方式向演示文稿的幻灯片中添加图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——帮助用户快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}} 
如果您想将图像作为框架对象添加——尤其是计划对其使用标准格式化选项来调整大小、添加特效等——请参阅 [图片框架](https://docs.aspose.com/slides/nodejs-java/picture-frame/)。 
{{% /alert %}} 

Aspose.Slides 支持以下流行格式的图像操作：JPEG、PNG、GIF 等。

## **向幻灯片添加本地存储的图像**

您可以将计算机上的一个或多个图像添加到演示文稿的幻灯片中。下面的 JavaScript 示例代码演示如何向幻灯片添加图像：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **从流向幻灯片添加图像**

如果要添加到幻灯片的图像在计算机上不可用，您可以直接从网络添加该图像。

下面的示例代码展示了如何在 JavaScript 中从网络向幻灯片添加图像：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 将 Excel 文件加载到流
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // 创建用于嵌入的数据对象
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // 添加 Ole 对象框架形状
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // 将 PPTX 文件写入磁盘
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **向幻灯片母版添加图像**

幻灯片母版是存储并控制其下所有幻灯片信息（主题、布局等）的顶层幻灯片。因此，当您向幻灯片母版添加图像时，该图像会出现在该母版下的每一张幻灯片上。

下面的 JavaScript 示例代码展示了如何向幻灯片母版添加图像：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将图像设为幻灯片背景**

您可能决定将图片用作特定幻灯片或多张幻灯片的背景。在这种情况下，请参阅 *[将图像设为幻灯片背景](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿中添加 SVG**

您可以使用属于 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 类的 [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 方法向演示文稿中添加任意图像。

要基于 SVG 图像创建图像对象，可按以下方式进行：

1. 创建 SvgImage 对象以插入到 ImageShapeCollection
2. 从 ISvgImage 创建 PPImage 对象
3. 使用 PPImage 类创建 PictureFrame 对象

下面的示例代码展示了如何实现上述步骤，将 SVG 图像添加到演示文稿中：
```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 SVG 转换为形状集合**

Aspose.Slides 将 SVG 转换为形状集合的功能类似于 PowerPoint 用于处理 SVG 图像的功能：

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) 类的 [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) 方法的其中一个重载提供，该重载以 [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) 对象作为第一个参数。

下面的示例代码展示了如何使用上述方法将 SVG 文件转换为形状集合：
```javascript
// 创建新演示文稿
var presentation = new aspose.slides.Presentation();
try {
    // 读取 SVG 文件内容
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // 创建 SvgImage 对象
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // 获取幻灯片尺寸
    var slideSize = presentation.getSlideSize().getSize();
    // 将 SVG 图像转换为形状组并按幻灯片尺寸缩放
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // 以 PPTX 格式保存演示文稿
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **在幻灯片中将图像添加为 EMF**

Aspose.Slides for Node.js via Java 允许您从 Excel 工作表生成 EMF 图像，并使用 Aspose.Cells 将这些图像作为 EMF 添加到幻灯片中。

下面的示例代码展示了如何执行上述任务：
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **替换图像集合中的图像**

Aspose.Slides 让您可以替换演示文稿图像集合中存储的图像（包括幻灯片形状使用的图像）。本节展示了几种更新集合中图像的方法。API 提供了直接使用原始字节数据、[IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) 实例或集合中已存在的另一图像来替换图像的简便方法。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。  
2. 从文件将新图像加载为字节数组。  
3. 使用字节数组将目标图像替换为新图像。  
4. 在第二种方法中，将图像加载为 [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) 对象，并使用该对象替换目标图像。  
5. 在第三种方法中，用集合中已存在的图像替换目标图像。  
6. 将修改后的演示文稿写入为 PPTX 文件。  
```js
// 实例化表示演示文件的 Presentation 类。
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 第一种方法。
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 第二种方法。
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 第三种方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // 将演示文稿保存到文件。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}} 
使用 Aspose 免费的 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文本制作动画、从文本创建 GIF 等。 
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**  
是的。源像素被保留，但最终外观取决于幻灯片上 [图片](/slides/zh/nodejs-java/picture-frame/) 的缩放方式以及保存时是否进行压缩。

**一次性替换数十张幻灯片中的同一徽标的最佳方法是什么？**  
将徽标放在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——更新会自动传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**  
可以。您可以将 SVG 转换为一组形状，随后各个部分即可使用标准形状属性进行编辑。

**如何一次性为多张幻灯片设置图片背景？**  
在母版幻灯片或相关布局上 [将图像设为背景](/slides/zh/nodejs-java/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积“膨胀”？**  
复用单一图像资源而非复制，选择合适的分辨率，保存时进行压缩，并在必要时将重复的图形放在母版上。