---
title: จัดการตัวแทนตำแหน่งการนำเสนอบน Android
linktitle: จัดการตัวแทนตำแหน่ง
type: docs
weight: 10
url: /th/androidjava/manage-placeholder/
keywords:
- ตัวแทนตำแหน่ง
- ตัวแทนตำแหน่งข้อความ
- ตัวแทนตำแหน่งรูปภาพ
- ตัวแทนตำแหน่งแผนภูมิ
- ตัวแทนตำแหน่งเนื้อหา
- ข้อความแจ้งเตือน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไขตัวแทนตำแหน่งข้อความ, รูปภาพ, แผนภูมิ และเนื้อหา รวมถึงเข้าใจการสืบทอดตัวแทนตำแหน่งด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับเนื้อหาชนิดหนึ่งในเทมเพลตงานนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder ของหัวข้อ, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder เนื้อหาทั่วไป ต่างจากรูปทรงปกติ placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ และการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) เพื่อตรวจสอบ placeholder มีจุดประสงค์เพื่อเก็บอะไร

อินเทอร์เฟซของรูปทรงยังคงสำคัญหลังจากทราบประเภทของ placeholder:

- placeholder ของข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาที่ว่างเปล่ามักจะแสดงด้วย [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)  
- placeholder ของรูปภาพที่มีเนื้อหาแล้วสามารถแสดงด้วย [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)  
- placeholder ของแผนภูมิที่มีเนื้อหาแล้วสามารถแสดงด้วย [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/)  
- placeholder ของเนื้อหาอาจมีหลายประเภท ตรวจสอบทั้ง [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) และอินเทอร์เฟซของรูปทรงในช่วงเวลารันไทม์ แทนการสันนิษฐานว่า placeholder ทั้งหมดเป็น [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) บรรยายบทบาทของ placeholder; มันไม่ได้รับประกันประเภทของรูปทรงในช่วงเวลารันไทม์ ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกของข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder สร้างเป็นลำดับชั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และบางกรณีอาจมี placeholder ระดับมาสเตอร์
2. สไลด์เลย์เอาต์กำหนดการจัดเรียงที่ใช้โดยสไลด์ปกติเพิ่มเติมหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ของมัน

เรียกใช้ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) เพื่อย้ายขึ้นหนึ่งระดับในลำดับชั้นนี้ สไลด์ placeholder จะคืนค่า placeholder ของเลย์เอาต์; placeholder ของเลย์เอาต์อาจคืนค่า placeholder ของมาสเตอร์ เมธอดจะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder ในสไลด์แรกและรายงาน base placeholder ของแต่ละอัน:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่เฉพาะสำหรับสไลด์นั้น การแก้ไขเลย์เอาต์หรือมาสเตอร์ที่เกี่ยวข้องจะส่งผลต่อสไลด์ทั้งหมดที่ยังสืบทอดการตั้งค่านั้น รูปทรงปกติที่เป็นชั้นท้องถิ่นไม่มี base placeholder และไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อปรับแต่งเทมเพลต ให้ใช้เมธอด [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) เพื่อเก็บอ็อบเจ็กต์ที่มีอยู่เป็นรูปทรงปกติ เมธอด [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) จะคืนค่า `null` แต่รูปทรงยังคงอยู่ในคอลเลกชันของสไลด์ ในทางตรงกันข้ามเมธอด [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) จะลบรูปทรงออกจากคอลเลกชันนั้น

ตัวอย่างต่อไปนี้ต้องการไฟล์ `template.pptx` ที่มีอย่างน้อยหนึ่งสไลด์และ placeholder ข้อความที่ไม่ว่างเปล่าในสไลด์แรก ใช้ placeholder ที่สืบทอดการจัดรูปแบบจากเลย์เอาต์หรือมาสเตอร์เพื่อดูผลลัพธ์ของการลบความสัมพันธ์ ตัวอย่างจะตรวจสอบว่ารูปทรงเดียวกันยังคงอยู่, เรียกเมธอดอีกครั้งบนรูปทรงที่กลายเป็นธรรมดา, แล้วบันทึกผลลัพธ์

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้ทำให้การตั้งค่าการแสดงผลที่สืบทอดโดยอัตโนมัติ คอยตั้งค่าเหล่านั้นไว้ไม่เปลี่ยนแปลง ตัวอย่างด้านล่างจึงทิ้งการตั้งค่าเดิมไว้ ดังนั้นผลลัพธ์อาจดูแตกต่าง รูปทรงที่ตำแหน่งและขนาดสืบทอดทั้งหมดอาจเหลือค่าพิกัดและมิติเป็นศูนย์หลังการเรียกและกลายเป็นไม่มองเห็นได้ แม้ยังคงอยู่ในคอลเลกชัน
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // การเรียกเมธอดบนรูปทรงปกติไม่มีผล.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

