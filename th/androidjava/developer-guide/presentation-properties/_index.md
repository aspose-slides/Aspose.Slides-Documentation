---
title: จัดการคุณสมบัติงานนำเสนอบน Android
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/androidjava/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติกำหนดเอง
- คุณสมบัติเพิ่มเติม
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมทาดาต้าเอกสาร
- แก้ไขเมทาดาต้า
- ภาษาตรวจสอบ
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างราบรื่น"
---
## **บทนำ**

Aspose.Slides สำหรับ Android ผ่าน Java รองรับคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมทาดาต้าของงานนำเสนอ เช่น ผู้เขียน ชื่อเรื่อง และค่าที่กำหนดโดยผู้ใช้

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) ตัวอย่างของอินเทอร์เฟซนี้จะถูกคืนค่าจาก [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมทาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงอธิบายเคียงข้างเนื้อหางานนำเสนอ พวกมันแบ่งออกเป็นสองประเภท

- **Built-in properties** มีเมทาดาต้ามาตรฐาน เช่น ชื่อเรื่อง ผู้เขียน และสถิติของเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides สำหรับ Android ผ่าน Java ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อตรวจสอบเมทาดาต้าเอกสาร กล่องโต้ตอบจะแบ่งข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนด

## **อ่านคุณสมบัตสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์มักจะปกป้องทั้งเนื้อหาและคุณสมบัติเอกสาร เมื่อทำการเข้ารหัสงานนำเสนอหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วย `false` คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true` และอ่านเมทาดาต้าสาธารณะโดยไม่ต้องระบุรหัสผ่านเปิดไฟล์

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ทำการถอดรหัสใด ๆ หากคุณสมบัติเหล่านั้นรวมอยู่ในกระบวนการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ถูกเข้ารหัส ตัวเลือกนี้จะถูกละเว้นและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต่อไปนี้ต้องการงานนำเสนอที่เข้ารหัสซึ่งคุณสมบัติเอกสารถูกตั้งเป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) แล้วอ่านคุณสมบัติ built‑in ผ่าน [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--)：

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

ในโหมดนี้ เนื้อหาของสไลด์จะไม่ถูกรโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อและอ็อบเจกต์อื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ก่อนทำงานใด ๆ ที่ต้องการแบบจำลองอ็อบเจกต์ของงานนำเสนอเต็มรูปแบบ

{{% alert color="warning" title="Warning" %}}
เมทาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง เรื่องย่อย คำสำคัญ ข้อมูลบริษัท ความคิดเห็น และค่าที่กำหนดเอง ให้เข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ ปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี การจัดประเภท การค้นหา หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true` มีจุดประสงค์เพื่ออ่านเมทาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากอ็อบเจกต์ที่โหลดเฉพาะเมทาดาต้านี้ได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและการโหลดแบบเต็ม

ตัวอย่างต่อไปนี้ต้องการไฟล์ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดไฟล์ที่ทราบ มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) อัปเดตคุณสมบัติ built‑in สาธารณะ แล้วบันทึกผลลัพธ์ จากนั้นใช้ [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมทาดาต้าสาธารณะอีกครั้งโดยไม่ต้องใช้รหัสผ่านเพื่อตรวจสอบค่าที่ใหม่：

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

หากแอปพลิเคชันไม่อนุญาตให้ถอดรหัสหรือโหลดเนื้อหาสไลด์ จะต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึงคุณสมบัติ Built‑in**

อินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) เปิดเผยเมทาดาต้า built‑in ผ่านเมธอด getter เช่น [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), และ [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมทาดาต้าที่เก็บไว้ลงคอนโซล ค่าเหล่านี้ขึ้นกับงานนำเข้าที่ใช้; บางฟิลด์อาจว่างเปล่า

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

### **รายงานหมายเลขการแก้ไขและเวลาการแก้ไข**

เพื่อรายงานหนึ่งแถวต่อไฟล์ PPTX ในโฟลเดอร์ที่แอป Android ของคุณสามารถอ่านได้ ให้เรียก [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่าน [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) โดยไม่ต้องโหลดสไลด์สำหรับการแก้ไข API ของ Android ผ่าน Java จะคืนค่าระยะเวลาแก้ไขเป็นมิลลิวินาที แทนที่เส้นทางโฟลเดอร์ตัวอย่างด้วยเส้นทางของไฟล์ของคุณ ตัวอย่างจะแปลงระยะเวลาเป็นชั่วโมง นาที และวินาที พร้อมนับวันเมื่อระยะเวลาดาวกว่า 24 ชั่วโมง

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

สำหรับงานนำเสนอที่บันทึกเวลาการแก้ไขไว้เป็น 1 วัน 2 ชั่วโมง 5 นาที รายงานจะแสดงผลลัพธ์ดังต่อไปนี้

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--) อ่านค่าที่แอปพลิเคชันสามารถเปลี่ยนได้ด้วย [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-). หมายเลขการแก้ไขเพียงอย่างเดียวไม่สามารถบอกได้ว่ามีการบันทึกงานนำเสนอกี่ครั้งหรือสร้างประวัติรุ่นอย่างไร

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) อ่านระยะเวลาการแก้ไขที่บันทึกในไฟล์ ค่า `00:00:00` หมายถึงระยะเวลาที่บันทึกเป็นศูนย์ แม้ว่ามีคนแก้ไขงานนำเสนอก็ตาม

## **แก้ไขคุณสมบัติ Built‑in**

เพื่ออัปเดตเมทาดาต้า built‑in ให้ใช้เมธอด setter ของอ็อบเจกต์ที่ได้จาก [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่ เรียก [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), และ [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). PPTX ที่บันทึกจะมีเมทาดาต้าใหม่

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

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) คืนค่าฐานระดับเอกสารสำหรับไฮเปอร์ลิงก์แบบสัมพันธ์ ใช้ [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) เพื่อเปลี่ยนหรือเคลียร์ค่า นี้เป็นประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งใหม่ มันแยกจาก [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) ของไฮเปอร์ลิงก์แต่ละรายการ: การเปลี่ยนฐานไม่ได้เขียนที่อยู่ลิงก์ที่เก็บไว้ใหม่หรือเปลี่ยนปลายทางแบบสัมบกัน

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์สัมพันธ์เช่น `target.html` และลิงก์สัมบกันเช่น `https://example.org/absolute.html` มันอ่านฐานปัจจุบัน กำหนดฐานใหม่ แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าว่างในไฟล์ที่บันทึกแยกต่างหาก แทนที่ฐานตัวอย่างด้วยตำแหน่งไฟล์ที่เชื่อมโยงของคุณ

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

ข้อความตรวจสอบสองข้อความควรพิมพ์ `true` การเคลียร์ฐานไม่กระทบที่อยู่ไฮเปอร์ลิงก์แต่ละรายการ

ลิงก์สัมพันธ์ `target.pptx` จะเปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` แล้วบันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์สัมบกันยังคงเปิดไฟล์เดิม ทดสอบลิงก์สัมพันธ์ของคุณใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัติการนำเสนอแบบกำหนดเอง**

คุณสมบัติกำหนดเองเก็บเมทาดาต้าที่ไม่มีฟิลด์ built‑in ที่สอดคล้องกัน วิธี [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ให้คุณกำหนดค่าโดยชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ เพิ่มค่าข้อความสองค่าและค่าตัวเลขเวอร์ชันหนึ่งค่า แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). การกำหนดค่าให้ชื่อที่มีอยู่แล้วจะทับค่าที่มีอยู่

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

## **เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) เพื่อวนลูปผ่านมัน [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) รับดัชนีเริ่มต้นจาก 0 และคืนชื่อที่ใช้โดย [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ แทนที่ค่าทั้งหมดด้วยสตริงลำดับหมายเลขโดยไม่คำนึงถึงประเภทเดิม แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติกำหนดเอง ลูปจะไม่มีการเปลี่ยนแปลงใด ๆ

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

## **ตัวอย่างแบบสด**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ built‑in ออกจากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาตให้ทำเช่นนั้น

**ถ้าฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว จะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่ใหม่ ไม่จำเป็นต้องลบหรือเช็กคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมทาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดตามรูปแบบได้ในหัวข้อ [Build a Lightweight Presentation Inventory](/slides/th/androidjava/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ด้วย `false` และต้องถูกโหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ด้วย `true`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document‑properties‑only ได้หรือไม่?**

ไม่ได้ คุณสมบัติสาธารณะและข้อมูลที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง