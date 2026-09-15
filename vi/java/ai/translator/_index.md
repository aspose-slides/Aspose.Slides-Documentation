---
title: Trình Dịch Bản Thuyết Trình Bằng AI
linktitle: Trình Dịch Bằng AI
type: docs
weight: 20
url: /vi/java/ai/translator/
keywords:
- Trình dịch bản thuyết trình AI
- Trình dịch slide AI
- Tính năng chạy bằng AI
- Bản thuyết trình đa ngôn ngữ
- Slide đa ngôn ngữ
- Dịch bản thuyết trình
- Dịch slide
- Các tính năng dựa trên AI
- Khả năng AI
- Đại lý AI
- Client Web
- PowerPoint
- OpenDocument
- bản thuyết trình
- Java
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho Java. Địa phương hoá PPT, PPTX và ODP đồng thời giữ nguyên bố cục—nhanh chóng và thân thiện với nhà phát triển. Hãy thử."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bản thuyết trình PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi các slide, nó cung cấp các tính năng dựa trên AI - chẳng hạn như Presentation Translation API cho nội dung slide đa ngôn ngữ.

## **Cách hoạt động**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn nhưng tích hợp với các mô hình AI bên ngoài qua internet. Chức năng này được cung cấp thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesaiagent/) sử dụng một triển khai của giao diện [IAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaiwebclient/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp sẵn để kết nối tới API của OpenAI hoặc triển khai [IAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaiwebclient/) của riêng bạn để sử dụng nhà cung cấp AI hoặc mô hình ngôn ngữ khác.

Aspose.Slides xử lý việc giao tiếp, phân tích phản hồi AI và chèn nội dung đã dịch một cách thông minh trong khi bảo toàn bố cục và định dạng slide gốc.

{{% alert color="info" title="Note" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API của mình khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp sẵn.
{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng tôi dịch một bản thuyết trình PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp sẵn với một [model](https://platform.openai.com/docs/models) OpenAI được chỉ định.

```java
import com.aspose.slides.*;

// Tải một bản thuyết trình để dịch.
Presentation presentation = new Presentation("sample.pptx");

// Tạo một client AI bằng OpenAIWebClient, chỉ định mô hình và khóa API của bạn.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Khởi tạo SlidesAIAgent với client AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Dịch bản thuyết trình sang tiếng Nhật.
    aiAgent.translate(presentation, "japanese");

    // Lưu bản thuyết trình đã dịch dưới dạng PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/) tích hợp sẵn tạo và quản lý một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ của riêng nó, tự động xử lý vòng đời. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — chủ yếu để cấu hình các thiết lập quan trọng như proxy, hoặc để sử dụng [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc một [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) khác để cải thiện quản lý tài nguyên và hiệu năng — bạn có thể cung cấp thể hiện `HttpURLConnection` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Cấu hình một thể hiện HttpURLConnection tự mình (thiết lập thời gian chờ tùy chỉnh, cài đặt proxy, v.v.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Ví dụ Azure OpenAI**

Bạn có thể cấu hình trình dịch để sử dụng triển khai Azure OpenAI của mình với [OpenAICompatibleWebClient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Đoạn mã này minh họa cách dịch một bản thuyết trình bằng điểm cuối Azure OpenAI của bạn. Thay thế các giá trị placeholder bằng tên triển khai, khóa API và URL điểm cuối của bạn.

## **Lợi ích chính**

Aspose.Slides Presentation Translation API cung cấp một giải pháp dựa trên AI để tạo ra các bản thuyết trình PowerPoint đa ngôn ngữ. Bằng cách tự động hoá quá trình dịch trong khi bảo toàn bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bản thuyết trình hấp dẫn, bản địa hoá cho khán giả toàn cầu — mở rộng tầm ảnh hưởng và cải thiện giao tiếp.