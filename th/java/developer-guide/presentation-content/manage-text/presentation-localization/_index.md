---
title: ทำให้การแปลภาษาในการนำเสนอเป็นอัตโนมัติใน Java
linktitle: การแปลภาษาการนำเสนอ
type: docs
weight: 100
url: /th/java/presentation-localization/
keywords:
- เปลี่ยนภาษา
- การตรวจสอบการสะกด
- การปิดการตรวจสอบการสะกด
- ภาษาการพิสูจน์
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตั้งค่าภาษาการพิสูจน์สำหรับข้อความนำเสนอ PowerPoint และ OpenDocument ใน Java ด้วย Aspose.Slides รวมถึงค่าเริ่มต้นและย่อหน้าหลายภาษา."
---
## **ภาพรวม**

Aspose.Slides for Java ให้คุณกำหนดเมตาดาต้าการพิสูจน์อักษรสำหรับส่วนข้อความแต่ละส่วน ใช้ [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) เพื่อระบุภาษาการพิสูจน์, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) เพื่อเปิดหรือปิดการตรวจสอบการสะกด, และ [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) เพื่อควบคุมสถานะ “ไม่พิสูจน์” ที่กว้างขึ้น เนื่องจากการตั้งค่าเหล่านี้ทำงานระดับส่วน จึงสามารถมีย่อหน้าหนึ่งที่ประกอบด้วยหลายภาษาและกฎการพิสูจน์ที่แตกต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาให้กับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), สร้างย่อหน้าหลายภาษา, เลือกใช้งานระหว่าง `SpellCheck` และ `ProofDisabled`, และรักษาการตั้งค่าเดิมเมื่อใช้ [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) คุณสมบัติเหล่านี้เก็บเมตาดาต้าสำหรับแอปพลิเคชันพรีเซนเทชัน; พวกมันไม่ได้แปลข้อความ, ไม่ทำการตรวจสอบการสะกดโดยพจนานุกรม, หรือคืนรายการคำที่สะกดผิด

## **กำหนดภาษาการพิสูจน์อักษรสำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getPortionFormat--), แล้วกำหนดรหัสภาษา ตัวอย่างต่อไปนี้สร้างรูปทรง, ตั้งค่าอังกฤษแบบบริติชเป็นภาษาการพิสูจน์, และบันทึกผลลัพธ์ด้วย [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อระบุภาษาการพิสูจน์ที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างขึ้นใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในพรีเซนเทชันใช้ภาษาเดียวกัน มันจะไม่เปลี่ยนเมตาดาต้าภาษาของข้อความที่มีการกำหนดภาษาไว้แล้วก่อนหน้า

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ข้อความใหม่ใช้กฎการพิสูจน์ของภาษาเยอรมัน:

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

[IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) แยกต่างหากสำหรับแต่ละภาษาและกำหนด `LanguageId` ของแต่ละส่วนโดยอิสระ

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

## **เปิดหรือปิดการตรวจสอบการสะกดสำหรับส่วนย่อยแต่ละส่วน**

[IPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/) สืบทอดคุณสมบัติตำแหน่งข้อความทั่วไปที่กำหนดโดย [IBasePortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/). เข้าถึงรูปแบบของส่วนผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getPortionFormat--) และใช้ [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) เพื่อควบคุมว่ามีการตรวจสอบการสะกดสำหรับส่วนนั้นหรือไม่ ค่าเริ่มต้นคือ `false`: `true` เปิดการตรวจสอบ, ในขณะที่ `false` ปิดการตรวจสอบ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ย่อหน้าที่มีส่วนต่าง ๆ สามารถใช้ค่าที่แตกต่างกันได้ [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) และ `setSpellCheck` มีวัตถุประสงค์เสริมกัน: `setLanguageId` ระบุภาษาการพิสูจน์, ส่วน `setSpellCheck` กำหนดว่าการตรวจสอบการสะกดจะเปิดหรือไม่

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) ยังควบคุมการพิสูจน์ด้วย, แต่เป็นตัวแทนของสถานะ “ไม่พิสูจน์” ที่กว้างกว่าในรูปของ [NullableBool](https://reference.aspose.com/slides/th/java/com.aspose.slides/nullablebool/). ใช้ `setSpellCheck` หากต้องการสวิตช์ Boolean ตรง ๆ สำหรับการตรวจสอบการสะกด ใช้ `setProofDisabled` หากต้องการเก็บหรือควบคุมเมตาดาต้า “ไม่พิสูจน์” ของพรีเซนเทชันอย่างชัดเจน รวมถึงสถานะ `NotDefined` หากกำหนดทั้งสองคุณสมบัติ ควรให้ค่าตรงกัน; อย่าผสม `setSpellCheck(true)` กับ `setProofDisabled(NullableBool.True)`

คุณสมบัติเหล่านี้กำหนดเมตาดาต้าการพิสูจน์ที่ใช้โดย PowerPoint และแอปพลิเคชันพรีเซนเทชันอื่น ๆ Aspose.Slides ไม่ได้ใช้เพื่อรันการตรวจสอบการสะกดแบบพจนานุกรมหรือคืนรายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างพรีเซนเทชันต้นฉบับ, โหลดมัน, กำหนดค่าการตรวจสอบการสะกดและภาษาการพิสูจน์ที่แตกต่างให้กับสองส่วนในย่อหน้าหนึ่ง, บันทึกผลลัพธ์, เปิดใหม่อีกครั้ง, และตรวจสอบค่าที่เก็บไว้:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) รวมส่วนที่ต่อกันที่มีรูปแบบเดียวกัน ความแตกต่างเพียงอย่างเดียวใน `SpellCheck` ไม่ทำให้ส่วนแยกกันอยู่; หลังจากรวมแล้ว ส่วนที่ได้จะคงค่า `SpellCheck` ของส่วนแรก หากส่วนต้องการการตั้งค่าการตรวจสอบที่ต่างกัน ให้เรียก `joinPortionsWithSameFormatting` ก่อนกำหนดค่าดังกล่าว, หรือสแกนขอบเขตของส่วนที่ได้และกำหนดค่าใหม่อีกครั้ง ส่วนที่มีค่า `LanguageId` แตกต่างกันจะยังคงแยกกันอยู่เนื่องจากรูปแบบภาษาการพิสูจน์แตกต่างกัน

## **คำถามที่พบบ่อย**

**ID ภาษาจะทำการแปลข้อความหรือไม่?**

ไม่. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) เก็บเมตาดาต้าการพิสูจน์สำหรับการสะกดและไวยากรณ์; ไม่ได้เปลี่ยนแปลงเนื้อหาข้อความ. ให้แปลข้อความแยกต่างหาก, จากนั้นตั้งค่ารหัสภาษาที่เหมาะสมสำหรับแต่ละส่วนที่แปลแล้ว

**ภาษาการพิสูจน์ควบคุมแบบอักษร, การแยกย่อหน้า, หรือการตัดบรรทัดหรือไม่?**

ไม่. รหัสภาษาถูกใช้สำหรับการพิสูจน์เท่านั้น. การแสดงผลและการจัดวางข้อความขึ้นอยู่กับ [แบบอักษร](/slides/th/java/powerpoint-fonts/) ที่มี, ระบบการเขียน, และการตั้งค่าเฟรมข้อความ. เพื่อให้การแสดงผลเชื่อถือได้, จัดหาแบบอักษรที่ต้องการ, ตั้งค่า [การแทนที่แบบอักษร](/slides/th/java/font-substitution/), หรือ [ฝังแบบอักษร](/slides/th/java/embedded-font/) ในพรีเซนเทชัน

**ย่อหน้าหนึ่งสามารถใช้หลายภาษาการพิสูจน์ได้หรือไม่?**

ได้. กำหนดแต่ละภาษาให้กับส่วนแยกต่างหาก, ตามตัวอย่างย่อหน้าหลายภาษา

**ควรใช้ `setDefaultTextLanguage` หรือ `setLanguageId`?**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เมื่อต้องการค่าเริ่มต้นสำหรับข้อความที่สร้างใหม่. ใช้ [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) เมื่อส่วนเฉพาะต้องการภาษาการพิสูจน์แบบชัดเจนหรือเมื่อย่อหน้ามีหลายภาษา.