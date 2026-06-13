---
title: ดึงขอบเขตของย่อหน้าจากการนำเสนอใน Java
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/java/paragraph/
keywords:
- ขอบเขตของย่อหน้า
- ขอบเขตของส่วนข้อความ
- พิกัดของย่อหน้า
- พิกัดของส่วน
- ขนาดของย่อหน้า
- ขนาดของส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตของย่อหน้าและส่วนข้อความใน Aspose.Slides สำหรับ Java เพื่อปรับตำแหน่งข้อความให้เหมาะสมในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับพิกัด, ขนาด และตำแหน่งของย่อหน้าและส่วนของข้อความใน Aspose.Slides โดยแสดงวิธีดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` ด้วย `getRect()`, วิธีรับพิกัดของย่อหน้าและส่วนภายในกรอบข้อความของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่นหน่วยวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าแบบมีประสิทธิภาพ

## **รับพิกัดย่อหน้าและส่วนใน TextFrame**
โดยใช้ Aspose.Slides for Java นักพัฒนาสามารถรับพิกัดสี่เหลี่ยมสำหรับ Paragraph ภายในคอลเลกชันของ TextFrame ได้ นอกจากนี้ยังสามารถรับ [the coordinates of portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getCoordinates--) ภายในคอลเลกชันของส่วนของย่อหน้า ในหัวข้อนี้ เราจะสาธิตด้วยตัวอย่างวิธีรับพิกัดสี่เหลี่ยมของย่อหน้าและตำแหน่งของส่วนภายในย่อหน้า

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
โดยใช้วิธี [**getRect()**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IParagraph#getRect--) นักพัฒนาสามารถรับสี่เหลี่ยมขอบเขตของย่อหน้าได้

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

เพื่อรับขนาดและพิกัดของ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/Portion) หรือ [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/Paragraph) ในกรอบข้อความของเซลล์ตาราง คุณสามารถใช้วิธี [IPortion.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortion#getRect--) และ [IParagraph.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/IParagraph#getRect--) ได้

ตัวอย่างโค้ดนี้แสดงการดำเนินการที่อธิบายไว้:

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

## **FAQ**

**หน่วยที่ใช้ในการคืนค่าพิกัดของย่อหน้าและส่วนข้อความคืออะไร?**

เป็นหน่วยจุด (points) โดยที่ 1 นิ้ว = 72 จุด นี้ใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ หาก [wrapping](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setWrapText-byte-) ถูกเปิดใช้งานใน [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/), ข้อความจะตัดให้พอดีกับความกว้างของพื้นที่ ซึ่งจะเปลี่ยนขอบเขตจริงของย่อหน้า

**สามารถแมปพิกัดย่อหน้าไปเป็นพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**

ได้ สามารถแปลงจุดเป็นพิกเซลโดยใช้: pixels = points × (DPI / 72) ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์/ส่งออก

**จะรับพารามิเตอร์การจัดรูปแบบย่อหน้า "effective" ที่คำนึงถึงการสืบทอดสไตล์อย่างไร?**

ใช้ [effective paragraph formatting data structure](/slides/th/java/shape-effective-properties/) จะคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL และอื่น ๆ