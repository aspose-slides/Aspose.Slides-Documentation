---
title: จัดการธีมการนำเสนอใน PHP
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/php-java/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ให้มีการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/php-java/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/php-java/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยกำหนดสีใหม่ให้ธีม เพื่อให้คุณสามารถเลือกสีธีมใหม่ Aspose.Slides มีค่าต่าง ๆ ใน enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/SchemeColor)

โค้ด PHP นี้แสดงวิธีเปลี่ยนสีอักเซนท์สำหรับธีม:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

คุณสามารถกำหนดค่าที่แท้จริงของสีที่ได้จากการดำเนินการนี้ได้ดังนี้:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

เพื่อสาธิตการเปลี่ยนสีเพิ่มเติม เราจะสร้างองค์ประกอบอื่นและกำหนดสีอักเซนท์ (จากการดำเนินการแรก) ให้กับมัน จากนั้นเปลี่ยนสีในธีม:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติกับทั้งสององค์ประกอบ

### **กำหนดสีธีมจากพาเลตเพิ่มเติม**

เมื่อคุณใช้การแปลงความสว่างกับสีธีมหลัก(1) จะสร้างสีจากพาเลตเพิ่มเติม(2) ขึ้นมา แล้วคุณสามารถตั้งค่าและดึงค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก  
**2** - สีจากพาเลตเพิ่มเติม

โค้ด PHP นี้แสดงการดึงสีจากพาเลตเพิ่มเติมโดยอ้างอิงจากสีธีมหลักและนำไปใช้ในรูปทรง:

```php
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        # Accent 4
        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
        $shape1->getFillFormat()->setFillType(FillType::Solid);
        $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
        # Accent 4, สีอ่อน 80%
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
        $shape2->getFillFormat()->setFillType(FillType::Solid);
        $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
        $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
        $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
        # Accent 4, สีอ่อน 60%
        $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
        $shape3->getFillFormat()->setFillType(FillType::Solid);
        $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
        $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
        $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
        # Accent 4, สีอ่อน 40%
        $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
        $shape4->getFillFormat()->setFillType(FillType::Solid);
        $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
        $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
        $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
        # Accent 4, สีเข้ม 25%
        $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
        $shape5->getFillFormat()->setFillType(FillType::Solid);
        $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
        $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
        # Accent 4, สีเข้ม 50%
        $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
        $shape6->getFillFormat()->setFillType(FillType::Solid);
        $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
        $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
        $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
```

### **แมป `SchemeColor` ไปยังสี `ColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) คุณอาจสังเกตว่าในนั้นมีค่าธีมสีต่อไปนี้:

`Background1`, `Background2`, `Text1`, และ `Text2`

อย่างไรก็ตาม `Presentation::getMasterTheme()::getColorScheme()` คืนค่า [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/) ซึ่งเผยสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, และ `Light2`

ความแตกต่างนี้มีเพียงชื่อ ค่าเหล่านี้อ้างอิงถึงช่องสีธีมเดียวกันและการแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกมันเป็นเพียงชื่อทางเลือกของสีธีมเดียวกัน

ความแตกต่างของการตั้งชื่อนี้มาจากเทอร์มินัลของ Microsoft Office เวอร์ชันเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ส่วน UI เวอร์ชันใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกแบบอักษรสำหรับธีมและการใช้งานอื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - ตัวอักษรหลัก Latin (Minor Latin Font)
* **+mj-lt** - ตัวอักษรหัวเรื่อง Latin (Major Latin Font)
* **+mn-ea** - ตัวอักษรหลัก East Asian (Minor East Asian Font)
* **+mj-ea** - ตัวอักษรหัวเรื่อง East Asian (Major East Asian Font)

โค้ด PHP นี้แสดงวิธีกำหนดแบบอักษร Latin ให้กับองค์ประกอบของธีม:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

โค้ด PHP นี้แสดงวิธีเปลี่ยนแบบอักษรธีมของการนำเสนอ:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

แบบอักษรในกล่องข้อความทั้งหมดจะถูกอัปเดต

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [PowerPoint fonts](/slides/th/php-java/powerpoint-fonts/). 
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังของธีม**

โดยค่าเริ่มต้น แอป PowerPoint มีพื้นหลังแบบกำหนดล่วงหน้าอยู่ 12 แบบ แต่ในงานนำเสนอทั่วไปจะบันทึกเพียง 3 แบบจาก 12 แบบเท่านั้น

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากคุณบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด PHP นี้เพื่อค้นหาจำนวนพื้นหลังกำหนดล่วงหน้าในงานนำเสนอได้:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
โดยใช้ property [BackgroundFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/FormatScheme) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint ได้ 
{{% /alert %}} 

โค้ด PHP นี้แสดงวิธีตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**คู่มือดัชนี**: 0 ใช้สำหรับไม่มีการเติม สีเริ่มต้นที่ 1

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [PowerPoint Background](/slides/th/php-java/presentation-background/). 
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติมีค่า 3 ค่าในแต่ละอาร์เรย์สไตล์ อาร์เรย์เหล่านั้นรวมเป็น 3 เอฟเฟกต์: ละเอียดอ่อน, ปานกลาง, และเข้มข้น ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปทรงเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้คุณสมบัติ 3 อย่าง ([FillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/FormatScheme#getEffectStyles--)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/FormatScheme) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้อย่างยืดหยุ่นกว่าใน PowerPoint

โค้ด PHP นี้แสดงวิธีเปลี่ยนเอฟเฟกต์ธีมโดยการแก้ไขส่วนต่าง ๆ ขององค์ประกอบ:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ประเภทการเติม, เอฟเฟกต์เงา ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถนำธีมไปใช้กับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ใช่ Aspose.Slides รองรับการกำหนดธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมท้องถิ่นกับสไลด์นั้นโดยไม่กระทบธีมมาสเตอร์ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

ใช้การ [Clone slides](/slides/th/php-java/clone-slides/) พร้อมกับมาสเตอร์ของมันไปยังงานนำเป้าหมาย วิธีนี้จะคงมาสเตอร์, เลเยาต่าง ๆ, และธีมที่เชื่อมโยงไว้ ทำให้รูปลักษณ์คงที่

**ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการบังคับใช้ทั้งหมดได้อย่างไร?**

ใช้ “effective” view ของ API [/slides/th/php-java/shape-effective-properties/] สำหรับธีม/สี/แบบอักษร/เอฟเฟกต์ ซึ่งจะคืนค่าคุณสมบัติที่สรุปแล้วหลังจากรวมมาสเตอร์และการบังคับใช้ในระดับท้องถิ่น.