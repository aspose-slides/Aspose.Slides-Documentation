---
title: "จัดการกรอบรูปในการนำเสนอด้วย PHP"
linktitle: "กรอบรูป"
type: docs
weight: 10
url: /th/php-java/picture-frame/
keywords:
- "กรอบรูป"
- "เพิ่มกรอบรูป"
- "สร้างกรอบรูป"
- "เพิ่มภาพ"
- "สร้างภาพ"
- "แยกรูปภาพ"
- "รูปแรสเตอร์"
- "รูปเวกเตอร์"
- "ตัดภาพ"
- "พื้นที่ที่ถูกตัด"
- "คุณสมบัติ StretchOff"
- "การจัดรูปแบบกรอบรูป"
- "คุณสมบัติกรอบรูป"
- "สเกลสัมพันธ์"
- "เอฟเฟกต์ภาพ"
- "อัตราส่วนภาพ"
- "ความโปร่งใสของภาพ"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "PHP"
- "Aspose.Slides"
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. ทำให้กระบวนการทำงานของคุณลื่นไหลและปรับปรุงการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปคือรูปร่างที่บรรจุภาพ—คล้ายภาพในกรอบ  

คุณสามารถเพิ่มรูปภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้ทำให้คุณจัดรูปแบบรูปภาพโดยจัดรูปแบบกรอบรูป  

{{% alert  title="Tip" color="primary" %}} 

Aspose ให้บริการแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนอจากรูปภาพได้อย่างรวดเร็ว  

{{% /alert %}} 

## **Create a Picture Frame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) โดยการเพิ่มรูปภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่เชื่อมกับอ็อบเจ็กต์ Presentation เพื่อใช้เป็นการเติมรูปร่าง  
4. ระบุความกว้างและความสูงของรูปภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) โดยใช้เมธอด `addPictureFrame` ของอ็อบเจ็กต์ shape ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ซึ่งบรรจุรูปภาพ) ลงในสไลด์  
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # รับสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของคลาส Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างของภาพที่เท่ากัน
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

กรอบรูปช่วยให้คุณสร้างสไลด์การนำเสนอจากรูปภาพได้อย่างรวดเร็ว เมื่อคุณผสมกรอบรูปกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการแปลงรูปภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/php-java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-png/); แปลง [PNG to JPG](https://products.aspose.com/slides/th/php-java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/php-java/conversion/png-to-svg/); แปลง [SVG to PNG](https://products.aspose.com/slides/th/php-java/conversion/svg-to-png/)  

{{% /alert %}} 

## **Create a Picture Frame with Relative Scale**

โดยการปรับสเกลสัมพันธ์ของรูปภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มรูปภาพลงใน ImageCollection ของการนำเสนอ  
4. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) โดยการเพิ่มรูปภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่เชื่อมกับอ็อบเจ็กต์ Presentation เพื่อใช้เป็นการเติมรูปร่าง  
5. ระบุความกว้างและความสูงสัมพันธ์ของรูปภาพในกรอบรูป  
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
  $pres = new Presentation();
  try {
    # รับสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของคลาส Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างเท่ากับของภาพ
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ตั้งค่าสเกลสัมพันธ์ความกว้างและความสูง
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extract Raster Images from Picture Frames**

คุณสามารถแยกรูปภาพ Raster จากอ็อบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) และบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ตัวอย่างโค้ดด้านล่างแสดงวิธีแยกรูปภาพจากไฟล์ “sample.pptx” แล้วบันทึกเป็น PNG  

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

## **Extract SVG Images from Picture Frames**

เมื่อการนำเสนอมีกราฟิก SVG อยู่ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) Aspose.Slides for PHP via Java จะช่วยให้คุณดึงรูปเวกเตอร์ SVG ดั้งเดิมออกมาได้อย่างเต็มที่ โดยการวนผ่านคอลเลกชันของรูปทรงบนสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ตรวจสอบว่า [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) มีเนื้อหา SVG หรือไม่ แล้วบันทึกเป็นไฟล์ SVG  

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

## **Get Transparency of an Image**

