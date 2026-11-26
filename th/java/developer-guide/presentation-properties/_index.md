---
title: จัดการคุณสมบัตินำเสนอใน Java
linktitle: คุณสมบัตินำเสนอ
type: docs
weight: 70
url: /th/java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัตินำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติ built-in
- คุณสมบัติ custom
- คุณสมบัติขั้นสูง
- การจัดการคุณสมบัติ
- การแก้ไขคุณสมบัติ
- metadata เอกสาร
- แก้ไข metadata
- ภาษา proofing
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัตินำเสนอใน Aspose.Slides สำหรับ Java และทำให้การค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย."
---
## **บทนำ**

Aspose.Slides for Java รองรับคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดต metadata ของงานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่ผู้ใช้กำหนด

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) ตัวอย่างของอินเทอร์เฟซนี้จะถูกคืนค่าโดย [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการ metadata ของแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงอธิบายควบคู่กับเนื้อหาของงานนำเสนอ พวกมันแบ่งออกเป็นสองประเภท:

- **Built-in properties** มี metadata มาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติของเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides for Java ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint, เลือก **File → Info → Properties → Advanced Properties** เพื่อดู metadata ของเอกสาร กล่องโต้ตอบจัดข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้กำหนด

## **Read Public Properties from an Encrypted Presentation**

รหัสผ่านเปิดปกติจะปกป้องทั้งเนื้อหาและคุณสมบัติเอกสารของงานนำเสนอ เมื่อมีการเข้ารหัสงานนำเสนอหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วย `false` คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true` และอ่าน metadata สาธารณะโดยไม่ต้องระบุรหัสผ่านเปิด

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสอะไร หากคุณสมบัติเกิดรวมอยู่ในการเข้ารหัส การโหลดโดยไม่ใช้รหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ถูกเข้ารหัส ตัวเลือกนี้จะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต้องการงานนำเสนอที่เข้ารหัสโดยที่คุณสมบัติเอกสารถูกฝากไว้เป็นสาธารณะ ตัวอย่างตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) แล้วอ่านคุณสมบัติ built‑in ผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

ในโหมดนี้เนื้อหาของสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลเอาต์, รูปร่าง, สื่อ, และออบเจ็กต์อื่นของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) เสมอก่อนทำการที่ต้องการโมเดลออบเจ็กต์ของงานนำเสนอเต็มรูปแบบ

{{% alert color="warning" title="Warning" %}}
metadata สาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง การเข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะกรณีที่ระบบจัดทำดัชนี, จัดประเภท, ค้นหา, หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true` มีวัตถุประสงค์เพื่ออ่าน metadata สาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากอ็อบเจ็กต์ที่โหลดเฉพาะ metadata ได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างต้องการงานนำเสนอ PPTX ที่เข้ารหัสพร้อมกับคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดที่ทราบ มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) อัปเดตคุณสมบัติ built‑in สาธารณะ และบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิด metadata สาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

หากแอปพลิเคชันไม่อนุญาตให้ถอดรหัสหรือโหลดเนื้อหาของงานนำเสนอ ต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสว่าเป็นอ่าน‑อย่างเดียว

## **Access Built-in Properties**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) เปิดเผย metadata built‑in ผ่านเมธอด getter เช่น [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), และ [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์ metadata ที่จัดเก็บลงคอนโซล ค่าเหล่านี้ขึ้นกับงานนำเข้าที่ใช้; บางฟิลด์อาจว่างเปล่า

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **Report Revision Number and Editing Time**

เพื่อรายงานหนึ่งแถวต่อไฟล์ PPTX ในโฟลเดอร์ `presentations` เรียก [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่าน [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) โดยไม่โหลดสไลด์สำหรับแก้ไข API ของ Java คืนค่าระยะเวลาการแก้ไขเป็นมิลลิวินาที ตัวอย่างจะแปลงเป็นชั่วโมง, นาที, และวินาที พร้อมจำนวนวันสำหรับระยะเวลาที่เหนือ 24 ชั่วโมง

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

สำหรับงานนำเสนอที่บันทึกเวลาแก้ไขเป็น 1 วัน, 2 ชั่วโมง, และ 5 นาที รายงานจะแสดงผลลัพธ์ดังต่อไปนี้

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) อ่านค่าที่แอปพลิเคชันสามารถเปลี่ยนได้ด้วย [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) หมายเลขรีวิชันเพียงอย่างเดียวไม่สามารถบ่งชี้จำนวนครั้งที่งานนำเสนอถูกบันทึกหรือสร้างประวัติเวอร์ชันได้

[getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) อ่านระยะเวลาการแก้ไขที่บันทึกไว้ในไฟล์ ค่า `00:00:00` หมายถึงระยะเวลาที่เก็บเป็นศูนย์ แม้ว่าจะมีคนแก้ไขงานนำเสนอ

## **Modify Built-in Properties**

เพื่ออัปเดต metadata built‑in ให้ใช้เมธอด setter บนวัตถุที่ได้จาก [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างเปิดงานนำเสนอที่มีอยู่, เรียก [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), และ [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) PPTX ที่บันทึกจะมี metadata ใหม่

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Manage the Hyperlink Base**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) คืนค่าฐานระดับเอกสารสำหรับ hyperlink เชิงสัมพันธ์ ใช้ [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) เพื่อเปลี่ยนหรือเคลียร์ค่า นี้เป็นประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่ลิงก์ไปยังตำแหน่งอื่น แยกจาก [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) ของ hyperlink แต่ละอัน: การเปลี่ยนฐานไม่ทำการเขียนทับที่อยู่ลิงก์ที่บันทึกไว้หรือเปลี่ยนปลายทางเป็นแบบ absolute

ตัวอย่างต้องการงานนำเสนอที่มีลิงก์เชิงสัมพันธ์ เช่น `target.html` และลิงก์ absolute เช่น `https://example.org/absolute.html` อ่านฐานที่มีอยู่, ตั้งฐานใหม่, บันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า หลังจากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าเปล่าในไฟล์ที่บันทึกแยกกัน แทนที่ฐานตัวอย่างด้วยตำแหน่งของไฟล์ที่ลิงก์ของคุณ

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

ข้อความตรวจสอบสองข้อความควรพิมพ์ `true` การเคลียร์ฐานจะไม่กระทบที่อยู่ของ hyperlink แยกแต่ละอัน

ลิงก์เชิงสัมพันธ์ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันเปิด `new/target.pptx` ลิงก์ absolute ยังคงเปิดไฟล์เดียวกัน ทดสอบลิงก์เชิงสัมพันธ์ของคุณใน PowerPoint ก่อนและหลังการย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **Add Custom Presentation Properties**

คุณสมบัติเฉพาะเก็บ metadata ที่ไม่มีฟิลด์ built‑in ที่สอดคล้องกัน [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่าข้อความสองค่และค่าตัวเลขเวอร์ชัน, แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) การกำหนดค่าให้ชื่อที่มีอยู่แล้วจะทับค่าของคุณสมบัตินั้น

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Access and Modify Custom Properties**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติเฉพาะและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) เพื่อวนลูปผ่านพวกมัน [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทุกค่าโดยสตริงลำดับเลข regardless of its original type, แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติเฉพาะ ลูปจะไม่ทำการใด ๆ

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live Example**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ API ของ Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

คุณสมบัติ built‑in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบโดยสมบูรณ์ได้ อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดค่าเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**What happens if I add a custom property that already exists?**

หากคุณเพิ่มคุณสมบัติเฉพาะที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**Can I access presentation properties without fully loading the presentation?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่าน metadata ที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดตามประเภทไฟล์ที่ [Build a Lightweight Presentation Inventory](/slides/th/java/examine-presentation/)

**Can I read public properties of an encrypted presentation without its opening password?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วย `false` และต้องโหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true`

**Can I update an encrypted PPTX file in document‑properties‑only mode?**

ไม่ได้ ข้อมูลคุณสมบัติสาธารณะและข้อมูลที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอแบบเต็มพร้อมรหัสผ่านเปิดที่ถูกต้อง