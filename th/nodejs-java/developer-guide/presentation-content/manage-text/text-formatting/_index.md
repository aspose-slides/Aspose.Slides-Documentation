---
title: จัดรูปแบบข้อความการนำเสนอใน JavaScript
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/nodejs-java/text-formatting/
keywords:
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติปรับอัตโนมัติ
- จุดยึดกรอบข้อความ
- การแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดรูปแบบและตกแต่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java ปรับแต่งแบบอักษร, สี, การจัดแนว และอื่น ๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. มันครอบคลุมสีพื้นหลัง, ความโปร่งใส, การจัดระยะห่างของอักขระ, คุณสมบัติของแบบอักษร, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรมการปรับอัตโนมัติ, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา.

ยกเว้นที่ระบุไว้เป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx). รูปทรงแรกในสไลด์แรกเป็นกล่องข้อความ และย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง ดัชนีสไลด์และรูปทรงใช้เลขศูนย์เป็นฐาน ตัวอย่างที่เลือกส่วนที่เป็นตัวหนาจะใช้การจัดรูปแบบที่มีผลจริง รวมถึงการจัดรูปแบบตัวหนาที่สืบทอดมา:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตามตัวอักษรหรือการจับคู่ด้วย regular‑expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/nodejs-java/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) สำหรับส่วนข้อความรายบุคคล.

ตัวอย่างต่อไปนี้ตั้งค่าไฮไลท์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลท์ที่ระบุโดยตรงสำหรับส่วนข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าเริ่มต้นนี้:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลต์สำหรับย่อหน้าทั้งหมด.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีแบบอักษรหนา**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีไฮไลต์สำหรับส่วนข้อความ.
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

ใช้ [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) เพื่อตั้งค่าการจัดตำแหน่งย่อหน้าในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง, จัดซ้าย, จัดขวา, จัดแนวเต็ม, เป็นต้น.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดตำแหน่งย่อหน้าไปที่ **กึ่งกลาง**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าการจัดแนวของย่อหน้าเป็นกึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดตำแหน่ง](aligned_paragraph.png)

## **จัดตำแหน่งแบบอักษรภายในบรรทัด**

ใช้ [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) เพื่อจัดตำแหน่งแนวตั้งของส่วนข้อความที่มีขนาดแบบอักษรต่างกันภายในบรรทัด การตั้งค่านี้จะใช้กับทั้งย่อหน้าและควบคุมการจัดตำแหน่งภายในแต่ละบรรทัดของมัน.

ตัวอย่างอิสระต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับสี่กล่องบนสไลด์หนึ่ง ย่อหน้าแต่ละย่อหน้ามีข้อความเดียวกันที่ขนาด 18, 36, และ 54 จุด พร้อมการจัดตำแหน่งแบบอักษรที่แตกต่างกัน ตัวอย่างใช้แบบอักษร Arial, ปิดการปรับอัตโนมัติและการตัดบรรทัด, และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เปรียบเทียบการจัดตำแหน่งแบบอักษร Baseline, Top, Center, Bottom กับขนาดแบบอักษรผสม](font_alignment.png)

การจัดตำแหน่งแบบอักษรใช้เมตริกของแบบอักษร ดังนั้นขอบที่มองเห็นของอักขระแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์ ตัวอย่างรวมทั้งอักษรพิมพ์ใหญ่และตัวตัวหางเพื่อแสดงความแตกต่างระหว่างการจัดตำแหน่ง baseline กับ bottom การมีแบบอักษรและการแทนที่, ตัวอักษรที่ใช้, และความแตกต่างของขนาดแบบอักษรส่งผลต่อผลลัพธ์ ขนาดกรอบ, ช่องว่าง, ระยะห่างบรรทัด, การห่อ, และการปรับอัตโนมัติก็มีผลต่อการจัดวาง; ควรใช้แบบอักษรและการตั้งค่าแบบเดียวกันเมื่อเปรียบเทียบโหมด.

