---
title: 图像
type: docs
weight: 10
url: /cpp/image/
---


## **演示文稿中的幻灯片图像**

图像使演示文稿更加吸引人和有趣。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他位置将图片插入到幻灯片中。同样，Aspose.Slides 允许您通过不同的过程在演示文稿中的幻灯片中添加图像。

{{% alert title="提示" color="primary" %}} 

Aspose 提供免费的转换器—[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—可以让人们快速从图像创建演示文稿。

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为框架对象添加—尤其是如果您计划使用标准格式选项来更改其大小、添加效果等—请参见 [图片框](/slides/cpp/picture-frame/)。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以操作与图像和 PowerPoint 演示文稿相关的输入/输出操作，将图像从一种格式转换为另一种格式。请查看这些页面：转换 [图像到 JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)；转换 [JPG 到图像](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)；转换 [JPG 到 PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)，转换 [PNG 到 JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)；转换 [PNG 到 SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)，转换 [SVG 到 PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides 支持使用以下流行格式的图像操作：JPEG、PNG、GIF 等。

## **将本地存储的图像添加到幻灯片中**

您可以将计算机上的一个或多个图像添加到演示文稿中的幻灯片上。以下 C++ 示例代码演示了如何将图像添加到幻灯片：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **将网络上的图像添加到幻灯片中**

如果您想要添加到幻灯片的图像在计算机上不可用，您可以直接从网络添加图像。

以下示例代码演示了如何将网络上的图像添加到 C++ 幻灯片中：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **将图像添加到幻灯片母版**

幻灯片母版是存储和控制其下所有幻灯片信息（主题、布局等）的顶级幻灯片。因此，当您将图像添加到幻灯片母版时，该图像会出现在该幻灯片母版下的每一张幻灯片上。

以下 C++ 示例代码演示了如何将图像添加到幻灯片母版：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **将图像添加为幻灯片背景**

您可能决定使用图片作为特定幻灯片或多个幻灯片的背景。在这种情况下，您需要查看 *[将图像设置为幻灯片背景](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 插入/添加到演示文稿中**
您可以通过使用属于 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口的 [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法，将任何图像添加或插入到演示文稿中。

要基于 SVG 图像创建图像对象，您可以这样做：

1. 创建SvgImage对象以将其插入到ImageShapeCollection中
2. 从ISvgImage创建PPImage对象
3. 使用IPPImage接口创建PictureFrame对象

以下示例代码演示了如何实现上述步骤以将 SVG 图像添加到演示文稿中：
``` cpp 
// 文档目录的路径
System::String dataDir = u"D:\\Documents\\";

// 源 SVG 文件名
System::String svgFileName = dataDir + u"sample.svg";

// 输出演示文稿文件名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 创建新的演示文稿
auto p = System::MakeObject<Presentation>();

// 读取 SVG 文件内容
System::String svgContent = File::ReadAllText(svgFileName);

// 创建 SvgImage 对象
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 创建 PPImage 对象
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// 创建新的 PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// 以 PPTX 格式保存演示文稿
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **将 SVG 转换为一组形状**
Aspose.Slides 将 SVG 转换为一组形状的功能类似于用于处理 SVG 图像的 PowerPoint 功能：

![PowerPoint 弹出菜单](img_01_01.png)

该功能由 [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 接口的 [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) 方法的重载之一提供，该方法将 [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) 对象作为第一个参数。

以下示例代码演示了如何使用描述的方法将 SVG 文件转换为一组形状：

``` cpp 
// 文档目录的路径
System::String dataDir = u"D:\\Documents\\";

// 源 SVG 文件名
System::String svgFileName = dataDir + u"sample.svg";

// 输出演示文稿文件名
System::String outPptxPath = dataDir + u"presentation.pptx";

// 创建新的演示文稿
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// 读取 SVG 文件内容
System::String svgContent = File::ReadAllText(svgFileName);

// 创建 SvgImage 对象
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 获取幻灯片大小
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// 将 SVG 图像转换为形状组，并将其缩放到幻灯片大小
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// 以 PPTX 格式保存演示文稿
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **将图像添加为幻灯片中的 EMF**
Aspose.Slides for C++ 允许您从 Excel 表生成 EMF 图像，并将图像作为 EMF 添加到幻灯片中与 Aspose.Cells。

以下示例代码演示了如何执行上述任务：

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

// 将工作簿保存到流中
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

{{% alert title="信息" color="info" %}}

使用 Aspose 免费的 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器，您可以轻松地为文本添加动画，创建 GIF 等。

{{% /alert %}}