---
title: مترجم ارائهٔ مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/java/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- قابلیت مبتنی بر هوش مصنوعی
- ارائه چند زبانه
- اسلاید چند زبانه
- ترجمهٔ ارائه
- ترجمهٔ اسلاید
- قابلیت‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای جاوا ترجمه کنید. فایل‌های PPT، PPTX و ODP را محلی‌سازی کنید در حالی که طرح‌بندی حفظ می‌شود — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی‌محور ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی مانند API ترجمه ارائه برای محتوای اسلایدهای چند زبانه را ارائه می‌دهد.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی را شامل نمی‌شود اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesaiagent/) در دسترس قرار می‌گیرد که از پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی برای اتصال به API شرکت OpenAI استفاده کنید یا [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) خود را پیاده‌سازی کنید تا از ارائه‌دهنده هوش مصنوعی یا مدل زبانی دیگری استفاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه و تحلیل می‌نمود و به‌طور هوشمندانه محتوی ترجمه‌شده را وارد می‌کند در حالی که طرح و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="primary" %}}

توجه داشته باشید که API شرکت OpenAI یک سرویس پرداختی است، بنابراین هنگام استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را وارد نمایید.

{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به زبان ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی و مدل مشخص‌شده OpenAI ترجمه می‌کنیم.

```java
// یک ارائه را برای ترجمه بارگذاری کنید.
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

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی یک نمونه [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلی ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار کنترل می‌دارد. اما اگر ترجیح می‌دهید [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را خودتان مدیریت کنید — عمدتاً برای پیکربندی تنظیمات اساسی مانند یک پروکسی، یا برای استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت به‌منظور بهبود مدیریت منابع و عملکرد — می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/)، نمونه `HttpURLConnection` خود را ارائه دهید.

```java
// فرض کنید یک نمونه HttpURLConnection پیش‌پیکربندی‌شده دارید (مثلاً با زمان‌سنجی‌های سفارشی، تنظیمات پروکسی و غیره).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **مزایای کلیدی**

API ترجمه ارائه Aspose.Slides یک راه حل مبتنی بر هوش مصنوعی برای ارائه ارائه‌های PowerPoint چند زبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که طرح و طراحی را حفظ می‌کند، زمان را صرفه‌جویی کرده و نسبت به جریان‌های کاری دستی خطاها را به حداقل می‌رساند. چه توسعه‌دهنده، معلم یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید — دامنهٔ دسترسی شما را گسترش داده و ارتباطات را بهبود می‌بخشد.