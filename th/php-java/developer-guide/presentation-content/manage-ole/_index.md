---
title: จัดการ OLE ในงานนำเสนอโดยใช้ PHP
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/php-java/manage-ole/
keywords:
- อ็อบเจกต์ OLE
- การเชื่อมโยงและฝังอ็อบเจกต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มอ็อบเจกต์
- ฝังอ็อบเจกต์
- เพิ่มไฟล์
- ฝังไฟล์
- อ็อบเจกต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- หัวเรื่อง OLE
- สกัด OLE
- สกัดอ็อบเจกต์
- สกัดไฟล์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่งการจัดการอ็อบเจกต์ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. ฝัง, อัปเดต และส่งออกเนื้อหา OLE ได้อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและอ็อบเจกต์ที่สร้างในแอปพลิเคชันหนึ่งถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือฝัง

{{% /alert %}} 

พิจารณาแผนภูมิที่สร้างใน MS Excel แผนภูมินั้นถูกวางไว้ในสไลด์ PowerPoint แผนภูมิ Excel นี้ถือเป็นอ็อบเจกต์ OLE 

- อ็อบเจกต์ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอน แผนภูมิจะเปิดในแอปพลิเคชันที่สัมพันธ์ (Excel) หรือคุณจะถูกถามให้เลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขอ็อบเจกต์
- อ็อบเจกต์ OLE อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของแผนภูมิ ในกรณีนี้แผนภูมิจะถูกเปิดใช้งานใน PowerPoint อินเทอร์เฟซของแผนภูมิจะโหลดขึ้น และคุณสามารถแก้ไขข้อมูลของแผนภูมิได้ภายใน PowerPoint

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบอ็อบเจกต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/))

## **เพิ่มกรอบอ็อบเจกต์ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างแผนภูมิใน Microsoft Excel แล้วและต้องการฝังมันในสไลด์เป็นกรอบอ็อบเจกต์ OLE ด้วย Aspose.Slides for PHP via Java คุณสามารถทำได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. อ่านไฟล์ Excel เป็นอาร์เรย์ของไบต์  
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ไปยังสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่นๆ ของอ็อบเจกต์ OLE  
5. เขียนพรีเซนเทชั่นที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มแผนภูมิจากไฟล์ Excel ลงในสไลด์เป็นกรอบอ็อบเจกต์ OLE ด้วย Aspose.Slides for PHP via Java. **หมายเหตุ**ว่า ตัวสร้าง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) รับส่วนขยายของอ็อบเจกต์ที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนั้นทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดอ็อบเจกต์ OLE นี้.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// เตรียมข้อมูลสำหรับอ็อบเจกต์ OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// เพิ่มกรอบอ็อบเจกต์ OLE ลงในสไลด์.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **เพิ่มกรอบอ็อบเจกต์ OLE ที่เชื่อมโยง**

Aspose.Slides for PHP via Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) โดยไม่ต้องฝังข้อมูล แต่เพียงแค่เชื่อมโยงไปยังไฟล์

โค้ด PHP นี้แสดงวิธีเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) พร้อมไฟล์ Excel ที่เชื่อมโยงไปยังสไลด์:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// เพิ่มกรอบอ็อบเจกต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **เข้าถึงกรอบอ็อบเจกต์ OLE**

หากอ็อบเจกต์ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหา หรือเข้าถึงมันได้อย่างง่ายดายโดยทำตามนี้:

