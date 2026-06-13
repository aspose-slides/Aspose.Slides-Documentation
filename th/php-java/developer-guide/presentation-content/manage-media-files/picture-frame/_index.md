---
title: จัดการกรอบรูปในงานนำเสนอโดยใช้ PHP
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/php-java/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพเวกเตอร์
- ครอบตัดภาพ
- พื้นที่ที่ถูกครอป
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติของกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. ทำให้กระบวนการทำงานของคุณเป็นระเบียบและเพิ่มคุณภาพการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปเป็นรูปทรงที่บรรจุภาพ—คล้ายกับภาพที่อยู่ในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบภาพโดยการจัดรูปแบบกรอบรูปได้

{{% alert  title="เคล็ดลับ" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากภาพ  

{{% /alert %}} 

## **สร้างกรอบรูป**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่เชื่อมกับอ็อบเจกต์การนำเสนอ ซึ่งจะใช้เพื่อเติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ตามความกว้างและความสูงของภาพผ่านเมธอด `addPictureFrame` ที่เปิดให้ใช้โดยอ็อบเจกต์รูปทรงที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างกรอบรูป:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของคลาส Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างที่เท่ากับของรูปภาพ
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # บันทึกไฟล์ PPTX ไปยังดิสก์
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

กรอบรูปช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อผสานกรอบรูปกับตัวเลือกการบันทึก Aspose.Slides คุณสามารถจัดการการนำเข้า/ส่งออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ คุณอาจต้องการดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/php-java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/php-java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/php-java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/php-java/conversion/svg-to-png/)  

{{% /alert %}}

## **สร้างกรอบรูปด้วยสเกลสัมพัทธ์**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนยิ่งขึ้นได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของการนำเสนอ  
4. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่เชื่อมกับอ็อบเจกต์การนำเสนอ เพื่อใช้เติมรูปทรง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของภาพในกรอบรูป  
6. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างกรอบรูปด้วยสเกลสัมพัทธ์:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของคลาส Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างเท่ากับของรูปภาพ
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # บันทึกไฟล์ PPTX ไปยังดิสก์
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สกัดภาพเรสเตอร์จากกรอบรูป**

คุณสามารถสกัดภาพเรสเตอร์จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) แล้วบันทึกในรูปแบบ PNG, JPG และรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **สกัดภาพ SVG จากกรอบรูป**

