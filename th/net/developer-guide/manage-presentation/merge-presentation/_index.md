---
title: ผสานงานนำเสนออย่างมีประสิทธิภาพใน .NET
linktitle: ผสานงานนำเสนอ
type: docs
weight: 40
url: /th/net/merge-presentation/
keywords:
- ผสาน PowerPoint
- ผสานงานนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument ใน .NET โดยการคัดลอกสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, คงส่วน, และจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for .NET รวมงานนำเสนอโดยการคัดลอกสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/), ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่คัดลอกไปยังมาสเตอร์หรือเลเอาต์ในงานนำเสนอปลายทางได้

บทความนี้ครอบคลุมการทำงานผสานที่พบบ่อยที่สุด:

- รวมสไลด์ทั้งหมดโดยคงรูปแบบต้นฉบับของสไลด์;
- รวมสไลด์ที่เลือก;
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง;
- ใช้เลเอาต์เฉพาะจากงานนำเสนอปลายทาง;
- ปรับขนาดสไลด์ที่แตกต่างให้เท่ากันก่อนการรวม;
- เพิ่มสไลด์ที่คัดลอกลงในส่วน;
- รวมหลายงานนำเสนอในกระบวนการเริ่มต้นถึงจบเดียว;
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, คอมเมนท์, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อกังวลเรื่องการทำงานแบบหลายเธรด

## **การคัดลอกสไลด์ที่มีผลต่อมาสเตอร์และเลเอาต์**

สไลด์สืบทอดลักษณะส่วนใหญ่จากเลเอาต์และมาสเตอร์ ดังนั้นการเลือก overload การคัดลอกจึงกำหนดว่าสไลด์ที่ผสานจะถูกรวมเข้ากับงานนำเสนอปลายทางอย่างไร

ใช้ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) ในหนึ่งในวิธีต่อไปนี้:

- `AddClone(sourceSlide)` — คงเลเอาต์และรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับสามารถถูกคัดลอกไปยังงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่คัดลอกโดยอัตโนมัติเพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันถูกคัดลอกหลายครั้ง
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่คัดลอกไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกับประเภทหรือชื่อภายใต้มาสเตอร์นั้น
- `AddClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่คัดลอกโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลเอาต์ที่ส่งให้ overload `AddClone` ต้องเป็นของ **งานนำเสนอปลายทาง**, ไม่ใช่ของงานนำเสนอแหล่ง

## **ผสานงานนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

การผสานที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากงานนำเสนอแหล่งไปยังงานนำเสนอปลายทาง วิธีนี้เหมาะเมื่อสไลด์ที่นำเข้าต้องคงธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิมไว้

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

ผลลัพธ์อาจมีหลายมาสเตอร์เมื่อแหล่งและปลายทางใช้ดีไซน์ต่างกัน สิ่งนี้เป็นเรื่องปกติเมื่อต้องการคงรูปแบบต้นฉบับ

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องคัดลอกทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะสไลด์ที่เลือกจากงานนำเสนอแหล่ง

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

ตรวจสอบดัชนีสไลด์ก่อนคัดลอกเมื่อมาจากผู้ใช้หรือการกำหนดค่าภายนอก

## **ผสานสไลด์ด้วยมาสเตอร์ปลายทาง**

ใช้ overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) เมื่อสไลด์ที่นำเข้าต้องปฏิบัติตามมาสเตอร์ที่มีอยู่แล้วในงานนำเสนอปลายทาง

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

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยจับคู่ประเภทหรือชื่อของเลเอาต์ต้นฉบับ หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` ระบบจะคัดลอกเลเอาต์ต้นฉบับเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/) ถูกโยนขึ้น

ใช้ค่า `false` เมื่อคุณต้องการให้การผสานล้มเหลวแทนการเพิ่มเลเอาต์ใหม่เข้ามาในมาสเตอร์ปลายทาง

## **ผสานสไลด์ด้วยเลเอาต์ปลายทางที่ระบุ**

ใช้ overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) เมื่อคุณทราบเลเอาต์ปลายทางที่ต้องการให้สไลด์ที่นำเข้าใช้

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

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบทอด; ไม่ได้ออกแบบใหม่เนื้อหาของสไลด์ต้นฉบับ หากเลเอาต์ต้นฉบับและปลายทางมีโครงสร้าง placeholder แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการฟอร์แมตและพฤติกรรม placeholder ที่สืบทอดเหมาะสม

## **ผสานงานนำเสนอที่มีขนาดสไลด์ต่างกัน**

งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานได้ แต่การคัดลอกสไลด์ลงในงานนำเสนอที่มีขนาดสไลด์อื่นไม่ทำให้เนื้อหาออกแบบใหม่อัตโนมัติสำหรับพื้นที่ใหม่ รูปทรงอาจปรากฏเคลื่อนที่, ย่อ-ขยายไม่คาดคิด, หรืออยู่นอกพื้นที่มองเห็นของสไลด์

แนวทางปฏิบัติที่เป็นประโยชน์คือปรับขนาดงานนำเสนอแหล่งก่อนคัดลอก วิธี `SlideSize.SetSize` สามารถสเกลเนื้อหาที่มีอยู่ขณะเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/net/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ต้องการ

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

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอแหล่งในหน่วยความจำ หากคุณต้องการให้งานนำเสนอแหล่งเดิมไม่เปลี่ยนแปลงสำหรับการดำเนินการอื่น เปิดอินสแตนซ์แยกต่างหากสำหรับการผสาน

## **ผสานสไลด์เข้าส่วนของงานนำเสนอ**

วงลูปคัดลอกสไลด์พื้นฐานจะไม่สร้างลำดับชั้นของส่วนจากงานนำเสนอแหล่ง หากส่วนมีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในงานนำเสนอปลายทางและคัดลอกสไลด์เข้าไปโดยใช้ [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/)

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

สไลด์ที่คัดลอกจะถูกเพิ่มต่อท้ายส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนจากแหล่ง ให้สร้างส่วนเหล่านั้นในปลายทางและแมปสไลด์แต่ละอันกับส่วนปลายทางที่สอดคล้องกัน

## **ผสานหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างแบบ end-to-end ต่อไปนี้ใช้งานนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งเพิ่มเติม, เปิดแต่ละแหล่งเฉพาะช่วงที่ทำการคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จสิ้น

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

นี่เป็นฐานที่ดีสำหรับการคงรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `AddClone(slide)` อย่างง่ายด้วย overload มาสเตอร์หรือเลเอาต์ปลายทางที่แสดงไว้ก่อนหน้า

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์, และความเที่ยงตรงของการฟอร์แมต**

การคัดลอกสไลด์โดยค่าเริ่มต้นสามารถนำมาสเตอร์ที่จำเป็นจากแหล่งเข้าสู่งานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในของมาสเตอร์ที่คัดลอกโดยอัตโนมัติเพื่อหลีกเลี่ยงการคัดลอกมาสเตอร์เดียวกันหลายครั้ง มาสเตอร์ที่คัดลอกด้วยตนเองจะไม่ถูกติดตามในทะเบียนนั้น ดังนั้นควรหลีกเลี่ยงการคัดลอกมาสเตอร์ล่วงหน้า เว้นแต่ต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าสมมติว่ามาสเตอร์หรือเลเอาต์สองตัวที่มีชื่อเดียวกันจะมีล appearance เหมือนกัน หากเทมเพลตขององค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างเจาะจงและตรวจสอบผลลัพธ์หลังการผสาน

### **โน้ตและคอมเมนท์**

โน้ตสำหรับผู้พูดและคอมเมนท์ของสไลด์จะเชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อตัวสไลด์ถูกคัดลอก Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](https://docs.aspose.com/slides/th/net/presentation-notes/) และ [presentation comments](https://docs.aspose.com/slides/th/net/presentation-comments/)

หากการฟอร์แมตของหน้าโน้ตสำคัญ ให้ตรวจสอบงานนำเสนอที่ผสานแล้ว เนื่องจากโน้ตมาสเตอร์เป็นอ็อบเจ็กต์ระดับงานนำเสนอและอาจแตกต่างกันระหว่างไฟล์แหล่ง สำหรับกระบวนการตรวจสอบ ให้ตรวจสอบผู้เขียนคอมเมนท์และคอมเมนท์แบบเธรดหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์สามารถอ้างอิงทรัพยากรระดับงานนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้คัดลอกสไลด์เองแทนการคัดลอกเฉพาะรูปร่างที่มองเห็น เพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์กับทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแตกต่างกัน ลิงก์เสียง, วิดีโอ, วัตถุ OLE, หรือไฮเปอร์ลิงก์ที่ลิงก์ไว้ยังคงพึ่งพาเป้าหมายภายนอก; การคัดลอกสไลด์ไม่ทำให้ลิงก์ภายนอกกลายเป็นเนื้อหาที่ฝัง ให้ทดสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่งานนำเสนอที่ผสานจะเปิด

Aspose.Slides ติดตามมาสเตอร์ที่คัดลอกโดยอัตโนมัติ แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากงานนำเสนอแหล่งที่ไม่เกี่ยวข้องจะถูกลบซ้ำเสมอ หากขนาดไฟล์ผลลัพธ์เป็นสิ่งสำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการลบซ้ำโดยอัตโนมัติ

### **ฟอนต์ฝังและความพร้อมใช้ของฟอนต์**

ฟอนต์จัดการระดับงานนำเสนอ หากต้องการให้การจัดรูปแบบตัวอักษรคงที่บนเครื่องต่าง ๆ อย่าสมมติว่าการคัดลอกสไลด์อย่างเดียวทำให้ฟอนต์ที่ต้องการมีอยู่ในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ฝังด้วย [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](https://docs.aspose.com/slides/th/net/embedded-font/)

นอกจากนี้ ให้ตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์แหล่งหรือไม่ เนื่องจากลิขสิทธิ์ฟอนต์อาจจำกัดการฝัง

### **งานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

แหล่งที่ถูกป้องกันด้วยรหัสผ่านต้องเปิดสำเร็จก่อนที่สไลด์จะสามารถคัดลอกได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/)

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

การเปิดแหล่งที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันอัตโนมัติกับงานนำเสนอปลายทาง ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วิดีโอ หรือวัตถุไบนารีขนาดใหญ่สามารถใช้หน่วยความจำมาก [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/blobmanagementoptions/) ให้การควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](https://docs.aspose.com/slides/th/net/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ขนาดใหญ่ ควรโหลดจากพาธไฟล์เมื่อเป็นไปได้, ปิดการใช้งานงานนำเสนอแหล่งทันทีที่ทำการผสานเสร็จ, และหลีกเลี่ยงการบันทึกรายการกลางบ่อย ๆ เว้นแต่กระบวนการต้องการจุดตรวจ

### **ความปลอดภัยในการทำงานหลายเธรด**

ห้ามโหลด, แก้ไข, บันทึก, หรือคัดลอกอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้จำกัดแต่ละอินสแตนซ์งานนำเสนอให้ใช้กับการผสานหนึ่งครั้ง หากคุณทำงานหลายงานแบบขนาน ให้ใช้อินสแตนซ์งานนำเสนออิสระและปฏิบัติตาม [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/th/net/multithreading/)

## **คำถามที่พบบ่อย**

**ฉันจะรักษาออกแบบดั้งเดิมของแต่ละงานนำเสนอได้อย่างไร?**

ใช้ [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) โดยไม่ระบุมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides สามารถคัดลอกมาสเตอร์ต้นฉบับได้โดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากงานนำเสนอปลายทาง, ไม่ใช่จากแหล่ง Aspose.Slides จะพยายามแมปสไลด์แต่ละอันกับเลเออต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**เมื่อไหร่ควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์ที่รู้จักล่วงหน้า ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอาต์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์ต้นฉบับ

**สามารถผสานงานนำเสนอที่มีขนาดสไลด์ต่างกันได้หรือไม่?**

ได้, แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติสำหรับขนาดปลายทาง ปรับขนาดงานนำเสนอแหล่งก่อนเมื่อจำเป็นต้องกำหนดตำแหน่งอย่างแม่นยำ เช่นใช้ [SlideSize.SetSize](https://reference.aspose.com/slides/th/net/aspose.slides/slidesize/setsize/) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/net/aspose.slides/slidesizescaletype/)

**ฉันสามารถผสานไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ โหลดแต่ละงานนำเสนอแหล่ง, คัดลอกสไลด์ที่ต้องการเข้าไปในงานนำเสนอปลายทางหนึ่ง, แล้วบันทึกผลลัพธ์ในรูปแบบที่รองรับ เนื่องจากฟีเจอร์ของรูปแบบไฟล์อาจต่างกัน ตรวจสอบเนื้อหาซับซ้อนหลังการผสานข้ามรูปแบบ ดู [Supported File Formats](https://docs.aspose.com/slides/th/net/supported-file-formats/)

**ส่วนของแหล่งจะถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่ใช่ในลูปพื้นฐานที่คัดลอกสไลด์เท่านั้น ให้สร้างส่วนที่ต้องการในปลายทางและใช้ overload ของ [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) สำหรับส่วนเมื่อโครงสร้างส่วนต้องคงไว้

**โน้ตและคอมเมนท์จะถูกคงไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมกับสไลด์ที่คัดลอก สำหรับกระบวนการที่พึ่งพาการจัดรูปแบบของโน้ตมาสเตอร์, ผู้เขียนคอมเมนท์, หรือข้อมูลการตรวจสอบแบบเธรด ให้ตรวจสอบผลลัพธ์ที่ผสานเนื่องจากสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับงานนำเสนอเช่นกัน

**เกิดอะไรขึ้นกับเสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาที่ฝังจะถูกนำไปพร้อมกับความสัมพันธ์ของทรัพยากรสไลด์ที่คัดลอก ลิงก์ภายนอกจะยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ของเป้าหมายต้องพร้อมใช้งานหลังการผสาน

**ฟอนต์ที่ฝังจากทุกแหล่งจะมีในงานนำเสนอที่ผสานหรือไม่?**

ไม่ควรพึ่งพาการคัดลอกสไลด์อย่างเดียวสำหรับการจัดเตรียมฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมใช้งานฟอนต์ภายนอกอย่างชัดเจนเมื่อการจัดรูปแบบตัวอักษรสำคัญ

**ฉันจะผสานไฟล์ที่ป้องกันด้วยรหัสผ่านได้อย่างไร?**

เปิดไฟล์ด้วย [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) ที่ถูกต้อง, จากนั้นคัดลอกสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก

**ฉันควรจัดการงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่เป็นสาเหตุหลักของการใช้หน่วยความจำ, โหลดจากพาธไฟล์สำหรับไฟล์ขนาดใหญ่, ปิดการใช้งานงานนำเสนอแหล่งทันทีที่ทำการผสานเสร็จ, และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็น

**ฉันสามารถคัดลอกสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เดียวกันพร้อมกันหลายเธรด ให้แยกการผสานแต่ละงานนำเสนอให้อยู่ในอินสแตนซ์ของตนเองเท่านั้น