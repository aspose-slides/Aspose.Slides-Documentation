---
title: จัดการรูปร่างการนำเสนอบน Android
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/androidjava/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop shape ID
- ข้อความแทนรูปร่าง
- รูปแบบการจัดวางรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การสร้าง, แก้ไขและเพิ่มประสิทธิภาพรูปร่างใน Aspose.Slides สำหรับ Android ผ่าน Java และส่งมอบงานนำเสนอ PowerPoint ที่มีประสิทธิภาพสูง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปร่างในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการค้นหารูปร่างบนสไลด์, คัดลอก, ลบ, ซ่อน, เปลี่ยนลำดับ, รับ Interop shape ID, และตั้งค่า Alternative Text เพื่อตรวจสอบและประมวลผลต่อไป

นอกจากนี้ยังอธิบายวิธีการเข้าถึง layout formats สำหรับรูปร่าง, การเรนเดอร์รูปร่างเป็น SVG, การจัดแนวรูปร่างบนสไลด์, และการใช้คุณสมบัติการพลิกเพื่อทำการสะท้อนแนวนอนและแนวตั้ง อีกทั้งยังมี FAQ สั้น ๆ เกี่ยวกับการรวมรูปร่าง, การจัดลำดับชั้น, และการล็อครูปร่าง

## **ค้นหารูปร่างบนสไลด์**
หัวข้อนี้จะอธิบายเทคนิคง่าย ๆ เพื่อช่วยให้ผู้พัฒนาค้นหารูปร่างเฉพาะบนสไลด์โดยไม่ต้องใช้ Id ภายใน การรู้ว่าหนังสือ Microsoft PowerPoint ไม่มีวิธีใดในการระบุรูปร่างบนสไลด์ยกเว้น Id ภายในที่เป็นค่าที่ไม่ซ้ำกัน การค้นหาด้วย Id ภายในมักเป็นเรื่องยาก ทุกรูปร่างที่เพิ่มลงในสไลด์จะมี Alt Text เราแนะนำให้ผู้พัฒนาใช้ Alternative Text ในการค้นหารูปร่างเฉพาะ คุณสามารถใช้ MS PowerPoint เพื่อตั้งค่า Alternative Text สำหรับวัตถุที่คุณวางแผนจะเปลี่ยนในอนาคต

หลังจากตั้งค่า Alternative Text ให้กับรูปร่างที่ต้องการแล้ว คุณสามารถเปิดงานนำเสนอด้วย Aspose.Slides for Android via Java และทำการวนลูปผ่านรูปร่างทั้งหมดที่เพิ่มบนสไลด์ ในแต่ละรอบคุณสามารถตรวจสอบ Alternative Text ของรูปร่างและรูปร่างที่มีข้อความตรงกันจะเป็นรูปร่างที่คุณต้องการ เพื่อแสดงเทคนิคนี้ได้ชัดเจน เราได้สร้างเมธอด [findShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) ที่ช่วยค้นหารูปร่างเฉพาะบนสไลด์และคืนค่ารูปร่างนั้นกลับมา

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // ข้อความแทนของรูปร่างที่ต้องการค้นหา
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
// การทำงานของเมธอดเพื่อค้นหารูปร่างในสไลด์โดยใช้ข้อความแทน
public static IShape findShape(ISlide slide, String alttext)
{
    // วนลูปผ่านรูปร่างทั้งหมดในสไลด์
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // ถ้าข้อความแทนของสไลด์ตรงกับข้อความที่ต้องการแล้ว
        // คืนค่ารูปร่าง
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **คัดลอกรูปร่าง**
เพื่อคัดลอกรูปร่างไปยังสไลด์โดยใช้ Aspose.Slides for Android via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึงคอลเลกชันรูปร่างของสไลด์ต้นฉบับ
1. เพิ่มสไลด์ใหม่เข้าไปในงานนำเสนอ
1. คัดลอกรูปร่างจากคอลเลกชันรูปร่างของสไลด์ต้นฉบับไปยังสไลด์ใหม่
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มกลุ่มรูปร่างลงบนสไลด์

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

    // Write the PPTX file to disk
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบรูปร่าง**
Aspose.Slides for Android via Java อนุญาตให้ผู้พัฒนาลบรูปร่างใด ๆ เพื่อทำการลบรูปร่างจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText เฉพาะ
1. ลบรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```java
// สร้างอ็อบเจ็กต์ Presentation
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

## **ซ่อนรูปร่าง**
Aspose.Slides for Android via Java อนุญาตให้ผู้พัฒนาซ่อนรูปร่างใด ๆ เพื่อซ่อนรูปร่างจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText เฉพาะ
1. ซ่อนรูปร่าง
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

## **เปลี่ยนลำดับรูปร่าง**
Aspose.Slides for Android via Java อนุญาตให้ผู้พัฒนาจัดลำดับรูปร่างใหม่ การจัดลำดับกำหนดว่ารูปร่างใดอยู่ข้างหน้า หรืออยู่ข้างหลัง เพื่อจัดลำดับรูปร่างจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่าง
1. เพิ่มข้อความบางส่วนใน text frame ของรูปร่าง
1. เพิ่มรูปร่างอีกชิ้นที่มีพิกัดเดียวกัน
1. จัดลำดับรูปร่างใหม่
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
Aspose.Slides for Android via Java อนุญาตให้ผู้พัฒนารับตัวระบุรูปร่างที่ไม่ซ้ำกันในระดับสไลด์ ซึ่งแตกต่างจากเมธอด [getUniqueId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getUniqueId--) ที่ให้ค่าตัวระบุไม่ซ้ำกันในระดับงานนำเสนอ เมธอด [getOfficeInteropShapeId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape) และคลาส [Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Shape) ค่าที่ส่งกลับโดยเมธอด [getOfficeInteropShapeId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) จะสอดคล้องกับ Id ของวัตถุ Microsoft.Office.Interop.PowerPoint.Shape ตัวอย่างโค้ดด้านล่างแสดงการใช้งาน

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // รับตัวระบุรูปร่างที่ไม่ซ้ำกันในระดับสไลด์
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่า Alternative Text สำหรับรูปร่าง**
Aspose.Slides for Android via Java อนุญาตให้ผู้พัฒนาตั้งค่า AlternateText ของรูปร่างใด ๆ รูปร่างในงานนำเสนอสามารถระบุได้ด้วยเมธอด [AlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) หรือ [Shape Name](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) เมธอด [setAlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) และ [getAlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getAlternativeText--) สามารถอ่านหรือเขียนได้โดยใช้ Aspose.Slides รวมถึง Microsoft PowerPoint ด้วยวิธีนี้คุณสามารถแท็กรูปร่างและทำการดำเนินการต่าง ๆ เช่น การลบรูปร่าง, การซ่อนรูปร่าง หรือการจัดลำดับรูปร่างบนสไลด์ เพื่อตั้งค่า AlternateText ของรูปร่าง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่างใด ๆ ลงบนสไลด์
1. ทำงานบางอย่างกับรูปร่างที่เพิ่มใหม่
1. วนลูปผ่านรูปร่างเพื่อค้นหารูปร่างที่ต้องการ
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

## **เข้าถึง Layout Formats สำหรับรูปร่าง**
Aspose.Slides for Android via Java มี API อย่างง่ายสำหรับเข้าถึง Layout Formats ของรูปร่าง บทความนี้แสดงวิธีการเข้าถึง Layout Formats

ตัวอย่างโค้ดด้านล่างแสดงการใช้งาน

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

## **แสดงรูปร่างเป็น SVG**
ตอนนี้ Aspose.Slides for Android via Java รองรับการเรนเดอร์รูปร่างเป็น SVG เมธอด [writeAsSvg](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (และ overload ของมัน) ถูกเพิ่มเข้าไปในคลาส [Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Shape) และอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape) วิธีนี้ช่วยให้บันทึกเนื้อหารูปร่างเป็นไฟล์ SVG ตัวอย่างโค้ดด้านล่างแสดงวิธีส่งออกรูปร่างของสไลด์เป็นไฟล์ SVG

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

## **จัดแนวรูปร่าง**
Aspose.Slides อนุญาตให้จัดแนวรูปร่างได้ทั้งสัมพันธ์กับขอบของสไลด์หรือสัมพันธ์กับรูปร่างอื่น ๆ สำหรับวัตถุประสงค์นี้ เมธอด overload [SlidesUtil.alignShape()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ถูกเพิ่มเข้ามา และ enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapesAlignmentType) กำหนดตัวเลือกการจัดแนวที่เป็นไปได้

**ตัวอย่าง 1**

Source code below aligns shapes with indices 1,2 and 4 along the top border of the slide.

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

**ตัวอย่าง 2**

The example below shows how to align the entire collection of shapes relative to the very bottom shape in the collection.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **คุณสมบัติการพลิก**

ใน Aspose.Slides คลาส [ShapeFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeframe/) ให้การควบคุมการสะท้อนแนวนอนและแนวตั้งของรูปร่างผ่านคุณสมบัติ `flipH` และ `flipV` ทั้งสองเป็นชนิด `byte` สามารถใช้ค่า `1` เพื่อบ่งบอกการพลิก, `0` สำหรับไม่พลิก หรือ `-1` เพื่อใช้ค่าเริ่มต้น ค่าเหล่านี้สามารถเข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getFrame--) ของรูปร่าง

เพื่อแก้ไขการตั้งค่า flip เราสร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปร่าง, ค่าที่ต้องการสำหรับ `flipH` และ `flipV`, และมุมการหมุน จากนั้นกำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getFrame--) ของรูปร่างและบันทึกงานนำเสนอ การทำเช่นนี้จะทำให้การสะท้อนเกิดขึ้นและบันทึกลงไฟล์ผลลัพธ์

สมมติว่าเรามีไฟล์ sample.pptx ที่สไลด์แรกมีรูปร่างเดียวที่ตั้งค่า flip เริ่มต้นตามภาพด้านล่าง

![รูปร่างที่จะแฟลิป](shape_to_be_flipped.png)

ตัวอย่างโค้ดต่อไปนี้ดึงค่า flip ปัจจุบันของรูปร่างและพลิกทั้งแนวนอนและแนวตั้ง

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // ดึงค่าคุณสมบัติการพลิกแนวนอนของรูปร่าง.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // ดึงค่าคุณสมบัติการพลิกแนวตั้งของรูปร่าง.
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

![รูปร่างที่ถูกพลิก](flipped_shape.png)

## **คำถามที่พบบ่อย**

**สามารถรวมรูปร่าง (union/intersect/subtract) บนสไลด์แบบโปรแกรมแก้ไขบนเดสก์ท็อปได้หรือไม่?**

ไม่มี API สำหรับการดำเนินการบูลีนแบบในตัว คุณอาจจำลองโดยสร้างรูปร่างตามโครงสร้างที่ต้องการเอง เช่น คำนวณเรขาคณิตผลลัพธ์ผ่าน [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/geometrypath/) แล้วสร้างรูปร่างใหม่ด้วยคอนทัวร์นั้น พร้อมกับลบรูปร่างเดิมตามต้องการ

**จะควบคุมลำดับการซ้อน (z-order) เพื่อให้รูปร่างอยู่บนสุดได้อย่างไร?**

เปลี่ยนลำดับการแทรกหรือย้ายภายในคอลเลกชัน [shapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslide/#getShapes--) ของสไลด์ เพื่อให้ได้ผลลัพธ์ที่คาดการณ์ได้ ให้จัด z-order สุดท้ายหลังจากทำการแก้ไขสไลด์ทั้งหมดแล้ว

**สามารถ “ล็อค” รูปร่างเพื่อป้องกันไม่ให้ผู้ใช้แก้ไขใน PowerPoint ได้หรือไม่?**

ทำได้ โดยตั้งค่าแฟล็กการป้องกันระดับรูปร่าง (เช่น ล็อคการเลือก, การย้าย, การปรับขนาด, การแก้ไขข้อความ) หากต้องการสามารถขยายการจำกัดบนมาสเตอร์หรือเลย์เอาต์ได้ โปรดทราบว่าเป็นการป้องกันระดับ UI ไม่ใช่คุณลักษณะความปลอดภัย หากต้องการความปลอดภัยที่เข้มงวดกว่า ควรใช้การจำกัดระดับไฟล์เช่น [read-only recommendations or passwords](/slides/th/androidjava/password-protected-presentation/)