---
title: แปลง PPT และ PPTX เป็น JPG ใน C++
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/cpp/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกงานนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- C++
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน C++ ด้วย Aspose.Slides โดยใช้ตัวอย่างโค้ดที่รวดเร็วและเชื่อถือได้"
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ JPG ช่วยในการแบ่งปันสไลด์, ปรับประสิทธิภาพ, และฝังเนื้อหาเข้าสู่เว็บไซต์หรือแอปพลิเคชัน Aspose.Slides for C++ ช่วยให้คุณเปลี่ยนไฟล์ PPTX, PPT, และ ODP เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีการแปลงที่แตกต่างกัน

ด้วยคุณลักษณะเหล่านี้จึงง่ายต่อการสร้างตัวดูงานนำเสนอของคุณเองและสร้างรูปย่อสำหรับทุกสไลด์ สิ่งนี้อาจมีประโยชน์หากคุณต้องการปกป้องสไลด์งานนำเสนอจากการคัดลอกหรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพ

## **แปลงสไลด์งานนำเสนอเป็นภาพ JPG**

ต่อไปนี้คือขั้นตอนการแปลงไฟล์ PPT, PPTX หรือ ODP เป็น JPG:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ็อบเจกต์สไลด์ของประเภท [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) จากคอลเลกชันสไลด์ของงานนำเสนอ
1. สร้างภาพของสไลด์โดยใช้เมธอด [ISlide.GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) 
1. เรียกเมธอด [IImage.Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) บนวัตถุภาพ ส่งชื่อไฟล์เอาต์พุตและรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="primary" %}} 
**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP เป็น JPG แตกต่างจากการแปลงเป็นรูปแบบอื่นใน Aspose.Slides for C++ API สำหรับรูปแบบอื่นคุณมักใช้เมธอด [IPresentation.Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) อย่างไรก็ตามสำหรับการแปลงเป็น JPG คุณต้องใช้เมธอด [IImage.Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) 
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // สร้างภาพสไลด์ด้วยสเกลที่ระบุ.
    auto image = slide->GetImage(scaleX, scaleY);

    // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **แปลงสไลด์เป็น JPG ด้วยขนาดที่กำหนดเอง**

เพื่อเปลี่ยนขนาดของภาพ JPG ที่ได้ คุณสามารถตั้งค่าขนาดภาพโดยส่งผ่านพารามิเตอร์ไปยังเมธอด [ISlide.GetImage(Size)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) วิธีนี้ทำให้คุณสร้างภาพที่มีความกว้างและความสูงตามที่กำหนดได้ ช่วยให้ผลลัพธ์ตรงตามความต้องการด้านความละเอียดและอัตราส่วนภาพ ความยืดหยุ่นนี้มีประโยชน์อย่างยิ่งเมื่อสร้างภาพสำหรับเว็บแอปพลิเคชัน, รายงาน หรือเอกสารที่ต้องการขนาดภาพที่แน่นอน

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // สร้างภาพสไลด์ด้วยขนาดที่ระบุ.
    auto image = slide->GetImage(imageSize);

    // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for C++ มีฟีเจอร์ที่อนุญาตให้เรนเดอร์คอมเมนต์บนสไลด์ของงานนำเสนอเมื่อแปลงเป็นภาพ JPG ฟังก์ชันนี้มีประโยชน์สำหรับการเก็บรักษาโน้ต, คำติชม, หรือการสนทนาที่ผู้ร่วมงานเพิ่มลงใน PowerPoint โดยการเปิดใช้งานตัวเลือกนี้ คอมเมนต์จะปรากฏในภาพที่สร้าง ทำให้การตรวจสอบและแชร์ฟีดแบ็กง่ายขึ้นโดยไม่ต้องเปิดไฟล์งานนำเสนอเดิม

สมมติว่าเรามีไฟล์งานนำเสนอ "sample.pptx" ที่มีสไลด์หนึ่งที่มีคอมเมนต์:

![สไลด์ที่มีคอมเมนต์](slide_with_comments.png)

โค้ด C++ ต่อไปนี้แปลงสไลด์เป็นภาพ JPG พร้อมคอมเมนต์:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // ตั้งค่าตัวเลือกสำหรับคอมเมนต์ของสไลด์.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // แปลงสไลด์แรกเป็นภาพ.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

ผลลัพธ์:

![ภาพ JPG ที่มีคอมเมนต์](image_with_comments.png)

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ สำหรับการแปลง PPT, PPTX หรือ ODP เป็นภาพ เช่น:

- [แปลง PowerPoint เป็น GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/)
- [แปลง PowerPoint เป็น PNG](/slides/th/cpp/convert-powerpoint-to-png/)
- [แปลง PowerPoint เป็น TIFF](/slides/th/cpp/convert-powerpoint-to-tiff/)
- [แปลง PowerPoint เป็น SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
เพื่อดูว่า Aspose.Slides แปลง PowerPoint เป็นภาพ JPG อย่างไร ลองใช้ตัวแปลงออนไลน์ฟรีเหล่านี้: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg) 
{{% /alert %}}

![ตัวแปลง PPTX เป็น JPG ออนไลน์ฟรี](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose มีแอปเว็บ [FREE Collage](https://products.aspose.app/slides/th/collage) ให้บริการ คุณสามารถรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ 

โดยใช้หลักการเดียวกับที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง สำหรับข้อมูลเพิ่มเติมดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/); แปลง [PNG to JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/); แปลง [SVG to PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/) 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงแบบแบตช์หรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการดำเนินการเดียว

**การแปลงรองรับ SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่น ๆ หรือไม่?**

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง, และอื่น ๆ อย่างไรก็ตาม ความแม่นยำในการเรนเดอร์อาจแตกต่างเล็กน้อยเมื่อเทียบกับ PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

**มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**

Aspose.Slides เองไม่ได้กำหนดข้อจำกัดที่เข้มงวดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตาม คุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง