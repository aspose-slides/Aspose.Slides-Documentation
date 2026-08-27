---
title: "จัดการกล่องข้อความในงานนำเสนอบน Android"
linktitle: "จัดการกล่องข้อความ"
type: docs
weight: 20
url: /th/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย เพิ่มประสิทธิภาพการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์โดยทั่วไปอยู่ในกล่องข้อความหรือรูปร่าง ดังนั้นเพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความลงในกล่องข้อความนั้น Aspose.Slides for Android via Java มีอินเตอร์เฟส [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ที่อนุญาตให้คุณเพิ่มรูปร่างที่มีข้อความ

{{% alert title="Info" color="info" %}}

Aspose.Slides ยังมีอินเตอร์เฟส [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape) ซึ่งอนุญาตให้คุณเพิ่มรูปร่างลงในสไลด์ อย่างไรก็ตามไม่ใช่ทุกรูปร่างที่เพิ่มผ่านอินเตอร์เฟส `IShape` จะสามารถเก็บข้อความได้ แต่รูปร่างที่เพิ่มผ่านอินเตอร์เฟส [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) อาจมีข้อความได้

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

ดังนั้นเมื่อทำงานกับรูปร่างที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ารูปร่างนั้นถูกแคสท์ผ่านอินเตอร์เฟส `IAutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrame) ซึ่งเป็นคุณสมบัติกลายภายใต้ `IAutoShape` ได้ ดูส่วน [อัปเดตข้อความ](https://docs.aspose.com/slides/th/androidjava/manage-textbox/#update-text) ในหน้านี้

{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างใหม่  
3. เพิ่มอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) โดยตั้งค่า [ShapeType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ `IAutoShape` ที่เพิ่มใหม่  
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจกต์ `IAutoShape` ที่จะบรรจุตัวอักษร ในตัวอย่างด้านล่าง เราเพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`  

โค้ด Java นี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีการเพิ่มข้อความลงในสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของ Presentation
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยตั้งประเภทเป็น Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // เพิ่ม TextFrame ไปยัง Rectangle
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

## **ตรวจสอบรูปร่างกล่องข้อความ**

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#isTextBox--) จากอินเตอร์เฟส [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ที่ช่วยให้คุณตรวจสอบรูปร่างและระบุว่ามันเป็นกล่องข้อความหรือไม่

![กล่องข้อความและรูปร่าง](istextbox.png)

โค้ด Java นี้แสดงวิธีการตรวจสอบว่ารูปร่างถูกสร้างเป็นกล่องข้อความหรือไม่:

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

ควรทราบว่าหากคุณเพิ่มออโต้ชเปโดยใช้เมธอด `addAutoShape` จากอินเตอร์เฟส [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) เมธอด `isTextBox` ของออโต้ชเปจะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความให้กับออโต้ชเปด้วยเมธอด `addTextFrame` หรือเมธอด `setText` คุณสมบัติ `isTextBox` จะคืนค่า `true`

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

ในโค้ดการประมวลผลข้อความทั่วไป คุณอาจได้รับอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) โดยยังไม่รู้ว่าอยู่ในงานนำเสนอไหน ใช้เมธอด [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) เพื่อกลับไปยังเจ้าของ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/)

สำหรับ Text Frame ที่เป็นของ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) หรือรูปร่างอื่นที่มีข้อความ [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) จะคืนค่าเจ้าของและ [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่า `null` ทั้งสองเมธอดเป็นการนำทางแบบอ่านอย่างเดียวจึงไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบค่า `null` ก่อนเข้าถึงรูปร่างเสมอ

สำหรับตัวอย่างเต็มที่ระบุเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/androidjava/search-and-replace-text/)

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) และ [ColumnSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (จากอินเตอร์เฟส [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)) ที่อนุญาตให้คุณเพิ่มคอลัมน์ให้กับกล่องข้อความ คุณสามารถระบุจำนวนคอลัมน์และกำหนดระยะห่างเป็นจุดระหว่างคอลัมน์ได้

โค้ด Java นี้แสดงการดำเนินการตามที่อธิบาย:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // รับสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape โดยตั้งประเภทเป็น Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // เพิ่ม TextFrame ไปยัง Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // รับรูปแบบข้อความของ TextFrame
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

## **เพิ่มคอลัมน์ให้กับ Text Frame**

Aspose.Slides for Android via Java มีคุณสมบัติ [ColumnCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (จากอินเตอร์เฟส [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat)) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame โดยคุณสามารถระบุจำนวนคอลัมน์ที่ต้องการได้

โค้ด Java นี้แสดงวิธีการเพิ่มคอลัมน์ภายใน Text Frame:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
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

Aspose.Slides อนุญาตให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในงานนำเสนอ

โค้ด Java นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนข้อความทั้งหมดในงานนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //ตรวจสอบว่ารูปร่างรองรับ text frame (IAutoShape) หรือไม่. 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //วนซ้ำผ่านย่อหน้าใน text frame
                {
                    for (IPortion portion : paragraph.getPortions()) //วนซ้ำผ่านแต่ละ portion ในย่อหน้า
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

## **เพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์**

คุณสามารถแทรกลิงก์ภายในกล่องข้อความ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกพาไปเปิดลิงก์นั้น

ขั้นตอนการเพิ่มกล่องข้อความที่มีลิงก์:

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอที่สร้างใหม่  
3. เพิ่มอ็อบเจกต์ `AutoShape` โดยตั้งค่า `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ AutoShape ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ให้กับอ็อบเจกต์ `AutoShape` และตั้งข้อความของส่วนแรก ในตัวอย่างด้านล่างเราใช้ข้อความนี้: *Aspose.Slides*  
5. รับอ็อบเจกต์ [IHyperlinkManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/) จาก `PortionFormat` ของส่วนที่ต้องการใน `TextFrame`  
6. เรียกเมธอด [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) เพื่อกำหนดลิงก์ที่เปิดเมื่อข้อความถูกคลิก  
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`  

โค้ด Java นี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีการเพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์ลงบนสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มอ็อบเจกต์ AutoShape โดยตั้งประเภทเป็น Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // แปลงรูปร่างเป็น AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // เพิ่มข้อความบางส่วนลงในเฟรม
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // ตั้งค่า Hyperlink สำหรับข้อความ portion
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

**ความแตกต่างระหว่างกล่องข้อความและตัวเก็บตำแหน่งข้อความเมื่อทำงานกับสไลด์แม่คืออะไร?**

[placeholder](/slides/th/androidjava/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/) และสามารถถูกเขียนทับบน [layouts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) ส่วนกล่องข้อความทั่วไปเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความเป็นจำนวนมากทั่วงานนำเสนอโดยไม่กระทบถึงข้อความในแผนภูมิ ตาราง และ SmartArt อย่างไร?**

จำกัดการวนรอบเฉพาะออโต้ชเปที่มี Text Frame และแยกออกจากอ็อบเจกต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/smartart/)) โดยการท่องคอลเลกชันของพวกมันแยกกันหรือข้ามประเภทอ็อบเจกต์เหล่านั้น.