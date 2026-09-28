---
title: จัดการมาสเตอร์สไลด์ของการนำเสนอบน Android
linktitle: มาสเตอร์สไลด์
type: docs
weight: 70
url: /th/androidjava/slide-master/
keywords:
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- หลายสไลด์มาสเตอร์
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตัวอ้างอิง
- คัดลอกสไลด์มาสเตอร์
- ทำสำเนาสไลด์มาสเตอร์
- ทำซ้ำสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการมาสเตอร์สไลด์ใน Aspose.Slides สำหรับ Android ผ่าน Java: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบ, และลบสไลด์มาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

**มาสเตอร์สไลด์** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถประกอบด้วยรูปทรงทั่วไป, โลโก้, พื้นหลัง, สไตล์ข้อความ, การตั้งค่าธีม, และการตั้งค่าฝั่งล่าง (footer) ใน PowerPoint การแก้ไขมาสเตอร์สไลด์เป็นวิธีปกติในการทำให้การนำเสนอมีความสอดคล้องโดยไม่ต้องทำซ้ำการฟอร์แมตเดียวกันบนทุกสไลด์

Aspose.Slides for Android via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมีมาสเตอร์สไลด์หนึ่งหรือหลายสไลด์ และแต่ละมาสเตอร์สไลด์สามารถมีสไลด์เค้าโครงหลายสไลด์ สไลด์ปกติมักไม่อ้างอิงมาสเตอร์สไลด์โดยตรง แต่สไลด์ปกติใช้สไลด์เค้าโครง และสไลด์เค้าโครงนั้นเป็นของมาสเตอร์สไลด์

ลำดับชั้นของมาสเตอร์สไลด์, สไลด์เค้าโครง, และสไลด์ปกติ:

1. **มาสเตอร์สไลด์** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน.
2. **สไลด์เค้าโครง** - กำหนดการจัดวางเฉพาะของ placeholder และการฟอร์แมตระดับเค้าโครง.
3. **สไลด์ปกติ** - มีเนื้อหาการนำเสนอจริงและใช้สไลด์เค้าโครงหนึ่งสไลด์.

![ลำดับชั้นของมาสเตอร์สไลด์, สไลด์เค้าโครง, และสไลด์ปกติ](slide-master_2.jpg)

ใน Aspose.Slides, มาสเตอร์สไลด์จะถูกแทนด้วยอินเทอร์เฟซ [IMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) . มาสเตอร์สไลด์ทั้งหมดในงานนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getMasters--) ซึ่ง implements [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/). สำหรับ API เต็มของ Android via Java โปรดดูที่ [com.aspose.slides API reference](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเดียวกันถูกกำหนดในหลายระดับ ระดับที่เฉพาะเจาะจงกว่าจะชนะ เช่น หากมาสเตอร์สไลด์และสไลด์เค้าโครงทั้งสองกำหนดพื้นหลัง สไลด์ที่อิงจากเค้าโครงนั้นจะใช้พื้นหลังของเค้าโครง สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสไลด์เค้าโครงดูที่ [Apply or Change Slide Layouts](/slides/th/androidjava/slide-layout/).
{{% /alert %}}

## **เข้าถึงมาสเตอร์สไลด์**

ใน PowerPoint คุณสามารถเปิดมุมมองมาสเตอร์สไลด์ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master ในแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ใช้คอลเลกชัน `getMasters()` เพื่อเข้าถึงมาสเตอร์สไลด์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถรับมาสเตอร์สไลด์ที่ใช้โดยสไลด์ปกติผ่านเค้าโครงของมันได้:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **สิ่งที่มาสเตอร์สไลด์ประกอบด้วย**

มาสเตอร์สไลด์เป็นวัตถุที่คล้ายสไลด์ มัน implements [IBaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติของสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและสไลด์เค้าโครง

สมาชิกที่ใช้บ่อยของมาสเตอร์สไลด์รวมถึง:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `getBackground()` | ตั้งค่าพื้นหลังของสไลด์ระดับมาสเตอร์. |
| `getShapes()` | เก็บรูปทรงที่วางบนมาสเตอร์ เช่น โลโก้, กรอบภาพ, และข้อความที่ใช้ร่วมกัน. |
| `getLayoutSlides()` | เก็บสไลด์เค้าโครงที่เป็นของมาสเตอร์. |
| `getThemeManager()` | ให้การเข้าถึง API ธีมของมาสเตอร์. |
| `getHeaderFooterManager()` | ควบคุมหัวเรื่อง, ส่วนท้าย, วันที่, และหมายเลขสไลด์สำหรับมาสเตอร์และเค้าโครงลูกของมัน. |
| `getDependingSlides()` | คืนค่าสไลด์ปกติที่พึ่งพามาสเตอร์ผ่านเค้าโครงของพวกมัน. |

## **เพิ่มรูปภาพในมาสเตอร์สไลด์**

เมื่อคุณเพิ่มรูปภาพลงในมาสเตอร์สไลด์ รูปภาพจะปรากฏบนสไลด์ที่ใช้เค้าโครงจากมาสเตอร์นั้น ซึ่งมีประโยชน์สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพอื่น ๆ ที่ต้องการใช้ซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงในมาสเตอร์สไลด์แรก:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบภาพ ดูที่ [Picture Frame](/slides/th/androidjava/picture-frame/).

## **ควบคุมการแสดงผลของกราฟิกมาสเตอร์**

ใช้ [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) เพื่อซ่อนกราฟิกมาสเตอร์ที่สืบทอดมา เช่น โลโก้หรือรูปทรงตกแต่ง โดยไม่ต้องลบออกจากมาสเตอร์ ให้ส่งค่า `false` ไปยัง [Slide.setShowMasterShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) บนสไลด์ที่ต้องการไม่แสดงกราฟิกเหล่านั้นและเก็บค่า `true` บนสไลด์ที่ต้องการแสดง

ตัวอย่างที่เป็นอิสระต่อเนื่องต่อไปนี้สร้างแถบตกแต่งสีน้ำเงินบนมาสเตอร์และสองสไลด์ที่ใช้เค้าโครงเปล่าเดียวกัน แถบจะมองเห็นได้บนสไลด์แรกและซ่อนบนสไลด์ที่สอง ไม่จำเป็นต้องมีงานนำเสนอหรือรูปภาพเข้า.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตัวอย่างใช้เค้าโครง **Blank** ที่มาพร้อมกับงานนำเสนอใหม่และลบ placeholder ของสไลด์เริ่มต้นออก.

### **เลือกขอบเขตของการตั้งค่า**

สไลด์ปกติใช้มาสเตอร์ของมันผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getLayoutSlide--) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). การตั้งค่าคุณสมบัติบนสไลด์เดี่ยวจะส่งผลเฉพาะสไลด์นั้น การส่งค่า `false` ไปยัง [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) จะซ่อนกราฟิกมาสเตอร์สำหรับสไลด์ที่ใช้เค้าโครงที่แชร์ แม้การตั้งค่าของสไลด์นั้นจะเป็น `true` ก็ตาม หากต้องการซ่อนกราฟิกบนสไลด์เดียว ให้เปลี่ยนคุณสมบัติของสไลด์และไม่เปลี่ยนเค้าโครงที่แชร์

