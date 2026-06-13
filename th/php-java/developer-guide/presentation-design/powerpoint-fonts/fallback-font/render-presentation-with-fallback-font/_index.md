---
title: แสดงงานนำเสนอด้วยฟอนต์สำรองใน PHP
linktitle: แสดงงานนำเสนอ
type: docs
weight: 30
url: /th/php-java/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- แสดง PowerPoint
- แสดงงานนำเสนอ
- แสดงสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แสดงงานนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ PHP ผ่าน Java – รักษาข้อความให้สอดคล้องกันในไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ดขั้นตอนต่อขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณแสดงสไลด์โดยใช้กฎฟอนต์สำรอง บทความนี้แสดงวิธีสร้างคอลเลกชันกฎฟอนต์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันให้กับเมธอด `FontsManager::setFontFallBackRulesCollection`.

เมื่อคอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ กฎเหล่านี้จะถูกใช้ในระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การแสดงผล, และการแปลงงานนำเสนอ ตัวอย่างแสดงวิธีใช้กฎที่ตั้งค่าไว้เมื่อแสดงภาพย่อของสไลด์และบันทึกเป็นภาพ PNG.

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนเหล่านี้:

1. เรา [สร้างคอลเลกชันกฎฟอนต์สำรอง](/slides/th/php-java/create-fallback-fonts-collection/).
2. [ลบ](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) กฎฟอนต์สำรองหนึ่งรายการและ [addFallBackFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ไปยังกฎอื่น.
3. ตั้งค่าคอลเลกชันกฎให้กับ [getFontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) เมธอด.
4. ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#save-java.lang.String-int-) เราสามารถบันทึกงานนำเสนอในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ [FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontsManager) กฎเหล่านี้จะถูกใช้ในระหว่างการดำเนินการใด ๆ บนงานนำเสนอ: บันทึก, แสดงผล, แปลง, เป็นต้น.

```php
  # สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
  $rulesList = new FontFallBackRulesCollection();
  # สร้างจำนวนกฎหลายรายการ
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # พยายามลบฟอนต์สำรอง "Tahoma" จากกฎที่โหลด
    $fallBackRule->remove("Tahoma");
    # และอัปเดตกฎสำหรับช่วงที่ระบุ
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # นอกจากนี้เรายังสามารถลบกฎที่มีอยู่ใด ๆ จากรายการ
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # กำหนดรายการกฎที่เตรียมไว้เพื่อใช้งาน
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าแล้วและบันทึกเป็น JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [แปลง PPT และ PPTX ไปเป็น JPG ใน PHP](/slides/th/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}