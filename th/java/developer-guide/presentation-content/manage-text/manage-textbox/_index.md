---
title: จัดการกล่องข้อความในงานนำเสนอด้วย Java
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/java/manage-textbox/
keywords:
- กล่องข้อความ
- กรอบข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ทำให้การสร้าง แก้ไข และทำสำเนากล่องข้อความในไฟล์ PowerPoint และ OpenDocument ง่ายขึ้น ช่วยปรับปรุงการทำงานอัตโนมัติของงานนำเสนอของคุณ"
---
## **บทนำ**

ข้อความบนสไลด์โดยทั่วไปจะอยู่ในกล่องข้อความหรือรูปร่าง ดังนั้นเมื่อต้องการเพิ่มข้อความลงสไลด์ คุณต้องเพิ่มกล่องข้อความก่อนแล้วจึงใส่ข้อความลงในกล่องนั้น Aspose.Slides for Java มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่ช่วยให้คุณสามารถเพิ่มรูปร่างที่มีข้อความได้.

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังให้บริการอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape) ที่ช่วยให้คุณเพิ่มรูปร่างลงในสไลด์ อย่างไรก็ตามรูปร่างทั้งหมดที่เพิ่มผ่านอินเทอร์เฟซ `IShape` ไม่สามารถบรรจุข้อความได้ แต่รูปร่างที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) อาจมีข้อความได้. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
ดังนั้นเมื่อต้องจัดการกับรูปร่างที่ต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่าได้ทำการแคสท์ผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้น จึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/TextFrame) ซึ่งเป็นพร็อพเพอร์ตี้ของ `IAutoShape` ได้ ดูส่วน [Update Text](https://docs.aspose.com/slides/th/java/manage-textbox/#update-text) ในหน้านี้. 
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation). 
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างใหม่. 
3. เพิ่มอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) โดยกำหนด [ShapeType](https://reference.aspose.com/slides/th/java/com.aspose.slides/IGeometryShape#setShapeType-int-) เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ `IAutoShape` ที่เพิ่มใหม่. 
4. เพิ่มพร็อพเพอร์ตี้ `TextFrame` ให้กับอ็อบเจกต์ `IAutoShape` ที่จะบรรจุข้อความ ในตัวอย่างด้านล่าง เราเพิ่มข้อความนี้: *Aspose TextBox* 
5. สุดท้ายเขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`. 

โค้ด Java นี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มข้อความลงสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกใน Presentation
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยกำหนด type เป็น Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame(" ");

    // เข้าถึง TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // ตั้งค่า Text
    portion.setText("Aspose TextBox");

    // บันทึก Presentation ลงดิสก์
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตรวจสอบรูปทรงกล่องข้อความ**

Aspose.Slides ให้บริการเมธอด [isTextBox](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/#isTextBox--) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ซึ่งช่วยให้คุณตรวจสอบรูปทรงและระบุว่ามันเป็นกล่องข้อความหรือไม่.

![กล่องข้อความและรูปทรง](istextbox.png)

โค้ด Java นี้แสดงวิธีตรวจสอบว่ารูปร่างถูกสร้างเป็นกล่องข้อความหรือไม่: 

```java
import com.aspose.slides.*;

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

หมายเหตุว่า หากคุณเพิ่มออโต้ชเมโดยใช้เมธอด `addAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) เมธอด `isTextBox` ของออโต้ชเมจะคืนค่า `false` อย่างไรก็ตามหลังจากคุณเพิ่มข้อความให้กับออโต้ชเมโดยใช้เมธอด `addTextFrame` หรือเมธอด `setText` พร็อพเพอร์ตี้ `isTextBox` จะคืนค่า `true`.

```java
import com.aspose.slides.*;

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

## **ค้นหารูปร่างที่เป็นเจ้าของ Text Frame**

ในโค้ดการประมวลผลข้อความทั่วไป คุณอาจได้รับอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) โดยที่ยังไม่รู้ว่ามันอยู่ในงานนำเสนอใด ใช้เมธอด [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentShape--) เพื่อนำทางกลับไปยัง [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ที่เป็นเจ้าของ.

สำหรับ Text Frame ที่เป็นของ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) หรือรูปร่างที่บรรจุข้อความอื่น ๆ เมธอด [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentShape--) จะคืนค่าเจ้าของและเมธอด [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่า `null` ทั้งสองเมธอดให้การนำทางแบบอ่านอย่างเดียว จึงไม่มีการเปลี่ยนแปลงความเป็นเจ้าของใด ๆ ควรตรวจสอบค่าที่คืนว่ามีค่าเป็น `null` ก่อนเข้าถึงรูปร่างเสมอ.

สำหรับตัวอย่างเต็มที่ระบุเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมกับโหนด SmartArt ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/java/search-and-replace-text/).

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

Aspose.Slides มีพร็อพเพอร์ตี้ [ColumnCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) และ [ColumnSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/TextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ให้กับกล่องข้อความ คุณสามารถระบุจำนวนคอลัมน์และกำหนดระยะห่างระหว่างคอลัมน์เป็นจุดได้.

โค้ด Java นี้แสดงการทำงานดังกล่าว: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยกำหนด type เป็น Rectangle
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

    // ระยะห่างระหว่างคอลัมน์
    format.setColumnSpacing(10);

    // บันทึกงานนำเสนอ
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มคอลัมน์ให้กับ Text Frame**

Aspose.Slides for Java มีพร็อพเพอร์ตี้ [ColumnCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านพร็อพเพอร์ตี้นี้ คุณสามารถระบุจำนวนคอลัมน์ที่ต้องการใน Text Frame ได้.

โค้ด Java นี้แสดงวิธีเพิ่มคอลัมน์ภายใน Text Frame:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **อัปเดตข้อความ**

Aspose.Slides อนุญาตให้คุณเปลี่ยนแปลงหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือทั้งหมดที่อยู่ในงานนำเสนอ.

โค้ด Java นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนแปลงข้อความทั้งหมดในงานนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //ตรวจสอบว่ารูปร่างสนับสนุน Text Frame (IAutoShape) หรือไม่.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //วนผ่านย่อหน้าใน Text Frame
                {
                    for (IPortion portion : paragraph.getPortions()) //วนผ่านแต่ละ Portion ในย่อหน้า
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

คุณสามารถแทรกลิงก์ภายในกล่องข้อความ เมื่อคลิกที่กล่องข้อความผู้ใช้จะถูกนำไปยังลิงก์นั้น.

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`. 
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างใหม่. 
3. เพิ่มอ็อบเจกต์ `AutoShape` โดยกำหนด `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ AutoShape ที่เพิ่มใหม่. 
4. เพิ่ม `TextFrame` ให้กับอ็อบเจกต์ `AutoShape` โดยมีข้อความเริ่มต้น *Aspose TextBox*. 
5. สร้างอินสแตนซ์ของคลาส `IHyperlinkManager`. 
6. กำหนดอ็อบเจกต์ `IHyperlinkManager` ให้กับพร็อพเพอร์ตี้ [HyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/Shape#getHyperlinkClick--) ที่เชื่อมกับส่วนที่คุณต้องการของ `TextFrame`. 
7. สุดท้ายเขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`. 

โค้ด Java นี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มกล่องข้อความพร้อมลิงก์ลงสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มอ็อบเจกต์ AutoShape โดยกำหนด type เป็น Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // แคสท์รูปร่างเป็น AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // เข้าถึงพร็อพเพอร์ตี้ ITextFrame ที่เชื่อมกับ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // เพิ่มข้อความบางส่วนลงในเฟรม
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ตั้งค่า Hyperlink ให้กับข้อความ Portion
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

**ความแตกต่างระหว่างกล่องข้อความและตัวแทนข้อความเมื่อทำงานกับสไลด์มาสเตอร์คืออะไร?**

[placeholder](/slides/th/java/manage-placeholder/) สืบทอดรูปแบบ/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterslide/) และสามารถถูกแทนที่ใน [layouts](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslide/) ส่วนกล่องข้อความทั่วไปเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อสลับเลย์เอาต์.

**ฉันจะทำการแทนที่ข้อความเป็นจำนวนมากทั่วทั้งงานนำเสนอโดยไม่กระทบข้อความในแผนภูมิ ตาราง และ SmartArt ได้อย่างไร?**

จำกัดการวนซ้ำเฉพาะออโต้ชเมที่มี Text Frame และละเว้นอ็อบเจกต์ฝังรวม ([charts](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/smartart/)) โดยการเดินสำรวจคอลเลกชันของพวกมันแยกกันหรือข้ามชนิดอ็อบเจกต์เหล่านั้น.