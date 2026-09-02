---
title: ปรับแต่งแบบอักษร PowerPoint ใน Java
linktitle: แบบอักษรแบบกำหนดเอง
type: docs
weight: 20
url: /th/java/custom-font/
keywords:
- แบบอักษร
- แบบอักษรกำหนดเอง
- แบบอักษรภายนอก
- โหลดแบบอักษร
- จัดการแบบอักษร
- โฟลเดอร์แบบอักษร
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อให้การนำเสนอของคุณคมชัดและสม่ำเสมอบนอุปกรณ์ใดก็ได้."
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้แบบอักษรที่กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, ให้แบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบต์

แบบอักษรที่โหลดจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ไปเป็น PDF, ภาพ, และรูปแบบอื่น ๆ ที่รองรับ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีลบแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรที่กำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการให้แบบอักษรถูกบันทึกภายในงานนำเสนอเอง ให้ใช้คุณลักษณะการฝังแบบอักษรอย่างชัดเจน

ธีมของงานนำเสนอสามารถอ้างอิงตระกูลแบบอักษรที่แตกต่างกันสำหรับระบบการเขียนแต่ละระบบได้ การแม็พเหล่านี้เก็บชื่อแบบอักษรแต่ไม่ได้ติดตั้งหรือโหลดไฟล์แบบอักษร ดูที่ [Script-Specific Theme Fonts](/slides/th/java/script-specific-font-mappings/) เพื่อจัดการการแม็พ และใช้ตัวเลือกการโหลดด้านล่างเพื่อให้แบบอักษรที่อ้างอิงพร้อมสำหรับการเรนเดอร์ที่สม่ำเสมอ

{{% alert color="info" title="Note" %}}
Aspose Slides ให้คุณโหลดแบบอักษรเหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).
* ฟอนต์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, ภาพ, และรูปแบบที่รองรับอื่น ๆ ทำให้เอกสารที่ได้มีลักษณะสม่ำเสมอในสภาพแวดล้อมต่าง ๆ แบบอักษรถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader#clearCache--) เพื่อลบแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:
```java
import com.aspose.slides.*;

// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรกำหนดเอง.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// โหลดแบบอักษรกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ, หรือรูปแบบอื่น) โดยใช้แบบอักษรที่โหลดแล้ว.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ลบแคชแบบอักษรหลังจากงานเสร็จสิ้น.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาแบบอักษรแต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร
แบบอักษรถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**

Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด Java นี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
import com.aspose.slides.*;

// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์แบบอักษร.
// โฟลเดอร์เหล่านั้นเป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุแบบอักษรที่กำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) เพื่อให้คุณระบุแบบอักษรภายนอกที่จะใช้กับงานนำเสนอ

โค้ด Java นี้แสดงวิธีใช้คุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของพวกมันพร้อมใช้งานสำหรับงานนำเสนอ
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบต์

โค้ด Java นี้แสดงกระบวนการโหลดแบบอักษรจากอาร์เรย์ไบต์:
```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // แบบอักษรภายนอกที่โหลดในช่วงอายุการทำงานของงานนำเสนอ
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

### แบบอักษรที่กำหนดเองมีผลต่อการส่งออกในทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?
ใช่ แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### แบบอักษรที่กำหนดเองจะถูกฝังอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?
ไม่ การลงทะเบียนแบบอักษรสำหรับการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากคุณต้องการให้แบบอักษรถูกบรรจุภายในไฟล์งานนำเสนอ ต้องใช้ [embedding features](/slides/th/java/embedded-font/) อย่างชัดเจน

### ฉันสามารถควบคุมพฤติกรรมการสำรองเมื่อแบบอักษรที่กำหนดเองขาด glyph บางตัวได้หรือไม่?
ได้ กำหนดค่า [font substitution](/slides/th/java/font-substitution/), [replacement rules](/slides/th/java/font-replacement/), และ [fallback sets](/slides/th/java/fallback-font/) เพื่อระบุแบบอักษรที่ใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

### ฉันสามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker ได้โดยไม่ต้องติดตั้งทั่วระบบหรือไม่?
ได้ ให้ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาร์เรย์ไบต์ สิ่งนี้จะลบการพึ่งพาโฟลเดอร์แบบอักษรของระบบในอิมเมจคอนเทนเนอร์ออก

### ส่วนเรื่องลิขสิทธิ์—ฉันสามารถฝังแบบอักษรที่กำหนดเองใด ๆ ได้โดยไม่มีข้อจำกัดหรือไม่?
คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของแบบอักษร เงื่อนไขจะแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของแบบอักษรก่อนเผยแพร่ผลลัพธ์เสมอ