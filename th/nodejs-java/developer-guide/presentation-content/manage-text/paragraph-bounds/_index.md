---
title: รับขอบเขตย่อหน้าในงานนำเสนอด้วย JavaScript
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/nodejs-java/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- text frame
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเพิ่มประสิทธิภาพการวางตำแหน่งข้อความในงานนำเสนอ PowerPoint."
---
## **Overview**

บทความนี้อธิบายวิธีการรับขอบเขต, ขนาดและพิกัดของย่อหน้าใน Aspose.Slides แสดงวิธีการดึงสี่เหลี่ยมของย่อหน้าจาก [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) โดยใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/getrect/), วิธีการรับพิกัดของย่อหน้าใน TextFrame ของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่นหน่วยวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าที่มีประสิทธิภาพ

## **Get Rectangular Coordinates of a Paragraph**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/getrect/) เพื่อรับสี่เหลี่ยมขอบเขตของย่อหน้า

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

เพื่อรับขนาดและพิกัดของ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) ใน TextFrame ของเซลล์ตาราง ให้ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/getrect/). สี่เหลี่ยมที่คืนมาจะสัมพันธ์กับ TextFrame ของเซลล์ตาราง ดังนั้นให้เพิ่มตำแหน่งของตารางและออฟเซ็ตของเซลล์เมื่อคุณต้องการพิกัดระดับสไลด์

ตัวอย่างต่อไปนี้รับขอบเขตของย่อหน้าในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In what units are paragraph coordinates measured?**

พิกัดของย่อหน้าถูกวัดเป็นหน่วยใด? พิกัดเหล่านี้วัดเป็น points โดยที่ 1 นิ้วเท่ากับ 72 points ค่านี้ใช้กับพิกัดและมิติทั้งหมดในสไลด์

**Does word wrapping affect a paragraph's bounds?**

การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่? ใช่ หากเปิดใช้งาน [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/) สำหรับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งจะทำให้ขอบเขตจริงของย่อหน้ามีการเปลี่ยนแปลง

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

พิกัดของย่อหน้าสามารถแม็ปไปยังพิกเซลในภาพที่ส่งออกได้อย่างเชื่อถือได้หรือไม่? ใช่ สามารถแปลงจาก points เป็นพิกเซลโดยใช้สูตรนี้: pixels = points x (DPI / 72) ผลลัพธ์ขึ้นอยู่กับค่า DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้าที่ "effective" โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร? ใช้ [effective paragraph formatting data structure](/slides/th/nodejs-java/shape-effective-properties/) จะส่งคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL และอื่นๆ