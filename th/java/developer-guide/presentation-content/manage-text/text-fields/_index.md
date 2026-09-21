---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Java
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/java/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันและเวลา
- ส่วนหัว
- ส่วนล่าง
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "สร้าง ตรวจสอบ แก้ไข และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java. คงรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ปกติ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) มีข้อความตามตัวอักษร; ส่วนของฟิลด์ยังมี [IField](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifield/) ที่ประเภทของมันบ่งบอกค่าที่อัปเดตอัตโนมัติ เช่น หมายเลขสไลด์หรือวันที่ ส่วนสองสามารถแสดงอักขระเดียวกันได้ในขณะที่เพียงส่วนเดียวมีฟิลด์

ใช้ [IPortion.getField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getField--) เพื่อแยกความแตกต่าง: ค่าจะเป็น `null` สำหรับข้อความธรรมดา [IPortion.addField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) จะแปลงส่วนที่มีอยู่ให้เป็นฟิลด์ เก็บฉลากและค่าที่เป็นไดนามิกไว้ในส่วนแยกกันเพื่อให้การแปลงค่านั้นไม่ได้แทนที่ฉลาก

คู่มือเล่มนี้ครอบคลุมฟิลด์ภายในข้อความ การจัดรูปแบบ และการบันทึกเป็น PPTX และ PPT สำหรับกรอบข้อความและย่อหน้า ดูที่ [Manage Text](/slides/th/java/manage-text/)

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างเต็มต่อไปนี้สร้างกล่องข้อความที่มีฉลากตัวอักษร `Slide ` ตามด้วยหมายเลขที่อัปเดตอัตโนมัติ ตั้งค่าขนาด น้ำหนัก และสีของหมายเลขก่อนเพิ่มฟิลด์ จากนั้นเปิดงานนำเสนอที่บันทึกไว้ใหม่และตรวจสอบประเภทฟิลด์ ข้อความ และการจัดรูปแบบ ไม่ต้องใช้ไฟล์อินพุต

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

งานนำเสนอใหม่เริ่มต้นด้วยหมายเลขสไลด์ 1 จึงข้อความเป็น `Slide 1` และการตรวจสอบทั้งสองพิมพ์ `true` หมายเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; ไม่ได้เป็นข้อความตามตัวอักษร `1` การแคสท์และดัชนีในการตรวจสอบอ้างอิงถึงรูปร่างและส่วนที่สร้างจากตัวอย่างนี้

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/) ทำการนำเข้า [IFieldType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifieldtype/) และมีเมธอดต่อไปนี้เพื่อรับค่าที่กำหนดไว้ล่วงหน้า ส่งค่าที่เหมาะสมไปยัง [addField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getSlideNumber--) | หมายเลขสไลด์ปัจจุบัน |
| [getDateTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getDateTime--) | วันที่/เวลาในรูปแบบเริ่มต้นของแอปพลิเคชันที่ทำการเรนเดอร์ |
| [getDateTime1](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getDateTime9--) | รูปแบบวันที่หรือวันที่/เวลาที่กำหนดไว้ล่วงหน้า |
| [getDateTime10](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getDateTime13--) | รูปแบบเวลาโดยมีตัวเลือกสำหรับวินาทีและนาฬิกา 12 ชั่วโมง |
| [getHeader](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getHeader--) | ฟิลด์ส่วนหัว; ดูข้อจำกัดของตัวแปรแทนและรูปแบบด้านล่าง |
| [getFooter](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getFooter--) | ฟิลด์ส่วนล่าง |

ตัวอย่างเช่น [getDateTime3](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#getDateTime3--) แสดงวัน เดือนเต็มเป็นภาษาอังกฤษและปี เหล่านี้เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า ไม่ใช่สตริงรูปแบบวันที่ของ Java ภาษา ที่ตั้งด้วย [setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) และแอปพลิเคชันที่ประมวลผลงานนำเสนออาจส่งผลต่อผลลัพธ์ที่แสดง

## **สร้างฟิลด์จากสตริงภายใน**

การอัดโหลดของสตริงใน [addField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#addField-java.lang.String-) รับตัวระบุฟิลด์ภายใน ใช้เมื่อคุณต้องการเก็บตัวระบุที่แอปพลิเคชันอื่นให้มา ซึ่งไม่มีค่าที่กำหนดไว้ล่วงหน้า คุณยังสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) จากตัวระบุนั้นได้ [IFieldType.getInternalString](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifieldtype/#getInternalString--) จะเปิดเผยตัวระบุนั้นเพื่อให้ตรวจสอบ

ตัวอย่างนี้เก็บฟิลด์ `custom-report-id` ที่กำหนดโดยแอปพลิเคชันพร้อมข้อความสำรอง `Report-042` ตัวระบุไม่ได้ทำการคำนวณ: Aspose.Slides ไม่สร้าง ID รายงานสำหรับชนิดที่ไม่รู้จัก แอปพลิเคชันที่เข้าใจตัวระบุนี้ต้องให้ความหมายและอัปเดตค่าเอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

หลังจากรอบการบันทึก PPTX ประเภทจะเป็น `custom-report-id` และข้อความเป็น `Report-042` การส่งสตริงเช่น `yyyy-MM-dd` จะสร้างชื่อประเภทฟิลด์; จะไม่ตั้งค่ารูปแบบวันที่แบบกำหนดเอง หากต้องการวันที่คงที่ในรูปแบบใด ๆ ให้ใช้ข้อความธรรมดา

## **ตรวจสอบ แก้ไข และลบฟิลด์วันที่/เวลา**

เปลี่ยนฟิลด์ที่มีอยู่ผ่าน [IField.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) ตรวจสอบว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน เพื่อหยุดการอัปเดตอัตโนมัติ ให้เรียก [IPortion.removeField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#removeField--)  ซึ่งจะคงส่วนและข้อความปัจจุบันไว้แต่ลบการเชื่อมโยงฟิลด์ หากต้องการค่าคงที่เฉพาะ ให้กำหนดข้อความนั้นหลังจากลบฟิลด์

สำหรับการตั้งค่า API ที่เกี่ยวข้องกับการประมวลผลฟิลด์วันที่/เวลา ดูที่ [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) ตัวอย่างด้านล่างใช้วันที่อนุมัติอย่างชัดเจนเมื่อแปลงฟิลด์เป็นข้อความธรรมดา

ดาวน์โหลด [sample.pptx](sample.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน ตัวไฟล์มีรูปร่างข้อความที่ตั้งชื่อไว้สองรูป `UpdatedAt` และ `ApprovedDate` แต่ละรูปมีฟิลด์วันที่/เวลา พร้อมฉลากข้อความธรรมดา ตัวอย่างต่อไปนี้เดินทางผ่านรูปร่างข้อความระดับบนของสไลด์ปกติ เปลี่ยนฟิลด์วันที่/เวลาให้เป็นรูปแบบวันที่ยาวและทำให้เป็นอิตาลิก โดยคงการจัดรูปแบบอื่นไว้ ไม่เพียงฟิลด์ใน `ApprovedDate` จะกลายเป็นข้อความคงที่

ตัวระบุภายในที่สร้างไว้แล้ว `datetime` ถึง `datetime13` จะถูกจำแนกโดยตัวอย่าง กลุ่ม ตาราง โน้ตเลย์เอาต์ และมาสเตอร์ต้องเดินทางผ่านคอนเทนเนอร์ข้อความของตนเองและอยู่นอกขอบเขตของตัวอย่างนี้

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

หลังจากเปิดใหม่ `UpdatedAt` มีประเภท `datetime3` และยังคงเป็นไดนามิก `ApprovedDate` ไม่มีฟิลด์และมีข้อความ `05 April 2030` ทั้งสองส่วนวันที่เป็นอิตาลิก และขนาดฟอนต์ น้ำหนักตัวหนา และสีเดิมยังคงอยู่ ฉลากข้อความธรรมดาไม่ได้เปลี่ยนแปลง การตรวจสอบอ่านส่วนแรกของสองรูปร่างที่รู้จักในตัวอย่างที่ให้มา

## **คงรูปแบบข้อความไว้**

ทำงานกับส่วนที่มีอยู่เมื่อเพิ่มฟิลด์ เปลี่ยนประเภท หรือเอาออก การทำเช่นนี้จะรักษาการจัดรูปแบบของส่วนนั้น ใช้ [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getPortionFormat--) เพื่อเปลี่ยนเฉพาะคุณสมบัติที่ต้องการ ตามที่ตัวอย่างทำสำหรับสีหรืออิตาลิก

หลีกเลี่ยงการสร้างกรอบข้อความใหม่ทั้งหมดเพื่ออัปเดตฟิลด์เดียว: การทำเช่นนั้นอาจทำให้พิกัดส่วนเดิมและการจัดรูปแบบแยกของมันสูญหาย นอกจากนี้ควรแยกความแตกต่างระหว่างการจัดรูปแบบที่ตั้งโดยตรงกับการจัดรูปแบบที่สืบทอดมาจากย่อหน้า เลย์เอาต์ หรือธีม ดูที่ [Text Formatting](/slides/th/java/text-formatting/) เพื่อทราบตัวเลือกการจัดรูปแบบที่กว้างขึ้น

## **ฟิลด์และตัวแทนสถานที่สำหรับส่วนหัว/ส่วนล่าง**

ฟิลด์เป็นส่วนหนึ่งของส่วนข้อความ ตัวแทนสถานที่คือรูปร่างที่มีบทบาทในงานนำเสนอ เช่น ส่วนล่างหรือหมายเลขสไลด์ การเพิ่มฟิลด์ในกล่องข้อความธรรมดาจะไม่ทำให้รูปร่างนั้นกลายเป็นตัวแทนสถานที่

ผู้จัดการส่วนหัว/ส่วนล่างควบคุมข้อความตัวแทนสถานที่และการมองเห็นบนสไลด์ เลย์เอาต์ และมาสเตอร์ รวมถึงการกระจายไปยังสไลด์ที่ขึ้นต่อกัน ฟิลด์หมายเลขในกล่องข้อความกำหนดเองจึงอาจมีประโยชน์แม้คุณไม่ใช้ตัวแทนสถานที่หมายเลขสไลด์ ตรงกันข้าม การเปลี่ยนการมองเห็นของตัวแทนสถานที่ไม่ได้ลบฟิลด์จากกล่องข้อความที่ไม่มีความสัมพันธ์

ประเภทส่วนหัวและส่วนล่างที่กำหนดไว้ล่วงหน้าไม่ได้สร้างตัวแทนสถานที่ที่สอดคล้องหรือให้เนื้อหาของมัน โดยเฉพาะ สไลด์ PowerPoint ปกติไม่มีตัวแทนสถานที่ส่วนหัว; ส่วนหัวเป็นของหน้าบันทึกย่อและเอกสารแจกแจง อย่าสันนิษฐานว่าฟิลด์ส่วนหัวหรือส่วนล่างในรูปร่างใด ๆ จะได้รับข้อความที่กำหนดผ่านผู้จัดการตัวแทนสถานที่โดยอัตโนมัติ สำหรับขั้นตอนนั้นดูที่ [Presentation Headers and Footers](/slides/th/java/presentation-header-and-footer/)

## **ข้อจำกัดของ PPTX และ PPT**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่ การเก็บตัวระบุไม่ได้พิสูจน์ว่าแอปพลิเคชันสามารถคำนวณหรือแสดงค่าของมันได้

| Format | Field behavior and limitations |
|---|---|
| PPTX | เก็บตัวระบุฟิลด์ภายในพร้อมข้อความฟิลด์ ในการตรวจสอบรอบการบันทึก ประเภทที่กำหนดไว้ล่วงหน้าและตัวระบุกำหนดเองที่ใช้ข้างต้นยังคงอยู่หลังการบันทึกและเปิดใหม่ ตัวระบุที่ไม่รู้จักยังคงข้อความสำรอง; ไม่ได้รับตรรกะการคำนวณอัตโนมัติ แอปพลิเคชันอื่นอาจจัดการตัวระบุที่ไม่ได้สนับสนุนแตกต่างกัน |
| PPT | ใช้การแสดงฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดกว่า ในการตรวจสอบรอบการบันทึก ฟิลด์หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดไว้ล่วงหน้ายังคงอยู่หลังการบันทึกและเปิดใหม่ ฟิลด์กำหนดเองในกล่องข้อความสไลด์ธรรมดาเปิดใหม่โดยมีตัวระบุแต่ข้อความเป็น `*`; ฟิลด์ส่วนหัวในบริบทเดียวกันก็ให้ผลเป็น `*` ไม่ควรพึ่งพาฟิลด์กำหนดเองหรือบริบทฟิลด์ที่ไม่ได้สนับสนุนให้คงข้อความที่มองเห็นได้ |

สำหรับผลลัพธ์ที่พกพาและคงที่ ให้แปลงฟิลด์ที่ไม่ได้สนับสนุนเป็นข้อความธรรมดาและกำหนดค่าที่ต้องการอย่างชัดเจนก่อนบันทึก วิธีนี้จะคงข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติ ตรวจสอบแอปพลิเคชันเป้าหมายด้วยเมื่อการคำนวณฟิลด์ของมันเป็นส่วนหนึ่งของขั้นตอนทำงานของคุณ

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าตัวเลขหรือวันที่ที่แสดงเป็นฟิลด์หรือไม่?**

ตรวจสอบ [IPortion.getField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getField--) ค่าไม่เป็น `null` แสดงว่ามันเป็นฟิลด์; ข้อความที่แสดงอย่างเดียวไม่บอกได้

**การลบฟิลด์จะลบข้อความหรือการจัดรูปแบบด้วยหรือไม่?**

ไม่ใช่ [removeField](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#removeField--) จะเปลี่ยนส่วนที่มีอยู่ให้เป็นข้อความธรรมดา หากต้องการค่าคงที่เฉพาะ ให้กำหนดค่าตรงนั้นหลังจากลบฟิลด์

**สตริงภายในสามารถกำหนดรูปแบบวันที่หรือสูตรใหม่ได้หรือไม่?**

ไม่ได้; มันเป็นตัวระบุประเภทฟิลด์ ตัวระบุที่ไม่รู้จักไม่ให้ตัวประเมินหรือรูปแบบวันที่ของ Java ใช้ประเภทที่สนับสนุนหรือจัดรูปแบบค่าด้วยตนเองเป็นข้อความธรรมดา

**ทำไมต้องตรวจสอบงานนำเสนออีกครั้งหลังจากบันทึก?**

ตัวระบุฟิลด์ ข้อความที่คำนวณ และการจัดรูปแบบเป็นสิ่งต่างกันที่ต้องตรวจสอบ การแปลงรูปแบบอาจเปลี่ยนผลลัพธ์ที่มองเห็นได้แม้ว่าตัวระบุฟิลด์ยังคงอยู่ก็ตาม