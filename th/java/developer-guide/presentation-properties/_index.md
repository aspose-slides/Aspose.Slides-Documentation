---
title: จัดการคุณสมบัติงานนำเสนอใน Java
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการตรวจสอบ
- ภาษามาตรฐาน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides for Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย"
---
## **บทนำ**

Aspose.Slides for Java รองรับคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาต้าของงานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่ผู้ใช้กำหนด

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกคืนค่าจาก [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัต่างานนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงบรรยายควบคู่กับเนื้อหาของงานนำเสนอ ทั้งนี้แบ่งออกเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติของเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides for Java ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร กล่องโต้ตอบจะจัดข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนด

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

โดยปกติรหัสผ่านเปิดจะปกป้องทั้งเนื้อหาของงานนำเสนอและคุณสมบัติเอกสาร เมื่อมีการเข้ารหัสงานนำเสนอหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วยค่า `false` คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วยค่า `true` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องใส่รหัสผ่านเปิด

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ควบคุมสิ่งที่ Aspose.Slides โหลด; ไม่ทำการถอดรหัสใด ๆ หากคุณสมบัตถูกรวมอยู่ในการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกนี้จะถูกละเลยและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างนี้ต้องการงานนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเอกสารถูกตั้งให้เป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) แล้วอ่านคุณสมบัติ built-in ผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):
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

ในโหมดนี้ เนื้อหาแผ่นสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และวัตถุอื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) เสมอก่อนทำการดำเนินการที่ต้องการโมเดลวัตถุของงานนำเสนอครบถ้วน
{{% alert color="warning" title="Warning" %}}
เมตาดาต้าสาธารณะอาจทำให้ชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเองถูกเปิดเผย ให้เข้ารหัสคุณสมบัติที่ละเอียดอ่อนพร้อมกับงานนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, การจัดหมวดหมู่, การค้นหา หรือระบบจัดการเอกสาร มีความต้องการเฉพาะในการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วยค่า `true` มีวัตถุประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนแปลงจากวัตถุที่มีเมตาดาต้าอย่างเดียวได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดที่ถูกต้องและการโหลดแบบเต็ม

ตัวอย่างนี้ต้องการงานนำเสนอ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดที่ทราบ มันเปิดงานนำเสนอเต็มด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ปรับปรุงคุณสมบัติ built-in สาธารณะ และบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะอีกครั้งโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่:
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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาของงานนำเสนอ มันต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว

## **เข้าถึงคุณสมบัติ Built-in**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) เปิดเผยเมตาดาต้า built-in ผ่านเมธอด getter รวมถึง [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), และ [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่เก็บไว้ลงคอนโซล ค่าเหล่านี้ขึ้นกับงานนำเข้าสำหรับอินพุต; บางฟิลด์อาจว่าง
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

## **แก้ไขคุณสมบัติ Built-in**

เพื่ออัปเดตเมตาดาต้า built-in ให้ใช้เมธอด setter บนวัตถุที่คืนค่าจาก [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่ เรียกใช้ [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), และ [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) PPTX ที่บันทึกจะมีเมตาดาต้าใหม่
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

## **จัดการฐานของ Hyperlink**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) คืนค่าฐานระดับเอกสารสำหรับ Hyperlink แบบสัมพันธ์ ใช้ [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) เพื่อเปลี่ยนหรือเคลียร์ค่า นี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น มันแยกจาก [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) ของ Hyperlink ทีละอัน: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนปลายทางแบบสัมบูรณ์

ตัวอย่างนี้ต้องการงานนำเสนอที่มีทั้งลิงก์สัมพันธ์ เช่น `target.html` และลิงก์แบบสัมบูรณ์ เช่น `https://example.org/absolute.html` มันอ่านฐานที่มีอยู่แล้วกำหนดฐานใหม่ จากนั้นบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า หลังจากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าที่ว่างในไฟล์ที่บันทึกแยกต่างหาก ให้เปลี่ยนที่อยู่ฐานตัวอย่างเป็นตำแหน่งของไฟล์ที่เชื่อมโยงของคุณ
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

ข้อความตรวจสอบสองข้อความควรพิมพ์ `true` การเคลียร์ฐานจะทำให้ที่อยู่ Hyperlink แต่ละรายการยังคงอยู่

ลิงก์สัมพันธ์ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์แบบสัมบูรณ์ยังคงเปิดไฟล์เดียวกัน ทดสอบลิงก์สัมพันธ์ของคุณใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัติการนำเสนอแบบกำหนดเอง**

คุณสมบัติที่กำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ built-in ที่สอดคล้องกัน เมธอด [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ เพิ่มค่าข้อความสองค่าและค่าตัวเลขเวอร์ชันหนึ่งค่า และบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) การกำหนดค่ากับชื่อที่มีอยู่จะทดแทนค่าของคุณสมบัตินั้น
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

## **เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติที่กำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) เพื่อลูปผ่านมัน [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ แทนที่ค่าทั้งหมดด้วยสตริงลำดับหมายเลขโดยไม่คำนึงถึงประเภทเดิม แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติที่กำหนดเอง ลูปจะไม่ทำการเปลี่ยนแปลงใด ๆ
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

ลองแอปออนไลน์ [**ดูและแก้ไขเมตาดาต้า PowerPoint**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in จากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้โดยสมบูรณ์ อย่างไรก็ตาม คุณสามารถเปลี่ยนค่าของมันหรือกำหนดให้เป็นค่าว่างได้ หากคุณสมบัตินั้นอนุญาต

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ ไม่จำเป็นต้องลบหรือเช็คคุณสมบัตินั้นล่วงหน้า เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มหรือไม่?**

ใช่ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ดู [Build a Lightweight Presentation Inventory](/slides/th/java/examine-presentation/) สำหรับตัวอย่างการรายงานที่ครบถ้วนและข้อจำกัดเฉพาะรูปแบบ

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ใช่ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วยค่า `false` และต้องโหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วยค่า `true`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document-properties-only ได้หรือไม่?**

ไม่ ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มด้วยรหัสผ่านเปิดที่ถูกต้อง