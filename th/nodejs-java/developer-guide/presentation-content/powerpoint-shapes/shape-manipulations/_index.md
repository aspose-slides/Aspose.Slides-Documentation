---
title: จัดการรูปร่างการนำเสนอใน JavaScript
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/nodejs-java/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- ทำสำเนารูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop Shape ID
- ข้อความแทนรูปร่าง
- รูปแบบการจัดวางรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้การสร้าง แก้ไข และเพิ่มประสิทธิภาพของรูปร่างโดยใช้ JavaScript และ Aspose.Slides for Node.js via Java เพื่อสร้างงานนำเสนอ PowerPoint ประสิทธิภาพสูง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปร่างในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการค้นหารูปร่างบนสไลด์, ทำสำเนา, ลบ, ซ่อน, เปลี่ยนลำดับ, รับค่า Interop shape ID, และตั้งค่า Alternative Text เพื่อการระบุตัวและการประมวลผลต่อไป

บทความยังครอบคลุมวิธีการเข้าถึงรูปแบบการจัดวางของรูปร่าง, แปลงรูปร่างเป็น SVG, จัดแนวรูปร่างบนสไลด์, และใช้คุณสมบัติการพลิกสำหรับการสะท้อนแนวนอนและแนวตั้ง อีกทั้งบทความยังมี FAQ สั้น ๆ เกี่ยวกับการรวมรูปร่าง, ลำดับการซ้อนกัน, และการล็อกรูปร่าง

## **ค้นหารูปร่างในสไลด์**
หัวข้อนี้จะอธิบายเทคนิคง่าย ๆ เพื่อทำให้ผู้พัฒนาค้นหารูปร่างเฉพาะบนสไลด์ได้ง่ายขึ้นโดยไม่ต้องใช้ Id ภายในของมัน สิ่งสำคัญคือไฟล์ PowerPoint Presentation ไม่มีวิธีใดในการระบุรูปร่างบนสไลด์นอกจาก Id ภายในที่เป็นเอกลักษณ์ ซึ่งทำให้ผู้พัฒนาพบว่าการค้นหารูปร่างโดยใช้ Id ภายในเป็นเรื่องยาก รูปร่างทั้งหมดที่เพิ่มเข้าไปในสไลด์จะมี Alt Text เราแนะนำให้ผู้พัฒนใช้ Alternative Text เพื่อค้นหารูปร่างเฉพาะ คุณสามารถใช้ MS PowerPoint เพื่อตั้งค่า Alternative Text สำหรับวัตถุที่คุณวางแผนจะเปลี่ยนในอนาคต

