---
title: Trình Dịch Bản Trình Chiếu Bằng AI
linktitle: Trình Dịch Bằng AI
type: docs
weight: 20
url: /vi/nodejs-java/ai/translator/
keywords:
- trình dịch bản trình chiếu AI
- trình dịch slide AI
- tính năng dựa trên AI
- bản trình chiếu đa ngôn ngữ
- slide đa ngôn ngữ
- dịch bản trình chiếu
- dịch slide
- tính năng điều khiển bởi AI
- khả năng AI
- AI agent
- client web
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho Node.js. Địa phương hóa PPT, PPTX và ODP trong khi giữ nguyên bố cục—nhanh chóng và thân thiện với nhà phát triển. Hãy thử."
---
## **Introduction**

Aspose.Slides là một API mạnh mẽ để quản lý các bản trình bày PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi các slide, nó còn cung cấp các tính năng dựa trên AI - như API Dịch Trình Chiếu cho nội dung slide đa ngôn ngữ.

## **How it Works**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn nhưng tích hợp với các mô hình AI bên ngoài qua internet. Chức năng này được cung cấp thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesaiagent/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) được tích hợp sẵn để kết nối tới API của OpenAI.

Aspose.Slides xử lý giao tiếp, phân tích phản hồi của AI và thông minh chèn nội dung đã dịch trong khi bảo tồn bố cục và định dạng slide gốc.

{{% alert color="primary" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API của mình khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) được tích hợp sẵn.
{{% /alert %}}

## **Example**

Trong ví dụ này, chúng tôi dịch một bản trình bày PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) được tích hợp sẵn với một [model](https://platform.openai.com/docs/models) của OpenAI được chỉ định.

```js
// Tải một bản trình chiếu để dịch.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Tạo một client AI bằng OpenAIWebClient, chỉ định mô hình và khóa API của bạn.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Khởi tạo SlidesAIAgent với client AI.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Dịch bản trình chiếu sang tiếng Nhật.
    aiAgent.translate(presentation, "japanese");

    // Lưu bản trình chiếu đã dịch thành PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/) được tích hợp sẵn tạo và quản lý một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ của riêng nó, tự động xử lý vòng đời. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — chủ yếu để cấu hình các thiết lập thiết yếu như proxy, hoặc để sử dụng một [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc một [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) khác để quản lý tài nguyên và hiệu suất tốt hơn — bạn có thể cung cấp thể hiện `HttpURLConnection` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Giả sử bạn đã có một thể hiện HttpURLConnection đã cấu hình trước (ví dụ: với thời gian chờ tùy chỉnh, cài đặt proxy, v.v.)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Key Benefits**

API Dịch Trình Chiếu của Aspose.Slides cung cấp giải pháp dựa trên AI để tạo các bản trình bày PowerPoint đa ngôn ngữ. Bằng cách tự động dịch trong khi bảo tồn bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với các quy trình thủ công. Dù bạn là nhà phát triển, giảng viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bản trình bày hấp dẫn, được bản địa hoá cho khán giả toàn cầu - mở rộng tầm ảnh hưởng và cải thiện giao tiếp.