---
title: จัดการ Hyperlink ของงานนำเสนอบน Android
linktitle: จัดการ Hyperlink
type: docs
weight: 20
url: /th/androidjava/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่ม Hyperlink
- สร้าง Hyperlink
- จัดรูปแบบ Hyperlink
- ลบ Hyperlink
- ปรับปรุง Hyperlink
- Hyperlink ข้อความ
- Hyperlink สไลด์
- Hyperlink รูปร่าง
- Hyperlink รูปภาพ
- Hyperlink วิดีโอ
- Hyperlink ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, ปรับปรุง และลบ Hyperlink ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java โดยใช้ตัวอย่าง Java."
---
## **บทนำ**

Hyperlink เชื่อมต่อเนื้อหาในงานนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในงานนำเสนอเอง ใน PowerPoint Hyperlink มักมีวัตถุประสงค์สองอย่าง:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ
* นำทางไปยังสไลด์อื่น, เช่น จากสารบัญ

Aspose.Slides for Android via Java ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, อัปเดตคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับ Hyperlink บนแต่ละองค์ประกอบและวิธีเข้าถึง Hyperlink ที่ระดับงานนำเสนอ, สไลด์, หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [ตัวแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **เพิ่ม Hyperlink URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ ส่วนที่คุณกำหนด Hyperlink จะเป็นพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์เฉพาะข้อความที่เลือก, ส่วนรูปร่างหรือกรอบจะลิงก์ออบเจกต์สไลด์ทั้งหมด

สำหรับงานนำเสนอที่มี Hyperlink แบบสัมพันธ์, ดูที่ [จัดการฐาน Hyperlink](/slides/th/androidjava/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน, หรือเคลียร์ฐานระดับเอกสาร

### **เพิ่ม Hyperlink URL ให้กับข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์ ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของส่วนข้อความตามตัวอย่างด้านล่าง เพียงส่วนของข้อความนั้นเท่านั้นที่จะคลิกได้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เพิ่ม Hyperlink URL ให้กับรูปร่างและกรอบสื่อ**

เรียก [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) บนสี่เหลี่ยมเพื่อให้ทั้งพื้นที่ของมันคลิกได้ ใช้ [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) เพื่อแสดงคำแนะนำให้ผู้อ่านเมื่อเมาส์อยู่เหนือสี่เหลี่ยม ทั้งสองเมธอดยังใช้ได้กับเฟรมรูปภาพ, เสียง, และวิดีโอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้ Hyperlink เพื่อสร้างสารบัญ**

Hyperlink ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รูปแบบ Hyperlink**

คุณสามารถเปลี่ยนสีของข้อความที่ลิงก์, เล่นหรือหยุดเสียงเมื่อผู้ใช้กดลิงก์, และตั้งค่า tooltip ที่แสดงเมื่อเมาส์อยู่เหนือ

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) ของ [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) กำหนดว่า Hyperlink จะใช้สี Hyperlink ของงานนำเสนอหรือสีการจัดรูปแบบของส่วนข้อความหรือไม่ หากต้องการกำหนดสีข้อความเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เริ่มต้นตั้งแต่ PowerPoint 2019; เวอร์ชันที่เก่ากว่าไม่รองรับการตั้งค่านี้

ในตัวอย่างนี้, [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) ทำให้ลิงก์แรกใช้สีเติมสีแดงของส่วนข้อความ ส่วนลิงก์ที่สองใช้สี Hyperlink ของงานนำเสนอ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เสียง**

Hyperlink สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) ระบุไฟล์เสียงที่เชื่อมกับ Hyperlink
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ควบคุมว่าการกด Hyperlink จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้ Hyperlink**

ปุ่มบนสไลด์แรกใช้ [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) เพื่อเล่นไฟล์ `sampleaudio.wav` เมื่อผู้ใช้คลิกเพื่อไปต่อ ส่วนบนสไลด์ที่สองปุ่มแยกต่างหากใช้ [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) เพื่อหยุดการเล่นและคงอยู่บนสไลด์นั้น

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **แยกเสียงจาก Hyperlink**

ตัวอย่างต่อไปนี้เปิดงานนำเสนอที่สร้างไว้ข้างบนและอ่านเสียง Hyperlink ของรูปร่างแรกเข้าสู่หน่วยความจำโดยใช้ [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) และ [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip และการตั้งค่าปฏิสัมพันธ์**

คุณสามารถเรียกเมธอดของ [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) ต่อไปนี้หลังจากกำหนด Hyperlink ให้กับข้อความหรือรูปร่าง:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ตั้งข้อความที่ผู้ดูสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) ระบุกรอบเป้าหมายภายในชุดกรอบ HTML หากมี
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) ควบคุมว่าการเปิดลิงก์จะบันทึกปลายทางไว้ในประวัติลิงก์ที่ดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ควบคุมว่าลิงก์จะถูกไฮไลท์เมื่อคลิกหรือไม่

