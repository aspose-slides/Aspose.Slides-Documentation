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
- ธีมภายนอก
- THMX
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
description: "จัดการธีมงานนำเสนอหลักใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ประสานกัน. วัตถุที่รับรู้ธีมจะอ้างอิงการกำหนดร่วมเหล่านี้แทนการเก็บคุณสมบัติเพิ่มเติมทั้งหมดเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมจะอัปเดตวัตถุหลายรายการพร้อมกัน.

ใน Aspose.Slides, ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). งานนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำลงได้. มาสเตอร์สามารถแทนที่ธีมของงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), ส่วนเลย์เอาต์หรือสไลด์แต่ละสไลด์สามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). ในการปฏิบัติ, ธีมที่มีผลสำหรับสไลด์จะถูกแก้ไขผ่านโซ่การสืบทอดนี้: ธีมของงานนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์.

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานที่พบบ่อยที่สุดของธีม: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, ปรับปรุงสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้ถูกแก้ไขแล้ว.

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) เปิดเผยโครงสี, โครงแบบอักษร, และโครงรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงมีประโยชน์มากเมื่อ งานนำเสนอมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน.

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว, อย่าสมมติว่าทุกสไลด์มีธีมที่มีผลเท่ากัน. ตรวจสอบมาสเตอร์ที่เกี่ยวข้องกับสไลด์, และใช้กระบวนการทำงานของธีมที่มีผลที่แสดงต่อไปในบทความเมื่ออาจมีการแทนที่จากเลย์เอาต์หรือสไลด์.

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขตามค่ใหม่. วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม.

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมเปลี่ยน. หากคุณแทนที่สีเชิงตรรกะด้วยสีโดยตรงบนรูปทรง, การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป.

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันที่อ่อนและเข้มจากสีธีมโดยการใช้การแปลงสี. Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![สีธีมหลักและสีอ่อนและเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก.

**2** - เวอร์ชันอ่อนและเข้มที่สร้างจากสีธีมหลัก.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, และบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม. หาก `Accent4` เปลี่ยนภายหลัง, สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่.

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่ออื่นของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกระหว่างรูปแบบต่าง ๆ.

## **เปลี่ยนแบบอักษรของธีม**

โครงแบบอักษรของธีมมีชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความเนื้อหา. วิธีการ [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น.

ตัวระบุแบบอักษรของธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - แบบอักษรเนื้อหา Latin (แบบอักษร Latin รอง)
* `+mj-lt` - แบบอักษรหัวเรื่อง Latin (แบบอักษร Latin หลัก)
* `+mn-ea` - แบบอักษรเนื้อหา East Asian (แบบอักษร East Asian รอง)
* `+mj-ea` - แบบอักษรหัวเรื่อง East Asian (แบบอักษร East Asian หลัก)
* `+mn-cs` - แบบอักษรเนื้อหา Complex Script (แบบอักษร Complex Script รอง)
* `+mj-cs` - แบบอักษรหัวเรื่อง Complex Script (แบบอักษร Complex Script หลัก)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดเนื้อหาเดียวที่ใช้แบบอักษร Latin รอง. จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะตามแบบอักษรหลักและข้อความเนื้อหาจะตามแบบอักษรรอง. ข้อความที่มีชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อโครงแบบอักษรของธีมเปลี่ยน.

ชุดแบบอักษรหลักและรองอาจรวมแมปแบบอักษรสำหรับระบบเขียนแบบเฉพาะ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana. หากต้องการตรวจสอบ, เพิ่ม, แทนที่, หรือลบแมปเหล่านี้, ดูที่ [Script-Specific Theme Fonts](/slides/th/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรของงานนำเสนอ, ดูที่ [PowerPoint Fonts](/slides/th/androidjava/powerpoint-fonts/).
{{% /alert %}}

### **แก้ไขการอ้างอิงแบบอักษรของธีม**

เมื่อทำการตรวจสอบข้อความ, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) สามารถคืนค่าอ้างอิงธีมเช่น `+mn-lt` แทนชื่อฟอนต์. เรียก [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) พร้อมกับ [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) ที่เหมาะสมเพื่อแก้ไขอ้างอิงนั้น. คำหน้ `+mj` และ `+mn` เลือกชุดแบบอักษรหลักและรอง; ส่วนต่อท้าย `-lt`, `-ea`, และ `-cs` เลือกฟอนต์ Latin, East Asian, และ Complex Script ตามลำดับ.

รับธีมที่มีผลผ่าน [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) บนวัตถุที่ธีมของมันใช้กับข้อความที่ตรวจสอบ. สำหรับข้อความธรรมดาบนสไลด์, เรียกเมธอดนี้บนสไลด์เพื่อให้คอนเท็กซ์รวมธีมที่สืบทอดและการแทนที่ในระดับท้องถิ่น. เมื่อทำการตรวจสอบเลย์เอาต์หรือมาสเตอร์เอง, ใช้ธีมที่มีผลของมันเอง. อย่าสมมติว่าธีมของมาสเตอร์แรกใช้กับทุกสไลด์.

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงแบบอักษร Latin รองโดยตรง. มันเริ่มต้นโครงแบบอักษรของสไลด์ผ่าน [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) และตั้งค่าฟอนต์ Latin หลักและรองเป็น `Arial` และ `Calibri`, ทำให้ผลลัพธ์ทำซ้ำได้โดยไม่ต้องมีไฟล์อินพุต.

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

ผลลัพธ์คือ `+mn-lt -> Calibri` ตามด้วย `Verdana -> Verdana`. การอ้างอิงที่เก็บไว้ยังคงไม่เปลี่ยนแปลง, ในขณะที่ชื่อฟอนต์โดยตรงจะถูกคืนค่าเช่นเดิม. หากส่วนข้อความใช้ `+mj-lt`, จะแก้ไขเป็น `Arial` ในธีมนี้.

การแก้ไขอ้างอิงธีมจะระบุฟอนต์ที่ธีมกำหนด. มันไม่ได้ตรวจสอบความพร้อมใช้งานของฟอนต์หรือกำหนดไฟล์ฟอนต์ที่ใช้จริงหลังจากการทดแทนหรือ fallback ของ glyph ในขั้นตอนการเรนเดอร์. ดูที่ [Font Selection Sequence](/slides/th/androidjava/font-selection-sequence/) และ [Font Substitution](/slides/th/androidjava/font-substitution/) สำหรับขั้นตอนแยกเหล่านั้น.

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ไขปัญหาที่เกี่ยวข้องกับธีมต่าง ๆ.

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์**

ใช้ [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการเปลี่ยนสไตล์ทุกสไลด์ที่ขึ้นอยู่กับมาสเตอร์เฉพาะ. เลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ที่ทำงานร่วมกับ [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), แล้วส่งพาธไฟล์ธีมให้เมธอด.

เมธอดทำขั้นตอนต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่จากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่ก่อนหน้านี้ขึ้นอยู่กับมาสเตอร์ที่เลือก
1. คืนค่า [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์แรกและบันทึกงานนำเสนอ:

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). ตรวจสอบพาธที่ผู้ใช้ป้อน, จัดการข้อผิดพลาดการเข้าถึงไฟล์ระบบ, และบันทึกงานนำเสนอหลังจากธีมถูกนำไปใช้สำเร็จแล้วเท่านั้น.

จะมีการเปลี่ยนมาสเตอร์เฉพาะสไลด์ที่ขึ้นอยู่กับมาสเตอร์ที่เลือก. สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิม. สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก. สี, แบบอักษร, การเติม, และการจัดรูปแบบโดยตรงอาจยังคงไม่เปลี่ยนแปลง. การแทนที่ในระดับเลย์เอาต์และสไลด์อาจมีความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่.

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์. เพื่อให้การเรนเดอร์และการส่งออกสม่ำเสมอ, ให้ติดตั้งฟอนต์ที่จำเป็น, จัดหาให้ผ่าน [custom font sources](/slides/th/androidjava/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/androidjava/font-substitution/).

นี่เป็นกระบวนการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง.

### **ใช้ธีมภายนอกที่แตกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ที่เกี่ยวข้องล่วงหน้า, ให้ดึงมาสเตอร์จากสไลด์ตัวอย่างผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). เก็บอ้างอิงมาสเตอร์ต้นฉบับก่อนใช้ธีมใด ๆ เพราะแต่ละครั้งที่เรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ.

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อค้นหามาสเตอร์ของพวกเขาและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกส่งผลต่อสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, ส่วนการเรียกครั้งที่สองส่งผลต่อสไลด์ที่ขึ้นกับ `secondGroupMaster` เท่านั้น. สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะไม่ถูกเปลี่ยนสไตล์.

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบต้นฉบับไว้, ให้คัดลอกมาสเตอร์ต้นฉบับเข้าสู่งานนำหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), แล้วคัดลอกสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) พร้อมมาสเตอร์ที่คัดลอก. สิ่งนี้จะพิมพ์มาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องพร้อมกัน.

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนเดิมในปลายทาง. การคัดลอกรายการเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป.

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน, ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ. วิธีการ [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) คัดลอกสามส่วนหลักของธีมเข้าสู่การแทนที่.

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

การกระทำนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สืบทอดจากสไลด์อื่น. เพื่อลบการแทนที่ท้องถิ่นและคืนค่าเดิมที่สืบทอด, เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น, ยกเว้นกรณีที่สไลด์มีการแทนที่ของตนเอง. วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องแชร์การออกแบบพื้นฐานเดียวกัน, ใช้การแทนที่เลย์เอาต์เมื่อครอบครัวเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง, และใช้การแทนที่สไลด์เฉพาะเมื่อมีข้อยกเว้นจริง. การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมทั่วโลกในภายหลังคาดเดาได้ยาก.

<!-- visual-explanation:presentation-theme:start -->
[![มาสเตอร์ธีมหนึ่งส่งผลให้สองเลย์เอาต์; การแทนที่เลย์เอาต์มีผลต่อสไลด์ยกเว้นสไลด์ที่มีการแทนที่ท้องถิ่นระดับสูงกว่า.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*การแทนที่เลย์เอาต์จะมีผลกับสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นสไลด์ที่กำหนดการแทนที่ของตนเอง. ค่าที่อิงธีมจะตามสโคมที่แก้ไขแล้ว; วัตถุที่จัดรูปแบบโดยตรงสามารถคงลักษณะท้องถิ่นได้. ให้การแทนที่แคบเท่ากับข้อยกเว้นการออกแบบที่ต้องการ.*
<!-- visual-explanation:presentation-theme:end -->

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังเพิ่มเติมใน UI มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เพราะ UI สามารถผสานการเติมธีมกับสีธีมและอ้างอิงสไตล์อื่น ๆ ได้.

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/). ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกเป็นอ้างอิงสไตล์พื้นหลังของธีม. นี้ต่างจากการอ้างอิงดัชนีของคอลเลกชัน Java โดยตรง, ที่ `get_Item(0)` หมายถึงรายการแรกที่เก็บ. อย่าสมมติว่างานนำเสนอทุกไฟล์มีจำนวนสไตล์เติมพื้นหลังเท่าเดีย

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่อาจมีในระดับเลย์เอาต์หรือสไลด์. หากสไลด์ใช้พื้นหลังของตนเอง, การเปลี่ยนพื้นหลังมาสเตอร์อย่างเดียวอาจไม่เปลี่ยนสไลด์นั้น. ใช้ [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้.

{{% alert color="warning" title="Warning" %}}
อย่าถือว่าดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์. อย่าตั้งค่าตัวเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามันมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นเรื่องเฉพาะของงานนำเสนอ.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/).
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

โครงรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). ธีม Office ปกติมักมีสามรายการสไตล์หลักที่สอดคล้องกับการจัดรูปแบบแบบอ่อน, ปานกลาง, และเข้ม, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่.

![เอฟเฟกต์ธีมแบบอ่อน, ปานกลาง, และเข้มที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java, ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่เก็บและ `get_Item(2)` คือสไตล์ที่สาม. ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่จัดรูปแบบโดยตรงอาจคงเดิม.

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้เงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกโดยระยะ 10 จุด. ผลภาพที่แน่นอนยังคงขึ้นกับว่ารูปทรงใดอ้างอิงช่องสไตล์ใดและว่าการจัดรูปแบบโดยตรงได้แทนที่ธีมหรือไม่.

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนเส้น, การเติม, และการตั้งค่าเงา](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูปทรง**

รูปทรงสามารถเลือกการเติมและเส้นขอบได้อย่างอิสระผ่าน [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) และ [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). สำหรับแต่ละเมธอด, ดัชนี `1` เลือกรายการแรกในคอลเลกชันธีมที่สอดคล้อง (`get_Item(0)`), และดัชนี `2` เลือกรายการที่สอง (`get_Item(1)`).

ตัวอย่างต่อไปนี้ตั้งค่าสไตล์การเติมสองแบบ (ทองและฟ้าอมฟ้า) และสไตล์เส้นสองแบบ (สีน้ำเงินเข้ม 6 pt และสีแดงเข้ม 12 pt) ในธีมเริ่มต้นของงานนำเสนอใหม่. มันบันทึกสไลด์ในสามขั้นตอนเพื่อให้คุณเปรียบเทียบผลลัพธ์ใน PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| สไตล์เริ่มต้น | เปลี่ยนเส้นขอบขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมทองและฟ้าอมฟ้าที่มีเส้นขอบสีน้ำเงินเข้มบางตรงกัน](theme-style-initial.png) | ![สี่เหลี่ยมฟ้าอมฟ้าขณะนี้มีเส้นขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมซ้ายตอนนี้เป็นสีเขียวและเส้นขอบทั้งสองคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่แตกต่างจะเปลี่ยนเส้นขอบของสี่เหลี่ยมขวาเท่านั้น. การแก้ไขการเติมธีมแรกจะอัปเดตทุกรูปทรงที่ใช้มัน. ในที่นี้, เพียงสี่เหลี่ยมซ้ายจะเปลี่ยนเป็นสีเขียว.

บนรูปทรงที่มีอยู่, สีเติมท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถแทนที่ส่วนของสไตล์ธีมนั้นได้. หากการเปลี่ยนดัชนีสไตล์ไม่มีผลที่มองเห็น, ตรวจสอบ [การจัดรูปแบบโดยตรง](/slides/th/androidjava/shape-formatting/) ของรูปทรงนั้น.

## **ตรวจสอบว่าการเติมแบบทึบที่มีผลใช้สีธีมหรือไม่**

การเติมสามารถเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลย์เอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น. เรียก [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) เพื่อตรวจสอบลำดับชั้นนั้นเป็น [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) ที่ไม่เปลี่ยนแปลง. ก่อนอื่นตรวจสอบ [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). เฉพาะเมื่อเป็น `FillType.Solid` จึงควรอ่านคุณสมบัติการเติมแบบทึบ.

สำหรับการเติมแบบทึบ, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) คืนค่า RGB ที่เรนเดอร์สุดท้ายหลังจากสืบทอด, ค้นหาธีม, และแปลงสี. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) คืนค่าโครงสีเชิงตรรกะ [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) ที่สอดคล้อง, เช่น `Text1` หรือ `Accent6`. ค่า `SchemeColor.NotDefined` หมายถึงการเติมแบบทึบที่มีผลไม่ได้อิงจากสีสคีม. ในกระบวนการที่การเติมเป็นสีธีมหรือสี RGB โดยตรง, ค่านี้บ่งบอกว่าการเติมเป็น RGB โดยตรง.

อย่าใช้ค่า [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) ท้องถิ่นเพียงอย่างเดียวเพื่อจัดประเภทการเติม. ตัวอย่างเช่น, ส่วนข้อความอาจไม่มีค่าสคีมสีที่กำหนดในท้องถิ่น, ดังนั้นค่าท้องถิ่นเป็น `NotDefined`, ในขณะที่การเติมที่มีผลสืบทอดสีธีมและแก้ไขเป็น `Text1` หรือ `Accent6`. ตรงกันข้าม, `getSolidFillSchemeColor` บอกว่าช่องสคีมใดผลิตสีที่มีผล, แต่ไม่บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลย์เอาต์, มาสเตอร์ หรือระดับอื่น.

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ตรวจสอบการเติมของรูปทรงและส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสคีมสีที่เกี่ยวข้อง, และทำเครื่องหมายการเติมแบบทึบที่ไม่ติดตามการเปลี่ยนแปลงสีธีม:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
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

สาขา `NotDefined` ให้รายการตรวจสอบการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม. ตรวจสอบวัตถุเหล่านั้นเมื่อการนำเสนอจำเป็นต้องสอดคล้องกับพาเลตสีใหม่ของแบรนด์. ค่าที่แสดง RGB ยังแสดงลักษณะปัจจุบัน, ส่วนค่าสคีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่.

