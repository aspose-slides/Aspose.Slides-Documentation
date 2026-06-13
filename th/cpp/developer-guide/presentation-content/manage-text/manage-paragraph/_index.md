---
title: จัดการย่อหน้าข้อความ PowerPoint ใน C++
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/cpp/manage-paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อสัญลักษณ์
- การเยื้องย่อหน้า
- การเยื้องแบบห้อย
- หัวข้อสัญลักษณ์ย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อสัญลักษณ์
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- แปลงข้อความเป็น HTML
- แปลงย่อหน้าเป็น HTML
- แปลงย่อหน้าเป็นภาพ
- แปลงข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ C++ — ปรับแต่งการจัดแนว การเว้นระยะและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP ด้วย C++."
---
## **บทนำ**

Aspose.Slides มีอินเทอร์เฟซและคลาสทั้งหมดที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint ย่อหน้าและส่วนย่อยใน C++.

* Aspose.Slides มีอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของย่อหน้า อ็อบเจ็กต์ `ITextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างโดยการขึ้นบรรทัดใหม่)
* Aspose.Slides มีอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของส่วนย่อย อ็อบเจ็กต์ `IParagraph` สามารถมีหนึ่งหรือหลายส่วนย่อย (คอลเลกชันของอ็อบเจ็กต์ iPortions)
* Aspose.Slides มีอินเทอร์เฟซ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของข้อความและคุณสมบัติการจัดรูปแบบของมัน

อ็อบเจ็กต์ `IParagraph` สามารถจัดการกับข้อความที่มีคุณสมบัติการจัดรูปแบบต่าง ๆ ผ่านอ็อบเจ็กต์ `IPortion` ที่อยู่ภายใต้

## **เพิ่มหลายย่อหน้าที่มีหลายส่วนย่อย**

ขั้นตอนต่อไปนี้จะแสดงวิธีเพิ่มกรอบข้อความที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วนย่อย:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน
3. เพิ่มสี่เหลี่ยม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์
4. รับ ITextFrame ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/)
5. สร้างอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) สองอ็อบเจ็กต์และเพิ่มลงในคอลเลกชัน `IParagraphs` ของ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)
6. สร้างอ็อบเจ็กต์ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) สามอ็อบเจ็กต์สำหรับแต่ละ `IParagraph` ใหม่ (สอง Portion สำหรับย่อหน้าเริ่มต้น) แล้วเพิ่มแต่ละอ็อบเจ็กต์ `IPortion` ลงในคอลเลกชัน IPortion ของแต่ละ `IParagraph`
7. ตั้งค่าข้อความสำหรับแต่ละส่วนย่อย
8. ใช้คุณสมบัติการจัดรูปแบบที่คุณต้องการกับแต่ละส่วนย่อยโดยใช้คุณสมบัติการจัดรูปแบบของอ็อบเจ็กต์ `IPortion`
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C++ นี้เป็นการทำตามขั้นตอนสำหรับการเพิ่มย่อหน้าที่มีส่วนย่อย:

```c++
// เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Add TextFrame to the Rectangle
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accessing the first Paragraph
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adding second Paragraph
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adding third Paragraph
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **จัดการ Bullet ของย่อหน้า**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบมี Bullet จะอ่านง่ายและเข้าใจได้ดีขึ้นเสมอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอ็อบเจ็กต์ย่อหน้าที่หนึ่งโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/)
7. ตั้งค่า `Type` ของ Bullet เป็น `Symbol` และตั้งค่าตัวอักษร Bullet
8. ตั้งค่า `Text` ของย่อหน้า
9. ตั้งค่า `Indent` ของ Bullet สำหรับย่อหน้า
10. ตั้งค่าสีสำหรับ Bullet
11. ตั้งค่าสูงของ Bullet
12. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตั้งแต่ 7 ถึง 13
14. บันทึกงานนำเสนอ

โค้ด C++ นี้แสดงวิธีเพิ่ม Bullet ให้กับย่อหน้า:

