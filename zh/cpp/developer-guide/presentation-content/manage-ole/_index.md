---
title: 管理 OLE
type: docs
weight: 40
url: /zh/cpp/manage-ole/
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
- C++
- Aspose.Slides for C++
description: 在 C++ 中将 OLE 对象添加到 PowerPoint 演示文稿中
---

{{% alert title="信息" color="info" %}}

OLE (对象链接与嵌入) 是一种 Microsoft 技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入被放置在另一个应用程序中。 

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。 

- OLE 对象可能显示为图标。在这种情况下，当您双击图标时，图表会在其关联的应用程序（Excel）中打开，或者会要求您选择一个应用程序以打开或编辑对象。 
- OLE 对象可能显示实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中激活，图表界面加载，您可以在 PowerPoint 应用程序中修改图表的数据。

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) 允许您将 OLE 对象插入幻灯片作为 OLE 对象框 ([OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame))。



## **向幻灯片添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了一个图表，并想将该图表作为 OLE 对象框嵌入到幻灯片中，您可以这样做：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 打开包含 Excel 图表对象的 Excel 文件并将其保存到 `MemoryStream`。
4. 向包含 OLE 对象的字节数组和其他信息的幻灯片中添加 [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)。
5. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for C++ 将来自 Excel 文件的图表添加到幻灯片中，作为 [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)。  
**注意**， [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) 构造函数的第二个参数是一个可嵌入对象扩展名。此扩展名允许 PowerPoint 正确解释文件类型并选择正确的应用程序来打开此 OLE 对象。

``` cpp
// 文档目录的路径。
String dataDir = u"";
// 实例化表示 PPTX 的 Presentation 类
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// 加载 Excel 文件到流
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// 创建用于嵌入的数据对象
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// 添加 Ole 对象框形状
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// 将 PPTX 文件写入磁盘
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **访问 OLE 对象框**
如果 OLE 对象已经嵌入到幻灯片中，您可以通过以下方式轻松找到或访问该对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。

2. 通过其索引获取幻灯片的引用。

3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) 形状。

   在我们的示例中，我们使用了之前创建的 PPTX，该 PPTX 的第一张幻灯片上只有一个形状。然后，我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)。这是要访问的所需 OLE 对象框。

4. 一旦访问了 OLE 对象框，您可以对其进行任何操作。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）——然后其文件数据被写入到 Excel 文件中：

``` cpp
// 文档目录的路径。
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 将形状强制转换为 OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// 读取 OLE 对象并写入磁盘
if (oleObjectFrame != nullptr)
{
    // 获取嵌入的文件数据
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // 获取嵌入的文件扩展名
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // 创建用于保存提取文件的路径
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // 保存提取的数据
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **更改 OLE 对象数据**
如果 OLE 对象已经嵌入到幻灯片中，您可以轻松访问该对象并以这种方式修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例打开包含嵌入 OLE 对象的演示文稿。

2. 通过其索引获取幻灯片的引用。 

3. 访问 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) 形状。

   在我们的示例中，我们使用了之前创建的 PPTX，该 PPTX 的第一张幻灯片上有一个形状。然后，我们将该对象 *强制转换* 为 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)。这是要访问的所需 OLE 对象框。

4. 一旦访问了 OLE 对象框，您可以对其进行任何操作。

5. 创建工作簿对象并访问 OLE 数据。

6. 访问所需的工作表并修改数据。

7. 在流中保存更新的工作簿。

8. 从流数据更改 OLE 对象数据。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）——然后其文件数据被修改以更改图表数据：

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // 遍历所有形状以查找 Ole 框
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // 在工作簿中读取对象数据
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // 修改工作簿数据
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // 更改 Ole 框对象数据
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## 在幻灯片中嵌入其他文件类型

除了 Excel 图表，Aspose.Slides for C++ 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入到幻灯片中。当用户双击嵌入的对象时，该对象会自动在相关程序中启动，或者用户会被引导选择一个合适的程序来打开该对象。 

以下 C++ 代码展示了如何在幻灯片中嵌入 HTML 和 ZIP：

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## 为嵌入对象设置文件类型

在处理演示文稿时，您可能需要用新对象替换旧的 OLE 对象。或者您可能需要用一个受支持的对象替换一个不受支持的 OLE 对象。 

Aspose.Slides for C++ 允许您为嵌入对象设置文件类型。通过这种方式，您可以更改 OLE 框数据或其扩展名。 

以下 C++ 代码展示了如何为嵌入的 OLE 对象设置文件类型：

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"当前嵌入数据扩展名为: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## 为嵌入对象设置图标图像和标题

在您嵌入 OLE 对象之后，预览图标图像和标题将自动添加。预览是用户在访问或打开 OLE 对象之前看到的内容。 

如果您想使用特定的图像和文本作为预览中的元素，可以使用 Aspose.Slides for C++ 设置图标图像和标题。

以下 C++ 代码展示了如何为嵌入对象设置图标图像和标题： 

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"我的标题");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **防止 OLE 对象框被调整大小和重新定位**

在您将链接的 OLE 对象添加到演示文稿幻灯片后，当您在 PowerPoint 中打开演示文稿时，您可能会看到一个提示要求您更新链接。单击“更新链接”按钮可能会更改 OLE 对象框的大小和位置，因为 PowerPoint 更新来自链接 OLE 对象的数据并刷新对象预览。要防止 PowerPoint 提示更新对象的数据，请将 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) 接口的 `set_UpdateAutomatic` 方法设置为 `false`：

```cpp
oleObjectFrame->set_UpdateAutomatic(false);
```

## 提取嵌入的文件

Aspose.Slides for C++ 允许您通过以下方式提取嵌入在幻灯片中作为 OLE 对象的文件：

1. 创建一个包含您打算提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 遍历演示文稿中的所有形状并访问 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) 形状。
3. 从 OLE 对象框中访问嵌入文件的数据并将其写入磁盘。 

以下 C++ 代码展示了如何提取作为 OLE 对象嵌入在幻灯片中的文件：

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```