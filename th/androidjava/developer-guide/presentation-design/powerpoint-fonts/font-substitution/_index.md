---
title: กำหนดการแทนที่แบบอักษรในการนำเสนอบน Android
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/androidjava/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรสำรอง
- การแทนที่แบบอักษร
- การเปลี่ยนแบบอักษร
- การแทนที่แบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "กำหนดกฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Android ผ่าน Java ขณะเรนเดอร์หรือแปลงการนำเสนอ."
---
## **ภาพรวม**

การแทนที่แบบอักษร (Font substitution) ทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อการนำเสนอถูกเรนเดอร์หรือแปลง การแทนที่ส่งผลต่อผลลัพธ์ที่เรนเดอร์เท่านั้น; มิได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาการนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรเฉพาะไม่มีให้ใช้งาน และสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้ผลลัพธ์คงที่ในอุปกรณ์ Android และสภาพแวดล้อมที่มีแบบอักษรต่างกัน

หากแบบอักษรพร้อมใช้งานแต่ไม่มีตัวหนาแบบเฉพาะ, ดูที่ [Handle Fonts Without a Dedicated Bold Typeface](/slides/th/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). ส่วนนั้นอธิบายวิธีทำให้ข้อความที่ได้รับผลกระทบเป็น raster ระหว่างการส่งออกเป็น PDF และผลกระทบต่อการเลือกข้อความ, การค้นหา, และการขยายขนาด

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) เพื่อกำหนดว่าแบบอักษรใดจะถูกแทนที่เมื่อการนำเสนอถูกเรนเดอร์ เมธอดจะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง Java ด้านล่างแสดงการแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับการนำเสนอหนึ่งชุด:

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

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้เมธอดโอเวอร์โหลดของ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อดูการแทนที่ที่จำเป็นต่อการเรนเดอร์สไลด์เฉพาะส่วน วิธีนี้เป็นประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกบางส่วนของการนำเสนอ, ตรวจสอบการนำเสนอขนาดใหญ่เป็นขั้น ๆ, ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มี, เตรียมชุดแบบอักษรขั้นต่ำสำหรับแอป Android, หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาเรย์ `slides` มีดัชนีสไลด์แบบหนึ่ง‑ฐาน: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) ใช้การจัดทำดัชนีแบบศูนย์‑ฐาน ดังนั้นสไลด์เดียวกันจะเข้าถึงได้เป็น `presentation.getSlides().get_Item(0)`. ควรคำนึงถึงความต่างนี้เมื่อสร้างอาเรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off‑by‑one

เรียกโอเวอร์โหลดผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) จะคืนค่าการแทนที่ที่กำหนดไว้ขณะเรนเดอร์สไลด์ที่เลือก ผลลัพธ์แต่ละรายการเป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่จัดเก็บใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/androidjava/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการกำจัดรายการซ้ำเมื่อคุณสร้างรายการแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ที่คืนค่าทั้งหมดและจากนั้นสร้างรายการแบบอักษรที่ไม่ซ้ำกันเรียงตามลำดับ:

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

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) มีโอเวอร์โหลดทั้งสองแบบ ให้เลือกใช้ตามขอบเขตของการดำเนินการเรนเดอร์:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบเพิ่มขึ้น, หรือการส่งออกบางส่วน |

## **กำหนดกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่มีให้ใช้งาน:

1. โหลดการนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรสำรอง
3. สร้างอ็อบเจ็กต์ [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) 
6. เรนเดอร์หรือแปลงการนำเสนอ

ตัวอย่าง Java ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีให้ใช้งาน แล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรสำรองต้องพร้อมใช้งานใน Aspose.Slides

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
สำหรับการเปลี่ยนแปลงแบบไม่มีเงื่อนไขทั่วทั้งการนำเสนอ, ดูที่ [Font Replacement](/slides/th/androidjava/font-replacement/) 
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานได้กับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่เข้าถึงไม่ได้ด้วยแบบอักษรที่กำหนดในกฎ

สมการ Office Math มีความต้องการเพิ่มเติม หากสมการใช้ **Cambria Math**, Aspose.Slides อาจจำเป็นต้องใช้แบบอักษรนั้นอย่างแม่นยำเพื่อคำนวนและเรนเดอร์รูปแบบสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้ และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงการนำเสนอแบบนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานใน Aspose.Slides โหลดเป็น [แบบอักษรภายนอก](/slides/th/androidjava/custom-font/) เพื่อให้แอปสามารถใช้ระหว่างการเรนเดอร์และการแปลง

ข้อจำกัดนี้ใช้กับการจัดรูปแบบสมการเท่านั้น กฎการแทนที่ที่อธิบายด้านบนยังคงใช้ได้กับข้อความทั่วไปในการนำเสนอ

## **FAQ**

**ความแตกต่างระหว่างการเปลี่ยนแบบอักษรและการแทนที่แบบอักษรคืออะไร?**

[Font replacement](/slides/th/androidjava/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วทั้งการนำเสนอ การแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรงตามที่ตั้งค่าไว้ เช่น เมื่อแบบอักษรต้นฉบับไม่มีให้ใช้งาน

**กฎการแทนที่ทำงานเมื่อใด?**

กฎเหล่านี้เข้าร่วมใน [font selection sequence](/slides/th/androidjava/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง ด้วย `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทางได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดตามกระบวนการเลือกแบบอักษร ผลลัพธ์ขึ้นกับแบบอักษรที่มีในสภาพแวดล้อมรันไทม์

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [load external fonts](/slides/th/androidjava/custom-font/) เพื่อให้ Aspose.Slides ใช้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรมาพร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามข้อตกลงลิขสิทธิ์ของแต่ละแบบอักษร

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่างอุปกรณ์ Android หรือไม่?**

ได้ แบบอักษรระบบที่พร้อมใช้งานอาจแตกต่างระหว่างเวอร์ชัน Android, อุปกรณ์, และผู้ผลิต ดังนั้นแบบอักษรที่มีในสภาพแวดล้อมหนึ่งอาจต้องการการแทนที่ในอีกสภาพแวดล้อมหนึ่ง

**ฉันจะทำให้การเลือกแบบอักษรสอดคล้องกันข้ามอุปกรณ์ Android อย่างไร?**

แพคไฟล์แบบอักษรที่จำเป็นเดียวกันกับแอป, [load them as external fonts](/slides/th/androidjava/custom-font/), และ [embed fonts](/slides/th/androidjava/embedded-font/) เมื่ออนุญาตตามลิขสิทธิ์ คุณยังสามารถเรียก [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิดได้.