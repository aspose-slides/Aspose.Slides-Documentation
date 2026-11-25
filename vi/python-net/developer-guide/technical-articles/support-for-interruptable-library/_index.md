---
title: Gián đoạn các thao tác chạy lâu của bản trình chiếu trong Python
linktitle: Gián đoạn các thao tác trình chiếu
type: docs
weight: 150
url: /vi/python-net/support-for-interruptable-library/
keywords:
- các thao tác có thể gián đoạn
- token gián đoạn
- hủy xuất PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Tìm hiểu cách hủy chuyển đổi bản trình chiếu trong Python và trả về danh sách các slide đã hoàn thành xuất trước khi hủy."
---
## **Tổng quan**

Aspose.Slides for Python via .NET hỗ trợ hủy bỏ hợp tác trong các thao tác kéo dài như tải, lưu và kết xuất bản trình chiếu. Khi bạn xuất các slide riêng lẻ, bạn cũng có thể kiểm tra hủy bỏ giữa các slide và trả về số thứ tự của các slide đã hoàn thành xuất.

## **Hủy chuyển đổi Bản trình chiếu**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), assign its [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) to [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), and pass the options to the [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). The token applies to the presentation throughout its lifetime. To request cancellation from your application, call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Tạo một InterruptionTokenSource, gán token của nó cho LoadOptions.interruption_token và truyền các tùy chọn vào constructor của Presentation. Token này áp dụng cho bản trình chiếu trong suốt vòng đời của nó. Để yêu cầu hủy bỏ từ ứng dụng của bạn, gọi InterruptionTokenSource.interrupt.

The example converts `sample.pptx` to `sample.pdf`. A [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) calls `source.interrupt` after 20 seconds. Starting the timer before opening the file makes the timeout apply to both loading and saving. An application with a Cancel button can call the same method from its event handler.

Ví dụ chuyển đổi `sample.pptx` sang `sample.pdf`. Một threading.Timer gọi `source.interrupt` sau 20 giây. Bắt đầu timer trước khi mở tệp làm cho thời gian chờ áp dụng cho cả việc tải và lưu. Một ứng dụng có nút Cancel có thể gọi cùng một phương thức từ trình xử lý sự kiện của nó.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

The explicit check after loading skips the export if the timeout has already elapsed. If loading or saving observes the request, the cancellation exception reaches the caller. A save can also finish before it observes the request, in which case the PDF is complete.

Kiểm tra rõ ràng sau khi tải sẽ bỏ qua việc xuất nếu thời gian chờ đã hết. Nếu quá trình tải hoặc lưu phát hiện yêu cầu, ngoại lệ hủy bỏ sẽ đến người gọi. Một quá trình lưu cũng có thể hoàn thành trước khi phát hiện yêu cầu, trong trường hợp đó PDF sẽ hoàn chỉnh.

## **Dừng lại trước khi xử lý Slide tiếp theo**

Check [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) before each export. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) accepts a list of slide numbers starting at 1. Add a number to the completed list only after its PDF has been saved successfully.

Kiểm tra InterruptionToken.is_interruption_requested trước mỗi lần xuất. Presentation.save chấp nhận một danh sách các số slide bắt đầu từ 1. Thêm một số vào danh sách đã hoàn thành chỉ sau khi PDF của nó đã được lưu thành công.

Use a file named `sample.pptx` with at least two slides. To make the result reproducible, the example requests cancellation as soon as slide 1 finishes. In an application, the request can come from another thread while a slide is being saved.

Sử dụng tệp có tên `sample.pptx` với ít nhất hai slide. Để kết quả có thể tái tạo, ví dụ yêu cầu hủy bỏ ngay khi slide 1 hoàn thành. Trong một ứng dụng, yêu cầu có thể đến từ một luồng khác trong khi slide đang được lưu.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The next iteration sees the request before starting slide 2. If cancellation interrupts a save, the exception handler returns the numbers recorded by earlier iterations. Other export errors reach the caller.

Ví dụ ghi `slide-1.pdf` và in `Starting slide 1` tiếp theo là `Completed: [1]`. Vòng lặp tiếp theo nhận được yêu cầu trước khi bắt đầu slide 2. Nếu hủy bỏ làm gián đoạn quá trình lưu, bộ xử lý ngoại lệ sẽ trả về các số được ghi lại bởi các vòng lặp trước. Các lỗi xuất khác sẽ đến người gọi.

If the caller should handle cancellation as an exception, replace the check and its `break` at the top of the loop with [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Also remove the `try`/`except` around the save. With the same input, slide 1 is saved and the second iteration raises a cancellation exception before starting slide 2.

Nếu người gọi muốn xử lý hủy bỏ dưới dạng ngoại lệ, thay thế việc kiểm tra và `break` ở đầu vòng lặp bằng token.throw_if_interruption_requested. Đồng thời loại bỏ `try`/`except` quanh lệnh lưu. Với cùng đầu vào, slide 1 sẽ được lưu và vòng lặp thứ hai sẽ ném ngoại lệ hủy bỏ trước khi bắt đầu slide 2.

## **FAQ**

**Khi nào yêu cầu hủy bỏ có hiệu lực?**

Một hoạt động có thể bị ngắt sẽ kiểm tra token định kỳ. Nó dừng lại khi phát hiện yêu cầu. Một hoạt động đã hoàn thành sẽ giữ lại kết quả của nó.

**Khác biệt giữa source và token là gì?**

Source cho phép ứng dụng của bạn yêu cầu hủy bỏ. Token cho phép cả bản trình chiếu và mã của bạn kiểm tra yêu cầu đó.

**Nhiều hoạt động có thể chia sẻ một source không?**

Có. Gọi `interrupt` sẽ yêu cầu hủy bỏ cho mọi hoạt động sử dụng token từ source đó. Cung cấp cho mỗi hoạt động một source riêng nếu bạn cần hủy chúng một cách độc lập.