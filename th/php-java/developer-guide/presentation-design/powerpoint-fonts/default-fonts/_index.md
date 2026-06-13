---
title: ระบุแบบอักษรเริ่มต้นสำหรับการนำเสนอใน PHP
linktitle: แบบอักษรเริ่มต้น
type: docs
weight: 30
url: /th/php-java/default-font/
keywords:
- แบบอักษรเริ่มต้น
- แบบอักษรปกติ
- แบบอักษรธรรมดา
- แบบอักษรเอเชีย
- การส่งออก PDF
- การส่งออก XPS
- การส่งออกภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ตั้งค่าแบบอักษรเริ่มต้นใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้การแปลง PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ไปยัง PDF, XPS และภาพทำได้อย่างถูกต้อง."
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุแบบอักษรเริ่มต้นที่ใช้เมื่อการนำเสนอถูกเรนเดอร์ นำไปใช้ในการสร้างภาพย่อสไลด์หรือส่งออกการนำเสนอเป็นรูปแบบต่าง ๆ เช่น PDF และ XPS แบบอักษรเริ่มต้นจะถูกกำหนดผ่าน `LoadOptions` ก่อนที่การนำเสนอจะถูกโหลด

เมธอด `setDefaultRegularFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความทั่วไป ในขณะที่ `setDefaultAsianFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความเอเชีย หลังจากตั้งค่าตัวเลือกเหล่านี้แล้ว การนำเสนอสามารถโหลดและเรนเดอร์ด้วยแบบอักษรที่ระบุได้

## **ใช้แบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอ**
Aspose.Slides ให้คุณตั้งค่าแบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอเป็น PDF, XPS หรือภาพย่อ บทความนี้แสดงวิธีการกำหนด DefaultRegular Font และ DefaultAsian Font เพื่อใช้เป็นแบบอักษรเริ่มต้น โปรดทำตามขั้นตอนด้านล่างเพื่อโหลดแบบอักษรจากไดเรกทอรีภายนอกโดยใช้ Aspose.Slides for PHP ผ่าน Java API:

1. สร้างอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ไปยังแบบอักษรที่คุณต้องการ ตัวอย่างต่อไปนี้ใช้ Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ไปยังแบบอักษรที่คุณต้องการ ฉันใช้ Wingdings ในตัวอย่างต่อไปนี้.
4. โหลดการนำเสนอโดยใช้ Presentation และตั้งค่าตัวเลือกการโหลด.
5. จากนั้นสร้างภาพย่อสไลด์, PDF และ XPS เพื่อยืนยันผลลัพธ์.

```php
  # ใช้ตัวเลือกการโหลดเพื่อกำหนดแบบอักษรปกติและแบบอักษรเอเชียเริ่มต้น
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # โหลดการนำเสนอ
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # สร้างภาพย่อสไลด์
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # บันทึกรูปภาพลงดิสก์.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # สร้าง PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # สร้าง XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**DefaultRegularFont และ DefaultAsianFont มีผลอย่างไรบ้าง—เฉพาะการส่งออกหรือรวมถึงภาพย่อ, PDF, XPS, HTML, และ SVG ด้วย?**

พวกเขามีส่วนร่วมในกระบวนการเรนเดอร์สำหรับผลลัพธ์ที่รองรับทั้งหมด ซึ่งรวมถึงภาพย่อสไลด์, [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/php-java/convert-powerpoint-to-xps/), [ภาพแรสเตอร์](/slides/th/php-java/convert-powerpoint-to-png/), [HTML](/slides/th/php-java/convert-powerpoint-to-html/), และ [SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/), เนื่องจาก Aspose.Slides ใช้ตรรกะการจัดวางและการแก้ไข glyph เดียวกันสำหรับเป้าหมายเหล่านี้

**แบบอักษรเริ่มต้นจะถูกนำไปใช้หรือไม่เมื่อเพียงอ่านและบันทึก PPTX โดยไม่มีการเรนเดอร์ใด ๆ?**

ไม่ แบบอักษรเริ่มต้นมีความสำคัญเมื่อข้อความต้องวัดและวาด การเปิด‑บันทึกโดยตรงของการนำเสนอไม่เปลี่ยนแปลงรันของแบบอักษรที่เก็บหรือโครงสร้างของไฟล์ แบบอักษรเริ่มต้นจะมีผลเมื่อดำเนินการเรนเดอร์หรือจัดรูปข้อความใหม่

**ถ้าฉันเพิ่มโฟลเดอร์แบบอักษรของฉันเองหรือจัดหาแบบอักษรจากหน่วยความจำ จะถูกพิจารณาเมื่อตั้งค่าแบบอักษรเริ่มต้นหรือไม่?**

ใช่ [Custom font sources](/slides/th/php-java/custom-font/) ขยายแค็ตตาล็อกของฟอนต์และ glyph ที่มีให้เครื่องยนต์ใช้งาน แบบอักษรเริ่มต้นและ [fallback rules](/slides/th/php-java/fallback-font/) จะตรวจสอบแหล่งเหล่านี้เป็นอันดับแรก ทำให้การรองรับบนเซิร์ฟเวอร์และคอนเทนเนอร์มีความน่าเชื่อถือมากขึ้น

**แบบอักษรเริ่มต้นจะส่งผลต่อเมตริกของข้อความ (kerning, advances) และทำให้การตัดบรรทัดและการห่อข้อความเปลี่ยนแปลงหรือไม่?**

ใช่ การเปลี่ยนแบบอักษรจะเปลี่ยนเมตริกของ glyph และอาจทำให้การตัดบรรทัด, การห่อข้อความ, และการแบ่งหน้าเปลี่ยนแปลงในระหว่างการเรนเดอร์ เพื่อความเสถียรของการจัดวาง ควร [embed the original fonts](/slides/th/php-java/embedded-font/) หรือเลือกฟอนต์เริ่มต้นและ fallback ที่เข้ากันทางเมตริก

**มีความจำเป็นต้องตั้งค่าแบบอักษรเริ่มต้นหรือไม่หากฟอนต์ทั้งหมดที่ใช้ในการนำเสนอถูกฝังแล้ว?**

โดยส่วนใหญ่ไม่จำเป็น เพราะ [embedded fonts](/slides/th/php-java/embedded-font/) ทำให้รูปลักษณ์สอดคล้องอยู่แล้ว แบบอักษรเริ่มต้นยังคงเป็นเครือข่ายสำรองสำหรับอักขระที่ไม่ครอบคลุมโดยชุดฝังหรือเมื่อไฟล์มีการผสมข้อความที่ฝังและไม่ได้ฝัง