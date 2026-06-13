---
title: "สร้างและใช้เอฟเฟกต์ WordArt บน Android"
linktitle: "WordArt"
type: docs
weight: 110
url: /th/androidjava/wordart/
keywords:
- WordArt
- สร้าง WordArt
- แม่แบบ WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การแสดงผล
- เอฟเฟกต์แสงเรือง
- การแปลง WordArt
- เอฟเฟกต์ 3D
- เอฟเฟกต์เงาเด่นนอก
- เอฟเฟกต์เงาใน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ Android คู่มือขั้นตอนนี้ช่วยให้นักพัฒนาปรับปรุงการนำเสนอด้วยข้อความระดับมืออาชีพใน Java."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่มีสไตล์และดึงดูดสายตาในงานนำเสนอ PowerPoint ของคุณได้อย่างสวยงาม ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt ได้โดยอัตโนมัติ เหมือนกับใน Microsoft PowerPoint—โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมของการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ สไตล์การเติม สีขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาในงานนำเสนอของคุณมีความแสดงออกและน่าสนใจมากขึ้น WordArt ทำให้คุณสามารถถือข้อความเป็นวัตถุกราฟิก มันประกอบด้วยเอฟเฟกต์หรือการปรับเปลี่ยนพิเศษที่ใช้กับข้อความเพื่อทำให้ดูน่าสนใจหรือโดดเด่นยิ่งขึ้น

## **สร้างแม่แบบ WordArt ง่าย ๆ และนำไปใช้กับข้อความ**

**Using Aspose.Slides** 

ก่อนอื่นเราจะสร้างข้อความง่าย ๆ ด้วยโค้ด Java นี้:

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
ต่อมาเราตั้งค่าความสูงของฟอนต์ให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เด่นชัดยิ่งขึ้นด้วยโค้ดนี้:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Using Microsoft PowerPoint**

ไปที่เมนูเอฟเฟกต์ WordArt ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่ได้

นี่คือตัวอย่างของพารามิเตอร์หรือทางเลือกที่มี:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

ที่นี้เรานำรูปแบบสี [SmallGrid](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PatternStyle#SmallGrid) ไปใช้กับข้อความและเพิ่มเส้นขอบสีดำความกว้าง 1 ด้วยโค้ดนี้:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

ข้อความที่ได้:

![todo:image_alt_text](image-20200930114108-4.png)

## **ใช้เอฟเฟกต์ WordArt อื่น ๆ**

**Using Microsoft PowerPoint**

จากส่วนติดต่อของโปรแกรม คุณสามารถใช้เอฟเฟกต์เหล่านี้กับข้อความ บล็อกข้อความ รูปร่าง หรือองค์ประกอบที่คล้ายกัน:

![todo:image_alt_text](image-20200930114129-5.png)

เช่น เงา (Shadow), การสะท้อน (Reflection) และแสงเรือง (Glow) สามารถใช้กับข้อความได้; ฟอร์แมต 3 มิติ (3D Format) และการหมุน 3 มิติ (3D Rotation) สามารถใช้กับบล็อกข้อความ; คุณสมบัติขอบอ่อน (Soft Edges) สามารถใช้กับวัตถุ Shape (ยังคงทำงานเมื่อไม่ได้ตั้งค่า 3D Format)

### **ใช้เอฟเฟกต์เงา**

ที่นี้เราตั้งค่าคุณสมบัติที่เกี่ยวข้องกับข้อความเท่านั้น โดยใช้โค้ด Java นี้เพื่อใส่เงาให้กับข้อความ:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API รองรับเงาสามประเภท: OuterShadow, InnerShadow, และ PresetShadow

ด้วย PresetShadow คุณสามารถใส่เงาให้กับข้อความโดยใช้ค่าที่กำหนดไว้ล่วงหน้า

**Using Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาประเภทเดียวเท่านั้น ตัวอย่างเช่น:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้ใช้เงาสองประเภทพร้อมกัน: InnerShadow และ PresetShadow

**Notes:**
- เมื่อใช้ OuterShadow กับ PresetShadow พร้อมกัน จะได้เฉพาะเอฟเฟกต์ OuterShadow เท่านั้น
- หากใช้ OuterShadow และ InnerShadow ร่วมกัน ผลลัพธ์หรือเอฟเฟกต์ที่ใช้จะขึ้นอยู่กับเวอร์ชัน PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะซ้ำสองเท่า แต่ใน PowerPoint 2007 จะใช้เอฟเฟกต์ OuterShadow เท่านั้น

### **ใช้เอฟเฟกต์การสะท้อนกับข้อความ**

เราจะเพิ่มการสะท้อนให้กับข้อความด้วยโค้ด Java นี้:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **ใช้เอฟเฟกต์แสงเรืองกับข้อความ**

เราจะใส่เอฟเฟกต์แสงเรืองให้กับข้อความเพื่อให้มันส่องสว่างหรือโดดเด่นด้วยโค้ดนี้:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา การสะท้อน และแสงเรืองได้ คุณสมบัติของเอฟเฟกต์จะถูกตั้งค่าต่อแต่ละส่วนของข้อความแยกกัน 

{{% /alert %}} 

### **ใช้การแปลงใน WordArt**

เราใช้คุณสมบัติ Transform (ซึ่งมีผลกับบล็อกข้อความทั้งหมด) ด้วยโค้ดนี้:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

ทั้ง Microsoft PowerPoint และ Aspose.Slides for Android via Java มีประเภทการแปลงที่กำหนดล่วงหน้าจำนวนหนึ่ง

{{% /alert %}} 

**Using PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดล่วงหน้า ไปที่: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

เพื่อเลือกประเภทการแปลง ใช้ enum `TextShapeType`

### **ใช้เอฟเฟกต์ 3D กับข้อความและรูปร่าง**

เราตั้งค่าเอฟเฟกต์ 3D ให้กับรูปร่างข้อความด้วยโค้ดตัวอย่างนี้:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

ข้อความและรูปร่างที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟกต์ 3D ไปใช้กับข้อความด้วยโค้ด Java นี้:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

การใช้เอฟเฟกต์ 3D กับข้อความหรือรูปร่างของมันและการโต้ตอบระหว่างเอฟเฟกต์ต่าง ๆ มีเงื่อนไขตามกฎบางประการ

พิจารณาฉากสำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3D ประกอบด้วยการแสดงวัตถุ 3D และฉากที่วัตถุถูกวาง

- เมื่อฉากถูกกำหนดไว้ทั้งสำหรับรูปร่างและข้อความ ฉากของรูปร่างจะได้รับความสำคัญสูงกว่า—ฉากของข้อความจะถูกละเว้น
- เมื่อรูปร่างไม่มีฉากของตนเองแต่มีการแสดงผล 3D จะใช้ฉากของข้อความ
- หากไม่มีเอฟเฟกต์ 3D กับรูปร่างเดิม รูปร่างจะเป็นแบนและเอฟเฟกต์ 3D จะถูกใช้เฉพาะกับข้อความเท่านั้น

คำอธิบายเหล่านี้เชื่อมโยงกับเมธอด `ThreeDFormat.getLightRig()` และ `ThreeDFormat.getCamera()`

{{% /alert %}} 

## **ใช้เอฟเฟกต์ Outer Shadow กับข้อความ**
Aspose.Slides for Android via Java มีคลาส [**IOuterShadow**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioutershadow/) และ [**IInnerShadow**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinnershadow/) ที่ให้คุณใส่เงาให้กับข้อความที่อยู่ใน [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม AutoShape ชนิด Rectangle ลงในสไลด์
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill
6. สร้างอินสแทนซ์ของคลาส OuterShadow
7. ตั้งค่า BlurRadius ของเงา
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา
10. ตั้งค่า RectanglelAlign เป็น TopLeft
11. ตั้งค่า PresetColor ของเงาเป็น Black
12. เขียนพรีเซนเทชันเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)

โค้ดตัวอย่างใน Java—การทำตามขั้นตอนข้างต้น—แสดงวิธีใส่เอฟเฟกต์ Outer Shadow ให้กับข้อความ:

```java
Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิด Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // ปิดการเติมสีรูปร่างในกรณีที่ต้องการเงาของข้อความ
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่มเงานอกและตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //บันทึกพรีเซนเทชันลงดิสก์
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ใช้เอฟเฟกต์ Inner Shadow กับรูปร่าง**
ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. รับอ้างอิงของสไลด์
3. เพิ่ม AutoShape ชนิด Rectangle
4. เปิดใช้งาน InnerShadowEffect
5. ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
6. ตั้งค่า ColorType เป็น Scheme
7. ตั้งค่าสี Scheme
8. เขียนพรีเซนเทชันเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)

โค้ดตัวอย่าง (ตามขั้นตอนข้างต้น) แสดงวิธีเพิ่มคอนเน็กเตอร์ระหว่างสองรูปร่างใน Java:

```java
Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิด Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // เปิดใช้งาน InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ตั้งค่า ColorType เป็น Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // ตั้งค่าสี Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // บันทึกพรีเซนเทชัน
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I use WordArt effects with different fonts or scripts (e.g., Arabic, Chinese)?**

ใช่, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติมสี, และขอบสามารถใช้ได้โดยไม่คำนึงถึงภาษา แม้ว่าความพร้อมใช้ของฟอนต์และการเรนเดอร์อาจขึ้นกับฟอนต์ในระบบ

**Can I apply WordArt effects to slide master elements?**

ใช่, คุณสามารถใส่เอฟเฟกต์ WordArt ให้กับรูปร่างบนสไลด์มาสเตอร์ได้รวมถึงตัวยึดหัวเรื่อง, ส่วนท้าย หรือข้อความพื้นหลัง การเปลี่ยนแปลงบนแม่แบบจะส่งผลกับสไลด์ที่เชื่อมโยงทั้งหมด

**Do WordArt effects affect presentation file size?**

ส่งผลเล็กน้อย เอฟเฟกต์ WordArt เช่น เงา, แสงเรือง, และการเติมแบบไล่สีอาจเพิ่มขนาดไฟล์เล็กน้อยเนื่องจากข้อมูลเมตาเพิ่มเติม แต่ส่วนต่างมักไม่สำคัญ

**Can I preview the result of WordArt effects without saving the presentation?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) ด้วยเมธอด `getImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ทำให้สามารถดูตัวอย่างผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกพรีเซนเทชันเต็มรูปแบบ