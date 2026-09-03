---
title: ฝังฟอนต์ในงานนำเสนอโดยใช้ PHP
linktitle: ฟอนต์ที่ฝังไว้
type: docs
weight: 40
url: /th/php-java/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- ดึงฟอนต์ที่ฝังไว้
- เพิ่มฟอนต์ที่ฝังไว้
- ลบฟอนต์ที่ฝังไว้
- บีบอัดฟอนต์ที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการฟอนต์ที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพิ่ม ดึง ลบ และบีบอัดฟอนต์เพื่อรักษารูปแบบข้อความและลดขนาดไฟล์."
---
## **บทนำ**

การฝังฟอนต์จะเก็บข้อมูลฟอนต์ไว้ภายในไฟล์การนำเสนอ PowerPoint เมื่อโปรแกรมดูสนับสนุนฟอนต์ที่ฝังไว้ มันจะสามารถแสดงข้อความโดยใช้ฟอนต์เหล่านั้นแม้ว่าไม่ได้ติดตั้งบนระบบเป้าหมาย การทำเช่นนี้ช่วยรักษาการตัดบรรทัด การจัดช่องว่างของข้อความ และการจัดรูปแบบสไลด์

Aspose.Slides for PHP via Java ช่วยให้คุณเรียกคืน เพิ่ม และลบฟอนต์ที่ฝังไว้ผ่านคลาส [FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/) ที่ได้รับจาก [Presentation::getFontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getFontsManager) คุณยังสามารถลดขนาดข้อมูลฟอนต์ที่ฝังไว้โดยการลบอักขระที่การนำเสนอไม่ได้ใช้

ตัวอย่างต่อไปนี้ทำงานกับไฟล์ PPTX ก่อนที่จะฝังฟอนต์ อย่าลืมตรวจสอบว่าข้อมูลฟอนต์พร้อมใช้งานสำหรับ Aspose.Slides และใบอนุญาตของฟอนต์อนุญาตให้ฝังได้

## **รับและลบฟอนต์ที่ฝังไว้**

