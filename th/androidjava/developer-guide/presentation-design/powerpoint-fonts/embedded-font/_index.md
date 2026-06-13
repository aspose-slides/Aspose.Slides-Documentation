---
title: ฝังฟอนต์ในงานนำเสนอบน Android
linktitle: การฝังฟอนต์
type: docs
weight: 40
url: /th/androidjava/embedded-font/
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
- Android
- Java
- Aspose.Slides
description: "ฝังฟอนต์ TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้การแสดงผลแม่นยำในทุกแพลตฟอร์ม"
---
## **บทนำ**

**ฟอนต์ที่ฝังใน PowerPoint** มีประโยชน์เมื่อคุณต้องการให้การนำเสนอของคุณปรากฏอย่างถูกต้องเมื่อเปิดในระบบหรืออุปกรณ์ใดก็ได้ หากคุณใช้ฟอนต์จากบุคคลที่สามหรือฟอนต์ที่ไม่เป็นมาตรฐานเพราะคุณสร้างสรรค์งานของคุณ คุณก็มีเหตุผลเพิ่มเติมในการฝังฟอนต์ของคุณ มิฉะนั้น (หากไม่มีฟอนต์ที่ฝัง) ข้อความหรือเลขบนสไลด์ การจัดวาง การออกแบบ ฯลฯ อาจเปลี่ยนแปลงหรือกลายเป็นสี่เหลี่ยมที่สับสน

คลาส [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager) , คลาส [FontData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontdata/) , คลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) และอินเทอร์เฟซของพวกมันมีคุณสมบัติและวิธีการส่วนใหญ่ที่คุณต้องการเพื่อทำงานกับฟอนต์ที่ฝังในงานนำเสนอ PowerPoint

## **รับและลบฟอนต์ที่ฝัง**

Aspose.Slides มีเมธอด [getEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (ที่เปิดเผยโดยคลาส [FontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontsManager)) เพื่อให้คุณสามารถรับ (หรือค้นหา) ฟอนต์ที่ฝังอยู่ในงานนำเสนอได้ หากต้องการลบฟอนต์ ใช้เมธอด [removeEmbeddedFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (ที่เปิดเผยโดยคลาสเดียวกัน)

โค้ด Java นี้แสดงวิธีการรับและลบฟอนต์ที่ฝังจากงานนำเสนอ:

```java
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // เรนเดอร์สไลด์ที่มีเฟรมข้อความที่ใช้ฟอนต์ที่ฝัง "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
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

    // เรนเดอร์งานนำเสนอ; ฟอนต์ "Calibri" จะถูกแทนที่ด้วยฟอนต์ที่มีอยู่
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // บันท่างานนำเสนอที่ไม่มีฟอนต์ "Calibri" ที่ฝังลงดิสก์
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มฟอนต์ที่ฝัง**

โดยใช้ enum [EmbedFontCharacters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embedfontcharacters/) และสอง overload ของเมธอด [addEmbeddedFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) คุณสามารถเลือกกฎการฝังคือที่ต้องการเพื่อฝังฟอนต์ในงานนำเสนอได้ โค้ด Java นี้แสดงวิธีการฝังและเพิ่มฟอนต์ในงานนำเสนอ:

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

เพื่อให้คุณสามารถบีบอัดฟอนต์ที่ฝังในงานนำเสนอและลดขนาดไฟล์ Aspose.Slides มีเมธอด [compressEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (ที่เปิดเผยโดยคลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/))

โค้ด Java นี้แสดงวิธีการบีบอัดฟอนต์ PowerPoint ที่ฝังอยู่:

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

**ฉันจะรู้ได้อย่างไรว่าฟอนต์เฉพาะในงานนำเสนอจะยังคงถูกแทนที่ระหว่างการเรนเดอร์แม้จะฝังแล้ว?**

ตรวจสอบ [substitution information](/slides/th/androidjava/font-substitution/) ในตัวจัดการฟอนต์และ [fallback/substitution rules](/slides/th/androidjava/fallback-font/): หากฟอนต์ไม่มีหรือถูกจำกัด ระบบจะใช้ฟอนต์สำรอง

**การฝังฟอนต์ “system” เช่น Arial/Calibri มีความคุ้มหรือไม่?**

โดยปกติไม่—โดยส่วนใหญ่ฟอนต์เหล่านี้จะมีอยู่แล้ว แต่สำหรับการพกพาเต็มรูปแบบในสภาพแวดล้อม “บาง” (Docker, เซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ล่วงหน้า) การฝังฟอนต์ระบบสามารถขจัดความเสี่ยงจากการแทนที่ที่ไม่คาดคิดได้