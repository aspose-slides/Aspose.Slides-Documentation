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
description: "ควบคุมธีมงานนำเสนอหลักใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint พร้อมการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสี, ฟอนต์, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บคุณสมบัติวิสวลแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตหลายวัตถุพร้อมกันได้.

ใน Aspose.Slides, ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/). งานนำเสนออาจมีการบังคับใช้ธีมที่ระดับล่างได้เช่นกัน มาสเตอร์สามารถบังคับใช้ธีมของงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterthememanager/), ส่วนเลย์เอาต์หรือสไลด์เดี่ยวสามารถบังคับใช้ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/). โดยปฏิบัติ ธีมที่ใช้งานจริงสำหรับสไลด์หนึ่งจะได้รับการแก้ไขผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ, การบังคับใช้ของมาสเตอร์, การบังคับใช้ของเลย์เอ็ต, และการบังคับใช้ของสไลด์.

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานของธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่ใช้งานจริงหลังจากการสืบทอดและการบังคับใช้ได้รับการแก้ไข.

## **ตรวจสอบธีม**

ออบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/) เปิดเผยโครงร่างสี, โครงร่างฟอนต์, และโครงร่างรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่องานนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน.

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

หากไฟล์ใช้หลายมาสเตอร์, อย่าสมมติว่าทุกสไลด์มีธีมที่ใช้จริงเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์, และใช้กระบวนการทำงานของธีมที่ใช้จริงที่แสดงต่อไปนี้ในบทความเมื่อต้องมีการบังคับใช้ที่ระดับเลย์เออตหรือสไลด์.

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ได้ เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการประมวลผลกับค่าที่ใหม่. วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม.

ตัวอย่างต่อไปนี้จากต้นจนจบสร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่ใช้จริง:
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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมเปลี่ยน หากคุณแทนที่สีในสเคียมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อมาของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป.

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยการประยุกต์การแปลงสี. Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/colortransformoperation/).
![สีธีมหลักและสีอ่อนและเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก.  
**2** - เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีธีมหลัก.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปที่อ้างอิง `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, และบันทึกผลลัพธ์:
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

เวอร์ชันเหล่านี้ยังคงอ้างอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่.

### **แมปค่าของ `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/) แสดงช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปนี้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง.

## **เปลี่ยนฟอนต์ธีม**

โครงร่างฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความเนื้อหา. วิธี [IFontScheme.getMajor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) เปิดเผยชุดเหล่านั้น.

PowerPoint‑compatible theme font identifiers can be used in text formatting:
* `+mn‑lt` - ฟอนต์เนื้อหา Latin (ฟอนต์ Latin รอง)
* `+mj‑lt` - ฟอนต์หัวเรื่อง Latin (ฟอนต์ Latin หลัก)
* `+mn‑ea` - ฟอนต์เนื้อหา East Asian (ฟอนต์ East Asian รอง)
* `+mj‑ea` - ฟอนต์หัวเรื่อง East Asian (ฟอนต์ East Asian หลัก)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ Latin รองของธีม. จากนั้นเปลี่ยนฟอนต์ของธีมและบันทึกผลลัพธ์:
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

หัวเรื่องจะใช้ฟอนต์หลักและข้อความเนื้อหาจะใช้ฟอนต์รอง. ข้อความที่มีชื่อฟอนต์อย่างชัดเจนแทนตัวระบุธีมจะไม่เปลี่ยนโดยอัตโนมัติเมื่อโครงร่างฟอนต์ของธีมเปลี่ยน.

{{% alert color="info" title="Tip" %}}สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ของงานนำเสนอ, ดูที่ [PowerPoint Fonts](/slides/th/androidjava/powerpoint-fonts/).{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีกระบวนการทำงานทั่วไปสองแบบ, และพวกมันแก้ปัญหาที่แตกต่างกัน.

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

ถ้าคุณต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม, ให้ทำการโคลนมาสเตอร์ต้นฉบับไปยังงานนำหมายด้วย [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/), จากนั้นโคลนสไลด์ด้วย [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) และมาสเตอร์ที่โคลนไว้. วิธีนี้จะนำมาสเตอร์, เลย์เอาต์ของมัน, และธีมที่เกี่ยวข้องไปด้วย.
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

นี่เป็นกระบวนการทำงานที่แนะนำเมื่ สไลด์ต้นฉบับต้องดูเหมือนเดิมในปลายทาง. การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความเกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับโดยธีมเปลี่ยนแปลง.

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน, ให้เริ่มต้นการบังคับใช้ระดับสไลด์จากธีมต้นฉบับ. วิธี [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/) จะคัดลอกส่วนประกอบธีมหลักสามส่วนไปยังการบังคับใช้.
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

วิธีนี้จะเปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่เปลี่ยนธีมที่สืบทอดจากสไลด์อื่น. หากต้องการลบการบังคับใช้ในระดับท้องถิ่นและกลับสู่ค่าที่สืบทอด, ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/overridetheme/).

### **ใช้การบังคับใช้ธีมกับเลย์เอต**

การบังคับใช้ระดับเลย์เอ็ตจะนำไปใช้กับสไลด์ที่ใช้เลย์เอ็ตนั้น, เว้นแต่สไลด์เฉพาะจะมีการบังคับใช้ของตนเอง. วิธีการเริ่มต้นเดียวกันสามารถใช้ได้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslidethememanager/):
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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลย์เอัตและสไลด์ควรแชร์การออกแบบพื้นฐานเดียวกัน, ใช้การบังคับใช้ระดับเลย์เอ็ตเมื่อกลุ่มเลย์เอ็ตหนึ่งต้องการสไตล์ที่ต่างออกไป, และใช้การบังคับใช้ระดับสไลด์เฉพาะกรณีที่ต้องการข้อยกเว้นจริง. การบังคับใช้ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก.

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าจำนวนการกำหนดการเติมที่จัดเก็บในคอลเลกชันนี้จริง ๆ เนื่องจาก UI สามารถรวมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ.
![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่จัดเก็บและ [Background.getStyleIndex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) ปัจจุบัน. ดัชนีสไตล์ที่ `0` หมายถึงไม่มีการเติมแบบธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม. สิ่งนี้แตกต่างจากการทำดัชนีโดยตรงในคอลเลกชัน Java, ที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ. อย่าสมมติว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่าเดิม.

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่ใช้ได้, กำหนดการอ้างอิงพื้นหลังของธีมให้มาสเตอร์แรก, และบันทึกงานนำเสนอ:
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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการบังคับใช้พื้นหลังที่ระดับเลย์เอ็ตหรือสไลด์. หากสไลด์ใช้พื้นหลังของตนเอง, การเปลี่ยนพื้นหลังของมาสเตอร์เพียงอย่างเดียวอาจไม่ทำให้สไลด์นั้นเปลี่ยน. ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้.

{{% alert color="warning" title="Warning" %}}อย่าพิจารณาดัชนีสไตล์เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์. อีกทั้งหลีกเลี่ยงการกำหนดเลขสไตล์แบบคงที่จากไฟล์หนึ่งและสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นแบบเฉพาะงานนำเสนอ.{{% /alert %}}

{{% alert color="info" title="Tip" %}}สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/).{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

โครงร่างรูปแบบของธีมประกอบด้วยคอลเลกชันสไตล์การเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/), และ [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iformatscheme/). ธีม Office ปกติมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบเป็นแบบละมุน, ปานกลาง, และเข้มข้น, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่.
![เอฟเฟกต์ธีมละมุน, ปานกลาง, และเข้มข้นที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อคุณเข้าถึงคอลเลกชันเหล่านี้ใน Java, ดัชนีของคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม. ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจไม่เปลี่ยนแปลง.

ตัวอย่างต่อไปนี้ตรวจสอบว่ารายการสไตล์ที่ต้องการมีอยู่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดใช้เงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:
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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์การเติมธีมที่สามจะกลายเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะได้รับเงานอกที่มีระยะห่าง 10 พอยต์. ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปทรงแต่ละอันอ้างอิงช่องสไตล์ใดและว่าการจัดรูปแบบโดยตรงบังคับใช้ธีมหรือไม่.
![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น, การเติม, และเงา](presentation-design_11.png)

## **อ่านค่าธีมที่ใช้จริง**

อ็อบเจกต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรที่ระดับหนึ่ง. ค่าที่ใช้จริงบอกคุณว่าสไลด์หรือรูปทรงใช้อะไรจริงหลังจากการสืบทอดและการบังคับใช้ระดับท้องถิ่นได้รับการแก้ไข. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/).

ตัวอย่างต่อไปนี้อ่านธีมที่ใช้จริง, พื้นหลัง, และการเติมรูปทรงแรกจากสไลด์:
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

ใช้ข้อมูลที่ใช้จริงสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/), คุณอาจพลาดมาสเตอร์, เลย์เอาต์, สไลด์, หรือการบังคับใช้รูปทรงที่เปลี่ยนลักษณะสุดท้าย.

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**  
ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมบังคับใช้ของมัน. การเปลี่ยนแปลงจะอยู่ในระดับท้องถิ่นของสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมที่มีอยู่.

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**  
เมื่อย้ายสไลด์และคงลักษณะต้นฉบับ, ให้โคลนมาสเตอร์ต้นฉบับไปยังปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/) และ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/). วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน.

**ฉันจะดูค่าที่ใช้จริงหลังจากการสืบทอดและการบังคับใช้ได้อย่างไร?**  
ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseoverridethememanager/) สำหรับธีมของสไลด์หรือเลย์เออตและวิธีการข้อมูลที่ใช้จริงที่สอดคล้องสำหรับอ็อบเจกต์รูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่ได้รับการแก้ไขหลังจากการสืบทอดและการบังคับใช้.