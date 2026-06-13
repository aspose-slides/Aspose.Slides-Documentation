---
title: เพิ่มประสิทธิภาพการจัดการภาพในงานนำเสนอด้วย .NET
linktitle: จัดการภาพ
type: docs
weight: 10
url: /th/net/image/
keywords:
- เพิ่มภาพ
- เพิ่มรูปภาพ
- เพิ่มบิตแมพ
- แทนที่ภาพ
- แทนที่รูปภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำให้การจัดการภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET มีประสิทธิภาพมากขึ้น ทั้งการเพิ่มประสิทธิภาพการทำงานและอัตโนมัติกระบวนการของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ลงในสไลด์ได้เช่นกัน อย่างเดียวกัน Aspose.Slides ก็อนุญาตให้คุณเพิ่มภาพลงในสไลด์ของการนำเสนอผ่านขั้นตอนต่าง ๆ

{{% alert  title="Tip" color="primary" %}} 
Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างการนำเสนออย่างรวดเร็วจากภาพ 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
หากคุณต้องการเพิ่มภาพเป็นออบเจกต์กรอบ—โดยเฉพาะหากคุณตั้งใจใช้ตัวเลือกการจัดรูปแบบมาตรฐานเพื่อปรับขนาด เพิ่มเอฟเฟกต์ ฯลฯ—ดูที่ [Picture Frame](https://docs.aspose.com/slides/th/net/picture-frame/) 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
คุณสามารถจัดการการดำเนินการอินพุต/เอาต์พุตที่เกี่ยวกับภาพและการนำเสนอ PowerPoint เพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/) 
{{% /alert %}}

Aspose.Slides รองรับการดำเนินการกับภาพในรูปแบบที่เป็นที่นิยมเหล่านี้: JPEG, PNG, BMP, GIF, และอื่น ๆ 

## **เพิ่มภาพที่จัดเก็บไว้ในเครื่องลงสไลด์**

คุณสามารถเพิ่มภาพหนึ่งหรือหลายภาพจากคอมพิวเตอร์ของคุณลงในสไลด์ของการนำเสนอ โค้ดตัวอย่างใน C# แสดงวิธีการเพิ่มภาพลงในสไลด์:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพจากเว็บลงสไลด์**

หากภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่มีในคอมพิวเตอร์ของคุณคุณสามารถเพิ่มภาพโดยตรงจากเว็บได้

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มภาพจากเว็บลงในสไลด์ด้วย C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพลงใน Slide Master**

Slide Master คือสไลด์ระดับบนสุดที่เก็บและควบคุมข้อมูล (ธีม, เค้าโครง ฯลฯ) ของสไลด์ทั้งหมดใต้มัน ดังนั้นเมื่อคุณเพิ่มภาพลงใน Slide Master ภาพนั้นจะปรากฏบนทุกสไลด์ที่ใช้ Slide Master นั้น

โค้ดตัวอย่าง C# นี้แสดงวิธีการเพิ่มภาพลงใน Slide Master:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มภาพเป็นพื้นหลังของสไลด์**

คุณอาจต้องการใช้รูปภาพเป็นพื้นหลังสำหรับสไลด์เดียวหรือหลายสไลด์ ในกรณีนั้นคุณต้องดู *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/th/net/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ลงในงานนำเสนอ**

คุณสามารถเพิ่มหรือแทรกรูปภาพใด ๆ ลงในงานนำเสนอโดยใช้เมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/methods/addpictureframe) ที่เป็นส่วนหนึ่งของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection)

เพื่อสร้างออบเจกต์ภาพจาก SVG ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างออบเจกต์ SvgImage เพื่อนำเข้าไปยัง ImageShapeCollection  
2. สร้างออบเจกต์ PPImage จาก ISvgImage  
3. สร้างออบเจกต์ PictureFrame ด้วยการใช้ IPPImage interface  

โค้ดตัวอย่างนี้แสดงวิธีการดำเนินการตามขั้นตอนข้างต้นเพื่อเพิ่มภาพ SVG ลงในงานนำเสนอ:
``` csharp 
// เส้นทางไปยังไดเรกทอรีเอกสาร
string dataDir = @"D:\Documents\";

// ชื่อไฟล์ SVG ต้นฉบับ
string svgFileName = dataDir + "sample.svg";

// ชื่อไฟล์งานนำเสนอผลลัพธ์
string outPptxPath = dataDir + "presentation.pptx";

// สร้างงานนำเสนอใหม่
using (var p = new Presentation())
{
    // อ่านเนื้อหาไฟล์ SVG
    string svgContent = File.ReadAllText(svgFileName);

    // สร้างอ็อบเจกต์ SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // สร้างอ็อบเจกต์ PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // สร้าง PictureFrame ใหม่
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // บันทึกงานนำเสนอในรูปแบบ PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **แปลง SVG เป็นชุดของรูปทรง**

การแปลง SVG เป็นชุดของรูปทรงของ Aspose.Slides มีลักษณะคล้ายกับฟังก์ชันของ PowerPoint ที่ใช้ทำงานกับภาพ SVG:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้บริการโดยหนึ่งใน overload ของเมธอด [AddGroupShape](https://reference.aspose.com/slides/th/net/aspose.slides.ishapecollection/addgroupshape/methods/1) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection) ที่รับออบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/net/aspose.slides/isvgimage) เป็นอาร์กิวเมนต์แรก

โค้ดตัวอย่างนี้แสดงวิธีใช้เมธอดที่อธิบายเพื่อแปลงไฟล์ SVG เป็นชุดของรูปทรง:

``` csharp 
// เส้นทางไปยังไดเรกทอรีเอกสาร
string dataDir = @"D:\Documents\";

// ชื่อไฟล์ SVG ต้นฉบับ
string svgFileName = dataDir + "sample.svg";

// ชื่อไฟล์งานนำเสนอผลลัพธ์
string outPptxPath = dataDir + "presentation.pptx";

// สร้างงานนำเสนอใหม่
using (IPresentation presentation = new Presentation())
{
    // อ่านเนื้อหาไฟล์ SVG
    string svgContent = File.ReadAllText(svgFileName);

    // สร้างอ็อบเจกต์ SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์
    SizeF slideSize = presentation.SlideSize.Size;

    // แปลงภาพ SVG เป็นกลุ่มรูปทรงและปรับขนาดให้พอดีกับสไลด์
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // บันทึกงานนำเสนอในรูปแบบ PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **เพิ่มภาพเป็น EMF ลงสไลด์**

Aspose.Slides for .NET อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel และเพิ่มภาพเหล่านั้นเป็น EMF ลงในสไลด์โดยใช้ Aspose.Cells  

โค้ดตัวอย่างนี้แสดงวิธีทำตามขั้นตอนที่อธิบายไว้:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //บันทึกเวิร์กบุ๊กไปยังสตรีม
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **แทนที่ภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่ภาพที่จัดเก็บใน Image Collection ของงานนำเสนอ (รวมถึงภาพที่ใช้โดยรูปทรงสไลด์) ส่วนนี้แสดงวิธีการอัปเดตภาพในคอลเลกชันหลายวิธี API มีเมธอดที่ใช้งานง่ายเพื่อแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์งานนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. โหลดภาพใหม่จากไฟล์เข้าสู่ byte array  
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้ byte array  
4. แนวทางที่สอง โหลดภาพเข้าสู่อ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/net/aspose.slides/iimage/) แล้วแทนที่ภาพเป้าหมายด้วยอ็อบเจกต์นั้น  
5. แนวทางที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วใน Image Collection ของงานนำเสนอ  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
using Presentation presentation = new Presentation("sample.pptx");

// วิธีแรก.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// วิธีที่สอง.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// วิธีที่สาม.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// บันทึกการนำเสนอลงไฟล์.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
โดยใช้ตัวแปลงฟรีของ Aspose [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวสร้าง GIF จากข้อความ ฯลฯ ได้อย่างง่ายดาย 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของภาพต้นฉบับจะคงเดิมหลังจากแทรกหรือไม่?**  
ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่การแสดงผลสุดท้ายขึ้นอยู่กับว่าภาพ [picture](/slides/th/net/picture-frame/) ถูกสเกลบนสไลด์อย่างไรและการบีบอัดใด ๆ ที่ใช้เมื่อบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโกเดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**  
วางโลโกบน master slide หรือ layout แล้วแทนที่ใน Image Collection ของงานนำเสนอ—การเปลี่ยนแปลงจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**SVG ที่แทรกเข้ามาสามารถแปลงเป็นรูปทรงที่แก้ไขได้หรือไม่?**  
ได้ คุณสามารถแปลง SVG เป็นกลุ่มรูปทรงได้ หลังจากนั้นแต่ละส่วนจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปทรง

**จะตั้งค่าภาพเป็นพื้นหลังของหลายสไลด์พร้อมกันอย่างไร?**  
[Assign the image as the background](/slides/th/net/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้ master/layout นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ

**ทำอย่างไรเพื่อป้องกันไม่ให้ไฟล์งานนำเสนอขยายขนาดมากเกินไปจากภาพจำนวนมาก?**  
ใช้ภาพเดียวซ้ำแทนการทำสำเนา, เลือกความละเอียดที่เหมาะสม, บีบอัดเมื่อบันทึก, และเก็บกราฟิกที่ซ้ำกันไว้บน master slide เมื่อเป็นไปได้