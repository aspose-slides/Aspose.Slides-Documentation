---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย .NET
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/net/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงอำพราง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides for .NET—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าการใช้เอฟเฟกต์ใน PowerPoint สามารถทำให้รูปทรงโดดเด่นได้ แต่พวกมันแตกต่างจาก [การเติม](/slides/th/net/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงอำพรางของรูปทรง เป็นต้น.

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกประเภทที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูปได้.

บางการผสมผสานของเอฟเฟกต์ดูดีขึ้นกว่าการผสมอื่น ๆ ด้วยเหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานที่ดูดีของสองหรือมากกว่าหนึ่งเอฟเฟกต์ ดังนั้นโดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint.

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for .NET รองรับเงานอกและเงาในสำหรับรูปทรง คุณสามารถปรับแต่งสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ.

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือพาเนลโดดเด่นจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้รูปลักษณ์เหมือนรูปทรงยกขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ.

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) กับสี่เหลี่ยมผืนผ้า:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Shadow effect](shadow_effect.png)

### **ใช้เงาใน**

เมื่อทำสำเนาการออกแบบภาพของเทมเพลต ให้ใช้เงาในเพื่อให้การ์ดหรือพาเนลดูถูกฝัง เงานอกขยายออกนอกรูปทรงทำให้ดูยกขึ้น ส่วนเงาในจะให้เฉดสีภายในขอบของรูปทรง.

เรียกใช้ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), จากนั้นกำหนดค่า [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). ค่าที่มากขึ้นจะทำให้ขอบนุ่มขึ้น.

ตัวอย่าง C# นี้สร้างการ์ดสีฟ้าอ่อนที่มีเงาในสีเทาดำและบันทึกเป็นไฟล์ PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาใน](inner_shadow_effect.png)

เพื่อลบเงาใน ให้เรียกใช้ [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) บน EffectFormat ของรูปทรง.

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for .NET คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งแสง, และขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามให้การนำเสนอของคุณโดยทำให้รูปทรงดูเรียบหรูและเป็นมืออาชีพ การทำงานง่ายด้วยโค้ดที่เรียบง่าย ทำให้สามารถประยุกต์ใช้ได้อย่างรวดเร็วบนหลายองค์ประกอบเพื่อการออกแบบที่สม่ำเสมอ.

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟ็กต์การสะท้อน](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) กับรูปทรง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![เอฟเฟ็กต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงอำพราง**

เพื่อใช้เอฟเฟกต์แสงอำพรางกับรูปทรงใน Aspose.Slides for .NET คุณสามารถเพิ่มออร่าที่อ่อนและเปล่งแสงไปรอบ ๆ รูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดสายตาให้การนำเสนอของคุณ การทำงานง่ายด้วยโค้ดเพียงเล็กน้อย ช่วยเพิ่มรูปลักษณ์โดยรวมของสไลด์.

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟกต์แสงอำพราง](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) กับรูปทรง:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![เอฟเฟกต์แสงอำพราง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for .NET คุณสามารถสร้างการไล่สีที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและพรีเมี่ยม เหมาะกับการออกแบบที่ต้องการลุคนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมี ได้อย่างง่ายดายเพื่อให้ได้เอฟเฟกต์ที่ต้องการในรูปทรงต่าง ๆ ของการนำเสนอของคุณ.

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) กับรูปทรง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![เอฟเฟกต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟ็กต์การเบลอ**

ใช้การเบลอของรูปทรงเพื่อทำให้สีเติมและเส้นขอบของรูปทรงนุ่มขึ้นพร้อมคงรูปทรงให้แก้ไขได้ เรียกใช้ [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) บน EffectFormat ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าไม่เป็นลบ โดยค่าที่มากกว่าจะทำให้เบลอแรงขึ้น รัศมีเป็นศูนย์จะไม่มีการเปลี่ยนแปลงลักษณะ.

การตั้งค่า [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ หากเป็น `false` การเบลอจะถูกตัดให้อยู่ภายในขอบเขตที่วาดไว้เดิมรวมถึงเส้นขอบ หากเป็น `true` การเบลอสามารถขยายเกินขอบเขตเหล่านั้น การตั้งค่าใด ๆ ก็ไม่ได้เปลี่ยนตำแหน่งหรือขนาดของรูปทรง.

การเปรียบเทียบด้านล่างใช้สีเติม เส้นขอบ และขนาดรูปทรงเดียวกันตลอด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![สี่เหลี่ยมต้นฉบับที่เทียบกับรัศมีการเบลอ 5 และ 15 จุด, พร้อมการเปิด/ปิด Grow](shape_blur_comparison.png)

ตัวอย่าง C# นี้สร้างสี่เหลี่ยมสีส้มที่มีเส้นขอบสีน้ำเงินเข้ม ใช้การเบลอ 5 จุด แล้วอัปเดตเป็น 15 จุดโดยเรียก [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) อีกครั้ง บันทึกสถานะที่เบลอทั้งสอง แล้วเรียก [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) และบันทึกรูปทรงโดยไม่มีการเบลอ.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

การเบลอของรูปทรงจะส่งผลต่อสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบของรูปทรงจางลง ในขณะที่การเบลอของเงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟกต์การแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้การเบลอตรงกับ EffectFormat ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ.

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมผสานเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อนและแสงอำพราง บนรูปทรงเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น.

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงต่าง ๆ รวมถึงอัตโนมัติรูป (autoshapes), แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ.

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่รวมกลุ่มกันได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่รวมกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.