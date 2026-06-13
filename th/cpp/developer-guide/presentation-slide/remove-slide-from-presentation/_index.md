---
title: ลบสไลด์จากงานนำเสนอใน C++
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/cpp/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ลบสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++. รับตัวอย่างโค้ดที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **คำนำ**

หากสไลด์ (หรือเนื้อหาในสไลด์) กลายเป็นข้อมูลซ้ำซ้อน คุณสามารถลบออกได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่ห่อหุ้ม [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) ซึ่งเป็นคลังเก็บสไลด์ทั้งหมดในงานนำเสนอ โดยใช้ตัวชี้ (อ้างอิงหรือดัชนี) ของอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ที่ทราบ คุณสามารถระบุสไลด์ที่ต้องการลบได้

## **ลบสไลด์โดยอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ที่ต้องการลบผ่าน ID หรือ Index ของสไลด์นั้น  
1. ลบสไลด์ที่อ้างอิงไว้จากงานนำเสนอ  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ ด้านล่างแสดงวิธีการลบสไลด์โดยอ้างอิง:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// สร้างอ็อบเจกต์ Presentation ซึ่งแสดงไฟล์งานนำเสนอ
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// เข้าถึงสไลด์ผ่านดัชนีในคอลเลกชันของสไลด์
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// ลบสไลด์ผ่านอ้างอิงของมัน
	pres->get_Slides()->Remove(slide);

	// บันทึกงานนำเสนอที่แก้ไขแล้ว
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ลบสไลด์โดยดัชนี**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. ลบสไลด์จากงานนำเสนอผ่านตำแหน่งดัชนีของสไลด์นั้น  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ ด้านล่างแสดงวิธีการลบสไลด์โดยดัชนี:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// สร้างอ็อบเจกต์ Presentation ซึ่งแสดงไฟล์งานนำเสนอ
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// ลบสไลด์ผ่านดัชนีของสไลด์
	pres->get_Slides()->RemoveAt(0);

	// บันทึกงานนำเสนอที่แก้ไขแล้ว
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ลบ Layout Slides ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (จากคลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/)) เพื่อให้คุณลบ Layout Slides ที่ไม่ต้องการและไม่ได้ใช้ โค้ด C++ ด้านล่างแสดงวิธีการลบ Layout Slide จากงานนำเสนอ PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **ลบ Master Slides ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (จากคลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/)) เพื่อให้คุณลบ Master Slides ที่ไม่ต้องการและไม่ได้ใช้ โค้ด C++ ด้านล่างแสดงวิธีการลบ Master Slide จากงานนำเสนอ PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**เกิดอะไรขึ้นกับดัชนีสไลด์หลังจากที่ฉันลบสไลด์?**

หลังจากการลบ, [collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidecollection/) จะทำการจัดดัชนีใหม่: สไลด์ต่อไปทุกสไลด์จะเลื่อนตำแหน่งซ้ายหนึ่งตำแหน่ง ทำให้หมายเลขดัชนีก่อนหน้าล้าสมัย หากคุณต้องการอ้างอิงที่คงที่ ให้ใช้ ID ถาวรของสไลด์แทนดัชนี

**ID ของสไลด์ต่างจากดัชนีหรือไม่ และมันเปลี่ยนแปลงเมื่อสไลด์ใกล้เคียงถูกลบหรือไม่?**

ใช่ ดัชนีเป็นตำแหน่งของสไลด์และจะเปลี่ยนแปลงเมื่อมีการเพิ่มหรือลบสไลด์ ส่วน ID ของสไลด์เป็นตัวระบุถาวรและจะไม่เปลี่ยนแปลงเมื่อสไลด์อื่นถูกลบ

**การลบสไลด์ส่งผลต่อ Section ของสไลด์อย่างไร?**

หากสไลด์เป็นส่วนหนึ่งของ Section, Section นั้นจะมีสไลด์น้อยลงหนึ่งสไลด์ โครงสร้างของ Section จะคงอยู่; หาก Section ว่างเปล่า คุณสามารถ [remove or reorganize sections](/slides/th/cpp/slide-section/) ตามต้องการ

**บันทึกและความคิดเห็นที่แนบกับสไลด์จะเกิดอะไรขึ้นเมื่อสไลด์นั้นถูกลบ?**

[Notes](/slides/th/cpp/presentation-notes/) และ [comments](/slides/th/cpp/presentation-comments/) ถูกผูกไว้กับสไลด์นั้นและจะถูกลบพร้อมกับสไลด์ เนื้อหาในสไลด์อื่นจะไม่ได้รับผลกระทบ

**การลบสไลด์ต่างจากการทำความสะอาด Layout/Master ที่ไม่ได้ใช้อย่างไร?**

การลบจะเอาสไลด์ปกติที่ต้องการออกจากชุดสไลด์ ส่วนการทำความสะอาด Layout/Master ที่ไม่ได้ใช้จะลบ Layout หรือ Master Slides ที่ไม่มีอ้างอิงใด ๆ อยู่ ลดขนาดไฟล์โดยไม่กระทบเนื้อหาสไลด์ที่เหลือ การดำเนินการทั้งสองจึงเสริมกัน: ปกติให้ลบสไลด์ก่อน แล้วจึงทำความสะอาด Layout/Master ที่ไม่ได้ใช้.