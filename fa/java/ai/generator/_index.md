---
title: ژنراتور اسلاید چند زبانه با هوش مصنوعی
linktitle: ژنراتور هوش مصنوعی
type: docs
weight: 40
url: /fa/java/ai/generator/
keywords:
- ارائه چند زبانه
- اسلاید چند زبانه
- ژنراتور ارائه هوش مصنوعی
- ژنراتور اسلاید هوش مصنوعی
- قابلیت هوش مصنوعی
- عامل هوش مصنوعی
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "اسلایدهای چند زبانه را از متن با Aspose.Slides برای جاوا تولید کنید. الگوی خود را اعمال کنید و مجموعه‌های صیقلی را به PowerPoint و OpenDocument صادر کنید. بیشتر بیاموزید."
---
## **مقدمه**

Aspose.Slides یک ویژگی جدید مبتنی بر هوش مصنوعی به نام Presentation Generator معرفی می‌کند که به توسعه‌دهندگان امکان می‌دهد ارائه‌های PowerPoint ساختارمند را به‌صورت خودکار از ورودی‌های متنی ساده مانند توصیف موضوع، خلاصه‌ها، نقل‌قول‌ها یا نکات بولت‌دار ایجاد کنند.

کاربران می‌توانند سطح جزئیات محتوا را تنظیم کرده و به‌صورت اختیاری یک قالب سفارشی ارائه را برای تعریف طراحی بصری اعمال کنند.

در حال حاضر، Presentation Generator محتوا را با استفاده از بلوک‌های متنی، فهرست‌های بولت‌دار و جدول‌ها ساختار می‌دهد. تولید تصویر هنوز پشتیبانی نمی‌شود؛ اما می‌توان تصاویر را پس از آن به‌راحتی با ابزارهای Aspose.Slides یا به صورت دستی اضافه کرد.

خروجی یک ارائه کامل PowerPoint است که می‌توان به‌صورت مستقیم استفاده کرد یا به هر فرمتی که API Aspose.Slides پشتیبانی می‌کند صادر نمود. اگرچه این Generator نتایج با کیفیت بالایی تولید می‌کند، ممکن است برای برآورده کردن نیازهای خاص، ویرایش‌های جزئی پس از تولید لازم باشد.

## **نحوه کارکرد**

Aspose.Slides مدل‌های هوش مصنوعی داخلی ندارد؛ در عوض، با خدمات هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این یکپارچه‌سازی توسط کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesaiagent/) انجام می‌شود که از یک پیاده‌سازی از اینترفیس [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) برای ارتباط با مدل هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی استفاده کنید که به API OpenAI متصل می‌شود، یا یک پیاده‌سازی سفارشی از [IAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaiwebclient/) ارائه دهید تا با ارائه‌دهنده هوش مصنوعی یا مدل زبانی دیگری کار کند. Aspose.Slides تمام ارتباطات با سرویس هوش مصنوعی را مدیریت می‌کند و پاسخ‌های هوش مصنوعی را برای تولید اسلایدها پردازش می‌نماید. توجه داشته باشید که API OpenAI یک سرویس پرداختی است، بنابراین هنگام استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) یک حساب کاربری و کلید API مورد نیاز است.

## **بیایید کدنویسی کنیم**

### **مثال ۱**

این مثال نشان می‌دهد چگونه می‌توان با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی، یک ارائه دربارهٔ موضوع Aspose.Slides تولید کرد.

```java
// یک نمونه از OpenAIWebClient ایجاد کنید، پیاده‌سازی داخلی کلاینت وب OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // یک نمونه از SlidesAIAgent ایجاد کنید، که دسترسی به ویژگی‌های مبتنی بر هوش مصنوعی را فراهم می‌کند.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // دستور برای تولید ارائه را تعریف کنید.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // یک ارائه با مقدار متوسط محتوا بر اساس دستور تولید کنید.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // ارائه تولید شده را به‌عنوان فایل PowerPoint (.pptx) در دیسک محلی ذخیره کنید.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **مثال ۲**

مثال زیر بارگذاری‌های متد [generatePresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) را نشان می‌دهد. در این حالت، یک نمونهٔ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) مدیریت‌شده به‌صورت خارجی و «master presentation» کاربر استفاده می‌شود.

به‌صورت پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) داخلی یک نمونهٔ داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را ایجاد و مدیریت می‌کند و چرخهٔ حیات آن را به‌طور خودکار اداره می‌نماید. با این حال، اگر تمایل دارید خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید—به‌عنوان مثال هنگام استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) برای بهبود مدیریت منابع و عملکرد—می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/openaiwebclient/) خودتان یک نمونهٔ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را فراهم کنید.

```java
// HttpURLConnection را به سازنده OpenAIWebClient پاس می‌دهد.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // یک نمونه از SlidesAIAgent ایجاد کنید.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // دستور برای تولید ارائه را تعریف کنید.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // یک ارائهٔ اصلی را از دیسک محلی بارگذاری کنید تا به‌عنوان قالب طراحی استفاده شود.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // یک ارائهٔ دقیق را با استفاده از دستور و قالب اصلی تولید کنید.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // ارائهٔ تولید شده را به‌عنوان PDF ذخیره کنید.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **مزایای کلیدی**

Presentation Generator جدید هوش مصنوعی در Aspose.Slides روشی سریع و انعطاف‌پذیر برای تولید مجموعه‌های اسلاید ساختارمند از درخواست‌های متنی ساده فراهم می‌کند. با پشتیبانی از قالب‌های سفارشی و نمونه‌های [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) مدیریت‌شده به‌صورت خارجی، می‌تواند به‌راحتی در طیف گسترده‌ای از برنامه‌ها یکپارچه شود.

موارد استفاده رایج شامل ایجاد ارائه‌های بازاریابی، مواد آموزشی، گزارش‌های مشتری و مجموعه‌های اسلاید داخلی است. اگرچه تولید تصویر هنوز پشتیبانی نمی‌شود، این ابزار هم‌اکنون پایهٔ محکمی برای خودکارسازی ایجاد ارائه‌ها ارائه می‌دهد و انتظار می‌رود در آینده بهبودهای بیشتری دریافت کند.