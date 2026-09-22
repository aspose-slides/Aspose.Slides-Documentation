---
title: ดึงและอัปเดตข้อมูลงานนำเสนอบน Android
linktitle: ข้อมูลงานนำเสนอ
type: docs
weight: 30
url: /th/androidjava/examine-presentation/
keywords:
- รูปแบบงานนำเสนอ
- คุณสมบัติงานนำเสนอ
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
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ชาญฉลาดขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุของงานนำเสนอเต็มรูปแบบ ซึ่งมีประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการสินค้าคงคลัง หรือสำรวจคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาของงานนำเสนอหรือไม่

บทความนี้แสดงการตรวจสอบแบบน้ำหนักเบาผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) รวมทั้งการอัปเดตแบบเฉพาะเจาะจงผ่าน [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/)

## **ตรวจสอบรูปแบบงานนำเสนอ**

หากคุณมีงานนำเสนอที่โหลดแล้วแล้ว ให้ดูที่ [กำหนดรูปแบบงานนำเสนอเดิม](/slides/th/androidjava/detect-presentation-source-format/) สำหรับการตรวจจับหลังการโหลดและข้อจำกัดของสตรีม PPT, PPS, และ POT แบบเก่า

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) เพื่อสำรวจไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) วิธีการ [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP

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

## **สร้างรายการสินค้างานนำเสนอแบบน้ำหนักเบา**

เมื่อคุณต้องประมวลผลไฟล์งานนำเสนอจำนวนมาก คุณอาจต้องการรายการสินค้าขนาดกะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในกรณีนี้ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับอ็อบเจ็กต์ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) จากนั้นเรียก [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาดาต้าเอกสาร วิธีการนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) หรือจำเป็นต้องวนรอบโมเดลวัตถุของงานนำเสนอทั้งหมด

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/) ให้ค่ารายการสินค้าต่อไปนี้:

| เมธอด | ค่ารายการสินค้ |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | จำนวนสไลด์ทั้งหมด |
| [getHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [getNotes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | จำนวนสไลด์ที่มีโน้ต |
| [getParagraphs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | จำนวนย่อหน้าทั้งหมด (ถ้ามี) |
| [getWords](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | จำนวนคำทั้งหมด |
| [getMultimediaClips](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และพิมพ์รายการสินค้ากะทัดรัด นอกจากนี้ยังผสาน [getHeadingPairs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) กับ [getTitlesOfParts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) เพื่อแสดงกลุ่มเนื้อหา เช่น ฟอนต์ ธีม และชื่อสไลด์

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

แต่ละ [IHeadingPair](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iheadingpair/) ให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) คืนค่ารายการแอเรย์แบบเรียงลำดับเดียว ดังนั้นจึงต้องใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละหัวข้อระบุ

### **เมตาดาต้าจัดเก็บและข้อจำกัดของรูปแบบ**

ค่าคุณสมบัติสต็อกที่คืนโดย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) สะท้อนเมตาดาต้าที่มีอยู่ในเอกสารต้นทาง Aspose.Slides จะไม่โหลดและวนรอบโมเดลวัตถุของงานนำเสนอเพื่อคำนวณค่าเหล่านี้ใหม่ ค่าที่หายไปจะแสดงเป็นค่าเริ่มต้น และค่าที่เก็บไว้อาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ และสื่อมัลติมีเดีย รวมถึงคู่หัวเรื่องและชื่อส่วน ความพร้อมใช้งานขึ้นอยู่กับว่าผู้ออกเอกสารได้เขียนคุณสมบัติเหล่านี้หรือไม่
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติเขียนไม่ได้หรือไม่ได้รับการรีเฟรชโดยผู้ออกเอกสาร Aspose.Slides จะคืนค่าที่เก็บไว้หรือค่าเริ่มต้นแทนที่จะคำนวณจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติเอกสารทั่วไป เช่น จำนวนหน้า, ย่อหน้า, คำ แต่ค่าต่าง ๆ เหล่านี้ไม่สอดคล้องกับคุณสมบัติขยายของ PowerPoint ทุกอย่าง เมตาดาต้าสไลด์ที่ซ่อน, โน้ต, มัลติมีเดีย, คู่หัวเรื่องและชื่อส่วนอาจไม่มีให้บริการและค่าคลังสินค้าจะคืนค่าเริ่มต้น อย่ามองว่าค่าเป็นศูนย์หรือแอเรย์ว่างเป็นหลักฐานชัดเจนว่ามีเนื้อหาที่สอดคล้องกันไม่มีอยู่

ใช้วิธีเมตาดาต้าน้ำหนักเบาสำหรับรายการสินค้และการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุที่ทำงานอยู่เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาจริงของงานนำเสนอ

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่คืนโดย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ใช้การเปลี่ยนแปลงกับ [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) แล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-)

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารต้นฉบับของงานนำเสนอ PowerPoint

![คุณสมบัติเ�เอกสารต้นฉบับของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาแก้ไขล่าสุดและเขียนผลลัพธ์ไปยังไฟล์ใหม่:

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

![คุณสมบัติเ�เอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการปกป้องที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [การปกป้องด้วยรหัสผ่านสำหรับงานนำเสนอ](/slides/th/androidjava/password-protected-presentation/)
- [การปกป้องการเขียนสำหรับงานนำเสนอ](/slides/th/androidjava/write-protected-presentation/)

## **ถาม‑ตอบ**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนท์ถูกฝังอยู่และมีฟอนท์ใดบ้าง?**

โหลดงานนำเสนอแล้วใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getFontsManager--) เรียก [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) เพื่อรับฟอนท์ที่ฝังอยู่และ [IFontsManager.getFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อรับฟอนท์ที่ใช้งานในงานนำเสนอ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาฟอนท์ที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝัง

**ฉันจะบอกได้อย่างเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และมีจำนวนเท่าไหร่?**

เมื่อเมตาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) และ [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) วิธีนี้เหมาะสำหรับการสำรวจรายการสินค้าน้ำหนักเบา หากงานนำเสนอถูกแก้ไขในหน่วยความจำ เมตาดาต้าเก็บอาจหายหรือเก่า หรือหากต้องการตรวจสอบค่าที่ทำงานอยู่ ให้วนผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) และตรวจสอบแต่ละสไลด์ด้วยเมธอด [ISlide.getHidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getHidden--)

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและทิศทางสไลด์ที่กำหนดเองและว่าแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้ โหลดงานนำเสนอแล้วเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideSize--) ใช้ [ISlideSize.getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/#getType--) , [ISlideSize.getSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/#getSize--) และ [ISlideSize.getOrientation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/#getOrientation--) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าพรีเซ็ตและขนาดเริ่มต้น

**มีวิธีรวดเร็วในการดูว่าแผนภูมิเกิดการอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

มี ให้ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/) แล้วเรียก [IChartData.getDataSourceType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) สำหรับแหล่งข้อมูลภายนอกให้เรียก [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ประเภทและเส้นทางของแหล่งข้อมูลบ่งชี้ว่ามีการอ้างอิงภายนอก แต่การตรวจสอบว่าแหล่งนั้นมีอยู่จริงต้องทำการตรวจสอบแหล่งทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าลงอย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเดียวที่บ่งบอก ให้วนตรวจสอบ [Presentation.getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) และคอลเลคชัน [IBaseSlide.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getShapes--) ของแต่ละสไลด์ ใช้จำนวนรูปร่างและการมีอยู่ของรูปภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และอาจทำการเรนเดอร์หรือส่งออกตัวอย่างเพื่อวัดประสิทธิภาพก่อนสรุปว่าสไลด์เป็นคอขวดของประสิทธิภาพ.