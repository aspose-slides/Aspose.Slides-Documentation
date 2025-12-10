---
title: 使用 C++ 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/cpp/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- EMF
- SVG
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并实现工作流自动化。"
---

## **演示文稿幻灯片中的图像**

图像使演示文稿更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以将来自文件、互联网或其他位置的图片插入到幻灯片中。同样，Aspose.Slides 也允许您通过不同的方式向演示文稿的幻灯片添加图像。

{{% alert title="提示" color="primary" %}} 
Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——可让用户快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="信息" color="info" %}}
如果您想将图像作为框架对象添加——尤其是计划对其使用标准格式选项来更改大小、添加效果等——请参阅 [图片框](/slides/zh/cpp/picture-frame/)。 
{{% /alert %}} 

{{% alert title="注意" color="warning" %}}
您可以操作涉及图像和 PowerPoint 演示文稿的输入/输出，以将图像从一种格式转换为另一种格式。请参阅以下页面：将 [图像转 JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/) 转换；将 [JPG 转 图像](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/) 转换；将 [JPG 转 PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/) 转换，将 [PNG 转 JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/) 转换；将 [PNG 转 SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/) 转换，将 [SVG 转 PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/) 转换。 
{{% /alert %}}

Aspose.Slides 支持对这些常用格式的图像进行操作：JPEG、PNG、GIF 等。

## **向幻灯片添加本地存储的图像**

您可以添加一张或多张计算机上的图像到演示文稿的幻灯片中。以下 C++ 示例代码演示如何向幻灯片添加图像：
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **从网络向幻灯片添加图像**

如果您想添加到幻灯片的图像在计算机上不可用，您可以直接从网络添加该图像。以下 C++ 示例代码演示如何从网络向幻灯片添加图像：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **向母版幻灯片添加图像**

幻灯片母版是位于顶部的幻灯片，用于存储和控制其下所有幻灯片的信息（主题、布局等）。因此，当您向幻灯片母版添加图像时，该图像会出现在该母版下的每张幻灯片上。以下 C++ 示例代码演示如何向幻灯片母版添加图像：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **将图像设为幻灯片背景**

您可能决定将图片作为特定幻灯片或多张幻灯片的背景。在这种情况下，请参阅 *[将图像设为幻灯片背景](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG**

您可以使用属于 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口的 [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法向演示文稿添加或插入任何图像。要基于 SVG 图像创建图像对象，可以按以下方式操作：

1. 创建 SvgImage 对象并将其插入到 ImageShapeCollection 中
2. 从 ISvgImage 创建 PPImage 对象
3. 使用 IPPImage 接口创建 PictureFrame 对象

以下示例代码演示如何实现上述步骤，以将 SVG 图像添加到演示文稿中：
``` cpp 
// 文档目录的路径
System::String dataDir = u"D:\\Documents\\";

// 源 SVG 文件名
System::String svgFileName = dataDir + u"sample.svg";

// 输出演示文稿文件名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 创建新演示文稿
auto p = System::MakeObject<Presentation>();

// 读取 SVG 文件内容
System::String svgContent = File::ReadAllText(svgFileName);

// 创建 SvgImage 对象
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 创建 PPImage 对象
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// 创建新的 PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// 将演示文稿保存为 PPTX 格式
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **将 SVG 转换为形状集合**

Aspose.Slides 将 SVG 转换为形状集合的功能类似于 PowerPoint 用于处理 SVG 图像的功能：

![PowerPoint Popup Menu](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口的 [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) 方法的其中一个重载提供，该重载以 [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) 对象作为第一个参数。以下示例代码演示如何使用上述方法将 SVG 文件转换为形状集合：
``` cpp 
// 文档目录的路径
System::String dataDir = u"D:\\Documents\\";

// 源 SVG 文件名
System::String svgFileName = dataDir + u"sample.svg";

// 输出演示文稿文件名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 创建新演示文稿
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// 读取 SVG 文件内容
System::String svgContent = File::ReadAllText(svgFileName);

// 创建 SvgImage 对象
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 获取幻灯片尺寸
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// 将 SVG 图像转换为形状组，按幻灯片尺寸进行缩放
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// 将演示文稿保存为 PPTX 格式
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **将图像作为 EMF 添加到幻灯片**

Aspose.Slides for C++ 允许您从 Excel 工作表生成 EMF 图像，并使用 Aspose.Cells 将这些图像作为 EMF 添加到幻灯片中。以下示例代码演示如何完成上述任务：
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```


## **替换图像集合中的图像**

Aspose.Slides 允许您替换存储在演示文稿图像集合中的图像（包括幻灯片形状使用的图像）。本节展示了更新集合中图像的多种方法。API 提供了使用原始字节数据、[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) 实例或集合中已存在的另一图像来替换图像的直接方法。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。
2. 将新图像从文件加载到字节数组中。
3. 使用字节数组将目标图像替换为新图像。
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) 对象中并使用该对象替换目标图像。
5. 在第三种方法中，将目标图像替换为演示文稿图像集合中已经存在的图像。
6. 将修改后的演示文稿写入为 PPTX 文件。
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 第一种方法。
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 第二种方法。
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 第三种方法。
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// 将演示文稿保存到文件。
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="信息" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松为文本添加动画、从文本创建 GIF 等。 
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素被保留，但最终显示效果取决于在幻灯片上如何缩放 [图片](/slides/zh/cpp/picture-frame/) 以及保存时是否进行压缩。

**一次性在数十张幻灯片中替换相同徽标的最佳方法是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中进行替换——更新将传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为形状组，随后各个部件即可使用标准形状属性进行编辑。

**如何一次性将图片设置为多张幻灯片的背景？**

在母版幻灯片或相应布局上 [将图像指定为背景](/slides/zh/cpp/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因大量图片导致演示文稿尺寸“膨胀”？**

重复使用单一图像资源而非副本，选择合理的分辨率，保存时进行压缩，并在适当情况下将重复图形放在母版上。