---
title: Ngắt các thao tác trên bản trình chiếu chạy lâu trong .NET
linktitle: Ngắt các thao tác trên bản trình chiếu
type: docs
weight: 150
url: /vi/net/support-for-interruptable-library/
keywords:
- các thao tác có thể ngắt
- token ngắt
- token hủy
- công việc chạy lâu
- ngắt công việc
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách hủy các thao tác trên bản trình chiếu chạy lâu trong Aspose.Slides cho .NET và trả về kết quả một phần khi xuất các slide trong vòng lặp."
---
## **Tổng quan**

Aspose.Slides for .NET có thể ngắt các thao tác chạy lâu như tải, lưu và render bản trình chiếu. Ứng dụng của bạn có thể sử dụng cùng một interruption token để dừng một vòng lặp trước khi nó bắt đầu xử lý slide tiếp theo.

## **Ngắt một thao tác trên Bản trình chiếu**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), gán [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) của nó cho [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), và truyền các tùy chọn tải vào [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Để yêu cầu hủy, gọi [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) trên nguồn. Một thao tác có thể ngắt sẽ dừng khi nó phát hiện yêu cầu.

Ví dụ bắt đầu chuyển đổi `sample.pptx` sang `sample.ppt` trong một tác vụ nền và yêu cầu hủy sau 10 giây. Nếu quá trình chuyển đổi hoàn thành sớm hơn, đầu ra đã hoàn tất.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Kết nối hủy .NET với Aspose.Slides**

Nếu ứng dụng của bạn sử dụng .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), chuyển tiếp yêu cầu hủy của nó tới Aspose.Slides. Ví dụ bắt đầu xuất `sample.pptx` sang `sample.pdf` và đặt thời gian chờ 20 giây. Trong khi quá trình xuất đang chạy, nó kiểm tra [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) mỗi 500 miligiây. Khi thuộc tính này trở thành `true`, nó gọi [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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

    while (!task.Wait(500)) // đợi và giám sát xem cancellationToken.IsCancellationRequested đã được đặt hay chưa
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

## **Dừng trước khi xử lý Slide tiếp theo**

Sử dụng cùng một [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) cho cả bản trình chiếu và vòng lặp xuất các slide của nó. Kiểm tra [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) trước khi bắt đầu mỗi lần xuất. Nếu người gọi có thể sử dụng kết quả một phần, hãy trả về các số slide cho các lần xuất đã hoàn thành thành công.

Sử dụng một bản trình chiếu có tên `sample.pptx` với ít nhất hai slide. Ví dụ yêu cầu hủy ngay sau khi ghi nhận lần xuất thành công đầu tiên.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

Ví dụ ghi `slide-1.pdf` và in `Starting slide 1` tiếp theo là `Completed: [1]`. Vòng lặp nhận yêu cầu trước khi bắt đầu slide 2. Nếu việc hủy thay vào đó ngắt [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) trong quá trình xuất, khối `catch` sẽ thoát vòng lặp trước khi mã ghi lại slide hiện tại là đã hoàn thành.

Nếu người gọi cần xử lý hủy, thay thế kiểm tra `if` và `break` ở đầu vòng lặp bằng một lời gọi tới [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) trên token. Loại bỏ khối `try`/`catch` quanh quá trình xuất để việc hủy trong khi lưu cũng được truyền tới người gọi. Với cùng đầu vào, ví dụ chỉ in `Starting slide 1` và ghi `slide-1.pdf`. Khi bắt đầu vòng lặp thứ hai, người gọi nhận được một [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) trước khi quá trình xuất bắt đầu. Phương thức không trả về danh sách nào.

## **FAQ**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi một thao tác vượt quá thời gian giới hạn của bạn hoặc khi ứng dụng của bạn không còn cần kết quả nữa.

**Sự khác nhau giữa [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Nguồn cho phép ứng dụng của bạn yêu cầu hủy. Token cho phép Aspose.Slides và ứng dụng của bạn kiểm tra yêu cầu đó.

**Tôi có thể sử dụng .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) với Aspose.Slides không?**

Có. Khi token .NET của bạn báo hiệu hủy, hãy gọi [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) trên nguồn liên kết với bản trình chiếu.

**Các thao tác nào tôi có thể ngắt?**

Bạn có thể ngắt việc tải, lưu và render. Truyền token vào [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) thông qua [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Bản trình chiếu sau đó có thể nhận biết hủy trong các thao tác tiếp theo như [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Thao tác có dừng ngay lập tức không?**

Việc hủy là hợp tác. Thao tác kiểm tra token định kỳ và dừng khi phát hiện yêu cầu.

**Điều gì xảy ra nếu tôi gọi [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) sau khi một thao tác đã hoàn thành?**

Thao tác đã hoàn thành sẽ giữ kết quả của nó.

**Nhiều thao tác có thể chia sẻ một [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Có. Gọi [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) sẽ yêu cầu hủy cho mọi thao tác sử dụng token từ nguồn đó. Sử dụng một nguồn riêng cho mỗi thao tác mà bạn muốn hủy độc lập.