---
title: จัดรูปแบบข้อความการนำเสนอใน Java
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/java/text-formatting/
keywords:
- ไฮไลท์ข้อความ
- นิพจน์ปกติ
- จัดตำแหน่งย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- การยึดกรอบข้อความ
- การตั้งค่าแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดรูปแบบและกำหนดสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java ปรับแต่งฟอนต์ สี การจัดตำแหน่ง และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Java รวมถึงการไฮไลท์, สีพื้นหลัง, ความโปร่งแสง, ระยะห่างระหว่างอักขระ, คุณสมบัติของฟอนต์, การหมุน, ระยะห่างของย่อหน้า, พฤติกรรม Autofit, การยึดตำแหน่งข้อความ, การตั้งค่าตำแหน่งแท็บ, และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **ไฮไลท์ข้อความ**

ใช้เมธอด [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) เมื่อคุณต้องการไฮไลท์ข้อความที่ตรงกับตัวอย่างเฉพาะภายในกรอบข้อความ เมธอดจะใส่สีไฮไลท์ให้กับส่วนของข้อความที่ตรงกันและสามารถใช้ร่วมกับ [TextSearchOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/) เพื่อควบคุมวิธีการค้นหาได้ ตัวอย่างเช่น เพื่อจับคู่เฉพาะคำเต็ม

ตัวอย่างโค้ดด้านล่างจะแสดงการไฮไลท์ทุกการปรากฏของอักขระ **"try"** แล้วต่อมาจะไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // รับรูปทรงแรกจากสไลด์แรก.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // ไฮไลท์คำ "try" ในรูปทรง.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // ไฮไลท์คำ "to" ในรูปทรง.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) จะไฮไลท์ข้อความที่ตรงกับผลลัพธ์ของ Regular Expression ใน Java API นี้ปรากฏใน [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)

ตัวอย่างโค้ดด้านล่างไฮไลท์ทุกคำที่มี **เจ็ดอักขระหรือมากกว่า**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // ไฮไลท์ทุกคำที่มีตัวอักษรเจ็ดหรือมากกว่าตัว.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์โดยใช้ Regular Expression](highlighted_text_using_regex.png)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าเป็นสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่เป็นฟอนต์ตัวหนา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความเป็นสีเทา](gray_text_portions.png)

## **จัดตำแหน่งย่อหน้าข้อความ**

ใช้ [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เพื่อกำหนดการจัดตำแหน่งย่อหน้าภายในกรอบข้อความ ค่าเช่น จัดกึ่งกลาง, จัดซ้าย, จัดขวา, จัดเต็ม ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดตำแหน่งย่อหน้าให้ **กึ่งกลาง**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าการจัดตำแหน่งของย่อหน้าเป็นกึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดตำแหน่งแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งแสงของข้อความ**

ความโปร่งแสงของข้อความควบคุมผ่านส่วนประกอบอัลฟ่า ของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) ตัวอย่างด้านล่าง `alpha = 50` คือค่าช่องอัลฟ่า ARGB บนสเกล 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งแสง

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ย่อหน้าทั้งหมด**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งแสง.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งแสง](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ส่วนข้อความที่เป็นฟอนต์ตัวหนา**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าความโปร่งแสงของส่วนข้อความ.
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

![ส่วนข้อความที่โปร่งแสง](transparent_text_portions.png)

## **ตั้งค่าระยะห่างอักขระของข้อความ**

ใช้ [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) เพื่อขยายหรือย่อระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด Java ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่เป็นฟอนต์ตัวหนา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เราดึงโดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันใน PowerPoint ซึ่งอาจเกิดจาก PowerPoint ไม่ได้ใช้ข้อมูล Kerning สำหรับฟอนต์บางประเภท แม้ว่าฟอนต์จะมีข้อมูล Kerning ที่ถูกต้องและเปิดใช้งานในตั้งค่า PowerPoint ก็ตาม

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint ในกรณีดังกล่าว คุณสามารถปิด Kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ให้เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตั้งค่านี้จะป้องกันไม่ให้ Kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) หรือที่ระดับส่วนข้อความผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/)

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับ **ย่อหน้าทั้งหมด**: จะตั้งค่าขนาดฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

ตัวอย่างโค้ดต่อไปนี้ใช้คุณสมบัติเดียวกันกับ **ส่วนข้อความที่เป็นฟอนต์ตัวหนา**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าในรูปทรง

โค้ดต่อไปนี้ตั้งค่าการจัดแนวข้อความในรูปทรงเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาตามเข็มนาฬิกาแบบย้อนกลับ**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนของข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) เพื่อกำหนดมุมหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)

โค้ดต่อไปนี้หมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาในรูปทรง:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ได้ดังนี้

* ใช้ค่าเป็นบวกเพื่อระบุระยะห่างเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าเป็นลบเพื่อระบุระยะห่างเป็นจุด

โค้ดต่อไปนี้แสดงวิธีกำหนดระยะห่างบรรทัดภายในย่อหน้า:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างบรรทัดในย่อหน้า](line_spacing.png)

## **ตั้งค่า Autofit Type สำหรับกรอบข้อความ**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) กำหนดวิธีการที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหดลง, ล้นออก, หรือเปลี่ยนขนาดรูปทรงโดยอัตโนมัติ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่า Anchor ของกรอบข้อความ**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) กำหนดตำแหน่งแนวตั้งของข้อความภายในรูปทรง เช่น บน, กลาง, หรือล่าง

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการแท็บของข้อความ**

ใช้ [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getTabs--) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ซึ่งให้คุณกำหนดภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // ตั้งค่า Id ของภาษาการตรวจสอบ.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
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

เพื่อใช้ฟอร์แมตข้อความเริ่มต้นในระดับงานนำเสนอ ให้ใช้ [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)

โค้ดต่อไปนี้แสดงวิธีกำหนดฟอนต์ตัวหนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ใหม่

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

## **สกัดข้อความด้วยเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่ทั้งหมดแม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็ก เดิมเมื่อดึงส่วนข้อความเช่นนี้ด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้ เพื่อตรงกับข้อความที่แสดงให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/java/com.aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`

สมมติว่ามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดต่อไปนี้แสดงวิธีสกัดข้อความพร้อมเอฟเฟกต์ **All Caps** ที่กำหนดไว้:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**ทำอย่างไรจึงแก้ไขข้อความในตารางบนสไลด์ได้?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/itable/) ลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/#getTextFrame--) และกำหนดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getParagraphFormat--)

**ทำอย่างไรจึงใส่สีไล่ระดับให้กับข้อความในสไลด์ PowerPoint?**

เพื่อใส่สีไล่ระดับให้กับข้อความ ใช้ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งแสง)