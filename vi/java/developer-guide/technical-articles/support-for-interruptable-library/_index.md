---
title: Ngắt các hoạt động trình chiếu chạy lâu trong Java
linktitle: Ngắt các hoạt động trình chiếu
type: docs
weight: 120
url: /vi/java/support-for-interruptable-library/
keywords:
- các hoạt động có thể ngắt
- token ngắt
- token hủy
- tác vụ chạy lâu
- ngắt tác vụ
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách hủy các hoạt động trình chiếu chạy lâu trong Aspose.Slides cho Java và trả về kết quả một phần khi xuất các slide trong vòng lặp."
---
## **Tổng quan**

Aspose.Slides for Java có thể ngắt các hoạt động chạy lâu như tải, lưu và render bản trình chiếu. Ứng dụng của bạn có thể sử dụng cùng một token ngắt để dừng một vòng lặp trước khi nó bắt đầu xử lý slide tiếp theo.

## **Ngắt một hoạt động trình chiếu**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), lấy token bằng [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), và truyền token cho [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Truyền các tùy chọn tải vào [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Để yêu cầu hủy, gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) trên nguồn. Một hoạt động có khả năng ngắt sẽ dừng khi nó nhận thấy yêu cầu.

Ví dụ chuyển đổi `sample.pptx` sang `sample.ppt` trên một luồng nền. Luồng gọi đợi tối đa 10 giây cho quá trình chuyển đổi hoàn thành. Nếu việc chuyển đổi vẫn đang chạy, nó yêu cầu hủy và đợi luồng công nhân thoát.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Kết nối thời gian chờ Java với Aspose.Slides**

Để đặt giới hạn thời gian cho một hoạt động trình chiếu, sử dụng một [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) để gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) khi thời gian chờ hết. Ví dụ cho phép 20 giây để tải `sample.pptx` và xuất nó ra `sample.pdf`. Nếu việc xuất hoàn thành sớm, ứng dụng sẽ hủy yêu cầu đã lên lịch.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Dừng trước khi xử lý slide tiếp theo**

Sử dụng cùng một [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) cho trình chiếu và vòng lặp xuất các slide của nó. Kiểm tra [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) trước mỗi lần xuất. Nếu người gọi có thể sử dụng kết quả một phần, trả về các số slide cho những lần xuất thành công.

Sử dụng một trình chiếu có tên `sample.pptx` với ít nhất hai slide. Phiên bản tải chồng của [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) nhận một mảng số slide tính từ 1. Ví dụ lưu mỗi slide thành một file PDF riêng và yêu cầu hủy ngay sau khi ghi nhận lần xuất thành công đầu tiên.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

Ví dụ ghi `slide-1.pdf` và in ra `Starting slide 1` tiếp theo là `Completed: [1]`. Vòng lặp nhận thấy yêu cầu trước khi bắt đầu slide 2. Nếu việc hủy tới trong quá trình lưu, vòng lặp sẽ thoát trước khi ghi nhận slide đó là đã hoàn thành.

Nếu người gọi cần xử lý việc hủy, thay thế việc kiểm tra và lệnh `break` ở đầu vòng lặp bằng `token.throwIfInterruptionRequested()`. Xóa phần `try`/`catch` quanh lệnh lưu để việc hủy trong quá trình xuất cũng được truyền tới người gọi. Với cùng dữ liệu đầu vào, ví dụ chỉ in `Starting slide 1` và ghi `slide-1.pdf`. Khi bắt đầu vòng lặp thứ hai, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) ném `com.aspose.slides.exceptions.OperationCanceledException` trước khi xuất tiếp theo bắt đầu. Phương thức không trả về danh sách nào.

## **FAQ**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi một hoạt động vượt quá giới hạn thời gian của bạn hoặc khi ứng dụng của bạn không còn cần kết quả nữa.

**Khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) là gì?**

Nguồn cho phép ứng dụng của bạn yêu cầu hủy. Token cho phép Aspose.Slides và ứng dụng của bạn kiểm tra yêu cầu đó.

**Bạn có thể hủy một hoạt động từ bộ hẹn giờ Java không?**

Có. Lên lịch một cuộc gọi tới [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) trên nguồn liên kết với trình chiếu.

**Bạn có thể ngắt những hoạt động nào?**

Bạn có thể ngắt việc tải, lưu và render. Truyền token cho [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) qua [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Trình chiếu sau đó có thể quan sát việc hủy trong các hoạt động tiếp theo như lưu sang PDF.

**Hoạt động có dừng ngay lập tức không?**

Việc hủy là hợp tác. Một hoạt động kiểm tra token định kỳ và dừng khi nó nhận thấy yêu cầu.

**Điều gì xảy ra nếu tôi gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) sau khi một hoạt động đã hoàn thành?**

Hoạt động đã hoàn thành vẫn giữ kết quả của nó.

**Nhiều hoạt động có thể chia sẻ một [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) không?**

Có. Gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) yêu cầu hủy cho mọi hoạt động sử dụng token từ nguồn đó. Sử dụng nguồn riêng cho mỗi hoạt động bạn muốn hủy độc lập.