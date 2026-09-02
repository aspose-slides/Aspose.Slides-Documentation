---
title: กำหนดค่าการแทนที่แบบอักษรในการนำเสนอบน Android
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/androidjava/font-substitution/
keywords:
- แบบอักษร
- แทนที่แบบอักษร
- การแทนที่แบบอักษร
- เปลี่ยนแบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "กำหนดกฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ Android ผ่าน Java เมื่อทำการเรนเดอร์หรือแปลงการนำเสนอ"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides ใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อการนำเสนอถูกเรนเดอร์หรือแปลง การแทนที่มีผลต่อผลลัพธ์ที่เรนเดอร์; มันไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาการนำเสนอ

คุณสามารถกำหนดแบบอักษรที่ใช้เมื่อแบบอักษรบางตัวไม่พร้อมใช้งานและคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำในระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้ผลลัพธ์คงที่ในอุปกรณ์ Android และสภาพแวดล้อมที่มีแบบอักษรที่มีให้แตกต่างกัน

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) เพื่อตรวจสอบว่าแบบอักษรใดจะถูกแทนที่เมื่อการนำเสนอถูกเรนเดอร์ เมธอดนี้ส่งคืนอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

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

ใช้เมธอดโอเวอร์โหลด [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อทำการตรวจสอบการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะเท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนหนึ่งของการนำเสนอ, ตรวจสอบการนำเสนอขนาดใหญ่เป็นขั้น ๆ, ค้นหาสไลด์ที่ขึ้นกับแบบอักษรที่ไม่มี, เตรียมแพคเกจแบบอักษรขนาดเล็กสำหรับแอป Android, หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์เริ่มจากหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) ใช้ดัชนีเริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจะถูกเข้าถึงเป็น `presentation.getSlides().get_Item(0)` ให้คำนึงถึงความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียกใช้โอเวอร์โหลดผ่านเมธอด [Presentation.getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getFontsManager--) มันจะส่งคืนการแทนที่เท่านั้นที่กำหนดขณะเรนเดอร์สไลด์ที่เลือก แต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsubstitutioninfo/) ที่มีชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์นี้สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎการสำรองที่กำหนด, กฎการแทนที่ที่เก็บไว้ใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsubstrulecollection/), และ [externally loaded fonts](/slides/th/androidjava/custom-font/)

การแทนที่เดียวกันอาจจำเป็นต้องใช้ในสไลด์ที่เลือกหลายสไลด์ ให้ลบข้อมูลซ้ำออกเมื่อคุณสร้างรายการตรวจสอบแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ที่ส่งคืนทั้งหมดและจากนั้นสร้างรายการที่เรียงลำดับของการแมปแบบอักษรที่ไม่ซ้ำกัน:

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

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/) ให้โอเวอร์โหลดทั้งสองแบบ เลือกแบบที่เหมาะกับขอบเขตของการดำเนินการเรนเดอร์:

| โอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบเป็นขั้น ๆ, หรือการส่งออกบางส่วน |

## **ตั้งกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่พร้อมใช้งาน:

1. โหลดการนำเสนอ.
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรแทนที่.
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsubstcondition/).
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. กำหนดคอลเลกชันด้วยการใช้เมธอด [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. เรนเดอร์หรือแปลงการนำเสนอ.

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
สำหรับการเปลี่ยนแปลงแบบไม่มีเงื่อนไขต่อแบบอักษรที่ใช้ทั่วทั้งการนำเสนอ ดูที่ [Font Replacement](/slides/th/androidjava/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานสำหรับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่เข้าถึงได้ด้วยแบบอักษรที่มีตามที่กฎระบุ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math**, Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์เลย์เอาต์ของสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่นเช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** เพื่อวัตถุประสงค์นี้ได้ และการเรนเดอร์อาจยังคงรายงานว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงการนำเสนอแบบนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานใน Aspose.Slides โหลดเป็น [external font](/slides/th/androidjava/custom-font/) เพื่อให้แอปพลิเคชันใช้ได้ระหว่างการเรนเดอร์และการแปลง

ข้อจำกัดนี้ใช้กับเลย์เอาต์ของสมการ กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปของการนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่แบบอักษรและการแทนที่แบบอักษรคืออะไร?**  
[Font replacement](/slides/th/androidjava/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งโดยเจตนาในทั่วทั้งการนำเสนอ การแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดถูกตรงกัน เช่น เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

**กฎการแทนที่ใช้เมื่อใด?**  
กฎเหล่านี้เข้าร่วมใน [font selection sequence](/slides/th/androidjava/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง เมื่อใช้ `WhenInaccessible` กฎจะใช้เฉพาะเมื่อตัว Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นฉบับได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายไปและไม่มีการกำหนดกฎการแทนที่?**  
Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีในสภาพแวดล้อมรันไทม์

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้ไหม?**  
ได้ คุณสามารถ [load external fonts](/slides/th/androidjava/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรมาพร้อมกับไลบรารีหรือไม่?**  
ไม่ คุณเป็นผู้รับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามเงื่อนไขการใช้สิทธิ์ของแบบอักษรเหล่านั้น

**ผลลัพธ์การแทนที่อาจแตกต่างระหว่างอุปกรณ์ Android หรือไม่?**  
ใช่ แบบอักษรระบบที่มีอาจแตกต่างระหว่างเวอร์ชัน Android, อุปกรณ์และผู้ผลิต ดังนั้นแบบอักษรที่มีในสภาพแวดล้อมหนึ่งอาจต้องการการแทนที่ในอีกสภาพแวดล้อมหนึ่ง

**ฉันจะทำให้การเลือกแบบอักษรสอดคล้องกันทั่วอุปกรณ์ Android อย่างไร?**  
รวมไฟล์แบบอักษรที่จำเป็นเดียวกันไว้กับแอปพลิเคชัน, [load them as external fonts](/slides/th/androidjava/custom-font/), และ [embed fonts](/slides/th/androidjava/embedded-font/) เมื่อได้รับอนุญาตตามสัญญาอนุญาต คุณยังสามารถเรียก [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด.