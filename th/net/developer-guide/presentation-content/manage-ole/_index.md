---
title: จัดการวัตถุ OLE ในการนำเสนอด้วย .NET
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/net/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและฝังวัตถุ
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มวัตถุ
- ฝังวัตถุ
- เพิ่มไฟล์
- ฝังไฟล์
- วัตถุที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- หัวเรื่อง OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides for .NET ฝัง, ปรับปรุงและส่งออกเนื้อหา OLE อย่างราบรื่น"
---
## **บทนำ**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง
{{% /alert %}}

พิจารณาชาร์ตที่สร้างใน MS Excel ชาร์ตนั้นจะถูกวางไว้ในสไลด์ PowerPoint ชาร์ต Excel นี้ถือเป็นวัตถุ OLE

- วัตถุ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอน ชาร์ตจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือคุณจะถูกถามให้เลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขวัตถุ
- วัตถุ OLE อาจแสดงเนื้อหาจริง เช่นเนื้อหาของชาร์ต ในกรณีนี้ชาร์ตจะทำงานใน PowerPoint อินเทอร์เฟซของชาร์ตโหลดขึ้นและคุณสามารถแก้ไขข้อมูลของชาร์ตได้ภายใน PowerPoint

[Aspose.Slides for .NET](https://products.aspose.com/slides/th/net/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe))

## **เพิ่มกรอบวัตถุ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างชาร์ตใน Microsoft Excel แล้วต้องการฝังมันในสไลด์เป็นกรอบวัตถุ OLE ด้วย Aspose.Slides for .NET คุณทำได้ดังนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน
3. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ลงในสไลด์พร้อมอาร์เรย์ไบต์และข้อมูลอื่นเกี่ยวกับวัตถุ OLE
5. เขียนพรีเซนเทชั่นที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มชาร์ตจากไฟล์ Excel ลงในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ด้วย Aspose.Slides for .NET  
**หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/net/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายของวัตถุที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ช่วยให้ PowerPoint ตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // เตรียมข้อมูลสำหรับวัตถุ OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // เพิ่มกรอบวัตถุ OLE ไปยังสไลด์.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **เพิ่มกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides for .NET อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) โดยไม่ฝังข้อมูล แต่เชื่อมโยงไปยังไฟล์เท่านั้น

โค้ด C# นี้แสดงวิธีเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ที่เชื่อมโยงกับไฟล์ Excel ไปยังสไลด์:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **เข้าถึงกรอบวัตถุ OLE**

หากวัตถุ OLE ได้ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้ดังนี้

1. โหลดพรีเซนเทชั่นที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึงรูปทร Shape [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ในตัวอย่างของเรามี PPTX ที่มี Shape หนึ่งเดียวบนสไลด์แรก เราจึง *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe) ซึ่งเป็นกรอบ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบวัตถุ OLE (ออบเจ็กต์ชาร์ต Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับรูปทรแรกเป็นกรอบวัตถุ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // ดึงข้อมูลไฟล์ที่ฝังอยู่.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // ดึงส่วนขยายของไฟล์ที่ฝังอยู่.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **เข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยง

โค้ด C# นี้แสดงวิธีตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่และจากนั้นรับพาธไฟล์ที่เชื่อมโยง:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // รับรูปทรแรกเป็นกรอบวัตถุ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // ตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // พิมพ์พาธเต็มของไฟล์ที่เชื่อมโยง.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // พิมพ์พาธแบบ relative ของไฟล์ที่เชื่อมโยงหากมี.
        // พรีเซนเทชัน PPT เท่านั้นที่สามารถบรรจุพาธแบบ relative ได้.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **เปลี่ยนแปลงข้อมูลวัตถุ OLE**

{{% alert color="primary" %}} 
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for .NET](/cells/net/) 
{{% /alert %}}

หากวัตถุ OLE ได้ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของมันได้ดังนี้

1. โหลดพรีเซนเทชั่นที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เข้าถึงรูปทร Shape [OLEObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ในตัวอย่างของเรามี PPTX ที่มี Shape หนึ่งบนสไลด์แรก เราจึง *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe) ซึ่งเป็นกรอบ OLE ที่ต้องการเข้าถึง
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้
5. สร้างอ็อบเจ็กต์ `Workbook` และเข้าถึงข้อมูล OLE
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม
8. เปลี่ยนแปลงข้อมูลวัตถุ OLE จากสตรีม

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบวัตถุ OLE (ออบเจ็กต์ชาร์ต Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลของชาร์ต

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับรูปทรแรกเป็นกรอบวัตถุ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // อ่านข้อมูลวัตถุ OLE เป็นอ็อบเจ็กต์ Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // แก้ไขข้อมูลของ workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // เปลี่ยนข้อมูลวัตถุของกรอบ OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ฝังไฟล์ชนิดอื่นในสไลด์**

นอกจากชาร์ต Excel แล้ว Aspose.Slides for .NET ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นออบเจ็กต์ เมื่อผู้ใช้ดับเบิลคลิกออบเจ็กต์ที่แทรกไว้ ระบบจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะถูกถามให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น

โค้ด C# นี้แสดงวิธีฝัง HTML และ ZIP ลงในสไลด์:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **กำหนดประเภทไฟล์สำหรับออบเจ็กต์ที่ฝัง**

เมื่อต้องทำงานกับพรีเซนเทชั่น คุณอาจจำเป็นต้องแทนที่วัตถุ OLE เก่าด้วยออบเจ็กต์ใหม่หรือแทนที่ OLE ที่ไม่รองรับด้วย OLE ที่รองรับ Aspose.Slides for .NET อนุญาตให้คุณกำหนดประเภทไฟล์สำหรับออบเจ็กต์ที่ฝังได้ ช่วยให้คุณอัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของมันได้

โค้ด C# นี้แสดงวิธีตั้งค่าประเภทไฟล์สำหรับออบเจ็กต์ OLE ที่ฝังเป็น `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // เปลี่ยนประเภทไฟล์เป็น ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **กำหนดรูปไอคอนและหัวเรื่องสำหรับออบเจ็กต์ที่ฝัง**

หลังจากฝังออบเจ็กต์ OLE แล้ว จะมีการเพิ่มพรีวิวแบบไอคอนโดยอัตโนมัติ พรีวิวนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดออบเจ็กต์ OLE หากคุณต้องการใช้รูปภาพและข้อความเฉพาะเป็นองค์ประกอบในพรีวิว คุณสามารถตั้งค่ารูปไอคอนและหัวเรื่องได้ด้วย Aspose.Slides for .NET

โค้ด C# นี้แสดงวิธีตั้งค่ารูปไอคอนและหัวเรื่องสำหรับออบเจ็กต์ที่ฝัง:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // เพิ่มรูปภาพไปยังทรัพยากรของพรีเซนเทชั่น.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // ตั้งชื่อเรื่องและรูปภาพสำหรับพรีวิว OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและเปลี่ยนตำแหน่ง**

หลังจากคุณเพิ่มออบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์ของพรีเซนเทชั่น เมื่อเปิดพรีเซนเทชั่นใน PowerPoint คุณอาจเห็นข้อความขออัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของกรอบวัตถุ OLE เปลี่ยนแปลงไป เนื่องจาก PowerPoint อัปเดตข้อมูลจากออบเจ็กต์ OLE ที่เชื่อมโยงและรีเฟรชพรีวิวของออบเจ็กต์ เพื่อลดการแจ้งเตือนให้ PowerPoint ไม่ขออัปเดตข้อมูลของออบเจ็กต์ ให้ตั้งค่าคุณสมบัติ `UpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) เป็น `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **ดึงไฟล์ที่ฝังอยู่**

Aspose.Slides for .NET อนุญาตให้คุณดึงไฟล์ที่ฝังอยู่ในสไลด์เป็นออบเจ็กต์ OLE ดังนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีออบเจ็กต์ OLE ที่ต้องการดึง
2. วนลูปผ่าน Shape ทั้งหมดในพรีเซนเทชั่นและเข้าถึง Shape ประเภท [OLEObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบ OLE Object และเขียนลงดิสก์

โค้ด C# นี้แสดงวิธีดึงไฟล์ที่ฝังอยู่ในสไลด์เป็นออบเจ็กต์ OLE:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**  
สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์คือไอคอน/ภาพแทน (พรีวิว) เนื้อหา OLE แบบ “สด” จะไม่ทำงานระหว่างการเรนเดอร์ หากต้องการให้แสดงผลตามที่คาดไว้ใน PDF ให้ตั้งค่าภาพพรีวิวของคุณเอง

**จะล็อกออบเจ็กต์ OLE บนสไลด์ให้ผู้ใช้ไม่สามารถย้ายหรือแก้ไขใน PowerPoint ได้อย่างไร?**  
ล็อก Shape: Aspose.Slides มี [shape‑level locks](/slides/th/net/applying-protection-to-presentation/) ซึ่งไม่ได้เป็นการเข้ารหัส แต่ช่วยป้องกันการแก้ไขและการย้ายโดยไม่ได้ตั้งใจ

**ทำไมออบเจ็กต์ Excel ที่เชื่อมโยง “กระเด้ง” หรือเปลี่ยนขนาดเมื่อเปิดพรีเซนเทชั่น?**  
PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้แสดงผลคงที่ ควรปฏิบัติตามแนวทาง [Working Solution for Worksheet Resizing](/slides/th/net/working-solution-for-worksheet-resizing/) เช่น ปรับกรอบให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้พอดีกับกรอบคงที่และตั้งค่าภาพแทนที่เหมาะสม

**พาธแบบ relative สำหรับออบเจ็กต์ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**  
ใน PPTX ไม่มีข้อมูล “พาธแบบ relative” มีเฉพาะพาธเต็มเท่านั้น พาธแบบ relative มีอยู่ในรูปแบบ PPT เก่า สำหรับความพกพา แนะนำให้ใช้พาธเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือฝังไฟล์ไว้ในพรีเซนเทชั่น