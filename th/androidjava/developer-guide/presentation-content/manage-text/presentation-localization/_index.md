---
title: อัตโนมัติการแปลภาษาในการนำเสนอบน Android
linktitle: การแปลภาษาในการนำเสนอ
type: docs
weight: 100
url: /th/androidjava/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจสอบการสะกด
- ปิดการตรวจสอบการสะกด
- ภาษาการตรวจสอบ
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "กำหนดภาษาการตรวจสอบสำหรับข้อความนำเสนอ PowerPoint และ OpenDocument บน Android ด้วย Aspose.Slides สำหรับ Android ผ่าน Java รวมถึงค่าเริ่มต้นและย่อหน้าหลายภาษา."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Android ผ่าน Java ให้คุณกำหนดเมตาดาต้าการตรวจสอบภาษาสำหรับส่วนข้อความแต่ละส่วน ใช้ [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) เพื่อระบุภาษาการตรวจสอบ, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) เพื่อเปิดหรือปิดการตรวจสอบการสะกด, และ [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) เพื่อควบคุมสถานะไม่ตรวจสอบแบบกว้างขึ้น เนื่องจากการตั้งค่าเหล่านี้ทำงานที่ระดับส่วน จึงทำให้ย่อหน้าหนึ่งสามารถมีหลายภาษาและกฎการตรวจสอบที่แตกต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาให้กับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), สร้างย่อหน้าหลายภาษา, เลือกระหว่าง `SpellCheck` และ `ProofDisabled`, และรักษาการตั้งค่าเดิมเมื่อใช้ [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) คุณสมบัติเหล่านี้จัดเก็บเมตาดาต้าสำหรับแอปพลิเคชันนำเสนอ; พวกมันไม่ได้แปลข้อความ, ไม่ทำการตรวจสอบการสะกดด้วยพจนานุกรม, หรือคืนรายการคำที่สะกดผิด

## **ตั้งค่าภาษาการตรวจสอบสำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getPortionFormat-- ) และกำหนดตัวระบุภาษา ตัวอย่างต่อไปนี้สร้างรูปทรง, ตั้งค่าอังกฤษแบบบริติชเป็นภาษาการตรวจสอบ, และบันทึกผลลัพธ์ด้วย [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อระบุภาษาการตรวจสอบที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในงานนำเสนอใช้ภาษาเดียวกัน มันไม่เปลี่ยนเมตาดาต้าภาษาของข้อความที่มีการกำหนดภาษาเป็นไว้แล้ว

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่ข้อความใหม่ใช้กฎการตรวจสอบภาษาเยอรมัน:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้หลายภาษาในย่อหน้าหนึ่ง**

[IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) มีคอลเลคชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) แยกสำหรับแต่ละภาษาและตั้งค่า `LanguageId` อย่างอิสระ

ตัวอย่างนี้สร้างย่อหน้าหนึ่งที่มีส่วนภาษาอังกฤษและฝรั่งเศส:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เปิดหรือปิดการตรวจสอบการสะกดสำหรับส่วนแต่ละส่วน**

[IPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/) สืบทอดคุณสมบัติข้อความทั่วไปที่กำหนดโดย [IBasePortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/). เข้าถึงรูปแบบของส่วนผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getPortionFormat--) และใช้ [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) เพื่อควบคุมว่าตัวแอปพลิเคชันนำเสนอจะทำการตรวจสอบการสะกดสำหรับส่วนนั้นหรือไม่ ค่าเริ่มต้นคือ `false`: `true` เปิดการตรวจสอบการสะกด, ส่วน `false` ปิดการตรวจสอบ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ในย่อหน้าเดียวกันจึงสามารถใช้ค่าต่างกันได้ [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) และ `setSpellCheck` มีหน้าที่เสริมกัน: `setLanguageId` ระบุภาษาการตรวจสอบ, ส่วน `setSpellCheck` กำหนดว่าการตรวจสอบการสะกดจะถูกอนุญาตหรือไม่สำหรับส่วนนั้น

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) ก็ควบคุมการตรวจสอบเช่นกัน แต่เป็นการแสดงสถานะ "ไม่ตรวจสอบ" อย่างกว้างโดยใช้ [NullableBool](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/nullablebool/). ใช้ `setSpellCheck` เมื่อคุณต้องการสวิตช์ Boolean ตรงสำหรับการตรวจสอบการสะกด ใช้ `setProofDisabled` เมื่อคุณต้องการเก็บหรือควบคุมเมตาดาต้า "ไม่ตรวจสอบ" ของงานนำเสนออย่างชัดเจน รวมถึงสถานะ `NotDefined` หากคุณตั้งค่าทั้งสองคุณสมบัติ กรุณาทำให้ค่าตรงกัน; อย่าผสม `setSpellCheck(true)` กับ `setProofDisabled(NullableBool.True)`.

คุณสมบัติเหล่านี้กำหนดเมตาดาต้าการตรวจสอบที่ใช้โดย PowerPoint และแอปพลิเคชันนำเสนออื่น ๆ Aspose.Slides ไม่ได้ใช้เพื่อรันการตรวจสอบการสะกดแบบอิงพจนานุกรมหรือคืนรายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างงานนำเข้าการนำเสนอ, โหลดมัน, กำหนดการตั้งค่าการตรวจสอบการสะกดและภาษาการตรวจสอบที่ต่างกันให้กับสองส่วนในย่อหน้าหนึ่ง, บันทึกผลลัพธ์, เปิดใหม่อีกครั้ง, และตรวจสอบค่าที่เก็บไว้:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) รวมส่วนที่ต่อเนื่องกันที่มีรูปแบบเดียวกัน ความแตกต่างเพียงอย่างเดียวใน `SpellCheck` ไม่ทำให้ส่วนเหล่านั้นแยกจากกัน; หลังจากถูกรวม ส่วนที่ได้จะคงค่าของ `SpellCheck` ของส่วนแรก หากส่วนต้องการการตั้งค่าการตรวจสอบการสะกดที่ต่างกัน ให้เรียก `joinPortionsWithSameFormatting` ก่อนกำหนดค่าดังกล่าว, หรือสังเกตขอบเขตของส่วนที่ได้และกำหนดค่าซ้ำหลังจากนั้น ส่วนที่มีค่า `LanguageId` ต่างกันจะยังคงแยกกันอยู่เนื่องจากรูปแบบภาษาการตรวจสอบแตกต่างกัน

## **FAQ**

**รหัสภาษาแปลข้อความหรือไม่?**

ไม่. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) เก็บเมตาดาต้าการตรวจสอบการสะกดและไวยากรณ์; ไม่เปลี่ยนเนื้อหาข้อความ. แปลข้อความแยกจากกัน, แล้วตั้งค่าตัวระบุภาษาที่เหมาะสมสำหรับแต่ละส่วนที่แปลแล้ว.

**ภาษาการตรวจสอบควบคุมแบบอักษร, การเว้นย่อหน้า, หรือการตัดบรรทัดหรือไม่?**

ไม่. ตัวระบุภาษาใช้สำหรับการตรวจสอบเท่านั้น การเรนเดอร์และการจัดวางข้อความขึ้นอยู่กับ [fonts](/slides/th/androidjava/powerpoint-fonts/), ระบบการเขียน, และการตั้งค่าเฟรมข้อความ. เพื่อให้การเรนเดอร์เชื่อถือได้ ให้จัดเตรียมแบบอักษรที่จำเป็น, กำหนดการแทนที่แบบอักษร [font substitution](/slides/th/androidjava/font-substitution/), หรือ [embed fonts](/slides/th/androidjava/embedded-font/) ในงานนำเสนอ.

**ย่อหน้าเดียวสามารถใช้หลายภาษาการตรวจสอบได้หรือไม่?**

ได้. กำหนดแต่ละภาษาให้กับส่วนแยกต่างหากตามที่แสดงในตัวอย่างย่อหน้าหลายภาษา.

**ควรใช้ `setDefaultTextLanguage` หรือ `setLanguageId`?**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เมื่อต้องการค่าเริ่มต้นสำหรับข้อความที่สร้างใหม่. ใช้ [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) เมื่อส่วนข้อความใดส่วนหนึ่งต้องการภาษาการตรวจสอบโดยเฉพาะหรือเมื่อย่อหน้ามีหลายภาษา.