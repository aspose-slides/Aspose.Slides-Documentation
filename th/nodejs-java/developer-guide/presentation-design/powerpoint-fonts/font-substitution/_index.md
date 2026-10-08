---
title: กำหนดการแทนที่แบบอักษรในงานนำเสนอโดยใช้ JavaScript
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
description: "กำหนดกฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Node.js ผ่าน Java เมื่อทำการแสดงผลหรือแปลงงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อทำการแสดงหรือแปลงงานนำเสนอ การแทนที่จะส่งผลต่อผลลัพธ์ที่แสดง; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาในงานนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรใดแบบอักษรก็ไม่มีอยู่ได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการแสดงผล สิ่งนี้ช่วยให้ผลลัพธ์คงที่ข้ามสภาพแวดล้อมที่มีแบบอักษรที่ติดตั้งแตกต่างกัน

หากแบบอักษรมีอยู่แต่ไม่มีรูปแบบหนาที่แยกออกมา ดูที่ [จัดการแบบอักษรที่ไม่มีรูปแบบหนาแยก](/slides/th/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). ส่วนนั้นอธิบายวิธีการเรสเตอร์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลกระทบต่อการเลือกข้อความ การค้นหา และการปรับขนาด

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) เพื่อกำหนดว่ากรณีใดแบบอักษรจะถูกแทนที่เมื่อทำการแสดงผลงานนำเสนอ เมธอดนี้คืนค่าออบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่ถูกแทน

ตัวอย่าง JavaScript ต่อไปนี้แสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับงานนำเสนอ:

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

ใช้เมธอด overload ของ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) พร้อมอาร์เรย์ของดัชนีสไลด์เพื่อสำรวจเฉพาะการแทนที่ที่จำเป็นสำหรับการแสดงสไลด์เฉพาะ นี่เป็นประโยชน์เมื่อคุณกำลังแสดงหรือส่งออกส่วนของงานนำเสนอ, ตรวจสอบงานนำเสนอที่ใหญ่เป็นขั้น ๆ, ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มี, เตรียมแพคเกจแบบอักษรขั้นต่ำสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างในการแสดงโดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

overload นี้คาดหวังอาเรย์พื้นฐานของ Java `int[]`. สร้างด้วย `java.newArray("int", [...])`; อาเรย์ JavaScript ธรรมดาจะถูกแปลงเป็น `Integer[]` และไม่ตรงกับ overload นี้

อาเรย์นี้ประกอบด้วยดัชนีสไลด์ที่เริ่มนับจากหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้าม, ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) ใช้การนับจากศูนย์ ดังนั้นสไลด์เดียวกันจะเข้าถึงเป็น `presentation.getSlides().get_Item(0)`. จำความแตกต่างนี้เมื่อตั้งค่าอาเรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียก overload ผ่าน [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). เมธอดนี้คืนค่าการแทนที่ที่กำหนดระหว่างการแสดงสไลด์ที่เลือกเท่านั้น แต่ละผลลัพธ์คือออบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อแบบอักษรต้นฉบับและแบบอักษรที่ถูกแทน ที่ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่เก็บไว้ใน [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/), และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/nodejs-java/custom-font/).

การแทนที่เดียวกันอาจจำเป็นสำหรับหลายสไลด์ที่เลือก ให้กำจัดรายการซ้ำเมื่อคุณสร้างรายการแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ที่คืนค่าทุกรายการและจากนั้นสร้างรายการเรียงลำดับของการแมปแบบอักษรที่ไม่ซ้ำ:

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

คลาส [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) มี overload ทั้งสอง ให้เลือกตามขอบเขตของการดำเนินการแสดงผล:

| Overload | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบเพิ่มขั้น, หรือการส่งออกบางส่วน. |

## **ตั้งกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรทดแทน
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎไปยัง [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)
6. แสดงหรือแปลงงานนำเสนอ

ตัวอย่าง JavaScript ต่อไปนี้แทนที่ `Arial` แทน `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่, จากนั้นแสดงสไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรทดแทนต้องมีใน Aspose.Slides

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

{{% alert color="info" title="หมายเหตุ" %}}
หากต้องการเปลี่ยนแบบอักษรโดยไม่มีเงื่อนไขทั่วทั้งงานนำเสนอ, ดูที่ [การเปลี่ยนแบบอักษร](/slides/th/nodejs-java/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการแสดงผลและการแปลง พวกมันทำงานได้สำหรับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่เข้าถึงไม่ได้ด้วยแบบอักษรที่มีตามที่กฎระบุ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math**, Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและแสดงเลย์เอาต์ของสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math**, ไม่สามารถแทนที่ **Cambria Math** เพื่อจุดประสงค์นี้ได้ และการแสดงอาจยังรายงานว่าต้องใช้ **Cambria Math**

เพื่อแสดงหรือแปลงงานนำเสนอเช่นนี้ ให้ทำให้ **Cambria Math** มีอยู่ใน Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/nodejs-java/custom-font/).

ข้อจำกัดนี้ใช้กับการจัดวางสมการ กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปในงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการเปลี่ยนแบบอักษรและการแทนที่แบบอักษรคืออะไร?**

[การเปลี่ยนแบบอักษร](/slides/th/nodejs-java/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งโดยตั้งใจตลอดงานนำเสนอ การแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่แสดงเมื่อเงื่อนไขที่กำหนดเป็นจริง เช่น เมื่อแบบอักษรต้นฉบับไม่มีอยู่

**กฎการแทนที่ถูกนำไปใช้เมื่อใด?**

กฎเหล่านี้มีส่วนร่วมใน [ลำดับการเลือกแบบอักษร](/slides/th/nodejs-java/font-selection-sequence/) ระหว่างการแสดงผลและการแปลง โดยใช้ `WhenInaccessible`, กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทาง

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายไปและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [โหลดแบบอักษรภายนอก](/slides/th/nodejs-java/custom-font/) เพื่อให้ Aspose.Slides ใช้ระหว่างการแสดงผลและการแปลง

**Aspose แจกจ่ายแบบอักษรมาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณเป็นผู้รับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามใบอนุญาตของพวกมัน

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงแบบกลุ่มได้อย่างไร?**

ใช้ไฟล์และเวอร์ชันแบบอักษรเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [โหลดแบบอักษรภายนอกที่จำเป็น](/slides/th/nodejs-java/custom-font/), และ [ฝังแบบอักษร](/slides/th/nodejs-java/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียก [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด