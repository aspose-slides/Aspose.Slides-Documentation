---
title: รับขอบเขตของย่อหน้าจากงานนำเสนอบน Android
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/androidjava/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ Android ด้วย Java เพื่อเพิ่มประสิทธิภาพการจัดตำแหน่งข้อความในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต ขนาด และพิกัดของย่อหน้าใน Aspose.Slides จะสาธิตการดึงสี่เหลี่ยมของย่อหน้าจาก[ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/)โดยใช้[IParagraph.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraph#getRect--), วิธีการรับพิกัดของย่อหน้าภายใน TextFrame ของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่นหน่วยวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าแบบมีผล.

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**

ใช้[IParagraph.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraph#getRect--)เพื่อรับสี่เหลี่ยมที่ล้อมรอบย่อหน้า

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **รับขนาดของย่อหน้าภายใน TextFrame ของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ[IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/)ใน TextFrame ของเซลล์ตาราง ให้ใช้[IParagraph.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraph#getRect--)โดยสี่เหลี่ยมที่คืนค่าจะเป็นสัมพัทธ์ต่อ TextFrame ของเซลล์ตาราง ดังนั้นจึงต้องเพิ่มตำแหน่งของตารางและออฟเซ็ตของเซลล์เมื่อต้องการพิกัดระดับสไลด์

ตัวอย่างต่อไปนี้ดึงขอบเขตของย่อหน้าภายในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**พิกัดของย่อหน้าถูกวัดเป็นหน่วยอะไร?**

พิกัดวัดเป็นจุด (points) โดย 1 นิ้วเท่ากับ 72 จุด ค่าดังกล่าวใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ ถ้า[TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)เปิดใช้งานสำหรับ[ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งจะเปลี่ยนขอบเขตจริงของย่อหน้า

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**

ใช่ ใช้สูตรต่อไปนี้เพื่อแปลงจุดเป็นพิกเซล: พิกเซล = จุด × (DPI / 72) ผลลัพธ์ขึ้นกับ DPI ที่เลือกใช้สำหรับการเรนเดอร์หรือการส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้า “effective” โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**

ใช้[effective paragraph formatting data structure](/slides/th/androidjava/shape-effective-properties/) ซึ่งจะคืนค่าสรุปขั้นสุดท้ายของการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL และอื่น ๆ