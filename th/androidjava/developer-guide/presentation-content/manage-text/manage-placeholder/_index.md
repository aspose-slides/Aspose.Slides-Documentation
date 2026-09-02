---
title: จัดการ Placeholder ของงานนำเสนอบน Android
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/androidjava/manage-placeholder/
keywords:
- ตัวแทนตำแหน่ง
- ตัวแทนตำแหน่งข้อความ
- ตัวแทนตำแหน่งรูปภาพ
- ตัวแทนตำแหน่งแผนภูมิ
- ตัวแทนตำแหน่งเนื้อหา
- ข้อความ Prompt
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไขตัวแทนตำแหน่งข้อความ, รูปภาพ, แผนภูมิ และเนื้อหา รวมถึงทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับเนื้อหาประเภทหนึ่งในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder เนื้อหาทั่วไป ไม่เหมือนรูปทรงทั่วไป Placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ, และการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านวิธีการ [IShape.getPlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) วิธีการนี้จะคืนค่าอ็อบเจ็กต์ [IPlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) หรือ `null` สำหรับรูปทรงทั่วไป ใช้ [IPlaceholder.getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) เพื่อตรวจสอบว่า placeholder มีวัตถุประสงค์จะบรรจุอะไร

รูปแบบของรูปทรงยังคงสำคัญหลังจากที่คุณทราบประเภทของ placeholder แล้ว:

- Placeholder ที่ว่างเปล่าสำหรับข้อความ, รูปภาพ, แผนภูมิ, หรือเนื้อหามักจะแทนด้วย [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)  
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแทนด้วย [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/)  
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแทนด้วย [IChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/)  
- Placeholder เนื้อหาอาจบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [IPlaceholder.getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) และอินเทอร์เฟซของรูปทรงในช่วงเวลารันไทม์ แทนที่จะสมมติว่า placeholder ทุกอันเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) ระบุบทบาทของ placeholder; แต่ไม่ได้รับประกันประเภทของรูปทรงในช่วงเวลารันไทม์ ควรตรวจสอบประเภทเสมอก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholders มีโครงสร้างเป็นลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และบางครั้งอาจมี placeholder ระดับมาสเตอร์
2. สไลด์เลย์เอาต์กำหนดการจัดเรียงที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์ได้
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ของมันได้

เรียกใช้ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อเลื่อนระดับหนึ่งขึ้นในลำดับขั้น สไลด์ placeholder โดยทั่วไปจะคืนค่า placeholder ของเลย์เอาต์; placeholder ของเลย์เอาต์อาจคืนค่า placeholder ของมาสเตอร์ วิธีการนี้จะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของพวกมัน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการทับซ้อนระดับท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลย์เอาต์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งค่านั้น รูปทรงธรรมดาท้องถิ่นที่ไม่มี base placeholder จะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, centered‑title, subtitle, body, และข้อความมักสนับสนุนข้อความ ตรวจสอบว่าเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)

ตัวอย่างนี้อัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปแบบนี้หลีกเลี่ยงการแคสต์ placeholder ที่เป็นรูปภาพ, แผนภูมิ, ตาราง หรือสื่อให้เป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนการอ้างอิงตามดัชนีรูปทรงที่เปราะบาง

## **ตั้งข้อความ Prompt บน Layout**

Prompt text คือคำแนะนำที่แสดงใน placeholder ที่ว่างเปล่าในระหว่างการออกแบบ เช่น *คลิกเพื่อเพิ่มหัวเรื่อง* ตั้งข้อความ Prompt ที่กำหนดเองบน placeholder ของเลย์เอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลย์เอาต์ผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) และวนลูปคอลเลกชันที่คืนโดย [ILayoutSlide.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/)

ตัวอย่างต่อไปนี้เปลี่ยน Prompt ของหัวเรื่องและหัวเรื่องย่อยบนเลย์เอาต์ที่ใช้โดยสไลด์แรก:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prompt text ไม่ใช่เนื้อหาสไลด์ปกติ มันมีไว้สำหรับ placeholder ที่ว่างเปล่าในเครื่องมือแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริง Prompt จะไม่แสดงอีกต่อไป การเปลี่ยน Prompt ยังไม่ได้แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลย์เอ็ตนั้น

