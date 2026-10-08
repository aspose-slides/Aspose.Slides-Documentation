---
title: กำหนดการแทนที่ฟอนต์ในการนำเสนอโดยใช้ Java
linktitle: การแทนที่ฟอนต์
type: docs
weight: 70
url: /th/java/font-substitution/
keywords:
- ฟอนต์
- ฟอนต์ทดแทน
- การแทนที่ฟอนต์
- เปลี่ยนฟอนต์
- การเปลี่ยนฟอนต์
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "กำหนดกฎการแทนที่ฟอนต์และตรวจสอบฟอนต์ที่ถูกแทนที่ใน Aspose.Slides สำหรับ Java ขณะเรนเดอร์หรือแปลงการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่ฟอนต์ทำให้ Aspose.Slides ใช้ฟอนต์ที่มีอยู่แทนฟอนต์ที่ไม่สามารถเข้าถึงได้เมื่อการนำเสนอถูกเรนเดอร์หรือแปลง การแทนที่มีผลต่อผลลัพธ์ที่เรนเดอร์; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับเนื้อหาในงานนำเสนอ

คุณสามารถกำหนดฟอนต์ที่จะใช้เมื่อฟอนต์บางตัวไม่มีอยู่ได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้ผลลัพธ์คงที่ในสภาพแวดล้อมที่มีฟอนต์ติดตั้งต่างกัน

หากฟอนต์มีอยู่แต่ไม่มีตัวหนาที่กำหนดเฉพาะ ดู [จัดการฟอนต์ที่ไม่มีตัวหนาที่กำหนดเฉพาะ](/slides/th/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). ส่วนนี้อธิบายวิธีการแรสเตอร์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลกระทบต่อการเลือกข้อความ, การค้นหา, และการปรับขนาด

## **รับการแทนที่ฟอนต์**

ใช้เมธอด [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) เพื่อกำหนดว่าฟอนต์ใดจะถูกแทนที่เมื่อการนำเสนอถูกเรนเดอร์ เมธอดนี้คืนค่าอ็อบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อฟอนต์ต้นแบบและฟอนต์ที่แทนที่

ตัวอย่าง Java ด้านล่างนี้แสดงรายการการแทนที่ฟอนต์ทั้งหมดสำหรับการนำเสนอ:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **รับการแทนที่ฟอนต์สำหรับสไลด์ที่เลือก**

ใช้เมธอด overload [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อดูการแทนที่ที่จำเป็นต่อการเรนเดอร์สไลด์เฉพาะอย่างเท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของการนำเสนอ, ตรวจสอบการนำเสนอขนาดใหญ่แบบเพิ่มทีละส่วน, ค้นหาสไลด์ที่พึ่งพาฟอนต์ที่ไม่มีอยู่, เตรียมแพคเกจฟอนต์ขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์แบบ 1‑based: `1` หมายถึงสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) ใช้การจัดทำดัชนีแบบ 0‑based ดังนั้นสไลด์เดียวกันจะถูกเข้าถึงเป็น `presentation.getSlides().get_Item(0)`. โปรดคำนึงถึงความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off‑by‑one

เรียก overload ผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) ซึ่งจะคืนค่าการแทนที่ที่กำหนดระหว่างการเรนเดอร์สไลด์ที่เลือกเท่านั้น แต่ละผลลัพธ์เป็นอ็อบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) ที่มีชื่อฟอนต์ต้นแบบและฟอนต์ที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมฟอนต์ปัจจุบัน, กฎ fallback ที่กำหนด, และ [ฟอนต์ที่โหลดจากภายนอก](/slides/th/java/custom-font/). กฎการแทนที่ที่เก็บไว้ใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) จะถูกนำไปใช้เมื่อการนำเสนอถูกเรนเดอร์ แต่ผลลัพธ์จะไม่แสดงรายการกฎเหล่านั้น; ให้ตรวจสอบฟอนต์ในไฟล์ผลลัพธ์แทน

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ลบรายการซ้ำออกเมื่อคุณสร้างรายการตรวจสอบฟอนต์หรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ที่ส่งคืนทั้งหมดแล้วสร้างรายการจัดเรียงของการแมปฟอนต์ที่ไม่ซ้ำ:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) มี overload ทั้งสองแบบ ให้เลือกตามขอบเขตของการเรนเดอร์:

