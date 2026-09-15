---
title: Trình dịch Bài thuyết trình dựa trên AI
linktitle: Trình dịch dựa trên AI
type: docs
weight: 20
url: /vi/python-net/ai/translator/
keywords:
- Trình dịch bài thuyết trình AI
- Trình dịch slide AI
- Tính năng sử dụng AI
- Bài thuyết trình đa ngôn ngữ
- Slide đa ngôn ngữ
- Dịch bài thuyết trình
- Dịch slide
- Tính năng dựa trên AI
- Khả năng AI
- Đại lý AI
- Máy khách Web
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Dịch slide PowerPoint bằng AI sử dụng Aspose.Slides cho Python. Địa phương hoá PPT, PPTX và ODP trong khi giữ nguyên bố cục—nhanh và thân thiện với nhà phát triển. Hãy thử."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bản trình bày PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi các slide, nó còn cung cấp các tính năng dựa trên AI - chẳng hạn như [Presentation Translation API](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/) cho nội dung slide đa ngôn ngữ.

## **Cách hoạt động**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn nhưng tích hợp với các mô hình AI bên ngoài qua internet. Chức năng này được cung cấp thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/slidesaiagent/), lớp này sử dụng các lớp con của [IAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/iaiwebclient/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaiwebclient/) tích hợp để kết nối tới API của OpenAI hoặc triển khai [IAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/iaiwebclient/) của riêng bạn để sử dụng nhà cung cấp AI hoặc mô hình ngôn ngữ khác.

Aspose.Slides xử lý việc giao tiếp, phân tích các phản hồi của AI và chèn nội dung đã dịch một cách thông minh trong khi giữ nguyên bố cục và định dạng gốc của slide.

{{% alert color="info" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API của mình khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng tôi dịch một bản trình bày PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaiwebclient/) tích hợp với một [model](https://platform.openai.com/docs/models) của OpenAI được chỉ định.

```py
import aspose.slides as slides

# Tải một bản trình bày để dịch.
with slides.Presentation("sample.pptx") as presentation:

    # Tạo một khách hàng AI với OpenAIWebClient, chỉ định mô hình và khóa API của bạn.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Khởi tạo SlidesAIAgent với khách hàng AI.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Dịch bản trình bày sang tiếng Nhật.
        ai_agent.translate(presentation, "japanese")

        # Lưu bản trình bày đã dịch dưới dạng PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Ví dụ Azure OpenAI**

Kể từ phiên bản **26.7.0**, Aspose.Slides cho Python thông qua .NET hỗ trợ các nhà cung cấp tương thích với OpenAI, bao gồm Azure OpenAI. Bạn có thể cấu hình trình dịch để sử dụng triển khai Azure nội bộ của mình bằng [OpenAICompatibleWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Đoạn mã này minh họa cách dịch một bản trình bày bằng endpoint Azure OpenAI của bạn. Thay thế các giá trị placeholder bằng tên triển khai, khóa API và URL endpoint của bạn.

## **Lợi ích chính**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/) cung cấp một giải pháp dựa trên AI để tạo ra các bản trình bày PowerPoint đa ngôn ngữ. Bằng cách tự động dịch trong khi giữ nguyên bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bản trình bày hấp dẫn, bản địa hoá cho khán giả toàn cầu - mở rộng phạm vi tiếp cận và cải thiện giao tiếp.