หลังจากตั้งค่า Alternative Text ของรูปร่างที่ต้องการแล้ว คุณสามารถเปิดงานนำเสนอนั้นโดยใช้ Aspose.Slides for Node.js via Java และวนลูปผ่านรูปร่างทั้งหมดที่เพิ่มเข้ามาในสไลด์ ในแต่ละลูปคุณสามารถตรวจสอบ Alternative Text ของรูปร่างและรูปร่างที่มี Alternative Text ตรงกันจะเป็นรูปร่างที่คุณต้องการ เพื่อสาธิตเทคนิคนี้ให้ชัดเจนเราจึงได้สร้างเมธอด [findShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) ที่ทำหน้าที่ค้นหารูปร่างเฉพาะในสไลด์และคืนค่ารูปร่างนั้น

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // ข้อความแทนของรูปร่างที่ต้องการค้นหา
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **ทำสำเนารูปร่าง**
เพื่อทำสำเนารูปร่างไปยังสไลด์โดยใช้ Aspose.Slides for Node.js via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึงคอลเลกชันรูปร่างของสไลด์ต้นทาง
1. เพิ่มสไลด์ใหม่เข้าไปในงานนำเสนอ
1. ทำสำเนารูปร่างจากคอลเลกชันรูปร่างของสไลด์ต้นทางไปยังสไลด์ใหม่
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มกลุ่มรูปร่างเข้าไปในสไลด์

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบรูปร่าง**
Aspose.Slides for Node.js via Java ช่วยให้ผู้พัฒนาสามารถลบรูปร่างใดก็ได้ เพื่อทำการลบรูปร่างจากสไลด์ใด ๆ กรุณาปฏิบัติตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText เฉพาะ
1. ลบรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```javascript
// สร้างอ็อบเจกต์ Presentation
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม autoshape ประเภทสี่เหลี่ยม
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ซ่อนรูปร่าง**
Aspose.Slides for Node.js via Java ช่วยให้ผู้พัฒนาสามารถซ่อนรูปร่างใดก็ได้ เพื่อซ่อนรูปร่างจากสไลด์ใด ๆ กรุณาปฏิบัติตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText เฉพาะ
1. ซ่อนรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม autoshape ประเภทสี่เหลี่ยม
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนลำดับรูปร่าง**
Aspose.Slides for Node.js via Java ช่วยให้ผู้พัฒนาสามารถจัดลำดับใหม่ของรูปร่างได้ การจัดลำดับใหม่ระบุว่ารูปร่างอยู่ด้านหน้า หรือด้านหลัง เพื่อจัดลำดับใหม่ของรูปร่างจากสไลด์ใด ๆ กรุณาปฏิบัติตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่าง
1. เพิ่มข้อความบางส่วนใน Text Frame ของรูปร่าง
1. เพิ่มรูปร่างอีกอันหนึ่งที่มีพิกัดเดียวกัน
1. จัดลำดับรูปร่างใหม่
1. บันทึกไฟล์ลงดิสก์

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **รับ Interop Shape ID**
Aspose.Slides for Node.js via Java ช่วยให้ผู้พัฒนาสามารถรับตัวระบุรูปร่างที่เป็นเอกลักษณ์ในระดับสไลด์ ซึ่งแตกต่างจากเมธอด [getUniqueId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getUniqueId--) ที่ให้ตัวระบุเอกลักษณ์ในระดับงานนำเสนอ เมธอด [getOfficeInteropShapeId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) ถูกเพิ่มเข้าไปในคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) และคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) ตามลำดับ ค่า ที่คืนจากเมธอด [getOfficeInteropShapeId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) สอดคล้องกับค่า Id ของออบเจ็กต์ Microsoft.Office.Interop.PowerPoint.Shape ด้านล่างเป็นตัวอย่างโค้ด

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // รับตัวระบุรูปร่างที่เป็นเอกลักษณ์ในระดับสไลด์
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่า Alternative Text ให้กับรูปร่าง**
Aspose.Slides for Node.js via Java ช่วยให้ผู้พัฒนาตั้งค่า AlternateText ของรูปร่างใดก็ได้ รูปร่างในงานนำเสนอสามารถแยกแยะได้โดยใช้เมธอด [AlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) หรือ [Shape Name](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) [setAlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) และ [getAlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getAlternativeText--) สามารถอ่านหรือกำหนดค่าได้ด้วย Aspose.Slides เช่นเดียวกับ Microsoft PowerPoint การใช้เมธอดนี้คุณสามารถแท็กรูปร่างและทำการดำเนินการต่าง ๆ เช่น การลบรูปร่าง, การซ่อนรูปร่าง หรือการจัดลำดับรูปร่างบนสไลด์ เพื่อกำหนด AlternateText ของรูปร่าง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่างใด ๆ ลงในสไลด์
1. ทำงานบางอย่างกับรูปร่างที่เพิ่มใหม่
1. วนตรวจสอบรูปร่างเพื่อค้นหารูปร่าง
1. ตั้งค่า AlternativeText
1. บันทึกไฟล์ลงดิสก์

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม autoshape ประเภทสี่เหลี่ยม
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงรูปแบบการจัดวางสำหรับรูปร่าง**
Aspose.Slides for Node.js via Java มี API ง่าย ๆ เพื่อเข้าถึงรูปแบบการจัดวางของรูปร่าง บทความนี้สาธิตวิธีการเข้าถึงรูปแบบการจัดวาง

ด้านล่างเป็นตัวอย่างโค้ด

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แสดงรูปร่างเป็น SVG**
ตอนนี้ Aspose.Slides for Node.js via Java รองรับการแปลงรูปร่างเป็น SVG เมธอด [writeAsSvg](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (และโอเวอร์โหลด) ถูกเพิ่มเข้าไปในคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) และคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) เมธอดนี้ช่วยให้บันทึกเนื้อหาของรูปร่างเป็นไฟล์ SVG ตัวอย่างโค้ดด้านล่างแสดงวิธีการส่งออกรูปร่างของสไลด์เป็นไฟล์ SVG

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การจัดแนวรูปร่าง**
Aspose.Slides อนุญาตให้จัดแนวรูปร่างได้ทั้งสัมพันธ์กับขอบสไลด์หรือสัมพันธ์กับกันและกัน เพื่อวัตถุประสงค์นี้เมธอดโอเวอร์โหลด [SlidesUtil.alignShape()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) ถูกเพิ่มเข้ามา รายการ enum [ShapesAlignmentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapesAlignmentType) กำหนดตัวเลือกการจัดแนวที่เป็นไปได้

**ตัวอย่าง 1**

โค้ดต้นฉบับด้านล่างจัดแนวรูปร่างที่มีดัชนี 1,2 และ 4 ไปตามขอบบนของสไลด์

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**ตัวอย่าง 2**

ตัวอย่างด้านล่างแสดงวิธีจัดแนวคอลเลกชันทั้งหมดของรูปร่างสัมพันธ์กับรูปร่างที่อยู่ด้านล่างสุดในคอลเลกชัน

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คุณสมบัติการพลิก**

ใน Aspose.Slides คลาส [ShapeFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeframe/) ให้การควบคุมการสะท้อนแนวนอนและแนวตั้งของรูปร่างผ่านคุณสมบัติ `flipH` และ `flipV` ทั้งสองคุณสมบัติเป็นประเภท `byte` โดยค่าที่เป็น `1` แสดงการพลิก, `0` แสดงไม่มีการพลิก, หรือ `-1` เพื่อใช้พฤติกรรมเริ่มต้น ค่าต่าง ๆ นี้สามารถเข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getFrame) ของรูปร่าง

เพื่อปรับแต่งการตั้งค่าการพลิก เราจะสร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปร่าง, ค่า `flipH` และ `flipV` ที่ต้องการ, และมุมการหมุน การกำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getFrame) ของรูปร่างและบันทึกงานนำเสนอจะทำให้การแปลงสะท้อนถูกนำไปใช้และบันทึกลงไฟล์ผลลัพธ์

สมมติว่าเรามีไฟล์ sample.pptx ซึ่งสไลด์แรกมีรูปร่างเดียวที่มีการตั้งค่าการพลิกเริ่มต้น ดังแสดงด้านล่าง

![รูปร่างที่ต้องการพลิก](shape_to_be_flipped.png)

โค้ดตัวอย่างต่อไปนี้ดึงคุณสมบัติการพลิกปัจจุบันของรูปร่างและพลิกทั้งแนวนอนและแนวตั้ง

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // ดึงคุณสมบัติการพลิกแนวนอนของรูปร่าง.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // ดึงคุณสมบัติการพลิกแนวตั้งของรูปร่าง.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // พลิกแนวนอน.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // พลิกแนวตั้ง.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่ถูกพลิก](flipped_shape.png)

## **FAQ**

**ฉันสามารถรวมรูปร่าง (union/intersect/subtract) บนสไลด์แบบโปรแกรมบนเดสก์ท็อปได้หรือไม่?**

ไม่มี API สำหรับการดำเนินการ Boolean แบบในตัว คุณสามารถประมาณได้โดยสร้างโครงร่างที่ต้องการด้วยตนเอง เช่น คำนวณเรขาคณิตที่ได้ผล (ผ่าน [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/geometrypath/)) และสร้างรูปร่างใหม่กับเส้นรอบนั้น พร้อมกับอาจลบรูปร่างเดิมออกได้

**ฉันจะควบคุมลำดับการซ้อนกัน (z-order) เพื่อให้รูปร่างอยู่ด้านบนเสมอได้อย่างไร?**

เปลี่ยนลำดับการแทรก/ย้ายภายในคอลเลกชัน [shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getShapes) ของสไลด์ เพื่อผลลัพธ์ที่คาดการณ์ได้ ควรสรุปลำดับ z-order หลังจากทำการแก้ไขสไลด์อื่น ๆ เสร็จเรียบร้อย

**ฉันสามารถ 'ล็อค' รูปร่างเพื่อป้องกันผู้ใช้จากการแก้ไขใน PowerPoint ได้หรือไม่?**

ใช่ ตั้งค่าธงการป้องกันระดับรูปร่าง (เช่น ล็อกการเลือก, การเคลื่อนที่, การปรับขนาด, การแก้ไขข้อความ) หากจำเป็นสามารถทำการจำกัดบนมาสเตอร์หรือเลย์เอาต์ได้ โปรดทราบว่านี่เป็นการป้องกันระดับ UI ไม่ใช่ฟีเจอร์ความปลอดภัย; เพื่อการป้องกันที่แข็งแรงขึ้นให้รวมกับการจำกัดระดับไฟล์ เช่น [ข้อแนะนำแบบอ่านอย่างเดียวหรือรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/)