```c++
// เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// เพิ่ม TextFrame ไปยังสี่เหลี่ยม
ashp->AddTextFrame(u"");

// กำลังเข้าถึง TextFrame
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// สร้างอ็อบเจ็กต์ Paragraph สำหรับ TextFrame
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// ตั้งค่าข้อความ
paragraph->set_Text(u"Welcome to Aspose.Slides");

// ตั้งค่าการเยื้องของ Bullet
paragraph->get_ParagraphFormat()->set_Indent (25);

// ตั้งค่าสีของ Bullet
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สี Bullet ของคุณเอง
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// ตั้งค่าสูงของ Bullet
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// เพิ่ม Paragraph ไปยัง TextFrame
txtFrame->get_Paragraphs()->Add(paragraph);

// สร้างย่อหน้าที่สอง
// สร้างอ็อบเจ็กต์ Paragraph สำหรับ TextFrame
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// ตั้งค่าข้อความ
paragraph2->set_Text(u"This is numbered bullet");

// ตั้งค่าชนิดและสไตล์ของ Bullet ในย่อหน้า
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// ตั้งค่าการเยื้องของ Bullet
paragraph2->get_ParagraphFormat()->set_Indent(25);

// ตั้งค่าสีของ Bullet
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สี Bullet ของคุณเอง
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// ตั้งค่าสูงของ Bullet
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// เพิ่ม Paragraph ไปยัง TextFrame
txtFrame->get_Paragraphs()->Add(paragraph2);


// บันทึก PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **จัดการ Picture Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบภาพก็อ่านง่ายและเข้าใจได้เช่นกัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอ็อบเจ็กต์ย่อหน้าที่หนึ่งโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/)
7. โหลดภาพใน [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)
8. ตั้งค่า Bullet type เป็น [Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) แล้วตั้งค่าภาพ
9. ตั้งค่า `Text` ของ Paragraph
10. ตั้งค่า `Indent` ของ Bullet สำหรับ Paragraph
11. ตั้งค่าสีสำหรับ Bullet
12. ตั้งค่าสูงของ Bullet
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนก่อนหน้า
15. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C++ นี้แสดงวิธีเพิ่มและจัดการ Picture Bullet:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// สร้างอินสแตนซ์ของภาพสำหรับ Bullet
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// เพิ่มและเข้าถึง Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// เข้าถึง TextFrame ของ Autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// ลบย่อหน้าเริ่มต้น
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// สร้างย่อหน้าใหม่
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// ตั้งค่าสไตล์และรูปภาพของ Bullet ในย่อหน้า
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// ตั้งค่าสูงของ Bullet
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// เพิ่มย่อหน้าไปยัง TextFrame
paragraphs->Add(paragraph);

// บันทึกงานนำเสนอเป็นไฟล์ PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// บันทึกงานนำเสนอเป็นไฟล์ PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **จัดการ Multilevel Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Multilevel Bullet ทำให้การอ่านและความเข้าใจง่ายขึ้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ในสไลด์ใหม่
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) แล้วตั้งค่า depth เป็น 0
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 1
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 2
9. สร้างย่อหน้าที่สี่ผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 3
10. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
11. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C++ นี้แสดงวิธีเพิ่มและจัดการ Multilevel Bullet:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// เพิ่มและเข้าถึง Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// เข้าถึง TextFrame ของ Autoshape ที่สร้าง
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// ลบย่อหน้าเริ่มต้น
text->get_Paragraphs()->Clear();

// เพิ่มย่อหน้าแรก
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// ตั้งค่าระดับของ Bullet
para1Format->set_Depth(0);

// เพิ่มย่อหน้าที่สอง
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// ตั้งค่าระดับของ Bullet
para2Format->set_Depth(1);

// เพิ่มย่อหน้าที่สาม
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// ตั้งค่าระดับของ Bullet
para3Format->set_Depth(2);

// เพิ่มย่อหน้าที่สี่
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// ตั้งค่าระดับของ Bullet
para4Format->set_Depth(3);

// เพิ่มย่อหน้าไปยังคอลเลกชัน
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// บันทึกงานนำเสนอเป็นไฟล์ PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **จัดการย่อหน้าที่มีรายการหมายเลขกำหนดเอง**

อินเทอร์เฟซ [IBulletFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/) ให้คุณใช้คุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) และอื่น ๆ เพื่อจัดการย่อหน้าที่มีการนับเลขหรือการจัดรูปแบบแบบกำหนดเอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่มีย่อหน้าอยู่
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) แล้วตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เป็น 2
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 3
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 7
9. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C++ นี้แสดงวิธีเพิ่มและจัดการย่อหน้าที่มีการนับเลขหรือการจัดรูปแบบแบบกำหนดเอง:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// เข้าถึง TextFrame ของ autoshape ที่สร้าง
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// ลบย่อหน้าเริ่มต้นที่มีอยู่
textFrame->get_Paragraphs()->RemoveAt(0);

// รายการแรก
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **ตั้งค่า First-Line Indent ให้กับย่อหน้า**

ใช้เมธอด [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เพื่อตั้งค่าการเยื้องบรรทัดแรกของย่อหน้า เมธอดนี้จะเลื่อนบรรทัดแรกเท่านั้นเมื่อเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ที่ตำแหน่งเดิม

ใช้ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) เมื่อคุณต้องการเลื่อนย่อหน้าทั้งหมด ใช้ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เมื่อต้องการเลื่อนแค่บรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ `Indent` เพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/) ว่างเปล่าลงในรูปร่างแล้วลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ให้กับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Indent ให้กับย่อหน้า:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งค่า Hanging Indent ให้กับย่อหน้า**

Hanging Indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ตั้งค่า Indent เป็นค่าลบเพื่อเลื่อนบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยทั่วไป [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับ MarginLeft การสร้าง Hanging Indent ทำได้โดยตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้เหมาะสำหรับบรรณานุกรม, การอ้างอิง, รายการพจนานุกรม และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่พับลงอยู่ใต้เนื้อหาย่อหน้า ไม่ใช่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/) ว่างเปล่าลงในรูปร่างแล้วลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า `MarginLeft` ให้เป็นบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า `Indent` เป็นค่าลบเพื่อสร้างเอฟเฟกต์ Hanging Indent
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Hanging Indent ให้กับย่อหน้า:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การเยื้องแบบ Hanging ของย่อหน้า](hanging_indent.png)

## **จัดการ End Paragraph Run Properties**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. รับอ้างอิงของสไลด์ที่มีย่อหน้าโดยใช้ตำแหน่งของมัน
1. เพิ่มสี่เหลี่ยม [autoshape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ที่มีสองย่อหน้าลงในสี่เหลี่ยม
1. ตั้งค่า `FontHeight` และชนิดฟอนต์สำหรับย่อหน้า
1. ตั้งค่า End properties สำหรับย่อหน้า
1. เขียนไฟล์งานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด C++ นี้แสดงวิธีตั้งค่า End properties สำหรับย่อหน้าใน PowerPoint:

```c++
// เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// เพิ่ม TextFrame ไปยังสี่เหลี่ยม
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// เพิ่มย่อหน้าที่แรก
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// เพิ่มย่อหน้าที่สอง
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);


