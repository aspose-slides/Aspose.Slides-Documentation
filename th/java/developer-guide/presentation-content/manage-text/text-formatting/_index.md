---
title: จัดรูปแบบข้อความการนำเสนอใน Java
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/java/text-formatting/
keywords:
- จัดย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- เฟรมข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดเฟรมข้อความ
- การทำแท็บของข้อความ
- ภาษามาตรฐาน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Java ปรับแต่งฟอนต์, สี, การจัดแนว และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Java ครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างของอักขระ, คุณสมบัติฟอนต์, การหมุน, ระยะห่างของย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, ตำแหน่งแท็บ, และการตั้งค่าภาษา

หากไม่มีการระบุอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx). รูปทรงแรกบนสไลด์แรกเป็นกล่องข้อความและย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง ดัชนีของสไลด์และรูปทรงเป็นแบบศูนย์ฐาน ตัวอย่างที่เลือกส่วนที่หนาจะใช้การจัดรูปแบบที่มีผลรวมถึงการจัดรูปแบบที่สืบทอดจากส่วนที่หนา:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความตามตัวอักษรหรือการจับคู่แบบ regular-expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/java/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้ตั้งค่าไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลต์ที่กำหนดโดยตรงบนส่วนย่อยจะมีลำดับความสำคัญเหนือค่าดังกล่าว:

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

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

ใช้ [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เพื่อกำหนดการจัดแนวย่อหน้าในกรอบข้อความ ค่าที่กำหนดสามารถเป็นศูนย์กลาง, ชิดซ้าย, ชิดขวา, ปรับเต็มแนว, เป็นต้น

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **อยู่กึ่งกลาง**:

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

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านส่วนประกอบอัลฟาของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). ในตัวอย่างด้านล่าง `alpha = 50` หมายถึงค่าอัลฟา ARGB บนสเกล 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

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

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

## **ตั้งค่าการจัดระยะห่างของตัวอักษรสำหรับข้อความ**

ใช้ [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าติดลบจะบีบอัดข้อความ

โค้ด Java ด้านล่างแสดงวิธีขยายระยะห่างของอักขระใน **ย่อหน้าทั้งหมด**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างของอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

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

### **ปิดการเคอร์นิ่งสำหรับฟอนต์เฉพาะ**

ในบางกรณีข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint เนื่องจาก PowerPoint บางครั้งอาจละเว้นข้อมูลเคอร์นิ่งของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูลเคอร์นิ่งที่ถูกต้องและเคอร์นิ่งเปิดอยู่ในการตั้งค่าของ PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการเคอร์นิ่งสำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) ให้มีค่ามากกว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องใช้ไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ตรวจสอบชื่อฟอนต์ที่มีผลรวมรวมถึงฟอนต์ที่สืบทอด และตั้งค่าขีดจำกัด 100 จุดสำหรับส่วนที่ใช้ Roboto การตั้งค่านี้จะปิดเคอร์นิ่งสำหรับส่วนที่ใช้ฟอนต์ขนาดต่ำกว่า 100 จุด:

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

สำหรับข้อความที่ตรงกับเกณฑ์นี้ การตั้งค่านี้จะป้องกันการเคอร์นิ่งและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) หรือบนส่วนแยกด้วย [IPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุดพร้อมหนา, เอียง, และเส้นใต้แบบจุด สีรูปแบบที่กำหนดโดยตรงบนส่วนแยกจะมีลำดับความสำคัญเหนือค่าดังกล่าว:

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

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 จุด, การจัดรูปแบบเอียง, และเส้นใต้แบบจุด สำหรับส่วนที่มีการจัดรูปแบบที่มีผลรวมเป็นหนา:

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

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) เพื่อกำหนดแนวตั้งล่วงหน้าของข้อความภายในรูปทรง

โค้ดตัวอย่างต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/th/java/com.aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาไปในทิศทวนเข็มนาฬิกา**:

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

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับเฟรมข้อความ**

ใช้ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)

โค้ดตัวอย่างด้านล่างหมุนเฟรมข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปทรง:

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

Aspose.Slides มี [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) เพื่อควบคุมระยะห่างของย่อหน้า การใช้คุณสมบัติเหล่านี้เป็นดังนี้

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นจุด

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

กฎการตัดบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมข้อความละตินกับข้อความเอเชียตะวันออก วิธีการต่อไปนี้เป็นของ [IParagraphFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/) ดังนั้นจึงส่งผลต่อย่อหน้าทั้งหมด

