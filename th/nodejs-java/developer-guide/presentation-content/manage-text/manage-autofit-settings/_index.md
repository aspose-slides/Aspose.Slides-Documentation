---
title: เพิ่มประสิทธิภาพการพรีเซนเทชันของคุณด้วย AutoFit ใน JavaScript
linktitle: การตั้งค่า Autofit
type: docs
weight: 30
url: /th/nodejs-java/manage-autofit-settings/
keywords:
- กล่องข้อความ
- ปรับอัตโนมัติให้พอดี
- ไม่ใช้การปรับอัตโนมัติ
- ทำให้ข้อความพอดี
- ย่อข้อความ
- ห่อข้อความ
- ปรับขนาดรูปร่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการการตั้งค่า AutoFit ใน Aspose.Slides สำหรับ Node.js เพื่อเพิ่มประสิทธิภาพการแสดงผลข้อความในงานพรีเซนเทชัน PowerPoint และ OpenDocument ของคุณและปรับปรุงความชัดเจนของเนื้อหา."
---
## **Introduction**

โดยค่าเริ่มต้นเมื่อคุณเพิ่มกล่องข้อความ Microsoft PowerPoint จะใช้การตั้งค่า **Resize shape to fix text** สำหรับกล่องข้อความ — ระบบจะปรับขนาดกล่องข้อความโดยอัตโนมัติเพื่อให้ข้อความอยู่ในกรอบเสมอ  

![กล่องข้อความใน PowerPoint](textbox-in-powerpoint.png)

* เมื่อข้อความในกล่องข้อความยาวหรือใหญ่ขึ้น PowerPoint จะขยายกล่องข้อความโดยเพิ่มความสูงเพื่อให้บรรจุข้อความได้มากขึ้น  
* เมื่อข้อความในกล่องข้อความสั้นหรือเล็กลง PowerPoint จะลดขนาดกล่องข้อความโดยลดความสูงเพื่อลบพื้นที่ว่างที่ไม่จำเป็น  

ใน PowerPoint มี 4 พารามิเตอร์หรือทางเลือกสำคัญที่ควบคุมพฤติกรรม autofit ของกล่องข้อความ:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![ตัวเลือก autofit ใน PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java มีตัวเลือกที่คล้ายกัน — คุณสมบัติบางอย่างภายในคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) — ที่ช่วยให้คุณควบคุมพฤติกรรม autofit สำหรับกล่องข้อความในงานนำเสนอ

## **Resize Shape to Fit Text**

หากคุณต้องการให้ข้อความในกล่องเสมออยู่ในกรอบหลังจากมีการเปลี่ยนแปลงใด ๆ คุณต้องใช้ตัวเลือก **Resize shape to fix text** เมื่อต้องการกำหนดการตั้งค่านี้ ให้เรียกเมธอด [setAutofitType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) โดยระบุค่า `Shape`

![การตั้งค่า alwaysfit ใน PowerPoint](alwaysfit-setting-powerpoint.png)

โค้ด JavaScript นี้แสดงวิธีการกำหนดให้ข้อความต้องพอดีในกล่องเสมอในงานนำเสนอ PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

หากข้อความยาวหรือใหญ่ขึ้น กล่องข้อความจะถูกปรับขนาดอัตโนมัติ (เพิ่มความสูง) เพื่อให้ข้อความทั้งหมดพอดี หากข้อความสั้นลงก็จะเกิดการทำงานตรงกันข้าม

## **Do Not Autofit**

หากต้องการให้กล่องข้อความหรือรูปทรงคงขนาดเดิมไม่ว่าเนื้อความจะเปลี่ยนแปลงอย่างไร คุณต้องใช้ตัวเลือก **Do not Autofit** เมื่อต้องการกำหนดการตั้งค่านี้ ให้เรียกเมธอด [setAutofitType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) โดยระบุค่า `None`

![การตั้งค่า donotautofit ใน PowerPoint](donotautofit-setting-powerpoint.png)

โค้ด JavaScript นี้แสดงวิธีการกำหนดให้กล่องข้อความคงขนาดเดิมตลอดในงานนำเสนอ PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

เมื่อข้อความยาวเกินขนาดกล่อง มันจะล้นออกมา

## **Shrink Text on Overflow**

หากข้อความยาวเกินขนาดกล่อง คุณสามารถใช้ตัวเลือก **Shrink text on overflow** เพื่อบ่งบอกให้ระบบลดขนาดและระยะห่างของข้อความให้พอดีในกรอบ เมื่อต้องการกำหนดการตั้งค่านี้ ให้เรียกเมธอด [setAutofitType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) โดยระบุค่า `Normal`

![การตั้งค่า shrinktextonoverflow ใน PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

โค้ด JavaScript นี้แสดงวิธีการกำหนดให้ข้อความถูกย่อลดเมื่อเกิด overflow ในงานนำเสนอ PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
เมื่อใช้ตัวเลือก **Shrink text on overflow** การตั้งค่านี้จะทำงานเฉพาะเมื่อตัวข้อความยาวเกินขนาดกล่องเท่านั้น  
{{% /alert %}}

## **Wrap Text**

หากต้องการให้ข้อความในรูปทรงห่อหุ้มภายในรูปทรงเมื่อข้อความเกินขอบ (กว้างเท่านั้น) คุณต้องใช้พารามิเตอร์ **Wrap text in shape** เมื่อต้องการกำหนดการตั้งค่านี้ ให้เรียกเมธอด [setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) โดยระบุค่า `true`

โค้ด JavaScript นี้แสดงวิธีการใช้ตั้งค่า Wrap Text ในงานนำเสนอ PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
หากคุณเรียกเมธอด `setWrapText` ด้วยค่า `False` สำหรับรูปทรง เมื่อข้อความภายในรูปทรงยาวกว่าความกว้างของรูปทรง ข้อความจะต่อเนื่องออกนอกขอบของรูปทรงในบรรทัดเดียว  
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**  
ใช่ — Padding (ระยะขอบภายใน) ลดพื้นที่ที่ใช้ได้สำหรับข้อความ ดังนั้น AutoFit จะทำงานเร็วกว่าด้วยการย่อฟอนต์หรือปรับขนาดรูปทรงก่อน ตรวจสอบและปรับระยะขอบก่อนทำการปรับ AutoFit

**How does AutoFit interact with manual and soft line breaks?**  
การแบ่งบรรทัดแบบบังคับจะคงอยู่และ AutoFit จะปรับขนาดฟอนต์และระยะห่างรอบ ๆ การแบ่งบรรทัดนั้น การลบการแบ่งบรรทัดที่ไม่จำเป็นมักช่วยลดความต้องการของ AutoFit ในการย่อข้อความ

**Does changing the theme font or triggering font substitution affect AutoFit results?**  
ใช่ — การเปลี่ยนฟอนต์หรือการแทนที่ฟอนต์ที่มีเมตริกซ์ glyph ต่างกันจะเปลี่ยนความกว้าง/ความสูงของข้อความ ซึ่งอาจทำให้ขนาดฟอนต์สุดท้ายและการห่อบรรทัดเปลี่ยนแปลง หลังจากเปลี่ยนฟอนต์ใด ๆ ควรตรวจสอบสไลด์อีกครั้ง