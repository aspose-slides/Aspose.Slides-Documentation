---
title: จัดการ Slide Master ของการนำเสนอใน Java
linktitle: สไลด์มาสเตอร์
type: docs
weight: 70
url: /th/java/slide-master/
keywords:
- สไลด์มาสเตอร์
- มาสเตอร์สไลด์
- มาสเตอร์สไลด์ PPT
- หลายมาสเตอร์สไลด์
- เปรียบเทียบมาสเตอร์สไลด์
- พื้นหลัง
- ตัวอ้างอิง
- ทำสำเนามาสเตอร์สไลด์
- คัดลอกมาสเตอร์สไลด์
- ทำซ้ำมาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ Java: เข้าถึง, แก้ไข, ทำสำเนา, เปรียบเทียบ และลบมาสเตอร์สไลด์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

**Slide master** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ มันสามารถบรรจุรูปทรงทั่วไป โลโก้ พื้นหลัง รูปแบบข้อความ การตั้งค่าธีม และการตั้งค่าฝั่งล่าง ใน PowerPoint การแก้ไข slide master เป็นวิธีปกติในการทำให้การนำเสนอมีความสอดคล้องโดยไม่ต้องทำรูปแบบซ้ำในแต่ละสไลด์

Aspose.Slides for Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี slide master หนึ่งหรือหลายอัน และแต่ละ slide master สามารถมี layout slide หลายอัน สไลด์ปกติทั่วไปจะไม่อ้างอิง slide master โดยตรง แต่จะใช้ layout slide แทน และ layout slide นั้นเป็นส่วนหนึ่งของ slide master

ระดับโครงสร้างคือ:

1. **Slide master** – กำหนดการออกแบบและธีมที่ใช้ร่วมกัน  
1. **Layout slide** – กำหนดการจัดเรียงของ placeholder และการจัดรูปแบบระดับ layout  
1. **Normal slide** – บรรจุเนื้อหาการนำเสนอจริงและใช้ layout slide หนึ่งอัน

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

ใน Aspose.Slides slide master แทนด้วยอินเทอร์เฟซ [IMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) ทุก slide master ในการนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getMasters--) ซึ่งทำงานเป็น [IMasterSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/)

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเช่นเดียวกันถูกกำหนดที่หลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก slide master และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่อิงจาก layout นั้นจะใช้พื้นหลังของ layout ดูข้อมูลเพิ่มเติมเกี่ยวกับ layout slide ได้ที่ [Apply or Change Slide Layouts](/slides/th/java/slide-layout/)
{{% /alert %}}

## **เข้าถึง Slide Masters**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master ได้จาก **View** > **Slide Master**

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

ใน Aspose.Slides ให้ใช้คอลเลกชัน `getMasters()` เพื่อเข้าถึง slide master:

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

คุณยังสามารถรับ slide master ที่ใช้โดยสไลด์ปกติผ่าน layout ของมันได้:

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

## **เนื้อหาของ Slide Master**

