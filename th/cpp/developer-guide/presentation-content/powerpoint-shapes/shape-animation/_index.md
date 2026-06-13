---
title: ใช้แอนิเมชันรูปร่างในงานนำเสนอด้วย C++
linktitle: แอนิเมชันรูปร่าง
type: docs
weight: 60
url: /th/cpp/shape-animation/
keywords:
- รูปร่าง
- แอนิเมชัน
- เอฟเฟกต์
- รูปร่างแอนิเมชัน
- ข้อความแอนิเมชัน
- เพิ่มแอนิเมชัน
- รับแอนิเมชัน
- สกัดแอนิเมชัน
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ใช้แอนิเมชัน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแอนิเมชันรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++. โดดเด่น!"
---
## **บทนำ**

แอนิเมชันคือเอฟเฟกต์ภาพที่สามารถใช้กับข้อความ, รูปภาพ, รูปร่าง, หรือ [แผนภูมิ](/slides/th/cpp/animated-charts/). พวกมันให้ชีวิตแก่การนำเสนอหรือส่วนประกอบของมัน. 

## **ทำไมต้องใช้แอนิเมชันในงานนำเสนอ?**

ใช้แอนิเมชันคุณสามารถ 

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ฟัง
* ทำให้เนื้อหาอ่านง่ายหรือทำความเข้าใจหรือประมวลผลได้ง่ายขึ้น
* ดึงดูดความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในการนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือหลากหลายสำหรับแอนิเมชันและเอฟเฟกต์แอนิเมชันในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**. 

## **แอนิเมชันใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการเพื่อทำงานกับแอนิเมชันภายใต้เนมสเปซ [Aspose.Slides.Animation](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation).
* Aspose.Slides มีเอฟเฟกต์แอนิเมชันกว่า **150** รายการภายใต้การระบุ [EffectType](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเหมือนกับ (หรือเทียบเท่า) เอฟเฟกต์ที่ใช้ใน PowerPoint.

## **ใช้แอนิเมชันกับ TextBox**

Aspose.Slides สำหรับ C++ ช่วยให้คุณสามารถใช้แอนิเมชันกับข้อความในรูปร่างได้. 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape). 
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. รับลำดับหลักของเอฟเฟกต์.
6. เพิ่มเอฟเฟกต์แอนิเมชันให้กับ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape). 
7. ตั้งค่าคุณสมบัติ [TextAnimation.BuildType](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) ให้เป็นค่าจาก [BuildType Enumeration](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีการใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าแอนิเมชันของข้อความเป็นค่าที่ *By 1st Level Paragraphs* :

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

นอกจากการใช้แอนิเมชันกับข้อความแล้ว คุณยังสามารถใช้แอนิเมชันกับ [Paragraph](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_paragraph) หนึ่งรายการได้ ดูที่ [**Animated Text**](/slides/th/cpp/animated-text/).

{{% /alert %}} 

## **ใช้แอนิเมชันกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_frame) บนสไลด์. 
4. รับลำดับหลักของเอฟเฟกต์.
5. เพิ่มเอฟเฟกต์แอนิเมชันให้กับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_frame).
6. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีการใช้เอฟเฟกต์ `Fly` กับ picture frame:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// โหลดรูปภาพที่จะเพิ่มในคอลเลกชันรูปภาพของการนำเสนอ
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// เพิ่ม picture frame ไปยังสไลด์
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// รับลำดับหลักของสไลด์.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// เพิ่มเอฟเฟกต์แอนิเมชัน Fly จากด้านซ้ายให้กับ picture frame
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ใช้แอนิเมชันกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape). 
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) (เมื่อออบเจ็กต์นี้ถูกคลิก แอนิเมชันจะเล่น).
5. สร้างลำดับของเอฟเฟกต์บนรูปร่าง bevel.
6. สร้าง `UserPath` ที่กำหนดเอง.
7. เพิ่มคำสั่งสำหรับการย้ายไปยัง `UserPath`.
8. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีการใช้เอฟเฟกต์ `PathFootball` (path football) กับ Shape:

```c++
	// เส้นทางไปยังไดเรกทอรีเอกสาร.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// โหลดการนำเสนอ
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// เข้าถึงสไลด์แรก
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// เข้าถึงคอลเลกชันรูปร่างสำหรับสไลด์ที่เลือก
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// สร้างเอฟเฟกต์ PathFootball ให้กับรูปร่างที่มีอยู่ตั้งแต่ต้น.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// เพิ่มเอฟเฟกต์แอนิเมชัน PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// สร้างบางประเภทของ "ปุ่ม".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // สร้างเส้นทางผู้ใช้แบบกำหนดเอง. วัตถุของเราจะเคลื่อนที่เฉพาะหลังจากคลิกปุ่ม.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// เพิ่มคำสั่งการเคลื่อนที่เนื่องจากเส้นทางที่สร้างว่างเปล่า.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // เขียนไฟล์ PPTX ลงดิสก์
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **รับเอฟเฟกต์แอนิเมชันที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีการใช้เมธอด `GetEffectsByShape` จากอินเทอร์เฟซ [ISequence](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/) เพื่อรับเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับรูปร่าง.

**ตัวอย่างที่ 1: รับเอฟเฟกต์แอนิเมชันที่ใช้กับรูปร่างบนสไลด์ปกติ**

ก่อนหน้านี้คุณได้เรียนรู้วิธีเพิ่มเอฟเฟกต์แอนิเมชันให้กับรูปร่างในงานนำเสนอ PowerPoint. ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับเอฟเฟกต์ที่ใช้กับรูปร่างแรกบนสไลด์ปกติแรกในงานนำเสนอ `AnimExample_out.pptx`.

```c++
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

**ตัวอย่างที่ 2: รับเอฟเฟกต์แอนิเมชันทั้งหมด รวมถึงที่สืบทอดจาก placeholder**

หากรูปร่างบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์ layout และ/หรือ master, และมีการเพิ่มเอฟเฟกต์แอนิเมชันให้กับ placeholder เหล่านั้น, เอฟเฟกต์ทั้งหมดของรูปร่างจะถูกเล่นระหว่างการแสดงสไลด์, รวมถึงที่สืบทอดจาก placeholder.

สมมติว่าเรามีไฟล์ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งสไลด์ซึ่งมีเพียงรูปร่าง footer ที่มีข้อความ "Made with Aspose.Slides" และมีการใช้เอฟเฟกต์ **Random Bars** กับรูปร่างนั้น.

![เอฟเฟกต์แอนิเมชันรูปร่างสไลด์](slide-shape-animation.png)

สมมติเพิ่มเติมว่าเอฟเฟกต์ **Split** ถูกใช้กับ placeholder ของ footer บนสไลด์ **layout**.

![เอฟเฟกต์แอนิเมชันรูปร่าง Layout](layout-shape-animation.png)

และสุดท้ายเอฟเฟกต์ **Fly In** ถูกใช้กับ placeholder ของ footer บนสไลด์ **master**.

![เอฟเฟกต์แอนิเมชันรูปร่าง Master](master-shape-animation.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการใช้เมธอด `GetBasePlaceholder` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) เพื่อเข้าถึง placeholder ของรูปร่างและรับเอฟเฟกต์แอนิเมชันที่ใช้กับรูปร่าง footer, รวมถึงที่สืบทอดจาก placeholder ที่อยู่บนสไลด์ layout และ master.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// รับเอฟเฟกต์แอนิเมชันของรูปร่างบนสไลด์ปกติ.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// รับเอฟเฟกต์แอนิเมชันของ placeholder บนสไลด์ layout.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// รับเอฟเฟกต์แอนิเมชันของ placeholder บนสไลด์ master.
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
Type: 47, subtype: 2              // บิน, ด้านล่าง
Type: 134, subtype: 45            // แยก, เข้าตั้งแนวตั้ง
Type: 126, subtype: 22            // แถบสุ่ม, แนวนอน
```

## **เปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์แอนิเมชัน**

Aspose.Slides สำหรับ C++ ช่วยให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์แอนิเมชันได้.

นี่คือแผง Animation Timing ใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

ความสัมพันธ์ระหว่าง PowerPoint Timing กับคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) มีดังนี้:

- รายการดรอปดาวน์ **Start** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- รายการ **Duration** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.Duration](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). ระยะเวลาของแอนิเมชัน (วินาที) คือเวลาทั้งหมดที่แอนิเมชันใช้ในการทำรอบหนึ่ง. 
- รายการ **Delay** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

วิธีการเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์แอนิเมชัน.
2. ตั้งค่าคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) ที่ต้องการใหม่. 
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

โค้ด C++ นี้แสดงการดำเนินการ:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
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

## **เสียงของเอฟเฟกต์แอนิเมชัน**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์แอนิเมชัน:

- [set_Sound()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **เพิ่มเสียงของเอฟเฟกต์แอนิเมชัน**

โค้ด C++ นี้แสดงวิธีการเพิ่มเสียงของเอฟเฟกต์แอนิเมชันและหยุดเสียงเมื่อเอฟเฟกต์ถัดไปเริ่มทำงาน:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// เพิ่มเสียงไปยังคอลเลกชันเสียงของงานนำเสนอ
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

// รับลำดับเชิงโต้ตอบแรกของสไลด์.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// ตั้งค่าสถานะ "หยุดเสียงก่อนหน้า" ของเอฟเฟกต์
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **ดึงเสียงของเอฟเฟกต์แอนิเมชัน**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. รับลำดับหลักของเอฟเฟกต์. 
4. ดึงเสียงที่ฝังไว้ในแต่ละเอฟเฟกต์แอนิเมชันโดยใช้เมธอด [set_Sound()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effect/set_sound/). 

โค้ด C++ นี้แสดงวิธีการดึงเสียงที่ฝังอยู่ในเอฟเฟกต์แอนิเมชัน:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
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

## **After Animation**

Aspose.Slides สำหรับ C++ ช่วยให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์แอนิเมชันได้.

นี่คือแผง After Animation ใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

รายการดรอปดาวน์ After animation ของ PowerPoint ตรงกับคุณสมบัติดังนี้: 

- คุณสมบัติ [set_AfterAnimationType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) ซึ่งกำหนดประเภท After animation :
  * รายการ **More Colors** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/).
  * รายการ **Don't Dim** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/) (ค่าเริ่มต้นของ After animation).
  * รายการ **Hide After Animation** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/).
  * รายการ **Hide on Next Mouse Click** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/).
- คุณสมบัติ [set_AfterAnimationColor()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) ซึ่งกำหนดรูปแบบสีของ After animation. คุณสมบัตินี้ทำงานร่วมกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/). หากคุณเปลี่ยนประเภทเป็นค่าอื่น สีของ After animation จะถูกล้าง.

โค้ด C++ นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ After animation:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// รับเอฟเฟกต์แรกของลำดับหลัก
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// เปลี่ยนประเภท After animation เป็น Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// ตั้งค่าสีของ After animation dim
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animate Text**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์แอนิเมชัน:

- [set_AnimateTextType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) ซึ่งกำหนดประเภทการแอนิเมตข้อความของเอฟเฟกต์. ข้อความของรูปร่างสามารถแอนิเมตได้:
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/animatetexttype/) type)
  - ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/animatetexttype/) type)
  - ตามตัวอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/animatetexttype/) type)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ตั้งค่าความล่าช้าระหว่างส่วนของข้อความที่แอนิเมต (คำหรืออักษร). ค่าเป็นบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์. ค่าเป็นลบระบุความล่าช้าเป็นวินาที.

นี่คือวิธีการเปลี่ยนคุณสมบัติ Animate text ของเอฟเฟกต์:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์แอนิเมชัน.
2. ตั้งค่าคุณสมบัติ [set_BuildType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation.itextanimation/set_buildtype/) ให้เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/buildtype/) เพื่อปิดโหมดแอนิเมชัน *By Paragraphs*.
3. ตั้งค่าคุณสมบัติ [set_AnimateTextType()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) และ [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ใหม่ตามต้องการ.
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

โค้ด C++ นี้แสดงการดำเนินการ:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// รับเอฟเฟกต์แรกของลำดับหลัก
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// เปลี่ยนประเภทการแอนิเมชันข้อความของเอฟเฟกต์เป็น "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// เปลี่ยนประเภทการแอนิเมตข้อความของเอฟเฟกต์เป็น "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// ตั้งค่าความล่าช้ารหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
firstEffect->set_DelayBetweenTextParts(20.0f);

// บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันจะทำอย่างไรเพื่อให้แอนิเมชันคงอยู่เมื่อเผยแพร่การนำเสนอไปยังเว็บ?**

[Export to HTML5](/slides/th/cpp/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/) ที่รับผิดชอบต่อการแอนิเมชันของ [shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animateshapes/) และ [transition](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animatetransitions/). HTML ปกติไม่เล่นแอนิเมชันสไลด์, ส่วน HTML5 เล่นได้.

**การเปลี่ยนลำดับ z-order (ลำดับชั้น) ของรูปร่างส่งผลต่อแอนิเมชันอย่างไร?**

แอนิเมชันและลำดับการวาดเป็นสิ่งอิสระ: เอฟเฟกต์กำหนดเวลาและประเภทการปรากฏ/หายไป, ในขณะที่ [z-order](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_zorderposition/) กำหนดว่าอะไรอยู่เหนืออะไร. ผลลัพธ์ที่มองเห็นได้กำหนดโดยการผสมผสานของทั้งสอง (นี่คือพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และรูปร่างของ Aspose.Slides ยึดตามหลักการเดียวกัน).

**มีข้อจำกัดใดเมื่อแปลงแอนิเมชันเป็นวิดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?**

โดยทั่วไป [animations are supported](/slides/th/cpp/convert-powerpoint-to-video/), แต่ในบางกรณีหรือเอฟเฟกต์เฉพาะอาจแสดงผลต่างออกไป. แนะนำให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และเวอร์ชันของไลบรารี.