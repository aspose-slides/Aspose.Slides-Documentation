---
title: Ngắt các thao tác trình chiếu dài hạn trong C++
linktitle: Ngắt các thao tác trình chiếu
type: docs
weight: 150
url: /vi/cpp/support-for-interruptable-library/
keywords:
- các thao tác có thể ngắt
- token ngắt
- token hủy
- tác vụ chạy lâu
- ngắt tác vụ
- PowerPoint
- OpenDocument
- trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách hủy các thao tác trình chiếu chạy lâu trong Aspose.Slides cho C++ và trả về kết quả một phần khi xuất các slide trong vòng lặp."
---
## **Tổng quan**

Aspose.Slides cho C++ có thể ngắt các thao tác chạy lâu như tải, lưu và dựng trình chiếu. Ứng dụng của bạn có thể sử dụng cùng một interruption token để dừng vòng lặp trước khi nó bắt đầu xử lý slide tiếp theo.

## **Ngắt một thao tác trên bài thuyết trình**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), lấy token của nó bằng [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), truyền token vào [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), và truyền các tùy chọn tải vào [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Để yêu cầu hủy, gọi [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) trên nguồn. Một thao tác có thể ngắt sẽ dừng khi nó quan sát được yêu cầu.

Ví dụ bắt đầu chuyển đổi `sample.pptx` sang `sample.ppt` trong một tác vụ nền và yêu cầu hủy nếu tác vụ vẫn đang chạy sau 10 giây. Nếu việc chuyển đổi hoàn thành sớm hơn, kết quả đầu ra đã có sẵn.

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

## **Kết nối việc hủy của ứng dụng với Aspose.Slides**

Nếu ứng dụng của bạn sử dụng một [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), dùng [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) để chuyển tiếp yêu cầu hủy tới [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). Ví dụ xuất `sample.pptx` sang `sample.pdf` trong một tác vụ nền. Nếu quá trình xuất vẫn đang chạy sau 20 giây, ứng dụng gọi [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), điều này sẽ kích hoạt callback đã đăng ký.

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

## **Dừng trước khi xử lý Slide tiếp theo**

Sử dụng cùng một [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) cho cả bài thuyết trình và vòng lặp xuất các slide của nó. Kiểm tra [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) trước khi bắt đầu mỗi lần xuất. Nếu người gọi có thể chấp nhận kết quả một phần, hãy trả về các số slide cho các lần xuất đã hoàn thành thành công.

Sử dụng một bài thuyết trình có tên `sample.pptx` chứa ít nhất hai slide. Ví dụ yêu cầu hủy ngay sau khi ghi nhận lần xuất thành công đầu tiên.

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

Ví dụ ghi `slide-1.pdf` và in `Starting slide 1` tiếp theo là `Completed: [1]`. Vòng lặp thấy yêu cầu trước khi bắt đầu slide 2. Nếu việc hủy thay vì đó ngắt [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) trong quá trình xuất, khối `catch` sẽ thoát khỏi vòng lặp trước khi mã ghi lại slide hiện tại là đã hoàn thành.

Nếu người gọi cần xử lý hủy, thay thế kiểm tra `if` và lệnh `break` ở đầu vòng lặp bằng một lời gọi tới [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) trên token. Loại bỏ khối `try`/`catch` quanh quá trình xuất để việc hủy trong khi lưu cũng tới được người gọi. Với cùng đầu vào, ví dụ chỉ in `Starting slide 1` và ghi `slide-1.pdf`. Khi bắt đầu vòng lặp thứ hai, người gọi nhận được một [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) trước khi quá trình xuất bắt đầu. Người gọi sẽ không nhận được danh sách các slide đã hoàn thành.

## **FAQ**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi một thao tác vượt quá thời gian giới hạn của bạn hoặc khi ứng dụng không còn cần kết quả nữa.

**Sự khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) là gì?**

Nguồn cho phép ứng dụng của bạn yêu cầu hủy. Token cho phép Aspose.Slides và ứng dụng của bạn kiểm tra yêu cầu đó.

**Tôi có thể sử dụng một [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) với Aspose.Slides không?**

Có. Khi token của ứng dụng tín hiệu hủy, hãy gọi [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) trên nguồn được liên kết với bài thuyết trình.

**Những thao tác nào tôi có thể ngắt?**

Bạn có thể ngắt việc tải, lưu và dựng. Truyền token vào [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) thông qua [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Khi đó bài thuyết trình có thể quan sát việc hủy trong các thao tác sau như [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Thao tác có dừng ngay lập tức không?**

Hủy là hợp tác. Một thao tác kiểm tra token theo chu kỳ và dừng khi nó nhận được yêu cầu.

**Điều gì xảy ra nếu tôi gọi [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sau khi một thao tác đã hoàn thành?**

Thao tác đã hoàn thành giữ nguyên kết quả của nó.

**Nhiều thao tác có thể chia sẻ một [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) không?**

Có. Gọi [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sẽ yêu cầu hủy cho mọi thao tác sử dụng token từ nguồn đó. Hãy sử dụng một nguồn riêng cho mỗi thao tác nếu bạn muốn hủy chúng một cách độc lập.