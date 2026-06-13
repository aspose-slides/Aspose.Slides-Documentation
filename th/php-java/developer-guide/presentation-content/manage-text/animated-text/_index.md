---
title: ทำแอนิเมชันข้อความ PowerPoint ใน PHP
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/php-java/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- แอนิเมชันข้อความ
- ย่อหน้าที่เคลื่อนไหว
- แอนิเมชันย่อหน้า
- เอฟเฟกต์แอนิเมชัน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมตัวอย่างโค้ดที่เข้าใจง่ายและได้รับการปรับแต่งให้มีประสิทธิภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับข้อความเคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์แอนิเมชันกับย่อหน้าแต่ละย่อหน้าและการดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วในย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้เพื่อเพิ่มแอนิเมชันระดับย่อหน้าและตรวจสอบเอฟเฟกต์แอนิเมชันของย่อหน้าที่มีอยู่ในงานพรีเซนเตชั่น

## **เพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้า**

เราได้เพิ่มเมธอด [**addEffect()**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) ไปยังคลาส [**Sequence**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Sequence) เมธอดนี้ช่วยให้คุณสามารถเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มเอฟเฟ็กต์แอนิเมชันให้กับย่อหน้าเดียว:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # เลือกย่อหน้าที่จะเพิ่มเอฟเฟกต์
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # เพิ่มเอฟเฟกต์แอนิเมชัน Fly ให้กับย่อหน้าที่เลือก
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **รับเอฟเฟกต์แอนิเมชันของย่อหน้า**

คุณอาจต้องการค้นหาเอฟเฟกต์แอนิเมชันที่เพิ่มให้กับย่อหน้า เช่น ในบางสถานการณ์คุณต้องการดึงเอฟเฟกต์แอนิเมชันในย่อหน้าเพื่อใช้กับย่อหน้าอื่นหรือรูปทรงอื่น

Aspose.Slides for PHP via Java ช่วยให้คุณรับเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (รูปทรง) ตัวอย่างโค้ดนี้แสดงวิธีการรับเอฟเฟกต์แอนิเมชันในย่อหน้า:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**แอนิเมชันข้อความแตกต่างจากการเปลี่ยนสไลด์อย่างไรและสามารถรวมกันได้หรือไม่?**

แอนิเมชันข้อความควบคุมพฤติกรรมของวัตถุตามกาลเวลาในสไลด์ ขณะที่ [การเปลี่ยนสไลด์](/slides/th/php-java/slide-transition/) ควบคุมวิธีการเปลี่ยนจากสไลด์หนึ่งไปยังอีกสไลด์หนึ่ง ทั้งสองเป็นอิสระและสามารถใช้ร่วมกันได้; ลำดับการเล่นจะกำหนดโดยไทม์ไลน์ของแอนิเมชันและการตั้งค่าการเปลี่ยนสไลด์

**แอนิเมชันข้อความจะยังคงอยู่เมื่อส่งออกเป็น PDF หรือภาพหรือไม่?**

ไม่ครับ PDF และภาพแรสเตอร์เป็นแบบคงที่ ดังนั้นคุณจะเห็นสถานะเดียวของสไลด์โดยไม่มีการเคลื่อนไหว หากต้องการเก็บการเคลื่อนไหวให้ใช้การส่งออกเป็น [วิดีโอ](/slides/th/php-java/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/php-java/export-to-html5/)

**แอนิเมชันข้อความทำงานในเลเอาต์และสไลด์มาสเตอร์หรือไม่?**

เอฟเฟกต์ที่ใช้กับวัตถุในเลเอาต์/มาสเตอร์จะสืบทอดไปยังสไลด์ แต่การกำหนดเวลาและการโต้ตอบกับแอนิเมชันระดับสไลด์จะขึ้นอยู่กับลำดับสุดท้ายบนสไลด์นั้น