ใช้ [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) เพื่อแสดงรายการฟอนต์ที่จัดเก็บไว้ในงานนำเสนอ เพื่อจะลบฟอนต์หนึ่ง ให้ส่งฟอนต์จากรายการนั้นไปยัง [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้แสดงรายการฟอนต์ที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบ Calibri หากพบอยู่:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

การลบฟอนต์ที่ฝังไว้จะทำการลบข้อมูลฟอนต์ที่จัดเก็บไว้; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับข้อความ หากฟอนต์ติดตั้งบนระบบเป้าหมาย ข้อความยังสามารถใช้ฟอนต์นั้นได้ มิฉะนั้น การเรนเดอร์อาจต้องใช้ [font substitution](/slides/th/php-java/font-substitution/) ซึ่งอาจส่งผลต่อการจัดวาง

## **ตรวจสอบข้อมูลฟอนต์และสิทธิ์การฝัง**

ใช้คลาส [FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/) เพื่อตรวจสอบฟอนต์ก่อนทำการฝัง เรียกใช้ [FontsManager::getFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getFonts) เพื่อดึงฟอนต์ที่ใช้ในงานนำเสนอ สำหรับแต่ละฟอนต์ ให้ส่งอ็อบเจ็กต์ [FontData](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontdata/) และค่าที่ต้องการของ [FontStyleType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontstyletype/) ไปยัง [FontsManager::getFontBytes](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getFontBytes) เมธอดนี้จะคืนค่าข้อมูลไบนารีของสไตล์ฟอนต์นั้น หรือ `null` เมื่อฟอนต์หรือสไตล์ที่ขอไม่มีอยู่ อย่าส่งผลลัพธ์ `null` ไปยัง [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) เนื่องจากเมธอดนั้นต้องการอาร์เรย์ไบต์

[EmbeddingLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/embeddinglevel/) เป็นการกำหนดค่าแบบแฟล็กที่รายงานข้อจำกัดการฝังที่เก็บไว้ในฟอนต์:
- `Installable` อนุญาตให้ฝังและติดตั้งถาวรบนระบบอื่นตามเงื่อนไขของใบอนุญาตฟอนต์
- `Restricted` ห้ามฝังเว้นแต่จะได้รับอนุญาตจากเจ้าของลิขสิทธิ์ฟอนต์เมื่อเป็นแฟล็กสิทธิ์การใช้งานเดียว
- `PreviewPrint` อนุญาตให้ใช้ชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีฟอนต์ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตให้ใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังเฉพาะส่วนย่อยของ glyphs. ต้องฝังทุกอักขระเมื่อมีแฟล็กนี้
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเฉพาะ bitmap strikes เท่านั้น ไม่ใช่ข้อมูล outlines. หากฟอนต์ไม่มี bitmap strikes จะไม่สามารถฝังได้

สี่ค่าตัวแรกอธิบายสิทธิ์การใช้งาน ส่วน `NoSubsetting` และ `BitmapOnly` สามารถรวมกับค่าต่าง ๆ ได้ ตรวจสอบตัวแก้ไขด้วยการดำเนินการบิตวายส์ เนื่องจาก `Installable` มีค่าเป็นศูนย์ ให้ทำการมาสก์บิตสิทธิ์การใช้งานและเปรียบเทียบผลลัพธ์กับ `Installable` แทนการตรวจสอบเป็นแฟล็ก ฟอนต์ปัจจุบันควรกำหนดบิตสิทธิ์การใช้งานไม่เกินหนึ่งบิต เพื่อความเข้ากันได้กับฟอนต์รุ่นเก่าที่กำหนดมากกว่าหนึ่งบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนปรนที่สุด: `Editable` แล้วตามด้วย `PreviewPrint` แล้วตามด้วย `Restricted`

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลปกติ, ตัวหนา, ตัวเอียง, และตัวหนาเอียงของฟอนต์ทุกตัวที่ `FontsManager::getFonts` คืนค่า มันจะข้ามสไตล์ที่ไม่พร้อมใช้งาน, ฟอนต์ที่จำกัด, ฟอนต์ bitmap‑only, ฟอนต์ที่จำกัดให้ดูและพิมพ์เท่านั้นเนื่องจากผลลัพธ์ยังคงแก้ไขได้, และฟอนต์ที่ฝังไว้แล้ว หากสไตล์ใดสไตล์หนึ่งมี `NoSubsetting` จะฝังทุกอักขระสำหรับตระกูลฟอนต์นั้น
```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์ฟอนต์ มันไม่ได้ให้สิทธิ์ใบอนุญาต, พิสูจน์ว่าคุณได้ฟอนต์อย่างถูกกฎหมาย, หรือแทนที่การตรวจสอบสัญญาใบอนุญาตของฟอนต์ก่อนแจกจ่ายสำเนาที่ฝังไว้

## **เพิ่มฟอนต์ที่ฝังไว้**

ใช้ [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) เพื่อฝังฟอนต์ การโอเวอร์โหลดรับอ็อบเจ็กต์ [FontData](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontdata/) หรืออาร์เรย์ไบต์ที่มีข้อมูลฟอนต์ [EmbedFontCharacters](https://reference.aspose.com/slides/th/php-java/aspose.slides/embedfontcharacters/) เป็นการกำหนดค่าว่าอักขระใดจะรวมอยู่:
- [All](https://reference.aspose.com/slides/th/php-java/aspose.slides/embedfontcharacters/) ฝังทุกอักขระในฟอนต์ ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและพิมพ์ข้อความใหม่
- [OnlyUsed](https://reference.aspose.com/slides/th/php-java/aspose.slides/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อลดขนาดไฟล์ เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมุ่งเน้นการดูเป็นหลัก

ตัวอย่างต่อไปนี้ใช้ [FontsManager::getFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getFonts) เพื่อดึงฟอนต์ที่ใช้ใน `Fonts.pptx` และฝังฟอนต์ที่ยังไม่ได้ฝัง ฟอนต์ที่จะเพิ่มต้องพร้อมใช้งานบนเครื่องที่รันโค้ด ฟอนต์ที่ฝังอยู่แล้วจะคงชุดอักขระปัจจุบันไว้
```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **บีบอัดฟอนต์ที่ฝังไว้**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#compressEmbeddedFonts) ลดข้อมูลฟอนต์ที่ฝังไว้โดยลบอักขระที่ไม่ได้ใช้ มันทำงานกับฟอนต์ที่ฝังไว้แล้ว ดังนั้นการลดขนาดขึ้นอยู่กับจำนวนข้อมูลฟอนต์ที่ไม่ได้ใช้ในงานนำเสนอ

ตัวอย่างต่อไปนี้จะบีบอัดฟอนต์ใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก:
```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องเพิ่มข้อความในภายหลัง อักขระที่ลบระหว่างการบีบอัดจะไม่มีอยู่ในฟอนต์ที่ฝังแล้ว แม้ว่าคุณจะฝังทุกอักขระตั้งแต่แรก

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ที่ฝังไว้จะยังถูกแทนที่ระหว่างการเรนเดอร์หรือไม่?**

เรียกใช้ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getSubstitutions) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูฟอนต์ที่ Aspose.Slides จะเปลี่ยน นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/php-java/font-substitution/) และกฎ [font fallback](/slides/th/php-java/fallback-font/) การ fallback จะจัดการอักขระที่หายไป ดังนั้นการฝังฟอนต์จะไม่แก้ไขอักขระที่ฟอนต์เองไม่มี

**ฉันควรฝังฟอนต์ทั่วไปเช่น Arial และ Calibri หรือไม่?**

ให้ตัดสินใจตามสภาพแวดล้อมเป้าหมาย หากฟอนต์ที่ต้องการมีอยู่บนทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจทำให้ไฟล์ใหญ่เกินความจำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีฟอนต์เหล่านั้น การฝังฟอนต์ช่วยรักษารูปแบบที่ต้องการได้ ตราบใดที่ใบอนุญาตของฟอนต์อนุญาต