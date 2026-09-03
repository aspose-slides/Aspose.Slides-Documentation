---
title: ฝังแบบอักษรในงานนำเสนอบน Android
linktitle: แบบอักษรที่ฝังไว้
type: docs
weight: 40
url: /th/androidjava/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- รับแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการแบบอักษรที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพิ่ม ดึงข้อมูล ลบ และบีบอัดแบบอักษรเพื่อรักษาการแสดงผลของข้อความและลดขนาดไฟล์"
---
## **บทนำ**

การฝังแบบอักษรจะเก็บข้อมูลแบบอักษรภายในงานนำเสนอ PowerPoint เมื่อผู้ดูรองรับแบบอักษรที่ฝังไว้ สามารถแสดงข้อความด้วยแบบอักษรเหล่านั้นได้แม้ว่าแบบอักษรจะไม่ได้ติดตั้งบนระบบเป้าหมาย การทำเช่นนี้ช่วยรักษาการตัดบรรทัด การเว้นระยะห่างของข้อความ และการจัดรูปแบบสไลด์  

Aspose.Slides สำหรับ Android ผ่าน Java ให้คุณเรียกคืน, เพิ่ม และลบแบบอักษรที่ฝังไว้ผ่านอินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/) ที่คืนค่าจาก [Presentation.getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getFontsManager--). คุณยังสามารถลดขนาดข้อมูลแบบอักษรที่ฝังไว้โดยการลบอักขระที่งานนำเสนอไม่ได้ใช้  

ตัวอย่างต่อไปนี้ทำงานกับไฟล์ PPTX ก่อนที่จะแฝงแบบอักษร ให้แน่ใจว่าข้อมูลแบบอักษรนั้นพร้อมใช้งานสำหรับ Aspose.Slides และใบอนุญาตของแบบอักษรอนุญาตให้ฝังได้  

## **รับและลบแบบอักษรที่ฝังไว้**

ใช้ [getEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) เพื่อแสดงรายการแบบอักษรที่เก็บไว้ในงานนำเสนอ เพื่อทำการลบแบบอักษรหนึ่ง ให้ส่งแบบอักษรจากรายการนั้นไปที่ [removeEmbeddedFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), แล้วบันทึกงานนำเสนอ  

ตัวอย่างต่อไปนี้แสดงรายการแบบอักษรที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบ Calibri หากมีอยู่:
```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

การลบแบบอักษรที่ฝังไว้จะลบข้อมูลแบบอักษรที่เก็บไว้; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับข้อความ หากแบบอักษรติดตั้งบนระบบเป้าหมาย ข้อความยังคงสามารถใช้ได้ มิฉะนั้น การเรนเดอร์อาจต้องใช้ [font substitution](/slides/th/androidjava/font-substitution/) ซึ่งอาจส่งผลต่อการจัดวาง  

## **ตรวจสอบข้อมูลแบบอักษรและสิทธิ์การฝัง**

ใช้อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/) เพื่อตรวจสอบแบบอักษรก่อนทำการฝัง เรียก [IFontsManager.getFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อดึงแบบอักษรที่ใช้งานในงานนำเสนอ สำหรับแต่ละแบบอักษร ให้ส่งวัตถุ [IFontData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontdata/) และค่าที่จำเป็นของ [FontStyleType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontstyletype/) ไปที่ [IFontsManager.getFontBytes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). เมธอดนี้จะคืนค่าข้อมูลไบต์ของสไตล์แบบอักษรนั้น หรือ `null` หากแบบอักษรหรือสไตล์ที่ร้องขอไม่มีอยู่ อย่าส่งผลลัพธ์ `null` ไปยัง [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), เพราะเมธอดนั้นต้องการอาร์เรย์ไบต์  

[EmbeddingLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embeddinglevel/) เป็น enumeration แบบแฟล็กที่รายงานข้อจำกัดการฝังที่เก็บไว้ในแบบอักษร:

- `Installable` อนุญาตให้ฝังและติดตั้งถาวรบนระบบอื่น ภายใต้เงื่อนไขของสัญญาอนุญาตแบบอักษร
- `Restricted` ห้ามฝังเว้นแต่จะได้รับอนุญาตจากเจ้าของลิขสิทธิ์ของแบบอักษรเมื่อเป็นแฟล็กสิทธิ์การใช้งานเดียว
- `PreviewPrint` อนุญาตการใช้งานชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีแบบอักษรนี้ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตการใช้งานชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังส่วนย่อยของ glyphs; ต้องฝังทุกอักขระเมื่อแฟล็กนี้ปรากฏ
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตฝังเฉพาะบิทแมปสไตล์ ไม่ใช่ข้อมูลเส้นขอบ; หากแบบอักษรไม่มีบิทแมปสไตล์ ไม่สามารถฝังได้  

ค่าแรกสี่ค่าจะบรรยายสิทธิ์การใช้งาน ส่วน `NoSubsetting` และ `BitmapOnly` สามารถผสานรวมกับค่าดังกล่าวได้ ตรวจสอบตัวแก้ไขด้วยการทำงานบิตไวส์ เนื่องจาก `Installable` มีค่าเป็นศูนย์ ให้ทำการมาสก์บิตสิทธิ์การใช้งานและเปรียบเทียบผลลัพธ์กับ `Installable` แทนการตรวจสอบเป็นแฟล็ก แบบอักษรปัจจุบันควรกำหนดบิตสิทธิ์การใช้งานไม่เกินหนึ่งบิต เพื่อความเข้ากันได้กับแบบอักษรเก่าที่กำหนดหลายบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนปรนน้อยที่สุด: `Editable` ตามด้วย `PreviewPrint` แล้ว `Restricted`  

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลแบบปกติ, ตัวหนา, ตัวเอียง, และตัวหนา‑เอียง ที่มีอยู่สำหรับแต่ละแบบอักษรที่ `getFonts` คืนค่า จะข้ามสไตล์ที่ไม่มี, แบบอักษรที่จำกัด, แบบอักษร bitmap‑only, แบบอักษรที่จำกัดเฉพาะ preview และ print เพราะผลลัพธ์ยังคงแก้ไขได้, และแบบอักษรที่ฝังไว้แล้ว หากมีสไตล์ใดที่มี `NoSubsetting` จะฝังทุกอักขระสำหรับฟอนต์ครอบครัวนั้น  
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในไฟล์แบบอักษรแต่ละไฟล์ ไม่ได้ให้สิทธิ์ใบอนุญาต ไม่ได้พิสูจน์ว่าคุณได้แบบอักษรมาอย่างถูกกฎหมาย หรือแทนที่การตรวจสอบสัญญาอนุญาตของแบบอักษรก่อนแจกจ่ายสำเนาที่ฝังไว้  

## **เพิ่มแบบอักษรที่ฝังไว้**

ใช้ [addEmbeddedFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) เพื่อฝังแบบอักษร ส่วน overload ของเมธอดรับอ็อบเจกต์ [IFontData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontdata/) หรืออาร์เรย์ไบต์ที่มีข้อมูลแบบอักษร ค่าต enum [EmbedFontCharacters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embedfontcharacters/) กำหนดว่าอักขระใดจะถูกใส่เข้าไป:

- [All](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embedfontcharacters/) ฝังอักขระทั้งหมดในแบบอักษร ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและใส่ข้อความใหม่
- [OnlyUsed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อ ลดขนาดไฟล์ เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมุ่งเน้นการชม  

ตัวอย่างต่อไปนี้ใช้ [getFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อดึงแบบอักษรที่ใช้ใน `Fonts.pptx` และฝังแบบอักษรที่ยังไม่ได้ฝังไว้ แบบอักษรที่จะเพิ่มต้องพร้อมใช้งานบนอุปกรณ์ Android หรือได้ลงทะเบียนกับ Aspose.Slides แบบอักษรที่ฝังไว้แล้วจะคงชุดอักขระปัจจุบันไว้  
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บีบอัดแบบอักษรที่ฝังไว้**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) ลดข้อมูลแบบอักษรที่ฝังไว้โดยลบอักขระที่ไม่ได้ใช้ มันทำงานกับแบบอักษรที่ฝังไว้แล้ว ดังนั้นการลดขนาดขึ้นอยู่กับข้อมูลแบบอักษรที่ไม่ได้ใช้ในงานนำเสนอเท่าใด  

ตัวอย่างต่อไปนี้บีบอัดแบบอักษรใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก:
```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องการเพิ่มข้อความภายหลัง อักขระที่ลบระหว่างการบีบอัดจะไม่สามารถใช้ได้จากแบบอักษรที่ฝังไว้ แม้ว่าคุณจะฝังอักขระทั้งหมดในตอนแรกก็ตาม  

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรที่ฝังไว้ยังคงถูกแทนที่ขณะเรนเดอร์หรือไม่?**  
เรียก [getSubstitutions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูว่า Aspose.Slides จะเปลี่ยนแบบอักษรใดบ้าง นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/androidjava/font-substitution/) และกฎ [font fallback](/slides/th/androidjava/fallback-font/) ด้วย Fallback จะจัดการกับอักขระที่หายไป ดังนั้นการฝังแบบอักษรไม่ได้แก้ปัญหาอักขระที่แบบอักษรนั้นไม่มีอยู่เอง  

**ฉันควรฝังแบบอักษรทั่วไปเช่น Arial และ Calibri หรือไม่?**  
ตัดสินใจโดยอิงตามสภาพแวดล้อมเป้าหมาย หากแบบอักษรที่ต้องการมีอยู่บนอุปกรณ์ทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีแบบอักษรเหล่านั้น การฝังจะช่วยรักษารูปแบบที่ต้องการได้ กำหนดให้เป็นไปตามเงื่อนไขของใบอนุญาตของแบบอักษรนั้น.