---
title: ทำอัตโนมัติการแปลโลคัลไลเซชันของพรีเซนเทชันใน .NET
linktitle: การแปลโลคัลไลเซชันของพรีเซนเทชัน
type: docs
weight: 100
url: /th/net/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจสอบการสะกด
- ยับยั้งการตรวจสอบการสะกด
- ภาษาการ proof
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ตั้งค่าภาษาการ proof สำหรับข้อความพรีเซนเทชัน PowerPoint และ OpenDocument ใน .NET ด้วย Aspose.Slides รวมถึงค่าเริ่มต้นและย่อหน้าหลายภาษา"
---
## **ภาพรวม**

Aspose.Slides for .NET ให้คุณกำหนดค่าเมตาดาต้า proofing สำหรับส่วนข้อความแต่ละส่วน ใช้ [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) เพื่อระบุภาษาการตรวจสอบ, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/spellcheck/) เพื่ออนุญาตหรือยับยั้งการตรวจสอบการสะกด, และ [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/proofdisabled/) เพื่อควบคุมสถานะ “ไม่ทำ proof” ที่กว้างกว่า เพราะการตั้งค่าเหล่านี้ทำงานระดับส่วนข้อความ หนึ่งย่อหน้าสามารถมีหลายภาษาและกฎการ proof ที่แตกต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาให้กับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaulttextlanguage/), สร้างย่อหน้าหลายภาษา, เลือกใช้ระหว่าง `SpellCheck` และ `ProofDisabled`, และรักษาการตั้งค่าเหล่านั้นเมื่อใช้ [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/joinportionswithsameformatting/) คุณสมบัติเหล่านี้จัดเก็บเมตาดาต้าสำหรับแอปพลิเคชันพรีเซนเทชัน; พวกมันไม่ได้ทำการแปลข้อความ, ทำการตรวจสอบการสะกดโดยพจนานุกรม, หรือคืนค่าคำที่สะกดผิด

## **ตั้งค่าภาษา Proofing สำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/portionformat/), แล้วกำหนดรหัสภาษาของมัน ตัวอย่างต่อไปนี้สร้างรูปทรง, ตั้งค่า British English เป็นภาษาการ proof, และบันทึกผลลัพธ์ด้วย [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaulttextlanguage/) เพื่อระบุภาษาการ proof ที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในพรีเซนเทชันใช้ภาษาเดียวกัน มันไม่เปลี่ยนเมตาดาต้าภาษาในข้อความที่มีการกำหนดภาษาอย่างชัดเจนแล้ว

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ข้อความใหม่ใช้กฎการ proof ภาษาเยอรมัน :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **ใช้หลายภาษาในย่อหน้าหนึ่ง**

[IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/net/aspose.slides/portion/) แยกกันสำหรับแต่ละภาษาและกำหนด `LanguageId` ของแต่ละส่วนอย่างอิสระ

ตัวอย่างนี้สร้างย่อหน้าเดียวที่มีส่วนข้อความภาษาอังกฤษและฝรั่งเศส :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **เปิดหรือยับยั้งการตรวจสอบการสะกดสำหรับส่วนข้อความแต่ละส่วน**

[IPortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportionformat/) สืบทอดคุณสมบัติข้อความทั่วไปที่กำหนดโดย [IBasePortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/) เข้าถึงรูปแบบของส่วนข้อความผ่าน [IPortion.PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/iportion/portionformat/) แล้วตั้งค่า [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/spellcheck/) เพื่อกำหนดว่ามีการตรวจสอบการสะกดหรือไม่ ค่าเริ่มต้นคือ `false`: `true` อนุญาตให้ตรวจสอบการสะกด, ส่วน `false` จะยับยั้งการตรวจสอบ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ในย่อหน้าหนึ่งจึงสามารถใช้ค่าแตกต่างกันได้ [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/languageid/) และ `SpellCheck` ทำงานร่วมกัน: `LanguageId` ระบุภาษาการ proof, ส่วน `SpellCheck` กำหนดว่าการตรวจสอบการสะกดจะถูกอนุญาตหรือไม่

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/proofdisabled/) ยังควบคุมการ proof ด้วย แต่เป็นตัวแทนสถานะ “ไม่ทำ proof” ที่กว้างกว่าในรูปแบบ [NullableBool](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/) ใช้ `SpellCheck` เมื่อคุณต้องการสวิตช์ Boolean ตรงสำหรับการตรวจสอบการสะกด ใช้ `ProofDisabled` เมื่อคุณต้องการเก็บหรือควบคุมเมตาดาต้า “ไม่ทำ proof” ของพรีเซนเทชันอย่างชัดเจนรวมถึงสถานะ `NotDefined` หากคุณตั้งค่าทั้งสองคุณสมบัติ ควรรักษาค่าตรงกัน; อย่าผสม `SpellCheck = true` กับ `ProofDisabled = NullableBool.True`

