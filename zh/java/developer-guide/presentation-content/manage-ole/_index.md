---
title: 管理 OLE
type: docs
weight: 40
url: /zh/java/manage-ole/
keywords:
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 嵌入文件
- 链接对象
- 对象链接与嵌入
- OLE 对象
- PowerPoint 
- 演示文稿
- Java
- Aspose.Slides for Java
description: 在 Java 中将 OLE 对象添加到 PowerPoint 演示文稿
---

{{% alert color="primary" %}} 

OLE（对象链接与嵌入）是微软的一种技术，它允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。 

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。 

- OLE 对象可能显示为一个图标。在这种情况下，当你双击图标时，图表将在其关联的应用程序（Excel）中打开，或者你会被要求选择一个应用程序来打开或编辑该对象。 
- OLE 对象可能显示实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中激活，图表界面加载，你可以在 PowerPoint 应用程序中修改图表的数据。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) 允许你将 OLE 对象插入到幻灯片中作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）。

## **将 OLE 对象框添加到幻灯片**
假设你已经在 Microsoft Excel 中创建了一个图表，并希望使用 Aspose.Slides for Java 将该图表作为 OLE 对象框嵌入到幻灯片中，可以按照以下步骤进行：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 打开包含 Excel 图表对象的 Excel 文件并将其保存到 `MemoryStream` 中。
1. 将 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) 添加到包含字节数组和其他关于 OLE 对象的信息的幻灯片中。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Java 将 Excel 文件中的图表作为 OLE 对象框添加到幻灯片中。  
**注意**，[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) 构造函数的第二个参数是可嵌入对象的扩展名。该扩展名允许 PowerPoint 正确解释文件类型并选择正确的应用程序来打开该 OLE 对象。

``` java 
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将 Excel 文件加载到流中
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // 创建一个数据对象以进行嵌入
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // 添加 Ole 对象框形状
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    //将 PPTX 文件写入磁盘
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问 OLE 对象框**
如果 OLE 对象已经嵌入到幻灯片中，你可以使用以下方式轻松找到或访问该对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 访问 OLE 对象框形状。

   在我们的示例中，我们使用了之前创建的 PPTX，它在第一张幻灯片上只有一个形状。我们然后将该对象*转换*为 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)。这是我们希望访问的 OLE 对象框。
1. 一旦访问了 OLE 对象框，你可以对其执行任何操作。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）——然后将其文件数据写入 Excel 文件。

``` java 
// 加载 PPTX 到一个 Presentation 对象
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将形状转换为 OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // 读取 OLE 对象并写入磁盘
    if (oleObjectFrame != null) {
        // 获取嵌入文件数据
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // 获取嵌入文件扩展名
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // 创建保存提取文件的路径
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // 保存提取的数据
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改 OLE 对象数据**

如果 OLE 对象已经嵌入到幻灯片中，你可以轻松访问该对象并以以下方式修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例打开带有嵌入 OLE 对象的所需演示文稿。
1. 通过其索引获取幻灯片的引用。 
1. 访问 OLE 对象框形状。

   在我们的示例中，我们使用了之前创建的 PPTX，该幻灯片上只有一个形状。我们然后将该对象*转换*为 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)。这是要访问的 OLE 对象框。
1. 一旦访问了 OLE 对象框，你可以对其执行任何操作。
1. 创建 Workbook 对象并访问 OLE 数据。
1. 访问所需的工作表并修改数据。
1. 将更新后的 Workbook 保存在流中。
1. 从流数据更改 OLE 对象数据。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）——然后修改了其文件数据以更改图表数据：

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // 遍历所有形状以查找 Ole 框
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // 在 Workbook 中读取对象数据
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // 修改工作簿数据
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // 更改 Ole 框对象数据
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 在幻灯片中嵌入其他文件类型

除了 Excel 图表，Aspose.Slides for Java 还允许你将其他类型的文件嵌入到幻灯片中。例如，你可以将 HTML、PDF 和 ZIP 文件作为对象插入到幻灯片中。当用户双击插入的对象时，该对象会自动在相关程序中启动，或者用户将被引导选择一个合适的程序来打开该对象。 

下面的 Java 代码演示了如何在幻灯片中嵌入 HTML 和 ZIP：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 为嵌入对象设置文件类型

在处理演示文稿时，你可能需要用新对象替换旧的 OLE 对象。或者你可能需要用支持的对象替换不支持的 OLE 对象。 

Aspose.Slides for Java 允许你为嵌入对象设置文件类型。这样，你可以更改 OLE 框数据或其扩展名。 

下面的 Java 代码演示了如何为嵌入 OLE 对象设置文件类型：

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("当前嵌入数据扩展名为: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 为嵌入对象设置图标图像和标题

在你嵌入 OLE 对象后，会自动添加一个包含图标图像和标题的预览。预览是用户在访问或打开 OLE 对象之前看到的内容。 

如果你希望使用特定的图像和文本作为预览中的元素，可以使用 Aspose.Slides for Java 设置图标图像和标题。 

下面的 Java 代码演示了如何为嵌入对象设置图标图像和标题： 

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("我的标题");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **防止 OLE 对象框被调整大小和重新定位**

在你将链接的 OLE 对象添加到演示文稿幻灯片后，当你在 PowerPoint 中打开演示文稿时，可能会看到一条消息，询问你是否要更新链接。单击“更新链接”按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。要防止 PowerPoint 提示更新对象的数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) 接口的 `setUpdateAutomatic` 方法设置为 `false`：

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## 提取嵌入文件

Aspose.Slides for Java 允许你以以下方式提取作为 OLE 对象嵌入到幻灯片中的文件：

1. 创建一个包含你打算提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 遍历演示文稿中的所有形状并访问 [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) 形状。
3. 从 OLE 对象框中访问嵌入文件的数据并将其写入磁盘。 

下面的 Java 代码演示了如何提取嵌入在幻灯片中的文件作为 OLE 对象：

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // 保存提取的数据
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```