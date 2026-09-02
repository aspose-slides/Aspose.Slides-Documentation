---
title: ปรับแต่งฟอนท์ PowerPoint บน Android
linktitle: ฟอนท์แบบกำหนดเอง
type: docs
weight: 20
url: /th/androidjava/custom-font/
keywords:
- ฟอนท์
- ฟอนท์แบบกำหนดเอง
- ฟอนท์ภายนอก
- โหลดฟอนท์
- จัดการฟอนท์
- โฟลเดอร์ฟอนท์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับแต่งฟอนท์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันบนอุปกรณ์ใดก็ได้."
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้ฟอนท์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนท์จากโฟลเดอร์แบบกำหนดเอง, ให้ฟอนท์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนท์ระดับเอกสาร, หรือโหลดฟอนท์ภายนอกจากข้อมูลไบต์ได้โดยตรง.

ฟอนท์ที่โหลดจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่นเป็น PDF, ภาพ, และรูปแบบอื่นที่รองรับ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ระหว่างสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนท์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนท์หลังจากทำงานกับฟอนท์ภายนอก.

การลงทะเบียนฟอนท์แบบกำหนดเองสำหรับการเรนเดอร์เป็นกระบวนการแยกจากการฝังฟอนท์ลงในไฟล์ PPTX หากต้องการเก็บฟอนท์ไว้ในงานนำเสนอเอง จำเป็นต้องใช้คุณสมบัติการฝังฟอนท์อย่างชัดเจน.

ธีมงานนำเสนอสามารถอ้างอิงตระกูลฟอนท์ที่แตกต่างกันสำหรับระบบเขียนแต่ละระบบ การแมปนี้จะเก็บชื่อฟอนท์เท่านั้น โดยไม่ทำการติดตั้งหรือโหลดไฟล์ฟอนท์ ดูที่ [ฟอนท์ธีมตามสคริปต์](/slides/th/androidjava/script-specific-font-mappings/) เพื่อจัดการการแมป และใช้ตัวเลือกการโหลดด้านล่างเพื่อให้ฟอนท์ที่อ้างอิงพร้อมสำหรับการเรนเดอร์ที่สอดคล้องกัน.

{{% alert color="info" title="หมายเหตุ" %}}
Aspose Slides ให้คุณโหลดฟอนท์เหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* ฟอนท์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).

* ฟอนท์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **โหลดฟอนท์แบบกำหนดเอง**

Aspose.Slides ให้คุณโหลดฟอนท์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ การทำเช่นนี้จะมีผลต่อผลลัพธ์การส่งออก เช่น PDF, ภาพ, และรูปแบบที่รองรับอื่น ๆ ทำให้เอกสารที่ได้คงที่ระหว่างสภาพแวดล้อมต่าง ๆ ฟอนท์จะถูกโหลดจากไดเรกทอรีแบบกำหนดเอง.

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนท์.
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพื่อโหลดฟอนท์จากโฟลเดอร์เหล่านั้น.
3. โหลดและทำการเรนเดอร์/ส่งออกงานนำเสนอ.
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsLoader#clearCache--) เพื่อทำการล้างแคชฟอนท์.

```java
import com.aspose.slides.*;

// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนท์แบบกำหนดเอง.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// โหลดฟอนท์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, ภาพ หรือรูปแบบอื่น) โดยใช้ฟอนท์ที่โหลดไว้.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชฟอนท์หลังจากงานเสร็จสิ้น.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="หมายเหตุ" %}}
เมธอด [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนท์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนท์ ฟอนท์จะถูกเริ่มต้นตามลำดับต่อไปนี้:

1. เส้นทางฟอนท์เริ่มต้นของระบบปฏิบัติการ.
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **รับโฟลเดอร์ฟอนท์แบบกำหนดเอง**

Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) ให้คุณค้นหาโฟลเดอร์ฟอนท์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนท์ของระบบ.

โค้ด Java นี้แสดงวิธีการใช้ [getFontFolders](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์ฟอนท์.
// เหล่านั้นเป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนท์ของระบบ.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **ระบุฟอนท์แบบกำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ให้คุณระบุฟอนท์ภายนอกที่จะใช้กับงานนำเสนอ.

โค้ด Java นี้แสดงวิธีการใช้ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 และฟอนท์จากโฟลเดอร์ assets\fonts & global\fonts รวมทั้งโฟลเดอร์ย่อยของมันพร้อมใช้งานในงานนำเสนอ
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการฟอนท์จากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ให้คุณโหลดฟอนท์ภายนอกจากข้อมูลไบต์.

โค้ด Java นี้แสดงกระบวนการโหลดฟอนท์จากอาเรย์ไบต์:

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
        // ฟอนท์ภายนอกถูกโหลดในช่วงอายุการทำงานของงานนำเสนอ
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **คำถามที่พบบ่อย**

### ฟอนท์แบบกำหนดเองมีผลต่อการส่งออกไปยังรูปแบบทั้งหมด (PDF, PNG, SVG, HTML) หรือไม่?

ใช่ ฟอนท์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก.

### ฟอนท์แบบกำหนดเองจะถูกฝังอัตโนมัติลงในไฟล์ PPTX ที่ได้หรือไม่?

ไม่ การลงทะเบียนฟอนท์เพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากคุณต้องการให้ฟอนท์อยู่ภายในไฟล์งานนำเสนอ ต้องใช้คุณสมบัติการ [ฝังฟอนท์](/slides/th/androidjava/embedded-font/) อย่างชัดเจน.

### ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนท์แบบกำหนดไม่มี glyph บางตัวได้หรือไม่?

ใช่ ปรับแต่ง [การแทนที่ฟอนท์](/slides/th/androidjava/font-substitution/), [กฎการแทนที่](/slides/th/androidjava/font-replacement/), และ [ชุด fallback](/slides/th/androidjava/fallback-font/) เพื่อกำหนดฟอนท์ที่จะใช้เมื่อ glyph ที่ร้องขอไม่มี.

### ฉันสามารถใช้ฟอนท์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งบนระบบทั้งหมดได้หรือไม่?

ใช่ ชี้ไปที่โฟลเดอร์ฟอนท์ของคุณเองหรือโหลดฟอนท์จากอาเรย์ไบต์ ซึ่งช่วยลบการพึ่งพาไดเรกทอรีฟอนท์ของระบบในอิมเมจคอนเทนเนอร์.

### ส่วนเรื่องลิขสิทธิ์—ฉันสามารถฝังฟอนท์แบบกำหนดใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบการปฏิบัติตามลิขสิทธิ์ฟอนท์ เงื่อนไขอาจแตกต่างกัน บางลิขสิทธิ์ห้ามฝังหรือห้ามใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนท์ก่อนแจกจ่ายผลลัพธ์.