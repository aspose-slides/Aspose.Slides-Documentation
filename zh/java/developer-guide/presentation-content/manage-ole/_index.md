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
## **介绍**

{{% alert color="info" %}} 

OLE（对象链接与嵌入）是微软技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入放入另一个应用程序。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可能以图标形式出现。在这种情况下，双击图标时，图表会在其关联的应用程序（Excel）中打开，或系统会提示您选择用于打开或编辑对象的应用程序。
- OLE 对象也可能直接显示其实际内容，例如图表内容。在这种情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。

[Aspose.Slides for Java](https://products.aspose.com/slides/zh/java/) 允许您将 OLE 对象作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/OleObjectFrame)）插入到幻灯片中。

## **向幻灯片添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Java 将其嵌入到幻灯片中作为 OLE 对象框，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 将 Excel 文件读取为字节数组。
4. 将 [OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/OleObjectFrame) 添加到幻灯片中，其中包括字节数组和 OLE 对象的其他信息。
5. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Java 将来自 Excel 文件的图表添加为 OLE 对象框。

**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/OleEmbeddedDataInfo) 构造函数将可嵌入对象的扩展名作为第二参数。此扩展名使 PowerPoint 能够正确解释文件类型并选择合适的应用程序打开该 OLE 对象。

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### **添加链接的 OLE 对象框**

Aspose.Slides for Java 允许您添加一个不嵌入数据、仅包含文件链接的 [OleObjectFrame]。

此 Java 代码演示如何将带有链接的 Excel 文件的 [OleObjectFrame] 添加到幻灯片中：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **访问 OLE 对象框**

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松查找或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例加载包含嵌入 OLE 对象的演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/OleObjectFrame) 形状。在我们的示例中，我们使用了先前创建的只有第一张幻灯片上一个形状的 PPTX。我们随后 *强制转换* 该对象为 [IOleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IOleObjectFrame)。这就是要访问的目标 OLE 对象框。
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。

在下面的示例中，访问了 OLE 对象框（嵌入幻灯片的 Excel 图表对象）及其文件数据。

``` java 
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

### **访问链接的 OLE 对象框属性**

Aspose.Slides 允许您访问链接的 OLE 对象框属性。

此 Java 代码演示如何检查 OLE 对象是否为链接，并获取链接文件的路径：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // 检查 OLE 对象是否为链接。
    if (oleFrame.isObjectLink()) {
        // 输出链接文件的完整路径。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 如果存在，输出链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **更改 OLE 对象数据**

{{% alert color="info" %}} 

在本节中，下面的代码示例使用 [Aspose.Cells for Java](/cells/java/)。

{{% /alert %}}

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松访问并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例加载包含嵌入 OLE 对象的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 OLE 对象框形状。在我们的示例中，我们使用了先前创建的只有第一张幻灯片上一个形状的 PPTX。我们随后 *强制转换* 该对象为 [IOleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IOleObjectFrame)。这就是要访问的目标 OLE 对象框。
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。
5. 创建一个 `Workbook` 对象并访问 OLE 数据。
6. 访问所需的 `Worksheet` 并修改数据。
7. 将更新后的 `Workbook` 保存到流中。
8. 从流中更改 OLE 对象数据。

在下面的示例中，访问了 OLE 对象框（嵌入幻灯片的 Excel 图表对象），并修改其文件数据以更新图表数据。

``` java 
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

    // 更改 OLE 框对象数据。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for Java 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相应程序中打开，或提示用户选择合适的程序。

此 Java 代码演示如何将 HTML 和 ZIP 嵌入到幻灯片中：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

在处理演示文稿时，您可能需要用新对象替换旧的 OLE 对象，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for Java 允许您为嵌入对象设置文件类型，从而更新 OLE 框数据或其扩展名。

此 Java 代码演示如何将嵌入的 OLE 对象的文件类型设置为 `zip`：

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

嵌入 OLE 对象后，系统会自动添加一个由图标图像组成的预览。这是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图像和文本作为预览元素，可以使用 Aspose.Slides for Java 设置图标图像和标题。

此 Java 代码演示如何为嵌入对象设置图标图像和标题：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **防止 OLE 对象框被重新调整大小和重新定位**

在向演示文稿幻灯片添加链接的 OLE 对象后，打开 PowerPoint 时可能会出现提示要求更新链接。单击“Update Links”按钮可能会因为 PowerPoint 更新链接的 OLE 对象数据并刷新对象预览而改变 OLE 对象框的大小和位置。为防止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ioleobjectframe/) 接口的 `setUpdateAutomatic` 方法设置为 `false`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **提取嵌入的文件**

Aspose.Slides for Java 允许您按以下方式提取嵌入在幻灯片中的 OLE 对象文件：

1. 创建包含您要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类实例。
2. 循环遍历演示文稿中的所有形状，并访问 [OLEObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/oleobjectframe) 形状。
3. 从 OLE 对象框中访问嵌入文件的数据并写入磁盘。

此 Java 代码演示如何将幻灯片中嵌入的文件提取为 OLE 对象：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### 在将幻灯片导出为 PDF/图像时，是否会渲染 OLE 内容？

渲染的是幻灯片上可见的内容——图标/替代图像（预览）。“实时” OLE 内容在渲染过程中不会被执行。如有需要，可设置您自己的预览图像，以确保在导出的 PDF 中呈现预期的外观。

### 如何锁定幻灯片上的 OLE 对象，使用户无法在 PowerPoint 中移动/编辑它？

锁定形状：Aspose.Slides 提供 [shape-level locks](/slides/zh/java/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外编辑和移动。

### 为什么打开演示文稿时，链接的 Excel 对象会“跳动”或改变大小？

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定的外观，请遵循 [Worksheet Resizing 的工作方案](/slides/zh/java/working-solution-for-worksheet-resizing/)——要么将框架适配到范围，要么将范围缩放到固定框架并设置合适的替代图像。

### PPTX 格式中会保留链接 OLE 对象的相对路径吗？

在 PPTX 中，不提供 “相对路径” 信息——仅有完整路径。相对路径存在于旧的 PPT 格式中。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或直接嵌入。