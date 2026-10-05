---
title: จัดการวัตถุ OLE ในงานนำเสนอด้วย .NET
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
- ชื่อ OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่งการจัดการวัตถุ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ฝัง แก้ไข และส่งออกเนื้อหา OLE อย่างไร้รอยต่อ"
---
## **บทนำ**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง  

{{% /alert %}} 

พิจารณาชาร์ตที่สร้างใน MS Excel แล้ววางลงในสไลด์ PowerPoint ชาร์ต Excel นี้ถือเป็นวัตถุ OLE  

- วัตถุ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณคลิกสองครั้งที่ไอคอน ชาร์ตจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือระบบจะให้คุณเลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขวัตถุ  
- วัตถุ OLE อาจแสดงเนื้อหาแท้จริง เช่น เนื้อหาของชาร์ต ในกรณีนี้ชาร์ตจะถูกเปิดใช้งานใน PowerPoint อินเทอร์เฟซของชาร์ตจะโหลดขึ้นและคุณสามารถแก้ไขข้อมูลของชาร์ตภายใน PowerPoint ได้  

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) อนุญาตให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe))

## **เพิ่มกรอบวัตถุ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างชาร์ตใน Microsoft Excel แล้วต้องการฝังลงในสไลด์เป็นกรอบวัตถุ OLE ด้วย Aspose.Slides for .NET คุณสามารถทำได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์  
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ลงในสไลด์พร้อมอาร์เรย์ไบต์และข้อมูลอื่น ๆ ของวัตถุ OLE  
5. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มชาร์ตจากไฟล์ Excel ลงในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ด้วย Aspose.Slides for .NET  
**Note** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายของวัตถุที่ฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ช่วยให้ PowerPoint แปลความหมายประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // เตรียมข้อมูลสำหรับวัตถุ OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // เพิ่มกรอบวัตถุ OLE ลงในสไลด์.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **เพิ่มกรอบวัตถุ OLE แบบเชื่อมโยง**

Aspose.Slides for .NET อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) โดยไม่ฝังข้อมูล เพียงเชื่อมโยงไปยังไฟล์เท่านั้น  

โค้ด C# ด้านล่างนี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:  

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **เข้าถึงกรอบวัตถุ OLE**

หากวัตถุ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหาหรือเข้าถึงได้ตามนี้:

1. โหลดงานนำเสนอที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)  
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีรูปร่างเดียวบนสไลด์แรก แล้วเราก็ *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) ซึ่งเป็นกรอบวัตถุ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้  

ในตัวอย่างด้านล่าง แสดงการเข้าถึงกรอบวัตถุ OLE (วัตถุชาร์ต Excel ที่ฝังในสไลด์) พร้อมข้อมูลไฟล์ของมัน  

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // ดึงรูปร่างแรกเป็นกรอบวัตถุ OLE.
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

โค้ด C# ด้านล่างนี้แสดงวิธีตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่ และรับเส้นทางไปยังไฟล์ที่เชื่อมโยง:  

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Get the first shape as an OLE object frame.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Check if the OLE object is linked.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Print the full path to the linked file.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Print the relative path to the linked file if present.
        // Only the PPT presentations can contain the relative path.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **เปลี่ยนแปลงข้อมูลวัตถุ OLE**

{{% alert color="info" title="Note" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/)  

{{% /alert %}}

หากวัตถุ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของวัตถุนั้นได้ตามนี้:

1. โหลดงานนำเสนอที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงรูปร่าง [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)  
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่มีรูปร่างเดียวบนสไลด์แรก จากนั้น *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) เพื่อให้ได้กรอบวัตถุ OLE ที่ต้องการ  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้  
5. สร้างออบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม  
8. แทนที่ข้อมูลวัตถุ OLE ด้วยสตรีมที่แก้ไขแล้ว  

ในตัวอย่างด้านล่าง แสดงการเข้าถึงกรอบวัตถุ OLE (วัตถุชาร์ต Excel ที่ฝังในสไลด์) และปรับเปลี่ยนข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลชาร์ต  

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // ดึงรูปร่างแรกเป็นกรอบวัตถุ OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // อ่านข้อมูลวัตถุ OLE เป็นออบเจ็กต์ Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // แก้ไขข้อมูล workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // เปลี่ยนข้อมูลวัตถุกรอบ OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ฝังไฟล์ประเภทอื่นลงในสไลด์**

นอกจากชาร์ต Excel แล้ว Aspose.Slides for .NET ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ เช่น HTML, PDF และ ZIP เมื่อผู้ใช้คลิกสองครั้งที่วัตถุที่แทรกไว้ ระบบจะเปิดไฟล์นั้นโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือแจ้งให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์  

โค้ด C# ด้านล่างนี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:  

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

## **ตั้งค่าประเภทไฟล์สำหรับวัตถุที่ฝัง**

