---
title: จัดการรูปทรงในการนำเสนอด้วย Java
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/java/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงการนำเสนอ
- รูปทรงบนสไลด์
- ค้นหารรูปทรง
- คัดลอกรูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ Interop shape ID
- ข้อความทางเลือกของรูปทรง
- รูปแบบการจัดวางรูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การสร้าง, แก้ไขและเพิ่มประสิทธิภาพรูปทรงใน Aspose.Slides สำหรับ Java และส่งมอบงานนำเสนอ PowerPoint ที่มีประสิทธิภาพสูง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปทรงในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการค้นหารูปทรงบนสไลด์, คัดลอก, ลบ, ซ่อน, เปลี่ยนลำดับ, รับ Interop shape ID, และตั้งค่าข้อความทางเลือกสำหรับการระบุตัวและการประมวลผลต่อไป

นอกจากนี้ยังครอบคลุมวิธีการเข้าถึงรูปแบบการจัดวางสำหรับรูปทรง, เรนเดอร์รูปทรงเป็น SVG, จัดแนวรูปทรงบนสไลด์, และใช้คุณสมบัติการพลิกเพื่อการสะท้อนแนวนอนและแนวตั้ง อีกทั้งบทความยังมีส่วน FAQ สั้น ๆ เกี่ยวกับการรวมรูปทรง, ลำดับการซ้อน, และการล็อกรูปทรง

## **ค้นหารูปทรงบนสไลด์**
หัวข้อนี้จะอธิบายเทคนิคง่าย ๆ เพื่อทำให้นักพัฒนาค้นหารูปทรงเฉพาะบนสไลด์ได้ง่ายขึ้นโดยไม่ต้องใช้ Id ภายในของมัน สำคัญที่ต้องรู้คือไฟล์ PowerPoint Presentation ไม่มีวิธีใด ๆ ที่จะระบุรูปทรงบนสไลด์ยกเว้น Id ภายในที่เป็นเอกลักษณ์ การค้นหารูปทรงโดยใช้ Id ภายในอาจเป็นเรื่องยากสำหรับนักพัฒนา รูปทรงทั้งหมดที่เพิ่มลงในสไลด์จะมี Alt Text เราแนะนำให้นักพัฒนาใช้ข้อความทางเลือกเพื่อค้นหารูปทรงเฉพาะ คุณสามารถใช้ MS PowerPoint เพื่อกำหนดข้อความทางเลือกสำหรับวัตถุที่คุณวางแผนจะเปลี่ยนในอนาคต