1. โหลดพรีเซนเทชั่นที่มีอ็อบเจกต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปทรง [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างขึ้นก่อนหน้านี้ซึ่งมีรูปร่างเดียวบนสไลด์แรก  
4. เมื่อเข้าถึงกรอบอ็อบเจกต์ OLE แล้ว คุณสามารถทำการดำเนินการใดๆ กับมันได้  

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบอ็อบเจกต์ OLE (อ็อบเจกต์แผนภูมิ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // รับข้อมูลไฟล์ที่ฝังไว้.
    // รับส่วนขยายของไฟล์ที่ฝังไว้.
    // ...
}
```

### **เข้าถึงคุณสมบัติกรอบอ็อบเจกต์ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติกรอบอ็อบเจกต์ OLE ที่เชื่อมโยง

โค้ด PHP นี้แสดงวิธีตรวจสอบว่าอ็อบเจกต์ OLE ถูกเชื่อมโยงหรือไม่และรับเส้นทางไปยังไฟล์ที่เชื่อมโยง:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // ตรวจสอบว่าอ็อบเจกต์ OLE ถูกเชื่อมโยงหรือไม่.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // พิมพ์เส้นทางเต็มของไฟล์ที่เชื่อมโยง.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // พิมพ์เส้นทางสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะพรีเซนเทชั่น PPT เท่านั้นที่สามารถมีเส้นทางสัมพัทธ์ได้.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **เปลี่ยนข้อมูลอ็อบเจกต์ OLE**

{{% alert color="info" title="Note" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

หากอ็อบเจกต์ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงอ็อบเจกต์นั้นและแก้ไขข้อมูลของมันได้อย่างง่ายดายโดยทำตามนี้:

1. โหลดพรีเซนเทชั่นที่มีอ็อบเจกต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงรูปทรง [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างขึ้นก่อนหน้านี้ซึ่งมีรูปร่างหนึ่งบนสไลด์แรก  
4. เมื่อเข้าถึงกรอบอ็อบเจกต์ OLE แล้ว คุณสามารถทำการดำเนินการใดๆ กับมันได้  
5. สร้างอ็อบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม  
8. เปลี่ยนข้อมูลอ็อบเจกต์ OLE จากสตรีม  

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบอ็อบเจกต์ OLE (อ็อบเจกต์แผนภูมิ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลของแผนภูมิ

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // อ่านข้อมูลอ็อบเจกต์ OLE เป็นอ็อบเจกต์ Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // แก้ไขข้อมูลของ workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // เปลี่ยนข้อมูลอ็อบเจกต์ของกรอบ OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ฝังไฟล์ประเภทอื่นในสไลด์**

นอกเหนือจากแผนภูมิ Excel แล้ว Aspose.Slides for PHP via Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นอ็อบเจกต์ เมื่อผู้ใช้ดับเบิลคลิกที่อ็อบเจกต์ที่แทรกไว้ มันจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะได้รับการแจ้งให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิด

โค้ด PHP นี้แสดงวิธีฝัง HTML และ ZIP ลงในสไลด์:

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

## **ตั้งค่าประเภทไฟล์สำหรับอ็อบเจกต์ที่ฝัง**

เมื่อทำงานกับพรีเซนเทชั่น คุณอาจต้องการแทนที่อ็อบเจกต์ OLE เก่าโดยอ็อบเจกต์ใหม่หรือแทนที่อ็อบเจกต์ OLE ที่ไม่รองรับด้วยอ็อบเจกต์ที่รองรับ Aspose.Slides for PHP via Java อนุญาตให้คุณตั้งค่าประเภทไฟล์สำหรับอ็อบเจกต์ที่ฝังไว้ เพื่อให้คุณสามารถอัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของมันได้

โค้ด PHP นี้แสดงวิธีตั้งค่าประเภทไฟล์สำหรับอ็อบเจกต์ OLE ที่ฝังเป็น `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// เปลี่ยนประเภทไฟล์เป็น ZIP.

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ตั้งค่าภาพไอคอนและหัวเรื่องสำหรับอ็อบเจกต์ที่ฝัง**

หลังจากฝังอ็อบเจกต์ OLE จะมีการเพิ่มตัวอย่างภาพประกอบที่ประกอบด้วยภาพไอคอนโดยอัตโนมัติ ตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดอ็อบเจกต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นองค์ประกอบในตัวอย่าง สามารถตั้งค่าภาพไอคอนและหัวเรื่องโดยใช้ Aspose.Slides for PHP via Java

โค้ด PHP นี้แสดงวิธีตั้งค่าภาพไอคอนและหัวเรื่องสำหรับอ็อบเจกต์ที่ฝัง:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของพรีเซนเทชั่น.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ป้องกันไม่ให้กรอบอ็อบเจกต์ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากที่คุณเพิ่มอ็อบเจกต์ OLE ที่เชื่อมโยงลงในสไลด์พรีเซนเทชั่น เมื่อคุณเปิดพรีเซนเทชั่นใน PowerPoint คุณอาจเห็นข้อความขอให้คุณอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของกรอบอ็อบเจกต์ OLE เปลี่ยนไป เพราะ PowerPoint จะอัปเดตข้อมูลจากอ็อบเจกต์ OLE ที่เชื่อมโยงและรีเฟรชตัวอย่างอ็อบเจกต์ เพื่อป้องกันไม่ให้ PowerPoint แสดงข้อความขออัปเดตข้อมูลของอ็อบเจกต์ ให้เรียกเมธอด [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ด้วยค่า `false` :

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **สกัดไฟล์ที่ฝังไว้**

Aspose.Slides for PHP via Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจกต์ OLE ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ที่มีอ็อบเจกต์ OLE ที่คุณต้องการสกัด  
2. วนลูปผ่านรูปทรงทั้งหมดในพรีเซนเทชั่นและเข้าถึงรูปทรง [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)  
3. เข้าถึงข้อมูลไฟล์ที่ฝังจากกรอบอ็อบเจกต์ OLE แล้วเขียนลงดิสก์  

โค้ด PHP นี้แสดงวิธีสกัดไฟล์ที่ฝังในสไลด์เป็นอ็อบเจกต์ OLE:

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

## **คำถามที่พบบ่อย**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**

สิ่งที่แสดงบนสไลด์เท่านั้นที่จะถูกเรนเดอร์ — ไอคอน/ภาพทดแทน (พรีวิว) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลในระหว่างการเรนเดอร์ หากต้องการสามารถตั้งค่าภาพพรีวิวของคุณเองเพื่อให้ได้ลักษณะที่คาดหวังใน PDF ที่ส่งออก  

เพื่อให้คงไฟล์ที่ฝังเป็นไฟล์แนบใน PDF ด้วย ให้เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) ด้วยค่า `true` ตัวเลือกนี้จะปิดการใช้งานโดยค่าเริ่มต้น สำหรับตัวอย่างและวิธีตรวจสอบไฟล์แนบ ให้ดูที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**ฉันจะล็อกอ็อบเจกต์ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?**

ล็อกรูปทรง: Aspose.Slides มีการล็อกระดับรูปทรง ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ตั้งใจ

**เส้นทางสัมพัทธ์สำหรับอ็อบเจกต์ OLE ที่เชื่อมโยงจะถูกคงไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ไม่มีข้อมูล "เส้นทางสัมพัทธ์" — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์จะมีในรูปแบบ PPT เก่า สำหรับความพกพา แนะนำให้ใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์