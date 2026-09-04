---
title: Trình Dịch Bản Trình Chiếu Bằng AI
linktitle: Trình Dịch Bằng AI
type: docs
weight: 20
url: /vi/python-java/ai/translator/
keywords:
- Trình dịch bản trình chiếu AI
- Trình dịch slide AI
- Bản trình chiếu đa ngôn ngữ
- Dịch bản trình chiếu
- Dịch slide
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Dịch các bản trình chiếu bằng AI sử dụng Aspose.Slides cho Python qua Java. Địa phương hoá văn bản slide và lưu bản trình chiếu đã dịch dưới dạng PowerPoint hoặc PDF."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cung cấp API Dịch Bản Trình Chiếu AI để địa phương hoá nội dung slide. Dịch một bản trình chiếu hiện có sang ngôn ngữ được chỉ định, sau đó lưu phiên bản đã dịch ở định dạng mà khán giả của bạn cần.

## **Cách hoạt động**

[SlidesAIAgent](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesaiagent/) giao tiếp với dịch vụ AI bên ngoài thông qua một client AI. Các ví dụ sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-java/aspose.slides/openaiwebclient/) tích hợp sẵn.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesaiagent/#translate) cập nhật bản trình chiếu được truyền vào. Aspose.Slides xử lý các phản hồi AI và thay thế văn bản slide trong khi giữ nguyên bố cục và định dạng hiện có. Xem lại kết quả: văn bản đã dịch có thể dài hơn bản gốc và yêu cầu điều chỉnh bố cục.

## **Điều kiện tiên quyết**

Thực hiện theo [Installation](/slides/vi/python-java/installation/) để cấu hình thư viện và môi trường chạy. Đặt các biến môi trường `OPENAI_API_KEY` và `OPENAI_MODEL` trước khi chạy các ví dụ. Chọn một mô hình được hỗ trợ bởi client tích hợp và có sẵn cho tài khoản API của bạn.

{{% alert color="info" title="Lưu ý" %}}
Việc dịch yêu cầu kết nối internet và gửi văn bản bản trình chiếu tới dịch vụ AI đã cấu hình. Quyền truy cập API và phí sử dụng của nó độc lập với giấy phép Aspose.Slides của bạn.
{{% /alert %}}

Các ví dụ tái sử dụng một JVM đang hoạt động hoặc khởi động nó nếu cần. Xem [JVM lifecycle guidance](/slides/vi/python-java/limitations-and-api-differences/#import-the-library) để biết hướng dẫn sử dụng trong notebook.

## **Dịch một bản trình chiếu**

Đặt `sample.pptx` trong thư mục làm việc. Ví dụ này tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), dịch văn bản sang tiếng Nhật và lưu kết quả dưới dạng PDF. Nó giải phóng bản trình chiếu và đóng client AI ngay cả khi một thao tác thất bại.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Cấu hình kết nối HTTP**

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-java/aspose.slides/openaiwebclient/) quản lý kết nối HTTP nội bộ. Constructor với bốn đối số của nó cũng chấp nhận một [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) Java được quản lý bên ngoài. Sử dụng overload này khi bạn cần cấu hình proxy hoặc thời gian chờ kết nối.

Ví dụ sau tạo một proxy HTTP Java bằng [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) và mở kết nối qua [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Thay thế `proxy.example.com` và cổng bằng cài đặt proxy của bạn. Kết nối được truyền trực tiếp qua JPype; một phiên HTTP Python không thể được sử dụng thay thế.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Lợi ích chính**

Dịch tự động giúp chuẩn bị tài liệu đào tạo đa ngôn ngữ, bản trình chiếu sản phẩm và báo cáo khách hàng trong khi tái sử dụng thiết kế slide hiện có. Lưu một bản trình chiếu có thể chỉnh sửa để xem xét thêm hoặc xuất PDF để phân phối.

## **Câu hỏi thường gặp**

**Dịch có tạo một đối tượng bản trình chiếu riêng không?**

Không. [SlidesAIAgent.translate](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesaiagent/#translate) sửa đổi bản trình chiếu được cung cấp. Lưu nó dưới một tên tệp mới để giữ nguyên tệp gốc.

**Làm sao tôi chỉ định ngôn ngữ đích?**

Truyền tên ngôn ngữ, chẳng hạn `"Japanese"` hoặc `"Spanish"`, làm đối số thứ hai. Chất lượng dịch và phạm vi ngôn ngữ phụ thuộc vào mô hình đã chọn.

**Tôi có thể dịch mà không sử dụng proxy không?**

Có. Sử dụng constructor client ba đối số được hiển thị trong ví dụ đầu tiên. Ví dụ kết nối tùy chỉnh chỉ cần thiết khi ứng dụng của bạn yêu cầu cấu hình kết nối rõ ràng.