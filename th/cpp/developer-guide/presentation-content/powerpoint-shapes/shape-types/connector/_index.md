---
title: จัดการคอนเน็กเตอร์ในงานนำเสนอด้วย C++
linktitle: คอนเน็กเตอร์
type: docs
weight: 10
url: /th/cpp/connector/
keywords:
- คอนเน็กเตอร์
- ประเภทคอนเน็กเตอร์
- จุดคอนเน็กเตอร์
- เส้นคอนเน็กเตอร์
- มุมคอนเน็กเตอร์
- เชื่อมต่อรูปร่าง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ทำให้แอป C++ สามารถวาด, เชื่อมต่อและกำหนดเส้นทางอัตโนมัติในสไลด์ PowerPoint — ควบคุมคอนเน็กเตอร์แบบตรง, แบบศอกและแบบโค้งได้อย่างเต็มที่"
---
## **บทนำ**

คอนเน็กเตอร์ PowerPoint คือเส้นพิเศษที่เชื่อมต่อหรือเชื่อมโยงรูปร่างสองรูปเข้าด้วยกันและยังคงติดกับรูปร่างแม้ว่าจะเคลื่อนย้ายหรือเปลี่ยนตำแหน่งบนสไลด์ที่กำหนด

คอนเน็กเตอร์มักจะเชื่อมต่อกับ *จุดเชื่อมต่อ* (จุดสีเขียว) ซึ่งมีอยู่บนรูปร่างทุกรูปโดยค่าเริ่มต้น จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์เข้าใกล้

*จุดปรับค่า* (จุดสีส้ม) ซึ่งมีอยู่เฉพาะบนคอนเน็กเตอร์บางประเภท ใช้เพื่อแก้ไขตำแหน่งและรูปทรงของคอนเน็กเตอร์

## **ประเภทของคอนเน็กเตอร์**

ใน PowerPoint คุณสามารถใช้คอนเน็กเตอร์แบบตรง, แบบศอก (มุม) และแบบโค้ง

Aspose.Slides มีคอนเน็กเตอร์เหล่านี้:

| คอนเน็กเตอร์ | รูปภาพ | จำนวนจุดปรับค่า |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **เชื่อมโยงรูปร่างด้วยคอนเน็กเตอร์**

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/)  
1. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.auto_shape) สองอันลงในสไลด์โดยใช้เมธอด`AddAutoShape` ของอ็อบเจกต์`Shapes`  
1. เพิ่มคอนเน็กเตอร์โดยใช้เมธอด`AddConnector` ของอ็อบเจกต์`Shapes` พร้อมระบุประเภทของคอนเน็กเตอร์  
1. เชื่อมต่อรูปร่างด้วยคอนเน็กเตอร์  
1. เรียกเมธอด`Reroute`เพื่อกำหนดเส้นเชื่อมที่สั้นที่สุด  
1. บันทึกการนำเสนอ  

โค้ด C++ นี้แสดงวิธีเพิ่มคอนเน็กเตอร์ (คอนเน็กเตอร์แบบโค้ง) ระหว่างรูปร่างสองรูป (รูปวงรีและสี่เหลี่ยม):

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// โหลดการนำเสนอที่ต้องการ
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// เข้าถึงสไลด์แรก
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์ที่ระบุ
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// เพิ่มรูปร่างอัตโนมัติรูปวงรี
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// เพิ่มรูปร่างอัตโนมัติรูปสี่เหลี่ยม
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// เพิ่มรูปร่างคอนเน็กเตอร์ไปยังคอลเลกชันของรูปร่างบนสไลด์
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// เชื่อมต่อรูปร่างโดยใช้คอนเน็กเตอร์
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// เรียกเมธอด reroute เพื่อกำหนดเส้นทางสั้นที่สุดอัตโนมัติระหว่างรูปร่าง
	connector->Reroute();
	
	// บันทึกการนำเสนอ
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

