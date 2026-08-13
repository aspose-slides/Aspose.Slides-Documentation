---
title: จัดการ OLE Objects ในการนำเสนอด้วย .NET
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/net/manage-ole/
keywords:
- อ็อบเจ็กต์ OLE
- การเชื่อมโยงและฝังอ็อบเจ็กต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มอ็อบเจ็กต์
- ฝังอ็อบเจ็กต์
- เพิ่มไฟล์
- ฝังไฟล์
- อ็อบเจ็กต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- สกัด OLE
- สกัดอ็อบเจ็กต์
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการอ็อบเจ็กต์ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides สำหรับ .NET. ฝัง, อัปเดตและส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่ทำให้ข้อมูลและอ็อบเจ็กต์ที่สร้างในแอปพลิเคชันหนึ่งสามารถถูกวางในแอปพลิเคชันอื่นได้ผ่านการเชื่อมต่อหรือการฝังตัว  

ลองพิจารณากราฟที่สร้างใน MS Excel แล้วนำกราฟนั้นวางลงในสไลด์ PowerPoint กราฟ Excel นี้ถือเป็นอ็อบเจ็กต์ OLE  

- อ็อบเจ็กต์ OLE อาจแสดงเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอนกราฟจะเปิดในแอปพลิเคชันที่เชื่อมโยง (Excel) หรือระบบจะถามให้คุณเลือกแอปพลิเคชันสำหรับการเปิดหรือแก้ไขอ็อบเจ็กต์  
- อ็อบเจ็กต์ OLE อาจแสดงเนื้อหาจริง เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะถูกเปิดใช้งานใน PowerPoint ส่วนติดต่อกราฟจะโหลดและคุณสามารถแก้ไขข้อมูลของกราฟภายใน PowerPoint  

[Aspose.Slides for .NET](https://products.aspose.com/slides/th/net/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe)).
{{% /alert %}} 

## **เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังลงในสไลด์เป็นกรอบอ็อบเจ็กต์ OLE ด้วย Aspose.Slides for .NET คุณสามารถทำได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. อ่านไฟล์ Excel เป็นอาเรย์ของไบต์  
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ลงในสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่น ๆ ของอ็อบเจ็กต์ OLE  
5. บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ลงในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ด้วย Aspose.Slides for .NET  
**หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/net/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายของอ็อบเจ็กต์ที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดอ็อบเจ็กต์ OLE นี้

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // เตรียมข้อมูลสำหรับอ็อบเจ็กต์ OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // เพิ่มกรอบอ็อบเจ็กต์ OLE ลงในสไลด์.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **เพิ่มกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides for .NET ช่วยให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) โดยไม่ฝังข้อมูล แต่เพียงลิงก์ไปยังไฟล์เท่านั้น  

โค้ด C# ด้านล่างแสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) พร้อมไฟล์ Excel ที่เชื่อมโยงลงในสไลด์:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มกรอบอ็อบเจ็กต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **เข้าถึงกรอบอ็อบเจ็กต์ OLE**

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหา หรือเข้าถึงได้ง่ายโดยทำตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้าที่มีรูปร่างหนึ่งอันบนสไลด์แรก จากนั้น *cast* อ็อบเจ็กต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe) นี่คือกรอบอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE แล้ว คุณสามารถทำงานใด ๆ กับมันได้  

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์กราฟ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับรูปร่างแรกเป็นกรอบอ็อบเจ็กต์ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // รับข้อมูลไฟล์ที่ฝังไว้.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // รับส่วนขยายของไฟล์ที่ฝังไว้.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **เข้าถึงคุณสมบัติกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides สามารถให้คุณเข้าถึงคุณสมบัติกรอบอ็อบเจ็กต์ OLE ที่เชื่อมโยงได้  

โค้ด C# ด้านล่างแสดงวิธีตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่ และรับเส้นทางไปยังไฟล์ที่เชื่อมโยง:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // รับรูปร่างแรกเป็นกรอบอ็อบเจ็กต์ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // ตรวจสอบว่าอ็อบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // พิมพ์เส้นทางเต็มของไฟล์ที่เชื่อมโยง.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // พิมพ์เส้นทางสัมพันธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะงานนำเสนอ PPT เท่านั้นที่สามารถมีเส้นทางสัมพันธ์ได้.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE**

{{% alert color="info" %}} 
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for .NET](/cells/net/).
{{% /alert %}}

หากอ็อบเจ็กต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของอ็อบเจ็กต์นั้นได้ง่ายโดยทำตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอที่มีอ็อบเจ็กต์ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงรูปร่าง [OLEObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe) ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้าซึ่งมีรูปร่างหนึ่งอันบนสไลด์แรก จากนั้น *cast* อ็อบเจ็กต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe) นี่คือกรอบอ็อบเจ็กต์ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบอ็อบเจ็กต์ OLE แล้ว คุณสามารถทำการใด ๆ กับมันได้  
5. สร้างอ็อบเจ็กต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตไว้ในสตรีม  
8. เปลี่ยนข้อมูลอ็อบเจ็กต์ OLE จากสตรีม  

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบอ็อบเจ็กต์ OLE (อ็อบเจ็กต์กราฟ Excel ที่ฝังในสไลด์) และปรับข้อมูลไฟล์เพื่ออัปเดตข้อมูลของกราฟ

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับรูปร่างแรกเป็นกรอบอ็อบเจ็กต์ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // อ่านข้อมูลอ็อบเจ็กต์ OLE เป็นอ็อบเจ็กต์ Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // ปรับแก้ข้อมูล workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // เปลี่ยนข้อมูลอ็อบเจ็กต์ของกรอบ OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ฝังประเภทไฟล์อื่นในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides for .NET ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นอ็อบเจ็กต์ เมื่อผู้ใช้ดับเบิลคลิกอ็อบเจ็กต์ที่แทรกไว้ ระบบจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือจะมีการแจ้งให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์  

