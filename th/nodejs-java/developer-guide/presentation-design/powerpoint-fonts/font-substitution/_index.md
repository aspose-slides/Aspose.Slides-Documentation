---
title: กำหนดค่าการแทนที่แบบอักษรในงานนำเสนอโดยใช้ JavaScript
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/nodejs-java/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรทดแทน
- การแทนที่แบบอักษร
- แทนที่แบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Node.js ผ่าน Java เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides ใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ การแทนที่จะมีผลต่อผลลัพธ์ที่เรนเดอร์; แต่ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดแบบอักษรที่ใช้เมื่อแบบอักษรบางตัวไม่มีอยู่ได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ ซึ่งช่วยให้ผลลัพธ์คงที่เมื่อติดตั้งแบบอักษรต่างกันในแต่ละสภาพแวดล้อม

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) เพื่อตรวจสอบว่าแบบอักษรใดจะถูกแทนที่เมื่อทำการเรนเดอร์งานนำเสนอ เมธอดจะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง JavaScript ต่อไปนี้แสดงการแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับงานนำเสนอ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้เมธอดโอเวอร์โหลดของ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) พร้อมอาร์เรย์ของดัชนีสไลด์เพื่อดูการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะ ช่วยเมื่อต้องเรนเดอร์หรือส่งออกบางส่วนของงานนำเสนอ ตรวจสอบงานนำเสนอขนาดใหญ่แบบเป็นขั้นเป็นตอน ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มีอยู่ เตรียมชุดแบบอักษรขั้นต่ำสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

โอเวอร์โหลดนี้ต้องการพารามิเตอร์ primitive ของ Java `int[]` สร้างด้วย `java.newArray("int", [...])`; อาร์เรย์ JavaScript ปกติจะถูกแปลงเป็น `Integer[]` ซึ่งไม่ตรงกับโอเวอร์โหลดนี้

อาร์เรย์จะประกอบด้วยดัชนีสไลด์แบบหนึ่ง‑ฐาน: `1` ระบุสไลด์แรก ในขณะที่ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) ใช้การนับแบบศูนย์‑ฐาน จึงต้องเข้าถึงสไลด์เดียวกันด้วย `presentation.getSlides().get_Item(0)` โปรดระวังความแตกต่างนี้เมื่อตั้งค่าอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off‑by‑one

เรียกโอเวอร์โหลดผ่าน [Presentation.getFontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getfontsmanager/) จะคืนค่าการแทนที่ที่กำหนดระหว่างการเรนเดอร์สไลด์ที่เลือก ผลลัพธ์แต่ละรายการเป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsubstitutioninfo/) ซึ่งมีชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน กฎ fallback ที่กำหนดไว้ กฎการแทนที่ที่เก็บใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsubstrulecollection/) และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/nodejs-java/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการกำจัดรายการซ้ำเมื่อสร้างฐานข้อมูลแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้แสดงการรายงานการแทนที่ที่คืนค่าแล้วและสร้างรายการจัดเรียงตามลำดับของการแมปแบบอักษรที่ไม่ซ้ำกัน:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

คลาส [FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/) มีโอเวอร์โหลดทั้งสองแบบ เลือกใช้งานตามขอบเขตของการเรนเดอร์:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | You need substitutions for the entire presentation. |
| [getSubstitutions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | You need substitutions for a selected range, incremental check, or partial export. |

## **กำหนดกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรแทนที่
3. สร้างอ็อบเจ็กต์ [FontSubstRule](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง JavaScript ต่อไปนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วเรนเดอร์สไลด์แรกเพื่อตรวจสอบผลลัพธ์ แบบอักษรแทนที่ต้องพร้อมใช้งานสำหรับ Aspose.Slides

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงแบบไม่มีเงื่อนไขทั่วงานนำเสนอทั้งหมด ให้ดูที่ [Font Replacement](/slides/th/nodejs-java/font-replacement/)
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง ทำงานได้สำหรับข้อความทั่วไปเมื่อ Aspose.Slides สามารถเปลี่ยนแบบอักษรที่เข้าถึงไม่ได้ให้เป็นแบบอักษรที่กำหนดในกฎได้

สมการ Office Math มีความต้องการเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์รูปแบบสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่นเช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้ และการเรนเดอร์อาจยังคงแจ้งว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงงานนำเสนอดังกล่าว ให้ทำให้ **Cambria Math** พร้อมใช้งานกับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/nodejs-java/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดรูปแบบสมการเท่านั้น กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปในงานนำเสนอ

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Font replacement](/slides/th/nodejs-java/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วงานนำเสนออย่างเจตนา ส่วนการแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดเป็นจริง เช่น เมื่อแบบอักษรต้นฉบับไม่มีอยู่

**When are substitution rules applied?**

กฎจะเข้าร่วมใน [font selection sequence](/slides/th/nodejs-java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง ด้วย `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทางได้

**What happens when a font is missing and no substitution rule is configured?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษร ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีในสภาพแวดล้อมการทำงาน

**Can I load external fonts to avoid substitution?**

ได้ คุณสามารถ [load external fonts](/slides/th/nodejs-java/custom-font/) เพื่อให้ Aspose.Slides ใช้งานได้ระหว่างการเรนเดอร์และการแปลง

**Does Aspose distribute fonts with the library?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามเงื่อนไขลิขสิทธิ์ของแบบอักษรเหล่านั้น

**Can substitution results differ between Windows, Linux, and macOS?**

ได้ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีในเครื่องหนึ่งอาจต้องแทนที่ในเครื่องอื่น

**How can I make font selection consistent in batch conversions?**

ใช้ไฟล์แบบอักษรและเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์ [load required external fonts](/slides/th/nodejs-java/custom-font/) และ [embed fonts](/slides/th/nodejs-java/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียกใช้ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) ก่อนส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด