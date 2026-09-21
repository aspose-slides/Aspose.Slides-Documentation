---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint บน Android
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/androidjava/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันและเวลา
- ส่วนหัว
- ส่วนท้าย
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, แก้ไข, และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. คงรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **Overview**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ส่วนปกติของ [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) มีข้อความตามตัวอักษร; ส่วนฟิลด์จะมี [IField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifield/) ที่ประเภทของมันระบุค่าที่อัปเดตอัตโนมัติ เช่นหมายเลขสไลด์หรือวันที่ ส่วนสองส่วนอาจแสดงอักขระเดียวกันโดยที่เพียงส่วนหนึ่งเท่านั้นที่มีฟิลด์  

ใช้ [IPortion.getField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getField--) เพื่อแยกแยะ: ค่าจะเป็น `null` สำหรับข้อความปกติ. [IPortion.addField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) จะเปลี่ยนส่วนที่มีอยู่ให้เป็นฟิลด์. เก็บป้ายกำกับและค่าที่เปลี่ยนแปลงได้ไว้ในส่วนแยกกันเพื่อให้การแปลงค่าจะไม่ทำให้ป้ายกำกับถูกแทนที่ด้วย.  

คู่มือฉบับนี้ครอบคลุมฟิลด์ภายในข้อความ, การจัดรูปแบบของฟิลด์, และการบันทึกฟิลด์ในรูปแบบ PPTX และ PPT. สำหรับกรอบข้อความและย่อหน้า, ดู [Manage Text](/slides/th/androidjava/manage-text/).

## **Create a Slide Number Field**

ตัวอย่างสมบูรณ์ต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับตัวอักษร `Slide ` ตามด้วยหมายเลขที่อัปเดตอัตโนมัติ. ตัวอย่างกำหนดขนาด, ความหนา, และสีของหมายเลขก่อนเพิ่มฟิลด์, แล้วเปิดการนำเสนอที่บันทึกไว้ใหม่และตรวจสอบประเภทฟิลด์, ข้อความ, และการจัดรูปแบบ. ไม่ต้องใช้ไฟล์อินพุต.  

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

การนำเสนอใหม่เริ่มต้นด้วยหมายเลขสไลด์ที่ 1, ดังนั้นข้อความจะเป็น `Slide 1`, และการตรวจสอบทั้งสองกรณีจะพิมพ์ `true`. หมายเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; มันไม่ใช่ตัวอักษร `1`. การแปลงประเภทและดัชนีในการตรวจสอบอ้างอิงถึงรูปร่างและส่วนที่สร้างโดยตัวอย่างนี้.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/) ทำการ 구현 [IFieldType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifieldtype/) และมีเมธอดต่อไปนี้สำหรับรับค่าที่กำหนดไว้ล่วงหน้า. ส่งค่าที่เหมาะสมไปยัง [addField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).  

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | หมายเลขสไลด์ปัจจุบัน |
| [getDateTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | วันที่/เวลาในรูปแบบเริ่มต้นของแอปพลิเคชันที่ทำการเรนเดอร์ |
| [getDateTime1](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | รูปแบบวันที่หรือวันที่/เวลาแบบผสมที่กำหนดไว้ล่วงหน้า |
| [getDateTime10](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | รูปแบบเวลาแบบกำหนดไว้ล่วงหน้า, มีตัวเลือกสำหรับวินาทีและนาฬิกาแบบ 12‑ชั่วโมง |
| [getHeader](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getHeader--) | ฟิลด์ส่วนหัว; ดูข้อจำกัดของตัวแทนและรูปแบบด้านล่าง |
| [getFooter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getFooter--) | ฟิลด์ส่วนท้าย |

ตัวอย่างเช่น, [getDateTime3](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) แทนวัน, ชื่อเดือนเต็ม, และปีในภาษาอังกฤษ. สิ่งเหล่านี้เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า, ไม่ใช่สตริงรูปแบบวันที่ของ Java. ภาษาที่ตั้งค่าด้วย [setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) และแอปพลิเคชันที่ประมวลผลการนำเสนออาจมีผลต่อผลลัพธ์ที่แสดง.

## **Create a Field from an Internal String**

การโอเวอร์โหลดสตริงของ [addField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) ยอมรับตัวระบุฟิลด์ภายใน. ใช้เมื่อจำเป็นต้องเก็บตัวระบุที่มาจากแอปพลิเคชันอื่นที่ไม่มีค่าที่กำหนดไว้ล่วงหน้า. คุณยังสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) จากตัวระบุได้. [IFieldType.getInternalString](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) จะเปิดเผยตัวระบุนั้นเพื่อการตรวจสอบ.  

ตัวอย่างนี้จัดเก็บฟิลด์เฉพาะแอป `custom-report-id` พร้อมข้อความสำรอง `Report-042`. ตัวระบุจะไม่ทำการคำนวณ: Aspose.Slides ไม่ได้สร้างรหัสรายงานสำหรับประเภทที่ไม่รู้จัก. แอปที่เข้าใจตัวระบุนั้นต้องให้ความหมายและอัปเดตค่าของมัน.  

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

หลังจากการเดินทางแบบรอบ PPTX, ประเภทจะเป็น `custom-report-id` และข้อความจะเป็น `Report-042`. การส่งสตริงเช่น `yyyy-MM-dd` จะตั้งชื่อประเภทฟิลด์; มันจะไม่กำหนดรูปแบบวันที่แบบกำหนดเอง. หากต้องการวันที่คงที่ในรูปแบบใดรูปแบบหนึ่ง, ให้ใช้ข้อความปกติ.

## **Inspect, Modify, and Remove Date/Time Fields**

เปลี่ยนฟิลด์ที่มีอยู่ผ่าน [IField.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). ตรวจสอบว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน. เพื่อตัดการอัปเดตอัตโนมัติ, เรียก [IPortion.removeField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#removeField--). วิธีนี้จะเก็บส่วนและข้อความปัจจุบันไว้ขณะที่ลบการเชื่อมโยงฟิลด์. หากต้องการค่าคงที่เฉพาะ, กำหนดข้อความนั้นหลังจากลบฟิลด์.  

สำหรับการตั้งค่า API ที่เกี่ยวข้องกับการประมวลผลฟิลด์วันที่/เวลา, ดู [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). ตัวอย่างด้านล่างใช้วันที่อนุมัติอย่างชัดเจนเมื่อแปลงฟิลด์เป็นข้อความธรรมดา.  

ดาวน์โหลด [sample.pptx](sample.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน. ไฟล์นี้มีรูปร่างข้อความที่ตั้งชื่อสองอัน, `UpdatedAt` และ `ApprovedDate`, แต่ละอันมีฟิลด์วันที่/เวลา พร้อมป้ายกำกับข้อความปกติ. ตัวอย่างต่อไปนี้วนรอบรูปร่างข้อความระดับบนในสไลด์ปกติ. มันเปลี่ยนฟิลด์วันที่/เวลาเป็นรูปแบบวันที่แบบเต็มและทำให้เป็นตัวเอียง, ในขณะที่คงรูปแบบอื่นไว้. ฟิลด์ใน `ApprovedDate` เท่านั้นที่กลายเป็นข้อความคงที่.  

ตัวอย่างนี้รับรู้ตัวระบุภายในที่สร้างมาแล้ว `datetime` และ `datetime1` ถึง `datetime13`. กลุ่ม, ตาราง, โน้ต, เลย์เอาต์, และมาสเตอร์ต้อง traversed ผ่านคอนเทนเนอร์ข้อความของตนเองและอยู่นอกขอบเขตของตัวอย่างนี้.  

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

หลังจากเปิดใหม่, `UpdatedAt` มีประเภท `datetime3` และยังคงเป็นไดนามิก. `ApprovedDate` ไม่มีฟิลด์และมีข้อความ `05 April 2030`. ส่วนของวันที่ทั้งสองเป็นตัวเอียง, และขนาดฟอนต์, การตั้งค่าหนา, และสีเดิมยังคงอยู่. ป้ายกำกับข้อความธรรมดาไม่ได้เปลี่ยนแปลง. การตรวจสอบอ่านส่วนแรกของสองรูปร่างที่รู้จักในตัวอย่างที่ให้มา.

## **Preserve Text Formatting**

ทำงานกับส่วนที่มีอยู่เมื่อเพิ่มฟิลด์, เปลี่ยนประเภทของฟิลด์, หรือเอาฟิลด์ออก. การดำเนินการเหล่านี้จะคงรูปแบบของส่วนนั้น. ใช้ [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getPortionFormat--) เพื่อเปลี่ยนเฉพาะคุณสมบัติที่จำเป็น, เช่นตัวอย่างที่ทำสำหรับสีหรือการทำตัวเอียง.  

หลีกเลี่ยงการสร้างกรอบข้อความใหม่ทั้งหมดเพียงเพื่ออัปเดตฟิลด์เดียว: การกระทำเช่นนั้นอาจทำให้สูญเสียขอบเขตส่วนเดิมและรูปแบบแยกของแต่ละส่วน. แยกความแตกต่างระหว่างการจัดรูปแบบที่ตั้งค่าโดยตรงและการจัดรูปแบบที่สืบทอดจากย่อหน้า, เลย์เอาต์, หรือธีม. ดู [Text Formatting](/slides/th/androidjava/text-formatting/) สำหรับตัวเลือกการจัดรูปแบบที่กว้างขึ้น.

## **Fields and Header/Footer Placeholders**

ฟิลด์เป็นส่วนของข้อความ. ตัวแทน (placeholder) คือรูปร่างที่มีบทบาทการนำเสนอ, เช่นส่วนท้ายหรือหมายเลขสไลด์. การเพิ่มฟิลด์ลงในกล่องข้อความธรรมดาจะไม่ทำให้รูปร่างนั้นกลายเป็นตัวแทน.  

ตัวจัดการส่วนหัว/ส่วนท้ายควบคุมข้อความตัวแทนและการมองเห็นบนสไลด์, เลย์เอาต์, และมาสเตอร์, รวมถึงการกระจายไปยังสไลด์ที่อิง. ฟิลด์หมายเลขในกล่องข้อความที่กำหนดเองจึงอาจมีประโยชน์แม้คุณไม่ใช้ตัวแทนหมายเลขสไลด์. ในทางกลับกัน, การเปลี่ยนการมองเห็นของตัวแทนจะไม่ลบฟิลด์จากกล่องข้อความที่ไม่เกี่ยวข้อง.  

ประเภทส่วนหัวและส่วนท้ายที่กำหนดไว้ล่วงหน้าไม่ได้สร้างตัวแทนที่สอดคล้องหรือให้เนื้อหาของมัน. โดยเฉพาะ, สไลด์ PowerPoint ปกติไม่มีตัวแทนส่วนหัว; ส่วนหัวเป็นของหน้าบันทึกและเอกสารแจก. อย่าสันนิษฐานว่าฟิลด์ส่วนหัวหรือส่วนท้ายในรูปร่างใด ๆ จะได้รับข้อความที่ตั้งค่าผ่านตัวจัดการตัวแทนโดยอัตโนมัติ. สำหรับกระบวนการนั้น, ดู [Presentation Headers and Footers](/slides/th/androidjava/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่. การเก็บรักษาตัวระบุไม่ได้หมายความว่าแอปพลิเคชันจะคำนวณหรือแสดงค่าของมันได้.  

| Format | Field behavior and limitations |
|---|---|
| PPTX | เก็บตัวระบุฟิลด์ภายในพร้อมกับข้อความฟิลด์. ในการตรวจสอบรอบการบันทึก, ประเภทที่กำหนดไว้ล่วงหน้าและตัวระบุที่กำหนดเองที่ใช้ข้างต้นยังคงอยู่หลังการบันทึกและเปิดใหม่. ประเภทที่ไม่รู้จักยังคงข้อความสำรอง; ไม่ได้รับตรรกะคำนวณอัตโนมัติ. แอปพลิเคชันอื่นอาจจัดการกับตัวระบุที่ไม่ได้สนับสนุนแตกต่างกัน. |
| PPT | ใช้การแทนฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดมากขึ้น. ในการตรวจสอบรอบการบันทึก, ฟิลด์หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดล่วงหน้ายังคงอยู่หลังการบันทึกและเปิดใหม่. ฟิลด์ที่กำหนดเองในกล่องข้อความสไลด์ธรรมดาจะเปิดใหม่พร้อมตัวระบุแต่ข้อความเป็น `*`; ฟิลด์ส่วนหัวในบริบทเดียวกันก็ให้ผลเป็น `*`. อย่าอาศัยฟิลด์ที่กำหนดเองหรือบริบทฟิลด์ที่ไม่รองรับให้คงข้อความที่มองเห็นได้. |

สำหรับผลลัพธ์ที่พกพาและคงที่, แปลงฟิลด์ที่ไม่รองรับเป็นข้อความธรรมดาและกำหนดค่าที่ต้องการอย่างชัดเจนก่อนบันทึก. วิธีนี้จะคงข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติ. ทดสอบแอปเป้าหมายด้วยเช่นกันเมื่อการคำนวณฟิลด์ของมันเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**  
ตรวจสอบ [IPortion.getField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getField--). ค่าไม่เป็น `null` หมายถึงเป็นฟิลด์; ข้อความที่แสดงอย่างเดียวไม่สามารถบอกได้.

**Does removing a field remove its text or formatting?**  
ไม่. [removeField](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#removeField--) จะเปลี่ยนส่วนที่มีอยู่เป็นข้อความธรรมดา. หากต้องการค่าคงที่ให้กำหนดค่าตัวอักษรหลังจากลบฟิลด์.

**Can an internal string define a new date format or formula?**  
ไม่. มันระบุประเภทฟิลด์เท่านั้น. ตัวระบุที่ไม่รู้จักจะไม่ให้ตัวประเมินหรือรูปแบบวันที่ของ Java. ใช้ประเภทที่รองรับหรือจัดรูปแบบค่าด้วยตนเองเป็นข้อความธรรมดา.

**Why check a presentation again after saving it?**  
ตัวระบุฟิลด์, ข้อความที่คำนวณ, และการจัดรูปแบบเป็นสิ่งที่ต้องตรวจสอบแยกกัน. การแปลงรูปแบบอาจเปลี่ยนผลลัพธ์ที่มองเห็นได้แม้ตัวระบุฟิลด์ยังคงอยู่.