---
title: ตั้งค่าคอลเลกชันฟอนต์สำรองใน PHP
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/php-java/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- คอลเลกชันฟอนต์
- ตั้งค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้ข้อความคงที่และคมชัดในงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดกฎฟอนต์สำรองสำหรับงานนำเสนอ แต่ละกฎฟอนต์สำรองถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มลงใน `FontFallBackRulesCollection` ได้

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับเมธอด `setFontFallBackRulesCollection` ของ `FontsManager` ของงานนำเสนอ `FontsManager` ควบคุมฟอนต์ทั่วทั้งงานนำเสนอ และแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของ[FontFallBackRule](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule)สามารถจัดเป็น[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRulesCollection)ได้ สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้

จากนั้นคอลเลกชันนี้อาจถูกกำหนดให้กับเมธอด[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRulesCollection)ของคลาส[FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontsManager) FontsManager ควบคุมฟอนต์ทั่วงานนำเสนอ

แต่ละ[Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)มีเมธอด[getFontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#getFontsManager)พร้อมอินสแตนซ์ของคลาส[FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontsManager)ของตนเอง

ต่อไปนี้คือตัวอย่างการสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ[FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#getFontsManager)ของงานนำเสนอบางงาน:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

หลังจาก FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับการเรนเดอร์งานนำเสนอด้วยฟอนต์สำรอง[Render Presentation with Fallback Font](/slides/th/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎฟอนต์สำรองของฉันจะฝังอยู่ในไฟล์ PPTX และปรากฏใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าเรนเดอร์ขณะทำงาน; ไม่ได้ถูกซีเรียลไลซ์ลงใน PPTX และจะไม่ปรากฏใน UI ของ PowerPoint

**ฟอนต์สำรองใช้กับข้อความใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?**

ใช่ กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้

**Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและรับผิดชอบต่อการใช้งานนั้น

**สามารถใช้การแทนที่/การทดแทนฟอนต์ที่หายไปและฟอนต์สำรองสำหรับ glyph ที่หายไปพร้อมกันได้หรือไม่?**

ได้ ทั้งสองเป็นขั้นตอนอิสระของไพพ์ไลน์การแก้ปัญหาฟอนต์เดียวกัน: ก่อนหน้าเอนจินจะตรวจสอบความพร้อมของฟอนต์ ([replacement](/slides/th/php-java/font-replacement/)/[substitution](/slides/th/php-java/font-substitution/)) แล้วฟอนต์สำรองจะเติมช่องว่างของ glyph ที่หายไปในฟอนต์ที่มีอยู่