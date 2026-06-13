---
title: จัดการโครงการ VBA ในงานนำเสนอโดยใช้ JavaScript
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย JavaScript โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **บทนำ**

Aspose.Slides มีคลาสสำหรับทำงานกับแมโครและโค้ด VBA.

{{% alert title="หมายเหตุ" color="warning" %}} 

เมื่อคุณแปลงงานนำเสนอที่มีแมโครเป็นรูปแบบไฟล์อื่น (PDF, HTML, ฯลฯ) Aspose.Slides จะละเลยแมโครทั้งหมด (แมโครจะไม่ถูกนำไปยังไฟล์ผลลัพธ์)

เมื่อคุณเพิ่มแมโครลงในงานนำเสนอหรือบันทึกงานนำเสนอที่มีแมโครใหม่ Aspose.Slides จะเขียนไบต์ของแมโครเท่านั้น

Aspose.Slides **ไม่เคย** รันแมโครในงานนำเสนอ

{{% /alert %}}

## **เพิ่ม VBA แมโคร**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/vbaproject/) เพื่อให้คุณสร้างโครงการ VBA (และการอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้คลาส [VbaProject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/vbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
1. ใช้ตัวสร้างของ [VbaProject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/vbaproject/#VbaProject--) เพื่อเพิ่มโครงการ VBA ใหม่ 
1. เพิ่มโมดูลลงใน VbaProject 
1. ตั้งค่าซอร์สโค้ดของโมดูล 
1. เพิ่มการอ้างอิงไปยัง <stdole> 
1. เพิ่มการอ้างอิงไปยัง **Microsoft Office** 
1. เชื่อมโยงการอ้างอิงกับโครงการ VBA 
1. บันทึกงานนำเสนอ

โค้ด JavaScript นี้แสดงวิธีการเพิ่ม VBA แมโครจากศูนย์ลงในงานนำเสนอ:

```javascript
// สร้างอินสแตนซ์ของคลาสงานนำเสนอ
let pres = new aspose.slides.Presentation();
try {
    // สร้างโครงการ VBA ใหม่
    pres.setVbaProject(new aspose.slides.VbaProject());
    // เพิ่มโมดูลว่างลงในโครงการ VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // ตั้งค่าซอร์สโค้ดของโมดูล
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // สร้างการอ้างอิงถึง <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // สร้างการอ้างอิงถึง Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // เพิ่มการอ้างอิงลงในโครงการ VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // บันทึกงานนำเสนอ
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีสำหรับลบแมโครจากเอกสาร PowerPoint, Excel และ Word 

{{% /alert %}} 

## **ลบ VBA แมโคร**

โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getVbaProject--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) คุณสามารถลบแมโคร VBA ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดงานนำเสนอที่มีแมโคร 
1. เข้าถึงโมดูล Macro และลบออก 
1. บันทึกงานนำเสนอที่แก้ไขแล้ว 

โค้ด JavaScript นี้แสดงวิธีการลบแมโคร VBA:

```javascript
// โหลดงานนำเสนอที่มีแมโคร
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // เข้าถึงโมดูล Vba และลบออก
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // บันทึกงานนำเสนอ
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สกัด VBA แมโคร**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดงานนำเสนอที่มีแมโคร 
2. ตรวจสอบว่างานนำเสนอมีโครงการ VBA หรือไม่ 
3. วนลูปผ่านโมดูลทั้งหมดในโครงการ VBA เพื่อดูแมโคร 

โค้ด JavaScript นี้แสดงวิธีการสกัดแมโคร VBA จากงานนำเสนอที่มีแมโคร:

```javascript
// โหลดงานนำเสนอที่มีแมโคร
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // ตรวจสอบว่างานนำเสนอมีโครงการ VBA หรือไม่
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตรวจสอบว่าโครงการ VBA ถูกตั้งรหัสผ่านหรือไม่**

โดยใช้เมธอด [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) คุณสามารถกำหนดได้ว่าโครงการนั้นมีการป้องกันด้วยรหัสผ่านหรือไม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีแมโคร 
2. ตรวจสอบว่างานนำเสนอมี [VBA project](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/vbaproject/) หรือไม่ 
3. ตรวจสอบว่าโครงการ VBA ถูกตั้งรหัสผ่านหรือไม่เพื่อดูคุณสมบัติต่าง ๆ 

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // ตรวจสอบว่างานนำมีโครงการ VBA หรือไม่.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**อะไรจะเกิดขึ้นกับแมโครหากฉันบันทึกงานนำเสนอเป็น PPTX?**

แมโครจะถูกลบเนื่องจาก PPTX ไม่รองรับ VBA. หากต้องการเก็บแมโคร ให้เลือก PPTM, PPSM หรือ POTM

**Aspose.Slides สามารถรันแมโครภายในงานนำเสนอเพื่อเช่น การรีเฟรชข้อมูลได้หรือไม่?**

ไม่ได้. ไลบรารีจะไม่ทำการรันโค้ด VBA; การรันจะทำได้เฉพาะใน PowerPoint ที่ตั้งค่าความปลอดภัยที่เหมาะสม

**การทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA ได้รับการสนับสนุนหรือไม่?**

ใช่, คุณสามารถเข้าถึง [ActiveX controls](/slides/th/nodejs-java/activex/) ที่มีอยู่, แก้ไขคุณสมบัติของมัน, และลบออกได้. สิ่งนี้เป็นประโยชน์เมื่อแมโครทำงานกับ ActiveX