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
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมของงานนำเสนอกำหนดชุดสี, ฟอนต์, รูปแบบพื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่ประสานกัน ธีมออเบเจ็กต์จะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บคุณสมบัติดิสเพิลแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตอ็อบเจกต์หลาย ๆ ตัวได้พร้อมกัน

ใน Aspose.Slides ธีมระดับงานนำเสนอพร้อมใช้งานผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/). งานนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำลงได้ ไมสเตอร์สามารถแทนที่ธีมของงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterthememanager/), ในขณะที่เลเอาต์หรือสไลด์เดี่ยวสามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/). โดยปกติ ธีมที่ใช้งานจริงสำหรับสไลด์จะถูกแก้ไขผ่านลำดับการสืบทอดนี้: ธีมงานนำเสนอ → ไมสเตอร์แทนที่ → เลเอาต์แทนที่ → สไลด์แทนที่

![ส่วนประกอบของธีม: สี, ฟอนต์, รูปแบบพื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานของธีมที่พบได้บ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตรูปแบบพื้นหลังและเอฟเฟกต์, และอ่านค่าที่ใช้งานจริงหลังจากสืบทอดและการแทนที่ถูกแก้ไข

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/) เปิดเผยสคีมสี, สคีมฟอนต์, และสคีมรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่อการนำเสนอมาจากแหล่งภายนอกเพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนรูปแบบพื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้งานหลายไมสเตอร์ อย่าสันนิษฐานว่าสไลด์ทุกสไลด์มีธีมที่ใช้งานจริงเดียวกัน ตรวจสอบไมสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้กระบวนการทำงานของธีมที่ใช้งานจริงที่แสดงต่อไปในบทความนี้เมื่ออาจมีการแทนที่ที่ระดับเลเอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่อ้างอิงธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) ได้ เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/) ทุกอ็อบเจกต์ที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่ใหม่ อ็อบเจกต์ที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัพเดตสีธีม

ตัวอย่างต่อไปนี้เป็นตัวอย่าง end‑to‑end ที่สร้างรูปที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, แล้วพิมพ์สีเติมที่ใช้งานจริง:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจะแสดงเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคี็มด้วยสีโดยตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่กระทบต่อเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/java/com.aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อน‑เข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก  

**2** - เวอร์ชันสีอ่อน‑เข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, แล้วบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงตามสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่าของ `Accent4` ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ส่วน [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมพนี้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกสำหรับช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

สคีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับเนื้อหา ตัวเมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ของธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn‑lt` - Body Font Latin (ฟอนต์ตัวอักษรละตินรอง)
* `+mj‑lt` - Heading Font Latin (ฟอนต์ตัวอักษรละตินหลัก)
* `+mn‑ea` - Body Font East Asian (ฟอนต์เอเชียตะวันออกรอง)
* `+mj‑ea` - Heading Font East Asian (ฟอนต์เอเชียตะวันออกหลัก)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ละตินหลักของธีมและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ละตินรองของธีม จากนั้นเปลี่ยนฟอนต์ของธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะอ้างอิงฟอนต์หลักและข้อความเนื้อหาจะอ้างอิงฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสคีมฟอนต์ของธีมเปลี่ยน

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/java/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานที่พบบ่อยและแก้ปัญหาต่างกัน

### **รักษาธีมต้นฉบับเมื่อนำสไลด์ไปยังงานใหม่**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและต้องการรักษาการออกแบบเดิม ให้โคลนไมสเตอร์ต้นฉบับไปยังงานนำหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/), แล้วโคลนสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) และไมสเตอร์ที่โคลนไว้ วิธีนี้จะพาไมสเตอร์, เลเอาต์, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง การโคลนเนื้อหาไปยังไมสเตอร์ปลายทางที่ไม่มีความสัมพันธ์อาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนโดยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนไมสเตอร์และเลเอาต์ปัจจุบัน ให้ทำการเริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/) จะคัดลอกสามส่วนสำคัญของธีมเข้าไปในการแทนที่

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

วิธีนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สไลด์อื่นสืบทอดจากนั้น หากต้องการลบการแทนที่ระดับท้องถิ่นและคืนค่าเป็นค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลเอาต์**

การแทนที่ระดับเลเอาต์จะนำไปใช้กับสไลด์ที่ใช้เลเอาต์นั้น ยกเว้นกรณีที่สไลด์ใดมีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับไมสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลเอาต์และสไลด์ควรแชร์การออกแบบฐานเดียวกัน ใช้การแทนที่ระดับเลเอาต์เมื่อกลุ่มเลเอาต์หนึ่งต้องการสไตลิงที่แตกต่าง และใช้การแทนที่ระดับสไลด์เฉพาะกรณีพิเศษเท่านั้น การมีการแทนที่ระดับสไลด์มากเกินไปจะทำให้การเปลี่ยนธีมแบบรวมภายหลังคาดการณ์ได้ยากขึ้น

## **อัปเดตรูปแบบพื้นหลังของธีม**

รูปแบบการเติมพื้นหลังของธีมจัดเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าที่จำนวนการกำหนดเติมที่เก็บอยู่จริงในคอลเลกชันนี้ เพราะ UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลลอรี่รูปแบบพื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้งานรูปแบบพื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมแบบธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังธีม สิ่งนี้แตกต่างจากการอ้างอิงดัชนีของคอลเลกชัน Java โดยตรงที่ `get_Item(0)` หมายถึงรายการที่เก็บเป็นอันดับแรก อย่าสันนิษฐานว่าทุกงานนำเสนอมีจำนวนรูปแบบเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่พร้อมใช้งาน, กำหนดการอ้างอิงพื้นหลังธีมให้กับไมสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นจะขึ้นอยู่กับรายการธีมที่ไมสเตอร์อ้างอิงและการแทนที่พื้นหลังที่อาจมีที่ระดับเลเอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของไมสเตอร์อย่างเดียวอาจไม่กระทบต่อสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) เมื่อคุณต้องการรู้พื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้

{{% alert color="warning" title="Warning" %}}
อย่าถือว่าดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการเขียนค่าดัชนีสไตล์แบบคงที่จากไฟล์หนึ่งและสันนิษฐานว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นลักษณะเฉพาะของงานนำเสนอแต่ละไฟล์
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการกำหนดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สคีมรูปแบบของธีมประกอบด้วยคอลเลกชันเติม, เส้น, และเอฟเฟกต์ที่แยกกัน เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/). ธีมของ Office ที่พบบ่อยมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบละเอียด, ปานกลาง, และเข้ม แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานจำนวนคงที่

![เอฟเฟกต์ธีมแบบละเอียด, ปานกลาง, และเข้มที่ใช้กับรูปเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java ดัชนีของคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่เก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปเป็นแนวคิดแยกต่างหาก ที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะกระทบต่อรูปที่อ้างอิงสไตล์นั้น; รูปที่กำหนดรูปแบบโดยตรงอาจไม่เปลี่ยนแปลง

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะกลายเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกที่ระยะ 10 จุด ผลลัพธ์ที่เห็นยังคงขึ้นอยู่กับรูปใดรูปหนึ่งอ้างอิงช่องสไตล์ใดและว่าการกำหนดรูปแบบโดยตรงจะทับธีมหรือไม่

![สไตล์เอฟเฟกต์ธีมหลังจากการเปลี่ยนเส้น, เติม, และการตั้งค่าเงา](presentation-design_11.png)

## **อ่านค่าธีมที่ใช้งานจริง**

อ็อบเจกต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรบ้างในระดับหนึ่ง ค่าที่ใช้งานจริงบอกคุณว่าสไลด์หรือรูปใช้ค่าอะไรหลังจากสืบทอดและการแทนที่ท้องถิ่นถูกแก้ไขแล้ว สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/), และสำหรับเติม ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่ใช้งานจริง, พื้นหลัง, และเติมของรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่ใช้งานจริงสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเพียง [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เท่านั้น คุณอาจพลาดการแทนที่ที่มาจากไมสเตอร์, เลเอาต์, สไลด์, หรือรูปที่เปลี่ยนลักษณะสุดท้ายได้

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนไมสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมแทนที่ การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ จะยังคงสืบทอดธีมที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

เมื่อนำสไลด์และต้องการรักษาลักษณะเดิมของแหล่งต้น ให้โคลนไมสเตอร์ต้นฉบับไปยังปลายทางและโคลนสไลด์ด้วยไมสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/). วิธีนี้จะทำให้ไมสเตอร์, เลเอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่ใช้งานจริงหลังจากสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือเลเอาต์ธีมและเมธอดข้อมูลที่ใช้งานจริงที่สอดคล้องสำหรับออบเจกต์รูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่แก้ไขหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้