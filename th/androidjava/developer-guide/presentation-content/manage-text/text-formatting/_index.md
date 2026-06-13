---
title: จัดรูปแบบข้อความการนำเสนอบน Android
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/androidjava/text-formatting/
keywords:
- เน้นข้อความ
- นิพจน์ปกติ
- จัดย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติฟอนต์
- แบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- เฟรมข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติการปรับอัตโนมัติ
- จุดยึดเฟรมข้อความ
- การตั้งค่าแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java ปรับแต่งฟอนต์ สี การจัดแนวและอื่น ๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for Android ผ่าน Java ครอบคลุมการเน้นสี, สีพื้นหลัง, ความโปร่งแสง, ระยะห่างระหว่างอักขระ, คุณสมบัติเช_FONT_, การหมุน, การเว้นบรรทัด, พฤติกรรมอัตโนมัติ, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เน้นข้อความ**

ใช้เมธอด [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) เมื่อคุณต้องการเน้นข้อความที่ตรงกับตัวอย่างเฉพาะในเฟรมข้อความ เมธอดจะใส่สีเน้นให้กับส่วนข้อความที่ตรงกันและสามารถใช้ร่วมกับ [ITextSearchOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextSearchOptions) เพื่อควบคุมวิธีการค้นหา เช่น การจับคู่เฉพาะคำเต็ม

โค้ดตัวอย่างด้านล่างเน้นการปรากฏของอักขระ **“try”** ทั้งหมดแล้วจึงเน้นเฉพาะคำเต็ม **“to”** เท่านั้น

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงรูปทรงแรกจากสไลด์แรก.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // เน้นคำ "try" ในรูปทรง.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // เน้นคำ "to" ในรูปทรง.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่เน้นแล้ว](highlighted_text.png)

## **เน้นข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) จะเน้นข้อความที่ตรงกับการค้นหาตามนิพจน์ปกติ

โค้ดตัวอย่างด้านล่างเน้นคำทั้งหมดที่มี **เจ็ดอักขระขึ้นไป**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // เน้นคำทั้งหมดที่มีอักขระเจ็ดตัวหรือมากกว่า.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่เน้นโดยใช้ regular expression](highlighted_text_using_regex.png)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้เมธอด [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) เพื่อกำหนดสีเน้นเริ่มต้นให้กับย่อหน้าทั้งหมด หรือใช้เมธอด [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีเน้นสำหรับย่อหน้าเต็ม.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีเน้นสำหรับส่วนข้อความ.
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

## **จัดแนวย่อหน้าของข้อความ**

ใช้เมธอด [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) เพื่อกำหนดการจัดแนวย่อหน้าภายในเฟรมข้อความ ค่าที่ตั้งได้อาจเป็นจัดกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดแบบเต็มบรรทัด ฯลฯ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **กึ่งกลาง**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **ตั้งค่าความโปร่งแสงของข้อความ**

ความโปร่งแสงของข้อความถูกควบคุมผ่านองค์ประกอบอัลฟาของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) ในตัวอย่างด้านล่าง `alpha = 50` คือค่าช่องอัลฟา ARGB บนสเกล 0‑255 ไม่ได้หมายถึงเปอร์เซ็นต์ความโปร่งแสง

โค้ดตัวอย่างด้านล่างแสดงวิธีใช้ความโปร่งแสงกับ **ย่อหน้าทั้งหมด**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีเติมของข้อความให้เป็นสีโปร่งแสง.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งแสง](transparent_paragraph.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

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

![ส่วนข้อความที่โปร่งแสง](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะห่างระหว่างอักขระของข้อความ**

ใช้เมธอด [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) เพื่อขยายหรือหดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด Java ต่อไปนี้แสดงวิธีขยายระยะห่างระหว่างอักขระใน **ย่อหน้าทั้งหมด**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าลบเพื่อลดระยะห่างระหว่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // หมายเหตุ: ใช้ค่าลบเพื่อลดระยะห่างระหว่างอักขระ.
            portion.getPortionFormat().setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้งาน Kerning สำหรับฟอนต์บางตัว**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint ซึ่งอาจเกิดจาก PowerPoint ไม่สนใจข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ไว้ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint ในกรณีดังกล่าว คุณสามารถปิด kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติเบรนด์ของข้อความ**

คุณสมบัติเบรนด์ของฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) หรือที่ระดับส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPortionFormat)

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับ **ย่อหน้าทั้งหมด**: ใช้ขนาดฟอนต์, ตัวหนา, ตัวเอียง, เส้นขีดล่างแบบจุดและฟอนต์ Times New Roman กับทุกส่วนในย่อหน้า

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าคุณสมบัติของฟอนต์สำหรับย่อหน้า.
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

