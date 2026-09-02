---
title: กำหนดการแทนที่แบบอักษรในการนำเสนอด้วย Java
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/java/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรทดแทน
- การแทนที่แบบอักษร
- เปลี่ยนแบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "กำหนดกฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Java เมื่อทำการเรนเดอร์หรือแปลงการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรช่วยให้ Aspose.Slides ใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อการนำเสนอถูกเรนเดอร์หรือแปลง การแทนที่นี้มีผลต่อเอาต์พุตที่เรนเดอร์เท่านั้น; ไม่เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาการนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรเฉพาะบางตัวไม่พร้อมใช้งานและคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้เอาต์พุตคงที่ระหว่างสภาพแวดล้อมที่มีแบบอักษรติดตั้งต่างกัน

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) เพื่อกำหนดว่าแบบอักษรใดจะถูกแทนที่เมื่อการนำเสนอถูกเรนเดอร์ เมธอดนี้คืนค่าออบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง Java ด้านล่างแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับการนำเสนอ:

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

ใช้เมธอดโอเวอร์โหลดของ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อสอบถามการแทนที่ที่จำเป็นต่อการเรนเดอร์สไลด์เฉพาะ ซึ่งมีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของการนำเสนอ, ตรวจสอบการนำเสนอขนาดใหญ่แบบเพิ่มขึ้น, ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่พร้อมใช้งาน, เตรียมแพกเกจแบบอักษรขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างในการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

`array` slides มีดัชนีสไลด์เริ่มจากหนึ่ง: `1` หมายถึงสไลด์แรก ในทางกลับกัน ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlides--) ใช้ดัชนีเริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจะเข้าถึงได้โดยใช้ `presentation.getSlides().get_Item(0)` จำไว้ความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียกโอเวอร์โหลดผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getFontsManager--) จะคืนค่าเฉพาะการแทนที่ที่กำหนดขณะเรนเดอร์สไลด์ที่เลือก ผลลัพธ์แต่ละรายการเป็นออบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstitutioninfo/) ประกอบด้วยชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่เก็บใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsubstrulecollection/), และ [แบบอักษรที่โหลดภายนอก](/slides/th/java/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการลบซ้ำผลลัพธ์เมื่อคุณสร้างรายการแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ทุกรายการที่คืนค่าแล้วสร้างรายการเรียงลำดับของการแมปแบบอักษรที่ไม่ซ้ำกัน:

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

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/) ให้โอเวอร์โหลดทั้งสองแบบ เลือกใช้ตามขอบเขตของการดำเนินการเรนเดอร์:

| โอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) โดยไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด. |
| [getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อม `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบเพิ่มขึ้น, หรือการส่งออกบางส่วน. |

## **กำหนดกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่พร้อมใช้งาน:

1. โหลดการนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรแทนที่
3. สร้างอ็อบเจกต์ [FontSubstRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-)
6. เรนเดอร์หรือแปลงการนำเสนอ

ตัวอย่าง Java ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน และจากนั้นเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรแทนที่ต้องมีอยู่ใน Aspose.Slides.

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
สำหรับการเปลี่ยนแปลงแบบไม่มีเงื่อนไขต่อแบบอักษรที่ใช้ทั่วทั้งการนำเสนอ ดูที่ [Font Replacement](/slides/th/java/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานได้กับข้อความปกติเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่สามารถเข้าถึงได้ด้วยแบบอักษรที่พร้อมใช้งานตามกฎ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างตรงเพื่อคำนวณและเรนเดอร์เลย์เอาต์ของสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** สำหรับจุดประสงค์นี้ได้และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงการนำเสนอแบบนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานใน Aspose.Slides ติดตั้งมันในระบบปฏิบัติการหรือโหลดเป็น [external font](/slides/th/java/custom-font/).

ข้อจำกัดนี้ใช้กับเลย์เอาต์ของสมการ กฎการแทนที่ที่อธิบายไว้ข้างต้นยังคงใช้กับข้อความปกติของการนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการเปลี่ยนแบบอักษร (font replacement) กับการแทนที่แบบอักษร (font substitution) คืออะไร?**

[Font replacement](/slides/th/java/font-replacement/) ทำการเปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วทั้งการนำเสนอโดยตั้งใจ การแทนที่แบบอักษรจะเลือกแบบอักษรสำหรับเอาต์พุตที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรงตาม เช่น เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

**กฎการแทนที่จะถูกนำไปใช้เมื่อใด?**

กฎเหล่านี้เข้าร่วมใน [ลำดับการเลือกแบบอักษร](/slides/th/java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง โดยเมื่อใช้ `WhenInaccessible` กฎจะถูกใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทาง

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายไปและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีอยู่ในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [load external fonts](/slides/th/java/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรมาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณเป็นผู้รับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามใบอนุญาตของแบบอักษรเหล่านั้น

**ผลการแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS ได้หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรจะแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีอยู่ในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงแบบชุดได้อย่างไร?**

ใช้ไฟล์แบบอักษรและเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [load required external fonts](/slides/th/java/custom-font/), และ [embed fonts](/slides/th/java/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียก [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) ก่อนการส่งออกเพื่อระบุการแทนที่ที่คาดไม่ถึง