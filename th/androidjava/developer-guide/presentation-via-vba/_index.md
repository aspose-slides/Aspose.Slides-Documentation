---
title: จัดการโปรเจกต์ VBA ในงานนำเสนอบน Android
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/androidjava/presentation-via-vba/
keywords:
- มาโคร
- VBA
- มาโคร VBA
- เพิ่มมาโคร
- ลบมาโคร
- ดึงมาโคร
- เพิ่ม VBA
- ลบ VBA
- ดึง VBA
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบและมีประสิทธิภาพ"
---
## **คำนำ**

Aspose.Slides ให้คลาสและอินเทอร์เฟซสำหรับการทำงานกับมาโครและโค้ด VBA

{{% alert title="Note" color="warning" %}} 
เมื่อคุณแปลงงานนำเสนอที่มีมาโครเป็นรูปแบบไฟล์อื่น (PDF, HTML, ฯลฯ) Aspose.Slides จะละเว้นมาโครทั้งหมด (มาโครจะไม่ถูกรวมเข้าในไฟล์ผลลัพธ์)

เมื่อคุณเพิ่มมาโครลงในงานนำเสนอหรือบันทึกงานนำเสนอที่มีมาโครใหม่ Aspose.Slides จะเพียงแค่เขียนไบต์ของมาโครลงไป

Aspose.Slides **ไม่เคย** รันมาโครในงานนำเสนอ
{{% /alert %}}

## **เพิ่ม VBA Macros**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/vbaproject/) เพื่อให้คุณสร้างโปรเจกต์ VBA (และการอ้างอิงโปรเจกต์) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้อินเทอร์เฟซ [IVbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. ใช้คอนสตรัคเตอร์ [VbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/vbaproject/#VbaProject--) เพื่อเพิ่มโปรเจกต์ VBA ใหม่
1. เพิ่มโมดูลลงใน VbaProject
1. ตั้งค่าซอร์สโค้ดของโมดูล
1. เพิ่มการอ้างอิงไปยัง <stdole>
1. เพิ่มการอ้างอิงไปยัง **Microsoft Office**
1. ผสานการอ้างอิงเข้ากับโปรเจกต์ VBA
1. บันทึกงานนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีการเพิ่มมาโคร VBA ตั้งแต่ต้นลงในงานนำเสนอ:

```java
// สร้างอินสแตนซ์ของคลาสงานนำเสนอ
Presentation pres = new Presentation();
try {
    // สร้าง VBA Project ใหม่
    pres.setVbaProject(new VbaProject());
    
    // เพิ่มโมดูลเปล่าลงใน VBA project
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // ตั้งค่าซอร์สโค้ดของโมดูล
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // สร้างการอ้างอิงถึง <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // สร้างการอ้างอิงถึง Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // เพิ่มการอ้างอิงลงใน VBA project
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // บันทึกงานนำเสนอ
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีที่ใช้ลบมาโครจากไฟล์ PowerPoint, Excel และ Word  
{{% /alert %}} 

## **ลบ VBA Macros**

โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getVbaProject--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) คุณสามารถลบมาโคร VBA ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีมาโคร
1. เข้าถึงโมดูล Macro และลบออก
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java ต่อไปนี้แสดงวิธีการลบมาโคร VBA:

```java
// โหลดงานนำเสนอที่มีมาโคร
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

## **ดึง VBA Macros**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีมาโคร
2. ตรวจสอบว่ามี VBA Project อยู่หรือไม่
3. วนลูปผ่านโมดูลทั้งหมดใน VBA Project เพื่อดูมาโคร

โค้ด Java ต่อไปนี้แสดงวิธีการดึง VBA macros จากงานนำเสนอที่มีมาโคร:

```java
// โหลดงานนำเสนอที่มีมาโคร
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // ตรวจสอบว่างานนำเสนอมี VBA Project หรือไม่
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

## **ตรวจสอบว่า VBA Project มีการป้องกันด้วยรหัสผ่านหรือไม่**

โดยใช้เมธอด [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) คุณสามารถตรวจสอบได้ว่าโปรเจกต์ถูกป้องกันด้วยรหัสผ่านหรือไม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร
2. ตรวจสอบว่ามี [VBA project](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/vbaproject/) อยู่หรือไม่
3. ตรวจสอบว่า VBA project ถูกป้องกันด้วยรหัสผ่านหรือไม่เพื่อดูคุณสมบัติของมัน

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // ตรวจสอบว่างานนำเสนอมีโปรเจกต์ VBA หรือไม่.
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

**จะเกิดอะไรขึ้นกับมาโครถ้าฉันบันทึกงานนำเสนอเป็น PPTX?**

มาโครจะถูกลบออกเพราะ PPTX ไม่รองรับ VBA หากต้องการเก็บมาโครให้ใช้รูปแบบ PPTM, PPSM หรือ POTM

**Aspose.Slides สามารถรันมาโครในงานนำเสนอเพื่อทำอย่างเช่นรีเฟรชข้อมูลได้หรือไม่?**

ไม่ได้ ไลบรารีไม่เคยดำเนินการโค้ด VBA; การทำงานของ VBA เป็นไปได้เฉพาะใน PowerPoint โดยมีการตั้งค่าความปลอดภัยที่เหมาะสมเท่านั้น

**การทำงานกับ ActiveX control ที่เชื่อมโยงกับโค้ด VBA ได้รับการสนับสนุนหรือไม่?**

ได้ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/androidjava/activex/) ที่มีอยู่แล้ว, ปรับเปลี่ยนคุณสมบัติและลบออกได้ ซึ่งเป็นประโยชน์เมื่อมาโครโต้ตอบกับ ActiveX  