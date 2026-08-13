---
title: สร้างและใช้เอฟเฟกต์ WordArt บน Android
linktitle: WordArt
type: docs
weight: 110
url: /th/androidjava/wordart/
keywords:
- WordArt
- สร้าง WordArt
- เทมเพลต WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การแสดงผล
- เอฟเฟกต์เรืองแสง
- การแปลง WordArt
- เอฟเฟกต์ 3D
- เอฟเฟกต์เงานอก
- เอฟเฟกต์เงาภายใน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ Android คู่มือขั้นตอนต่อขั้นตอนนี้ช่วยนักพัฒนาเพิ่มคุณภาพงานนำเสนอด้วยข้อความมืออาชีพใน Java."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่มีลักษณะสวยงามและสไตล์ลงในงานนำเสนอ PowerPoint ของคุณได้ ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt ด้วยโค้ดได้เหมือนกับใน Microsoft PowerPoint—โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมของการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ รูปแบบการเติมสี เส้นขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหานำเสนอของคุณแสดงออกได้ชัดเจนและดึงดูดมากขึ้น WordArt ทำให้คุณจัดการข้อความเป็นวัตถุกราฟิก ซึ่งประกอบด้วยเอฟเฟกต์หรือการปรับเปลี่ยนพิเศษที่นำไปใช้กับข้อความเพื่อทำให้ดูน่าสนใจหรือโดดเด่นยิ่งขึ้น

## **สร้างเทมเพลต WordArt แบบง่ายและนำไปใช้กับข้อความ**

**ใช้ Aspose.Slides** 

ก่อนอื่น เราจะสร้างข้อความอย่างง่ายด้วยโค้ด Java นี้: 

