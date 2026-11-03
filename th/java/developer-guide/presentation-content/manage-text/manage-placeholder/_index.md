---
title: จัดการ Placeholder ของงานนำเสนอใน Java
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/java/manage-placeholder/
keywords:
- ตัวเก็บตำแหน่ง
- ตัวเก็บตำแหน่งข้อความ
- ตัวเก็บตำแหน่งรูปภาพ
- ตัวเก็บตำแหน่งแผนภูมิ
- ตัวเก็บตำแหน่งเนื้อหา
- ข้อความ Prompt
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ของข้อความ, รูปภาพ, แผนภูมิและเนื้อหา และทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Placeholder คือรูปร่างที่สงวนพื้นที่ไว้สำหรับชนิดเนื้อหาที่เฉพาะเจาะจงในแม่แบบการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อความ, รูปภาพ, แผนภูมิ และ placeholder เนื้อหาทั่วไปอื่น ๆ แตกต่างจากรูปร่างธรรมดา placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เลเอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) เมธอดจะคืนค่าอ็อบเจกต์ [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) หรือ `null` สำหรับรูปร่างปกติ ใช้ [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) เพื่อตรวจสอบว่า placeholder มีจุดมุ่งหมายเพื่อเก็บอะไร

อินเทอร์เฟซของรูปร่างยังคงสำคัญหลังจากคุณทราบประเภทของ placeholder:

- Placeholder ที่ว่างเปล่าสำหรับข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาทั่วไปมักจะแสดงเป็น [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)  
- Placeholder รูปภาพที่มีเนื้อหาแล้วอาจแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/)  
- Placeholder แผนภูมิที่มีเนื้อหาแล้วอาจแสดงเป็น [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/)  
- Placeholder เนื้อหาอาจมีหลายชนิดของเนื้อหา ตรวจสอบทั้ง [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) และอินเทอร์เฟซของรูปร่างในเวลา runtime แทนการสันนิษฐานว่า placeholder ทั้งหมดเป็น [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) บรรยายบทบาทของ placeholder; มันไม่ได้รับประกันประเภทของรูปร่างใน runtime. ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกที่เฉพาะสำหรับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่อ.
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีลำดับชั้นดังนี้:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่สามารถนำกลับมาใช้ได้และในบางกรณีกำหนด placeholder ระดับมาสเตอร์.  
2. สไลด์เลเอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์.  
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาต์ของมัน.

เรียก [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) เพื่อย้ายขึ้นหนึ่งระดับในลำดับชั้นนี้. placeholder ของสไลด์มักจะคืนค่า placeholder ของเลเอาต์; placeholder ของเลเอาต์อาจคืนค่า placeholder ของมาสเตอร์. เมธอดจะคืนค่า `null` เมื่อรูปร่างไม่มี base placeholder.

ตัวอย่างต่อไปจะแสดงรายชื่อ placeholder บนสไลด์แรกและรายงาน base placeholder ของพวกมัน:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่เฉพาะสไลด์นั้น. การแก้ไขเลเอาต์หรือมาสเตอร์ที่เกี่ยวข้องอาจมีผลกับสไลด์ทั้งหมดที่ยังสืบทอดการตั้งค่านั้น. รูปร่างปกติที่เป็นท้องถิ่นไม่มี base placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน.

## **ลบสถานะ Placeholder**

เมื่อปรับแต่งแม่แบบ ให้ใช้ [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) เพื่อทำให้วัตถุที่มีอยู่กลายเป็นรูปร่างปกติ. เมธอด [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) จะคืนค่า `null` แต่รูปร่างจะยังคงอยู่ในคอลเล็กชันของสไลด์. ในทางตรงข้าม [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) จะลบรูปร่างออกจากคอลเล็กชันนั้น.

ตัวอย่างต่อไปต้องการไฟล์ `template.pptx` ที่มีอย่างน้อยหนึ่งสไลด์และ placeholder ข้อความที่ไม่ว่างบนสไลด์แรก. ใช้ placeholder ที่สืบทอดการจัดรูปแบบจากเลเอาต์หรือมาสเตอร์เพื่อดูผลของการลบความสัมพันธ์นั้น. ตัวอย่างจะตรวจสอบว่ารูปร่างเดียวกันยังคงอยู่, เรียกเมธอดอีกครั้งบนรูปร่างที่กลายเป็นปกติ, แล้วบันทึกผลลัพธ์.

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้ทำให้การตั้งค่าการแสดงผลที่สืบทอดโดยอัตโนมัติคงอยู่. ตัวอย่างด้านล่างจึงตั้งค่าเหล่านั้นไว้อย่างไม่เปลี่ยนแปลง, ดังนั้นผลลัพธ์อาจดูแตกต่าง. รูปร่างที่ตำแหน่งและขนาดสืบทอดทั้งหมดอาจมีพิกัดและมิติศูนย์หลังการเรียกและกลายเป็นไม่มองเห็นแม้ว่าจะยังอยู่ในคอลเล็กชัน.
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

        // การเรียกเมธอดบนรูปร่างปกติไม่มีผลใด ๆ.
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

สำหรับ placeholder ที่ตรงกัน ทั้งสามการตรวจสอบจะพิมพ์ `true`. ข้อความจะคงอยู่, แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนต์, การจัดย่อหน้า, ระยะขอบของ text‑frame, การยึดแนวตั้ง, การเติมสีและการตั้งค่าเส้นอาจเปลี่ยนเมื่อความสัมพันธ์ของ placeholder ถูกลบ. ตัวอย่างเช่น การจัดรูปแบบหัวเรื่องที่สืบทอดอาจกลับไปใช้การจัดรูปแบบข้อความปกติ. ดูเพิ่มเติมใน [Slide Layout](/slides/th/java/slide-layout/) สำหรับข้อมูลเกี่ยวกับเลเอาต์.

เพื่อคงลักษณะที่ต้องการ ให้บันทึกตำแหน่ง, ขนาดและการหมุนที่ได้รับการคำนวณแล้วก่อนการเรียก, แล้วคัดลอกค่าการจัดรูปแบบที่มีผลจริงลงในตัวแปรแยกต่างหาก. ดึงค่าดังกล่าวผ่าน [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), และ [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). อย่าอาศัยแค่วัตถุ effective‑format เนื่องจากค่าการจัดรูปแบบข้อความอาจเปลี่ยนหลังจากความสัมพันธ์ถูกตัด. นำค่าที่บันทึกไว้ไปใช้กับรูปร่างปกติหลังจากนั้นอย่างชัดเจน, รวมถึงฟอนต์ (family, size, style, color), ตั้งค่าการจัดย่อหน้า, การตั้งค่า text‑frame, การเติมสีและเส้นที่ใช้ในแม่แบบของคุณ.

รูปร่างเรขาคณิตที่สืบทอดอาจต้องกำหนดโดยชัดเจนผ่าน [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). สำหรับ placeholder ข้อความแบบสี่เหลี่ยม ให้กำหนด [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); การคืนค่าเฉพาะการเติมสีและเส้นอาจไม่ทำให้สี่เหลี่ยมที่มองเห็นกลับมา. เทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือการจัดรูปแบบที่ซับซ้อนต้องจัดการการตั้งค่าเหล่านั้นเช่นกัน.

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, centered‑title, subtitle, body และข้อความมักสนับสนุนข้อความ. ตรวจสอบว่ารูปร่างเป็น [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

ตัวอย่างต่อไปอัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

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

รูปแบบนี้หลีกเลี่ยงการแคสท์ placeholder รูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็น [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). นอกจากนี้ยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปร่างที่เปราะบาง.

## **ตั้งค่าข้อความ Prompt บน Layout**

ข้อความ Prompt คือคำสั่งแบบออกแบบที่แสดงใน placeholder ว่าง เช่น *Click to add title*. ตั้งค่าข้อความ Prompt ที่กำหนดเองบน placeholder ของเลเอาต์แทนการพยายามเข้าถึงผ่านคอลเล็กชันรูปร่างของสไลด์ปกติ. เข้าถึงเลเอาต์ผ่าน [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) และวนลูปคอลเล็กชันที่คืนโดย [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

ตัวอย่างต่อไปเปลี่ยน Prompt ของหัวเรื่องและหัวเรื่องย่อยบนเลเอาต์ที่ใช้โดยสไลด์แรก:

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

Prompt ไม่ใช่เนื้อหาในสไลด์ปกติ. มันมีจุดประสงค์สำหรับ placeholder ว่างในแอปพลิเคชันแก้ไขเช่น PowerPoint. เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว Prompt จะไม่แสดงอีก. การเปลี่ยน Prompt ก็ไม่ได้แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลเอาต์นั้น.

## **อัปเดต Placeholder รูปภาพ**

มีสองกรณีที่ต้องจัดการ:

- หาก placeholder รูปภาพมีเนื้อหาแล้วและแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), ให้แทนที่รูปภาพผ่าน [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) และ [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).  
- หากยังเป็น placeholder ว่าง, ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) แล้วลบ placeholder ที่ว่างออก.

ตัวอย่างต่อไปรองรับทั้งสองกรณีและบันทึกการนำเสนอ:

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

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame เฉพาะท้องถิ่น, ไม่ได้เป็น placeholder ใหม่, เนื่องจาก [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ไม่มี setter. มันรักษาตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder อีกต่อไป. หากต้องการคงความสัมพันธ์ของ placeholder ไว้, ให้เตรียมและเติม placeholder ใน PowerPoint ก่อน, แล้วอัปเดต [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides.

สำหรับความโปร่งใสของภาพ, การครอปและเอฟเฟกต์อื่น ๆ ของรูปภาพ, ดูที่ [Manage Picture Frames](/slides/th/java/picture-frame/). การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill, ไม่ใช่ของเมตาดาต้า placeholder.

## **ทำงานกับ Placeholder แผนภูมิและเนื้อหา**

Placeholder แผนภูมิที่มีเนื้อหาแล้วอาจแสดงเป็น [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). ตัวอย่างนี้ค้นหาแผนภูมิที่ตรงตามประเภท placeholder และอินเทอร์เฟซ runtime, เปลี่ยนหัวเรื่อง, แล้วบันทึกไฟล์:

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

Placeholder เนื้อหาทั่วไปมักมี [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). ใน PowerPoint ทำหน้าที่เป็นตัวเปิดหลายประเภทของเนื้อหา, รวมถึงแผนภูมิ, ตาราง, ไดอาแกรม, รูปภาพ และสื่อ. หลังจากที่มันถูกเติมแล้ว, ตรวจสอบอินเทอร์เฟซของรูปร่างจริงเพื่อทราบว่ามีอะไรอยู่. เลเอาต์เฉพาะบางอย่างอาจเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Aspose.Slides ไม่ได้แปลง placeholder [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ที่ว่างให้เป็น [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) เพียงแค่เปลี่ยน [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/); ประเภทไม่สามารถเปลี่ยนผ่านอินเทอร์เฟซได้. เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาเปล่าโดยโปรแกรม, ให้เพิ่มอ็อบเจกต์ที่จำเป็นที่พิกัดของ placeholder แล้วลบ placeholder ว่างออก. ตัวอย่างต่อไปทำเช่นนั้นสำหรับแผนภูมิ:

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

แผนภูมิที่เพิ่มขึ้นเป็นแผนภูมิท้องถิ่นธรรมดา. มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาต์. ใช้บทความจัดการแผนภูมิที่เฉพาะเจาะจง [chart management articles](/slides/th/java/powerpoint-charts/) เมื่อคุณต้องการแทนที่ประเภท, ชุดข้อมูล หรือข้อมูลเวิร์กบุ๊กของแผนภูมิ.

## **ตัวอย่างครบถ้วน: อัปเดตข้อความหรือเนื้อหาภาพ**

ตัวอย่างต่อไปเป็นการทำขั้นตอนครบวงจร: เปิดแม่แบบ, ค้นหาสไลด์แรกเพื่อหา placeholder ที่เป็นหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปร่าง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์. ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปร่างหรือการแคสท์ทุก placeholder ไปยังอินเทอร์เฟซเดียวกัน.

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

## **FAQ**

**Placeholder ฐานคืออะไร?**

Placeholder ฐานคือรูปร่างที่สอดคล้องบนเลเอ็ตหรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจากมัน. ใช้ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) เพื่อดึงคืนค่า. รูปร่างท้องถิ่นปกติจะคืนค่า `null` เพราะไม่ได้เป็นส่วนหนึ่งของลำดับชั้น placeholder.

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข placeholder ของเลเอ็ตได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ Prompt ที่สืบทอดผ่านเลเอ็ตได้, แต่เนื้อหาหัวเรื่องที่มีอยู่จะถูกเก็บไว้บนสไลด์ปกติ. หากต้องการแทนที่ข้อความหัวเรื่องจริงทั่วทั้งงานนำเสนอ, ให้วนลูปสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง.

**ฉันจะจัดการ placeholder ของวัน/เวลา, หมายเลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในสโคปที่เหมาะสม (สไลด์, เลเอ็ต, มาสเตอร์, โน้ต หรือแฮนด์เอาต์). ดูที่ [Manage Presentation Header and Footer](/slides/th/java/presentation-header-and-footer/) สำหรับตัวอย่างสมบูรณ์.