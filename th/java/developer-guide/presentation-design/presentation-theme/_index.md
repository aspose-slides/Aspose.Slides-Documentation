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
- ธีมภายนอก
- THMX
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
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, ฟอนต์, รูปแบบพื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ประสานกัน. วัตถุที่รับรู้ธีมอ้างอิงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติดีไซน์แต่ละอย่างเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุหลาย ๆ อย่างพร้อมกัน.

ใน Aspose.Slides, ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). การนำเสนออาจมีการเขียนทับธีมที่ระดับต่ำกว่าได้เช่นกัน. มาสเตอร์สามารถเขียนทับธีมการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/), ส่วนเลย์เอาต์หรือสไลด์เดี่ยวสามารถเขียนทับธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). ปฏิบัติการจริง, ธีมที่มีผลต่อสไลด์จะถูกกำหนดโดยโซ่การสืบทอดนี้: ธีมการนำเสนอ, การเขียนทับมาสเตอร์, การเขียนทับเลย์เอาต์, และการเขียนทับสไลด์.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, ปรับปรุงสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไข.

## **ตรวจสอบธีม**

[MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) เปิดเผยโครงสี, โครงฟอนต์, และโครงรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนการเปลี่ยนแปลงมีประโยชน์โดยเฉพาะเมื่อการนำเข้ามาจากแหล่งภายนอกเพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน.

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว, อย่าสมมติว่าแต่ละสไลด์มีธีมที่มีผลเท่ากัน. ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์, และใช้กระบวนการทำงานธีมที่มีผลตามที่แสดงต่อไปนี้เมื่ออาจมีการเขียนทับที่ระดับเลย์เอาต์หรือสไลด์.

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/). เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขด้วยค่าที่ใหม่. วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม.

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสีธีม `Accent4` เป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่, แล้วพิมพ์สีเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน. หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปทรง, การเปลี่ยนแปลงต่อเนื่องของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป.

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างรูปแบบสีที่อ่อนและเข้มจากสีธีมโดยใช้การแปลงสี. Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีธีมหลัก.

