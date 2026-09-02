---
title: 使用 JavaScript 优化演示文稿中的图像管理
linktitle: 管理图片
type: docs
weight: 10
url: /zh/nodejs-java/image/
keywords:
- 添加图片
- 添加图片
- 添加位图
- 替换图片
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 外部 SVG 资源
- SVG 解析器
- 链接的 SVG 图像
- SVG 字体
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并实现工作流自动化。"
---
## **简介**

图片使演示更具吸引力和视觉效果。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源将图片插入到幻灯片中。同样，Aspose.Slides 也提供多种方式将图片添加到演示幻灯片中。

{{% alert title="提示" color="primary" %}} 
Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可以快速地从图片创建演示文稿。 
{{% /alert %}} 

{{% alert title="信息" color="info" %}}
如果您想将图片作为图片框插入——尤其是计划对其进行调整大小、应用效果或使用其他标准格式选项——请参阅 [图片框](/slides/zh/nodejs-java/picture-frame/)。 
{{% /alert %}} 

{{% alert title="注意" color="warning" %}}
您可以将图片从一种格式转换为另一种格式。请参阅以下页面：转换 [image to JPG](https://products.aspose.com/slides/zh/nodejs-java/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/zh/nodejs-java/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/zh/nodejs-java/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/zh/nodejs-java/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/zh/nodejs-java/conversion/png-to-svg/)，以及 [SVG to PNG](https://products.aspose.com/slides/zh/nodejs-java/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides 支持常见的图片格式，例如 JPEG、PNG、BMP、GIF 等。

## **将本地存储的图片添加到幻灯片**

您可以将计算机上存储的一张或多张图片添加到演示幻灯片中。以下 JavaScript 示例代码演示了如何向幻灯片添加图片：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **将网络图片添加到幻灯片**

如果要添加的图片未保存在本地，可以直接从网络添加。

以下 JavaScript 示例代码演示了如何从网络向幻灯片添加图片：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **将图片添加到母版幻灯片**

母版幻灯片存储并控制使用该母版的幻灯片的主题和布局信息。向母版幻灯片添加图片后，基于该母版的每张幻灯片都会显示该图片。

以下 JavaScript 示例代码演示了如何向母版幻灯片添加图片：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **将图片设为幻灯片背景**

您可以使用图片作为一张或多张幻灯片的背景。详情请参阅 *[将图片设置为幻灯片背景](/slides/zh/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/) 类将 SVG 内容添加到演示文稿中。生成的 SVG 图片对象随后可以添加到演示文稿的图片集合，并用于创建图片框。

以下 JavaScript 示例导入了一个自包含的 SVG 字符串。该 SVG 中使用的所有图片、样式和其他资源均直接嵌入在 SVG 内容中。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **导入包含外部资源的 SVG 内容**

从设计工具、图表编辑器、图标系统和网页管线导出的 SVG 文件可能会引用存储在 SVG 文档之外的资源。例如，SVG 可以包含 `images/photo.png` 之类的图片链接、CSS `url(...)` 值或字体 URL。

要导入此类 SVG 内容，需要提供一个外部资源解析器，并将其与基 URI 一起传递给相应的 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/) 构造函数。基 URI 标识 SVG 文档的位置，用于解析相对链接。

`SvgImage` 类提供了访问已导入 SVG 信息的方法：

- `getSvgContent()` 返回 SVG 标记的字符串形式。
- `getSvgData()` 返回 SVG 内容的字节数组。
- `getBaseUri()` 返回用于相对链接的基 URI。
- `getExternalResourceResolver()` 返回分配给 SVG 图片的解析器。

### **实现外部资源解析器**

解析器包含两个方法：

- `resolveUri` 将基 URI 与相对资源链接组合，返回绝对 URI。当链接无法解析或不被允许时返回 `null`。
- `getEntity` 为绝对资源 URI 返回可读取的 Java 流。当资源缺失、被阻止或不可用时返回 `null`。必要时也可以返回回退流。

以下辅助代码创建了一个解析器，仅从允许的本地目录加载链接资源。网络资源以及超出允许目录的路径均被阻止。对于未解析的图片链接，可返回可选的回退图片。

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // 此解析器专门只允许本地文件。
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // 仅在图像资源时使用回退。对缺失的字体或样式表返回图像流将无效。
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **在 SVG 导入期间解析链接资源**

