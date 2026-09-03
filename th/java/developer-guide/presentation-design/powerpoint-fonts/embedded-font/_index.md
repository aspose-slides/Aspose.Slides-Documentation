---
title: ฝังฟอนต์ในงานนำเสนอด้วย Java
linktitle: ฟอนต์ฝัง
type: docs
weight: 40
url: /th/java/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- ดึงฟอนต์ที่ฝัง
- เพิ่มฟอนต์ที่ฝัง
- ลบฟอนต์ที่ฝัง
- บีบอัดฟอนต์ที่ฝัง
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการฟอนต์ที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ Java เพิ่ม ดึง ลบ และบีบอัดฟอนต์เพื่อรักษารูปแบบข้อความและลดขนาดไฟล์."
---
## **Introduction**

การฝังฟอนต์จะเก็บข้อมูลฟอนต์ไว้ภายในไฟล์งาน PowerPoint เมื่อโปรแกรมแสดงผลรองรับฟอนต์ที่ฝังไว้ จะสามารถแสดงข้อความด้วยฟอนต์เหล่านั้นได้แม้ว่าจะไม่ได้ติดตั้งบนระบบเป้าหมาย ซึ่งช่วยรักษาการตัดบรรทัด การเว้นระยะห่างของข้อความ และรูปแบบสไลด์ไว้ได้

Aspose.Slides for Java ให้คุณเรียกคืน เพิ่ม และลบฟอนต์ที่ฝังไว้ผ่านอินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/) ที่ได้จาก [Presentation.getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getFontsManager--) คุณยังสามารถลดขนาดข้อมูลฟอนต์ที่ฝังไว้ได้โดยลบอักขระที่งานนำเสนอไม่ได้ใช้

ตัวอย่างด้านล่างทำงานกับไฟล์ PPTX ก่อนฝังฟอนต์ให้ตรวจสอบว่าข้อมูลฟอนต์พร้อมใช้งานกับ Aspose.Slides แล้วไลเซนส์ของฟอนต์อนุญาตให้ฝังหรือไม่

## **Get and Remove Embedded Fonts**

