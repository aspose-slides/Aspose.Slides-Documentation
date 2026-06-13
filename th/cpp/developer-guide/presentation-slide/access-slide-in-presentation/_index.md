---
title: เข้าถึงสไลด์การนำเสนอใน C++
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/cpp/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ไอดีสไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++. เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีการดึงสไลด์ตามตำแหน่งที่เริ่มจากศูนย์จากคอลเลกชันสไลด์และวิธีการเข้าถึงสไลด์โดยใช้ ID เฉพาะด้วยเมธอด `GetSlideById`  

คุณจะได้เรียนรู้วิธีการเปลี่ยนตำแหน่งของสไลด์โดยใช้เมธอด `set_SlideNumber` และวิธีการกำหนดหมายเลขสไลด์เริ่มต้นของงานนำเสนอด้วยเมธอด `set_FirstSlideNumber` ตัวอย่างจะแสดงการโหลดงานนำเสนอ การอ้างอิงสไลด์ การปรับลำดับหรือหมายเลขสไลด์ และการบันทึกงานนำเสนอที่แก้ไขแล้ว  

## **เข้าถึงสไลด์โดยใช้ดัชนี**

สไลด์ทั้งหมดในงานนำเสนอจะเรียงลำดับตามตำแหน่งสไลด์โดยเริ่มจาก 0 สไลด์แรกเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองเข้าถึงผ่านดัชนี 1; เป็นต้น  

คลาส Presentation ซึ่งเป็นตัวแทนไฟล์งานนำเสนอ เปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) (คอลเลกชันของอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/)) โค้ด C++ นี้แสดงวิธีเข้าถึงสไลด์ผ่านดัชนีของมัน:  

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String templatePath = u"../templates/AddSlides.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// รับอ้างอิงสไลด์ผ่านดัชนีของมัน
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **เข้าถึงสไลด์โดยใช้ ID**

แต่ละสไลด์ในงานนำเสนอมี ID ที่เป็นเอกลักษณ์ คุณสามารถใช้เมธอด [GetSlideById()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/getslidebyid/) (ซึ่งเปิดโดยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)) เพื่อระบุ ID นั้น โค้ด C++ นี้แสดงวิธีให้ค่า ID ของสไลด์ที่ถูกต้องและเข้าถึงสไลด์ผ่านเมธอด [GetSlideById()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/getslidebyid/):  

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String templatePath = u"../templates/AddSlides.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// รับ ID ของสไลด์
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// เข้าถึงสไลด์ผ่าน ID ของมัน
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides อนุญาตให้คุณเปลี่ยนตำแหน่งสไลด์ ตัวอย่างเช่น คุณสามารถระบุให้สไลด์แรกกลายเป็นสไลด์ที่สอง  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ (ตำแหน่งที่ต้องการเปลี่ยน) ผ่านดัชนีของมัน  
1. ตั้งค่าตำแหน่งใหม่ให้สไลด์ผ่านคุณสมบัติ [set_SlideNumber()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/set_slidenumber/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้แสดงการทำงานที่สไลด์ในตำแหน่ง 1 ถูกย้ายไปยังตำแหน่ง 2:  

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// สร้างอินสแตนซ์ของคลาส Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// รับสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// ตั้งค่าตำแหน่งใหม่ให้สไลด์
	slide->set_SlideNumber(2);

	// บันทึกงานนำเสนอที่แก้ไขแล้ว
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่น ๆ จะปรับตำแหน่งโดยอัตโนมัติ  

## **กำหนดหมายเลขสไลด์**

โดยใช้คุณสมบัติ [set_FirstSlideNumber()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/set_firstslidenumber/) (เปิดโดยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)) คุณสามารถระบุหมายเลขใหม่สำหรับสไลด์แรกในงานนำเสนอ การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่น ๆ ถูกคำนวณใหม่  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. รับหมายเลขสไลด์  
1. ตั้งค่าหมายเลขสไลด์  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้แสดงการตั้งค่าหมายเลขสไลด์แรกเป็น 10:  

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//สร้างอินสแตนซ์ของคลาส Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// รับหมายเลขสไลด์
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// ตั้งค่าหมายเลขสไลด์
	pres->set_FirstSlideNumber(2);
	
	// บันทึกงานนำเสนอที่แก้ไขแล้ว
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

หากต้องการข้ามสไลด์แรก คุณสามารถเริ่มนับหมายเลขจากสไลด์ที่สอง (และซ่อนการแสดงหมายเลขสำหรับสไลด์แรก) ได้ดังนี้:  

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีที่เริ่มจากศูนย์ของคอลเลกชันหรือไม่?**  

หมายเลขที่แสดงบนสไลด์สามารถเริ่มจากค่าที่กำหนดเอง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/set_firstslidenumber/) ของงานนำเสนอ  

**สไลด์ที่ถูกซ่อนมีผลต่อการจัดทำดัชนีหรือไม่?**  

ใช่ สไลด์ที่ถูกซ่อนยังคงอยู่ในคอลเลกชันและนับเข้าระบบดัชนี; “ซ่อน” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน  

**ดัชนีของสไลด์จะเปลี่ยนเมื่อสไลด์อื่นถูกเพิ่มหรือเลิกใช้งานหรือไม่?**  

ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและจะคำนวณใหม่เมื่อมีการแทรก, ลบ หรือย้ายสไลด์  