---
title: จัดการส่วนสไลด์ในงานนำเสนอโดยใช้ C++
linktitle: ส่วนสไลด์
type: docs
weight: 100
url: /th/cpp/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทำให้การจัดการส่วนสไลด์ใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ มีประสิทธิภาพมากขึ้น — แบ่ง, เปลี่ยนชื่อ, และจัดเรียงใหม่เพื่อเพิ่มประสิทธิภาพการทำงานของ PPTX และ ODP"
---
## **บทนำ**

ด้วย Aspose.Slides for C++ คุณสามารถจัดระเบียบงานนำเสนอ PowerPoint เป็นส่วนต่าง ๆ ได้ คุณสามารถสร้างส่วนที่มีสไลด์เฉพาะได้

คุณอาจต้องการสร้างส่วนและใช้เพื่อจัดระเบียบหรือแบ่งสไลด์ในงานนำเสนอให้เป็นส่วนที่มีเหตุผลในสถานการณ์ต่อไปนี้:

- เมื่อคุณกำลังทำงานบนงานนำเสนอขนาดใหญ่กับคนอื่นหรือทีม—และคุณจำเป็นต้องมอบสไลด์บางส่วนให้กับเพื่อนร่วมงานหรือสมาชิกในทีม
- เมื่อคุณกำลังจัดการกับงานนำเสนอที่มีสไลด์จำนวนมาก—and คุณกำลังประสบปัญหาในการจัดการหรือแก้ไขเนื้อหาทั้งหมดในครั้งเดียว

โดยทั่วไปคุณควรสร้างส่วนที่เก็บสไลด์ที่คล้ายคลึงกัน—สไลด์เหล่านั้นมีความสัมพันธ์กันหรือสามารถจัดเป็นกลุ่มตามกฎบางอย่าง—and ตั้งชื่อส่วนให้บรรยายลักษณะของสไลด์ภายใน

## **สร้างส่วนในงานนำเสนอ**

เพื่อเพิ่มส่วนที่เก็บสไลด์ในงานนำเสนอ Aspose.Slides for C++ มีเมธอด AddSection ซึ่งให้คุณระบุชื่อส่วนที่ต้องการสร้างและสไลด์ที่เป็นจุดเริ่มต้นของส่วน

โค้ดตัวอย่างนี้แสดงวิธีสร้างส่วนในงานนำเสนอด้วย C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 จะสิ้นสุดที่ newSlide2 และหลังจากนั้น section2 จะเริ่มต้น   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนชื่อส่วน**

หลังจากคุณสร้างส่วนในงานนำเสนอ PowerPoint แล้ว คุณอาจต้องการเปลี่ยนชื่อของมัน

โค้ดตัวอย่างนี้แสดงวิธีเปลี่ยนชื่อส่วนในงานนำเสนอด้วย C++ โดยใช้ Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**ส่วนต่าง ๆ จะถูกคงไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่สนับสนุนเมตาดาต้าของส่วน ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt

**ส่วนทั้งหมดสามารถถูก "ซ่อนได้" หรือไม่?**

ไม่. สามารถซ่อนได้เฉพาะสไลด์เดี่ยวเท่านั้น ส่วนในฐานะเอนทิตี้ไม่มีสถานะ "ซ่อน"

**ฉันสามารถค้นหาส่วนโดยอาศัยสไลด์ได้อย่างรวดเร็ว หรือค้นหาสไลด์แรกของส่วนได้หรือไม่?**

ได้. ส่วนถูกกำหนดโดยสไลด์เริ่มต้นอย่างชัดเจน; เมื่อคุณมีสไลด์หนึ่ง คุณสามารถระบุได้ว่ามันอยู่ในส่วนใด และสำหรับส่วนใดก็สามารถเข้าถึงสไลด์แรกของส่วนนั้นได้