---
title: "ปรับแต่งแบบอักษร PowerPoint ใน Java"
linktitle: "แบบอักษรที่กำหนดเอง"
type: docs
weight: 20
url: /th/java/custom-font/
keywords:
- "แบบอักษร"
- "แบบอักษรที่กำหนดเอง"
- "แบบอักษรภายนอก"
- "โหลดแบบอักษร"
- "จัดการแบบอักษร"
- "โฟลเดอร์แบบอักษร"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อให้การนำเสนอของคุณคมชัดและสม่ำเสมอในทุกอุปกรณ์"
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้แบบอักษรที่กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, จัดหาแบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบนารี

แบบอักษรที่โหลดแล้วจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ, เช่นเป็น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่นๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ข้ามสภาพแวดล้อมต่างๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรที่กำหนดเองสำหรับการเรนเดอร์เป็นขั้นตอนที่แยกจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการให้แบบอักษรถูกเก็บไว้ภายในงานนำเสนอเอง ให้ใช้คุณสมบัติการฝังแบบอักษรอย่างชัดเจน

{{% alert color="info" %}}

Aspose Slides ให้คุณโหลดแบบอักษรเหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* แบบ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).

* แบบ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก—เช่น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่นๆ—เพื่อให้เอกสารที่ได้ดูสม่ำเสมอข้ามสภาพแวดล้อมต่างๆ แบบอักษรถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอด static [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและทำการเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader#clearCache--) เพื่อล้างแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:

```java
import com.aspose.slides.*;

// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรที่กำหนดเอง.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่นเป็น PDF, รูปภาพ, หรือรูปแบบอื่น) โดยใช้แบบอักษรที่โหลดไว้.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางค้นหาแบบอักษร, แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร
แบบอักษรถูกเริ่มต้นในลำดับดังนี้:

1. เส้นทางแบบอักษรของระบบปฏิบัติการเริ่มต้น
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**

Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้คืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด Java นี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์แบบอักษร.
// เหล่านั้นเป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุแบบอักษรที่กำหนดเองสำหรับงานนำเสนอ**

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
    // CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมัน สามารถใช้ในงานนำเสนอได้
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบนารี

โค้ด Java นี้แสดงกระบวนการโหลดแบบอักษรจากอาเรย์ไบต์:

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
        // ฟอนต์ภายนอกที่โหลดระหว่างอายุการทำงานของงานนำเสนอ
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

### แบบอักษรที่กำหนดเองส่งผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?

ใช่. แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### แบบอักษรที่กำหนดเองจะถูกฝังโดยอัตโนมัติใน PPTX ที่ได้หรือไม่?

ไม่. การลงทะเบียนแบบอักษรสำหรับการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้แบบอักษรถูกเก็บไว้ในไฟล์งานนำเสนอ คุณต้องใช้ [embedding features](/slides/th/java/embedded-font/) อย่างชัดเจน.

### ฉันสามารถควบคุมพฤติกรรม fallback เมื่อแบบอักษรที่กำหนดไม่มี glyph บางตัวได้หรือไม่?

ได้. ตั้งค่า [font substitution](/slides/th/java/font-substitution/), [replacement rules](/slides/th/java/font-replacement/), และ [fallback sets](/slides/th/java/fallback-font/) เพื่อกำหนดอย่างชัดเจนว่าแบบอักษรใดจะถูกใช้เมื่อ glyph ที่ร้องขอไม่มีในแบบอักษร

### ฉันสามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งบนระบบทั้งหมดได้หรือไม่?

ได้. ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาเรย์ไบต์ จะทำให้ไม่ต้องพึ่งพาไดเรกทอรีแบบอักษรของระบบในภาพคอนเทนเนอร์

### เรื่องลิขสิทธิ์ละ—ฉันสามารถฝังแบบอักษรที่กำหนดเองใดก็ได้โดยไม่จำกัดหรือไม่?

คุณเป็นผู้รับผิดชอบการปฏิบัติตามลิขสิทธิ์ของแบบอักษร ข้อกำหนดจะแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของแบบอักษรก่อนแจกจ่ายผลลัพธ์เสมอ