假设 `assets/diagram.svg` 包含如下相对引用：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 JavaScript 示例将 SVG 文件的 URI 作为基 URI，并提供自定义解析器。解析器将相对图片链接转换为绝对 URI，并返回包含链接资源的流，供 Aspose.Slides 处理 SVG 时使用。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// 基 URI 表示 SVG 文档的位置。
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage 提供源内容、二进制数据、基 URI 和解析器。
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` 类还提供了接受字节数组形式 SVG 数据的重载，以及带外部资源解析器和基 URI 的基于流的工厂方法。

{{% alert title="重要" color="warning" %}}
资源解析器在 Aspose.Slides 处理并渲染 SVG 时，使外部资源可用。它不会修改原始 SVG 标记，也不会自动将解析后的资源嵌入其中。

当 SVG 图片被添加到演示文稿的图片集合中时，PPTX 文件可能同时包含原始 SVG 表示和光栅回退图片。生成的回退图片中可能出现链接资源，而存储的 SVG 中相对链接（如 `images/photo.png`）保持不变。渲染原生 SVG 表示的应用程序因此在原始外部资源不可用时可能会省略该链接内容。
{{% /alert %}}

### **创建可移植的 SVG 图片**

要创建不依赖外部文件的 SVG 图片，请在创建 `SvgImage` 之前使 SVG 自包含。例如，用包含图片数据的 `data:` URI 替换链接的图片 URL：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必需资源嵌入到 SVG 内容后，创建 `SvgImage`，将其添加到演示文稿的图片集合，并按前例插入到图片框中。

### **处理缺失或受阻的资源**

当资源 URI 无效、被禁止或无法解析时，`resolveUri` 返回 `null`。当资源无法读取时，`getEntity` 返回 `null`。Aspose.Slides 在可能的情况下继续处理 SVG 而不使用该资源。

可以为缺失的资源返回回退流，但其内容必须与请求的资源类型兼容。例如，仅为缺失的图片返回图片流，而不是为字体或样式表返回图片流。

{{% alert title="安全" color="warning" %}}
不要从不可信的 SVG 文件解析任意文件路径或无限制的网络 URL。请限制允许的协议、目录和主机。对于网络资源，还应使用连接超时、响应大小限制以及内容验证。
{{% /alert %}}

## **将 SVG 转换为形状集合**

Aspose.Slides 可以将 SVG 转换为形状集合，其功能类似于 PowerPoint 中的对应功能：

![PowerPoint弹出菜单](img_01_01.png)

该功能由 [ShapeCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ShapeCollection) 类的 [addGroupShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) 方法的重载提供，该重载接受 SVG 图片对象作为第一个参数。

以下 JavaScript 示例代码演示了如何使用此方法将 SVG 文件转换为形状集合：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// 源 SVG 文件名。
const svgFileName = "sample.svg";

// 输出演示文稿文件名。
const outPptxPath = "presentation.pptx";

// 创建新演示文稿。
const presentation = new aspose.slides.Presentation();
try {
    // 读取 SVG 文件内容。
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // 创建 SvgImage 对象。
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // 获取幻灯片尺寸。
    const slideSize = presentation.getSlideSize().getSize();

    // 将 SVG 图像转换为形状组并按幻灯片尺寸进行缩放。
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // 以 PPTX 格式保存演示文稿。
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **将图片以 EMF 形式添加到幻灯片**

Aspose.Slides for Node.js via Java 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图片并将其添加到演示幻灯片中。

以下 JavaScript 示例代码展示了具体做法：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// 将工作簿保存到流中。
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // 将文件原样添加，以便图片保持为矢量 EMF 而不是被光栅化。
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **替换图片集合中的图片**

Aspose.Slides 允许您替换演示文稿图片集合中存储的图片，包括由幻灯片形状使用的图片。本节介绍了多种更新集合中图片的方法。您可以使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 实例，或集合中已有的另一张图片来替换目标图片。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载包含图片的演示文件。  
1. 将新图片从文件加载为字节数组。  
1. 使用字节数组将目标图片替换为新图片。  
1. 在第二种方法中，将图片加载为 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 对象，并使用该对象替换目标图片。  
1. 在第三种方法中，使用演示文稿图片集合中已存在的图片替换目标图片。  
1. 将修改后的演示文稿写入为 PPTX 文件。  

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// 实例化表示演示文稿文件的 Presentation 类。
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 第一种方法。
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 第二种方法。
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // 第三种方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // 将演示文稿保存到文件。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="信息" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文字添加动画并生成 GIF。
{{% /alert %}}

## **常见问题**

**插入后原始图片分辨率是否保持不变？**

是的。源像素得以保留，但最终显示效果取决于在幻灯片上对 [picture](/slides/zh/nodejs-java/picture-frame/) 的缩放方式以及保存时是否应用了压缩。

**一次性在数十张幻灯片上替换同一徽标的最佳方法是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图片集合中替换它——所有使用该资源的元素都会同步更新。

**插入的 SVG 能否转换为可编辑形状？**

可以。您可以将 SVG 转换为一组形状，随后各部分即可使用标准形状属性进行编辑。

**如何一次性为多张幻灯片设置相同的背景图片？**

在母版幻灯片或相应布局上 [将图片设为背景](/slides/zh/nodejs-java/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿体积过大？**

重复使用同一图片资源，避免重复复制；选择适当的分辨率，保存时进行压缩，并在合适的情况下将重复图形放在母版上。