การตั้งค่านี้ไม่รองรับเป็นการควบคุมการมองเห็นบนมาสเตอร์สไลด์เอง บนมาสเตอร์, [getShowMasterShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) จะคืนค่า `false` เสมอและการส่งค่า `true` ไปยัง [setShowMasterShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) จะทำให้เกิดข้อยกเว้น ใช้บนสไลด์ปกติหรือเค้าโครงแทน

### **แยกกราฟิกออกจากพื้นหลัง**

| การดำเนินการ | ผลลัพธ์ |
| --- | --- |
| ซ่อนกราฟิกมาสเตอร์ | ควบคุมการมองเห็นของรูปทรงมาสเตอร์ที่สืบทอดโดยไม่ลบหรือเปลี่ยนแปลงรูปทรงของสไลด์เอง. |
| เปลี่ยนการเติมพื้นหลังของสไลด์ | เปลี่ยนสีพื้นหลัง, การไล่สี, หรือรูปภาพ พื้นหลังกราฟิกมาสเตอร์เป็นรูปทรงแยกต่างหากและสามารถมองเห็นอยู่เหนือพื้นหลังนั้น ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/). |
| ลบรูปทรงจากมาสเตอร์ | เอารูปทรงต้นแบบที่ใช้ร่วมกันออก ทำให้สไลด์ใด ๆ ที่ใช้มาสเตอร์นั้นไม่มีรูปทรงดังกล่าว. |

## **ทำงานกับ Placeholder**

Placeholder ปกติจะถูกกำหนดบนสไลด์เค้าโครง มาสเตอร์สไลด์ให้สไตล์และธีมที่ใช้ร่วมกันซึ่งเค้าโครงเหล่านั้นสืบทอด ในขณะที่แต่ละเค้าโครงตัดสินใจว่า placeholder ใดบ้างที่พร้อมใช้งานและวางตำแหน่งที่ไหน

ใน PowerPoint คำสั่ง placeholder มีให้ใช้ในมุมมอง Slide Master.

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ให้ทำงานกับสไลด์เค้าโครงที่เป็นของมาสเตอร์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่แล้วบนมาสเตอร์สไลด์ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใช้การเติมไลเนียร์ไล่สี:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder ของหัวเรื่องที่จัดรูปแบบแล้วที่สืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [Set Prompt Text in Placeholder](/slides/th/androidjava/manage-placeholder/) และ [Text Formatting](/slides/th/androidjava/text-formatting/).

