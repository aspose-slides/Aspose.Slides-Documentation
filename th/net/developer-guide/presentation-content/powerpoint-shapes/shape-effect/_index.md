---
title: ใช้เอฟเฟ็กต์รูปทรงในงานนำเสนอด้วย .NET
linktitle: เอฟเฟ็กต์รูปทรง
type: docs
weight: 30
url: /th/net/shape-effect
keywords:
- เอฟเฟ็กต์รูปทรง
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์สะท้อน
- เอฟเฟ็กต์เรืองแสง
- เอฟเฟ็กต์ขอบอ่อน
- รูปแบบเอฟเฟ็กต์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟ็กต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ .NET — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟ็กต์ใน PowerPoint จะใช้เพื่อทำให้รูปร่างโดดเด่น แต่พวกมันจะแตกต่างจาก [การเติม](/slides/th/net/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟ็กต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่เชื่อถือได้บนรูปร่าง ทำให้รูปร่างมีความสว่าง เป็นต้น

<img src="shape-effect.png" alt="เอฟเฟ็กต์รูปทรง" style="zoom:50%;" />

PowerPoint มีเอฟเฟ็กต์หกประเภทที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟ็กต์กับรูปร่างได้  

บางการผสมผสานของเอฟเฟ็กต์ดูดีขึ้นกว่าที่อื่น ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset โดยพื้นฐานคือการผสมผสานที่ดูดีของสองหรือหลายเอฟเฟ็กต์ การเลือก Preset จะช่วยให้คุณไม่ต้องเสียเวลาทดสอบหรือผสมผสานเอฟเฟ็กต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและวิธีการภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/net/aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟ็กต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟ็กต์เงา**

เพื่อใช้เอฟเฟ็กต์เงากับรูปร่างใน Aspose.Slides for .NET คุณสามารถปรับพารามิเตอร์เช่น สี, รัศมีการเบลอ, และทิศทางได้อย่างง่ายดาย สิ่งนี้ทำให้รูปร่างของคุณดูไดนามิกและเป็นมืออาชีพมากขึ้น เพิ่มความลึกและการโฟกัส โดยใช้โค้ดสแนปเพียงเล็กน้อย คุณสามารถนำเอฟเฟ็กต์เหล่านี้ไปใช้กับหลายรูปร่าง เพิ่มความสวยงามโดยรวมของงานนำเสนอของคุณ  

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟ็กต์เงาภายนอก](https://reference.aspose.com/slides/th/net/aspose.slides/effectformat/outershadoweffect/) กับสี่เหลี่ยม:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![เอฟเฟ็กต์เงา](shadow_effect.png)

## **ใช้เอฟเฟ็กต์การสะท้อน**

เพื่อใช้เอฟเฟ็กต์การสะท้อนใน Aspose.Slides for .NET คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใส, และขนาด เอฟเฟ็กต์นี้ทำให้การนำเสนอของคุณดูหรูหรามากขึ้นโดยให้รูปร่างดูเป็นมืออาชีพและมีสไตล์ การทำเช่นนี้ง่ายด้วยโค้ดสั้น ๆ ซึ่งช่วยให้คุณนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อการออกแบบที่สอดคล้องกัน  

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟ็กต์การสะท้อน](https://reference.aspose.com/slides/th/net/aspose.slides/effectformat/reflectioneffect/) กับรูปร่าง:

```c#
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

## **ใช้เอฟเฟ็กต์เรืองแสง**

เพื่อใช้เอฟเฟ็กต์เรืองแสงกับรูปร่างใน Aspose.Slides for .NET คุณสามารถเพิ่มออร่าที่อ่อนนุ่มและสว่างไสวรอบ ๆ รูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟ็กต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับการนำเสนอของคุณ ง่ายต่อการใช้งานด้วยโค้ดเพียงเล็กน้อย ซึ่งช่วยปรับปรุงรูปลักษณ์โดยรวมของสไลด์ของคุณ  

โค้ด C# นี้แสดงวิธีใช้ [เอฟเฟ็กต์เรืองแสง](https://reference.aspose.com/slides/th/net/aspose.slides/effectformat/gloweffect/) กับรูปร่าง:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![เอฟเฟ็กต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟ็กต์ขอบอ่อน**

เพื่อใช้เอฟเฟ็กต์ขอบอ่อนใน Aspose.Slides for .NET คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปร่าง เอฟเฟ็กต์นี้ให้รูปลักษณ์ที่ละเอียดอ่อนและเป็นมืออาชีพ เหมาะสำหรับการออกแบบที่ต้องการลุคที่อ่อนโยนและนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้เอฟเฟ็กต์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณ  

โค้ด C# นี้แสดงวิธีใช้ [ขอบอ่อน](https://reference.aspose.com/slides/th/net/aspose.slides/effectformat/softedgeeffect/) กับรูปร่าง:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![เอฟเฟ็กต์ขอบอ่อน](soft_edges_effect.png)

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟ็กต์กับรูปทร่างเดียวกันได้หรือไม่?**  

ได้ คุณสามารถผสานเอฟเฟ็กต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่มีความไดนามิกมากขึ้น  

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปทรงอะไรได้บ้าง?**  

คุณสามารถใช้เอฟเฟ็กต์กับรูปทรงหลายประเภท รวมถึงออโต้ชิพ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ  

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปทรงที่รวมกันเป็นกลุ่มได้หรือไม่?**  

ได้ คุณสามารถใช้เอฟเฟ็กต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟ็กต์จะถูกนำไปใช้กับทั้งกลุ่มโดยรวม