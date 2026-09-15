---
title: Trình dịch bản trình bày sử dụng AI
linktitle: Trình dịch sử dụng AI
type: docs
weight: 20
url: /vi/nodejs-java/ai/translator/
keywords:
- Trình dịch bản trình bày AI
- Trình dịch slide AI
- Tính năng hỗ trợ AI
- Bản trình bày đa ngôn ngữ
- Slide đa ngôn ngữ
- Dịch bản trình bày
- Dịch slide
- Các tính năng dựa trên AI
- Khả năng AI
- Agent AI
- Client Web
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho Node.js. Địa phương hoá PPT, PPTX và ODP trong khi giữ nguyên bố cục—nhanh và thân thiện với nhà phát triển. Hãy thử."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bản trình bày PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi slide, nó còn cung cấp các tính năng dựa trên AI – chẳng hạn như Presentation Translation API cho nội dung slide đa ngôn ngữ.

## **Cách hoạt động**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn mà tích hợp với các mô hình AI bên ngoài qua Internet. Chức năng này được cung cấp thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesaiagent/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp sẵn để kết nối tới API của OpenAI.

Aspose.Slides xử lý việc giao tiếp, phân tích phản hồi AI và chèn nội dung đã dịch một cách thông minh trong khi giữ nguyên bố cục và định dạng slide gốc.

{{% alert color="info" title="Note" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng ta dịch một bản trình bày PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp sẵn với một [model](https://platform.openai.com/docs/models) OpenAI được chỉ định.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tải một bản trình bày để dịch.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Tạo một client AI với OpenAIWebClient, chỉ định model và khóa API của bạn.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Khởi tạo SlidesAIAgent với client AI.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Dịch bản trình bày sang tiếng Nhật.
    aiAgent.translate(presentation, "japanese");

    // Lưu bản trình bày đã dịch dưới dạng PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) tích hợp sẵn tạo và quản lý một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ, tự động xử lý vòng đời của nó. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — chủ yếu để cấu hình các thiết lập quan trọng như proxy, hoặc để sử dụng một [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc một [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) khác nhằm cải thiện quản lý tài nguyên và hiệu năng — bạn có thể cung cấp thể hiện `HttpURLConnection` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Ví dụ Azure OpenAI**

Bạn có thể cấu hình trình dịch để sử dụng triển khai Azure OpenAI của mình với [OpenAICompatibleWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Đoạn mã này minh họa cách dịch một bản trình bày bằng endpoint Azure OpenAI của bạn. Thay các giá trị giữ chỗ bằng tên triển khai, khóa API và URL endpoint của bạn.

## **Lợi ích chính**

Aspose.Slides Presentation Translation API cung cấp một giải pháp dựa trên AI để cung cấp các bản trình bày PowerPoint đa ngôn ngữ. Bằng cách tự động hoá việc dịch đồng thời giữ nguyên bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bản trình bày hấp dẫn, bản địa hoá cho khán giả toàn cầu — mở rộng phạm vi tiếp cận và cải thiện giao tiếp.