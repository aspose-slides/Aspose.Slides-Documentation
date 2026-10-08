---
title: กำหนดค่าการแทนที่แบบอักษรในงานนำเสนอด้วย PHP
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/php-java/font-substitution/
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
- การนำเสนอ
- PHP
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ PHP ผ่าน Java เมื่อทำการเรนเดอร์หรือแปลงการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อนำเสนอถูกเรนเดอร์หรือแปลง การแทนที่มีผลต่อผลลัพธ์ที่เรนเดอร์; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาการนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรบางตัวไม่พร้อมใช้งาน และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ สิ่งนี้ช่วยให้ผลลัพธ์คงที่ในสภาพแวดล้อมที่มีแบบอักษรติดตั้งต่างกัน

หากแบบอักษรพร้อมใช้งานแต่ไม่มีรูปแบบหนาเฉพาะ ดูที่ [จัดการแบบอักษรที่ไม่มีรูปแบบหนาเฉพาะ](/slides/th/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). ตอนนี้อธิบายวิธีการทำเรสเตอร์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลของการเลือกข้อความ การค้นหา และการปรับขนาด

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) เพื่อระบุว่าแบบอักษรใดจะถูกแทนที่เมื่อการนำเสนอถูกเรนเดอร์ เมธอดจะคืนอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) ที่บ่งบอกชื่อแบบอักษรต้นฉบับและแบบอักษรที่ถูกแทนที่

ตัวอย่าง PHP ด้านล่างแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับการนำเสนอ:

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

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้เมธอด overload ของ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อตรวจสอบการแทนที่เฉพาะที่จำเป็นต้องใช้ในการเรนเดอร์สไลด์ที่ระบุ สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของการนำเสนอ, ตรวจสอบการนำเสนอขนาดใหญ่แบบเพิ่มทีละส่วน, ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มี, เตรียมแพ็คเกจแบบอักษรขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาเรย์ `slides` มีดัชนีสไลด์เริ่มจากหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวเข้าถึงคอลเลกชัน [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) ใช้ดัชนีเริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจะถูกเข้าถึงเป็น `$presentation->getSlides()->get_Item(0)` ควรคำนึงถึงความแตกต่างนี้เมื่อสร้างอาเรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียก overload ผ่านเมธอด [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) ผลลัพธ์จะคืนเฉพาะการแทนที่ที่กำหนดในระหว่างการเรนเดอร์สไลด์ที่เลือก แต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่จัดเก็บใน [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/php-java/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการลบซ้ำผลลัพธ์เมื่อคุณสร้างรายการตรวจสอบแบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ทั้งหมดที่ถูกคืนค่าและจากนั้นสร้างรายการที่เรียงลำดับของการแมปแบบอักษรที่ไม่ซ้ำกัน:

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

คลาส [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) มี overload ทั้งสองตัว ให้เลือกตามขอบเขตของการดำเนินการเรนเดอร์:

| การโอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) ไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) พร้อม `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, ตรวจสอบแบบเพิ่มทีละส่วน, หรือการส่งออกบางส่วน |

## **ตั้งค่ากฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่พร้อมใช้งาน:

1. โหลดการนำเสนอ
2. สร้างการกำหนดค่าแบบอักษรสำหรับแบบอักษรต้นฉบับและแบบอักษรแทนที่
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) ด้วยเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/)
5. กำหนดค่าคอลเลกชันโดยใช้เมธอด [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/)
6. เรนเดอร์หรือแปลงการนำเสนอ

ตัวอย่าง PHP ด้านล่างทำการแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน และจากนั้นเรนเดอร์สไลด์แรกเพื่อยืนยันผล แบบอักษรแทนที่ต้องพร้อมใช้งานกับ Aspose.Slides

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
สำหรับการเปลี่ยนแปลงแบบอักษรทั้งหมดแบบไม่มีเงื่อนไขในการนำเสนอ, ดูที่ [การแทนที่แบบอักษร](/slides/th/php-java/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง ทำงานได้กับข้อความปกติเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่สามารถเข้าถึงได้ด้วยแบบอักษรที่พร้อมใช้งานตามกฎ

สมการ Office Math มีความต้องการเพิ่มเติม หากสมการใช้ **Cambria Math**, Aspose.Slides อาจต้องการฟอนต์นั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์เลย์เอาต์ของสมการ กฎที่แทนที่ฟอนต์คณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้สำหรับวัตถุประสงค์นี้ และการเรนเดอร์อาจยังระบุว่า **Cambria Math** จำเป็นต้องใช้

เพื่อเรนเดอร์หรือแปลงการนำเสนอเช่นนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานกับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/php-java/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดเลย์เอาต์ของสมการ กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความปกติของการนำเสนอ

## **คำถามที่พบบ่อย**

**อะไรคือความแตกต่างระหว่างการแทนที่แบบอักษรและการแทนที่แบบอักษร?**

[การแทนที่แบบอักษร](/slides/th/php-java/font-replacement/) จะเปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วทั้งการนำเสนอ ส่วนการแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรงตาม เช่น เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

**กฎการแทนที่จะถูกนำไปใช้เมื่อไหร่?**

กฎเข้าร่วมใน [ลำดับการเลือกแบบอักษร](/slides/th/php-java/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง เมื่อใช้ `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นฉบับได้

**เกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีอยู่ในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [โหลดแบบอักษรภายนอก](/slides/th/php-java/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามใบอนุญาตของพวกมัน

**ผลลัพธ์การแทนที่อาจแตกต่างกันระหว่าง Windows, Linux และ macOS หรือไม่?**

ได้ ฟอนต์ที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**ฉันจะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงแบบกลุ่มอย่างไร?**

ใช้ไฟล์และเวอร์ชันแบบอักษรเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [โหลดแบบอักษรภายนอกที่จำเป็น](/slides/th/php-java/custom-font/), และ [ฝังแบบอักษร](/slides/th/php-java/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียกใช้ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด