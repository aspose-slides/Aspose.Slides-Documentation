---
title: Manage OLE
type: docs
weight: 40
url: /cpp/manage-ole/
keywords: "Add OLE, Add object, Embed object Object Linking & Embedding, OLE Object Frame, Embed OLE, PowerPoint presentation, C++, CPP, Aspose.Slides for C++ "
description: "Add OLE object to PowerPoint presentation in C++"
---

{{% alert title="Info" color="info" %}}

OLE  (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display actual contents—for example, the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint app.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) allows you to insert OLE Objects into slides as OLE Object Frames ([OleObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)).



## **Adding OLE Object Frames to Slides**

Assuming you already created a chart in Microsoft Excel and want to embed that chart in a slide as an OLE Object Frame using Aspose.Slides for C++, you can do it this way:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Get a slide's reference through its index.
3. Open the Excel file containing the Excel chart object and save it to `MemoryStream`.
4. Add the [OleObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) to the slide containing the array of bytes and other information about the OLE object.
5. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an [OleObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) using Aspose.Slides for C++.  
**Note** that the [IOleEmbeddedDataInfo](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

``` cpp
// The path to the documents directory.
String dataDir = u"";
// Instantiates the Presentation class that represents the PPTX
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accesses the the first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// Loads an excel file to stream
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

// Creates a data object for embedding
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Adds an Ole Object Frame shape
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// Writes the PPTX file to disk
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **Accessing OLE Object Frames**
If an OLE object is already embedded in a slide, you can find or access that object easily this way:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.

2. Obtain the reference of the slide by using its index.

3. Access the [OleObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) shape.

   In our example, we used the previously created PPTX that has only one shape on the first slide.  We then *cast* that object as an [OleObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). This was the desired OLE Object Frame to be accessed.

4. Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data gets written to an Excel file:

``` cpp
// The path to the documents directory.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// Loads the desired presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accesses the first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Casts the shape to OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::DynamicCast_noexcept<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// Reads the OLE Object and write it to disk
if (oleObjectFrame != nullptr)
{
    // Gets embedded file data
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // Gets embedded file extention
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // Creates path for saving the extracted file
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // Saves extracted data
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **Changing OLE Object Data**
If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Open the desired presentation with the embedded OLE Object by creating an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.

2. Get the slide's reference through its index. 

3. Access the [OLEObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) shape.

   In our example, we used the previously created PPTX that has one shape on the first slide. We then *cast* that object as an [OLEObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). This was the desired OLE Object Frame to be accessed.

4. Once the OLE Object Frame is accessed, you can perform any operation on it.

5. Create the Workbook object and access the OLE Data.

6. Access the desired Worksheet and amend the data.

7. Save the updated Workbook in streams.

8. Change the OLE object data from stream data.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data is modified to change the chart data:

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

    // Traverses all shapes for Ole frame
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::DynamicCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Reads object data in Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // Modifies the workbook data
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Changes Ole frame object data
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## Embedding Other File Types in Slides

Besides Excel charts, Aspose.Slides for C++ allows you to embed other types of files in slides. For example, you can insert HTML, PDF, and ZIP files as objects into a slide. When a user double-clicks the inserted object, the object automatically gets launched in the relevant program, or the user gets directed to select an appropriate program to open the object. 

This C++ code shows you how to embed HTML and ZIP in a slide: XXX

```c++

```

## Setting File Types for Embedded Objects

When working on presentations, you may need to replace old OLE objects with new ones. Or you may need to replace an unsupported OLE object with a supported one. 

Aspose.Slides for C++ allows you to set the file type for an embedded object. This way, you get to change the OLE frame data or its extension. 

This C++ code shows you how to set the file type for an embedded OLE object:

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

## Extracting Embedded Files

Aspose.Slides for C++ allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class containing the OLE object you intend to extract.
2. Loop through all the shapes in the presentation and access the  [OLEObjectFrame](https://apireference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) shape.
3. Access the embedded file's data from the OLE Object Frame and write it to disk. 

This C++ code shows you how to extract a file embedded in a slide as an OLE object:

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

