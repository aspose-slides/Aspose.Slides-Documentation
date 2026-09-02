---
title: "กำหนดค่าการทดแทนแบบอักษรในการนำเสนอโดยใช้ PHP"
linktitle: "การทดแทนแบบอักษร"
type: docs
weight: 70
url: /th/php-java/font-substitution/
keywords:
- แบบอักษร
- แทนแบบอักษร
- การทดแทนแบบอักษร
- แทนที่แบบอักษร
- การแทนที่แบบอักษร
- กฎการทดแทน
- กฎการแทนที่
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "กำหนดกฎการทดแทนแบบอักษรและตรวจสอบแบบอักษรที่ถูกทดแทนใน Aspose.Slides สำหรับ PHP ผ่าน Java เมื่อทำการเรนเดอร์หรือแปลงการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การทดแทนแบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อการนำเสนอถูกเรนเดอร์หรือแปลง การทดแทนนี้มีผลต่อผลลัพธ์ที่เรนเดอร์; มันไม่ทำการเปลี่ยนแปลงแบบอักษรที่กำหนดให้กับเนื้อหาการนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรบางตัวไม่ได้อยู่ และคุณสามารถตรวจสอบการทดแทนที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ได้ สิ่งนี้ช่วยให้ผลลัพธ์คงที่ในสภาพแวดล้อมที่มีแบบอักษรติดตั้งต่างกัน

## **รับการทดแทนแบบอักษร**

ใช้เมธอด [FontsManager::getSubstitutions](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getsubstitutions/) เพื่อกำหนดว่าแบบอักษรใดจะถูกทดแทนเมื่อการนำเสนอถูกเรนเดอร์ เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsubstitutioninfo/) ซึ่งระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่ถูกทดแทน

ตัวอย่าง PHP ด้านล่างจะแสดงการทดแทนแบบอักษรทั้งหมดสำหรับการนำเสนอ:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **รับการทดแทนแบบอักษรสำหรับสไลด์ที่เลือก**

ใช้เมธอดโอเวอร์โหลดของ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getsubstitutions/) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อดูการทดแทนที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะเท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนหนึ่งของการนำเสนอ ตรวจสอบการนำเสนอขนาดใหญ่เป็นขั้นเป็นตอน ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่สามารถเข้าถึงได้ เตรียมแพคเกจแบบอักษรขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์ที่เริ่มจาก 1: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation::getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) ใช้การจัดทำดัชนีเริ่มจาก 0 ดังนั้นสไลด์เดียวกันจะถูกเข้าถึงเป็น `$presentation->getSlides()->get_Item(0)` อย่าลืมคำนึงถึงความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียกโอเวอร์โหลดผ่านเมธอด [Presentation::getFontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getFontsManager) มันจะคืนค่าการทดแทนที่กำหนดระหว่างการเรนเดอร์สไลด์ที่เลือกแต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อแบบอักษรต้นฉบับและแบบอักษรที่ถูกทดแทน ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน กฎ fallback ที่กำหนดไว้ กฎการทดแทนที่จัดเก็บไว้ใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsubstrulecollection/) และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/php-java/custom-font/)

การทดแทนเดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการลบข้อมูลซ้ำเมื่อคุณสร้างรายการแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้จะแสดงการรายงานการทดแทนที่คืนค่าแล้วสร้างรายการแบบอักษรที่แมปแบบไม่ซ้ำและเรียงลำดับ:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

คลาส [FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/) มีโอเวอร์โหลดทั้งสองแบบ ให้เลือกตามขอบเขตของการทำงานเรนเดอร์:

| การโอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getsubstitutions/) โดยไม่มีอาร์กิวเมนต์ | คุณต้องการการทดแทนสำหรับการนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getsubstitutions/) พร้อม `int[] slides` | คุณต้องการการทดแทนสำหรับช่วงเลือก การตรวจสอบแบบขั้นเป็นขั้น หรือการส่งออกบางส่วน |

## **กำหนดกฎการทดแทนแบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่สามารถเข้าถึงได้:

1. โหลดการนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นฉบับและแบบอักษรทดแทน
3. สร้างอ็อบเจ็กต์ [FontSubstRule](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/)
6. เรนเดอร์หรือแปลงการนำเสนอ

ตัวอย่าง PHP ด้านล่างจะทดแทน `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน จากนั้นเรนเดอร์สไลด์แรกเพื่อตรวจสอบผลลัพธ์ แบบอักษรทดแทนต้องพร้อมใช้งานสำหรับ Aspose.Slides

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงแบบอักษรโดยไม่มีเงื่อนไขทั่วทั้งการนำเสนอ โปรดดูที่ [Font Replacement](/slides/th/php-java/font-replacement/)
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการทดแทนแบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานได้กับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่สามารถเข้าถึงได้ด้วยแบบอักษรที่กำหนดไว้ในกฎ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์การจัดรูปสมการ กฎที่ทดแทนแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ในกรณีนี้ได้ และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงการนำเสนอที่มีลักษณะเช่นนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานสำหรับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/php-java/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดรูปสมการ กฎการทดแทนที่อธิบายข้างต้นยังคงใช้ได้กับข้อความปกติในการนำเสนอ

## **FAQ**

**ความแตกต่างระหว่างการเปลี่ยนแบบอักษรและการทดแทนแบบอักษรคืออะไร?**

[Font replacement](/slides/th/php-java/font-replacement/) จะเปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วทั้งการนำเสนออย่างตั้งใจ ส่วนการทดแทนแบบอักษรจะเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดไว้เป็นจริง เช่น เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

**กฎการทดแทนจะถูกนำไปใช้เมื่อใด?**

กฎจะมีส่วนร่วมใน [ลำดับการเลือกแบบอักษร](/slides/th/php-java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง ด้วย `WhenInaccessible` กฎจะใช้ก็ต่อเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นฉบับได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการทดแทน?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษร ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีในสภาพแวดล้อมรันไทม์

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการทดแทนได้หรือไม่?**

ได้ คุณสามารถ [โหลดแบบอักษรภายนอก](/slides/th/php-java/custom-font/) เพื่อให้ Aspose.Slides ใช้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรพร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามลิขสิทธิ์ของแบบอักษรเหล่านั้น

**ผลลัพธ์การทดแทนอาจแตกต่างระหว่าง Windows, Linux และ macOS หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่พร้อมใช้บนเครื่องหนึ่งอาจต้องการการทดแทนบนเครื่องอื่น

**จะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงเป็นชุดได้อย่างไร?**

ใช้ไฟล์และเวอร์ชันแบบอักษรเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์ [โหลดแบบอักษรภายนอกที่จำเป็น](/slides/th/php-java/custom-font/) และ [ฝังแบบอักษร](/slides/th/php-java/embedded-font/) เมื่อได้รับอนุญาตตามสัญญาอนุญาต คุณยังสามารถเรียก [FontsManager::getSubstitutions](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/getsubstitutions/) ก่อนการส่งออกเพื่อระบุการทดแทนที่ไม่คาดคิด)