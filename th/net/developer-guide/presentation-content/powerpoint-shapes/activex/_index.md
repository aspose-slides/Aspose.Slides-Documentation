---
title: จัดการ ActiveX Controls ในงานนำเสนอด้วย .NET
linktitle: ActiveX
type: docs
weight: 80
url: /th/net/activex/
keywords:
- ActiveX
- การควบคุม ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, ปรับปรุงการแสดงตัวอย่างของการควบคุม, และใช้ซ้ำการควบคุม Windows Media Player ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET."
---
## **บทนำ**

ActiveX controls ให้สไลด์ PowerPoint มีองค์ประกอบเชิงโต้ตอบ เช่น กล่องข้อความ, ปุ่มคำสั่ง และเครื่องเล่นสื่อ. Aspose.Slides for .NET เปิดเผยการควบคุมของสไลด์ผ่าน [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). ใช้คอลเลกชันนี้เพื่อแก้ไขการควบคุม, ย้ายบนสไลด์, หรือเอาออก.

## **รายการ ActiveX Controls และคุณสมบัติที่เก็บไว้**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย, เปิดไฟล์เพื่ออ่านและวนลูปผ่านการควบคุมบนแต่ละสไลด์. ตัวอย่างจะรายงานหมายเลขสไลด์, ชื่อการควบคุม, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), และแต่ละคู่คีย์-ค่าใน [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). การอ่านงานนำเสนอจะทำโดยไม่ทำให้การควบคุมทำงาน, เรียกเหตุการณ์หรือมาโคร, เปลี่ยนค่า, หรือบันทึกไฟล์.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มคำสั่ง.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเลกชันคุณสมบัติที่ว่างจะแสดงเป็น `[]`. สำหรับการควบคุมที่ใช้การเก็บข้อมูลแบบไบนารี, `Properties` อาจคืนค่า `null`, แสดงเป็น `Properties unavailable`. หากต้องการเพียงชื่อเท่านั้น, ให้ใช้ [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) หลังจากตรวจสอบค่า null. รายงานจะแสดงคุณสมบัติที่สามารถดึงจากงานนำเสนอได้. การควบคุมอาจสนับสนุนคุณสมบัติเพิ่มเติมในช่วงเวลาใช้งาน.

## **แก้ไข ActiveX Controls**

ตัวอย่างคาดว่ามีงานนำเสนอที่เปิดใช้งานมาโครพร้อมกับกล่องข้อความชื่อ `TextBox1` และปุ่มคำสั่งชื่อ `CommandButton1` บนสไลด์แรก. ตัวอย่างใช้ [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายของปุ่ม. การควบคุมแต่ละตัวยังมีตัวอย่างภาพนิ่งที่ PowerPoint สามารถแสดงก่อนการเปิดใช้งาน. จัดเตรียมไฟล์ PNG สำหรับแต่ละการควบคุมที่แสดงข้อความและลักษณะที่อัปเดต. ตัวอย่างกำหนดรูปภาพเหล่านี้ผ่าน [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

ตัวอย่างย้ายการควบคุมทั้งหมดบนสไลด์แรกลง 100 จุดโดยเปลี่ยน [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). จากนั้นบันทึกงานนำเสนอที่แก้ไขเป็นรูปแบบ PPTM, แล้วใช้ [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) เพื่อบันทึกสำเนาที่สองที่ลบ ActiveX controls ออกจากสไลด์นั้นทั้งหมด.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **เพิ่ม ActiveX Media Player Control**

เพื่อใช้ซ้ำ Windows Media Player ที่กำหนดค่าไว้, เริ่มต้นด้วยเทมเพลตที่สไลด์แรกมีเครื่องเล่นชื่อ `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) คัดลอกสไลด์ทั้งหมดไปยังงานนำเสนอใหม่. ตัวอย่างตั้งค่า `URL` ของเครื่องเล่นใน [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) แล้วบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์. วิดีโอจะคงอยู่เป็นไฟล์ภายนอก, ดังนั้นให้เลือกเส้นทางที่เครื่องเล่นสามารถเข้าถึงได้ระหว่างการเล่น.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides สามารถเก็บ ActiveX controls ไว้โดยไม่ต้องเรียกใช้ได้หรือไม่?**

ได้. Aspose.Slides สามารถอ่านและบันทึกการควบคุม รวมถึงคุณสมบัติและตำแหน่งของมัน โดยไม่ต้องทำให้การควบคุมทำงาน.

**ActiveX controls แตกต่างจาก OLE objects อย่างไร?**

ActiveX controls ให้ผู้ใช้โต้ตอบกับสไลด์, เช่น ป้อนข้อความหรือคลิกปุ่ม. ส่วน [OLE object](/slides/th/net/manage-ole/) ทำให้สไลด์สามารถมีหรือเชื่อมโยงเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น, เช่น แผ่นงาน Excel.

**หลังจากบันทึกงานนำเสนอด้วย Aspose.Slides, งานกำหนดเหตุการณ์ของ ActiveX จะยังคงเรียก VBA macros หรือไม่?**

ให้บันทึกงานนำเสนอในรูปแบบที่รองรับมาโคร เช่น PPTM เพื่อรักษาโปรเจกต์ VBA ไว้. PowerPoint สำหรับ Windows สามารถรันตัวจัดการเหตุการณ์ที่มีอยู่ได้เมื่อการตั้งค่าความปลอดภัยอนุญาตให้ใช้ ActiveX controls และมาโครพร้อมกัน.