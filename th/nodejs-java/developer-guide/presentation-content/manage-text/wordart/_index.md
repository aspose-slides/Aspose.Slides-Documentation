---
title: สร้างและใช้เอฟเฟกต์ WordArt ใน Node.js
linktitle: WordArt
type: docs
weight: 110
url: /th/nodejs-java/wordart/
keywords:
- WordArt
- สร้าง WordArt
- เทมเพลต WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรืองแสง
- การแปลง WordArt
- เอฟเฟกต์ 3D
- เอฟเฟ็กต์เงานอก
- เอฟเฟ็กต์เงาภายใน
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ Node.js ผ่าน Java คู่มือขั้นตอนนี้ช่วยนักพัฒนาปรับปรุงการนำเสนอด้วยข้อความระดับมืออาชีพใน Node.js."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณจัดรูปแบบข้อความด้วยการเติมสี, เส้นขอบ, เงา, การสะท้อน, แสงเรืองแสง, การแปลงรูป, และการจัดรูปแบบ 3D. บทความนี้อธิบายวิธีสร้างและปรับแต่งเอฟเฟกต์เหล่านี้ในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Node.js via Java โดยไม่ต้องติดตั้ง Microsoft Office.

## **สร้างเทมเพลต WordArt ง่ายและใช้กับข้อความ**

ตัวอย่างต่อไปนี้สร้างสไตล์ WordArt อย่างง่ายโดยการกำหนดข้อความ, ฟอนต์, การเติมลวดลาย, และเส้นขอบ.

แต่ละตัวอย่างจะสร้างงานนำเสนอใหม่และเพิ่มสี่เหลี่ยมผืนผ้าไปยังสไลด์แรก; ไม่จำเป็นต้องมีไฟล์อินพุต ตัวอย่างแรกตั้งค่าข้อความเป็น "Aspose.Slides". ตำแหน่งและขนาดของรูปร่างวัดเป็นหน่วยจุด:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

ตั้งค่าฟอนต์เป็น Arial Black ขนาด 36 จุดเพื่อให้การจัดรูปแบบเด่นชัดยิ่งขึ้น:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

