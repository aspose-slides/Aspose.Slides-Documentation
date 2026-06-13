---
title: ป้องกันการแก้ไขงานนำเสนอด้วยการล็อกรูปทรง
linktitle: ป้องกันการแก้ไขงานนำเสนอ
type: docs
weight: 10
url: /th/cpp/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันจากการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides for C++ ล็อกหรือปลดล็อกรูปทรงในไฟล์ PPT, PPTX และ ODP อย่างไร เพื่อความปลอดภัยของงานนำเสนอพร้อมอนุญาตการแก้ไขที่ควบคุมได้และการส่งมอบที่รวดเร็วขึ้น"
---
## **พื้นหลัง**

การใช้ Aspose.Slides อย่างทั่วไปคือการสร้าง, อัปเดต, และบันทึกงานนำเสนอ Microsoft PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ ผู้ใช้แอปพลิเคชันที่ใช้ Aspose.Slides ด้วยวิธีนี้จะเข้าถึงงานนำเสนอที่สร้างขึ้นได้ ดังนั้นการป้องกันไม่ให้แก้ไขจึงเป็นความกังวลทั่วไป สิ่งสำคัญคือนำเสนอที่สร้างโดยอัตโนมัติต้องรักษารูปแบบและเนื้อหาเดิมไว้

บทความนี้อธิบายว่าโครงสร้างของงานนำเสนอและสไลด์เป็นอย่างไรและ Aspose.Slides for C++ สามารถใช้การป้องกันกับงานนำเสนอและลบการป้องกันนั้นออกได้อย่างไร มันให้วิธีการแก่ผู้พัฒนาในการควบคุมการใช้งานนำเสนอที่แอปพลิเคชันของพวกเขาสร้างขึ้น

## **โครงสร้างของสไลด์**

สไลด์ของงานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for C++ แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจ็กต์ที่ทำการ implements อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

โครงสร้างของ PPTX มีความซับซ้อน ดังนั้นแตกต่างจาก PPT ที่สามารถใช้ lock ทั่วไปกับรูปทรงทุกประเภทได้ รูปทรงแต่ละประเภทต้องการ lock ที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseshapelock/) เป็นคลาสการล็อกทั่วไปสำหรับ PPTX ประเภทของ lock ต่อไปนี้ได้รับการสนับสนุนใน Aspose.Slides for C++ สำหรับ PPTX:
- [IAutoShapeLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshapelock/) ล็อก autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/iconnectorlock/) ล็อก connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/igraphicalobjectlock/) ล็อก graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/igroupshapelock/) ล็อก group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/) ล็อก picture frames.   

การกระทำใด ๆ ที่ทำบนอ็อบเจ็กต์ shape ทั้งหมดในอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) จะถูกนำไปใช้กับงานนำเสนอทั้งหมด

## **ใช้และลบการป้องกัน**

การใช้การป้องกันจะทำให้แน่ใจว่างานนำเสนอไม่สามารถแก้ไขได้ นี่เป็นเทคนิคที่มีประโยชน์ในการปกป้องเนื้อหาของงานนำเสนอ

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for C++ ให้อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) เพื่อทำงานกับ shape บนสไลด์

ตามที่ได้กล่าวไว้ก่อนหน้านี้แต่ละคลาส shape มีคลาส shape‑lock ที่สัมพันธ์กันสำหรับการป้องกัน บทความนี้มุ่งเน้นที่ lock NoSelect, NoMove, และ NoResize lock เหล่านี้ทำให้ shape ไม่สามารถเลือก (โดยการคลิกเมาส์หรือวิธีการเลือกอื่น) และไม่สามารถย้ายหรือปรับขนาดได้

ตัวอย่างโค้ดต่อไปนี้ใช้การป้องกันกับทุกประเภทของ shape ในงานนำเสนอ

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// วนผ่านสไลด์ทั้งหมดในงานนำเสนอ.
for (auto&& slide : presentation->get_Slides())	{

	// วนผ่านรูปทรงทั้งหมดในสไลด์.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// แปลงประเภทของรูปร่างเป็น autoshape และดึง shape lock ของมัน.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// แปลงประเภทของรูปร่างเป็น group shape และดึง shape lock ของมัน.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// แปลงประเภทของรูปร่างเป็น connector shape และดึง shape lock ของมัน.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// แปลงประเภทของรูปร่างเป็น picture frame และดึง shape lock ของมัน.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// บันทึกไฟล์งานนำเสนอ.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **ลบการป้องกัน**

เพื่อปลดล็อก shape ให้ตั้งค่าของ lock ที่ใช้งานเป็น `false` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปลดล็อก shape ในงานนำเสนอที่ถูกล็อก

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// วนผ่านสไลด์ทั้งหมดในงานนำเสนอ.
for (auto&& slide : presentation->get_Slides())	{

	// วนผ่านรูปทรงทั้งหมดในสไลด์.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// แปลงประเภทของรูปร่างเป็น autoshape และดึง shape lock ของมัน.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// แปลงประเภทของรูปร่างเป็น group shape และดึง shape lock ของมัน.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// แปลงประเภทของรูปร่างเป็น connector shape และดึง shape lock ของมัน.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// แปลงประเภทของรูปร่างเป็น picture frame และดึง shape lock ของมัน.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// บันทึกไฟล์งานนำเสนอ.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สรุป**

Aspose.Slides มีตัวเลือกหลายอย่างสำหรับการป้องกัน shape ในงานนำเสนอ คุณสามารถล็อก shape เดียวหรือวนรอบทุก shape ในงานนำเสนอและล็อกแต่ละอันเพื่อปกป้องไฟล์ทั้งหมดได้อย่างมีประสิทธิภาพ คุณสามารถลบการป้องกันโดยตั้งค่าของ lock เป็น `false`

## **คำถามที่พบบ่อย**

**ฉันสามารถรวม shape locks กับการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้. Locks จำกัดการแก้ไขอ็อบเจ็กต์ภายในไฟล์ในขณะที่ [password protection](/slides/th/cpp/password-protected-presentation/) ควบคุมการเข้าถึงการเปิดและ/หรือการบันทึกการเปลี่ยนแปลง กลไกเหล่านี้ทำงานเสริมกันและทำงานร่วมกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่นได้หรือไม่?**

ได้. ใช้ locks กับ shape บนสไลด์ที่เลือก; สไลด์ที่เหลือจะยังคงสามารถแก้ไขได้

**shape locks ใช้กับอ็อบเจ็กต์ที่จัดกลุ่มและ connectors หรือไม่?**

ได้. มีประเภท lock เฉพาะสำหรับกลุ่ม, connectors, graphic objects, และรูปแบบ shape อื่น ๆ