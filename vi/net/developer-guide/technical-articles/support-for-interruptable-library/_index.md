---
title: Hỗ trợ Thư viện có thể ngắt
type: docs
weight: 150
url: /vi/net/support-for-interruptable-library/
keywords:
- thư viện có thể ngắt
- token ngắt
- token hủy
- tác vụ chạy lâu
- ngắt tác vụ
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Biến các tác vụ chạy lâu có thể hủy với Aspose.Slides cho .NET. Ngắt việc render và chuyển đổi cho PowerPoint và OpenDocument một cách an toàn, kèm theo các ví dụ."
---
## **Tổng quan**

Aspose.Slides cho .NET cung cấp cơ chế xử lý có thể ngắt cho các tác vụ trình chiếu chạy lâu, chẳng hạn như giải tuần tự hoá, tuần tự hoá và render. Cơ chế này dựa trên các lớp `InterruptionToken` và `InterruptionTokenSource`.

Một `InterruptionToken` có thể được gán cho `LoadOptions` và truyền vào hàm tạo `Presentation`. Khi gọi `InterruptionTokenSource.Interrupt()`, tác vụ chạy lâu liên quan sẽ bị ngắt. Bài viết cũng chỉ ra cách sử dụng cơ chế này cùng với `CancellationToken` chuẩn của .NET bằng cách theo dõi yêu cầu hủy và gọi `Interrupt()` khi có yêu cầu hủy.

## **Thư viện có khả năng ngắt**

Trong [Aspose.Slides 18.4](https://releases.aspose.com/slides/vi/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), chúng tôi đã giới thiệu các lớp [InterruptionToken](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontokensource/). Chúng cho phép bạn ngắt các tác vụ chạy lâu như giải tuần tự hoá, tuần tự hoá và render.

- [InterruptionTokenSource](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontokensource/) là nguồn tạo token được truyền cho [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/vi/net/aspose.slides/iloadoptions/interruptiontoken/).
- Khi [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/vi/net/aspose.slides/iloadoptions/interruptiontoken/) được thiết lập và đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/) được truyền vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), việc gọi [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontokensource/interrupt/) sẽ ngắt bất kỳ tác vụ chạy lâu nào liên quan tới [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).

Đoạn mã dưới đây minh họa cách ngắt một tác vụ đang chạy:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // chạy hành động trong một luồng riêng
    Thread.Sleep(10000);            // hết thời gian chờ
    tokenSource.Interrupt();        // dừng quá trình chuyển đổi
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken và Thư viện có khả năng ngắt**

Khi bạn cần sử dụng một [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) cùng với thư viện Aspose.Slides có khả năng ngắt, hãy bao bọc quá trình xử lý của [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và ngắt [InterruptionToken](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontoken/) khi [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) là `true`.

Mã C# dưới đây trình bày cách thực hiện:

```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // chạy hành động trong một luồng riêng

    while (!task.Wait(500)) // đợi và giám sát xem cancellationToken.IsCancellationRequested đã được đặt chưa
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // ngắt quá trình xử lý Presentation
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **Câu hỏi thường gặp**

**Mục đích của thư viện ngắt Aspose.Slides là gì?**

Nó cung cấp cơ chế để ngắt các thao tác chạy lâu—như tải, lưu hoặc render các bản trình chiếu—trước khi chúng hoàn thành. Điều này hữu ích khi thời gian xử lý cần được giới hạn hoặc tác vụ không còn cần thiết.

**Sự khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/net/aspose.slides/iinterruptiontokensource/) là gì?**

- `InterruptionToken` được truyền vào API Aspose.Slides và được kiểm tra trong các thao tác chạy lâu.
- `InterruptionTokenSource` được sử dụng trong mã của bạn để tạo token và kích hoạt việc ngắt bằng cách gọi `Interrupt()`.

**Tôi có thể dùng .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) với thư viện ngắt không?**

Có. Bạn có thể theo dõi [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) trong logic ứng dụng và gọi [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/vi/net/aspose.slides/iinterruptiontokensource/interrupt/) khi có yêu cầu hủy. Điều này cho phép Aspose.Slides tích hợp với quy trình hủy chuẩn của .NET.

**Những tác vụ nào có thể bị ngắt?**

Bất kỳ tác vụ nào của Aspose.Slides chấp nhận một [InterruptionToken](https://reference.aspose.com/slides/vi/net/aspose.slides/interruptiontoken/)—chẳng hạn như tải một bản trình chiếu bằng `Presentation(path, loadOptions)` hoặc lưu bằng `Presentation.Save(...)`—có thể bị ngắt.

**Việc ngắt có xảy ra ngay lập tức không?**

Không. Việc ngắt là hợp tác: thao tác sẽ kiểm tra token định kỳ và dừng lại ngay khi phát hiện rằng [Interrupt()](https://reference.aspose.com/slides/vi/net/aspose.slides/iinterruptiontokensource/interrupt/) đã được gọi.

**Nếu tôi gọi [Interrupt()](https://reference.aspose.com/slides/vi/net/aspose.slides/iinterruptiontokensource/interrupt/) sau khi một tác vụ đã hoàn thành thì sao?**

Không có gì xảy ra—lệnh gọi không có hiệu lực nếu tác vụ tương ứng đã hoàn thành.

**Tôi có thể tái sử dụng cùng một [InterruptionTokenSource](https://reference.aspose.com/slides/vi/net/aspose.slides/iinterruptiontokensource/) cho nhiều tác vụ không?**

Có—nhưng sau khi bạn gọi [Interrupt()](https://reference.aspose.com/slides/vi/net/aspose.slides/iinterruptiontokensource/interrupt/) trên nguồn đó, tất cả các tác vụ sử dụng token của nó sẽ bị ngắt. Hãy sử dụng các nguồn token riêng biệt để quản lý các tác vụ một cách độc lập.