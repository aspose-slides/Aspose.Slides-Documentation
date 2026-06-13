---
title: จัดการโครงการ VBA ในงานนำเสนอโดยใช้ Java
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ Java เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **บทนำ**

Aspose.Slides มีคลาสและอินเทอร์เฟซสำหรับทำงานกับมาโครและโค้ด VBA.

{{% alert title="Note" color="warning" %}} 

เมื่อคุณแปลงงานนำเสนอที่มีมาโครเป็นรูปแบบไฟล์อื่น (PDF, HTML, เป็นต้น) Aspose.Slides จะละเว้นมาโครทั้งหมด (มาโครจะไม่ถูกรวมไว้ในไฟล์ผลลัพธ์).

เมื่อคุณเพิ่มมาโครเข้าไปในงานนำเสนอหรือบันทึกงานนำเสนอที่มีมาโครใหม่ Aspose.Slides จะเพียงเขียนไบต์ของมาโครเท่านั้น.

Aspose.Slides **ไม่เคย** รันมาโครในงานนำเสนอ.

{{% /alert %}}

## **เพิ่ม VBA มาโคร**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/vbaproject/) เพื่อให้คุณสร้างโครงการ VBA (และอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้อินเทอร์เฟซ [IVbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. ใช้คอนสตรักเตอร์ [VbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/vbaproject/#VbaProject--) เพื่อเพิ่มโครงการ VBA ใหม่.
1. เพิ่มโมดูลเข้าสู่ VbaProject.
1. ตั้งค่าโค้ดต้นฉบับของโมดูล.
1. เพิ่มการอ้างอิงไปยัง <stdole>.
1. เพิ่มการอ้างอิงไปยัง **Microsoft Office**.
1. เชื่อมโยงการอ้างอิงกับโครงการ VBA.
1. บันทึกงานนำเสนอ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // สร้างโครงการ VBA ใหม่
    pres.setVbaProject(new VbaProject());
    
    // เพิ่มโมดูลเปล่าเข้าสู่โครงการ VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // ตั้งค่าซอร์สโค้ดของโมดูล
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // สร้างการอ้างอิงถึง <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // สร้างการอ้างอิงถึง Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // เพิ่มการอ้างอิงเข้าสู่โครงการ VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // บันทึกงานนำเสนอ
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

คุณอาจต้องการดู **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีที่ใช้ในการลบมาโครจากไฟล์ PowerPoint, Excel และ Word.

{{% /alert %}} 

## **ลบ VBA มาโคร**

โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getVbaProject--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) คุณสามารถลบมาโคร VBA ได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีมาโคร.
1. เข้าถึงโมดูล Macro และลบออก.
1. บันทึกงานนำเสนอที่แก้ไขแล้ว.

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

## **ดึง VBA มาโคร**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มีมาโคร.
2. ตรวจสอบว่ามงานนำเสนอมี VBA Project หรือไม่.
3. วนลูปผ่านทุกโมดูลที่อยู่ใน VBA Project เพื่อดูมาโคร.

```java
// โหลดงานนำเสนอที่มีมาโคร
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่
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

โดยใช้เมธอด [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) คุณสามารถกำหนดได้ว่าคุณสมบัติของโครงการถูกป้องกันด้วยรหัสผ่านหรือไม่.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร.
2. ตรวจสอบว่าภาพนำเสนอมี [VBA project](https://reference.aspose.com/slides/th/java/com.aspose.slides/vbaproject/) หรือไม่.
3. ตรวจสอบว่า VBA project ถูกป้องกันด้วยรหัสผ่านหรือไม่เพื่อดูคุณสมบัติของมัน.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**จะเกิดอะไรขึ้นกับมาโครหากฉันบันทึกงานนำเสนอเป็น PPTX?**

มาโครจะถูกลบเพราะ PPTX ไม่รองรับ VBA หากต้องการเก็บมาโครไว้ ให้เลือก PPTM, PPSM หรือ POTM.

**Aspose.Slides สามารถรันมาโครภายในงานนำเสนอเพื่อเช่น การรีเฟรชข้อมูลได้หรือไม่?**

ไม่ได้ ไลบรารีไม่มีการรันโค้ด VBA เลย การดำเนินการทำได้เฉพาะใน PowerPoint พร้อมการตั้งค่าความปลอดภัยที่เหมาะสม.

**การทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA รองรับหรือไม่?**

ใช่ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/java/activex/) ที่มีอยู่ ปรับเปลี่ยนคุณสมบัติของมัน และลบออกได้ สิ่งนี้มีประโยชน์เมื่อมาโครโต้ตอบกับ ActiveX.