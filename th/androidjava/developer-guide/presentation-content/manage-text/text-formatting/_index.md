---
title: จัดรูปแบบข้อความการนำเสนอบน Android
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/androidjava/text-formatting/
keywords:
- จัดแนวย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- การเว้นบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java ปรับแต่งฟอนต์, สี, การจัดแนว และอื่น ๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java โดยครอบคลุมสีพื้นหลัง, ความโปร่งใส, การเว้นระยะระหว่างอักขระ, คุณสมบัติของฟอนต์, การหมุน, การเว้นระยะย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, การตั้งค่าตำแหน่งแท็บ, และการตั้งค่าภาษา

หากไม่ได้ระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx) ข้อความแรกในสไลด์แรกเป็นกล่องข้อความ และย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง ดัชนีของสไลด์และรูปร่างใช้ค่าตั้งต้นจากศูนย์ ตัวอย่างที่เลือกส่วนที่หนาใช้การจัดรูปแบบที่มีผลจริงรวมถึงการจัดรูปแบบหนาที่สืบทอดมา:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตามตัวอักษรหรือการจับคู่โดย regular-expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/androidjava/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้ตั้งค่าสีไฮไลท์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าที่หนึ่ง สีไฮไลท์ที่กำหนดโดยตรงสำหรับส่วนข้อความแต่ละส่วนจะมีความสำคัญเหนือค่าดีฟอลต์นี้:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้สาธิตวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
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

ใช้ [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เพื่อตั้งค่าการจัดแนวย่อหน้าในกรอบข้อความ ค่าอาจเป็นกลาง, ด้านซ้าย, ด้านขวา, จัดบรรทัดเต็ม ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าไปที่ **ศูนย์กลาง**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าการจัดแนวของย่อหน้าให้เป็นศูนย์กลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนว](aligned_paragraph.png)

## **จัดแนวฟอนต์ภายในบรรทัด**

ใช้ [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) เพื่อจัดแนวในแนวตั้งของส่วนข้อความที่มีขนาดฟอนต์ต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของมัน

ตัวอย่างที่เป็นอิสระต่อไปนี้สร้างกล่องข้อความที่มีป้ายชื่อสี่กล่องบนสไลด์เดียว ย่อหน้าแต่ละย่อหน้ามีข้อความเดียวกันขนาด 18, 36, และ 54 pt โดยมีการจัดแนวฟอนต์ที่ต่างกัน ใช้ Arial ปิดการทำ autofit และการห่อข้อความ และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![การเปรียบเทียบการจัดแนวฟอนต์ Baseline, Top, Center, Bottom พร้อมขนาดฟอนต์ผสม](font_alignment.png)

การจัดแนวฟอนต์ใช้เมตริกของฟอนต์ ดังนั้นขอบที่มองเห็นของตัวอักษรแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์ ตัวอย่างรวมอักษรพิมพ์ใหญ่และตัวขากลับเพื่อช่วยแสดงความแตกต่างระหว่างการจัดแนว baseline และ bottom ความพร้อมใช้งานและการแทนที่ของฟอนต์ ตัวอักษรที่ใช้ และความแตกต่างของขนาดฟอนต์มีผลต่อผลลัพธ์ มิติของกรอบ, ระยะขอบ, ระยะบรรทัด, การห่อข้อความ, และ autofit ก็ส่งผลต่อการจัดเลย์เอาต์เช่นกัน; ควรใช้ฟอนต์และการตั้งค่าเลย์เอาต์เดียวกันเมื่อเปรียบเทียบโหมดต่าง ๆ

การตั้งค่านี้แตกต่างจาก [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), ซึ่งควบคุมการจัดแนวแนวนอนของย่อหน้า และ [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), ซึ่งกำหนดตำแหน่งบล็อกข้อความในแนวตั้งภายในรูปร่าง การจัดรูปแบบเป็นซูเปอร์สคริปต์และซับสคริปต์ผ่าน [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) จะเลื่อนส่วนข้อความแต่ละส่วนสัมพันธ์กับ baseline แทนที่จะแนวฟอนต์สำหรับบรรทัดของย่อหน้า

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมโดยส่วนประกอบ alpha ของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่อง alpha แบบ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) เพื่อเพิ่มหรือบีบระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าลบจะบีบข้อความ