Aspose.Slides ให้คุณรับค่าการทำให้รูปภาพโปร่งใส โค้ด PHP ด้านล่างแสดงการทำงาน  

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

## **Get Brightness and Contrast of an Image**

Aspose.Slides ให้คุณรับค่าความสว่างและคอนทราสต์ที่ถูกประยุกต์กับรูปภาพ คลาส [Luminance](https://reference.aspose.com/slides/th/php-java/aspose.slides/luminance/) แทนการแปลงนี้  

โค้ด PHP ด้านล่างแสดงวิธีดึงค่าความสว่างและคอนทราสต์จากกรอบรูป  

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Picture Frame Formatting**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับกรอบรูปได้ ด้วยตัวเลือกเหล่านี้คุณสามารถปรับกรอบรูปให้ตรงกับข้อกำหนดเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) โดยการเพิ่มรูปภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่เชื่อมกับอ็อบเจ็กต์ Presentation เพื่อใช้เป็นการเติมรูปร่าง  
4. ระบุความกว้างและความสูงของรูปภาพ  
5. สร้าง `PictureFrame` โดยใช้เมธอด [addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) ของอ็อบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ซึ่งบรรจุรูปภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยระบุค่าเป็นบวกหรือค่าลบ  
   * ค่าเป็นบวกจะหมุนตามเข็มนาฬิกา  
   * ค่าเป็นลบจะหมุนทวนเข็มนาฬิกา  
10. เพิ่มกรอบรูป (ซึ่งบรรจุรูปภาพ) ลงในสไลด์  
11. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # รับสไลด์แรก
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
    # เขียนไฟล์ PPTX ลงดิสก์
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [merge JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [create grids from photos](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  

{{% /alert %}}

## **Add an Image as a Link**

เพื่อหลีกเลี่ยงขนาดการนำเสนอที่ใหญ่ คุณสามารถเพิ่มรูปภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรง โค้ด PHP ด้านล่างแสดงวิธีเพิ่มรูปภาพและวิดีโอลงใน placeholder  

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

## **Crop Images**

โค้ด PHP ด้านล่างแสดงวิธีตัดส่วนของรูปภาพที่มีอยู่บนสไลด์  

```php
  $pres = new Presentation();
  # สร้างอ็อบเจ็กต์รูปภาพใหม่
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
    # ตัดรูปภาพ (ค่าร้อยละ)
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

## **Delete Cropped Areas of a Picture**

หากต้องการลบส่วนที่ถูกตัดของรูปภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) เมธอดนี้จะคืนค่ารูปที่ถูกตัดหรือรูปเดิมหากไม่จำเป็นต้องตัด  

โค้ด PHP ด้านล่างแสดงการทำงาน  

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # ดึง PictureFrame จากสไลด์แรก
    $picFrame = $slide->getShapes()->get_Item(0);
    # ลบพื้นที่ที่ถูกตัดของภาพใน PictureFrame และส่งคืนภาพที่ถูกตัด
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # บันทึกผลลัพธ์
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) จะเพิ่มรูปที่ถูกตัดลงในคอลเลกชันรูปของการนำเสนอ หากรูปถูกใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) การตั้งค่านี้สามารถลดขนาดการนำเสนอได้ มิฉะนั้นจำนวนรูปในไฟล์ที่ได้จะเพิ่มขึ้น  

เมธอดนี้จะทำการแปลงไฟล์ WMF/EMF เป็นรูป PNG แรสเตอร์ในกระบวนการตัด  

{{% /alert %}}

## **Compress Images**

คุณสามารถบีบอัดรูปในงานนำเสนอได้โดยใช้เมธอด [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) เมธอดนี้จะลดขนาดรูปโดยอิงตามขนาดรูปร่างและความละเอียดที่กำหนด พร้อมตัวเลือกการลบส่วนที่ถูกตัด  

มันปรับขนาดและความละเอียดของรูปคล้ายคุณลักษณะ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง PHP ด้านล่างแสดงการบีบอัดรูปโดยระบุความละเอียดเป้าหมายและลบส่วนที่ถูกตัด (ถ้าต้องการ)  

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # ตรวจสอบผลของการบีบอัด
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

หรือใช้ค่ DPI ที่กำหนดเองโดยตรง  

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

เมธอดนี้จะลดความละเอียดของรูปตามขนาดรูปร่างและ DPI ที่ระบุ ส่วนที่ถูกตัดสามารถลบเพื่อเพิ่มประสิทธิภาพขนาดไฟล์ได้  
หากรูปเป็นเมตะไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะถูกเก็บไว้หรืออาจลดลงเล็กน้อยตามความละเอียดเช่นเดียวกับ PowerPoint  

{{% /alert %}}

## **Lock Aspect Ratio**

หากต้องการให้รูปร่างที่บรรจุรูปภาพคงอัตราส่วนแม้หลังจากเปลี่ยนขนาดรูปภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) เพื่อตั้งค่าการ **Lock Aspect Ratio**  

โค้ด PHP ด้านล่างแสดงวิธีล็อกอัตราส่วนของรูปร่าง  

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
    # ตั้งรูปให้คงอัตราส่วนเมื่อปรับขนาด
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

การตั้งค่า **Lock Aspect Ratio** นี้จะรักษาอัตราส่วนของรูปร่างเท่านั้น ไม่ได้ล็อกอัตราส่วนของรูปภาพที่อยู่ภายใน  

{{% /alert %}}

## **Use the StretchOff Property**

โดยใช้เมธอด [setStretchOffsetLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) และ [setStretchOffsetBottom](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) คุณสามารถกำหนดสี่เหลี่ยมเติมได้  

เมื่อกำหนดการยืดสำหรับรูปภาพสี่เหลี่ยมแหล่งจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่กำหนด แต่ละขอบของสี่เหลี่ยมเติมถูกกำหนดโดยออฟเซ็ตเป็นเปอร์เซ็นต์จากขอบของกล่องขอบรูปร่าง ออฟเซ็ตบวกหมายถึงการย่อเข้า ในขณะที่ออฟเซ็ตลบหมายถึงการขยายออก  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างรูปภาพ  
5. ตั้งค่าชนิดการเติมของรูปร่าง  
6. ตั้งค่าโหมดการเติมรูปภาพของรูปร่าง  
7. เพิ่มรูปที่ใช้เติมรูปร่าง  
8. ระบุออฟเซ็ตของรูปจากขอบที่สอดคล้องของกล่องขอบรูปร่าง  
9. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # รับสไลด์แรก
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
    # เพิ่ม AutoShape ตั้งค่าเป็นสี่เหลี่ยมผืนผ้า
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # ตั้งค่าชนิดการเติมของรูปร่าง
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # ตั้งค่าโหมดการเติมรูปภาพของรูปร่าง
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # ตั้งค่ารูปภาพเพื่อเติมรูปร่าง
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # ระบุออฟเซ็ตของรูปภาพจากขอบที่สอดคล้องของกล่องขอบรูปร่าง
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # เขียนไฟล์ PPTX ลงดิสก์
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**  
คุณสามารถตรวจสอบได้ว่ารูปแบบภาพใดรองรับสำหรับ [PictureFrame] โดย Aspose.Slides รองรับทั้งภาพแรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame] รายการรูปแบบที่รองรับมักสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ  

**How will adding dozens of large images affect PPTX size and performance?**  
การฝังรูปภาพขนาดใหญ่หลายรูปจะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์รูปภาพช่วยลดขนาดการนำเสนอแต่ต้องให้ไฟล์ภายนอกเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มรูปภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์  

**How can I lock an image object from accidental moving/resizing?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/getpictureframelock/) สำหรับ [PictureFrame] (เช่น ปิดการย้ายหรือปรับขนาด) กลไกการล็อกนี้รองรับหลายประเภทของรูปร่าง รวมถึง [PictureFrame]  

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  
Aspose.Slides สามารถแยกรูป SVG จาก [PictureFrame] เป็นเวกเตอร์ดั้งเดิมได้ เมื่อ [exporting to PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/php-java/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; ความจริงที่ว่า SVG ดั้งเดิมยังคงเป็นเวกเตอร์จะได้รับการยืนยันจากการแยกไฟล์.