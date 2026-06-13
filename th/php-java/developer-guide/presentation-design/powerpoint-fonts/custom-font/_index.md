---
title: ปรับแต่งแบบอักษร PowerPoint ใน PHP
linktitle: ฟอนต์กำหนดเอง
type: docs
weight: 20
url: /th/php-java/custom-font/
keywords:
- ฟอนต์
- ฟอนต์กำหนดเอง
- ฟอนต์ภายนอก
- โหลดฟอนต์
- จัดการฟอนต์
- โฟลเดอร์ฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "กำหนดแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันบนทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้แบบอักษรที่กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, จัดหาฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร, หรือโหลดฟอนต์ภายนอกจากข้อมูลไบต์โดยตรง

ฟอนต์ที่โหลดแล้วจะถูกใช้เมื่อเรนเดอร์หรือส่งออกงานนำเสนอ เช่น เป็น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสมอไปในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์ที่กำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการเก็บฟอนต์ไว้ภายในงานนำเสนอเอง ให้ใช้คุณลักษณะการฝังฟอนต์โดยตรง

{{% alert color="primary"%}} 
Aspose Slides ให้คุณโหลดฟอนต์เหล่านี้โดยใช้วิธี [loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) และ TrueType Collection (.ttc) ฟอนต์ ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf) ฟอนต์ ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ ทำให้เอกสารที่สร้างออกมามีลักษณะสม่ำเสมอระหว่างสภาพแวดล้อม ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่บรรจุไฟล์ฟอนต์  
2. เรียกเมธอดสแตติก [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น  
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ  
4. เรียกเมธอด [FontsLoader::clearCache](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#clearCache--) เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```php
// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์กำหนดเอง.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// โหลดฟอนต์กำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดไว้.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // ล้างแคชฟอนต์หลังจากงานเสร็จสิ้น.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="หมายเหตุ"%}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางค้นหาฟอนต์ แต่ไม่เปลี่ยนลำดับการเริ่มต้นฟอนต์  
ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ  
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/)  

{{%/alert%}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**

Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด PHP นี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์ฟอนต์.
# โฟลเดอร์เหล่านั้นถูกเพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
$fontFolders = FontsLoader::getFontFolders();
```

## **ระบุแบบอักษรที่กำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีเมธอด [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) เพื่อให้คุณระบุฟอนต์ภายนณะที่จะใช้กับงานนำเสนอ

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
    # ทำงานกับการนำเสนอ
    # CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของพวกมัน สามารถใช้ได้ในงานนำเสนอ
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบต์

โค้ด PHP นี้แสดงกระบวนการโหลดฟอนต์จากอาร์เรย์ไบต์:

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
        # ฟอนต์ภายนอกที่โหลดในช่วงอายุของการนำเสนอ
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

**ฟอนต์ที่กำหนดเองส่งผลต่อการส่งออกเป็นทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**  
ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยตัวเรนเดอร์ในทุกรูปแบบการส่งออก

**ฟอนต์ที่กำหนดเองจะถูกฝังอัตโนมัติใน PPTX ที่ได้หรือไม่?**  
ไม่ การลงทะเบียนฟอนต์สำหรับการเรนเดอร์ไม่ได้หมายถึงการฝังลงใน PPTX หากต้องการให้ฟอนต์อยู่ภายในไฟล์งานนำเสนอ ต้องใช้คุณลักษณะการฝังฟอนต์โดยชัดเจน ([embedding features](/slides/th/php-java/embedded-font/))

**สามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์ที่กำหนดไม่มี glyph บางตัวได้หรือไม่?**  
ใช่ สามารถกำหนด [font substitution](/slides/th/php-java/font-substitution/), [replacement rules](/slides/th/php-java/font-replacement/), และ [fallback sets](/slides/th/php-java/fallback-font/) เพื่อระบุฟอนต์ที่จะใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

**สามารถใช้ฟอนต์ใน Linux/Docker container ได้โดยไม่ต้องติดตั้งบนระบบหรือไม่?**  
ใช่ เพียงชี้ไปที่โฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาร์เรย์ไบต์ จะทำให้ไม่พึ่งพาโฟลเดอร์ฟอนต์ของระบบในภาพคอนเทนเนอร์

**เรื่องลิขสิทธิ์—สามารถฝังฟอนต์ที่กำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**  
คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนต์ เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามฝังหรือห้ามใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์ก่อนนำผลลัพธ์ไปเผยแพร่