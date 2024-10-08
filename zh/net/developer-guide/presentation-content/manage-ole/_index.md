---
title: 管理OLE
type: docs
weight: 40
url: /net/manage-ole/
keywords:
- 添加OLE
- 嵌入OLE
- 添加对象
- 嵌入对象
- 嵌入文件
- 连接对象
- 对象链接与嵌入
- OLE对象
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: 在C#或.NET中将OLE对象添加到PowerPoint演示文稿
---

{{% alert title="信息" color="info" %}}

OLE（对象链接与嵌入）是一种微软技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入被放置到另一个应用程序中。

{{% /alert %}}

考虑在MS Excel中创建的图表。该图表随后被放置在PowerPoint幻灯片中。那个Excel图表被视为OLE对象。

- OLE对象可以显示为一个图标。在这种情况下，当您双击图标时，图表将在其关联的应用程序（Excel）中打开，或者系统会要求您选择一个应用程序来打开或编辑该对象。
- OLE对象可以显示实际内容，例如图表的内容。在这种情况下，图表会在PowerPoint中激活，图表界面被加载，您可以在PowerPoint应用程序中修改图表的数据。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/)允许您将OLE对象插入幻灯片作为OLE对象框（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）。

## **向幻灯片添加OLE对象框**
假设您已经在Microsoft Excel中创建了一个图表，并希望使用Aspose.Slides for .NET将该图表作为OLE对象框嵌入到幻灯片中，可以这样做：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 通过索引获取幻灯片的引用。
3. 打开包含Excel图表对象的Excel文件并保存到`MemoryStream`。
4. 将包含字节数组和关于OLE对象的其他信息的[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)添加到幻灯片中。
5. 将修改后的演示文稿写入PPTX文件。

在下面的示例中，我们使用Aspose.Slides for .NET将来自Excel文件的图表添加到幻灯片中作为[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)。
**注意**，[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo)构造函数的第二个参数为可嵌入对象的扩展名。此扩展名允许PowerPoint正确解释文件类型并选择正确的应用程序打开此OLE对象。

``` csharp 
// 实例化表示PPTX文件的Presentation类
using (Presentation pres = new Presentation())
{
    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 将Excel文件加载到流中
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // 创建一个嵌入数据对象
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // 添加一个Ole对象框形状
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    //将PPTX文件写入磁盘
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
### 添加链接的OLE对象框

Aspose.Slides for .NET允许您添加一个没有嵌入数据而仅仅链接到文件的[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)。

以下C#代码向您展示如何将链接的Excel文件添加到幻灯片中的[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)：

``` csharp 
using (Presentation pres = new Presentation())
{
	// 访问第一张幻灯片
	ISlide slide = pres.Slides[0];

	// 添加一个链接的Excel文件的Ole对象框
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");

	// 将PPTX文件写入磁盘
	pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);
}
```

## **访问OLE对象框**
如果OLE对象已经嵌入在幻灯片中，您可以这样轻松找到或访问该对象：

1. 创建一个包含OLE对象的[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 通过索引获取幻灯片的引用。
3. 访问[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)形状。
   在我们的示例中，我们使用先前创建的只有一个形状的PPTX在第一张幻灯片上。然后我们将该对象*强制转换*为[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)。这是要访问的目标OLE对象框。
4. 一旦访问了OLE对象框，您可以对其执行任何操作。
在下面的示例中，访问了一个OLE对象框（在幻灯片中嵌入的Excel图表对象），然后将其文件数据写入Excel文件：
``` csharp 
// 将PPTX加载到演示对象中
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 强制转换形状为OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // 读取OLE对象并将其写入磁盘
    if (oleObjectFrame != null)
    {
        // 获取嵌入的文件数据
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // 获取嵌入的文件扩展名
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // 创建一个路径以保存提取的文件
        string extractedPath = "excelFromOLE_out" + fileExtention;

        // 保存提取的数据
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

### 访问链接的OLE对象框属性

Aspose.Slides允许您访问链接的OLE对象框属性。

以下C#代码向您展示如何检查OLE对象是否链接，并获取链接文件的路径：
```csharp
using (Presentation pres = new Presentation("OleLinked.ppt"))
{
	// 访问第一张幻灯片
	ISlide slide = pres.Slides[0];

	// 将第一个形状作为OLE对象框获取
	OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;

	// 检查OLE对象是否链接。
	if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)
	{
		// 打印链接文件的完整路径
		Console.WriteLine("Ole对象框链接到: " + oleObjectFrame.LinkPathLong);

		// 如果存在，打印链接文件的相对路径。
		// 只有PPT演示文稿可以包含相对路径。
		string relativePath = oleObjectFrame.LinkPathRelative;
		if (!string.IsNullOrEmpty(relativePath))
		{
			Console.WriteLine("Ole对象框相对路径: " + oleObjectFrame.LinkPathRelative);
		}
	}
}
```
## **更改OLE对象数据**

如果OLE对象已经嵌入在幻灯片中，您可以通过以下方式轻松访问该对象并修改其数据：

1. 通过创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例来打开所需的包含嵌入OLE对象的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)形状。
   在我们的示例中，我们使用先前创建的PPTX在第一张幻灯片上有一个形状。我们将该对象*强制转换*为[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)。这是要访问的目标OLE对象框。
4. 一旦访问了OLE对象框，您可以对其执行任何操作。
5. 创建Workbook对象并访问OLE数据。
6. 访问所需的工作表并修改数据。
7. 在流中保存更新的工作簿。
8. 从流数据更改OLE对象数据。
在下面的示例中，访问了一个OLE对象框（在幻灯片中嵌入的Excel图表对象），然后将其文件数据修改以更改图表数据：
``` csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // 遍历所有形状以寻找OLE框
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // 在Workbook中读取对象数据
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // 修改工作簿数据
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // 更改OLE框对象数据
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```
## **在幻灯片中嵌入其他文件类型**

除了Excel图表，Aspose.Slides for .NET允许您在幻灯片中嵌入其他类型的文件。例如，您可以将HTML、PDF和ZIP文件作为对象插入到幻灯片中。当用户双击插入的对象时，该对象会自动在相关程序中启动，或者用户会被引导选择相应的程序来打开该对象。

以下C#代码向您展示如何在幻灯片中嵌入HTML和ZIP：

```c#
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```
## **为嵌入对象设置文件类型**

在处理演示文稿时，您可能需要用新的OLE对象替换旧的OLE对象。或者，您可能需要将不支持的OLE对象替换为支持的对象。

Aspose.Slides for .NET允许您为嵌入对象设置文件类型。通过这种方式，您可以更改OLE框数据或其扩展名。

以下C#代码向您展示如何为嵌入的OLE对象设置文件类型：

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"当前嵌入数据扩展名为: {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```
## **为嵌入对象设置图标图像和标题**

在您嵌入OLE对象后，预览将自动添加一个图标图像和标题。预览是用户在访问或打开OLE对象之前看到的内容。

如果您希望使用特定的图像和文本作为预览中的元素，您可以使用Aspose.Slides for .NET设置图标图像和标题。

以下C#代码向您展示如何为嵌入对象设置图标图像和标题：

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "我的标题";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

## **防止OLE对象框被调整大小和重新定位**

在您将链接的OLE对象添加到演示文稿幻灯片后，当您在PowerPoint中打开演示文稿时，您可能会看到一个消息提示您更新链接。点击“更新链接”按钮可能会改变OLE对象框的大小和位置，因为PowerPoint会从链接的OLE对象更新数据并刷新对象预览。要防止PowerPoint提示更新对象的数据，请将[IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/)接口的`UpdateAutomatic`属性设置为`false`：

```cs
oleObjectFrame.UpdateAutomatic = false;
```

## **提取嵌入文件**

Aspose.Slides for .NET允许您按以下方式提取作为OLE对象嵌入在幻灯片中的文件：
1. 创建一个包含您打算提取的OLE对象的[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
2. 遍历演示文稿中的所有形状，并访问[OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)形状。
3. 从OLE对象框访问嵌入文件的数据并将其写入磁盘。
以下C#代码向您展示如何提取作为OLE对象嵌入在幻灯片中的文件：
```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```