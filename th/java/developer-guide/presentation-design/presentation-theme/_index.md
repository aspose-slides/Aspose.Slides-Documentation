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
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint โดยคงแบรนด์ดิ้งที่สอดคล้องกัน"
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้นและเอฟเฟ็กต์ที่ประสานกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติภาพแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุหลายรายการพร้อมกัน

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/). การนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำกว่าด้วยเช่นกัน มาสเตอร์สามารถเขียนทับธีมของการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterthememanager/), ขณะที่เลเอาต์หรือสไลด์เดี่ยวสามารถเขียนทับธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/). ในทางปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะได้รับการแก้ไขผ่านลำดับการสืบทอดนี้: ธีมการนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลเอาต์ → การเขียนทับของสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลังและเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานของธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, ปรับสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับเสร็จสมบูรณ์

## **ตรวจสอบธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/) แสดงสกีมสี, สกีมแบบอักษร และสกีมรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานว่ามีสไตล์พื้นหลัง, การเติม, เส้นและเอฟเฟ็กต์กี่รายการที่เก็บอยู่ในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว อย่าสมมติว่าทุกสไลด์มีธีมที่มีผลแบบเดียวกัน ตรวจสอบมาสเตอร์ที่สัมพันธ์กับสไลด์และใช้กระบวนการทำงานของธีมที่มีผลตามที่แสดงต่อไปในบทความเมื่ออาจมีการเขียนทับที่ระดับเลเอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้นและข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจากรายการ [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/), ทุกวัตถุที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้งและพิมพ์สีการเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากเปลี่ยนธีม หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่มีผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่านรายการ [ColorTransformOperation](https://reference.aspose.com/slides/th/java/com.aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อนและเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก  

**2** – เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้าอันและบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` มีการเปลี่ยนแปลงในภายหลัง สีที่แปลงแล้วจะถูกคำนวนใหม่จากค่าของ `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

