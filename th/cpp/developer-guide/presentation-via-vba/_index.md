---
title: จัดการโครงการ VBA ในงานนำเสนอด้วย C++
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/cpp/presentation-via-vba/
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
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ C++ เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **บทนำ**

ชื่อเนมสเปซ [Aspose.Slides.Vba](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.vba/) มีคลาสและอินเทอร์เฟซสำหรับทำงานกับมาโครและโค้ด VBA.

{{% alert title="Note" color="warning" %}} 

เมื่อคุณแปลงงานนำเสนอที่มีมาโครเป็นรูปแบบไฟล์อื่น (PDF, HTML เป็นต้น) Aspose.Slides จะละเว้นมาโครทั้งหมด (มาโครจะไม่ถูกรวมอยู่ในไฟล์ที่ได้)

เมื่อคุณเพิ่มมาโครในงานนำเสนอหรือบันทึกงานนำเสนอที่มีมาโครใหม่ Aspose.Slides จะเพียงเขียนไบต์ของมาโครลงไปเท่านั้น

Aspose.Slides **ไม่เคย** เรียกใช้มาโครในงานนำเสนอ.

{{% /alert %}}

## **เพิ่ม VBA Macros**

Aspose.Slides ให้คลาส [VbaProject](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.vba.vba_project) เพื่อให้คุณสร้างโครงการ VBA (และการอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้อินเทอร์เฟซ [IVbaProject](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.vba.i_vba_project/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation).
2. ใช้คอนสตรัคเตอร์ของ [VbaProject](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) เพื่อเพิ่มโครงการ VBA ใหม่.
3. เพิ่มโมดูลเข้าไปใน VbaProject.
4. ตั้งค่าโค้ดต้นทางของโมดูล.
5. เพิ่มการอ้างอิงไปยัง <stdole>.
6. เพิ่มการอ้างอิงไปยัง **Microsoft Office**.
7. เชื่อมโยงการอ้างอิงกับโครงการ VBA.
8. บันทึกงานนำเสนอ.

โค้ด C++ นี้แสดงวิธีเพิ่ม VBA macro ตั้งแต่เริ่มต้นลงในงานนำเสนอ: 

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// สร้างอินสแตนซ์ของคลาส Presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// สร้างโครงการ VBA ใหม่
presentation->set_VbaProject(MakeObject<VbaProject>());

// เพิ่มโมดูลเปล่าลงในโครงการ VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// ตั้งค่าโค้ดต้นฉบับของโมดูล
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// สร้างการอ้างอิงไปยัง <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// สร้างการอ้างอิงไปยัง Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// เพิ่มการอ้างอิงไปยังโครงการ VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// บันทึกงานนำเสนอ
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

คุณอาจต้องการดู **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีที่ใช้ลบมาโครจากไฟล์ PowerPoint, Excel และ Word. 

{{% /alert %}} 

## **ลบ VBA Macros**

ด้วยคุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) คุณสามารถลบ VBA macro ได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอที่มีมาโคร.
2. เข้าถึงโมดูล Macro และลบออก.
3. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด C++ นี้แสดงวิธีลบ VBA macro: 

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// โหลดงานนำเสนอที่มีมาโคร
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// เข้าถึงโมดูล Vba และลบออก 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// บันทึกงานนำเสนอ
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **ดึง VBA Macros**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอที่มีมาโคร.
2. ตรวจสอบว่างานนำเสนอมี VBA Project หรือไม่.
3. วนลูปผ่านโมดูลทั้งหมดใน VBA Project เพื่อดูมาโคร.

โค้ด C++ นี้แสดงวิธีสกัด VBA macros จากงานนำเสนอที่มีมาโคร: 

```c++

	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String templatePath = u"../templates/VBA.pptm";

	// โหลดงานนำเสนอที่มีมาโคร
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **ตรวจสอบว่า VBA Project ถูกป้องกันด้วยรหัสผ่านหรือไม่**

ด้วยคุณสมบัติ [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/th/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) คุณสามารถตรวจสอบได้ว่าคุณสมบัติโครงการถูกป้องกันด้วยรหัสผ่านหรือไม่.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร.
2. ตรวจสอบว่างานนำเสนอมี [VBA project](https://reference.aspose.com/slides/th/cpp/aspose.slides.vba/vbaproject/) หรือไม่.
3. ตรวจสอบว่า VBA project ถูกป้องกันด้วยรหัสผ่านเพื่อดูคุณสมบัติของมันหรือไม่.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**อะไรจะเกิดขึ้นกับมาโครถ้าฉันบันทึกงานนำเสนอเป็น PPTX?**

มาโครจะถูกลบเนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บมาโครให้เลือกใช้ PPTM, PPSM หรือ POTM.

**Aspose.Slides สามารถรันมาโครภายในงานนำเสนอได้หรือไม่ เช่น เพื่อรีเฟรชข้อมูล?**

ไม่ครับ ไลบรารีไม่เคยรันโค้ด VBA; การรันโค้ดทำได้เฉพาะภายใน PowerPoint ที่ตั้งค่าความปลอดภัยที่เหมาะสมเท่านั้น.

**การทำงานกับ ActiveX control ที่เชื่อมโยงกับโค้ด VBA ได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/cpp/activex/) ที่มีอยู่, แก้ไขคุณสมบัติของพวกมันและลบออกได้ ซึ่งเป็นประโยชน์เมื่อมาโครโต้ตอบกับ ActiveX.