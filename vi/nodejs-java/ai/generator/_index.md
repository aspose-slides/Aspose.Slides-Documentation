---
title: Trình tạo Slide Đa Ngôn ngữ dựa trên AI
linktitle: Trình tạo dựa trên AI
type: docs
weight: 40
url: /vi/nodejs-java/ai/generator/
keywords:
- bản trình chiếu đa ngôn ngữ
- slide đa ngôn ngữ
- trình tạo bản trình chiếu AI
- trình tạo slide AI
- tính năng hỗ trợ AI
- đại lý AI
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo slide đa ngôn ngữ từ văn bản bằng Aspose.Slides cho Node.js. Áp dụng mẫu của bạn và xuất các bộ slide đã được chỉnh sửa sang PowerPoint và OpenDocument. Tìm hiểu thêm."
---
## **Giới thiệu**

Aspose.Slides giới thiệu một tính năng mới dựa trên AI, trình tạo bài thuyết trình, cho phép các nhà phát triển tự động tạo các bản trình chiếu PowerPoint có cấu trúc tốt từ các đầu vào văn bản đơn giản như mô tả chủ đề, tóm tắt, trích dẫn hoặc các gạch đầu dòng.

Người dùng có thể điều chỉnh mức độ chi tiết của nội dung và tùy chọn áp dụng mẫu trình chiếu tùy chỉnh để xác định thiết kế hình ảnh.

Hiện tại, Trình tạo Bài thuyết trình AI cấu trúc nội dung bằng các khối văn bản, danh sách gạch đầu dòng và bảng. Việc tạo hình ảnh chưa được hỗ trợ; tuy nhiên, hình ảnh có thể dễ dàng thêm sau bằng công cụ Aspose.Slides hoặc thủ công.

Kết quả là một bản trình chiếu PowerPoint hoàn chỉnh có thể được sử dụng ngay hoặc xuất sang bất kỳ định dạng nào được Aspose.Slides API hỗ trợ. Mặc dù trình tạo tạo ra kết quả chất lượng cao, nhưng có thể cần một số chỉnh sửa nhỏ sau khi tạo để đáp ứng các yêu cầu cụ thể.

## **Cách hoạt động**

Aspose.Slides không bao gồm các mô hình AI tích hợp; thay vào đó, nó tích hợp với các dịch vụ AI bên ngoài qua internet. Việc tích hợp này được xử lý bởi lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesaiagent/).

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp, nó kết nối tới API của OpenAI. Aspose.Slides quản lý toàn bộ việc giao tiếp với dịch vụ AI và xử lý phản hồi của AI để tạo các slide. Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy cần tài khoản và khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp.

## **Hãy lập trình**

### **Ví dụ 1**

Ví dụ này trình bày cách tạo một bản trình chiếu về chủ đề Aspose.Slides bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp.

```js
// Tạo một thể hiện của OpenAIWebClient, triển khai tích hợp sẵn của khách hàng web OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Tạo một thể hiện của SlidesAIAgent, cung cấp quyền truy cập vào các tính năng hỗ trợ AI.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Xác định chỉ thị để tạo bản trình chiếu.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Tạo một bản trình chiếu với lượng nội dung vừa phải dựa trên chỉ thị.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Lưu bản trình chiếu đã tạo vào ổ đĩa cục bộ dưới dạng file PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Ví dụ 2**

Ví dụ sau đây trình bày các overload của phương thức [generatePresentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). Trong trường hợp này, một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) được quản lý bên ngoài và `master presentation` của người dùng được sử dụng.

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp tạo và quản lý thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ của nó, tự động xử lý vòng đời. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — ví dụ khi sử dụng [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) để cải thiện quản lý tài nguyên và hiệu năng — bạn có thể cung cấp thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Truyền HttpURLConnection vào hàm tạo OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Tạo một thể hiện của SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Xác định chỉ thị để tạo bản trình chiếu.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Tải bản trình chiếu master từ ổ đĩa cục bộ để sử dụng làm mẫu thiết kế.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Tạo một bản trình chiếu chi tiết bằng cách sử dụng chỉ thị và mẫu master.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Lưu bản trình chiếu đã tạo dưới dạng PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Lợi ích chính**

Trình tạo Bài thuyết trình AI mới trong Aspose.Slides cung cấp cách nhanh chóng và linh hoạt để tạo các bộ slide có cấu trúc từ các lời nhắc văn bản đơn giản. Với hỗ trợ mẫu tùy chỉnh và các thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) được quản lý bên ngoài, nó có thể được tích hợp liền mạch vào nhiều loại ứng dụng.

Các trường hợp sử dụng điển hình bao gồm tạo các bản thuyết trình tiếp thị, tài liệu giáo dục, báo cáo khách hàng và bộ slide nội bộ. Mặc dù việc tạo hình ảnh chưa được hỗ trợ, công cụ này đã cung cấp nền tảng vững chắc để tự động hoá việc tạo bài thuyết trình, và dự kiến sẽ có các cải tiến bổ sung trong tương lai.