---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/java/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- قابلیت مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- قابلیت‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- پاورپوینت
- سند باز
- ارائه
- جاوا
- Aspose.Slides
description: "اسلایدهای پاورپوینت را با هوش مصنوعی با استفاده از Aspose.Slides برای جاوا ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان را حفظ می‌کنید—سرعت بالا و مناسب برای توسعه‌دهندگان. همین حالا امتحان کنید."
---
## **معرفی**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌ای ارائه‌ها (PowerPoint) است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی ارائه می‌دهد - مانند API ترجمه ارائه برای محتوای چندزبانه اسلایدها.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesaiagent/) در دسترس قرار می‌گیرد که از پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) برای برقراری ارتباط با خدمات هوش مصنوعی استفاده می‌کند.

شما می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی برای اتصال به API اوپن‌ای‌آی استفاده کنید یا پیاده‌سازی خودتان از [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) را برای استفاده از ارائه‌دهنده یا مدل زبانی هوش مصنوعی مختلف ایجاد کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌نماید و به‌صورت هوشمند محتواهای ترجمه‌شده را وارد می‌کند، در حالی که طرح و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="info" %}}
توجه داشته باشید که API اوپن‌ای‌آی یک سرویس پرداختی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را ارائه دهید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به زبان ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی و با یک [مدل](https://platform.openai.com/docs/models) مشخص اوپن‌ای‌آی ترجمه می‌کنیم.

```java
import com.aspose.slides.*;

// یک ارائه را برای ترجمه بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ارائه را به زبان ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه شده را به‌صورت PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی یک نمونه داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار کنترل می‌نماید. اما اگر ترجیح می‌دهید [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را خودتان مدیریت کنید — عمدتاً برای پیکربندی تنظیمات اساسی مانند پراکسی، یا برای استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای مدیریت بهتر منابع و عملکرد — می‌توانید نمونه `HttpURLConnection` خود را هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) فراهم کنید.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// یک نمونه HttpURLConnection را به‌صورت دستی پیکربندی کنید (زمان‌های انتظار سفارشی، تنظیمات پراکسی و غیره).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **فواید کلیدی**

API ترجمه ارائه Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه پاورپوینت‌های چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که طرح و طراحی را حفظ می‌کند، زمان را صرفه‌جویی می‌کند و نسبت به گردش کارهای دستی خطاها را به حداقل می‌رساند. چه توسعه‌دهنده، مدرس یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و محلی‌سازی‌شده برای مخاطبان جهانی ایجاد کنید — دامنهٔ دسترسی‌تان را گسترش داده و ارتباطات را بهبود می‌بخشد.