- [setLatinLineBreak](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนค่านี้อาจทำให้ตำแหน่งการตัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนเปลี่ยนไปด้วย
- [setEastAsianLineBreak](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ตำแหน่งเริ่มต้นและสิ้นสุดของบรรทัด

กฎเหล่านี้ไม่แทนที่ [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), ซึ่งเปิดใช้งานการตัดบรรทัดอัตโนมัติภายในเฟรมข้อความ พวกมันมีผลต่อการจัดวางเมื่อมีการตัดบรรทัดเกิดขึ้น; ไม่ได้แทรกอักขระการตัดบรรทัด การตัดบรรทัดแบบชัดเจนจะบังคับให้เริ่มบรรทัดใหม่ภายในย่อหน้าโดยไม่คำนึงถึงความกว้างที่มี

ตัวอย่างสาธิตต่อไปนี้สร้างบล็อกข้อความแคบที่มีจีนและละติน ตั้งค่าตัวเลือกการตัดบรรทัดทั้งสองอย่างอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx". เพื่อทดลองแต่ละกฎ ให้เปลี่ยนค่าที่สอดคล้องกันในขณะที่ค่าที่อื่นคงที่ ตัวอย่างใช้ Arial ขนาด 24 จุดและ SimSun พร้อมความกว้างเฟรม 160 จุดและระยะขอบแนวนอนของเฟรมเท่ากับศูนย์ [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ถูกตั้งค่าเป็น [TextAutofitType.None](https://reference.aspose.com/slides/th/java/com.aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติของเฟรมคงที่

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

## **ควบคุมเครื่องหมายวรรคตอนลอย**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) อนุญาตให้เครื่องหมายวรรคตอนที่มีคุณสมบัติเหมาะสมขยายออกไปเหนือขอบขวาของบรรทัดข้อความแทนที่จะอยู่ในบรรทัดถัดไป ใช้กับย่อหน้าทั้งหมดและแตกต่างจากการเยื้องลอย

ตัวอย่างสาธิตต่อไปนี้เปิดใช้งานเครื่องหมายวรรคตอนลอยในเฟรมข้อความกว้าง 100 จุดและบันทึกเป็น "hanging_punctuation.pptx". ด้วย Arial ขนาด 24 จุดและระยะขอบแนวนอนของเฟรมเท่ากับศูนย์ จุดจบประโยคสุดท้ายจะอยู่หลังคำว่า "sentence" และขยายออกไปเหนือขอบขวาของข้อความ ตั้งคุณสมบัตินี้เป็น [NullableBool.False](https://reference.aspose.com/slides/th/java/com.aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: เมื่อตั้งค่านี้ จุดจบจะอยู่ในบรรทัดแยกออกมา การตัดบรรทัดเปิดใช้งานและ autofit ปิดเพื่อให้ความกว้างที่มีคงที่

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

ไม่ได้ทุกเครื่องหมายวรรคตอนสามารถลอยได้ ผลลัพธ์ที่มองเห็นขึ้นอยู่กับฟอนต์ที่มีและการจัดวาง: การเปลี่ยนฟอนต์, ความกว้างที่ใช้, ระยะขอบ, หรือการตั้งค่า autofit อาจทำให้ความแตกต่างที่มองเห็นหายไป

## **ตั้งค่าประเภทการปรับอัตโนมัติสำหรับเฟรมข้อความ**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) กำหนดว่าข้อความจะทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปทรงโดยอัตโนมัติ ตัวอย่างต่อไปนี้ตั้งค่ารูปทรงให้ปรับขนาดตามข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx"

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

เพื่อดูจำนวนบรรทัดหลังการตัดบรรทัดอัตโนมัติและตรวจสอบว่าขนาดข้อความหรือความกว้างของรูปทรงเปลี่ยนแปลงผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/java/manage-paragraph/). จำนวนบรรทัดอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **ตั้งจุดยึดของเฟรมข้อความ**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) กำหนดว่าข้อความจะตำแหน่งอยู่แนวตั้งในรูปทรงอย่างไร เช่น ที่ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปทรงแรกและบันทึกผลลัพธ์เป็น "text_anchor.pptx"

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

## **ตั้งค่าการทำแท็บของข้อความ**

ใช้ [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getTabs--) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าระยะห่างแท็บเริ่มต้นเป็น 100 จุดและเพิ่มตำแหน่งแท็บซ้ายที่ 30 จุด การตั้งค่าเหล่านี้จะมีผลต่อข้อความที่มีอักขระแท็บ

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

## **ตั้งค่าภาษาตรวจสอบการสะกด**

Aspose.Slides มี [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ซึ่งช่วยให้คุณตั้งค่าภาษาตรวจสอบการสะกดสำหรับส่วนข้อความ ภาษาตรวจสอบนี้กำหนดภาษาที่ใช้ในการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องใช้ไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า จะเปลี่ยนเนื้อหาของย่อหน้าแรกเป็น "1。", ตั้งฟอนต์เป็น SimSun, และกำหนดภาษาตรวจสอบเป็นภาษาจีนตัวย่อ (`zh-CN`). บันทึกผลลัพธ์เป็น "proofing_language.pptx":

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

    // ตั้งค่า Id ของภาษาตรวจสอบ.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าภาษามาตรฐาน**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษามาตรฐานสำหรับข้อความที่สร้างขึ้นระหว่างการโหลดหรือสร้างการนำเสนอ ตัวอย่างต่อไปนี้สร้างการนำเสนอที่ตั้งค่าภาษาอังกฤษสหรัฐเป็นภาษาข้อความเริ่มต้น, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงสี่เหลี่ยมใหม่พร้อมข้อความ.
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

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับการนำเสนอ ใช้ [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์หนาขนาด 14 จุดเป็นค่าเริ่มต้นสำหรับย่อหน้าระดับบนในการนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx". ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้หากไม่มีการจัดรูปแบบที่เจาะจงมากกว่ามาแทนที่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // รับรูปแบบย่อหน้าระดับบน.
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

## **ดึงข้อความพร้อมผลลัพธ์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าเดิมจะพิมพ์เป็นตัวพิมพ์เล็ก เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่ป้อนเดิม เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/java/com.aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าของมันเป็น `All`

ตัวอย่างนี้ต้องใช้ไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ส่วนแรกของย่อหน้าแรกมี "Hello, Aspose!" พร้อมเอฟเฟกต์ All Caps ตามที่แสดงด้านล่าง

![ผลลัพธ์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีดึงข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ใช้:

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

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/itable/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/icell/#getTextFrame--) และจัดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getParagraphFormat--)

**ฉันจะใช้สีไล่ระดับสีบนข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับสีบนข้อความ ให้ใช้ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) และกำหนดจุดไล่ระดับสี, ทิศทาง, และความโปร่งใส.