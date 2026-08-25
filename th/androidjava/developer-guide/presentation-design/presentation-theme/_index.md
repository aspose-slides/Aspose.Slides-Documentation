---
title: จัดการธีมงานนำเสนอบน Android
linktitle: ธีมงานนำเสนอ
type: docs
weight: 10
url: /th/androidjava/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมงานนำเสนอ
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
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมธีมงานนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อสร้าง, ปรับแต่งและแปลงไฟล์ PowerPoint ให้มีการสร้างแบรนด์สม่ำเสมอ."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสี แบบอักษร รูปแบบพื้นหลัง การเติม สี เส้น และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่แชร์เหล่านี้แทนการเก็บค่าคุณสมบัติวิสูลแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลายตัวพร้อมกันได้

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/). งานนำเสนออาจมีการเขียนทับธีมในระดับล่างได้ด้วยเช่นกัน มาสเตอร์สามารถเขียนทับธีมงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterthememanager/), ขณะที่เลย์เอาต์หรือสไลด์เดี่ยวสามารถเขียนทับธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/). โดยทั่วไป ธีมที่ใช้งานจริงสำหรับสไลด์จะถูกกำหนดผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลย์เอาต์ → การเขียนทับของสไลด์

![องค์ประกอบของธีม: สี แบบอักษร รูปแบบพื้นหลัง และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือประยุกต์ใช้ธีม, ปรับสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไข

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/) เปิดเผยโครมสีของธีม, โครมแบบอักษร, และโครมฟอร์แมตผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์มากเมื่อไฟล์งานนำเสนอมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ถูกเก็บไว้ในธีม:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

หากไฟล์ใช้มาสเตอร์หลายอัน อย่าสมมติว่าทุกสไลด์มีธีมที่มีผลเท่าเดิม ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้ขั้นตอนการทำงานธีมที่มีผลตามที่อธิบายต่อไปนี้เมื่อมีการเขียนทับของเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ได้ เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/), objects ทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกประมวลผลกับค่าที่ใหม่ ส่วน objects ที่ใช้สี RGB ตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นแบบ end‑to‑end ที่สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสีของธีม `Accent4` เป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่, และพิมพ์สีการเติมที่มีผล:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่เห็นจึงกลายเป็นสีแดงหลังจากธีมเปลี่ยน หากคุณแทนที่สี scheme ด้วยสีตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่กระทบต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างสีอ่อนและสีเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/colortransformoperation/).

![สีธีมหลักและสีอ่อน‑สีเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก  

**2** – สีอ่อนและสีเข้มที่ได้จากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกอันโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้าอัน, แล้วบันทึกผลลัพธ์:

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

ตัวแปรเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่ผ่านการแปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ส่วน [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมพเป็นคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่ออื่นของช่องธีมเดียวกัน; ไม่ใช่ค่าที่ถูกแปลงจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่งแบบไดนามิก

## **เปลี่ยนแบบอักษรของธีม**

โครมแบบอักษรของธีมมีชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับเนื้อหา ตัวเมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านี้

ตัวระบุแบบอักษรธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn‑lt` – ฟอนต์หน้า Body Latin (Minor Latin Font)
* `+mj‑lt` – ฟอนต์หัวเรื่อง Latin (Major Latin Font)
* `+mn‑ea` – ฟอนต์หน้า Body East Asian (Minor East Asian Font)
* `+mj‑ea` – ฟอนต์หัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งบรรทัดที่ใช้ฟอนต์ Latin ชุดหลักและบรรทัดเนื้อหาใช้ฟอนต์ Latin ชุดรอง จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้แบบอักษรหลักและเนื้อหาใช้แบบอักษรรอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อธีมแบบอักษรเปลี่ยน

ชุดแบบอักษรหลักและรองยังสามารถมีการแมพฟอนต์สำหรับระบบเขียนแต่ละภาษา เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่, หรือถอดการแมพเหล่านี้ ดูที่ [Script‑Specific Theme Fonts](/slides/th/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือประยุกต์ใช้ธีม**

มีขั้นตอนการทำงานสองแบบที่พบบ่อยและแก้ไขปัญหาต่างกัน

### **รักษาธีมต้นฉบับเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากคุณต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและต้องการรักษาการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/), จากนั้นคัดลอกสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) พร้อมมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะพามาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในที่ปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์เป้าหมายที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป

### **ประยุกต์ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์ปลายทางต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มการเขียนทับระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/) คัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การเขียนทับ

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

วิธีนี้เปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบธีมที่สืบทอดจากสไลด์อื่น เพื่อถอดการเขียนทับในระดับท้องถิ่นและคืนค่าให้เป็นค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/)

### **ประยุกต์ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นกรณีสไลด์บางรายการมีการเขียนทับของตนเอง เมธอดการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องการออกแบบฐานเดียวกัน ใช้การเขียนทับเลย์เอาต์เมื่อครอบครัวเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง และใช้การเขียนทับสไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง การเขียนทับระดับสไลด์มากเกินไปจะทำให้การเปลี่ยนธีมระดับสากลในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดเติมที่เก็บจริงในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่นๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/). ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม ซึ่งต่างจากการใช้ดัชนีของคอลเลกชัน Java โดยตรงที่ `get_Item(0)` หมายถึงรายการแรก อย่าสมมติว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, แล้วบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่ระดับเลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์เท่านั้นอาจไม่ส่งผลต่อสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่าถือว่าดัชนีสไตล์คือดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามันจะมีลักษณะเดียวกันในไฟล์อื่น; นิยามสไตล์ธีมเป็นแบบเฉพาะงานนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

โครมฟอร์แมตของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/). ธีม Office ปกติอาจมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟกต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java, ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่เก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะกระทบกับรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, แล้วบันทึกผลลัพธ์:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกระยะ 10 จุด ผลลัพธ์ภาพสุดท้ายยังคงขึ้นอยู่กับว่ารูปร่างอ้างอิงช่องสไตล์ใดและว่าการจัดรูปแบบโดยตรงได้เขียนทับธีมหรือไม่

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น, เติม, และเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจกต์ธีมดิบบอกสิ่งที่กำหนดในระดับหนึ่งๆ ค่าแบบมีผลบอกสิ่งที่สไลด์หรือรูปร่างใช้จริงหลังจากการสืบทอดและการเขียนทับท้องถิ่นได้รับการแก้ไข สำหรับสไลด์ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลังใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/), และสำหรับการเติมใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) คุณอาจพลาดการเขียนทับของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปร่างที่เปลี่ยนรูปแบบสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถประยุกต์ใช้ธีมกับสไลด์เดี่ยวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มการเขียนทับธีมของมัน การเปลี่ยนแปลงจะอยู่ในระดับสไลด์เท่านั้น; สไลด์อื่นยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะเดิมของต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/). วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลย์เอาต์ และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับออบเจกต์ฟอร์แมต เช่น [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่ได้จากการสืบทอดและการเขียนทับที่ประมวลผลแล้ว.