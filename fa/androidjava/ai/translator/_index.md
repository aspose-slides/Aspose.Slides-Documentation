---
title: مترجم ارائه‌ای مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/androidjava/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- قابلیت مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- قابلیت‌های هدایت‌شده توسط هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Android از طریق Java ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان حفظ می‌شود—سرعت بالا و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، قابلیت‌های مبتنی بر هوش مصنوعی مانند API ترجمه ارائه برای محتوای اسلایدهای چندزبانه را ارائه می‌دهد.

## **نحوه کار**

Aspose.Slides شامل قابلیت‌های هوش مصنوعی داخلی نیست، اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesaiagent/) که از پیاده‌سازی اینترفیس [IAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند، در دسترس قرار می‌گیرد.

شما می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید یا پیاده‌سازی خودتان از [IAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaiwebclient/) را برای استفاده از فراهم‌کننده هوش مصنوعی یا مدل زبانی دیگری پیاده‌سازی کنید.

Aspose.Slides ارتباط را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌صورت هوشمند محتوی ترجمه‌شده را وارد می‌سازد در حالی که چیدمان و قالب‌بندی اصلی اسلاید حفظ می‌شود.

{{% alert color="info" title="Note" %}}
به‌خاطر داشته باشید که API OpenAI یک سرویس پرداختی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را فراهم کنید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی و با یک [مدل](https://platform.openai.com/docs/models) مشخص OpenAI به زبان ژاپنی ترجمه می‌کنیم.

```java
import com.aspose.slides.*;

// یک ارائه برای ترجمه بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ارائه را به زبان ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه‌شده را به عنوان PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی یک نمونهٔ داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ایجاد و مدیریت می‌کند و عمر آن را به‌صورت خودکار کنترل می‌نماید. با این حال، اگر مایل باشید خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید — به‌ویژه برای پیکربندی تنظیمات اساسی مانند پروکسی، یا برای استفاده از یک [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای مدیریت بهتر منابع و کارایی — می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) نمونهٔ `HttpURLConnection` خود را ارائه دهید.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // یک نمونه HttpURLConnection را خودتان پیکربندی کنید (مثلاً با زمان‌سنجی‌های سفارشی، تنظیمات پروکسی و غیره).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // اتصال را به سازنده OpenAIWebClient پاس دهید.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **مثال Azure OpenAI**

می‌توانید مترجم را طوری پیکربندی کنید که از استقرار Azure OpenAI شما با [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaicompatiblewebclient/) استفاده کند.

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

این قطعه کد نشان می‌دهد که چگونه یک ارائه را با استفاده از نقطهٔ پایان Azure OpenAI شما ترجمه کنید. مقادیر نگه‌دارنده را با نام استقرار، کلید API و آدرس URL نقطهٔ پایان خود جایگزین کنید.

## **مزایای کلیدی**

API ترجمه ارائه Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان را صرفه‌جویی می‌کند و خطاها را نسبت به روش‌های دستی کاهش می‌دهد. چه شما یک توسعه‌دهنده، مدرس یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید — دسترسی خود را گسترش داده و ارتباطات را بهبود می‌بخشد.