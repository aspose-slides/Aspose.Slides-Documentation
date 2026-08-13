---
title: 使用 C++ 在演示文稿中管理 OLE
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
description: "使用 Aspose.Slides for C++ 优化在 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。实现 OLE 内容的嵌入、更新和无缝导出。"
---
## **介绍**

{{% alert title="Info" color="info" %}}

OLE（对象链接与嵌入）是微软技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入方式放置到另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可能显示为图标。在这种情况下，双击图标时，图表将在其关联的应用程序（Excel）中打开，或系统会提示您选择用于打开或编辑对象的应用程序。
- OLE 对象也可能直接显示其实际内容，例如图表的内容。这时，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。

[Aspose.Slides for C++](https://products.aspose.com/slides/zh/cpp/) 允许您将 OLE 对象插入幻灯片作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/)）。

## **在幻灯片中添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了一个图表，并希望使用 Aspose.Slides for C++ 将其作为 OLE 对象框嵌入到幻灯片中，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 将 Excel 文件读取为字节数组。
4. 将 [OleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/) 添加到幻灯片中，包含字节数组及其他 OLE 对象信息。
5. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for C++ 将来自 Excel 文件的图表作为 [OleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/) 添加到幻灯片中。**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 构造函数将可嵌入对象的扩展名作为第二个参数。此扩展名使 PowerPoint 能够正确解释文件类型并选择适当的应用程序来打开此 OLE 对象。

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// 为 OLE 对象准备数据。
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// 将 OLE 对象框添加到幻灯片。
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **添加链接的 OLE 对象框**

Aspose.Slides for C++ 允许您添加一个不嵌入数据、仅通过文件链接的 [OleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/)。

以下 C++ 代码演示如何将带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/) 添加到幻灯片：

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **访问 OLE 对象框**

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松查找或访问它：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例，加载包含已嵌入 OLE 对象的演示文稿。
2. 使用索引获取幻灯片的引用。
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/) 形状。 在我们的示例中，我们使用先前创建的 PPTX，它在第一张幻灯片上只有一个形状。然后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleobjectframe/)。这就是要访问的 OLE 对象框。
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 获取嵌入文件的数据。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 获取嵌入文件的扩展名。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **访问链接的 OLE 对象框属性**

Aspose.Slides 允许您访问链接的 OLE 对象框属性。

以下 C++ 代码演示如何检查 OLE 对象是否为链接，并获取链接文件的路径：

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 检查 OLE 对象是否为链接。
    if (oleFrame->get_IsObjectLink())
    {
        // 打印链接文件的完整路径。
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 如果存在，打印链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **更改 OLE 对象数据**

{{% alert color="info" %}} 

在本节中，下面的代码示例使用 [Aspose.Cells for C++](/cells/cpp/)。

{{% /alert %}}

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松访问该对象并修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例，加载包含已嵌入 OLE 对象的演示文稿。
2. 通过索引获取幻灯片的引用。 
3. 访问 [OLEObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/oleobjectframe/) 形状。 在我们的示例中，我们使用先前创建的 PPTX，它在第一张幻灯片上有一个形状。然后将该对象 *强制转换* 为 [IOleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleobjectframe/)。这就是要访问的 OLE 对象框。
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。
5. 创建 `Workbook` 对象并访问 OLE 数据。
6. 访问所需的 `Worksheet` 并修改数据。
7. 在流中保存更新后的 `Workbook`。
8. 从流中更改 OLE 对象数据。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），并修改其文件数据以更新图表数据。

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 在使用任何 Aspose.Cells 类型之前，必须启动 Aspose.Cells for C++。
Aspose::Cells::Startup();

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

    // 更改 OLE 框对象的数据。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for C++ 允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相关程序中打开，或提示用户选择合适的程序来打开它。

以下 C++ 代码演示如何将 HTML 和 ZIP 嵌入幻灯片：

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

在处理演示文稿时，您可能需要用新对象替换旧的 OLE 对象，或用受支持的对象替换不受支持的 OLE 对象。Aspose.Slides for C++ 允许您设置嵌入对象的文件类型，从而更新 OLE 框数据或其扩展名。

以下 C++ 代码演示如何将嵌入的 OLE 对象的文件类型设置为 `zip`：

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **为嵌入对象设置图标图像和标题**

嵌入 OLE 对象后，会自动添加由图标图像组成的预览。此预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想在预览中使用特定的图像和文本，可以使用 Aspose.Slides for C++ 设置图标图像和标题。

以下 C++ 代码演示如何为嵌入对象设置图标图像和标题：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **防止 OLE 对象框被重新调整大小和重新定位**

在将链接的 OLE 对象添加到演示文稿幻灯片后，如果在 PowerPoint 中打开演示文稿，可能会看到一个提示更新链接的消息。单击 “Update Links” 按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。要阻止 PowerPoint 提示更新对象数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleobjectframe/) 接口的 `set_UpdateAutomatic` 方法设为 `false`：

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **提取嵌入的文件**

Aspose.Slides for C++ 允许您按以下方式提取嵌入在幻灯片中作为 OLE 对象的文件：

1. 创建一个包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类实例。
2. 遍历演示文稿中的所有形状，访问 [OLEObjectFrame] 形状。
3. 从 OLE 对象框获取嵌入文件的数据并写入磁盘。

以下 C++ 代码演示如何提取嵌入在幻灯片中的文件作为 OLE 对象：

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

## **常见问题**

### 导出幻灯片为 PDF/图像时，OLE 内容会被渲染吗？

幻灯片上可见的内容会被渲染——即图标/替代图像（预览）。在渲染过程中不会执行 “实时” OLE 内容。如有需要，请设置您自己的预览图像，以确保导出的 PDF 中出现预期的外观。

### 如何锁定幻灯片上的 OLE 对象，使用户无法在 PowerPoint 中移动/编辑它？

锁定形状：Aspose.Slides 提供 [shape-level locks](/slides/zh/cpp/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外编辑和移动。

### 为什么在打开演示文稿时，链接的 Excel 对象会“跳动”或改变大小？

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定的外观，请遵循 [Working Solution for Worksheet Resizing](/slides/zh/cpp/working-solution-for-worksheet-resizing/) 的做法——要么将框架适配到范围，要么将范围缩放到固定框架并设置合适的替代图像。

### 在 PPTX 格式中，链接的 OLE 对象的相对路径会被保留吗？

在 PPTX 中不提供 “相对路径” 信息——仅有完整路径。相对路径出现在较旧的 PPT 格式中。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或进行嵌入。