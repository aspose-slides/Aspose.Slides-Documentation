---
title: ทำให้ข้อความ PowerPoint เคลื่อนไหวใน .NET
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/net/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- การเคลื่อนไหวของข้อความ
- ย่อหน้าเคลื่อนไหว
- การเคลื่อนไหวของย่อหน้า
- เอฟเฟกต์การเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET พร้อมตัวอย่างโค้ด C# ที่ง่ายต่อการทำตามและผ่านการปรับให้เหมาะที่สุด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับข้อความที่เคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์การเคลื่อนไหวกับย่อหน้าต่าง ๆ และการดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วให้กับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้เพื่อเพิ่มการเคลื่อนไหวในระดับย่อหน้าและตรวจสอบเอฟเฟกต์การเคลื่อนไหวของย่อหน้าที่มีอยู่ในงานนำเสนอ

## **เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้า**

เราได้เพิ่มเมธอด [**AddEffect()**](https://reference.aspose.com/slides/th/net/aspose.slides.animation/sequence/methods/addeffect/index) ไปยังคลาส [**Sequence**](https://reference.aspose.com/slides/th/net/aspose.slides.animation/sequence) และ [**ISequence**](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence) เมธอดนี้ทำให้คุณสามารถเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้าเดียวได้ ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้าเดียว:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // เลือกย่อหน้าที่จะเพิ่มเอฟเฟกต์
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // เพิ่มเอฟเฟกต์การเคลื่อนไหวแบบ Fly ให้กับย่อหน้าที่เลือก
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **ดึงเอฟเฟกต์การเคลื่อนไหวสำหรับย่อหน้า**

คุณอาจต้องการตรวจสอบเอฟเฟกต์การเคลื่อนไหวที่เพิ่มให้กับย่อหน้า ตัวอย่างเช่น ในสถานการณ์หนึ่งคุณอาจต้องการดึงเอฟเฟกต์การเคลื่อนไหวในย่อหน้าเพื่อนำไปใช้กับย่อหน้าหรือรูปร่างอื่น

Aspose.Slides for .NET ช่วยให้คุณดึงเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (รูปร่าง) ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการดึงเอฟเฟกต์การเคลื่อนไหวในย่อหน้า:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **คำถามที่พบบ่อย**

**การเคลื่อนไหวของข้อความต่างจากการเปลี่ยนสไลด์อย่างไร และสามารถใช้ร่วมกันได้หรือไม่?**

การเคลื่อนไหวของข้อความควบคุมพฤติกรรมของออบเจกต์ตามเวลาบนสไลด์ ในขณะที่ [transitions](/slides/th/net/slide-transition/) ควบคุมวิธีการเปลี่ยนสไลด์ พวกมันทำงานแยกจากกันและสามารถใช้ร่วมกันได้; ลำดับการเล่นจะถูกกำหนดโดยไทม์ไลน์ของการเคลื่อนไหวและการตั้งค่า transition

**การเคลื่อนไหวของข้อความจะยังคงอยู่เมื่อส่งออกเป็น PDF หรือภาพหรือไม่?**

ไม่มี PDF และภาพ raster เป็นสภาพคงที่ ดังนั้นคุณจะเห็นสไลด์ในสถานะเดียวโดยไม่มีการเคลื่อนไหว หากต้องการรักษาการเคลื่อนไหว ให้ใช้การส่งออกเป็น [video](/slides/th/net/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/net/export-to-html5/)

**การเคลื่อนไหวของข้อความทำงานในเลเอาต์และสไลด์มาสเตอร์หรือไม่?**

เอฟเฟกต์ที่ใส่ลงในวัตถุของเลเอาต์หรือมาสเตอร์จะสืบทอดไปยังสไลด์ แต่การกำหนดเวลาและการโต้ตอบกับการเคลื่อนไหวระดับสไลด์จะขึ้นอยู่กับลำดับขั้นสุดท้ายบนสไลด์