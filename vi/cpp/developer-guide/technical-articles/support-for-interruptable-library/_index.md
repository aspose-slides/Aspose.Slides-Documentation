---
title: Hỗ trợ Thư viện có khả năng ngắt
type: docs
weight: 150
url: /vi/cpp/support-for-interruptable-library/
keywords:
- thư viện có khả năng ngắt
- token ngắt
- token hủy
- tác vụ chạy dài
- ngắt tác vụ
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Biến các tác vụ chạy dài có thể hủy được với Aspose.Slides cho C++. Ngắt việc kết xuất và chuyển đổi cho PowerPoint và OpenDocument một cách an toàn, kèm theo ví dụ."
---
## **Tổng quan**

Aspose.Slides cung cấp cơ chế xử lý có thể ngắt cho các tác vụ trình chiếu kéo dài, chẳng hạn như giải tuần tự, tuần tự hoá và kết xuất. Cơ chế này dựa trên các lớp `InterruptionToken` và `InterruptionTokenSource`.

`InterruptionToken` có thể được gán cho `LoadOptions` và truyền vào hàm tạo `Presentation`. Khi gọi `InterruptionTokenSource::Interrupt()`, tác vụ kéo dài liên quan sẽ bị ngắt.

## **Thư viện có khả năng ngắt**

Trong [Aspose.Slides 18.4](https://releases.aspose.com/slides/vi/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), chúng tôi đã giới thiệu các lớp [InterruptionToken](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/). Chúng cho phép bạn ngắt các tác vụ kéo dài như giải tuần tự, tuần tự hoá và kết xuất.

- [InterruptionTokenSource](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/) là nguồn của token(s) được truyền cho [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Khi [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_interruptiontoken/) được đặt và đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/) được truyền vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/), việc gọi [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/interrupt/) sẽ ngắt bất kỳ tác vụ kéo dài nào liên quan tới [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).

Đoạn mã sau minh họa việc ngắt một tác vụ đang chạy:

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
    
    Run(action, tokenSource->get_Token()); // chạy hành động trong một luồng riêng
    Threading::Thread::Sleep(10000);       // hết thời gian chờ
    tokenSource->Interrupt();              // dừng quá trình chuyển đổi
}
```

## **Câu hỏi thường gặp**

**Mục đích của thư viện interrupt của Aspose.Slides là gì?**

Nó cung cấp một cơ chế để ngắt các hoạt động kéo dài—như tải, lưu hoặc kết xuất các bản trình chiếu—trước khi hoàn thành. Điều này hữu ích khi thời gian xử lý phải được giới hạn hoặc tác vụ không còn cần thiết.

**Sự khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/) là gì?**

- `InterruptionToken` được truyền vào API Aspose.Slides và được kiểm tra trong suốt các hoạt động kéo dài.  
- `InterruptionTokenSource` được sử dụng trong mã của bạn để tạo token và kích hoạt việc ngắt bằng cách gọi `Interrupt()`.

**Các tác vụ nào có thể bị ngắt?**

Bất kỳ tác vụ nào của Aspose.Slides chấp nhận một [InterruptionToken](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontoken/)—chẳng hạn tải một bản trình chiếu bằng `Presentation(path, loadOptions)` hoặc lưu bằng `Presentation::Save(...)`—có thể bị ngắt.

**Việc ngắt có xảy ra ngay lập tức không?**

Không. Việc ngắt là hợp tác: thao tác sẽ định kỳ kiểm tra token và dừng ngay khi phát hiện rằng [Interrupt()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/interrupt/) đã được gọi.

**Nếu tôi gọi [Interrupt()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/interrupt/) sau khi một tác vụ đã hoàn thành, sẽ xảy ra gì?**

Không có gì—lệnh gọi không có hiệu lực nếu tác vụ tương ứng đã hoàn thành.

**Tôi có thể tái sử dụng cùng một [InterruptionTokenSource](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/) cho nhiều tác vụ không?**

Có—nhưng sau khi bạn gọi [Interrupt()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/interruptiontokensource/interrupt/) trên nguồn đó, mọi tác vụ sử dụng token của nó sẽ bị ngắt. Hãy sử dụng các nguồn token riêng biệt để quản lý các tác vụ một cách độc lập.