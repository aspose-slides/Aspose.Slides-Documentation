---
title: จัดการโครงการ VBA ในงานนำเสนอด้วย Java
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/java/presentation-via-vba/
keywords:
- แมโคร
- VBA
- แมโคร VBA
- เพิ่มแมโคร
- ลบแมโคร
- สกัดแมโคร
- เพิ่ม VBA
- ลบ VBA
- สกัด VBA
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ Java เพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบมากขึ้น"
---
## **บทนำ**

Aspose.Slides มีคลาสและอินเทอร์เฟซสำหรับทำงานกับแมโครและโค้ด VBA

{{% alert title="หมายเหตุ" color="warning" %}} 
เมื่อคุณแปลงงานนำเสนอที่มีแมโครเป็นรูปแบบไฟล์อื่น (PDF, HTML, ฯลฯ) Aspose.Slides จะละเลยแมโครทั้งหมด (แมโครจะไม่ถูกนำไปยังไฟล์ผลลัพธ์)

เมื่อคุณเพิ่มแมโครลงในงานนำเสนอหรือบันทึกงานนำเสนอที่มีแมโครใหม่ Aspose.Slides จะเพียงเขียนไบต์ของแมโครเท่านั้น

Aspose.Slides **ไม่เคย** ทำการรันแมโครในงานนำเสนอ
{{% /alert %}}

## **เพิ่ม VBA Macros**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/vbaproject/) เพื่อให้คุณสร้างโปรเจกต์ VBA (และอ้างอิงโปรเจกต์) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้อินเทอร์เฟซ [IVbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
1. ใช้ตัวสร้าง [VbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/vbaproject/#VbaProject--) เพื่อเพิ่มโปรเจกต์ VBA ใหม่
1. เพิ่มโมดูลเข้าไปใน VbaProject
1. ตั้งค่าซอร์สโค้ดของโมดูล
1. เพิ่มอ้างอิงไปยัง <stdole>
1. เพิ่มอ้างอิงไปยัง **Microsoft Office**
1. เชื่อมโยงอ้างอิงเหล่านั้นกับโปรเจกต์ VBA
1. บันทึกงานนำเสนอ

โค้ดภาษา Java นี้แสดงวิธีเพิ่ม VBA macro ตั้งแต่ต้นจนจบในงานนำเสนอ:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้าง VBA Project ใหม่
    pres.setVbaProject(new VbaProject());
    
    // เพิ่มโมดูลเปล่าลงใน VBA Project
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // ตั้งค่าซอร์สโค้ดของโมดูล
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // สร้างการอ้างอิงไปยัง <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // สร้างการอ้างอิงไปยัง Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // เพิ่มการอ้างอิงลงใน VBA Project
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // บันทึกงานนำเสนอ
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีสำหรับลบแมโครจากเอกสาร PowerPoint, Excel, และ Word
{{% /alert %}} 

## **ลบ VBA Macros**

โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getVbaProject--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) คุณสามารถลบ VBA macro ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีแมโคร
1. เข้าถึงโมดูล Macro และลบออก
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดภาษา Java นี้แสดงวิธีลบ VBA macro:

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอที่มีแมโคร
Presentation pres = new Presentation("VBA.pptm");
try {
    // เข้าถึงโมดูล Vba และลบออก 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // บันทึกงานนำเสนอ
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สกัด VBA Macros**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีแมโคร
2. ตรวจสอบว่างานนำเสนอมี VBA Project หรือไม่
3. ลูปผ่านโมดูลทั้งหมดใน VBA Project เพื่อดูแมโคร

โค้ดภาษา Java นี้แสดงวิธีสกัด VBA macro จากงานนำเสนอที่มีแมโคร:

```java
import com.aspose.slides.*;

// โหลดงานนำเสนอที่มีแมโคร
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // ตรวจสอบว่างานนำเสนอมีโปรเจกต์ VBA หรือไม่
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

## **ตรวจสอบว่า VBA Project มีการตั้งรหัสผ่านหรือไม่**

โดยใช้เมธอด [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) คุณสามารถกำหนดได้ว่าโพรพีเทรีของโปรเจกต์ถูกตั้งรหัสผ่านหรือไม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอที่มีแมโคร
2. ตรวจสอบว่างานนำเสนอมี [VBA project](https://reference.aspose.com/slides/th/java/com.aspose.slides/vbaproject/) หรือไม่
3. ตรวจสอบว่า VBA project ถูกตั้งรหัสผ่านหรือไม่เพื่อดูโพรพีเทรีของมัน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // ตรวจสอบว่าการนำเสนอมีโปรเจกต์ VBA หรือไม่.
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

### เกิดอะไรขึ้นกับแมโครหากฉันบันทึกงานนำเสนอเป็น PPTX?

แมโครจะถูกลบเนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บแมโครให้เลือกใช้ PPTM, PPSM หรือ POTM

### Aspose.Slides สามารถรันแมโครภายในงานนำเสนอเพื่อเช่น รีเฟรชข้อมูลได้หรือไม่?

ไม่ได้ ไลบรารีนี้ไม่เคยทำการรันโค้ด VBA; การรันสามารถทำได้เฉพาะใน PowerPoint ที่ตั้งค่าความปลอดภัยที่เหมาะสมเท่านั้น

### การทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA ได้รับการสนับสนุนหรือไม่?

ใช่ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/java/activex/) ที่มีอยู่ ปรับเปลี่ยนคุณสมบัติของมัน และลบออกได้ ซึ่งมีประโยชน์เมื่อแมโครโต้ตอบกับ ActiveX