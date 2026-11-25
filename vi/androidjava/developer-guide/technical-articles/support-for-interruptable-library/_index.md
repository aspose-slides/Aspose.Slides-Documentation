---
title: Ngắt các thao tác trình chiếu chạy lâu trên Android
linktitle: Ngắt các thao tác trình chiếu
type: docs
weight: 120
url: /vi/androidjava/support-for-interruptable-library/
keywords:
- các thao tác có thể ngắt
- token ngắt
- token hủy
- công việc chạy lâu
- ngắt công việc
- PowerPoint
- OpenDocument
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách hủy các thao tác trình chiếu chạy lâu trong Aspose.Slides cho Android qua Java và trả về kết quả một phần khi xuất các slide trong vòng lặp."
---
## **Tổng quan**

Aspose.Slides for Android via Java có thể ngắt các thao tác chạy lâu như tải, lưu và render bản trình chiếu. Ứng dụng của bạn có thể sử dụng cùng một interruption token để dừng vòng lặp trước khi nó bắt đầu xử lý slide tiếp theo.

## **Ngắt một thao tác Trình chiếu**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), lấy token của nó bằng [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), và truyền token cho [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Truyền các tùy chọn tải vào [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Để yêu cầu hủy, gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) trên nguồn. Một thao tác có thể bị ngắt sẽ dừng khi nó phát hiện yêu cầu.

Ví dụ chuyển đổi `sample.pptx` sang `sample.ppt` trên một luồng nền. Luồng gọi chờ tối đa 10 giây cho việc chuyển đổi hoàn thành. Nếu việc chuyển đổi vẫn đang chạy, nó sẽ yêu cầu hủy và chờ worker kết thúc.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Gọi từ một luồng nền và truyền context.getFilesDir(), nơi chứa sample.pptx.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```

## **Kết nối thời gian chờ Java với Aspose.Slides**

Để đặt giới hạn thời gian cho một thao tác trình chiếu, sử dụng [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) để gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) khi thời gian chờ hết. Ví dụ cho phép 20 giây để tải `sample.pptx` và xuất nó ra `sample.pdf`. Nếu việc xuất kết thúc sớm, ứng dụng sẽ hủy yêu cầu đã lập lịch.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Gọi từ một luồng nền và truyền context.getFilesDir(), nơi chứa sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Dừng trước khi xử lý slide tiếp theo**

Sử dụng cùng một [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) cho bản trình chiếu và vòng lặp xuất các slide của nó. Kiểm tra [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) trước mỗi lần xuất. Nếu người gọi có thể sử dụng kết quả một phần, trả về các số slide cho các lần xuất đã hoàn thành thành công.

Sử dụng một bản trình chiếu tên `sample.pptx` có ít nhất hai slide. Phần overload của [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) nhận một mảng số slide bắt đầu từ 1. Ví dụ lưu mỗi slide thành một PDF riêng và yêu cầu hủy ngay sau khi ghi nhận lần xuất đầu tiên thành công.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Gọi từ một luồng nền và truyền context.getFilesDir(), nơi chứa sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Ví dụ ghi `slide-1.pdf` và in `Starting slide 1` tiếp theo là `Completed: [1]`. Vòng lặp nhận thấy yêu cầu trước khi bắt đầu slide 2. Nếu hủy đến trong quá trình lưu, vòng lặp sẽ thoát trước khi ghi nhận slide đó là hoàn thành.

Nếu người gọi cần xử lý hủy, thay thế việc kiểm tra và lệnh `break` ở đầu vòng lặp bằng `token.throwIfInterruptionRequested()`. Loại bỏ `try`/`catch` quanh lệnh lưu để việc hủy trong quá trình xuất cũng được truyền tới người gọi. Với cùng đầu vào, ví dụ chỉ in `Starting slide 1` và ghi `slide-1.pdf`. Khi bắt đầu lần lặp thứ hai, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) ném `com.aspose.slides.exceptions.OperationCanceledException` trước khi lần xuất tiếp theo bắt đầu. Phương thức không trả về danh sách nào.

## **FAQ**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi một thao tác vượt quá thời gian giới hạn của bạn hoặc khi ứng dụng của bạn không còn cần kết quả nữa.

**Sự khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Nguồn cho phép ứng dụng của bạn yêu cầu hủy. Token cho phép Aspose.Slides và ứng dụng của bạn kiểm tra yêu cầu đó.

**Tôi có thể hủy một thao tác từ bộ hẹn giờ Java không?**

Có. Lên lịch gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) trên nguồn liên kết với bản trình chiếu.

**Tôi có thể ngắt những thao tác nào?**

Bạn có thể ngắt việc tải, lưu và render. Truyền token cho [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) thông qua [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Bản trình chiếu sau đó có thể nhận thấy việc hủy trong các thao tác tiếp theo như lưu dưới dạng PDF.

**Thao tác có dừng ngay lập tức không?**

Việc hủy là hợp tác. Một thao tác kiểm tra token định kỳ và dừng khi nó nhận thấy yêu cầu.

**Điều gì xảy ra nếu tôi gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) sau khi một thao tác hoàn thành?**

Thao tác đã hoàn thành sẽ giữ kết quả của nó.

**Có một nguồn [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) có thể được nhiều thao tác chia sẻ không?**

Có. Gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) yêu cầu hủy cho mọi thao tác sử dụng token từ nguồn đó. Sử dụng một nguồn riêng cho mỗi thao tác bạn muốn hủy một cách độc lập.