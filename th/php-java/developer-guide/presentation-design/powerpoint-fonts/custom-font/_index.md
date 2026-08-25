---
title: ปรับแต่งแบบอักษร PowerPoint ใน PHP
linktitle: แบบอักษรแบบกำหนดเอง
type: docs
weight: 20
url: /th/php-java/custom-font/
keywords:
- แบบอักษร
- แบบอักษรกำหนดเอง
- แบบอักษรภายนอก
- โหลดแบบอักษร
- จัดการแบบอักษร
- โฟลเดอร์แบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ทำให้คุณสามารถใช้แบบอักษรที่กำหนดเองในงานนำเสนอได้โดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, ให้แบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบนารี

แบบอักษรที่โหลดจะถูกใช้เมื่อทำการแสดงผลหรือส่งออกงานนำเสนอ, เช่น เป็น PDF, ภาพ, หรือรูปแบบอื่นที่รองรับ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสมอมากขึ้นในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรที่กำหนดเองสำหรับการแสดงผลเป็นเรื่องแยกจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการเก็บแบบอักษรไว้ในงานนำเสนอเอง, ให้ใช้ฟีเจอร์การฝังแบบอักษรโดยเจาะจง

ธีมของงานนำเสนอสามารถอ้างอิงฟอนต์ฟา́มิลีต่าง ๆ สำหรับระบบการเขียนแต่ละระบบ การแมปเหล่านี้เก็บชื่อแบบอักษรแต่ไม่ได้ติดตั้งหรือโหลดไฟล์แบบอักษร ดู [แบบอักษรธีมตามสคริปต์](/slides/th/php-java/script-specific-font-mappings/) เพื่อจัดการการแมป, และใช้ตัวเลือกการโหลดด้านล่างเพื่อให้แบบอักษรที่อ้างอิงพร้อมใช้สำหรับการแสดงผลที่สอดคล้องกัน

{{% alert color="info" title="Note" %}}
Aspose Slides ให้คุณโหลดแบบอักษรเหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) และ TrueType Collection (.ttc) ดู [TrueType](https://en.wikipedia.org/wiki/TrueType)

* OpenType (.otf) ดู [OpenType](https://en.wikipedia.org/wiki/OpenType)
{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ทำให้คุณสามารถโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, ภาพ, หรือรูปแบบอื่นที่รองรับ ทำให้เอกสารที่สร้างขึ้นดูสอดคล้องกันในทุกสภาพแวดล้อม แบบอักษรถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอดสแตติก [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและแสดงผล/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader::clearCache](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#clearCache--) เพื่อทำความสะอาดแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:

```php
// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรกำหนดเอง.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// โหลดแบบอักษรกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // แสดงผล/ส่งออกงานนำเสนอ (เช่นเป็น PDF, รูปภาพ, หรือรูปแบบอื่น) โดยใช้แบบอักษรที่โหลดแล้ว.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางการค้นหาแบบอักษร, แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร แบบอักษรจะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/)
{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**
Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#getFontFolders--) เพื่อช่วยคุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้คืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด PHP นี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์แบบอักษร.
# คือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
$fontFolders = FontsLoader::getFontFolders();
```

## **ระบุแบบอักษรที่กำหนดเองที่ใช้ร่วมกับงานนำเสนอ**
Aspose.Slides มีเมธอด [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) เพื่อให้คุณระบุแบบอักษรภายนอกที่จะใช้กับงานนำเสนอ

โค้ด PHP นี้แสดงวิธีใช้เมธอด [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # ทำงานกับงานนำเสนอ
    # CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts และ global\fonts รวมถึงโฟลเดอร์ย่อยของมันสามารถใช้ได้ในงานนำเสนอ
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบนารี

โค้ด PHP นี้แสดงกระบวนการโหลดแบบอักษรจากอาเรย์ไบต์:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # แบบอักษรภายนอกโหลดในช่วงชีวิตของงานนำเสนอ
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **คำถามที่พบบ่อย**

### แบบอักษรที่กำหนดเองส่งผลต่อการส่งออกทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?

ใช่ แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### แบบอักษรที่กำหนดเองจะถูกฝังอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?

ไม่ การลงทะเบียนแบบอักษรเพื่อการแสดงผลไม่เท่ากับการฝังแบบอักษรลงใน PPTX หากต้องการให้แบบอักษรถูกเก็บในไฟล์งานนำเสนอ, คุณต้องใช้ [ฟีเจอร์การฝัง](/slides/th/php-java/embedded-font/)

### สามารถควบคุมพฤติกรรมสำรองเมื่อแบบอักษรที่กำหนดไม่มี glyph บางตัวได้หรือไม่?

ได้ กำหนดค่า [การแทนที่แบบอักษร](/slides/th/php-java/font-substitution/), [กฎการแทนที่](/slides/th/php-java/font-replacement/), และ [ชุดสำรอง](/slides/th/php-java/fallback-font/) เพื่อระบุอย่างชัดเจนว่าแบบอักษรใดจะถูกใช้เมื่อ glyph ที่ร้องขอหายไป

### สามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งระบบได้หรือไม่?

ได้ ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาเรย์ไบต์ ซึ่งจะลดการพึ่งพาโฟลเดอร์แบบอักษรของระบบในอิมเมจคอนเทนเนอร์

### เรื่องลิขสิทธิ์ – สามารถฝังแบบอักษรที่กำหนดเองได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของแบบอักษร เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้งานเชิงพาณิชย์ ตรวจสอบ EULA ของแบบอักษรก่อนจัดจำหน่ายผลลัพธ์