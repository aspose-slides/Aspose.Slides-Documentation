---
title: จัดการ Placeholder ของการนำเสนอใน Java
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/java/manage-placeholder/
keywords:
- ตัวแทนตำแหน่ง
- ตัวแทนตำแหน่งข้อความ
- ตัวแทนตำแหน่งรูปภาพ
- ตัวแทนตำแหน่งแผนภูมิ
- ตัวแทนตำแหน่งเนื้อหา
- ข้อความแจ้งเตือน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ของข้อความ, รูปภาพ, แผนภูมิ, และเนื้อหา พร้อมทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับประเภทของเนื้อหาที่กำหนดในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder สำหรับเนื้อหาทั่วไป ต่างจากรูปทรงทั่วไป placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [IShape.getPlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [IPlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [IPlaceholder.getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/) เพื่อตรวจสอบว่า placeholder มีจุดประสงค์เพื่อบรรจุสิ่งใด

รูปแบบของรูปทรงยังคงสำคัญหลังจากคุณรู้ประเภทของ placeholder:

- Placeholder สำหรับข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาที่ว่างเปล่ามักจะแสดงเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/).
- Placeholder รูปภาพที่เติมข้อมูลแล้วสามารถแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/).
- Placeholder แผนภูมิที่เติมข้อมูลแล้วสามารถแสดงเป็น [IChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/).
- Placeholder เนื้อหาอาจบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [IPlaceholder.getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/) และอินเทอร์เฟซรูปทรงในช่วงเวลารันไทม์แทนการสันนิษฐานว่า placeholder ทั้งหมดเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/) บรรยายบทบาทของ placeholder; ไม่รับประกันประเภทของรูปทรงในช่วงเวลารันไทม์ ควรตรวจสอบประเภทเสมอก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่อ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder สร้างเป็นลำดับชั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และในบางกรณี placeholder ระดับมาสเตอร์
2. สไลด์เลย์เอาต์กำหนดการจัดเรียงที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์ และสามารถสืบทอดจากมาสเตอร์ได้
3. สไลด์ปกติมี placeholder สำหรับสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ของมัน

ใช้เมธอด [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เพื่อย้ายขึ้นหนึ่งระดับในลำดับชั้นนี้ โดยทั่วไป placeholder ของสไลด์จะคืนค่า placeholder ของเลย์เอาต์; placeholder ของเลย์เอาต์อาจคืนค่า placeholder ของมาสเตอร์ เมธอดนี้จะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่ในระดับท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลย์เอาต์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งค่านั้น รูปทรงปกติในระดับท้องถิ่นไม่มี base placeholder และไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, หัวเรื่องกึ่งกลาง, หัวเรื่องย่อย, เนื้อหา, และข้อความมักรองรับข้อความ ตรวจสอบว่าเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ของมัน

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

รูปแบบนี้หลีกเลี่ยงการแคสท์ placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/). นอกจากนี้ยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **ตั้งข้อความ Prompt บนเลย์เอาต์**

Prompt text คือคำแนะนำในช่วงออกแบบที่แสดงใน placeholder ที่ว่างเปล่า เช่น *Click to add title* ตั้งข้อความ prompt แบบกำหนดเองบน placeholder ของเลย์เอาต์แทนที่จะพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลย์เอาต์ผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) และทำการวนซ้ำคอลเลกชันที่ส่งกลับมาจาก [ILayoutSlide.getShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/)

ตัวอย่างต่อไปนี้เปลี่ยน prompt ของหัวเรื่องและหัวเรื่องย่อยบนเลย์เอาต์ที่ใช้โดยสไลด์แรก:

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

Prompt text ไม่ใช่เนื้อหาของสไลด์ปกติ มันมีไว้สำหรับ placeholder ที่ว่างเปล่าในแอปพลิเคชันแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว prompt จะไม่แสดงอีก การเปลี่ยน prompt ยังไม่ได้แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลย์เอาต์นั้น

## **อัปเดต Picture Placeholder**

There are two cases to handle:

