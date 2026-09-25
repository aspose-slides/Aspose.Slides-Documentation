---
title: สร้างเอฟเฟกต์ 3D ในงานนำเสนอด้วย C++
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดัน 3D
- การไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความของ PowerPoint ใน C++ ด้วย Aspose.Slides กำหนดค่ากล้อง แสง วัสดุ การดัน การเติมและข้อความ 3D"
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถสร้าง แก้ไข เก็บรักษา และเรนเดอร์การจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน การดัน การทำบีเวล การจัดแสง วัสดุ การไล่สีหรือการเติมภาพ และข้อความ 3D

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แบบอิสระ เมื่อคุณส่งออกสไลด์เป็นรูปภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้เมธอด [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_threedformat/) เพื่อใช้การจัดรูปแบบ 3D กับรูปร่าง เมธอดจะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/) ซึ่งควบคุมฉาก 3D ของรูปร่างนั้น

สำหรับข้อความ ให้ใช้เมธอด [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/get_threedformat/) ซึ่งจะนำการจัดรูปแบบ 3D ไปใช้กับเฟรมข้อความแทนส่วนเนื้อหาของรูปร่าง

เมธอดที่สำคัญที่สุด ได้แก่

| Method | ควบคุมอะไร | เมื่อใดใช้ |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_camera/) | จุดมอง กล้องสำเร็จรูป การหมุน การขยาย และมุมมอง | หมุนวัตถุในพื้นที่ 3D หรือจับคู่กับพรีเซ็ตการหมุน 3D ของ PowerPoint |
| [get_LightRig](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_lightrig/) | แสงสำเร็จรูป ทิศทาง และการหมุนแสง | ปรับวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3D |
| [set_Material](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_material/) | วัสดุผิว เช่น แบน แมตต์ พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า นุ่มกว่า มีความเงาหรือเป็นโลหะ |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | ระยะที่รูปร่างยืดออกจากหน้ากหน้า | แปลงรูปร่างแบนเป็นวัตถุ 3D ที่มีความหนาเห็นได้ |
| [get_ExtrusionColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | สีของด้านที่ถูกดันออก | ทำให้ความลึกเห็นได้หรือประสานสีด้านข้างกับการเติมหน้า |
| [set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_depth/) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกละเอียดสำหรับรูปร่างหรือข้อความ โดยเฉพาะเมื่อใช้ร่วมกับบีเวลและวัสดุ |
| [get_BevelTop](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | ขอบยกหรือโค้งบนหน้าหน้าและด้านหลัง | เพิ่มขอบที่นุ่มหรือขึ้นรูปแทนหน้าที่แบนและคม |
| [get_ContourColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_contourwidth/) | เส้นขอบรอบวัตถุ 3D | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปแบบ 3D**

รูปร่างมักต้องการการตั้งสี่ประเภทก่อนที่จะแสดงเป็น 3D อย่างสมจริง:

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าตามค่าเริ่มต้นอาจซ่อนการดันออก
- การตั้งค่าแสง เนื่องจากแสงทำให้หน้าและด้านสามารถมองเห็นได้
- การตั้งค่าวัสดุ เพราะพื้นผิวมีผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันหรือความลึก เพราะรูปร่างแบนต้องมีความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม กำหนดข้อความบนหน้าหน้า และนำการจัดรูปแบบ 3D ไปใช้ ค่าการหมุนของกล้องเป็นองศาและความสูงการดันเป็น 100 จุด ตัวอย่างนี้เรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่าของค่าเริ่มต้นและบันทึกงานนำเสนอเป็น PPTX

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3D หนา:

![สี่เหลี่ยม 3D สีน้ำเงินที่เรนเดอร์พร้อมข้อความ 3D สีขาวบนหน้าหน้า](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint การหมุน 3D ถูกกำหนดจากพาเนล 3‑D Rotation ค่าการหมุน X, Y, Z จะสอดคล้องกับการตั้งค่าที่คุณกำหนดผ่าน API ของกล้อง

![พาเนล 3‑D Rotation ของ PowerPoint พร้อมค่าการหมุน X, Y, Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides ให้เข้าถึงกล้องผ่าน [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_camera/) ตัวอย่างนี้สร้างสี่เหลี่ยม เลือกมุมมองหน้าคณิตศาสตร์ และตั้งค่าการหมุน X, Y, Z ที่ 20, 30, 40 องศาตามลำดับ โดยกำหนดรูปทรงในหน่วยความจำโดยไม่บันทึกไฟล์:

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

presentation->Dispose();
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมเห็นวัตถุ มันไม่ได้เปลี่ยนรูปทรง 2D บนสไลด์ แต่เปลี่ยนจุดมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

## **เพิ่มการดันและความลึก**

การดันทำให้รูปร่างดูหนาโดยขยายออกจากหน้าหน้า ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่แมปกับสีการดันและคุณสมบัติความสูงการดัน](img_02_02.png)

ตั้งค่า [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) เพื่อกำหนดความหนาและ [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) เพื่อกำหนดสีด้านข้าง ตัวอย่างนี้ทำให้สี่เหลี่ยมมีการดัน 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา มันกำหนดรูปทรงในหน่วยความจำโดยไม่บันทึกไฟล์:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

เมธอด [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_depth/) กำหนดความลึกของรูปร่าง 3D เมธอด [set_ExtrusionHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ithreedformat/set_extrusionheight/) ควบคุมความสูงของเอฟเฟกต์การดันตามที่แสดงในตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D ไม่ขึ้นกับการเติมรูปร่าง คุณสามารถใช้สีทึบ การไล่สี พาเทิร์น หรือการเติมภาพบนหน้าหน้าได้โดยยังคงใช้การตั้งค่ากล้อง แสง วัสดุ และการดันเหมือนเดิม

ตัวอย่างนี้ใช้การไล่สีจากน้ำเงินไปส้มบนหน้าหน้าและสีส้มเข้มสำหรับการดัน 150 จุด การหยุดไล่สีที่ตำแหน่ง 0 และ 100 คือจุดเริ่มและจบของการไล่ สีการหมุนของกล้องเป็นองศา สไลด์จะเรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของค่าเริ่มต้น:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

ผลลัพธ์ที่เรนเดอร์ยังคงการไล่สีบนหน้าหน้าและเรนเดอร์การดันแยกจากกัน:

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการไล่สีจากน้ำเงินไปส้มและการดันสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพ ให้เพิ่มภาพเข้าไปในงานนำเสนอและกำหนดเป็นการเติมรูปร่าง ตัวอย่างนี้ต้องมีไฟล์ชื่อ "image.jpg" ในไดเรกทอรีทำงาน มันขยายรูปภาพให้เต็มสี่เหลี่ยม ใส่การดัน 150 จุด และตั้งค่าการหมุนกล้องเป็นองศา มันกำหนดรูปทรงในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

รูปภาพจะเรนเดอร์บนหน้าหน้า ส่วนการดันจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3D:

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการเติมรูปภาพบนหน้าหน้าและการดันสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างส่งผลต่อเนื้อหารูปร่าง ส่วนการจัดรูปแบบ 3D ของข้อความส่งผลต่อเฟรมข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดัน วัสดุ แสง และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยพาเทิร์นตารางสีส้มและขาว ใช้โค้งขึ้นด้านบน และกำหนดค่า 3D ผ่าน [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/get_threedformat/) ความสูงการดันและความลึกเป็นจุด และการหมุนแสงเป็นองศา การเติมและเส้นขอบของรูปร่างถูกซ่อนเพื่อให้เห็นเฉพาะข้อความ ตัวอย่างเรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของสไลด์เริ่มต้นและบันทึกงานนำเสนอเป็น PPTX:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

ข้อความถูกเรนเดอร์เป็นตัวอักษร 3D โค้งที่มีการดันเข้มสีส้ม:

![ข้อความ 3D ที่เรนเดอร์พร้อมการแปลง WordArt โค้ง พาเทิร์นสีส้ม และการดันสีเข้ม](img_02_05.png)

## **รักษาข้อความให้แบนบนรูปแบบ 3D**

เพื่อให้ข้อความอ่านง่ายขณะคงรูปร่าง 3D ให้เรียก [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_keeptextflat/) ผ่าน [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_textframeformat/) เมื่อค่าตรง `true` ข้อความจะอยู่นอกฉาก 3D เมื่อเป็น `false` ข้อความจะเข้าร่วมฉากและตามการจัดแนว 3D

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3D ของรูปร่าง: กล้อง แสง วัสดุ และการดันยังคงถูกตั้งค่าผ่าน [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_threedformat/) นอกจากนี้ยังแตกต่างจากการหมุนปกติ [IShape::set_Rotation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_rotation/) หมุนรูปร่างบนระนาบสไลด์ ในขณะที่ [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_rotationangle/) ควบคุมการหมุนกำหนดเองของข้อความภายในกล่องขอบเขต การทำให้ข้อความอยู่นอกฉาก 3D ไม่ได้รีเซ็ตมุมใด ๆ เหล่านั้น

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนาไว้ข้าง ๆ ทั้งสองรูปร่างมีการจัดรูปแบบ 3D เดียวกัน; เพียงการตั้งค่าข้อความต่างกัน: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศาและความสูงการดันเป็น 40 จุด ตัวอย่างบันทึกงานนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่าของค่าเริ่มต้น

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

ทางซ้ายข้อความตามแนว 3D ทางขวาข้อความคงแบนและอ่านง่ายขึ้น ทั้งสองสี่เหลี่ยมยังคงการดันและการจัดแนว 3D ที่เห็นได้เหมือนกัน

![สี่เหลี่ยม 3D คู่ข้าง: KeepTextFlat เป็น false ทางซ้ายและ true ทางขวา](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides จะคงการจัดรูปแบบ 3D เมื่อตบลงเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่ ฉาก 3D จะถูกเรเดอร์หรือวาดลงในผลลัพธ์เป็นภาพ 2D นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/cpp/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/cpp/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [การแปลงวิดีโอ](/slides/th/cpp/convert-powerpoint-to-video/)

ควรจำข้อเท็จจริงต่อไปนี้:

- ภาพที่ส่งออกและ PDF ไม่ใช่แบบโต้ตอบ ผู้ใช้ไม่สามารถหมุนวัตถุหลังการส่งออกได้
- รูปลักษณ์สุดท้ายขึ้นกับการรวมกันของกล้อง แสง วัสดุ การดัน การเติม และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [คุณสมบัติรูปร่างที่มีผล](/slides/th/cpp/shape-effective-properties/)
- รูปแบบผลลัพธ์บางรูปแบบไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์จะแสดงเป็นภาพเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D แบบโต้ตอบได้หรือไม่?**

Aspose.Slides จะสร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ แต่ไม่ได้ทำให้ภาพที่ส่งออก, PDF หรือหน้า HTML เป็นฉาก 3D ที่ผู้ชมสามารถหมุนได้ ในไฟล์ PPTX การจัดรูปแบบ 3D ยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D เป็นวัตถุ 3D แยกที่แทรกเข้ามาในงานนำเสนอ ส่วนเอฟเฟกต์ 3D เป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน การดัน บีเวล การจัดแสงและวัสดุ บทความนี้เน้นที่เอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้เห็นรูปร่าง 3D?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและการดันหรือความลึก ในทางปฏิบัติ ควรตั้งค่า LightRig และ Material ด้วยเพื่อให้หน้าตาแสงและเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_threedformat/) สำหรับส่วนเนื้อหารูปร่างและ [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/get_threedformat/) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะแน่นอน Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, PDF, HTML หรือเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์แล้ว ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าจุด 3D สุดท้ายหลังจากการสืบทอดและธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีผลที่อธิบายไว้ใน [คุณสมบัติรูปร่างที่มีผล](/slides/th/cpp/shape-effective-properties/) เพื่ออ่านกล้อง, LightRig, Bevel และค่าที่เกี่ยวข้องกับ 3D ที่ได้หลังจากการสืบทอดและธีมปรับใช้แล้ว