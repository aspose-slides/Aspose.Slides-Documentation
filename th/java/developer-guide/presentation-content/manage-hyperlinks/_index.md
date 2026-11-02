---
title: จัดการไฮเปอร์ลิงก์งานนำเสนอใน Java
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
- ไฮเปอร์ลิงก์รูปทรง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java โดยใช้ตัวอย่าง Java"
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาในงานนำเสนอกับเว็บไซต์หรือสถานที่ภายในงานนำเสนอเอง ใน PowerPoint ไฮเปอร์ลิงก์มักใช้สองวัตถุประสงค์หลัก:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือเฟรมสื่อ
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for Java ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, ปรับปรุงคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบเดี่ยว ๆ และวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับงานนำเสนอ, สไลด์, หรือ Text‑Frame

{{% alert color="info" title="Note" %}}

คุณสามารถแก้ไขงานนำเสนอด้วย[เครื่องมือแก้ไข PowerPoint ออนไลน์ของ Aspose ฟรี](https://products.aspose.app/slides/editor)。

{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือเฟรมสื่อ พื้นที่ที่คลิกได้กำหนดโดยองค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์: ส่วนของข้อความจะทำให้ข้อความที่เลือกคลิกได้, ในขณะที่รูปหรือเฟรมจะทำให้วัตถุสไลด์ทั้งหมดคลิกได้

สำหรับงานนำเสนอที่มีไฮเปอร์ลิงก์แบบสัมพันธ์, โปรดดู[จัดการ Hyperlink Base](/slides/th/java/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน, หรือเคลียร์ฐานระดับเอกสาร

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์ ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของส่วนข้อความตามตัวอย่างด้านล่าง เพียงส่วนของข้อความนั้นเท่านั้นที่จะคลิกได้

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

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปและเฟรมสื่อ**

เพื่อทำให้รูปหรือเฟรมคลิกได้ ให้เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของมัน ไฮเปอร์ลิงก์จะเป็นของวัตถุเอง ไม่ใช่ของส่วนข้อความภายใน

วิธีเดียวกันใช้กับเฟรมภาพ, เสียง, และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับเฟรมและเรียก [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) หากต้องการ

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

ไฮเปอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

เมธอด [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) ของ [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่ หากต้องการใช้สีข้อความที่กำหนดเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) และตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เปิดตัวใน PowerPoint 2019; เวอร์ชันก่อนหน้าไม่สนับสนุนการตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองรายการในสไลด์เดียว รายการแรกใช้สีเติมข้อความเป็นสีแดง, ส่วนรายการที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

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

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) กำหนดไฟล์เสียงที่ผูกกับไฮเปอร์ลิงก์
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้ไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` และผูกกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำทางไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทางใด ๆ

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

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างข้างต้นและอ่านเสียงของไฮเปอร์ลิงก์ในรูปแรกเข้าสู่หน่วยความจำโดยใช้ [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) และ [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--)

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

หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูป คุณสามารถเรียกเมธอดต่อไปนี้ของ [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) ได้:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) กำหนดข้อความที่ผู้ดูสามารถเห็นเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) ระบุเฟรมเป้าหมายภายใน HTML frameset ของพาเรนท์ เมื่อมีความเกี่ยวข้อง
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) ควบคุมว่าการเปิดลิงก์จะเพิ่มตำแหน่งปลายทางลงในรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) กำหนดว่าลิงก์จะไฮไลท์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์ออกจากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบการเปิดใช้งานทั้งสองประเภทจากสไลด์แรก หากต้องการลบประเภทใดประเภทหนึ่งเท่านั้น ให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) ; การลบการคลิกจะไม่ลบการเม้าส์โอเวอร์ที่สอดคล้องกัน

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

หากต้องการลบอย่างไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) จะลบทั้งสองการเปิดใช้งานในสโคปที่เลือกในครั้งเดียว สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ให้ดู[รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการไฮเปอร์ลิงก์ฉบับสมบูรณ์**

ก่อนกระจายงานนำเสนอให้ทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) จะคืนค่าอ็อบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันสามารถเปิดใช้งานทั้งสองการกระทำได้ ดังนั้นรายงานสมบูรณ์อาจต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้ทำการคิวรีในสโคปที่เหมาะสมแทนและเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อให้คุณสามารถอัปเดตหรือลบการกระทำของมันในภายหลังได้

### **คิวรีสโคป Presentation, Slide, และ Text‑Frame**

อินเตอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) สามารถเข้าถึงผ่าน [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). แต่ละสโคปรองรับคิวรีเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) คืนคอนเทนเนอร์ที่มีการกระทำเม้าส์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนคอนเทนเนอร์ที่มีการกระทำใด ๆ หรือทั้งสองอย่าง

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` ที่มีลิงก์คลิกภายนอก, ลิงก์เม้าส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เม้าส์โอเวอร์ข้อความ, และการกระทำแมโคร ตัวอย่างไม่ได้เรียกใช้การกระทำเหล่านั้น คิวรีทั้งสามทำงานในทุกสโคป; จำนวนที่คืนเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ ขอบเขต Text‑Frame ไม่รวมลิงก์ของรูปร่างที่หุ้มมัน

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

สำหรับตัวอย่างนี้ คิวรีระดับงานนำเสนอและสไลด์แต่ละอันรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เม้าส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีการกระทำใด ๆ หนึ่งรายการ คิวรีระดับ Text‑Frame รายงานหนึ่งคอนเทนเนอร์ในแต่ละประเภท

### **จำแนกประเภทการกระทำและปลายทาง**

ใช้ [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) เพื่อแปลประเภทการกระทำก่อนแปลปลายทาง [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) มีค่าดังต่อไปนี้ซึ่งครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน |
| `JumpSpecificSlide` | นำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางอเนกประสงค์ในโหมดสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้แมโคร |
| `StartProgram` | เริ่มโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือไฟล์งานนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทางหรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม Tooltip ที่คืนจาก [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) เมื่อมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Java ต่อไปอ่านงานนำเสนอที่สร้างข้างต้น, เขียนไฟล์ `hyperlink-audit.json`, ใช้นโยบาย, บันทึกเป็น `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบการกระทำทั้งสองประเภทอีกครั้ง ตัวอย่างรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การตรวจเทียบอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันซ้ำ คิวรีงานนำเสนอครอบคลุมสไลด์ปกติ; สำหรับการสำรวจระดับแพ็กเกจ ตัวอย่างยังคิวรีมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ตและแฮนด์เอาท์เมื่อมี

รายงานบันทึกดัชนีสไลด์ (เริ่มที่ 1) และ [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) เมื่อพร้อมใช้งาน [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะแทนที่ด้วยสโคปของมัน คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะถูกระบุแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์ของมัน แต่ละคอนเทนเนอร์จะมี ID ในรายงานเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกันได้ รายงานเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enum ของ Java

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบสมบูรณ์และเป้าหมายสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจตามนโยบาย ไม่ได้เป็นการตัดสินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่รับประกันความเชื่อถือ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาเดต้าต่างไม่ตามลิงก์หรือดำเนินการใด ๆ

สำหรับการแก้ไข, เมธอด [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) ของคอนเทนเนอร์สนับสนุน [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) ในที่นี้ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า HTTPS คงที่; ลิงก์คลิกและเม้าส์โอเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบการละเมิดนโยบายทั้งหมด เลือกหน้าทดแทนที่เป็นของแอปก่อนการปรับใช้

แฟล็กการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF ที่ระมัดระวัง: ทำแฟล็กการกระทำเม้าส์โอเวอร์และทุกสิ่งที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นคำแนะนำการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ทำแฟล็กจะคงอยู่ในการส่งออก การส่งออก PDF และ HTML ที่รองรับ ([PDF](/slides/th/java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/java/convert-powerpoint-to-html/)) อาจคงไฮเปอร์ลิงก์ได้ ขึ้นกับการกระทำ, ตัวเลือกการส่งออก, และผู้ชม ภาพ raster ([images](/slides/th/java/convert-powerpoint-to-png/)) และวิดีโอ ([video](/slides/th/java/convert-powerpoint-to-video/)) ไม่สามารถคงไฮเปอร์ลิงก์เชิงโต้ตอบ; ควรทำแฟล็กทุกการกระทำเมื่อตรวจสอบเพื่อการส่งออกเหล่านั้น

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

    // ทำให้แถวแบนของรายงานนี้เป็น JSON โดยไม่มีการพึ่งพาไลบรารี JSON เพิ่มเติม
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

ด้วยอินพุตที่สร้างข้างต้น รายงานมีห้ารายการการกระทำ ลิงก์เม้าส์โอเวอร์ไฟล์และแมโครคลิกถูกลบ, ในขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์ศูนย์การกระทำที่ผิดกฎ อินพุตที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตก็แสดงสาขาการแทนที่ คอนเทนเนอร์ที่มีคลิกที่ได้รับอนุญาตและเม้าส์โอเวอร์ที่ไม่ได้รับอนุญาตจะเก็บการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ซึ่งลบการกระทำทั้งสองประเภทในสโคปที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเพียงการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบ VBA project ที่ฝังอยู่, อ็อบเจกต์ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะเชื่อมลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์บุคคลหนึ่ง เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้ในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจคงไฮเปอร์ลิงก์ไว้; ภาพ raster และวิดีโอไม่สามารถคงไฮเปอร์ลิงก์เชิงโต้ตอบได้ ดูรายละเอียดการส่งออกใน[รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)。