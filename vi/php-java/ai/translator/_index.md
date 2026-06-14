---
title: Trình dịch bài thuyết trình bằng AI
linktitle: Trình dịch hỗ trợ AI
type: docs
weight: 20
url: /vi/php-java/ai/translator/
keywords:
- Trình dịch bài thuyết trình AI
- Trình dịch slide AI
- Tính năng hỗ trợ AI
- Bài thuyết trình đa ngôn ngữ
- Slide đa ngôn ngữ
- Dịch bài thuyết trình
- Dịch slide
- Tính năng do AI điều khiển
- Khả năng AI
- Đại lý AI
- Khách hàng Web
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho PHP. Địa phương hoá PPT, PPTX và ODP trong khi giữ nguyên bố cục—nhanh và thân thiện với nhà phát triển. Hãy thử ngay."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bài thuyết trình PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi các slide, nó còn cung cấp các tính năng dựa trên AI - chẳng hạn như Presentation Translation API cho nội dung slide đa ngôn ngữ.

## **Cách hoạt động**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn nhưng tích hợp với các mô hình AI bên ngoài qua internet. Chức năng này được mở ra thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesaiagent/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/php-java/aspose.slides/openaiwebclient/) được tích hợp sẵn để kết nối tới API của OpenAI.

Aspose.Slides xử lý việc giao tiếp, phân tích các phản hồi của AI, và chèn nội dung đã dịch một cách thông minh trong khi vẫn giữ nguyên bố cục và định dạng slide gốc.

{{% alert color="primary" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API của mình khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng tôi dịch một bài thuyết trình PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/php-java/aspose.slides/openaiwebclient/) được tích hợp sẵn với một [model](https://platform.openai.com/docs/models) của OpenAI đã chỉ định.

```php
// Tải một bài thuyết trình để dịch.
$presentation = new Presentation("sample.pptx");

// Tạo một client AI với OpenAIWebClient, chỉ định mô hình và khóa API của bạn.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Khởi tạo SlidesAIAgent với client AI.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Dịch bài thuyết trình sang tiếng Nhật.
    $aiAgent->translate($presentation, "japanese");

    // Lưu bài thuyết trình đã dịch dưới dạng PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/php-java/aspose.slides/openaiwebclient/) được tích hợp sẵn tạo và quản lý riêng một thực thể [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ, tự động xử lý vòng đời của nó. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — chủ yếu để cấu hình các cài đặt quan trọng như proxy, hoặc sử dụng [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc một [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) khác để quản lý tài nguyên và hiệu suất tốt hơn — bạn có thể cung cấp thực thể `HttpURLConnection` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/php-java/aspose.slides/openaiwebclient/).

```php
// Giả sử bạn đã có một thể hiện HttpURLConnection được cấu hình trước (ví dụ, với thời gian chờ tùy chỉnh, cài đặt proxy, v.v.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Lợi ích chính**

Presentation Translation API của Aspose.Slides cung cấp một giải pháp dựa trên AI để tạo ra các bài thuyết trình PowerPoint đa ngôn ngữ. Bằng cách tự động hoá việc dịch trong khi vẫn giữ nguyên bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bài thuyết trình hấp dẫn, bản địa hoá cho khán giả toàn cầu - mở rộng độ phủ và cải thiện giao tiếp.