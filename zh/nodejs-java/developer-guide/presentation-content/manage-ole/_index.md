---
title: 使用 JavaScript 在演示文稿中管理 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/nodejs-java/manage-ole/
keywords:
- OLE 对象
- 对象链接与嵌入
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 添加文件
- 嵌入文件
- 链接对象
- 链接文件
- 更改 OLE
- OLE 图标
- OLE 标题
- 提取 OLE
- 提取对象
- 提取文件
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。无缝嵌入、更新并导出 OLE 内容。"
---

{{% alert color="primary" %}} 
OLE（Object Linking & Embedding）是 Microsoft 的一项技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。 
{{% /alert %}} 
考虑一个在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表即被视为 OLE 对象。 

- OLE 对象可能以图标形式出现。在此情况下，双击图标后，图表将在其关联的应用程序（Excel）中打开，或者会提示您选择用于打开或编辑对象的应用程序。 
- OLE 对象也可能直接显示其实际内容，例如图表的内容。在此情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) 允许您将 OLE 对象插入幻灯片作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)）。 

## **Adding OLE Object Frames to Slides** 
假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Node.js via Java 将其嵌入幻灯片作为 OLE 对象框，您可以按以下方式操作： 

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。 
1. 通过索引获取幻灯片的引用。 
1. 将 Excel 文件读取为字节数组。 
1. 将 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) 添加到幻灯片中，包含字节数组及其他 OLE 对象信息。 
1. 将修改后的演示文稿写入为 PPTX 文件。 

在下面的示例中，我们使用 Aspose.Slides for Node.js via Java 将 Excel 文件中的图表作为 OLE 对象框添加到幻灯片。 
**Note** 该 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) 构造函数将可嵌入对象的扩展名作为第二个参数。此扩展名使 PowerPoint 能够正确解释文件类型并选择合适的应用程序打开该 OLE 对象。 
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```
 

### **Adding Linked OLE Object Frames** 
Aspose.Slides for Node.js via Java 允许您添加一个不嵌入数据、仅通过链接指向文件的 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)。 

下面的 JavaScript 代码演示如何向幻灯片添加一个链接到 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)： 
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```
 

## **Accessing OLE Object Frames** 
如果幻灯片中已经嵌入了 OLE 对象，您可以按照以下方式轻松查找或访问它： 

1. 通过创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。 
2. 使用索引获取幻灯片的引用。 
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) 形状。在本例中，我们使用了之前创建的仅在第一张幻灯片上包含一个形状的 PPTX。 
4. 访问 OLE 对象框后，您可以对其执行任何操作。 

下面的示例演示如何访问 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // 获取嵌入的文件数据。
    // 获取嵌入文件的扩展名。
    // ...
}
```
 

### **Accessing Linked OLE Object Frame Properties** 
Aspose.Slides 允许您访问链接的 OLE 对象框属性。 

下面的 JavaScript 代码演示如何检查 OLE 对象是否为链接以及获取链接文件的路径： 
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // 检查 OLE 对象是否为链接。
    if (oleFrame.isObjectLink()) {
        // 打印链接文件的完整路径。
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 如果存在，打印链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```
 

## **Changing OLE Object Data** 
{{% alert color="primary" %}} 
本节中的代码示例使用 [Aspose.Cells for Java](/cells/java/)。 
{{% /alert %}} 
如果 OLE 对象已经嵌入幻灯片，您可以按以下方式访问并修改其数据： 

1. 通过创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。 
2. 通过索引获取幻灯片的引用。 
3. 访问 OLE 对象框形状。在本例中，我们使用了之前创建的仅在第一张幻灯片上包含一个形状的 PPTX。 
4. 访问 OLE 对象框后，您可以对其执行任何操作。 
5. 创建 `Workbook` 对象并访问 OLE 数据。 
6. 访问所需的 `Worksheet` 并修改数据。 
7. 将更新后的 `Workbook` 保存到流中。 
8. 从流中更改 OLE 对象数据。 

下面的示例演示如何访问 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），并修改其文件数据以更新图表数据。 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 读取 OLE 对象数据为 Workbook 对象。
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // 修改工作簿数据。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // 更改 OLE 框对象数据。
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```
 

## **Embedding Other File Types in Slides** 
除了 Excel 图表，Aspose.Slides for Node.js via Java 还允许您在幻灯片中嵌入其他类型的文件。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相应程序中打开，或提示用户选择合适的程序打开。 

下面的 JavaScript 代码演示如何将 HTML 和 ZIP 嵌入幻灯片： 
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```
 

## **Setting File Types for Embedded Objects** 
在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的。Aspose.Slides for Node.js via Java 允许您为嵌入对象设置文件类型，从而更新 OLE 框数据或其扩展名。 

下面的 JavaScript 代码演示如何将嵌入的 OLE 对象的文件类型设置为 `zip`： 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// 将文件类型更改为 ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```
 

## **Setting Icon Images and Titles for Embedded Objects** 
嵌入 OLE 对象后，会自动添加由图标图像组成的预览。该预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图像和文字作为预览元素，可以使用 Aspose.Slides for Node.js via Java 设置图标图像和标题。 

下面的 JavaScript 代码演示如何为嵌入对象设置图标图像和标题： 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// 将图像添加到演示文稿资源中。
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// 为 OLE 预览设置标题和图像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```
 

## **Prevent an OLE Object Frame from Being Resized and Pepositioned** 
在向演示文稿幻灯片添加链接的 OLE 对象后，打开 PowerPoint 时可能会看到提示更新链接的消息。单击“Update Links”按钮可能会更改 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。要阻止 PowerPoint 提示更新对象数据，请使用 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) 类的 `setUpdateAutomatic` 方法并将其值设为 `false`： 
```javascript
oleFrame.setUpdateAutomatic(false);
```
 

## **Extracting Embedded Files** 
Aspose.Slides for Node.js via Java 允许您按以下方式提取嵌入在幻灯片中作为 OLE 对象的文件： 

1. 创建包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类实例。 
2. 遍历演示文稿中的所有形状，访问 [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) 形状。 
3. 访问 OLE 对象框中嵌入文件的数据并写入磁盘。 

下面的 JavaScript 代码演示如何提取嵌入在幻灯片中的 OLE 对象文件： 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```
 

## **FAQ** 

**Will the OLE content be rendered when exporting slides to PDF/images?** 

在导出为 PDF/图像时，仅渲染幻灯片上可见的内容——图标/替代图像（预览）。“实时”OLE 内容在渲染过程中不执行。如有需要，可自行设置预览图像，以确保在导出的 PDF 中呈现期望的外观。 

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?** 

锁定形状：Aspose.Slides 提供 [shape-level locks](/slides/zh/nodejs-java/applying-protection-to-presentation/)。这不是加密，但可有效防止意外编辑和移动。 

**Will relative paths for linked OLE objects be preserved in the PPTX format?** 

在 PPTX 中不保存“相对路径”信息，仅保存完整路径。相对路径仅在旧的 PPT 格式中存在。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或嵌入文件。