การตั้งค่านี้แตกต่างจาก [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), ซึ่งควบคุมการจัดตำแหน่งย่อหน้าในแนวนอน, และ [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), ซึ่งกำหนดตำแหน่งบล็อคข้อความในแนวตั้งภายในรูปร่าง การจัดรูปแบบตัวยกและตัวย่อล่างผ่าน [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) จะย้ายส่วนข้อความแต่ละส่วนสัมพันธ์กับ baseline แทนการตั้งค่าการจัดตำแหน่งแบบอักษรสำหรับบรรทัดของย่อหน้า.

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วน alpha ของสีที่กำหนดให้กับ [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). ในตัวอย่างด้านล่าง, `alpha = 50` คือค่าแชนแนล alpha ของ ARGB บนสเกล 0–255, ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีแบบอักษรหนา**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // ตั้งค่าความโปร่งใสของส่วนข้อความ.
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

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าระยะห่างอักขระสำหรับข้อความ**

ใช้ [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าติดลบจะบีบอัดข้อความ.

โค้ด JavaScript ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างของอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีแบบอักษรหนา**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
            portion.getPortionFormat().setSpacing(3); // ขยายระยะห่างของอักขระ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint เรื่องนี้อาจเกิดจาก PowerPoint เพิกเฉยข้อมูล kerning สำหรับแบบอักษรบางตัว แม้ว่าแบบอักษรนั้นจะมีข้อมูล kerning ที่ถูกต้องและ kerning ถูกเปิดในการตั้งค่า PowerPoint.

เพื่อทำให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint ในกรณีเช่นนี้ คุณสามารถปิด kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบ ตั้งค่า [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) เป็นค่าที่ใหญ่กว่าขนาดแบบอักษรจริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ตรวจสอบชื่อแบบอักษรที่มีผลจริงรวมถึงแบบอักษรที่สืบทอด และตั้งค่าขีดจำกัด 100 จุดสำหรับส่วนที่ใช้ Roboto การตั้งค่านี้จะปิด kerning สำหรับส่วนที่ตรงกันที่มีขนาดแบบอักษรต่ำกว่า 100 จุด:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับข้อความที่ตรงกับเกณฑ์แต่มีขนาดต่ำกว่าขีดจำกัด การตั้งค่านี้จะป้องกัน kerning และช่วยให้การแสดงผลของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับแบบอักษรที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้.

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าที่ระดับย่อหน้าผ่าน [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือบนส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรเริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการจัดรูปแบบตัวหนา, ตัวเอียง, และขีดล่างเป็นจุด การจัดรูปแบบโดยตรงบนส่วนข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าเริ่มต้นเหล่านี้:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
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

![คุณสมบัติแบบอักษรสำหรับย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 จุด, การจัดรูปแบบตัวเอียง, และขีดล่างเป็นจุด กับส่วนที่การจัดรูปแบบที่มีผลเป็นตัวหนา:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
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

![คุณสมบัติแบบอักษรสำหรับส่วนข้อความ](font_properties_for_text_portions.png)

## **ควบคุมการทำให้ความสูงข้อความเป็นมาตรฐาน**

ใช้ [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) เมื่อทำสำเนาแบบอักษรตามแม่แบบหรือวิเคราะห์ความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดใช้งานการทำให้ความสูงเป็นมาตรฐานจะยืดหรือบีบอัดอักขระแต่ละตัวในแนวตั้งเพื่อให้มีความสูงที่มองเห็นเท่ากันภายในส่วนข้อความ แต่มันไม่ได้รับประกันความสูงข้อความที่เท่ากันระหว่างแบบอักษรที่แตกต่างกัน.

ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.True หรือ False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำให้ความสูงเป็นมาตรฐานอย่างชัดเจน `NullableBool.NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นไม่ได้กำหนดเพื่อให้ส่วนสืบทอดค่าจากที่อื่น เช่น จาก [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ของย่อหน้า ซึ่งไม่ได้หมายความว่า `False`. ใช้ [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) และอ่าน [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) เพื่อรับค่า Boolean ที่สรุปแล้ว.

ตัวอย่างอิสระต่อไปนี้ต้องการให้ **Arial** ถูกติดตั้ง มันสร้างสองบล็อกข้อความที่มีอักษรพิมพ์ใหญ่, ตัวพิมพ์เล็ก, ตัวหาง, และอักขระมีเครื่องหมายสำคัญขนาด 54 จุด ย่อหน้าแต่ละย่อหน้าจะเปิดการทำให้ความสูงเป็นมาตรฐานโดยค่าเริ่มต้น ส่วนบนจะปิดการทำให้ความสูงโดยตรง; ส่วนล่างจะสืบทอดค่า การขนาดกรอบ, ช่องว่าง, และระยะห่างย่อหน้าจะเหมือนกัน, ปิดการห่อและการปรับอัตโนมัติเพื่อให้การเปรียบเทียบคงที่ ตัวอย่างพิมพ์ `False: false` และ `NotDefined: true`, จากนั้นบันทึกเป็น "text_height_normalization.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างถูกส่งออกจากงานนำเสนอที่บันทึกไว้ แถวบนมีการทำให้ความสูงเป็นมาตรฐานปิด (`False`); แถวล่างสืบทอดการตั้งค่าเปิด (`NotDefined` → `True`). ควรมี Arial ติดตั้งเพื่อสร้างรูปลักษณ์นี้.

![ข้อความ Arial ขนาด 54 จุดที่มีการทำให้ความสูงเป็นมาตรฐานปิดด้านบนและสืบทอดเปิดด้านล่าง](text_height_normalization.png)

การทำให้ความสูงเป็นมาตรฐานเปลี่ยนความสูงของอักขระโดยไม่เปลี่ยนค่า [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) ที่กำหนดขนาดแบบอักษรเป็นจุด ย่อหน้า [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) ควบคุมระยะห่างบรรทัด, ส่วนกรอบข้อความ [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) ควบคุมว่าข้อความหรือคอนเทนเนอร์ปรับขนาดอย่างไร เพื่อตอบสนองต่อขนาด การตั้งค่าเหล่านี้มีจุดประสงค์แตกต่างกันและอาจส่งผลต่อการจัดวางโดยรวม สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ดูที่ [Manage Paragraph](/slides/th/nodejs-java/manage-paragraph/).

## **ใช้และลบการขีดฆ่า**

ใช้ [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำยกเลิก, หรือราคาก่อนหน้าโดยไม่ลบข้อความต้นฉบับ ตั้งค่าเป็น [TextStrikethroughType.Single หรือ Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) เพื่อให้มีเส้นขีดหนึ่งหรือสองเส้นผ่านข้อความ.

เพื่อเอาการขีดฆ่าออก ให้ส่งค่า [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). ค่าดังกล่าวจะปิดเอฟเฟ็กต์โดยชัดเจน แม้ว่าการจัดรูปแบบโดยรอบจะระบุการขีดฆ่า ในทางตรงกันข้าม [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) จะปล่อยให้การตั้งค่าท้องถิ่นไม่ได้กำหนด ทำให้ส่วนสืบทอดการจัดรูปแบบ เช่น จากย่อหน้า ซึ่งไม่ได้รับประกันว่าการขีดฆ่าจะถูกลบ ใช้ [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) เพื่ออ่านการจัดรูปแบบที่ได้รวมถึงค่าที่สืบทอด.

ตัวอย่างอิสระต่อไปนี้สร้างการเปรียบเทียบราคา three รายการ ย่อหน้าแต่ละย่อหน้ามีส่วนแยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน ดังนั้นจึงมีผลต่อราคาก่อนหน้าเท่านั้น แถวแรกใช้และลบการขีดฆ่าตามลำดับ; แถวอื่นคงการขีดฆ่าแบบหนึ่งเส้นและสองเส้น การเปลี่ยนการตั้งค่านี้จะคงข้อความและการจัดรูปแบบอื่น ๆ รวมถึงราคาก่อนหน้าที่เป็นตัวหนา.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // ใช้การขีดฆ่า, แล้วลบอย่างเจาะจงออกจากราคาก่อนหน้าตัวแรก.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากบนลงล่าง: ไม่มีการขีดฆ่า, การขีดฆ่าแบบหนึ่งเส้น, และการขีดฆ่าแบบสองเส้น.

![ราคาก่อนหน้าโดยไม่มีการขีดฆ่า, มีการขีดฆ่าแบบหนึ่งเส้น, และมีการขีดฆ่าแบบสองเส้น](strikethrough.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อกำหนดทิศทางข้อความที่กำหนดไว้ล่วงหน้าในรูปทรง.

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาตรงทวนเข็มนาฬิกา**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **แสดงตัวเลขต่อเนื่องในข้อความแนวตั้ง**

เพื่อให้ตัวเลขสองหลักอยู่ด้วยกันในป้ายภาษาญี่ปุ่นแนวตั้ง ให้วางตัวเลขทั้งสองหลักในส่วนข้อความเดียวและเรียก [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) บนการจัดรูปแบบของส่วนนั้น ตัวอย่างใช้ [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) และ MS Gothic ขนาด 40 จุดสำหรับป้ายทั้งสอง ค่า [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) ที่ส่งให้ส่วนตัวเลขจะแตกต่างกันเท่านั้น.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใน PowerPoint, ป้ายซ้าย (`True`) แสดงตัวเลขตั้งตรงและอยู่ต่อกันระหว่าง 和 และ 年. ป้ายขวา (`False`) ตัวเลขจะถูกหมุน 90 องศาตามเข็มนาฬิกา ตัวอักษรญี่ปุ่นรอบ ๆ ยังคงตั้งตรงในทั้งสองป้าย.

![เปรียบเทียบ PowerPoint ของป้ายวันที่แนวตั้งที่ตัวเลขตั้งตรงด้านซ้ายและหมุนด้านขวา](vertical_date.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาในรูปทรง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore), และ [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้:

* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด.
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นจุด.

ตัวอย่างต่อไปนี้ตั้งค่าระยะห่างภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (ระยะห่างสองเท่า):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้ามีประโยชน์ในบล็อกข้อความแคบและงานนำเสนอที่ผสานข้อความละตินและเอเชียตะวันออก วิธีต่อไปนี้เป็นของ [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), ดังนั้นจึงใช้กับย่อหน้าเต็ม:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนอาจทำให้ตำแหน่งการตัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ข้างเคียงเปลี่ยน.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ตำแหน่งเริ่มต้นและสิ้นสุดบรรทัด.

กฎเหล่านี้ไม่แทนที่ [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), ซึ่งเปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ พวกมันมีผลต่อการจัดวางเมื่อเกิดการตัดบรรทัด; ไม่ได้แทรกอักขระการตัดบรรทัด การตัดบรรทัดโดยตรงจะบังคับให้ขึ้นบรรทัดใหม่ภายในย่อหน้าโดยไม่ขึ้นกับความกว้างที่มี.

ตัวอย่างอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่มีข้อความภาษาจีนและละติน มันตั้งค่าตัวเลือกการตัดบรรทัดทั้งสองอย่างอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อทดลองกับกฎใด ๆ ให้เปลี่ยนค่าที่สอดคล้องกันขณะที่ตั้งค่าอื่นคงที่ ตัวอย่างใช้ Arial ขนาด 24 จุดและ SimSun พร้อมความกว้างเฟรม 160 จุดและขอบกรอบข้อความแนวนอนเป็นศูนย์ [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) ถูกเรียกด้วย [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/), เพื่อให้ขนาดข้อความและขนาดเฟรมคงที่.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมเครื่องหมายวรรคตอนห้อย**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) ทำให้เครื่องหมายวรรคตอนที่เหมาะสมขยายออกไปเหนือขอบขวาของบรรทัดข้อความแทนที่จะอยู่ในบรรทัดต่อไป ใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องห้อย.

ตัวอย่างอิสระต่อไปนี้เปิดการใช้เครื่องหมายวรรคตอนห้อยในกรอบข้อความกว้าง 100 จุดและบันทึกเป็น "hanging_punctuation.pptx" ด้วย Arial 24 จุดและขอบกรอบข้อความแนวนอนเป็นศูนย์ จุดสุดท้ายของประโยคจะอยู่หลัง "sentence" และขยายเกินขอบขวาของข้อความ ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดเต็มจะอยู่ในบรรทัดแยก การตัดบรรทัดเปิดและการปรับอัตโนมัติปิดเพื่อคงความกว้างที่มี.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ไม่ใช่ทุกเครื่องหมายวรรคตอนจะสามารถห้อยได้ เงื่อนไข [แบบอักษรและการจัดวางที่อธิบายข้างต้น](#control-line-breaking) ยังใช้กับการเปรียบเทียบนี้: การเปลี่ยนแบบอักษร, ความกว้างที่มี, ขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไป.

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) กำหนดว่าข้อความทำอย่างไรเมื่อเกินขอบของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ไหลทับ, หรือปรับขนาดรูปร่างโดยอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดรูปทรงให้ปรับขนาดเพื่อให้พอดีกับข้อความและบันทึกผลเป็น "autofit_type.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพื่อคับจำนวนบรรทัดหลังจากการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือความกว้างของรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/nodejs-java/manage-paragraph/). จำนวนบรรทัดอย่างเดียวไม่บอกว่าข้อความไหลทับคอนเทนเนอร์หรือไม่.

## **ตั้งตำแหน่งยึดของกรอบข้อความ**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดว่าข้อความจัดตำแหน่งอย่างไรในแนวตั้งภายในรูปร่าง เช่น บน, กลาง, หรือล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปร่างแรกและบันทึกผลเป็น "text_anchor.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการแทบข้อความ**

ใช้ [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) และ [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) เพื่อกำหนดตำแหน่งหยุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 จุดและเพิ่มหยุดแท็บจัดซ้ายที่ 30 จุด การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษาตรวจสอบ**

Aspose.Slides มี [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) ที่ให้คุณตั้งค่าภาษาตรวจสอบสำหรับส่วนข้อความ ภาษาตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรกและอย่างน้อยหนึ่งย่อหน้า มันแทนที่เนื้อหาของย่อหน้าแรกด้วย "1。", ตั้งแบบอักษรเป็น SimSun, และกำหนดภาษาตรวจสอบจีนแบบง่าย (`zh-CN`). จากนั้นบันทึกผลเป็น "proofing_language.pptx":

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // ตั้งค่า Id ของภาษาตรวจสอบ.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากแม่แบบ ให้รักษาไว้ทั้ง [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) และ [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). ตัวอย่างอิสระต่อไปนี้สร้างส่วนต้นฉบับที่มีภาษาอังกฤษสหรัฐเป็นภาษาและฝรั่งเศสเป็นภาษาทางเลือก แล้วคัดลอข้อความและตัวระบุไปยังส่วนในพรีเซนเทชันใหม่.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // ถ้าแหล่งไม่มีภาษาทางเลือก, null จะลบค่าของปลายทางออก.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลองแหล่งที่ไม่มีภาษาทางเลือก ให้ละเว้นการกำหนด "fr-FR" ตัวระบุทางเลือกจะเป็น `null` และคำสั่งคัดลอเดียวกันจะคงไว้ซึ่งการไม่มีค่านั้นโดยไม่สร้างค่าดีฟอลท์ แม้ว่าปลายทางอาจเคยมีภาษาทางเลือกกำหนดไว้ก่อนหน้า.

ตัวระบุเหล่านี้จัดเก็บเป็นเมตาดาต้าภาษา การเก็บรักษาพวกมันไม่ได้กำหนดว่าพาวเวอร์พอยท์จะเลือกพจนานุกรมใดสำหรับการตรวจสอบการสะกดหรือไวยากรณ์.

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาดีฟอลท์สำหรับข้อความที่สร้างขณะโหลดหรือสร้างพรีเซนเทชัน ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ภาษาอังกฤษสหรัฐเป็นภาษาข้อความเริ่มต้น, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // ตรวจสอบภาษาของส่วนแรก.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **ตั้งค่ารูปแบบข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับพรีเซนเทชัน ใช้ [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

ตัวอย่างต่อไปนี้ตั้งแบบอักษรหนาขนาด 14 จุดเป็นค่าเริ่มต้นสำหรับย่อหน้าระดับบนในพรีเซนเทชันใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้หากไม่มีการจัดรูปแบบที่เฉพาะเจาะจงมากกว่ามาบังคับ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // ดึงรูปแบบย่อหน้าระดับบนสุด.
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

## **ดึงข้อความพร้อมเอฟเฟ็กต์อักษรพิมพ์ใหญ่ทั้งหมด**

ใน PowerPoint การใช้เอฟเฟ็กต์แบบ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กเดิม เมื่อนำส่วนข้อความดังกล่าวออกกับ Aspose.Slides ไลบรารีจะคืนข้อความตามที่ใส่ไว้ เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) และแปลงสตริงที่คืนเป็นตัวพิมพ์ใหญ่เมค่าของมันเป็น `All`.

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ย่อหน้าแรกของมันมีส่วนแรกเป็น "Hello, Aspose!" ที่ใช้เอฟเฟ็กต์ All Caps ตามที่แสดงด้านล่าง.

![เอฟเฟ็กต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงข้อความพร้อมเอฟเฟ็กต์ **All Caps** ที่ใช้:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
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

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). วนลูปผ่านเซลล์ต่าง ๆ และอัปเดตแต่ละเซลล์โดยใช้ [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ ใช้ [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). ตั้งค่า [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส.