---
title: مترجم ارائه با هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/java/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- ویژگی مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Java ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان حفظ می‌شود — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌ها (PowerPoint) است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی را نیز ارائه می‌دهد - مانند API ترجمه ارائه برای محتوای اسلایدهای چندزبانه.

## **نحوه کار**

Aspose.Slides شامل قابلیت‌های داخلی هوش مصنوعی نیست، اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesaiagent/) نمایش داده می‌شود که از پیاده‌سازی اینترفیس [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید یا پیاده‌سازی خود را از [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) ایجاد کنید تا از ارائه‌دهنده یا مدل زبانی دیگری بهره ببرید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌صورت هوشمند محتواهای ترجمه‌شده را در حالی که چیدمان و قالب‌بندی اصلی اسلاید حفظ می‌شود، وارد می‌کند.

{{% alert color="info" title="Note" %}}
توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) باید یک حساب کاربری ایجاد کرده و کلید API خود را فراهم کنید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی و یک [مدل](https://platform.openai.com/docs/models) مشخص OpenAI به زبان ژاپنی ترجمه می‌کنیم.

```java
import com.aspose.slides.*;

// یک ارائه را برای ترجمه بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");

// یک مشتری هوش مصنوعی با OpenAIWebClient ایجاد کنید، مدل و کلید API خود را مشخص کنید.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با مشتری هوش مصنوعی مقداردهی اولیه کنید.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ارائه را به ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه‌شده را به عنوان PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی یک نمونهٔ داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ایجاد و مدیریت می‌کند و دورهٔ حیات آن را به‌صورت خودکار کنترل می‌نماید. با این حال، اگر مایل باشید خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید — به‌ویژه برای تنظیماتی مانند پراکسی، یا برای استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای بهبود مدیریت منابع و کارایی — می‌توانید نمونهٔ `HttpURLConnection` خود را هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) ارائه دهید.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// یک نمونه HttpURLConnection را خودتان پیکربندی کنید (زمان‌سنجی‌های سفارشی، تنظیمات پراکسی و غیره).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **مثال Azure OpenAI**

می‌توانید مترجم را برای استفاده از استقرار Azure OpenAI خود با [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaicompatiblewebclient/) پیکربندی کنید.

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

این تکه کد نشان می‌دهد که چگونه یک ارائه را با استفاده از نقطهٔ انتهایی Azure OpenAI خود ترجمه کنید. مقادیر جایگزین را با نام استقرار، کلید API و URL نقطهٔ انتهایی خود عوض کنید.

## **مزایای کلیدی**

API ترجمه ارائه Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان را صرفه‌جویی کرده و خطاها را نسبت به فرآیندهای دستی به حداقل می‌رساند. چه توسعه‌دهنده، معلم یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید - دسترسی خود را گسترش داده و ارتباطات را بهبود بخشید.