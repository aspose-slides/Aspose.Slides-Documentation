---
title: สร้างและแก้ไขพฤติกรรมการเคลื่อนไหวแบบกำหนดเองใน C++
linktitle: การเคลื่อนไหวแบบกำหนดเอง
type: docs
weight: 151
url: /th/cpp/custom-animation/
keywords:
- การเคลื่อนไหวแบบกำหนดเอง
- พฤติกรรมการเคลื่อนไหว
- เส้นทางการเคลื่อนที่
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมการเคลื่อนไหวแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

พฤติกรรมการเคลื่อนไหวที่กำหนดเองช่วยให้คุณควบคุมการดำเนินการแต่ละอย่างภายในผลกระทบการเคลื่อนไหว เช่น การเปลี่ยนสี การหมุนรูปทรง หรือการตามเส้นทางการเคลื่อนไหวที่แก้ไขได้ คู่มือนี้แสดงวิธีสร้างและรวมพฤติกรรม ตั้งค่าเวลา ตรวจสอบและแก้ไขการเคลื่อนไหวที่มีอยู่ และยืนยันว่าคุณสมบัติของพวกมันคงอยู่หลังจากบันทึกและเปิดงานนำเสนอใหม่

สำหรับเอฟเฟกต์ที่กำหนดไว้ล่วงหน้าและทริกเกอร์คลิก ดูที่ [การเคลื่อนไหวของรูปทรง](/slides/th/cpp/shape-animation/)

## **ทำความเข้าใจโมเดลการเคลื่อนไหว**

การเคลื่อนไหวถูกจัดระเบียบเป็น **Timeline → Sequence → Effect → Behaviors**:

- สไลด์ของคุณที่มี [get_Timeline](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_timeline/) จะมีลำดับหลักและลำดับเชิงโต้ตอบ
- [ISequence](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/) ประกอบด้วยเอฟเฟกต์ ซึ่งอาจเป้าหมายที่รูปทรงต่าง ๆ
- [IEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/) ระบุรูปทรงเป้าหมาย, พรีเซ็ต, ชนิดย่อย, และเวลาของเอฟเฟกต์
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/get_behaviors/) มีการดำเนินการที่ทำให้เอฟเฟกต์ทำงาน: การเปลี่ยนสี, การเคลื่อนที่, การหมุน, การตั้งค่าคุณสมบัติ ฯลฯ

## **สร้างพฤติกรรมแต่ละรายการ**

เรียกใช้ [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/) เพื่อสร้างเอฟเฟกต์และเข้าถึงคอลเลกชัน [get_Behaviors](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/get_behaviors/) พรีเซ็ตสามารถเติมคอลเลกชันนี้โดยอัตโนมัติ ควรเก็บการดำเนินการไว้เมื่อขยายพรีเซ็ต หรือใช้ [Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/clear/) เมื่อต้องการแทนที่อย่างเจตนา

[IBehaviorFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/) สร้างพฤติกรรมประเภทแปดที่แสดงด้านล่าง การเคลื่อนที่จะอธิบายในหัวข้อ [สร้างเส้นทางการเคลื่อนที่](#build-a-motion-path) ตัวอย่างการสร้างแต่ละประเภทเป็นโค้ดที่ทำงานได้ภายในฟังก์ชัน; ตัวอย่างการแก้ไขภายหลังจะระบุไฟล์ผลลัพธ์ที่ใช้

### **การหมุน**

ใช้ [CreateRotationEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) เพื่อสร้างการหมุน [get_By](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/irotationeffect/get_by/) ระบุมุมสัมพัทธ์เป็นองศา; [get_From](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/irotationeffect/get_from/) และ [get_To](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/irotationeffect/get_to/) ระบุจุดเริ่มและสิ้นสุด

ตัวอย่างเริ่มด้วยเอฟเฟกต์ Spin แล้วแทนที่การดำเนินการของพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งรายการ และกำหนดระยะเวลาให้สองวินาที มุมสัมพัทธ์ 90 องศาแสดงการหมุนหนึ่งในสี่รอบจากทิศทางเริ่มต้นของรูปทรง จึงไม่ต้องกำหนดมุมเริ่มต้นอย่างชัดเจน

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` มีรูปทรงหนึ่งรูปและพฤติกรรมการหมุนหนึ่งรายการ คอลเลกชัน เวลา และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การขยายขนาด**

ใช้ [CreateScaleEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) พร้อมเปอร์เซ็นต์ X/Y: [get_From](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/iscaleeffect/get_from/) และ [get_To](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/iscaleeffect/get_to/) ระบุขนาดเริ่มและขนาดสุดท้าย, ส่วน [get_By](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/iscaleeffect/get_by/) ระบุการเปลี่ยนแปลงสัมพัทธ์ ที่นี่ 100 หมายถึงขนาดเดิม

ตัวอย่างทำให้ทั้งสองมิติจาก 100% เพิ่มเป็น 125% ในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันจะรักษาสัดส่วนของรูปทรง; เปอร์เซ็นต์ที่ต่างกันจะยืดมิติหนึ่งมากกว่ามิติอื่น

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **สี**

ใช้ [CreateColorEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) เพื่อเปลี่ยนสีเติมจากสีน้ำเงินเป็นสีส้ม [get_From](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/icoloreffect/get_from/) และ [get_To](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/icoloreffect/get_to/) เป็นสี; [get_By](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/icoloreffect/get_by/) เป็นการเปรียบเทียบสี [IBehavior::get_Properties](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehavior/get_properties/) ระบุตัวแปรที่ถูกเคลื่อนไหว

สีเติมของรูปทรงเริ่มต้นเป็นสีน้ำเงิน ตรงกับสีเริ่มต้นของการเคลื่อนไหว การเลือกแอตทริบิวต์สีเติมบอกพฤติกรรมว่าจะเปลี่ยนส่วนใดของรูปทรง; จุดสิ้นสุดของสีเพียงอย่างเดียวดังกล่าวไม่ได้ระบุตัวแอตทริบิวต์เอง เอฟเฟกต์ที่บันทึกไว้บรรยายการเปลี่ยนแปลงสองวินาทีไปเป็นสีส้ม

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **ฟิลเตอร์**

ใช้ [CreateFilterEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) เพื่อเลือกการไหลเอ็กซ์ (wipe) [get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), และ [get_Reveal](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) ระบุฟิลเตอร์, ทิศทาง, และว่าจะเปิดหรือซ่อนรูปทรง

ตัวอย่างนี้กำหนดการไหลเอ็กซ์สองวินาทีที่เปิดเผยรูปทรงโดยใช้ชนิดย่อยทิศทางขวา การตั้งค่าฟิลเตอร์เป็นของพฤติกรรมภายในเอฟเฟกต์ จึงกำหนดหลังจากลบการดำเนินการดั้งเดิมของพรีเซ็ตออกแล้ว

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **คุณสมบัติ**

ใช้ [CreatePropertyEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) เพื่อเคลื่อนไหวความทึบแสง [get_From](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ipropertyeffect/get_to/), และ [get_By](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ipropertyeffect/get_by/) เป็นสตริงที่ตีความโดยใช้ [get_ValueType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) และ [get_CalcMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) เลือกจุดสิ้นสุดหรือออฟเซ็ตสัมพัทธ์แทนการตั้งค่าทั้งสามพร้อมกัน

ที่นี่แอตทริบิวต์ที่เลือกคือความทึบแสง และสตริงตัวเลขแสดงการเปลี่ยนจากความทึบ 25% ไปเป็นความทึบเต็ม การอินเทอร์โพเลชันเชิงเส้นบรรยายการเปลี่ยนแปลงแบบค่อยเป็นค่อยไประหว่างค่าทั้งสอง เมื่อปรับตัวอย่างนี้ไปยังแอตทริบิวต์อื่น ให้เลือกประเภทค่าและค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **ตั้งค่า**

ใช้ [CreateSetEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) เพื่อกำหนดความมองเห็นผ่าน [get_To](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/iseteffect/get_to/) พฤติกรรมชุด (set) ไม่ทำการอินเทอร์โพเลชันระหว่างจุดสิ้นสุด

ตัวอย่างเลือกแอตทริบิวต์ความมองเห็นและกำหนดสตริง `visible` เมื่อพฤติกรรมทำงาน ใน C++ ให้ห่อสตริงเป็นอ็อบเจ็กต์ก่อนกำหนดให้กับพฤติกรรมชุด สี่เหลี่ยมมองเห็นอยู่แล้วในงานนำเสนอขั้นพื้นฐานนี้ ดังนั้นการกำหนดอาจไม่ทำให้เห็นการเปลี่ยนแปลงที่ชัดเจนเอง การดำเนินการเช่นนี้มีประโยชน์เมื่อนำไปใช้ร่วมกับเอฟเฟกต์ที่ควบคุมการซ่อนหรือแสดงรูปทรงในช่วงเวลาต่าง ๆ

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **คำสั่ง**

ใช้ [CreateCommandEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) และตั้งค่า [get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), และ [get_ShapeTarget](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/) ใส่ไฟล์เสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์ด้วย [AddAudioFrameEmbedded](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) แล้วแนบคำสั่งเล่นให้กับเฟรมเสียง

เฟรมเสียงเป็นทั้งเป้าหมายของเอฟเฟกต์และเป้าหมายของคำสั่ง การเชื่อมคำสั่งเล่นกับไฟล์เสียงที่ฝังอยู่ทำให้คำสั่งเล่นทำงาน; สตริงคำสั่งอย่างเดียวไม่บ่งบอกว่าจะควบคุมสื่อใด เอฟเฟกต์ตั้งค่าให้เริ่มเมื่อตอนคลิกในขณะสไลด์โชว์

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

การบันทึกจะเก็บคำสั่งไว้ใน `command.pptx`; ไฟล์นั้นจะไม่เล่นเสียง การเล่นต้องใช้โปรแกรมสไลด์โชว์ที่รองรับคำสั่งและสื่อเป้าหมาย

## **จัดการคอลเลกชันพฤติกรรม**

[IBehaviorCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/) รองรับ [Add](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/remove/), และ [RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/removeat/) ตัวอย่างนี้เปิด `rotation.pptx`, เพิ่มการขยายขนาด, ย้ายมันก่อนการหมุน, และลบการหมุน การลบและใส่กลับวัตถุเดียวกันจะเปลี่ยนตำแหน่งที่จัดเก็บโดยไม่ทำสำเนา

ลำดับของการแก้ไขเปลี่ยนคอลเลกชันจาก rotation–scale ไปเป็น scale–rotation แล้วเป็น scale เพียงอย่างเดียว ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังจากจัดลำดับใหม่ การนับสุดท้ายยืนยันว่าพฤติกรรมใดจะถูกบันทึก

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

ผลลัพธ์คือ `ScaleEffect`: เหลือเพียงการขยายขนาด คอลเลกชันไม่ได้กำหนดให้พฤติกรรมทำงานต่อเนื่องโดยอัตโนมัติ ใช้ Clear คอลเลกชันเฉพาะเมื่อแทนที่การดำเนินการทั้งหมด

## **กำหนดเวลาพฤติกรรม**

[IBehavior::get_Timing](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehavior/get_timing/) เปิดเผย [ITiming](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/) อย่างอิสระจาก [IEffect::get_Timing](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/get_timing/) เวลาเอฟเฟกต์กำหนดการทำงานของเอฟเฟกต์รอบนอก; เวลาพฤติกรรมบรรยายการดำเนินการภายในเอฟเฟกต์นั้น

### **กำหนดระยะเวลา, ความหน่วง, การทำซ้ำ, และการเร่งความเร็ว**

เปิด `rotation.pptx` แล้วตั้งค่า [get_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_duration/) และ [get_TriggerDelayTime](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) เป็นวินาที จากนั้นกำหนด [get_RepeatCount](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_repeatcount/) [get_Accelerate](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_accelerate/) และ [get_Decelerate](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_decelerate/) เป็นส่วนของระยะเวลา; รักษาผลรวมไม่เกิน 1

ไฟล์อินพุตเป็นไฟล์ที่สร้างในตัวอย่างการหมุน ซึ่งพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนเฉพาะเวลาของพฤติกรรมนั้น; มุม 90 องศายังคงเดิม การแยกมุมและเวลาออกจากกันทำให้ปรับจังหวะได้โดยไม่ต้องสร้างเอฟเฟกต์ใหม่

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

พฤติกรรมใช้ระยะเวลา 2 วินาที, หน่วงครึ่งวินาที, และทำซ้ำ 3 ครั้ง 20% แรกและสุดท้ายของระยะเวลาใช้สำหรับการเร่งและการชะลอ

นโยบายการทำซ้ำอื่น ๆ ได้แก่ [get_RepeatDuration](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), และ [get_RepeatUntilNextClick](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/) – เลือกนโยบายหนึ่งแทนการเปิดทั้งหมดพร้อมกัน [get_AutoReverse](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/get_autoreverse/) ทำให้การเคลื่อนไหวเล่นย้อนกลับหลังจากเล่นไปข้างหน้า การเร่งและการชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าตรงหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนที่**

ใช้ [CreateMotionEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) เพื่อสร้างการเคลื่อนที่ [get_From](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioneffect/get_to/), และ [get_By](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioneffect/get_by/) บรรยายพิกัดหรือออฟเซ็ตเป็นเปอร์เซ็นต์ สำหรับเส้นทางที่แก้ไขได้ สร้าง [MotionPath](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/motionpath/) และกำหนดให้กับ [IMotionEffect::get_Path](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioneffect/get_path/) [IMotionPath](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotionpath/) เก็บคำสั่งของเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/motioncommandpathtype/) เลือกการดำเนินการ:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | หนึ่ง | ตั้งค่าตำแหน่งเริ่มต้น |
| LineTo | หนึ่ง | ย้ายตามส่วนตรงไปยังจุดสิ้นสุด |
| CurveTo | สาม | ตามเส้นโค้งลูกบาศก์ที่กำหนดโดยจุดควบคุมสองจุดและจุดสิ้นสุด |
| CloseLoop | ไม่มี | กลับไปยังตำแหน่งเริ่มต้น |
| End | ไม่มี | สิ้นสุดเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/motionpathpointstype/) บรรยายลักษณะการแก้ไขจุด เช่น จุดมุมหรือจุดเรียบ ไม่ได้แทนที่ประเภทคำสั่ง ใช้ประเภทจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง, และประเภทจุดมุมสำหรับส่วนตรง

พิกัดของเส้นทางถูกทำให้เป็นสเกลตามขนาดสไลด์: การเคลื่อนที่ X 0.25 หมายถึงหนึ่งในสี่ของความกว้างสไลด์, ไม่ใช่ 0.25 พิกเซล Y บวกลงไปเป็นด้านล่าง คำสั่งแบบ Absolute ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่งแบบ Relative ระบุออฟเซ็ตจากตำแหน่งปัจจุบัน นี่แยกจาก [get_Origin](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioneffect/get_origin/) ที่เลือกกรอบอ้างอิงของเส้นทาง, และ [get_PathEditMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อรูปทรงเคลื่อนที่

### **สร้างเส้นทางตรง**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่ม, ส่วนตรงหนึ่ง, และคำสั่ง End [IMotionPath::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotionpath/add/) รับประเภทคำสั่ง, จุดของมัน, ประเภทจุด, และแฟล็กพิกัดสัมพัทธ์

คำสั่งเริ่มต้นกำหนด (0, 0) แล้วเส้นสิ้นสุดที่ (0.25, 0) ให้เส้นทางเคลื่อนที่แนวนอนหนึ่งในสี่ของความกว้างสไลด์ คำสั่ง End ไม่มีจุดพิกัด เมื่อกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่ให้กับเอฟเฟกต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยม

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งรายการพร้อมสามคำสั่งเส้นทาง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้ใช้โครงสร้างนี้

### **เปรียบเทียบพิกัด Absolute กับ Relative**

สองวัตถุเส้นทางนี้บรรยายเส้นทางเดียวกัน คำสั่ง Absolute สิ้นสุดที่ (0.3, 0.1); คำสั่ง Relative เพิ่ม (0.1, 0.1) ไปยังตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นทางเริ่มจากตำแหน่งเดียวกัน สำหรับเส้น Relative ให้บวกออฟเซ็ต X และ Y กับตำแหน่งปัจจุบันเพื่อให้ได้จุดสิ้นสุด; สำหรับเส้น Absolute ให้อ่านจุดสิ้นสุดโดยตรง การสลับแฟล็กโดยไม่แปลงพิกัดจะทำให้เส้นทางต่างกัน

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

กำหนดเส้นทางใดก็ได้ให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ อาร์กิวเมนต์ Boolean สุดท้ายเลือกพิกัดสัมพัทธ์สำหรับคำนั้น

### **แทนที่เส้นตรงด้วยเส้นโค้ง**

เปิด `motion.pptx` แล้วแทนที่คำสั่งเส้นตรงด้วยโค้งลูกบาศก์ ใส่จุดควบคุมสองจุดก่อน, ตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นมาจากคำสั่งก่อนหน้า จุดสองแรกกำหนดรูปร่างของโค้ง, จุดที่สามเป็นจุดสิ้นสุด; ไม่ได้เป็นจุดปลายต่อเนื่องสามจุด การอัปเดตประเภทคำสั่ง, ประเภทจุดแก้ไข, และอาเรย์จุดพร้อมกันทำให้ส่วนนี้สอดคล้องกับเรขาคณิตใหม่

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

เส้นทางใน `curve.pptx` ยังคงมีสามคำสั่ง; คำสั่งกลางตอนนี้เป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [IMotionCmdPath](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioncmdpath/) เปิดเผย [get_Points](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), และ [get_IsRelative](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/) ตัวอย่างต่อไปใช้เส้นทางสามคำสั่งที่รู้จักใน `motion.pptx` สำหรับอินพุตใด ๆ ให้ค้นหาเอฟเฟกต์ที่ต้องการและตรวจสอบประเภทคำสั่งและจำนวนจุดก่อนแก้ไขตามดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ CloseLoop ไม่ต้องการจุด จึงต้องเตรียมอาเรย์จุดเป็น null

ผลลัพธ์แสดงแต่ละคำสั่งพร้อมแฟล็กพิกัดสัมพัทธ์ก่อนแสดงจุดของมัน ทำให้คุณแยกจุดสิ้นสุดจากออฟเซ็ตก่อนแก้ไขเส้นทาง โค้งจะแสดงสามจุด, ในขณะที่เส้นตรงในไฟล์นี้แสดงเพียงหนึ่งจุด

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

รายการประกอบด้วยจุดเริ่มต้น, เส้น Absolute สิ้นสุดที่ (0.25, 0), และคำสั่ง End

### **เปลี่ยนจุดสิ้นสุด**

เปิด `motion.pptx` แล้วแทนที่อาเรย์จุดของเส้นเพื่อย้ายจุดสิ้นสุด

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้นและดัชนี 1 คือเส้น การแทนที่จุดเดียวของเส้นจะเปลี่ยนตำแหน่งปลายโดยไม่เปลี่ยนประเภทคำสั่ง, เวลา, หรือตำแหน่งในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัด Absolute คู่ใหม่จึงระบุตำแหน่งแทนออฟเซ็ตที่เพิ่ม

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

เส้นใน `motion-endpoint.pptx` สิ้นสุดที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่เปลี่ยน

### **แทนที่ส่วน**

ใช้ [Insert](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotionpath/insert/) และ [RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/imotionpath/removeat/) เพื่อแทนที่เส้นใน `motion.pptx` การแทรกจะทำให้เส้นเก่าขยับไปยังดัชนี 2

นี่แสดงการแทนที่อ็อบเจ็กต์คำสั่งแทนการแก้ไขพิกัดเดิม หลังการแทรก คอลเลกชันจะชั่วคราวมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, และคำสั่ง End การลบดัชนี 2 จะกำจัดเส้นเก่าและเหลือเส้นใหม่เป็นเส้นทางสุดท้าย

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

เส้นทางที่บันทึกยังคงมีสามคำสั่ง, เส้นใหม่สิ้นสุดที่ (0.2, 0.1) และคำสั่ง End อยู่สุดท้าย

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีพฤติกรรม ให้เลือกตามประเภท ตัวอย่างนี้เปิด `rotation.pptx`, ค้นหา [IRotationEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/irotationeffect/) เปลี่ยนมุม, แล้วตรวจสอบค่าที่บันทึกหลังจากเปิดใหม่

การตรวจสอบประเภททำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์บันทึกเข้าสู่วัตถุพรีเซนเทชันแยกต่างหาก ดังนั้นการเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่ไม่ใช่ค่าที่ยังอยู่ในหน่วยความจำ ตัวอย่างนี้ยังคงสมมติว่าเอฟเฟกต์ที่รู้จักอยู่เป็นรายการแรกในลำดับหลัก; การเลือกพฤติกรรมตามประเภทไม่ได้บอกตำแหน่งเอฟเฟกต์ที่ถูกต้องในพรีเซนเทชันใดก็ได้

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

ผลลัพธ์คือ `Rotation preserved: True` ใช้รูปแบบการตรวจสอบประเภทเดียวกันสำหรับพฤติกรรมอื่น ๆ สำหรับการตรวจสอบการคงอยู่อย่างครบถ้วน ให้เปรียบเทียบรูปทรงเป้าหมาย, เอฟเฟกต์, ประเภทและลำดับพฤติกรรม, เวลา, และคำสั่งเส้นทาง ใช้ความคลาดเคลื่อนเชิงตัวเลขสำหรับค่าจุดทศนิยม สำหรับพรีเซนเทชันที่มีเค้าโครงการเคลื่อนไหวไม่ทราบ, ดูที่ [อ่านการเคลื่อนไหวของรูปทรง](/slides/th/cpp/shape-animation/#read-shape-animations) เพื่อสำรวจลำดับหลักและลำดับเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [IBehaviorCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehaviorcollection/) คือลำดับที่จัดเก็บของการดำเนินการเอฟเฟกต์ ไม่ได้เป็นเพลย์ลิสต์ที่พฤติกรรมทุกอย่างรอคอยอัตโนมัติจากก่อนหน้า เวลาและเอฟเฟกต์ที่บรรจุกำหนดการจัดตาราง พฤติกรรมสามารถทับซ้อนกันได้, การดำเนินการบนคุณสมบัติเดียวกันอาจโต้ตอบผ่าน [get_Additive](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehavior/get_additive/) และ [get_Accumulate](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ibehavior/get_accumulate/) อย่าใช้การจัดลำดับคอลเลกชันอย่างเดียวเพื่อกำหนด “ย้าย แล้วหมุน”; ใช้เวลาที่ชัดเจนหรือเอฟเฟกต์แยกตามที่อธิบายใน [การเคลื่อนไหวของรูปทรง](/slides/th/cpp/shape-animation/)

ประเภทของเอฟเฟกต์ [get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/get_type/) และ [get_Subtype](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/get_subtype/) บรรยายพรีเซ็ตของมัน ไม่ได้เป็นคำอธิบายเต็มของต้นไม้พฤติกรรมที่แก้ไขแล้ว ควรเลือกพรีเซ็ตและชนิดย่อยก่อนปรับพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบการดำเนินการที่กำหนดเองของคุณ ตัวอย่างเช่น การเปลี่ยนเอฟเฟกต์ Spin ที่กำหนดเองเป็น Fade อาจแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันอีกครั้งหลังจากเปลี่ยนพรีเซ็ตหรือชนิดย่อย การล้างพฤติกรรมพรีเซ็ตอาจลบการดำเนินการที่พรีเซ็ตต้องการ ตัวอย่างใช้รูปทรงที่มองเห็นได้และแทนที่พฤติกรรม; ไม่ได้สร้างการทำงานของพรีเซ็ตใหม่ทั้งหมด

## **ความเข้ากันได้ของฟอร์แมต**

ต้นไม้พฤติกรรมที่คงอยู่ไม่ได้รับประกันว่าจะเล่นได้เหมือนกันในทุกตัวดูหรือเครื่องมือแปลงผล ให้ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| ฟอร์แมตหรือผลลัพธ์ | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นฟอร์แมตหลักสำหรับตัวอย่างนี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้, แล้วตรวจสอบการเล่นในเวอร์ชั่น PowerPoint ที่ต้องการ |
| PPT | ตัวแทนไบนารีเก่าอาจแตกต่างจาก PPTX ทดสอบรอบบันทึก-เปิดใหม่และการเล่น; อย่าอนุมานว่าทุกการผสมผสานกำหนดไว้จากผลลัพธ์ PPTX ที่สำเร็จ |
| PDF, PNG, JPEG, และภาพสไลด์คงที่อื่น ๆ | เป็นภาพสไลด์คงที่ ไม่ใช่ไทม์ไลน์การเคลื่อนไหวที่เล่นได้หรือเฟรมสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/cpp/export-to-html5/) | สามารถเล่นการเคลื่อนไหวที่รองรับได้เมื่อเปิดการเคลื่อนไหวรูปทรงในตัวเลือกการส่งออก ทดสอบการผสมผสานกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/) | บันทึกเฟรมที่เรนเดอร์ ไม่ใช่พฤติกรรมแก้ไขหรือการโต้ตอบที่เปิดด้วยคลิก ตรวจสอบการเคลื่อนที่ที่เรนเดอร์จริง |
| [Video](/slides/th/cpp/convert-powerpoint-to-video/) | เรนเดอร์เฟรมการเคลื่อนไหวและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดตาม [การเคลื่อนไหวและเอฟเฟกต์ที่รองรับ](/slides/th/cpp/convert-powerpoint-to-video/#supported-animations-and-effects); คำสั่งและเหตุการณ์เชิงโต้ตอบจะไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **คำถามที่พบบ่อย**

**ทำไมเอฟเฟกต์ของฉันจึงมีพฤติกรรมอยู่ก่อนที่ฉันจะเพิ่มอะไรเลย?**

การสร้างเอฟเฟกต์พรีเซ็ตอาจสร้างการดำเนินการพื้นฐานไว้แล้ว ตรวจสอบก่อนตัดสินใจว่าจะขยายพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปยังตำแหน่งแรกทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็น คอลเลกชันไม่ได้เป็นตัวแทนของเวลา ตรวจสอบความหน่วง, ระยะเวลา, และการโต้ตอบระหว่างการดำเนินการบนคุณสมบัติเดียวกัน

**ทำไมคำสั่ง End จึงไม่มีจุด?**

มันเป็นเครื่องหมายจบของเส้นทาง ไม่ต้องการพิกัด ตรวจสอบอาเรย์จุดเป็น null เมื่ออ่านเส้นทางจากไฟล์

**การทำรอบแบบสำเร็จถือว่าเพียงพอที่จะยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่ยืนยันว่าคุณสมบัติที่ตรวจสอบยังคงอยู่ ต้องทดสอบตัวเล่นสไลด์โชว์หรือการส่งออกแอนิเมชันแยกต่างหากเพื่อยืนยันพฤติกรรมภาพตามที่คาดหวัง