![คุณสมบัติเบรนด์ของย่อหน้า](font_properties_for_paragraph.png)

โค้ดตัวอย่างด้านล่างนำคุณสมบัติเดียวกันไปใช้กับ **ส่วนข้อความที่มีฟอนต์หนา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

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

![คุณสมบัติเบรนด์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้เมธอด [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) เพื่อกำหนดการจัดแนวข้อความที่กำหนดล่วงหน้าในรูปทรง

โค้ดต่อไปนี้ตั้งค่าการจัดแนวข้อความในรูปทรงเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาตรงข้ามเข็มนาฬิกา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนของข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับเฟรมข้อความ**

ใช้เมธอด [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) เพื่อกำหนดมุมการหมุนแบบกำหนดเองให้กับ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame)

โค้ดตัวอย่างด้านล่างหมุนเฟรมข้อความ 3 องศาตามเข็มนาฬิกาในรูปทรง:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการเว้นระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides ให้เมธอด [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) เพื่อควบคุมการเว้นระยะของย่อหน้า คุณลักษณะเหล่านี้ใช้ดังนี้

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นจุด

โค้ดตัวอย่างต่อไปนี้แสดงวิธีระบุการเว้นบรรทัดภายในย่อหน้า:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเว้นบรรทัดภายในย่อหน้า](line_spacing.png)

## **ตั้งค่าประเภท Autofit สำหรับเฟรมข้อความ**

เมธอด [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) กำหนดพฤติกรรมของข้อความเมื่อมีขนาดเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะย่อขนาด, ล้นออกนอก หรือปรับขนาดรูปทรงโดยอัตโนมัติ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าจุดยึดของเฟรมข้อความ**

เมธอด [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) กำหนดวิธีการจัดตำแหน่งข้อความแนวตั้งภายในรูปทรง เช่น สูงสุด, กลาง, หรือต่ำสุด

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการแท็บของข้อความ**

ใช้เมธอด [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **ตั้งค่าภาษาการตรวจสอบคำ**

Aspose.Slides มีเมธอด [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) ซึ่งช่วยให้คุณตั้งค่าภาษาการตรวจสอบการสะกดและไวยากรณ์สำหรับส่วนข้อความ ภาษานี้จะถูกใช้โดย PowerPoint ในการตรวจสอบ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // ตั้งค่า ID ของภาษาตรวจสอบ.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้เมธอด [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาที่ใช้เป็นค่าเริ่มต้นสำหรับข้อความที่สร้างระหว่างการโหลดหรือสร้างการนำเสนอใหม่

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างสี่เหลี่ยมจัตุรัสใหม่พร้อมข้อความ.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับการนำเสนอ ให้ใช้เมธอด [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--)

โค้ดต่อไปนี้กำหนดฟอนต์หนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของการนำเสนอใหม่

```java
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

## **ดึงข้อความที่มีเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** จะทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่ทั้งหมด แม้ว่าต้นฉบับจะพิมพ์เป็นตัวพิมพ์เล็กก็ตาม เมื่อคุณดึงส่วนข้อความแบบนี้ด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้เดิม เพื่อให้ตรงกับที่แสดงบนสไลด์ ให้ตรวจสอบค่า [TextCapType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextCapType) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`

สมมติว่าเรามีกล่องข้อความดังต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีดึงข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ถูกนำมาใช้:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **FAQ**

**จะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้เมธอด [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITable) ทำการวนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICell#getTextFrame--) พร้อมกับการจัดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--)

**จะใส่สีไล่ระดับให้กับข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใส่สีไล่ระดับให้กับข้อความ ใช้เมธอด [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FillType) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทางและความโปร่งแสง)