โค้ด C# ด้านล่างแสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **กำหนดประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังไว้**

เมื่อทำงานกับการนำเสนอ คุณอาจต้องการแทนที่อ็อบเจ็กต์ OLE เก่าด้วยอ็อบเจ็กต์ใหม่ หรือแทนที่อ็อบเจ็กต์ OLE ที่ไม่รองรับด้วยอ็อบเจ็กต์ที่รองรับ Aspose.Slides for .NET ให้คุณกำหนดประเภทไฟล์สำหรับอ็อบเจ็กต์ที่ฝังไว้ ทำให้คุณสามารถอัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของมันได้  

โค้ด C# ด้านล่างแสดงวิธีการกำหนดประเภทไฟล์สำหรับอ็อบเจ็กต์ OLE ที่ฝังไว้เป็น `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **กำหนดภาพไอคอนและชื่อสำหรับอ็อบเจ็กต์ที่ฝังไว้**

หลังจากฝังอ็อบเจ็กต์ OLE จะมีการเพิ่มตัวอย่าง (preview) ที่ประกอบด้วยภาพไอคอนโดยอัตโนมัติ ตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนจะเข้าถึงหรือเปิดอ็อบเจ็กต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นส่วนประกอบของตัวอย่าง คุณสามารถกำหนดภาพไอคอนและชื่อโดยใช้ Aspose.Slides for .NET  

โค้ด C# ด้านล่างแสดงวิธีกำหนดภาพไอคอนและชื่อสำหรับอ็อบเจ็กต์ที่ฝังไว้: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // เพิ่มภาพไปยังทรัพยากรของการนำเสนอ.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // ตั้งชื่อและภาพสำหรับตัวอย่าง OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ป้องกันไม่ให้กรอบอ็อบเจ็กต์ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากที่คุณเพิ่มอ็อบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์การนำเสนอ เมื่อเปิดการนำเสนอใน PowerPoint คุณอาจเห็นข้อความให้คุณอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE เปลี่ยนไป เนื่องจาก PowerPoint จะอัปเดตข้อมูลจากอ็อบเจ็กต์ OLE ที่เชื่อมโยงและรีเฟรชตัวอย่างอ็อบเจ็กต์ เพื่อป้องกันไม่ให้ PowerPoint แจ้งเตือนให้อัปเดตข้อมูลของอ็อบเจ็กต์ ให้ตั้งค่าคุณสมบัติ `UpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ioleobjectframe/) เป็น `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // คงขนาดและตำแหน่งของกรอบอ็อบเจ็กต์ OLE ไว้เมื่อ PowerPoint อัปเดตลิงก์.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ดึงไฟล์ที่ฝังไว้**

Aspose.Slides for .NET ให้คุณดึงไฟล์ที่ฝังอยู่ในสไลด์เป็นอ็อบเจ็กต์ OLE ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) ที่มีอ็อบเจ็กต์ OLE ที่คุณต้องการดึงออก  
2. วนลูปผ่านรูปร่างทั้งหมดในการนำเสนอและเข้าถึงรูปร่าง [OLEObjectFrame](https://reference.aspose.com/slides/th/net/aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบอ็อบเจ็กต์ OLE แล้วเขียนลงดิสก์  

โค้ด C# ด้านล่างแสดงวิธีดึงไฟล์ที่ฝังในสไลด์เป็นอ็อบเจ็กต์ OLE:

```c#
using Aspose.Slides;

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

### เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?

สิ่งที่ปรากฏบนสไลด์เท่านั้นที่ถูกเรนเดอร์ — ไอคอน/รูปภาพแทน (preview) เนื้อหา OLE แบบ “live” จะไม่ถูกประมวลผลขณะเรนเดอร์ หากต้องการ สามารถตั้งค่าภาพ preview ของคุณเองเพื่อให้ได้ลักษณะที่ต้องการใน PDF ที่ส่งออก  

### ฉันจะล็อกอ็อบเจ็กต์ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?

ล็อกรูปร่าง: Aspose.Slides มี [shape-level locks](/slides/th/net/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจได้อย่างมีประสิทธิภาพ  

### ทำไมอ็อบเจ็กต์ Excel ที่เชื่อมโยงจึง “กระโดด” หรือเปลี่ยนขนาดเมื่อฉันเปิดการนำเสนอ?

PowerPoint อาจรีเฟรช preview ของ OLE ที่เชื่อมโยง สำหรับการแสดงผลที่คงที่ ให้ทำตามแนวทางจาก [Working Solution for Worksheet Resizing](/slides/th/net/working-solution-for-worksheet-resizing/) — กำหนดกรอบให้พอดีกับช่วงข้อมูล หรือปรับขนาดช่วงให้เข้ากับกรอบคงที่และตั้งค่าภาพแทนที่เหมาะสม  

### เส้นทางแบบ relative สำหรับอ็อบเจ็กต์ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?

ใน PPTX ไม่มีข้อมูล “relative path” — มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทางแบบ relative พบได้ในรูปแบบ PPT เก่า สำหรับการพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์