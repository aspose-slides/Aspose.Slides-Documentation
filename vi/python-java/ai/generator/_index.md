---
title: Trình tạo Slide Đa ngôn ngữ có AI
linktitle: Trình tạo có AI
type: docs
weight: 40
url: /vi/python-java/ai/generator/
keywords:
- bản trình bày đa ngôn ngữ
- slide đa ngôn ngữ
- trình tạo bản trình bày AI
- trình tạo slide AI
- mẫu bản trình bày
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Tạo các bản trình bày đa ngôn ngữ từ văn bản bằng Aspose.Slides cho Python qua Java. Chọn mức độ chi tiết nội dung, áp dụng mẫu và xuất ra PowerPoint hoặc PDF."
---
## **Giới thiệu**

Trình tạo Bản trình bày AI trong Aspose.Slides cho Python qua Java tạo các bản trình bày từ mô tả chủ đề, tóm tắt, trích dẫn hoặc các điểm danh sách. Chỉ định ngôn ngữ yêu cầu trong lời nhắc của bạn, chọn lượng nội dung và tùy chọn cung cấp một mẫu bản trình bày để định nghĩa bố cục và thiết kế.

Trình tạo cấu trúc nội dung bằng các khối văn bản, danh sách dấu đầu dòng và bảng. Nó không tạo ra hình ảnh; bạn có thể thêm chúng vào bản trình bày đã tạo sau này. Kiểm tra nội dung và bố cục đã tạo trước khi chia sẻ bản trình bày.

## **Cách hoạt động**

[SlidesAIAgent](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesaiagent/) sử dụng một khách hàng AI để giao tiếp với mô hình bên ngoài. Các ví dụ dưới đây sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-java/aspose.slides/openaiwebclient/). Aspose.Slides xử lý các phản hồi của mô hình và xây dựng một bản trình bày mà bạn có thể chỉnh sửa hoặc xuất.

Sử dụng [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesaiagent/#generatePresentation) với mô tả văn bản và một giá trị [PresentationContentAmountType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationcontentamounttype/). Phiên bản tải đồng thời với đối số thứ ba chấp nhận một bản trình bày để sử dụng làm mẫu thiết kế.

## **Yêu cầu trước**

Thực hiện theo [Installation](/slides/vi/python-java/installation/) để cấu hình Python, Java, JPype và Aspose.Slides. Đặt các biến môi trường `OPENAI_API_KEY` và `OPENAI_MODEL` trước khi chạy các ví dụ. Chọn một mô hình được hỗ trợ bởi khách hàng tích hợp và có sẵn cho tài khoản API của bạn.

{{% alert color="info" title="Note" %}}
Dịch vụ AI yêu cầu kết nối internet và quyền truy cập API riêng. Các lời nhắc được gửi tới dịch vụ đã cấu hình, và chi phí sử dụng của nó áp dụng độc lập với giấy phép Aspose.Slides của bạn.
{{% /alert %}}

Mỗi ví dụ khởi động JVM chỉ khi nó chưa đang chạy và để nó khả dụng cho các thao tác tiếp theo. Xem [JVM lifecycle guidance](/slides/vi/python-java/limitations-and-api-differences/#import-the-library) khi điều chỉnh mã cho sổ ghi chú.

## **Tạo bản trình bày từ văn bản**

Ví dụ này tạo một bản trình bày tiếng Anh với lượng nội dung [Medium](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationcontentamounttype/#Medium) và lưu nó dưới dạng tệp PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Tạo bản trình bày bằng mẫu**

Đặt `masterPresentation.pptx` trong thư mục làm việc. Ví dụ này tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), tạo một bản trình bày tiếng Tây Ban Nha với nội dung [Detailed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationcontentamounttype/#Detailed), và xuất nó ra PDF. Cả mẫu và bản trình bày đã tạo đều được giải phóng, ngay cả khi quá trình tạo hoặc lưu thất bại.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Nếu bạn cần cấu hình proxy hoặc thời gian chờ kết nối, hãy xem [Configure the HTTP Connection](/slides/vi/python-java/ai/translator/#configure-the-http-connection). Bạn cũng có thể truyền khách hàng đã tạo cho trình tạo.

## **Lợi ích chính**

Việc tạo có thể giảm công việc soạn thảo ban đầu cho tài liệu đào tạo, tổng quan sản phẩm, báo cáo khách hàng và các bản trình bày nội bộ. Các lời nhắc kiểm soát chủ đề và ngôn ngữ, trong khi mẫu cho phép bạn tái sử dụng thiết kế bản trình bày hiện có.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi kiểm soát độ dài của bản trình bày được tạo?**

Chọn [Brief](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationcontentamounttype/#Medium), hoặc [Detailed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Các thiết lập này ảnh hưởng đến cả số lượng slide và mức độ chi tiết trên mỗi slide; chúng không chỉ định số slide chính xác.

**Tôi có thể tạo slide bằng ngôn ngữ khác không?**

Có. Bao gồm ngôn ngữ yêu cầu trong mô tả văn bản. Kết quả phụ thuộc vào khả năng ngôn ngữ của mô hình được chọn.

**Tôi có thể giữ phiên bản có thể chỉnh sửa khi xuất ra PDF không?**

Có. Trước khi giải phóng bản trình bày đã tạo, hãy cũng lưu nó dưới dạng PPTX bằng cách sử dụng phương pháp trong ví dụ đầu tiên.