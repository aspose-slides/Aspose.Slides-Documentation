---
title: จัดการธีมการนำเสนอบน Android
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/androidjava/presentation-theme/
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
- พาเลทเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Android ด้วย Java เพื่อสร้าง ปรับแต่งและแปลงไฟล์ PowerPoint ให้สอดคล้องกับการสร้างแบรนด์."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติมสี, เส้น, และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงการกำหนดร่วมเหล่านี้แทนการเก็บค่าคุณลักษณะภาพแต่ละอย่างเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุต่าง ๆ ได้หลายรายการพร้อมกัน

ใน Aspose.Slides, ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/). การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำกว่าด้วย มาสเตอร์สามารถแทนที่ธีมของการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterthememanager/), ขณะที่เลย์เอาต์หรือสไลด์แต่ละสไลด์สามารถแทนที่ธีมที่สืบทอดมาได้ผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/). ในทางปฏิบัติ ธีมที่ใช้จริงสำหรับสไลด์หนึ่งจะถูกกำหนดผ่านห่วงโซ่การสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานที่พบบ่อยที่สุดของธีม: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, ปรับปรุงสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่ใช้จริงหลังจากการสืบทอดและการแทนที่ถูกแก้ไขแล้ว

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/) เปิดเผยชุดสีธีม, ชุดแบบอักษร, และชุดรูปแบบผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์เป็นพิเศษเมื่อการนำเข้ามาจากแหล่งภายนอกเนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, เติมสี, เส้น, และเอฟเฟกต์ที่ถูกจัดเก็บในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว, อย่าถือว่าทุกสไลด์มีธีมที่ใช้จริงเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมกับสไลด์และใช้กระบวนการทำงานของธีมที่ใช้จริงที่แสดงต่อไปนี้เมื่ออาจมีการแทนที่ที่ระดับเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติมสี, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจากการนับเฉพาะใน enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/). เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขตามค่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, แล้วพิมพ์สีเติมที่ใช้จริง:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่ส่งผลต่อการเติมสีนั้นอีกต่อไป

### **ใช้สีจากพาเลทเพิ่มเติม**

PowerPoint สร้างเวอร์ชันอ่อนและเข้มจากสีธีมโดยการใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/colortransformoperation/).

![สีธีมหลักและสีที่อ่อนและเข้มที่สร้างจากพาเลทเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีอ่อนและสีเข้มที่ผลิตจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ทำการแปลงความสว่างกับห้ารูป, แล้วบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` มีการเปลี่ยนแปลงในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมพนี้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

นี่เป็นชื่ออื่นของช่องธีมเดียวกัน; ไม่ใช่ค่าที่ถูกแปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรธีม**

ชุดแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับเนื้อหา เมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn-lt` - แบบอักษรเนื้อหา ละติน (แบบอักษรละตินรอง)
* `+mj-lt` - แบบอักษรหัวเรื่อง ละติน (แบบอักษรละตินหลัก)
* `+mn-ea` - แบบอักษรเนื้อหา เอเชียตะวันออก (แบบอักษรเอเชียตะวันออกรอง)
* `+mj-ea` - แบบอักษรหัวเรื่อง เอเชียตะวันออก (แบบอักษรเอเชียตะวันออกหลัก)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษรละตินหลักและบรรทัดเนื้อหาหนึ่งที่ใช้แบบอักษรละตินรอง จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้แบบอักษรหลักและข้อความเนื้อหาใช้แบบอักษรรอง ข้อความที่ระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อชุดแบบอักษรธีมมีการเปลี่ยนแปลง

ชุดแบบอักษรหลักและรองยังสามารถมีการแมพแบบอักษรสำหรับระบบการเขียนแต่ละระบบ เช่น ซีริลลิก, ภาษาอาหรับ, ภาษาญี่ปุ่น, จอร์เจีย, และธานา เพื่อตรวจสอบ, เพิ่ม, แทนที่, หรือเอาออกการแมพเหล่านี้, ดู [Script-Specific Theme Fonts](/slides/th/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรการนำเสนอ, ดูที่ [PowerPoint Fonts](/slides/th/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการทำงานด้านล่างแก้ไขปัญหาที่เกี่ยวกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์**

ใช้ [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นอยู่กับมาสเตอร์หนึ่งเลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ซึ่งเป็นการทำงานของ [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/), แล้วส่งเส้นทางไฟล์ธีมไปยังเมธอด

เมธอดทำงานต่อไปนี้:

1. สร้างสไลด์มาสเตอร์ใหม่โดยอิงจากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นอยู่กับมาสเตอร์ที่เลือก
1. ส่งคืน [IMasterSlide] ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์แรกและบันทึกการนำเสนอ:

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxreadexception/). ตรวจสอบเส้นทางที่ผู้ใช้ป้อน, จัดการการล้มเหลวของการเข้าถึงไฟล์ระบบ, และบันทึกการนำเสนอเฉพาะหลังจากธีมถูกใช้สำเร็จ

เฉพาะสไลด์ที่ขึ้นอยู่กับมาสเตอร์ที่เลือกเท่านั้นที่จะถูกกำหนดใหม่ สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมไว้ สี, แบบอักษร, การเติมสี, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก สี, แบบอักษร, การเติมสี, และรูปแบบที่กำหนดโดยตรงอาจคงเดิม การแทนที่ระดับเลย์เอาต์และระดับสไลด์ก็อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อการเรนเดอร์และการส่งออกที่สอดคล้อง, ให้ติดตั้งแบบอักษรที่จำเป็น, ให้บริการผ่าน [custom font sources](/slides/th/androidjava/custom-font/), หรือกำหนด [font substitution](/slides/th/androidjava/font-substitution/)

นี่เป็นการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับเส้นทางไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกที่แตกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า, ให้ดึงมาสเตอร์จากสไลด์ตัวแทนผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/). เก็บอ้างอิงมาสเตอร์ต้นฉบับก่อนทำการใช้ธีมใด ๆ เพราะแต่ละครั้งที่เรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อค้นหามาสเตอร์ของพวกมันและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกส่งผลต่อสไลด์ที่ขึ้นอยู่กับ `firstGroupMaster` เท่านั้น, ส่วนการเรียกครั้งที่สองส่งผลต่อสไลด์ที่ขึ้นอยู่กับ `secondGroupMaster` เท่านั้น. สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์

### **รักษาธีมต้นทางเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม, ให้โคลนมาสเตอร์ต้นทางลงในงานนำหมายโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/), จากนั้นโคลนสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) และมาสเตอร์ที่โคลนไว้ การทำเช่นนี้จะพามาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องมาด้วยกัน

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นทางต้องแสดงผลเหมือนเดิมในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน, ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นทาง เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/) คัดลอกสามส่วนหลักของธีมเข้าสู่การแทนที่

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

การทำเช่นนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อเอาการแทนที่ท้องถิ่นออกและกลับไปใช้ค่าที่สืบทอด, เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะนำไปใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น, ยกเว้นสไลด์ใดที่มีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ควรใช้การออกแบบฐานเดียวกัน, ใช้การแทนที่ระดับเลย์เอาต์เมื่อกลุ่มเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง, และใช้การแทนที่ระดับสไลด์เฉพาะกรณีที่จำเป็น การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมระดับโลกในภายหลังพยากรณ์ได้ยากขึ้น

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์พื้นหลังของธีมถูกจัดเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการเติมสีที่จัดเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถรวมการเติมสีธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมสีธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังธีม นี่แตกต่างจากการทำดัชนีคอลเลกชัน Java โดยตรง, ที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมสีพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมสีพื้นหลังที่มี, กำหนดอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่ระดับเลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์อาจไม่เปลี่ยนสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) เมื่อจำเป็นต้องทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}
ห้ามถือดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ ควรหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ธีมเป็นลักษณะเฉพาะของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

ชุดรูปแบบธีมประกอบด้วยคอลเลกชันการเติมสี, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/). ธีม Office ปกติมักมีสามรายการสไตล์หลักที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![เอฟเฟกต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java, ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมสีที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมสีธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกระยะ 10 จุด ผลลัพธ์ภาพสุดท้ายยังคงขึ้นกับสไตล์ที่แต่ละรูปร่างอ้างอิงและว่าการจัดรูปแบบโดยตรงได้ทับธีมหรือไม่

![สไตล์เอฟเฟกต์ธีมหลังจากการเปลี่ยนเส้น, เติมสี, และการตั้งค่าเงา](presentation-design_11.png)

## **อ่านค่าธีมที่ใช้จริง**

วัตถุธีมดิบบอกคุณว่ามีการกำหนดอะไรไว้ที่ระดับหนึ่ง ค่าที่ใช้จริงบอกคุณว่าสไลด์หรือรูปร่างใช้อะไรจริงหลังจากการสืบทอดและการแทนที่ในระดับท้องถิ่นถูกแก้ไขแล้ว สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/), และสำหรับการเติมสี, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/).

ตัวอย่างต่อไปนี้อ่านธีมที่ใช้จริง, พื้นหลัง, และการเติมสีของรูปร่างแรกจากสไลด์:

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

ใช้ข้อมูลที่ใช้จริงสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/), คุณอาจพลาดมาสเตอร์, เลย์เอาต์, สไลด์, หรือการแทนที่ของรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลต่อสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นอยู่กับมาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิมไว้

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการแทนที่ธีม การเปลี่ยนแปลงจะอยู่ในระดับสไลด์เท่านั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาการออกแบบต้นฉบับ, ให้โคลนมาสเตอร์ต้นทางเข้าสู่ปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/). วิธีนี้จะเก็บมาสเตอร์, เลย์เอาต์, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่ใช้จริงหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลย์เอาต์และเมธอดข้อมูลที่ใช้จริงที่สอดคล้องสำหรับวัตถุรูปแบบเช่น [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้.