| Overload | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบเพิ่มทีละส่วน, หรือการส่งออกบางส่วน |

## **ตั้งค่ากฎการแทนที่ฟอนต์**

เพื่อระบุฟอนต์ที่ Aspose.Slides ควรใช้เมื่อฟอนต์ต้นฉบับไม่มีอยู่:

1. โหลดการนำเสนอ
2. สร้างการกำหนดฟอนต์สำหรับฟอนต์ต้นฉบับและฟอนต์ทดแทน
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) ด้วยเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/)
4. เพิ่มกฎเข้าไปใน [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-)
6. เรนเดอร์หรือแปลงการนำเสนอ

ตัวอย่าง Java ด้านล่างนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ ฟอนต์ทดแทนต้องมีอยู่ใน Aspose.Slides

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงฟอนต์โดยไม่มีเงื่อนไขทั่วทั้งการนำเสนอ ดู [Font Replacement](/slides/th/java/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับฟอนต์สมการคณิตศาสตร์**

กฎการแทนที่ฟอนต์เป็นส่วนหนึ่งของกระบวนการเลือกฟอนต์มาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานได้กับข้อความปกติเมื่อ Aspose.Slides สามารถแทนที่ฟอนต์ที่เข้าถึงไม่ได้ด้วยฟอนต์ที่กำหนดโดยกฎ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการฟอนต์นั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์เค้าโครงสมการ กฎที่แทนที่ฟอนต์คณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** เพื่อจุดประสงค์นี้ได้ และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math** อยู่

เพื่อเรนเดอร์หรือแปลงการนำเสนอเช่นนี้ ให้ทำให้ **Cambria Math** มีอยู่ใน Aspose.Slides ติดตั้งมันในระบบปฏิบัติการหรือโหลดเป็น [ฟอนต์ภายนอก](/slides/th/java/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดเค้าโครงสมการ กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความปกติในงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่ฟอนต์และการแทนที่ฟอนต์คืออะไร?**

[Font replacement](/slides/th/java/font-replacement/) เปลี่ยนฟอนต์หนึ่งเป็นอีกฟอนต์หนึ่งทั่วทั้งการนำเสนอโดยตั้งใจ การแทนที่ฟอนต์จะเลือกฟอนต์สำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรง, เช่น เมื่อฟอนต์ต้นแบบไม่มีอยู่

**กฎการแทนที่ฟอนต์ทำงานเมื่อใด?**

กฎเหล่านี้เข้าร่วมใน [ลำดับการเลือกฟอนต์](/slides/th/java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง กับ `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงฟอนต์ต้นแบบได้

**จะเกิดอะไรขึ้นเมื่อฟอนต์หายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกฟอนต์ที่ใกล้เคียงที่สุดตามกระบวนการเลือกฟอนต์ของมัน ผลลัพธ์ขึ้นอยู่กับฟอนต์ที่มีในสภาพแวดล้อมรันไทม์

**ฉันสามารถโหลดฟอนต์ภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [โหลดฟอนต์ภายนอก](/slides/th/java/custom-font/) เพื่อให้ Aspose.Slides ใช้งานได้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายฟอนต์พร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาและปฏิบัติตามใบอนุญาตของฟอนต์

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่าง Windows, Linux และ macOS หรือไม่?**

ใช่ ฟอนต์ที่ติดตั้งและตำแหน่งการค้นหาฟอนต์ต่างกันตามระบบปฏิบัติการ ดังนั้นฟอนต์ที่มีในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกฟอนต์สม่ำเสมอในการแปลงแบบกลุ่มได้อย่างไร?**

ใช้ไฟล์ฟอนต์และเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [โหลดฟอนต์ภายนอกที่จำเป็น](/slides/th/java/custom-font/), และ [ฝังฟอนต์](/slides/th/java/embedded-font/) เมื่อใบอนญาติอนุญาต คุณยังสามารถเรียก [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) ก่อนการส่งออกเพื่อระบุการแทนที่ที่คาดไม่ถึง.