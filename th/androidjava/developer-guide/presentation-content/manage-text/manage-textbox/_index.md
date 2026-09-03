---
title: จัดการกล่องข้อความในงานนำเสนอบน Android
linktitle: จัดการกล่องข้อความ
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
description: "สร้าง, ระบุ, จัดรูปแบบ, และอัปเดตกล่องข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

ใน Aspose.Slides for Android via Java, ข้อความบนสไลด์จะถูกจัดเก็บไว้ในกรอบข้อความซึ่งเป็นส่วนหนึ่งของรูปร่าง อินเตอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แสดงถึงรูปร่างที่มีข้อความทั่วไปที่สุดและเปิดเผยข้อความของมันผ่านเมธอด [IAutoShape.getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) 

{{% alert color="info" title="Note" %}}
รูปร่างอัตโนมัติทุกตัวจะ implement [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/), แต่ไม่ใช่ทุกรูปร่างเป็นรูปร่างอัตโนมัติหรือสนับสนุนกรอบข้อความ เมื่อต้องประมวลผลงานนำเสนอที่มีอยู่ ให้ตรวจสอบว่ารูปร่างนั้น implement [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ก่อนเข้าถึงข้อความของมัน
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความ ให้เพิ่มรูปร่างอัตโนมัติลงในสไลด์, เพิ่มข้อความลงในกรอบข้อความของมัน, แล้วบันทึกงานนำเสนอ ตัวอย่างต่อไปนี้สร้างกล่องข้อความสี่เหลี่ยม:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

พิกัดและขนาดที่ส่งไปยัง [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) วัดเป็นจุด [IAutoShape.addTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) จะเริ่มต้นกรอบข้อความด้วยข้อความที่ระบุ

## **ตรวจสอบรูปทรงกล่องข้อความ**

ใช้เมธอด [IAutoShape.isTextBox](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#isTextBox--) เพื่อตรวจสอบว่ารูปร่างอัตโนมัติได้รับการพิจารณาเป็นกล่องข้อความหรือไม่ สิ่งนี้มีประโยชน์เมื่องานนำเสนอมีทั้งรูปร่างที่มีข้อความและรูปร่างกราฟิกเพียว ๆ

![กล่องข้อความและรูปร่าง](istextbox.png)

ตัวอย่างต่อไปนี้ตรวจสอบรูปร่างอัตโนมัติทุกตัวในงานนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

รูปร่างอัตโนมัติที่เพิ่มใหม่จะไม่ถูกพิจารณาว่าเป็นกล่องข้อความจนกว่าจะมีข้อความที่ไม่ว่างเปล่า คุณสามารถใส่ข้อความนั้นผ่าน [IAutoShape.addTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) หรือ [ITextFrame.setText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) การเพิ่มหรือกำหนดสตริงว่างทำให้ [IAutoShape.isTextBox](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#isTextBox--) คืนค่า `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

การเรียกครั้งแรกสองครั้งพิมพ์ `true`; สองครั้งสุดท้ายพิมพ์ `false`.

## **ค้นหารูปร่างที่เป็นเจ้าของกรอบข้อความ**

โค้ดการประมวลผลข้อความทั่วไปอาจได้รับ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) โดยไม่ทราบว่าวัตถุงานนำเสนอใดเป็นเจ้าของ ใช้เมธอดอ่านอย่างเดียว [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) เพื่อย้อนกลับไปยัง [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ที่เป็นเจ้าของ

สำหรับกรอบข้อความที่เป็นของรูปร่างอัตโนมัติหรือรูปร่างที่มีข้อความอื่น ๆ, [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) คืนค่าเจ้าของและ [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) คืนค่า `null` ตรวจสอบค่าที่คืนมาก่อนเข้าถึง เพื่อระบุทั้งเจ้าของรูปร่างและเซลล์ตาราง รวมถึงรูปร่างที่เชื่อมโยงกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/androidjava/search-and-replace-text/)

## **เพิ่มคอลัมน์ในกล่องข้อความ**

เมธอด [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) แบ่งกรอบข้อความเป็นคอลัมน์ ส่วน [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) ตั้งช่องว่างระหว่างคอลัมน์เป็นจุด ทั้งสองการตั้งค่าเป็นของ [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/) และสามารถเปลี่ยนแปลงได้ผ่านกรอบข้อความของกล่องข้อความที่มีอยู่ ข้อความจะไหลใหม่ระหว่างคอลัมน์ภายในรูปร่างเดียวกัน; จะไม่ต่อเนื่องไปยังรูปร่างอื่น

ตัวอย่างต่อไปนี้สร้างกล่องข้อความสามคอลัมน์โดยมีช่องว่าง 10 จุดระหว่างคอลัมน์, บันทึกงานนำเสนอ, และอ่านการตั้งค่าที่เก็บไว้จากไฟล์ผลลัพธ์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **สกัดข้อความจากแต่ละคอลัมน์**

ใช้ [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) เพื่อดึงข้อความที่กำหนดให้แต่ละคอลัมน์ที่มองเห็นได้ในกรอบข้อความที่มีอยู่ เมธอดจะคืนสตริงหนึ่งค่าให้แต่ละคอลัมน์ตามลำดับการอ่านแบบคอลัมน์ กรอบข้อความที่มีเพียงคอลัมน์เดียวจะสร้างอาเรย์ที่มีหนึ่งสมาชิก และคอลัมน์ว่างจะเป็นสตริงว่าง สตริงเหล่านี้มีเฉพาะข้อความธรรมดา; การจัดรูปแบบระดับส่วนจะไม่ถูกเก็บรักษา

สิ่งนี้มีประโยชน์เมื่อคุณต้อง:

- สกัดข้อความพร้อมคงลำดับการอ่านตามคอลัมน์
- ทำดัชนีหรือเปรียบเทียบเนื้อหาของสไลด์หลายคอลัมน์
- ส่งออกแต่ละคอลัมน์ไปยังไฟล์, ฟิลด์ฐานข้อมูล หรือปลายทางอื่นแยกกัน
- ตรวจสอบวิธีที่ข้อความถูกจัดสรรใหม่หลังจากเปลี่ยนจำนวนคอลัมน์ด้วย [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), ช่องว่างด้วย [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), ฟอนต์, หรือขนาดกรอบข้อความ

เมธอดนี้รายงานข้อความที่กระจายอยู่ภายใน [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ปัจจุบัน; มันจะไม่ไหลอัตโนมัติระหว่างรูปร่างหรือกล่องข้อความแยกต่างหาก การกระจายคอลัมน์อาจขึ้นกับฟอนต์ที่มีและการตั้งค่าเลย์เอาต์ข้อความอื่น ๆ ดังนั้นให้แน่ใจว่าฟอนต์ที่ต้องการพร้อมใช้งานเมื่อผลลัพธ์ที่สอดคล้องกันสำคัญ

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ค้นหารูปร่างอัตโนมัติหลายคอลัมน์แรกที่มีกรอบข้อความ, อ่านจำนวนคอลัมน์ที่กำหนดไว้, และเขียนข้อความจากทุกคอลัมน์ไปยังไฟล์แยกกัน รูปร่างที่ไม่มีกรอบข้อความจะถูกข้าม

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **อัปเดตข้อความ**

เพื่ออัปเดตข้อความทั่วทั้งงานนำเสนอ, ให้วนลูปผ่านสไลด์และรูปร่าง, เลือกรูปร่างอัตโนมัติ, แล้วแก้ไขส่วนข้อความของมัน การทำงานที่ระดับส่วนทำให้คุณเปลี่ยนทั้งข้อความและการจัดรูปแบบอักขระได้

ตัวอย่างต่อไปนี้แทนที่ทุกตำแหน่งของ `years` ด้วย `months` ในข้อความของรูปร่างอัตโนมัติและทำให้ส่วนที่ได้รับผลกระทบแต่ละส่วนเป็นตัวหนา:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การวนลูปนี้จะอัปเดตข้อความเฉพาะในรูปร่างอัตโนมัติ เท่านั้น ข้อความที่เก็บอยู่ในตาราง, แผนภูมิ, SmartArt หรือรูปร่างที่กลุ่มไว้ต้องวนลูปผ่านคอลเลคชันของอ็อบเจ็กต์เหล่านั้น

## **เพิ่มกล่องข้อความพร้อมลิงก์**

ลิงก์สามารถกำหนดให้กับส่วนข้อความเฉพาะได้ ดังนั้นข้อความส่วนนั้นเท่านั้นจะทำหน้าที่เป็นลิงก์คลิกได้ ใช้ [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) เพื่อเชื่อมโยงส่วนนั้นกับ URL ภายนอก

ตัวอย่างต่อไปนี้สร้างข้อความที่ลิงก์และบันทึกลงในงานนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**  
[placeholder](/slides/th/androidjava/manage-placeholder/) สามารถสืบทอดตำแหน่งและการจัดรูปแบบจาก [master slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/) หรือ [layout slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) กล่องข้อความทั่วไปเป็นรูปร่างอิสระบนสไลด์ที่สร้างขึ้นและจะไม่รับพฤติกรรมของ placeholder เมื่อเลย์เอาต์เปลี่ยนแปลง

**How can I replace text without changing text in charts, tables, or SmartArt?**  
จำกัดการวนลูปเฉพาะรูปร่างที่ implement [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ตามที่แสดงในตัวอย่าง Update Text แผนภูมิ, ตาราง, และ SmartArt เก็บข้อความในโมเดลอ็อบเจ็กต์ของตนเอง จึงไม่ถูกแก้ไขโดยลูปนั้น