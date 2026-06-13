---
title: สนับสนุนไลบรารีที่สามารถขัดจังหวะได้
type: docs
weight: 150
url: /th/cpp/support-for-interruptable-library/
keywords:
  - ไลบรารีที่สามารถขัดจังหวะได้
  - โทเค็นการขัดจังหวะ
  - โทเค็นการยกเลิก
  - งานที่ใช้เวลานาน
  - ขัดจังหวะงาน
  - PowerPoint
  - OpenDocument
  - การนำเสนอ
  - C++
  - Aspose.Slides
description: "ทำให้งานที่ใช้เวลานานสามารถยกเลิกได้ด้วย Aspose.Slides สำหรับ C++. ขัดจังหวะการเรนเดอร์และการแปลงสำหรับ PowerPoint และ OpenDocument อย่างปลอดภัย พร้อมตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides มีกลไกการประมวลผลที่สามารถขัดจังหวะได้สำหรับงานนำเสนอที่ใช้เวลานาน เช่น การถอดรหัส, การเข้ารหัส, และการเรนเดอร์ กลไกนี้อิงตามคลาส `InterruptionToken` และ `InterruptionTokenSource`  

`InterruptionToken` สามารถกำหนดให้กับ `LoadOptions` และส่งต่อไปยังคอนสตรักเตอร์ของ `Presentation` เมื่อเรียก `InterruptionTokenSource::Interrupt()` งานที่ใช้เวลานานที่เกี่ยวข้องจะถูกขัดจังหวะ  

## **ไลบรารีที่สามารถขัดจังหวะได้**

ใน [Aspose.Slides 18.4](https://releases.aspose.com/slides/th/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), เราได้แนะนำคลาส [InterruptionToken](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/) ซึ่งช่วยให้คุณสามารถขัดจังหวะงานที่ใช้เวลานาน เช่น การถอดรหัส, การเข้ารหัส, และการเรนเดอร์  

- [InterruptionTokenSource](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/) คือแหล่งที่มาของโทเค็นที่ถูกส่งให้กับ [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_interruptiontoken/)。  
- เมื่อกำหนดค่า [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_interruptiontoken/) และอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) ถูกส่งต่อไปยังคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) การเรียก [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/interrupt/) จะขัดจังหวะงานที่ใช้เวลานานใด ๆ ที่เชื่อมโยงกับ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) นั้น  

โค้ดตัวอย่างต่อไปนี้แสดงการขัดจังหวะงานที่กำลังทำงาน:

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // เรียกดำเนินการในเธรดแยก
    Threading::Thread::Sleep(10000);       // หมดเวลา
    tokenSource->Interrupt();              // หยุดการแปลง
}
```

## **คำถามที่พบบ่อย**

**วัตถุประสงค์ของไลบรารีการขัดจังหวะของ Aspose.Slides คืออะไร?**

มันให้กลไกในการขัดจังหวะการดำเนินการที่ใช้เวลานาน เช่น การโหลด, การบันทึก, หรือการเรนเดอร์การนำเสนอ ก่อนที่การดำเนินการจะเสร็จสมบูรณ์ ซึ่งมีประโยชน์เมื่อต้องจำกัดเวลาการประมวลผลหรือเมื่อไม่จำเป็นต้องทำงานต่อ  

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontoken/) กับ [InterruptionTokenSource](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/) คืออะไร?**

- `InterruptionToken` ถูกส่งไปยัง API ของ Aspose.Slides และจะถูกตรวจสอบระหว่างการดำเนินการที่ใช้เวลานาน  
- `InterruptionTokenSource` ใช้ในโค้ดของคุณเพื่อสร้างโทเคนและกระตุ้นการขัดจังหวะโดยเรียก `Interrupt()`  

**งานใดบ้างที่สามารถขัดจังหวะได้?**

งานใด ๆ ของ Aspose.Slides ที่รับ [InterruptionToken](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontoken/) เช่น การโหลดการนำเสนอด้วย `Presentation(path, loadOptions)` หรือการบันทึกด้วย `Presentation::Save(...)` สามารถถูกขัดจังหวะได้  

**การขัดจังหวะเกิดขึ้นทันทีหรือไม่?**

ไม่ การขัดจังหวะเป็นแบบทำงานร่วมกัน: การดำเนินการจะตรวจสอบโทเค็นเป็นระยะ ๆ และหยุดทันทีเมื่อพบว่า [Interrupt()](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/interrupt/) ถูกเรียก  

**จะเกิดอะไรขึ้นหากฉันเรียก [Interrupt()](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/interrupt/) หลังจากงานเสร็จแล้ว?**

ไม่มีผล—การเรียกนี้จะไม่มีผลใด ๆ หากงานที่เกี่ยวข้องได้เสร็จแล้ว  

**ฉันสามารถใช้ [InterruptionTokenSource](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/) เดียวกันสำหรับหลายงานได้หรือไม่?**

ได้—แต่หลังจากที่คุณเรียก [Interrupt()](https://reference.aspose.com/slides/th/cpp/aspose.slides/interruptiontokensource/interrupt/) บนแหล่งนั้น งานทั้งหมดที่ใช้โทเค็นจากมันจะถูกขัดจังหวะ ใช้แหล่งโทเค็นแยกต่างหากเพื่อจัดการงานอย่างอิสระ  