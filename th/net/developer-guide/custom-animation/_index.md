---
title: สร้างและแก้ไขพฤติกรรมการเคลื่อนไหวแบบกำหนดเองใน .NET
linktitle: การเคลื่อนไหวแบบกำหนดเอง
type: docs
weight: 151
url: /th/net/custom-animation/
keywords:
- การเคลื่อนไหวแบบกำหนดเอง
- พฤติกรรมการเคลื่อนไหว
- เส้นทางการเคลื่อนที่
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมการเคลื่อนไหวแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

พฤติกรรมการเคลื่อนไหวแบบกำหนดเองช่วยให้คุณควบคุมการทำงานแต่ละอย่างภายในเอฟเฟ็กต์การเคลื่อนไหวได้ เช่น การเปลี่ยนสี การหมุนรูปทรง หรือการตามเส้นทางการเคลื่อนที่ที่แก้ไขได้ คู่มือเล่านี้แสดงวิธีการสร้างและรวมพฤติกรรม ตั้งค่าเวลา ตรวจสอบและแก้ไขการเคลื่อนไหวที่มีอยู่ และตรวจสอบว่าคุณสมบัติต่าง ๆ ยังคงอยู่หลังจากบันทึกและเปิดการนำเสนอใหม่

สำหรับเอฟเฟ็กต์ที่กำหนดไว้ล่วงหน้าและการทำงานเมื่อคลิก ดูที่ [Shape Animation](/slides/th/net/shape-animation/)

## **ทำความเข้าใจโมเดลการเคลื่อนไหว**

การเคลื่อนไหวถูกจัดเป็น **Timeline → Sequence → Effect → Behaviors** :

- [Timeline](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/timeline/) ของสไลด์มีลำดับหลักและลำดับเชิงโต้ตอบ
- [ISequence](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/) มีเอฟเฟ็กต์ต่าง ๆ ซึ่งอาจเป้าหมายที่รูปร่างหลากหลาย
- [IEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/) ระบุตำแหน่งของรูปร่าง เป้าหมาย ค่าตั้งต้น ชนิดย่อย และเวลาเอฟเฟ็กต์
- [IEffect.Behaviors](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/behaviors/) มีการทำงานที่ทำให้เอฟเฟ็กต์เกิดขึ้น: การเปลี่ยนสี การย้าย การหมุน การตั้งค่าคุณสมบัติ ฯลฯ

## **สร้างพฤติกรรมเดี่ยว**

เรียก [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/) เพื่อสร้างเอฟเฟ็กต์และเข้าถึงคอลเลกชัน [Behaviors](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/behaviors/) ของมัน พรีเซ็ตสามารถเติมคอลเลกชันนี้โดยอัตโนมัติ ให้คงการทำงานไว้เมื่อต่อเติมพรีเซ็ต หรือใช้ [Clear](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/clear/) เมื่อต้องการแทนที่โดยเจตนา

[IBehaviorFactory](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/) สร้าง 8 ชนิดของพฤติกรรมที่แสดงด้านล่าง การเคลื่อนไหวอธิบายไว้ในส่วน [Build a Motion Path](#build-a-motion-path) ตัวอย่างการสร้างแต่ละอย่างเป็นโปรแกรมเต็มรูปแบบ; ตัวอย่างการแก้ไขต่อมาจะระบุไฟล์ผลลัพธ์ที่ใช้

### **Rotation**

ใช้ [CreateRotationEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) เพื่อสร้างการหมุน [By](https://reference.aspose.com/slides/th/net/aspose.slides.animation/irotationeffect/by/) ระบุมุมสัมพัทธ์เป็นองศา; [From](https://reference.aspose.com/slides/th/net/aspose.slides.animation/irotationeffect/from/) และ [To](https://reference.aspose.com/slides/th/net/aspose.slides.animation/irotationeffect/to/) ระบุจุดเริ่มต้นและสิ้นสุด

ตัวอย่างเริ่มจากเอฟเฟ็กต์ Spin แทนที่การทำงานของพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งรายการ และกำหนดระยะเวลาให้สองวินาที มุมสัมพัทธ์ 90 องศาเป็นการหมุนหนึ่งไตรมาสจากทิศทางเริ่มต้นของรูปร่าง ดังนั้นไม่จำเป็นต้องกำหนดมุมเริ่มต้นอย่างชัดเจน

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` มีรูปร่างหนึ่งและพฤติกรรมการหมุนหนึ่งตัว คอลเลกชัน เวลา และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **Scale**

ใช้ [CreateScaleEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) พร้อมเปอร์เซ็นต์ X/Y: [From](https://reference.aspose.com/slides/th/net/aspose.slides.animation/iscaleeffect/from/) และ [To](https://reference.aspose.com/slides/th/net/aspose.slides.animation/iscaleeffect/to/) บรรยายขนาดเริ่มต้นและสิ้นสุด ในขณะที่ [By](https://reference.aspose.com/slides/th/net/aspose.slides.animation/iscaleeffect/by/) บรรยายการเปลี่ยนแปลงสัมพัทธ์ ที่นี่ 100 หมายถึงขนาดดั้งเดิม

ตัวอย่างขยายมิติทั้งสองจาก 100 % ไปเป็น 125 % ในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันจะรักษาสัดส่วนของรูป; ค่าเปอร์เซ็นต์ต่างกันจะทำให้มิติหนึ่งยืดออกมากกว่าอีกมิติ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Color**

ใช้ [CreateColorEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) เพื่อเปลี่ยนสีเติมจากสีน้ำเงินเป็นสีส้ม [From](https://reference.aspose.com/slides/th/net/aspose.slides.animation/icoloreffect/from/) และ [To](https://reference.aspose.com/slides/th/net/aspose.slides.animation/icoloreffect/to/) เป็นสี; [By](https://reference.aspose.com/slides/th/net/aspose.slides.animation/icoloreffect/by/) เป็นการออฟเซ็ตสี [IBehavior.Properties](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehavior/properties/) ระบุแอตทริบิวต์ที่กำลังเคลื่อนไหว

การเติมเต็มของรูปร่างจะเริ่มต้นด้วยสีน้ำเงิน ตรงกับสีเริ่มต้นของการเคลื่อนไหว การเลือกแอตทริบิวต์สีเติมทำให้พฤติกรรมรู้ว่าจะเปลี่ยนส่วนใดของรูปร่าง; จุดสีเริ่มและสิ้นสุดเพียงอย่างเดียวไม่ได้ระบุแอตทริบิวต์นั้น ผลเอฟเฟ็กต์บันทึกการเปลี่ยนสีเป็นสองวินาทีไปเป็นสีส้ม

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filter**

ใช้ [CreateFilterEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) เพื่อเลือกวิธีการลบ [Type](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ifiltereffect/subtype/), และ [Reveal](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ifiltereffect/reveal/) ระบุฟิลเตอร์ ทิศทาง และว่าจะเปิดหรือซ่อนรูปร่างหรือไม่

ตัวอย่างนี้ตั้งค่าให้ลบสองวินาทีโดยเปิดเผยรูปร่างโดยใช้ชนิดย่อยที่มาจากด้านขวา การตั้งค่าฟิลเตอร์อยู่ในพฤติกรรมภายในเอฟเฟ็กต์ ดังนั้นจึงตั้งค่าได้หลังจากลบการทำงานดั้งเดิมของพรีเซ็ตออกแล้ว

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Property**

ใช้ [CreatePropertyEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) เพื่อเคลื่อนไหวความทึบแสง [From](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ipropertyeffect/to/), และ [By](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ipropertyeffect/by/) เป็นสตริงที่ตีความโดยใช้ [ValueType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ipropertyeffect/valuetype/) และ [CalcMode](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ipropertyeffect/calcmode/) เลือกใช้จุดสิ้นสุดหรือออฟเซ็ตสัมพัทธ์แทนการตั้งค่าทั้งสามพร้อมกัน

ที่นี่แอตทริบิวต์ที่เลือกคือ opacity และสตริงตัวเลขแสดงการเปลี่ยนจาก 25 % ไปเป็นความทึบแสงเต็ม การผสมเชิงเส้นอธิบายการเปลี่ยนแปลงอย่างค่อยเป็นค่อยไประหว่างค่าเหล่านั้น เมื่อนำตัวอย่างนี้ไปใช้กับแอตทริบิวต์อื่น ให้เลือกประเภทค่าและค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Set**

ใช้ [CreateSetEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) เพื่อกำหนดการมองเห็นผ่าน [To](https://reference.aspose.com/slides/th/net/aspose.slides.animation/iseteffect/to/) พฤติกรรม set ไม่ได้ทำการผสมค่าระหว่างจุดสิ้นสุด

ตัวอย่างเลือกแอตทริบิวต์ visibility แล้วกำหนดสตริง `visible` เมื่อพฤติกรรมทำงาน รูปสี่เหลี่ยมมองเห็นได้แล้วในงานนำเสนอขนาดเล็กนี้ ดังนั้นการกำหนดอาจไม่ทำให้เห็นการเปลี่ยนแปลงที่ชัดเจนโดยตัวมันเอง การทำแบบนี้มีประโยชน์เมื่อเป็นส่วนหนึ่งของเอฟเฟ็กต์ที่ใหญ่กว่าที่ควบคุมการซ่อนหรือแสดงรูปร่างด้วย

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Command**

ใช้ [CreateCommandEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) และกำหนดค่า [Type](https://reference.aspose.com/slides/th/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/th/net/aspose.slides.animation/icommandeffect/commandstring/), และ [ShapeTarget](https://reference.aspose.com/slides/th/net/aspose.slides.animation/icommandeffect/shapetarget/) ใส่ไฟล์บันทึกเสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์ด้วย [AddAudioFrameEmbedded](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addaudioframeembedded/) แล้วแนบคำสั่งเล่นไปยัง audio frame

audio frame เป็นทั้งเป้าหมายของเอฟเฟ็กต์และของคำสั่ง การเชื่อมคำสั่ง play กับการบันทึกที่ฝังไว้ทำให้เกิดการเล่น; คำสั่งสตริงเพียงอย่างเดียวไม่บ่งบอกว่าจะควบคุมวัตถุสื่ออะไร เอฟเฟ็กต์ตั้งค่าให้เริ่มเมื่อคลิกในระหว่างการสไลด์โชว์

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

การบันทึกจะเก็บคำสั่งไว้ใน `command.pptx`; มันจะไม่เล่นไฟล์เสียง การเล่นต้องใช้โปรแกรมสไลด์โชว์ที่สนับสนุนคำสั่งและสื่อเป้าหมายนั้น

## **จัดการคอลเลกชันพฤติกรรม**

[IBehaviorCollection](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/) รองรับ [Add](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/remove/), และ [RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/removeat/) ตัวอย่างนี้เปิด `rotation.pptx` เพิ่มการสเกล ย้ายมันก่อนการหมุน และลบการหมุน การลบและแทรกใหม่ของอ็อบเจ็กต์เดียวกันทำให้ตำแหน่งที่จัดเก็บเปลี่ยนโดยไม่ทำสำเนา

ลำดับการแก้ไขทำให้คอลเลกชันเปลี่ยนจาก rotation–scale ไปเป็น scale–rotation จากนั้นเป็น scale เพียงอย่างเดียว ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังการจัดลำดับใหม่ การวนลูปสุดท้ายยืนยันว่าพฤติกรรมใดจะถูกบันทึก

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

ผลลัพธ์คือ `ScaleEffect`: เหลือเพียงการสเกลเท่านั้น คำสั่งของคอลเลกชันเองไม่ได้กำหนดให้พฤติกรรมทำงานต่อเนื่องกัน ควรใช้ Clear เฉพาะเมื่อแทนที่การทำงานทั้งหมด

## **กำหนดเวลาพฤติกรรม**

[IBehavior.Timing](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehavior/timing/) เปิดเผย [ITiming](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/) แยกจาก [IEffect.Timing](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/timing/) เวลาเอฟเฟ็กต์กำหนดการทำงานของเอฟเฟ็กต์โดยรวม; เวลาพฤติกรรมอธิบายการทำงานภายในเอฟเฟ็กต์นั้น

### **ตั้งค่า Duration, Delay, Repetition, และ Acceleration**

เปิด `rotation.pptx` และตั้งค่า [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/duration/) และ [TriggerDelayTime](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/triggerdelaytime/) เป็นวินาที จากนั้นกำหนดค่า [RepeatCount](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatcount/) [Accelerate](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/accelerate/) และ [Decelerate](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/decelerate/) เป็นส่วนของระยะเวลา; ให้ผลรวมสูงสุดไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างในตัวอย่างการหมุน ซึ่งพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนเวลาเพียงพฤติกรรมนั้น; มุม 90 ° ยังคงเหมือนเดิม การแยกมุมและเวลาออกจากกันทำให้ปรับความเร็วได้ง่ายขึ้นโดยไม่ต้องสร้างเอฟเฟ็กต์ใหม่

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

พฤติกรรมนี้ใช้ระยะเวลา 2 วินาที, หน่วงครึ่งวินาที, และทำซ้ำ 3 ครั้ง 20 % แรกและสุดท้ายของระยะเวลาจะใช้สำหรับการเร่งความเร็วและการชะลอ

นโยบายการทำซ้ำอื่น ๆ รวมถึง [RepeatDuration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilendslide/), และ [RepeatUntilNextClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilnextclick/) ให้เลือกใช้หนึ่งนโยบายแทนการเปิดทั้งหมดพร้อมกัน [AutoReverse](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/autoreverse/) จะเล่นเอฟเฟ็กต์ย้อนกลับหลังจากเล่นไปข้างหน้า การเร่งและการชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าแบบก้าวกระโดดหรือคำสั่ง

## **สร้าง Motion Path**

ใช้ [CreateMotionEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) เพื่อสร้างการเคลื่อนที่ [From](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioneffect/to/), และ [By](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioneffect/by/) บรรยายพิกัดหรือออฟเซ็ตเป็นเปอร์เซ็นต์ สำหรับเส้นทางที่แก้ไขได้ ให้สร้าง [MotionPath](https://reference.aspose.com/slides/th/net/aspose.slides.animation/motionpath/) แล้วกำหนดให้กับ [IMotionEffect.Path](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioneffect/path/) [IMotionPath](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotionpath/) จะเก็บคำสั่งเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/motioncommandpathtype/) เลือกการทำงาน:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | หนึ่ง | กำหนดตำแหน่งเริ่มต้น |
| LineTo | หนึ่ง | เคลื่อนที่ไปตามส่วนตรงจนถึงจุดสิ้นสุด |
| CurveTo | สาม | ตามโค้งพาราโบลาโดยใช้จุดควบคุมสองจุดและจุดสิ้นสุด |
| CloseLoop | ไม่มี | กลับไปยังตำแหน่งเริ่มต้น |
| End | ไม่มี | สิ้นสุดเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/motionpathpointstype/) บรรยายลักษณะการแก้ไขจุด เช่น จุดมุมหรือจุดเรียบ ไม่ได้แทนที่ชนิดคำสั่ง ใช้ชนิดจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง และชนิดจุดมุมสำหรับส่วนตรง

พิกัดเส้นทางเป็นค่าปกติเทียบกับขนาดสไลด์: การเคลื่อนที่ X ที่ 0.25 หมายถึงหนึ่งส่วนสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 จุด; ค่า Y บวกไปด้านล่าง คำสั่ง Absolute ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่ง Relative ระบุออฟเซ็ตจากตำแหน่งปัจจุบัน สิ่งนี้แยกจาก [Origin](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioneffect/origin/) ที่เลือกกรอบอ้างอิงของเส้นทาง, และ [PathEditMode](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioneffect/patheditmode/) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อย้ายรูปร่าง

### **สร้าง Straight Path**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่มต้น ส่วนตรงหนึ่งส่วน และคำสั่งจบ [IMotionPath.Add](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotionpath/add/) รับชนิดคำสั่ง, จุดของมัน, ชนิดจุด, และแฟล็กพิกัดสัมพัทธ์

คำสั่งเริ่มต้นกำหนด (0, 0) และเส้นตรงสิ้นสุดที่ (0.25, 0) ทำให้เส้นทางเคลื่อนที่แนวนอนหนึ่งส่วนสี่ของความกว้างสไลด์ คำสั่งสิ้นสุดไม่มีจุดพิกัด เมื่อกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่เข้าไปในเอฟเฟ็กต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยม

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งตัวพร้อมคำสั่งเส้นทางสามคำสั่ง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้อ้างอิงโครงสร้างนี้

### **เปรียบเทียบ Absolute และ Relative Coordinates**

สองอ็อบเจ็กต์เส้นทางนี้บรรยายเส้นทางเดียวกัน คำสั่ง Absolute สิ้นสุดที่ (0.3, 0.1); คำสั่ง Relative เพิ่ม (0.1, 0.1) ไปยังตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นทางเริ่มจากตำแหน่งเดียวกัน สำหรับเส้นตรงแบบ Relative ให้นำออฟเซ็ต X และ Y ไปบวกกับตำแหน่งปัจจุบันเพื่อหาจุดสิ้นสุด; สำหรับ Absolute ให้อ่านจุดสิ้นสุดโดยตรง การสลับแฟล็กโดยไม่แปลงค่าพิกัดจะทำให้เส้นทางต่างกัน

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ ตัวแปรบูลีนสุดท้ายเลือกพิกัดสัมพัทธ์สำหรับคําสั่งนั้น

### **แทนที่ Line ด้วย Curve**

เปิด `motion.pptx` และแทนที่คำสั่งเส้นตรงด้วยโค้งลูกบาศก์ ให้ใส่จุดควบคุมสองจุดก่อน แล้วตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นมาจากคำสั่งก่อนหน้า จุดสองแรกกำหนดรูปร่างโค้ง ส่วนจุดที่สามเป็นจุดหมาย; ไม่ใช่สามจุดต่อเนื่องเป็นจุดหมาย การอัปเดตชนิดคำสั่ง, ชนิดจุดแก้ไข, และอาร์เรย์จุดพร้อมกันทำให้ส่วนโค้งสอดคล้องกับเรขาคณิตใหม่

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

เส้นทางใน `curve.pptx` ยังมีคำสั่งสามคำสั่ง; คำสั่งกลางตอนนี้เป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [IMotionCmdPath](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioncmdpath/) เปิดเผย [Points](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioncmdpath/pointstype/), และ [IsRelative](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotioncmdpath/isrelative/) ตัวอย่างต่อไปใช้เส้นทางสามคำสั่งที่ทราบใน `motion.pptx` สำหรับอินพุตใด ๆ ให้ค้นหาเอฟเฟ็กต์ที่ตั้งใจและตรวจสอบชนิดคำสั่งและจำนวนจุดก่อนแก้ไขโดยตำแหน่ง

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ CloseLoop ไม่ต้องการจุด ดังนั้นให้เตรียมรับอาร์เรย์จุดเป็น null

ผลลัพธ์จับคู่แต่ละคำสั่งกับแฟล็กพิกัดสัมพัทธ์ก่อนแสดงจุดของมัน ทำให้คุณแยกจุดสิ้นสุดจากออฟเซ็ตก่อนแก้ไขเส้นทาง โค้งจะแสดงสามจุด ส่วนเส้นตรงในไฟล์นี้จะแสดงเพียงหนึ่งจุด

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

การแสดงรายการมีจุดเริ่มต้น, เส้นตรง Absolute สิ้นสุดที่ (0.25, 0), และคำสั่ง End

### **เปลี่ยน Endpoint**

เปิด `motion.pptx` และแทนที่อาร์เรย์จุดของเส้นตรงเพื่อย้ายจุดสิ้นสุด

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้น ดัชนี 1 คือเส้นตรง การแทนที่จุดเดียวของเส้นตรงจะเปลี่ยนปลายทางโดยไม่เปลี่ยนชนิดคำสั่ง เวลา หรือตำแหน่งในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัด Absolute คู่ใหม่จึงระบุตำแหน่งแทนการเพิ่มออฟเซ็ต

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

เส้นตรงใน `motion-endpoint.pptx` สิ้นสุดที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่ได้รับการเปลี่ยนแปลง

### **แทนที่ Segment**

ใช้ [Insert](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotionpath/insert/) และ [RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides.animation/imotionpath/removeat/) เพื่อแทนที่เส้นตรงใน `motion.pptx` การแทรกทำให้เส้นตรงเดิมย้ายไปเป็นดัชนี 2

ตัวอย่างนี้แสดงการแทนที่อ็อบเจ็กต์คำสั่งแทนการแก้ไขพิกัดเดิม หลังการแทรก คอลเลกชันชั่วคราวจะมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, และคำสั่ง End การลบดัชนี 2 จะทิ้งเส้นเก่าและเหลือเส้นใหม่ในที่ตำแหน่ง

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

เส้นทางที่บันทึกยังคงมีสามคำสั่ง โดยเส้นใหม่สิ้นสุดที่ (0.2, 0.1) และคำสั่ง End อยู่ท้ายสุด

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีของพฤติกรรม ให้เลือกโดยชนิด ตัวอย่างนี้เปิด `rotation.pptx` ค้นหา [IRotationEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/irotationeffect/) เปลี่ยนมุมและตรวจสอบค่าที่บันทึกหลังจากเปิดใหม่

การตรวจสอบชนิดทำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์ที่บันทึกลงในอ็อบเจ็กต์การนำเสนอแยกต่างหาก ดังนั้นการเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่ ไม่ใช่ค่าที่ยังคงอยู่ในหน่วยความจำ ตัวอย่างยังคงสมมติว่าเอฟเฟ็กต์ที่รู้จักอยู่เป็นรายการแรกในลำดับหลัก; การเลือกพฤติกรรมโดยชนิดไม่ได้ทำให้ค้นหาเอฟเฟ็กต์ที่ถูกต้องในงานนำเสนอใด ๆ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

ผลลัพธ์คือ `Rotation preserved: True` ใช้รูปแบบการตรวจสอบชนิดเดียวกันกับพฤติกรรมอื่น ๆ สำหรับการตรวจสอบการคงที่อย่างสมบูรณ์ ให้เปรียบเทียบรูปร่างเป้าหมาย, เอฟเฟ็กต์, ชนิดและลำดับพฤติกรรม, เวลา, และคำสั่งเส้นทาง ใช้ความทนทานเชิงตัวเลขสำหรับค่าทศนิยม สำหรับงานนำเสนอที่มีโครงสร้างการเคลื่อนไหวไม่ทราบ ให้ดูที่ [Read Shape Animations](/slides/th/net/shape-animation/#read-shape-animations) เพื่อท่องลำดับหลักและลำดับเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [IBehaviorCollection](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehaviorcollection/) คือลำดับที่จัดเก็บของการทำงานในเอฟเฟ็กต์ ไม่ได้เป็นเพลย์ลิสต์ที่พฤติกรรมทุกรายการรอคอยรายการก่อนหน้า เวลาและเอฟเฟ็กต์ที่ห่อหุ้มกำหนดการจัดตาราง พฤติกรรมสามารถทับซ้อนกันได้ และการทำงานบนคุณสมบัติเช่นเดียวกันอาจโต้ตอบผ่าน [Additive](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehavior/additive/) และ [Accumulate](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ibehavior/accumulate/) อย่าใช้การจัดลำดับคอลเลกชันเพียงอย่างเดียวเพื่อกำหนด “ย้าย แล้วหมุน”; ให้ใช้เวลาแบบชัดเจนหรือเอฟเฟ็กต์แยกตามที่อธิบายใน [Shape Animation](/slides/th/net/shape-animation/)

[Type](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/type/) และ [Subtype](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/subtype/) ของเอฟเฟ็กต์บรรยายพรีเซ็ต ไม่ได้เป็นคำอธิบายครบถ้วนของต้นไม้พฤติกรรมที่แก้ไขแล้ว เลือกพรีเซ็ตและซับไทป์ก่อนปรับแต่งพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และทำให้การทำงานที่กำหนดเองหายไป ตัวอย่างเช่น การเปลี่ยนเอฟเฟ็กต์ Spin ที่กำหนดเองเป็น Fade อาจแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันอีกครั้งหลังจากเปลี่ยนพรีเซ็ตหรือซับไทป์ การล้างพฤติกรรมของพรีเซ็ตอาจทำให้การตั้งค่าการมองเห็นหรือการเริ่มต้นที่พรีเซ็ตต้องการหายไป ตัวอย่างใช้รูปร่างที่มองเห็นได้และแทนที่พฤติกรรม; ไม่ได้สร้างต้นแบบการทำงานของพรีเซ็ตทั้งหมดใหม่

## **ความเข้ากันได้ของฟอร์แมต**

ต้นไม้พฤติกรรมที่คงไว้ไม่ได้รับประกันว่าจะเล่นได้เหมือนกันในทุกโปรแกรมหรือเรนเดอร์เอาท์พุต ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| ฟอร์แมตหรือผลลัพธ์ | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นฟอร์แมตหลักสำหรับตัวอย่างเหล่านี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้ แล้วตรวจสอบการเล่นใน PowerPoint เวอร์ชันที่ต้องการ |
| PPT | ตัวแทนไบนารีแบบเก่าอาจแตกต่างจาก PPTX ทดสอบวงจรบันทึก‑เปิดใหม่และการเล่น; อย่าอนุมานการสนับสนุนทุกการผสมผสานที่กำหนดจากผลลัพธ์ PPTX เพียงอย่างเดียว |
| PDF, PNG, JPEG และภาพสไลด์แบบคงที่อื่น ๆ | มีเพียงการแสดงสไลด์แบบคงที่ ไม่ใช่ไทม์ไลน์การเคลื่อนไหวที่เล่นได้ หรือเฟรมสุดท้ายของการเคลื่อนไหวที่รับประกัน |
| [HTML5](/slides/th/net/export-to-html5/) | สามารถเล่นการเคลื่อนไหวที่สนับสนุนได้เมื่อเปิดใช้งาน shape animation ในตัวเลือกการส่งออก ทดสอบการผสมผสานที่กำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/net/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ใช่พฤติกรรมที่แก้ไขได้หรือการโต้ตอบแบบคลิก‑ทริกเกอร์ ตรวจสอบการเคลื่อนไหวที่เรนเดอร์จริง |
| [Video](/slides/th/net/convert-powerpoint-to-video/) | เรนเดอร์เฟรมการเคลื่อนไหวและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดอยู่ที่ [supported animations and effects](/slides/th/net/convert-powerpoint-to-video/#supported-animations-and-effects) ของเรนเดอร์เดอร์; คำสั่งและเหตุการณ์เชิงโต้ตอบไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **FAQ**

**ทำไมเอฟเฟ็กต์ของฉันถึงมีพฤติกรรมก่อนที่ฉันจะเพิ่มอะไรลงไป?**

การสร้างเอฟเฟ็กต์ที่กำหนดล่วงหน้าสามารถสร้างการทำงานพื้นฐานของมันได้ ตรวจสอบพวกมันก่อนตัดสินใจว่าจะต่อเติมพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปเป็นตำแหน่งแรกทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็น ลำดับคอลเลกชันไม่ใช่การแทนที่เวลา ตรวจสอบการหน่วง, ระยะเวลา, และการโต้ตอบระหว่างการทำงานบนคุณสมบัติเช่นเดียวกัน

**ทำไมคำสั่ง End ถึงไม่มีจุด?**

มันบ่งบอกจุดสิ้นสุดของเส้นทางและไม่ต้องการพิกัด ตรวจสอบอาร์เรย์จุดเป็น null เมื่ออ่านเส้นทางจากไฟล์

**การวนรอบสำเร็จเป็นการยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่ยืนยันการคงอยู่ของคุณสมบัติที่ตรวจสอบเท่านั้น ต้องทดสอบโปรแกรมสไลด์โชว์หรือการส่งออกแบบเคลื่อนไหวแยกต่างหากเพื่อยืนยันพฤติกรรมภาพสุดท้าย