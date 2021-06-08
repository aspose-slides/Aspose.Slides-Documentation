---
title: Image
type: docs
weight: 10
url: /cpp/image/
---


## **Adding EMZ Images to Images Collection**
Aspose.Slides for C++ allows you to embed EMZ (Windows Compressed Enhanced Metafile) files in a presentation images collection. 

EMZ files are compressed image files commonly used in Microsoft Office programs. They typically contain  EMF (Enhanced Metafile) files. Normally, you can decompress an EMZ file and get an EMF file from it. 


This sample code shows you how to add an EMZ image to the images collection:

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

if (slide != nullptr)
{
    System::ArrayPtr<uint8_t> bufferData = File::ReadAllBytes(u"image.emz");
    
    System::SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(bufferData);
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), imgx);
    
    pres->Save(u"Presentation_Saved.pptx", SaveFormat::Pptx);
}
```

## **Inserting/Adding SVG into Presentations**
You can add or insert any image into a presentation by using the [AddPictureFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) method that belongs to the [IShapeCollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) interface.

To create an image object based on SVG image, you can do it this way:

1. Create SvgImage object to insert it to ImageShapeCollection
2. Create PPImage object from ISvgImage
3. Create PictureFrame object using IPPImage interface

This sample code shows you how to implement the steps above to add an SVG image into a presentation:
``` cpp 
// The path to the documents directory
System::String dataDir = u"D:\\Documents\\";

// Source SVG file name
System::String svgFileName = dataDir + u"sample.svg";

// Output presentation file name
System::String outPptxPath = dataDir + u"presentation.pptx";

// Create new presentation
auto p = System::MakeObject<Presentation>();

// Read SVG file content
System::String svgContent = File::ReadAllText(svgFileName);

// Create SvgImage object
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Create PPImage object
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Creates a new PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Save presentation in PPTX format
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Converting SVG to a Set of Shapes**
Aspose.Slides' conversion of SVG to a set of shapes is similar to the PowerPoint functionality used to work with SVG images:


![PowerPoint Popup Menu](img_01_01.png)

The functionality is provided by one of the overloads of the [AddGroupShape](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) method of the [IShapeCollection](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) interface that takes an [ISvgImage](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) object as the first argument.

This sample code shows you how to use the described method to convert an SVG file to a set of shapes:

``` cpp 
// The path to the documents directory
System::String dataDir = u"D:\\Documents\\";

// Source SVG file name
System::String svgFileName = dataDir + u"sample.svg";

// Output presentation file name
System::String outPptxPath = dataDir + u"presentation.pptx";

// Create new presentation
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Read SVG file content
System::String svgContent = File::ReadAllText(svgFileName);

// Create SvgImage object
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Get slide size
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Convert SVG image to group of shapes scaling it to slide size
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Save presentation in PPTX format
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Adding Images as EMF in Slides**
Aspose.Slides for C++ allows you to generate EMF images from excel sheets and add the images as EMF in slides with Aspose.Cells. 

This sample code shows you how to perform the described task:

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
