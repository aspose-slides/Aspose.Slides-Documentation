---
title: 使用 C++ 管理演示文稿中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/cpp/manage-ole/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理，实现 OLE 内容的无缝嵌入、更新和导出。"
---

{{% alert title="Info" color="info" %}}

OLE（对象链接与嵌入）是 Microsoft 的一项技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表，然后将该图表放置在 PowerPoint 幻灯片中。该 Excel 图表即被视为 OLE 对象。

- OLE 对象可能以图标形式出现。此时，当您双击该图标时，图表将在其关联的应用程序（Excel）中打开，或者系统会要求您选择用于打开或编辑对象的应用程序。
- OLE 对象也可能直接显示其实际内容，例如图表本身。此时，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) 允许您将 OLE 对象作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)）插入到幻灯片中。

## **在幻灯片中添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for C++ 将其嵌入为 OLE 对象框，可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 将 Excel 文件读取为字节数组。
4. 将包含字节数组及 OLE 对象其他信息的 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 添加到幻灯片。
5. 将修改后的演示文稿写入为 PPTX 文件。

下面的示例演示了如何使用 Aspose.Slides for C++ 将 Excel 文件中的图表作为 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 添加到幻灯片中。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 构造函数的第二个参数是可嵌入对象的扩展名。该扩展名使 PowerPoint 能够正确识别文件类型并选择合适的应用程序打开此 OLE 对象。
``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **添加链接 OLE 对象框**

Aspose.Slides for C++ 允许您在不嵌入数据的情况下，仅通过链接文件来添加 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)。

下面的 C++ 代码展示了如何将链接到 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 添加到幻灯片：
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **访问 OLE 对象框**

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松找到或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。
2. 使用索引获取幻灯片的引用。
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 形状。  
   在我们的示例中，我们使用之前创建的只在第一页上有一个形状的 PPTX。然后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)，这就是我们想要访问的 OLE 对象框。
4. 一旦访问到 OLE 对象框，您就可以对其执行任何操作。

下面的示例演示了如何访问 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）以及其文件数据。
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 获取嵌入的文件数据。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 获取嵌入文件的扩展名。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```


### **访问链接 OLE 对象框属性**

Aspose.Slides 允许您访问链接 OLE 对象框的属性。

下面的 C++ 代码展示了如何检查 OLE 对象是否为链接状态，以及获取链接文件的路径：
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 检查 OLE 对象是否已链接。
    if (oleFrame->get_IsObjectLink())
    {
        // 打印链接文件的完整路径。
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 如有，则打印链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```


## **更改 OLE 对象数据**

{{% alert color="primary" %}} 

本节中的代码示例使用 [Aspose.Cells for C++](/cells/cpp/)。

{{% /alert %}}

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松访问该对象并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例来加载包含嵌入 OLE 对象的演示文稿。
2. 通过索引获取幻灯片的引用。 
3. 访问 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 形状。  
   在我们的示例中，我们使用之前创建的在第一页上只有一个形状的 PPTX。然后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)，这就是我们想要访问的 OLE 对象框。
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。
5. 创建 `Workbook` 对象并访问 OLE 数据。
6. 访问目标 `Worksheet` 并修改数据。
7. 将更新后的 `Workbook` 保存到流中。
8. 从流中更改 OLE 对象的数据。

下面的示例演示了如何访问嵌入在幻灯片中的 OLE 对象框（Excel 图表对象），并修改其文件数据以更新图表数据。
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// 获取第一个形状作为 OLE 对象框。
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // 将 OLE 对象数据读取为 Workbook 对象。
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // 修改工作簿数据。
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // 更改 OLE 框对象数据。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for C++ 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击该对象时，它会自动在相应程序中打开，或提示用户选择合适的程序打开它。

下面的 C++ 代码展示了如何将 HTML 和 ZIP 嵌入到幻灯片中：
``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for C++ 允许您为嵌入对象设置文件类型，从而更新 OLE 框的数据或其扩展名。

下面的 C++ 代码展示了如何将嵌入的 OLE 对象的文件类型设置为 `zip`：
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// 将文件类型更改为 ZIP。
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **为嵌入对象设置图标图片和标题**

嵌入 OLE 对象后，系统会自动添加一个由图标图片组成的预览。这是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图片和文字作为预览元素，可以使用 Aspose.Slides for C++ 设置图标图片和标题。

下面的 C++ 代码展示了如何为嵌入对象设置图标图片和标题：
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// 将图像添加到演示文稿资源中。
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// 为 OLE 预览设置标题和图像。
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **防止 OLE 对象框被重新调整大小和重新定位**

在向演示文稿幻灯片添加链接 OLE 对象后，打开 PowerPoint 时可能会出现提示更新链接的消息。单击 “Update Links” 按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。要阻止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) 接口的 `set_UpdateAutomatic` 方法设为 `false`：
```cpp
oleFrame->set_UpdateAutomatic(false);
```


## **提取嵌入的文件**

Aspose.Slides for C++ 允许您按以下方式提取幻灯片中作为 OLE 对象嵌入的文件：

1. 创建包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类实例。
2. 遍历演示文稿中的所有形状，访问其中的 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 形状。
3. 从 OLE 对象框中获取嵌入文件的数据，并写入磁盘。

下面的 C++ 代码展示了如何提取幻灯片中作为 OLE 对象嵌入的文件：
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```


## **FAQ**

**将 OLE 内容导出为 PDF/图片时会被渲染吗？**

渲染的是幻灯片上可见的内容——图标/替代图片（预览）。“实时” OLE 内容在渲染过程中不会执行。如有需要，可自行设置预览图片，以确保导出 PDF 时的外观符合预期。

**如何锁定幻灯片上的 OLE 对象，使用户在 PowerPoint 中无法移动或编辑？**

锁定形状：Aspose.Slides 提供了[形状级别的锁定](/slides/zh/cpp/applying-protection-to-presentation/)。这不是加密，但可有效防止意外编辑和移动。

**为什么链接的 Excel 对象在打开演示文稿时会“跳动”或改变大小？**

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定外观，请遵循[工作表大小调整的解决方案](/slides/zh/cpp/working-solution-for-worksheet-resizing/)——要么将框适配到范围，要么将范围缩放到固定框并设置合适的替代图片。

**PPTX 格式会保留链接 OLE 对象的相对路径吗？**

在 PPTX 中不存在 “相对路径” 信息——仅存储完整路径。相对路径仅在旧的 PPT 格式中出现。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或直接嵌入。