โค้ด Java ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างอักขระ.
            portion.getPortionFormat().setSpacing(3); // ขยายระยะห่างอักขระ.
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

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูคอมแคบกว่าข้อความเดียวกันใน PowerPoint นี่อาจเกิดจาก PowerPoint ข้ามข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและมีการเปิดใช้งาน kerning ในการตั้งค่า PowerPoint

เพื่อทำให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint ในกรณีเหล่านี้ คุณสามารถปิดการ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ให้เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ตรวจสอบชื่อฟอนต์ที่มีผลรวมถึงฟอนต์ที่สืบทอดและตั้งค่าขีดจำกัด 100 จุดสำหรับส่วนที่ใช้ Roboto ซึ่งจะปิดการ kerning สำหรับส่วนที่มีขนาดฟอนต์ต่ำกว่า 100 จุด:

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

สำหรับข้อความที่ตรงกับเกณฑ์และมีขนาดต่ำกว่าขีดจำกัด การตั้งค่านี้จะป้องกันการ kerning และช่วยให้การแสดงผลของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) หรือบนส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 pt พร้อมการหนา, ตัวเอียง, และการขีดเส้นใต้แบบจุด จุดกำหนดการจัดรูปแบบโดยตรงบนส่วนข้อความแต่ละส่วนจะมีความสำคัญเหนือค่าเริ่มต้นเหล่านี้:

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

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 pt, การจัดรูปแบบเป็นตัวเอียง, และขีดเส้นใต้แบบจุดกับส่วนที่มีการจัดรูปแบบจริงเป็นหนา:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าคุณสมบัติของฟอนต์สำหรับส่วนข้อความ.
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

## **ตั้งค่าการหมุนข้อความ**

ใช้ [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าในรูปร่าง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาตรงทวนเข็มนาฬิกา**:

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

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) เพื่อตั้งค่ามุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)

ตัวอย่างโค้ดต่อไปนี้จะหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาในรูปร่าง:

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

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) เพื่อควบคุมการเว้นระยะย่อหน้า คุณสมบัติเหล่านี้ใช้ดังต่อไปนี้:

- ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
- ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นหน่วยจุด

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นบรรทัดภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (เว้นบรรทัดสองเท่า):

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

กฎการตัดบรรทัดของย่อหน้ามีประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก วิธีต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), ดังนั้นใช้ได้กับย่อหน้าเต็ม:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนค่านี้อาจเปลี่ยนตำแหน่งการห่อของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ใกล้เคียง
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ตำแหน่งเริ่มต้นและสิ้นสุดบรรทัด

กฎเหล่านี้ไม่ได้แทนที่ [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), ที่เปิดใช้งานการห่ออัตโนมัติภายในกรอบข้อความ พวกมันส่งผลต่อการจัดวางเมื่อมีการห่อ; ไม่ได้แทรกตัวอักษรการตัดบรรทัด การตัดบรรทัดแบบชัดเจนจะบังคับให้มีบรรทัดใหม่ในย่อหน้าโดยไม่คำนึงถึงความกว้างที่มีอยู่

