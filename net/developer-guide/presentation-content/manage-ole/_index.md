---
title: OLE
type: docs
weight: 232
url: /net/ole/
---


OLE stands for Object Linking & Embedding . It's a Microsoft technology that allows objects created in one application to be embedded in another application. For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. Aspose.Slides for .NET supports adding OLE Objects to the slides in the form of OLE Object Frames . In this topic, we will work with OLE Object Frames to see that how can we add and access these objects to and from slides using Aspose.Slides for .NET. This article explains different examples of working with Ole frames:

- Adding an OLE Object Frame to a Slide.
- Accessing an OLE Object Frame from a Slide.
- Changing an OLE Object data from a Slide.
## **Add OLE Object Frame to a Slide**
Suppose, you have created a Microsoft Excel Chart in an Excel file and want to embed that chart object in a slide as an OLE Object Frame using Aspose.Slides for .NET . Then you can do that using the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Open the Excel file containing Microsoft Excel Chart object and save it to MemoryStream.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example given below, a Microsoft Excel Chart object in an Excel file is added to a slide as an OLE Object Frame using Aspose.Slides for .NET.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddOLEObjectFrame-AddOLEObjectFrame.cs" >}}
## **Access OLE Object Frame**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for .NET . Please follow the steps below to find or access an OLE object from a slide:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then all of its Object Data is written to an Excel file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AccessOLEObjectFrame-AccessOLEObjectFrame.cs" >}}
## **Change OLE Object data**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for .NET and can modify its data . Please follow the steps below to find how to modify an OLE object data from a slide:

1. Open the desired presentation with embedded Ole Object by creating an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.
1. Create the Workbook object and access the Ole Data.
1. Access the desired Worksheet and amend the data.
1. Save the updated Workbook in streams.
1. Change the Ole object data from stream data.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then its Object Data is modified to change the chart data.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-ChangeOLEObjectData-ChangeOLEObjectData.cs" >}}
## **Set File Type of OLE Object**
Using Aspose.Slides for .NET you can set file type for an embedding object. For this purpose, new methods **addOleObjectFrame** and **insertOleObjectFrame** have been added into **IShapeCollection**.

These methods allow to get **IOleEmbeddedDataInfo** object as a parameter so now OLE object knows its type and PowerPoint can open created OLE objects.

The following example shows how to set file type for an embedding object:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Shapes-SetFileTypeForAnEmbeddingObject-SetFileTypeForAnEmbeddingObject.cs" >}}
## **Extract Embedded Files from OLE Object**
Aspose.Slides for .NET supports extracting embedded files from OLE Object. In order to extract embedded files, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class and Load a presentation contains OLE Object
- Loop through all the shapes in a presentation and access the OLE Object Frame shape
- Access the data of the Embedded file from OLE Object Frame and write it to disk

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Shapes-ExtractEmbeddedFileDataFromOLEObject-ExtractEmbeddedFileDataFromOLEObject.cs" >}}
