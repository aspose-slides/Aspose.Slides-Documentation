---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอโดยใช้ C++
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดันออก 3D
- ไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความของ PowerPoint ใน C++ ด้วย Aspose.Slides ตั้งค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถสร้าง แก้ไข รักษา และเรนเดอร์รูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน การดันออก (extrusion) การโค้ง (bevel) แสงสว่าง วัสดุ การไล่สี หรือการเติมรูปภาพ และข้อความ 3D

{{% alert color="primary" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกส่วน เมื่อคุณส่งออกสไลด์เป็นภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านี้ลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้เมธอด [get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_threedformat/) ของอินเทอร์เฟส [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) เพื่อใช้การจัดรูปแบบ 3D กับรูปร่าง เมธอดจะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/) ซึ่งควบคุมฉาก 3D ของรูปร่างนั้น

สำหรับข้อความ ให้ใช้เมธอด [get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/get_threedformat/) ของอินเทอร์เฟส [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/) วิธีนี้จะใช้การจัดรูปแบบ 3D กับเฟรมข้อความแทนส่วนเนื้อหาของรูปร่าง

เมธอดที่สำคัญที่สุดมีดังนี้:

| เมธอด | สิ่งที่ควบคุม | เมื่อใช้ |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_camera/) | มุมมอง ประเภทกล้องที่ตั้งไว้ การหมุน การซูม และการมองภาพเป็นเชิงลึก | หมุนอ็อบเจกต์ในพื้นที่ 3D หรือใช้ค่าที่ตั้งไว้ของ PowerPoint |
| [get_LightRig](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_lightrig/) | แสงตั้งล่วงหน้า ทิศทาง และการหมุนของแสง | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3D |
| [set_Material](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_material/) | วัสดุผิวหน้า เช่น แบน, mat, พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนขึ้น นุ่มขึ้น เงางาม หรือเป็นโลหะ |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | ระยะที่รูปร่างขยายไปด้านหลังจากพื้นหน้า | แปลงรูปร่างแบนให้เป็นอ็อบเจกต์ 3D ที่มองเห็นความหนา |
| [get_ExtrusionColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | สีของด้านที่ดันออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมด้านหน้า |
| [set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_depth/) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกของรูปร่างหรือข้อความ โดยมักใช้ร่วมกับ bevel และ material |
| [get_BevelTop](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_beveltop/) และ [get_BevelBottom](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | ขอบที่ยกขึ้นหรือโค้งบนหน้าหน้าและหลัง | เพิ่มขอบที่นุ่มหรือบ่นแทนที่จะเป็นพื้นแบนคม |
| [get_ContourColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_contourcolor/) และ [set_ContourWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_contourwidth/) | เส้นขอบรอบอ็อบเจกต์ 3D | เน้นขอบอ็อบเจกต์ในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3D**

โดยทั่วไปรูปร่างต้องตั้งค่าตามสี่ประเภทก่อนจะดูเหมือน 3D อย่างน่าเชื่อถือ:

- การตั้งค่ากล้อง เพราะมุมมองหน้าเริ่มต้นอาจซ่อนการดันออก
- การตั้งค่าแสง เพราะแสงทำให้หน้าและด้านอ่านง่าย
- การตั้งค่าวัสดุ เพราะพื้นผิวมีผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันออกหรือความลึก เพราะรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปสร้างสี่เหลี่ยม เพิ่มข้อความลงบนหน้าหน้า ใช้การจัดรูปแบบ 3D บันทึกพรีเซนเทชันเป็น PPTX และเรนเดอร์สไลด์เป็นภาพ PNG

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมเป็นบล็อก 3D หนา:

![สี่เหลี่ยม 3D สีฟ้า พร้อมข้อความ 3D สีขาวบนหน้าหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3D ตั้งค่าจากแผง 3‑D Rotation ค่า X, Y, Z สอดคล้องกับการหมุนที่คุณตั้งผ่าน API ของกล้อง

![แผง 3‑D Rotation ของ PowerPoint แสดงค่าการหมุน X, Y, Z ที่เน้นไว้](img_02_01.png)

ใน Aspose.Slides ให้ตั้งค่าชนิดกล้องและการหมุนผ่าน [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/) :

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนมุมมองของผู้ชมต่ออ็อบเจกต์ ไม่ได้เปลี่ยนรูปทรง 2D ของสไลด์ แต่เปลี่ยนจุดมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาโดยขยายไปด้านหลังของหน้าหน้า ใน PowerPoint ตัวควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และตัวควบคุมสีกำหนดสีของด้านข้าง

![ตัวควบคุมความลึกของ PowerPoint ที่เชื่อมกับคุณสมบัติ extrusion color และ extrusion height](img_02_02.png)

ตั้งค่า [set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) เพื่อกำหนดความหนาและ [get_ExtrusionColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) เพื่อกำหนดสีด้าน:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

ใช้ [set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_depth/) เมื่อต้องการทำงานกับค่าความลึกของ PowerPoint โดยตรง หรือผสานความลึกกับ bevel, material และเอฟเฟกต์ข้อความ ในหลายกรณี `set_ExtrusionHeight` จะชัดเจนกว่าเพราะบ่งบอกการดันออกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมรูปภาพร่วมกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D แยกจากการเติมรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, ลวดลาย หรือรูปภาพบนหน้าหน้าและยังคงใช้กล้อง, แสง, วัสดุ, การดันออกเดียวกันได้

ตัวอย่างนี้เติมไล่สีให้กับรูปร่างและสีด้านที่ดันออกสีเข้มขึ้น:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนหน้าหน้าและเรนเดอร์การดันออกแยกกัน:

![สี่เหลี่ยม 3D พร้อมการไล่สีจากน้ำเงินไปส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพ ให้เพิ่มรูปลงในพรีเซนเทชันและกำหนดให้เป็นการเติมรูปร่าง:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

รูปภาพจะถูกเรนเดอร์บนหน้าหน้า ส่วนการดันออกจะเรนเดอร์เป็นพื้นผิวด้าน 3D:

![สี่เหลี่ยม 3D พร้อมการเติมภาพบนหน้าหน้าและการดันออกสีส้ม](img_02_04.png)

## **นำการจัดรูปแบบ 3D ไปใช้กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างส่งผลต่อเนื้อหารูปร่าง ส่วนการจัดรูปแบบ 3D ของข้อความส่งผลต่อเฟรมข้อความ สิ่งนี้มีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดันออก, วัสดุ, แสงและการตั้งค่ากล้อง

ตัวอย่างต่อไปสร้างข้อความด้วยการเติมลวดลาย ใช้การแปลง WordArt และตั้งค่าการจัดรูปแบบ 3D บน [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/) :

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ข้อความจะถูกเรนเดอร์เป็นตัวอักษร 3D โค้ง, ดันออก:

![ข้อความ 3D ที่แปลงเป็น WordArt โค้ง, เติมลวดลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3D ไว้เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่ ฉาก 3D จะถูกแปลงเป็นภาพเรสเตอร์หรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2D นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/cpp/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/cpp/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/cpp/convert-powerpoint-to-video/)

ควรจำไว้:

- ภาพและ PDF ที่ส่งออกจะไม่โต้ตอบได้ ผู้ใช้ไม่สามารถหมุนอ็อบเจกต์หลังการส่งออกได้
- ลักษณะที่สุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, light rig, material, extrusion, fill, และการย่อสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [effective shape properties](/slides/th/cpp/shape-effective-properties/)
- รูปแบบเอาต์พุตบางประเภทไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ได้ผลลัพธ์ที่แสดงจะถูกเรนเดอร์แทนที่จะเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างพรีเซนเทชัน 3D ที่โต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3D ที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คืออ็อบเจกต์ 3D แยกที่แทรกลงในพรีเซนเทชัน ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่นำไปใช้กับรูปร่างหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน, การดันออก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เท่านั้น

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3D มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการดันออกหรือความลึก ในทางปฏิบัติควรตั้งค่า light rig และ material เพิ่มด้วยเพื่อให้พื้นผิวที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใส่เอฟเฟกต์ 3D ให้กับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) สำหรับเนื้อหารูปร่างและ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, PDF, HTML และเฟรมที่ใช้สำหรับการแปลงเป็นวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์แล้ว ไม่ใช่อ็อบเจกต์ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าจำนวน 3D สุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายใน [Shape Effective Properties](/slides/th/cpp/shape-effective-properties/) เพื่ออ่านค่ากล้อง, light rig, bevel, และค่าที่เกี่ยวข้องกับ 3D ที่สุดท้าย.