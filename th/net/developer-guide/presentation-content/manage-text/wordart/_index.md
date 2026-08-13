---
title: สร้างและใช้เอฟเฟกต์ WordArt ใน .NET
linktitle: WordArt
type: docs
weight: 110
url: /th/net/wordart/
keywords:
- WordArt
- สร้าง WordArt
- เทมเพลต WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การแสดงผล
- เอฟเฟกต์เรืองแสง
- การแปลง WordArt
- เอฟเฟกต์ 3 มิติ
- เอฟเฟกต์เงานอก
- เอฟเฟกต์เงาภายใน
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ .NET คู่มือขั้นตอนต่อขั้นตอนนี้ช่วยนักพัฒนาปรับปรุงการนำเสนอด้วยข้อความระดับมืออาชีพใน C#."
---
## **ภาพรวม**

WordArt effects ช่วยให้คุณเพิ่มข้อความสไตล์ที่สวยงามและน่าสนใจในงานนำเสนอ PowerPoint ของคุณ ด้วย Aspose.Slides for .NET นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt ได้โดยอัตโนมัติเหมือนใน Microsoft PowerPoint—โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมของการทำงานกับ WordArt ใน .NET รวมถึงวิธีการใช้การแปลงข้อความ สไตล์การเติม สีขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาการนำเสนอของคุณมีความแสดงออกและดึงดูดมากขึ้น WordArt ทำให้คุณจัดการข้อความเป็นวัตถุกราฟิก ซึ่งประกอบด้วยเอฟเฟกต์หรือการปรับเปลี่ยนพิเศษที่ใช้กับข้อความเพื่อทำให้ดูโดดเด่นหรือสังเกตได้ง่ายขึ้น

## **สร้างเท็มเพลต WordArt อย่างง่ายและนำไปใช้กับข้อความ**

ในส่วนนี้เราจะสำรวจวิธีการสร้างเท็มเพลต WordArt อย่างง่ายและนำไปใช้กับข้อความโดยใช้ Aspose.Slides for .NET WordArt ให้วิธีง่าย ๆ ในการปรับปรุงลักษณะของข้อความด้วยเอฟเฟกต์และสไตล์ที่โดดเด่น โดยเรียนรู้ขั้นตอนพื้นฐานของการสร้างและการใช้งาน WordArt คุณสามารถนำเทคนิคเหล่านี้ไปปรับใช้กับโครงการใด ๆ ทำให้การนำเสนอของคุณมีชีวิตชีวาและน่าจดจำยิ่งขึ้น

แรกสุด เราจะสร้างข้อความง่าย ๆ ด้วยโค้ด C# ต่อไปนี้:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

ต่อมา เราจะตั้งค่าความสูงของฟอนต์ข้อความให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เด่นชัดยิ่งขึ้นโดยใช้โค้ดต่อไปนี้:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

ต่อจากนั้น เราจะใช้การเติมรูปแบบ SmallGrid กับข้อความและเพิ่มเส้นขอบสีดำความกว้าง 1 ด้วยโค้ดต่อไปนี้:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

ข้อความที่ได้:

![เท็มเพลต WordArt อย่างง่าย](WordArt_template.png)

## **ใช้เอฟเฟกต์ WordArt อื่น ๆ**

นอกเหนือจากการแปลงพื้นฐาน Aspose.Slides for .NET ยังให้คุณใช้เอฟเฟกต์ WordArt ขั้นสูงหลากหลายเพื่อปรับปรุงลักษณะข้อความของคุณ รวมถึงขอบสี การเติม เงา การสะท้อน และเอฟเฟกต์เรืองแสง โดยการผสานคุณลักษณะเหล่านี้เข้าด้วยกัน คุณสามารถสร้างสไตล์ข้อความที่ดึงดูดสายตาและโดดเด่นในงานนำเสนอของคุณ ส่วนนี้จะแสดงวิธีการใช้เอฟเฟกต์เหล่านี้ด้วยโค้ดที่เรียบง่ายและสะอาด

### **ใช้เอฟเฟกต์เงานอก**

เอฟเฟกต์เงานอกช่วยให้ข้อความเด่นขึ้นโดยเพิ่มเงาที่อยู่ด้านหลังขอบของข้อความ ทำให้เกิดความลึกและแยกจากพื้นหลัง Aspose.Slides for .NET อนุญาตให้คุณใช้และปรับแต่งเงานอกบนข้อความ WordArt ได้อย่างง่ายดาย ในส่วนนี้คุณจะได้เรียนรู้วิธีตั้งค่าสีเงา ทิศทาง ระยะทาง รัศมีเบลอร์ และอื่น ๆ เพื่อให้ได้ผลลัพธ์ตามต้องการ

โค้ด C# ตัวอย่างต่อไปนี้ใช้เงากับข้อความที่สร้างไว้ข้างต้น

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

ข้อความที่ได้:

![เอฟเฟกต์เงานอก](outer_shadow_effect.png)

{{% alert color="info" %}} 
- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะมีเพียงเอฟเฟกต์ OuterShadow เท่านั้นที่ถูกนำไปใช้
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์ขึ้นกับเวอร์ชันของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 จะเห็นเอฟเฟกต์ซ้ำสองเท่า ส่วนใน PowerPoint 2007 จะมีเพียงเอฟเฟกต์ OuterShadow เท่านั้น
{{% /alert %}}

### **ใช้เอฟเฟกต์การสะท้อน**

ในส่วนนี้เราจะสำรวจวิธีการใช้เอฟเฟกต์การสะท้อนในสไลด์ของคุณด้วย Aspose.Slides for .NET เอฟเฟกต์การสะท้อนเป็นวิธีที่มีประสิทธิภาพในการทำให้ข้อความหรือรูปร่างดูสไตล์และทันสมัย ช่วยให้องค์ประกอบสำคัญโดดเด่นและเพิ่มความลึกให้กับการนำเสนอของคุณ โดยการเข้าใจกระบวนการนำไปใช้และการปรับแต่งคุณสามารถปรับให้เข้ากับความต้องการด้านการออกแบบและแบรนด์ของคุณได้อย่างง่ายดาย

เพิ่มเอฟเฟกต์การสะท้อนให้กับข้อความด้วยตัวอย่างโค้ด C# ต่อไปนี้:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableReflectionEffect();
    portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
}
```

ข้อความที่ได้:

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

### **ใช้เอฟเฟกต์เรืองแสง**

ในส่วนนี้เราจะสำรวจวิธีการใช้เอฟเฟกต์เรืองแสงกับข้อความด้วย Aspose.Slides for .NET เอฟเฟกต์เรืองแสงสามารถทำให้ข้อความของคุณเด่นด้วยโครงรอบที่ส่องแสง เพิ่มความสวยงามให้กับสไลด์ของคุณ โดยการปรับสีและความเข้ม คุณสามารถปรับให้สอดคล้องกับการออกแบบและแบรนด์ของคุณได้ง่าย ๆ เพื่อให้จุดสำคัญในงานนำเสนอดึงดูดความสนใจของผู้ชม

ใช้เอฟเฟกต์เรืองแสงกับข้อความเพื่อทำให้ข้อความส่องแสงหรือเด่นด้วยโค้ดต่อไปนี้:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

ข้อความที่ได้:

![เอฟเฟกต์เรืองแสง](glow_effect.png)

### **ใช้การแปลง WordArt**

ในส่วนนี้เราจะสำรวจวิธีการใช้การแปลงใน WordArt ด้วย Aspose.Slides for .NET การแปลงช่วยให้คุณดัดเบี้ยง ยืด หรือบิดข้อความเพื่อสร้างเอฟเฟกต์ที่เป็นเอกลักษณ์และดึงดูดสายตา โดยการเชี่ยวชาญเทคนิคเหล่านี้ คุณสามารถปรับรูปแบบและสไตล์ข้อความให้สอดคล้องกับแบรนด์หรือวิสัยทัศน์สร้างสรรค์ของคุณ ทำให้งานนำเสนอของคุณดูน่าประทับใจและเป็นมืออาชีพ

ใช้คุณสมบัติ `Transform` (ซึ่งส่งผลต่อบล็อกข้อความทั้งหมด) ด้วยโค้ดต่อไปนี้:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

ข้อความที่ได้:

![การแปลง WordArt](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET มีชุดของ [ประเภทการแปลง](https://reference.aspose.com/slides/th/net/aspose.slides/textshapetype/) ที่กำหนดไว้ล่วงหน้า
{{% /alert %}} 

### **ใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความ**

การสร้างภาพที่สมจริงและดึงดูดสายตาสามารถเพิ่มผลกระทบต่อการนำเสนอของคุณได้อย่างมาก ในส่วนนี้เราจะสำรวจวิธีการใช้เอฟเฟกต์สามมิติ (3D) กับรูปร่างโดยใช้ Aspose.Slides for .NET ด้วยการปรับพารามิเตอร์เช่น ความลึก มุม และการจัดแสง คุณสามารถสร้างการแปลง 3D ที่น่าประทับใจและดึงดูดความสนใจของผู้ชมได้ทันที ไม่ว่าจะเป็นการไฮไลท์แบบอ่อน ๆ หรือภาพลวงตาที่ดราม่า คุณลักษณะเหล่านี้ให้วิธีที่ยืดหยุ่นในการยกระดับการออกแบบและสื่อสารแนวคิดของคุณให้มีความน่าสนใจยิ่งขึ้น

ใช้โค้ดตัวอย่างต่อไปนี้เพื่อกำหนดเอฟเฟกต์ 3D ให้กับรูปร่าง:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

    autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
    autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

    autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelTop.Height = 12.5;
    autoShape.ThreeDFormat.BevelTop.Width = 11;

    autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    autoShape.ThreeDFormat.ExtrusionHeight = 6;

    autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    autoShape.ThreeDFormat.ContourWidth = 1.5;

    autoShape.ThreeDFormat.Depth = 3;

    autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

    autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

รูปร่างที่ได้:

![เอฟเฟกต์ 3D ของรูปร่าง](shape_3D_effect.png)

ใช้โค้ดตัวอย่างต่อไปนี้เพื่อกำหนดเอฟเฟกต์ 3D ให้กับข้อความ:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

ข้อความที่ได้:

![เอฟเฟกต์ 3D ของข้อความ](text_3D_effect.png)

{{% alert color="info" %}} 
การใช้เอฟเฟกต์ 3D กับข้อความหรือรูปร่างของข้อความ—and การโต้ตอบระหว่างเอฟเฟกต์เหล่านี้—ถูกกำหนดโดยกฎเฉพาะ พิจารณาฉากที่ประกอบด้วยทั้งข้อความและรูปร่างที่บรรจุตัวข้อความนั้นเอฟเฟกต์ 3D จะรวมการแสดงผล 3D ของวัตถุและฉากที่วางไว้

- หากกำหนดฉากสำหรับทั้งรูปร่างและข้อความ ฉากของรูปร่างจะมีลำดับความสำคัญและฉากของข้อความจะถูกละเลย
- หากรูปร่างไม่มีฉากของตนเองแต่มีการแสดงผล 3D จะใช้ฉากของข้อความ
- หากรูปร่างไม่มีเอฟเฟกต์ 3D เลย จะถือว่าเป็นแบนและเอฟเฟกต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความ

พฤติกรรมเหล่านี้เกี่ยวข้องกับคุณสมบัติ [ThreeDFormat.LightRig](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/lightrig/) และ [ThreeDFormat.Camera](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/camera/)
{{% /alert %}} 

## **คำถามที่พบบ่อย**

### สามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ต่าง ๆ (เช่น ภาษาอาหรับ, จีน) ได้หรือไม่?

ได้ Aspose.Slides for .NET รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา การเติม และขอบสามารถใช้ได้โดยไม่คำนึงถึงภาษา แม้ว่า availability ของฟอนต์และการเรนเดอร์อาจขึ้นกับฟอนต์ระบบ

### สามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบใน slide master ได้หรือไม่?

ได้ คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปร่างบน master slide รวมถึง placeholder ของหัวเรื่อง ส่วนท้าย หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาท์ master จะสะท้อนไปยังสไลด์ที่เชื่อมโยงทั้งหมด

### เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์ของงานนำเสนอหรือไม่?

ค่อนข้างเล็ก เอฟเฟกต์ WordArt เช่น เงา เรืองแสง และการเติมไล่ระดับสีอาจเพิ่มขนาดไฟล์เล็กน้อยเนื่องจากเมตาดาต้าการจัดรูปแบบที่เพิ่มเข้ามา แต่ส่วนต่างมักไม่มีนัยสำคัญ

### สามารถดูตัวอย่างผลของเอฟเฟกต์ WordArt โดยไม่ต้องบันทึกงานนำเสนอได้หรือไม่?

ได้ คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `GetImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) วิธีนี้ช่วยให้คุณดูตัวอย่างผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกงานนำเสนอเต็มรูปแบบ