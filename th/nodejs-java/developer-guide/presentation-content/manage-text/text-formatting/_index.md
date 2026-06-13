---
title: จัดรูปแบบข้อความการนำเสนอใน JavaScript
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/nodejs-java/text-formatting/
keywords:
- ไฮไลท์ข้อความ
- นิพจน์ปกติ
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งแสงของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- เฟรมข้อความ
- การเว้นบรรทัด
- คุณสมบัติ Autofit
- จุดยึดเฟรมข้อความ
- การเยื้องแท็บของข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java ปรับแต่งฟอนต์ สี การจัดแนว และอื่น ๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Node.js via Java โดยครอบคลุมการไฮไลท์ สีพื้นหลัง ความโปร่งแสง การเว้นระยะระหว่างอักขระ คุณสมบัติฟอนต์ การหมุน การเว้นระยะของย่อหน้า พฤติกรรม autofit การยึดตำแหน่งข้อความ จุดหยุดแท็บ และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) เมื่อคุณต้องการไฮไลท์ข้อความที่ตรงกับตัวอย่างเฉพาะภายใน TextFrame เมธอดจะใส่สีไฮไลท์ให้กับส่วนข้อความที่ตรงกันและสามารถใช้ร่วมกับ [TextSearchOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/) เพื่อควบคุมวิธีการค้นหา เช่น ให้จับคู่เฉพาะคำเต็ม

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกการปรากฏของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // ไฮไลท์คำ "try" ในรูปร่าง.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // ไฮไลท์คำ "to" ในรูปร่าง.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) จะไฮไลท์ข้อความที่ตรงกับการค้นหาด้วย regular expression ใน Node.js via Java API นี้เปิดเผยบน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกคำที่มี **เจ็ดอักษรหรือมากกว่า**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // ไฮไลท์ทุกคำที่มีอักขระเจ็ดตัวหรือมากกว่า.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์ด้วย regular expression](highlighted_text_using_regex.png)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

โค้ดตัวอย่างต่อไปแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ทั้งย่อหน้า**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลท์สำหรับทั้งย่อหน้า.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

โค้ดตัวอย่างด้านล่างสาธิตวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดตำแหน่งย่อหน้าข้อความ**

ใช้ [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) เพื่อตั้งค่าการจัดแนวย่อหน้าใน TextFrame ค่าที่ตั้งได้อาจเป็น ศูนย์กลาง, ชิดซ้าย, ชิดขวา, จัดเต็ม ฯลฯ

โค้ดตัวอย่างต่อไปแสดงวิธีจัดแนวย่อหน้าให้ **ตรงกลาง**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าการจัดแนวของย่อหน้าให้เป็นศูนย์กลาง.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งแสงสำหรับข้อความ**

ความโปร่งแสงของข้อความถูกควบคุมผ่านคอมโพเนนต์อัลฟาของสีที่กำหนดให้กับ [PortionFormat.getFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getFillFormat--) ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่องอัลฟา ARGB บนสเกล 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งแสง

โค้ดตัวอย่างด้านล่างแสดงวิธีใช้ความโปร่งแสงกับ **ทั้งย่อหน้า**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งแสง.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งแสง](transparent_paragraph.png)

โค้ดตัวอย่างต่อไปแสดงวิธีใช้ความโปร่งแสงกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // ตั้งค่าความโปร่งแสงของส่วนข้อความ.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งแสง](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระของข้อความ**

ใช้ [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) เพื่อเพิ่มหรือย่อตัวอักษรระหว่างกันในกล่องข้อความ

โค้ด JavaScript ต่อไปแสดงวิธีขยายระยะห่างระหว่างอักขระใน **ทั้งย่อหน้า**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีขยายระยะห่างระหว่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
            portion.getPortionFormat().setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้งาน Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์ด้วย Aspose.Slides อาจดูแน่นเกินกว่าที่แสดงใน PowerPoint เนื่องจาก PowerPoint อาจละเลยข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งานในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดรสคล้ายกับ PowerPoint มากขึ้น คุณสามารถปิดการใช้งาน kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ โดยตั้งค่า [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) ให้มีค่ามากกว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกัน และช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าผ่าน [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) หรือที่ส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/)

โค้ดต่อไปตั้งค่าฟอนต์และรูปแบบข้อความสำหรับ **ทั้งย่อหน้า**: จะตั้งขนาดฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

โค้ดตัวอย่างด้านล่างใช้คุณสมบัติคล้ายกันกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าในรูปร่าง

โค้ดตัวอย่างต่อไปตั้งค่าการวางแนวข้อความในรูปร่างเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาตรงข้ามเข็มนาฬิกา**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับ Text Frame**

ใช้ [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)

โค้ดตัวอย่างด้านล่างหมุน Text Frame ไป 3 องศาในทิศตามเข็มนาฬิกาในรูปร่าง:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), และ [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) เพื่อควบคุมการเว้นระยะของย่อหน้า คุณสมบัติเหล่านี้ใช้ได้ดังนี้

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นจุด

โค้ดตัวอย่างต่อไปแสดงวิธีระบุการเว้นบรรทัดภายในย่อหน้า:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเว้นบรรทัดภายในย่อหน้า](line_spacing.png)

## **ตั้งค่าประเภท Autofit สำหรับ Text Frame**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) กำหนดวิธีการที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติหรือไม่

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าจุดยึดของ Text Frame**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) กำหนดวิธีการวางตำแหน่งข้อความในแนวตั้งภายในรูปร่าง เช่น ด้านบน, กลาง, หรือด้านล่าง

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการเยื้องแท็บของข้อความ**

ใช้ [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) และ [ParagraphFormat.getTabs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#getTabs--) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษาการตรวจสอบอักขระ**

Aspose.Slides มี [PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ซึ่งช่วยให้คุณตั้งค่าภาษาการตรวจสอบอักขระสำหรับส่วนข้อความ ภาษาการตรวจสอบนี้กำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ดตัวอย่างต่อไปแสดงวิธีตั้งค่าภาษาการตรวจสอบอักขระสำหรับส่วนข้อความ:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // ตั้งค่า Id ของภาษาการพิสูจน์อักษร.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาที่ใช้เป็นค่าเริ่มต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้ฟอร์แมตข้อความเริ่มต้นระดับงานนำเสนอ ใช้ [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--)

โค้ดตัวอย่างต่อไปแสดงวิธีตั้งค่าแบบอักษรหนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // รับรูปแบบย่อหน้าในระดับบนสุด.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ดึงข้อความที่มีเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** จะทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้ว่าจะพิมพ์เป็นตัวเล็กเดิมก็ตาม เมื่อคุณดึงส่วนข้อความเช่นนี้ด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่ามี `All`

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีดึงข้อความที่มีเอฟเฟกต์ **All Caps** ที่ใช้งานอยู่:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**วิธีแก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์โดยใช้ [Cell.getTextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/#getTextFrame--) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**วิธีใส่สีไล่ระดับสีให้กับข้อความในสไลด์ PowerPoint?**

เพื่อใส่สีไล่ระดับสีให้กับข้อความ ให้ใช้ [PortionFormat.getFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getFillFormat--). ตั้งค่า [FillFormat.setFillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) แล้วกำหนดจุดไล่ระดับสี, ทิศทาง, และความโปร่งแสง.