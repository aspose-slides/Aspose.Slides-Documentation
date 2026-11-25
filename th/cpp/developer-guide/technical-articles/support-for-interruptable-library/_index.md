---
title: ขัดจังหวะการทำงานของการนำเสนอที่ใช้เวลานานใน C++
linktitle: ขัดจังหวะการทำงานของการนำเสนอ
type: docs
weight: 150
url: /th/cpp/support-for-interruptable-library/
keywords:
- การทำงานที่สามารถขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- โทเค็นการยกเลิก
- งานที่ใช้เวลานาน
- ขัดจังหวะงาน
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธียกเลิกการทำงานของการนำเสนอที่ใช้เวลานานใน Aspose.Slides สำหรับ C++ และส่งคืนผลลัพธ์บางส่วนเมื่อส่งออกสไลด์ในลูป."
---
## **ภาพรวม**

Aspose.Slides for C++ สามารถขัดจังหวะการทำงานที่ใช้เวลานาน เช่น การโหลด, การบันทึก, และการแสดงผลการนำเสนอ แอปพลิเคชันของคุณสามารถใช้ token ขัดจังหวะเดียวกันเพื่อหยุดลูปก่อนที่จะเริ่มประมวลผลสไลด์ถัดไป

## **Interrupt a Presentation Operation**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), ดึง token ของมันด้วย [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), ส่ง token ไปยัง [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), และส่ง load options ไปยัง [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). เพื่อขอการยกเลิก ให้เรียก [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) บน source การดำเนินการที่สามารถขัดจังหวะได้จะหยุดเมื่อพบคำขอ

ตัวอย่างเริ่มแปลง `sample.pptx` ไปเป็น `sample.ppt` ในงานเบื้องหลัง และขอการยกเลิกหากงานยังทำงานอยู่หลังจาก 10 วินาที หากการแปลงเสร็จเร็วกว่าก่อนหน้านั้น ผลลัพธ์ก็จะสมบูรณ์แล้ว

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Connect Application Cancellation to Aspose.Slides**

หากแอปพลิเคชันของคุณใช้ [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), ให้ใช้ [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) เพื่อส่งต่อคำขอยกเลิกไปยัง [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). ตัวอย่างส่งออก `sample.pptx` เป็น `sample.pdf` ในงานเบื้องหลัง หากการส่งออกยังทำงานอยู่หลังจาก 20 วินาที แอปพลิเคชันจะเรียก [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), ซึ่งจะเรียก callback ที่ลงทะเบียนไว้

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Stop Before Processing the Next Slide**

ใช้ [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) เดียวกันสำหรับการนำเสนอและลูปที่ส่งออกสไลด์ของมัน ตรวจสอบ [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) ก่อนเริ่มการส่งออกแต่ละครั้ง หากผู้เรียกสามารถใช้ผลลัพธ์บางส่วนได้ ให้คืนหมายเลขสไลด์สำหรับการส่งออกที่เสร็จสมบูรณ์อย่างประสบความสำเร็จ

ใช้การนำเสนอชื่อ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ ตัวอย่างขอการยกเลิกทันทีหลังจากบันทึกการส่งออกที่สำเร็จครั้งแรก

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

ตัวอย่างเขียน `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` ลูปจะเห็นคำขอก่อนเริ่มสไลด์ 2 หากการยกเลิกขัดจังหวะ [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ระหว่างการส่งออก บล็อก `catch` จะออกจากลูปก่อนที่โค้ดจะบันทึกสไลด์ปัจจุบันว่าเสร็จสมบูรณ์

หากผู้เรียกต้องการจัดการการยกเลิก ให้แทนที่การตรวจสอบ `if` และ `break` ที่หัวของลูปด้วยการเรียก [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) บน token นอกจากนี้ให้ลบ `try`/`catch` รอบการส่งออก เพื่อให้การยกเลิกระหว่างการบันทึกไปยังผู้เรียกด้วย ตัวอย่างเดียวกันจะพิมพ์เฉพาะ `Starting slide 1` และเขียน `slide-1.pdf` เมื่อต้นของการวนซ้ำครั้งที่สอง ผู้เรียกจะได้รับ [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) ก่อนการส่งออกเริ่มต้น ผู้เรียกจะไม่ได้รับรายการสไลด์ที่เสร็จสมบูรณ์

## **FAQ**

**When should I request cancellation?**

ขอการยกเลิกเมื่อการดำเนินการเกินเวลาที่กำหนดหรือเมื่อแอปพลิเคชันของคุณไม่ต้องการผลลัพธ์ต่อไป

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Source จะอนุญาตให้แอปพลิเคชันของคุณขอการยกเลิก ส่วน token จะให้ Aspose.Slides และแอปพลิเคชันของคุณตรวจสอบคำขอนั้น

**Can I use a [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) with Aspose.Slides?**

ได้ เมื่อ token ของแอปพลิเคชันของคุณส่งสัญญาณการยกเลิก ให้เรียก [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) บน source ที่เชื่อมโยงกับการนำเสนอ

**Which operations can I interrupt?**

คุณสามารถขัดจังหวะการโหลด, การบันทึก, และการเรนเดอร์ได้ ส่ง token ไปยัง [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) ผ่าน [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) การนำเสนอจะตรวจสอบการยกเลิกในการดำเนินการต่อไป เช่น [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)

**Does an operation stop immediately?**

การยกเลิกเป็นการทำงานร่วมกัน การดำเนินการจะตรวจสอบ token อย่างสม่ำเสมอและหยุดเมื่อพบคำขอ

**What happens if I call [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) after an operation finishes?**

การดำเนินการที่เสร็จแล้วจะคงผลลัพธ์เดิมไว้

**Can multiple operations share an [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

ได้ การเรียก [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) จะขอการยกเลิกสำหรับทุกการดำเนินการที่ใช้ token จาก source นั้น ใช้ source แยกต่างหากสำหรับแต่ละการดำเนินการที่ต้องการยกเลิกแยกกัน