---
title: 管理 OLE
type: docs
weight: 40
url: /androidjava/manage-ole/
keywords:
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 嵌入文件
- 关联对象
- 对象链接与嵌入
- OLE 对象
- PowerPoint 
- 演示文稿
- Android
- Java
- Aspose.Slides for Android via Java
description: 在 Java 中向 PowerPoint 演示文稿添加 OLE 对象
---

{{% alert color="primary" %}} 

OLE (对象链接与嵌入) 是一种 Microsoft 技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入放置到另一个应用程序中。 

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表然后放置在 PowerPoint 幻灯片中。这个 Excel 图表被视为 OLE 对象。

- OLE 对象可能显示为图标。在这种情况下，当你双击图标时，图表会在其关联的应用程序（Excel）中打开，或者会提示您选择一个应用程序来打开或编辑该对象。
- OLE 对象可能显示实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中被激活，图表界面加载，然后你可以在 PowerPoint 应用程序中修改图表的数据。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) 允许你将 OLE 对象作为 OLE 对象框插入到幻灯片中 ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame))。

## **向幻灯片添加 OLE 对象框**
假设你已经在 Microsoft Excel 中创建了一个图表，并希望使用 Aspose.Slides for Android via Java 将该图表作为 OLE 对象框嵌入到幻灯片中，你可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 打开包含 Excel 图表对象的 Excel 文件并将其保存到 `MemoryStream`。
1. 将 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) 添加到包含字节数组和有关 OLE 对象的其他信息的幻灯片中。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Android via Java 将来自 Excel 文件的图表作为 OLE 对象框添加到幻灯片中。
**注意**，[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IOleEmbeddedDataInfo) 构造函数将可嵌入对象扩展名作为第二个参数。此扩展名允许 PowerPoint 正确解释文件类型并选择正确的应用程序打开该 OLE 对象。

``` java 
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 加载 Excel 文件到流
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

    // 创建嵌入数据对象
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // 添加 Ole 对象框形状
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    // 将 PPTX 文件写入磁盘
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问 OLE 对象框**
如果 OLE 对象已经嵌入到幻灯片中，你可以轻松地找到或访问该对象：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 访问 OLE 对象框形状。

   在我们的示例中，我们使用了之前创建的 PPTX，该 PPTX 在第一张幻灯片上只有一个形状。然后我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)。这就是要访问的 OLE 对象框。
1. 一旦访问了 OLE 对象框，你可以在其上执行任何操作。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），然后将其文件数据写入到一个 Excel 文件中。

``` java 
// 加载 PPTX 到 Presentation 对象
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 将形状强制转换为 OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // 读取 OLE 对象并将其写入磁盘
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

## **更改 OLE 对象的数据**

如果 OLE 对象已经嵌入到幻灯片中，你可以轻松访问该对象并以这种方式修改其数据：

1. 通过创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例打开目标演示文稿，该演示文稿中嵌入了 OLE 对象。
1. 通过其索引获取幻灯片的引用。
1. 访问 OLE 对象框形状。

   在我们的示例中，我们使用了之前创建的 PPTX，该 PPTX 在第一张幻灯片上只有一个形状。我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)。这就是要访问的 OLE 对象框。
1. 一旦访问了 OLE 对象框，你可以在其上执行任何操作。
1. 创建 Workbook 对象并访问 OLE 数据。
1. 访问所需的工作表并修改数据。
1. 在流中保存更新后的工作簿。
1. 从流数据中更改 OLE 对象数据。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），然后其文件数据被修改以更改图表数据：

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

## 在幻灯片中嵌入其他类型的文件

除了 Excel 图表，Aspose.Slides for Android via Java 还允许你在幻灯片中嵌入其他类型的文件。例如，你可以将 HTML、PDF 和 ZIP 文件作为对象插入到幻灯片中。当用户双击插入的对象时，该对象会自动在相关程序中启动，或者用户会被引导选择一个适当的程序来打开该对象。

以下 Java 代码展示了如何在幻灯片中嵌入 HTML 和 ZIP：

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

## 为嵌入的对象设置文件类型

在处理演示文稿时，你可能需要用新对象替换旧的 OLE 对象。或者你可能需要用一个支持的 OLE 对象替换一个不受支持的 OLE 对象。

Aspose.Slides for Android via Java 允许你为嵌入的对象设置文件类型。这样，你可以更改 OLE 框数据或其扩展名。

以下 Java 代码展示了如何为嵌入的 OLE 对象设置文件类型：

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("当前嵌入数据扩展名是: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 为嵌入的对象设置图标图像和标题

在你嵌入 OLE 对象后，预览包含图标图像和标题会自动添加。预览是用户在访问或打开 OLE 对象之前所看到的内容。

如果你想使用特定的图像和文本作为预览中的元素，可以使用 Aspose.Slides for Android via Java 设置图标图像和标题。

以下 Java 代码展示了如何为嵌入的对象设置图标图像和标题：

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

在你将关联 OLE 对象添加到演示文稿幻灯片后，当你在 PowerPoint 中打开演示文稿时，可能会看到一条消息，要求你更新链接。单击“更新链接”按钮可能会更改 OLE 对象框的大小和位置，因为 PowerPoint 更新了来自关联 OLE 对象的数据并刷新了对象的预览。为了防止 PowerPoint 提示更新对象的数据，可以将 [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) 接口的 `setUpdateAutomatic` 方法设置为 `false`：

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## 提取嵌入的文件

Aspose.Slides for Android via Java 允许你以以下方式提取作为 OLE 对象嵌入在幻灯片中的文件：

1. 创建一个包含你打算提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 遍历演示文稿中的所有形状，访问 [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) 形状。
3. 从 OLE 对象框访问嵌入文件的数据并将其写入磁盘。

以下 Java 代码展示了如何提取嵌入在幻灯片中的 OLE 对象中的文件：

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