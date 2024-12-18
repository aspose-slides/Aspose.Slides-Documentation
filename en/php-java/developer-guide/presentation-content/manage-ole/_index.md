---
title: Manage OLE
type: docs
weight: 40
url: /php-java/manage-ole/
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
- PHP
- Java
- Aspose.Slides for PHP via Java
description: Manage OLE objects in PowerPoint presentations in PHP
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) is a Microsoft technology that allows data and objects created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- An OLE object may appear as an icon. In this case, when you double-click the icon, the chart gets opened in its associated application (Excel), or you are asked to select an application for object opening or editing. 
- An OLE object may display its actual contents, such as the contents of a chart. In this case, the chart is activated in PowerPoint, the chart interface loads, and you get to modify the chart's data within the PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Adding OLE Object Frames to Slides**

Assuming you have already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for PHP via Java, you can do it this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Read the Excel file as a byte array.
1. Add the [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) to the slide containing the byte array and other information about the OLE object.
1. Write the modified presentation as a PPTX file.

In the example below, we added a chart from an Excel file to a slide as an OLE object frame using Aspose.Slides for PHP via Java.
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Adding Linked OLE Object Frames**

Aspose.Slides for PHP via Java allows you to add an [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) without embedding data but only with a link to the file.

This PHP code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) with a linked Excel file to a slide:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Add an OLE object frame with a linked Excel file.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Accessing OLE Object Frames**

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get the reference of the slide by using its index.
3. Access the [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) shape. In our example, we used the previously created PPTX that has only one shape on the first slide.
4. Once the OLE object frame is accessed, you can perform any operation on it.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Get the embedded file data.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Get the extention of the embedded file.
    $fileExtention = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Accessing Linked OLE Object Frame Properties**

Aspose.Slides allows you to access linked OLE object frame properties.

This PHP code shows you how to check if an OLE object is linked and then obtain the path to the linked file:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Check if the OLE object is linked.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Print the full path to the linked file.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Print the relative path to the linked file if present.
        // Only the PPT presentations can contain the relative path.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Changing OLE Object Data**

{{% alert color="primary" %}} 

In this section, the code example below uses [Aspose.Cells for PHP via Java](/cells/php-java/).

{{% /alert %}}

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Get the slide's reference through its index. 
3. Access the [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) shape. In our example, we used the previously created PPTX that has one shape on the first slide.
4. Once the OLE object frame is accessed, you can perform any operation on it.
5. Create a `Workbook` object and access the OLE data.
6. Access the desired `Worksheet` and amend the data.
7. Save the updated `Workbook` in a stream.
8. Change the OLE object data from the stream.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) is accessed, and its file data is modified to update the chart data.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Read the OLE object data as a Workbook object.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modify the workbook data.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Change the OLE frame object data.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Embedding Other File Types in Slides**

Besides Excel charts, Aspose.Slides for PHP via Java allows you to embed other types of files into slides. For example, you can insert HTML, PDF, and ZIP files as objects. When a user double-clicks the inserted object, it automatically opens in the relevant program, or the user is prompted to select an appropriate program to open it.

This PHP code shows you how to embed HTML and ZIP into a slide:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Setting File Types for Embedded Objects**

When working with presentations, you may need to replace old OLE objects with new ones or replace an unsupported OLE object with a supported one. Aspose.Slides for PHP via Java allows you to set the file type for an embedded object, enabling you to update the OLE frame data or its extension.

This PHP code shows you how to set the file type for an embedded OLE object to `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Setting Icon Images and Titles for Embedded Objects**

After embedding an OLE object, a preview consisting of an icon image is added automatically. This preview is what users see before accessing or opening the OLE object. If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for PHP via Java.

This PHP code shows you how to set the icon image and title for an embedded object:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Add an image to the presentation resources.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Prevent an OLE Object Frame from Being Resized and Pepositioned**

After you add a linked OLE object to a presentation slide, when you open the presentation in PowerPoint, you might see a message asking you to update the links. Clicking the "Update Links" button may change the size and position of the OLE object frame because PowerPoint updates the data from the linked OLE object and refreshes the object preview. To prevent PowerPoint from prompting to update the object's data, set the `setUpdateAutomatic` method of the [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) class to `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Extracting Embedded Files**

Aspose.Slides for PHP via Java allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class containing the OLE objects you intend to extract.
2. Loop through all the shapes in the presentation and access the [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) shapes.
3. Access the data of embedded files from OLE object frames and write it to disk.

This PHP code shows you how to extract files embedded in a slide as OLE objects:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```
