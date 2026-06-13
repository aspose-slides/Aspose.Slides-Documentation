---
title: กำหนดแบบอักษร PowerPoint ใน Java
linktitle: แบบอักษรกำหนดเอง
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "กำหนดแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อทำให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้แบบอักษรกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, จัดหาแบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบต์

แบบอักษรที่โหลดแล้วจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น PDF, ภาพ และรูปแบบที่สนับสนุนอื่น ๆ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ข้ามสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรกำหนดเองสำหรับการเรนเดอร์เป็นเรื่องแยกจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการเก็บแบบอักษรไว้ภายในงานนำเสนอเอง ให้ใช้คุณลักษณะการฝังแบบอักษรอย่างชัดเจน

{{% alert color="primary" %}} 

Aspose Slides อนุญาตให้คุณโหลดแบบอักษรเหล่านี้ด้วยเมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* แบบอักษร TrueType (.ttf) และ TrueType Collection (.ttc) ดูข้อมูลเพิ่มเติมที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).
* แบบอักษร OpenType (.otf) ดูข้อมูลเพิ่มเติมที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **โหลดแบบอักษรกำหนดเอง**

Aspose.Slides อนุญาตให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, ภาพ, และรูปแบบที่สนับสนุนอื่น ๆ ทำให้เอกสารที่ได้ดูสอดคล้องกันข้ามสภาพแวดล้อมต่าง ๆ แบบอักษรถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader#clearCache--) เพื่อล้างแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:

```java
// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรกำหนดเอง.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// โหลดแบบอักษรกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, ภาพ, หรือรูปแบบอื่น) ด้วยแบบอักษรที่โหลดไว้.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="หมายเหตุ" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) จะเพิ่มโฟลเดอร์เพิ่มเติมลงในเส้นทางค้นหาแบบอักษร แต่จะไม่เปลี่ยนลำดับการเริ่มต้นแบบอักษร  
แบบอักษรถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรกำหนดเอง**

Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้จะคืนค่าโฟลเดอร์ที่ถูกเพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด Java ต่อไปนี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์แบบอักษร.
// เหล่านั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุแบบอักษรกำหนดเองสำหรับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) เพื่อให้คุณระบุแบบอักษรภายนอกที่ใช้ร่วมกับงานนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีใช้คุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมัน พร้อมใช้งานในงานนำเสนอ
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการแบบอักษรภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบต์

โค้ด Java ต่อไปนี้แสดงกระบวนการโหลดแบบอักษรจากอาร์เรย์ไบต์:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // แบบอักษรภายนอกที่โหลดในช่วงอายุของการนำเสนอ
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

**แบบอักษรกำหนดเองส่งผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่. แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์สำหรับทุกรูปแบบการส่งออก

**แบบอักษรกำหนดเองจะถูกฝังอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

ไม่. การลงทะเบียนแบบอักษรสำหรับการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้แบบอักษรถูกเก็บอยู่ในไฟล์งานนำเสนอ ต้องใช้คุณลักษณะการ [ฝังแบบอักษร](/slides/th/java/embedded-font/)

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อแบบอักษรกำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

ได้. ตั้งค่า [การทดแทนแบบอักษร](/slides/th/java/font-substitution/), [กฎการแทนที่](/slides/th/java/font-replacement/), และ [ชุด fallback](/slides/th/java/fallback-font/) เพื่อกำหนดว่าจะใช้แบบอักษรใดเมื่อ glyph ที่ต้องการขาดหาย

**ฉันสามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งในระบบหรือไม่?**

ได้. ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาร์เรย์ไบต์ วิธีนี้จะลบการพึ่งพาโฟลเดอร์แบบอักษรระบบออกจากอิมเมจคอนเทนเนอร์

**เรื่องลิขสิทธิ์—ฉันสามารถฝังแบบอักษรกำหนดเองใด ๆ ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามเงื่อนไขลิขสิทธิ์ของแบบอักษร เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์หากันการฝังหรือการใช้งานเชิงพาณิชย์ ตรวจสอบข้อตกลง EULA ของแบบอักษรก่อนแจกจ่ายผลลัพธ์.