---
title: Hỗ trợ Thư viện có khả năng ngắt
type: docs
weight: 120
url: /vi/java/support-for-interruptable-library/
keywords:
- thư viện có thể ngắt
- token ngắt
- token hủy
- tác vụ kéo dài
- ngắt tác vụ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Biến các tác vụ chạy lâu thành có thể hủy với Aspose.Slides cho Java. Ngắt việc render và chuyển đổi cho PowerPoint và OpenDocument một cách an toàn, kèm ví dụ."
---
## **Tổng quan**

Aspose.Slides cung cấp cơ chế xử lý có khả năng ngắt cho các tác vụ trình chiếu kéo dài, chẳng hạn như giải mã, mã hoá và render. Cơ chế này dựa trên các lớp `InterruptionToken` và `InterruptionTokenSource`.

`InterruptionToken` có thể được gán cho `LoadOptions` và truyền vào hàm tạo `Presentation`. Khi gọi `InterruptionTokenSource.interrupt()`, tác vụ kéo dài liên quan sẽ bị ngắt.

## **Thư viện có thể ngắt**

Trong [Aspose.Slides 18.4](https://releases.aspose.com/slides/vi/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), chúng tôi đã giới thiệu các lớp [InterruptionToken](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/). Chúng cho phép bạn ngắt các tác vụ kéo dài như giải mã, mã hoá và render.

- [InterruptionTokenSource](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/) là nguồn cung cấp token(s) được truyền cho [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Khi [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) được đặt và thể hiện [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) được truyền vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), việc gọi [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/#interrupt--) sẽ ngắt bất kỳ tác vụ kéo dài nào liên quan đến [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).

Mã mẫu sau cho thấy cách ngắt một tác vụ đang chạy:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // chạy hành động trong một luồng riêng biệt
Thread.sleep(10000);     // thời gian chờ
tokenSource.interrupt(); // dừng quá trình chuyển đổi
```

## **Câu hỏi thường gặp**

**Mục đích của thư viện ngắt Aspose.Slides là gì?**

Nó cung cấp một cơ chế để ngắt các hoạt động kéo dài—chẳng hạn như tải, lưu hoặc render các bài thuyết trình—trước khi chúng hoàn thành. Điều này hữu ích khi thời gian xử lý phải được giới hạn hoặc tác vụ không còn cần thiết.

**Sự khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/) là gì?**

- `InterruptionToken` được truyền vào API Aspose.Slides và được kiểm tra trong suốt các hoạt động kéo dài.  
- `InterruptionTokenSource` được sử dụng trong mã của bạn để tạo token và kích hoạt việc ngắt bằng cách gọi `Interrupt()`.

**Những tác vụ nào có thể bị ngắt?**

Bất kỳ tác vụ nào của Aspose.Slides chấp nhận một [InterruptionToken]—chẳng hạn như tải một bài thuyết trình bằng `Presentation(path, loadOptions)` hoặc lưu bằng `Presentation.save(...)`—có thể bị ngắt.

**Việc ngắt có xảy ra ngay lập tức không?**

Không. Việc ngắt là hợp tác: thao tác sẽ kiểm tra token định kỳ và dừng ngay khi phát hiện rằng [Interrupt()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/#interrupt--) đã được gọi.

**Nếu tôi gọi [Interrupt()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/#interrupt--) sau khi một tác vụ đã hoàn thành thì sẽ xảy ra gì?**

Không có gì—lệnh gọi không có hiệu lực nếu tác vụ tương ứng đã hoàn thành.

**Tôi có thể tái sử dụng cùng một [InterruptionTokenSource](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/) cho nhiều tác vụ không?**

Có—nhưng sau khi bạn gọi [Interrupt()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/interruptiontokensource/#interrupt--) trên nguồn đó, tất cả các tác vụ sử dụng token của nó sẽ bị ngắt. Hãy sử dụng các nguồn token riêng biệt để quản lý các tác vụ một cách độc lập.