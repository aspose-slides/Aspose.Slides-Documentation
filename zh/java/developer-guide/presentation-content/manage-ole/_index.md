---
title: 使用 Java 在演示文稿中管理 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/java/manage-ole/
keywords:
  - OLE 对象
  - 对象链接与嵌入
  - 添加 OLE
  - 嵌入 OLE
  - 添加 对象
  - 嵌入 对象
  - 添加 文件
  - 嵌入 文件
  - 链接 对象
  - 链接 文件
  - 更改 OLE
  - OLE 图标
  - OLE 标题
  - 提取 OLE
  - 提取 对象
  - 提取 文件
  - PowerPoint
  - 演示文稿
  - Java
  - Aspose.Slides
description: "使用 Aspose.Slides for Java 优化 PowerPoint 和 OpenDocument 文件中 OLE 对象的管理。无缝嵌入、更新和导出 OLE 内容。"
---

{{% alert color="primary" %}} 

OLE（对象链接与嵌入）是微软技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可以显示为图标。在此情况下，双击图标会在其关联的应用程序（Excel）中打开图表，或系统会提示您选择用于打开或编辑对象的应用程序。
- OLE 对象也可以直接显示其实际内容，例如图表本身。在此情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) 允许您将 OLE 对象插入到幻灯片中作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）。

## **Add OLE Object Frames to Slides**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Java 将其以 OLE 对象框的形式嵌入到幻灯片中，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 将 Excel 文件读取为字节数组。
1. 将包含字节数组及其他 OLE 对象信息的 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 添加到幻灯片。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Java 将 Excel 文件中的图表添加为 OLE 对象框。

**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Add Linked OLE Object Frames**

Aspose.Slides for Java 允许您在不嵌入数据的情况下，仅通过链接文件来添加 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)。

下面的 Java 代码演示如何将链接的 Excel 文件作为 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 添加到幻灯片中：
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add an OLE object frame with a linked Excel file.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Access OLE Object Frames**

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松查找或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。
2. 使用索引获取幻灯片的引用。
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 形状。  
   在我们的示例中，使用了之前创建的仅在第一张幻灯片上包含一个形状的 PPTX。随后将该对象 *cast* 为 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)。这就是需要访问的 OLE 对象框。
4. 一旦访问到 OLE 对象框，您即可对其执行任意操作。

下面的示例演示如何访问嵌入在幻灯片中的 OLE 对象框（Excel 图表对象）以及其文件数据。
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 获取嵌入的文件数据。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 获取嵌入文件的扩展名。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Access Linked OLE Object Frame Properties**

Aspose.Slides 允许您访问链接的 OLE 对象框属性。

下面的 Java 代码演示如何检查 OLE 对象是否为链接，并获取链接文件的路径：
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // 检查 OLE 对象是否为链接。
    if (oleFrame.isObjectLink()) {
        // 打印链接文件的完整路径。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 如果存在，打印链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Change OLE Object Data**

{{% alert color="primary" %}} 

本节中的代码示例使用 [Aspose.Cells for Java](/cells/java/)。

{{% /alert %}}

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松访问该对象并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 OLE 对象框形状。  
   在我们的示例中，使用了之前创建的在第一张幻灯片上仅有一个形状的 PPTX。随后将该对象 *cast* 为 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)。这就是需要访问的 OLE 对象框。
4. 一旦访问到 OLE 对象框，您即可对其执行任意操作。
5. 创建 `Workbook` 对象并访问 OLE 数据。
6. 访问目标 `Worksheet` 并修改数据。
7. 将更新后的 `Workbook` 保存到流中。
8. 从流中更改 OLE 对象的数据。

下面的示例演示如何访问 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）并修改其文件数据以更新图表数据。
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 将 OLE 对象数据读取为 Workbook 对象。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // 修改工作簿数据。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // 更改 OLE 框对象的数据。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Embed Other File Types in Slides**

除了 Excel 图表外，Aspose.Slides for Java 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相关程序中打开，或提示用户选择合适的程序打开。

下面的 Java 代码演示如何将 HTML 和 ZIP 嵌入到幻灯片中：
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Set File Types for Embedded Objects**

在处理演示文稿时，您可能需要用新 OLE 对象替换旧对象，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for Java 允许您为嵌入对象设置文件类型，从而更新 OLE 框数据或其扩展名。

下面的 Java 代码演示如何将嵌入 OLE 对象的文件类型设置为 `zip`：
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Set Icon Images and Titles for Embedded Objects**

嵌入 OLE 对象后，会自动添加一个由图标图像组成的预览。这是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图像和文字作为预览元素，可以使用 Aspose.Slides for Java 设置图标图像和标题。

下面的 Java 代码演示如何为嵌入对象设置图标图像和标题：
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 将图像添加到演示文稿资源中。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// 为 OLE 预览设置标题和图像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

将链接的 OLE 对象添加到演示文稿幻灯片后，打开 PowerPoint 时可能会看到提示更新链接的消息。单击 “Update Links” 按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。要阻止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) 接口的 `setUpdateAutomatic` 方法设为 `false`：
```java
oleFrame.setUpdateAutomatic(false);
```


## **Extract Embedded Files**

Aspose.Slides for Java 允许您按以下方式提取幻灯片中作为 OLE 对象嵌入的文件：

1. 创建包含待提取 OLE 对象的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类实例。
2. 遍历演示文稿中的所有形状，访问其中的 [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) 形状。
3. 从 OLE 对象框中获取嵌入文件的数据并写入磁盘。

下面的 Java 代码演示如何提取嵌入在幻灯片中的文件作为 OLE 对象：
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```


## **FAQ**

**Will the OLE content be rendered when exporting slides to PDF/images?**

渲染的仅是幻灯片上可见的内容——图标/替代图像（预览）。“实时” OLE 内容在渲染时不会执行。如有需要，可设置自定义预览图像，以确保导出 PDF 时的预期外观。

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

锁定形状：Aspose.Slides 提供 [shape-level locks](/slides/zh/java/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外编辑和移动。

**Why does a linked Excel object "jump" or change size when I open the presentation?**

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定外观，请遵循 [Working Solution for Worksheet Resizing](/slides/zh/java/working-solution-for-worksheet-resizing/) 的做法——要么将框适配到范围，要么将范围缩放到固定框并设置合适的替代图像。

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

在 PPTX 中不支持 “相对路径” 信息——仅存储完整路径。相对路径存在于旧的 PPT 格式中。为提升可移植性，建议使用可靠的绝对路径/可访问的 URI 或直接嵌入文件。