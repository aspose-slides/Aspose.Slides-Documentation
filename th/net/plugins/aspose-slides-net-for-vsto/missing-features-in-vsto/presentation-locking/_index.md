---
title: การล็อกการนำเสนอ
type: docs
weight: 110
url: /th/net/presentation-locking/
---
## **การล็อกการนำเสนอ**
การใช้ทั่วไปของ **Aspose.Slides** คือการสร้าง, ปรับปรุง และบันทึกการนำเสนอ Microsoft PowerPoint 2007 (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ ผู้ใช้แอปพลิเคชันที่ใช้ Aspose.Slides แบบนี้จะได้รับการเข้าถึงการนำเสนอผลลัพธ์ การปกป้องไม่ให้มีการแก้ไขเป็นความกังวลทั่วไป สิ่งสำคัญคือการนำเสนอที่สร้างโดยอัตโนมัติต้องรักษารูปแบบและเนื้อหาต้นฉบับไว้

นี่อธิบายว่าการนำเสนอและสไลด์ถูกสร้างอย่างไรและ Aspose.Slides for .NET สามารถใช้การปกป้องและจากนั้นลบออกจากการนำเสนอได้อย่างไร คุณลักษณะนี้เป็นเอกลักษณ์ของ Aspose.Slides และ ณ เวลาเขียน ยังไม่มีให้ใน Microsoft PowerPoint มันให้วิธีการแก่ผู้พัฒนาในการควบคุมการใช้งานการนำเสนอที่แอปพลิเคชันของพวกเขาสร้างขึ้น
## **ส่วนประกอบของสไลด์**
สไลด์ PPTX ประกอบด้วยส่วนประกอบหลายอย่าง เช่น รูปร่างอัตโนมัติ, ตาราง, วัตถุ OLE, รูปร่างที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อและองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ

ใน Aspose.Slides for .NET แต่ละองค์ประกอบบนสไลด์จะถูกแปลงเป็นอ็อบเจ็กต์ Shape กล่าวคือ แต่ละองค์ประกอบบนสไลด์จะเป็นอ็อบเจ็กต์ Shape หรืออ็อบเจ็กต์ที่สืบทอดจาก Shape

โครงสร้างของ PPTX มีความซับซ้อน ดังนั้นไม่เหมือน PPT ที่สามารถใช้การล็อกทั่วไปกับทุกประเภทของรูปร่าง มีประเภทการล็อกต่าง ๆ สำหรับแต่ละประเภทของรูปร่าง คลาส BaseShapeLock เป็นคลาสการล็อกทั่วไปของ PPTX ประเภทการล็อกต่อไปนี้ได้รับการสนับสนุนใน Aspose.Slides for .NET สำหรับ PPTX
- AutoShapeLock ล็อกรูปร่างอัตโนมัติ.
- ConnectorLock ล็อกรูปร่างเชื่อมต่อ.
- GraphicalObjectLock ล็อกวัตถุกราฟิก.
- GroupshapeLock ล็อกรูปร่างกลุ่ม.
- PictureFrameLock ล็อกกรอบรูปภาพ.

การกระทำใด ๆ ที่ทำบนอ็อบเจ็กต์ Shape ทั้งหมดในอ็อบเจ็กต์ Presentation จะถูกนำไปใช้กับการนำเสนอทั้งหมด.
## **การใช้และลบการปกป้อง**
การใช้การปกป้องทำให้แน่ใจว่าการนำเสนอไม่สามารถแก้ไขได้ เป็นเทคนิคที่มีประโยชน์สำหรับการปกป้องเนื้อหาของการนำเสนอ

**การใช้การปกป้องกับ Shape ของ PPTX**

Aspose.Slides for .NET มีคลาส Shape เพื่อจัดการกับรูปร่างบนสไลด์

เช่นที่กล่าวไปก่อนหน้านี้ แต่ละคลาสของรูปร่างมีคลาสล็อกรูปร่างที่เกี่ยวข้องสำหรับการปกป้อง บทความนี้มุ่งเน้นที่การล็อก NoSelect, NoMove และ NoResize การล็อกเหล่านี้ทำให้แน่ใจว่ารูปร่างไม่สามารถถูกเลือก (ผ่านการคลิกเมาส์หรือวิธีการเลือกอื่น) และไม่สามารถย้ายหรือเปลี่ยนขนาดได้

ตัวอย่างโค้ดต่อไปนี้ใช้การปกป้องกับทุกประเภทของรูปร่างในการนำเสนอ.

``` csharp

 //สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX


//อ็อบเจ็กต์ ISlide สำหรับเข้าถึงสไลด์ในงานนำเสนอ

SlideEx slide = pTemplate.Slides[0];

//อ็อบเจ็กต์ IShape สำหรับเก็บรูปร่างชั่วคราว

ShapeEx shape;

//วนผ่านสไลด์ทั้งหมดในงานนำเสนอ

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//วนผ่านรูปร่างทั้งหมดในสไลด์

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//ถ้ารูปร่างเป็น autoshape

		if (shape is AutoShapeEx)

		{

			//แปลงชนิดเป็น Auto shape และรับล็อกของ Auto shape

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//ใช้ล็อกของรูปร่าง

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//ถ้ารูปร่างเป็น group shape

		else if (shape is GroupShapeEx)

		{

			//แปลงชนิดเป็น group shape และรับล็อกของ group shape

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//ใช้ล็อกของรูปร่าง

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//ถ้ารูปร่างเป็น connector

		else if (shape is ConnectorEx)

		{

			//แปลงชนิดเป็น connector shape และรับล็อกของ connector shape

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//ใช้ล็อกของรูปร่าง

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//ถ้ารูปร่างเป็น picture frame

		else if (shape is PictureFrameEx)

		{

			//แปลงชนิดเป็น picture frame shape และรับล็อกของ picture frame shape

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

            //ใช้ล็อกของรูปร่าง

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//บันทึกไฟล์งานนำเสนอ

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**การลบการปกป้อง**

การปกป้องที่ใช้ด้วย Aspose.Slides for .NET สามารถลบได้เฉพาะด้วย Aspose.Slides for .NET เท่านั้น เพื่อปลดล็อกรูปร่าง ให้ตั้งค่าให้กับการล็อกที่ใช้งานเป็น false ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปลดล็อกรูปร่างในการนำเสนอที่ถูกล็อก.

``` csharp

 //เปิดงานนำเสนอที่ต้องการ
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//อ็อบเจ็กต์ ISlide เพื่อเข้าถึงสไลด์ในงานนำเสนอ
SlideEx slide = pTemplate.Slides[0];

//อ็อบเจ็กต์ IShape สำหรับเก็บรูปร่างชั่วคราว
ShapeEx shape;

//วนผ่านสไลด์ทั้งหมดในงานนำเสนอ
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//วนผ่านรูปร่างทั้งหมดในสไลด์
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//ถ้ารูปร่างเป็น autoshape
		if (shape is AutoShapeEx)
		{
			//แปลงประเภทเป็น Auto shape และ  รับล็อกของ auto shape
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//กำลังใช้ล็อกของรูปร่าง
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//ถ้ารูปร่างเป็น group shape
		else if (shape is GroupShapeEx)
		{
			//แปลงประเภทเป็น group shape และ  รับล็อกของ group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//กำลังใช้ล็อกของรูปร่าง
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//ถ้ารูปร่างเป็น Connector shape
		else if (shape is ConnectorEx)
		{
			//แปลงประเภทเป็น connector shape และ  รับล็อกของ connector shape
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//กำลังใช้ล็อกของรูปร่าง
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//ถ้ารูปร่างเป็น picture frame
		else if (shape is PictureFrameEx)
		{
			//แปลงประเภทเป็น picture frame shape และ  รับล็อกของ picture frame shape
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//กำลังใช้ล็อกของรูปร่าง
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//บันทึกไฟล์งานนำเสนอ
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)