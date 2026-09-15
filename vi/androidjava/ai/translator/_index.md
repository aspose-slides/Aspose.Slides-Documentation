---
title: Trình Dịch Trình Chiếu Bằng AI
linktitle: Trình Dịch Hỗ Trợ AI
type: docs
weight: 20
url: /vi/androidjava/ai/translator/
keywords:
- Trình dịch trình chiếu AI
- Trình dịch slide AI
- Tính năng được hỗ trợ bởi AI
- Trình chiếu đa ngôn ngữ
- Slide đa ngôn ngữ
- Dịch trình chiếu
- Dịch slide
- Các tính năng do AI điều khiển
- Khả năng AI
- Tác nhân AI
- Khách hàng web
- PowerPoint
- OpenDocument
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Dịch các slide PowerPoint bằng AI sử dụng Aspose.Slides cho Android qua Java. Địa phương hoá PPT, PPTX và ODP trong khi giữ nguyên bố cục—nhanh và thân thiện với nhà phát triển. Hãy thử."
---
## **Giới thiệu**

Aspose.Slides là một API mạnh mẽ để quản lý các bản trình bày PowerPoint một cách lập trình. Ngoài việc tạo, chỉnh sửa và chuyển đổi các slide, nó còn cung cấp các tính năng dựa trên AI - chẳng hạn như API Dịch Trình Chiếu cho nội dung slide đa ngôn ngữ.

## **Cách Hoạt Động**

Aspose.Slides không bao gồm các khả năng AI tích hợp sẵn, nhưng tích hợp với các mô hình AI bên ngoài qua internet. Chức năng này được cung cấp thông qua lớp [SlidesAIAgent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesaiagent/) , lớp này sử dụng một triển khai của giao diện [IAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaiwebclient/) để giao tiếp với các dịch vụ AI.

Bạn có thể sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/openaiwebclient/) tích hợp sẵn để kết nối với API của OpenAI hoặc tự triển khai [IAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaiwebclient/) để dùng nhà cung cấp AI hoặc mô hình ngôn ngữ khác.

Aspose.Slides xử lý việc giao tiếp, phân tích các phản hồi AI và tự động chèn nội dung đã dịch trong khi bảo tồn bố cục và định dạng gốc của slide.

{{% alert color="info" title="Lưu ý" %}}
Lưu ý rằng API của OpenAI là dịch vụ trả phí, vì vậy bạn sẽ cần tạo tài khoản và cung cấp khóa API khi sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/openaiwebclient/) tích hợp sẵn.
{{% /alert %}}

## **Ví dụ**

Trong ví dụ này, chúng ta dịch một bản trình bày PowerPoint sang tiếng Nhật bằng cách sử dụng [OpenAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/openaiwebclient/) tích hợp sẵn với một [model](https://platform.openai.com/docs/models) OpenAI được chỉ định.

```java
import com.aspose.slides.*;

// Tải một bản trình chiếu để dịch.
Presentation presentation = new Presentation("sample.pptx");

// Khởi tạo SlidesAIAgent với client AI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Dịch bản trình chiếu sang tiếng Nhật.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Lưu bản trình chiếu đã dịch dưới dạng PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Theo mặc định, [OpenAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/openaiwebclient/) tạo và quản lý một thể hiện [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nội bộ, tự động xử lý vòng đời của nó. Tuy nhiên, nếu bạn muốn tự quản lý [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — chủ yếu để cấu hình các thiết lập quan trọng như proxy, hoặc để sử dụng một [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) hoặc một [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) khác để cải thiện quản lý tài nguyên và hiệu suất — bạn có thể cung cấp thể hiện `HttpURLConnection` của riêng mình khi khởi tạo [OpenAIWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Cấu hình một thể hiện HttpURLConnection theo cách của bạn (ví dụ: với thời gian chờ tùy chỉnh, cài đặt proxy, v.v.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Truyền kết nối cho hàm khởi tạo OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}

```

### **Ví dụ Azure OpenAI**

Bạn có thể cấu hình trình dịch để sử dụng triển khai Azure OpenAI của mình với [OpenAICompatibleWebClient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/openaicompatiblewebclient/).

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

Đoạn mã này minh họa cách dịch một bản trình bày bằng endpoint Azure OpenAI của bạn. Thay thế các giá trị placeholder bằng tên triển khai, khóa API và URL endpoint của bạn.

## **Lợi Ích Chính**

API Dịch Trình Chiếu của Aspose.Slides cung cấp giải pháp AI cho việc tạo ra các bản PowerPoint đa ngôn ngữ. Bằng cách tự động hoá quá trình dịch trong khi giữ nguyên bố cục và thiết kế, nó tiết kiệm thời gian và giảm thiểu lỗi so với quy trình thủ công. Dù bạn là nhà phát triển, giáo viên hay chuyên gia kinh doanh, API này cho phép bạn tạo các bản trình bày hấp dẫn, bản địa hoá cho khán giả toàn cầu — mở rộng tầm ảnh hưởng và cải thiện giao tiếp.