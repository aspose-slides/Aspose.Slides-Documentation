---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอด้วย C++
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/cpp/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิทแมพ
- แทนที่รูปภาพ
- แทนที่ภาพ
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
- EMF
- SVG
- C++
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides for C++ ราบรื่นขึ้น เพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ"
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากยิ่งขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ลงในสไลด์ได้เช่นกัน Aspose.Slides ให้คุณเพิ่มภาพลงในสไลด์ของการนำเสนอผ่านขั้นตอนต่าง ๆ

{{% alert title="เคล็ดลับ" color="primary" %}} 

Aspose มีเครื่องแปลงฟรี—[JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างการนำเสนออย่างรวดเร็วจากภาพ  

{{% /alert %}} 

{{% alert title="ข้อมูล" color="info" %}}

หากคุณต้องการเพิ่มภาพเป็นอ็อบเจกต์กรอบ—โดยเฉพาะอย่างยิ่งหากวางแผนใช้ตัวเลือกการจัดรูปแบบมาตรฐานเพื่อปรับขนาด เพิ่มเอฟเฟกต์ ฯลฯ—ดูที่ [Picture Frame](/slides/th/cpp/picture-frame/)  

{{% /alert %}} 

{{% alert title="หมายเหตุ" color="warning" %}}

คุณสามารถจัดการการดำเนินการอินพุต/เอาต์พุตที่เกี่ยวข้องกับภาพและการนำเสนอ PowerPoint เพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง ดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/).  

{{% /alert %}}

Aspose.Slides รองรับการทำงานกับภาพในรูปแบบยอดนิยมเหล่านี้: JPEG, PNG, GIF และรูปแบบอื่น ๆ  

## **เพิ่มภาพที่เก็บไว้ในเครื่องลงในสไลด์**

คุณสามารถเพิ่มภาพหนึ่งหรือหลายภาพจากคอมพิวเตอร์ของคุณลงในสไลด์ของการนำเสนอ ตัวอย่างโค้ดใน C++ แสดงวิธีเพิ่มภาพลงในสไลด์:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **เพิ่มภาพจากเว็บลงในสไลด์**

หากภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่มีในเครื่องของคุณ คุณสามารถเพิ่มภาพโดยตรงจากเว็บได้

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มภาพจากเว็บลงในสไลด์ใน C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **เพิ่มภาพลงใน Slide Masters**

Slide master คือสไลด์ระดับบนสุดที่เก็บและควบคุมข้อมูล (ธีม, เลย์เอาต์ ฯลฯ) ของสไลด์ทั้งหมดที่อยู่ภายใต้มัน ดังนั้นเมื่อคุณเพิ่มภาพลงใน slide master ภาพนั้นจะปรากฏบนทุกสไลด์ที่ใช้ slide master นี้

ตัวอย่างโค้ด C++ นี้แสดงวิธีเพิ่มภาพลงใน slide master:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **เพิ่มภาพเป็นพื้นหลังสไลด์**

คุณอาจต้องการใช้รูปภาพเป็นพื้นหลังสำหรับสไลด์เดียวหรือหลายสไลด์ ในกรณีนี้ให้ดู *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/th/cpp/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ไปยังการนำเสนอ**
คุณสามารถเพิ่มหรือแทรกภาพใด ๆ ลงในการนำเสนอโดยใช้เมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) ที่เป็นส่วนหนึ่งของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection)

เพื่อสร้างอ็อบเจกต์ภาพจาก SVG ให้ทำตามขั้นตอนนี้:

1. สร้างอ็อบเจกต์ SvgImage เพื่อแทรกลงใน ImageShapeCollection  
2. สร้างอ็อบเจกต์ PPImage จาก ISvgImage  
3. สร้างอ็อบเจกต์ PictureFrame โดยใช้อินเทอร์เฟซ IPPImage  

ตัวอย่างโค้ดนี้แสดงวิธีทำตามขั้นตอนข้างต้นเพื่อเพิ่มภาพ SVG ลงในการนำเสนอ:
``` cpp 
// เส้นทางไปยังไดเรกทอรีเอกสาร
System::String dataDir = u"D:\\Documents\\";

// ชื่อไฟล์ SVG แหล่งที่มา
System::String svgFileName = dataDir + u"sample.svg";

// ชื่อไฟล์การนำเสนอผลลัพธ์
System::String outPptxPath = dataDir + u"presentation.pptx";

// สร้างการนำเสนอใหม่
auto p = System::MakeObject<Presentation>();

// อ่านเนื้อหาไฟล์ SVG
System::String svgContent = File::ReadAllText(svgFileName);

// สร้างอ็อบเจกต์ SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// สร้างอ็อบเจกต์ PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// สร้าง PictureFrame ใหม่
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// บันทึกการนำเสนอในรูปแบบ PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **แปลง SVG เป็นชุดรูปร่าง**
การแปลง SVG ของ Aspose.Slides ให้เป็นชุดรูปร่างคล้ายกับฟังก์ชันของ PowerPoint ที่ใช้ทำงานกับภาพ SVG:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้บริการโดยหนึ่งใน overload ของเมธอด [AddGroupShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection) ที่รับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_svg_image) เป็นอาร์กิวเมนต์แรก

ตัวอย่างโค้ดนี้แสดงวิธีใช้เมธอดที่อธิบายเพื่อแปลงไฟล์ SVG เป็นชุดรูปร่าง:

``` cpp 
// เส้นทางไปยังไดเรกทอรีเอกสาร
System::String dataDir = u"D:\\Documents\\";

// ชื่อไฟล์ SVG แหล่งที่มา
System::String svgFileName = dataDir + u"sample.svg";

// ชื่อไฟล์การนำเสนอผลลัพธ์
System::String outPptxPath = dataDir + u"presentation.pptx";

// สร้างการนำเสนอใหม่
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// อ่านเนื้อหาไฟล์ SVG
System::String svgContent = File::ReadAllText(svgFileName);

// สร้างอ็อบเจกต์ SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// รับขนาดสไลด์
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// แปลงภาพ SVG เป็นกลุ่มของรูปร่างโดยปรับสัดส่วนให้พอดีกับขนาดสไลด์
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// บันทึกการนำเสนอในรูปแบบ PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **เพิ่มภาพเป็น EMF ไปยังสไลด์**
Aspose.Slides for C++ อนุญาตให้คุณสร้างภาพ EMF จากชีต Excel และเพิ่มภาพเหล่านั้นเป็น EMF ในสไลด์ด้วย Aspose.Cells

ตัวอย่างโค้ดนี้แสดงวิธีทำงานตามที่อธิบาย:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **แทนที่ภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่ภาพที่เก็บอยู่ใน Image Collection ของการนำเสนอ (รวมถึงภาพที่ใช้โดยรูปร่างสไลด์) ส่วนนี้แสดงหลายวิธีในการอัปเดตภาพในคอลเลกชัน API มีเมธอดง่าย ๆ สำหรับแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. โหลดภาพใหม่จากไฟล์ไปยังอาร์เรย์ไบต์  
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้ไบต์อาร์เรย์  
4. ในวิธีที่สอง โหลดภาพเข้าสู่วัตถุ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) และแทนที่ภาพเป้าหมายด้วยวัตถุนั้น  
5. ในวิธีที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ  
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// วิธีแรก.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// วิธีที่สอง.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// วิธีที่สาม.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// บันทึกการนำเสนอไปยังไฟล์.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="ข้อมูล" color="info" %}}

โดยใช้เครื่องแปลง Aspose FREE [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหว สร้าง GIF จากข้อความ ฯลฯ ได้อย่างง่ายดาย  

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของภาพต้นฉบับยังคงเหมือนเดิมหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่การแสดงผลสุดท้ายขึ้นอยู่กับการปรับสัดส่วนของ [picture](/slides/th/cpp/picture-frame/) บนสไลด์และการบีบอัดที่ทำระหว่างการบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ใน Image Collection ของการนำเสนอ — การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**สามารถแปลง SVG ที่แทรกแล้วให้เป็นรูปร่างที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG ให้เป็นกลุ่มของรูปร่าง หลังจากนั้นส่วนต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปร่าง

**จะตั้งค่าภาพเป็นพื้นหลังของหลายสไลด์พร้อมกันอย่างไร?**

[Assign the image as the background](/slides/th/cpp/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง — สไลด์ใด ๆ ที่ใช้ master/layout นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ

**จะป้องกันไม่ให้การนำเสนอ “บวม” ขนาดใหญ่จากภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรภาพเดียวกันหลายครั้งแทนการทำสำเนา เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ซ้ำซ้อนไว้บน master เมื่อเป็นไปได้  