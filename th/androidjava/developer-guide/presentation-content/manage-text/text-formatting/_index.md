---
title: "จัดรูปแบบข้อความการนำเสนอบน Android"
linktitle: "การจัดรูปแบบข้อความ"
type: docs
weight: 50
url: /th/androidjava/text-formatting/
keywords:
- "จัดแนวย่อหน้า"
- "สไตล์ข้อความ"
- "พื้นหลังข้อความ"
- "ความโปร่งใสของข้อความ"
- "ระยะห่างอักขระ"
- "คุณสมบัติเฟอนต์"
- "ตระกูลฟอนต์"
- "การหมุนข้อความ"
- "มุมการหมุน"
- "กรอบข้อความ"
- "ระยะห่างบรรทัด"
- "คุณสมบัติ Autofit"
- "การยึดกรอบข้อความ"
- "การแท็บข้อความ"
- "ภาษาตั้งต้น"
- PowerPoint
- OpenDocument
- "งานนำเสนอ"
- Android
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java ปรับแต่งฟอนต์ สี การจัดแนวและอื่นๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java ครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของฟอนต์, การหมุน, ระยะห่างของย่อหน้า, พฤติกรรม Autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความลอจิกหรือผลลัพธ์ของ regular‑expression ให้ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/androidjava/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังข้อความ**

ใช้ [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) เพื่อกำหนดสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลท์สำหรับย่อหน้าเต็ม.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

ใช้ [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เพื่อตั้งค่าการจัดแนวย่อหน้าในกรอบข้อความ ค่าที่กำหนดได้รวมถึง กลาง, ชิดซ้าย, ชิดขวา, ล้านค่า ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการจัดแนวย่อหน้าให้อยู่ **กึ่งกลาง**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าการจัดแนวของย่อหน้าให้เป็นกึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนกึ่งกลาง](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านค่าแอลฟาของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าแอลฟาแบบ ARGB ในช่วง 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

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

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการใช้ความโปร่งใสกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

## **ตั้งค่าระยะห่างอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) เพื่อขยายหรือหดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด Java ต่อไปนี้แสดงวิธีการขยายระยะห่างอักขระใน **ย่อหน้าเต็ม**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างของอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการขยายระยะห่างอักขระใน **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
            portion.getPortionFormat().setSpacing(3); // ขยายระยะห่างของอักขระ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำงานของ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูคับแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint ซึ่งอาจเกิดจาก PowerPoint เพิกเฉยต่อข้อมูล kerning ของฟอนต์บางตัว แม้ฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการทำงานของ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ให้เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับฟอนต์ที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติเฟอนต์ของข้อความ**

คุณสมบัติเฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) หรือที่ระดับส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/)

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับ **ย่อหน้าเต็ม**: กำหนดขนาดฟอนต์, หนา, เอียง, ขีดเส้นประใต้และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

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

![คุณสมบัติเฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติเช่นเดียวกันกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

![คุณสมบัติเฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าภายในรูปร่าง

โค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textverticaltype/) ซึ่งทำให้ข้อความ **หมุน 90 องศาแบบทวนเข็มนาฬิกา**:

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

ใช้ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/)

โค้ดต่อไปนี้หมุนกรอบข้อความ 3 องศาในแนวตามเข็มนาฬิกา ภายในรูปร่าง:

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

Aspose.Slides มี [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) เพื่อควบคุมระยะห่างของย่อหน้า โดยใช้ตามนี้

* ใช้ค่าบวกเพื่อระบุระยะห่างเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างเป็นพอยต์

โค้ดต่อไปนี้แสดงวิธีการระบุระยะห่างบรรทัดภายในย่อหน้า:

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

![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) กำหนดว่าข้อความทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าจะให้ข้อความย่อ, ล้นออก, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

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

## **ตั้งค่าการยึดของกรอบข้อความ**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) กำหนดว่าข้อความจะวางตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น ที่บน, กลาง, หรือล่าง

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

## **ตั้งค่าการแท็บของข้อความ**

ใช้ [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) เพื่อตั้งค่าจุดหยุดแท็บในย่อหน้า

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

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ซึ่งอนุญาตให้คุณกำหนดภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบจะกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ดต่อไปนี้แสดงวิธีการตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ:

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

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

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

    // ตรวจสอบภาษาของส่วนแรก.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ใช้ [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--)

โค้ดต่อไปนี้แสดงวิธีกำหนดฟอนต์หนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดบนสไลด์ในงานนำเสนอใหม่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // ดึงรูปแบบย่อหน้าระดับบน.
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

## **ดึงข้อความพร้อมเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้ว่าต้นฉบับจะพิมพ์เป็นตัวพิมพ์เล็กก็ตาม เมื่อตัวแปรส่วนข้อความถูกดึงจาก Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับที่แสดงบนสไลด์ ให้แปลงสตริงที่คืนค่ามาให้เป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น [TextCapType.All](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textcaptype/)

สมมติว่ามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดต่อไปนี้แสดงวิธีดึงข้อความที่มีเอฟเฟกต์ **All Caps** ถูกนำไปใช้:

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

**จะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/) วนซ้ำผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/#getTextFrame--) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)

**จะทำอย่างไรให้ข้อความในสไลด์ PowerPoint มีสีไล่ระดับ?**

เพื่อให้ข้อความมีสีไล่ระดับ ใช้ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส