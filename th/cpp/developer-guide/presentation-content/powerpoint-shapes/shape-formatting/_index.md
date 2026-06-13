---
title: จัดรูปแบบรูปร่าง PowerPoint ใน C++
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/cpp/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อม
- ไล่สี
- การเติมลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการจัดรูปแบบรูปร่าง PowerPoint ใน C++ ด้วย Aspose.Slides—ตั้งค่าการเติม เส้น และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบเส้นของพวกมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมการเติมภายในของรูปร่างได้

![รูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slidesสำหรับ C++ มีอินเทอร์เฟซและเมธอดที่ให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ด้วย Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปร่างได้ ขั้นตอนต่อไปนี้สรุปขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่าที่ [line style](https://reference.aspose.com/slides/th/cpp/aspose.slides/linestyle/) ของรูปร่าง 
1. ตั้งค่าความกว้างของเส้น 
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/cpp/aspose.slides/linedashstyle/) ของเส้น 
1. ตั้งค่าสีของเส้นสำหรับรูปร่าง 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` แบบสี่เหลี่ยมผืนผ้า:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape ชนิด Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยม.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **จัดรูปแบบสไตล์การเชื่อม**

ต่อไปนี้เป็นตัวเลือกสามประเภทของการเชื่อม:

* โค้ง
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมเส้นสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **โค้ง** อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคม คุณอาจต้องการตัวเลือก **มิตเตอร์** 

![สไตล์การเชื่อมในงานนำเสนอ](join-style-powerpoint.png)

โค้ด C++ ต่อไปนี้แสดงว่าอย่างไรสี่เหลี่ยมผืนผ้าสามรูป (ตามที่แสดงในภาพด้านบน) ถูกสร้างโดยใช้การตั้งค่าประเภทการเชื่อม Miter, Bevel, และ Round:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape จำนวนสามรูปแบบชนิด Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// ตั้งค่าสีเติมสำหรับสี่เหลี่ยมแต่ละรูป.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// ตั้งค่าความกว้างของเส้น.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมแต่ละรูป.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ตั้งค่าสไตล์การเชื่อม.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// เพิ่มข้อความลงในสี่เหลี่ยมแต่ละรูป.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การผสมสีอย่างต่อเนื่องกับรูปร่าง ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่านั้นโดยสีหนึ่งค่อยๆ จางลงเป็นอีกสีหนึ่ง

ต่อไปนี้เป็นวิธีการใช้ Gradient Fill เติมแบบไล่สีลงในรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient` 
1. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `Add` ของคอลเลกชัน gradient stop ที่เปิดให้ใช้งานผ่านอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/igradientformat/) 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape ชนิด Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// ใช้การจัดรูปแบบไล่สีกับวงรี.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// ตั้งค่าทิศทางของไล่สี.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// เพิ่มจุดหยุดสีไล่สีสองจุด.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปวงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

## **การเติมแบบลาย**

ใน PowerPoint การเติมแบบลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, ลายขีด, ลายขีดตัดกัน หรือ ลายตาราง—ลงในรูปร่าง คุณสามารถเลือกสีกำหนดเองสำหรับสีหน้าและสีหลังของลายได้

Aspose.Slides มีสไตล์ลายที่กำหนดไว้ล่วงหน้ามากกว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปร่างเพื่อเพิ่มความสวยงามให้กับงานนำเสนอของคุณ แม้หลังจากเลือกลายที่กำหนดไว้แล้ว คุณยังสามารถระบุสีที่ต้องการให้ใช้ได้

