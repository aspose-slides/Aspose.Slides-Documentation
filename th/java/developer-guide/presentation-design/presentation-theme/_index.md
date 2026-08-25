---
title: จัดการธีมการนำเสนอใน Java
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/java/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี แบบอักษร รูปแบบพื้นหลัง การเติมสี เส้น และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงคำนิยามร่วมเหล่านี้แทนการเก็บค่าทรัพย์สินภาพแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุหลายๆ รายการพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/). การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำกว่าได้ มาสเตอร์สามารถแทนที่ธีมของการนำเสนอได้ผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterthememanager/), ขณะที่เลย์เอาต์หรือสไลด์เดี่ยวสามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/). โดยทั่วไป ธีมที่มีผลสำหรับสไลด์จะได้รับการแก้ไขผ่านสายอาณัติการสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, รูปแบบพื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, ปรับปรุงรูปแบบพื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/) จะเปิดเผยสกีมสี, สกีมแบบอักษรและสกีมรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/) และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงมีประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น และเอฟเฟกต์ที่จัดเก็บในธีม:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

หากไฟล์ใช้มาสเตอร์หลายอัน อย่า Assume ว่าทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์และใช้กระบวนการทำงานของธีมที่มีผลตามที่แสดงในบทความนี้เมื่อต้องจัดการการแทนที่ของเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้นและข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/) วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นกระบวนการจบถึงจบที่สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้งและพิมพ์สีการเติมที่มีผล:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนกว่าหรือเข้มกว่าจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/java/com.aspose.slides/colortransformoperation/)

![สีธีมหลักและสีที่อ่อนหรือเข้มกว่าที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีที่อ่อนและเข้มกว่าที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกอันโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้าอันและบันทึกผลลัพธ์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปแบบเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2` และ `Background2` ขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2` และ `Light2` การแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อสลับสำหรับช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรของธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับเนื้อหา ตัวเมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - แบบอักษรร่างกาย Latin (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่อง Latin (Major Latin Font)
* `+mn-ea` - แบบอักษรร่างกาย East Asian (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดเนื้อหาเดียวที่ใช้แบบอักษร Latin รอง จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หัวเรื่องจะใช้แบบอักษรหลักและข้อความส่วนเนื้อหาจะใช้แบบอักษรรอง ข้อความที่ระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมแบบอักษรของธีมเปลี่ยน

คอลเลกชันแบบอักษรหลักและรองยังสามารถมีการแมปแบบอักษรสำหรับระบบเขียนต่างๆ เช่น Cyrillic, Arabic, Japanese, Georgian และ Thaana เพื่อดู, เพิ่ม, แทนที่หรือเอาการแมปเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/java/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรของการนำเสนอ โปรดดูที่ [PowerPoint Fonts](/slides/th/java/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานทั่วไป ซึ่งแก้ปัญหาต่างกัน

### **เก็บธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังการนำเสนออื่นและรักษารูปแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับไปยังการนำเสนอเป้าหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/), จากนั้นคัดลอกสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) และมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะพามาสเตอร์, เลย์เอาต์และธีมที่เชื่อมโยงมาด้วยกัน

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลังและเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลง

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นทาง เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/) และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/) จะคัดลอกส่วนสำคัญสามส่วนของธีมไปยังการแทนที่

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

วิธีนี้จะเปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สไลด์อื่นสืบทอด หากต้องการลบการแทนที่ในระดับท้องถิ่นและกลับไปสู่ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะส่งผลต่อสไลด์ที่ใช้เลย์เอาต์นั้น เว้นแต่สไลด์บางรายการจะมีการแทนที่ของตนเอง เมธอดการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ควรแชร์การออกแบบฐานเดียวกัน ใช้การแทนที่ระดับเลย์เอาต์เมื่อชุดเลย์เอาต์หนึ่งต้องการสไตลิงที่ต่างออกไป และใช้การแทนที่ระดับสไลด์เฉพาะกรณีพิเศษเท่านั้น การแทนที่ระดับสไลด์มากเกินไปจะทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก

## **อัปเดตรูปแบบพื้นหลังของธีม**

การเติมพื้นหลังของธีมจะจัดเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เนื่องจาก UI สามารถรวมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่นๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) ปัจจุบัน ค่าอินเด็กซ์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม ซึ่งแตกต่างจากการอ้างอิงดัชนีของคอลเลกชัน Java โดยตรงที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าการนำเสนอแต่ละไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังของธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่มองเห็นจะขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่อาจมีอยู่ในระดับเลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์อย่างเดียวอาจไม่เปลี่ยนสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) เมื่อคุณต้องการรู้พื้นหลังสุดท้ายหลังจากการสืบทอดได้รับการประยุกต์

{{% alert color="warning" title="Warning" %}}
อย่าใช้ค่าอินเด็กซ์เป็นดัชนีของคอลเลกชันแบบศูนย์ฐาน อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำนิยามสไตล์ธีมเป็นเอกลักษณ์ของการนำเสนอแต่ละไฟล์
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง โปรดดูที่ [Presentation Background](/slides/th/java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมรูปแบบของธีมประกอบด้วยคอลเลกชันการเติม, เส้นและเอฟเฟกต์ที่แยกกัน ซึ่งเปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/) และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/). ธีมของ Office ทั่วไปมักมีสามรายการสไตล์หลักที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![เอฟเฟกต์ธีมแบบ Subtle, Moderate และ Intense ที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java ดัชนีของคอลเลกชันเป็นศูนย์ฐาน: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหาก ที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ของธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์นั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจคงไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, แล้วบันทึกผลลัพธ์:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะได้เงาแบบนอกด้วยระยะ 10 จุด ผลลัพธ์ภาพจริงยังคงขึ้นอยู่กับว่ารูปทรงแต่ละรูปอ้างอิงช่องใดและว่าการจัดรูปแบบโดยตรงได้แทนที่ธีมหรือไม่

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น, เติมและเงา](presentation-design_11.png)

## **อ่านค่าที่มีผลของธีม**

ออบเจ็กต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปทรงใช้ค่าใดจริงหลังจากการสืบทอดและการแทนที่ในระดับท้องถิ่นได้รับการแก้ไขแล้ว สำหรับสไลด์ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลังให้ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) และสำหรับการเติมให้ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลังและการเติมของรูปทรงแรกจากสไลด์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบและการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) คุณอาจพลาดมาสเตอร์, เลย์เอาต์, สไลด์หรือการแทนที่ของรูปทรงที่เปลี่ยนลักษณะที่สุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมการแทนที่ การเปลี่ยนแปลงจะอยู่ในระดับท้องถิ่นของสไลด์นั้น; สไลด์อื่นจะยังคงสืบทอดธีมที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/). วิธีนี้จะทำให้มาสเตอร์, เลย์เอาต์และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลย์เอาต์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับออบเจ็กต์รูปแบบเช่น [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำมาใช้.