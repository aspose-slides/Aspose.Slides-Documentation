---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน Java
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/java/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีรับขอบเขตย่อหน้าใน Aspose.Slides สำหรับ Java เพื่อปรับตำแหน่งข้อความในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต ขนาด และพิกัดของย่อหน้าต่างใน Aspose.Slides. แสดงวิธีดึงสี่เหลี่ยมของย่อหน้าจาก [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) โดยใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IParagraph#getRect--), วิธีรับพิกัดของย่อหน้าในกรอบข้อความของเซลล์ตาราง, และเน้นรายละเอียดสำคัญ เช่น หน่วยการวัด, ผลของการตัดข้อความต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าที่มีประสิทธิภาพ.

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IParagraph#getRect--) เพื่อรับสี่เหลี่ยมขอบเขตของย่อหน้า.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **รับขนาดของย่อหน้าในกรอบข้อความของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) ในกรอบข้อความของเซลล์ตาราง ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IParagraph#getRect--). สี่เหลี่ยมที่คืนค่าจะเป็นสัมพันธ์กับกรอบข้อความของเซลล์ตาราง ดังนั้นให้เพิ่มตำแหน่งของตารางและออฟเซ็ตของเซลล์เมื่อคุณต้องการพิกัดระดับสไลด์.

ตัวอย่างต่อไปนี้รับขอบเขตของย่อหน้าภายในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**พิกัดของย่อหน้าถูกวัดเป็นหน่วยอะไร?**

พิกัดถูกวัดเป็นจุด (points) โดยที่ 1 นิ่วเท่ากับ 72 จุด. นี่ใช้กับพิกัดและมิติทั้งหมดบนสไลด์.

**การตัดคำมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ หากเปิดใช้งาน [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) สำหรับ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/), ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งทำให้ขอบเขตจริงของย่อหน้าเปลี่ยนแปลง.

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**

ได้. ใช้สูตรแปลงจุดเป็นพิกเซล: pixels = points × (DPI / 72). ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก.

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้า "ที่มีประสิทธิภาพ" โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**

ใช้ [effective paragraph formatting data structure](/slides/th/java/shape-effective-properties/); จะคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดคำ, RTL, และอื่น ๆ.