---
title: ใช้การเคลื่อนไหวรูปทรงในงานนำเสนอด้วย C++
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/cpp/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงที่เคลื่อนที่
- ข้อความที่เคลื่อนที่
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ใช้การเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งการเคลื่อนไหวของรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++. ทำให้โดดเด่น!"
---
## **บทนำ**

การเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถใช้กับข้อความ, รูปภาพ, รูปทรง, หรือ [แผนภูมิ](/slides/th/cpp/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา. 

## **ทำไมต้องใช้การเคลื่อนไหวในงานนำเสนอ?**

การใช้การเคลื่อนไหวคุณสามารถ

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ฟัง
* ทำให้เนื้อหาอ่านง่ายหรือประมวลผลได้ง่ายขึ้น
* ดึงดูดความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในงานนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือหลายอย่างสำหรับการเคลื่อนไหวและเอฟเฟกต์การเคลื่อนไหวในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**. 

## **การเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการสำหรับทำงานกับการเคลื่อนไหวภายใต้ namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation),
* Aspose.Slides มีเอฟเฟกต์การเคลื่อนไหวมากกว่า **150** ใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเป็นเอฟเฟกต์เดียวกัน (หรือเทียบเท่า) ที่ใช้ใน PowerPoint.

## **เพิ่มการเคลื่อนไหวให้กับ TextBox**

Aspose.Slides for C++ อนุญาตให้คุณเพิ่มการเคลื่อนไหวให้กับข้อความในรูปทรง. 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/).
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape). 
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. รับลำดับหลักของเอฟเฟกต์.
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape). 
7. ตั้งค่าคุณสมบัติ [TextAnimation.BuildType](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) ให้เป็นค่าจาก [BuildType Enumeration](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีการเพิ่มเอฟเฟกต์ `Fade` ให้กับ AutoShape และตั้งค่าการเคลื่อนไหวของข้อความเป็นค่า *By 1st Level Paragraphs* :

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape ใหม่พร้อมข้อความ
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// รับลำดับหลักของสไลด์
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// เพิ่มเอฟเฟกต์การเคลื่อนไหว Fade ให้กับ shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// ทำให้ข้อความของ shape เคลื่อนไหวตามย่อหน้าในระดับที่ 1
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

นอกเหนือจากการเพิ่มการเคลื่อนไหวให้กับข้อความแล้ว คุณยังสามารถเพิ่มการเคลื่อนไหวให้กับ [Paragraph](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_paragraph) เดียวได้ ดู [**Animated Text**](/slides/th/cpp/animated-text/).

{{% /alert %}} 

## **เพิ่มการเคลื่อนไหวให้กับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/) .
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_frame) บนสไลด์. 
4. รับลำดับหลักของเอฟเฟกต์.
5. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_frame).
6. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีการเพิ่มเอฟเฟกต์ `Fly` ให้กับ picture frame:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของการนำเสนอ
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// เพิ่ม picture frame ลงบนสไลด์
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// รับลำดับหลักของสไลด์
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly จากด้านซ้ายให้กับ picture frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **เพิ่มการเคลื่อนไหวให้กับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/) .
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape). 
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) (เมื่อออบเจ็กต์นี้ถูกคลิก การเคลื่อนไหวจะเริ่มเล่น).
5. สร้างลำดับของเอฟเฟกต์บนรูปทรง bevel.
6. สร้าง `UserPath` ที่กำหนดเอง.
7. เพิ่มคำสั่งสำหรับการเคลื่อนที่ไปยัง `UserPath`.
8. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีการเพิ่มเอฟเฟกต์ `PathFootball` (path football) ให้กับ shape:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// เส้นทางไปยังไดเรกทอรีของเอกสาร.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// โหลดการนำเสนอ
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// เข้าถึงสไลด์แรก
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// เข้าถึงคอลเลกชันรูปทรงของสไลด์ที่เลือก
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// สร้างเอฟเฟกต์ PathFootball สำหรับรูปทรงที่มีอยู่ตั้งแต่เริ่มต้น.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// เพิ่มเอฟเฟกต์การเคลื่อนไหว PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// สร้างบางอย่างที่คล้ายกับ "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // สร้างเส้นทางผู้ใช้แบบกำหนดเอง. วัตถุของเราจะเคลื่อนที่เฉพาะหลังจากคลิกปุ่ม.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// เพิ่มคำสั่งสำหรับการเคลื่อนที่เนื่องจากเส้นทางที่สร้างยังว่างเปล่า.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	//SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //เขียนไฟล์ PPTX ไปยังดิสก์
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีใช้เมธอด `GetEffectsByShape` จาก interface [ISequence](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/) เพื่อรับเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับ shape.

**Example 1: รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape บนสไลด์ปกติ**

ก่อนหน้านี้คุณได้เรียนรู้วิธีเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ shape ในการนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับเอฟเฟกต์ที่ใช้กับ shape แรกบนสไลด์ปกติงแรกในไฟล์ `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Example 2: รับเอฟเฟกต์การเคลื่อนไหวทั้งหมดรวมถึงที่สืบทอดจาก placeholders**

หาก shape บนสไลด์ปกติดี placeholders ที่อยู่บน layout slide หรือ master slide และมีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ placeholders เหล่านี้, แล้วเอฟเฟกต์ทั้งหมดของ shape จะเล่นในระหว่างการแสดงสไลด์รวมถึงที่สืบทอดจาก placeholders.

สมมุติว่าเรามีไฟล์ PowerPoint `sample.pptx` ที่มีสไลด์เดียวที่มี shape ส่วนท้ายที่มีข้อความ "Made with Aspose.Slides" และมีเอฟเฟกต์ **Random Bars** ถูกใช้กับ shape นี้.

![เอฟเฟกต์การเคลื่อนไหวของรูปบนสไลด์](slide-shape-animation.png)

สมมุติว่าเอฟเฟกต์ **Split** ถูกใช้กับ placeholder ส่วนท้ายบน **layout** slide.

![เอฟเฟกต์การเคลื่อนไหวของรูปบน layout](layout-shape-animation.png)

และสุดท้ายเอฟเฟกต์ **Fly In** ถูกใช้กับ placeholder ส่วนท้ายบน **master** slide.

![เอฟเฟกต์การเคลื่อนไหวของรูปบน master](master-shape-animation.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้เมธอด `GetBasePlaceholder` จาก interface [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides.ishape/) เพื่อเข้าถึง placeholders ของ shape และรับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ shape ส่วนท้าย รวมถึงที่สืบทอดจาก placeholders บน layout และ master slides.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// รับเอฟเฟกต์การเคลื่อนไหวของรูปทรงบนสไลด์ปกติ.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์เลย์เอาต์.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์มาสเตอร์.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // พุ่ง, ด้านล่าง
Type: 134, subtype: 45            // แยก, เข้าแนวตั้ง
Type: 126, subtype: 22            // แถบสุ่ม, แนวนอน
```

## **เปลี่ยนคุณสมบัติเวลาเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides for C++ อนุญาตให้คุณเปลี่ยนคุณสมบัติเวลา (Timing) ของเอฟเฟกต์การเคลื่อนไหว.

นี่คือแผง Animation Timing ใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

นี่คือความสอดคล้องระหว่าง PowerPoint Timing กับคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- รายการดรอปดาวน์ **Start** ของ PowerPoint Timing ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- PowerPoint Timing **Duration** ตรงกับคุณสมบัติ [Effect.Timing.Duration](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). ระยะเวลาของการเคลื่อนไหว (เป็นวินาที) คือเวลาทั้งหมดที่การเคลื่อนไหวใช้ในการทำหนึ่งรอบ. 
- PowerPoint Timing **Delay** ตรงกับคุณสมบัติ [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

นี่คือวิธีเปลี่ยนคุณสมบัติ Effect Timing:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.
2. ตั้งค่าคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) ใหม่ตามที่ต้องการ. 
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

โค้ด C++ นี้แสดงการดำเนินการ:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// รับลำดับหลักของสไลด์.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// รับเอฟเฟกต์แรกของลำดับหลัก.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// เปลี่ยนระยะเวลา (Duration) ของเอฟเฟกต์
effect->get_Timing()->set_Duration(3.f);

// เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **เสียงของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์การเคลื่อนไหว: 

- [set_Sound()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **เพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหว**

โค้ด C++ นี้แสดงวิธีการเพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหวและหยุดมันเมื่อเอฟเฟกต์ถัดไปเริ่มทำงาน:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// เพิ่มไฟล์เสียงลงในคอลเลกชันเสียงของการนำเสนอ
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// รับลำดับหลักของสไลด์.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// รับเอฟเฟกต์แรกของลำดับหลัก
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// ตรวจสอบว่าเอฟเฟกต์ไม่มีเสียง
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // เพิ่มเสียงให้กับเอฟเฟกต์แรก
    firstEffect->set_Sound(effectSound);
}

// รับลำดับแบบโต้ตอบแรกของสไลด์.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// ตั้งค่าสถานะ "หยุดเสียงก่อนหน้า" ของเอฟเฟกต์
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **สกัดเสียงจากเอฟเฟกต์การเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. รับลำดับหลักของเอฟเฟกต์. 
4. สกัดเสียงที่ฝังอยู่ในแต่ละเอฟเฟกต์การเคลื่อนไหวโดยใช้เมธอด [set_Sound()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effect/set_sound/). 

โค้ด C++ นี้แสดงวิธีสกัดเสียงที่ฝังอยู่ในเอฟเฟกต์การเคลื่อนไหว:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// รับลำดับหลักของสไลด์.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **หลังการเคลื่อนไหว**

Aspose.Slides for C++ อนุญาตให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์การเคลื่อนไหว.

นี่คือแผง Animation Effect และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

รายการดรอปดาวน์ **After animation** ของ PowerPoint Effect ตรงกับคุณสมบัติเหล่านี้: 

- คุณสมบัติ [set_AfterAnimationType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) ซึ่งอธิบายประเภท After animation :
  * รายการ **More Colors** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/);
  * รายการ **Don't Dim** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/) (ประเภท After animation เริ่มต้น);
  * รายการ **Hide After Animation** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/);
  * รายการ **Hide on Next Mouse Click** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/);
- คุณสมบัติ [set_AfterAnimationColor()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) ซึ่งกำหนดรูปแบบสี After animation. คุณสมบัตินี้ทำงานร่วมกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/). หากคุณเปลี่ยนประเภทเป็นอย่างอื่น สี After animation จะถูกล้าง.

โค้ด C++ นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ After animation:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// รับเอฟเฟกต์แรกของลำดับหลัก
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// เปลี่ยนประเภท After animation เป็นสี
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// ตั้งค่าสี After animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **เคลื่อนไหวข้อความ**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์การเคลื่อนไหว:

- [set_AnimateTextType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) ซึ่งอธิบายประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์. ข้อความของ shape สามารถเคลื่อนไหวได้:
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/animatetexttype/) type)
  - ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/animatetexttype/) type)
  - ตามอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/animatetexttype/) type)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ตั้งค่าการหน่วงเวลาระหว่างส่วนของข้อความที่เคลื่อนไหว (คำหรืออักษร). ค่าบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์. ค่าลบระบุหน่วงเวลาเป็นวินาที.

นี่คือวิธีการเปลี่ยนคุณสมบัติ Effect Animate text:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.
2. ตั้งค่าคุณสมบัติ [set_BuildType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation.itextanimation/set_buildtype/) ให้เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/buildtype/) เพื่อปิดโหมดการเคลื่อนไหว *By Paragraphs*.
3. ตั้งค่าคุณสมบัติใหม่สำหรับ [set_AnimateTextType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) และ [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

โค้ด C++ นี้แสดงการดำเนินการ:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// รับเอฟเฟกต์แรกของลำดับหลัก
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์เป็น "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// เปลี่ยนประเภท Animate text ของเอฟเฟกต์เป็น "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// ตั้งค่าการหน่วงเวลาระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
firstEffect->set_DelayBetweenTextParts(20.0f);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### ฉันจะทำอย่างไรให้แน่ใจว่าการเคลื่อนไหวยังคงอยู่เมื่อเผยแพร่การนำเสนอไปยังเว็บ?

[Export to HTML5](/slides/th/cpp/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/) ที่รับผิดชอบสำหรับ [shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [transition](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animatetransitions/) animation. HTML ธรรมดาไม่สามารถเล่นการเคลื่อนไหวของสไลด์ได้, ในขณะที่ HTML5 ทำได้.

### การเปลี่ยนลำดับ z-order (ลำดับชั้น) ของ shape มีผลต่อการเคลื่อนไหวอย่างไร?

การเคลื่อนไหวและลำดับการวาดเป็นอิสระกัน: เอฟเฟกต์ควบคุมเวลาและประเภทของการปรากฏ/หายไป, ส่วน [z-order](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_zorderposition/) กำหนดว่าอะไรจะบังอะไร. ผลลัพธ์ที่มองเห็นจะกำหนดโดยการผสมผสานของทั้งสอง (นี่คือพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และ shape ของ Aspose.Slides ทำตามตรรกะเดียวกัน).

### มีข้อจำกัดอะไรเมื่อแปลงการเคลื่อนไหวเป็นวิดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?

โดยทั่วไป [animations are supported](/slides/th/cpp/convert-powerpoint-to-video/), แต่ในบางกรณีหรือเอฟเฟกต์เฉพาะอาจแสดงผลต่างกัน. แนะนำให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.