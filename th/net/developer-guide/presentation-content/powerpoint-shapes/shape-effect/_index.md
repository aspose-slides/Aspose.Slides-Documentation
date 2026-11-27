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
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ .NET—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในเวลาไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปทรงโดดเด่นขึ้น แต่เอฟเฟกต์จะแตกต่างจาก [การเติม](/slides/th/net/shape-formatting/#gradient-fill) หรือเค้าโครงเส้นขอบ การใช้เอฟเฟกต์ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงรอบรูปทรง ฯลฯ

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถนำเอฟเฟกต์หนึ่งหรือหลายแบบไปใช้กับรูปทรงได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานที่ดูดีของเอฟเฟกต์สองแบบหรือมากกว่าที่ทราบกันดี ด้วยวิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่น่าพอใจ

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) ที่ให้คุณนำเอฟเฟกต์เดียวกันไปใช้กับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for .NET รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับสี, ทิศทาง, ระยะห่างและรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นบนพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้รูปทรงดูเหมือนลอยเหนือสไลด์ ปรับสี, ทิศทาง, ระยะห่างและรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด C# นี้แสดงวิธีการใช้ [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) กับสี่เหลี่ยมผืนผ้า:

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

![เอฟเฟกต์เงา](shadow_effect.png)

#### **ควบคุมทิศทางเงาเมื่อรูปร่างหมุน**

โดยค่าเริ่มต้น [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) มีค่าเป็น `true` ทำให้เงาหมุนพร้อมกับรูปทรง เพื่อให้รูปทรงที่มีการหมุนต่างกันดูเหมือนได้รับแสงจากทิศเดียวกัน ให้ตั้งค่าคุณสมบัตินี้เป็น `false` แล้วกำหนด [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/) ให้เงาเหมือนกัน

ตัวอย่างสร้างลูกศรสองลูกโดยมีเงาสีเทาเลื่อนไปทางขวา (`Direction = 0`) จากนั้นทำสำเนาสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

ในสไลด์ที่สอง ลูกศรซ้ายทำเงาตกลงด้านล่าง ส่วนลูกศรขวายังคงทำเงาไปทางขวา ทิศทางที่ตั้งค่าไว้ยังคงเป็น 0° สำหรับเงาทั้งสอง

![การแสดงผล PowerPoint ก่อนและหลังการหมุน 90°. เงาทั้งสองเริ่มจากขวา หลังการหมุน เงาจะย้ายไปด้านล่างของลูกศรซ้ายและคงอยู่ทางขวาของลูกศรขวา.](arrow-shadow-rotation.png)

### **ใช้เงาภายใน**

เมื่อทำซ้ำสไตล์ภาพของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูมีลักษณะกดลงภายใน เงานอกจะขยายออกนอกรูปทรงทำให้ดูยกขึ้น ส่วนเงาภายในจะทำให้ขอบภายในรูปทรงมีเงา

เรียกใช้ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) แล้วกำหนดค่า [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) ค่าที่ใหญ่ขึ้นจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง C# นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX:

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

![สี่เหลี่ยมสีน้ำเงินอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

หากต้องการลบเงาภายใน ให้เรียกใช้ [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) บนรูปทรงที่มีรูปแบบเอฟเฟกต์

### **ใช้, เปลี่ยนและลบ Preset Shadow**

เรียกใช้ [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) แล้วตั้งค่า [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) เป็น [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) ที่มีชื่อ เพื่อสลับสไตล์ให้เปลี่ยน Preset บนรูปทรงเดียวกัน เรียกใช้ [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) เพื่อเอาเงาออกในขณะที่ยังคงรักษาการเติมและเค้าโครงเส้นขอบไว้

ตัวอย่างนี้เก็บสำเนาของสี่เหลี่ยมในแต่ละขั้นตอน เงาทั้งสองมีการเลื่อน 10 จุด ทิศทาง 225° ทำให้เงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม และ 45° ทำให้เงาที่สองอยู่ด้านล่างขวา

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| ดั้งเดิม | พรีเซ็ตแรก | พรีเซ็ตที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for .NET คุณสามารถเพิ่มการสะท้อนเหมือนกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะห่าง, ความโปร่งใสและขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามให้กับงานนำเสนอของคุณโดยทำให้รูปทรงดูเป็นมืออาชีพและหรูหรา สามารถนำไปใช้ได้ง่ายด้วยโค้ดที่เรียบง่าย ทำให้การนำไปใช้กับหลาย ๆ อิลิเมนต์เพื่อการออกแบบที่สม่ำเสมอเป็นเรื่องเร็ว

โค้ด C# นี้แสดงวิธีการใช้ [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) กับรูปทรง:

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

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟ็กต์เรืองแสง**

เพื่อใช้เอฟเฟ็กต์เรืองแสงกับรูปทรงใน Aspose.Slides for .NET คุณสามารถเพิ่มแสงสว่างอ่อน ๆ รอบ ๆ รูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟ็กต์นี้ช่วยให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบ視覺ที่ดึงดูดให้กับงานนำเสนอของคุณ ใช้งานได้ง่ายด้วยโค้ดที่สั้น ๆ ทำให้การปรับปรุงรูปลักษณ์ของสไลด์ทั้งหมดเป็นเรื่องง่าย

โค้ด C# นี้แสดงวิธีการใช้ [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) กับรูปทรง:

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

![เอฟเฟ็กต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟ็กต์ขอบนุ่ม**

เพื่อใช้เอฟเฟ็กต์ขอบนุ่มใน Aspose.Slides for .NET คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟ็กต์นี้เพิ่มลุคที่อ่อนโยนและละเอียดอ่อน เหมาะกับการออกแบบที่ต้องการลุคอ่อนนุ่ม คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้เอฟเฟ็กต์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณได้อย่างง่ายดาย

โค้ด C# นี้แสดงวิธีการใช้ [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) กับรูปทรง:

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

![เอฟเฟ็กต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟ็กต์เบลอ**

ใช้การเบลอรูปทรงเพื่อทำให้การเติมและเค้าโครงเส้นขอบของรูปทรงนุ่มขึ้นในขณะที่ยังคงให้รูปทรงแก้ไขได้ เรียกใช้ [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) บนรูปแบบเอฟเฟกต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าเป็นจำนวนไม่ลบ โดยค่ายิ่งใหญ่จะทำให้เบลอแรงขึ้น รัศมีศูนย์จะทำให้ลุคไม่เปลี่ยนแปลง

การตั้งค่า [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ ด้วยค่า `false` การเบลอจะถูกตัดให้อยู่ภายในขอบเขตที่วาดไว้รวมถึงเค้าโครงเส้นขอบ ด้วยค่า `true` การเบลอสามารถขยายเกินขอบเขตนั้นได้ การตั้งค่าใด ๆ ก็ไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้การเติม, เค้าโครงเส้นขอบและขนาดรูปทรงเดียวกันทั่วทั้งตัวอย่าง แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![สี่เหลี่ยมดั้งเดิมเปรียบเทียบกับรัศมีการเบลอ 5 และ 15 จุด พร้อม Grow ปิดและเปิด](shape_blur_comparison.png)

ตัวอย่าง C# นี้สร้างสี่เหลี่ยมสีส้มพร้อมเค้าโครงเส้นขอบสีน้ำเงินเข้ม ใช้การเบลอ 5 จุด แล้วอัปเดตเป็นการเบลอ 15 จุดโดยเรียกใช้ [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) อีกครั้ง บันทึกทั้งสองสภาวะที่เบลอ แล้วเรียกใช้ [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) และบันทึกรูปทรงที่ไม่มีการเบลอ

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

การเบลอรูปทรงทำให้การเติมและเค้าโครงเส้นขอบเปลี่ยนแปลงพร้อมกัน เอฟเฟ็กต์ขอบนุ่มทำให้ขอบรูปทรงจางหายไป ในขณะที่การเบลอเงาจะทำให้เงาเท่านั้นเบลอ เอฟเฟ็กต์การแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้การเบลอโดยตรงบนรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นภาพ

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ใช่ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อนและเรืองแสงไว้บนรูปทรงเดียวเพื่อสร้างลุคที่มีความเคลื่อนไหวมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลายประเภท รวมถึงรูปอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มไว้ได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มไว้ได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.