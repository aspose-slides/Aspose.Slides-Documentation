---
title: จัดการคุณสมบัตินำเสนอบน Android
linktitle: คุณสมบัตินำเสนอ
type: docs
weight: 70
url: /th/androidjava/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัตินำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบการพิสูจน์
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัตินำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระเบียบและมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides for Android via Java รองรับคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาต้าของงานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่กำหนดโดยผู้ใช้  

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) ส่วนหนึ่งของอินเทอร์เฟซนี้จะถูกคืนค่าด้วย [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุตัวซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเอกสารจะเก็บข้อมูลอธิบายพร้อมกับเนื้อหางานนำเสนอ แบ่งออกเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่กำหนดโดยผู้ใช้  

Aspose.Slides for Android via Java ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร หน้าต่างจะแบ่งข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่กำหนดโดยผู้ใช้

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์โดยปกติจะปกป้องทั้งเนื้อหางานนำเสนอและคุณสมบัติเอกสาร เมื่อทำการเข้ารหัสงานนำเสนอหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วยค่า `false` คุณสมบัติเอกสารจะคงเป็นสาธารณะ แอปพลิเคชันจึงสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วยค่า `true` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องใส่รหัสผ่านเปิดไฟล์  

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ทำการถอดรหัสใด ๆ หากคุณสมบัติเ�ถูกเข้ารหัส การโหลดโดยไม่ใส่รหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้ถูกเข้ารหัส ตัวเลือกจะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด  

ตัวอย่างนี้ต้องการงานนำเสนอที่เข้ารหัสโดยคุณสมบัติเอกสารถูกเปิดให้สาธารณะ ตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) แล้วอ่านคุณสมบัติในตัวสร้างด้วย [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) :

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

ในโหมดนี้ เนื้อหา slide จะไม่ถูกโหลด Slides, masters, layouts, shapes, media, และออบเจ็กต์อื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ก่อนทำการที่ต้องอาศัยโมเดลออบเจ็กต์ของงานนำเสนอทั้งหมด

{{% alert color="warning" title="Warning" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวเรื่อง, คีย์เวิร์ด, ข้อมูลบริษัท, คอมเมนต์, และค่าที่กำหนดเอง การเข้ารหัสคุณสมบัติที่อ่อนไหวพร้อมกับงานนำเสนอเป็นวิธีที่ปลอดภัย ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, จัดประเภท, ค้นหา, หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true` มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากออบเจ็กต์แบบเมตาดาต้า‑เท่านั้นได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและโหลดเต็มรูปแบบ  

ตัวอย่างนี้ต้องการ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดไฟล์ที่ทราบ เปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) อัปเดตคุณสมบัติ built‑in สาธารณะ แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่ :

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ จะต้องถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึงคุณสมบัติดำน้ำ (Built‑in) **

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) เปิดเผยเมตาดาต้าดำน้ำผ่านเมธอด getter รวมถึง [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), และ [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่เก็บไว้บนคอนโซล ค่าเหล่านี้ขึ้นกับงานนำเข้าที่ให้; บางฟิลด์อาจว่างเปล่า  

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

## **แก้ไขคุณสมบัติดำน้ำ**

เพื่ออัปเดตเมตาดาต้าดำน้ำ ใช้เมธอด setter บน object ที่ได้จาก [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่ เรียก [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), และ [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) PPTX ที่บันทึกจะมีเมตาดาต้าใหม่  

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **จัดการ Hyperlink Base**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) คืนค่าฐานของเอกสารสำหรับไฮเปอร์ลิงก์เชิงสัมพันธ์ ใช้ [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) เพื่อเปลี่ยนหรือเคลียร์ค่า สิ่งนี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น มันแยกจาก [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) ของไฮเปอร์ลิงก์แต่ละอัน: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนปลายทางแบบสัมบูรณ์  

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์เชิงสัมพันธ์ เช่น `target.html` และลิงก์สัมบูรณ์เช่น `https://example.org/absolute.html` อ่านฐานเดิม ตั้งค่าฐานใหม่ แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นเคลียร์ฐานด้วยสตริงว่างและยืนยันค่าว่างในไฟล์บันทึกแยกต่างหาก แทนที่ที่อยู่ฐานตัวอย่างด้วยตำแหน่งไฟล์ที่เชื่อมโยงของคุณ  

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

ข้อความตรวจสอบทั้งสองควรพิมพ์ `true` การเคลียร์ฐานจะไม่กระทบที่อยู่ไฮเปอร์ลิงก์แต่ละอัน  

ลิงก์เชิงสัมพันธ์ `target.pptx` จะเปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` แล้วบันทึกและเปิดงานนำเสนออีกครั้ง ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์สัมบูรณ์จะยังคงเปิดไฟล์เดิม ทดสอบลิงก์เชิงสัมพันธ์ใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัต้งานนำเสนอแบบกำหนดเอง**

คุณสมบัติแบบกำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ดำน้ำที่สอดคล้องกัน เมธอด [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ให้คุณกำหนดค่าผ่านชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ เพิ่มค่าข้อความสองค่าและค่าตัวเลขเวอร์ชันหนึ่งค่า แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) การกำหนดค่าชื่อที่มีอยู่แล้วจะทับค่าที่มีอยู่  

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

## **เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติแบบกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) เพื่อนับจำนวน จากนั้นใช้ [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) ด้วยดัชนีตั้งต้นศูนย์เพื่อรับชื่อที่ใช้กับ [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ตัวอย่างพิมพ์ชื่อและค่าเดิมแต่ละรายการ แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลข regardless of original type แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติแบบกำหนดเอง ลูปจะไม่ทำการใด ๆ  

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

## **ตัวอย่างสด**

ลองใช้ออนไลน์แอป [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเ�เอกสารโดยใช้ Aspose.Slides API  

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติดำน้ำจากงานนำเสนอได้อย่างไร?**  
คุณสมบัติดำน้ำเป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาตให้ทำเช่นนั้น  

**ถ้าฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้วจะเกิดอะไรขึ้น?**  
ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าโดยอัตโนมัติ  

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่โหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**  
ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ดูตัวอย่างการรายงานแบบเบาใน [Build a Lightweight Presentation Inventory](/slides/th/androidjava/examine-presentation/) สำหรับข้อจำกัดตามรูปแบบไฟล์  

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**  
ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วย `false` และต้องถูกโหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true`  

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมดอ่านเฉพาะคุณสมบัติเ�เอกสารได้หรือไม่?**  
ไม่ได้ คุณสมบัติสาธารณะและที่เข้ารหัสต้องคงความสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง  