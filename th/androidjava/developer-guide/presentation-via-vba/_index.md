---
title: "จัดการโครงการ VBA ในงานพรีเซนเทชันบน Android"
linktitle: "พรีเซนเทชันผ่าน VBA"
type: docs
weight: 250
url: /th/androidjava/presentation-via-vba/
keywords:
  - "แมโคร"
  - "VBA"
  - "แมโคร VBA"
  - "เพิ่มแมโคร"
  - "ลบแมโคร"
  - "สกัดแมโคร"
  - "เพิ่ม VBA"
  - "ลบ VBA"
  - "สกัด VBA"
  - "PowerPoint"
  - "OpenDocument"
  - "พรีเซนเทชัน"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "ค้นพบวิธีสร้างและจัดการพรีเซนเทชัน PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ Android ด้วย Java เพื่อปรับปรุงกระบวนการทำงานของคุณ."
---
## **บทนำ**

Aspose.Slides มีคลาสและอินเทอร์เฟซสำหรับทำงานกับแมโครและโค้ด VBA.

{{% alert title="Note" color="warning" %}} 

เมื่อคุณแปลงงานพรีเซนเทชันที่มีแมโครเป็นรูปแบบไฟล์อื่น (PDF, HTML, ฯลฯ) Aspose.Slides จะละเลยแมโครทั้งหมด (แมโครจะไม่ได้ถ่ายทอดไปยังไฟล์ผลลัพธ์)

เมื่อคุณเพิ่มแมโครลงในงานพรีเซนเทชันหรือบันทึกงานพรีเซนเทชันที่มีแมโครใหม่อีกครั้ง Aspose.Slides จะเขียนไบต์ของแมโครเท่านั้น

Aspose.Slides **ไม่เคย** รันแมโครในงานพรีเซนเทชัน

{{% /alert %}}

## **เพิ่ม VBA แมโคร**

Aspose.Slides ให้คลาส [VbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/vbaproject/) เพื่อให้คุณสร้างโครงการ VBA (และอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้อินเทอร์เฟซ [IVbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานพรีเซนเทชัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
1. ใช้คอนสตรัคเตอร์ [VbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/vbaproject/#VbaProject--) เพื่อเพิ่มโครงการ VBA ใหม่
1. เพิ่มโมดูลไปยัง VbaProject
1. ตั้งค่ารหัสต้นฉบับของโมดูล
1. เพิ่มการอ้างอิงไปยัง <stdole>
1. เพิ่มการอ้างอิงไปยัง **Microsoft Office**
1. เชื่อมโยงการอ้างอิงกับโครงการ VBA
1. บันทึกการพรีเซนเทชัน

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาสพรีเซนเทชัน
Presentation pres = new Presentation();
try {
    // สร้าง VBA Project ใหม่
    pres.setVbaProject(new VbaProject());
    
    // เพิ่มโมดูลว่างลงใน VBA Project
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // ตั้งค่ารหัสต้นฉบับของโมดูล
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // สร้างการอ้างอิงไปยัง <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // สร้างการอ้างอิงไปยัง Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // เพิ่มการอ้างอิงไปยัง VBA Project
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // บันทึกพรีเซนเทชัน
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

คุณอาจต้องการตรวจสอบ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นแอปเว็บฟรีที่ใช้ในการลบแมโครจากเอกสาร PowerPoint, Excel และ Word

{{% /alert %}} 

## **ลบ VBA แมโคร**

โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getVbaProject--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) คุณสามารถลบแมโคร VBA ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานพรีเซนเทชันที่มีแมโคร
1. เข้าถึงโมดูลแมโครและลบออก
1. บันทึกการพรีเซนเทชันที่แก้ไข

```java
import com.aspose.slides.*;

// โหลดพรีเซนเทชันที่มีแมโคร
Presentation pres = new Presentation("VBA.pptm");
try {
    // เข้าาถึงโมดูล Vba และลบออก 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // บันทึกพรีเซนเทชัน
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สกัด VBA แมโคร**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานพรีเซนเทชันที่มีแมโคร
2. ตรวจสอบว่าการพรีเซนเทชันมี VBA Project หรือไม่
3. วนลูปผ่านโมดูลทั้งหมดที่อยู่ใน VBA Project เพื่อดูแมโคร

```java
import com.aspose.slides.*;

// โหลดพรีเซนเทชันที่มีแมโคร
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // ตรวจสอบว่าพรีเซนเทชันมี VBA Project หรือไม่
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตรวจสอบว่า VBA Project ถูกป้องกันด้วยรหัสผ่านหรือไม่**

โดยใช้เมธอด [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) คุณสามารถระบุได้ว่าโครงการมีการป้องกันด้วยรหัสผ่านหรือไม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และโหลดงานพรีเซนเทชันที่มีแมโคร
2. ตรวจสอบว่าการพรีเซนเทชันมี [VBA project](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/vbaproject/) หรือไม่
3. ตรวจสอบว่า VBA project ถูกป้องกันด้วยรหัสผ่านหรือไม่เพื่อดูคุณสมบัติของมัน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // ตรวจสอบว่าพรีเซนเทชันมีโครงการ VBA หรือไม่
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### จะเกิดอะไรขึ้นกับแมโครหากฉันบันทึกการพรีเซนเทชันเป็น PPTX?

แมโครจะถูกลบเนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บแมโครไว้ให้เลือกใช้ PPTM, PPSM หรือ POTM

### Aspose.Slides สามารถรันแมโครภายในงานพรีเซนเทชันเพื่อเช่น การรีเฟรชข้อมูลได้หรือไม่?

ไม่ได้ ไลบรารีจะไม่มีการประมวลผลโค้ด VBA; การประมวลผลสามารถทำได้เฉพาะใน PowerPoint พร้อมการตั้งค่าความปลอดภัยที่เหมาะสมเท่านั้น

### รองรับการทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA หรือไม่?

ใช่ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/androidjava/activex/) ที่มีอยู่แก้ไขคุณสมบัติของมันและลบออกได้ ซึ่งมีประโยชน์เมื่อแมโครทำงานร่วมกับ ActiveX