ใช้ [getEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) เพื่อแสดงรายการฟอนต์ที่เก็บไว้ในงานนำเสนอ เพื่อเอาออกให้ส่งฟอนต์จากรายการนั้นไปยัง [removeEmbeddedFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้แสดงรายการฟอนต์ที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบฟอนต์ Calibri หากพบ:

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

การลบฟอนต์ที่ฝังไว้จะลบข้อมูลฟอนต์ที่เก็บไว้; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับข้อความ หากฟอนต์ติดตั้งอยู่บนระบบเป้าหมายข้อความยังคงใช้ฟอนต์นั้นได้ หากไม่เช่นนั้นการเรนเดอร์อาจต้องอาศัย [font substitution](/slides/th/java/font-substitution/) ซึ่งอาจทำให้เค้าโครงเปลี่ยนแปลง

## **Inspect Font Data and Embedding Permissions**

ใช้อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/) เพื่อตรวจสอบฟอนต์ก่อนทำการฝัง เรียก [IFontsManager.getFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อดึงฟอนต์ที่ใช้ในงานนำเสนอ สำหรับฟอนต์แต่ละตัวส่งวัตถุ [IFontData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontdata/) และค่าที่ต้องการของ [FontStyleType](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontstyletype/) ไปยัง [IFontsManager.getFontBytes](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-) วิธีนี้จะคืนค่าข้อมูลไบนารีของสไตล์ฟอนต์นั้น หรือ `null` หากฟอนต์หรือสไตล์ที่ขอไม่พร้อมใช้งาน อย่าส่งผลลัพธ์ `null` ไปยัง [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-) เนื่องจากเมธอดนั้นต้องการอาร์เรย์ไบต์

[EmbeddingLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/embeddinglevel/) เป็นการอธิบายค่าธงที่บ่งบอกข้อจำกัดการฝังฟอนต์ที่เก็บไว้ในฟอนต์:

- `Installable` อนุญาตให้ฝังและติดตั้งถาวรบนระบบอื่นได้ โดยต้องปฏิบัติตามข้อกำหนดไลเซนส์ของฟอนต์
- `Restricted` ห้ามฝังเว้นแต่จะได้รับการยินยอมจากเจ้าของลิขสิทธิ์ของฟอนต์เมื่อเป็นธงสิทธิ์การใช้เดียว
- `PreviewPrint` อนุญาตให้ใช้ชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีฟอนต์ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตให้ใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังเพียงส่วนย่อยของ glyphs; หากมีธงนี้จะต้องฝังอักขระทั้งหมด
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเฉพาะบิทแมปสไตล์ ไม่ใช่ข้อมูลรูปร่างเส้น; หากฟอนต์ไม่มีบิทแมปสไตล์จะไม่สามารถฝังได้

สี่ค่าตัวแรกบรรยายสิทธิ์การใช้ ส่วน `NoSubsetting` และ `BitmapOnly` สามารถรวมกับพวกมันได้ ตรวจสอบธงเหล่านี้ด้วยการดำเนินการบิตเชฟ เนื่องจาก `Installable` มีค่าเป็นศูนย์ จึงต้องมาสก์บิตสิทธิ์การใช้และเปรียบเทียบผลลัพธ์กับ `Installable` แทนการตรวจสอบเป็นธง ฟอนต์ปัจจุบันควรตั้งบิตสิทธิ์การใช้ไม่เกินหนึ่งบิต สำหรับความเข้ากันได้กับฟอนต์เก่าที่ตั้งหลายบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนคลายที่สุด: `Editable` แล้วตามด้วย `PreviewPrint` แล้ว `Restricted`

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลแบบปกติ, หนา, ตัวเอียง, และหนา‑เอียง ที่มีให้สำหรับฟอนต์แต่ละตัวที่ได้จาก `getFonts` จะข้ามสไตล์ที่ไม่มี, ฟอนต์ที่ถูกจำกัด, ฟอนต์แบบ bitmap‑only, ฟอนต์ที่จำกัดเฉพาะ preview‑print เพราะผลลัพธ์ยังคงแก้ไขได้, และฟอนต์ที่ฝังไว้แล้ว หากสไตล์ใดมี `NoSubsetting` จะฝังอักขระทั้งหมดของตระกูลฟอนต์นั้น

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

การตรวจสอบนี้รายงานข้อจำกัดที่บันทึกในแต่ละไฟล์ฟอนต์ ไม่ได้ให้ไลเซนส์ ไม่ได้พิสูจน์ว่าคุณได้รับฟอนต์อย่างถูกกฎหมาย และไม่แทนที่การตรวจสอบข้อตกลงไลเซนส์ของฟอนต์ก่อนเผยแพร่สำเนาที่ฝังไว้

## **Add Embedded Fonts**

ใช้ [addEmbeddedFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) เพื่อฝังฟอนต์ การ overload รองรับวัตถุ [IFontData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontdata/) หรืออาร์เรย์ไบต์ที่บรรจุข้อมูลฟอนต์ ตัวนับ [EmbedFontCharacters](https://reference.aspose.com/slides/th/java/com.aspose.slides/embedfontcharacters/) ควบคุมว่าต้องใส่อักขระใดบ้าง:

- [All](https://reference.aspose.com/slides/th/java/com.aspose.slides/embedfontcharacters/) ฝังอักขระทั้งหมดในฟอนต์ ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและพิมพ์ข้อความใหม่
- [OnlyUsed](https://reference.aspose.com/slides/th/java/com.aspose.slides/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อลดขนาดไฟล์ เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมุ่งเน้นการดูเท่านั้น

ตัวอย่างต่อไปนี้ใช้ [getFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อดึงฟอนต์ที่ใช้ใน `Fonts.pptx` และฝังฟอนต์ที่ยังไม่ถูกฝัง ฟอนต์ที่จะเพิ่มต้องพร้อมใช้งานบนเครื่องที่รันโค้ด ฟอนต์ที่ฝังไว้แล้วจะคงชุดอักขระเดิมไว้

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

## **Compress Embedded Fonts**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) ลดข้อมูลฟอนต์ที่ฝังโดยลบอักขระที่ไม่ได้ใช้ มันทำงานกับฟอนต์ที่ฝังอยู่แล้ว ดังนั้นการลดขนาดขึ้นอยู่กับปริมาณข้อมูลฟอนต์ที่ไม่ได้ใช้ในงานนำเสนอ

ตัวอย่างต่อไปนี้บีบอัดฟอนต์ใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยกต่างหาก:

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

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องการเพิ่มข้อความในภายหลัง อักขระที่ถูกลบระหว่างการบีบอัดจะไม่สามารถใช้ได้จากฟอนต์ที่ฝังไว้ แม้ว่าตอนแรกคุณจะฝังอักขระทั้งหมดก็ตาม

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

เรียก [getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูฟอนต์ใดบ้างที่ Aspose.Slides จะเปลี่ยน นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/java/font-substitution/) และกฎ [font fallback](/slides/th/java/fallback-font/) ด้วย ฟอลแบ็กจัดการอักขระที่หายไป ดังนั้นการฝังฟอนต์ไม่สามารถแก้ไขอักขระที่ฟอนต์เองไม่มีได้

**Should I embed common fonts such as Arial and Calibri?**

ให้ตัดสินใจตามสภาพแวดล้อมเป้าหมาย หากฟอนต์ที่ต้องการมีบนเครื่องทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจทำให้ไฟล์ใหญ่เกินความจำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีฟอนต์เหล่านั้น การฝังฟอนต์จะช่วยรักษาการแสดงผลตามที่ต้องการได้ เพียงให้แน่ใจว่าไลเซนส์ของฟอนต์อนุญาตให้ทำเช่นนั้น