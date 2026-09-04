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
- คุณสมบัติในตัว
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบอักษร
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัตินำเสนอใน Aspose.Slides for Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระบบระเบียบ"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้ง่ายโดยใช้ Aspose.Slides API.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/) ตัวอินสแตนซ์ของอินเทอร์เฟซนี้จะถูกส่งคืนโดย [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDocumentProperties--). ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
กรุณาทราบว่าฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นงานนำเสนอที่บันทึกแล้วจะรายงานเป็น "Aspose.Slides for Java" พร้อมเวอร์ชันของไลบรารีที่สร้างมัน ค่าที่ส่งผ่าน `setNameOfApplication` จะถูกละทิ้งเมื่อเขียนงานนำเสนอ.
{{% /alert %}} 

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์งานนำเสนอได้ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
หลังจากคุณเลือกเมนู **Advanced Properties** จะปรากฏหน้าต่างที่ให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ตามรูปด้านล่าง:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ใน **Properties Dialog** ด้านบน คุณจะเห็นว่ามีหลายแท็บเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom**. ทั้งหมดนี้ให้คุณกำหนดค่าข้อมูลประเภทต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint ได้ แท็บ **Custom** ใช้เพื่อจัดการคุณสมบัติที่กำหนดเองของไฟล์ PowerPoint.

ทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Java

ตามที่อธิบายไว้ก่อนหน้านี้ Aspose.Slides for Java รองรับคุณสมบัติเอกสารสองประเภทคือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงทั้งสองประเภทได้โดยใช้ Aspose.Slides for Java API. Aspose.Slides for Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) ที่แทนคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติเอกสารของไฟล์งานนำเสนอได้ตามที่อธิบายด้านล่าง:

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านการเปิดปกติจะแยกปกป้องทั้งเนื้อหางานนำเสนอและคุณสมบัติเอกสาร เมื่อทำการเข้ารหัสงานนำเสนอโดยส่งค่า `false` ไปยัง [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถส่งค่า `true` ไปยัง [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) เพื่ออ่านเมตาดาต้าสาธารณะโดยไม่ต้อง supplying รหัสผ่านการเปิด.

ตัวเลือก “document-properties-only” ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสอะไรเลย หากคุณสมบัติกำหนดให้อยู่ในกระบวนการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกนี้จะถูกละเว้นและงานนำเสนอทั้งหมดจะถูกโหลด.

ตัวอย่างต่อไปตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) แล้วอ่านคุณสมบัติ built-in ผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

ในโหมดนี้ เนื้อหา slide จะไม่ถูกโหลด Slides, masters, layouts, shapes, media, และอ็อบเจกต์อื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) เสมอก่อนทำการดำเนินการที่ต้องการโมเดลอ็อบเจกต์ของงานนำเสนอเต็มรูปแบบ

{{% alert color="warning" title="Warning" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง ควรเข้ารหัสคุณสมบัติที่เป็นข้อมูลลับพร้อมกับงานนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารมีความต้องการเฉพาะให้เข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดในโหมด “document-properties-only” มีวัตถุประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากอ็อบเจกต์ที่มีเมตาดาต้าเพียงอย่างนี้ได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส ดังนั้นการอัปเดตจึงต้องใช้รหัสผ่านการเปิดที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างต่อไปเปิดงานนำเสนอด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), อัปเดตคุณสมบัติ built-in สาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ มันต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจกต์ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) รวมถึง: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันพิมพ์ครั้งสุดท้าย), **LastModifiedBy**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่าง ๆ?), **PresentationFormat**, **Subject** และ **Title**

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงงานนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติ built-in
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

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ built-in ของไฟล์งานนำเสนอันง่ายเท่ากับการเข้าถึงมัน คุณสามารถกำหนดค่า string ให้กับคุณสมบัติใดก็ได้และค่าเหล่านั้นจะถูกแก้ไข ในตัวอย่างด้านล่าง เราได้สาธิตวิธีการแก้ไขคุณสมบัติเอกสาร built-in ของไฟล์งานนำเสนอด้วย Aspose.Slides for Java

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ตั้งค่าคุณสมบัติ built-in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกงานนำเสนอของคุณเป็นไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ built-in ของงานนำเสนอ ซึ่งสามารถดูผลได้ตามด้านล่าง:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสารแบบ Custom**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาสร้างค่าที่กำหนดเองสำหรับคุณสมบัติเอกสารของงานนำเสนอ ตัวอย่างด้านล่างเพิ่มคุณสมบัติ custom สามค่า, จากนั้นค้นหาชื่อที่เก็บไว้ที่ตำแหน่งดัชนี 2 และลบคุณสมบัตินั้น ทำให้งานนำเสนอที่บันทึกไว้เหลือสองค่า คุณสมบัติ custom จะจัดเรียงตามตัวอักษร ไม่ใช่ตามลำดับที่เพิ่ม

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // ดึงคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติที่กำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกงานนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาถึงค่าของคุณสมบัติ custom ตัวอย่างต่อไปแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดสำหรับงานนำเสนอหนึ่งไฟล์

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติที่กำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติที่กำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกงานนำเสนอของคุณเป็นไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ custom ของ [PPTX](https://docs.fileformat.com/presentation/pptx/) งานนำเสนอ รูปต่อไปนี้แสดงคุณสมบัติ custom ก่อนและหลังการแก้ไข:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติเอกสารขั้นสูง**

{{% alert color="info" title="Note" %}}
เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ถูกเพิ่มเข้าไปใน [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) และตรรกะของตัวตั้งค่า [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ได้ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงคุณสมบัติได้โดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าบางอย่างและอัปเดตเอกสาร สามารถทำได้ตามวิธีต่อไปนี้:

```java
import com.aspose.slides.*;

// อ่านข้อมูลของงานนำเสนอ
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

มีอีกวิธีหนึ่งคือใช้คุณสมบัติของงานนำเสนอเฉพาะเป็นเทมเพลตเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

เทมเพลตใหม่สามารถสร้างจากศูนย์แล้วใช้เพื่ออัปเดตหลายงานนำเสนอ:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่ใช้ตรวจการสะกดและไวยากรณ์ใน PowerPoint

โค้ด Java นี้แสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
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

    portionFormat.setLanguageId("zh-CN"); // กำหนด ID ของภาษาตรวจสอบ

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด Java นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของ portion แรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ built-in จากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**เกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าให้โดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่โหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดตามประเภทไฟล์ได้ที่ [Build a Lightweight Presentation Inventory](/slides/th/java/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านการเปิดได้หรือไม่?**

ได้ การเข้ารหัสคุณสมบัติเอกสารต้องถูกปิดก่อนที่งานนำเสนอจะถูกเข้ารหัสและงานนำเสนอจะต้องถูกโหลดในโหมด “document-properties-only”

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด “document-properties-only” ได้หรือไม่?**

ไม่ได้ คุณสมบัติสาธารณะและข้อมูลที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านการเปิดที่ถูกต้อง.