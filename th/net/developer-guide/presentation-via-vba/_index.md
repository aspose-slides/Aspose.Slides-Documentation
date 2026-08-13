---
title: จัดการโครงการ VBA ในงานนำเสนอด้วย .NET
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/net/presentation-via-vba/
keywords:
- มาร์โคร
- VBA
- มาร์โคร VBA
- เพิ่มมาร์โคร
- ลบมาร์โคร
- ดึงมาร์โคร
- เพิ่ม VBA
- ลบ VBA
- ดึง VBA
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **บทนำ**

เนมสเปซ [Aspose.Slides.Vba](https://reference.aspose.com/slides/th/net/aspose.slides.vba/) มีคลาสและอินเทอร์เฟซสำหรับทำงานกับมาโครและโค้ด VBA.

{{% alert title="Note" color="warning" %}} 

เมื่อคุณแปลงงานนำเสนอที่มีมาโครเป็นรูปแบบไฟล์อื่น (PDF, HTML ฯลฯ) Aspose.Slides จะละเลยมาโครทั้งหมด (มาโครจะไม่ถูกนำเข้าในไฟล์ผลลัพธ์).

เมื่อคุณเพิ่มมาโครลงในงานนำเสนอหรือบันทึกรายงานนำเสนอที่มีมาโครอีกครั้ง Aspose.Slides จะบันทึกไบต์ของมาโครเท่านั้น.

Aspose.Slides **ไม่เคย** รันมาโครในงานนำเสนอ.

{{% /alert %}}

## **เพิ่ม VBA มาโคร**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides.vba/vbaproject/) เพื่อให้คุณสร้างโครงการ VBA (และการอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้อินเทอร์เฟซ [IVbaProject](https://reference.aspose.com/slides/th/net/aspose.slides.vba/ivbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
2. ใช้คอนสตรักเตอร์ของ [VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) เพื่อเพิ่มโครงการ VBA ใหม่.
3. เพิ่มโมดูลเข้าไปใน VbaProject.
4. ตั้งค่าซอร์สโค้ดของโมดูล.
5. เพิ่มการอ้างอิงไปยัง <stdole>.
6. เพิ่มการอ้างอิงไปยัง **Microsoft Office**.
7. เชื่อมโยงการอ้างอิงกับโครงการ VBA.
8. บันทึกงานนำเสนอ.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation presentation = new Presentation())
{
    // สร้างโครงการ VBA ใหม่
    presentation.VbaProject = new VbaProject();

    // เพิ่มโมดูลเปล่าเข้าสู่โครงการ VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // ตั้งค่าซอร์สโค้ดของโมดูล
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // สร้างการอ้างอิงไปยัง <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // สร้างการอ้างอิงไปยัง Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // เพิ่มการอ้างอิงไปยังโครงการ VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // บันทึกงานนำเสนอ
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีสำหรับลบมาโครจากไฟล์ PowerPoint, Excel และ Word.

{{% /alert %}} 

## **ลบ VBA มาโคร**
โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/vbaproject/) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสามารถลบ VBA มาโครได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร.
2. เข้าถึงโมดูล Macro แล้วลบออก.
3. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// โหลดงานนำเสนอที่มีมาโคร
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // เข้าถึงโมดูล Vba และลบออก
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // บันทึกงานนำเสนอ
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **ดึง VBA มาโคร**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร.
2. ตรวจสอบว่างานนำเสนอมีโครงการ VBA หรือไม่.
3. วนลูปผ่านโมดูลทั้งหมดในโครงการ VBA เพื่อดูมาโคร.

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // โหลดงานนำเสนอที่มีมาโคร
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **ตรวจสอบว่าโครงการ VBA มีการป้องกันด้วยรหัสผ่านหรือไม่**
โดยใช้คุณสมบัติ [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/th/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) คุณสามารถตรวจสอบได้ว่าแอ็ตทริบิวต์ของโครงการถูกป้องกันด้วยรหัสผ่านหรือไม่.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร.
2. ตรวจสอบว่างานนำเสนอมี [VBA project](https://reference.aspose.com/slides/th/net/aspose.slides.vba/vbaproject/) หรือไม่.
3. ตรวจสอบว่าโครงการ VBA ถูกป้องกันด้วยรหัสผ่านหรือไม่เพื่อดูแอ็ตทริบิวต์ของมัน.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **คำถามที่พบบ่อย**

### เกิดอะไรขึ้นกับมาโครถ้าฉันบันทึกงานนำเสนอเป็น PPTX?
มาโครจะถูกลบเนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บมาโคร ให้เลือกเป็น PPTM, PPSM, หรือ POTM.

### Aspose.Slides สามารถรันมาโครภายในงานนำเสนอเพื่อเช่น การรีเฟรชข้อมูลได้หรือไม่?
ไม่ได้ ไลบรารีจะไม่เคยทำการรันโค้ด VBA; การรันโค้ดทำได้เฉพาะภายใน PowerPoint โดยต้องตั้งค่าความปลอดภัยที่เหมาะสม.

### การทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA ได้รับการสนับสนุนหรือไม่?
ใช่ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/net/activex/) ที่มีอยู่แล้ว ปรับเปลี่ยนคุณสมบัติของมัน และลบออกได้ ซึ่งมีประโยชน์เมื่อมาโครทำงานร่วมกับ ActiveX.