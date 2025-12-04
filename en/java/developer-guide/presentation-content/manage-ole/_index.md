---
title: Manage OLE in Presentations Using Java
linktitle: Manage OLE
type: docs
weight: 40
url: /java/manage-ole/
keywords:
- OLE object
- Object Linking & Embedding
- add OLE
- embed OLE
- add object
- embed object
- add file
- embed file
- linked object
- linked file
- change OLE
- OLE icon
- OLE title
- extact OLE
- extract object
- extract file
- PowerPoint 
- presentation
- Java
- Aspose.Slides
description: "Optimize OLE object management in PowerPoint and OpenDocument files with Aspose.Slides for Java. Embed, update, and export OLE content seamlessly."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display its actual contents, such as the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Add OLE Object Frames to Slides**

Assuming you have already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for Java, you can do it this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Get a slide's reference through its index.
1. Read the Excel file as a byte array.
1. Add the [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) to the slide containing the byte array and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an OLE object frame using Aspose.Slides for Java.
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Add Linked OLE Object Frames**

Aspose.Slides for Java allows you to add an [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) without embedding data but only with a link to the file.

This Java code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) with a linked Excel file to a slide:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add an OLE object frame with a linked Excel file.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Access OLE Object Frames**

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get the reference of the slide by using its index.
3. Access the [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) shape.
   In our example, we used the previously created PPTX that has only one shape on the first slide.  We then *cast* that object as an [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). This was the desired OLE object frame to be accessed.
4. Once the OLE object frame is accessed, you can perform any operation on it.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Get the embedded file data.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Get the extension of the embedded file.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Access Linked OLE Object Frame Properties**

Aspose.Slides allows you to access linked OLE object frame properties.

This Java code shows you how to check if an OLE object is linked and then obtain the path to the linked file:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Check if the OLE object is linked.
    if (oleFrame.isObjectLink()) {
        // Print the full path to the linked file.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Print the relative path to the linked file if present.
        // Only the PPT presentations can contain the relative path.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Change OLE Object Data**

{{% alert color="primary" %}} 

In this section, the code example below uses [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get the slide's reference through its index. 
3. Access the OLE object frame shape.
   In our example, we used the previously created PPTX that has one shape on the first slide. We then *cast* that object as an [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). This was the desired OLE object frame to be accessed.
4. Once the OLE object frame is accessed, you can perform any operation on it.
5. Create a `Workbook` object and access the OLE data.
6. Access the desired `Worksheet` and amend the data.
7. Save the updated `Workbook` in a stream.
8. Change the OLE object data from the stream.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) is accessed, and its file data is modified to update the chart data.

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Read the OLE object data as a Workbook object.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modify the workbook data.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Change the OLE frame object data.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Embed Other File Types in Slides**

Besides Excel charts, Aspose.Slides for Java allows you to embed other types of files into slides. For example, you can insert HTML, PDF, and ZIP files as objects. When a user double-clicks the inserted object, it automatically opens in the relevant program, or the user is prompted to select an appropriate program to open it.

This Java code shows you how to embed HTML and ZIP into a slide:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Set File Types for Embedded Objects**

When working with presentations, you may need to replace old OLE objects with new ones or replace an unsupported OLE object with a supported one. Aspose.Slides for Java allows you to set the file type for an embedded object, enabling you to update the OLE frame data or its extension.

This Java code shows you how to set the file type for an embedded OLE object to `zip`:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Set Icon Images and Titles for Embedded Objects**

After embedding an OLE object, a preview consisting of an icon image is added automatically. This preview is what users see before accessing or opening the OLE object. If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for Java.

This Java code shows you how to set the icon image and title for an embedded object:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Add an image to the presentation resources.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

After you add a linked OLE object to a presentation slide, when you open the presentation in PowerPoint, you might see a message asking you to update the links. Clicking the "Update Links" button may change the size and position of the OLE object frame because PowerPoint updates the data from the linked OLE object and refreshes the object preview. To prevent PowerPoint from prompting to update the object's data, set the `setUpdateAutomatic` method of the [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) interface to `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Extract Embedded Files**

Aspose.Slides for Java allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class containing the OLE objects you intend to extract.
2. Loop through all the shapes in the presentation and access the [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) shapes.
3. Access the data of embedded files from OLE object frames and write it to disk.

This Java code shows you how to extract files embedded in a slide as OLE objects:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**Will the OLE content be rendered when exporting slides to PDF/images?**

What is visible on the slide is rendered—the icon/substitute image (preview). The "live" OLE content is not executed during rendering. If needed, set your own preview image to ensure the expected appearance in the exported PDF.

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

Lock the shape: Aspose.Slides provides [shape-level locks](/slides/java/applying-protection-to-presentation/). This is not encryption, but it effectively prevents accidental edits and movement.

**Why does a linked Excel object "jump" or change size when I open the presentation?**

PowerPoint may refresh the preview of the linked OLE. For a stable appearance, follow the [Working Solution for Worksheet Resizing](/slides/java/working-solution-for-worksheet-resizing/) practices—either fit the frame to the range, or scale the range to a fixed frame and set an appropriate substitute image.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

In PPTX, "relative path" information is not available—only the full path. Relative paths are found in the older PPT format. For portability, prefer reliable absolute paths/accessible URIs or embedding.
