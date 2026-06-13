---
title: สร้างและใช้เอฟเฟกต์ WordArt ใน JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /th/nodejs-java/wordart/
keywords:
- WordArt
- สร้าง WordArt
- แม่แบบ WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การแสดงผล
- เอฟเฟกต์แสงเรืองแสง
- การแปลง WordArt
- เอฟเฟกต์ 3 มิติ
- เอฟเฟกต์เงานอก
- เอฟเฟกต์เงาใน
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ Node.js คู่มือนี้แนะนำขั้นตอนทีละขั้นตอนเพื่อช่วยให้นักพัฒนาเพิ่มประสิทธิภาพการนำเสนอด้วยข้อความระดับมืออาชีพ"
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่มีรูปลักษณ์สวยงามและสไตล์ให้กับงานนำเสนอ PowerPoint ของคุณ ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt ได้เช่นเดียวกับใน Microsoft PowerPoint—โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมของการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ การเติมสี การกำหนดขอบเงาและตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาในงานนำเสนอของคุณดูมีชีวิตชีวาและดึงดูดมากขึ้น WordArt ทำให้ข้อความเป็นวัตถุกราฟิก โดยใช้เอฟเฟกต์หรือการเปลี่ยนแปลงพิเศษที่ทำให้ข้อความดูโดดเด่นหรือสังเกตได้ง่ายขึ้น

## **การสร้างเทมเพลต WordArt ง่าย ๆ และการนำไปใช้กับข้อความ**

**ใช้ Aspose.Slides** 

ขั้นแรก เราสร้างข้อความง่าย ๆ ด้วยโค้ด JavaScript นี้:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
ต่อไป เราจะตั้งค่าขนาดฟอนต์ของข้อความให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เห็นชัดเจนยิ่งขึ้นด้วยโค้ดนี้:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**ใช้ Microsoft PowerPoint**

ไปที่เมนู WordArt effects ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดไว้ล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่ได้  

นี่คือบางส่วนของพารามิเตอร์หรือทางเลือกที่มีให้:

![todo:image_alt_text](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี่ เราใช้สีแบบลาย [SmallGrid](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PatternStyle#SmallGrid) กับข้อความและเพิ่มเส้นขอบสีดำความกว้าง 1 ด้วยโค้ดนี้:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

ข้อความที่ได้:

![todo:image_alt_text](image-20200930114108-4.png)

## **การใช้เอฟเฟกต์ WordArt อื่น ๆ**

**ใช้ Microsoft PowerPoint**

จากคลาสของโปรแกรม คุณสามารถนำเอฟเฟกต์เหล่านี้ไปใช้กับข้อความ, กลุ่มข้อความ, รูปร่าง หรือองค์ประกอบคล้าย ๆ กันได้:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟกต์เงา, การสะท้อนแสง, และแสงเรืองแสงสามารถนำไปใช้กับข้อความ; เอฟเฟกต์ 3D Format และ 3D Rotation สามารถนำไปใช้กับกลุ่มข้อความ; คุณสมบัติ Soft Edges สามารถนำไปใช้กับ Shape Object (ยังคงมีผลอยู่แม้ไม่มีการตั้งค่า 3D Format)

### **การนำเอฟเฟกต์เงาไปใช้**

ที่นี่ เราตั้งค่าคุณสมบัติเกี่ยวกับข้อความเท่านั้น เรานำเอฟเฟกต์เงาไปใช้กับข้อความด้วยโค้ด JavaScript นี้:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Aspose.Slides API รองรับเงา 3 ชนิด: OuterShadow, InnerShadow, และ PresetShadow  

ด้วย PresetShadow คุณสามารถนำเงามาใช้กับข้อความ (โดยใช้ค่าที่กำหนดไว้ล่วงหน้า)

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาชนิดเดียวเท่านั้น ตัวอย่างเช่น:

![todo:image_alt_text](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาได้สองชนิดพร้อมกัน: InnerShadow และ PresetShadow

**หมายเหตุ:**

- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะมีแต่เอฟเฟกต์ OuterShadow ถูกนำไปใช้
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์หรือเอฟเฟกต์ที่นำไปใช้จะขึ้นกับเวอร์ชันของ PowerPoint เช่น ใน PowerPoint 2013 เอฟเฟกต์จะซ้อนสองครั้ง แต่ใน PowerPoint 2007 จะใช้เฉพาะเอฟเฟกต์ OuterShadow เท่านั้น

### **การนำเอฟเฟกต์แสงสว่าง (Display) ไปใช้กับข้อความ**

เราติดตั้งแสงสว่างให้กับข้อความด้วยตัวอย่างโค้ด JavaScript นี้:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **การนำเอฟเฟกต์แสงเรืองแสง (Glow) ไปใช้กับข้อความ**

เรานำเอฟเฟกต์แสงเรืองแสงไปใช้กับข้อความเพื่อให้ดูสว่างหรือโดดเด่นด้วยโค้ดนี้:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

คุณสามารถเปลี่ยนพารามิเตอร์ของเงา, แสงสว่าง, และแสงเรืองแสงได้ คุณสมบัติของเอฟเฟกต์จะถูกตั้งค่าแยกกันในแต่ละส่วนของข้อความ  

{{% /alert %}} 

### **การใช้การแปลง (Transformations) ใน WordArt**

เราใช้คุณสมบัติ Transform (ซึ่งมีผลต่อบล็อกข้อความทั้งหมด) ด้วยโค้ดนี้:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

ทั้ง Microsoft PowerPoint และ Aspose.Slides สำหรับ Node.js via Java มีประเภทการแปลงที่กำหนดไว้ล่วงหน้าหลายประเภท  

{{% /alert %}} 

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดไว้ล่วงหน้า ไปที่: **Format** -> **TextEffect** -> **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ให้ใช้ enum TextShapeType

### **การนำเอฟเฟกต์ 3D ไปใช้กับข้อความและรูปร่าง**

เราตั้งค่าเอฟเฟกต์ 3D ให้กับรูปร่างข้อความด้วยตัวอย่างโค้ดนี้:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

ข้อความและรูปร่างที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟกต์ 3D ไปใช้กับข้อความด้วยโค้ด JavaScript นี้:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

การนำเอฟเฟกต์ 3D ไปใช้กับข้อความหรือรูปร่างของมันและการโต้ตอบระหว่างเอฟเฟกต์ต่าง ๆ ถูกกำหนดตามกฎบางประการ  

พิจารณาฉากสำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3D ประกอบด้วยการแสดงออบเจ็กต์ 3D และฉากที่ออบเจ็กต์ถูกวาง  

- เมื่อกำหนดฉากให้กับทั้งรูปและข้อความ ฉากของรูปจะได้ลำดับความสำคัญสูงกว่า—ข้อความจะถูกละเลย  
- เมื่อรูปไม่มีฉากของตนเองแต่มีการแสดง 3D จะใช้ฉากของข้อความ  
- ในกรณีอื่น—เมื่อรูปเดิมไม่มีเอฟเฟกต์ 3D—รูปจะเป็นแบนและเอฟเฟกต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น  

คำอธิบายเหล่านี้เกี่ยวข้องกับเมธอด ThreeDFormat.getLightRig() และ ThreeDFormat.getCamera()  

{{% /alert %}} 

## **การนำเอฟเฟกต์ Outer Shadow ไปใช้กับข้อความ**

Aspose.Slides สำหรับ Node.js via Java มีคลาส [**OuterShadow**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/outershadow/) และ [**InnerShadow**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/innershadow/) ที่ให้คุณนำเอฟเฟกต์เงาไปใช้กับข้อความที่อยู่ใน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม AutoShape ประเภท Rectangle ลงในสไลด์
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill
6. สร้างอินสแตนซ์ของคลาส OuterShadow
7. ตั้งค่า BlurRadius ของเงา
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา
10. ตั้งค่า RectanglelAlign เป็น TopLeft
11. ตั้งค่า PresetColor ของเงาเป็น Black
12. เขียนงานนำเสนอออกเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)  

โค้ดตัวอย่างใน Java ที่แสดงขั้นตอนข้างต้นเพื่อทำการนำเอฟเฟกต์ Outer Shadow ไปใช้กับข้อความมีดังนี้:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // รับอ้างอิงของสไลด์
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภท Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame("Aspose TextBox");
    // ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาของข้อความ
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // เพิ่มเงานอกและตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // เขียนงานนำเสนอลงดิสก์
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การนำเอฟเฟกต์ Inner Shadow ไปใช้กับรูปร่าง**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
2. รับอ้างอิงของสไลด์
3. เพิ่ม AutoShape ประเภท Rectangle
4. เปิดใช้งาน InnerShadowEffect
5. ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
6. ตั้งค่า ColorType เป็น Scheme
7. ตั้งค่าสี Scheme
8. เขียนงานนำเสนอออกเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)  

โค้ดตัวอย่าง (ตามขั้นตอนข้างต้น) ที่แสดงวิธีการเพิ่มคอนเน็กเตอร์ระหว่างสองรูปร่างใน JavaScript มีดังนี้:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // รับอ้างอิงของสไลด์
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภท Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // เปิดใช้ InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ตั้งค่า ColorType เป็น Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // ตั้งค่าสี Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // บันทึกงานนำเสนอ
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่แตกต่างกัน (เช่น Arabic, Chinese) ได้หรือไม่?**

ใช่, Aspose.Slides รองรับ Unicode และทำงานร่วมกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติมสี, และขอบสามารถนำไปใช้ได้โดยไม่คำนึงถึงภาษาที่ใช้ แม้ว่าความพร้อมของฟอนต์และการแสดงผลอาจขึ้นอยู่กับฟอนต์ที่ติดตั้งในระบบ

**ฉันสามารถนำเอฟเฟกต์ WordArt ไปใช้กับองค์ประกอบของ slide master ได้หรือไม่?**

ได้, คุณสามารถนำเอฟเฟกต์ WordArt ไปใช้กับรูปร่างบนสไลด์มาสเตอร์ได้ รวมถึง placeholder ของหัวเรื่อง, ส่วนท้าย, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาต์มาสเตอร์จะสะท้อนไปยังสไลด์ทั้งหมดที่เชื่อมโยง

**เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์งานนำเสนอหรือไม่?**

เล็กน้อย การใช้เอฟเฟกต์ WordArt เช่น เงา, แสงเรืองแสง, หรือการเติมสีแบบไล่ระดับอาจทำให้ขนาดไฟล์เพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาต้าเพิ่มเติมของการจัดรูปแบบ แต่ส่วนต่าง ๆ มักไม่มีผลอย่างมีนัยสำคัญ

**ฉันสามารถดูตัวอย่างผลลัพธ์ของเอฟเฟกต์ WordArt ได้โดยไม่ต้องบันทึกงานนำเสนอหรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt ให้เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `getImage` จากคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) หรือ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) วิธีนี้ช่วยให้คุณดูตัวอย่างผลลัพธ์แบบอิน‑เมมโมรีหรือบนหน้าจอก่อนที่จะทำการบันทึกหรือส่งออกงานนำเสนอเต็มรูปแบบ