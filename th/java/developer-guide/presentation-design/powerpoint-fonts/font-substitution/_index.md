---
title: กำหนดการแทนที่ฟอนต์ในงานนำเสนอโดยใช้ Java
linktitle: การแทนที่ฟอนต์
type: docs
weight: 70
url: /th/java/font-substitution/
keywords:
- ฟอนต์
- ฟอนต์ทดแทน
- การแทนที่ฟอนต์
- การเปลี่ยนฟอนต์
- การแทนที่ฟอนต์
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "กำหนดกฎการแทนที่ฟอนต์และตรวจสอบฟอนต์ที่ถูกแทนที่ใน Aspose.Slides สำหรับ Java เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่ฟอนต์ทำให้ Aspose.Slides สามารถใช้ฟอนต์ที่มีอยู่แทนฟอนต์ที่ไม่สามารถเข้าถึงได้เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ การแทนที่จะส่งผลต่อผลลัพธ์ที่เรนเดอร์; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดฟอนต์ที่จะใช้เมื่อฟอนต์บางตัวไม่มีอยู่ได้และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้ผลลัพธ์สอดคล้องกันระหว่างสภาพแวดล้อมที่มีฟอนต์ติดตั้งต่างกัน

## **รับการแทนที่ฟอนต์**

ใช้ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) เพื่อกำหนดว่าฟอนต์ใดจะถูกแทนที่เมื่อทำการเรนเดอร์งานนำเสนอ วิธีนี้จะคืนค่าออบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทนที่

ตัวอย่าง Java ต่อไปนี้แสดงฟอนต์ที่ถูกแทนที่ทั้งหมดสำหรับงานนำเสนอ:

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

ใช้การเรียก [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อดูการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะเท่านั้น วิธีนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนหนึ่งของงานนำเสนอ, ตรวจสอบงานนำเสนอขนาดใหญ่แบบขั้นเป็นขั้น, ค้นหาสไลด์ที่พึ่งพาฟอนต์ที่ไม่มีอยู่, เตรียมแพ็กเกจฟอนต์ขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวิเคราะห์ความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` ใช้ดัชนีสไลด์แบบหนึ่งฐาน: `1` หมายถึงสไลด์แรก ตรงกันข้ามกับตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlides--) ที่ใช้ดัชนีศูนย์ฐาน ดังนั้นสไลด์เดียวกันจะเข้าถึงด้วย `presentation.getSlides().get_Item(0)` อย่าลืมคำนึงถึงความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียกการโอเวอร์โหลดผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getFontsManager--) วิธีนี้จะคืนค่าเฉพาะการแทนที่ที่กำหนดขณะเรนเดอร์สไลด์ที่เลือก แต่ละผลลัพธ์เป็นออบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมฟอนต์ปัจจุบัน, กฎการสำรองที่กำหนด, และ [ฟอนต์ที่โหลดจากภายนอก](/slides/th/java/custom-font/) กฎการแทนที่ที่เก็บไว้ใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsubstrulecollection/) จะถูกใช้เมื่อทำการเรนเดอร์งานนำเสนอ แต่ผลลัพธ์จะไม่แสดงรายการกฎเหล่านั้น; ให้ตรวจสอบฟอนต์ในไฟล์ผลลัพธ์แทน

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการลดผลซ้ำเมื่อต้องสร้างรายการตรวจสอบฟอนต์หรือรายงานการตรวจสอบล่วงหน้า ตัวอย่างต่อไปนี้รายงานการแทนที่ที่ได้รับทั้งหมดแล้วสร้างรายการที่จัดเรียงตามฟอนต์ที่แมพอย่างเป็นเอกลักษณ์:

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

อินเตอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/) ให้บริการทั้งสองโอเวอร์โหลด เลือกใช้ตามขอบเขตของการทำงานเรนเดอร์:

| Overload | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) โดยไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อม `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงสไลด์ที่เลือก, การตรวจสอบแบบเพิ่มทีละส่วน, หรือการส่งออกบางส่วน |

## **กำหนดกฎการแทนที่ฟอนต์**

เพื่อระบุฟอนต์ที่ Aspose.Slides ควรใช้เมื่อฟอนต์ต้นทางไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างการนิยามฟอนต์สำหรับฟอนต์ต้นทางและฟอนต์ทดแทน
3. สร้างออบเจ็กต์ [FontSubstRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง Java ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วเรนเดอร์สไลด์แรกเพื่อตรวจสอบผลลัพธ์ ฟอนต์ทดแทนต้องมีอยู่ใน Aspose.Slides

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
สำหรับการเปลี่ยนแปลงฟอนต์โดยไม่มีเงื่อนไขตลอดงานนำเสนอทั้งหมด โปรดดู [Font Replacement](/slides/th/java/font-replacement/) 
{{% /alert %}}

## **ข้อจำกัดสำหรับฟอนต์สมการคณิตศาสตร์**

กฎการแทนที่ฟอนต์เป็นส่วนหนึ่งของกระบวนการเลือกฟอนต์มาตรฐานที่ใช้ในระหว่างการเรนเดอร์และการแปลง พวกมันทำงานได้กับข้อความปกติเมื่อ Aspose.Slides สามารถแทนที่ฟอนต์ที่เข้าถึงไม่ได้ด้วยฟอนต์ที่กำหนดโดยกฎ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการฟอนต์นั้นอย่างละเอียดเพื่อคำนวนและเรนเดอร์เค้าโครงสมการ กฎที่แทนที่ฟอนต์คณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้ และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math** อยู่

เพื่อเรนเดอร์หรือแปลงงานนำเสนอที่มีลักษณะเช่นนี้ ให้ทำให้ **Cambria Math** มีอยู่ใน Aspose.Slides โดยติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [ฟอนต์ภายนอก](/slides/th/java/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดวางสมการเท่านั้น กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความปกติในงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่ฟอนต์กับการเปลี่ยนฟอนต์คืออะไร?**

[Font replacement](/slides/th/java/font-replacement/) เป็นการเปลี่ยนฟอนต์หนึ่งเป็นอีกฟอนต์หนึ่งทั่วทั้งงานนำเสนออย่างเจตนา การแทนที่ฟอนต์เลือกฟอนต์สำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดเกิดขึ้น เช่น ฟอนต์ต้นฉบับไม่มีอยู่

**กฎการแทนที่ฟอนต์ถูกใช้เมื่อนไหน?**

กฎมีส่วนร่วมใน [ลำดับการเลือกฟอนต์](/slides/th/java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง โดยใช้ `WhenInaccessible` กฎจะถูกใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงฟอนต์ต้นทางได้

**เกิดอะไรขึ้นเมื่อตัวฟอนต์หายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกฟอนต์ที่ใกล้เคียงที่สุดตามกระบวนการเลือกฟอนต์ ผลลัพธ์ขึ้นกับฟอนต์ที่มีอยู่ในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดฟอนต์ภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [โหลดฟอนต์ภายนอก](/slides/th/java/custom-font/) เพื่อให้ Aspose.Slides ใช้งานได้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายฟอนต์มาพร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหารองรับฟอนต์และปฏิบัติตามสัญญาอนุญาตของฟอนต์นั้นๆ

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ ฟอนต์ที่ติดตั้งและตำแหน่งการค้นหาฟอนต์แตกต่างกันตามระบบปฏิบัติการ ดังนั้นฟอนต์ที่มีในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกฟอนต์สอดคล้องกันในการแปลงแบบกลุ่มอย่างไร?**

ใช้ไฟล์และเวอร์ชันฟอนต์เดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [โหลดฟอนต์ภายนอกที่จำเป็น](/slides/th/java/custom-font/), และ [ฝังฟอนต์](/slides/th/java/embedded-font/) เมื่อได้รับอนุญาตตามลิขสิทธิ์ คุณยังสามารถเรียก [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) ก่อนทำการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด