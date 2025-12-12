---
title: 在 Android 上管理演示文稿中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。实现 OLE 内容的无缝嵌入、更新和导出。"
---

{{% alert color="primary" %}} 

OLE（对象链接与嵌入）是微软技术，可让在一个应用程序中创建的数据和对象通过链接或嵌入放置在另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。 

- OLE 对象可能显示为图标。此情况下，双击图标后，图表将在其关联的应用程序（Excel）中打开，或会提示您选择用于打开或编辑对象的应用程序。 
- OLE 对象可能直接显示其实际内容，例如图表的内容。此情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表数据。 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) 允许您将 OLE 对象插入幻灯片作为 OLE 对象帧（[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)）。

## **向幻灯片添加 OLE 对象帧**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Android via Java 将其以 OLE 对象帧的形式嵌入到幻灯片中，可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将 Excel 文件读取为字节数组。  
4. 将 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 添加到幻灯片中，包含字节数组和 OLE 对象的其他信息。  
5. 将修改后的演示文稿写入为 PPTX 文件。  

在下面的示例中，我们使用 Aspose.Slides for Android via Java 将 Excel 文件中的图表以 OLE 对象帧的形式添加到幻灯片中。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) 构造函数接受可嵌入对象的扩展名作为第二个参数。此扩展名使 PowerPoint 能够正确解释文件类型并选择打开该 OLE 对象的合适应用程序。  
```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// 为 OLE 对象准备数据。
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **添加链接的 OLE 对象帧**

Aspose.Slides for Android via Java 允许您添加一个 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)，而不嵌入数据，仅使用指向文件的链接。

以下 Java 代码演示如何将带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 添加到幻灯片中：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 添加一个带链接的 Excel 文件的 OLE 对象框。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **访问 OLE 对象帧**

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松查找或访问它：

1. 通过创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例，加载包含嵌入 OLE 对象的演示文稿。  
2. 使用索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 形状。 在我们的示例中，使用了之前创建的仅在第一张幻灯片上有一个形状的 PPTX。然后 *cast* 该对象为 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)。这就是我们要访问的目标 OLE 对象帧。  
4. 一旦访问到 OLE 对象帧，即可对其执行任何操作。  

下面的示例中，访问了一个 OLE 对象帧（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。  
```java 
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


### **访问链接 OLE 对象帧属性**

Aspose.Slides 允许您访问链接的 OLE 对象帧属性。

以下 Java 代码演示如何检查 OLE 对象是否为链接，并获取链接文件的路径：  
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

        // 打印链接文件的相对路径（如果存在）。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **更改 OLE 对象数据**

{{% alert color="primary" %}} 

在本节中，下面的代码示例使用 [Aspose.Cells for Android via Java](/cells/androidjava/)。  

{{% /alert %}}

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松访问该对象并修改其数据：

1. 通过创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例，加载包含嵌入 OLE 对象的演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 访问 OLE 对象帧形状。 在我们的示例中，使用了之前创建的在第一张幻灯片上只有一个形状的 PPTX。然后 *cast* 该对象为 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)。这就是我们要访问的目标 OLE 对象帧。  
4. 一旦访问到 OLE 对象帧，即可对其执行任何操作。  
5. 创建一个 `Workbook` 对象并访问 OLE 数据。  
6. 访问所需的 `Worksheet` 并修改数据。  
7. 将更新后的 `Workbook` 保存到流中。  
8. 从流中更改 OLE 对象数据。  

下面的示例中，访问了一个 OLE 对象帧（嵌入在幻灯片中的 Excel 图表对象），并修改其文件数据以更新图表数据。  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // 读取 OLE 对象数据为 Workbook 对象。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // 修改工作簿数据。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // 更改 OLE 帧对象数据。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for Android via Java 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。用户双击插入的对象时，会自动在相应程序中打开，或提示用户选择合适的程序打开。  

以下 Java 代码演示如何将 HTML 和 ZIP 嵌入到幻灯片中：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for Android via Java 允许您设置嵌入对象的文件类型，从而更新 OLE 框的数据或其扩展名。  

以下 Java 代码演示如何将嵌入 OLE 对象的文件类型设置为 `zip`：  
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


## **为嵌入对象设置图标图像和标题**

嵌入 OLE 对象后，系统会自动添加由图标图像组成的预览。该预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想在预览中使用特定的图像和文字，可使用 Aspose.Slides for Android via Java 设置图标图像和标题。  

以下 Java 代码演示如何为嵌入对象设置图标图像和标题：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 向演示文稿资源添加图像。
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// 为 OLE 预览设置标题和图像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **防止 OLE 对象帧被调整大小和重新定位**

在向演示文稿幻灯片添加链接的 OLE 对象后，打开 PowerPoint 时可能会出现提示更新链接的消息。单击 “Update Links” 按钮可能会改变 OLE 对象帧的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。为防止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) 接口的 `setUpdateAutomatic` 方法设为 `false`：  
```java
oleFrame.setUpdateAutomatic(false);
```


## **提取嵌入文件**

Aspose.Slides for Android via Java 允许您按以下方式提取嵌入在幻灯片中的 OLE 对象文件：

1. 创建一个包含待提取 OLE 对象的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类实例。  
2. 循环遍历演示文稿中的所有形状，并访问 [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) 形状。  
3. 从 OLE 对象帧中访问嵌入文件的数据并写入磁盘。  

以下 Java 代码演示如何将幻灯片中嵌入的文件作为 OLE 对象提取出来：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```


## **常见问题**

**Will the OLE content be rendered when exporting slides to PDF/images?**  
幻灯片上可见的内容会被渲染——即图标/替代图像（预览）。“实时” OLE 内容在渲染时不会被执行。如有需要，可自行设置预览图像，以确保导出 PDF 时的预期外观。

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
锁定形状：Aspose.Slides 提供了 [shape-level locks](/slides/zh/androidjava/applying-protection-to-presentation/)。这并非加密，但能有效防止意外编辑和移动。

**Why does a linked Excel object "jump" or change size when I open the presentation?**  
PowerPoint 可能会刷新链接 OLE 的预览。为保持稳定外观，请遵循 [Working Solution for Worksheet Resizing](/slides/zh/androidjava/working-solution-for-worksheet-resizing/) 的做法——要么让框架适合数据范围，要么将范围缩放到固定框架并设置合适的替代图像。

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
在 PPTX 中不保留 “相对路径” 信息，仅保存完整路径。相对路径仅在旧的 PPT 格式中存在。为保证可移植性，建议使用可靠的绝对路径/可访问的 URI 或采用嵌入方式。