คุณสมบัติเหล่านี้กำหนดเมตาดาต้าการ proof ที่ใช้โดย PowerPoint และแอปพลิเคชันพรีเซนเทชันอื่น ๆ Aspose.Slides ไม่ได้ใช้มันเพื่อรันการตรวจสอบการสะกดแบบพจนานุกรมหรือคืนค่ารายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างพรีเซนเทชันต้นฉบับ, โหลดมัน, กำหนดการตั้งค่าการตรวจสอบการสะกดและภาษาการ proof ที่แตกต่างให้กับสองส่วนในย่อหน้าเดียว, บันทึกผลลัพธ์, เปิดใหม่อีกครั้ง, แล้วตรวจสอบค่าที่จัดเก็บ :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/joinportionswithsameformatting/) จะรวมส่วนข้อความที่ต่อกันและมีรูปแบบเดียวกัน ความแตกต่างเพียงอย่างเดียวใน `SpellCheck` ไม่ทำให้ส่วนเหล่านั้นแยกออกจากกัน; หลังจากถูกรวม ส่วนที่ได้จะคงค่า `SpellCheck` ของส่วนแรก หากส่วนต้องการการตั้งค่าการตรวจสอบการสะกดที่แตกต่าง ให้เรียก `JoinPortionsWithSameFormatting` ก่อนกำหนดค่าดังกล่าว, หรือสแกนขอบเขตส่วนที่ได้และกำหนดค่าใหม่ภายหลัง ส่วนที่มีค่า `LanguageId` ต่างกันจะคงอยู่แยกกันเนื่องจากรูปแบบภาษาการ proof แตกต่างกัน

## **คำถามที่พบบ่อย**

**รหัสภาษา (Language ID) แปลข้อความหรือไม่?**

ไม่ใช่. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) จะเก็บเมตาดาต้าการ proof สำหรับการสะกดและไวยากรณ์; มันไม่ได้เปลี่ยนเนื้อหาข้อความ ให้แปลข้อความแยกต่างหากแล้วตั้งค่ารหัสภาษาที่เหมาะสมสำหรับแต่ละส่วนที่แปลแล้ว

**ภาษาการ proof ควบคุมแบบอักษร, การแบ่งคำ, หรือการตัดบรรทัดหรือไม่?**

ไม่ใช่. รหัสภาษามีไว้เพื่อการ proof เท่านั้น การเรนเดอร์และการจัดวางข้อความขึ้นกับ [fonts](/slides/th/net/powerpoint-fonts/) ที่มีอยู่, ระบบเขียน, และการตั้งค่าเฟรมข้อความ เพื่อให้การเรนเดอร์แม่นยำ ให้จัดหาแบบอักษรที่ต้องการ, ตั้งค่าการทดแทนแบบอักษร [font substitution](/slides/th/net/font-substitution/), หรือ [embed fonts](/slides/th/net/embedded-font/) ในพรีเซนเทชัน

**ย่อหน้าเดียวสามารถใช้หลายภาษาการ proof ได้หรือไม่?**

ได้. กำหนดแต่ละภาษาให้กับส่วนข้อความแยกกัน ตามตัวอย่างย่อหน้าหลายภาษา

**ควรใช้ `DefaultTextLanguage` หรือ `LanguageId`?**

ใช้ [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/defaulttextlanguage/) เมื่อคุณต้องการค่าเริ่มต้นสำหรับข้อความที่สร้างใหม่ ใช้ [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseportionformat/languageid/) เมื่อส่วนข้อความใดต้องการภาษาการ proof อย่างชัดเจน หรือเมื่อย่อหน้ามีหลายภาษา