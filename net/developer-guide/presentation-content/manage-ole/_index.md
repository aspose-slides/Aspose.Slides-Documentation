---
title: Manage OLE
type: docs
weight: 232
url: /net/manage-ole/
---

{{% alert color="primary" %}} 

OLE  (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display actual contents—for example, the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint app. 

Aspose.Slides for .NET allows you to insert OLE Objects into slides as OLE Object Frames. In this topic, we will show you how to work with OLE Object Frames. You will learn how to add and manipulate OLE objects. 

## **Adding OLE Object Frames to Slides**
Assuming you already created a chart in Microsoft Excel and want to embed that chart in a slide as an OLE Object Frame using Aspose.Slides for .NET, you can do it this way:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of the slide by using its index.
1. Open the Excel file containing the Excel chart object and save it to MemoryStream.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an OLE Object Frame using Aspose.Slides for .NET.  
**Note** that the [IOleEmbeddedDataInfo](https://apireference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

``` csharp 
// Instantiate the Presentation class that represents the PPTX
using (Presentation pres = new Presentation())
{
    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Load an excel file to stream
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // Create a data object for embedding
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // Add an Ole Object Frame shape
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    //Write the PPTX to disk
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
## **Accessing OLE Object Frames**
If an OLE object is already embedded in a slide, you can find or access that object easily using Aspose.Slides for .NET this way:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.

1. Obtain the reference of the slide by using its index.

1. Access the OLE Object Frame shape.

   In our example, we used the previously created PPTX, which has only one shape on the first slide.  We then *cast* that object as an [OleObjectFrame](https://apireference.aspose.com/slides/net/aspose.slides/oleobjectframe). This was the desired OLE Object Frame to be accessed.

1. Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data gets written to an Excel file.

``` csharp 
// Load the PPTX to Presentation object
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Cast the shape to OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // Read the OLE Object and write it to disk
    if (oleObjectFrame != null)
    {
        // Get embedded file data
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // Get embedded file extention
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // Create a path to save the extracted file
        string extractedPath = "excelFromOLE_out" + fileExtention;

        // Save extracted data
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

## **Changing OLE Object Data**

If an OLE object is already embedded in a slide, you can easily access that object with Aspose.Slides for .NET and modify its data this way:

1. Open the desired presentation with the embedded OLE Object by creating an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.

1. Obtain the reference of the slide by using its Index.

1. Access the OLE Object Frame shape.

   In our example, we used the previously created PPTX, which has only one shape on the first slide. We then *cast* that object as an [OleObjectFrame](https://apireference.aspose.com/slides/net/aspose.slides/oleobjectframe). This was the desired OLE Object Frame to be accessed.

1. Once the OLE Object Frame is accessed, you can perform any operation on it.

1. Create the Workbook object and access the OLE Data.

1. Access the desired Worksheet and amend the data.

1. Save the updated Workbook in streams.

1. Change the OLE object data from stream data.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data is modified to change the chart data.

``` csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // Traversing all shapes for Ole frame
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // Reading object data in Workbook
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // Modifying the workbook data
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // Changing Ole frame object data
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```

## Embedding Other File Types in Slides

Besides Excel charts, Aspose.Slides for .NET allows you to embed other types of files in slides. For example, you can insert HTML, PDF, and ZIP files as objects into a slide. When a user double-clicks the inserted object, the object automatically gets launched in the relevant program, or the user gets directed to select an appropriate program to open the object. 

This sample code shows you how to embed HTML and ZIP in a slide:

```c#
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```

## Setting File Types for Embedded Objects

When working on presentations, you may need to replace old OLE objects with new ones. Or you may need to replace an unsupported OLE object with a supported one. 

Aspose.Slides for .NET allows you to set the file type for an embedded object. This way, you get to change the OLE frame data or its extension. 

This sample code shows you how to set the file type for an embedded OLE object:

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"Current embedded data extension is: {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```

## Setting Icon Images and Titles for Embedded Objects

After you embed an OLE object, a preview consisting of an icon image and title gets added automatically. The preview is what user see before they access or open the OLE object. 

If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for .NET. 

This C# code shows you how to set the icon image and title for an embedded object: 

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "My title";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```



## Extracting Embedded Files

Aspose.Slides for .NET allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the Presentation class containing the OLE object you intend to extract.
2. Loop through all the shapes in the presentation and access the OLE Object Frame shape.
3. Access the embedded file's data from the OLE Object Frame and write it to disk. 

This sample code shows you how to extract a file embedded in a slide as an OLE object:

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```