เมธอด`connector->Reroute`จะทำการกำหนดเส้นคอนเน็กเตอร์ใหม่และบังคับให้ใช้เส้นทางที่สั้นที่สุดระหว่างรูปร่าง เพื่อให้บรรลุเป้าหมายนั้นเมธอดอาจเปลี่ยนค่าจุด`StartShapeConnectionSiteIndex`และ`EndShapeConnectionSiteIndex` 

{{% /alert %}} 

## **ระบุจุดเชื่อมต่อ**

หากต้องการให้คอนเน็กเตอร์เชื่อมสองรูปร่างโดยใช้จุดเฉพาะบนรูปร่าง คุณต้องระบุจุดเชื่อมต่อที่ต้องการดังนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/)  
1. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.auto_shape) สองอันลงในสไลด์โดยใช้เมธอด`AddAutoShape`ของอ็อบเจกต์`Shapes`  
1. เพิ่มคอนเน็กเตอร์โดยใช้เมธอด`AddConnector`ของอ็อบเจกต์`Shapes`พร้อมระบุประเภทของคอนเน็กเตอร์  
1. เชื่อมต่อรูปร่างด้วยคอนเน็กเตอร์  
1. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่าง  
1. บันทึกการนำเสนอ  

โค้ด C++ นี้แสดงการกำหนดจุดเชื่อมต่อที่ต้องการ:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// โหลดการนำเสนอที่ต้องการ
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// เข้าถึงสไลด์แรก
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์ที่ระบุ
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// เพิ่มรูปร่างอัตโนมัติรูปวงรี
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// เพิ่มรูปร่างอัตโนมัติรูปสี่เหลี่ยม
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// เพิ่มรูปร่างคอนเน็กเตอร์ไปยังคอลเลกชันของรูปร่างบนสไลด์
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// เชื่อมต่อรูปร่างโดยใช้คอนเน็กเตอร์
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// ตั้งค่าดัชนีจุดเชื่อมต่อที่ต้องการบนรูปร่างวงรี
	int wantedIndex = 6;

	// ตรวจสอบว่าดัชนีที่ต้องการน้อยกว่าจำนวนจุดเชื่อมต่อสูงสุดหรือไม่
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่างอัตโนมัติวงรี
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// บันทึกการนำเสนอ
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **ปรับจุดคอนเน็กเตอร์**

คุณสามารถปรับคอนเน็กเตอร์ที่มีอยู่แล้วผ่านจุดปรับค่าได้ เฉพาะคอนเน็กเตอร์ที่มีจุดปรับค่าจึงสามารถแก้ไขได้ ดูตารางภายใต้ **[ประเภทของคอนเน็กเตอร์](/slides/th/cpp/connector/#types-of-connectors)**

### **กรณีง่าย**

พิจารณากรณีที่คอนเน็กเตอร์ระหว่างรูปร่างสองรูป (A และ B) ผ่านรูปร่างที่สาม (C):

![connector-obstruction](connector-obstruction.png)

โค้ด:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

เพื่อหลีกเลี่ยงหรือข้ามรูปร่างที่สาม เราสามารถปรับคอนเน็กเตอร์โดยเลื่อนเส้นแนวตั้งไปทางซ้ายดังนี้:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **กรณีซับซ้อน** 

เมื่อต้องทำการปรับที่ซับซ้อนขึ้น คุณต้องคำนึงถึงประเด็นต่อไปนี้:

* จุดปรับค่าของคอนเน็กเตอร์เชื่อมโยงกับสูตรที่คำนวณและกำหนดตำแหน่งของมัน ดังนั้นการเปลี่ยนตำแหน่งจุดอาจทำให้รูปทรงของคอนเน็กเตอร์เปลี่ยนไป  
* จุดปรับค่าถูกกำหนดตามลำดับที่เข้มงวดในอาร์เรย์ โดยเริ่มจากจุดเริ่มต้นของคอนเน็กเตอร์ไปจนถึงจุดสิ้นสุด  
* ค่าจุดปรับค่าแสดงเปอร์เซ็นต์ของความกว้าง/ความสูงของรูปคอนเน็กเตอร์  
  * รูปจะถูกจำกัดโดยจุดเริ่มต้นและจุดสิ้นสุดของคอนเน็กเตอร์ที่คูณด้วย 1000  
  * จุดแรก, จุดที่สอง, และจุดที่สาม จะกำหนดเปอร์เซ็นต์จากความกว้าง, ความสูง, และความกว้าง (อีกครั้ง) ตามลำดับ  
* สำหรับการคำนวณตำแหน่งของจุดปรับค่าของคอนเน็กเตอร์ คุณต้องคำนึงถึงการหมุนและการสะท้อนของคอนเน็กเตอร์ **หมายเหตุ** ว่าองศาการหมุนสำหรับคอนเน็กเตอร์ทั้งหมดที่แสดงใน **[ประเภทของคอนเน็กเตอร์](/slides/th/cpp/connector/#types-of-connectors)** มีค่าเป็น 0

#### **กรณีที่ 1**

พิจารณากรณีที่วัตถุกรอบข้อความสองอันถูกเชื่อมต่อกันผ่านคอนเน็กเตอร์:

![connector-shape-complex](connector-shape-complex.png)

โค้ด:

```c++
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>();
// ดึงสไลด์แรกในงานนำเสนอ
auto slide = pres->get_Slides()->idx_get(0);
// ดึงรูปร่างจากสไลด์แรก
auto shapes = slide->get_Shapes();
// เพิ่มรูปร่างที่จะเชื่อมต่อกันผ่านคอนเน็กเตอร์
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// เพิ่มคอนเน็กเตอร์
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// ระบุทิศทางของคอนเน็กเตอร์
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// ระบุความหนาของเส้นคอนเน็กเตอร์
lineFormat->set_Width(3);
// ระบุสีของคอนเน็กเตอร์
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// เชื่อมโยงรูปร่างเข้าด้วยกันด้วยคอนเน็กเตอร์
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// ดึงจุดปรับค่าสำหรับคอนเน็กเตอร์
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**การปรับค่า**

เราสามารถเปลี่ยนค่าจุดปรับค่าของคอนเน็กเตอร์ได้โดยเพิ่มเปอร์เซ็นต์ความกว้างและความสูงที่สอดคล้องกันเป็น 20% และ 200% ตามลำดับ:

```c++
// เปลี่ยนค่าของจุดปรับค่า
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-1](connector-adjusted-1.png)

เพื่อกำหนดโมเดลที่ช่วยให้เราคำนวณพิกัดและรูปทรงของส่วนต่าง ๆ ของคอนเน็กเตอร์ เราจะสร้างรูปร่างที่สอดคล้องกับส่วนแนวนอนของคอนเน็กเตอร์ที่จุด`connector.Adjustments[0]`:

```c++
// วาดส่วนแนวตั้งของคอนเน็กเตอร์
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

ผลลัพธ์:

![connector-adjusted-2](connector-adjusted-2.png)

#### **กรณีที่ 2**

ใน **กรณีที่ 1** เราได้สาธิตการปรับคอนเน็กเตอร์แบบง่ายด้วยหลักการพื้นฐาน ในสถานการณ์ปกติคุณต้องคำนึงถึงการหมุนของคอนเน็กเตอร์และการแสดงผล (ซึ่งตั้งค่าผ่าน`connector.Rotation`, `connector.Frame.FlipH`, และ `connector.Frame.FlipV`) เราจะสาธิตขั้นตอนต่อไป

แรกเริ่ม เพิ่มวัตถุกรอบข้อความใหม่ (**To 1**) ลงในสไลด์ (เพื่อการเชื่อมต่อ) และสร้างคอนเน็กเตอร์สีเขียวใหม่ที่เชื่อมต่อกับวัตถุที่เราสร้างไว้ก่อนหน้านี้

```c++
// สร้างอ็อบเจกต์การผูกใหม่
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// สร้างคอนเน็กเตอร์ใหม่
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// เชื่อมต่อวัตถุด้วยคอนเน็กเตอร์ที่สร้างใหม่
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// ดึงจุดปรับค่าของคอนเน็กเตอร์
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// เปลี่ยนค่าของจุดปรับค่า
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-3](connector-adjusted-3.png)