**2** - รูปแบบสีอ่อนและเข้มที่สร้างจากสีธีมหลัก.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปอ้างอิง `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, แล้วบันทึกผลลัพธ์:

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

รูปแบบเหล่านี้ยังคงอ้างอิงสีธีม. หาก `Accent4` เปลี่ยนในภายหลัง, สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ที่ใหม่.

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ขณะที่ [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปนี้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ใช่ค่าที่ถูกแปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง.

## **เปลี่ยนฟอนต์ของธีม**

โครงฟอนต์ของธีมมีชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความหลัก. วิธีการ [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น.

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)
* `+mn-cs` - Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` - Heading Font Complex Script (Major Complex Script Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ Latin รองของธีม. จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะตามฟอนต์หลักและข้อความหลักจะตามฟอนต์รอง. ข้อความที่มีชื่อฟอนต์เจาะจงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อโครงฟอนต์ธีมเปลี่ยน.

คอลเลกชันฟอนต์หลักและรองยังสามารถมีแมปฟอนต์สำหรับระบบเขียนแบบเฉพาะ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana. เพื่อตรวจสอบ, เพิ่ม, แทนที่, หรือเอาแมปเหล่านี้ออก, ดู [Script-Specific Theme Fonts](/slides/th/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในการนำเสนอ, ดู [PowerPoint Fonts](/slides/th/java/powerpoint-fonts/).
{{% /alert %}}

### **แก้ไขการอ้างอิงฟอนต์ธีม**

เมื่อทำการตรวจสอบข้อความ, [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) สามารถคืนค่าการอ้างอิงธีมเช่น `+mn-lt` แทนชื่อฟอนต์. เรียก [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) พร้อมกับ [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) ที่เหมาะสมเพื่อแก้ไขการอ้างอิงนั้น. คำนำหน้า `+mj` และ `+mn` เลือกชุดฟอนต์หลักและรอง; ส่วนต่อท้าย `-lt`, `-ea`, และ `-cs` เลือกฟอนต์ Latin, East Asian, และ Complex Script ตามลำดับ.

รับธีมที่มีผลผ่าน [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) บนวัตถุที่ธีมของมันใช้กับข้อความที่ตรวจสอบ. สำหรับข้อความทั่วไปบนสไลด์, เรียกเมธอดนี้บนสไลด์เพื่อให้บริบทรวมธีมที่สืบทอดและการเขียนทับในระดับท้องถิ่น. เมื่อทำการตรวจสอบเลย์เอาต์หรือมาสเตอร์เอง, ใช้ธีมที่มีผลของมันเอง. อย่าสมมติว่าธีมของมาสเตอร์แรกใช้กับสไลด์ทุกสไลด์.

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงฟอนต์ Latin รองอย่างชัดเจน. มันเริ่มต้นโครงฟอนต์สไลด์ผ่าน [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) แล้วตั้งฟอนต์ Latin หลักและรองเป็น `Arial` และ `Calibri`, ทำให้ผลลัพธ์ทำซ้ำได้โดยไม่มีไฟล์อินพุต.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

ผลลัพธ์คือ `+mn-lt -> Calibri` ตามด้วย `Verdana -> Verdana`. การอ้างอิงที่เก็บไว้ยังคงไม่เปลี่ยน, ขณะที่ชื่อฟอนต์ที่เจาะจงจะคืนค่าเดิม. หากส่วนข้อความใช้ `+mj-lt`, จะแก้เป็น `Arial` ในธีมนี้.

การแก้ไขการอ้างอิงธีมระบุฟอนต์ที่ธีมกำหนด. มันไม่ได้ตรวจสอบความพร้อมของฟอนต์หรือกำหนดไฟล์ฟอนต์ที่ใช้จริงหลังจากการทดแทนหรือ fallback ระหว่างการเรนเดอร์. ดู [Font Selection Sequence](/slides/th/java/font-selection-sequence/) และ [Font Substitution](/slides/th/java/font-substitution/) สำหรับขั้นตอนแยกเหล่านั้น.

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาที่เกี่ยวกับธีมต่าง ๆ.

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์**

ใช้ [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์เฉพาะ. เลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ที่ใช้ [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), แล้วส่งพาธไฟล์ธีมให้เมธอด.

เมธอดทำงานดังต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่โดยอิงจากมาสเตอร์ที่เลือก.
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่.
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก.
1. คืนค่า [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) ที่สร้างใหม่.

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์แรกและบันทึกการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);

    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");
    System.out.println("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่สนับสนุนอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/). ตรวจสอบพาธที่ผู้ใช้ระบุ, จัดการความล้มเหลวในการเข้าถึงไฟล์ระบบ, และบันทึกการนำเสนอหลังจากธีมถูกใช้สำเร็จเท่านั้น.

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่ถูกย้าย. สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิม. สี, ฟอนต์, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก. สี, ฟอนต์, การเติม, และรูปแบบที่กำหนดโดยตรงอาจคงเดิม. การเขียนทับระดับเลย์เอาต์และสไลด์ยังอาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่.

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมการทำงาน. เพื่อให้การเรนเดอร์และการส่งออกสอดคล้อง, ให้ติดตั้งฟอนต์ที่ต้องการ, จัดหาไฟล์ฟอนต์ผ่าน [custom font sources](/slides/th/java/custom-font/), หรือกำหนด [font substitution](/slides/th/java/font-substitution/).

นี่เป็นกระบวนการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการเขียนทับธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง.

### **ใช้ธีมภายนอกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า, ให้นำมาสเตอร์มาจากสไลด์ตัวอย่างผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). เก็บอ้างอิงมาสเตอร์ดั้งเดิมก่อนใช้ธีมใด ๆ เพราะแต่ละครั้งเรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ.

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อหามาสเตอร์ของพวกมันและใช้ธีมภายนอกต่างกันกับแต่ละกลุ่ม:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

การเรียกครั้งแรกส่งผลต่อสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองส่งผลต่อสไลด์ที่ขึ้นกับ `secondGroupMaster` เท่านั้น. สไลด์ที่เชื่อมกับมาสเตอร์อื่น ๆ จะไม่เปลี่ยนสไตล์.

### **รักษาธีมต้นฉบับเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและต้องการรักษาการออกแบบเดิม, ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำเป้าหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), จากนั้นคัดลอกสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) และมาสเตอร์ที่คัดลอก. การกระทำนี้จะพามาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องไปด้วยกัน.

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง. การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลง.

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน, ให้เริ่มต้นการเขียนทับระดับสไลด์จากธีมต้นฉบับ. เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) คัดลอกสามส่วนหลักของธีมเข้าสู่การเขียนทับ.

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

การกระทำนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น. เพื่อเอาการเขียนทับท้องถิ่นออกและกลับไปใช้ค่าที่สืบทอด, เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/).

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์ใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น, ยกเว้นกรณีสไลด์มีการเขียนทับของตนเอง. วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องแชร์การออกแบบฐานเดียวกัน, ใช้การเขียนทับระดับเลย์เอาต์เมื่อชุดเลย์เอาต์ต้องการสไตล์ที่แตกต่าง, และใช้การเขียนทับระดับสไลด์เฉพาะกรณีพิเศษ. การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก.

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*การเขียนทับระดับเลย์เอาต์ใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นสไลด์ที่มีการเขียนทับระดับท้องถิ่นมากกว่*. ค่าที่อิงธีมจะตามสกีมที่แก้ไขแล้ว; วัตถุที่กำหนดรูปแบบโดยตรงสามารถคงลักษณะท้องถิ่นได้. เก็บการเขียนทับให้แคบเท่าที่จำเป็นสำหรับข้อยกเว้นการออกแบบที่ตั้งใจ.
<!-- visual-explanation:presentation-theme:end -->

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์การเติมพื้นหลังของธีมถูกจัดเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ ได้.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/). ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังธีม. นี่แตกต่างจากการทำดัชนีโดยตรงในคอลเลกชัน Java, ที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ. อย่าสมมติว่าทุกการนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน.

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, แล้วบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่ระดับเลย์เอ็ตหรือสไลด์. หากสไลด์ใช้พื้นหลังของตนเอง, การเปลี่ยนพื้นหลังมาสเตอร์อย่างเดียวอาจไม่ทำให้สไลด์นั้นเปลี่ยน. ใช้ [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำมาใช้.

{{% alert color="warning" title="Warning" %}}
อย่าพิจารณาดัชนีสไตล์เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์. อีกทั้งหลีกเลี่ยงการทำฮาร์ดโค้ดหมายเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นลักษณะเฉพาะของการนำเสนอ.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดู [Presentation Background](/slides/th/java/presentation-background/).
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

โครงรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). ธีม Office ทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบละเอียด, ปานกลาง, และเข้ม, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติจำนวนคงที่.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java, ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม. ดัชนีอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยก, เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจคงเดิม.

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะมีเงานอกระยะ 10 จุด. ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับว่ารูปทรงใดอ้างอิงช่องใดและการจัดรูปแบบโดยตรงจะเขียนทับธีมหรือไม่.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูปทรง**

รูปทรงสามารถเลือกการเติมและเส้นขอบแยกกันผ่าน [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) และ [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). สำหรับแต่ละเมธอด, ดัชนี `1` เลือกรายการแรกในคอลเลกชันธีมที่สอดคล้อง (`get_Item(0)`), ดัชนี `2` เลือกรายการที่สอง (`get_Item(1)`).

ตัวอย่างต่อไปนี้ตั้งค่าสไตล์การเติมสองแบบ (ทองและสีฟ้าอากาศ) และสไตล์เส้นสองแบบ (สีน้ำเงินเข้ม 6 pt และสีแดงเข้ม 12 pt) ในธีมเริ่มต้นของการนำเสนอใหม่. มันบันทึกสไลด์ในสามขั้นตอนเพื่อให้คุณเปรียบเทียบผลใน PowerPoint.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| สไตล์เริ่มต้น | เปลี่ยนโครงร่างด้านขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่ต่างกันจะเปลี่ยนโครงร่างของสี่เหลี่ยมขวาเท่านั้น. การแก้ไขการเติมธีมแรกจะอัปเดตทุกรูปทรงที่ใช้มัน. ที่นี่, เพียงสี่เหลี่ยมด้านซ้ายเท่านั้นที่กลายเป็นสีเขียว.

