---
title: จัดการไฮเปอร์ลิงก์การนำเสนอบน Android
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
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่ม จัดรูปแบบ อัปเดต และลบไฮเปอร์ลิงก์ในการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java โดยใช้ตัวอย่าง Java."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อสองวัตถุประสงค์:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ.
* ไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ.

Aspose.Slides for Android ผ่าน Java ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมการปรากฏและเสียง, อัปเดตคุณสมบัติต่าง ๆ, และลบออก ตัวอย่างต่อไปนี้แสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละอันและวิธีเข้าถึงไฮเปอร์ลิงก์ระดับการนำเสนอ, สไลด์, หรือกรอบข้อความ.

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขการนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/editor).
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ ส่วนที่คุณกำหนดไฮเปอร์ลิงก์จะกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์ข้อความที่เลือก, ส่วนของรูปหรือกรอบจะลิงก์วัตถุสไลด์.

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์ ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของส่วนข้อความตามตัวอย่างด้านล่าง ส่วนของข้อความนั้นเท่านั้นที่จะสามารถคลิกได้.

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

เพื่อทำให้รูปหรือกรอบสามารถคลิกได้ ให้เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของออบเจกต์นั้น ไฮเปอร์ลิงก์เป็นของออบเจกต์เองไม่ใช่ของส่วนข้อความภายใน

แนวทางเดียวกันใช้กับกรอบรูปภาพ, กรอบเสียง, และกรอบวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและเรียก [setTooltip](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมสามารถคลิกได้:

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

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง.

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

เมธอด [setColorSource](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) ของ [IHyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของการนำเสนอหรือการฟอร์แมตของส่วนข้อความ เพื่อใช้สีข้อความที่กำหนดเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วน วิธีนี้เริ่มต้นตั้งแต่ PowerPoint 2019; เวอร์ชันเก่าไม่รองรับการตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองอันลงในสไลด์เดียว อันแรกใช้สีเติมข้อความสีแดง ส่วนอันที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้วิธีต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [IHyperlink.setSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ควบคุมว่าการเปิดไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก คลิกปุ่มจะเล่นเสียงและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์นั้นคลิกจะหยุดเสียงก่อนหน้าโดยไม่ทำการนำทาง

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

#### **ดึงเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดการนำเสนอที่สร้างด้านบนและอ่านเสียงไฮเปอร์ลิงก์ของรูปแรกเข้าสู่หน่วยความจำด้วย [getSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#getSound--) และ [getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudio/#getBinaryData--)

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

### **คำแนะนำเครื่องมือและการตั้งค่าการโต้ตอบ**

คุณสามารถเรียกเมธอดของ [IHyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [setTooltip](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำของลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) ระบุกรอบเป้าหมายภายในเฟรมเซ็ต HTML ของพาเรนท์ หากมี
- [setHistory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางลงในรายการไฮเปอร์ลิงก์ที่ดูแล้วหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ควบคุมว่าลิงก์จะถูกไฮไลท์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์ออกจากการนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อเก็บคอนเทนเนอร์ไฮเปอร์ลิงก์รวมถึงลิงก์ส่วนข้อความ ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเพียงประเภทหนึ่ง ให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) ; การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สอดคล้องกัน

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

สำหรับการลบโดยไม่มีเงื่อนไข [removeAllHyperlinks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) จะลบทั้งสองการเปิดใช้งานในขอบเขตที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลเอาต์, และโน้ต ให้ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการไฮเปอร์ลิงก์ที่สมบูรณ์**

ก่อนกระจายการนำเสนอ ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) จะคืนค่าอ็อบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่ลิสต์แบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันอาจเปิดเผยทั้งสองการกระทำ ดังนั้นรายงานที่ครบถ้วนต้องใช้แถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สืบค้นขอบเขตที่เหมาะสมแทนและเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อให้คุณสามารถอัปเดตหรือเอาการกระทำออกในภายหลังได้

### **สอบถามขอบเขตการนำเสนอ, สไลด์, และกรอบข้อความ**

อินเตอร์เฟส [IHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/) มีให้ผ่าน [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). แต่ละขอบเขตสนับสนุนการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) คืนคอนเทนเนอร์ที่มีการคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) คืนคอนเทนเนอร์ที่มีการเมาส์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างต่อไปสร้าง `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เมาส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เมาส์โอเวอร์ข้อความ, และการกระทำแมโคร ไม่ได้เรียกใช้การกระทำใด ๆ คำสืบค้นสามแบบทำงานที่ทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำทั้งหมด ขอบเขตกรอบข้อความจะยกเว้นลิงก์ของรูปร่างที่ครอบมัน

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

สำหรับตัวอย่างนี้ การสืบค้นการนำเสนอและสไลด์แต่ละอันรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เมาส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำสามรายการ ขอบเขตกรอบข้อความรายงานคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จำแนกการกระทำและปลายทาง**

ใช้ [IHyperlink.getActionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#getActionType--) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่าใน [HyperlinkActionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน. |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางภายในสไลด์โชว์ที่มีอยู่แล้ว, แก้ไขในบริบทสไลด์โชว์. |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงสไลด์แบบกำหนดเอง. |
| `StartMacro` | เรียกใช้มาโคร. |
| `StartProgram` | เปิดโปรแกรม. |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ. |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ. |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักและต้องตรวจสอบ. |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) การกระทำภายในและคำสั่งที่มีมาในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวมคำแนะนำเครื่องมือที่คืนจาก [getTooltip](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) หากมี

### **รายงาน, ทำให้สะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Java ต่อไปอ่านการนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างด้านบน), เขียน `hyperlink-audit.json`, นำแนวนโยบายไปใช้, บันทึก `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบทั้งสองประเภทการเปิดใช้งานอีกครั้ง มันเก็บคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเทียบอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันสองครั้ง การสืบค้นการนำเสนอครอบคลุมสไลด์ทั่วไป; สำหรับการทำรายการระดับแพคเกจ จะสืบค้นมาสเตอร์, เลเอาต์, โน้ต, และมาสเตอร์ของโน้ตและแจกจ่ายเมื่อมี

รายงานบันทึกดัชนีสไลด์ตั้งแต่ 1 และ [getSlideId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) เมื่อมีให้ [ISlideComponent.getSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecomponent/#getSlide--) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่สนับสนุน มาสเตอร์, เลเอาต์, และโน้ตไม่มีดัชนีสไลด์ทั่วไปและระบุด้วยขอบเขตของมันเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์ฟอร์แมตส่วนข้อความแยกป้ายชื่อ; ประเภทคอนเทนเนอร์อื่นคงชื่อชนิดรันไทม์ของมัน แต่ละคอนเทนเนอร์จะได้รับ ID รายงานท้องถิ่นเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกัน รายงานจัดเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enum ของ Java

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบสัมบูรณ์และเป้าหมายสไลด์ภายในที่ถูกต้อง มันปฏิเสธมาโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสกีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจกับนโยบาย ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS อย่างเดียวไม่ถือเป็นความเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมทาดาต้าโดยไม่ตามลิงก์หรือรันการกระทำ

สำหรับการแก้ไข ปัญหา, คอนเทนเนอร์ของ [getHyperlinkManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) ในที่นี้ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; ลิงก์คลิกและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อให้ลบการละเมิดนโยบายทั้งหมด เลือกหน้าทดแทนอัตโนมัติที่เป็นของแอปก่อนการปรับใช้

ธงส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ เป็นเพียงคำแนะนำสำหรับการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับรองว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะยังคงอยู่ในการส่งออก การส่งออก PDF และ HTML ที่รองรับอาจยังคงไฮเปอร์ลิงก์ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ดูไฟล์ ภาพ [images](/slides/th/androidjava/convert-powerpoint-to-png/) และวิดีโอ [video](/slides/th/androidjava/convert-powerpoint-to-video/) แบบราสเตอร์ไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

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

    // แปลงแถวแบนของรายงานนี้เป็น JSON โดยไม่ต้องใช้ไลบรารี JSON เพิ่มเติม
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

ด้วยอินพุตที่สร้างด้านบน รายงานมีแถวการกระทำห้ารายการ ลิงก์เมาส์โอเวอร์ไฟล์และคลิกมาโครถูกลบ ส่วนลิงก์ HTTPSและการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์จำนวนการกระทำที่ไม่ได้รับอนุญาตเป็นศูนย์ อินพุตที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตจะทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตจะรักษาการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ซึ่งลบทั้งสองการกระทำในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ลบโครงการ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะเป้าหมายที่สไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลเอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลเอาต์ที่สัมพันธ์

**ไฮเปอร์ลิงก์จะถูกเก็บไว้เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้; รูปภาพแบบราสเตอร์และวิดีโอไม่สามารถทำได้ ดูข้อพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)