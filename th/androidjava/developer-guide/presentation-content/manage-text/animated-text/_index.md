---
title: ทำให้ข้อความ PowerPoint เคลื่อนไหวบน Android
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/androidjava/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- การเคลื่อนไหวของข้อความ
- ย่อหน้าเคลื่อนไหว
- การเคลื่อนไหวของย่อหน้า
- เอฟเฟกต์การเคลื่อนไหว
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด Java ที่ทำตามได้ง่ายและได้รับการปรับให้เหมาะสม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับข้อความเคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์การเคลื่อนไหวกับย่อหน้าต่างๆ และการดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วให้กับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้ในการเพิ่มการเคลื่อนไหวระดับย่อหน้าและตรวจสอบเอฟเฟกต์การเคลื่อนไหวของย่อหน้าที่มีอยู่ในงานนำเสนอ

## **เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้า**

เราได้เพิ่มเมธอด [**addEffect()**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) ไปยังคลาส [**Sequence**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Sequence) และ [**ISequence**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISequence) เมธอดนี้ทำให้คุณสามารถเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้าเดียวได้ ตัวอย่างโค้ดด้านล่างแสดงวิธีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้าเดียว:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // เลือกย่อหน้าที่จะเพิ่มเอฟเฟกต์
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly ให้กับย่อหน้าที่เลือก
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **รับเอฟเฟกต์การเคลื่อนไหวของย่อหน้า**

คุณอาจต้องการค้นหาเอฟเฟกต์การเคลื่อนไหวที่เพิ่มเข้าไปในย่อหน้า—for ตัวอย่างหนึ่ง คุณอาจต้องการดึงเอฟเฟกต์การเคลื่อนไหวจากย่อหน้าเพื่อที่จะนำเอาฟเฟกต์เหล่านั้นไปใช้กับย่อหน้าอื่นหรือรูปร่างอื่น

Aspose.Slides for Android via Java ให้คุณดึงเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับย่อหน้าในกรอบข้อความ (รูปทรง) ตัวอย่างโค้ดด้านล่างแสดงวิธีการดึงเอฟเฟกต์การเคลื่อนไหวในย่อหน้า:

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

**How do text animations differ from slide transitions, and can they be combined?**

การเคลื่อนที่ของข้อความควบคุมพฤติกรรมของวัตถุตามเวลาในสไลด์ ส่วน [transitions](/slides/th/androidjava/slide-transition/) ควบคุมการเปลี่ยนสไลด์ พวกมันทำงานแยกจากกันและสามารถใช้ร่วมกันได้; ลำดับการเล่นจะถูกกำหนดโดยไทม์ไลน์ของการเคลื่อนที่และการตั้งค่าการเปลี่ยนสไลด์

**Are text animations preserved when exporting to PDF or images?**

ไม่ PDF และภาพเรสเตอร์เป็นแบบคงที่ ดังนั้นคุณจะเห็นสไลด์ในสภาพเดียวโดยไม่มีการเคลื่อนไหว หากต้องการรักษาการเคลื่อนไหว ให้ใช้การส่งออกเป็น [video](/slides/th/androidjava/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/androidjava/export-to-html5/)

**Do text animations work in layouts and the slide master?**

เอฟเฟกต์ที่ใช้กับวัตถุในเลย์เอาต์/มาสเตอร์จะถูกสืบทอดไปยังสไลด์ แต่เวลาการทำงานและการโต้ตอบกับการเคลื่อนที่ระดับสไลด์จะขึ้นอยู่กับลำดับสุดท้ายในสไลด์นั้น