## **ลบ Hyperlink จากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์ Hyperlink รวมถึงลิงก์ส่วนข้อความ ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบประเภทเดียวให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) การลบการคลิกจะไม่ลบการวางเมาส์

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) จะลบทั้งสองประเภทการเปิดใช้งานในสโคปที่เลือกในครั้งเดียว สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ดูที่ [รายงาน, ทำความสะอาด, และตรวจสอบ Hyperlink](#report-sanitize-and-verify-hyperlinks)

### **ล้าง Hyperlink ก่อนแทนที่ข้อความ SmartArt**

เมื่อคุณแทนที่ย่อหน้าภายในโหนด SmartArt ที่มีอยู่, การล้างส่วนข้อความอาจทำให้ Hyperlink เก่ายังคงอยู่ ดึงย่อหน้าผ่าน [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getTextFrame--) ก่อนลบส่วน ให้เรียก [getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) บนกรอบข้อความของรูปร่างโหนดที่แสดงย่อหน้านั้น แล้วเรียก [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) บนออบเจกต์ที่คืนค่า วิธีนี้จะลบ Hyperlink ทั้งหมดในกรอบนั้นรวมถึงลิงก์ในย่อหนูอื่น ๆ ด้วย

ตัวอย่างสมมติว่า formeที่สามบนสไลด์แรกของ `SmartArtHyperlink.pptx` เป็นกราฟิก SmartArt มันแทนที่ย่อหน้าที่หนึ่งของโหนดที่สี่ ในงานนำเสนอ, รูปแรกของโหนดจะแสดงย่อหน้านั้น

หลังจากเพิ่มทั้งสองส่วน, ตัวอย่างอ่านการจัดรูปแบบที่มีผลผ่าน [getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) บนการจัดรูปแบบนั้น, [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) จะคืน Hyperlink ใหม่สำหรับส่วนแรกและ `null` สำหรับส่วนที่สอง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(2);
    ISmartArtNode node = smartArt.getAllNodes().get_Item(3);
    IParagraph paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    IPortion link = new Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    IPortion text = new Portion(" (updated)");
    paragraph.getPortions().add(text);

    System.out.println(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    System.out.println(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **สร้างรายการตรวจสอบ Hyperlink ครบถ้วน**

ก่อนแจกจ่ายงานนำเสนอ, ควรตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บทั้งหมด [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) จะคืนออบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการ URL แบน ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจมีทั้งสองการกระทำ ดังนั้นรายงานครบถ้วนอาจต้องมีสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะ Hyperlink ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้ทำการคิวรีสโคปที่เหมาะแทน และเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่ออัปเดตหรือลบภายหลังได้

### **คิวรีสโคปของงานนำเสนอ, สไลด์, และกรอบข้อความ**

อินเทอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) สามารถเข้าถึงได้ผ่าน [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). แต่ละสโคปสนับสนุนคิวรีเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) คืนคอนเทนเนอร์ที่มีการกระทำเมาส์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างนี้กำหนดการกระทำคลิกและเมาส์โอเวอร์ให้กับรูปร่างและข้อความของมัน, และกำหนดการกระทำมาโครให้กับปุ่มแยกต่างหาก มันเปรียบเทียบจำนวนคอนเทนเนอร์ที่คืนมาจาก [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) กับจำนวนที่ได้จากแต่ละประเภทการกระทำ คำคิวรีกรอบข้อความนับเฉพาะลิงก์ในข้อความ คำกระทำของรูปร่างที่ห่อหุ้มปรากฏในคิวรีสไลด์และงานนำเสนอ

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับตัวอย่างนี้, คำคิวรีของงานนำเสนอและสไลด์แต่ละรายการแสดงคอนเทนเนอร์คลิก 3 รายการ, คอนเทนเนอร์เมาส์โอเวอร์ 2 รายการ, และคอนเทนเนอร์ที่มีการกระทำใด ๆ 3 รายการ. คำคิวรีกรอบข้อความแสดงคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จัดประเภทการกระทำและปลายทาง**

ใช้ [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่าใน [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่าที่กำหนด | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | Hyperlink ภายนอก; ตรวจสอบ URL และสกีมของมัน |
| `JumpSpecificSlide` | นำทางภายในไปยังสไลด์เฉพาะหนึ่งสไลด์ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์แบบในตัว, แก้ไขตามบริบทของการแสดงสไลด์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงสไลด์แบบกำหนดเอง |
| `StartMacro` | เรียกใช้มาโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือเปิดงานนำเสนออื่น; ควรตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักที่ต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม tooltip ที่คืนจาก [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) หากมี

### **รายงาน, ทำความสะอาด, และตรวจสอบ Hyperlink**

ตัวอย่างนี้เปิดงานนำเสนอจากตัวอย่างก่อนหน้าและเขียนบันทึก JSON หนึ่งรายการต่อการกระทำ ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์บนสไลด์ปกติ, มาสเตอร์, เลย์เอาต์, และโน้ต รวมถึงมาสเตอร์โน้ตและมือจับเมื่อมี ตัวอย่างใช้การตรวจสอบความเท่ากันของอ้างอิงเพื่อคัดลอกคอนเทนเนอร์หนึ่งครั้ง, ประยุกต์นโยบายที่อธิบายไว้ด้านล่าง, แล้วเปิดงานนำเสนอที่บันทึกใหม่เพื่อตรวจสอบการกระทำคลิกและเมาส์โอเวอร์

รายงานบันทึกดัชนีสไลด์แบบเลขฐานหนึ่งและ [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) เมื่อมีให้ [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) จะให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะระบุโดยสโคปของมันเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นเก็บชื่อชนิดรันไทม์ของมัน แต่ละคอนเทนเนอร์จะได้รับ ID รายงานภายในเพื่อให้การกระทำสองอย่างของมันเชื่อมโยงกัน รายงานบันทึกประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enumeration ของ Java

นโยบายแอปพลิเคชันนี้อนุญาตเฉพาะ URL HTTPS แบบสมบูรณ์และเป้าหมายสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธมาโคร, โปรแกรม, การทำงานไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสกีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ใช่คำตัดสินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่สร้างความเชื่อถือ: ให้เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือรันการกระทำ

สำหรับการแก้ไข, [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) ของคอนเทนเนอร์สนับสนุน [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) ที่นี่ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า HTTPS คงที่; คลิกภายนอกและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบทุกการละเมิดนโยบายแทน เลือกหน้าที่แทนที่เป็นของแอปก่อนการปรับใช้

แฟล็กการส่งออกของรายงานใช้แนวทางตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และสิ่งใดที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่สนับสนุน มันเป็นการบ่งชี้ให้ตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่มีแฟล็กจะคงอยู่ในการส่งออก การส่งออก PDF [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) และ HTML [HTML](/slides/th/androidjava/convert-powerpoint-to-html/) ที่สนับสนุนอาจคง Hyperlink ไว้ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ดู ภาพ [images](/slides/th/androidjava/convert-powerpoint-to-png/) และวิดีโอ [video](/slides/th/androidjava/convert-powerpoint-to-video/) ไม่สามารถคง Hyperlink เชิงโต้ตอบ; ทำเครื่องหมายการกระทำทั้งหมดเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // แปลงแถวแบนของรายงานนี้เป็น JSON โดยไม่ต้องพึ่งพาไลบรารี JSON เพิ่มเติม.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

ด้วยอินพุตที่สร้างข้างต้น, รายงานประกอบด้วยแถวการกระทำห้าแถว ลิงก์เมาส์โอเวอร์ไฟล์และคลิกมาโครถูกลบ, ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในคงไว้ ผลการตรวจสอบแสดงศูนย์การกระทำที่ไม่ได้รับอนุญาต อินพุตที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตยังทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่ได้รับอนุญาตและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตจะคงคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ที่ลบทั้งสองการกระทำในสโคปที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเพียงการกระทำ Hyperlink; ไม่ได้ลบโปรเจค VBA ฝัง, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ, และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนนั้นอย่างไร?**

ส่วนใน PowerPoint จะจัดกลุ่มสไลด์, แต่ Hyperlink ภายในจะชี้ไปยังสไลด์เดียวเท่านั้น เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบ Hyperlink ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์สนับสนุน Hyperlink ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้ระหว่างการนำเสนอในสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น

**Hyperlink จะถูกคงไว้เมื่อส่งออกเป็น PDF, HTML, ภาพ, หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่สนับสนุนอาจคง Hyperlink ไว้; ภาพเรสเตอร์และวิดีโอไม่สามารถคง Hyperlink เชิงโต้ตอบได้ ดูข้อพิจารณาการส่งออกใน [รายงาน, ทำความสะอาด, และตรวจสอบ Hyperlink](#report-sanitize-and-verify-hyperlinks).