## **อัปเดต Picture Placeholder**

มีสองกรณีที่ต้องจัดการ:

- หาก picture placeholder ถูกเติมแล้วและแทนด้วย [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) ให้แทนที่ภาพผ่าน [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) และ [ISlidesPicture.setImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/)
- หากยังเป็น placeholder ที่ว่างเปล่า ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) แล้วลบ placeholder ที่ว่างเปล่าออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกงานนำเสนอ:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การแทนที่ที่สร้างขึ้นสำหรับ placeholder ที่ว่างเปล่าเป็น picture frame ท้องถิ่น ไม่ใช่ placeholder ใหม่ เนื่องจาก [IShape.getPlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ไม่ได้มี setter มันยังคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder อีกต่อไป หากต้องการรักษาความสัมพันธ์ของ placeholder ควรเตรียมและเติม placeholder ใน PowerPoint ก่อน จากนั้นอัปเดต [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับการปรับความโปร่งใสของภาพ, การครอป, และเอฟเฟ็กต์เฉพาะของรูปภาพอื่น ๆ ดูที่ [Manage Picture Frames](/slides/th/androidjava/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่เมตาดาต้าของ placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder แผนภูมิที่เติมแล้วสามารถแทนด้วย [IChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/) ตัวอย่างนี้ค้นหาแผนภูมิที่เป็นเช่นนั้นโดยตรวจสอบทั้งประเภทของ placeholder และอินเทอร์เฟซรันไทม์, เปลี่ยนหัวเรื่องของมัน, และบันทึกไฟล์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Placeholder เนื้อหาทั่วไปมักมี [PlaceholderType.Object](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholdertype/) ใน PowerPoint ทำหน้าที่เป็นตัวเรียกใช้หลายประเภทของเนื้อหา รวมถึงแผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากถูกเติมแล้ว ให้ตรวจสอบอินเทอร์เฟซรูปทรงจริงเพื่อทราบว่ามีอะไรบ้าง เลเอาต์เฉพาะบางประเภทอาจเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholdertype/), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder ที่เป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ว่างเปล่าให้เป็น [IChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/) เพียงแค่เปลี่ยน [IPlaceholder.getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) ; ประเภทไม่สามารถเปลี่ยนได้ผ่านอินเทอร์เฟซ เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาว่างเปล่าโปรแกรมmatically ให้เพิ่มอ็อบเจ็กต์ที่จำเป็นที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่างเปล่าออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิท้องถิ่นทั่วไป มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลย์เอ็ต ใช้บทความการจัดการแผนภูมิที่เฉพาะเจาะจง [chart management articles](/slides/th/androidjava/powerpoint-charts/) เมื่อจำเป็นต้องแทนที่ประเภท, ชุดข้อมูล, หรือข้อมูลใน workbook

## **ตัวอย่างครบถ้วน: อัปเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างต่อไปนี้เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ที่เป็นหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, และบันทึกผลลัพธ์ ตัวอย่างนี้ตั้งใจหลีกเลี่ยงการสมมติว่ามีดัชนีรูปทรงหรือการแคสต์ placeholder ทุกอันเป็นอินเทอร์เฟซเดียวกัน

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Placeholder ฐานคืออะไร?**

Placeholder ฐานคือรูปทรงที่สอดคล้องบนเลย์เออตหรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดมาจากมัน ใช้ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อดึงค่า placeholder ฐาน รูปทรงท้องถิ่นธรรมดาจะคืนค่า `null` เนื่องจากไม่ได้เป็นส่วนหนึ่งของโครงสร้าง hierarchy ของ placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องของทุกสไลด์โดยแก้ไข placeholder ของเลย์เออตได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ Prompt ที่สืบทอดผ่านเลย์เออตได้ แต่เนื้อหาหัวเรื่องที่มีอยู่ถูกจัดเก็บบนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริงทั่วทั้งงานนำเสนอ ให้วนลูปผ่านสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจะจัดการ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในระดับสไลด์, เลย์เออต, มาสเตอร์, โน้ต, หรือเอกสารแจกจ่ายตามความต้องการ ดูที่ [Manage Presentation Header and Footer](/slides/th/androidjava/presentation-header-and-footer/) สำหรับตัวอย่างที่ครบถ้วน