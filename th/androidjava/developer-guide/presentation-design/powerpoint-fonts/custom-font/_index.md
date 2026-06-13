---
title: ปรับแต่งฟอนต์ PowerPoint บน Android
linktitle: ฟอนต์ที่กำหนดเอง
type: docs
weight: 20
url: /th/androidjava/custom-font/
keywords:
- ฟอนต์
- ฟอนต์ที่กำหนดเอง
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
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้ฟอนต์ที่กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์ที่กำหนดเอง, ระบุฟอนต์สำหรับงานนำเสนอเฉพาะผ่าน document-level font sources, หรือโหลดฟอนต์ภายนอกจากข้อมูลไบต์โดยตรง

ฟอนต์ที่โหลดแล้วจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ส่งออกเป็น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์ที่กำหนดเองสำหรับการเรนเดอร์เป็นกระบวนการแยกจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการให้ฟอนต์ถูกจัดเก็บภายในงานนำเสนอเอง ให้ใช้คุณสมบัติการฝังฟอนต์โดยตรง

{{% alert color="primary" %}} 

Aspose Slides ช่วยให้คุณโหลดฟอนต์เหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูเพิ่มเติมที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)

* ฟอนต์ OpenType (.otf) ดูเพิ่มเติมที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)

{{% /alert %}}

## **โหลดฟอนต์ที่กำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ นี่จะมีผลต่อผลลัพธ์การส่งออกเช่น PDF, รูปภาพ, และรูปแบบที่รองรับอื่น ๆ เพื่อให้เอกสารที่ได้มีลักษณะสอดคล้องกันในทุกสภาพแวดล้อม ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและทำการเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsLoader#clearCache--) เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้สาธิตกระบวนการโหลดฟอนต์:

```java
// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์ที่กำหนดเอง.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// โหลดฟอนต์ที่กำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น เป็น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลด.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชฟอนต์หลังจากทำงานเสร็จ.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์
ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์ที่กำหนดเอง**

Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์ฟอนต์.
// เหล่านั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุฟอนต์ที่กำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีพร็อพเพอร์ตี้ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) เพื่อให้คุณระบุฟอนต์ภายนอกที่ต้องการใช้กับงานนำเสนอ

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีใช้ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมันสามารถใช้ในงานนำเสนอได้
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบต์

โค้ด Java ตัวอย่างต่อไปนี้สาธิตกระบวนการโหลดฟอนต์จากอาเรย์ไบต์:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // ฟอนต์ภายนอกที่โหลดในช่วงอายุการทำงานของงานนำเสนอ
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

**ฟอนต์ที่กำหนดเองส่งผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่. ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์เมอร์ในทุกรูปแบบการส่งออก

**ฟอนต์ที่กำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

ไม่. การลงทะเบียนฟอนต์สำหรับการเรนเดอร์ไม่เท่ากับการฝังฟอนต์ลงใน PPTX หากต้องการให้ฟอนต์อยู่ในไฟล์งานนำเสนอเอง ต้องใช้ [embedding features](/slides/th/androidjava/embedded-font/)

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์ที่กำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

ได้. กำหนดค่า [font substitution](/slides/th/androidjava/font-substitution/), [replacement rules](/slides/th/androidjava/font-replacement/), และ [fallback sets](/slides/th/androidjava/fallback-font/) เพื่อระบุฟอนต์ที่ใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

**ฉันสามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งระบบ-wide ได้หรือไม่?**

ได้. เพียงชี้ไปที่โฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาเรย์ไบต์ ซึ่งจะลบการพึ่งพาโฟลเดอร์ฟอนต์ของระบบในอิมเมจคอนเทนเนอร์ออก

**เรื่องลิขสิทธิ์—ฉันสามารถฝังฟอนต์ที่กำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามเงื่อนไขลิขสิทธิ์ของฟอนต์ เงื่อนไขอาจแตกต่างกัน; บางใบอนุญาตห้ามการฝังหรือการใช้งานเพื่อการค้า ตรวจสอบ EULA ของฟอนต์ก่อนนำผลลัพธ์ไปแจกจ่ายเสมอ