สำหรับ placeholder ที่ตรงกัน การตรวจสอบทั้งสามอย่างจะพิมพ์ `true` ข้อความยังคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนต์, การจัดย่อหน้า, ระยะขอบของ text‑frame, การยึดแนวตั้ง, การเติม, และการกำหนดเส้นอาจเปลี่ยนเมื่อความสัมพันธ์ placeholder ถูกลบ ตัวอย่างเช่น การจัดรูปแบบหัวข้อที่สืบทอดอาจกลับไปใช้การจัดรูปแบบข้อความธรรมดา ดูเพิ่มเติมเกี่ยวกับเลย์เออต์ในบทความ [Slide Layout](/slides/th/androidjava/slide-layout/)

เพื่อคงลักษณะการแสดงที่ต้องการ ให้บันทึกตำแหน่ง, ขนาด, และการหมุนที่ได้คำนวนแล้วก่อนทำการลบ แล้วคัดลอกค่าการจัดรูปแบบที่มีผลจริงลงในตัวแปรแยกต่างหาก ดึงค่าดังกล่าวผ่านเมธอด [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), และ [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) อย่าพึ่งพาแค่วัตถุ effective‑format เนื่องจากค่าการจัดรูปแบบข้อความอาจเปลี่ยนหลังการลบ ให้นำค่าที่บันทึกไว้ไปใช้กับรูปทรงธรรมดาหลังจากนั้นอย่างชัดเจน รวมถึงฟอนต์, ขนาด, สไตล์, สี, การตั้งค่าข้อความ, การตั้งค่า text‑frame, การเติม, และเส้นที่เทมเพลตของคุณใช้

เรขาคณิตของรูปทรงที่สืบทอดอาจต้องกำหนดอย่างเจาะจงผ่านเมธอด [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) สำหรับ placeholder ของข้อความสี่เหลี่ยม จะต้องกำหนด [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle) การคืนค่าเพียงการเติมและเส้นอาจไม่ทำให้สี่เหลี่ยมมองเห็นได้ เทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือการจัดรูปแบบที่ซับซ้อนต้องจัดการตั้งค่าเหล่านั้นด้วย

## **เปลี่ยนข้อความใน Placeholder**

