---
title: ฝังฟอนต์ในงานนำเสนอด้วย Java
linktitle: การฝังฟอนต์
type: docs
weight: 40
url: /th/java/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- รับฟอนต์ที่ฝัง
- เพิ่มฟอนต์ที่ฝัง
- ลบฟอนต์ที่ฝัง
- บีบอัดฟอนต์ที่ฝัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ฝังฟอนต์ TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม."
---
## **บทนำ**

**ฟอนต์ที่ฝังใน PowerPoint** มีประโยชน์เมื่อคุณต้องการให้การนำเสนอของคุณแสดงผลอย่างถูกต้องเมื่อเปิดบนระบบหรืออุปกรณ์ใดก็ได้ หากคุณใช้ฟอนต์จากบุคคลที่สามหรือฟอนต์ที่ไม่เป็นมาตรฐานเนื่องจากคุณสร้างสรรค์งานของคุณเองแล้ว คุณจะมีเหตุผลมากขึ้นในการฝังฟอนต์ของคุณ หากไม่มีการฝังฟอนต์ (โดยไม่ได้ฝังฟอนต์) ข้อความหรือ ตัวเลขบนสไลด์ การจัดวาง สไตล์ ฯลฯ อาจเปลี่ยนแปลงหรือกลายเป็นสี่เหลี่ยมที่ทำให้สับสน

คลาส [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager) , คลาส [FontData](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontdata/) , คลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) และอินเทอร์เฟซของพวกเขามีคุณสมบัติและเมธอดส่วนใหญ่ที่คุณต้องการใช้เพื่อทำงานกับฟอนต์ที่ฝังในงานนำเสนอ PowerPoint

## **รับและลบฟอนต์ที่ฝัง**

Aspose.Slides มีเมธอด [getEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (ที่เปิดให้ใช้โดยคลาส [FontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsManager)) เพื่อให้คุณสามารถรับ (หรือค้นหา) ฟอนต์ที่ฝังในงานนำเสนอได้ การลบฟอนต์จะใช้เมธอด [removeEmbeddedFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (ที่เปิดให้ใช้โดยคลาสเดียวกัน)

โค้ด Java นี้แสดงให้คุณดูวิธีรับและลบฟอนต์ที่ฝังจากงานนำเสนอ:

```java
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // เรนเดอร์สไลด์ที่มีกรอบข้อความที่ใช้ฟอนต์ที่ฝังไว้ "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //บันทึกภาพลงดิสก์ในรูปแบบ JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // ดึงฟอนต์ที่ฝังทั้งหมด
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // ค้นหาฟอนต์ "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // ลบฟอนต์ "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // เรนเดอร์งานนำเสนอ; "Calibri" ฟอนต์จะถูกแทนที่ด้วยฟอนต์ที่มีอยู่แล้ว
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //บันทึกภาพลงดิสก์ในรูปแบบ JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // บันทึกงานนำเสนอโดยไม่มีฟอนต์ "Calibri" ที่ฝังลงดิสก์
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มฟอนต์ที่ฝัง**

โดยใช้ enum [EmbedFontCharacters](https://reference.aspose.com/slides/th/java/com.aspose.slides/embedfontcharacters/) และการโอเวอร์โหลดสองแบบของเมธอด [addEmbeddedFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) คุณสามารถเลือกกฎ (การฝัง) ที่คุณต้องการเพื่อฝังฟอนต์ในงานนำเสนอ โค้ด Java นี้แสดงให้คุณดูวิธีฝังและเพิ่มฟอนต์ลงในงานนำเสนอ:

```java
// โหลดงานนำเสนอ
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **บีบอัดฟอนต์ที่ฝัง**

เพื่อให้คุณสามารถบีบอัดฟอนต์ที่ฝังในงานนำเสนอและลดขนาดไฟล์ของมัน Aspose.Slides มีเมธอด [compressEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (ที่เปิดให้ใช้โดยคลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/))

โค้ด Java นี้แสดงให้คุณดูวิธีบีบอัดฟอนต์ PowerPoint ที่ฝัง:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบอย่างไรว่าฟอนต์เฉพาะในงานนำเสนอยังคงถูกแทนที่ระหว่างการเรนเดอร์แม้จะฝังแล้ว?**

ตรวจสอบ [ข้อมูลการทดแทน](/slides/th/java/font-substitution/) ใน Font Manager และ [กฎการสำรอง/การทดแทน](/slides/th/java/fallback-font/): หากฟอนต์ไม่พร้อมใช้งานหรือถูกจำกัด การสำรองจะถูกใช้งาน

**การฝังฟอนต์ "system" เช่น Arial/Calibri คุ้มหรือไม่?**

โดยทั่วไปไม่มี—พวกมันมักจะพร้อมใช้งานเสมอ แต่สำหรับการพกพาเต็มรูปแบบในสภาพแวดล้อม “บาง” (Docker, เซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ติดตั้งล่วงหน้า) การฝังฟอนต์ระบบสามารถขจัดความเสี่ยงจากการทดแทนโดยไม่คาดคิดได้