ต่อมา สร้างรูปร่างที่จะสอดคล้องกับส่วนแนวนอนของคอนเน็กเตอร์ที่ผ่านจุดปรับค่าใหม่`connector.Adjustments[0]` เราจะใช้ค่าจากข้อมูลคอนเน็กเตอร์สำหรับ`connector.Rotation`, `connector.Frame.FlipH`, และ `connector.Frame.FlipV` และใช้สูตรการแปลงพิกัดเพื่อหมุนรอบจุด `x0`:

X=(x—x0)*cos(alpha)—(y—y0)*sin(alpha)+x0;  
Y=(x—x0)*sin(alpha)+(y—y0)*cos(alpha)+y0;

ในกรณีของเรา มุมการหมุนของวัตถุคือ 90 องศาและคอนเน็กเตอร์แสดงเป็นแนวตั้ง ดังนั้นโค้ดที่สอดคล้องคือ:

```c++

```

ผลลัพธ์:

![connector-adjusted-4](connector-adjusted-4.png)

เราสาธิตการคำนวณที่เกี่ยวข้องกับการปรับค่าแบบง่ายและการปรับค่าที่ซับซ้อน (จุดปรับค่าพร้อมมุมหมุน) ด้วยความรู้ที่ได้คุณสามารถพัฒนาโมเดลของคุณเอง (หรือเขียนโค้ด) เพื่อรับอ็อบเจกต์`GraphicsPath` หรือแม้แต่ตั้งค่าจุดปรับค่าของคอนเน็กเตอร์ตามพิกัดสไลด์เฉพาะ

## **หามุมของเส้นคอนเน็กเตอร์**

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/)  
1. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เข้าถึงรูปร่างเส้นคอนเน็กเตอร์  
1. ใช้ความกว้าง, ความสูง, ความสูงของเฟรมรูปร่างและความกว้างของเฟรมรูปร่างเพื่อคำนวณมุม

โค้ด C++ นี้สาธิตการคำนวณมุมสำหรับรูปร่างเส้นคอนเน็กเตอร์:

```c++
void ConnectorLineAngle()
{

	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// โหลดการนำเสนอที่ต้องการ
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// เข้าถึงสไลด์แรก
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// เข้าถึงคอลเลกชันของรูปร่างในสไลด์
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าคอนเน็กเตอร์สามารถ “กาว” ติดกับรูปร่างเฉพาะได้หรือไม่?**

ตรวจสอบว่ารูปร่างเปิดเผย[จุดเชื่อมต่อ](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_connectionsitecount/)หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การกาวจะไม่สามารถใช้ได้; ในกรณีนั้นให้ใช้จุดปลายอิสระและจัดตำแหน่งด้วยตนเอง ควรตรวจสอบจำนวนจุดก่อนการแนบ

**ถ้าฉันลบรูปร่างที่เชื่อมต่ออยู่กับคอนเน็กเตอร์ จะเกิดอะไรขึ้น?**

ส่วนปลายของคอนเน็กเตอร์จะถูกแยกออก; คอนเน็กเตอร์จะคงอยู่บนสไลด์เป็นเส้นธรรมดาที่มีจุดเริ่มต้น/สิ้นสุดอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่และหากจำเป็นให้[reroute](https://reference.aspose.com/slides/th/cpp/aspose.slides/connector/reroute/)

**การผูกคอนเน็กเตอร์จะคงอยู่หรือไม่เมื่อคัดลอกสไลด์ไปยังการนำเสนออื่น?**

โดยทั่วไปจะคงอยู่ หากรูปร่างเป้าหมายถูกคัดลอกด้วย หากสไลด์ถูกแทรกเข้าไฟล์อื่นโดยไม่มีรูปร่างที่เชื่อมต่อไว้ ส่วนปลายจะกลายเป็นอิสระและคุณจำเป็นต้องแนบใหม่