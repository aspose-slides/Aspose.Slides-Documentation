---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย JavaScript
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/nodejs-java/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันที่และเวลา
- ส่วนหัว
- ส่วนท้าย
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, แก้ไข, และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. รักษาการจัดรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ส่วน [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) ปกติจะมีข้อความตามตัวอักษร; ส่วนฟิลด์ยังมี [Field](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/field/) ซึ่งประเภทของมันบ่งชี้ค่าที่อัปเดตโดยอัตโนมัติ เช่นหมายเลขสไลด์หรือวันที่ ส่วนสองส่วนอาจแสดงอักขระเดียวกันในขณะที่เพียงส่วนเดียวมีฟิลด์

ใช้ [Portion.getField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getField) เพื่อแยกแยะ: ค่านั้นจะเป็น `null` สำหรับข้อความปกติ [Portion.addField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#addField) จะเปลี่ยนส่วนที่มีอยู่ให้เป็นฟิลด์ เก็บป้ายกำกับและค่าที่เปลี่ยนแปลงได้ในส่วนแยกต่างหากเพื่อให้การแปลงค่าไม่ได้แทนที่ป้ายกำกับ

คำแนะนำนี้ครอบคลุมฟิลด์ภายในข้อความ, การจัดรูปแบบของมัน, และการบันทึกเป็น PPTX และ PPT สำหรับกรอบข้อความและย่อหน้า ดูที่ [Manage Text](/slides/th/nodejs-java/manage-text/)

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างเต็มต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับอักษร `Slide ` ตามด้วยหมายเลขที่อัปเดตโดยอัตโนมัติ ตั้งขนาด, ความหนา, และสีของหมายเลขก่อนเพิ่มฟิลด์ แล้วเปิดการนำเสนอที่บันทึกใหม่และตรวจสอบประเภทฟิลด์, ข้อความ, และการจัดรูปแบบ ไม่จำเป็นต้องมีไฟล์อินพุต

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

การนำเสนอใหม่เริ่มที่หมายเลขสไลด์ 1 ดังนั้นข้อความจะเป็น `Slide 1` และการตรวจสอบทั้งสองจะแสดงผล `true` หมายเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; ไม่ได้เป็นอักษร `1` ดัชนีในกระบวนการตรวจสอบอ้างอิงถึงรูปร่างและส่วนที่สร้างโดยตัวอย่างนี้

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/) มีเมธอดต่อไปนี้สำหรับรับค่าที่กำหนดไว้ล่วงหน้า ส่งค่าที่เหมาะสมไปยัง [addField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#addField)

| วิธีการ | วัตถุประสงค์ |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | หมายเลขสไลด์ปัจจุบัน |
| [getDateTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getDateTime) | วันที่/เวลาในรูปแบบค่าเริ่มต้นของแอปพลิเคชันที่ทำการเรนเดอร์ |
| [getDateTime1](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | รูปแบบวันที่หรือวันที่/เวลาที่กำหนดไว้ล่วงหน้า |
| [getDateTime10](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | รูปแบบเวลาแบบกำหนดไว้ล่วงหน้า, มีตัวเลือกสำหรับวินาทีและนาฬิกา 12 ชั่วโมง |
| [getHeader](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getHeader) | ฟิลด์ส่วนหัว; ดูข้อจำกัดของ placeholder และรูปแบบด้านล่าง |
| [getFooter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getFooter) | ฟิลด์ส่วนท้าย |

ตัวอย่างเช่น [getDateTime3](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getDateTime3) แสดงวัน, ชื่อเดือนเต็ม, และปีเป็นภาษาอังกฤษ นี่เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า ไม่ใช่สตริงรูปแบบวันที่แบบอิสระ ภาษาที่ตั้งด้วย [setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) และแอปพลิเคชันที่ประมวลผลการนำเสนออาจมีผลต่อผลลัพธ์ที่แสดง

## **สร้างฟิลด์จากสตริงภายใน**

อิมพอร์ทของ [addField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#addField) ที่รับสตริงภายในรองรับตัวระบุฟิลด์ภายใน ใช้เมื่อคุณต้องการเก็บตัวระบุที่มาจากแอปพลิเคชันอื่นซึ่งไม่มีค่าที่กำหนดไว้ล่วงหน้า คุณยังสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/) จากตัวระบุได้ [FieldType.getInternalString](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fieldtype/#getInternalString) จะเปิดเผยตัวระบุนั้นสำหรับการตรวจสอบ

ตัวอย่างนี้เก็บฟิลด์ `custom-report-id` เฉพาะแอปพลิเคชันพร้อมข้อความสำรอง `Report-042` ตัวระบูปไม่ได้ลงทะเบียนการคำนวณ: Aspose.Slides ไม่สร้าง ID รายงานสำหรับประเภทที่ไม่รู้จัก แอปพลิเคชันที่เข้าใจตัวระบูปต้องกำหนดความหมายและอัปเดตค่าเอง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

หลังจากการรอบกลับ PPTX, ประเภทจะเป็น `custom-report-id` และข้อความจะเป็น `Report-042` การส่งสตริงเช่น `yyyy-MM-dd` จะตั้งชื่อประเภทฟิลด์; มันจะไม่กำหนดรูปแบบวันที่ที่กำหนดเอง สำหรับวันที่คงที่ในรูปแบบอิสระให้ใช้ข้อความปกติ

## **ตรวจสอบ, แก้ไข, และลบฟิลด์วันที่/เวลา**

เปลี่ยนฟิลด์ที่มีอยู่ผ่าน [Field.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/field/#setType) ตรวจสอบให้แน่ใจว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน เพื่อหยุดการอัปเดตอัตโนมัติให้เรียก [Portion.removeField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#removeField) จะทำให้ส่วนคงอยู่พร้อมข้อความปัจจุบันขณะลบการเชื่อมโยงฟิลด์ หากต้องการค่าคงที่เฉพาะให้กำหนดข้อความหลังจากลบฟิลด์

สำหรับการตั้งค่า API ที่เกี่ยวกับการประมวลผลฟิลด์วันที่/เวลา ดูที่ [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#setCurrentDateTime) ตัวอย่างด้านล่างใช้วันที่อนุมัติที่ระบุเมื่อแปลงฟิลด์เป็นข้อความปกติ

ดาวน์โหลด [sample.pptx](sample.pptx) แล้ววางในไดเรกทอรีทำงาน ไฟล์นี้มีรูปข้อความที่ตั้งชื่อสองรูป `UpdatedAt` และ `ApprovedDate` ซึ่งแต่ละอันมีฟิลด์วันที่/เวลา พร้อมป้ายกำกับข้อความปกติ ตัวอย่างต่อไปนี้เดินทางผ่านรูปข้อความระดับบนสุดบนสไลด์ปกติ เปลี่ยนฟิลด์วันที่/เวลาเป็นรูปแบบวันที่ยาวและทำให้เป็นตัวเอียง พร้อมรักษาการจัดรูปแบบอื่นไว้ โดยฟิลด์ใน `ApprovedDate` จะแปลงเป็นข้อความคงที่

วันที่อนุมัติคือ 5 เมษายน 2030; ดัชนีเดือนใน JavaScript เริ่มจากศูนย์, ดังนั้นเดือนเมษายนคือ `3` ใช้ UTC ทั้งในการสร้างและการจัดรูปแบบเพื่อให้วันที่ไม่ขึ้นกับโซนเวลาในเครื่อง

ตัวอย่างจะจดจำตัวระบุภายในที่สร้างไว้ `datetime` และ `datetime1` ถึง `datetime13` กลุ่ม, ตาราง, โน๊ต, การจัดวาง, และแม่แบบต้องทำการเดินทางผ่านคอนเทนเนอร์ข้อความของตนเองและอยู่นอกขอบเขตของตัวอย่างนี้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

หลังจากเปิดใหม่ `UpdatedAt` มีประเภท `datetime3` และยังคงเป็นค่าไดนามิก `ApprovedDate` ไม่มีฟิลด์และมีข้อความ `05 April 2030` ส่วนวันที่ทั้งสองเป็นตัวเอียง และขนาดฟอนต์, การตั้งค่าหนา, สีเดิมยังคงอยู่ ป้ายกำกับข้อความปกติไม่ได้เปลี่ยน การตรวจสอบจะอ่านส่วนแรกของสองรูปที่รู้จักในตัวอย่างที่ให้มา

## **รักษาการจัดรูปแบบข้อความ**

ทำงานกับส่วนที่มีอยู่เมื่อเพิ่มฟิลด์, เปลี่ยนประเภท, หรือถอนฟิลด์ การดำเนินการเหล่านี้จะคงการจัดรูปแบบของส่วนนั้นไว้ ใช้ [Portion.getPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getPortionFormat) เพื่อเปลี่ยนเฉพาะคุณสมบัติที่ต้องการ ตามตัวอย่างที่ทำสำหรับสีหรือการทำเอียง

หลีกเลี่ยงการสร้างกรอบข้อความใหม่ทั้งหมดเพียงเพื่ออัปเดตฟิลด์เดียว: การทำเช่นนั้นอาจทำให้สูญเสียขอบเขตของส่วนเดิมและการจัดรูปแบบของแต่ละส่วน แยกความแตกต่างระหว่างการจัดรูปแบบที่ตั้งค่าอย่างชัดเจนกับการจัดรูปแบบที่สืบทอดจากย่อหน้า, การจัดวาง, หรือธีม ดูที่ [Text Formatting](/slides/th/nodejs-java/text-formatting/) สำหรับตัวเลือกการจัดรูปแบบที่กว้างขวางขึ้น

## **ฟิลด์และ Placeholder ส่วนหัว/ส่วนท้าย**

ฟิลด์เป็นส่วนหนึ่งของส่วนข้อความ Placeholder คือรูปร่างที่มีบทบาทในงานนำเสนอ เช่นส่วนท้ายหรือหมายเลขสไลด์ การเพิ่มฟิลด์ลงในกล่องข้อความปกติไม่ได้ทำให้รูปร่างนั้นกลายเป็น placeholder

ผู้จัดการส่วนหัว/ส่วนท้ายควบคุมข้อความ placeholder และการมองเห็นบนสไลด์, การจัดวาง, และแม่แบบ รวมถึงการแพร่กระจายไปยังสไลด์ที่ขึ้นอยู่ ฟิลด์ตัวเลขในกล่องข้อความที่กำหนดเองจึงอาจเป็นประโยชน์แม้คุณจะไม่ใช้ placeholder หมายเลขสไลด์ ในทางกลับกัน การเปลี่ยนการมองเห็นของ placeholder ไม่ได้ลบฟิลด์ออกจากกล่องข้อความที่ไม่เกี่ยวข้อง

ประเภทส่วนหัวและส่วนท้ายที่กำหนดไว้ล่วงหน้าไม่ได้สร้าง placeholder ที่สอดคล้องหรือให้เนื้อหาในนั้น โดยเฉพาะ สไลด์ PowerPoint ปกติไม่มี placeholder ส่วนหัว; ส่วนหัวอยู่ในหน้าบันทึกและเอกสารแจกจ่าย อย่าสันนิษฐานว่าฟิลด์ส่วนหัวหรือส่วนท้ายในรูปร่างใด ๆ จะได้รับข้อความที่กำหนดผ่านผู้จัดการ placeholder โดยอัตโนมัติ สำหรับกระบวนการนั้น ดูที่ [Presentation Headers and Footers](/slides/th/nodejs-java/presentation-header-and-footer/)

## **ข้อจำกัดของ PPTX และ PPT**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่ การรักษาตัวระบุไม่ได้พิสูจน์ว่าแอปพลิเคชันสามารถคำนวณหรือแสดงค่าของมันได้

| รูปแบบ | พฤติกรรมฟิลด์และข้อจำกัด |
|---|---|
| PPTX | เก็บตัวระบุฟิลด์ภายในพร้อมกับข้อความฟิลด์ ในการตรวจสอบรอบกลับ ประเภทที่กำหนดไว้ล่วงหน้าและตัวระบุกำหนดเองที่ใช้ด้านบนยังคงอยู่หลังการบันทึกและเปิดใหม่ ตัวระบุแบบกำหนดเองที่ไม่รู้จักยังคงข้อความสำรอง; ไม่ได้รับตรรกะการคำนวณอัตโนมัติ แอปพลิเคชันอื่นอาจจัดการตัวระบุที่ไม่สนับสนุนแตกต่างกัน |
| PPT | ใช้การแสดงฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดกว่า ในการตรวจสอบรอบกลับ ฟิลด์หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดไว้ล่วงหน้ายังคงอยู่หลังบันทึกและเปิดใหม่ ฟิลด์กำหนดเองในกล่องข้อความสไลด์ปกติเปิดใหม่ด้วยตัวระบุแต่ข้อความเป็น `*`; ฟิลด์ส่วนหัวในบริบทเดียวกันก็ให้ผลเป็น `*` อย่าเชื่อฟิลด์กำหนดเองหรือบริบทฟิลด์ที่ไม่รองรับจะคงข้อความที่มองเห็นได้ |

สำหรับผลลัพธ์ที่พกพาและคงที่ ให้แปลงฟิลด์ที่ไม่รองรับเป็นข้อความปกติและกำหนดค่าที่ต้องการอย่างชัดเจนก่อนบันทึก วิธีนี้จะคงข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติ ตรวจสอบแอปพลิเคชันเป้าหมายด้วยเมื่อการคำนวณฟิลด์ของมันเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าตัวเลขหรือวันที่ที่แสดงเป็นฟิลด์หรือไม่?**

ตรวจสอบ [Portion.getField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getField) ค่าไม่เป็น `null` หมายถึงเป็นฟิลด์; ข้อความที่แสดงเพียงอย่างเดียวไม่สามารถบอกได้

**การลบฟิลด์จะลบข้อความหรือการจัดรูปแบบหรือไม่?**

ไม่ [removeField](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#removeField) จะเปลี่ยนส่วนที่มีอยู่เป็นข้อความปกติ กำหนดค่าที่ต้องการหลังจากนั้นหากต้องการวันที่คงที่หรือข้อความสำรอง

**สตริงภายในสามารถกำหนดรูปแบบวันที่หรือสูตรใหม่ได้หรือไม่?**

ไม่ได้ มันระบุประเภทฟิลด์ ตัวระบุที่ไม่รู้จักไม่ได้ให้ตัวประเมินหรือรูปแบบวันที่ ใช้ประเภทที่สนับสนุนหรือจัดรูปแบบค่าเองเป็นข้อความปกติ

**ทำไมต้องตรวจสอบงานนำเสนออีกครั้งหลังจากบันทึก?**

ตัวระบุฟิลด์, ข้อความที่คำนวณ, และการจัดรูปแบบเป็นสิ่งที่ต้องตรวจสอบแยกกัน การแปลงรูปแบบอาจเปลี่ยนผลลัพธ์ที่มองเห็นได้แม้ว่าตัวระบุฟิลด์จะยังคงอยู่ก็ตาม