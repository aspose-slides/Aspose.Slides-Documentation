---
title: Trình Dịch Bản Trình Chiếu Hỗ Trợ AI
linktitle: Trình Dịch Hỗ Trợ AI
type: docs
weight: 20
url: /vi/java/ai/translator/
keywords:
- Trình dịch bản trình chiếu AI
- Trình dịch slide AI
- Tính năng hỗ trợ AI
- Bản trình chiếu đa ngôn ngữ
- Slide đa ngôn ngữ
- Dịch bản trình chiếu
- Dịch slide
- Các tính năng dựa trên AI
- Khả năng AI
- Đại lý AI
- Khách hàng web
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho Java. Bản địa hoá PPT, PPTX và ODP trong khi giữ nguyên bố cục—nhanh chóng và thân thiện với nhà phát triển. Hãy thử."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bản trình bày PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi các slide, nó còn cung cấp các tính năng dựa trên AI — chẳng hạn như Presentation Translation API cho nội dung slide đa ngôn ngữ.

## **Cách hoạt động**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn nhưng tích hợp với các mô hình AI bên ngoài qua Internet. Chức năng này được bật ra thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesaiagent/) , lớp này sử dụng một triển khai của giao diện [IAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaiwebclient/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) có sẵn để kết nối tới API của OpenAI hoặc tự triển khai [IAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaiwebclient/) của riêng bạn để sử dụng nhà cung cấp AI hoặc mô hình ngôn ngữ khác.

Aspose.Slides chịu trách nhiệm giao tiếp, phân tích phản hồi AI và chèn nội dung đã dịch một cách thông minh trong khi vẫn bảo toàn bố cục và định dạng gốc của slide.

{{% alert color="info" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng ta dịch một bản trình bày PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) có sẵn cùng với một [model](https://platform.openai.com/docs/models) của OpenAI được chỉ định.

```java
import com.aspose.slides.*;

// Tải một bản trình chiếu để dịch.
Presentation presentation = new Presentation("sample.pptx");

// Tạo một khách hàng AI với OpenAIWebClient, chỉ định mô hình và khóa API của bạn.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Khởi tạo SlidesAIAgent với khách hàng AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Dịch bản trình chiếu sang tiếng Nhật.
    aiAgent.translate(presentation, "japanese");

    // Lưu bản trình chiếu đã dịch dưới dạng PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tạo và quản lý một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ, tự động xử lý vòng đời của nó. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — chủ yếu để cấu hình các thiết lập quan trọng như proxy, hoặc để sử dụng một [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc một [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) khác nhằm cải thiện việc quản lý tài nguyên và hiệu suất — bạn có thể cung cấp thể hiện `HttpURLConnection` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Cấu hình một thể hiện HttpURLConnection tự mình (thiết lập thời gian chờ tùy chỉnh, cấu hình proxy, v.v.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Lợi ích chính**

Presentation Translation API của Aspose.Slides cung cấp một giải pháp dựa trên AI để tạo ra các bản trình bày PowerPoint đa ngôn ngữ. Bằng cách tự động dịch trong khi vẫn giữ nguyên bố cục và thiết kế, nó giúp tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bản trình bày hấp dẫn, bản địa hoá cho khán giả toàn cầu — mở rộng tầm ảnh hưởng và cải thiện khả năng giao tiếp.