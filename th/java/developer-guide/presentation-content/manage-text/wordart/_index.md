---
title: "สร้างและใช้เอฟเฟกต์ WordArt ใน Java"
linktitle: "WordArt"
type: docs
weight: 110
url: /th/java/wordart/
keywords:
- WordArt
- สร้าง WordArt
- แม่แบบ WordArt
- เอฟเฟ็กต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การแสดงผล
- เอฟเฟกต์เรืองแสง
- การแปลง WordArt
- เอฟเฟกต์ 3 มิติ
- เอฟเฟกต์เงานอก
- เอฟเฟกต์เงาใน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ Java คู่มือแบบขั้นตอนนี้ช่วยให้นักพัฒนาปรับปรุงการนำเสนอด้วยข้อความระดับมืออาชีพใน Java."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่มีลักษณะสวยงามและสไตล์ให้กับงานนำเสนอ PowerPoint ของคุณได้อย่างมีความน่าสนใจ ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt อย่างโปรแกรมเมทีบเหมือนใน Microsoft PowerPoint—โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมเกี่ยวกับการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ รูปแบบการเติม สีเส้นขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาในงานนำเสนอของคุณมีความแสดงออกและดึงดูดมากขึ้น WordArt ทำให้คุณสามารถจัดการข้อความเหมือนเป็นวัตถุกราฟิก ซึ่งประกอบด้วยเอฟเฟกต์หรือการแก้ไขพิเศษที่นำไปใช้กับข้อความเพื่อทำให้ดูน่าสนใจหรือเด่นขึ้น

## **สร้างเทมเพลต WordArt อย่างง่ายและนำไปใช้กับข้อความ**

**ใช้ Aspose.Slides** 

ก่อนแรก เราสร้างข้อความง่าย ๆ โดยใช้โค้ด Java นี้: 

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
ต่อไป เรากำหนดความสูงของฟอนต์ของข้อความให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เด่นขึ้นโดยใช้โค้ดนี้:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**ใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟกต์ WordArt ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูทางขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดล่วงหน้าได้ จากเมนูทางซ้าย คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่ได้

นี่คือบางส่วนของพารามิเตอร์หรือ ตัวเลือกที่มีให้:

![todo:image_alt_text](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี่ เราใช้สีรูปแบบ [SmallGrid](https://reference.aspose.com/slides/th/java/com.aspose.slides/PatternStyle#SmallGrid) กับข้อความและเพิ่มเส้นขอบข้อความสีดำความกว้าง 1 ด้วยโค้ดนี้:

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

## **การใช้เอฟเฟ็กต์ WordArt อื่น ๆ**

**ใช้ Microsoft PowerPoint**

จากอินเทอร์เฟซของโปรแกรม คุณสามารถใช้เอฟเฟกต์เหล่านี้กับข้อความ, กลุ่มข้อความ, รูปร่าง หรือองค์ประกอบที่คล้ายกันได้:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟกต์ Shadow, Reflection และ Glow สามารถนำไปใช้กับข้อความ; เอฟเฟกต์ 3D Format และ 3D Rotation สามารถนำไปใช้กับกลุ่มข้อความ; คุณสมบัติ Soft Edges สามารถนำไปใช้กับ Shape Object (ยังคงมีผลเมื่อไม่มีการตั้งค่า 3D Format)

### **การใช้เอฟเฟ็กต์เงา**

ที่นี่ เราตั้งค่าคุณลักษณะที่เกี่ยวกับข้อความเท่านั้น เราใช้เอฟเฟกต์เงากับข้อความโดยใช้โค้ดนี้ใน Java:

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

Aspose.Slides API รองรับเงา 3 ประเภท: OuterShadow, InnerShadow, และ PresetShadow

ด้วย PresetShadow คุณสามารถใช้เงาสำหรับข้อความ (โดยใช้ค่าที่กำหนดไว้ล่วงหน้า)

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาประเภทเดียวได้ ตัวอย่างดังนี้:

![todo:image_alt_text](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้ใช้เงา 2 ประเภทพร้อมกัน: InnerShadow และ PresetShadow

**หมายเหตุ:**

- เมื่อใช้ OuterShadow และ PresetShadow พร้อมกัน จะมีเพียงเอฟเฟกต์ OuterShadow ที่ถูกนำไปใช้
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์หรือเอฟเฟกต์ที่นำไปใช้ขึ้นอยู่กับเวอร์ชันของ PowerPoint ตัวอย่างเช่นใน PowerPoint 2013 เอฟเฟกต์จะเพิ่มเป็นสองเท่า แต่ใน PowerPoint 2007 จะใช้เอฟเฟกต์ OuterShadow

### **การใช้การแสดงผลกับข้อความ**

เราเพิ่มการแสดงผลให้กับข้อความโดยใช้ตัวอย่างโค้ดนี้ใน Java:

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

### **การใช้เอฟเฟกต์เรืองแสงกับข้อความ**

เรานำเอฟเฟกต์เรืองแสงไปใช้กับข้อความเพื่อให้มันสว่างหรือเด่นขึ้นโดยใช้โค้ดนี้:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

ผลลัพธ์ของการทำงาน:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา, การแสดงผล, และเรืองแสงได้ คุณสมบัติของเอฟเฟกต์จะถูกตั้งค่าแยกตามแต่ละส่วนของข้อความ 
{{% /alert %}} 

### **การใช้การแปลงใน WordArt**

เราจะใช้คุณสมบัติ Transform (ซึ่งสืบเนื่องมาจากบล็อกข้อความทั้งหมด) ผ่านโค้ดนี้:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
ทั้ง Microsoft PowerPoint และ Aspose.Slides สำหรับ Java มีการให้ประเภทการแปลงที่กำหนดล่วงหน้าจำนวนหนึ่ง 
{{% /alert %}} 

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดล่วงหน้า ให้ไปที่: **Format** -> **TextEffect** -> **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ให้ใช้ enum TextShapeType

### **การใช้เอฟเฟกต์ 3 มิติกับข้อความและรูปร่าง**

เราตั้งค่าเอฟเฟกต์ 3 มิติให้กับรูปร่างข้อความโดยใช้โค้ดตัวอย่างนี้:

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

เรานำเอฟเฟกต์ 3 มิติไปใช้กับข้อความด้วยโค้ด Java นี้:

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

ผลลัพธ์ของการทำงาน:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
การใช้เอฟเฟกต์ 3 มิติกับข้อความหรือรูปร่างของมันและการทำงานร่วมกันระหว่างเอฟเฟกต์นั้นขึ้นอยู่กับกฎบางประการ

ให้พิจารณาซีนสำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3 มิติมีการแสดงวัตถุ 3 มิติและซีนที่วัตถุถูกวาง

- เมื่อซีนถูกตั้งค่าสำหรับทั้งรูปและข้อความ ซีนของรูปจะได้ลำดับความสำคัญสูงกว่า – ซีนของข้อความจะถูกละเลย
- เมื่อรูปไม่มีซีนของตนเองแต่มีการแสดง 3 มิติ ซีนของข้อความจะถูกใช้
- มิฉะนั้น – เมื่อรูปร่างเดิมไม่มีเอฟเฟกต์ 3 มิติ รูปร่างจะเป็นแบนและเอฟเฟกต์ 3 มิติจะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น

คำอธิบายเหล่านี้เชื่อมโยงกับเมธอด ThreeDFormat.getLightRig() และ ThreeDFormat.getCamera() 
{{% /alert %}} 

## **การใช้เอฟเฟกต์เงานอกกับข้อความ**
Aspose.Slides สำหรับ Java มีคลาส [**IOuterShadow**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioutershadow/) และ [**IInnerShadow**](https://reference.aspose.com/slides/th/java/com.aspose.slides/iinnershadow/) ที่ให้คุณนำเอฟเฟกต์เงาไปใช้กับข้อความที่อยู่ใน [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/). ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม AutoShape ประเภท Rectangle ไปยังสไลด์
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill
6. สร้างอินสแตนซ์ของคลาส OuterShadow
7. ตั้งค่า BlurRadius ของเงา
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา
10. ตั้งค่า RectanglelAlign เป็น TopLeft
11. ตั้งค่า PresetColor ของเงาเป็น Black
12. เขียนพรีเซนเทชันเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) 

โค้ดตัวอย่างใน Java—การนำขั้นตอนข้างต้นมาปฏิบัติ—แสดงวิธีการใช้เอฟเฟกต์เงานอกกับข้อความ:

```java
Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิด Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame เข้าไปใน Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาของข้อความ
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่มเงานอกและตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
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

## **การใช้เอฟเฟกต์เงาในกับรูปร่าง**
ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์
3. เพิ่ม AutoShape ประเภท Rectangle
4. เปิดใช้งาน InnerShadowEffect
5. ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
6. ตั้งค่า ColorType เป็น Scheme
7. ตั้งค่า Scheme Color
8. เขียนพรีเซนเทชันเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) 

โค้ดตัวอย่าง (อิงตามขั้นตอนข้างต้น) แสดงวิธีการเพิ่มคอนเนคเตอร์ระหว่างรูปร่างสองรูปใน Java:

```java
Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิด Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่ม TextFrame เข้าไปใน Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // เปิดใช้งาน InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ตั้งค่า ColorType เป็น Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // ตั้งค่า Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // บันทึกพรีเซนเทชัน
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่ต่างกัน (เช่น Arabic, Chinese) ได้หรือไม่?**

ได้, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติมสี และเส้นขอบสามารถนำไปใช้ได้โดยไม่คำนึงถึงภาษาหากแม้ว่า Availability ของฟอนต์และการแสดงผลอาจขึ้นกับฟอนต์ในระบบ

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบใน Slide Master ได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปร่างบนสไลด์มาสเตอร์ รวมถึง Placeholder หัวเรื่อง, ฟุตเตอร์ หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาต์มาสเตอร์จะถูกสะท้อนไปยังสไลด์ที่เชื่อมต่อทั้งหมด

**เอฟเฟกต์ WordArt ทำให้ขนาดไฟล์พรีเซนเทชันเพิ่มขึ้นหรือไม่?**

เพิ่มเล็กน้อย เอฟเฟกต์เช่น เงา, เรืองแสง, และการเติมแบบไล่สีอาจทำให้ขนาดไฟล์เพิ่มขึ้นบ้างเนื่องจากเมตาดาต้าการจัดรูปแบบเพิ่มเข้ามา แต่ส่วนต่างมักจะไม่มีนัยสำคัญ

**ฉันสามารถดูตัวอย่างผลของเอฟเฟกต์ WordArt โดยไม่ต้องบันทึกพรีเซนเทชันได้หรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `getImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) วิธีนี้ช่วยให้คุณดูตัวอย่างผลในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกพรีเซนเทชันเต็มรูปแบบ