---
title: อัตโนมัติการแปลโลคัลไลเซชันของงานนำเสนอใน JavaScript
linktitle: การแปลโลคัลไลเซชันของงานนำเสนอ
type: docs
weight: 100
url: /th/nodejs-java/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจการสะกด
- ปิดการตรวจการสะกด
- ภาษาการพิสูจน์
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "กำหนดภาษาการพิสูจน์สำหรับข้อความงานนำเสนอ PowerPoint และ OpenDocument ใน JavaScript ด้วย Aspose.Slides รวมถึงค่าเริ่มต้นและย่อหน้าหลายภาษา"
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java ให้คุณกำหนดเมตาดาต้าการพิสูจน์สำหรับส่วนข้อความแต่ละส่วน ใช้ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) เพื่อระบุภาษาการพิสูจน์, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) เพื่อเปิดหรือปิดการตรวจสอบการสะกด, และ [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) เพื่อควบคุมสถานะ “ไม่พิสูจน์” ในระดับกว้าง เพราะการตั้งค่าเหล่านี้ถูกนำไปใช้ระดับส่วน ดังนั้นย่อหน้าหนึ่งสามารถมีหลายภาษาและกฎการพิสูจน์ที่แตกต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาให้กับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), สร้างย่อหน้าหลายภาษ, เลือกใช้ระหว่าง `SpellCheck` และ `ProofDisabled`, และรักษาการตั้งค่าเดิมเมื่อต้องใช้ [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) คุณสมบัติเหล่านี้เก็บเมตาดาต้าสำหรับแอปพลิเคชันพรีเซนเทชัน; พวกมันไม่ได้แปลข้อความ, ไม่ทำการตรวจสอบการสะกดแบบพจนานุกรม, หรือคืนคำที่สะกดผิด

## **ตั้งค่าภาษาการพิสูจน์สำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getPortionFormat--), และกำหนดตัวระบุภาษา ตัวอย่างต่อไปนี้สร้างรูปทรง, ตั้งค่าภาษาอังกฤษแบบอังกฤษ (British English) เป็นภาษาการพิสูจน์, และบันทึกผลลัพธ์ด้วย [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อระบุภาษาการพิสูจน์ที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในพรีเซนเทชันใช้ภาษาเดียวกัน มันจะไม่เปลี่ยนเมตาดาต้าภาษาของข้อความที่มีการระบุภาษาชัดเจนอยู่แล้ว

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ข้อความใหม่ใช้กฎการพิสูจน์ภาษาเยอรมัน:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้หลายภาษาในย่อหน้าหนึ่ง**

[Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) แยกกันสำหรับแต่ละภาษาและตั้งค่า `LanguageId` ของแต่ละส่วนโดยอิสระ

ตัวอย่างนี้สร้างย่อหน้าหนึ่งที่มีส่วนข้อความภาษาอังกฤษและฝรั่งเศส:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เปิดหรือปิดการตรวจสอบการสะกดสำหรับส่วนข้อความแต่ละส่วน**

[PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/) สืบทอดคุณสมบัติข้อความทั่วไปที่กำหนดโดย [BasePortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/) เข้าถึงรูปแบบของส่วนผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getPortionFormat--) และใช้ [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) เพื่อควบคุมว่าพรีเซนเทชันแอปพลิเคชันอาจตรวจสอบการสะกดสำหรับส่วนนั้นหรือไม่ ค่าเริ่มต้นคือ `false`: `true` เปิดการตรวจสอบการสะกด, ส่วน `false` ปิดการตรวจสอบ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ในย่อหน้าเดียวกันจึงสามารถใช้ค่าที่แตกต่างกันได้ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) และ `setSpellCheck` มีจุดประสงค์ร่วมกัน: `setLanguageId` ระบุภาษาการพิสูจน์, ส่วน `setSpellCheck` กำหนดว่าการตรวจสอบการสะกดจะถูกอนุญาตหรือไม่สำหรับส่วนนั้น

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) ยังควบคุมการพิสูจน์ด้วย, แต่เป็นสถานะ “ไม่พิสูจน์” ที่กว้างกว่าในรูปแบบ [NullableBool](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/nullablebool/) ใช้ `setSpellCheck` เมื่อคุณต้องการสวิตช์แบบ Boolean ตรง ๆ สำหรับการตรวจสอบการสะกด ใช้ `setProofDisabled` เมื่อคุณต้องการรักษาหรือควบคุมเมตาดาต้า “ไม่พิสูจน์” ของพรีเซนเทชันรวมถึงสถานะ `NotDefined` หากคุณตั้งค่าทั้งสองคุณสมบัติควรรักษาค่าให้สอดคล้องกัน; อย่าผสาน `setSpellCheck(true)` กับ `setProofDisabled(NullableBool.True)`

คุณสมบัติเหล่านี้กำหนดเมตาดาต้าการพิสูจน์ที่ใช้โดย PowerPoint และแอปพลิเคชันพรีเซนเทชันอื่น ๆ Aspose.Slides ไม่ได้ใช้เพื่อรันการตรวจสอบการสะกดแบบพจนานุกรมหรือคืนรายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างพรีเซนเทชันต้นฉบับ, โหลดมัน, กำหนดการตั้งค่าการตรวจสอบการสะกดและภาษาการพิสูจน์ที่แตกต่างให้กับสองส่วนในย่อหน้าเดียวกัน, บันทึกผล, เปิดใหม่อีกครั้ง, และตรวจสอบค่าที่เก็บไว้:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) จะรวมส่วนที่ต่อเนื่องที่มีรูปแบบเดียวกัน ความแตกต่างเพียง `SpellCheck` อย่างเดียวจะไม่ทำให้ส่วนแยกกันอยู่; หลังจากรวมแล้วส่วนผลลัพธ์จะคงค่า `SpellCheck` ของส่วนแรก หากต้องการให้ส่วนต่าง ๆ มีการตั้งค่าการตรวจสอบการสะกดที่ต่างกัน ให้เรียก `joinPortionsWithSameFormatting` ก่อนกำหนดค่าดังกล่าว, หรือสอบถามขอบเขตของส่วนที่ได้และตั้งค่าใหม่อีกครั้งหลังจากนั้น ส่วนที่มีค่า `LanguageId` แตกต่างกันจะยังคงแยกกันอยู่เนื่องจากรูปแบบภาษาการพิสูจน์ต่างกัน

## **คำถามที่พบบ่อย**

**การระบุ Language ID จะทำให้ข้อความแปลหรือไม่?**

ไม่. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) จะเก็บเมตาดาต้าการพิสูจน์สำหรับการสะกดและไวยากรณ์; มันไม่ได้เปลี่ยนเนื้อหาข้อความ. ให้แปลข้อความแยกจากกัน, แล้วตั้งตัวระบุภาษาให้เหมาะสมกับแต่ละส่วนที่แปลแล้ว

**ภาษาการพิสูจน์ควบคุมฟอนต์, การเว้นบรรทัด, หรือการตัดคำหรือไม่?**

ไม่. ตัวระบุภาษามีไว้สำหรับการพิสูจน์เท่านั้น. การเรนเดอร์และการจัดวางข้อความขึ้นอยู่กับ [fonts](/slides/th/nodejs-java/powerpoint-fonts/), ระบบการเขียน, และการตั้งค่าเฟรมข้อความ. เพื่อให้การแสดงผลเชื่อถือได้, ให้จัดหาไฟล์ฟอนต์ที่ต้องการ, ตั้งค่า [font substitution](/slides/th/nodejs-java/font-substitution/), หรือ [embed fonts](/slides/th/nodejs-java/embedded-font/) ในพรีเซนเทชัน

**ย่อหน้าหนึ่งสามารถใช้หลายภาษาการพิสูจน์ได้หรือไม่?**

ได้. ให้กำหนดแต่ละภาษาให้กับส่วนแยกต่างหาก ตามที่แสดงในตัวอย่างย่อหน้าหลายภาษา

**ควรใช้ `setDefaultTextLanguage` หรือ `setLanguageId`?**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เมื่อคุณต้องการตั้งค่าภาษาเริ่มต้นสำหรับข้อความที่สร้างใหม่. ใช้ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) เมื่อส่วนใดส่วนหนึ่งต้องการภาษาการพิสูจน์เฉพาะหรือเมื่อย่อหน้ามีหลายภาษา