---
title: Manage OLE
type: docs
weight: 232
url: /java/manage-ole/
---

{{% alert color="primary" %}} 

OLE stands for **Object Linking & Embedding**. It's a Microsoft technology that allows objects created in one application to be embedded in another application. For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. Aspose.Slides for Java supports adding OLE Objects to the slides in the form of **OLE Object Frames**. In this topic, we will work with **OLE Object Frames** to see that how can we add and access these objects to and from slides using Aspose.Slides for Java.

{{% /alert %}} 

OLE stands for Object Linking & Embedding. It's a Microsoft technology that allows objects created in one application to be embedded in another application. 

For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. 

Aspose.Slides for Java supports inserting OLE Objects into the slide as OLE Object Frames. 
In this topic, we will work with OLE Object Frames to see how these objects can be added and manipulated via 
Aspose.Slides for Java. This article explains different examples of working with OLE Object Frames.

## **Add OLE Object Frame to Slide**
Suppose, you have created a Microsoft Excel Chart in an Excel file and want to embed that chart object in a slide as an OLE Object Frame using Aspose.Slides for Java. It can be done with the following steps:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Open the Excel file containing Microsoft Excel Chart object and save it to MemoryStream.
1. Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example given below, a Microsoft Excel Chart object in an Excel file is added to a slide as an OLE Object Frame using Aspose.Slides for Java.  
**Note** that [IOleEmbeddedDataInfo](https://apireference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) 
constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly 
interpret the file type and, choose the right application to open this OLE object.
``` java 
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try
{
	// Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

	// Load an cel file to stream
	FileInputStream fs = new FileInputStream("book1.xlsx");
	ByteArrayOutputStream mstream = new ByteArrayOutputStream();
	byte[] buf = new byte[4096];

	while (true)
	{
		int bytesRead = fs.read(buf, 0, buf.length);
		if (bytesRead <= 0)
			break;
		mstream.write(buf, 0, bytesRead);
	}

	// Create data object for embedding
	IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");

	// Add an Ole Object Frame shape
	IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
			(float) pres.getSlideSize().getSize().getWidth(),
			(float) pres.getSlideSize().getSize().getHeight(), 
			dataInfo);

	//Write the PPTX to disk
	pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} 
finally 
{
	if (pres != null) pres.dispose();
}
```
## **Access OLE Object Frame**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for Java. Please follow the steps below to find or access an OLE object from a slide:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once OLE Object Frame is accessed, you can perform any operation on it.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then its file data is written to an Excel file.

``` java 
// Load the PPTX to Presentation object
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Cast the shape to OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Read the OLE Object and write it to disk
    if (oleObjectFrame != null) {
        // Get embedded file data
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // Get embedded file extention
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // Create path for saving the extracted file
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // Save extracted data
        // Save extracted data
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change OLE Object Data**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for Java and can 
modify its data. Please follow the steps below to find how to modify an OLE object data from a slide:

1. Open the desired presentation with embedded OLE Object by creating an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.
1. Create the Workbook object and access the OLE Data.
1. Access the desired Worksheet and amend the data.
1. Save the updated Workbook in streams.
1. Change the OLE object data from stream data.

In the example given below, an OLE Object Frame (that is a Microsoft Excel Chart object embedded in a slide) is accessed and then its file data is modified to change the chart data.

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    OleObjectFrame ole = null;

    // Traversing all shapes for Ole frame
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof OleObjectFrame) {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // Reading object data in Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // Modifying the workbook data
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // Changing Ole frame object data
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

