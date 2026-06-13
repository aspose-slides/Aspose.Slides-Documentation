---
title: "จัดการกล่องข้อความในงานนำเสนอด้วย Java"
linktitle: "จัดการกล่องข้อความ"
type: docs
weight: 20
url: /th/java/manage-textbox/
keywords:
- "กล่องข้อความ"
- "เฟรมข้อความ"
- "เพิ่มข้อความ"
- "อัปเดตข้อความ"
- "สร้างกล่องข้อความ"
- "ตรวจสอบกล่องข้อความ"
- "เพิ่มคอลัมน์ข้อความ"
- "เพิ่มไฮเปอร์ลิงก์"
- "PowerPoint"
- "งานนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยเพิ่มประสิทธิภาพการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์โดยทั่วไปอยู่ในกล่องข้อความหรือรูปทรง ดังนั้น เพื่อเพิ่มข้อความในสไลด์ คุณต้องเพิ่มกล่องข้อความและใส่ข้อความลงในกล่องนั้น Aspose.Slides for Java มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่ช่วยให้คุณสามารถเพิ่มรูปทรงที่มีข้อความได้.

{{% alert title="Info" color="info" %}}

Aspose.Slides ยังมีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape) ที่ช่วยให้คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ อย่างไรก็ตาม ไม่ใช่รูปทรงทั้งหมดที่เพิ่มผ่านอินเทอร์เฟซ `IShape` สามารถบรรจุข้อความได้ แต่รูปทรงที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) อาจมีข้อความ. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

