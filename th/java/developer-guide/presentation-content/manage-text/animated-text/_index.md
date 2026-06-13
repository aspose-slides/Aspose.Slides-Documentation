---
title: ทำให้ข้อความ PowerPoint เคลื่อนไหวใน Java
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/java/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- การแอนิเมชันข้อความ
- ย่อหน้าเคลื่อนไหว
- การแอนิเมชันย่อหน้า
- เอฟเฟกต์แอนิเมชัน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java พร้อมตัวอย่างโค้ด Java ที่ทำตามง่ายและได้รับการปรับให้เหมาะที่สุด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับข้อความที่มีการเคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์แอนิเมชันกับย่อหน้าแต่ละย่อหน้าและการดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วสำหรับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้ในการเพิ่มแอนิเมชันระดับย่อหน้าและตรวจสอบเอฟเฟกต์แอนิเมชันย่อหน้าที่มีอยู่ในงานนำเสนอ

## **เพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้า**

เราได้เพิ่มเมธอด [**addEffect()**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) ให้กับคลาส [**Sequence**](https://reference.aspose.com/slides/th/java/com.aspose.slides/Sequence) และ [**ISequence**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISequence) เมธอดนี้ทำให้คุณสามารถเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // เลือกย่อหน้าเพื่อเพิ่มเอฟเฟกต์
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // เพิ่มเอฟเฟกต์แอนิเมชัน Fly ให้กับย่อหน้าที่เลือก
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **รับเอฟเฟกต์แอนิเมชันของย่อหน้า**

คุณอาจต้องการค้นหาเอฟเฟกต์แอนิเมชันที่เพิ่มเข้าไปในย่อหน้า ตัวอย่างเช่น ในสถานการณ์หนึ่งคุณต้องการดึงเอฟเฟกต์แอนิเมชันจากย่อหน้าเพื่อใช้กับย่อหน้าหรือรูปร่างอื่น

Aspose.Slides for Java ให้คุณดึงเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (รูปร่าง) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึงเอฟเฟกต์แอนิเมชันในย่อหน้า:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**การแอนิเมชันข้อความต่างจากการเปลี่ยนสไลด์อย่างไรและสามารถใช้ร่วมกันได้หรือไม่?**

การแอนิเมชันข้อความควบคุมพฤติกรรมของวัตถุตามเวลาในสไลด์ ในขณะที่ [transitions](/slides/th/java/slide-transition/) ควบคุมวิธีการเปลี่ยนสไลด์ ทั้งสองเป็นอิสระกันและสามารถใช้ร่วมกันได้; ลำดับการเล่นถูกกำหนดโดยไทม์ไลน์ของแอนิเมชันและการตั้งค่า transition

**เอฟเฟกต์แอนิเมชันข้อความยังคงอยู่เมื่อส่งออกเป็น PDF หรือภาพหรือไม่?**

ไม่ PDF และภาพแบบแรสเตอร์เป็นคงที่ ดังนั้นคุณจะเห็นสถานะหนึ่งของสไลด์โดยไม่มีการเคลื่อนไหว หากต้องการคงการเคลื่อนไหวให้ใช้การส่งออกเป็น [video](/slides/th/java/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/java/export-to-html5/)

**แอนิเมชันข้อความทำงานในเลเอาต์และมาสเตอร์สไลด์หรือไม่?**

เอฟเฟกต์ที่ใช้กับวัตถุในเลเอาต์/มาสเตอร์จะสืบทอดไปยังสไลด์ แต่เวลาการทำงานและการโต้ตอบกับแอนิเมชันระดับสไลด์ขึ้นอยู่กับลำดับสุดท้ายบนสไลด์