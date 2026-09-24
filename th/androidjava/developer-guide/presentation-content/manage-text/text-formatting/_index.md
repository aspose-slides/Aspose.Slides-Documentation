---
title: จัดรูปแบบข้อความการนำเสนอบน Android
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/androidjava/text-formatting/
keywords:
- จัดตำแหน่งย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติการปรับอัตโนมัติ
- การตรึงกรอบข้อความ
- การทำแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java ปรับแต่งฟอนต์, สี, การจัดตำแหน่ง, และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java. เนื้อหาครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างตัวอักษร, คุณสมบัติของฟอนต์, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรมอัตโนมัติในการปรับขนาด, การตรึงข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา.

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

To find and highlight literal text or regular-expression matches, see [ค้นหาและแทนที่ข้อความ](/slides/th/androidjava/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า, หรือใช้ [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) สำหรับส่วนข้อความแต่ละส่วน.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีไฮไลต์สำหรับย่อหน้าเต็ม.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

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
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ตั้งค่าสีไฮไลต์สำหรับส่วนข้อความ.
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

## **จัดย่อหน้าข้อความ**

ใช้ [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เพื่อตั้งค่าการจัดแนวย่อหน้าในกรอบข้อความ. ค่าสามารถเป็นกำกับศูนย์, ซ้าย, ขวา, จัดแนวเต็ม, เป็นต้น.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าเป็น **กึ่งกลาง**:

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

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วนประกอบอัลฟ่าของสีที่กำหนดให้กับ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). ในตัวอย่างต่อไปนี้ `alpha = 50` เป็นค่าอัลฟ่า ARGB บนสเกล 0–255, ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ตั้งค่าสีเติมของข้อความให้เป็นสีโปร่งใส.
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

## **ตั้งค่าการเว้นระยะระหว่างอักขระสำหรับข้อความ**

ใช้ [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ.

โค้ด Java ต่อไปนี้แสดงวิธีขยายระยะห่างระหว่างอักขระใน **ย่อหน้าเต็ม**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเว้นระยะอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

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
            portion.getPortionFormat().setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเว้นระยะอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint. สาเหตุอาจเป็นเพราะ PowerPoint เพิกเฉยต่อข้อมูล kerning ของฟอนต์บางตัว, แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและการตั้งค่า kerning ถูกเปิดใน PowerPoint.

เพื่อให้ผลลัพธ์การเรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้นในกรณีเช่นนี้, คุณสามารถปิดการ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ. ตั้งค่า [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

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

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การแสดงผลของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้.

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าผ่าน [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) หรือบนส่วนข้อความแต่ละส่วนผ่าน [IPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformat/).

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับย่อหน้าเต็ม: มันกำหนดขนาดฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า.

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

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติเช่นเดียวกันกับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

## **ตั้งค่าการหมุนข้อความ**

ใช้ [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) เพื่อตั้งค่าการวางแนวข้อความที่กำหนดไว้ล่วงหน้าภายในรูปร่าง.

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปร่างเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาตรงข้ามเข็มนาฬิกา**:

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

ใช้ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) เพื่อตั้งค่ามุมการหมุนแบบกำหนดเองสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/).

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความโดย 3 องศาตามเข็มนาฬิกาในรูปร่าง:

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

Aspose.Slides มี [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), และ [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) เพื่อควบคุมระยะห่างของย่อหน้า. คุณสมบัติเหล่านี้ใช้ได้ดังต่อไปนี้:

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด.
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นจุด.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีระบุการเว้นบรรทัดภายในย่อหน้า:

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

## **ตั้งค่าประเภทการปรับอัตโนมัติสำหรับกรอบข้อความ**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) กำหนดพฤติกรรมของข้อความเมื่อเกินขอบเขตของคอนเทนเนอร์. ใช้เพื่อควบคุมว่าข้อความจะหดลง, เกินขอบ, หรือปรับขนาดรูปร่างโดยอัตโนมัติ.

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

เพื่อเรียงบรรทัดหลังจากห่ออัตโนมัติและดูว่าขนาดข้อความหรือรูปร่างเปลี่ยนแปลงผลลัพธ์อย่างไร, ดูที่ [นับบรรทัดที่เรนเดอร์](/slides/th/androidjava/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความเกินคอนเทนเนอร์หรือไม่.

## **ตั้งค่าการตรึงของกรอบข้อความ**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) กำหนดวิธีการวางตำแหน่งข้อความในแนวตั้งภายในรูปร่าง, เช่นบน, กลาง, หรือด้านล่าง.

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

## **ตั้งค่าการทำแท็บข้อความ**

ใช้ [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) และ [IParagraphFormat.getTabs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า.

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

Aspose.Slides มี [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) والتيช่วยให้คุณตั้งค่าภาษา Proofing สำหรับส่วนข้อความ. ภาษาตรวจสอบช่วยกำหนดภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษา Proofing สำหรับส่วนข้อความ:

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

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ.

```java
import com.aspose.slides.*;

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

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ, ใช้ [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าแบบอักษรตัวหนาตั้งต้นขนาด 14 pt สำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // รับรูปแบบย่อหน้าที่ระดับบนสุด.
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

## **สกัดข้อความพร้อมเอฟเฟกต์ All-Caps**

ใน PowerPoint, การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวเล็กเดิม. เมื่อคุณดึงส่วนข้อความเช่นนี้ด้วย Aspose.Slides, ไลบรารีจะส่งกลับข้อความตามที่พิมพ์ไว้. เพื่อให้ตรงกับข้อความที่แสดง, ให้แปลงสตริงที่ส่งกลับเป็นตัวพิมพ์ใหญ่เมื่อค่เป็น [TextCapType.All](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textcaptype/).

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx.

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ได้ทำการใช้:

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

**วิธีแก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์, ใช้ [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [ICell.getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/#getTextFrame--) และการจัดรูปแบบย่อหน้าผ่าน [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**วิธีใช้สีไล่ระดับในข้อความบนสไลด์ PowerPoint?**

เพื่อใช้สีไล่ระดับกับข้อความ, ใช้ [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). ตั้งค่า [IFillFormat.setFillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) และกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส.