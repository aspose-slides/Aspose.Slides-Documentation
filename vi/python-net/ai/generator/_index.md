---
title: Trình tạo Slide đa ngôn ngữ dựa trên AI
linktitle: Trình tạo dựa trên AI
type: docs
weight: 40
url: /vi/python-net/ai/generator/
keywords:
- bài thuyết trình đa ngôn ngữ
- slide đa ngôn ngữ
- trình tạo bài thuyết trình AI
- trình tạo slide AI
- tính năng hỗ trợ AI
- agent AI
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo slide đa ngôn ngữ từ văn bản bằng Aspose.Slides cho Python. Áp dụng mẫu của bạn và xuất các bộ slide đã được chỉnh sửa sang PowerPoint và OpenDocument. Tìm hiểu thêm."
---
## **Giới thiệu**

Aspose.Slides giới thiệu tính năng mới được hỗ trợ bởi AI, Trình tạo Bài thuyết trình, cho phép các nhà phát triển tự động tạo ra các bài thuyết trình PowerPoint có cấu trúc tốt từ các đầu vào văn bản đơn giản như mô tả chủ đề, tóm tắt, trích dẫn hoặc các điểm gạch đầu dòng.

Người dùng có thể điều chỉnh mức độ chi tiết của nội dung và tùy chọn áp dụng mẫu bài thuyết trình tùy chỉnh để xác định thiết kế trực quan.

Hiện tại, Trình tạo Bài thuyết trình AI sắp xếp nội dung bằng các khối văn bản, danh sách dấu đầu dòng và bảng. Việc tạo hình ảnh chưa được hỗ trợ; tuy nhiên, hình ảnh có thể dễ dàng được thêm vào sau bằng công cụ Aspose.Slides hoặc thủ công.

Kết quả là một bài thuyết trình PowerPoint hoàn chỉnh có thể được sử dụng ngay hoặc xuất ra bất kỳ định dạng nào được hỗ trợ bởi API Aspose.Slides. Mặc dù trình tạo tạo ra kết quả chất lượng cao, có thể cần một số chỉnh sửa nhỏ sau để đáp ứng các yêu cầu cụ thể.

## **Cách hoạt động**

Aspose.Slides không bao gồm các mô hình AI tích hợp; thay vào đó, nó tích hợp với các dịch vụ AI bên ngoài qua Internet. Sự tích hợp này được xử lý bởi lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/slidesaiagent/), lớp này sử dụng một triển khai của lớp [IAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/iaiwebclient/) để giao tiếp với mô hình AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaiwebclient/) tích hợp, lớp này kết nối tới API của OpenAI, hoặc cung cấp một triển khai tùy chỉnh của [IAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/iaiwebclient/) để làm việc với nhà cung cấp AI khác hoặc mô hình ngôn ngữ. Aspose.Slides quản lý toàn bộ giao tiếp với dịch vụ AI và xử lý các phản hồi của AI để tạo các slide. Lưu ý rằng API OpenAI là dịch vụ trả phí, vì vậy tài khoản và khóa API là bắt buộc khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaiwebclient/) tích hợp.

## **Hãy lập trình**

### **Ví dụ 1**

Ví dụ này trình bày cách tạo một bài thuyết trình về chủ đề Aspose.Slides bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/openaiwebclient/) tích hợp.

```py
# Tạo một thể hiện của OpenAIWebClient, triển khai tích hợp của client web OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Tạo một thể hiện của SlidesAIAgent, cung cấp quyền truy cập vào các tính năng hỗ trợ AI.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Định nghĩa chỉ dẫn cho việc tạo bài thuyết trình.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Tạo một bài thuyết trình với lượng nội dung trung bình dựa trên chỉ dẫn.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Lưu bài thuyết trình đã tạo vào đĩa cục bộ dưới dạng tệp PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Ví dụ 2**

Ví dụ sau trình bày các overload của phương thức [generate_presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). Trong trường hợp này, `master presentation` của người dùng được sử dụng.

```py
# Truyền HttpClient vào hàm khởi tạo OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Tạo một thể hiện của SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Định nghĩa chỉ dẫn cho việc tạo bài thuyết trình.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Tải một bài thuyết trình master từ đĩa cục bộ để sử dụng làm mẫu thiết kế.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Tạo một bài thuyết trình chi tiết bằng cách sử dụng chỉ dẫn và mẫu master.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Lưu bài thuyết trình đã tạo dưới dạng PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Lợi ích chính**

Trình tạo Bài thuyết trình AI mới trong Aspose.Slides cung cấp cách nhanh chóng và linh hoạt để tạo ra các bộ slide có cấu trúc từ các lời nhắc văn bản đơn giản. Với hỗ trợ các mẫu tùy chỉnh, nó có thể được tích hợp liền mạch vào một loạt các ứng dụng.

Các trường hợp sử dụng điển hình bao gồm tạo các bài thuyết trình tiếp thị, tài liệu giáo dục, báo cáo cho khách hàng và bộ slide nội bộ. Mặc dù việc tạo hình ảnh chưa được hỗ trợ, công cụ này đã cung cấp nền tảng vững chắc để tự động hóa việc tạo bài thuyết trình, với các cải thiện thêm sẽ được thực hiện trong tương lai.