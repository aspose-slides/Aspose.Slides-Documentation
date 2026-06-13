---
title: จัดการ Slide Masters ของการนำเสนอใน Android
linktitle: สไลด์มาสเตอร์
type: docs
weight: 70
url: /th/androidjava/slide-master/
keywords:
- สไลด์มาสเตอร์
- มาสเตอร์สไลด์
- มาสเตอร์สไลด์ PPT
- หลายมาสเตอร์สไลด์
- เปรียบเทียบมาสเตอร์สไลด์
- พื้นหลัง
- ตัวแทนตำแหน่ง
- คัดลอกมาสเตอร์สไลด์
- สำเนามาสเตอร์สไลด์
- ทำซ้ำมาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ Android ผ่าน Java: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบ, และลบมาสเตอร์สไลด์ในการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

A **slide master** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ มันอาจมีรูปทรงทั่วไป, โลโก้, พื้นหลัง, สไตล์ข้อความ, การตั้งค่าธีม, และการตั้งค่าข้อความท้ายสไลด์ ใน PowerPoint การแก้ไข slide master เป็นวิธีทั่วไปที่จะทำให้การนำเสนอคงความสม่ำเสมอโดยไม่ต้องทำรูปแบบเดียวกันซ้ำในทุกสไลด์

Aspose.Slides for Android via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี slide master หนึ่งหรือหลายหน้าตา และแต่ละ slide master สามารถมี layout slide หลายหน้า สไลด์ปกติส่วนใหญ่จะไม่อ้างอิง slide master โดยตรง แต่จะใช้ layout slide ซึ่ง layout slide นั้นเป็นส่วนหนึ่งของ slide master

โครงสร้างคือ:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน
1. **Layout slide** - กำหนดการจัดเรียงเฉพาะของ placeholder และรูปแบบระดับ layout
1. **Normal slide** - มีเนื้อหาในการนำเสนอจริงและใช้ layout slide หนึ่งหน้า

![โครงสร้างของ master slide, layout slide, และ normal slide](slide-master_2.jpg)

ใน Aspose.Slides, slide master แสดงด้วยอินเทอร์เฟซ [IMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) ทั้งหมดของ master slide ในการนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getMasters--) ซึ่งทำหน้าที่เป็น [IMasterSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/) สำหรับ API เต็มของ Android via Java, ดูที่ [com.aspose.slides API reference](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/)

{{% alert color="info" title="การสืบทอด" %}}

เมื่อคุณสมบัติเช่นเดียวกันถูกกำหนดในระดับมากกว่าหนึ่งระดับ ระดับที่ระบุเฉพาะมากกว่าจะชนะ ตัวอย่างเช่น หาก master slide และ layout slide ทั้งสองกำหนดพื้นหลัง, สไลด์ที่อ้างอิง layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slide, ดูที่ [Apply or Change Slide Layouts](/slides/th/androidjava/slide-layout/)

{{% /alert %}}

## **เข้าถึง Slide Masters**

ใน PowerPoint, คุณสามารถเปิดมุมมอง Slide Master ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides, ใช้คอลเลกชัน `getMasters()` เพื่อเข้าถึง master slide:

```java
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

คุณยังสามารถรับ master slide ที่ใช้โดยสไลด์ปกติผ่าน layout ของมันได้:

```java
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