ใช้ลวดลาย [SmallGrid](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternstyle/#SmallGrid) โดยมีสีพื้นหน้าสีส้มเข้มและพื้นหลังสีขาว, จากนั้นเพิ่มเส้นขอบข้อความสีดำที่กว้าง 1 จุด:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

ข้อความที่ได้:
![เทมเพลต WordArt ง่าย](WordArt_template.png)

## **ใช้เอฟเฟกต์ WordArt อื่นๆ**

ตัวอย่างต่อไปนี้แสดงวิธีใช้เงา, การสะท้อน, แสงเรืองแสง, การแปลงรูป, และเอฟเฟกต์ 3D กับข้อความ.

### **ใช้เอฟเฟกต์เงานอก**

เงานอกเพิ่มความลึกโดยการวางเงาที่อยู่ด้านหลังข้อความ คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทาง, รัศมีความเบลอ, สเกล, และการเอียงของมันได้.

ตัวอย่างนี้เรียก [enableOuterShadowEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) และตั้งค่าเงาสีดำที่มีรัศมีความเบลอ 4 จุด, ทิศทาง 230 องศา, และระยะ 30 จุด. ค่าระดับสเกล 100 จะคงขนาดเงา, ในขณะที่เอียงแนวนอนทำให้เงาเอียง 20 องศา. การแปลงแอลฟ่า ตั้งค่าความโปร่งแสงเป็น 32%:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

ข้อความที่ได้:
![เอฟเฟกต์เงานอก](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- เมื่อใช้เงานอกและเงาที่กำหนดไว้ล่วงหน้าพร้อมกัน จะใช้เฉพาะเงานอกเท่านั้น.
- หากใช้เงานอกและเงาภายในพร้อมกัน เอฟเฟกต์ที่ได้จะขึ้นอยู่กับเวอร์ชันของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะเพิ่มเป็นสองเท่า, ในขณะที่ใน PowerPoint 2007 จะใช้เฉพาะเงานอกเท่านั้น.
{{% /alert %}}

### **ใช้เอฟเฟกต์การสะท้อน**

การสะท้อนสร้างสำเนาที่เป็นกระจกของข้อความ ปรับตำแหน่ง, สเกล, ความเบลอ, และความโปร่งแสงเพื่อควบคุมลักษณะของมัน.

ตัวอย่างนี้เรียก [enableReflectionEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) และพลิกการสะท้อนในแนวตั้งด้วยสเกล -100%. ใช้รัศมีความเบลอ 0.5 จุดและระยะ 4.72 จุด. ความโปร่งแสงลดลงจาก 60% ไปเป็น 0.9% ระหว่างตำแหน่ง 0% และ 60% ของการสะท้อน:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

ข้อความที่ได้:
![เอฟเฟกต์การสะท้อน](reflection_effect.png)

### **ใช้เอฟเฟกต์แสงเรืองแสง**

แสงเรืองแสงเพิ่มเส้นขอบสีอ่อนรอบข้อความ ปรับสี, ความโปร่งแสง, และรัศมีเพื่อควบคุมเอฟเฟกต์.

ตัวอย่างนี้เรียก [enableGlowEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) และใช้แสงเรืองแสงสีแดงที่มีความโปร่งแสง 54% และรัศมี 7 จุด:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

ข้อความที่ได้:
![เอฟเฟกต์แสงเรืองแสง](glow_effect.png)

### **ใช้การแปลง WordArt**

การแปลง WordArt ทำให้ข้อความโค้ง, ยืดหรือบิดรูปบล็อกข้อความ.

ตั้งค่า [setTransform](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setTransform) เป็น [ArchUpPour](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) เพื่อโค้งกรอบข้อความทั้งหมดขึ้นด้านบน:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

ข้อความที่ได้:
![การแปลง WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java ให้ชุดของ [ประเภทการแปลง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textshapetype/) ที่กำหนดล่วงหน้าต่างๆ
{{% /alert %}}

### **ใช้เอฟเฟกต์ 3D กับรูปร่างและข้อความ**

คุณสามารถใช้เอฟเฟกต์ 3D กับรูปร่างหรือกับข้อความของมันได้ การเอียงมุม, การบีบอัด, แสงสว่าง, และการตั้งค่ากล้องจะควบคุมลักษณะที่ได้.

ตัวอย่างต่อไปนี้ใช้ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) เพื่อเพิ่มการเอียงมุมกลม, การบีบอัดสีส้ม, และเส้นขอบสีแดงเข้มให้กับสี่เหลี่ยมมิติ. ขนาดการเอียงมุม, ความสูงการบีบอัด, ความกว้างเส้นขอบ, และความลึกวัดเป็นหน่วยจุด. วัสดุพลาสติก, แสงสว่างสมดุลที่หมุน 40 องศารอบแกน Z, และกล้องมุมมองกำหนดลักษณะของมัน:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

ภาพที่ได้:
![เอฟเฟกต์ 3D ของรูปร่าง](shape_3D_effect.png)

ตัวอย่างนี้ใช้การจัดรูปแบบ 3D คล้ายกันกับข้อความผ่าน [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). การเอียงมุมขนาดเล็กจะกำหนดขอบตัวอักษร, ในขณะที่การบีบอัดและแสงสว่างทำให้ข้อความมีความลึก:
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

ข้อความที่ได้:
![เอฟเฟกต์ 3D ของข้อความ](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
การใช้เอฟเฟกต์ 3D กับข้อความหรือรูปร่างของมัน—และการโต้ตอบระหว่างเอฟเฟกต์เหล่านี้—ถูกกำหนดโดยกฎเฉพาะ พิจารณาฉากที่เกี่ยวข้องทั้งข้อความและรูปร่างที่บรรจุข้อความอยู่ เอฟเฟกต์ 3D จะรวมถึงการแสดงผล 3D ของวัตถุและฉากที่มันถูกวางอยู่.

- หากมีการตั้งค่าฉากสำหรับทั้งรูปร่างและข้อความ ฉากของรูปร่างจะมีลำดับความสำคัญก่อนและฉากของข้อความจะถูกละเลย.
- หากรูปร่างไม่มีฉากของตนเองแต่มีการแสดงผล 3D จะใช้ฉากของข้อความ.
- หากรูปร่างไม่มีเอฟเฟกต์ 3D เลย จะถือว่าเป็นแบน และเอฟเฟกต์ 3D จะใช้เฉพาะกับข้อความเท่านั้น.

พฤติกรรมเหล่านี้เกี่ยวข้องกับเมธอด [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getLightRig) และ [ThreeDFormat.getCamera](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

เพื่อให้ข้อความแบนและอ่านง่ายขณะรักษาการจัดรูปแบบ 3D ของรูปร่างไว้, ดู [Keep Text Flat on a 3D Shape](/slides/th/nodejs-java/3d-presentation/) สำหรับการเปรียบเทียบทั้งสองการตั้งค่าและตัวอย่าง JavaScript ฉบับสมบูรณ์.

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่ต่างกัน (เช่น ภาษาอาหรับ, ภาษาจีน) ได้หรือไม่?**

ใช่, Aspose.Slides for Node.js via Java รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติมสี, และเส้นขอบสามารถใช้ได้โดยไม่คำนึงถึงภาษา แม้ว่าการมีฟอนต์และการเรนเดอร์อาจขึ้นอยู่กับฟอนต์ของระบบ.

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบของมาสเตอร์สไลด์ได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปร่างบนสไลด์มาสเตอร์ได้ รวมถึงตำแหน่งข้อความหัวเรื่อง, ส่วนนิ้วยล่าง, หรือข้อความพื้นหลัง การเปลี่ยนแปลงที่ทำบนเค้าโครงมาสเตอร์จะสะท้อนไปยังสไลด์ทั้งหมดที่เชื่อมโยง.

**เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์การนำเสนอหรือไม่?**

ค่อนข้างน้อย. เอฟเฟกต์ WordArt เช่น เงา, แสงเรืองแสง, และการเติมสีไล่ระดับอาจทำให้ขนาดไฟล์เพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาท้าการจัดรูปแบบที่เพิ่มเข้ามา แต่ส่วนต่างมักจะไม่สำคัญ.

**ฉันสามารถดูตัวอย่างผลของเอฟเฟกต์ WordArt ได้โดยไม่ต้องบันทึกการนำเสนอหรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้ [Slide.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage), หรือเรนเดอร์รูปร่างแต่ละอันโดยใช้ [Shape.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage). วิธีนี้ทำให้คุณดูตัวอย่างผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกการนำเสนอเต็มรูปแบบ.