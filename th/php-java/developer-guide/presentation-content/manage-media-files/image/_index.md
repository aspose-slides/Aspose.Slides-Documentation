---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอด้วย PHP
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/php-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่ภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- EMF
- SVG
- PHP
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ง่ายและรวดเร็วขึ้น เพิ่มประสิทธิภาพและอัตโนมัติกระบวนการทำงานของคุณ."
---
## **บทนำ**

รูปภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ไปยังสไลด์ได้ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มรูปภาพลงในสไลด์ของการนำเสนอผ่านขั้นตอนต่าง ๆ  

{{% alert  title="Tip" color="primary" %}} 

Aspose มีเครื่องมือแปลงแบบฟรี —[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว  

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

หากต้องการเพิ่มรูปภาพเป็นวัตถุกรอบ—โดยเฉพาะอย่างยิ่งหากต้องการใช้ตัวเลือกการจัดรูปแบบมาตรฐานเพื่อปรับขนาด เพิ่มเอฟเฟกต์ ฯลฯ—ดูที่ [Picture Frame](/slides/th/php-java/picture-frame/)  

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

คุณสามารถจัดการการดำเนินการนำเข้า/ส่งออกที่เกี่ยวข้องกับรูปภาพและการนำเสนอ PowerPoint เพื่อแปลงรูปจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง ดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/php-java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/php-java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/php-java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/php-java/conversion/svg-to-png/)  

{{% /alert %}}

Aspose.Slides รองรับการทำงานกับรูปภาพในรูปแบบยอดนิยมเหล่านี้: JPEG, PNG, GIF และอื่น ๆ  

## **เพิ่มรูปภาพที่เก็บไว้ในเครื่องลงบนสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งภาพหรือหลายภาพจากคอมพิวเตอร์ของคุณลงในสไลด์ของการนำเสนอ ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มรูปภาพลงในสไลด์:  

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มรูปภาพจากเว็บลงบนสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงสไลด์ไม่มีในเครื่อง คุณสามารถเพิ่มรูปภาพโดยตรงจากเว็บได้  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มรูปภาพจากเว็บลงบนสไลด์:  

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มรูปภาพไปยัง Slide Masters**

Slide master คือสไลด์ระดับบนสุดที่จัดเก็บและควบคุมข้อมูล (ธีม, เค้าโครง ฯลฯ) ของสไลด์ทั้งหมดที่อยู่ภายใต้มัน ดังนั้นเมื่อคุณเพิ่มรูปภาพไปยัง slide master รูปภาพนั้นจะปรากฏบนทุกสไลด์ที่ใช้ master นี้  

ตัวอย่างโค้ด Java ต่อไปนี้แสดงวิธีเพิ่มรูปภาพไปยัง slide master:  

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มรูปภาพเป็นพื้นหลังของสไลด์**

คุณอาจต้องการใช้รูปเป็นพื้นหลังสำหรับสไลด์ใดสไลด์หนึ่งหรือหลายสไลด์ ในกรณีนั้นคุณต้องดูวิธี [Set an Image as a Slide Background](/slides/th/php-java/presentation-background/#set-an-image-as-a-slide-background)  

## **เพิ่ม SVG ลงในการนำเสนอ**

คุณสามารถเพิ่มหรือแทรกรูปภาพใด ๆ ลงในการนำเสนอโดยใช้เมธอด [addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/)  

เพื่อสร้างอ็อบเจ็กต์รูปภาพจาก SVG ให้ทำตามขั้นตอนนี้:

1. สร้างอ็อบเจ็กต์ SvgImage เพื่อแทรกลงใน ImageShapeCollection  
2. สร้างอ็อบเจ็กต์ PPImage จาก ISvgImage  
3. สร้างอ็อบเจ็กต์ PictureFrame โดยใช้คลาส PPImage  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดำเนินการตามขั้นตอนข้างต้นเพื่อเพิ่มรูป SVG ลงในการนำเสนอ:  
```php
  # สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แปลง SVG เป็นชุดของ Shapes**

การแปลง SVG เป็นชุดของ shapes ของ Aspose.Slides มีลักษณะคล้ายกับฟังก์ชันของ PowerPoint ที่ใช้ทำงานกับรูปภาพ SVG:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้บริการโดยหนึ่งใน overloaded ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addgroupshape/) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ที่รับอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) เป็นอาร์กิวเมนต์แรก  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้เมธอดที่อธิบายเพื่อแปลงไฟล์ SVG เป็นชุดของ shapes:  

```php
  # สร้างการนำเสนอใหม่
  $presentation = new Presentation();
  try {
    # อ่านเนื้อหาไฟล์ SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # สร้างอ็อบเจ็กต์ SvgImage
    $svgImage = new SvgImage($svgContent);
    # รับขนาดสไลด์
    $slideSize = $presentation->getSlideSize()->getSize();
    # แปลงภาพ SVG เป็นกลุ่มของ shapes และปรับขนาดให้พอดีกับสไลด์
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # บันทึกการนำเสนอในรูปแบบ PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **เพิ่มรูปภาพเป็น EMF ลงบนสไลด์**

Aspose.Slides for PHP via Java อนุญาตให้คุณสร้างรูปภาพ EMF จากแผ่นงาน Excel และเพิ่มรูปภาพเหล่านั้นเป็น EMF ลงสไลด์ด้วย Aspose.Cells  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำภารกิจที่อธิบายไว้:  

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # บันทึกเวิร์กบุ๊กไปยังสตรีม
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บอยู่ใน Image Collection ของการนำเสนอ (รวมถึงรูปที่ใช้โดยรูปร่างสไลด์) ส่วนนี้แสดงวิธีการหลายแบบเพื่ออัปเดตรูปภาพในคอลเลกชัน API มีเมธอดง่าย ๆ สำหรับแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/), หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน  

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. โหลดรูปภาพใหม่จากไฟล์เข้าสู่ byte array  
1. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้ byte array  
1. วิธีที่สอง: โหลดรูปภาพเข้าสู่อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น  
1. วิธีที่สาม: แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ  
1. บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

```php
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์การนำเสนอ.
$presentation = new Presentation("sample.pptx");
try {
    // วิธีแรก.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // วิธีที่สอง.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // วิธีที่สาม.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // บันทึกการนำเสนอไปยังไฟล์.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

โดยใช้เครื่องมือแปลงฟรีของ Aspose [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหว, สร้าง GIF จากข้อความ ฯลฯ ได้อย่างง่ายดาย  

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของรูปภาพต้นฉบับยังคงเหมือนเดิมหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่การแสดงผลสุดท้ายขึ้นอยู่กับการสเกล [picture](/slides/th/php-java/picture-frame/) บนสไลด์และการบีบอัดที่ทำในขั้นตอนการบันทึก  

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ใน Image Collection ของการนำเสนอ — การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น  

**SVG ที่แทรกเข้าไปสามารถแปลงเป็น shapes ที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของ shapes หลังจากนั้นส่วนประกอบแต่ละส่วนจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของ shapes  

**จะตั้งรูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**

[Assign the image as the background](/slides/th/php-java/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง — สไลด์ที่ใช้ master/layout นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ  

**ทำอย่างไรเพื่อป้องกันไม่ให้การนำเสนอขยายขนาดใหญ่เกินไปจากรูปภาพจำนวนมาก?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำซ้ำหลายครั้ง, เลือกความละเอียดที่เหมาะสม, ใช้การบีบอัดเมื่อบันทึก, และเก็บกราฟิกที่ทำซ้ำไว้บน master เมื่อเหมาะสม  