ตัวอย่างที่เป็นอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่มีข้อความจีนและละติน ตั้งค่าตัวเลือกการตัดบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อทดลองแต่ละกฎให้เปลี่ยนค่าที่สอดคล้องกันในขณะที่ตั้งค่าอื่นคงที่ ตัวอย่างใช้ Arial และ SimSun ขนาด 24 pt พร้อมความกว้างกรอบ 160 pt และระยะขอบแนวนอนศูนย์ [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ถูกเรียกด้วย [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติของกรอบคงที่.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) ทำให้เครื่องหมายวรรคตอนที่สามารถห้อยได้ขยับออกนอกขอบขวาของบรรทัดข้อความแทนที่จะอยู่บรรทัดถัดไป ใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องห้อย

ตัวอย่างที่เป็นอิสระต่อไปนี้เปิดใช้งานเครื่องหมายวรรคตอนห้อยในกรอบข้อความกว้าง 100 pt และบันทึกเป็น "hanging_punctuation.pptx" โดยใช้ Arial 24 pt และระยะขอบแนวนอนศูนย์ จุดสุดท้ายจะอยู่หลัง "sentence" และขยายออกนอกขอบขวาของข้อความ ตั้งค่าคุณสมบัติเป็น [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดสุดท้ายจะอยู่ในบรรทัดแยก การห่อเปิดใช้งานและ autofit ปิดเพื่อคงความกว้างที่มี.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

ไม่ใช่เครื่องหมายวรรคตอนทุกตัวจะสามารถห้อยได้ เงื่อนไขของ [ฟอนต์และการจัดวางที่อธิบายข้างต้น](#control-line-breaking) ยังใช้กับการเปรียบเทียบนี้: การเปลี่ยนฟอนต์, ความกว้างที่มี, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นได้หายไป

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) กำหนดวิธีการทำงานของข้อความเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดค่ารูปร่างให้ปรับขนาดเพื่อให้พอดีกับข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx".

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

เพื่อวัดจำนวนบรรทัดหลังการห่ออัตโนมัติและดูว่าขนาดข้อความหรือรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/androidjava/manage-paragraph/). จำนวนบรรทัดอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **ตั้งค่าจุดยึดของกรอบข้อความ**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) กำหนดวิธีการวางข้อความในแนวตั้งภายในรูปร่าง เช่น ที่ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความที่ด้านล่างของรูปร่างแรกและบันทึกผลลัพธ์เป็น "text_anchor.pptx".

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

## **ตั้งค่าการแท็บข้อความ**

ใช้ [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) เพื่อตั้งค่าตำแหน่งแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 pt และเพิ่มตำแหน่งแท็บชิดซ้ายที่ 30 pt การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

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

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), ซึ่งให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษา proofing กำหนดภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรกและอย่างน้อยหนึ่งย่อหน้า เปลี่ยนเนื้อหาของย่อหน้าแรกเป็น "1。", ตั้งค่า SimSun เป็นฟอนต์และกำหนดภาษ proofing เป็นภาษาจีนแผ่นดินใหญ่ (`zh-CN`). บันทึกผลลัพธ์เป็น "proofing_language.pptx":

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

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาเริ่มต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างการนำเสนอ ตัวอย่างต่อไปนี้สร้างการนำเสนอโดยตั้งค่าภาษาเริ่มต้นเป็นภาษาอังกฤษสหรัฐ (US English), เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างสี่เหลี่ยมใหม่พร้อมข้อความ.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **ตั้งค่ารูปแบบข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับการนำเสนอ ใช้ [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์หนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับย่อหน้าในระดับบนของการนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้หากไม่ได้รับการแทนที่โดยการจัดรูปแบบที่เฉพาะเจาะจงอื่น.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // รับรูปแบบย่อหน้าระดับบนสุด.
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

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กเดิม เมื่อคุณดึงส่วนข้อความนั้นด้วย Aspose.Slides ไลบรารีจะส่งคืนข้อความตามที่พิมพ์ไว้เพื่อให้ตรงกับข้อความที่แสดง ต้องตรวจสอบ [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่ามีค่า `All`

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ย่อหน้าแรกของมันส่วนแรกมีข้อความ "Hello, Aspose!" พร้อมเอฟเฟกต์ All Caps ตามที่แสดงด้านล่าง.

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ถูกนำมาใช้:

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

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**ฉันจะใช้สีไล่ระดับกับข้อความบนสไลด์ PowerPoint ได้อย่างไร?**

เพื่อใช้สีไล่ระดับกับข้อความ ใช้ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) และกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส.