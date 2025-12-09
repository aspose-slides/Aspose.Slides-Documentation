---
title: 在 .NET 中管理演示文稿中的 OLE 对象
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/net/manage-ole/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 文件中优化 OLE 对象管理。无缝嵌入、更新和导出 OLE 内容。"
---

{{% alert title="Info" color="info" %}}
OLE（Object Linking & Embedding）是 Microsoft 的一项技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。
{{% /alert %}}

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可能以图标形式出现。在此情况下，双击该图标会在其关联的应用程序（Excel）中打开图表，或者系统会提示您选择用于打开或编辑对象的应用程序。
- OLE 对象也可能直接显示其实际内容，例如图表的内容。此时，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 内修改图表的数据。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) 允许您将 OLE 对象插入幻灯片，作为 OLE 对象框架（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）。

## **向幻灯片添加 OLE 对象框架**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for .NET 将其嵌入为 OLE 对象框架，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 将 Excel 文件读取为字节数组。
4. 将包含字节数组及其他 OLE 对象信息的 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 添加到幻灯片中。
5. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for .NET 将 Excel 文件中的图表添加为 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)。  
**Note** 构造函数 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 的第二个参数是可嵌入对象的扩展名。此扩展名使 PowerPoint 能够正确解释文件类型并选择合适的应用程序打开该 OLE 对象。
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // 为 OLE 对象准备数据。
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // 将 OLE 对象框架添加到幻灯片。
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **添加链接的 OLE 对象框架**

Aspose.Slides for .NET 允许您添加一个不嵌入数据、仅通过链接指向文件的 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)。

下面的 C# 代码演示了如何将带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 添加到幻灯片中：
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带有链接 Excel 文件的 OLE 对象框架。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **访问 OLE 对象框架**

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松找到或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。
2. 使用索引获取幻灯片的引用。
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 形状。 在我们的示例中，我们使用了先前创建的仅在第一张幻灯片上包含一个形状的 PPTX。随后将该对象 *cast* 为 [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe)。这就是我们想要访问的 OLE 对象框架。
4. 一旦访问到 OLE 对象框架，您就可以对其执行任何操作。

下面的示例演示了如何访问嵌入在幻灯片中的 OLE 对象框架（Excel 图表对象）以及其文件数据。
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 将第一个形状获取为 OLE 对象框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 获取嵌入的文件数据。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 获取嵌入文件的扩展名。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **访问链接的 OLE 对象框架属性**

Aspose.Slides 允许您访问链接的 OLE 对象框架属性。

下面的 C# 代码演示了如何检查 OLE 对象是否为链接以及获取链接文件的路径：
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 获取第一个形状作为 OLE 对象框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // 检查 OLE 对象是否为链接。
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // 打印链接文件的完整路径。
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 如有，打印链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **更改 OLE 对象数据**

{{% alert color="primary" %}} 
在本节中，下面的代码示例使用 [Aspose.Cells for .NET](/cells/net/)。
{{% /alert %}}

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松访问该对象并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。
2. 通过索引获取幻灯片的引用。 
3. 访问 [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 形状。 在我们的示例中，我们使用了先前创建的仅在第一张幻灯片上包含一个形状的 PPTX。随后将该对象 *cast* 为 [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe)。这就是我们想要访问的 OLE 对象框架。
4. 一旦访问到 OLE 对象框架，您就可以对其执行任何操作。
5. 创建 `Workbook` 对象并访问 OLE 数据。
6. 访问所需的 `Worksheet` 并修改数据。
7. 将更新后的 `Workbook` 保存到流中。
8. 从流中更改 OLE 对象数据。

下面的示例演示了如何访问嵌入在幻灯片中的 OLE 对象框架（Excel 图表对象），并修改其文件数据以更新图表数据。
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 获取第一个形状作为 OLE 对象框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // 将 OLE 对象数据读取为 Workbook 对象。
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // 修改工作簿数据。
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // 更改 OLE 框架对象数据。
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for .NET 还允许您在幻灯片中嵌入其他类型的文件。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。用户双击插入的对象时，会自动在相应程序中打开，或提示用户选择合适的程序打开。

下面的 C# 代码演示了如何将 HTML 和 ZIP 嵌入到幻灯片中：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的。Aspose.Slides for .NET 允许您为嵌入对象设置文件类型，从而更新 OLE 框架的数据或其扩展名。

下面的 C# 代码演示了如何将嵌入的 OLE 对象的文件类型设置为 `zip`：
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // 将文件类型更改为 ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **为嵌入对象设置图标图片和标题**

嵌入 OLE 对象后，会自动添加一个由图标图片组成的预览。该预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图片和文字作为预览元素，可以使用 Aspose.Slides for .NET 设置图标图片和标题。

下面的 C# 代码演示了如何为嵌入对象设置图标图片和标题：
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // 向演示文稿资源添加图像。
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // 为 OLE 预览设置标题和图像。
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **防止 OLE 对象框架被重新调整大小和重新定位**

在向演示文稿幻灯片添加链接的 OLE 对象后，打开 PowerPoint 时可能会看到提示更新链接的消息。单击 “Update Links” 按钮可能会改变 OLE 对象框架的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。为防止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) 接口的 `UpdateAutomatic` 属性设置为 `false`：
```cs
oleFrame.UpdateAutomatic = false;
```


## **提取嵌入的文件**

Aspose.Slides for .NET 允许您按以下方式提取幻灯片中作为 OLE 对象嵌入的文件：

1. 创建包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 实例。
2. 循环遍历演示文稿中的所有形状，并访问 [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 形状。
3. 访问 OLE 对象框架中嵌入文件的数据并将其写入磁盘。

下面的 C# 代码演示了如何提取嵌入在幻灯片中的文件作为 OLE 对象：
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```


## **常见问题**

**在将幻灯片导出为 PDF/图片时，OLE 内容会被渲染吗？**

渲染的仅是幻灯片上可见的内容——图标/替代图片（预览）。“实时” OLE 内容在渲染时不会执行。如有需要，可设置自己的预览图片，以确保在导出的 PDF 中呈现预期的外观。

**如何锁定幻灯片上的 OLE 对象，使用户在 PowerPoint 中无法移动/编辑？**

锁定形状：Aspose.Slides 提供 [shape-level locks](/slides/zh/net/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外编辑和移动。

**为什么链接的 Excel 对象在打开演示文稿时会“跳动”或改变大小？**

PowerPoint 可能会刷新链接 OLE 的预览。要保持外观稳定，请遵循 [Working Solution for Worksheet Resizing](/slides/zh/net/working-solution-for-worksheet-resizing/) 的做法——要么将框架适配到范围，要么将范围缩放到固定框架并设置合适的替代图片。

**在 PPTX 格式中，链接的 OLE 对象的相对路径会被保留吗？**

在 PPTX 中不存在 “相对路径” 信息——仅有完整路径。相对路径存在于旧的 PPT 格式中。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或嵌入方式。