หลังจากตั้งค่าข้อความทางเลือกของรูปทรงใด ๆ ที่ต้องการแล้ว คุณสามารถเปิดงานนำเสนอนั้นด้วย Aspose.Slides for Java และวนลูปผ่านรูปทรงทั้งหมดที่เพิ่มลงในสไลด์ ในแต่ละรอบคุณสามารถตรวจสอบข้อความทางเลือกของรูปทรงและรูปทรงที่มีข้อความตรงจะเป็นรูปทรงที่คุณต้องการ เพื่อแสดงเทคนิคนี้อย่างชัดเจน เราได้สร้างเมธอด [findShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) ที่ทำหน้าที่ค้นหารูปทรงเฉพาะในสไลด์และคืนค่ารูปทรงนั้น

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // ข้อความทางเลือกของรูปทรงที่ต้องการค้นหา
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// การทำงานของเมธอดเพื่อค้นหารูปทรงในสไลด์โดยใช้ข้อความทางเลือกของมัน
public static IShape findShape(ISlide slide, String alttext)
{
    // วนลูปผ่านรูปทรงทั้งหมดภายในสไลด์
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // หากข้อความทางเลือกของสไลด์ตรงกับที่ต้องการแล้ว
        // คืนค่ารูปทรงนั้น
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **คัดลอกรูปทรง**
เพื่อคัดลอกรูปทรงไปยังสไลด์โดยใช้ Aspose.Slides for Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
1. รับอ็อบเจกต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน 
1. เข้าถึงคอลเล็กชันรูปทรงของสไลด์ต้นทาง 
1. เพิ่มสไลด์ใหม่ลงในงานนำเสนอ 
1. คัดลอกรูปทรงจากคอลเล็กชันของสไลด์ต้นทางไปยังสไลด์ใหม่ 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

ตัวอย่างด้านล่างเพิ่มกลุ่มรูปทรงลงในสไลด์

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบรูปทรง**
Aspose.Slides for Java อนุญาตให้ผู้พัฒนาลบรูปทรงใด ๆ ได้ เพื่อลบรูปทรงจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
1. เข้าถึงสไลด์แรก 
1. ค้นหารูปทรงที่มี AlternativeText เฉพาะ 
1. ลบรูปทรง 
1. บันทึกไฟล์ลงดิสก์ 

```java
// สร้างออบเจกต์ Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ซ่อนรูปทรง**
Aspose.Slides for Java อนุญาตให้ผู้พัฒนาซ่อนรูปทรงใด ๆ ได้ เพื่ซ่อนรูปทรงจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
1. เข้าถึงสไลด์แรก 
1. ค้นหารูปทรงที่มี AlternativeText เฉพาะ 
1. ซ่อนรูปทรง 
1. บันทึกไฟล์ลงดิสก์ 

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม autoshape ประเภทสี่เหลี่ยม
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนลำดับรูปทรง**
Aspose.Slides for Java อนุญาตให้ผู้พัฒนาจัดลำดับรูปทรงใหม่ การจัดลำดับรูปทรงระบุว่ารูปทรงใดอยู่หน้า หรือใดอยู่หลัง เพื่อจัดลำดับรูปทรงจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
1. เข้าถึงสไลด์แรก 
1. เพิ่มรูปทรง 
1. เพิ่มข้อความบางส่วนใน Text Frame ของรูปทรง 
1. เพิ่มรูปทรงอีกอันหนึ่งด้วยพิกัดเดียวกัน 
1. จัดลำดับรูปทรงใหม่ 
1. บันทึกไฟล์ลงดิสก์ 

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับ Interop Shape ID**
Aspose.Slides for Java อนุญาตให้ผู้พัฒนารับตัวระบุรูปทรงที่เป็นเอกลักษณ์ในระดับสไลด์ ซึ่งต่างจากเมธอด [getUniqueId](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getUniqueId--) ที่ให้ตัวระบุระดับงานนำเสนอ เมธอด [getOfficeInteropShapeId](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape) และคลาส [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/Shape) ค่าที่คืนจากเมธอดนี้สอดคล้องกับ Id ของวัตถุ Microsoft.Office.Interop.PowerPoint.Shape ตัวอย่างโค้ดด้านล่างแสดงการใช้งาน

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // รับตัวระบุรูปทรงที่ไม่ซ้ำในระดับสไลด์
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าข้อความทางเลือกสำหรับรูปทรง**
Aspose.Slides for Java อนุญาตให้ผู้พัฒนาตั้งค่า AlternateText ของรูปทรงใด ๆ
รูปทรงในงานนำเสนอสามารถระบุได้โดยเมธอด [AlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) หรือ [Shape Name](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setName-java.lang.String-)
เมธอด [setAlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) และ [getAlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getAlternativeText--) สามารถอ่านหรือกำหนดได้โดยใช้ Aspose.Slides รวมถึง Microsoft PowerPoint
ด้วยเมธอดนี้คุณสามารถทำเครื่องหมายรูปทรงและทำการดำเนินการต่าง ๆ เช่น การลบรูปทรง, การซ่อนรูปทรง หรือการจัดลำดับรูปทรงบนสไลด์
เพื่อกำหนด AlternateText ของรูปทรง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
1. เข้าถึงสไลด์แรก 
1. เพิ่มรูปทรงใด ๆ ลงในสไลด์ 
1. ทำงานบางอย่างกับรูปทรงที่เพิ่งเพิ่ม 
1. วนลูปผ่านรูปทรงเพื่อค้นหารูปทรง 
1. ตั้งค่า AlternativeText 
1. บันทึกไฟล์ลงดิสก์ 

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม autoshape ประเภทสี่เหลี่ยม
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงรูปแบบการจัดวางสำหรับรูปทรง**
Aspose.Slides for Java มี API ง่าย ๆ เพื่อเข้าถึงรูปแบบการจัดวางสำหรับรูปทรง บทความนี้แสดงตัวอย่างวิธีการเข้าถึงรูปแบบการจัดวาง

ตัวอย่างโค้ดด้านล่าง

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เรนเดอร์รูปทรงเป็น SVG**
ขณะนี้ Aspose.Slides for Java รองรับการเรนเดอร์รูปทรงเป็น SVG เมธอด [writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (และโอเวอร์โหลด) ถูกเพิ่มในคลาส [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/Shape) และอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape) เมธอดนี้ช่วยบันทึกเนื้อหาของรูปทรงเป็นไฟล์ SVG ตัวอย่างโค้ดด้านล่างแสดงวิธีการส่งออกรูปทรงของสไลด์เป็นไฟล์ SVG

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดแนวรูปทรง**
Aspose.Slides อนุญาตให้จัดแนวรูปทรงได้ทั้งสัมพันธ์กับขอบสไลด์หรือสัมพันธ์กันเอง เพื่อวัตถุประสงค์นี้ได้เพิ่มเมธอดโอเวอร์โหลด [SlidesUtil.alignShape()](https://reference.aspose.com/slides/th/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) โดย enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ShapesAlignmentType) กำหนดตัวเลือกรูปแบบการจัดแนวที่เป็นไปได้

**Example 1**

โค้ดต้นฉบับด้านล่างจัดแนวรูปทรงที่มีดัชนี 1,2 และ 4 ตามขอบด้านบนของสไลด์

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Example 2**

ตัวอย่างด้านล่างแสดงวิธีจัดแนวคอลเล็กชันทั้งหมดของรูปทรงสัมพันธ์กับรูปทรงที่อยู่ด้านล่างสุดในคอลเล็กชัน

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **คุณสมบัติการพลิก**

ใน Aspose.Slides คลาส [ShapeFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeframe/) ให้การควบคุมการสะท้อนแนวนอนและแนวตั้งของรูปทรงผ่านคุณสมบัติ `flipH` และ `flipV` ทั้งสองเป็นประเภท `byte` โดยค่าที่เป็น `1` หมายถึงพลิก, `0` ไม่พลิก, หรือ `-1` ใช้ค่าดีฟอลต์ ค่าดังกล่าวเข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getFrame--) ของรูปทรง

เพื่อปรับการตั้งค่าการพลิก จะสร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปทรง, ค่าที่ต้องการสำหรับ `flipH` และ `flipV`, และมุมการหมุน การกำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getFrame--) ของรูปทรงและบันทึกงานนำเสนอจะทำให้การสะท้อนถูกนำไปใช้และบันทึกลงไฟล์ผลลัพธ์

สมมติว่ามีไฟล์ sample.pptx ที่สไลด์แรกมีรูปทรงเดียวที่ตั้งค่า flip เริ่มต้นตามด้านล่าง

![รูปทรงที่ต้องการพลิก](shape_to_be_flipped.png)

โค้ดตัวอย่างต่อไปนี้ดึงคุณสมบัติ flip ปัจจุบันของรูปทรงและพลิกทั้งแนวนอนและแนวตั้ง

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // ดึงคุณสมบัติการพลิกแนวนอนของรูปทรง
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // ดึงคุณสมบัติการพลิกแนวตั้งของรูปทรง
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // พลิกแนวนอน.
    byte flipV = NullableBool.True; // พลิกแนวนอน.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่พลิกแล้ว](flipped_shape.png)

## **ถามตอบ**

**ฉันสามารถรวมรูปทรง (union/intersect/subtract) บนสไลด์เหมือนในโปรแกรมเดสก์ท็อปได้หรือไม่?**

ไม่มี API การดำเนินการบูลีนในตัว คุณสามารถทำโดยประมาณโดยสร้างรูปร่างสรุปที่ต้องการเอง เช่น คำนวณเรขาคณิตผลลัพธ์ (ผ่าน [GeometryPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/geometrypath/)) แล้วสร้างรูปทรงใหม่ด้วยโครงร่างนั้น พร้อมกับลบรูปทรงต้นฉบับถ้าต้องการ

**ฉันจะควบคุมลำดับการซ้อน (z-order) เพื่อให้รูปทรงอยู่ด้านบนเสมอได้อย่างไร?**

เปลี่ยนลำดับการแทรก/ย้ายภายในคอลเล็กชัน [shapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslide/#getShapes--) ของสไลด์ เพื่อให้ได้ผลลัพธ์คาดเดาได้ ให้สรุปลำดับ z-order หลังจากทำการแก้ไขสไลด์อื่น ๆ เสร็จแล้ว

**ฉันสามารถ 'ล็อค' รูปทรงเพื่อป้องกันไม่ให้ผู้ใช้แก้ไขใน PowerPoint ได้หรือไม่?**

ได้ โดยตั้งค่าธงป้องกันระดับรูปทรง (เช่น lock selection, movement, resizing, text edits) ดูเอกสารที่เกี่ยวกับการป้องกันระดับพรีเซนเทชัน หากต้องการความปลอดภัยที่สูงขึ้น สามารถผสานกับการจำกัดระดับไฟล์เช่นคำแนะนำให้เป็นแบบอ่านอย่างเดียวหรือการตั้งรหัสผ่าน [/slides/th/java/password-protected-presentation/](​/slides/th/java/password-protected-presentation/)