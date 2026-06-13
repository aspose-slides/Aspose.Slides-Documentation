---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ C++
linktitle: การทำงานหลายเธรด
type: docs
weight: 200
url: /th/cpp/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานขนาน
- แปลงสไลด์
- สไลด์เป็นภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "การทำงานหลายเธรดของ Aspose.Slides สำหรับ C++ ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument. ค้นหาวิธีปฏิบัติที่ดีที่สุดสำหรับกระบวนการทำงานการนำเสนอที่มีประสิทธิภาพ."
---
## **บทนำ**

แม้การทำงานแบบขนานกับงานนำเสนอจะเป็นไปได้ (ยกเว้นการแยกวิเคราะห์/โหลด/คล cloning) และส่วนใหญ่ทำงานได้ดี (ส่วนใหญ่) แต่ก็มีโอกาสเล็กน้อยที่คุณอาจได้รับผลลัพธ์ที่ไม่ถูกต้องเมื่อใช้ไลบรารีในหลายเธรด  

เราขอแนะนำอย่างยิ่งว่า **ไม่** ควรใช้อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) เพียงหนึ่งเดียวในสภาพแวดล้อมแบบหลายเธรด เนื่องจากอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่ไม่สามารถคาดเดาได้และไม่ง่ายต่อการตรวจจับ  

เป็น **ไม่** ปลอดภัยที่จะโหลด บันทึก และ/หรือคลอนอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) ในหลายเธรด การดำเนินการดังกล่าว **ไม่** ได้รับการสนับสนุน หากคุณต้องการทำงานประเภทนี้ คุณต้องทำงานแบบขนานโดยใช้หลายโปรเซสที่ทำงานแบบเดี่ยวเท่านั้น และแต่ละโปรเซสควรใช้อินสแตนซ์งานนำเสนอของตนเอง  

## **แปลงสไลด์นำเสนอเป็นภาพแบบขนาน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจากงานนำเสนอ PowerPoint ไปเป็นภาพ PNG แบบขนาน เนื่องจากการใช้อินสแตนซ์ `Presentation` เพียงหนึ่งเดียวในหลายเธรดไม่ปลอดภัย เราจึงแยกสไลด์งานนำเสนอออกเป็นงานนำเสนอหลายชุดและแปลงสไลด์เป็นภาพแบบขนานโดยใช้แต่ละงานนำเสนอในเธรดแยกกัน ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น  

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // แยกสไลด์ i ออกเป็นงานนำเสนอแยกส่วน.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // แปลงสไลด์เป็นภาพในงานที่แยกออก.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// รอให้ทุกงานเสร็จสิ้น.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**Do I need to call license setup in every thread?**  

ไม่ จำเป็นต้องทำเพียงครั้งเดียวต่อกระบวนการ/โดเมนแอป ก่อนที่เธรดจะเริ่มทำงาน หาก [การตั้งค่าลิขสิทธิ์](/slides/th/cpp/licensing/) อาจถูกเรียกพร้อมกัน (เช่น ในระหว่างการเริ่มต้นแบบเล็กน้อย) ให้ซิงโครไนซ์การเรียกนั้นเนื่องจากเมธอดการตั้งค่าลิขสิทธิ์เองไม่ปลอดภัยต่อเธรด  

**Can I pass `Presentation` or `Slide` objects between threads?**  

ไม่แนะนำให้ส่งวัตถุ `Presentation` หรือ `Slide` ที่ยังใช้งานอยู่ระหว่างเธรด ควรใช้อินสแตนซ์แยกกันต่อเธรดหรือสร้างงานนำเสนอ/คอนเทนเนอร์สไลด์แยกไว้ล่วงหน้าสำหรับแต่ละเธรด วิธีนี้สอดคล้องกับคำแนะนำทั่วไปว่าจะไม่แชร์อินสแตนซ์งานนำเสนอเดียวกันระหว่างเธรด  

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**  

ใช่ เมื่อแต่ละเธรดมีอินสแตนซ์ `Presentation` ของตนเองและกำหนดเส้นทางการส่งออกแยกกัน งานเหล่านี้มักจะสามารถทำแบบขนานได้อย่างถูกต้อง; อย่าใช้วัตถุงานนำเสนอหรือสตรีม I/O ร่วมกัน  

**What should I do with global font settings (folders, substitutions) in multithreading?**  

ให้กำหนดค่าฟอนต์ระดับโลกทั้งหมดก่อนเริ่มเธรดและไม่เปลี่ยนแปลงระหว่างการทำงานแบบขนาน การทำเช่นนี้จะขจัดการชนกันเมื่อเข้าถึงทรัพยากรฟอนต์ที่แชร์.