บนรูปทรงที่มีอยู่, สีเติมท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถเขียนทับส่วนของสไตล์ธีมนั้นได้. หากการเปลี่ยนดัชนีสไตล์ไม่มีผลปรากฏ, ตรวจสอบ [direct formatting](/slides/th/java/shape-formatting/) ของรูปทรง.

## **ตรวจสอบว่าการเติมเป็นสีของธีมหรือไม่**

การเติมอาจจัดเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลย์เอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น. เรียก [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) เพื่อแก้ลำดับชั้นนั้นเป็น [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) ที่ไม่เปลี่ยนแปลง. ตรวจสอบแรก [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). เฉพาะเมื่อค่าคือ `FillType.Solid` จึงอ่านคุณสมบัติการเติมแบบทึบ.

สำหรับการเติมแบบทึบ, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) คืนค่ารหัส RGB ที่เรนเดอร์สุดท้ายหลังจากสืบทอด, ค้นหาธีม, และการแปลงสี. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) คืนค่าสกีมสี [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) ที่สอดคล้อง, เช่น `Text1` หรือ `Accent6`. ค่า `SchemeColor.NotDefined` หมายความว่าการเติมแบบทึบที่มีผลไม่ได้อิงสกีมสี. ในกระบวนการที่เติมเป็นสีธีมหรือสี RGB โดยตรง, ค่านี้บ่งชี้การเติม RGB โดยตรง.

อย่าใช้ค่า [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) ท้องถิ่นเพียงอย่างเดียวเพื่อจัดประเภทการเติม. ตัวอย่างเช่น, ส่วนข้อความอาจไม่มีสกีมสีที่กำหนดในท้องถิ่น, ดังนั้นค่าท้องถิ่นเป็น `NotDefined`, แต่การเติมที่มีผลอาจสืบทอดสีธีมและแก้เป็น `Text1` หรือ `Accent6`. ตรงกันข้าม, `getSolidFillSchemeColor` บอกว่าช่องสกีมธีมใดสร้างสีที่มีผล, แต่ไม่บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลย์เอาต์, มาสเตอร์, หรือระดับอื่น.

ตัวอย่างต่อไปนี้โหลดการนำเสนอ, ตรวจสอบการเติมรูปทรงและการเติมส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสกีมสีที่เชื่อมโยง, และทำเครื่องหมายการเติมแบบทึบที่ไม่ติดตามการเปลี่ยนสีธีม:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

สาขา `NotDefined` ให้รายการตรวจสอบการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนสลอตสีธีม. ตรวจสอบวัตถุเหล่านี้เมื่อการนำเสนอจำเป็นต้องสอดคล้องกับพาเลตแบรนด์ใหม่. ค่าที่รายงานยังคงแสดงลักษณะปัจจุบัน, ขณะที่ค่าสกีมอธิบายว่าลักษณะนั้นเชื่อมกับธีมหรือไม่.

วัตถุรูปแบบที่มีผลเป็นภาพ snapshot. หลังจากเปลี่ยนธีมการนำเสนอ, การเขียนทับธีมหรือการจัดรูปแบบที่สืบทอด, เรียก `getEffective` อีกครั้งและอ่านออबเจ็กต์ `IFillFormatEffectiveData` ใหม่ก่อนเปรียบเทียบหรือรายงานสี.

## **อ่านค่าธีมที่มีผล**

ออบเจ็กต์ธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับนั้น. ค่าที่มีผลบอกว่าสไลด์หรือรูปทรงใช้อะไรจริงหลังจากสืบทอดและการเขียนทับท้องถิ่นได้รับการแก้. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), คุณอาจพลาดการเขียนทับที่มาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปทรงที่เปลี่ยนลักษณะสุดท้าย.

## **FAQ**

**การใช้ธีมภายนอกส่งผลต่อสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) จะย้ายเฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก. สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม.

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ทำได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีมของมัน. การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่นจะยังคงสืบทอดธีมเดิมต่อไป.

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะต้นฉบับ, ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน.

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือเลย์เอาต์ธีมและเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับออบเจ็กต์รูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). API เหล่านี้คืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับ.