---
title: Trình tạo Slide Đa ngôn ngữ hỗ trợ AI
linktitle: Trình tạo hỗ trợ AI
type: docs
weight: 40
url: /vi/java/ai/generator/
keywords:
- bài thuyết trình đa ngôn ngữ
- slide đa ngôn ngữ
- trình tạo bài thuyết trình AI
- trình tạo slide AI
- tính năng hỗ trợ AI
- tác nhân AI
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tạo các slide đa ngôn ngữ từ văn bản bằng Aspose.Slides cho Java. Áp dụng mẫu của bạn và xuất các bộ slide hoàn thiện sang PowerPoint và OpenDocument. Tìm hiểu thêm."
---
## **Giới thiệu**

Aspose.Slides giới thiệu một tính năng mới được hỗ trợ bởi AI, gọi là Trình tạo Bài thuyết trình, cho phép các nhà phát triển tự động tạo các bài thuyết trình PowerPoint có cấu trúc tốt từ các đầu vào văn bản đơn giản như mô tả chủ đề, tóm tắt, trích dẫn hoặc các gạch đầu dòng.

Người dùng có thể điều chỉnh mức độ chi tiết của nội dung và tùy chọn áp dụng một mẫu bài thuyết trình tùy chỉnh để xác định thiết kế hình ảnh.

Hiện tại, Trình tạo Bài thuyết trình AI cấu trúc nội dung bằng các khối văn bản, danh sách gạch đầu dòng và bảng. Việc tạo hình ảnh chưa được hỗ trợ; tuy nhiên, hình ảnh có thể dễ dàng thêm sau đó bằng công cụ Aspose.Slides hoặc thủ công.

Kết quả là một bài thuyết trình PowerPoint hoàn chỉnh có thể được sử dụng ngay hoặc xuất sang bất kỳ định dạng nào được Aspose.Slides API hỗ trợ. Mặc dù trình tạo tạo ra kết quả chất lượng cao, nhưng có thể cần một số chỉnh sửa nhỏ để đáp ứng các yêu cầu cụ thể.

## **Cách hoạt động**

Aspose.Slides không bao gồm các mô hình AI tích hợp; thay vào đó, nó tích hợp với các dịch vụ AI bên ngoài qua internet. Việc tích hợp này được xử lý bởi lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesaiagent/) , lớp này sử dụng một triển khai của giao diện [IAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaiwebclient/) để giao tiếp với mô hình AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp, lớp này kết nối tới API của OpenAI, hoặc cung cấp một triển khai tùy chỉnh của [IAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaiwebclient/) để làm việc với nhà cung cấp AI khác hoặc mô hình ngôn ngữ khác. Aspose.Slides quản lý mọi giao tiếp với dịch vụ AI và xử lý các phản hồi của AI để tạo các slide. Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy cần có tài khoản và khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp.

## **Hãy lập trình**

### **Ví dụ 1**

Ví dụ này minh họa cách tạo một bài thuyết trình về chủ đề Aspose.Slides bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp.

```java
// Tạo một thể hiện của OpenAIWebClient, triển khai tích hợp sẵn của client web OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Tạo một thể hiện của SlidesAIAgent, cung cấp quyền truy cập vào các tính năng hỗ trợ AI.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Xác định hướng dẫn để tạo bài thuyết trình.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Tạo một bài thuyết trình với lượng nội dung trung bình dựa trên hướng dẫn.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Lưu bài thuyết trình đã tạo vào đĩa cục bộ dưới dạng tệp PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Ví dụ 2**

Ví dụ sau đây minh họa các phương thức overload của phương thức [generatePresentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). Trong trường hợp này, một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) được quản lý bên ngoài và `master presentation` của người dùng được sử dụng.

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tạo và quản lý thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ của mình, tự động xử lý vòng đời của nó. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — ví dụ, khi sử dụng [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) để cải thiện quản lý tài nguyên và hiệu suất — bạn có thể cung cấp thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/).

```java
// Truyền HttpURLConnection vào hàm khởi tạo OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Tạo một thể hiện của SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Xác định hướng dẫn để tạo bài thuyết trình.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Tải một bài thuyết trình mẫu từ đĩa cục bộ để dùng làm mẫu thiết kế.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Tạo một bài thuyết trình chi tiết bằng cách sử dụng hướng dẫn và mẫu chính.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Lưu bài thuyết trình đã tạo dưới dạng PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Lợi ích chính**

Trình tạo Bài thuyết trình AI mới trong Aspose.Slides cung cấp cách nhanh chóng và linh hoạt để tạo các bộ slide có cấu trúc từ các lời nhắc văn bản đơn giản. Với hỗ trợ các mẫu tùy chỉnh và các thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) được quản lý bên ngoài, nó có thể được tích hợp liền mạch vào nhiều loại ứng dụng.

Các trường hợp sử dụng điển hình bao gồm tạo bài thuyết trình marketing, tài liệu giáo dục, báo cáo khách hàng và bộ slide nội bộ. Mặc dù việc tạo hình ảnh chưa được hỗ trợ, công cụ này đã cung cấp nền tảng vững chắc cho việc tự động hóa việc tạo bài thuyết trình, với các cải tiến bổ sung dự kiến trong tương lai.