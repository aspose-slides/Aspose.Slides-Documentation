---
title: จัดการไฮเปอร์ลิงก์ของการนำเสนอใน Java
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์ภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Java พร้อมตัวอย่าง Java."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาในการนำเสนอกับเว็บไซต์หรือตำแหน่งภายในงานนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อสองวัตถุประสงค์หลัก:

* เปิดเว็บไซต์จากข้อความ รูปร่าง หรือเฟรมสื่อ
* นำทางไปยังสไลด์อื่น ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for Java ช่วยให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมลักษณะและเสียงของมัน อัปเดตคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละตัวและวิธีเข้าถึงไฮเปอร์ลิงก์ระดับงานนำเสนอ สไลด์ หรือเฟรมข้อความ

{{% alert color="info" title="Note" %}}
คุณสามารถแก้ไขงานนำเสนอด้วย [ฟรีออนไลน์ Aspose PowerPoint editor](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ รูปร่าง หรือเฟรมสื่อได้ ส่วนที่คุณกำหนดไฮเปอร์ลิงก์จะกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์เฉพาะข้อความที่เลือก ส่วนรูปร่างหรือเฟรมจะลิงก์กับวัตถุสไลด์

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อทำให้ข้อความเชื่อมต่อกับเว็บไซต์ ให้ส่ง [ไฮเปอร์ลิงก์](https://reference.aspose.com/slides/th/java/com.aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของส่วนข้อความตามตัวอย่างด้านล่าง ส่วนข้อความนั้นเท่านั้นที่จะคลิกได้

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

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างและเฟรมสื่อ**

เพื่อทำให้รูปร่างหรือเฟรมคลิกได้ ให้เรียกเมธodb [setHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของวัตถุนั้น ไฮเปอร์ลิงก์จะเป็นของวัตถุเอง ไม่ได้เป็นของส่วนข้อความภายใน

วิธีเดียวกันใช้ได้กับภาพ, เสียง, และวิดีโอเฟรม: กำหนดไฮเปอร์ลิงก์ให้กับเฟรมแล้วเรียก [setTooltip](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมคลิกได้:

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

## **ใช้ไฮเปอร์ลิงก์สร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setColorSource-int-) ของ [IHyperlink](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการฟอร์แมตของส่วนข้อความหรือไม่ เพื่อกำหนดสีข้อความเองให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เริ่มต้นตั้งแต่ PowerPoint 2019; เวอร์ชันเก่าจะไม่รองรับการตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองรายการบนสไลด์เดียว รายการแรกใช้สีเติมข้อความสีแดง ส่วนรายการที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

```java
import com.aspose.slides.*;
import java.awt.Color;

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ได้ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [IHyperlink.setSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) กำหนดว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าไหม

#### **เพิ่มเสียงให้กับไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิก โดยไม่ทำการนำทางใด ๆ

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปร่างแรกเข้าในหน่วยความจำโดยใช้ [getSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getSound--) และ [getBinaryData](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudio/#getBinaryData--)

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

### **เคล็ดลับและการตั้งค่าการโต้ตอบ**

คุณสามารถเรียกเมธอด [IHyperlink](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [setTooltip](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ตั้งข้อความที่ผู้ชมเห็นเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) ระบุเฟรมเป้าหมายในชุดเฟรม HTML ของพาเรนท์ (หากมี)
- [setHistory](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) กำหนดว่าการเปิดลิงก์จะบันทึกจุดหมายไว้ในประวัติการดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) กำหนดว่าลิงก์จะถูกไฮไลท์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์ไฮเปอร์ลิงก์ (รวมถึงลิงก์ส่วนข้อความ) ก่อนทำการเปลี่ยน แสดงตัวอย่างต่อไปจะลบประเภทการเปิดใช้งานทั้งสองจากสไลด์แรก หากต้องการลบประเภทเดียวให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) ; การลบการคลิกจะไม่ลบการโฮเวอร์

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

สำหรับการลบโดยไม่เลือก เฉพาะ [removeAllHyperlinks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) จะลบประเภทการเปิดใช้งานทั้งสองในขอบเขตที่เลือกในคำสั่งเดียว สำหรับการทำความสะอาดแบบเลือกเฉพาะและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบไฮเปอร์ลิงก์ครบถ้วน**

ก่อนแจกจ่ายงานนำเสนอ ควรทำรายการตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บทั้งหมด [getAnyHyperlinks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนค่าอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจเปิดใช้งานทั้งสอง ดังนั้นรายงานที่ครบต้องมีสูงสุดสองแถวต่อคอนเทนเนอร์

การตรวจสอบเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ควรสืบค้นตามขอบเขตที่เหมาะสมแทน และเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อที่จะแก้ไขหรือลบภายหลัง

### **สืบค้นขอบเขตงานนำเสนอ, สไลด์, และเฟรมข้อความ**

อินเตอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/) สามารถเข้าถึงได้ผ่าน [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). แต่ละขอบเขตสนับสนุนการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) คืนคอนเทนเนอร์ที่มีการคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) คืนคอนเทนเนอร์ที่มีการโฮเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งหรือทั้งสอง

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์โฮเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์โฮเวอร์ข้อความ, และการดำเนินการมาโคร ตัวอย่างไม่ได้เรียกใช้การกระทำใด ๆ คำสืบค้นสามแบบทำงานที่ทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ เฟรมข้อความจะยกเว้นลิงก์ของรูปร่างที่บรรจุเอง

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

สำหรับตัวอย่างนี้ คำสืบค้นระดับงานนำเสนอและสไลด์แต่ละรายการแสดงคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์โฮเวอร์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ ส่วนคำสืบค้นเฟรมข้อความแสดงคอนเทนเนอร์หนึ่งรายการในแต่ละหมวด

### **จำแนกประเภทการกระทำและจุดหมาย**

ใช้ [IHyperlink.getActionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getActionType--) เพื่อแปลความหมายการกระทำก่อนแปลความหมายของจุดหมาย ค่าของ [HyperlinkActionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่าที่เป็น | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ที่สร้างขึ้นมา, แก้ไขในบริบทของสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงสไลด์แบบกำหนดเอง |
| `StartMacro` | เรียกใช้มาโคร |
| `StartProgram` | เริ่มโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือเปิดงานนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักและต้องตรวจสอบ |

อ่านจุดหมายภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getExternalUrl--) และจุดหมายภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getTargetSlide--). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวมเคล็ดลับจาก [getTooltip](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlink/#getTooltip--) หากมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Java ต่อไปอ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น) เขียน `hyperlink-audit.json` ใช้นโยบาย ปิดไฟล์เป็น `hyperlink-sanitized.pptx` แล้วเปิดใหม่เพื่อตรวจสอบประเภทการเปิดใช้งานทั้งสองอีกครั้ง มันรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนและใช้การเทียบอัตลักษณ์เพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันสองครั้ง คำสืบค้นระดับงานนำเสนอครอบคลุมสไลด์ธรรมดา; สำหรับการตรวจสอบทั่วแพ็คเกจยังสืบค้นมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ต/แฮนด์เอาต์เมื่อมีอยู่

รายงานบันทึกดัชนีสไลด์ที่เริ่มจาก 1 และ [getSlideId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getSlideId--) หากมี [ISlideComponent.getSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะระบุตามขอบเขตของตนเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์ฟอร์แมตส่วนข้อความจะมีป้ายแยกต่างหาก; คอนเทนเนอร์ประเภทอื่นคงชื่อประเภทรันไทม์ของตน แต่ละคอนเทนเนอร์จะได้รับ ID รายงานภายในเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกัน รายงานเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มตามที่กำหนดใน enum ของ Java

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธมาโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ได้เป็นการตัดสินความปลอดภัยของ Aspose.Slides HTTPS อย่างเดียวไม่รับประกันความเชื่อถือ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมทาดาต้าโดยไม่ตามลิงก์หรือเรียกการกระทำ

สำหรับการปรับปรุง คอนเทนเนอร์ [getHyperlinkManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). ที่นี่ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; ลิงก์คลิกและโฮเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อเอาการละเมิดนโยบายทั้งหมดออกและเลือกหน้าแทนที่เป็นของแอปก่อนการใช้งาน

ค่าสถานะการส่งออกของรายงานใช้แนวทางการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำโฮเวอร์และทุกอย่างนอกจากลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นเพียงการชี้แนะเพื่อการตรวจสอบ ไม่ได้เป็นการทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ในการส่งออก PDF และ HTML ที่รองรับอาจรักษาไฮเปอร์ลิงก์ไว้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ชม ภาพเรสเตอร์ [images](/slides/th/java/convert-powerpoint-to-png/) และ [video](/slides/th/java/convert-powerpoint-to-video/) ไม่สามารถรักษาไฮเปอร์ลิงก์เชิงโต้ตอบได้; ควรทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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

    // แปลงแถวแบนของรายงานนี้เป็น JSON โดยไม่ต้องพึ่งพาไลบรารี JSON เพิ่มเติม
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

ด้วยอินพุตที่สร้างด้านบน รายงานมีแถวการกระทำห้ารายการ ลิงก์ไฟล์โฮเวอร์และคลิกมาโครถูกลบ ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์ศูนย์การกระทำที่ถูกห้าม อินพุตที่มี URL คลิกภายนอกที่ถูกห้ามก็จะทดสอบสาขาการแทนที่ด้วย คอนเทนเนอร์ที่มีคลิกที่อนุญาตและโฮเวอร์ที่ถูกห้ามจะรักษาการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ที่ลบการเปิดใช้งานทั้งสองในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเพียงการกระทำของไฮเปอร์ลิงก์เท่านั้น; ไม่ได้ลบโครงการ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จะจัดกลุ่มสไลด์ แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานในโหมดแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น

**ไฮเปอร์ลิงก์จะยังคงอยู่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ ส่วนภาพเรสเตอร์และวิดีโอไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบได้ ดูข้อมูลการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)