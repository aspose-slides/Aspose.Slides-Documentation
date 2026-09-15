---
title: Trình dịch bài thuyết trình bằng AI
linktitle: Trình dịch bằng AI
type: docs
weight: 20
url: /vi/net/ai/translator/
keywords:
- trình dịch bài thuyết trình AI
- trình dịch slide AI
- tính năng hỗ trợ AI
- bài thuyết trình đa ngôn ngữ
- slide đa ngôn ngữ
- dịch bài thuyết trình
- dịch slide
- tính năng dựa trên AI
- khả năng AI
- đại lý AI
- client web
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho .NET. Địa phương hoá PPT, PPTX và ODP đồng thời giữ nguyên bố cục—nhanh chóng và thân thiện với nhà phát triển. Hãy thử ngay."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bản trình bày PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi slide, nó còn cung cấp các tính năng dựa trên AI - chẳng hạn như [Presentation Translation API](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/) để dịch nội dung slide đa ngôn ngữ.

## **Cách hoạt động**

Aspose.Slides không có khả năng AI tích hợp sẵn mà tích hợp với các mô hình AI bên ngoài qua Internet. Chức năng này được mở ra thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/slidesaiagent), lớp này sử dụng một triển khai của giao diện [IAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/iaiwebclient/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) tích hợp sẵn để kết nối tới API của OpenAI hoặc tự triển khai [IAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/iaiwebclient/) để sử dụng nhà cung cấp AI hoặc mô hình ngôn ngữ khác.

Aspose.Slides xử lý việc giao tiếp, phân tích các phản hồi AI và chèn nội dung đã dịch một cách thông minh đồng thời giữ nguyên bố cục và định dạng gốc của slide.

{{% alert color="info" title="Lưu ý" %}}

Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/).

{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng ta dịch một bản trình bày PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) tích hợp sẵn với một [model](https://platform.openai.com/docs/models) OpenAI được chỉ định.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Tải một bản trình bày để dịch.
using var presentation = new Presentation("sample.pptx");

// Tạo client AI với OpenAIWebClient, chỉ định mô hình và khóa API của bạn.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Khởi tạo SlidesAIAgent với client AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Dịch bản trình bày sang tiếng Nhật.
await aiAgent.TranslateAsync(presentation, "japanese");

// Lưu bản trình bày đã dịch dưới dạng PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/) tạo và quản lý một thể hiện [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) nội bộ, tự động xử lý vòng đời và việc giải phóng tài nguyên. Tuy nhiên, nếu bạn muốn tự quản lý [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — chẳng hạn khi sử dụng [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) để cải thiện việc quản lý tài nguyên và hiệu năng — bạn có thể cung cấp thể hiện `HttpClient` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Sử dụng một HttpClient do bạn tự quản lý - ví dụ, một HttpClient được tạo bởi IHttpClientFactory
// được tiêm thông qua dependency injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides thường được sử dụng trong môi trường đồng bộ. Để hỗ trợ điều này, lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/slidesaiagent/) cung cấp cả các phương thức đồng bộ và bất đồng bộ — cho phép bạn chọn cách tiếp cận phù hợp nhất với quy trình làm việc của ứng dụng.

### **Ví dụ Azure OpenAI**

Aspose.Slides for .NET hỗ trợ các nhà cung cấp tương thích OpenAI, bao gồm Azure OpenAI. Bạn có thể cấu hình bộ dịch để sử dụng triển khai Azure nội bộ của mình với [OpenAICompatibleWebClient](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Đoạn mã này minh họa cách dịch một bản trình bày bằng endpoint Azure OpenAI của bạn. Thay các giá trị giữ chỗ bằng tên triển khai, khóa API và URL endpoint của bạn.

## **Lợi ích chính**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/vi/net/aspose.slides.ai/) cung cấp giải pháp AI cho việc tạo các bản trình bày PowerPoint đa ngôn ngữ. Bằng cách tự động dịch trong khi giữ nguyên bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này giúp bạn tạo các bản trình bày hấp dẫn, địa phương hoá cho khán giả toàn cầu — mở rộng phạm vi tiếp cận và cải thiện giao tiếp.