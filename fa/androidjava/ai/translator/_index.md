---
title: مترجم ارائه با هوش مصنوعی
linktitle: مترجم هوش مصنوعی
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
- ویژگی‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Android از طریق Java ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که طرح حفظ می‌شود—سرعت بالا و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی مانند Presentation Translation API برای محتوای چندزبانه اسلایدها را ارائه می‌دهد.

## **چگونه کار می‌کند**

Aspose.Slides قابلیت هوش مصنوعی داخلی را ندارد ولی با مدل‌های هوش مصنوعی خارجی از طریق اینترنت ادغام می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesaiagent/) ارائه می‌شود که از پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید یا خودتان رابط [IAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaiwebclient/) را پیاده‌سازی کنید تا از ارائه‌دهنده یا مدل زبانی هوش مصنوعی دیگری بهره‌مند شوید.

Aspose.Slides ارتباط را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌طور هوشمند محتواهای ترجمه‌شده را درج می‌کند در حالی که طرح و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="primary" %}}
توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را فراهم کنید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی به زبان ژاپنی ترجمه می‌کنیم، با یک مدل OpenAI تعیین‌شده.

```java
// یک ارائه برای ترجمه بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با مشتری هوش مصنوعی مقداردهی اولیه کنید.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ارائه را به زبان ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه‌شده را به صورت PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) داخلی یک نمونه داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ایجاد و مدیریت می‌کند و چرخه‌عمر آن را به‌صورت خودکار مدیریت می‌نماید. با این حال، اگر تمایل داشته باشید که خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید — عمدتاً برای پیکربندی تنظیمات ضروری مانند پراکسی، یا برای استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای بهبود مدیریت منابع و عملکرد — می‌توانید هنگام ساخت [OpenAIWebClient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/openaiwebclient/) خود، نمونه `HttpURLConnection` خود را فراهم کنید.

```java
// فرض کنید یک نمونه HttpURLConnection از پیش پیکربندی‌شده دارید (مثلاً با تنظیمات زمان‌سنجی سفارشی، تنظیمات پروکسی، و غیره).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **مزایای کلیدی**

API ترجمه ارائه Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که طرح و طراحی را حفظ می‌کند، زمان را صرفه‌جویی کرده و خطاها را نسبت به جریان‌های کاری دستی به حداقل می‌رساند. چه توسعه‌دهنده، مدرس یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید — که دسترسی شما را گسترش داده و ارتباطات را بهبود می‌بخشد.