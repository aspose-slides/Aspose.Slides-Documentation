---
title: Manage OLE
type: docs
weight: 232
url: /net/manage-ole/
---

OLE stands for Object Linking & Embedding. It's a Microsoft technology that allows objects created in one application to be embedded in another application. 

For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. 

Aspose.Slides for .NET supports inserting OLE Objects into the slide as OLE Object Frames. 
In this topic, we will work with OLE Object Frames to see how these objects can be added and manipulated via 
Aspose.Slides for .NET. This article explains different examples of working with OLE Object Frames.

## **Add OLE Object Frame to Slide**
Suppose, you have created a Microsoft Excel Chart in an Excel file and want to embed that chart object in a slide as an OLE Object Frame using Aspose.Slides for .NET. It can be done with the following steps:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Open the Excel file containing Microsoft Excel Chart object and save it to MemoryStream.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example given below, a Microsoft Excel Chart object in an Excel file is added to a slide as an OLE Object Frame using Aspose.Slides for .NET.  
**Note** that [IOleEmbeddedDataInfo](https://apireference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) 
constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly 
interpret the file type and, choose the right application to open this OLE object.
``` csharp 
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Shapes();

// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{
    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Load an cel file to stream
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream(dataDir + "book1.xlsx", FileMode.Open, FileAccess.Read))
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

    // Create data object for embedding
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // Add an Ole Object Frame shape
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    //Write the PPTX to disk
    pres.Save(dataDir + "OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
## **Access OLE Object Frame**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for .NET. Please follow the steps below to find or access an OLE object from a slide:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once OLE Object Frame is accessed, you can perform any operation on it.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then all of its Object Data is written to an Excel file.

``` csharp 
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Shapes();

// Load the PPTX to Presentation object
using (Presentation pres = new Presentation(dataDir + "AccessingOLEObjectFrame.pptx"))
{
    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Cast the shape to OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // Read the OLE Object and write it to disk
    if (oleObjectFrame != null)
    {
        // Get embedded file data
        byte[] data = oleObjectFrame.EmbeddedFileData;

        // Get embedded file extention
        string fileExtention = oleObjectFrame.EmbeddedFileExtension;

        // Create path for saving the extracted file
        string extractedPath = dataDir + "excelFromOLE_out" + fileExtention;

        // Save extracted data
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

## **Change OLE Object Data**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for .NET and can 
modify its data. Please follow the steps below to find how to modify an OLE object data from a slide:

1. Open the desired presentation with embedded OLE Object by creating an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.
1. Create the Workbook object and access the OLE Data.
1. Access the desired Worksheet and amend the data.
1. Save the updated Workbook in streams.
1. Change the OLE object data from stream data.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then its Object Data is modified to change the chart data.

``` csharp 
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Shapes();

using (Presentation pres = new Presentation(dataDir + "ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // Traversing all shapes for Ole frame
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null)
    {
        using (System.IO.MemoryStream msln = new System.IO.MemoryStream(ole.ObjectData))
        {
            // Reading object data in Workbook
            Aspose.Cells.Workbook Wb = new Aspose.Cells.Workbook(msln);

            using (System.IO.MemoryStream msout = new System.IO.MemoryStream())
            {
                // Modifying the workbook data
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions so1 =
                    new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);

                Wb.Save(msout, so1);

                // Changing Ole frame object data
                msout.Position = 0;
                ole.ObjectData = msout.ToArray();
            }
        }
    }

    pres.Save(dataDir + "OleEdit_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

ObjectData property of the OleObjectFrame class represents [Object Linking and Embedding (OLE) Data Structures](https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-oleds/85583d21-c1cf-4afe-a35f-d6701c5fbb6f) in general, but not file data itself. So please take into account the referenced documentation article when using this property.

{{% /alert %}} 
  