วัตถุที่ได้จากการจัดรูปแบบที่มีผลเป็นสแนปชอต. หลังจากเปลี่ยนธีมงานนำเสนอ, การแทนที่ธีม, หรือการจัดรูปแบบที่สืบทอดใด ๆ, ให้เรียก `getEffective` อีกครั้งและอ่านวัตถุ `IFillFormatEffectiveData` ใหม่ก่อนทำการเปรียบเทียบหรือรายงานสี.

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง. ค่าที่มีผลบอกว่าสตที่สไลด์หรือรูปทรงจริง ๆ ใช้อะไรหลังจากสืบทอดและการแทนที่ท้องถิ่นถูกแก้ไขแล้ว. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเพียง [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), คุณอาจพลาดมาสเตอร์, เลย์เอาต์, สไลด์, หรือการแทนที่รูปทรงที่เปลี่ยนลักษณะสุดท้าย.

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลกับสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก. สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิมไว้.

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการแทนที่ธีมของมัน. การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่นจะยังคงสืบทอดธีมเดิมต่อไป.

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องคงลักษณะต้นฉบับ, คัดลอกมาสเตอร์ต้นฉบับเข้าสู่ปลายทางและคัดลอกสไลด์พร้อมมาสเตอร์นั้นด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). วิธีนี้จะทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน.

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลย์เอาต์และวิธีการที่เกี่ยวข้องสำหรับวัตถุรูปแบบเช่น [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่.