---
title: ดึงข้อมูลและอัปเดตข้อมูลการนำเสนอใน Java
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/java/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น"
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านข้อมูลเมตาดาต้าเอกสารได้โดยไม่ต้องสร้างวัตถุโมเดลของงานนำเสนอที่สมบูรณ์ ซึ่งเป็นประโยชน์เมื่อต้องการจัดประเภทไฟล์ สร้างคลังข้อมูล หรือสอบสวนคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาของงานนำเสนอหรือไม่

บทความนี้แสดงการตรวจสอบแบบเบาที่ใช้ผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/), พร้อมทั้งการอัปเดตแบบเจาะจงผ่าน [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/).

## **ตรวจสอบรูปแบบงานนำเสนอ**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) วิธี [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **สร้างคลังงานนำเสนอแบบเบา**

เมื่อคุณประมวลผลไฟล์งานนำเสนอหลายไฟล์ อาจต้องการคลังข้อมูลที่กะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในสถานการณ์นี้ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับวัตถุ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/) จากนั้นเรียก [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาดาต้าเอกสาร วิธีการนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) หรือจำเป็นต้องเดินผ่านโมเดลวัตถุของงานนำเสนอทั้งหมด

คุณสมบัติเพิ่มเติมที่เปิดโดย [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/) ให้ค่าคลังต่อไปนี้:

| เมธอด | ค่าคลัง |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getSlides--) | จำนวนสไลด์ทั้งหมด |
| [getHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | จำนวนสไลด์ที่ซ่อนไว้ |
| [getNotes](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getNotes--) | จำนวนสไลด์ที่มีบันทึกหมายเหตุ |
| [getParagraphs](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | จำนวนย่อหน้าทั้งหมด (หากมี) |
| [getWords](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getWords--) | จำนวนคำทั้งหมด |
| [getMultimediaClips](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วพิมพ์คลังข้อมูลแบบกะทัดรัด นอกจากนี้ยังรวม [getHeadingPairs](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) กับ [getTitlesOfParts](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) เพื่อแสดงกลุ่มเนื้อหาเช่น ฟอนต์, ธีม, และหัวข้อสไลด์

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

แต่ละ [IHeadingPair](https://reference.aspose.com/slides/th/java/com.aspose.slides/iheadingpair/) จะจัดให้มีชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) จะส่งคืนอาร์เรย์แบนที่เรียงลำดับไว้ ดังนั้นจึงต้องใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละ heading pair ระบุ

### **เมตาดาต้าที่เก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติคลังที่คืนโดย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) สะท้อนเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเดินผ่านโมเดลวัตถุของงานนำมาเพื่อคำนวณค่าต่าง ๆ อีกครั้งสำหรับการเรียกนี้ คุณสมบัติที่หายไปจะแสดงเป็นค่าเริ่มต้น และค่าที่เก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติของเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมสำหรับจำนวนสไลด์, หมายเหตุ, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และสื่อมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้ขึ้นอยู่กับว่าผู้ผลิตเอกสารเขียนคุณสมบัติใดบ้าง
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปของเอกสารที่สอดคล้องกันได้ หากคุณสมบัตหายไปหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าเก็บไว้หรือค่าเริ่มต้นแทนการคำนวณจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้า, และคำ แต่ค่าเหล่านี้ไม่สอดคล้องกับคุณสมบัติเสริมเฉพาะ PowerPoint เช่น สไลด์ที่ซ่อน, สไลด์หมายเหตุ, สื่อมัลติมีเดีย, heading‑pair, และ part‑title อาจไม่มี และคุณสมบัติคลังอาจคืนค่าเริ่มต้น อย่าถือว่าค่า 0 หรืออาร์เรย์ว่างเป็นหลักฐานชัดเจนว่าข้อมูลที่เกี่ยวข้องไม่มีอยู่

ใช้วิธีเมตาดาต้าแบบเบาสำหรับคลังข้อมูลและการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุที่ทำงานอยู่เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาจริงของงานนำเสนอ

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่คืนโดย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) สามารถเปลี่ยนได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ใช้ [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) เพื่อปรับเปลี่ยน แล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-)

ภาพต่อไปนี้แสดงคุณสมบัติเ�เอกสารต้นฉบับของงานนำเสนอ PowerPoint

![คุณสมบัติเ�เอกสารต้นฉบับของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนหัวเรื่องและเวลาบันทึกครั้งสุดท้ายแล้วเขียนผลลัพธ์ไปยังไฟล์ใหม่:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงค์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [การป้องกันงานนำเสนอด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/)
- [การป้องกันการเขียนงานนำเสนอ](/slides/th/java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังไว้หรือไม่และเป็นแบบใดบ้าง?**

โหลดงานนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getFontsManager--) เรียก [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) เพื่อรับแบบอักษรที่ฝังไว้และ [IFontsManager.getFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อรับแบบอักษรที่งานนำใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาฟอนต์ที่จำเป็นสำหรับการแสดงผลแต่ไม่ได้ฝัง

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไหร่?**

เมื่อเมตาดาต้าเอกสารที่เก็บไว้เพียงพอ อ่าน [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) และ [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) วิธีนี้เหมาะกับคลังข้อมูลแบบเบา หากงานนำเสนอถูกแก้ไขในหน่วยความจำ เมทาดาต้าอาจหายหรือล้าสมัย หรือคุณต้องการตรวจสอบค่าแบบสด ให้วนลูปผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlides--) แล้วตรวจสอบวิธี [ISlide.getHidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getHidden--) ของแต่ละสไลด์

**ฉันจะตรวจจับว่ามีการใช้ขนาดสไลด์และการวางแนวแบบกำหนดเองหรือไม่ และต่างจากค่าเริ่มต้นอย่างไร?**

ทำได้โดยโหลดงานนำเสนอและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlideSize--) ใช้ [ISlideSize.getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidesize/#getSize--) และ [ISlideSize.getOrientation](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidesize/#getOrientation--) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่ตั้งไว้ล่วงหน้าและขนาดที่คาดหวัง

**มีวิธีเร็ว ๆ เพื่อดูว่าแผนภูมิมีการอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่ ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/) แล้วเรียก [IChartData.getDataSourceType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getDataSourceType--) หากเป็นแหล่งข้อมูลภายนอก ให้เรียก [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ประเภทและเส้นทางของแหล่งข้อมูลบ่งบอกการอ้างอิงภายนอก แต่การตรวจสอบว่าไฟล์เป้าหมายพร้อมใช้งานต้องทำการตรวจสอบทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ ‘หนัก’ ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าลงได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเพียงค่าเดียว ให้วนลูปผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlides--) และคอลเลกชัน [IBaseSlide.getShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getShapes--) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีอยู่ของรูปภาพขนาดใหญ่, เอฟเฟ็กต์, แอนิเมชัน หรือสื่อมัลติมีเดียเป็นสัญญาณคัดกรอง แล้วทำการเรนเดอร์หรือส่งออกตัวอย่างเพื่อวัดประสิทธิภาพก่อนสรุปว่าสไลด์เป็นคอขวดของประสิทธิภาพ.