master slide คือออบเจ็กต์ที่คล้ายสไลด์ มันทำงานตาม [IBaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติของสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout สมาชิกเฉพาะ master จะระบุในหน้า API ของ [IMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/)

สมาชิก master slide ที่ใช้บ่อย ได้แก่:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `getBackground()` | ตั้งค่าพื้นหลังของสไลด์ระดับ master |
| `getShapes()` | เก็บรูปทรงที่วางบน master เช่น โลโก้ กรอบรูป และข้อความที่ใช้ร่วมกัน |
| `getLayoutSlides()` | เก็บ layout slide ที่เป็นของ master |
| `getThemeManager()` | ให้เข้าถึง API ธีมของ master |
| `getHeaderFooterManager()` | ควบคุมหัวกระดาษ, ฝั่งล่าง, วันที่, และหมายเลขสไลด์สำหรับ master และ layout ลูก |
| `getDependingSlides()` | คืนค่าสไลด์ปกติที่พึ่งพา master ผ่าน layout ของมัน |

## **เพิ่มรูปภาพลงใน Slide Master**

เมื่อคุณเพิ่มรูปภาพลงใน master slide รูปภาพนั้นจะแสดงบนสไลด์ที่ใช้ layout จาก master นั้น ซึ่งเป็นประโยชน์สำหรับโลโก้, สัญลักษณ์น้ำ, แบนด์ตกแต่ง, และองค์ประกอบภาพที่ทำซ้ำอื่น ๆ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ไปยัง master slide แรก:

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ picture frame ดูที่ [Picture Frame](/slides/th/java/picture-frame/)

## **ควบคุมการมองเห็นของกราฟิก Master**

ใช้ [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) เพื่อซ่อนกราฟิก master ที่สืบทอดมา เช่น โลโก้หรือรูปทรงตกแต่ง โดยไม่ต้องลบออกจาก master ส่งค่า `false` ให้กับ [Slide.setShowMasterShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) ในสไลด์ที่ต้องการละเว้นกราฟิกเหล่านั้น และให้ค่า `true` ในสไลด์ที่ต้องการแสดงกราฟิก

ตัวอย่างต่อไปนี้สร้างแบนด์สีฟ้าตกแต่งบน master และสองสไลด์ที่ใช้ layout แบบเปล่า แบนด์จะแสดงบนสไลด์แรกและซ่อนบนสไลด์ที่สอง ไม่จำเป็นต้องมีการนำเข้าสไลด์หรือรูปภาพใด ๆ

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
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

ตัวอย่างใช้ layout **Blank** ที่มาพร้อมกับการสร้างการนำเสนอใหม่และลบ placeholder ของสไลด์เริ่มต้นออก

### **เลือกขอบเขตของการตั้งค่า**

สไลด์ปกติใช้ master ผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getLayoutSlide--) และ [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) การตั้งค่าคุณสมบัติบนสไลด์เดี่ยวจะส่งผลต่อสไลด์นั้นเท่านั้น การส่งค่า `false` ให้กับ [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) จะซ่อนกราฟิก master สำหรับสไลด์ที่ใช้ layout ร่วมกัน แม้ตั้งค่าของสไลด์นั้นจะเป็น `true` การซ่อนกราฟิกบนสไลด์เดียวให้เปลี่ยนคุณสมบัติของสไลด์นั้นและไม่แก้ไข layout ร่วม

การตั้งค่านี้ไม่รองรับการควบคุมการมองเห็นบน master slide เอง บน master, [getShowMasterShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterslide/#getShowMasterShapes--) จะคืนค่า `false` เสมอ และการส่งค่า `true` ให้กับ [setShowMasterShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) จะทำให้เกิดข้อยกเว้น ใช้บนสไลด์ปกติหรือ layout แทน

### **แยกกราฟิกจากพื้นหลัง**

| การดำเนินการ | ผลกระทบ |
| --- | --- |
| ซ่อนกราฟิก master | ควบคุมการมองเห็นของรูปทรง master ที่สืบทอดโดยไม่ลบหรือเปลี่ยนรูปทรงของสไลด์ |
| เปลี่ยนการเติมพื้นหลังสไลด์ | เปลี่ยนสี, ไอเดอล, หรือรูปภาพพื้นหลัง กราฟิก master เป็นรูปทรงแยกต่างหากและสามารถแสดงอยู่บนพื้นหลังนั้นได้ ดูที่ [Presentation Background](/slides/th/java/presentation-background/) |
| ลบรูปทรงจาก master | ลบรูปทรงต้นทางที่ใช้ร่วมกัน ทำให้ไม่สามารถใช้ได้กับสไลด์ใด ๆ ที่อิง master นั้น |

## **ทำงานกับ Placeholder**

Placeholder ปกติจะกำหนดบน layout slide master ให้สไตล์และธีมที่ใช้ร่วมกันที่ layout สืบทอดมา ในขณะที่แต่ละ layout จะตัดสินใจว่า placeholder ใดมีให้และวางไว้ที่ไหน

ใน PowerPoint คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

เพื่อเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ให้ทำงานกับ layout slide ที่เป็นของ master:

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

คุณยังสามารถกำหนดรูปแบบให้กับ placeholder ที่มีอยู่บน master slide ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใช้การเติมสีไลเนียร์กราเดียนท์:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [Set Prompt Text in Placeholder](/slides/th/java/manage-placeholder/) และ [Text Formatting](/slides/th/java/text-formatting/)

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลัง master จะสืบทอดไปยัง layout และสไลด์ที่ไม่ได้กำหนดทับ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับ master slide แรก:

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

หัวข้อที่เกี่ยวข้อง ดูที่ [Presentation Background](/slides/th/java/presentation-background/) และ [Presentation Theme](/slides/th/java/presentation-theme/)

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) เพื่อคัดลอก master slide ไปยังการนำเสนออื่น master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในการนำหมายถึงปลายทางได้

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

