---
title: รับขอบเขตย่อหน้าจากการนำเสนอบน Android
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/androidjava/paragraph/
keywords:
- ขอบเขตย่อหน้า
- ขอบเขตส่วนข้อความ
- พิกัดย่อหน้า
- พิกัดส่วน
- ขนาดย่อหน้า
- ขนาดส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตของย่อหน้าและส่วนข้อความใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อเพิ่มประสิทธิภาพการวางตำแหน่งข้อความในพรีเซนเทชัน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต, ขนาด และพิกัดของย่อหน้าและส่วนข้อความใน Aspose.Slides โดยแสดงวิธีการดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` ด้วยการใช้ `getRect()`, วิธีการรับพิกัดของย่อหน้าและส่วนภายในกรอบข้อความของเซลล์ตาราง, และเน้นรายละเอียดสำคัญ เช่น หน่วยการวัด, ผลของการตัดคำต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการฟอร์แมตย่อหน้าที่มีผลจริง

## **รับพิกัดของย่อหน้าและส่วนใน TextFrame**
โดยใช้ Aspose.Slides for Android ผ่าน Java นักพัฒนาสามารถรับพิกัดสี่เหลี่ยมของ Paragraph ภายในชุดย่อหน้าของ TextFrame ได้แล้ว นอกจากนี้ยังสามารถรับ[พิกัดของส่วน](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getCoordinates--)ภายในชุดส่วนของย่อหน้าได้ อีกในหัวข้อนี้ เราจะสาธิตด้วยตัวอย่างว่าต้องทำอย่างไรเพื่อรับพิกัดสี่เหลี่ยมของย่อหน้าพร้อมตำแหน่งของส่วนภายในย่อหน้า

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**
โดยใช้เมธอด[**getRect()**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraph#getRect--)นักพัฒนาสามารถรับสี่เหลี่ยมขอบเขตของย่อหน้าได้

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับขนาดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง**
เพื่อรับขนาดและพิกัดของ[Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Portion)หรือ[Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Paragraph)ใน TextFrame ของเซลล์ตาราง คุณสามารถใช้เมธอด[IPortion.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortion#getRect--)และ[IParagraph.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraph#getRect--)  

โค้ดตัวอย่างนี้แสดงการทำงานตามที่อธิบาย:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**หน่วยใดที่ใช้ในการวัดพิกัดของย่อหน้าและส่วนข้อความ?**  
ในหน่วยจุด (points) โดยที่ 1 นิ้ว = 72 จุด ค่าดังกล่าวใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดคำส่งผลต่อขอบเขตของย่อหน้าหรือไม่?**  
ใช่ หากมีการเปิดใช้งาน[wrapping](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)ใน[TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ข้อความจะถูกตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งจะทำให้ขอบเขตจริงของย่อหน้าเปลี่ยนแปลง

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างแม่นยำหรือไม่?**  
ได้ ใช้การแปลงจากจุดเป็นพิกเซลดังนี้: pixels = points × (DPI / 72) ผลลัพธ์จะขึ้นอยู่กับค่า DPI ที่เลือกสำหรับการเรนเดอร์/ส่งออก

**ฉันจะรับค่าการจัดรูปแบบย่อหน้าแบบ “effective” โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**  
ใช้[โครงสร้างข้อมูลการจัดรูปแบบย่อหน้าแบบ effective](/slides/th/androidjava/shape-effective-properties/) ซึ่งจะส่งคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ช่องว่าง, การตัดคำ, RTL และอื่น ๆ