- หาก picture placeholder ถูกเติมข้อมูลแล้วและแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/), ให้ทดแทนภาพผ่าน [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) และ [ISlidesPicture.setImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/).
- หากยังคงเป็น placeholder ที่ว่างเปล่า, ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) และลบ placeholder ที่ว่างเปล่าออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกงานนำเสนอ:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

การแทนที่ที่สร้างสำหรับ placeholder ที่ว่างเปล่าเป็น picture frame ในระดับท้องถิ่น, ไม่ใช่ placeholder ใหม่, เนื่องจาก [IShape.getPlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ไม่มี setter. มันจะคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder. หากต้องการรักษาความสัมพันธ์ของ placeholder ไว้, จำเป็นต้องเตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วจึงอัปเดต [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งแสงของภาพ, การครอบภาพ, และเอฟเฟกต์เฉพาะของรูปภาพอื่น ๆ ดูที่ [Manage Picture Frames](/slides/th/java/picture-frame/). การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill ไม่ใช่เมตาดาต้า placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder ของแผนภูมิที่เติมข้อมูลแล้วสามารถแสดงเป็น [IChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/). ตัวอย่างนี้ค้นหาแผนภูมินั้นโดยใช้ทั้งประเภท placeholder และอินเทอร์เฟซในช่วงเวลารันไทม์, เปลี่ยนหัวเรื่องของมันและบันทึกไฟล์:

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

Placeholder เนื้อหาทั่วไปมักมีค่า [PlaceholderType.Object](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholdertype/). ใน PowerPoint มันทำหน้าที่เป็นตัวเรียกหลายประเภทของเนื้อหา, รวมถึงแผนภูมิ, ตาราง, แผนผัง, รูปภาพ, และสื่อ. หลังจากที่ถูกเติมข้อมูลแล้ว, ให้ตรวจสอบอินเทอร์เฟซรูปทรงจริงเพื่อทราบว่ามีอะไรบ้าง. เลย์เอาต์พิเศษอาจเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholdertype/), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder ของ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ที่ว่างเปล่าเป็น [IChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/) เพียงแค่เปลี่ยน [IPlaceholder.getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/); ประเภทไม่สามารถเปลี่ยนได้ผ่านอินเทอร์เฟซ. เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาที่ว่างเปล่าโดยโปรแกรม, ให้เพิ่มอ็อบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่างเปล่าออก. ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

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

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิทั่วไปในระดับท้องถิ่น. มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลย์เอาต์. ใช้บทความการจัดการแผนภูมิที่เกี่ยวข้อง [chart management articles](/slides/th/java/powerpoint-charts/) เมื่อจำเป็นต้องแทนที่ประเภท, ชุดข้อมูล, หรือข้อมูลใน workbook ของมัน

## **ตัวอย่างสมบูรณ์: อัปเดตข้อความหรือเนื้อหาภาพ**

ตัวอย่างแบบ End-to-End ต่อไปนี้เปิดเทมเพลต, ค้นหาสไลด์แรกเพื่อหา placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, และบันทึกผลลัพธ์. ตัวอย่างนี้ตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปทรงหรือการแคสท์ทุก placeholder เป็นอินเทอร์เฟซเดียวกัน

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

**Base placeholder คืออะไร?**

Base placeholder คือรูปทรงที่สอดคล้องบนเลย์เอาต์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจาก ใช้ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เพื่อดึงคืน. ค่ารูปทรงท้องถิ่นทั่วไปจะคืนค่า `null` เนื่องจากไม่เป็นส่วนหนึ่งของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวข้อสไลด์ทั้งหมดโดยแก้ไข layout placeholder ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบที่สืบทอดหรือข้อความ prompt ผ่านเลย์เอาต์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่ถูกเก็บบนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริงทั่วงานนำเสนอ, ให้วนซ้ำสไลด์และอัปเดต placeholder ของหัวเรื่องแต่ละอัน

**ฉันจะจัดการ placeholder ของวันที่, เลขสไลด์, ส่วนหัว, และส่วนล่างอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนล่างในสไลด์, เลย์เอาต์, มาสเตอร์, โน้ต หรือ handout ที่เหมาะสม. ดูตัวอย่างเต็มที่ [Manage Presentation Header and Footer](/slides/th/java/presentation-header-and-footer/)