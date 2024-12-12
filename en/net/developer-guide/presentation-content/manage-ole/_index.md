---
title: Manage OLE
type: docs
weight: 40
url: /net/manage-ole/
keywords:
- OLE object
- Object Linking & Embedding
- add OLE
- embed OLE
- add an object
- embed an object
- embed a file
- linked object
- change OLE
- OLE icon
- OLE title
- extact OLE
- extract an object
- PowerPoint 
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: Manage OLE objects in PowerPoint presentations in C# or .NET
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display its actual contents, such as the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Adding OLE Object Frames to Slides**

Assuming you have already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for .NET, you can do it this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get a slide's reference through its index.
3. Read the Excel file as a byte array.
4. Add the [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) to the slide containing the byte array and other information about the OLE object.
5. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) using Aspose.Slides for .NET.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Prepare data for the OLE object.
    byte[] oleData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xlsx");

    // Add the OLE object frame to the slide.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Adding Linked OLE Object Frames**

Aspose.Slides for .NET allows you to add an [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) without embedding data but only with a link to the file.

This C# code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) with a linked Excel file to a slide:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Add an OLE object frame with a linked Excel file.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Accessing OLE Object Frames**

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get the reference of the slide by using its index.
3. Access the [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) shape.
   In our example, we used the previously created PPTX that has only one shape on the first slide.  We then *cast* that object as an [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). This was the desired OLE object frame to be accessed.
4. Once the OLE object frame is accessed, you can perform any operation on it.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Get the first shape as an OLE object frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Get the embedded file data.
        byte[] oleData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Get the extention of the embedded file.
        string fileExtention = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Accessing Linked OLE Object Frame Properties**

Aspose.Slides allows you to access linked OLE object frame properties.

This C# code shows you how to check if an OLE object is linked and then obtain the path to the linked file:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Get the first shape as an OLE object frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Check if the OLE object is linked.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Print the full path to the linked file.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Print the relative path to the linked file if present.
        // Only the PPT presentations can contain the relative path.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Changing OLE Object Data**

{{% alert color="primary" %}} 

In this section, the code example below uses [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get the slide's reference through its index. 
3. Access the [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) shape.
   In our example, we used the previously created PPTX that has one shape on the first slide. We then *cast* that object as an [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). This was the desired OLE object frame to be accessed.
4. Once the OLE object frame is accessed, you can perform any operation on it.
5. Create a `Workbook` object and access the OLE data.
6. Access the desired `Worksheet` and amend the data.
7. Save the updated `Workbook` in a stream.
8. Change the OLE object data from the stream.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) is accessed, and its file data is modified to update the chart data.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Get the first shape as an OLE object frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Read the OLE object data as a Workbook object.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modify the workbook data.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Change the OLE frame object data.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Embedding Other File Types in Slides**

Besides Excel charts, Aspose.Slides for .NET allows you to embed other types of files into slides. For example, you can insert HTML, PDF, and ZIP files as objects. When a user double-clicks the inserted object, it automatically opens in the relevant program, or the user is prompted to select an appropriate program to open it.

This C# code shows you how to embed HTML and ZIP into a slide:

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

## **Setting File Types for Embedded Objects**

When working with presentations, you may need to replace old OLE objects with new ones or replace an unsupported OLE object with a supported one. Aspose.Slides for .NET allows you to set the file type for an embedded object, enabling you to update the OLE frame data or its extension.

This C# code shows you how to set the file type for an embedded OLE object to `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] oleData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded data extension is: {fileExtension}");

    // Change the file type to ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(oleData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Setting Icon Images and Titles for Embedded Objects**

After embedding an OLE object, a preview consisting of an icon image is added automatically. This preview is what users see before accessing or opening the OLE object. If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for .NET.

This C# code shows you how to set the icon image and title for an embedded object: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Add an image to the presentation resources.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Set a title and the image for the OLE preview.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

After you add a linked OLE object to a presentation slide, when you open the presentation in PowerPoint, you might see a message asking you to update the links. Clicking the "Update Links" button may change the size and position of the OLE object frame because PowerPoint updates the data from the linked OLE object and refreshes the object preview. To prevent PowerPoint from prompting to update the object's data, set the `UpdateAutomatic` property of the [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) interface to `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Extracting Embedded Files**

Aspose.Slides for .NET allows you to extract the files embedded in slides as OLE objects this way:
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the OLE objects you intend to extract.
2. Loop through all the shapes in the presentation and access the [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) shapes.
3. Access the data of embedded files from OLE object frames and write it to disk.

This C# code shows you how to extract files embedded in a slide as OLE objects:

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
