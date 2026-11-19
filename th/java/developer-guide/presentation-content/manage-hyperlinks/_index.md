---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน Java
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
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดตและลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java โดยใช้ตัวอย่าง Java"
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมเนื้อหาการนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อวัตถุประสงค์สองอย่าง:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง หรือกรอบสื่อ.
* ไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ.

Aspose.Slides for Java ให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมลักษณะและเสียง ปรับปรุงคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบเดี่ยวและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับการนำเสนอ, สไลด์ หรือกรอบข้อความ.

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขการนำเสนอด้วย [ตัวแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง หรือกรอบสื่อได้ พื้นที่ที่คลิกได้ขึ้นกับองค์ประกอบที่กำหนดไฮเปอร์ลิงก์: ส่วนข้อความจะเชื่อมข้อความที่เลือก, ส่วนรูปร่างหรือกรอบจะเชื่อมวัตถุสไลด์ทั้งหมด.

สำหรับการนำเสนอที่มีไฮเปอร์ลิงก์แบบ relative, ดู [จัดการฐานไฮเปอร์ลิงก์](/slides/th/java/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน หรือเคลียร์ฐานระดับเอกสาร.

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

เพื่อเชื่อมข้อความไปยังเว็บไซต์ ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) ของส่วนข้อความตามที่แสดงด้านล่าง เฉพาะส่วนข้อความนั้นจะสามารถคลิกได้.

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

เรียกใช้ [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) บนสี่เหลี่ยมเพื่อทำให้พื้นที่ทั้งหมดของมันคลิกได้ ใช้ [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) เพื่อแสดงคําแนะนําเกี่ยวกับปลายทางเมื่อผู้ใช้วางเมาส์เหนือสี่เหลี่ยม วิธีทั้งสองนี้ยังใช้ได้กับกรอบรูปภาพ, เสียงและวิดีโอ.

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

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) เพื่อเชื่อมข้อความ “Page 2” ในสไลด์แรกไปยังสไลด์ที่สอง.

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

คุณสามารถเปลี่ยนสีของข้อความที่เชื่อม, เล่นหรือหยุดเสียงเมื่อผู้อ่านเปิดลิงก์, และตั้งค่าคําอธิบายที่ปรากฏเมื่อวางเมาส์.

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) ของ [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของการนำเสนอหรือรูปแบบของส่วนข้อความหรือไม่ เพื่อใช้สีข้อความที่กำหนดเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น คุณลักษณะนี้แนะนำใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ในตัวอย่างนี้, [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) ทำให้ลิงก์แรกใช้สีเติมสีแดงของส่วนข้อความ ส่วนลิงก์ที่สองคงสีไฮเปอร์ลิงก์ของการนำเสนอไว้.

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดหรือหยุดเสียงที่กำลังเล่นอยู่ได้ ใช้วิธีต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) ระบเสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ปุ่มบนสไลด์แรกใช้ [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) เพื่อเล่นไฟล์ `sampleaudio.wav` เมื่อผู้ใช้คลิกเพื่อเดินหน้า สไลด์ที่สองมีปุ่มแยกใช้ [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) เพื่อหยุดการเล่นและคงผู้ใช้บนสไลด์นั้น.

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

#### **ดึงเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้เปิดการนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปแรกเข้าสู่หน่วยความจำผ่าน [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) และ [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--).

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

### **คําอธิบายเครื่องมือและการตั้งค่าการโต้ตอบ**

คุณสามารถเรียกใช้เมธอดของ [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูป:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคําแนะนําให้กับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) ระบุกรอบเป้าหมายภายในชุดกรอบ HTML ของพาเรนท์ (ถ้ามี)
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) ควบคุมว่าการคลิกลิงก์จะเพิ่มปลายทางลงในรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ควบคุมว่าลิงก์จะถูกไฮไลต์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์จากการนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์รวมถึงลิงก์ส่วนข้อความ ก่อนทำการเปลี่ยน ตัวอย่างต่อไปนี้ลบการกระทำทั้งสองประเภทจากสไลด์แรก เพื่อเอาแค่หนึ่งประเภทให้เรียกใช้ [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) เท่านั้น; การลบการคลิกจะไม่ลบการวางเมาส์ที่สอดคล้องกัน.

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

สำหรับการลบอย่างไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) จะลบทั้งสองการกระทำในขอบเขตที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ให้ดูที่ [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks).

### **ล้างไฮเปอร์ลิงก์ก่อนแทนที่ข้อความ SmartArt**

เมื่อคุณแทนที่ย่อหน้าภายในโหนด SmartArt ที่มีอยู่ การล้างส่วนข้อความอาจทำให้ไฮเปอร์ลิงก์เก่ายังคงอยู่ เรียกย่อหน้าผ่าน [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getTextFrame--). ก่อนล้างส่วนข้อความ ให้เรียก [getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) บนกรอบข้อความของรูปโหนดที่แสดงย่อหน้า แล้วเรียก [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) บนออบเจ็กต์ที่คืนค่า วิธีนี้จะลบไฮเปอร์ลิงก์ทั้งหมดในกรอบนั้นรวมถึงลิงก์ในย่อหน้าอื่น ๆ

ตัวอย่างสันนิษฐานว่า รูปที่สามบนสไลด์แรกของ `SmartArtHyperlink.pptx` เป็นกราฟิก SmartArt มันแทนที่ย่อหน้าที่หนึ่งของโหนดที่สี่ ในการนำเสนอนี้ รูปแรกของโหนดแสดงย่อหน้านั้น

หลังจากเพิ่มทั้งสองส่วน ตัวอย่างอ่านการฟอร์แมตที่มีผลของพวกมันด้วย [getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--). บนการฟอร์แมตนั้น [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) คืนค่าไฮเปอร์ลิงก์ใหม่สำหรับส่วนแรกและ `null` สำหรับส่วนที่สอง.

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

## **สร้างรายการตรวจสอบไฮเปอร์ลิงก์แบบสมบูรณ์**

ก่อนแจกจ่ายการนำเสนอ ควรทำรายการตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนวัตถุ [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันสามารถเปิดเผยทั้งสองการกระทำได้ ดังนั้นรายงานเต็มต้องมีได้ถึงสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สืบค้นขอบเขตที่เหมาะแทนและเก็บคอนเทนเนอร์ที่คืนค่าเพื่อที่คุณจะอัปเดตหรือลบการกระทำภายหลังได้

### **สืบค้นการนำเสนอ, สไลด์, และขอบเขตกรอบข้อความ**

อินเตอร์เฟส [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) มีให้ผ่าน [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), และ [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). แต่ละขอบเขตรองรับการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) คืนคอนเทนเนอร์ที่มีการกระทำวางเมาส์
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) คืนคอนเทนเนอร์ที่มีอย่างหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างนี้กำหนดการกระทำคลิกและวางเมาส์ให้กับรูปร่างและข้อความของมัน, และการกระทำมาโครให้กับปุ่มแยก มันเปรียบเทียบจำนวนคอนเทนเนอร์ที่คืนค่าจาก [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) กับจำนวนของแต่ละประเภทการกระทำ การสืบค้นกรอบข้อความนับแค่ลิงก์ในข้อความ คอนเทนเนอร์ของรูปร่างที่ห่อหุ้มจะแสดงในผลการสืบค้นสไลด์และการนำเสนอ

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

สำหรับตัวอย่างนี้ การสืบค้นการนำเสนอและสไลด์แต่ละรายการรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์วางเมาส์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ ส่วนการสืบค้นกรอบข้อความรายงานหนึ่งคอนเทนเนอร์ในแต่ละประเภท

### **จัดประเภทการกระทำและปลายทาง**

ใช้ [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่าของ [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทการแสดงสไลด์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงสไลด์แบบกำหนดเอง |
| `StartMacro` | เรียกใช้มาโคร |
| `StartProgram` | เริ่มต้นโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; พิจารณาแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวมคําอธิบายที่คืนจาก [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) หากมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่างนี้เปิดการนำเสนอจากตัวอย่างก่อนหน้าและเขียนบันทึก JSON หนึ่งรายการต่อการกระทำ มันใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) เพื่อรวบรวมคอนเทนเนอร์บนสไลด์ทั่วไป, มาสเตอร์, เลย์เอาต์, และโน้ต รวมถึงมาสเตอร์โน้ตและมาสเตอร์แจกจ่ายเมื่อมีอยู่ มันใช้การเทียบค่าอ้างอิงเพื่อนับคอนเทนเนอร์แต่ละรายการหนึ่งครั้ง นำแนวทางนโยบายที่อธิบายไว้ด้านล่างไปใช้ แล้วเปิดการนำเสนอที่บันทึกใหม่เพื่อตรวจสอบการกระทำคลิกและวางเมาส์

รายงานบันทึกดัชนีสไลด์ที่เริ่มจากหนึ่งและ [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) เมื่อมี มันใช้ [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) เพื่อระบุสไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและระบุด้วยขอบเขตของตน คอนเทนเนอร์รูปและคอนเทนเนอร์ฟอร์แมตส่วนข้อความแยกกัน; ประเภทคอนเทนเนอร์อื่นคงชื่อประเภทขณะทำงาน รายการแต่ละรายการได้รับ ID ภายในรายงานเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกันได้ รายงานบันทึกประเภทการกระทำเป็นค่าคงที่จำนวนเต็มตามที่กำหนดใน enum ของ Java

นโยบายแอปพลิเคชันที่เข้มงวดนี้ยอมรับเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง มันปฏิเสธมาโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ได้เป็นการตัดสินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่รับประกันความเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ URL ภายนอกเดิมและที่ทำให้เป็นมาตรฐานทั้งสองถูกตรวจสอบ ตัวอย่างทำการตรวจสอบเมตาดาต้าโดยไม่ตามลิงก์หรือเรียกใช้การกระทำ

สำหรับการแก้ไข, คอนเทนเนอร์ของคุณที่ได้จาก [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). ที่นี่ ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้า Landing Page HTTPS คงที่; คลิกและการวางเมาส์ที่ห้ามอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบละเมิดนโยบายทั้งหมดแทน เลือกหน้าทดแทนที่เป็นของแอปก่อนการใช้งาน

ธงการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำวางเมาส์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นเพียงคำแนะนำการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ในการส่งออก PDF และ HTML ที่รองรับ ([PDF](/slides/th/java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/java/convert-powerpoint-to-html/)) อาจคงไฮเปอร์ลิงก์ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และตัวดูภาพ ส่วน [รูปภาพ](/slides/th/java/convert-powerpoint-to-png/) และ [วิดีโอ](/slides/th/java/convert-powerpoint-to-video/) ไม่สามารถคงไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

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

ด้วยข้อมูลที่สร้างข้างต้น รายงานมีแถวการกระทำห้ารายการ ลิงก์วางเมาส์ไฟล์และคลิกมาโครถูกลบ ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์ศูนย์การกระทำที่ห้าม ตัวอย่างที่มี URL คลิกภายนอกห้ามก็ทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่อนุญาตและวางเมาส์ที่ห้ามจะคงคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) ซึ่งลบทั้งสองการกระทำในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบการกระทำไฮเปอร์ลิงก์เท่านั้น; มันไม่ลบโปรเจคต์ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะเชื่อมโยงไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในชี้ไปยังสไลด์เดียว เพื่อสร้างการนำทางไปยังส่วน ให้เชื่อมไปยังสไลด์แรกของส่วนนั้น.

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบของมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะใช้ได้ระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น.

**ไฮเปอร์ลิงก์จะยังคงอยู่เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจคงไฮเปอร์ลิงก์; รูปภาพและวิดีโอแบบเรสเตอร์ไม่สามารถคงไฮเปอร์ลิงก์เชิงโต้ตอบได้ ดูข้อพิจารณาการส่งออกใน [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks).