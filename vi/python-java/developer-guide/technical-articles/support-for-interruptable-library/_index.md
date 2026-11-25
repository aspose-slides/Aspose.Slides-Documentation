---
title: Gián đoạn các thao tác trình chiếu chạy lâu trong Python
linktitle: Gián đoạn Thao tác Trình chiếu
type: docs
weight: 120
url: /vi/python-java/support-for-interruptable-library/
keywords:
- các thao tác có thể gián đoạn
- token gián đoạn
- token hủy
- công việc chạy lâu
- gián đoạn công việc
- PowerPoint
- OpenDocument
- trình chiếu
- Python
- Java
- Aspose.Slides
description: Tìm hiểu cách hủy các thao tác trình chiếu chạy lâu trong Aspose.Slides cho Python thông qua Java và trả về kết quả một phần khi xuất các slide trong vòng lặp.
---
## **Tổng quan**

Aspose.Slides cho Python thông qua Java có thể gián đoạn các hoạt động dài như tải, lưu và render các bài thuyết trình. Ứng dụng của bạn có thể sử dụng cùng một token gián đoạn để dừng một vòng lặp trước khi nó bắt đầu xử lý slide tiếp theo.

## **Gián đoạn một thao tác trên Bản trình chiếu**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), lấy token của nó bằng [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), và truyền token cho [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Đưa các tùy chọn tải vào [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Để yêu cầu hủy, gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) trên nguồn. Một hoạt động có thể gián đoạn sẽ dừng khi nó phát hiện yêu cầu. Sử dụng `jpype.JClass` để bắt ngoại lệ Java `com.aspose.slides.exceptions.OperationCanceledException` trong Python.

Ví dụ chuyển đổi `sample.pptx` sang `sample.ppt` trên một luồng nền. Luồng gọi chờ tối đa 10 giây để quá trình chuyển đổi hoàn thành. Nếu quá trình chuyển đổi vẫn đang chạy, nó yêu cầu hủy và chờ luồng làm việc kết thúc.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Kết nối thời gian chờ Python với Aspose.Slides**

Để đặt giới hạn thời gian cho một thao tác trên bản trình chiếu, sử dụng một [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) để gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) khi thời gian chờ hết. Ví dụ cho phép 20 giây để tải `sample.pptx` và xuất ra `sample.pdf`. Nếu việc xuất kết thúc sớm, ứng dụng sẽ hủy yêu cầu đã lên lịch.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Dừng Trước Khi Xử Lý Slide Tiếp Theo**

Sử dụng cùng một [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) cho bản trình chiếu và vòng lặp xuất các slide của nó. Kiểm tra [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) trước mỗi lần xuất. Nếu người gọi có thể sử dụng kết quả một phần, trả về các số slide cho những lần xuất đã thành công.

Sử dụng một bản trình chiếu tên `sample.pptx` có ít nhất hai slide. Phương thức [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) có tham số nhận một `int[]` Java sử dụng số slide bắt đầu từ 1. Dùng `jpype.JArray(jpype.JInt)` để tạo mảng đó trong Python. Ví dụ lưu mỗi slide thành một PDF riêng và yêu cầu hủy ngay sau khi ghi nhận lần xuất thành công đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Ví dụ ghi `slide-1.pdf` và in ra `Starting slide 1` sau đó là `Completed: [1]`. Vòng lặp phát hiện yêu cầu trước khi bắt đầu slide 2. Nếu hủy đến lúc đang lưu, vòng lặp sẽ thoát trước khi ghi nhận slide đó là hoàn thành.

Nếu người gọi cần xử lý hủy, thay thế việc kiểm tra và `break` ở đầu vòng lặp bằng `token.throwIfInterruptionRequested()`. Bỏ `try`/`except` quanh lệnh lưu để hủy trong quá trình xuất cũng được truyền tới người gọi. Với cùng đầu vào, ví dụ chỉ in `Starting slide 1` và ghi `slide-1.pdf`. Khi bắt đầu vòng lặp thứ hai, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) ném ra `com.aspose.slides.exceptions.OperationCanceledException` trước khi xuất tiếp theo bắt đầu. Ngoại lệ này lan tới người gọi trước khi hàm có thể trả về danh sách.

## **Câu hỏi thường gặp**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi một thao tác vượt quá giới hạn thời gian của bạn hoặc khi ứng dụng không còn cần kết quả nữa.

**Sự khác biệt giữa [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Nguồn cho phép ứng dụng của bạn yêu cầu hủy. Token cho phép Aspose.Slides và ứng dụng của bạn kiểm tra yêu cầu đó.

**Tôi có thể hủy một thao tác bằng bộ hẹn giờ Python không?**

Có. Lên lịch một cuộc gọi tới [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) trên nguồn liên kết với bản trình chiếu.

**Các thao tác nào tôi có thể gián đoạn?**

Bạn có thể gián đoạn việc tải, lưu và render. Truyền token cho [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) qua [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Khi đó bản trình chiếu có thể nhận thấy việc hủy trong các thao tác tiếp theo như lưu ra PDF.

**Một thao tác có dừng ngay lập tức không?**

Hủy là hợp tác. Một thao tác kiểm tra token định kỳ và dừng khi phát hiện yêu cầu.

**Điều gì xảy ra nếu tôi gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) sau khi một thao tác kết thúc?**

Thao tác đã hoàn thành giữ lại kết quả của nó.

**Nhiều thao tác có thể chia sẻ một [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Có. Gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) sẽ yêu cầu hủy cho mọi thao tác sử dụng token từ nguồn đó. Sử dụng một nguồn riêng cho mỗi thao tác mà bạn muốn hủy độc lập.