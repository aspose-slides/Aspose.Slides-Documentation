---
title: "จัดการกล่องข้อความในงานนำเสนอบน Android"
linktitle: "จัดการกล่องข้อความ"
type: docs
weight: 20
url: /th/androidjava/manage-textbox/
keywords:
- "กล่องข้อความ"
- "กรอบข้อความ"
- "เพิ่มข้อความ"
- "อัพเดตข้อความ"
- "สร้างกล่องข้อความ"
- "ตรวจสอบกล่องข้อความ"
- "เพิ่มคอลัมน์ข้อความ"
- "เพิ่มไฮเปอร์ลิงก์"
- "PowerPoint"
- "งานนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides สำหรับ Android ผ่าน Java ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยปรับปรุงระบบอัตโนมัติการนำเสนอของคุณ"
---
## **บทนำ**

ข้อความบนสไลด์ปกติจะอยู่ในกล่องข้อความหรือรูปทรง ดังนั้นเพื่อเพิ่มข้อความในสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความบางส่วนลงในกล่องข้อความนั้น Aspose.Slides for Android via Java มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ที่ช่วยให้คุณเพิ่มรูปทรงที่มีข้อความได้

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังมีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape) ที่ช่วยให้คุณเพิ่มรูปทรงลงบนสไลด์ อย่างไรก็ตาม รูปทรงทั้งหมดที่เพิ่มผ่านอินเทอร์เฟซ `IShape` ไม่สามารถเก็บข้อความได้ แต่รูปทรงที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) อาจมีข้อความได้
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
ดังนั้นเมื่อทำงานกับรูปทรงที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrame) ซึ่งเป็นคุณสมบัติของ `IAutoShape` ได้ ดูส่วน [Update Text](https://docs.aspose.com/slides/th/androidjava/manage-textbox/#update-text) ในหน้านี้
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์แรกในงานพรีเซนเทชันที่เพิ่งสร้าง  
3. เพิ่มอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ที่มี [ShapeType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) ตั้งค่าเป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์ และรับอ้างอิงของอ็อบเจกต์ `IAutoShape` ที่เพิ่งเพิ่ม  
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจกต์ `IAutoShape` ที่จะบรรจุข้อความ ในตัวอย่างด้านล่าง เราได้เพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้าย ให้บันทึกไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`  

โค้ด Java นี้—การทำตามขั้นตอนข้างต้น—แสดงวิธีการเพิ่มข้อความในสไลด์:

```java
// สร้างอินสแตนซ์ Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ที่มีประเภทเป็น Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame(" ");

    // เข้าถึง TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
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

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#isTextBox--) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ที่ช่วยให้คุณตรวจสอบรูปทรงและระบุว่ากล่องข้อความหรือไม่

![Text box and shape](istextbox.png)

โค้ด Java นี้แสดงวิธีการตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่: 

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

โปรดทราบว่าหากคุณเพียงแค่เพิ่ม autoshape ด้วยเมธอด `addAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) เมธอด `isTextBox` ของ autoshape จะคืนค่า `false` อย่างไรก็ตาม เมื่อคุณเพิ่มข้อความให้กับ autoshape ด้วยเมธอด `addTextFrame` หรือ `setText` คุณสมบัติ `isTextBox` จะคืนค่า `true`

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

## **เพิ่มคอลัมน์ในกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) และ [ColumnSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ในกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์ในกล่องข้อความและตั้งค่าการเว้นระยะห่างเป็นจุดระหว่างคอลัมน์ได้

โค้ดนี้ใน Java แสดงการดำเนินการที่อธิบายไว้:

```java
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยตั้งค่าชนิดเป็น Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // เพิ่ม TextFrame ให้กับ Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // ดึงรูปแบบข้อความของ TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // ระบุจำนวนคอลัมน์ใน TextFrame
    format.setColumnCount(3);

    // ระบุระยะห่างระหว่างคอลัมน์
    format.setColumnSpacing(10);

    // บันทึกงานนำเสนอ
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มคอลัมน์ใน Text Frame**

Aspose.Slides for Android via Java มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านคุณสมบัตินี้ คุณสามารถระบุจำนวนคอลัมน์ที่ต้องการใน Text Frame ได้

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

## **อัพเดตข้อความ**

Aspose.Slides ช่วยให้คุณเปลี่ยนหรืออัพเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดที่อยู่ในงานพรีเซนเทชัน

โค้ด Java นี้สาธิตการดำเนินการที่อัพเดตหรือเปลี่ยนข้อความทั้งหมดในงานพรีเซนเทชัน:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //ตรวจสอบว่ารูปทรงรองรับกรอบข้อความ (IAutoShape) หรือไม่.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //วนลูปผ่านย่อหน้าในกรอบข้อความ
                {
                    for (IPortion portion : paragraph.getPortions()) //วนลูปผ่านแต่ละ portion ในย่อหน้า
                    {
                        portion.setText(portion.getText().replace("years", "months")); //เปลี่ยนข้อความ
                        portion.getPortionFormat().setFontBold(NullableBool.True); //เปลี่ยนรูปแบบ
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

## **เพิ่มกล่องข้อความที่มีลิงก์**

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกนําไปเปิดลิงก์

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. รับอ้างอิงของสไลด์แรกในงานพรีเซนเทชันที่เพิ่งสร้าง  
3. เพิ่มอ็อบเจกต์ `AutoShape` ที่มี `ShapeType` ตั้งค่าเป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ AutoShape ที่เพิ่งเพิ่ม  
4. เพิ่ม `TextFrame` ให้กับอ็อบเจกต์ `AutoShape` ที่มี *Aspose TextBox* เป็นข้อความเริ่มต้น  
5. สร้างอินสแตนซ์ของคลาส `IHyperlinkManager`  
6. กําหนดอ็อบเจกต์ `IHyperlinkManager` ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) ที่เชื่อมโยงกับส่วนที่คุณต้องการของ `TextFrame`  
7. สุดท้าย ให้บันทึกไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`  

โค้ด Java นี้—การทำตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มกล่องข้อความที่มีลิงก์ไปยังสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มอ็อบเจกต์ AutoShape โดยตั้งค่าชนิดเป็น Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // แคสต์รูปทรงเป็น AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // เพิ่มข้อความบางส่วนลงในเฟรม
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ตั้งค่าลิงก์สำหรับข้อความ portion
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

**ความแตกต่างระหว่างกล่องข้อความและตัวเล่นข้อความเมื่อทำงานกับมาสเตอร์สไลด์คืออะไร?**

A [placeholder](/slides/th/androidjava/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/) และสามารถถูกแทนที่ได้บน [layouts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) ส่วนกล่องข้อความทั่วไปเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อตามสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความเป็นกลุ่มทั่วทั้งพรีเซนเทชันโดยไม่กระทบข้อความภายในแผนภูมิ ตาราง และ SmartArt ได้อย่างไร?**

จำกัดการวนรอบของคุณให้กับ auto‑shapes ที่มี text frame เท่านั้นและไม่รวมวัตถุที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/smartart/)) โดยการเดินทางผ่านคอลเลกชันของพวกมันแยกกันหรือข้ามประเภทวัตถุนั้น