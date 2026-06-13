---
title: จัดการโครงการ VBA ในพรีเซนเทชันด้วย .NET
linktitle: การนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/net/presentation-via-vba/
keywords:
- มาโคร
- VBA
- มาโคร VBA
- เพิ่มมาโคร
- ลบมาโคร
- สกัดมาโคร
- เพิ่ม VBA
- ลบ VBA
- สกัด VBA
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการพรีเซนเทชัน PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **คำนำ**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/th/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **เพิ่ม VBA มาโคร**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/th/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) .
2. ใช้คอนสตรักเตอร์ของ [VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) เพื่อเพิ่มโปรเจกต์ VBA ใหม่.
3. เพิ่มโมดูลเข้าไปใน VbaProject.
4. ตั้งค่าซอร์สโค้ดของโมดูล.
5. เพิ่มการอ้างอิงไปยัง <stdole>.
6. เพิ่มการอ้างอิงไปยัง **Microsoft Office**.
7. เชื่อมโยงการอ้างอิงกับโปรเจกต์ VBA.
8. บันทึกพรีเซนเทชัน.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
    // สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation presentation = new Presentation())
{
    // สร้าง VBA Project ใหม่
    presentation.VbaProject = new VbaProject();

    // เพิ่มโมดูลว่างลงใน VBA project
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // ตั้งค่าซอร์สโค้ดของโมดูล
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // สร้างการอ้างอิงไปยัง <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // สร้างการอ้างอิงไปยัง Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // เพิ่มการอ้างอิงไปยัง VBA project
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // บันทึกพรีเซนเทชัน
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **ลบ VBA มาโคร**
Using the [VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/vbaproject/) property under the [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และโหลดพรีเซนเทชันที่มีมาโคร.
2. เข้าถึงโมดูล Macro แล้วลบออก.
3. บันทึกพรีเซนเทชันที่แก้ไขแล้ว.

This C# code shows you how to remove a VBA macro:

```c#
    // โหลดพรีเซนเทชันที่มีมาโคร
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // เข้าถึงโมดูล Vba และลบออก 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // บันทึกพรีเซนเทชัน
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **สกัด VBA มาโคร**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และโหลดพรีเซนเทชันที่มีมาโคร.
2. ตรวจสอบว่าพรีเซนเทชันมี VBA Project หรือไม่.
3. วนลูปผ่านโมดูลทั้งหมดที่อยู่ใน VBA Project เพื่อดูมาโคร.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
    // โหลดพรีเซนเทชันที่มีมาโคร
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // ตรวจสอบว่าพรีเซนเทชันมี VBA Project หรือไม่
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **ตรวจสอบว่า VBA Project ถูกป้องกันด้วยรหัสผ่านหรือไม่**

Using the [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/th/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และโหลดพรีเซนเทชันที่มีมาโคร.
2. ตรวจสอบว่าพรีเซนเทชันมี [VBA project](https://reference.aspose.com/slides/th/net/aspose.slides.vba/vbaproject/) หรือไม่.
3. ตรวจสอบว่า VBA project ถูกป้องกันด้วยรหัสผ่านเพื่อดูโพรพอร์ตีของมัน.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // ตรวจสอบว่าพรีเซนเทชันมีโปรเจกต์ VBA หรือไม่.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **คำถามที่พบบ่อย**

**จะเกิดอะไรขึ้นกับมาโครหากฉันบันทึกพรีเซนเทชันเป็น PPTX?**

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

**Aspose.Slides สามารถรันมาโครภายในพรีเซนเทชันเพื่อเช่น ทำให้ข้อมูลรีเฟรชได้หรือไม่?**

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

**รองรับการทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA หรือไม่?**

Yes, you can access existing [ActiveX controls](/slides/th/net/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.