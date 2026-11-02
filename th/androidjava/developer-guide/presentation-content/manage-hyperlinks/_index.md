---
title: จัดการไฮเปอร์ลิงก์ของงานนำเสนอบน Android
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/androidjava/manage-hyperlinks/
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
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต, และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java โดยใช้ตัวอย่าง Java"
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือที่ตั้งภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อสองวัตถุประสงค์หลัก:

* เปิดเว็บไซต์จากข้อความ รูปร่าง หรือกรอบสื่อ
* นำทางไปยังสไลด์อื่น ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for Android via Java ให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมการแสดงผลและเสียง อัปเดตคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนแต่ละองค์ประกอบและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับงานนำเสนอ สไลด์ หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ รูปร่าง หรือกรอบสื่อได้ พื้นที่ที่คลิกได้ขึ้นอยู่กับองค์ประกอบที่กำหนดไฮเปอร์ลิงก์: ส่วนของข้อความจะลิงก์เฉพาะข้อความที่เลือก ส่วนรูปร่างหรือกรอบจะลิงก์วัตถุสไลด์

สำหรับงานนำเสนอที่มีไฮเปอร์ลิงก์แบบสัมพันธ์ ให้ดูที่ [จัดการฐานไฮเปอร์ลิงก์](/slides/th/androidjava/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน เปลี่ยน หรือเคลียร์ฐานระดับเอกสาร

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์ ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของส่วนข้อความตามตัวอย่างด้านล่าง ส่วนของข้อความนั้นจะกลายเป็นคลิกได้เท่านั้น

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

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปร่างและกรอบสื่อ**

เพื่อทำให้รูปร่างหรือกรอบคลิกได้ ให้เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของวัตถุ ไฮเปอร์ลิงก์จะเป็นของวัตถุนั้นเอง ไม่ใช่ของส่วนข้อความภายใน

แนวทางเดียวกันใช้กับกรอบรูป ภาพ เสียง และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบแล้วเรียก [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) หากต้องการ

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

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกกับสไลด์ที่สอง

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

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) ของ [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความ เพื่อใช้สีข้อความแบบกำหนดเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น คุณสมบัตินี้เริ่มใช้ตั้งแต่ PowerPoint 2019; เวอร์ชันเก่ากว่าจะไม่รองรับการตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองรายการในสไลด์เดียว รายการแรกใช้สีเติมข้อความสีแดง ส่วนรายการที่สองใช้สีไฮเปอร์ลิงก์ค่าเริ่มต้น

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อถูกเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) ระบุไฟล์เสียงที่เกี่ยวข้องกับไฮเปอร์ลิงก์
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำทางไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทาง

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

#### **สกัดเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านไฟล์เสียงไฮเปอร์ลิงก์ของรูปร่างแรกเข้าสู่หน่วยความจำโดยใช้ [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) และ [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--)

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

### **คำแนะนำเครื่องมือ (Tooltip) และการตั้งค่าการโต้ตอบ**

หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง คุณสามารถเรียกเมธอดของ [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) ต่อไปนี้ได้:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ตั้งข้อความที่ผู้ชมสามารถเห็นเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) ระบุกรอบเป้าหมายภายในชุดกรอบ HTML ของพาเรนท์ หากมี
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) ควบคุมว่าการเปิดลิงก์จะถูกบันทึกในประวัติลิงก์ที่ดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ควบคุมว่าฮีเปอร์ลิงก์จะถูกไฮไลท์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์ออกจากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์ รวมถึงลิงก์ส่วนข้อความ ก่อนทำการแก้ไข ตัวอย่างต่อไปลบการกระตุ้นทั้งสองประเภทจากสไลด์แรก หากต้องการลบแค่ประเภทหนึ่ง ให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) การลบการคลิกจะไม่ลบการเม้าส์โอเวอร์ที่สอดคล้องกัน

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

สำหรับการลบแบบไม่มีเงื่อนไข ให้ใช้ [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ซึ่งจะลบการกระตุ้นทั้งสองประเภทในขอบเขตที่เลือกด้วยคำสั่งเดียว สำหรับการทำความสะอาดอย่างเลือกสรรและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ให้ดูที่ [รายงาน ทำความสะอาด และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการไฮเปอร์ลิงก์ครบถ้วน**

ก่อนจัดจำหน่ายงานนำเสนอ ให้ทำรายการการกระทำเชิงโต้ตอบพร้อมลิงก์เว็บทั้งหมด [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) จะคืนค่าอ็อบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการ URL แบน ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) ของแต่ละคอนเทนเนอร์ ค่ะ ทั้งสองการกระทำอาจปรากฏในคอนเทนเนอร์เดียวกัน ดังนั้นรายงานที่ครบถ้วนอาจต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามขอบเขตที่เหมาะสมแทน และเก็บคอนเทนเนอร์ที่คืนกลับไว้เพื่อที่จะอัปเดตหรือเอาการกระทำออกในภายหลัง

### **สอบถามขอบเขตของงานนำเสนอ สไลด์ และกรอบข้อความ**

อินเทอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) สามารถเข้าถึงได้ผ่าน [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). แต่ละขอบเขตสนับสนุนการสอบถามเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) คืนคอนเทนเนอร์ที่มีการคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) คืนคอนเทนเนอร์ที่มีการเม้าส์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งหรือทั้งสอง

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เม้าส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เม้าส์โอเวอร์ข้อความ, และการกระทำแมโคร ตัวอย่างไม่ได้เรียกใช้การกระทำเหล่านั้น การสอบถามทั้งสามทำงานที่ทุกขอบเขต; จำนวนที่แสดงคือจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ ขอบเขตกรอบข้อความจะไม่รวมลิงก์ของรูปร่างที่ล้อมรอบ

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

สำหรับตัวอย่างนี้ งานสอบถามของงานนำเสนอและสไลด์แต่ละรายการคืนคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เม้าส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ ขอบเขตกรอบข้อความคืนคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จัดประเภทการกระทำและปลายทาง**

ใช้ [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทางค่า [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีม |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้แมโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทางหรือการกระทำที่ไม่รู้จัก, ต้องตรวจสอบต่อ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ปกติ และรวม tooltip จาก [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) หากมี

### **รายงาน ทำความสะอาด และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Java ด้านล่างอ่านงานนำเสนอที่สร้างไว้ข้างต้น, เขียนไฟล์ `hyperlink-audit.json`, ใช้นโยบาย, บันทึกเป็น `hyperlink-sanitized.pptx`, แล้วเปิดอีกครั้งเพื่อตรวจสอบการกระตุ้นทั้งสองประเภทอีกครั้ง จะรวบรวมคอนเทนเนอร์ก่อนแก้ไขและใช้การตรวจสอบอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวซ้ำ งานสอบถามของงานนำเสนอครอบคลุมสไลด์ธรรมดา; เพื่อทำรายการทั่วแพ็กเกจ ยังสอบถามมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ต/แฮนด์เอาท์เมื่อมี

รายงานบันทึกดัชนีสไลด์เริ่มจาก 1 และ [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) หากมี [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่สนับสนุน มาสเตอร์, เลย์เอาต์, โน้ตไม่มีดัชนีสไลด์ธรรมดาและจะแสดงตามขอบเขตของพวกมัน คอนเทนเนอร์ของรูปร่างและการจัดรูปแบบส่วนข้อความจะแยกแยะออก; ประเภทคอนเทนเนอร์อื่นคงชื่อประเภทเวลารัน แต่ละคอนเทนเนอร์จะมี ID ท้องถิ่นในรายงานเพื่อให้สามารถเชื่อมโยงการกระทำสองอย่างได้ ค่าในรายงานจะเป็นค่าคงที่จำนวนเต็มตามที่กำหนดใน enum ของ Java

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มที่และเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่รับประกันความเชื่อถือ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและปกติจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือรันการกระทำ

สำหรับการแก้ไข คอนเทนเนอร์ [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). ที่นี้ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; ลิงก์คลิกและเม้าส์โอเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบทั้งหมดที่ละเมิดนโยบาย เลือกหน้าทดแทนที่เป็นของแอปก่อนการปรับใช้

ธงการส่งออกของรายงานใช้โพลิซีการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเม้าส์โอเวอร์และสิ่งใด ๆ ยกเว้นลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นการให้คำแนะนำสำหรับการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ในการส่งออก PDF และ HTML ที่รองรับ ([PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/androidjava/convert-powerpoint-to-html/)) อาจเก็บไฮเปอร์ลิงก์ไว้ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และตัวดูภาพ ส่วน [images](/slides/th/androidjava/convert-powerpoint-to-png/) และ [video](/slides/th/androidjava/convert-powerpoint-to-video/) ไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบเพื่อวัตถุประสงค์เหล่านั้น

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

    // ซีเรียลไลซ์แถวแบนของรายงานนี้โดยไม่ต้องใช้ไลบรารี JSON เพิ่มเติม.
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

ด้วยข้อมูลที่สร้างข้างต้น รายงานมีแถวการกระทำห้าแถว ลิงก์เม้าส์โอเวอร์ไฟล์และแมโครที่คลิกถูกลบ ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบแสดงผลศูนย์การกระทำที่ไม่ได้รับอนุญาต ตัวอย่างที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตยังแสดงสาขาการแทนที่ด้วยคอนเทนเนอร์ที่คลิกได้และเม้าส์โอเวอร์ที่ไม่ได้รับอนุญาตจะเก็บการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ที่ลบการกระตุ้นทั้งสองประเภทในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบการกระทำของไฮเปอร์ลิงก์เท่านั้น; ไม่ได้ลบโครงการ VBA ฝัง, วัตถุ OLE, หรือคอนเทนต์ที่ทำงานอื่น ๆ และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะเชื่อมไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์ แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยวเพื่อทำการนำทางไปยังส่วน ให้เชื่อมไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกร่างสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้องกัน

**ไฮเปอร์ลิงก์จะยังคงอยู่เมื่อตีออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ได้ ส่วนภาพแบบแรสเตอร์และวิดีโอไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบได้ ดูข้อควรพิจารณาการส่งออกใน [รายงาน ทำความสะอาด และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)