เมื่อทำงานกับงานนำเสนอ คุณอาจต้องการแทนที่วัตถุ OLE เก่าด้วยวัตถุใหม่ หรือแทนที่วัตถุ OLE ที่ไม่รองรับด้วยวัตถุที่รองรับ Aspose.Slides for .NET อนุญาตให้คุณตั้งค่าประเภทไฟล์สำหรับวัตถุที่ฝัง เพื่ออัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของไฟล์  

โค้ด C# ด้านล่างนี้แสดงวิธีตั้งค่าประเภทไฟล์สำหรับวัตถุ OLE ที่ฝังเป็น `zip`:  

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

## **ตั้งค่าภาพไอคอนและชื่อเรื่องสำหรับวัตถุที่ฝัง**

หลังจากฝังวัตถุ OLE ระบบจะเพิ่มตัวอย่างพรีวิวที่มีภาพไอคอนโดยอัตโนมัติ ตัวพรีวิวนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดวัตถุ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นส่วนประกอบของพรีวิว คุณสามารถตั้งค่าภาพไอคอนและชื่อเรื่องได้ด้วย Aspose.Slides for .NET  

โค้ด C# ด้านล่างนี้แสดงวิธีตั้งค่าภาพไอคอนและชื่อเรื่องสำหรับวัตถุที่ฝัง:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // เพิ่มภาพลงในทรัพยากรของงานนำเสนอ.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // ตั้งชื่อเรื่องและภาพสำหรับพรีวิว OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ป้องกันการปรับขนาดและตำแหน่งของกรอบวัตถุ OLE**

หลังจากคุณเพิ่มวัตถุ OLE ที่เชื่อมโยงลงในสไลด์เมื่อเปิดงานนำเสนอใน PowerPoint อาจมีข้อความแจ้งให้คุณอัปเดตลิงก์ หากคลิก “Update Links” ขนาดและตำแหน่งของกรอบวัตถุ OLE อาจเปลี่ยนไป เนื่องจาก PowerPoint อัปเดตข้อมูลจากวัตถุ OLE ที่เชื่อมโยงและรีเฟรชพรีวิว เพื่อป้องกันไม่ให้ PowerPoint ขออัปเดตข้อมูลของวัตถุ ให้ตั้งค่าคุณสมบัติ `UpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) เป็น `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // คงขนาดและตำแหน่งของกรอบวัตถุ OLE เมื่อ PowerPoint อัปเดตลิงก์.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **สกัดไฟล์ที่ฝังอยู่**

Aspose.Slides for .NET อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นวัตถุ OLE ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ที่มีวัตถุ OLE ที่ต้องการสกัด  
2. วนลูปผ่านรูปร่างทั้งหมดในงานนำเสนอและเข้าถึงรูปร่าง [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบวัตถุ OLE และบันทึกลงดิสก์  

โค้ด C# ด้านล่างนี้แสดงวิธีสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นวัตถุ OLE:  

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

## **คำถามที่พบบ่อย**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/ภาพหรือไม่?**

สิ่งที่มองเห็นบนสไลด์คือไอคอน/ภาพแทน (พรีวิว) เท่านั้น เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากต้องการให้แสดงผลตามที่คาดไว้ใน PDF ให้ตั้งค่าภาพพรีวิวของคุณเอง  

เพื่อให้ไฟล์ที่ฝังยังคงเป็นไฟล์แนบใน PDF ให้ตั้งค่า [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) เป็น `true` ตัวเลือกนี้ปิดโดยค่าเริ่มต้น ดูตัวอย่างและวิธีตรวจสอบไฟล์แนบได้ที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)

**ฉันจะล็อกวัตถุ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้ายหรือแก้ไขใน PowerPoint ได้อย่างไร?**

ล็อกรูปร่าง: Aspose.Slides มี [shape-level locks](/slides/th/net/applying-protection-to-presentation/) ซึ่งไม่ได้เป็นการเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือย้ายโดยไม่ได้ตั้งใจ

**ทำไมวัตถุ Excel ที่เชื่อมโยงถึง “กระเด้ง” หรือเปลี่ยนขนาดเมื่อเปิดงานนำเสนอ?**

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้แสดงผลคงที่ ควรทำตามแนวทางใน [Working Solution for Worksheet Resizing](/slides/th/net/working-solution-for-worksheet-resizing/) เช่น ปรับกรอบให้พอดีกับช่วงข้อมูล หรือปรับสเกลช่วงให้เข้ากับกรอบคงที่และตั้งค่าภาพแทนที่เหมาะสม

**เส้นทางสัมพันธ์สำหรับวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บรักษาในรูปแบบ PPTX หรือไม่?**

ใน PPTX ไม่มีข้อมูล “เส้นทางสัมพันธ์” — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพันธ์พบได้ในรูปแบบ PPT เก่า สำหรับความพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้หรือ URI ที่เข้าถึงได้ หรือฝังไฟล์ไว้โดยตรง  