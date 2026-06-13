---
title: จัดการโหนดรูปทรง SmartArt ในงานนำเสนอด้วย .NET
linktitle: โหนดรูปทรง SmartArt
type: docs
weight: 30
url: /th/net/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดย่อย
- เพิ่มโหนด
- ตำแหน่งโหนด
- เข้าถึงโหนด
- ลบโหนด
- ตำแหน่งกำหนดเอง
- โหนดผู้ช่วย
- รูปแบบการเติม
- เรนเดอร์โหนด
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการโหนดรูปทรง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides สำหรับ .NET. รับตัวอย่างโค้ดที่ชัดเจนและเคล็ดลับเพื่อทำให้งานนำเสนอของคุณเป็นระบบระเบียบ"
---
## **ภาพรวม**

กราฟิก SmartArt ในงานนำเสนอ PowerPoint จัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของแผนภาพ Aspose.Slides อนุญาตให้คุณทำงานกับโหนด SmartArt เหล่านี้โดยโปรแกรม: เพิ่มโหนดและโหนดย่อยใหม่, แทรกโหนดย่อยในตำแหน่งที่กำหนด, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ, ระดับ, และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปทรง SmartArt แสดงวิธีการลบโหนด, ทำงานกับโหนดย่อยโดยใช้ดัชนีหรือตำแหน่ง, เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ, ปรับตำแหน่ง, ขนาด, และการหมุนของรูปทรงโหนด SmartArt, ตั้งค่ารูปแบบการเติมของโหนด, และสร้างภาพขนาดย่อของโหนดย่อย SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for .NET มี API ที่ง่ายที่สุดเพื่อจัดการรูปทรง SmartArt อย่างง่าย ตัวอย่างโค้ดต่อไปนี้จะช่วยเพิ่มโหนดและโหนดย่อยภายในรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำการ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- เพิ่ม Node ใหม่ใน NodeCollection ของรูปทรง SmartArt และตั้งค่าข้อความใน TextFrame
- ตอนนี้, เพิ่มโหนดย่อยใน SmartArt Node ที่เพิ่งเพิ่มใหม่และตั้งค่าข้อความใน TextFrame
- บันทึกงานนำเสนอ

```c#
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AddNodes.pptx");

// วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // แปลงประเภทรูปร่างเป็น SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // เพิ่มโหนด SmartArt ใหม่
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // เพิ่มข้อความ
        TemNode.TextFrame.Text = "Test";

        // เพิ่มโหนดย่อยใหม่ในโหนดแม่ โหนดนี้จะถูกเพิ่มที่ตำแหน่งสุดท้ายของคอลเลกชัน
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // เพิ่มข้อความ
        newNode.TextFrame.Text = "New Node Added";

    }
}

// บันทึกงานนำเสนอ
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **เพิ่มโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้ เราอธิบายวิธีการเพิ่มโหนดย่อยที่เป็นส่วนหนึ่งของโหนดที่สอดคล้องของรูปทรง SmartArt ในตำแหน่งที่กำหนด

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เพิ่มรูปทรง SmartArt แบบ StackedList ในสไลด์ที่เข้าถึงได้
- เข้าถึงโหนดแรกในรูปทรง SmartArt ที่เพิ่มไว้
- ตอนนี้, เพิ่มโหนดย่อยสำหรับโหนดที่เลือกที่ตำแหน่ง 2 และตั้งค่าข้อความของมัน
- บันทึกงานนำเสนอ

```c#
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();

// เข้าถึงสไลด์ของงานนำเสนอ
ISlide slide = pres.Slides[0];

// เพิ่ม Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// เข้าถึงโหนด SmartArt ที่ดัชนี 0
ISmartArtNode node = smart.AllNodes[0];

// เพิ่มโหนดย่อยใหม่ที่ตำแหน่ง 2 ในโหนดแม่
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// เพิ่มข้อความ
chNode.TextFrame.Text = "Sample Text Added";

// บันทึกงานนำเสนอ
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **เข้าถึงโหนด SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโหนดภายในรูปทรง SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นแบบอ่านอย่างเดียวและตั้งค่าได้เฉพาะเมื่อเพิ่มรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มีรูปทรง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำการ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- วนผ่านทุก Node ภายในรูปทรง SmartArt
- เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนด SmartArt, ระดับ, และข้อความ

```c#
  // โหลดงานนำเสนอที่ต้องการ
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // แปลงประเภทรูปร่างเป็น SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // วนผ่านโหนดทั้งหมดภายใน SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // เข้าถึงโหนด SmartArt ที่ดัชนี i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // พิมพ์พารามิเตอร์ของโหนด SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **เข้าถึงโหนดย่อย SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโหนดย่อยที่เป็นส่วนหนึ่งของโหนดที่สอดคล้องของรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส PresentationEx และโหลดงานนำเสนอที่มีรูปทรง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำการ Typecast รูปร่างที่เลือกเป็น SmartArtEx หากเป็น SmartArt
- วนผ่านทุก Node ภายในรูปทรง SmartArt
- สำหรับแต่ละ SmartArt shape Node ที่เลือก, วนผ่านโหนดย่อยทั้งหมดภายในโหนดนั้น
- เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนดย่อย, ระดับ, และข้อความ

```c#
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AccessChildNodes.pptx");

// วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // แปลงประเภทรูปร่างเป็น SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // วนผ่านโหนดทั้งหมดภายใน SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // เข้าถึงโหนด SmartArt ที่ดัชนี i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // วนผ่านโหนดลูกในโหนด SmartArt ที่ดัชนี i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // เข้าถึงโหนดลูกในโหนด SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // พิมพ์พารามิเตอร์ของโหนดลูก SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **เข้าถึงโหนดย่อย SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้การเข้าถึงโหนดย่อยในตำแหน่งบางอย่างที่เป็นส่วนหนึ่งของโหนดที่สอดคล้องของรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เพิ่มรูปทรง SmartArt แบบ StackedList
- เข้าถึงรูปทรง SmartArt ที่เพิ่มไว้
- เข้าถึงโหนดที่ตำแหน่งดัชนี 0 สำหรับรูปทรง SmartArt ที่เข้าถึงได้
- ตอนนี้, เข้าถึงโหนดย่อยที่ตำแหน่ง 1 สำหรับโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด GetNodeByPosition()
- เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งโหนดย่อย, ระดับ, และข้อความ

```c#
// สร้างอินสแตนซ์ของงานนำเสนอ
Presentation pres = new Presentation();

// เข้าถึงสไลด์แรก
ISlide slide = pres.Slides[0];

// เพิ่มรูปทรง SmartArt ในสไลด์แรก
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// เข้าถึงโหนด SmartArt ที่ดัชนี 0
ISmartArtNode node = smart.AllNodes[0];

// เข้าถึงโหนดลูกที่ตำแหน่ง 1 ในโหนดแม่
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// พิมพ์พารามิเตอร์ของโหนดลูก SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **ลบโหนด SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มีรูปทรง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำการ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- ตรวจสอบว่า SmartArt มีโหนดมากกว่า 0 โหนดหรือไม่
- เลือกโหนด SmartArt ที่จะลบ
- ตอนนี้, ลบโหนดที่เลือกโดยใช้เมธอด RemoveNode() * บันทึกงานนำเสนอ

```c#
// โหลดงานนำเสนอที่ต้องการ
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape is ISmartArt)
        {
            // แปลงประเภทรูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // เข้าถึงโหนด SmartArt ที่ดัชนี 0
                ISmartArtNode node = smart.AllNodes[0];

                // ลบโหนดที่เลือก
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // บันทึกงานนำเสนอ
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ลบโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้การลบโหนดภายในรูปทรง SmartArt ที่ตำแหน่งเฉพาะ

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มีรูปทรง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำการ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- เลือกโหนดรูปทรง SmartArt ที่ตำแหน่งดัชนี 0
- ตอนนี้, ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดย่อยมากกว่า 2 โหนดหรือไม่
- ตอนนี้, ลบโหนดที่ตำแหน่ง 1 โดยใช้เมธอด RemoveNodeByPosition()
- บันทึกงานนำเสนอ

```c#
// โหลดงานนำเสนอที่ต้องการ             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // แปลงประเภทรูปร่างเป็น SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // เข้าถึงโหนด SmartArt ที่ดัชนี 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // ลบโหนดลูกที่ตำแหน่ง 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// บันทึกงานนำเสนอ
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดย่อยในวัตถุ SmartArt**
ตอนนี้ Aspose.Slides for .NET รองรับการตั้งค่าคุณสมบัติ X และ Y ของ SmartArtShape โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาด, และการหมุนของ SmartArtShape อย่างกำหนดเอง โปรดทราบว่าการเพิ่มโหนดใหม่ทำให้ตำแหน่งและขนาดของโหนดทั้งหมดต้องคำนวณใหม่

```c#
// โหลดงานนำเสนอที่ต้องการ
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// ย้ายรูปร่าง SmartArt ไปยังตำแหน่งใหม่
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// เปลี่ยนความกว้างของรูปร่าง SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// เปลี่ยนความสูงของรูปร่าง SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// เปลี่ยนการหมุนของรูปร่าง SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **ตรวจสอบโหนดผู้ช่วย**
ในตัวอย่างโค้ดต่อไปนี้ เราจะตรวจสอบวิธีการระบุโหนดผู้ช่วยในคอลเลกชันโหนด SmartArt และการเปลี่ยนแปลงพวกมัน

- สร้างอินสแตนซ์ของคลาส PresentationEx และโหลดงานนำเสนอที่มีรูปทรง SmartArt
- รับอ้างอิงของสไลด์ที่สองโดยใช้ Index ของมัน
- วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำการ Typecast รูปร่างที่เลือกเป็น SmartArtEx หากเป็น SmartArt
- วนผ่านทุกโหนดภายในรูปทรง SmartArt และตรวจสอบว่าพวกมันเป็นโหนดผู้ช่วยหรือไม่
- เปลี่ยนสถานะของโหนดผู้ช่วยให้เป็นโหนดปกติ
- บันทึกงานนำเสนอ

```c#
// สร้างอินสแตนซ์ของงานนำเสนอ
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // วนผ่านรูปร่างทั้งหมดภายในสไลด์แรก
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // แปลงประเภทรูปร่างเป็น SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // วนผ่านโหนดทั้งหมดของรูปทรง SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // ตรวจสอบว่าโหนดเป็นโหนดผู้ช่วยหรือไม่
                if (node.IsAssistant)
                {
                    // ตั้งค่าโหนดผู้ช่วยเป็น false และทำให้เป็นโหนดปกติ
                    node.IsAssistant = false;
                }
            }
        }
    }
    // บันทึกงานนำเสนอ
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **ตั้งค่ารูปแบบการเติมของโหนด**
Aspose.Slides for .NET ทำให้สามารถเพิ่มรูปทรง SmartArt ที่กำหนดเองและตั้งค่ารูปแบบการเติมของโหนดได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปทรง SmartArt และตั้งค่ารูปแบบการเติมโดยใช้ Aspose.Slides for .NET

กรุณาทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- เพิ่มรูปทรง SmartArt โดยตั้งค่า LayoutType
- ตั้งค่า FillFormat สำหรับโหนดรูปทรง SmartArt
- เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
using (Presentation presentation = new Presentation())
{
    // เข้าถึงสไลด์
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปทรง SmartArt และโหนด
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // ตั้งค่าสีการเติมของโหนด
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // บันทึกงานนำเสนอ
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **สร้างภาพขนาดย่อของโหนดย่อย SmartArt**
นักพัฒนาสามารถสร้างภาพขนาดย่อของโหนดย่อยของ SmartArt ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation` ที่แสดงไฟล์ PPTX
2. เพิ่ม SmartArt
3. รับอ้างอิงของโหนดโดยใช้ Index ของมัน
4. รับภาพขนาดย่อ
5. บันทึกภาพขนาดย่อในรูปแบบภาพใด ๆ ที่ต้องการ

ตัวอย่างด้านล่างสร้างภาพขนาดย่อของโหนดย่อย SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **คำถามที่พบบ่อย**

**รองรับการทำแอนิเมชั่นของ SmartArt หรือไม่?**

ใช่. SmartArt ถูกจัดการเป็นรูปทรงปกติ ดังนั้นคุณสามารถ[ใช้แอนิเมชั่นมาตรฐาน](/slides/th/net/shape-animation/) (เข้ามา, ออกจาก, เน้น, เส้นทางการเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำแอนิเมชั่นให้รูปทรงภายในโหนด SmartArt เมื่อจำเป็น

**หากไม่ทราบ ID ภายใน ฉันจะหาตำแหน่ง SmartArt ที่เฉพาะเจาะจงบนสไลด์ได้อย่างไร?**

กำหนดและค้นหาโดยใช้[ข้อความแทน (alternative text)](https://reference.aspose.com/slides/th/net/aspose.slides/shape/alternativetext/). การตั้งค่า AltText ที่เป็นเอกลักษณ์บน SmartArt ทำให้คุณค้นหาได้โดยโปรแกรมโดยไม่ต้องอิงกับตัวระบุภายใน

**รูปลักษณ์ของ SmartArt จะถูกคงไว้เมื่อแปลงงานนำเสนอเป็น PDF หรือไม่?**

ใช่. Aspose.Slides เรนเดอร์ SmartArt ด้วยความละเอียดภาพสูงในระหว่าง[การส่งออกเป็น PDF](/slides/th/net/convert-powerpoint-to-pdf/) โดยคงรักษาเค้าโครง, สี, และเอฟเฟกต์

**ฉันสามารถดึงภาพของ SmartArt ทั้งหมด (สำหรับพรีวิวหรือรายงาน) ได้หรือไม่?**

ใช่. คุณสามารถเรนเดอร์รูปทรง SmartArt ไปเป็น[รูปแบบราสเตอร์](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getimage/) หรือเป็น[SVG](https://reference.aspose.com/slides/th/net/aspose.slides/shape/writeassvg/) สำหรับผลลัพธ์เวกเตอร์ที่ปรับขนาดได้ ทำให้เหมาะสำหรับภาพขนาดย่อ, รายงาน, หรือการใช้งานบนเว็บ