หากต้องการคัดลอกสไลด์ปกติกับ master ของมัน ให้ดูที่ [Clone Slides](/slides/th/java/clone-slides/)

## **เพิ่มหลาย Slide Masters**

การนำเสนอสามารถมีหลาย master slide ซึ่งมีประโยชน์เมื่อส่วนต่าง ๆ ต้องการแบรนด์, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น, ให้พื้นหลังแตกต่าง, สร้าง layout ภายใต้ master ที่คัดลอกนั้น, และเพิ่มสไลด์ใหม่ตาม layout นั้น:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **เปรียบเทียบ Slide Masters**

Slide master สามารถเปรียบเทียบด้วยเมธอด `equals` ที่สืบทอดจาก [IBaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปร่าง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุเฉพาะ เช่น slide ID หรือค่าตัวแปร placeholder แบบไดนามิก เช่น วันที่ปัจจุบัน

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

ดูข้อมูลเพิ่มเติมที่ [Compare Presentation Slides](/slides/th/java/compare-slides/)

## **ตั้งค่า Slide Master View เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดครั้งแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในโหมด Slide Master view:

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

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [Save Presentation](/slides/th/java/save-presentation/)

## **ลบ Master Slides ที่ไม่ได้ใช้**

บางครั้งการนำเสนออาจมี master slide ที่ไม่มีสไลด์ปกติใดใช้อยู่ การลบ master ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การบำรุงรักษาเทมเพลตง่ายขึ้น

ใช้ `removeUnused` เพื่อลบ master ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters()`:

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

คุณยังสามารถใช้เมธอด low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) ได้อีกด้วย:

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

**ความแตกต่างระหว่าง slide master กับ layout slide คืออะไร?**

slide master กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และรูปแบบข้อความ layout slide เป็นส่วนหนึ่งของ slide master และกำหนดการจัดเรียงเฉพาะของ placeholder สไลด์ปกติใช้ layout slide ดังนั้นจึงสืบทอดจากทั้ง layout และ master

**หนึ่งการนำเสนอสามารถมี slide master หลายอันได้หรือไม่?**

ได้ การนำเสนอสามารถบรรจุหลาย slide master ใช้หลาย master เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน

**ควรเพิ่ม placeholder ไปที่ master slide หรือ layout slide?**

โดยส่วนใหญ่ให้เพิ่ม placeholder ไปยัง layout slide ใส่องค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบน master slide แล้วใส่ placeholder เนื้อหาไว้บน layout ที่สไลด์ปกติจะใช้

**สามารถลบ slide master ที่ยังถูกใช้งานอยู่ได้หรือไม่?**

ไม่ได้ การลบ slide master ที่มีสไลด์ขึ้นอยู่จะไม่ปลอดภัย ต้องย้ายสไลด์เหล่านั้นไปยัง layout ภายใต้ master อื่นก่อน หรือใช้วิธีทำความสะอาด master ที่ไม่ได้ใช้ซึ่งลบเฉพาะ master ที่ไม่มีการอ้างอิง  