ดังนั้น เมื่อทำงานกับรูปทรงที่ต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสต์ผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้นที่คุณจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/TextFrame), ซึ่งเป็นคุณสมบัติของ `IAutoShape` ได้ ดูส่วน [อัปเดตข้อความ](https://docs.aspose.com/slides/th/java/manage-textbox/#update-text) ในหน้านี้. 

{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation). 
2. รับการอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างขึ้นใหม่. 
3. เพิ่มอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) พร้อมกับ [ShapeType](https://reference.aspose.com/slides/th/java/com.aspose.slides/IGeometryShape#setShapeType-int-) ตั้งค่าเป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับการอ้างอิงของอ็อบเจ็กต์ `IAutoShape` ที่เพิ่มใหม่. 
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจ็กต์ `IAutoShape` ที่จะบรรจุข้อความ ในตัวอย่างด้านล่าง เราได้เพิ่มข้อความนี้: *Aspose TextBox*
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`. 

โค้ด Java นี้—การนำขั้นตอนข้างต้นไปใช้—แสดงวิธีเพิ่มข้อความลงในสไลด์:

```java
// สร้างอินสแตนซ์ Presentation
Presentation pres = new Presentation();
try {
    // รับสไลด์แรกในงานนำเสนอ
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame(" ");

    // เข้าถึง TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // สร้างอ็อบเจ็กต์ Paragraph สำหรับ TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // สร้างอ็อบเจ็กต์ Portion สำหรับ Paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // ตั้งค่าข้อความ
    portion.setText("Aspose TextBox");

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตรวจสอบรูปทรงกล่องข้อความ**

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/#isTextBox--) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ซึ่งช่วยให้คุณตรวจสอบรูปทรงและระบุว่าตรงนั้นเป็นกล่องข้อความ

![Text box and shape](istextbox.png)

โค้ด Java นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

หมายเหตุว่า หากคุณเพียงเพิ่ม autoshape โดยใช้เมธอด `addAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) คุณสมบัติ `isTextBox` ของ autoshape จะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความให้กับ autoshape ด้วยเมธอด `addTextFrame` หรือเมธอด `setText` คุณสมบัติ `isTextBox` จะคืนค่า `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() คืนค่า false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() คืนค่า true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() คืนค่า false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() คืนค่า true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() คืนค่า false
shape3.addTextFrame("");
// shape3.isTextBox() คืนค่า false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() คืนค่า false
shape4.getTextFrame().setText("");
// shape4.isTextBox() คืนค่า false
```

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) และ [ColumnSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/TextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ให้กับกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์ในกล่องข้อความและตั้งค่าระยะห่างระหว่างคอลัมน์เป็นจุด

โค้ด Java นี้สาธิตการดำเนินการที่อธิบายไว้: 

```java
Presentation pres = new Presentation();
try {
    // รับสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // เพิ่ม TextFrame ให้กับ Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // รับรูปแบบข้อความของ TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // กำหนดจำนวนคอลัมน์ใน TextFrame
    format.setColumnCount(3);

    // กำหนดระยะห่างระหว่างคอลัมน์
    format.setColumnSpacing(10);

    // บันทึกงานนำเสนอ
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มคอลัมน์ให้กับ Text Frame**

Aspose.Slides for Java มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านคุณสมบัตินี้ คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame

โค้ด Java นี้แสดงวิธีเพิ่มคอลัมน์ภายใน Text Frame:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **อัปเดตข้อความ**

Aspose.Slides ช่วยให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในงานนำเสนอ

โค้ด Java นี้สาธิตการดำเนินการที่อัปเดตหรือเปลี่ยนแปลงข้อความทั้งหมดในงานนำเสนอ:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //ตรวจสอบว่ารูปทรงสนับสนุน TextFrame (IAutoShape) หรือไม่. 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //วนรอบพารากราฟใน TextFrame
                {
                    for (IPortion portion : paragraph.getPortions()) //วนรอบแต่ละ Portion ในพารากราฟ
                    {
                        portion.setText(portion.getText().replace("years", "months")); //เปลี่ยนข้อความ
                        portion.getPortionFormat().setFontBold(NullableBool.True); //เปลี่ยนการจัดรูปแบบ
                    }
                }
            }
        }
    }

    //บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มกล่องข้อความพร้อมลิงก์** 

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกนำไปยังลิงก์

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`. 
2. รับการอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างขึ้นใหม่. 
3. เพิ่มอ็อบเจ็กต์ `AutoShape` โดยตั้งค่า `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับการอ้างอิงของอ็อบเจ็กต์ AutoShape ที่เพิ่มใหม่.
4. เพิ่ม `TextFrame` ให้กับอ็อบเจ็กต์ `AutoShape` ที่มี *Aspose TextBox* เป็นข้อความเริ่มต้น. 
5. สร้างอินสแตนซ์ของคลาส `IHyperlinkManager`. 
6. กำหนดอ็อบเจ็กต์ `IHyperlinkManager` ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/Shape#getHyperlinkClick--) ที่เชื่อมโยงกับส่วนที่คุณต้องการใน `TextFrame`. 
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`. 

โค้ด Java นี้—การนำขั้นตอนข้างต้นไปใช้—แสดงวิธีเพิ่มกล่องข้อความที่มีลิงก์ไปยังสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มอ็อบเจ็กต์ AutoShape โดยตั้งค่าชนิดเป็น Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // แคสต์รูปทรงเป็น AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // เพิ่มข้อความบางส่วนลงในเฟรม
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ตั้งค่าลิงก์ไฮเปอร์ลิงก์สำหรับข้อความ Portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // บันทึกงานนำเสนอ PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวหล่นข้อความ (text placeholder) เมื่อทำงานกับมาสเตอร์สไลด์คืออะไร?**

ตัวหล่นข้อความ ([placeholder](/slides/th/java/manage-placeholder/)) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterslide/) และสามารถถูกเปลี่ยนแปลงในแต่ละ [layout](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslide/), ในขณะที่กล่องข้อความทั่วไปเป็นออบเจ็กต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับ layout.

**ฉันจะทำการแทนที่ข้อความหลายรายการทั่วทั้งงานนำเสนอโดยไม่กระทบข้อความภายในแผนภูมิ ตาราง และ SmartArt ได้อย่างไร?**

จำกัดการวนซ้ำของคุณให้กับ auto‑shapes ที่มี text frame เท่านั้นและละเว้นออบเจ็กต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/smartart/)) โดย traversing คอลเลกชันของพวกมันแยกกันหรือข้ามชนิดออบเจ็กต์เหล่านั้น.