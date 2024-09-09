---
title: Manage OLE
type: docs
weight: 40
url: /java/manage-ole/
---

{{% alert color="primary" %}} 

OLE  (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display actual contents—for example, the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint app.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) allows you to insert OLE Objects into slides as OLE Object Frames ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Adding OLE Object Frames to Slides**
Assuming you already created a chart in Microsoft Excel and want to embed that chart in a slide as an OLE Object Frame using Aspose.Slides for Java, you can do it this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of the slide by using its index.
1. Open the Excel file containing the Excel chart object and save it to `MemoryStream`.
1. Add the [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) to the slide containing the array of bytes and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an OLE Object Frame using Aspose.Slides for Java.  
**Note** that the [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```javascript
    // Instantiates Prseetation class that represents the PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Loads an excel file to stream
        var fs = java.newInstanceSync("java.io.FileInputStream", "book1.xlsx");
        var mstream = java.newInstanceSync("java.io.ByteArrayOutputStream", );
        var buf = new byte[4096];
        while (true) {
            var bytesRead = fs.read(buf, 0, buf.length);
            if (bytesRead <= 0) {
                break;
            }
            mstream.write(buf, 0, bytesRead);
        }
        fs.close();
        // Creates a data object for embedding
        var dataInfo = new  com.aspose.slides.OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
        mstream.close();
        // Adds an Ole Object Frame shape
        var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
        // Writes the PPTX file to disk
        pres.save("OleEmbed_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Accessing OLE Object Frames**
If an OLE object is already embedded in a slide, you can find or access that object easily using this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of the slide by using its index.
1. Access the OLE Object Frame shape.

   In our example, we used the previously created PPTX, which has only one shape on the first slide.  We then *cast* that object as an [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data gets written to an Excel file.

```javascript
    // Loads the PPTX to  a Presentation object
    var pres = new  com.aspose.slides.Presentation("AccessingOLEObjectFrame.pptx");
    try {
        // Accesses the first slide
        var sld = pres.getSlides().get_Item(0);
        // Casts the shape to OleObjectFrame
        var oleObjectFrame = sld.getShapes().get_Item(0);
        // Reads the OLE Object and writes it to disk
        if (oleObjectFrame != null) {
            // Get embedded file data
            var data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();
            // Gets embedded file extention
            var fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();
            // Creates a path to save the extracted file
            var extractedPath = "excelFromOLE_out" + fileExtention;
            // Saves extracted data
            var fstr = java.newInstanceSync("java.io.FileOutputStream", extractedPath);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Changing OLE Object Data**

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Open the desired presentation with the embedded OLE Object by creating an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Get the slide's reference through its index. 
1. Access the OLE Object Frame shape.

   In our example, we used the previously created PPTX that has only one shape on the first slide. We then *cast* that object as an [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). This was the desired OLE Object Frame to be accessed.
1. Once the OLE Object Frame is accessed, you can perform any operation on it.
1. Create the Workbook object and access the OLE Data.
1. Access the desired Worksheet and amend the data.
1. Save the updated Workbook in streams.
1. Change the OLE object data from stream data.

In the example below, an OLE Object Frame (an Excel chart object embedded in a slide) is accessed—and then its file data is modified to change the chart data:

```javascript
    var pres = new  com.aspose.slides.Presentation("ChangeOLEObjectData.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        var ole = null;
        // Traverses all shapes for Ole frame
        for (var shape : slide.getShapes()) {
            if (shape instanceof com.aspose.slides.OleObjectFrame) {
                ole = shape;
            }
        }
        if (ole != null) {
            var msln = java.newInstanceSync("java.io.ByteArrayInputStream", ole.getEmbeddedData().getEmbeddedFileData());
            try {
                // Reads object data in Workbook
                var Wb = java.newInstanceSync("Workbook", msln);
                var msout = java.newInstanceSync("java.io.ByteArrayOutputStream", );
                try {
                    // Modifies the workbook data
                    Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                    Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                    Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                    Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);
                    var so1 = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
                    Wb.save(msout, so1);
                    // Changes Ole frame object data
                    var newData = new  com.aspose.slides.OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                    ole.setEmbeddedData(newData);
                } finally {
                    if (msout != null) {
                        msout.close();
                    }
                }
            } finally {
                if (msln != null) {
                    msln.close();
                }
            }
        }
        pres.save("OleEdit_out.pptx", com.aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Embedding Other File Types in Slides

Besides Excel charts, Aspose.Slides for Java allows you to embed other types of files in slides. For example, you can insert HTML, PDF, and ZIP files as objects into a slide. When a user double-clicks the inserted object, the object automatically gets launched in the relevant program, or the user gets directed to select an appropriate program to open the object. 

This Java code shows you how to embed HTML and ZIP in a slide:

```javascript
    var pres = new  com.aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        var htmlBytes = java.callStaticMethodSync("java.nio.file.Files", "readAllBytes", java.callStaticMethodSync("java.nio.file.Paths", "get", "embedOle.html"));
        var dataInfoHtml = new  com.aspose.slides.OleEmbeddedDataInfo(htmlBytes, "html");
        var oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
        oleFrameHtml.setObjectIcon(true);
        var zipBytes = java.callStaticMethodSync("java.nio.file.Files", "readAllBytes", java.callStaticMethodSync("java.nio.file.Paths", "get", "embedOle.zip"));
        var dataInfoZip = new  com.aspose.slides.OleEmbeddedDataInfo(zipBytes, "zip");
        var oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
        oleFrameZip.setObjectIcon(true);
        pres.save("embeddedOle.pptx", com.aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Setting File Types for Embedded Objects

When working on presentations, you may need to replace old OLE objects with new ones. Or you may need to replace an unsupported OLE object with a supported one. 

Aspose.Slides for Java allows you to set the file type for an embedded object. This way, you get to change the OLE frame data or its extension. 

This Java shows you how to set the file type for an embedded OLE object:

```javascript
    var pres = new  com.aspose.slides.Presentation("embeddedOle.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        var oleObjectFrame = slide.getShapes().get_Item(0);
        console.log("Current embedded data extension is: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());
        oleObjectFrame.setEmbeddedData(new  com.aspose.slides.OleEmbeddedDataInfo(java.callStaticMethodSync("java.nio.file.Files", "readAllBytes", java.callStaticMethodSync("java.nio.file.Paths", "get", "embedOle.zip")), "zip"));
        pres.save("embeddedChanged.pptx", com.aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Setting Icon Images and Titles for Embedded Objects

After you embed an OLE object, a preview consisting of an icon image and title gets added automatically. The preview is what users see before they access or open the OLE object. 

If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for Java. 

This Java code shows you how to set the icon image and title for an embedded object: 

```javascript
    var pres = new  com.aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        var oleObjectFrame = slide.getShapes().get_Item(0);
        var oleImage;
        var image = com.aspose.slides.Images.fromFile("image.png");
        try {
            oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        oleObjectFrame.setSubstitutePictureTitle("My title");
        oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
        oleObjectFrame.setObjectIcon(false);
        pres.save("embeddedOle-newImage.pptx", com.aspose.slides.SaveFormat.Pptx);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Extracting Embedded Files

Aspose.Slides for Java allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class containing the OLE object you intend to extract.
2. Loop through all the shapes in the presentation and access the [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) shape.
3. Access the embedded file's data from the OLE Object Frame and write it to disk. 

This Java code shows you how to extract a file embedded in a slide as an OLE object:

```javascript
    var pres = new  com.aspose.slides.Presentation("embeddedOle.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        for (var index = 0; index < slide.getShapes().size(); index++) {
            var shape = slide.getShapes().get_Item(index);
            var oleFrame = shape;
            if (oleFrame != null) {
                var data = oleFrame.getEmbeddedData().getEmbeddedFileData();
                var extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
                // Save extracted data
                var fstr = java.newInstanceSync("java.io.FileOutputStream", ("oleFrame" + index) + extension);
                try {
                    fstr.write(data, 0, data.length);
                } finally {
                    fstr.close();
                }
            }
        }
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