เมื่อการนำเสนอมีกราฟิก SVG อยู่ในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) Aspose.Slides for PHP via Java ให้คุณดึงภาพเวกเตอร์ดั้งเดิมออกมาได้อย่างครบถ้วนโดยการ traversing คอลเลกชันรูปทรงของสไลด์เพื่อระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/), ตรวจสอบว่า [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่อยู่ภายใต้มีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีสกัดภาพ SVG จากกรอบรูป:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **รับค่าความโปร่งใสของภาพ**

Aspose.Slides ให้คุณรับผลลัพธ์ความโปร่งใสที่ใช้กับภาพได้ โค้ด PHP นี้สาธิตการดำเนินการ:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบมากมายที่สามารถใช้กับกรอบรูปได้ ด้วยตัวเลือกเหล่านี้ คุณสามารถปรับกรอบรูปให้ตรงตามความต้องการเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่เชื่อมกับอ็อบเจกต์การนำเสนอเพื่อใช้เติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพผ่านเมธอด [addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) ที่เปิดให้ใช้โดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยกำหนดค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
11. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้สาธิตกระบวนการจัดรูปแบบกรอบรูป:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของคลาส Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างเท่ากับของรูปภาพ
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ใช้การจัดรูปแบบบางอย่างกับ PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # บันทึกไฟล์ PPTX ไปยังดิสก์
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="เคล็ดลับ" color="primary" %}}

Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [merge JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [create grids from photos](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  

{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดการนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงลงในงานนำเสนอ โค้ด PHP นี้แสดงวิธีเพิ่มภาพและวิดีโอเข้าไปในตัวแทน:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ครอบตัดภาพ**

โค้ด PHP นี้แสดงวิธีครอบตัดภาพที่มีอยู่ในสไลด์:

```php
  $pres = new Presentation();
  # สร้างอ็อบเจกต์ภาพใหม่
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # เพิ่ม PictureFrame ไปยังสไลด์
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # ครอบตัดภาพ (ค่าร้อยละ)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # บันทึกผลลัพธ์
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบพื้นที่ที่ถูกครอปของกรอบรูป**

หากต้องการลบพื้นที่ที่ถูกครอปของภาพที่อยู่ในกรอบรูป คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) เมธอดนี้จะคืนภาพที่ถูกครอปหรือภาพต้นฉบับหากไม่จำเป็นต้องครอป  

โค้ด PHP นี้สาธิตการดำเนินการ:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # ดึง PictureFrame จากสไลด์แรก
    $picFrame = $slide->getShapes()->get_Item(0);
    # ลบพื้นที่ที่ถูกครอปของภาพ PictureFrame และคืนภาพที่ถูกครอป
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # บันทึกผลลัพธ์
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="หมายเหตุ" color="warning" %}} 

เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) จะเพิ่มภาพที่ถูกครอปลงในคอลเลกชันภาพของการนำเสนอ หากภาพถูกใช้เพียงใน [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ที่ประมวลผลแล้ว การตั้งค่านี้จะช่วยลดขนาดการนำเสนอได้ มิฉะนั้นจำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมต้าไฟล์ WMF/EMF ไปเป็นภาพ PNG เรสเตอร์ในกระบวนการครอป  

{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปในงานนำเสนอโดยใช้เมธอด [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปทรงและความละเอียดที่ระบุ พร้อมตัวเลือกการลบพื้นที่ที่ถูกครอป  

มันปรับขนาดและความละเอียดของรูปคล้ายกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง PHP ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ถูกครอป:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอป.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # ตรวจสอบผลลัพธ์ของการบีบอัด.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หรือใช้ค่า DPI กำหนดเองโดยตรง:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอป.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

เมธอดนี้แปลงภาพเป็นความละเอียดต่ำตามขนาดรูปทรงและ DPI ที่กำหนด พื้นที่ที่ถูกครอปสามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ อย่างไรก็ตามคุณภาพ JPEG จะถูกเก็บไว้หรืออาจลดลงเล็กน้อยตามความละเอียด เหมือนกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง  

{{% /alert %}}

## **ล็อกอัตราส่วนภาพ**

หากคุณต้องการให้รูปทรงที่บรรจุภาพคงอัตราส่วนภาพไว้แม้หลังจากเปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) เพื่อตั้งค่าการ *Lock Aspect Ratio*  

โค้ด PHP นี้แสดงวิธีล็อกอัตราส่วนภาพของรูปทรง:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # ตั้งรูปทรงให้คงอัตราส่วนภาพเมื่อตัดขนาด
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="หมายเหตุ" color="warning" %}} 

การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปทรงเท่านั้น ไม่ได้รักษาภาพที่บรรจุอยู่  

{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้เมธอด [setStretchOffsetLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) และ [setStretchOffsetBottom](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) จากคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) คุณสามารถกำหนดสี่เหลี่ยมเติมได้  

เมื่อระบุการยืดสำหรับภาพ สี่เหลี่ยมต้นทางจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่กำหนด แต่ละขอบของสี่เหลี่ยมเติมถูกกำหนดโดยออฟเซ็ตเป็นเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องกรอบรูปของรูปทรง ค่าเปอร์เซ็นต์บวกหมายถึงการซ่อนขอบ (inset) ส่วนค่าเปอร์เซ็นต์ลบหมายถึงการขยายขอบ (outset)  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าชนิดการเติมของรูปทรง  
6. ตั้งค่าโหมดการเติมภาพของรูปทรง  
7. เพิ่มภาพที่ตั้งค่าให้เติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องกรอบรูปของรูปทรง  
9. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้สาธิตกระบวนการที่ใช้คุณสมบัติ StretchOff:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของคลาส ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # เพิ่ม AutoShape ที่ตั้งเป็น Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # ตั้งประเภทการเติมของรูปทรง
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # ตั้งโหมดการเติมภาพของรูปทรง
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # ตั้งภาพเพื่อเติมรูปทรง
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องกรอบรูปของรูปทรง
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # บันทึกไฟล์ PPTX ไปยังดิสก์
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันจะค้นหารูปแบบภาพที่รองรับสำหรับ PictureFrame ได้อย่างไร?**

Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับโดยทั่วไปสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ  

**การเพิ่มรูปภาพจำนวนมากจะมีผลต่อขนาดและประสิทธิภาพของไฟล์ PPTX อย่างไร?**

การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพช่วยลดขนาดไฟล์แต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์  

**ฉันจะล็อกอ็อบเจกต์ภาพเพื่อป้องกันการเคลื่อนย้าย/ปรับขนาดโดยไม่ตั้งใจได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/getpictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) (เช่น ปิดการเคลื่อนย้ายหรือการปรับขนาด) กลไกการล็อกนี้รองรับรูปทรงหลายประเภท รวมถึง [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/)  

**ความละเอียดเวกเตอร์ของ SVG จะคงอยู่เมื่อส่งออกงานนำเสนอเป็น PDF/รูปภาพหรือไม่?**

Aspose.Slides สามารถสกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิมได้ เมื่อ [export to PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/php-java/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการสกัดนี้.