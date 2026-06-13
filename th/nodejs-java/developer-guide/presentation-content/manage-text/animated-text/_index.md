---
title: ทำให้ข้อความ PowerPoint เคลื่อนไหวใน JavaScript
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/nodejs-java/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- การเคลื่อนไหวของข้อความ
- ย่อหน้าที่เคลื่อนไหว
- การเคลื่อนไหวของย่อหน้า
- เอฟเฟกต์การเคลื่อนไหว
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Node.js พร้อมตัวอย่างโค้ดที่ทำตามง่ายและปรับแต่งให้มีประสิทธิภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับข้อความเคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์แอนิเมชันกับย่อหน้าต่าง ๆ และดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วให้กับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้เพื่อเพิ่มแอนิเมชันระดับย่อหน้าและตรวจสอบเอฟเฟกต์แอนิเมชันของย่อหน้าที่มีอยู่ในงานนำเสนอ

## **การเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้า**

เราได้เพิ่มเมธอด [**addEffect()**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) ไปยังคลาส [**Sequence**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Sequence) และ [**Sequence**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Sequence) เมธอดนี้ทำให้คุณสามารถเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียวได้ ตัวอย่างโค้ดต่อไปนี้จะแสดงวิธีการเพิ่มเอฟเฟกต์แอนิเมชันให้กับย่อหน้าเดียว:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // เลือกย่อหน้าเพื่อเพิ่มเอฟเฟกต์
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // เพิ่มเอฟเฟกต์แอนิเมชัน Fly ให้กับย่อหน้าที่เลือก
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **การดึงเอฟเฟกต์แอนิเมชันในย่อหน้า**

คุณอาจต้องการค้นหาเอฟเฟกต์แอนิเมชันที่เพิ่มเข้าไปในย่อหน้า ตัวอย่างเช่น ในสถานการณ์หนึ่งคุณต้องการดึงเอฟเฟกต์แอนิเมชันในย่อหน้าเนื่องจากคุณตั้งใจจะนำเอฟเฟกต์เหล่านั้นไปใช้กับย่อหน้าอื่นหรือรูปทรงอื่น

Aspose.Slides for Node.js via Java ช่วยให้คุณสามารถดึงเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (รูปร่าง) ตัวอย่างโค้ดต่อไปนี้จะแสดงวิธีการดึงเอฟเฟกต์แอนิเมชันในย่อหน้า:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**การแอนิเมชันข้อความแตกต่างจากการเปลี่ยนสไลด์อย่างไร และสามารถใช้ร่วมกันได้หรือไม่?**

แอนิเมชันข้อความควบคุมพฤติกรรมของวัตถุตลอดเวลาในสไลด์ ในขณะที่ [การเปลี่ยนสไลด์](/slides/th/nodejs-java/slide-transition/) ควบคุมการเปลี่ยนสไลด์ พวกมันทำงานแยกจากกันและสามารถใช้ร่วมกันได้; ลำดับการเล่นถูกกำหนดโดยไทม์ไลน์ของแอนิเมชันและการตั้งค่าการเปลี่ยนสไลด์

**แอนิเมชันข้อความถูกเก็บรักษาไว้เมื่อนำออกเป็น PDF หรือภาพหรือไม่?**

ไม่. PDF และภาพแบบแรสเตอร์เป็นแบบคงที่ ดังนั้นคุณจะเห็นสถานะเดียวของสไลด์โดยไม่มีการเคลื่อนไหว หากต้องการคงการเคลื่อนที่ ให้ใช้การส่งออกเป็น [วิดีโอ](/slides/th/nodejs-java/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/nodejs-java/export-to-html5/)

**แอนิเมชันข้อความทำงานในเลย์เอาต์และสไลด์มาสเตอร์หรือไม่?**

เอฟเฟกต์ที่ใช้กับอ็อบเจกต์ในเลย์เอาต์/มาสเตอร์จะสืบทอดไปยังสไลด์ แต่เวลาและการทำงานร่วมกับแอนิเมชันระดับสไลด์ขึ้นอยู่กับลำดับสุดท้ายบนสไลด์