``` java
import com.aspose.slides.*;

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
ต่อไป เราตั้งค่าความสูงของฟอนต์ให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เด่นชัดขึ้นด้วยโค้ดต่อไปนี้:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**ใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟกต์ WordArt ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดไว้ล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่ได้

นี่คือพารามิเตอร์หรือ ตัวเลือก ที่พร้อมใช้งานบางส่วน:

![todo:image_alt_text](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี้ เรานำสีแบบ pattern [SmallGrid](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PatternStyle#SmallGrid) ไปใช้กับข้อความและเพิ่มกรอบข้อความสีดำความกว้าง 1 ด้วยโค้ดนี้:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

ผลลัพธ์ที่ได้:

![todo:image_alt_text](image-20200930114108-4.png)

## **นำเอฟเฟกต์ WordArt อื่น ๆ ไปใช้**

**ใช้ Microsoft PowerPoint**

จากส่วนติดต่อของโปรแกรม คุณสามารถนำเอฟเฟกต์เหล่านี้ไปใช้กับข้อความ กลุ่มข้อความ รูปร่าง หรือองค์ประกอบที่คล้ายกันได้:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟกต์ Shadow, Reflection และ Glow สามารถนำไปใช้กับข้อความ; เอฟเฟกต์ 3D Format และ 3D Rotation สามารถนำไปใช้กับกลุ่มข้อความ; คุณสมบัติ Soft Edges สามารถนำไปใช้กับ Shape Object (ยังคงมีผลแม้ไม่มีการตั้งค่า 3D Format)

### **นำเอฟเฟกต์ Shadow ไปใช้**

ที่นี้ เราตั้งค่าคุณสมบัติที่เกี่ยวข้องกับข้อความเท่านั้น เรานำเอฟเฟกต์เงาไปใช้กับข้อความด้วยโค้ด Java นี้:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides API รองรับเงา 3 ประเภท: OuterShadow, InnerShadow และ PresetShadow

ด้วย PresetShadow คุณสามารถนำเงาไปใช้กับข้อความ (โดยใช้ค่าที่กำหนดไว้ล่วงหน้า)

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาประเภทเดียวเท่านั้น ตัวอย่างดังนี้:

![todo:image_alt_text](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาสองประเภทพร้อมกัน: InnerShadow และ PresetShadow

**หมายเหตุ:**

- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะใช้เฉพาะเอฟเฟกต์ OuterShadow เท่านั้น  
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์หรือเอฟเฟกต์ที่นำไปใช้จะขึ้นกับรุ่นของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะเพิ่มเป็นสองเท่า แต่ใน PowerPoint 2007 จะใช้เอฟเฟกต์ OuterShadow เท่านั้น  

### **นำเอฟเฟกต์ Reflection ไปใช้กับข้อความ**

เราทำให้ข้อความแสดงผลด้วยโค้ดตัวอย่าง Java นี้:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **นำเอฟเฟกต์ Glow ไปใช้กับข้อความ**

เรานำเอฟเฟกต์ glow ไปใช้กับข้อความเพื่อให้ข้อความส่องแสงหรือโดดเด่นด้วยโค้ดนี้:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา การแสดงผล และ glow ได้ คุณสมบัติของเอฟเฟกต์จะตั้งค่าแยกตามส่วนของข้อความแต่ละส่วน 

{{% /alert %}} 

### **ใช้ Transformations ใน WordArt**

เราจะใช้คุณสมบัติ Transform (ซึ่งเป็นส่วนหนึ่งของข้อความทั้งหมด) ด้วยโค้ดนี้:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

ทั้ง Microsoft PowerPoint และ Aspose.Slides สำหรับ Android ผ่าน Java มีประเภทการแปลงที่กำหนดล่วงหน้าจำนวนหนึ่ง

{{% /alert %}} 

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดล่วงหน้า ให้ไปที่: **Format** -> **TextEffect** -> **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ให้ใช้ enum TextShapeType 

### **นำเอฟเฟกต์ 3D ไปใช้กับข้อความและรูปร่าง**

เราตั้งค่าเอฟเฟกต์ 3D ให้กับรูปร่างข้อความด้วยโค้ดตัวอย่างนี้:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

ข้อความและรูปร่างที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟกต์ 3D ไปใช้กับข้อความด้วยโค้ด Java นี้:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

ผลลัพธ์ของการดำเนินการ:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

การนำเอฟเฟกต์ 3D ไปใช้กับข้อความหรือรูปร่างของข้อความและการโต้ตอบระหว่างเอฟเฟกต์นั้นอิงตามกฎบางอย่าง

ให้พิจารณาฉากสำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3D ประกอบด้วยการแสดงวัตถุ 3D และฉากที่วัตถุถูกวางไว้

- เมื่อฉากถูกตั้งค่าสำหรับทั้งรูปและข้อความ รูปจะได้ลำดับความสำคัญสูงกว่า—ข้อความจะถูกละเลย  
- เมื่อรูปขาดฉากของตนเองแต่มีการแสดง 3D จะใช้ฉากของข้อความ  
- มิฉะนั้น—เมื่อรูปร่างเดิมไม่มีเอฟเฟกต์ 3D—รูปร่างจะเป็นแบนและเอฟเฟกต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น  

คำอธิบายเหล่านี้เชื่อมโยงกับเมธอด ThreeDFormat.getLightRig() และ ThreeDFormat.getCamera() 

{{% /alert %}} 

## **นำเอฟเฟกต์ Outer Shadow ไปใช้กับข้อความ**

Aspose.Slides สำหรับ Android ผ่าน Java มีคลาส [**IOuterShadow**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioutershadow/) และ [**IInnerShadow**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinnershadow/) ที่ช่วยให้คุณนำเอฟเฟกต์เงาไปใช้กับข้อความที่อยู่ใน [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์โดยใช้ดัชนี
3. เพิ่ม AutoShape ชนิด Rectangle ไปยังสไลด์
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill
6. สร้างอินสแตนซ์ของคลาส OuterShadow
7. ตั้งค่า BlurRadius ของเงา
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา
10. ตั้งค่า RectangleAlign เป็น TopLeft
11. ตั้งค่า PresetColor ของเงาเป็น Black
12. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/)

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ไปยังสี่เหลี่ยม
    ashp.addTextFrame("Aspose TextBox");

    // ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาข้อความ
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่มเงานอกและตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //บันทึกงานนำเสนอลงดิสก์
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **นำเอฟเฟกต์ Inner Shadow ไปใช้กับรูปร่าง**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์
3. เพิ่ม AutoShape ชนิด Rectangle
4. เปิดใช้งาน InnerShadowEffect
5. ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
6. ตั้งค่า ColorType เป็น Scheme
7. ตั้งค่า Scheme Color
8. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // รับอ้างอิงของสไลด์
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่ม TextFrame ไปยังสี่เหลี่ยม
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

    // บันทึกงานนำเสนอ
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

### ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่ต่างกัน (เช่น Arabic, Chinese) ได้หรือไม่?

ได้, Aspose.Slides รองรับ Unicode และทำงานร่วมกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา การเติมสี และเส้นขอบสามารถนำไปใช้ได้โดยไม่คำนึงถึงภาษาแม้ว่าความพร้อมใช้งานของฟอนต์และการเรนเดอร์อาจขึ้นกับฟอนต์บนระบบ

### ฉันสามารถนำเอฟเฟกต์ WordArt ไปใช้กับองค์ประกอบของ slide master ได้หรือไม่?

ได้, คุณสามารถนำเอฟเฟกต์ WordArt ไปใช้กับรูปร่างบน master slide รวมถึง placeholder ของหัวเรื่อง, ส่วนท้าย, หรือข้อความพื้นหลัง การเปลี่ยนแปลงบน master layout จะสะท้อนต่อสไลด์ทั้งหมดที่เชื่อมโยง

### เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์ของงานนำเสนอหรือไม่?

มีผลเล็กน้อย เอฟเฟกต์ WordArt เช่น เงา การเรืองแสง และการเติมสีไล่ระดับอาจทำให้ไฟล์ขนาดเพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาต้าการจัดรูปแบบที่เพิ่มเข้ามา แต่ส่วนต่าง ๆ นี้มักไม่มีผลต่อขนาดไฟล์อย่างมีนัยสำคัญ

### ฉันสามารถดูตัวอย่างผลของเอฟเฟกต์ WordArt โดยไม่ต้องบันทึกงานนำเสนอได้หรือไม่?

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `getImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) นี้ทำให้คุณดูผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนไฟล์นำเสนอเต็มรูปแบบจะถูกบันทึกหรือส่งออก