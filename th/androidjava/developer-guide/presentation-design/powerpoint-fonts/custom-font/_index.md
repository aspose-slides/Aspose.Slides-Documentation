---
title: ปรับแต่งฟอนต์ PowerPoint บน Android
linktitle: ฟอนต์กำหนดเอง
type: docs
weight: 20
url: /th/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้พรีเซนเทชันของคุณดูคมชัดและสอดคล้องกันบนทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้ฟอนต์แบบกำหนดเองในงานพรีเซนเทชันโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์ที่กำหนดเอง, จัดหา ฟอนต์สำหรับพรีเซนเทชันเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร, หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบต์

ฟอนต์ที่โหลดจะถูกใช้เมื่องานพรีเซนเทชันถูกเรนเดอร์หรือส่งออก เช่นเป็น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของพรีเซนเทชันคงที่ในสภาพแวดล้อมต่าง ๆ บทความยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์แบบกำหนดเองสำหรับการเรนเดอร์จะแยกจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการเก็บฟอนต์ภายในพรีเซนเทชันเอง ให้ใช้คุณลักษณะการฝังฟอนต์อย่างชัดเจน

{{% alert color="info" %}} 

Aspose Slides ให้คุณโหลดฟอนต์เหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) และ TrueType Collection (.ttc) ฟอนต์. ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) ฟอนต์. ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **โหลดฟอนต์แบบกำหนดเอง**

Aspose.Slides ให้คุณโหลดฟอนต์ที่ใช้ในพรีเซนเทชันโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ เพื่อให้เอกสารที่ได้ดูสม่ำเสมอในสภาพแวดล้อมต่าง ๆ ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกพรีเซนเทชัน
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsLoader#clearCache--) เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```java
import com.aspose.slides.*;

// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// โหลดฟอนต์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // เรนเดอร์/ส่งออกพรีเซนเทชัน (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลด.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชฟอนต์หลังจากทำงานเสร็จ.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนต์, แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์แบบกำหนดเอง**
Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ

โค้ด Java นี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์ฟอนต์.
// นั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุฟอนต์แบบกำหนดเองที่ใช้ร่วมกับพรีเซนเทชัน**
Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) เพื่อให้คุณระบุฟอนต์ภายนอกที่จะใช้ร่วมกับพรีเซนเทชัน

โค้ด Java นี้แสดงวิธีใช้ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // ทำงานกับพรีเซนเทชัน
    // CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมันสามารถใช้ในพรีเซนเทชันได้
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบต์

โค้ด Java นี้แสดงกระบวนการโหลดฟอนต์จากอาเรย์ไบต์:

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
        // ฟอนต์ภายนอกถูกโหลดตลอดอายุการทำงานของพรีเซนเทชัน
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

### ฟอนต์กำหนดเองส่งผลต่อการส่งออกไปยังทุกรูปแบบหรือไม่ (PDF, PNG, SVG, HTML)?

ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### ฟอนต์กำหนดเองถูกฝังอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?

ไม่ การลงทะเบียนฟอนต์เพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้ฟอนต์อยู่ภายในไฟล์พรีเซนเทชัน คุณต้องใช้ [คุณลักษณะการฝัง](/slides/th/androidjava/embedded-font/)

### ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์กำหนดไม่มี glyph บางตัวหรือไม่?

ได้ คุณสามารถตั้งค่า [font substitution](/slides/th/androidjava/font-substitution/), [replacement rules](/slides/th/androidjava/font-replacement/), และ [fallback sets](/slides/th/androidjava/fallback-font/) เพื่อกำหนดว่าฟอนต์ใดจะใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

### ฉันสามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งทั่วระบบได้หรือไม่?

ได้ ให้ชี้ไปยังโฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาเรย์ไบต์ สิ่งนี้จะลบการพึ่งพาโฟลเดอร์ฟอนต์ของระบบในอิมเมจของคอนเทนเนอร์

### แล้วเรื่องลิขสิทธิ์ล่า—ฉันสามารถฝังฟอนต์กำหนดเองใด ๆ ได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนต์ เงื่อนไขแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้ในเชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์เสมอก่อนแจกจ่ายผลลัพธ์