// บันทึก PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **นำเข้า HTML Text เข้าไปในย่อหน้า**

Aspose.Slides ให้การสนับสนุนที่เพิ่มขึ้นสำหรับการนำเข้า HTML Text เข้าไปในย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์
4. เพิ่มและเข้าถึง `autoshape` [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)
5. ลบย่อหน้าเริ่มต้นใน `ITextFrame`
6. อ่านไฟล์ HTML ต้นฉบับด้วย TextReader
7. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/)
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraphcollection/) ของ TextFrame
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด C++ นี้เป็นการทำตามขั้นตอนสำหรับการนำเข้า HTML Text เข้าไปในย่อหน้า:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// รีเซ็ตสีเติมแบบเริ่มต้น
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// เพิ่ม TextFrame ไปยังสี่เหลี่ยม
ashp->AddTextFrame(u" ");

// กำลังเข้าถึง TextFrame
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// รับคอลเลกชัน Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่ม
ParaCollection->Clear();

// โหลดไฟล์ HTML ด้วย StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// สร้างอ็อบเจ็กต์ Paragraph สำหรับ TextFrame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// สร้างอ็อบเจ็กต์ Portion สำหรับย่อหน้า
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// รับรูปแบบ Portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// ตั้งค่าแบบอักษรสำหรับ Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// ตั้งค่าคุณสมบัติ Bold ของแบบอักษร
pf->set_FontBold(NullableBool::True);