Placeholder ของหัวข้อ, centered‑title, subtitle, body, และข้อความทั่วไปมักรองรับข้อความ ตรวจสอบว่ารูปทรงเป็น [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ก่อนเรียกเมธอด [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)

ตัวอย่างต่อไปนี้อัปเดต placeholder ของหัวข้อแรกบนสไลด์แรกและบันทึกผลลัพธ์:

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

รูปแบบนี้หลีกเลี่ยงการแคสท์รูปภาพ, แผนภูมิ, ตาราง หรือ placeholder สื่ออื่นเป็น [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปทรงที่อ่อนแรง

## **กำหนด Prompt Text บน Layout**

Prompt text คือข้อความแนะนำในช่วงออกแบบที่แสดงใน placeholder ว่าง เช่น *Click to add title* ให้ตั้งค่า prompt text บน placeholder ของเลย์เอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลย์เอาต์ผ่านเมธอด [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) แล้ววนลูปคอลเลกชันที่คืนจาก [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/)

ตัวอย่างต่อไปนี้เปลี่ยน prompt ของหัวข้อและ subtitle บนเลย์เอาต์ที่ใช้โดยสไลด์แรก:

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

Prompt text ไม่ใช่เนื้อหาของสไลด์ปกติ ตั้งใจใช้กับ placeholder ว่างในแอปแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว prompt จะไม่แสดงอีกแล้ว การเปลี่ยน prompt ยังไม่ทับข้อความที่มีอยู่บนสไลด์ที่ใช้เลย์เอาต์นั้น

## **อัปเดต Placeholder ของรูปภาพ**

มีสองกรณีให้จัดการ:

- หาก placeholder ของรูปภาพมีเนื้อหาแล้วและแสดงด้วย [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) ให้แทนที่รูปภาพผ่าน [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) และ [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/)
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ผ่าน [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) แล้วลบ placeholder ว่างออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการนำเสนอ:

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

การแทนที่ที่สร้างสำหรับ placeholder ว่างจะเป็น picture frame ท้องถิ่น ไม่ได้เป็น placeholder ใหม่ เนื่องจาก [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ไม่มี setter มันจะรักษาตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากการรักษาความสัมพันธ์ของ placeholder มีความสำคัญ ควรเตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วอัปเดต [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของรูปภาพ, การครอป, และเอฟเฟกต์อื่น ๆ ของรูปภาพ ดูบทความ [Manage Picture Frames](/slides/th/androidjava/picture-frame/) การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill ไม่ใช่เมตาดาทาของ placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder ของแผนภูมิที่มีข้อมูลสามารถแสดงด้วย [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) ตัวอย่างนี้ค้นหาแผนภูมิดังกล่าวโดยดูทั้งประเภทของ placeholder และอินเทอร์เฟซรันไทม์, เปลี่ยนหัวเรื่อง, แล้วบันทึกไฟล์:

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

Content placeholder ทั่วไปมักมีค่า [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) ใน PowerPoint มันทำหน้าที่เป็นตัวเรียกหลายประเภทของเนื้อหา เช่น แผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากที่มีการเติมแล้ว ตรวจสอบอินเทอร์เฟซรูปทรงจริงเพื่อทราบว่ามีอะไรอยู่ Layout เฉพาะยังสามารถเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder ของ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ที่ว่างเป็น [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) เพียงโดยการเปลี่ยน [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) ; ประเภทไม่สามารถเปลี่ยนได้ผ่านอินเทอร์เฟซ เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาที่ว่างโดยโปรแกรม ให้เพิ่มอ็อบเจ็กต์ที่จำเป็นที่พิกัดของ placeholder แล้วลบ placeholder ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

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

แผนภูมิที่เพิ่มเข้ามาจะเป็นแผนภูมิท้องถิ่นทั่วไป จะครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลย์เอาต์ ใช้บทความ [chart management articles](/slides/th/androidjava/powerpoint-charts/) เมื่อคุณต้องการแทนที่กลุ่มข้อมูล, ซีรีส์, หรือข้อมูลเวิร์กบุ๊กของแผนภูมิ

## **ตัวอย่างสมบูรณ์: อัปเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างต่อไปนี้เป็นการทำงานตั้งแต่ต้นจนจบ: เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ที่เป็นหัวข้อหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปทรงหรือการแคสท์ placeholder ทุกอันให้เป็นอินเทอร์เฟซเดียวกัน

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

## **FAQ**

**Base placeholder คืออะไร?**

Base placeholder คือรูปทรงที่สอดคล้องบนเลย์เอ็ตหรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจากมัน ใช้เมธอด [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) เพื่อดึงค่า รูปทรงท้องถิ่นทั่วไปจะคืนค่า `null` เพราะไม่ได้เป็นส่วนหนึ่งของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวข้อทั้งหมดของสไลด์โดยแก้ไข layout placeholder ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือ prompt text ที่สืบทอดผ่านเลย์เออต์ได้ แต่เนื้อหาหัวข้อที่มีอยู่ถูกจัดเก็บบนสไลด์ปกติ เพื่อแทนที่ข้อความหัวข้อจริง ๆ ทั่วทั้งงานนำเสนอ ให้วนลูปสไลด์และอัปเดตแต่ละ placeholder ของหัวข้อ

**ฉันจะจัดการกับ placeholder ของวันที่, เลขสไลด์, ส่วนหัวและส่วนเท้าอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนเท้าที่สอดคล้องกับสไลด์, เลย์เออต์, มาสเตอร์, โน้ต, หรือ handout ดูบทความ [Manage Presentation Header and Footer](/slides/th/androidjava/presentation-header-and-footer/) เพื่อดูตัวอย่างที่สมบูรณ์