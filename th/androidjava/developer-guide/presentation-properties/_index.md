---
title: จัดการคุณสมบัติการนำเสนอบน Android
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/androidjava/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติแบบกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมทาดาต้าเอกสาร
- แก้ไขเมทาดาต้า
- ภาษาการพิสูจน์อักษร
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณราบรื่นขึ้น"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ API ของ Aspose.Slides

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเบรนท์ของการพรีเซนต์ผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/) ตัวอย่างของอินเทอร์เฟซนี้จะถูกส่งคืนโดย [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
กรุณาทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นการพรีเซนต์ที่บันทึกแล้วจะรายงานชื่อผลิตภัณฑ์ Aspose.Slides และเวอร์ชันของไลบรารีที่สร้างมัน ค่าใด ๆ ที่ส่งผ่าน `setNameOfApplication` จะถูกละทิ้งเมื่อพรีเซนต์ถูกเขียน
{{% /alert %}} 

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติของไฟล์พรีเซนต์ได้ทั้งหมด เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามตัวอย่างด้านล่าง

|**เลือกเมนู Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากคุณเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ตามรูปต่อไปนี้

|**กล่องโต้ตอบ Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **กล่องโต้ตอบ Properties** ข้างต้น คุณจะเห็นแท็บหลายหน้า ได้แก่ **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ช่วยกำหนดค่าข้อมูลต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint ได้ **Custom** ใช้สำหรับจัดการคุณสมบัติแบบกำหนดเองของไฟล์ PowerPoint

### ทำงานกับคุณสมบัติเอกสารด้วย Aspose.Slides for Android via Java

อย่างที่อธิบายไว้ก่อนหน้านี้ Aspose.Slides for Android via Java รองรับคุณสมบัติของเอกสารสองประเภทคือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงคุณสมบัติทั้งสองประเภทได้โดยใช้ API ของ Aspose.Slides for Android via Java Aspose.Slides for Android via Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) ที่แสดงคุณสมบัติเบรนท์ของไฟล์พรีเซนต์ผ่านคุณสมบัติ **Presentation.DocumentProperties**

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของไฟล์พรีเซนต์ได้ตามรายละเอียดต่อไปนี้

## **อ่านคุณสมบัติสาธารณะจากพรีเซนต์ที่ถูกเข้ารหัส**

รหัสผ่านเปิดไฟล์โดยปกติจะปกป้องทั้งเนื้อหาและคุณสมบัติของพรีเซนต์ เมื่อพรีเซนต์ถูกเข้ารหัสโดยส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) คุณสมบัติของเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถส่งค่า `true` ไปยัง [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) และอ่านเมทาดาต้าสาธารณะโดยไม่ต้องระบุรหัสผ่านเปิดไฟล์

ตัวเลือกโหลดเฉพาะคุณสมบัติเอกสารควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ทำการถอดรหัสใด ๆ หากคุณสมบัติกำหนดอยู่ในกระบวนการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลวบ. หากพรีเซนต์ไม่ได้เข้ารหัส ตัวเลือกนี้จะถูกละเว้นและพรีเซนต์ทั้งหมดจะถูกโหลด

ตัวอย่างต่อไปนี้ตรวจสอบโหมดการโหลดโดยผ่าน [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) จากนั้นอ่านคุณสมบัติแบบ built‑in ผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปทรง, สื่อ และวัตถุตัวอื่นของพรีเซนต์จะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ก่อนทำการดำเนินการที่ต้องการโมเดลวัตถุของพรีเซนต์ทั้งหมด

{{% alert color="warning" title="Warning" %}}
เมทาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, คอมเมนต์, และค่าที่กำหนดเอง ควรเข้ารหัสคุณสมบัติที่สำคัญพร้อมกับพรีเซนต์ ทำให้เป็นสาธารณะเฉพาะเมื่อระบบการจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารมีความต้องการเฉพาะที่จะเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของพรีเซนต์ที่ถูกเข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส พรีเซนต์ที่โหลดในโหมด document‑properties‑only มีจุดประสงค์เพื่ออ่านเมทาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนแปลงจากวัตถุที่โหลดเฉพาะเมทาดาต้าได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลภายในพรีเซนต์ที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและโหลดเต็มรูปแบบ

ตัวอย่างต่อไปนี้เปิดพรีเซนต์ด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), อัปเดตคุณสมบัติ built‑in สาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมทาดาต้าสาธารณะโดยไม่ต้องใช้รหัสผ่านเพื่อยืนยันค่าใหม่:

```java
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
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาพรีเซนต์ จะต้องถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียวเท่านั้น

## **เข้าถึงคุณสมบัติ Built‑in**

คุณสมบัติที่เปิดเผยโดยวัตถุ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) มีดังนี้: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตหลายคน?), **PresentationFormat**, **Subject** และ **Title**

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนการนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติโบบิลท์‑อิน
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **แก้ไขคุณสมบัติ Built‑in**

การแก้ไขคุณสมบัติ built‑in ของไฟล์พรีเซนต์ทำได้ง่ายเท่ากับการเข้าถึง เพียงกำหนดค่า string ให้กับคุณสมบัติที่ต้องการ ค่าของคุณสมบัติก็จะถูกแก้ไข ตัวอย่างด้านล่างแสดงวิธีการแก้ไขคุณสมบัติเอกสาร built‑in ของพรีเซนต์ด้วย Aspose.Slides for Android via Java

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ตั้งค่าคุณสมบัติโบบิลท์‑อิน
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกการนำเสนอของคุณลงไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ built‑in ของพรีเซนต์และแสดงผลลัพธ์ดังต่อไปนี้

|**คุณสมบัติเอกสาร Built‑in หลังการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติ Document Custom**

Aspose.Slides for Android via Java ยังอนุญาตให้นักพัฒนาติดค่าคุณสมบัติแบบกำหนดเองสำหรับพรีเซนต์ ตัวอย่างด้านล่างเพิ่มคุณสมบัติ custom สามรายการ จากนั้นค้นหาชื่อที่จัดเก็บในดัชนี 2 และลบคุณสมบัตินั้น ดังนั้นพรีเซนต์ที่บันทึกไว้จะเหลือสองรายการ คุณสมบัติ custom จะถูกจัดเรียงตามลำดับอักษร ไม่ใช่ตามลำดับการเพิ่ม

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // ดึงคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติแบบกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัตที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกการนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**คุณสมบัติ Document Custom ที่เพิ่มเข้ามา**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides for Android via Java ยังอนุญาตให้เข้าถึงค่าของคุณสมบัติ custom ตัวอย่างด้านล่างแสดงวิธีเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดของพรีเซนต์

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกการนำเสนอของคุณลงไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ custom ของ [PPTX](https://docs.fileformat.com/presentation/pptx/) พรีเซนต์ ภาพต่อไปนี้แสดงคุณสมบัติ custom ก่อนและหลังการแก้ไข

|**คุณสมบัติ Custom ก่อนการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**คุณสมบัติ Custom หลังการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติ Document ขั้นสูง**

{{% alert color="info" title="Note" %}}
เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ถูกเพิ่มเข้าไปใน [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) การตั้งค่าเซ็ตเตอร์ของคุณสมบัติ [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดพรีเซนต์ทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, แก้ไขค่าบางอย่างและอัปเดตเอกสาร สามารถทำได้ตามตัวอย่างต่อไปนี้

```java
import com.aspose.slides.*;

// อ่านข้อมูลของพรีเซนต์
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ดึงคุณสมบัติปัจจุบัน
IDocumentProperties props = info.readDocumentProperties();

// ตั้งค่าค่าต่าง ๆ ใหม่ของฟิลด์ Author และ Title
props.setAuthor("New Author");
props.setTitle("New Title");

// อัปเดตพรีเซนต์ด้วยค่าที่ใหม่
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของพรีเซนต์หนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในพรีเซนต์อื่น ๆ

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายพรีเซนต์ได้

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **กำหนดภาษาการตรวจสอบ (Proofing Language)**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณกำหนดภาษาการตรวจสอบสำหรับเอกสาร PowerPoint ภาษาการตรวจสอบคือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด Java นี้แสดงวิธีกำหนดภาษาการตรวจสอบสำหรับ PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ตั้งค่า Id ของภาษาการตรวจสอบ

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดภาษาจัดเริ่มต้น (Default Language)**

โค้ด Java นี้แสดงวิธีกำหนดภาษาจัดเริ่มต้นสำหรับพรีเซนต์ PowerPoint ทั้งหมด:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของส่วนแรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างออนไลน์**

ลองใช้แอป [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) ออนไลน์เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน API ของ Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built‑in ออกจากพรีเซนต์ได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนสำคัญของพรีเซนต์และไม่สามารถลบออกได้โดยสมบูรณ์ อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างหากคุณสมบัตินั้นอนุญาตให้ทำได้

**ถ้าฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าใหม่ ไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าให้โดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติของพรีเซนต์โดยไม่ต้องโหลดพรีเซนต์ทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมทาดาต้าเก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานสรุปพรีเซนต์แบบเบา ๆ ที่ /slides/th/androidjava/examine-presentation/ สำหรับข้อจำกัดตามฟอร์แมต

**ฉันสามารถอ่านคุณสมบัติสาธารณะของพรีเซนต์ที่เข้ารหัสโดยไม่ใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ การเข้ารหัสคุณสมบัติโดยต้องเปิดไฟล์ต้องถูกปิดก่อนที่พรีเซนต์จะถูกเข้ารหัส และพรีเซนต์ต้องถูกโหลดในโหมด document‑properties‑only

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document‑properties‑only ได้หรือไม่?**

ไม่ได้ คุณสมบัติสาธารณะและข้อมูลที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดพรีเซนต์เต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง