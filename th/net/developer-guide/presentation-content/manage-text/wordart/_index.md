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
- เอฟเฟกต์เงาใน
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides สำหรับ .NET แนวทางแบบขั้นตอนนี้ช่วยให้นักพัฒนาปรับปรุงการนำเสนอด้วยข้อความระดับมืออาชีพใน C#."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความสไตล์ที่สวยงามและน่าสนใจในงานนำเสนอ PowerPoint ของคุณ ด้วย Aspose.Slides for .NET นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt programmatically ได้เช่นเดียวกับใน Microsoft PowerPoint — โดยไม่ต้องติดตั้ง Office บทความนี้นำเสนอภาพรวมของการทำงานกับ WordArt ใน .NET รวมถึงวิธีการใช้การแปลงข้อความ รูปแบบการเติม สีขอบ เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาในงานนำเสนอของคุณดูมีชีวิตชีวาและดึงดูดใจมากขึ้น WordArt ทำให้คุณจัดการข้อความเป็นวัตถุกราฟิก ประกอบด้วยเอฟเฟกต์หรือการปรับเปลี่ยนพิเศษที่ใช้กับข้อความเพื่อทำให้ดูสวยงามหรือเด่นชัดมากขึ้น

## **สร้างเทมเพลต WordArt ง่ายและนำไปใช้กับข้อความ**

ในส่วนนี้เราจะสำรวจวิธีสร้างเทมเพลต WordArt ง่ายและนำไปใช้กับข้อความโดยใช้ Aspose.Slides for .NET WordArt ให้วิธีง่าย ๆ ในการเพิ่มลักษณะการแสดงผลของข้อความด้วยเอฟเฟกต์และสไตล์ที่โดดเด่น โดยการเรียนรู้ขั้นตอนพื้นฐานของการสร้างและการใช้ WordArt คุณสามารถปรับใช้เทคนิคเหล่านี้กับโปรเจกต์ใดก็ได้ ทำให้งานนำเสนอของคุณมีสีสันและจดจำได้ง่ายขึ้น

ก่อนอื่นเราจะสร้างข้อความง่าย ๆ ด้วยโค้ด C# ด้านล่าง:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

ต่อไปเราจะตั้งค่าความสูงของฟอนต์ข้อความให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เด่นชัดขึ้นด้วยโค้ดต่อไปนี้:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

จากนั้นเราจะใช้การเติมแบบ SmallGrid ให้กับข้อความและเพิ่มขอบข้อความสีดำความกว้าง 1 ด้วยโค้ดต่อไปนี้:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

ข้อความที่ได้:

![เทมเพลต WordArt แบบง่าย](WordArt_template.png)

## **ใช้เอฟเฟกต์ WordArt อื่น ๆ**

นอกจากการแปลงพื้นฐานแล้ว Aspose.Slides for .NET ยังช่วยให้คุณใช้เอฟเฟกต์ WordArt ขั้นสูงหลากหลายเพื่อเพิ่มความสวยงามให้กับข้อความของคุณ ซึ่งรวมถึงขอบ, การเติม, เงา, การสะท้อน, และเอฟเฟกต์เรืองแสง โดยการผสานคุณสมบัติเหล่านี้ร่วมกัน คุณสามารถสร้างสไตล์ข้อความที่น่าสนใจและโดดเด่นในงานนำเสนอของคุณ ส่วนนี้จะแสดงวิธีใช้เอฟเฟกต์เหล่านี้ด้วยโค้ดที่เรียบง่ายและชัดเจน

### **ใช้เอฟเฟกต์เงานอก (Outer Shadow)**

เอฟเฟกต์เงานอกช่วยให้ข้อความเด่นชัดขึ้นโดยเพิ่มเงาที่อยู่ด้านหลังขอบของข้อความ สร้างความลึกและความแยกจากพื้นหลัง Aspose.Slides for .NET ทำให้คุณสามารถใช้และปรับแต่งเงานอกบนข้อความ WordArt ได้อย่างง่ายดาย ในส่วนนี้คุณจะได้เรียนรู้วิธีตั้งค่าสีเงา, ทิศทาง, ระยะทาง, รัศมีการเบลอ และอื่น ๆ เพื่อให้ได้ผลลัพธ์ตามที่ต้องการ

โค้ด C# ตัวอย่างต่อไปนี้ใช้เพื่อเพิ่มเอฟเฟกต์เงาให้กับข้อความที่สร้างขึ้นข้างต้น

```cs
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
```

ข้อความที่ได้:

![เอฟเฟกต์เงานอก](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะใช้เฉพาะเอฟเฟกต์ OuterShadow เท่านั้น  
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์ขึ้นอยู่กับเวอร์ชันของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะถูกทำซ้ำสองเท่า ในขณะที่ใน PowerPoint 2007 จะใช้เฉพาะเอฟเฟกต์ OuterShadow เท่านั้น  
{{% /alert %}}

### **ใช้เอฟเฟกต์การสะท้อน (Reflection)**

ในส่วนนี้เราจะสำรวจวิธีใช้เอฟเฟกต์การสะท้อนในสไลด์ด้วย Aspose.Slides for .NET เอฟเฟกต์การสะท้อนเป็นวิธีที่มีประสิทธิภาพในการทำให้ข้อความหรือรูปทรงดูหรูและทันสมัย ช่วยให้ส่วนที่สำคัญเด่นชัดและเพิ่มความลึกให้กับการนำเสนอของคุณ โดยการเข้าใจกระบวนการใช้และปรับแต่งเอฟเฟกต์เหล่านี้ คุณสามารถปรับให้ตรงกับความต้องการด้านการออกแบบและแบรนด์ได้ง่าย

เพิ่มเอฟเฟกต์การสะท้อนให้กับข้อความด้วยตัวอย่างโค้ด C# นี้:

```cs
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
```

ข้อความที่ได้:

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

### **ใช้เอฟเฟกต์เรืองแสง (Glow)**

ในส่วนนี้เราจะสำรวจวิธีใช้เอฟเฟกต์เรืองแสงกับข้อความโดยใช้ Aspose.Slides for .NET เอฟเฟกต์เรืองแสงทำให้ข้อความของคุณเด่นชัดด้วยขอบเรืองแสง เพิ่มความน่าสนใจให้กับสไลด์ของคุณ โดยการปรับค่าเช่น สีและความเข้ม คุณสามารถปรับเอฟเฟกต์ให้ตรงกับการออกแบบและแบรนด์ของคุณได้ง่าย เพื่อให้จุดสำคัญในงานนำเสนอของคุณดึงดูดความสนใจของผู้ฟัง

ใช้เอฟเฟกต์เรืองแสงบนข้อความเพื่อทำให้มันโบยหรือเด่นด้วยโค้ดต่อไปนี้:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

ข้อความที่ได้:

![เอฟเฟกต์เรืองแสง](glow_effect.png)

### **ใช้การแปลง WordArt (WordArt Transformations)**

ในส่วนนี้เราจะสำรวจวิธีใช้การแปลงใน WordArt ด้วย Aspose.Slides for .NET การแปลงทำให้คุณโค้ง, ยืด, หรือบิดข้อความเพื่อสร้างเอฟเฟกต์ที่เป็นเอกลักษณ์และน่าสนใจ โดยการเชี่ยวชาญเทคนิคเหล่านี้ คุณสามารถปรับรูปร่างและสไตล์ของข้อความให้ตรงกับแบรนด์หรือวิสัยทัศน์ของคุณได้อย่างง่ายดาย ทำให้งานนำเสนอของคุณดูมีพลังและเป็นมืออาชีพ

ใช้คุณสมบัติ `Transform` (ที่ใช้กับบล็อกข้อความทั้งหมด) ด้วยโค้ดต่อไปนี้:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

ข้อความที่ได้:

![การแปลง WordArt](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides for .NET มีชุดประเภทการแปลงที่กำหนดไว้ล่วงหน้าไว้ที่ [ประเภทการแปลง](https://reference.aspose.com/slides/th/net/aspose.slides/textshapetype/).  
{{% /alert %}} 

### **ใช้เอฟเฟกต์ 3 มิติ (3D) กับรูปทรงและข้อความ**

การสร้างภาพที่สมจริงและดึงดูดสายตาสามารถเพิ่มอิทธิพลของงานนำเสนอของคุณอย่างมาก ในส่วนนี้เราจะสำรวจวิธีใช้เอฟเฟกต์สามมิติ (3D) กับรูปทรงโดยใช้ Aspose.Slides for .NET ด้วยการปรับค่าความลึก, มุม, และแสง คุณสามารถสร้างการแปลง 3D ที่น่าประทับใจและดึงดูดความสนใจของผู้ฟังได้ทันที ไม่ว่าจะเป็นการเน้นแบบละเอียดหรือการสร้างภาพลวงตาที่โดดเด่น ฟีเจอร์เหล่านี้ให้วิธีที่ยืดหยุ่นในการยกระดับการออกแบบและสื่อสารแนวคิดของคุณให้มีความน่าสนใจมากขึ้น

ใช้โค้ดตัวอย่างต่อไปนี้เพื่อตั้งค่าเอฟเฟกต์ 3D ให้กับรูปทรง:

```cs
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
```

รูปทรงที่ได้:

![เอฟเฟกต์ 3D ของรูปทรง](shape_3D_effect.png)

ใช้โค้ดตัวอย่างต่อไปนี้เพื่อตั้งค่าเอฟเฟกต์ 3D ให้กับข้อความ:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

ข้อความที่ได้:

![เอฟเฟกต์ 3D ของข้อความ](text_3D_effect.png)

{{% alert color="primary" %}} 
การใช้เอฟเฟกต์ 3D กับข้อความหรือรูปทรงของข้อความ—and การทำงานร่วมกันของเอฟเฟกต์เหล่านี้—ได้รับการกำหนดโดยกฎเฉพาะ พิจารณาฉากที่ประกอบด้วยข้อความและรูปทรงที่บรรจุข้อความนั้น เอฟเฟกต์ 3D จะรวมถึงการแสดงผล 3D ของวัตถุและฉากที่วัตถุอยู่

- หากกำหนดฉากสำหรับทั้งรูปทรงและข้อความ ฉากของรูปทรงจะมีลำดับความสำคัญและฉากของข้อความจะถูกละเลย  
- หากรูปทรงไม่มีฉากของตนเองแต่มีการแสดงผล 3D จะใช้ฉากของข้อความ  
- หากรูปทรงไม่มีเอฟเฟกต์ 3D เลย จะถือว่าเป็นแบนและเอฟเฟกต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น  

พฤติกรรมเหล่านี้เกี่ยวข้องกับคุณสมบัติ [ThreeDFormat.LightRig](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/lightrig/) และ [ThreeDFormat.Camera](https://reference.aspose.com/slides/th/net/aspose.slides/threedformat/camera/)  
{{% /alert %}} 

## **คำถามที่พบบ่อย (FAQ)**

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่แตกต่าง (เช่น อาหรับ, จีน) ได้หรือไม่?**

ได้, Aspose.Slides for .NET รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติม, และขอบสามารถนำไปใช้ได้โดยไม่คำนึงถึงภาษา แม้ว่าการมีฟอนต์และการแสดงผลอาจขึ้นกับฟอนต์ของระบบ

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบของ Slide Master ได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปทรงบนสไลด์แม่รวมถึงตัวยึดหัวเรื่อง, เท้า, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลเอาต์แม่จะสะท้อนไปทั่วสไลด์ที่สัมพันธ์กันทั้งหมด

**เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์ของงานนำเสนอหรือไม่?**

มีผลเล็กน้อย. เอฟเฟกต์ WordArt อย่างเงา, เรืองแสง, และการเติมแบบไล่สีอาจทำให้ขนาดไฟล์เพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาทาเพิ่มเติมของการจัดรูปแบบ แต่ส่วนต่างมักไม่สำคัญ

**ฉันสามารถดูตัวอย่างผลของเอฟเฟกต์ WordArt ได้โดยไม่ต้องบันทึกงานนำเสนอหรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) ด้วยเมธอด `GetImage` จากอินเตอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) หรือ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ซึ่งช่วยให้คุณดูผลลัพธ์ในหน่วยความจำหรือบนหน้าจอได้ก่อนบันทึกหรือส่งออกรายการนำเสนอเต็มรูปแบบ.