// ตั้งค่าคุณสมบัติ Italic ของแบบอักษร
pf->set_FontItalic(NullableBool::True);

// ตั้งค่าคุณสมบัติ Underline ของแบบอักษร
pf->set_FontUnderline(TextUnderlineType::Single);

// ตั้งค่าขนาดความสูงของแบบอักษร
pf->set_FontHeight(25);

// ตั้งค่าสีของแบบอักษร
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// บันทึก PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides ให้การสนับสนุนที่เพิ่มขึ้นสำหรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน
3. เข้าถึงรูปร่างที่มีข้อความที่ต้องการส่งออกเป็น HTML
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปร่างนั้น
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่
6. ให้ค่าเริ่มต้นตำแหน่งสำหรับ StreamWriter แล้วส่งออกย่อหน้าที่คุณต้องการ

โค้ด C++ นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint ไปเป็น HTML:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// เข้าถึงสไลด์แรกเริ่มต้นของงานนำเสนอ
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// ดัชนีที่ต้องการ
int index = 0;

// เข้าถึงรูปร่างที่เพิ่มเข้ามา
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// ดึงย่อหน้าแรกเป็น HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่ต้องคัดลอก
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีบันทึกรายการข้อความที่เป็นย่อหน้า ซึ่งแสดงโดยอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) ทั้งสองตัวอย่างรวมถึงการดึงภาพของรูปร่างที่บรรจุย่อหน้าโดยใช้เมธอด `GetImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) คำนวณขอบเขตของย่อหน้าในรูปร่าง และส่งออกเป็นภาพบิตแมพ วิธีเหล่านี้ช่วยให้คุณดึงส่วนของข้อความจากงานนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์ในการใช้งานต่อไปในหลายสถานการณ์

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยดึงภาพของรูปร่างจากสไลด์แรกของงานนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่าง ย่อหน้าจะถูกวาดใหม่บนภาพบิตแมพใหม่และบันทึกเป็น PNG วิธีนี้เหมาะกับการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงความละเอียดและรูปแบบของข้อความไว้

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพ.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

ผลลัพธ์:

![ภาพของย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่างที่ 2**

ในตัวอย่างนี้ เราจะขยายวิธีก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างจะถูกดึงออกจากงานนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งทำให้ได้ผลลัพธ์ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าจะคำนวณโดยคำนึงถึงสเกล การสเกลมีประโยชน์เมื่อจำเป็นต้องการภาพที่ละเอียดกว่า เช่น การใช้ในสื่อพิมพ์คุณภาพสูง

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**ฉันสามารถปิดการห่อหุ้มบรรทัดภายใน TextFrame ได้อย่างสมบูรณ์หรือไม่?**

ได้ ใช้วิธีห่อหุ้มของ TextFrame ([set_WrapText](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframeformat/set_wraptext/)) เพื่อปิดการห่อหุ้มให้บรรทัดไม่ขาดที่ขอบของกรอบ

**ฉันจะได้ขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (และแม้แต่ของ Portion เดียว) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/กลาง/จัดเต็ม) ควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraphformat/set_alignment/) เป็นการตั้งค่าที่ระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraphformat/) จะนำไปใช้กับย่อหน้าเต็มโดยไม่คำนึงถึงการจัดรูปแบบของ Portion แต่ละอัน

**ฉันสามารถตั้งค่าภาษาตรวจสอบการสะกดสำหรับส่วนหนึ่งของย่อหน้า (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาจะถูกตั้งค่าที่ระดับ Portion โดยใช้ ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/)) ทำให้หลายภาษาอยู่ร่วมกันได้ภายในย่อหน้าเดียว