รายการ [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2` และ `Background2` ขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/) เปิดเผยช่องของธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2` และ `Light2` การแมปคงที่ดังนี้

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความตัว body วิธี `IFontScheme.getMajor` และ `IFontScheme.getMinor` (https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` – ฟอนต์ตัว body Latin (Minor Latin Font)
* `+mj-lt` – ฟอนต์หัวเรื่อง Latin (Major Latin Font)
* `+mn-ea` – ฟอนต์ตัว body East Asian (Minor East Asian Font)
* `+mj-ea` – ฟอนต์หัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งบรรทัดที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งบรรทัดที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้ฟอนต์หลักและข้อความ body จะใช้ฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมแบบอักษรของธีมเปลี่ยน

ชุดฟอนต์หลักและรองยังสามารถมีการแมปฟอนต์สำหรับระบบเขียนแบบเฉพาะ เช่น Cyrillic, Arabic, Japanese, Georgian และ Thaana เพื่อดู, เพิ่ม, แทนที่ หรือเอาการแมปเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/java/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรการนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/java/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการทำงานต่อไปนี้แก้ไขปัญหาเรื่องธีมที่แตกต่างกัน

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์**

ใช้ [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ที่ทำงานเป็น [IMasterSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/) แล้วส่งพาธไฟล์ธีมให้เมธอด

เมธอดทำงานดังนี้

1. สร้างมาสเตอร์สไลด์ใหม่บนพื้นมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก
1. คืนค่าอ็อบเจ็กต์ [IMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) ที่สร้างใหม่

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

ธีมที่ไม่ถูกต้อง, เสียหาย หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxreadexception/). ตรวจสอบพาธที่ผู้ใช้ส่งมา, จัดการกับข้อผิดพลาดการเข้าถึงระบบไฟล์, และบันทึกการนำเสนอเฉพาะเมื่อธีมถูกนำไปใช้สำเร็จ

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นจะถูกเปลี่ยน มาสเตอร์และธีมของสไลด์ที่เชื่อมกับมาสเตอร์อื่นจะคงเดิม สี, แบบอักษร, การเติม, เส้น, พื้นหลังและเอฟเฟ็กต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก สี, ฟอนต์, การเติมและการฟอร์แมตที่กำหนดโดยตรงอาจคงเดิม การเขียนทับระดับเลเอาต์และสไลด์ยังอาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมการทำงาน เพื่อให้การเรนเดอร์และการส่งออกสอดคล้อง ควรติดตั้งฟอนต์ที่จำเป็น, จัดหาให้ผ่าน [custom font sources](/slides/th/java/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/java/font-substitution/)

นี่เป็นกระบวนการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการเขียนทับธีมระดับสไลด์หรือเลเอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกต่าง ๆ ในการนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ล่วงหน้า ให้ดึงมาสเตอร์จากสไลด์ตัวอย่างผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/). เก็บอ้างอิงมาสเตอร์เดิมไว้ก่อนทำการใช้ธีมใด ๆ เพราะแต่ละการเรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

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

การเรียกครั้งแรกส่งผลต่อสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองส่งผลต่อสไลด์ที่ขึ้นกับ `secondGroupMaster` เท่านั้น สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังการนำเสนออื่นและรักษาการออกแบบเดิม ให้โคลนมาสเตอร์ต้นฉบับไปยังการนำเสนอเป้าหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/), แล้วโคลนสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) พร้อมมาสเตอร์ที่โคลนไว้ สิ่งนี้จะพ้อมมาสเตอร์, เลเอาต์และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลังและเอฟเฟ็กต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลเอาต์ปัจจุบัน ให้สร้างการเขียนทับระดับสไลด์จากธีมต้นทาง เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/) จะคัดลอกสามส่วนหลักของธีมเข้าสู่การเขียนทับ

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

การทำเช่นนี้จะเปลี่ยนธีมของสไลด์นั้นโดยไม่กระทบธีมที่สืบทอดจากสไลด์อื่น ๆ เพื่อเอาการเขียนทับท้องถิ่นออกและกลับไปสู่ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/overridetheme/)

### **ใช้การเขียนทับธีมกับเลเอาต์**

การเขียนทับระดับเลเอาต์จะใช้กับสไลด์ที่ใช้เลเอาต์นั้น ยกเว้นกรณีสไลด์มีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลเอาต์และสไลด์ต้องการแชร์การออกแบบฐานเดียวกัน ใช้การเขียนทับระดับเลเอาต์เมื่อครอบครัวเลเอาต์หนึ่งต้องการสไตล์ที่แตกต่างกัน และใช้การเขียนทับระดับสไลด์เฉพาะกรณีพิเศษ การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมแบบรวมในภายหลังทำนายได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์การเติมพื้นหลังของธีมถูกเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) ปัจจุบัน ค่าอินเดกซ์ `0` หมายถึงไม่มีการเติมธีม; ค่าเป็นบวกหมายถึงอ้างอิงสไตล์พื้นหลังของธีม นี่ต่างจากการใช้ดัชนีของคอลเลกชัน Java โดยตรงที่ `get_Item(0)` คือรายการที่เก็บเป็นแรก อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดอ้างอิงพื้นหลังที่มีธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างถึงและการเขียนทับพื้นหลังที่ระดับเลเอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์อาจไม่กระทบสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) เมื่อจำเป็นต้องทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่าอ้างอิงดัชนีสไตล์เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามันแสดงผลเหมือนกันในไฟล์อื่น; นิยามสไตล์ของธีมจะเป็นเฉพาะการนำเสนอแต่ละไฟล์
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการฟอร์แมตพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

สกีมรูปแบบของธีมประกอบด้วยคอลเลกชันการเติม, เส้นและเอฟเฟ็กต์ที่แยกกัน โดยเปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/iformatscheme/). ธีมของ Office ปกติมักมีสามรายการสไตล์หลักที่สอดคล้องกับการฟอร์แมตแบบ subtle, moderate และ intense อย่างไรก็ตามโค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติจำนวนคงที่

![เอฟเฟ็กต์ธีม subtle, moderate, และ intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Java ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่เก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก ซึ่งเปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์นั้น; รูปร่างที่มีฟอร์แมตโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟ็กต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์การเติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะเพิ่มเงานอกด้วยระยะ 10 จุด ผลลัพธ์ที่เห็นยังคงขึ้นอยู่กับว่ารูปร่างใดอ้างอิงช่องใดและฟอร์แมตโดยตรงจะเขียนทับธีมหรือไม่

![สไตล์เอฟเฟ็กต์ธีมหลังจากเปลี่ยนการตั้งค่าเส้น, การเติมและเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจ็กต์ธีมดิบบอกว่าอะไรถูกกำหนดในระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่า สไลด์หรือรูปร่างใช้ค่าอะไรหลังจากการสืบทอดและการเขียนทับท้องถิ่น ตัวอย่างเช่น สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/), และสำหรับการเติมใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบความถูกต้องและการเปรียบเทียบ หากคุณตรวจสอบเพียง [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) คุณอาจพลาดมาสเตอร์, เลเอาต์, สไลด์ หรือการเขียนทับของรูปร่างที่เปลี่ยนการแสดงผลสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลต่อสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีมของมัน การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการพาธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะเดิมของแหล่ง ให้โคลนมาสเตอร์ต้นทางเข้าไปในปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/). วิธีนี้ทำให้มาสเตอร์, เลเอาต์และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมระดับเลเอาต์ และเมธอดที่ให้ค่าข้อมูลที่มีผลสำหรับอ็อบเจ็กต์ฟอร์แมต เช่น [Background.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่ได้รับการแก้ไขหลังจากการสืบทอดและการเขียนทับเสร็จสมบูรณ์.