ต่อไปนี้เป็นวิธีการใช้ Pattern Fill เติมแบบลายลงในรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern` 
1. เลือกสไตล์ลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า 
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipatternformat/get_backcolor/) ของลาย 
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipatternformat/get_forecolor/) ของลาย 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape ชนิด Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ตั้งค่าแบบเติมเป็น Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// ตั้งค่าสไตล์ลาย.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// ตั้งค่าสีพื้นหลังและสีหน้าของลาย.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![สี่เหลี่ยมผืนผ้าที่มีการเติมแบบลาย](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกภาพภายในรูปร่าง—โดยใช้ภาพเป็นพื้นหลังของรูปร่าง

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพลงในรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของรูปร่างเป็น `Picture` 
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดที่ต้องการอื่น) 
1. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) จากภาพที่ต้องการใช้ 
1. ส่งภาพไปยังเมธอด `ISlidesPicture.set_Image` 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

สมมติว่าเรามีไฟล์ "lotus.png" ที่มีรูปภาพต่อไปนี้:

![รูปภาพ lotus](lotus.png)

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape ชนิด Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// ตั้งค่าแบบเติมเป็น Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// ตั้งค่าโหมดการเติมรูปภาพ.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// โหลดภาพและเพิ่มไปยังทรัพยากรของงานนำเสนอ.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// ตั้งค่าภาพ.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่มีการเติมรูปภาพ](picture-fill.png)

### **ตั้งค่าภาพต่อเป็นเทกซ์เจอร์**

หากคุณต้องการตั้งค่าภาพต่อเป็นเทกซ์เจอร์และกำหนดพฤติกรรมการต่อ คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch` 
- [set_TileAlignment](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): ระบุตำแหน่งการจัดเรียงของไทล์ภายในรูปร่าง 
- [set_TileFlip](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_tileflip/): ควบคุมว่าทไทล์จะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง 
- [set_TileOffsetX](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): ตั้งค่าออฟเซตแนวนอนของไทล์ (เป็นจุด) จากต้นตำแหน่งของรูปร่าง 
- [set_TileOffsetY](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): ตั้งค่าออฟเซตแนวตั้งของไทล์ (เป็นจุด) จากต้นตำแหน่งของรูปร่าง 
- [set_TileScaleX](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์ 
- [set_TileScaleY](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์ 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto firstSlide = presentation->get_Slide(0);

// เพิ่ม auto shape รูปสี่เหลี่ยม.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// ตั้งค่าแบบเติมของรูปร่างเป็น Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// โหลดภาพและเพิ่มไปยังทรัพยากรของงานนำเสนอ.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// กำหนดภาพให้กับรูปร่าง.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// ตั้งค่ารูปแบบการเติมรูปภาพและคุณสมบัติการต่อ.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ตัวเลือกการต่อ](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมรูปร่างด้วยสีเดียวที่สม่ำเสมอ ไม่มีการไล่สี เทกซ์เจอร์ หรือรูปแบบใด ๆ

เพื่อเติมสีทึบลงในรูปร่างโดยใช้ Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของรูปร่างเป็น `Solid` 
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง 
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape ชนิด Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ตั้งค่าแบบเติมเป็น Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// ตั้งค่าสีเติม.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่สี, รูปภาพ หรือเทกซ์เจอร์ลงในรูปร่าง คุณสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่าความโปร่งใสที่สูงทำให้รูปร่างดูโปร่งแสงมากขึ้น

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่าอัลฟาในสีที่ใช้สำหรับเติม นี่คือวิธีทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) เป็น `Solid` 
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส) 
1. บันทึกงานนำเสนอ 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape สี่เหลี่ยมแบบทึบ.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// เพิ่ม auto shape สี่เหลี่ยมใสเหนือรูปร่างทึบ.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **การหมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งมีประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามการจัดเรียงหรือความต้องการออกแบบเฉพาะ

เพื่อหมุนรูปร่างบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ตั้งค่าคุณสมบัติการหมุนของรูปร่างเป็นมุมที่ต้องการ 
1. บันทึกงานนำเสนอ 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ดึงสไลด์แรก.
auto slide = presentation->get_Slide(0);

// เพิ่ม auto shape ชนิด Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// หมุนรูปร่างด้วยมุม 5 องศา.
shape->set_Rotation(5);

// บันทึกไฟล์ PPTX ไปยังดิสก์.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การหมุนของรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

Aspose.Slides อนุญาตให้คุณเพิ่มเอฟเฟกต์ Bevel 3 มิติให้กับรูปร่างโดยการกำหนดคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/threedformat/) ของมัน

เพื่อเพิ่มเอฟเฟกต์ Bevel 3 มิติ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/threedformat/) ของรูปร่างเพื่อกำหนดการตั้งค่า bevel 
1. บันทึกงานนำเสนอ 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// เพิ่มรูปร่างลงในสไลด์.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// บันทึกงานนำเสนอเป็นไฟล์ PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เอฟเฟกต์ Bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณเพิ่มเอฟเฟกต์การหมุน 3 มิติให้กับรูปร่างโดยการกำหนดคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/threedformat/) ของมัน

เพื่อใช้การหมุน 3 มิติบนรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน 
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ 
1. ใช้เมธอด [set_CameraType](https://reference.aspose.com/slides/th/cpp/aspose.slides/icamera/set_cameratype/) และ [set_LightType](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilightrig/set_lighttype/) เพื่อกำหนดการหมุน 3 มิติ 
1. บันทึกงานนำเสนอ 

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// บันทึกงานนำเสนอเป็นไฟล์ PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด C++ ต่อไปนี้แสดงวิธีการรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/layoutslide/) ไปยังการตั้งค่าเริ่มต้น:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มี placeholder บน layout.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์ของงานนำเสนอสุดท้ายหรือไม่?**

มีผลเพียงเล็กน้อย เท่านั้น ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์, และการไล่สีจะถูกเก็บเป็นเมตาดาต้าและแทบไม่มีการเพิ่มขนาดไฟล์เพิ่มเติม  

**ฉันจะตรวจจับรูปร่างในสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ถือว่าสไตล์ของมันเหมือนกันและจัดกลุ่มรูปร่างเหล่านั้นในเชิงตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น  

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้งานซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการไว้ในชุดสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อต้องสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่มีสไตล์ที่ต้องการ, แล้วนำการจัดรูปแบบของมันไปใช้ใหม่ในที่ที่ต้องการ.