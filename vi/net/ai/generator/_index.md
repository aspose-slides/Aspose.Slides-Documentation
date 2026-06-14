---
title: Trình tạo slide đa ngôn ngữ hỗ trợ AI
linktitle: Trình tạo hỗ trợ AI
type: docs
weight: 40
url: /vi/net/ai/generator/
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
- .NET
- C#
- Aspose.Slides
description: "Tạo các slide đa ngôn ngữ từ văn bản bằng Aspose.Slides cho .NET. Áp dụng mẫu của bạn và xuất các bộ slide đã được chỉnh sửa sang PowerPoint và OpenDocument. Tìm hiểu thêm."
---
## **Giới thiệu**

Aspose.Slides giới thiệu tính năng mới được hỗ trợ bởi AI, gọi là Presentation Generator, cho phép các nhà phát triển tự động tạo các bài thuyết trình PowerPoint có cấu trúc tốt từ các đầu vào văn bản đơn giản như mô tả chủ đề, tóm tắt, trích dẫn hoặc các điểm bullet.

Người dùng có thể điều chỉnh mức độ chi tiết của nội dung và tùy chọn áp dụng mẫu thuyết trình tùy chỉnh để xác định thiết kế trực quan.

Hiện tại, AI Presentation Generator cấu trúc nội dung bằng các khối văn bản, danh sách bullet và bảng. Việc tạo hình ảnh vẫn chưa được hỗ trợ; tuy nhiên, hình ảnh có thể dễ dàng được thêm sau đó bằng công cụ Aspose.Slides hoặc thủ công.

Kết quả là một bài thuyết trình PowerPoint hoàn chỉnh có thể sử dụng ngay hoặc xuất ra bất kỳ định dạng nào được Aspose.Slides API hỗ trợ. Mặc dù trình tạo mang lại kết quả chất lượng cao, nhưng có thể cần một số chỉnh sửa nhỏ sau khi tạo để đáp ứng các yêu cầu cụ thể.

## **Cách hoạt động**

Aspose.Slides không bao gồm các mô hình AI tích hợp; thay vào đó, nó tích hợp với các dịch vụ AI bên ngoài qua internet. Việc tích hợp này được xử lý bởi lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/slidesaiagent/) , lớp này sử dụng một triển khai của giao diện [IAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/iaiwebclient/) để giao tiếp với mô hình AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) , được tích hợp sẵn, kết nối đến API của OpenAI, hoặc cung cấp một triển khai tùy chỉnh của [IAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/iaiwebclient/) để làm việc với nhà cung cấp AI khác hoặc mô hình ngôn ngữ khác. Aspose.Slides quản lý toàn bộ giao tiếp với dịch vụ AI và xử lý các phản hồi của AI để tạo slide. Lưu ý rằng API của OpenAI là dịch vụ trả phí, do đó cần có tài khoản và khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) .

## **Hãy viết code**

### **Ví dụ 1**

Ví dụ này minh họa cách tạo một bài thuyết trình về chủ đề Aspose.Slides bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) tích hợp sẵn.

```csharp
// Tạo một thể hiện của OpenAIWebClient, triển khai tích hợp sẵn của client web OpenAI.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Tạo một thể hiện của SlidesAIAgent, cung cấp quyền truy cập vào các tính năng hỗ trợ AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Xác định chỉ thị để tạo bài thuyết trình.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Tạo một bài thuyết trình với mức nội dung trung bình dựa trên chỉ thị.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Lưu bài thuyết trình đã tạo vào ổ đĩa cục bộ dưới dạng tệp PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Ví dụ 2**

Ví dụ sau minh họa các overload của phương thức [GeneratePresentation](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/slidesaiagent/generatepresentation/) . Trong trường hợp này, một thể hiện [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) được quản lý bên ngoài và `master presentation` của người dùng được sử dụng.

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) tích hợp sẵn tạo và quản lý một thể hiện [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) nội bộ của riêng nó, tự động xử lý vòng đời và việc giải phóng. Tuy nhiên, nếu bạn muốn tự quản lý [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — ví dụ, khi sử dụng [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) để cải thiện quản lý tài nguyên và hiệu suất — bạn có thể cung cấp thể hiện [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) .

```csharp
// Tạo một thể hiện HttpClient được quản lý bên ngoài.
using var httpClient = new HttpClient();

// Truyền HttpClient vào hàm khởi tạo OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Tạo một thể hiện của SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Xác định chỉ thị để tạo bài thuyết trình.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Tải một bài thuyết trình gốc từ ổ đĩa cục bộ để sử dụng làm mẫu thiết kế.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Tạo một bài thuyết trình chi tiết sử dụng chỉ thị và mẫu gốc.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Lưu bài thuyết trình đã tạo dưới dạng PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Cần lưu ý rằng nhiều khách hàng sử dụng Aspose.Slides trong các ngữ cảnh đồng bộ. Để hỗ trợ điều này, lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/slidesaiagent/) cung cấp cả các phương thức đồng bộ và bất đồng bộ, cho phép bạn chọn cách tiếp cận phù hợp nhất với luồng công việc của ứng dụng.

## **Lợi ích chính**

AI Presentation Generator mới trong Aspose.Slides cung cấp cách nhanh chóng và linh hoạt để tạo các bộ slide có cấu trúc từ các đề nghị văn bản đơn giản. Với hỗ trợ mẫu tùy chỉnh, các thể hiện [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) được quản lý bên ngoài, và cả quy trình đồng bộ lẫn bất đồng bộ, nó có thể được tích hợp một cách liền mạch vào nhiều loại ứng dụng.

Các trường hợp sử dụng phổ biến bao gồm tạo các bài thuyết trình marketing, tài liệu giáo dục, báo cáo khách hàng và bộ slide nội bộ. Mặc dù việc tạo hình ảnh chưa được hỗ trợ, công cụ này đã cung cấp nền tảng vững chắc cho việc tự động hóa việc tạo bài thuyết trình, với các cải tiến bổ sung dự kiến trong tương lai.