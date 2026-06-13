---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน .NET
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ไปเป็น SVG
- การนำเสนอไปเป็น SVG
- สไลด์ไปเป็น SVG
- PPT ไปเป็น SVG
- PPTX ไปเป็น SVG
- บันทึก PPT เป็น SVG
- บันทึก PPTX เป็น SVG
- ส่งออก PPT เป็น SVG
- ส่งออก PPTX เป็น SVG
- แสดงสไลด์
- แปลงสไลด์
- ส่งออกสไลด์
- ภาพเวกเตอร์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเรนเดอร์สไลด์ PowerPoint เป็นภาพ SVG โดยใช้ Aspose.Slides สำหรับ .NET ตัวอย่างโค้ด C# ที่ง่ายและภาพคุณภาพสูง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแสดงสไลด์การนำเสนอเป็นภาพ SVG ด้วย Aspose.Slides โดยอธิบายรูปแบบ SVG และข้อดีของมัน รวมถึงความสามารถในการขยายตัว การเข้าถึงได้ และความเหมาะสมสำหรับการพัฒนาเว็บ

คุณจะได้เรียนรู้วิธีโหลดไฟล์งานนำเสนอ, วนลูปผ่านสไลด์ต่างๆ, และบันทึกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์ บทความนี้ครอบคลุมรูปแบบการนำเสนอ PowerPoint และ OpenDocument รวมถึง PPT, PPTX, ODP, และ PPS และแสดงวิธีทำการแปลงอย่างโปรแกรมเมติกด้วยคลาส `Presentation` และเมธอด `WriteAsSvg`

## **รูปแบบ SVG**
SVG—คำย่อของ Scalable Vector Graphics—เป็นประเภทหรือรูปแบบกราฟิกมาตรฐานที่ใช้ในการแสดงภาพสองมิติ SVG จะจัดเก็บภาพเป็นเวกเตอร์ใน XML พร้อมรายละเอียดที่กำหนดพฤติกรรมหรือรูปลักษณ์ของมัน

SVG เป็นหนึ่งในรูปแบบภาพไม่กี่รูปแบบที่ตอบสนองมาตรฐานสูงในแง่ของ ความสามารถในการขยายตัว, ความโต้ตอบ, ประสิทธิภาพ, การเข้าถึง, การเขียนโปรแกรม, และอื่นๆ ด้วยเหตุผลเหล่านี้จึงมักถูกใช้ในการพัฒนาเว็บ

คุณอาจต้องการใช้ไฟล์ SVG เมื่อคุณต้องการ

- **พิมพ์งานนำเสนอของคุณใน *รูปแบบที่ใหญ่มาก***. ภาพ SVG สามารถขยายตัวไปยังความละเอียดหรือระดับใดก็ได้ คุณสามารถปรับขนาดภาพ SVG ได้หลายครั้งตามต้องการโดยไม่สูญเสียคุณภาพ
- **ใช้แผนภูมิและกราฟจากสไลด์ของคุณใน *สื่อหรือแพลตฟอร์มที่แตกต่างกัน***. ผู้อ่านส่วนใหญ่สามารถตีความไฟล์ SVG ได้
- **ใช้ *ขนาดภาพที่เล็กร้อยที่สุดที่เป็นไปได้***. ไฟล์ SVG ปกติมีขนาดเล็กกว่าตัวที่มีความละเอียดสูงในรูปแบบอื่นๆ โดยเฉพาะรูปแบบที่อิงบิตแมป (JPEG หรือ PNG)

## **แปลงสไลด์เป็นภาพ SVG**

Aspose.Slides for .NET ช่วยให้คุณส่งออกสไลด์ในงานนำเสนอของคุณเป็นภาพ SVG ทำตามขั้นตอนเหล่านี้เพื่อสร้างภาพ SVG:

_ขั้นตอน: การแปลง PowerPoint เป็น SVG ใน C#_

โค้ดตัวอย่างต่อไปนี้อธิบายการแปลงเหล่านี้ด้วย .NET
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>ขั้นตอน: แปลง PowerPoint เป็น SVG ใน C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>ขั้นตอน: แปลง PPT เป็น SVG ใน C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>ขั้นตอน: แปลง PPTX เป็น SVG ใน C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>ขั้นตอน: แปลง ODP เป็น SVG ใน C#</strong></a>

_ขั้นตอนโค้ด:_

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
   * _.ppt_ extension เพื่อโหลดไฟล์ **PPT** ภายในคลาส _Presentation_  
   * _.pptx_ extension เพื่อโหลดไฟล์ **PPTX** ภายในคลาส _Presentation_  
   * _.odp_ extension เพื่อโหลดไฟล์ **ODP** ภายในคลาส _Presentation_  
   * _.pps_ extension เพื่อโหลดไฟล์ **PPS** ภายในคลาส _Presentation_  
2. วนลูปผ่านสไลด์ทั้งหมดในงานนำเสนอ  
3. เขียนสไลด์แต่ละสไลด์เป็นไฟล์ SVG แยกโดยใช้ FileStream  

{{% alert color="primary" %}} 

คุณอาจต้องการลองใช้ [แอปพลิเคชันเว็บฟรีของเรา](https://products.aspose.app/slides/th/conversion/ppt-to-svg) ซึ่งเราได้ทำฟังก์ชันการแปลง PPT เป็น SVG จาก Aspose.Slides for .NET  

{{% /alert %}} 

โค้ดตัวอย่างใน C# นี้แสดงวิธีการแปลง PowerPoint เป็น SVG ด้วย Aspose.Slides: 

``` csharp
// วัตถุ Presentation สามารถโหลดรูปแบบ PowerPoint เช่น PPT, PPTX, ODP เป็นต้น
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **คำถามที่พบบ่อย**

**ทำไม SVG ที่ได้อาจดูแตกต่างกันในแต่ละเบราว์เซอร์?**

การสนับสนุนฟีเจอร์ SVG เฉพาะแตกต่างกันตามเอนจินของเบราว์เซอร์ พารามิเตอร์ [SVGOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/) ช่วยแก้ไขความไม่เข้ากันเหล่านี้

**สามารถส่งออกไม่เฉพาะสไลด์แต่รวมถึงรูปทรงเดี่ยวเป็น SVG ได้หรือไม่?**

ได้. ใด ๆ ที่เป็น [shape can be saved as a separate SVG](https://reference.aspose.com/slides/th/net/aspose.slides/shape/writeassvg/) สามารถบันทึกเป็นไฟล์ SVG แยก ซึ่งสะดวกสำหรับไอคอน, พิกโทแกรม, และการนำกราฟิกกลับมาใช้ใหม่

**สามารถรวมหลายสไลด์เป็น SVG เดียว (strip/document) ได้หรือไม่?**

สถานการณ์มาตรฐานคือสไลด์หนึ่ง → SVG หนึ่ง การรวมหลายสไลด์เป็นผ้าใบ SVG เดียวเป็นขั้นตอนการประมวลผลต่อมาที่ทำที่ระดับแอปพลิเคชัน

## **ดูเพิ่มเติม** 

บทความนี้ยังครอบคลุมหัวข้อเหล่านี้ โค้ดเดียวกันกับด้านบน

_รูปแบบ_: **PowerPoint**
- [C# PowerPoint ไปเป็น SVG โค้ด](#csharp-powerpoint-to-svg)
- [C# PowerPoint ไปเป็น SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint ไปเป็น SVG แบบโปรแกรมเมติก](#csharp-powerpoint-to-svg)
- [C# PowerPoint ไปเป็น SVG ไลบรารี](#csharp-powerpoint-to-svg)
- [C# บันทึก PowerPoint เป็น SVG](#csharp-powerpoint-to-svg)
- [C# สร้าง SVG จาก PowerPoint](#csharp-powerpoint-to-svg)
- [C# สร้าง SVG จาก PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint ไปเป็น SVG ตัวแปลง](#csharp-powerpoint-to-svg)

_รูปแบบ_: **PPT**
- [C# PPT ไปเป็น SVG โค้ด](#csharp-ppt-to-svg)
- [C# PPT ไปเป็น SVG API](#csharp-ppt-to-svg)
- [C# PPT ไปเป็น SVG แบบโปรแกรมเมติก](#csharp-ppt-to-svg)
- [C# PPT ไปเป็น SVG ไลบรารี](#csharp-ppt-to-svg)
- [C# บันทึก PPT เป็น SVG](#csharp-ppt-to-svg)
- [C# สร้าง SVG จาก PPT](#csharp-ppt-to-svg)
- [C# สร้าง SVG จาก PPT](#csharp-ppt-to-svg)
- [C# PPT ไปเป็น SVG ตัวแปลง](#csharp-ppt-to-svg)

_รูปแบบ_: **PPTX**
- [C# PPTX ไปเป็น SVG โค้ด](#csharp-pptx-to-svg)
- [C# PPTX ไปเป็น SVG API](#csharp-pptx-to-svg)
- [C# PPTX ไปเป็น SVG แบบโปรแกรมเมติก](#csharp-pptx-to-svg)
- [C# PPTX ไปเป็น SVG ไลบรารี](#csharp-pptx-to-svg)
- [C# บันทึก PPTX เป็น SVG](#csharp-pptx-to-svg)
- [C# สร้าง SVG จาก PPTX](#csharp-pptx-to-svg)
- [C# สร้าง SVG จาก PPTX](#csharp-pptx-to-svg)
- [C# PPTX ไปเป็น SVG ตัวแปลง](#csharp-pptx-to-svg)

_รูปแบบ_: **ODP**
- [C# ODP ไปเป็น SVG โค้ด](#csharp-odp-to-svg)
- [C# ODP ไปเป็น SVG API](#csharp-odp-to-svg)
- [C# ODP ไปเป็น SVG แบบโปรแกรมเมติก](#csharp-odp-to-svg)
- [C# ODP ไปเป็น SVG ไลบรารี](#csharp-odp-to-svg)
- [C# บันทึก ODP เป็น SVG](#csharp-odp-to-svg)
- [C# สร้าง SVG จาก ODP](#csharp-odp-to-svg)
- [C# สร้าง SVG จาก ODP](#csharp-odp-to-svg)
- [C# ODP ไปเป็น SVG ตัวแปลง](#csharp-odp-to-svg)