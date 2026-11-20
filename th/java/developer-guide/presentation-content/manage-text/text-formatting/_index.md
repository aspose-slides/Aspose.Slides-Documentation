---
title: "จัดรูปแบบข้อความในการนำเสนอด้วย Java"
linktitle: "การจัดรูปแบบข้อความ"
type: docs
weight: 50
url: /th/java/text-formatting/
keywords:
- "จัดย่อหน้า"
- "สไตล์ข้อความ"
- "พื้นหลังข้อความ"
- "ความโปร่งใสของข้อความ"
- "ระยะห่างระหว่างอักขระ"
- "คุณสมบัติของฟอนต์"
- "ตระกูลฟอนต์"
- "การหมุนข้อความ"
- "มุมการหมุน"
- "กรอบข้อความ"
- "ระยะห่างบรรทัด"
- "คุณสมบัติ Autofit"
- "จุดยึดของกรอบข้อความ"
- "การตั้งค่าตารางแท็บของข้อความ"
- "ภาษาปริยาย"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "จัดรูปแบบและตกแต่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java ปรับแต่งฟอนต์ สี การจัดแนว และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for Java ครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของฟอนต์, การหมุน, ระยะห่างของย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ยกเว้นจะระบุไว้เป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx) รูปทรงแรกบนสไลด์แรกเป็นกล่องข้อความ และย่อหน้าแรกของมันมีข้อความแสดงด้านล่าง ทั้งดัชนีสไลด์และรูปทรงใช้เลขศูนย์เป็นฐาน ตัวอย่างที่เลือกส่วนข้อความที่หนาตัวอักษรใช้การจัดรูปแบบที่มีประสิทธิภาพรวมถึงการจัดรูปแบบหนาที่สืบทอดมาด้วย:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความตัวอักษรหรือการจับคู่แบบ regular‑expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/java/search-and-replace-text/).

## **กำหนดสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) เพื่อกำหนดสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้กำหนดไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลต์ที่กำหนดโดยตรงบนส่วนข้อความแต่ละส่วนจะมีสิทธิ์เหนือค่าที่กำหนดเริ่มต้นนี้:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลต์สำหรับย่อหน้าทั้งหมด.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

โค้ดตัวอย่างต่อไปแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีไฮไลต์สำหรับส่วนข้อความ.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เพื่อกำหนดการจัดแนวย่อหน้าในกรอบข้อความ ค่าอาจเป็น centered, left‑aligned, right‑aligned, justified ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **กึ่งกลาง**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าการจัดแนวของย่อหน้าเป็นกึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **จัดแนวฟอนต์ภายในบรรทัด**

ใช้ [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) เพื่อจัดแนวแนวตั้งของส่วนข้อความที่มีขนาดฟอนต์ต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของย่อหน้า

ตัวอย่างต่อไปนี้สร้างกล่องข้อความสี่กล่องที่มีป้ายกำกับบนสไลด์เดียว แต่ละย่อหน้ามีข้อความเดียวกันที่ขนาด 18, 36, และ 54 จุด พร้อมการจัดแนวฟอนต์ที่แตกต่างกัน ใช้ Arial ปิดการ autofit และการห่อข้อความ และทำให้กรอบข้อความใหญ่พอที่จะบรรจุบรรทัดเดียว

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เปรียบเทียบการจัดแนว Baseline, Top, Center, และ Bottom กับขนาดฟอนต์ผสม](font_alignment.png)

การจัดแนวฟอนต์ใช้เมตริกของฟอนต์ ดังนั้นขอบของตัวอักษรแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์ ตัวอย่างรวมอักษรตัวพิมพ์ใหญ่และตัวที่มีส่วนยาวลงเพื่อแสดงความแตกต่างระหว่าง baseline และ bottom การใช้งานฟอนต์และการแทนที่ฟอนต์ ตัวอักษรที่ใช้ และความแตกต่างของขนาดฟอนต์ทั้งหมดส่งผลต่อผลลัพธ์ ความกว้างของเฟรม, ระยะขอบ, ระยะห่างบรรทัด, การห่อและการ autofit ก็มีผลต่อการจัดวาง; ควรใช้ฟอนต์และการตั้งค่าเดียวกันเมื่อเปรียบเทียบโหมด

การตั้งค่านี้แตกต่างจาก [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) ที่ควบคุมการจัดแนวแนวนอนของย่อหน้า, และ [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) ที่กำหนดตำแหน่งกรอบข้อความในแนวตั้งภายในรูปร่าง การจัดรูปแบบ superscript และ subscript ผ่าน [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) จะย้ายส่วนข้อความแต่ละส่วนสัมพันธ์กับ baseline แทนการตั้งค่าการจัดแนวฟอนต์สำหรับบรรทัดของย่อหน้า

## **กำหนดความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านส่วนประกอบ alpha ของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). ตัวอย่างต่อไปนี้ `alpha = 50` เป็นค่า ARGB alpha‑channel บนสเกล 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

โค้ดตัวอย่างต่อไปแสดงวิธีนำความโปร่งใสไปใช้กับ **ย่อหน้าทั้งหมด**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปแสดงวิธีนำความโปร่งใสไปใช้กับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าความโปร่งใสของส่วนข้อความ.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **กำหนดระยะห่างระหว่างตัวอักษรสำหรับข้อความ**

ใช้ [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) เพื่อเพิ่มหรือลดระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าลบจะทำให้ข้อความกระชับขึ้น

โค้ด Java ต่อไปนี้แสดงวิธีเพิ่มระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // เพิ่มระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

โค้ดตัวอย่างต่อไปแสดงวิธีเพิ่มระยะห่างอักขระใน **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
            portion.getPortionFormat().setSpacing(3); // เพิ่มระยะห่างระหว่างอักขระ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint เนื่องจาก PowerPoint อาจละเลยข้อมูล kerning สำหรับฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดการ kerning ไว้ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint คุณสามารถปิดการ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ให้มากกว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการ “presentation.pptx” ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ตรวจสอบชื่อฟอนต์ที่มีผล (รวมถึงฟอนต์ที่สืบทอด) และตั้งค่าเกณฑ์ 100 จุดสำหรับส่วนข้อความที่ใช้ Roboto การตั้งค่านี้จะปิดการ kerning สำหรับส่วนข้อความที่มีขนาดฟอนต์ต่ำกว่า 100 จุด:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับข้อความที่ตรงกับเกณฑ์นี้ การตั้งค่านี้จะป้องกัน kerning และช่วยให้การแสดงผลของ Aspose.Slides ใกล้เคียงกับผลลัพธ์ที่ PowerPoint แสดงสำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติของฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) หรือบนส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/)

ตัวอย่างต่อไปนี้กำหนดฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการทำให้หนา, ตัวเอียง, และขีดเส้นใต้แบบจุด จุดสีฟอนต์ที่กำหนดโดยตรงบนส่วนข้อความจะมีสิทธิ์เหนือค่าตั้งต้นเหล่านี้:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้นำ Times New Roman ขนาด 13 จุด, ตัวเอียง, และขีดเส้นใต้แบบจุดไปใช้กับส่วนข้อความที่มีการจัดรูปแบบที่มีผลเป็นหนา:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ควบคุมการทำให้ความสูงของข้อความเป็นมาตรฐาน**

ใช้ [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) เมื่อต้องการทำสำเนาเทคนิคการพิมพ์แบบเทมเพลตหรือศึกษาความแตกต่างของความสูงของอักขระ ใน PowerPoint การเปิดใช้งานการทำให้เป็นมาตรฐานจะยืดหรือบีบอักขระแต่ละตัวในแนวตั้งให้มีความสูงที่มองเห็นได้เท่ากันภายในส่วนข้อความ แต่ไม่ได้รับประกันความสูงของข้อความเท่ากันระหว่างฟอนต์ต่าง ๆ

ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.True หรือ False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำให้เป็นมาตรฐานอย่างชัดเจน `NullableBool.NotDefined` ทำให้การตั้งค่าท้องถิ่นไม่มีค่าและส่วนข้อความจะสืบทอดค่าจาก [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ของย่อหน้า ไม่ได้หมายถึง `False` ใช้ [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) และอ่านค่า [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) เพื่อรับค่า Boolean ที่สรุปแล้ว

ตัวอย่างต่อไปนี้ต้องมี **Arial** ติดตั้งอยู่ สร้างบล็อกข้อความสองบล็อกที่มีอักษรพิมพ์ใหญ่, พิมพ์เล็ก, ตัวลงเส้น, และอักขระที่มีสำเนียงขนาด 54 จุด ทั้งสองย่อหน้าตั้งค่าให้ทำให้เป็นมาตรฐานโดยค่าเริ่มต้น ส่วนบนปิดการทำให้เป็นมาตรฐานอย่างชัดเจน; ส่วนล่างสืบทอดการตั้งค่า การตั้งค่าขนาดเฟรม, ระยะขอบ, และระยะห่างของย่อหน้าเหมือนกัน โดยปิดการห่อและการ autofit เพื่อให้การเปรียบเทียบคงที่ ตัวอย่างพิมพ์ `False: false` และ `NotDefined: true` แล้วบันทึกเป็น “text_height_normalization.pptx”

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างได้ส่งออกจากงานนำเสนอที่บันทึกไว้ แถวบนปิดการทำให้เป็นมาตรฐาน (`False`) ส่วนล่างสืบทอดการเปิดใช้งาน (`NotDefined` → `True`) โปรดติดตั้ง Arial เพื่อให้ผลลัพธ์นี้ปรากฏ

![ข้อความ Arial ขนาด 54 จุดที่ปิดการทำให้เป็นมาตรฐานด้านบนและเปิดการทำให้เป็นมาตรฐานจากการสืบทอดด้านล่าง](text_height_normalization.png)

การทำให้เป็นมาตรฐานเปลี่ยนความสูงของอักขระโดยไม่เปลี่ยนค่า [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) ซึ่งระบุขนาดฟอนต์เป็นจุด ย่อหน้า [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) ควบคุมระยะห่างบรรทัด ส่วนกรอบข้อความ [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ควบคุมวิธีที่ข้อความหรือคอนเทนเนอร์ปรับขนาดให้พอดี การตั้งค่าเหล่านี้ทำหน้าที่ต่างกันและอาจส่งผลต่อโครงร่างโดยรวมได้อย่างอิสระ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ดูที่ [จัดการย่อหน้า](/slides/th/java/manage-paragraph/).

## **ใส่และลบการขีดเส้นทับข้อความ**

ใช้ [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาที่เคยมีโดยไม่ต้องลบข้อความต้นฉบับ ตั้งค่าเป็น [TextStrikethroughType.Single หรือ Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) เพื่อแสดงเส้นขีดผ่านข้อความหนึ่งหรือสองเส้น

เพื่อเอาการขีดเส้นทับออก ให้ใช้ [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) การตั้งค่านี้จะปิดการทำงานโดยชัดเจน แม้ฟอร์แมตโดยรอบจะกำหนดให้มีการขีดเส้นทับ อย่างตรงกันข้าม [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) จะทำให้การตั้งค่าท้องถิ่นไม่มีค่า ทำให้ส่วนข้อความสืบทอดการจัดรูปแบบจากย่อหน้า ตัวเลือกนี้ไม่ได้รับประกันว่าจะลบการขีดเส้นทับออก ใช้ [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) เพื่ออ่านรูปแบบที่ได้รวมถึงค่าที่สืบทอด

ตัวอย่างต่อไปสร้างการเปรียบเทียบราคาสามแบบ ย่อหน้าแต่ละย่อหน้ามีส่วนข้อความแยกสำหรับป้ายชื่อ, ราคาก่อน, และราคาปัจจุบัน ดังนั้นจึงมีผลต่อส่วนราคาก่อนเท่านั้น แถวแรกใส่และลบการขีดเส้นทับ; แถวอื่นคงการขีดเส้นทับแบบ single และ double การเปลี่ยนแปลงนี้ช่วยรักษาข้อความและการจัดรูปแบบอื่น ๆ รวมถึงการทำให้ราคาก่อนหนา

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // ใช้การขีดเส้นทับ, แล้วลบออกอย่างชัดเจนจากราคาก่อนหน้าแรก.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากบนลงล่าง: ไม่มีการขีดเส้นทับ, การขีดเส้นทับเดี่ยว, และการขีดเส้นทับคู่

![ราคาก่อนไม่มีการขีดเส้นทับ, มีการขีดเส้นทับเดี่ยว, และมีการขีดเส้นทับคู่](strikethrough.png)

## **กำหนดการหมุนข้อความ**

ใช้ [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) เพื่อตั้งค่าการวางทิศทางข้อความแบบกำหนดล่วงหน้าในรูปร่าง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางทิศทางข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) ซึ่งจะหมุนข้อความ **90 องศาตรงทวนเข็มนาฬิกา**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **กำหนดการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) เพื่อตั้งค่ามุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)

โค้ดตัวอย่างต่อไปหมุนกรอบข้อความ 3 องศา ตามเข็มนาฬิกาภายในรูปร่าง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **กำหนดการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้

* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นจุด

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นบรรทัดภายในย่อหน้าแรกเป็น 200 % ของความสูงบรรทัด (สองเท่า):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเว้นบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก วิธีต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) จึงใช้กับย่อหน้าเต็ม:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนอาจทำให้ตำแหน่งการห่อของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ใกล้เคียงเปลี่ยนไป
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ตำแหน่งเริ่มต้นและสิ้นสุดของบรรทัด

กฎเหล่านี้ไม่แทนที่ [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) ที่เปิดการห่ออัตโนมัติภายในกรอบข้อความ พวกมันมีผลต่อการจัดวางเมื่อเกิดการห่อ; ไม่ได้แทรกอักขระการตัดบรรทัด การตัดบรรทัดอย่างชัดเจนบังคับให้สร้างบรรทัดใหม่ภายในย่อหน้าโดยอิสระจากความกว้างที่ใช้ได้

ตัวอย่างต่อไปนี้สร้างบล็อกข้อความแคบที่มีภาษาจีนและละติน ตั้งค่าตัวเลือกการตัดบรรทัดทั้งสองแบบอย่างชัดเจนและบันทึกเป็น “line_breaking.pptx” เพื่อทดลองกับกฎใดกฎหนึ่ง ให้เปลี่ยนค่าที่สอดคล้องกันในขณะที่ค่าที่เหลือคงที่ ตัวอย่างใช้ Arial ขนาด 24 จุดและ SimSun พร้อมความกว้างเฟรม 160 จุดและระยะขอบกรอบข้อความแนวนอนเป็นศูนย์ [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ถูกเรียกด้วย [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและขนาดเฟรมคงที่

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมเครื่องหมายวรรคตอนห้อย**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) ทำให้เครื่องหมายวรรคตอนที่มีคุณสมบัติตรงขอบขวาของบรรทัดข้อความแทนที่จะอยู่บนบรรทัดถัดไป ใช้กับย่อหน้าทั้งหมดและต่างจากการเยื้องห้อย

ตัวอย่างต่อไปนี้เปิดใช้งานเครื่องหมายวรรคตอนห้อยในกรอบข้อความกว้าง 100 จุดและบันทึกเป็น “hanging_punctuation.pptx” ด้วย Arial ขนาด 24 จุดและระยะขอบกรอบข้อความแนวนอนเป็นศูนย์ จุดสุดท้ายยังคงอยู่หลังคำ “sentence” และขยายออกไปเกินขอบขวาของข้อความ ตั้งค่าคุณสมบัติเป็น [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยค่าตามนี้ จุดสุดท้ายจะอยู่บนบรรทัดแยกออก การห่อเปิดและการ autofit ปิดเพื่อคงความกว้างคงที่

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ไม่ใช่เครื่องหมายวรรคตอนทุกตัวที่จะห้อยได้ เงื่อนไขของฟอนต์และการจัดวางที่อธิบายไว้ด้านบน ([ควบคุมการตัดบรรทัด](#control-line-breaking)) ก็ใช้กับการเปรียบเทียบนี้เช่นกัน: การเปลี่ยนฟอนต์, ความกว้างที่ใช้ได้, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไป

## **กำหนดประเภท Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) กำหนดว่า ข้อความจะทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, เกิน, หรือปรับขนาดรูปร่างโดยอัตโนมัติ ตัวอย่างต่อไปนี้ตั้งค่ารูปร่างให้ปรับขนาดให้พอดีกับข้อความและบันทึกผลลัพธ์เป็น “autofit_type.pptx”

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพื่อให้นับจำนวนบรรทัดหลังการห่ออัตโนมัติและดูว่าขนาดข้อความหรือความกว้างของรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/java/manage-paragraph/) จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความเกินคอนเทนเนอร์หรือไม่

## **กำหนดจุดยึดของกรอบข้อความ**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) กำหนดว่าข้อความอยู่ในแนวตั้งภายในรูปร่างที่ตำแหน่งใด เช่น ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปร่างแรกและบันทึกผลลัพธ์เป็น “text_anchor.pptx”

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดการตั้งค่าตารางแท็บของข้อความ**

ใช้ [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 จุดและเพิ่มจุดหยุดแท็บซ้ายที่ 30 จุด การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **กำหนดภาษาการตรวจสอบ**

Aspose.Slides มี [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ที่อนุญาตให้ตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบจะกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องมี “presentation.pptx” ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก และอย่างน้อยหนึ่งย่อหน้า แทนที่เนื้อหาของย่อหน้าแรกด้วย “1。”, ตั้งค่า SimSun เป็นฟอนต์และกำหนดภาษาการตรวจสอบ Simplified Chinese (`zh-CN`) บันทึกผลลัพธ์เป็น “proofing_language.pptx”

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // ตั้งค่า Id ของภาษาการตรวจสอบ.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากเทมเพลต ควรรักษาทั้ง [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) และ [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) ตัวอย่างต่อไปนี้สร้างส่วนต้นฉบับที่มี US English เป็นภาษาและ French เป็นภาษาทางเลือก แล้วคัดลึกข้อความและตัวระบุไปยังส่วนในงานนำเสนอใหม่

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // ถ้าแหล่งไม่มีภาษาทางเลือก, ค่า null จะล้างค่าของปลายทาง.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการลองแหล่งข้อมูลที่ไม่มีภาษาทางเลือก ให้อีกขั้นตอนการกำหนดค่า `"fr-FR"` ไม่ทำให้ค่าเป็น `null` ตัวระบุทางเลือกจะเป็น `null` และคำสั่งคัดลอกเดียวกันจะคงความไม่มีค่านั้นไว้โดยไม่สร้างค่าเริ่มต้น แม้จุดหมายอาจเคยมีภาษาทางเลือกกำหนดไว้ก่อน

ตัวระบุเหล่านี้เป็นเมตาดาต้าภาษา การรักษาไว้ไม่ได้บ่งบอกว่า PowerPoint จะเลือกพจนานุกรมใดสำหรับการตรวจสอบการสะกดหรือไวยากรณ์

## **กำหนดภาษาปริยาย**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาปริยายสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มี US English เป็นภาษาข้อความปริยาย, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรก

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **กำหนดสไตล์ข้อความปริยาย**

เพื่อใช้การจัดรูปแบบข้อความปริยายระดับงานนำเสนอ ใช้ [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)

ตัวอย่างต่อไปนี้ตั้งฟอนต์หนาขนาด 14 จุดเป็นค่าเริ่มต้นสำหรับย่อหน้าในระดับบนของงานนำเสนอใหม่และบันทึกเป็น “default_text_style.pptx” ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้ เว้นแต่การจัดรูปแบบที่เจาะจงมากกว่าจะมันทับ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Get the top level paragraph format.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ดึงข้อความที่มีเอฟเฟกต์ตัวพิมพ์ใหญ่ทั้งหมด**

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็ก ตัวอย่างเช่น เมื่อดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์จริง เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) และแปลงสตริงที่ได้เป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`

ตัวอย่างนี้ต้องมี “sample2.pptx” ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ย่อหน้าแรกของมันมีส่วนแรกที่มี “Hello, Aspose!” พร้อมเอฟเฟกต์ All Caps ตามภาพด้านล่าง

![เอฟเฟกต์ตัวพิมพ์ใหญ่ทั้งหมด](all_caps_effect.png)

โค้ดตัวอย่างต่อไปแสดงวิธีดึงข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ได้ใช้:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). วนลูปผ่านเซลล์และอัพเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint ได้อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส

คุณลักษณะที่เกี่ยวข้อง: [Format text within slides](/slides/th/features/text-formatting/).