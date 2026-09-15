---
title: "Hỗ trợ Thư viện có khả năng ngắt"
type: docs
weight: 120
url: /vi/python-java/support-for-interruptable-library/
keywords:
- thư viện có thể ngắt
- token ngắt
- token hủy
- tác vụ chạy lâu
- ngắt tác vụ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Biến các tác vụ chạy lâu thành có thể hủy với Aspose.Slides cho Python thông qua Java. Ngắt việc render và chuyển đổi cho PowerPoint và OpenDocument một cách an toàn, kèm theo các ví dụ."
---
## **Overview**

Aspose.Slides cung cấp cơ chế xử lý có thể ngắt cho các tác vụ trình chiếu kéo dài, chẳng hạn như giải mã, mã hoá và render. Cơ chế này dựa trên các lớp [InterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/).

Một [InterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontoken/) có thể được gán cho [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/) và truyền vào hàm tạo của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Khi gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/#interrupt), tác vụ kéo dài liên quan sẽ bị ngắt.

## **Interruptible Library**

Aspose.Slides for Python via Java cung cấp các lớp [InterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/). Chúng cho phép bạn ngắt các tác vụ kéo dài như giải mã, mã hoá và render.

- [InterruptionTokenSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/) là nguồn cung cấp token được truyền cho [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Khi [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setInterruptionToken) được gọi và đối tượng [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/) được truyền vào hàm tạo của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), việc gọi [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/#interrupt) sẽ ngắt bất kỳ tác vụ kéo dài nào liên quan tới [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).

Đoạn mã sau minh họa cách ngắt một tác vụ đang chạy:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Chạy hành động trong một luồng riêng.
    time.sleep(10)  # Hết thời gian.
    token_source.interrupt()  # Dừng quá trình chuyển đổi.
```

## **FAQ**

**Mục đích của thư viện ngắt Aspose.Slides là gì?**

Nó cung cấp cơ chế để ngắt các thao tác kéo dài—chẳng hạn như tải, lưu hoặc render các bài thuyết trình—trước khi hoàn thành. Điều này hữu ích khi thời gian xử lý phải được giới hạn hoặc tác vụ không còn cần thiết.

**Sự khác nhau giữa [InterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontoken/) và [InterruptionTokenSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/) là gì?**

- [InterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontoken/) được truyền vào API Aspose.Slides và được kiểm tra trong suốt các thao tác kéo dài.
- [InterruptionTokenSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/) được sử dụng trong mã của bạn để tạo token và kích hoạt ngắt bằng cách gọi [interrupt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Những tác vụ nào có thể bị ngắt?**

Bất kỳ tác vụ Aspose.Slides nào chấp nhận một [InterruptionToken](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontoken/)—chẳng hạn như tải một bài thuyết trình bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) hoặc lưu bằng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save)—có thể bị ngắt.

**Việc ngắt có xảy ra ngay lập tức không?**

Không. Việc ngắt là hợp tác: thao tác sẽ kiểm tra token định kỳ và dừng lại ngay khi phát hiện [interrupt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/#interrupt) đã được gọi.

**Nếu tôi gọi [interrupt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/#interrupt) sau khi một tác vụ đã hoàn thành thì sẽ xảy ra gì?**

Không có gì—lệnh gọi sẽ không ảnh hưởng nếu tác vụ tương ứng đã hoàn thành.

**Tôi có thể tái sử dụng cùng một [InterruptionTokenSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/) cho nhiều tác vụ không?**

Có—nhưng sau khi bạn gọi [interrupt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/interruptiontokensource/#interrupt) trên nguồn đó, tất cả các tác vụ sử dụng token của nó sẽ bị ngắt. Hãy sử dụng các nguồn token riêng biệt để quản lý các tác vụ một cách độc lập.