master slide เป็นอ็อบเจกต์คล้ายสไลด์ มันทำงานตาม [IBaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout slide

สมาชิกของ master slide ที่ใช้บ่อยได้แก่:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `getBackground()` | ตั้งค่าพื้นหลังระดับ master |
| `getShapes()` | จัดเก็บรูปทรงที่วางบน master เช่น โลโก้, ฟรามภาพ, และข้อความที่ใช้ร่วมกัน |
| `getLayoutSlides()` | จัดเก็บ layout slide ที่เป็นของ master |
| `getThemeManager()` | ให้การเข้าถึง API ธีมของ master |
| `getHeaderFooterManager()` | ควบคุมหัวกระดาษ, ท้ายกระดาษ, วันที่, และหมายเลขสไลด์สำหรับ master และ layout ลูก |
| `getDependingSlides()` | คืนค่าสไลด์ปกติที่พึ่งพา master ผ่าน layout ของมัน |

## **เพิ่มรูปภาพไปยัง Slide Master**

เมื่อคุณเพิ่มรูปภาพไปยัง master slide, รูปนั้นจะแสดงในสไลด์ที่ใช้ layout จาก master นั้น ซึ่งเป็นประโยชน์สำหรับโลโก้, วอเตอร์มาร์ก, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องการใช้งานซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ไปยัง master slide แรก:

```java
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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟรามภาพ, ดูที่ [Picture Frame](/slides/th/androidjava/picture-frame/)

## **ทำงานกับ Placeholder**

Placeholder มักจะกำหนดบน layout slide master slide ให้สไตล์และธีมที่ใช้ร่วมกันซึ่ง layout สืบทอด, ส่วนแต่ละ layout จะตัดสินใจว่า placeholder ไหนพร้อมใช้งานและตำแหน่งใด

ใน PowerPoint, คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

การเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ทำได้โดยทำงานกับ layout slide ที่เป็นของ master:

```java
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

คุณยังสามารถจัดรูปแบบ placeholder ที่มีอยู่บน master slide ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใช้การเติมสีไล่ระดับเส้นตรง:

```java
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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

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

![Placeholder ของหัวเรื่องที่จัดรูปแบบแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม, ดูที่ [Set Prompt Text in Placeholder](/slides/th/androidjava/manage-placeholder/) และ [Text Formatting](/slides/th/androidjava/text-formatting/)

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลังของ master จะถูกสืบทอดโดย layout และสไลด์ที่ไม่ได้กำหนดทับ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับ master slide แรก:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับหัวข้อที่เกี่ยวข้อง, ดูที่ [Presentation Background](/slides/th/androidjava/presentation-background/) และ [Presentation Theme](/slides/th/androidjava/presentation-theme/)

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) เพื่อคัดลอก master slide ไปยังการนำเสนออื่น master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในการนำเสนอปลายทาง

```java
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

หากคุณต้องการคัดลอกสไลด์ปกติกับ master ของมันพร้อมกัน, ดูที่ [Clone Slides](/slides/th/androidjava/clone-slides/)

## **เพิ่มหลาย Slide Masters**

การนำเสนอสามารถมี master slide หลายหน้า ซึ่งมีประโยชน์เมื่อส่วนต่าง ๆ ต้องการแบรนด์, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการ master slide](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น, ให้พื้นหลังที่ต่างกัน, สร้าง layout ภายใต้ master ที่คัดลอกนั้น, และเพิ่มสไลด์ใหม่ที่อิงตาม layout นั้น:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

Master slide สามารถเปรียบเทียบได้ด้วยเมธอด `equals` ที่สืบทอดจาก [IBaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปทรง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุที่เป็นเอกลักษณ์ เช่น slide ID หรือค่าของ placeholder ที่เปลี่ยนแปลงเช่นวันที่ปัจจุบัน

```java
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

สำหรับข้อมูลเพิ่มเติม, ดูที่ [Compare Presentation Slides](/slides/th/androidjava/compare-slides/)

## **ตั้งค่า Slide Master View เป็นมุมมองค่าเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในมุมมอง Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม, ดูที่ [Save Presentation](/slides/th/androidjava/save-presentation/)

## **ลบ Master Slides ที่ไม่ได้ใช้**

บางครั้งการนำเสนออาจมี master slide ที่ไม่ได้ถูกสไลด์ปกติใด ๆ ใช้ การลบ master ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การดูแลเทมเพลตง่ายขึ้น

ใช้ `removeUnused` เพื่อลบ master ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters()`:

```java
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
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ความแตกต่างระหว่าง slide master และ layout slide คืออะไร?**

Slide master กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และสไตล์ข้อความ Layout slide เป็นส่วนหนึ่งของ slide master และกำหนดการจัดเรียงเฉพาะของ placeholder สไลด์ปกติใช้ layout slide ดังนั้นจึงสืบทอดจากทั้ง layout และ master

**การนำเสนอสามารถมี slide master ได้หลายอันหรือไม่?**

ได้ การนำเสนอสามารถมี slide master หลายอัน ใช้หลาย master เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน

**ควรเพิ่ม placeholder ไปที่ slide master หรือ layout slide?**

ส่วนใหญ่ควรเพิ่ม placeholder ไปที่ layout slide ใส่องค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบน slide master แล้วใส่ placeholder ของเนื้อหาบน layout ที่สไลด์ปกติจะใช้

**ฉันสามารถลบ slide master ที่ยังถูกใช้งานได้หรือไม่?**

ไม่ได้ slide master ที่มีสไลด์ dependent ไม่สามารถลบได้อย่างปลอดภัย ให้ย้ายสไลด์เหล่านั้นไปยัง layout ภายใต้ master อื่น หรือใช้วิธีทำความสะอาด master ที่ไม่ได้ใช้เพื่อลบเฉพาะ master ที่ไม่มีการอ้างอิง