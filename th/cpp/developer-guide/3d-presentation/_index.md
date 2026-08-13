---
title: สร้างเอฟเฟกต์ 3 มิติในการนำเสนอด้วย C++
linktitle: การนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/cpp/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- การนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดันออก 3 มิติ
- ไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปทรงและข้อความของ PowerPoint ใน C++ ด้วย Aspose.Slides ตั้งค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถสร้าง, แก้ไข, รักษาและแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดันออก, การเบิล, การจัดแสง, วัสดุ, การไล่สีหรือการเติมรูปภาพ, และข้อความ 3 มิติ.

{{% alert color="info" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปทรงและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแยกส่วน เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นเข้าสู่ผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_threedformat/) ของอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปทรง เมธอดนี้จะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/), ซึ่งควบคุมฉาก 3 มิติของรูปทรงนั้น

สำหรับข้อความ, ใช้เมธอด [get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/get_threedformat/) ของอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/) วิธีนี้จะใช้การจัดรูปแบบ 3 มิติกับกรอบข้อความแทนส่วนเนื้อหาของรูปทรง

เมธอดที่สำคัญที่สุดคือ:

| เมธอด | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_camera/) | มุมมอง, ประเภทกล้องที่กำหนดไว้ล่วงหน้า, การหมุน, การซูม และการมองเชิงลึก. | หมุนวัตถุในพื้นที่ 3 มิติหรือจับคู่กับการตั้งค่าการหมุน 3 มิติของ PowerPoint ที่กำหนดไว้ล่วงหน้า. |
| [get_LightRig](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_lightrig/) | การตั้งค่าแสง, ทิศทาง, และการหมุนของแสง. | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ. |
| [set_Material](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_material/) | วัสดุปผิว เช่น แบน, แมต, พลาสติก หรือ โลหะ. | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, มีเงามากกว่า หรือเป็นโลหะ |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | ระยะที่รูปทรงขยายออกไปข้างหลังจากหน้าฝังหน้า. | เปลี่ยนรูปทรงแบนให้เป็นวัตถุ 3 มิติที่มองเห็นได้หนา |
| [get_ExtrusionColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | สีของด้านที่ดันออก. | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมสีหน้า |
| [set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_depth/) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ. | ปรับความลึกให้เหมาะสมสำหรับรูปทรงหรือข้อความ, โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่าเบิลและวัสดุ |
| [get_BevelTop](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | ขอบที่ยกขึ้นหรือโค้งมนบนหน้าฝังหน้าและหลัง. | เพิ่มขอบที่นุ่มหรือหล่อแทนหน้าฝังแบนคม |
| [get_ContourColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_contourwidth/) | โครงร่างรอบวัตถุ 3 มิติ. | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปทรง 3 มิติ**

รูปทรงมักต้องการการตั้งค่าสี่ประเภทก่อนที่จะดูเหมือนเป็น 3 มิติอย่างน่าเชื่อถือ:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าเริ่มต้นอาจซ่อนการดันออก.
- การตั้งค่าแสง, เนื่องจากแสงทำให้หน้าฝาและด้านอ่านได้.
- การตั้งค่าวัสดุ, เนื่องจากผิวส่งผลต่อการเรนเดอร์แสง.
- การตั้งค่าการดันออกหรือความลึก, เนื่องจากรูปแบนต้องการความหนา.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนหน้าฝา, ใช้การจัดรูปแบบ 3 มิติ, บันทึกงานนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมเป็นบล็อก 3 มิติหนา:

![สี่เหลี่ยม 3 มิติสีฟ้าเรนเดอร์พร้อมข้อความ 3 มิติสีขาวบนหน้าฝา](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint, การหมุน 3 มิติกำหนดจากแผง 3-D Rotation ค่า X, Y, และ Z ของการหมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง.

![แผง 3-D Rotation ของ PowerPoint ที่เน้นค่าการหมุน X, Y, และ Z](img_02_01.png)

ใน Aspose.Slides, ตั้งค่าประเภทกล้องและการหมุนผ่าน [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ ไม่ได้เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปทรงดูหนาโดยการขยายออกไปข้างหลังหน้าฝา ใน PowerPoint, การควบคุมความลึกตั้งค่าความหนาที่มองเห็นได้ และการควบคุมสีตั้งค่าสีของด้านข้าง.

![การควบคุมความลึกของ PowerPoint ที่แมพกับคุณสมบัติสีการดันออกและความสูงการดันออก](img_02_02.png)

ตั้งค่า [set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) สำหรับความหนาและ [get_ExtrusionColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) สำหรับสีด้านข้าง:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

ใช้ [set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_depth/) เมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับเบิล, วัสดุ, และเอฟเฟกต์ข้อความ ในหลายสถานการณ์รูปทรง `set_ExtrusionHeight` เป็นการตั้งค่าที่ชัดเจนกว่าเพราะแสดงการดันออกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติเป็นอิสระจากการเติมรูปทรง คุณสามารถเติมสีทึบ, ไล่สี, ลาย, หรือรูปภาพไปที่หน้าฝาและยังคงใช้กล้อง, แสง, วัสดุ, และการตั้งค่าการดันออกเดียวกันได้

ตัวอย่างนี้เติมไล่สีให้กับรูปทรงและใช้สีด้านข้างที่มืดกว่า:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

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

![สี่เหลี่ยม 3 มิติที่เรนเดอร์ด้วยการไล่สีจากฟ้าเป็นส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน, ให้เพิ่มรูปภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปทรง:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

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

![สี่เหลี่ยม 3 มิติที่เรนเดอร์ด้วยการเติมรูปภาพบนหน้าฝาและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปทรงมีผลต่อเนื้อหารูปทรง การจัดรูปแบบ 3 มิติของข้อความมีผลต่อกรอบข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรเองต้องการการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลาย, ใช้การแปลง WordArt, และตั้งค่าการจัดรูปแบบ 3 มิติบน [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/):

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

![ข้อความ 3 มิติที่เรนเดอร์ด้วยการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่, ฉาก 3 มิติจะถูกแปลงเป็นเรสเตอร์หรือวาดลงในผลลัพธ์เป็น 2 มิติ การนี้เกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/cpp/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/cpp/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/cpp/convert-powerpoint-to-video/).

- ภาพและ PDF ที่ส่งออกไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังจากส่งออกได้.
- รูปลักษณ์สุดท้ายขึ้นอยู่กับการรวมกันของกล้อง, แสง, วัสดุ, การดันออก, การเติม, และสเกลของสไลด์.
- หากคุณต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงธีม, ให้อ่าน [คุณสมบัติรูปทรงที่มีประสิทธิภาพ](/slides/th/cpp/shape-effective-properties/).
- รูปแบบผลลัพธ์บางอย่างไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์เชิงภาพจะถูกเรนเดอร์แทนที่จะถูกเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้.

## **คำถามที่พบบ่อย**

### Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปทรงและข้อความ ไม่ได้ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ในไฟล์ PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

### ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกที่แทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปทรงหรือข้อความทั่วไปของ PowerPoint เช่น การหมุน, การดันออก, เบิล, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

### ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3 มิติมองเห็นได้?

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและตั้งค่าการดันออกหรือความลึก ในการปฏิบัติจริงควรตั้งค่าแสงและวัสดุด้วยเพื่อให้หน้าฝาแสดงไฮไลท์และเงาชัดเจน

### ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปทรงและข้อความได้หรือไม่?

ได้ ใช้ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) สำหรับส่วนเนื้อหารูปทรงและ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/) สำหรับข้อความ

### เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?

จะปรากฏ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะการแสดงผลที่เรนเดอร์แล้ว ไม่ได้เป็นวัตถุ 3 มิติที่แก้ไขได้

### ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติขั้นสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมถูกนำไปใช้ได้หรือไม่?

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [คุณสมบัติรูปทรงที่มีประสิทธิภาพ](/slides/th/cpp/shape-effective-properties/) เพื่ออ่านค่ากล้อง, แสง, เบิล, และค่าการจัดรูปแบบ 3 มิติอื่น ๆ ที่สุดท้าย.