---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย .NET
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/net/shape-effect/
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรืองรอบ
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ .NET — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที"
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะใช้เพื่อทำให้รูปร่างโดดเด่น แต่เอฟเฟกต์จะแตกต่างจาก [การเติม](/slides/th/net/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint สามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง กระจายแสงเงาของรูปร่าง ฯลฯ

![เอฟเฟกต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปร่าง คุณสามารถใช้เอฟเฟกต์หนึ่งหรือหลายแบบกับรูปร่างได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมผสานอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานที่ดูดีของสองหรือหลายเอฟเฟกต์ ซึ่งเป็นที่รู้จักแล้ว วิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่น่าพอใจ

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint ได้

## **ใช้เอฟเฟ็กต์เงา**

Aspose.Slides for .NET รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถกำหนดสี ทิศทาง ระยะทาง และรัศมีการเบลอให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือพาเนลโดดเด่นจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปร่าง ทำให้ดูเหมือนรูปร่างลอยขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีการเบลอให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด C# นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) กับสี่เหลี่ยมผืนผ้า:

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

### **ใช้เงาภายใน**

เมื่อต้องการจำลองสไตล์ภาพของเทมเพลต ใช้เงาภายในเพื่อให้การ์ดหรือพาเนลดูมีลักษณะฝังลงในพื้นผิว เงานอกจะแพร่กระจายนอกรูปร่างและทำให้ดูลอยขึ้น ส่วนเงาภายในจะทำให้ขอบภายในของรูปร่างมีสีเงา

เรียกใช้ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) แล้วกำหนดค่า [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) ค่าที่ใหญ่ขึ้นจะให้ขอบที่นุ่มขึ้น

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

เพื่อยกเลิกเงาภายใน ให้เรียกใช้ [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) บนรูปแบบเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for .NET คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งแสง และขนาด เอฟเฟกต์นี้เพิ่มความสวยงามให้กับงานนำเสนอของคุณโดยทำให้รูปร่างดูขัดเกลาและหรูหรามากขึ้น ใช้โค้ดง่าย ๆ เพื่อทำให้เอฟเฟกต์นี้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อการออกแบบที่สอดคล้องกัน

โค้ด C# นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) กับรูปร่าง:

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

## **ใช้เอฟเฟกต์แสงเรืองรอบ**

เพื่อใช้เอฟเฟกต์แสงเรืองรอบบนรูปร่างใน Aspose.Slides for .NET คุณสามารถเพิ่มออร่าที่นุ่มนวลและสว่างไสวรอบ ๆ รูปร่างโดยปรับคุณสมบัติต่าง ๆ เช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดตาให้กับงานนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้สไลด์ของคุณดูโดดเด่นยิ่งขึ้น

โค้ด C# นี้แสดงวิธีการใช้ [เอฟเฟกต์แสงเรืองรอบ](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) กับรูปร่าง:

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

![เอฟเฟกต์แสงเรืองรอบ](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for .NET คุณสามารถสร้างการเปลี่ยนแปลงที่ราบรื่นและเบลอรอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดและอ่อนโยน เหมาะสำหรับการออกแบบที่ต้องการลุคอ่อนนุ่ม คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้เอฟเฟกต์ที่ต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณได้อย่างง่ายดาย

โค้ด C# นี้แสดงวิธีการใช้ [ขอบนุ่ม](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) กับรูปร่าง:

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และแสงเรืองรอบ บนรูปร่างเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงออโต้ชพิพท์, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปแบบที่จัดกลุ่มกันได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปแบบที่จัดกลุ่มกันได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.