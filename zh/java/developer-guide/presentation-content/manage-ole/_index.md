---
title: 使用 Java 管理演示文稿中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/java/manage-ole/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。无缝嵌入、更新和导出 OLE 内容。"
---

{{% alert color="primary" %}} 

OLE（对象链接与嵌入）是微软技术，可让在一个应用程序中创建的数据和对象通过链接或嵌入方式放置到另一个应用程序中。 

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表即为 OLE 对象。 

- OLE 对象可以显示为图标。此时双击图标，图表将在其关联的应用程序（Excel）中打开，或系统会提示选择用于打开或编辑对象的应用程序。 
- OLE 对象也可以直接显示其实际内容，例如图表本身。此时图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。 

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) 允许您将 OLE 对象作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）插入到幻灯片中。 

## **向幻灯片添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Java 将其嵌入到幻灯片中作为 OLE 对象框，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 将 Excel 文件读取为字节数组。  
1. 将包含该字节数组及 OLE 对象其他信息的 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 添加到幻灯片。  
1. 将修改后的演示文稿写入为 PPTX 文件。  

下面的示例演示了如何使用 Aspose.Slides for Java 将 Excel 文件中的图表添加为 OLE 对象框。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) 构造函数的第二个参数是可嵌入对象的扩展名。此扩展名帮助 PowerPoint 正确识别文件类型并选择合适的应用程序打开该 OLE 对象。  
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// 为 OLE 对象准备数据。
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// 将 OLE 对象框添加到幻灯片。
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **添加链接的 OLE 对象框**

Aspose.Slides for Java 允许您在不嵌入数据的情况下，仅通过文件链接添加 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)。  

下面的 Java 代码演示了如何将链接到 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 添加到幻灯片中：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **访问 OLE 对象框**

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松查找或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例加载包含嵌入 OLE 对象的演示文稿。  
2. 使用索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 形状。  
   在本例中，我们使用先前创建的仅在第一张幻灯片上包含一个形状的 PPTX。随后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)，这就是需要访问的 OLE 对象框。  
4. 获取 OLE 对象框后，您可以对其执行任何操作。  

下面的示例演示了如何访问嵌入在幻灯片中的 OLE 对象框（一个 Excel 图表对象）及其文件数据。  
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


### **访问链接的 OLE 对象框属性**

Aspose.Slides 允许您访问链接的 OLE 对象框属性。  

下面的 Java 代码演示了如何检查 OLE 对象是否为链接，并获取链接文件的路径：  
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

        // 如有，打印链接文件的相对路径。
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

本节中的代码示例使用 [Aspose.Cells for Java](/cells/java/)。  

{{% /alert %}}

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松访问并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例加载包含嵌入 OLE 对象的演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 访问 OLE 对象框形状。  
   在本例中，我们使用先前创建的仅在第一张幻灯片上包含一个形状的 PPTX。随后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame)，这就是需要访问的 OLE 对象框。  
4. 获取 OLE 对象框后，您可以对其执行任何操作。  
5. 创建 `Workbook` 对象并访问 OLE 数据。  
6. 访问所需的 `Worksheet` 并修改数据。  
7. 将更新后的 `Workbook` 保存到流中。  
8. 从该流中更改 OLE 对象的数据。  

下面的示例演示了如何访问嵌入在幻灯片中的 OLE 对象框（一个 Excel 图表对象），并修改其文件数据以更新图表数据。  
``` java 
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

    // 更改 OLE 框对象的数据。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for Java 还支持将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，会自动在相应程序中打开，或提示用户选择合适的程序。  

下面的 Java 代码演示了如何将 HTML 和 ZIP 嵌入到幻灯片中：  
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


## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要用新对象替换旧的 OLE 对象，或用受支持的对象替换不受支持的对象。Aspose.Slides for Java 允许您为嵌入对象设置文件类型，从而更新 OLE 框的数据或其扩展名。  

下面的 Java 代码演示了如何将嵌入 OLE 对象的文件类型设置为 `zip`：  
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


## **为嵌入对象设置图标图片和标题**

嵌入 OLE 对象后，会自动添加一个由图标图片组成的预览。该预览是用户在访问或打开 OLE 对象之前看到的内容。如果您希望使用特定的图片和文字作为预览元素，可通过 Aspose.Slides for Java 设置图标图片和标题。  

下面的 Java 代码演示了如何为嵌入对象设置图标图片和标题：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// 向演示文稿资源添加图像。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// 为 OLE 预览设置标题和图像。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **防止 OLE 对象框被重新定位和重新大小调整**

将链接的 OLE 对象添加到演示文稿幻灯片后，打开 PowerPoint 时可能会出现提示要求更新链接。单击“更新链接”按钮可能会导致 OLE 对象框的大小和位置发生变化，因为 PowerPoint 会从链接的 OLE 对象刷新数据并更新预览。为防止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) 接口的 `setUpdateAutomatic` 方法设为 `false`：  
```java
oleFrame.setUpdateAutomatic(false);
```


## **提取嵌入的文件**

Aspose.Slides for Java 允许您按以下方式提取幻灯片中作为 OLE 对象嵌入的文件：

1. 创建包含需提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 实例。  
2. 遍历演示文稿中的所有形状，访问其中的 [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) 形状。  
3. 从 OLE 对象框中获取嵌入文件的数据并写入磁盘。  

下面的 Java 代码演示了如何提取幻灯片中嵌入的 OLE 对象文件：  
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


## **常见问题**

**导出幻灯片为 PDF/图像时会渲染 OLE 内容吗？**  

渲染的是幻灯片上可见的内容——图标/替代图片（预览）。“实时” OLE 内容不会在渲染时执行。如有需要，可自行设置预览图片，以确保在导出的 PDF 中得到期望的外观。  

**如何锁定幻灯片上的 OLE 对象，使用户在 PowerPoint 中无法移动或编辑？**  

锁定形状：Aspose.Slides 提供 [形状级别的锁定](/slides/zh/java/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外编辑和移动。  

**为何在打开演示文稿时，链接的 Excel 对象会“跳动”或改变大小？**  

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定外观，请参考 [工作表大小调整的解决方案](/slides/zh/java/working-solution-for-worksheet-resizing/)，要么将框架适配到范围，要么将范围缩放到固定框架并设置合适的替代图片。  

**在 PPTX 格式中，链接的 OLE 对象会保留相对路径吗？**  

在 PPTX 中，仅存储完整路径，不提供“相对路径”。相对路径仅在旧的 PPT 格式中存在。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或直接嵌入文件。