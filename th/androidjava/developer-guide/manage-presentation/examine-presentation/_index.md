---
title: ดึงข้อมูลและอัปเดตข้อมูลงานนำเสนอบน Android
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
description: "สำรวจสไลด์ โครงสร้าง และเมทาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านเมทาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุของงานนำเสนอแบบเต็ม นี่เป็นประโยชน์เมื่อคุณต้องการจำแนกไฟล์ สร้างรายการสินค้าคงคลัง หรือสอบถามคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหางานนำเสนอหรือไม่

บทความนี้สาธิตการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/), พร้อมกับการอัปเดตแบบเจาะจงผ่าน [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/).

## **ตรวจสอบรูปแบบงานนำเสนอ**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) วิธีการ [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP

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

## **สร้างรายการสินค้าคงคลังงานนำเสนอแบบเบา**

เมื่อคุณประมวลผลไฟล์งานนำเสนอจำนวนมาก คุณอาจต้องการรายการสินค้าคงคลังแบบกะทัดรัดสำหรับการตรวจสอบ ดัชนี หรือระบบจัดการเอกสาร ในสถานการณ์นี้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) เพื่อรับอ็อบเจ็กต์ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) แล้วเรียก [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมทาดาต้าเอกสาร วิธีการนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) หรือจำเป็นต้องเรียกดูโมเดลวัตถุของงานนำเสนอแบบเต็ม

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/) ให้ค่าต่อไปนี้สำหรับรายการสินค้าคงคลัง:

| เมธอด | ค่าที่บันทึก |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | จำนวนสไลด์ทั้งหมด. |
| [getHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | จำนวนสไลด์ที่ซ่อนอยู่. |
| [getNotes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | จำนวนสไลด์ที่มีโน้ต. |
| [getParagraphs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | จำนวนย่อหน้าทั้งหมด (เมื่อมี). |
| [getWords](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | จำนวนคำทั้งหมด. |
| [getMultimediaClips](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | จำนวนคลิปเสียงและวิดีโอทั้งหมด. |

ตัวอย่างต่อไปนี้อ่านค่าต่าง ๆ เหล่านี้โดยไม่ต้องสร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และแสดงรายการสินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังรวม [getHeadingPairs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) กับ [getTitlesOfParts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) เพื่อแสดงกลุ่มเนื้อหาเช่นแบบอักษร, ธีม, และชื่อสไลด์

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

แต่ละ [IHeadingPair](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iheadingpair/) ให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) ส่งกลับอีเรย์แบนที่เรียงลำดับ ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละหัวข้อคู่กำหนด

### **เมทาดาต้าที่จัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติรายการสินค้าคงคลังที่ส่งกลับโดย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) สะท้อนเมทาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่ทำการโหลดและเรียกดูโมเดลวัตถุของงานนำเสนอเพื่อนำค่าต่าง ๆ มาคำนวณใหม่สำหรับการเรียกนี้ คุณสมบัติที่ขาดหายจะถูกแทนด้วยค่าปริยาย และค่าที่เก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติของเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับการนับสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ และคลิปมัลติมีเดีย รวมถึงคู่หัวเรื่องและชื่อส่วน การใช้งานขึ้นอยู่กับว่าคุณสมบัติเหล่านั้นถูกเขียนโดยผู้สร้างเอกสารหรือไม่
- **PPT:** รูปแบบไบนารีนี้สามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัตหายไปหรือไม่ได้รับการอัปเดตโดยผู้สร้างเอกสาร Aspose.Slides จะส่งกลับค่าที่เก็บไว้หรือค่าปริยายแทนการคำนวณจากสไลด์
- **ODP:** เมทาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้า, และคำ แต่ค่าดังกล่าวไม่ได้แมพกับคุณสมบัติเพิ่มเติมเฉพาะ PowerPoint ทุกประการ ข้อมูลเมทาดาต้าสไลด์ที่ซ่อน, โน้ต, มัลติมีเดีย, คู่หัวเรื่อง, และชื่อส่วนอาจไม่มีให้ใช้งาน และคุณสมบัติรายการสินค้าคงคลังอาจส่งค่าปริยาย อย่าใช้ค่าเป็นศูนย์หรืออาเรย์ว่างเป็นหลักฐานยืนยันว่าเนื้อหาที่เกี่ยวข้องไม่มีอยู่

ใช้วิธีเมทาดาต้าแบบเบาสำหรับการทำรายการสินค้าคงคลังและการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุแบบสดเมื่อต้องการให้ผลลัพธ์สะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการตรวจสอบเนื้อจแท้ของงานนำเสนอ

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่ส่งกลับโดย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) แล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-)

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารต้นฉบับของงานนำเสนอ PowerPoint

![คุณสมบัติเอกสารต้นฉบับของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลียนชื่อเรื่องและเวลาบันทึกล่าสุดและเขียนผลลัพธ์ลงในไฟล์ใหม่:

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

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดต

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [การปกป้องงานนำเสนอด้วยรหัสผ่าน](/slides/th/androidjava/password-protected-presentation/)
- [การปกป้องงานนำเสนอจากการเขียน](/slides/th/androidjava/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบว่าแบบอักษรถูกฝังและแบบใดบ้าง?**

โหลดงานนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getFontsManager--). เรียก [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) เพื่อรับแบบอักษรที่ฝังไว้และ [IFontsManager.getFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) เพื่อรับแบบอักษรที่ใช้ในงานนำเสนอ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาแบบอักษรที่จำเป็นต้องใช้ในการเรนเดอร์แต่ไม่ได้ฝังไว้

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

เมื่อเมทาดาต้าเอกสารที่เก็บไว้เพียงพอ ให้อ่าน [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) และ [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) ซึ่งเหมาะกับการทำรายการสินค้าคงคลังแบบเบา หากงานนำเสนอถูกแก้ไขในหน่วยความจำ เมทาดาต้าที่เก็บไว้อาจขาดหายหรือไม่มีอัปเดต หรือคุณต้องการตรวจสอบค่าจริง ให้วนลูปผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) และตรวจสอบเมธอด [ISlide.getHidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getHidden--) ของแต่ละสไลด์แทน

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและทิศทางสไลด์ที่กำหนดเอง และว่าแตกต่างจากค่าเริ่มต้นหรือไม่?**

ใช่ โหลดงานนำเข้ามาและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideSize--). ใช้ [ISlideSize.getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/#getSize--) และ [ISlideSize.getOrientation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidesize/#getOrientation--) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดล่วงหน้าและมิติที่คาดหวัง

**มีวิธีรวดเร็วในการดูว่าแผนภูมิอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่ ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/) แล้วเรียก [IChartData.getDataSourceType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) สำหรับเวิร์กบุ๊คภายนอก ให้เรียก [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ประเภทและเส้นทางของแหล่งข้อมูลจะระบุการอ้างอิงภายนอก แต่การตรวจสอบว่าเป้าหมายพร้อมใช้งานต้องทำการตรวจสอบทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเดียวที่ใช้ได้ ให้เรียกดู [Presentation.getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) และคอลเลกชัน [IBaseSlide.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getShapes--) ของแต่ละสไลด์ ใช้จำนวนรูปร่างและการมีอยู่ของภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชั่น หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนพิจารณาสไลด์เป็นคอขวดประสิทธิภาพที่ยืนยันแล้ว