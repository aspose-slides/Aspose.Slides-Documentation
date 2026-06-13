---
title: จัดการ OLE ในการนำเสนอโดยใช้ PHP
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/php-java/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและการฝังวัตถุ
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มวัตถุ
- ฝังวัตถุ
- เพิ่มไฟล์
- ฝังไฟล์
- วัตถุที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. ฝัง, ปรับปรุงและส่งออกเนื้อหา OLE อย่างไร้รอยต่อ."
---
## **บทนำ**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและอ็อบเจกต์ที่สร้างในแอปพลิเคชันหนึ่งถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง. 
{{% /alert %}} 

ลองพิจารณาชาร์ตที่สร้างใน MS Excel ชาร์ตนั้นจะถูกวางอยู่ในสไลด์ของ PowerPoint ชาร์ต Excel นี้ถือเป็นวัตถุ OLE. 

- วัตถุ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้ เมื่อคุณดับเบิลคลิกไอคอน ชาร์ตจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือคุณจะถูกขอให้เลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขวัตถุ
- วัตถุ OLE อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของชาร์ต ในกรณีนี้ ชาร์ตจะถูกเปิดใช้งานใน PowerPoint อินเตอร์เฟสของชาร์ตจะโหลดและคุณสามารถปรับแก้ข้อมูลของชาร์ตภายใน PowerPoint ได้

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/th/php-java/) ช่วยให้คุณแทรกวัตถุ OLE ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/)).

## **เพิ่มกรอบวัตถุ OLE ลงในสไลด์**

Assuming you have already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for PHP via Java, you can do it this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
1. Get a slide's reference through its index.  
1. Read the Excel file as a byte array.  
1. Add the [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) to the slide containing the byte array and other information about the OLE object.  
1. Write the modified presentation as a PPTX file.  

In the example below, we added a chart from an Excel file to a slide as an OLE object frame using Aspose.Slides for PHP via Java.  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleembeddeddatainfo/) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// เตรียมข้อมูลสำหรับวัตถุ OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// เพิ่มกรอบวัตถุ OLE ลงในสไลด์.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **เพิ่มกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides for PHP via Java ช่วยให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) โดยไม่ต้องฝังข้อมูล แต่เพียงแค่เชื่อมโยงไปยังไฟล์  

This PHP code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) with a linked Excel file to a slide:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **เข้าถึงกรอบวัตถุ OLE**

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. Get the reference of the slide by using its index.  
3. Access the [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) shape. In our example, we used the previously created PPTX that has only one shape on the first slide.  
4. Once the OLE object frame is accessed, you can perform any operation on it.  

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // ดึงข้อมูลไฟล์ที่ฝังไว้.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // ดึงนามสกุลของไฟล์ที่ฝังไว้.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **คุณสมบัติของกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides ให้คุณเข้าถึงคุณสมบัติของกรอบวัตถุ OLE ที่เชื่อมโยง  

This PHP code shows you how to check if an OLE object is linked and then obtain the path to the linked file:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // ตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // พิมพ์เส้นทางเต็มไปยังไฟล์ที่เชื่อมโยง.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // พิมพ์เส้นทางสัมพันธ์ไปยังไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะการนำเสนอ PPT เท่านั้นที่สามารถมีเส้นทางสัมพันธ์ได้.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **เปลี่ยนข้อมูลวัตถุ OLE**

{{% alert color="primary" %}} 
In this section, the code example below uses [Aspose.Cells for PHP via Java](/cells/php-java/).  
{{% /alert %}}  

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. Load a presentation with the embedded OLE object by creating an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. Get the slide's reference through its index.  
3. Access the [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) shape. In our example, we used the previously created PPTX that has one shape on the first slide.  
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

    // อ่านข้อมูลวัตถุ OLE เป็นออบเจกต์ Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // แก้ไขข้อมูลของ workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // เปลี่ยนข้อมูลออบเจกต์ของกรอบ OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ฝังชนิดไฟล์อื่นในสไลด์**

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

## **ตั้งชนิดไฟล์สำหรับวัตถุที่ฝัง**

When working with presentations, you may need to replace old OLE objects with new ones or replace an unsupported OLE object with a supported one. Aspose.Slides for PHP via Java allows you to set the file type for an embedded object, enabling you to update the OLE frame data or its extension.  

This PHP code shows you how to set the file type for an embedded OLE object to `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// เปลี่ยนประเภทไฟล์เป็น ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ตั้งภาพไอคอนและชื่อสำหรับวัตถุที่ฝัง**

After embedding an OLE object, a preview consisting of an icon image is added automatically. This preview is what users see before accessing or opening the OLE object. If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for PHP via Java.  

This PHP code shows you how to set the icon image and title for an embedded object:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// เพิ่มภาพไปยังทรัพยากรของการนำเสนอ.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

After you add a linked OLE object to a presentation slide, when you open the presentation in PowerPoint, you might see a message asking you to update the links. Clicking the "Update Links" button may change the size and position of the OLE object frame because PowerPoint updates the data from the linked OLE object and refreshes the object preview. To prevent PowerPoint from prompting to update the object's data, set the `setUpdateAutomatic` method of the [OleObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) class to `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **สกัดไฟล์ที่ฝังไว้**

Aspose.Slides for PHP via Java allows you to extract the files embedded in slides as OLE objects this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class containing the OLE objects you intend to extract.  
2. Loop through all the shapes in the presentation and access the [OLEObjectFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleobjectframe/) shapes.  
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

## **FAQ**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อตัดออกเป็น PDF/รูปภาพหรือไม่?**  

สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์—ไอคอน/ภาพทดแทน (preview) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลในระหว่างการเรนเดอร์ หากต้องการ ให้ตั้งภาพ preview ของคุณเองเพื่อให้แน่ใจว่าการแสดงผลใน PDF ที่ส่งออกตรงตามที่คาดหวัง  

**ฉันจะล็อกวัตถุ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?**  

ล็อกรูปร่าง: Aspose.Slides ให้การล็อกระดับรูปร่าง นี่ไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจ  

**เส้นทางสัมพันธ์สำหรับวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บรักษาไว้ในรูปแบบ PPTX หรือไม่?**  

ใน PPTX ข้อมูล “relative path” ไม่ได้มีให้ใช้—จะมีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพันธ์พบได้ในรูปแบบ PPT เก่า ๆ เพื่อความพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้ หรือการฝังไฟล์แทน  