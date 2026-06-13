---
title: "รวมพรีเซนเทชั่นอย่างมีประสิทธิภาพใน C++"
linktitle: "รวมพรีเซนเทชั่น"
type: docs
weight: 40
url: /th/cpp/merge-presentation/
keywords:
- "รวม PowerPoint"
- "รวมพรีเซนเทชั่น"
- "รวมสไลด์"
- "รวม PPT"
- "รวม PPTX"
- "รวม ODP"
- "ผสาน PowerPoint"
- "ผสานพรีเซนเทชั่น"
- "ผสานสไลด์"
- "ผสาน PPT"
- "ผสาน PPTX"
- "ผสาน ODP"
- "C++"
- "Aspose.Slides"
description: "ผสานพรีเซนเทชั่น PowerPoint (PPT, PPTX) และ OpenDocument (ODP) อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++ เพื่อเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **Overview**

Aspose.Slides ช่วยให้คุณรวมพรีเซนเทชั่นโดยการคัดลอกสไลด์จากพรีเซนเทชั่นหนึ่งไปยังอีกพรีเซนเทชั่นหนึ่ง บทความนี้อธิบายวิธีการรวมพรีเซนเทชั่นทั้งหมดหรือสไลด์ที่เลือกใช้มาสเตอร์สไลด์หรือเค้าโครงเฉพาะในระหว่างการรวม วิธีจัดการพรีเซนเทชั่นที่มีขนาดสไลด์ต่างกัน และการเพิ่มสไลด์ที่รวมแล้วเข้าไปในส่วนของพรีเซนเทชั่น นอกจากนี้ยังครอบคลุมโน๊ตผู้พูด คอมเมนต์ ไฟล์ต้นทางที่ป้องกันด้วยรหัสผ่าน และการใช้งานเธรด

## **Presentation Merging**

เมื่อคุณรวมพรีเซนเทชั่นหนึ่งกับอีกพรีเซนเทชั่นหนึ่ง คุณกำลังรวมสไลด์ของพวกมันให้เป็นพรีเซนเทชั่นเดียวเพื่อให้ได้ไฟล์เดียว

{{% alert title="Info" color="info" %}}

โปรแกรมพรีเซนเทชั่นส่วนใหญ่ (PowerPoint หรือ OpenOffice) ขาดฟังก์ชันที่ให้ผู้ใช้รวมพรีเซนเทชั่นในลักษณะนี้ได้

[**Aspose.Slides for C++**](https://products.aspose.com/slides/th/cpp/), อย่างไรก็ตาม ช่วยให้คุณรวมพรีเซนเทชั่นได้หลายวิธี คุณสามารถรวมพรีเซนเทชั่นพร้อมกับรูปทรง สไตล์ ข้อความ การฟอร์แมต คอมเมนต์ แอนิเมชัน ฯลฯ โดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล

**See also**

[Clone Slides](https://docs.aspose.com/slides/th/cpp/clone-slides/)*.*

{{% /alert %}}

### **What Can Be Merged**

ด้วย Aspose.Slides คุณสามารถรวม

* พรีเซนเทชั่นทั้งหมด ทั้งสไลด์จากพรีเซนเทชั่นทั้งหมดจะอยู่ในพรีเซนเทชั่นเดียว
* สไลด์ที่เลือก สไลด์ที่เลือกจะอยู่ในพรีเซนเทชั่นเดียว
* พรีเซนเทชั่นในรูปแบบเดียวกัน (PPT ไป PPT, PPTX ไป PPTX ฯลฯ) หรือรูปแบบต่างกัน (PPT ไป PPTX, PPTX ไป ODP ฯลฯ) ให้กันและกัน

{{% alert title="Note" color="warning" %}}

นอกจากพรีเซนเทชั่นแล้ว Aspose.Slides ยังอนุญาตให้คุณรวมไฟล์อื่นได้:

* [Images](https://products.aspose.com/slides/th/cpp/merger/image-to-image/), เช่น [JPG to JPG](https://products.aspose.com/slides/th/cpp/merger/jpg-to-jpg/) หรือ [PNG to PNG](https://products.aspose.com/slides/th/cpp/merger/png-to-png/)
* เอกสาร เช่น [PDF to PDF](https://products.aspose.com/slides/th/cpp/merger/pdf-to-pdf/) หรือ [HTML to HTML](https://products.aspose.com/slides/th/cpp/merger/html-to-html/)
* และไฟล์ประเภทต่างกัน เช่น [image to PDF](https://products.aspose.com/slides/th/cpp/merger/image-to-pdf/) หรือ [JPG to PDF](https://products.aspose.com/slides/th/cpp/merger/jpg-to-pdf/) หรือ [TIFF to PDF](https://products.aspose.com/slides/th/cpp/merger/tiff-to-pdf/)

{{% /alert %}}

### **Merging Options**

คุณสามารถกำหนดตัวเลือกที่ตัดสินว่า

* แต่ละสไลด์ในพรีเซนเทชั่นผลลัพธ์จะคงสไตล์เฉพาะของมัน
* หรือสไตล์เดียวกันจะใช้กับสไลด์ทั้งหมดในพรีเซนเทชั่นผลลัพธ์

เพื่อรวมพรีเซนเทชั่น Aspose.Slides ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (จากอินเทอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection)) มีการทำงานหลายแบบที่กำหนดพารามิเตอร์ของกระบวนการรวมพรีเซนเทชั่น ทุกอ็อบเจกต์ Presentation มีคอลเลกชัน [Slides](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) ดังนั้นคุณสามารถเรียกเมธอด `AddClone` จากพรีเซนเทชั่นที่ต้องการรวมสไลด์เข้าไปได้

เมธอด `AddClone` จะคืนค่าเป็นอ็อบเจกต์ `ISlide` ซึ่งเป็นสำเนาของสไลด์ต้นทาง สไลด์ในพรีเซนเทชั่นผลลัพธ์จึงเป็นสำเนาของสไลด์จากต้นทาง ดังนั้นคุณสามารถเปลี่ยนแปลงสไลด์ที่ได้ (เช่น ใช้สไตล์หรือตัวเลือกการฟอร์แมตหรือเค้าโครง) โดยไม่ต้องกังวลว่าจะทำให้พรีเซนเทชั่นต้นทางได้รับผลกระทบ

## **Merge Presentations**

Aspose.Slides มีเมธอด [**AddClone (ISlide)**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) ที่ให้คุณรวมสไลด์โดยสไลด์ยังคงรักษาเค้าโครงและสไตล์เดิม (พารามิเตอร์เริ่มต้น)

โค้ด C++ ด้านล่างแสดงวิธีการรวมพรีเซนเทชั่น:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations with a Slide Master**

Aspose.Slides มีเมธอด [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) ที่ให้คุณรวมสไลด์พร้อมใช้แม่แบบสไลด์มาสเตอร์ของพรีเซนเทชั่น หากต้องการคุณสามารถเปลี่ยนสไตล์ของสไลด์ในพรีเซนเทชั่นผลลัพธ์ได้

โค้ด C++ ต่อไปนี้สาธิตการทำงานดังกล่าว:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}}

เค้าโครงสไลด์สำหรับมาสเตอร์สไลด์จะถูกกำหนดโดยอัตโนมัติ หากไม่สามารถกำหนดเค้าโครงที่เหมาะสมได้ และพารามิเตอร์ `allowCloneMissingLayout` ของเมธอด `AddClone` ถูกตั้งค่าเป็น true จะใช้เค้าโครงของสไลด์ต้นทาง มิฉะนั้นจะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)

{{% /alert %}}

หากคุณต้องการให้สไลด์ในพรีเซนเทชั่นผลลัพธ์ใช้เค้าโครงสไลด์ที่แตกต่างกัน ให้ใช้เมธอด [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) แทนเมื่อทำการรวม

## **Merge Specific Slides from Presentations**

การรวมสไลด์เฉพาะจากหลายพรีเซนเทชั่นมีประโยชน์สำหรับการสร้างชุดสไลด์ที่กำหนดเอง Aspose.Slides C++ อนุญาตให้คุณเลือกและนำเข้าเฉพาะสไลด์ที่ต้องการ API จะคงรูปแบบ เค้าโครง และการออกแบบของสไลด์ต้นฉบับ

โค้ด C++ ด้านล่างสร้างพรีเซนเทชั่นใหม่ เพิ่มสไลด์หัวเรื่องจากพรีเซนเทชั่นอื่นสองไฟล์แล้วบันทึกผลลัพธ์ลงไฟล์:

```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Merge Presentations with a Slide Layout**

โค้ด C++ นี้แสดงวิธีการรวมสไลด์จากพรีเซนเทชั่นพร้อมประยุกต์ใช้เค้าโครงสไลด์ที่คุณต้องการเพื่อให้ได้พรีเซนเทชั่นผลลัพธ์เดียว:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}}

คุณไม่สามารถรวมพรีเซนเทชั่นที่มีขนาดสไลด์ต่างกันได้

{{% /alert %}}

เพื่อรวมพรีเซนเทชั่น 2 ตัวที่มีขนาดสไลด์แตกต่างกัน คุณต้องปรับขนาดของพรีเซนเทชั่นหนึ่งให้ตรงกับอีกพรีเซนเทชั่นหนึ่ง

โค้ดตัวอย่างต่อไปนี้สาธิตวิธีการดังกล่าว:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Merge Slides to a Presentation Section**

โค้ด C++ นี้แสดงวิธีการรวมสไลด์เฉพาะเข้ากับส่วนหนึ่งของพรีเซนเทชั่น:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

สไลด์จะถูกเพิ่มที่ส่วนท้ายของเซคชั่นนั้น

{{% alert title="Tip" color="primary" %}}

Aspose มีแอปเว็บ **FREE Collage** ([https://products.aspose.app/slides/th/collage](https://products.aspose.app/slides/th/collage)) ให้คุณรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ

{{% /alert %}}

## **FAQ**

**Are speaker notes preserved during merge?**

ใช่ เมื่อตัวคัดลอกสไลด์ Aspose.Slides จะคัดลอกองค์ประกอบสไลด์ทั้งหมดรวมถึงโน้ตผู้พูด ฟอร์แมต และแอนิเมชัน

**Are comments and their authors transferred?**

คอมเมนต์เป็นส่วนของเนื้อหาสไลด์และจะถูกคัดลอกพร้อมสไลด์ ป้ายชื่อผู้เขียนคอมเมนต์จะถูกเก็บเป็นอ็อบเจกต์คอมเมนต์ในพรีเซนเทชั่นผลลัพธ์

**What if the source presentation is password-protected?**

ต้อง **เปิดด้วยรหัสผ่าน** (/slides/th/cpp/password-protected-presentation/) ผ่านเมธอด [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) หลังจากโหลดแล้วสไลด์เหล่านั้นสามารถคัดลอกไปยังไฟล์เป้าหมายที่ไม่ได้ป้องกัน (หรือไฟล์ที่ป้องกันก็ได้)

**How thread-safe is the merge operation?**

ห้ามใช้อ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ตัวเดียวกันจากหลายเธรด (/slides/th/cpp/multithreading/) กฎแนะนำคือ “หนึ่งเอกสาร — หนึ่งเธรด” ไฟล์ต่าง ๆ สามารถประมวลผลพร้อมกันในเธรดแยกต่างหากได้.