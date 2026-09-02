---
title: รวมงานนำเสนออย่างมีประสิทธิภาพใน .NET
linktitle: รวมงานนำเสนอ
type: docs
weight: 40
url: /th/net/merge-presentation/
keywords:
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการรวมงานนำเสนอ PowerPoint และ OpenDocument ใน .NET ด้วยการโคลนสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, รักษาส่วน, และจัดการไฟล์ที่มีการป้องกันหรือไฟล์ขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for .NET รวมงานนำเสนอโดยการโคลนสไลด์จาก [งานนำเสนอ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) หนึ่งไปยังอีกงานนำเสนอหนึ่ง การดำเนินการหลักคือ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/), ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับ หรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลเอาต์ในงานนำเสนอปลายทางได้

บทความนี้ครอบคลุมเวิร์กโฟลว์การรวมที่พบบ่อยที่สุด:

- รวมสไลด์ทั้งหมดพร้อมคงรูปแบบต้นฉบับ;
- รวมสไลด์ที่เลือก;
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง;
- ใช้เลเอาต์เฉพาะจากงานนำเสนอปลายทาง;
- ทำให้ขนาดสไลด์ที่ต่างกันเป็นมาตรฐานก่อนการรวม;
- เพิ่มสไลด์ที่โคลนเข้าไปในส่วน;
- รวมงานนำเสนอหลายไฟล์ในเวิร์กโฟลว์ชนิดปลายทางถึงปลายทาง;
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อกังวลเรื่องการทำงานหลายเธรด

## **ผลของการโคลนสไลด์ต่อมาสเตอร์และเลเอาต์**

สไลด์สืบทอดลักษณะส่วนใหญ่จากเลเอาต์และมาสเตอร์ ดังนั้นการเลือก overload ของการโคลนจะกำหนดว่สไลด์ที่รวมจะถูกผสานเข้ากับงานนำเสนอปลายทางอย่างไร

ใช้ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) ในวิธีใดวิธีหนึ่งต่อไปนี้:

- `AddClone(sourceSlide)` — คงเลเอาต์และรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับจะถูกโคลนเข้าสู่งานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนโดยอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) ปลายทางเฉพาะ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นโดยประเภทหรือชื่อของเลเอาต์
- `AddClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/) ปลายทางเฉพาะ

มาสเตอร์หรือเลเอาต์ที่ส่งให้ overload `AddClone` ต้องเป็นของ **งานนำเสนอปลายทาง** ไม่ใช่งานนำเสนอแหล่ง

## **รวมงานนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

การรวมที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากงานนำเสนอแหล่งไปยังงานนำเสนอปลายทาง นี่เป็นตัวเลือกที่เหมาะเมื่อต้องการให้สไลด์ที่นำเข้ารักษาธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิมไว้

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

งานนำเสนอที่ได้อาจมีมาสเตอร์หลายตัวเมื่อแหล่งและปลายทางใช้ดีไซน์ต่างกัน ซึ่งเป็นพฤติกรรมที่คาดหวังเมื่อคงรูปแบบต้นฉบับไว้

## **รวมสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะตำแหน่งสไลด์ที่เลือกจากงานนำเสนอแหล่ง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

ตรวจสอบตำแหน่งสไลด์ก่อนทำการโคลนเมื่อค่ามาจากอินพุตของผู้ใช้หรือการกำหนดค่าภายนอก

## **รวมสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) เมื่อสไลด์ที่นำเข้าต้องปฏิบัติตามมาสเตอร์ที่อยู่ในงานนำเสนอปลายทางอยู่แล้ว

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลเอาต์ต้นฉบับ หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` จะโคลนเลเอาต์ต้นฉบับเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/) ขึ้น

ใช้ค่า `false` เมื่อคุณต้องการให้การรวมล้มเหลวแทนที่จะเพิ่มเลเอาต์ใหม่เข้าสู่มาสเตอร์ปลายทาง

## **รวมสไลด์โดยใช้เลเอาต์ปลายทางเฉพาะ**

ใช้ overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) เมื่อคุณทราบเลเอาต์ปลายทางที่สไลด์นำเข้าต้องใช้อย่างชัดเจน

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบทอด; มันไม่ได้ออกแบบเนื้อหาสไลด์ต้นฉบับใหม่ หากเลเอาต์ของแหล่งและปลายทางมีโครงสร้าง placeholder แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรม placeholder ที่สืบทอดนั้นเหมาะสม

## **รวมงานนำเสนอที่มีขนาดสไลด์ต่างกัน**

งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้ แต่การโคลนสไลด์เข้าสู่งานนำเสนอที่มีขนาดสไลด์อื่นจะไม่ออกแบบเนื้อหาใหม่อัตโนมัติให้พอกับผืนผ้าใบใหม่ รูปร่างอาจปรากฏเป็นการย้าย, ยืดหดที่ไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

วิธีการที่เป็นประโยชน์คือปรับขนาดงานนำเสนอแหล่งก่อนโคลน วิธี [SlideSize.SetSize](https://reference.aspose.com/slides/th/net/aspose.slides/slidesize/setsize/) สามารถปรับสเกลเนื้อหาที่มีอยู่ในขณะเปลี่ยนขนาดสไลด์ได้ และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/net/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ร้องขอ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอแหล่งในหน่วยความจำ หากคุณต้องการให้งานนำเสนอแหล่งต้นฉบับยังคงไม่เปลี่ยนสำหรับการดำเนินการอื่น ให้เปิดอินสแตนซ์แยกสำหรับการรวม

## **รวมสไลด์ไปยังส่วนของงานนำเสนอ**

ลูปการโคลนสไลด์พื้นฐานจะไม่สร้างลำดับชั้นของส่วนจากงานนำเสนอแหล่ง หากส่วนมีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในงานนำเสนอปลายทางและโคลนสไลด์เข้าไปในส่วนเหล่านั้นโดยใช้ [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

สไลด์ที่โคลนจะถูกต่อท้ายในส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนจากแหล่ง ให้วนลูป [Presentation.Sections](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sections/), ดึงสไลด์ปัจจุบันของแต่ละส่วนแหล่งด้วย [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/th/net/aspose.slides/isection/getslideslistofsection/), สร้างส่วนในปลายทางใหม่, แล้วโคลนสไลด์ที่คืนค่ามาเข้าไปในส่วนปลายทางที่สอดคล้องกัน ดูตัวอย่างการจัดการส่วนสไลด์เต็มรูปแบบได้ที่ [Manage Slide Sections](/slides/th/net/slide-section/) ซึ่งรวมถึงส่วนว่างและการเปลี่ยนแปลงโครงสร้าง

## **รวมหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างแบบปลายทางถึงปลายทางต่อไปนี้ใช้งานนำเสนอแรกเป็นปลายทาง, ทำให้ขนาดสไลด์ของแต่ละแหล่งเป็นมาตรฐาน, เปิดแต่ละแหล่งเฉพาะขณะทำการคัดลอก, และบันทึกไฟล์สุดท้ายเพียงครั้งเดียว

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

นี่เป็นพื้นฐานที่มีประโยชน์สำหรับการคงรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ต้องใช้งานธีมเดียวของปลายทาง ให้เปลี่ยนการเรียก `AddClone(slide)` ธรรมดาเป็น overload ของมาสเตอร์หรือเลเอาต์ปลายทางที่แสดงไว้ก่อนหน้า

## **ข้อพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเออต์, และความถูกต้องของการจัดรูปแบบ**

การโคลนสไลด์โดยค่าเริ่มต้นสามารถนำมาสเตอร์ของแหล่งที่จำเป็นเข้าสู่งานนำเสนอปลายทางได้โดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับมาสเตอร์ที่โคลนอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองไม่ได้รับการติดตามโดยทะเบียนนั้น ดังนั้นควรหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าสันนิษฐานว่ามาสเตอร์หรือเลเออต์สองตัวที่มีชื่อเดียวกันจะดูเหมือนกัน หากเทมเพลตองค์กรต้องการควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างเจาะจงและตรวจสอบผลลัพธ์หลังการรวม

### **โน้ตและความคิดเห็น**

โน้ตวิทยากรและความคิดเห็นของสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อลูกศรโคลนสไลด์ Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/net/presentation-notes/) และ [presentation comments](/slides/th/net/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบงานนำเสนอที่รวมแล้วเนื่องจากมาสเตอร์ของโน้ตเป็นออบเจ็กต์ระดับงานนำเสนอและอาจแตกต่างระหว่างไฟล์แหล่ง สำหรับเวิร์กโฟลว์การรีวิวให้ตรวจสอบผู้เขียนความคิดเห็นและการแสดงความคิดเห็นแบบโซ่หลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงทรัพยากรระดับงานนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์เองแทนการคัดลอกเฉพาะรูปร่างที่มองเห็น เพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์ต่อทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการต่างกัน ลิงก์เสียง, วิดีโอ, วัตถุ OLE, หรือไฮเปอร์ลิงก์ที่เชื่อมต่อจะยังคงพึ่งพาแหล่งภายนอก; การโคลนสไลด์ไม่ได้เปลี่ยนลิงก์ภายนอกเป็นเนื้อหาฝัง ให้ทดสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่งานนำเสนอที่รวมจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่โคลนโดยอัตโนมัติ แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากงานนำเสนอแหล่งที่ไม่ได้เชื่อมต่อกันจะถูกกำจัดซ้ำเสมอ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่รวมและวัดผลลัพธ์แทนการพึ่งพาการกำจัดซ้ำโดยไม่ชัดเจน

### **ฟอนต์ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์จัดการระดับงานนำเสนอ หากต้องการให้การพิมพ์รักษาความสม่ำเสมอระหว่างเครื่อง อย่าสันนิษฐานว่าการโคลนสไลด์เพียงอย่างเดียวทำให้ฟอนต์ที่ต้องการทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังไว้ด้วย [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) และจัดการการฝังอย่างเจาะจงตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/net/embedded-font/)

ตรวจสอบด้วยว่าคุณมีสิทธิ์ฝังฟอนต์ที่ใช้ในไฟล์แหล่ง ฟอนต์บางตัวอาจมีใบอนุญาตห้ามฝัง

### **งานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

แหล่งที่ป้องกันด้วยรหัสผ่านต้องเปิดสำเร็จก่อนที่จะโคลนสไลด์ได้ ให้ส่งรหัสผ่านผ่าน [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/)

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

การเปิดแหล่งที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับงานนำเสนอปลายทางโดยอัตโนมัติ ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วิดีโอ หรือวัตถุไบนารีขนาดอื่น ๆ สามารถใช้หน่วยความจำจำนวนมากได้ [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/blobmanagementoptions/) ให้ตัวเลือกสำหรับการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](/slides/th/net/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ขนาดใหญ่ ให้โหลดจากเส้นทางไฟล์เมื่อเป็นไปได้ ปิดการใช้งานงานนำเสนอแหล่งทันทีหลังการรวมเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์ชั่วคราวซ้ำ ๆ เว้นแต่ว่าเวิร์กโฟลว์ต้องการจุดตรวจ

### **ความปลอดภัยของเธรด**

ห้ามโหลด, แก้ไข, บันทึก, หรือโคลนอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้จำกัดอินสแตนซ์งานนำเสนอแต่ละอันให้ใช้กับการดำเนินการรวมหนึ่งครั้งเท่านั้น หากคุณทำงานแบบขนานให้ใช้อินสแตนซ์งานนำเสนอที่แยกจากกันและปฏิบัติตาม [Aspose.Slides multithreading guidance](/slides/th/net/multithreading/)

## **FAQ**

**ฉันจะรักษาการออกแบบต้นฉบับของแต่ละงานนำเสนอได้อย่างไร?**

ใช้ [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) โดยไม่ระบุมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ของแหล่งโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมของปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากงานนำเสนอปลายทาง ไม่ใช่จากแหล่ง Aspose.Slides จะพยายามแมปสไลด์แต่ละอันไปยังเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**เมื่อใดควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์เดียวที่รู้จัก ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอาต์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลเออต์ต้นฉบับ

**งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้หรือไม่?**

ได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติตามมิติปลายทาง ให้ปรับขนาดงานนำแหล่งก่อนเมื่อคุณต้องการตำแหน่งที่คาดเดาได้ เช่นใช้ [SlideSize.SetSize](https://reference.aspose.com/slides/th/net/aspose.slides/slidesize/setsize/) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/net/aspose.slides/slidesizescaletype/)


**ฉันสามารถรวมไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ เปิดงานนำเสนอแต่ละไฟล์, โคลนสไลด์ที่ต้องการเข้าไปในงานนำเสนอปลายทางหนึ่ง, แล้วบันทึกปลายทางในรูปแบบที่รองรับ เนื่องจากรูปแบบไฟล์งานนำเสนอไม่สนับสนุนชุดคุณสมบัติเช่นเดียวกันทั้งหมด ควรตรวจสอบเนื้อหาซับซ้อนหลังการรวมข้ามรูปแบบ ดู [Supported File Formats](/slides/th/net/supported-file-formats/)

**ส่วนของแหล่งจะถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่ได้จากลูปพื้นฐานที่โคลนสไลด์เท่านั้น ให้สร้างส่วนที่ต้องการในปลายทางและใช้ overload ของส่วนใน [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) เมื่อโครงสร้างส่วนต้องถูกคงไว้

**โน้ตวิทยากรและความคิดเห็นจะถูกคงไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่ขึ้นกับสไตล์ของโน้ตมาสเตอร์, ผู้เขียนความคิดเห็น, หรือข้อมูลการรีวิวแบบโซ่ ให้ตรวจสอบผลลัพธ์ที่รวมเนื่องจากสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับงานนำเสนอเช่นเดียวกับเนื้อหาระดับสไลด์

**เกิดอะไรขึ้นกับเสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาที่ฝังจะถูกนำไปเป็นส่วนหนึ่งของความสัมพันธ์ทรัพยากรของสไลด์ที่โคลน ลิงก์ภายนอกจะยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ปลายทางต้องยังคงพร้อมใช้งานหลังการรวม

**ฟอนต์ที่ฝังจากทุกแหล่งจะได้รับการรับรองว่ามีอยู่ในงานนำเสนอที่รวมหรือไม่?**

อย่าพึ่งพาการโคลนสไลด์อย่างเดียวสำหรับการจัดจำหน่ายฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมใช้งานฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์เป็นสิ่งสำคัญ

**ฉันจะรวมไฟล์ที่ป้องกันด้วยรหัสผ่านได้อย่างไร?**

เปิดไฟล์ด้วย [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) ที่ถูกต้อง จากนั้นโคลนสไลด์ตามปกติ การป้องกันผลลัพธ์จะต้องกำหนดแยกต่างหาก

**ฉันควรจัดการงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อออบเจกต์ไบนารีขนาดใหญ่ครองหน่วยความจำเป็นส่วนใหญ่, โหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่อย่างเต็มที่, ปิดการใช้งานงานนำเสนอแหล่งทันทีหลังการรวม, และบันทึกผลลัพธ์สุดท้ายเฉพาะเมื่อจำเป็น

**ฉันสามารถโคลนสไลด์จากหลายเธรดพร้อมกันได้หรือไม่?**

ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แยกการดำเนินการรวมแต่ละงานนำเสนอออกเป็นอินสแตนซ์ของตนเองและปฏิบัติตามแนวทางการทำงานหลายเธรดของ Aspose.Slides.