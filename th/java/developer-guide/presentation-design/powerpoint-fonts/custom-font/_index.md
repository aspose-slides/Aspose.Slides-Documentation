---
title: ปรับแต่งฟอนต์ PowerPoint ใน Java
linktitle: ฟอนต์กำหนดเอง
type: docs
weight: 20
url: /th/java/custom-font/
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
- Java
- Aspose.Slides
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้ฟอนต์กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์กำหนดเอง, จัดหาไฟล์ฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร, หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบท์

ฟอนต์ที่โหลดจะถูกใช้เมื่อมีการเรนเดอร์หรือส่งออกงานนำเสนอ เช่นเป็น PDF, รูปภาพ และรูปแบบที่รองรับอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์กำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังฟอนต์เข้าไฟล์ PPTX หากต้องการให้ฟอนต์ถูกเก็บไว้ในงานนำเสนอเอง ต้องใช้คุณสมบัติการฝังฟอนต์อย่างชัดเจน

ธีมของงานนำเสนอสามารถอ้างอิงฟอนต์แฟมิลีย์ที่แตกต่างกันสำหรับระบบการเขียนแต่ละระบบ การแมปเหล่านี้จะเก็บชื่อฟอนต์ไว้แต่ไม่ได้ติดตั้งหรือโหลดไฟล์ฟอนต์ ดูที่ [Script-Specific Theme Fonts](/slides/th/java/script-specific-font-mappings/) เพื่อจัดการการแมป และใช้ตัวเลือกการโหลดด้านล่างเพื่อให้ฟอนต์ที่อ้างอิงพร้อมสำหรับการเรนเดอร์ที่สอดคล้องกัน

{{% alert color="info" title="Note" %}}
Aspose Slides ให้คุณโหลดฟอนต์เหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)

* ฟอนต์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)
{{% /alert %}}

## **โหลดฟอนต์กำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ และรูปแบบที่รองรับอื่น ๆ ทำให้เอกสารที่ได้มีลักษณะสอดคล้องกันในสภาพแวดล้อมต่าง ๆ ฟอนต์จะถูกโหลดจากไดเรกทอรีกำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์อยู่
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#clearCache--) เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```java
import com.aspose.slides.*;

// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์กำหนดเอง.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// โหลดฟอนต์กำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดไว้.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชฟอนต์หลังจากทำงานเสร็จ.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมลงในเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/)
{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์ที่กำหนดเอง**
Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--) ให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์ฟอนต์.
// เป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุฟอนต์กำหนดเองที่ใช้ร่วมกับงานนำเสนอ**
Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ให้คุณระบุฟอนต์ภายนอกที่จะใช้ร่วมกับงานนำเสนอ

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีใช้คุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของพวกมันพร้อมใช้งานในงานนำเสนอ
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบท์

โค้ด Java ตัวอย่างต่อไปนี้แสดงกระบวนการโหลดฟอนต์จากอาร์เรย์ไบท์:

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
        // ฟอนต์ภายนอกที่โหลดในช่วงอายุของงานนำเสนอ
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

### ฟอนต์กำหนดเองมีผลต่อการส่งออกเป็นทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?
ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### ฟอนต์กำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?
ไม่ การลงทะเบียนฟอนต์เพื่อการเรนเดอร์ไม่เท่ากับการฝังฟอนต์ลงใน PPTX หากต้องการให้ฟอนต์อยู่ภายในไฟล์งานนำเสนอต้องใช้ [คุณสมบัติการฝังฟอนต์](/slides/th/java/embedded-font/)

### สามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์กำหนดเองไม่มี glyph บางตัวได้หรือไม่?
ได้ ตั้งค่า [font substitution](/slides/th/java/font-substitution/), [replacement rules](/slides/th/java/font-replacement/), และ [fallback sets](/slides/th/java/fallback-font/) เพื่อกำหนดว่าฟอนต์ใดจะใช้เมื่อ glyph ที่ต้องการหายไป

### สามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งระบบได้หรือไม่?
บางส่วน Aspose.Slides สามารถใช้ฟอนต์จากโฟลเดอร์ของคุณหรือจากอาร์เรย์ไบท์โดยไม่ต้องติดตั้งบนระบบ แต่ Java ยังต้องการอย่างน้อยหนึ่งฟอนต์ที่ติดตั้งในอิมเมจ หากไม่มีจะเกิดข้อผิดพลาด “Fontconfig head is null, check your fonts or fonts configuration” ดูที่ [Deploy Fonts](/slides/th/java/deploy-fonts/)

### เรื่องลิขสิทธิ์—สามารถฝังฟอนต์กำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?
คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนต์ เงื่อนไขอาจแตกต่างกัน บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์ก่อนนำผลลัพธ์ไปเผยแพร่