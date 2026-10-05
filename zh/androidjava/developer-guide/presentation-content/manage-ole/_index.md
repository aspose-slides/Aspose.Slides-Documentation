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
## **介绍**

{{% alert color="info" title="Note" %}}

OLE（对象链接与嵌入）是一项 Microsoft 技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入方式放置到另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。 

- OLE 对象可能以图标形式出现。在这种情况下，双击该图标时，图表会在其关联的应用程序（Excel）中打开，或者系统会要求您选择一个应用程序来打开或编辑该对象。  
- OLE 对象也可能显示其实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) 允许您将 OLE 对象插入到幻灯片中作为 OLE 对象帧 ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame))。

## **向幻灯片添加 OLE 对象帧**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Android via Java 将其嵌入为 OLE 对象帧到幻灯片中，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 将 Excel 文件读取为字节数组。  
1. 将 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 添加到幻灯片中，包含该字节数组以及关于 OLE 对象的其他信息。  
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Android via Java 将来自 Excel 文件的图表添加为 OLE 对象帧到幻灯片中。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) 构造函数接受可嵌入对象的扩展名作为第二个参数。此扩展名使 PowerPoint 能正确识别文件类型并选择合适的应用程序打开此 OLE 对象。

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// 准备 OLE 对象的数据。
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// 将 OLE 对象框添加到幻灯片。
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **添加链接的 OLE 对象帧**

Aspose.Slides for Android via Java 允许您添加一个不嵌入数据、仅通过文件链接的 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)。

以下 Java 代码演示如何将带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 添加到幻灯片中：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **访问 OLE 对象帧**

如果 OLE 对象已经嵌入到幻灯片中，您可以通过以下方式轻松找到或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例，加载包含嵌入式 OLE 对象的演示文稿。  
2. 使用其索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 形状。  
   在我们的示例中，使用了先前创建的仅在第一张幻灯片上有一个形状的 PPTX。随后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)。这就是要访问的目标 OLE 对象帧。  
4. 一旦访问到 OLE 对象帧，您就可以对其执行任何操作。

在下面的示例中，访问了 OLE 对象帧（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。

```java 
import com.aspose.slides.*;

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

### **访问链接的 OLE 对象帧属性**

Aspose.Slides 允许您访问链接的 OLE 对象帧属性。

以下 Java 代码演示如何检查 OLE 对象是否为链接，并获取链接文件的路径：

```java
import com.aspose.slides.*;

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

## **更改 OLE 对象数据**

{{% alert color="info" title="Note" %}}

在本节中，下面的代码示例使用了 [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/)。

{{% /alert %}}

如果 OLE 对象已经嵌入到幻灯片中，您可以通过以下方式轻松访问该对象并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例，加载包含嵌入式 OLE 对象的演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 访问 OLE 对象帧形状。  
   在我们的示例中，使用了先前创建的在第一张幻灯片上只有一个形状的 PPTX。随后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)。这就是要访问的目标 OLE 对象帧。  
4. 一旦访问到 OLE 对象帧，您就可以对其执行任何操作。  
5. 创建一个 `Workbook` 对象并访问 OLE 数据。  
6. 访问所需的 `Worksheet` 并修改数据。  
7. 将更新后的 `Workbook` 保存到流中。  
8. 从流中更改 OLE 对象数据。

在下面的示例中，访问了 OLE 对象帧（嵌入在幻灯片中的 Excel 图表对象），并修改其文件数据以更新图表数据。

```java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

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

## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表外，Aspose.Slides for Android via Java 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相应程序中打开，或提示用户选择合适的程序来打开它。

以下 Java 代码演示如何将 HTML 和 ZIP 嵌入到幻灯片中：

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for Android via Java 允许您为嵌入的对象设置文件类型，从而更新 OLE 框数据或其扩展名。

以下 Java 代码演示如何将嵌入的 OLE 对象的文件类型设置为 `zip`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// 将文件类型更改为 ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **为嵌入对象设置图标图像和标题**

嵌入 OLE 对象后，会自动添加由图标图像组成的预览。该预览是用户在访问或打开 OLE 对象前看到的内容。如果您想在预览中使用特定的图像和文本作为元素，可以使用 Aspose.Slides for Android via Java 设置图标图像和标题。

以下 Java 代码演示如何为嵌入的对象设置图标图像和标题：

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **防止 OLE 对象框被重新调整大小和重新定位**

在将链接的 OLE 对象添加到演示文稿的幻灯片后，当您在 PowerPoint 中打开演示文稿时，可能会看到一个提示更新链接的消息。单击“更新链接”按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。要阻止 PowerPoint 提示更新对象数据，请对 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) 接口调用 [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) 方法并传入 `false`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **提取嵌入文件**

Aspose.Slides for Android via Java 允许您按以下方式提取嵌入在幻灯片中的 OLE 对象文件：

1. 创建一个包含您想要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类实例。  
2. 遍历演示文稿中的所有形状并访问 [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) 形状。  
3. 从 OLE 对象帧中获取嵌入文件的数据并写入磁盘。

以下 Java 代码演示如何提取嵌入在幻灯片中的 OLE 对象文件：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

**在将幻灯片导出为 PDF/图像时，OLE 内容会被渲染吗？**

幻灯片上可见的内容会被渲染——即图标/替代图像（预览）。“实时” OLE 内容在渲染时不会执行。如有需要，可设置自己的预览图像，以确保在导出的 PDF 中呈现预期的外观。  
若要将嵌入的文件也作为 PDF 附件保留，请以 `true` 调用 [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)。此选项默认关闭。有关示例和检查附件的说明，请参见 [Preserve Embedded OLE Files as PDF Attachments](/slides/zh/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何在幻灯片上锁定 OLE 对象，使用户在 PowerPoint 中无法移动/编辑它？**

锁定形状：Aspose.Slides 提供形状级别的锁定功能。这不是加密，但能够有效防止意外编辑和移动。

**为什么在打开演示文稿时，链接的 Excel 对象会“跳动”或改变大小？**

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定的外观，请遵循 [Working Solution for Worksheet Resizing](/slides/zh/androidjava/working-solution-for-worksheet-resizing/) 的做法——要么将框架适配到范围，要么将范围缩放到固定框架并设置适当的替代图像。

**链接的 OLE 对象的相对路径会在 PPTX 格式中保留下来吗？**

在 PPTX 中，不提供“相对路径”信息——仅有完整路径。相对路径只存在于旧的 PPT 格式中。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或进行嵌入。