## **เปลี่ยนพื้นหลังของมาสเตอร์สไลด์**

พื้นหลังของมาสเตอร์จะถูกสืบทอดโดยเค้าโครงและสไลด์ที่ไม่ทำการทับซ้อน ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับมาสเตอร์สไลด์แรก:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับหัวข้อที่เกี่ยวข้อง ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/) และ [Presentation Theme](/slides/th/androidjava/presentation-theme/).

## **คัดลอกมาสเตอร์สไลด์ไปยังงานนำเสนออื่น**

ใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) เพื่อคัดลอกมาสเตอร์สไลด์ไปยังงานนำเสนออื่น มาสเตอร์ที่คัดลอกแล้วสามารถใช้โดยเค้าโครงและสไลด์ในงานนำหมายปลายทาง.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

หากต้องการคัดลอกสไลด์ปกติพร้อมกับมาสเตอร์ของมัน ดูที่ [Clone Slides](/slides/th/androidjava/clone-slides/).

## **เพิ่มมาสเตอร์สไลด์หลายอัน**

งานนำเสนอสามารถมีมาสเตอร์สไลด์หลายอัน ซึ่งเป็นประโยชน์เมื่อแต่ละส่วนต้องการแบรนด์, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน.

![คำสั่ง PowerPoint สำหรับการแทรกและจัดการมาสเตอร์สไลด์](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอกมาสเตอร์เริ่มต้น, ตั้งค่าพื้นหลังที่แตกต่างให้กับสำเนา, สร้างเค้าโครงภายใต้มาสเตอร์ที่คัดลอก, และเพิ่มสไลด์ใหม่ที่อิงจากเค้าโครงนั้น:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เปรียบเทียบมาสเตอร์สไลด์**

มาสเตอร์สไลด์สามารถเปรียบเทียบด้วยเมธอด `equals` ที่สืบทอดจาก [IBaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/). การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่เช่นรูปทรง, ข้อความ, ฟอร์แมต, การเคลื่อนไหว, และการตั้งค่าอื่น ๆ ของสไลด์ ไม่ได้เปรียบเทียบตัวระบุเฉพาะเช่น slide ID หรือค่าของ placeholder แบบไดนามิก เช่น วันที่ปัจจุบัน.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

สำหรับข้อมูลเพิ่มเติม ดูที่ [Compare Presentation Slides](/slides/th/androidjava/compare-slides/).

## **ตั้งมุมมองมาสเตอร์สไลด์เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นครั้งแรก ตัวอย่างต่อไปนี้เปิดงานนำเสนอในมุมมอง Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [Save Presentation](/slides/th/androidjava/save-presentation/).

## **ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้**

บางครั้งงานนำเสนอมีมาสเตอร์สไลด์ที่ไม่ได้ใช้โดยสไลด์ปกติใด ๆ การลบมาสเตอร์ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การดูแลเทมเพลตง่ายขึ้น

ใช้ `removeUnused` เพื่อลบมาสเตอร์ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถใช้เมธอด low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างมาสเตอร์สไลด์และสไลด์เค้าโครงคืออะไร?**

มาสเตอร์สไลด์กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และสไตล์ข้อความ สไลด์เค้าโครงเป็นส่วนหนึ่งของมาสเตอร์สไลด์และกำหนดการจัดวางเฉพาะของ placeholder สไลด์ปกติใช้สไลด์เค้าโครง ดังนั้นจึงสืบทอดจากทั้งเค้าโครงและมาสเตอร์.

**งานนำเสนอหนึ่งสามารถมีมาสเตอร์สไลด์หลายอันได้หรือไม่?**

ได้ งานนำเสนอสามารถมีมาสเตอร์สไลด์หลายอันได้ ใช้หลายมาสเตอร์เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน.

**ควรเพิ่ม placeholder ไปยังมาสเตอร์สไลด์หรือสไลด์เค้าโครง?**

ในกรณีส่วนใหญ่ให้เพิ่ม placeholder ไปยังสไลด์เค้าโครง วางองค์ประกอบภาพที่ใช้ร่วมกันและฟอร์แมตที่ใช้ร่วมกันบนมาสเตอร์สไลด์ แล้วใส่ placeholder เนื้อหาในเค้าโครงที่สไลด์ปกติจะใช้.

**ฉันสามารถลบมาสเตอร์สไลด์ที่ยังถูกใช้ได้หรือไม่?**

ไม่ได้ มาสเตอร์สไลด์ที่มีสไลด์ที่พึ่งพาอยู่ไม่สามารถลบได้โดยตรง ต้องย้ายสไลด์เหล่านั้นไปยังเค้าโครงภายใต้มาสเตอร์อื่นก่อน หรือใช้วิธีทำความสะอาดมาสเตอร์ที่ไม่ได้ใช้ที่ลบเฉพาะมาสเตอร์ที่ไม่ได้ใช้.