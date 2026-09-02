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
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ธีมงานนำเสนอหลักใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อสร้าง ปรับแต่งและแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมของงานนำเสนอกำหนดชุดสี ตัวอักษร สไตล์พื้นหลัง การเติม สีเส้น และเอฟเฟกต์ที่ประสานกันอย่างเป็นระบบ วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามเหล่านี้แทนการเก็บคุณสมบัติวิดีโอแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลายรายการพร้อมกัน

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)。งานนำเสนออาจมีการปรับธีมในระดับที่ต่ำกว่าด้วยเช่นกัน มาสเตอร์สามารถเขียนทับธีมของงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterthememanager/)，ขณะที่เลเอาต์หรือสไลด์เดี่ยวสามารถเขียนทับธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/)。โดยจริง ๆ แล้วธีมที่มีผลสำหรับสไลด์หนึ่งจะถูกสรุปจากห่วงโซ่การสืบทอดนี้: ธีมของงานนำเสนอ → การเขียนทับโดยมาสเตอร์ → การเขียนทับโดยเลเอาต์ → การเขียนทับโดยสไลด์

![ส่วนประกอบของธีม: สี ตัวอักษร สไตล์พื้นหลัง และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้เสร็จสมบูรณ์

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/) เปิดเผยชุดสีชุดแบบอักษรและชุดรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/)。การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงมีประโยชน์เป็นพิเศษเมื่อไฟล์งานนำมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่จัดเก็บอยู่ในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่าสมมติว่าทุกสไลด์มีธีมที่มีผลเดียวกัน ให้ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์นั้น และใช้กระบวนการทำงานกับธีมที่มีผลตามที่อธิบายในบทความนี้เมื่อมีการเขียนทับจากเลเอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ได้ เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/)，ทุกวัตถุที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ใช้ค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบครบวงจรที่สร้างรูปร่างที่ใช้ `Accent4` เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง บันทึกงานนำเสนอ เปิดใหม่อีกครั้ง และพิมพ์สีการเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยน `Accent4` ต่อมาจะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/colortransformoperation/)

![สีหลักของธีมและสีอ่อน‑เข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีหลักของธีม

**2** - เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีหลักของธีม

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4` ใช้การแปลงความสว่างบนห้ารูปและบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ส่วน [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมพคงที่ดังนี้

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อสลับของช่องธีมเดียวกัน ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรของธีม**

ชุดแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวข้อและชุดแบบอักษรรองสำหรับเนื้อหา ตัวเมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านี้

ตัวระบุแบบอักษรของธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้

* `+mn-lt` - แบบอักษรเนื้อหา Latin (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวข้อ Latin (Major Latin Font)
* `+mn-ea` - แบบอักษรเนื้อหา East Asian (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวข้อ East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวข้อหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดเนื้อหาหนึ่งที่ใช้แบบอักษร Latin รอง จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

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

หัวข้อจะใช้แบบอักษรหลักและเนื้อหาจะใช้แบบอักษรรอง ข้อความที่ระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อชุดแบบอักษรของธีมเปลี่ยน

ชุดแบบอักษรหลักและรองยังสามารถมีการแมพแบบอักษรสำหรับระบบเขียนต่าง ๆ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อทำการตรวจสอบ, เพิ่ม, แทนที่ หรือเอาการแมพเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/androidjava/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรในงานนำเสนอ ให้ดู [PowerPoint Fonts](/slides/th/androidjava/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ไขปัญหาต่าง ๆ ที่เกี่ยวกับธีม

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์**

ใช้ [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์ที่ระบุ ให้เลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่ทำงานเป็น [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/) แล้วส่งพาธไฟล์ธีมให้เมธอด

เมธอดทำงานดังต่อไปนี้

1. สร้างมาสเตอร์สไลด์ใหม่จากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก
1. คืนค่า [IMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) ที่สร้างขึ้นใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์แรกและบันทึกงานนำเสนอ:

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxreadexception/)。ตรวจสอบพาธที่ผู้ใช้ใส่, จัดการกับข้อผิดพลาดการเข้าถึงระบบไฟล์, และบันทึกงานนำเสนอหลังจากที่ธีมถูกนำไปใช้สำเร็จ

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่ถูกเปลี่ยนมาสเตอร์ สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมไว้ สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก สี, แบบอักษร, การเติมและการจัดรูปแบบอื่น ๆ ที่กำหนดโดยตรงอาจคงเดิม การเขียนทับระดับเลเอาต์และสไลด์ก็อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อให้การเรนเดอร์และการส่งออกสอดคล้องกัน ให้ติดตั้งฟอนต์ที่ต้องการ, ให้บริการผ่าน [custom font sources](/slides/th/androidjava/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/androidjava/font-substitution/)

นี่เป็นกระบวนการระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการเขียนทับระดับสไลด์หรือเลเอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกที่ต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ล่วงหน้า ให้ดึงมาสเตอร์จากสไลด์ตัวอย่างผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/)。บันทึกการอ้างอิงมาสเตอร์ต้นฉบับก่อนทำการใช้ธีมใด ๆ เนื่องจากแต่ละครั้งที่เรียกเมธอดจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อหามาสเตอร์ของพวกมันและใช้ธีมภายนอกที่ต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกส่งผลต่อสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองส่งผลต่อสไลด์ที่ขึ้นกับ `secondGroupMaster` เท่านั้น สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์

### **รักษาธีมต้นฉบับขณะย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและต้องการคงการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับเข้าไปในงานนำหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/)，จากนั้นคัดลอกสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) พร้อมมาสเตอร์ที่คัดลอก ทำให้มาสเตอร์, เลเอาต์, และธีมที่เกี่ยวข้องไปด้วยกัน

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

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนเดิมในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่สัมพันธ์กันอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์ปลายทางต้องคงมาสเตอร์และเลเอาต์เดิม ให้เริ่มการเขียนทับระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/) จะคัดลอกส่วนประกอบธีมหลักสามส่วนไปยังการเขียนทับ

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

การทำเช่นนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดจากสไลด์อื่น ๆ เพื่อเอาการเขียนทับระดับท้องถิ่นออกและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/)

### **ใช้การเขียนทับธีมกับเลเอาต์**

การเขียนทับระดับเลเอาต์จะนำไปใช้กับสไลด์ที่ใช้เลเอาต์นั้น เว้นแต่สไลด์ใดสไลด์หนึ่งมีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslidethememanager/) ได้:

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลเอาต์และสไลด์ต้องการออกแบบพื้นฐานเดียวกัน ใช้การเขียนทับเลเอาต์เมื่อกลุ่มเลเอาต์ต้องการสไตล์แตกต่าง และใช้การเขียนทับสไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง ๆ การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมโดยรวมในภายหลังทำนายยากขึ้น

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์การเติมพื้นหลังของธีมถูกจัดเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/)。PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่มีอยู่จริงในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่าปัจจุบันของ [Background.getStyleIndex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/)。ค่าดัชนีสไตล์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม สิ่งนี้ต่างจากการนับดัชนีของคอลเลกชัน Java โดยตรงที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มีอยู่, กำหนดการอ้างอิงพื้นหลังที่เป็นธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่ระดับเลเอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์อย่างเดียวอาจไม่ทำให้สไลด์นั้นเปลี่ยน ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำมาใช้

{{% alert color="warning" title="Warning" %}}
อย่าอ้างอิงดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ และหลีกเลี่ยงการกำหนดหมายเลขสไตล์แบบคงที่จากไฟล์หนึ่งแล้วสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; การกำหนดค่าสไตล์ของธีมเป็นเรื่องเฉพาะงานนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

ชุดรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/)。ธีม Office ทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟกต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapestyle/)。การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์นั้น; รูปร่างที่ใช้การจัดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้เงาภายนอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าทึบแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะมีเงาภายนอกที่ระยะ 10 จุด ผลลัพธ์ภาพที่แท้จริงยังคงขึ้นกับว่ารูปร่างแต่ละรูปอ้างอิงช่องสไตล์ใดและการจัดรูปแบบโดยตรงอาจเขียนทับธีมหรือไม่

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนเส้น, เติม, และการตั้งค่าเงา](presentation-design_11.png)

## **กำหนดว่าการเติมแบบ Solid มีการใช้สีธีมหรือไม่**

การเติมอาจเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลเอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น ๆ เรียกใช้ [IFillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformat/) เพื่อแก้ลำดับชั้นนี้เป็น [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/) ที่ไม่เปลี่ยนแปลงได้ ก่อนอื่นตรวจสอบ [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/) เท่านั้นเมื่อค่าเป็น `FillType.Solid` จึงอ่านคุณสมบัติการเติมแบบ Solid

สำหรับการเติมแบบ Solid, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/) จะคืนค่ารหัส RGB สุดท้ายหลังจากการสืบทอด, การค้นหาธีม, และการแปลงสี [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/) จะคืนช่อง [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ที่สอดคล้อง เช่น `Text1` หรือ `Accent6` ค่า `SchemeColor.NotDefined` หมายความว่าการเติม Solid ที่มีผลไม่ได้อ้างอิงจากสีสกีม ในกระบวนการที่การเติมเป็นสีธีมหรือสี RGB โดยตรง ค่าดังกล่าวบ่งบอกว่าการเติมเป็นสี RGB โดยตรง

ห้ามใช้ค่า [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorformat/) ในระดับท้องถิ่นอย่างเดียวเพื่อจัดประเภทการเติม ตัวอย่างเช่น ส่วนข้อความอาจไม่มีสีสกีมที่กำหนดในระดับท้องถิ่น จึงค่า `NotDefined` แต่การเติมที่มีผลอาจสืบทอดจากสีธีมและแปลงเป็น `Text1` หรือ `Accent6` ตรงกันข้าม `getSolidFillSchemeColor` บอกว่าช่องธีมตรรกะใดสร้างสีที่มีผล แต่ไม่ได้บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลเออต์, มาสเตอร์ หรือระดับอื่นของลำดับการจัดรูปแบบ

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ตรวจสอบการเติมของรูปร่างและส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสีสกีมที่เกี่ยวข้อง, และระบุการเติม Solid ที่จะไม่ติดตามการเปลี่ยนแปลงสีธีม:

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

สาขา `NotDefined` ให้รายการตรวจสอบของการเติม Solid ที่จะไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม ตรวจสอบวัตถุเหล่านั้นเมื่อการนำเสนอจำเป็นต้องสอดคล้องกับพาเลตแบรนด์ใหม่ ค่ RGB ที่รายงานยังคงแสดงภาพปัจจุบัน ส่วนค่าช่องสกีมอธิบายว่าภาพนั้นเชื่อมต่อกับธีมหรือไม่

วัตถุรูปแบบที่มีผลเป็นสแนปชอต หลังจากเปลี่ยนธีมของงานนำเสนอ, การเขียนทับธีม, หรือการจัดรูปแบบที่สืบทอดใด ๆ ให้เรียก `getEffective` อีกครั้งและอ่านวัตถุ `IFillFormatEffectiveData` ใหม่ก่อนทำการเปรียบเทียบหรือรายงานสี

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่าสไลด์หรือรูปร่างจริง ๆ ใช้อะไรหลังจากการสืบทอดและการเขียนทับในระดับท้องถิ่น การอ่านค่าที่มีผลสำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/)。สำหรับพื้นหลัง ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/)，และสำหรับการเติม ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์หนึ่ง:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) คุณอาจพลาดการเขียนทับที่มาสเตอร์, เลเอาต์, สไลด์, หรือรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **FAQ**

**การใช้ธีมภายนอกจะส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) จะกำหนดสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้น สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิมไว้

**ฉันสามารถใช้ธีมกับสไลด์เดี่ยวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีม การเปลี่ยนแปลงจะอยู่ในระดับสไลด์นั้นเท่านั้น สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการคงลักษณะเดิมของต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) วิธีนี้ทำให้มาสเตอร์, เลเอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือเลเอาต์ธีม และเมธอดที่ให้ข้อมูลที่มีผลสำหรับวัตถุรูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำมาใช้  