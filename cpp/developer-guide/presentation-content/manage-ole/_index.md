---
title: Manage OLE
type: docs
weight: 40
url: /cpp/manage-ole/
---


OLE stands for Object Linking & Embedding. It's a Microsoft technology that allows objects created in one application to be embedded in another application.

For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. 

Aspose.Slides for С++ supports inserting OLE Objects into the slide as OLE Object Frames. 
In this topic, we will work with OLE Object Frames to see how these objects can be added and manipulated via 
Aspose.Slides for С++. This article explains different examples of working with OLE Object Frames.

## **Add OLE Object Frame to Slide**
Suppose, you have created a Microsoft Excel Chart in an Excel file and want to embed that chart object in a slide as an OLE Object Frame using Aspose.Slides for C++. It can be done with the following steps:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain the reference of a slide by using its index.
1. Open the Excel file containing Microsoft Excel Chart object and save it to MemoryStream.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example given below, a Microsoft Excel Chart object in an Excel file is added to a slide as an OLE Object Frame using Aspose.Slides for C++.  
**Note** that [IOleEmbeddedDataInfo](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) 
constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly 
interpret the file type and, choose the right application to open this OLE object.
``` cpp
// The path to the documents directory.
String dataDir = u"";
// Instantiate Presentation class that represents the PPTX
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Access the first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// Load an cel file to stream
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

// Create data object for embedding
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Add an Ole Object Frame shape
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// Write the PPTX to disk
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **Access OLE Object Frame**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for C++. Please follow the steps below to find or access an OLE object from a slide:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once OLE Object Frame is accessed, you can perform any operation on it.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then all of its Object Data is written to an Excel file.

``` cpp
// The path to the documents directory.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Access the first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Cast the shape to OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::DynamicCast_noexcept<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// Read the OLE Object and write it to disk
if (oleObjectFrame != nullptr)
{
    // Get embedded file data
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // Get embedded file extention
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // Create path for saving the extracted file
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // Save extracted data
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **Change OLE Object Data**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for C++ and can 
modify its data. Please follow the steps below to find how to modify an OLE object data from a slide:

1. Open the desired presentation with embedded OLE Object by creating an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.
1. Create the Workbook object and access the OLE Data.
1. Access the desired Worksheet and amend the data.
1. Save the updated Workbook in streams.
1. Change the OLE object data from stream data.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then its file data is modified to change the chart data.

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

    // Traversing all shapes for Ole frame
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::DynamicCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Reading object data in Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // Modifying the workbook data
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Changing Ole frame object data
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## **Set File Type for Embedded Object**
Using Aspose.Slides for C++ you can set file type for an embedding object. For this purpose, new **addOleObjectFrame** and **insertOleObjectFrame** methods have been added into **IShapeCollection**.

These methods allow to get **IOleEmbeddedDataInfo** object as a parameter so now OLE object knows its type and PowerPoint can open created OLE objects.

The following example shows how to set file type for an embedding object:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::DynamicCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"Current embedded data extension is: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## Setting Icon Images and Titles for Embedded Objects

After you embed an OLE object, a preview consisting of an icon image and title gets added automatically. The preview is what users see before they access or open the OLE object. 

If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for C++. 

This C++ code shows you how to set the icon image and title for an embedded object: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::DynamicCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"My title");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **Extract Embedded Files from OLE Object**
Aspose.Slides for C++ supports extracting embedded files from OLE Object. In order to extract embedded files, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class and Load a presentation containing OLE Object.
- Loop through all the shapes in a presentation and access the OLE Object Frame shape.
- Access the data of the Embedded file from OLE Object Frame and write it to disk.

The implementation of the above steps is demonstrated in the example below.

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::DynamicCast_noexcept<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```

