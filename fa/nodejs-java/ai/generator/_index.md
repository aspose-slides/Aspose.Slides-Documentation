---
title: "مولد اسلاید چندزبانه مبتنی بر هوش مصنوعی"
linktitle: "ژنراتور مبتنی بر هوش مصنوعی"
type: docs
weight: 40
url: /fa/nodejs-java/ai/generator/
keywords:
- "ارائه چندزبانه"
- "اسلاید چندزبانه"
- "ژنراتور ارائه هوش مصنوعی"
- "ژنراتور اسلاید هوش مصنوعی"
- "ویژگی مبتنی بر هوش مصنوعی"
- "عامل هوش مصنوعی"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "اسلایدهای چندزبانه را از متن با Aspose.Slides برای Node.js تولید کنید. الگوی خود را اعمال کنید و مجموعه‌های صیقلی را به PowerPoint و OpenDocument صادر نمایید. بیشتر بیاموزید."
---
## **مقدمه**

Aspose.Slides یک ویژگی جدید مبتنی بر هوش مصنوعی به نام Presentation Generator معرفی می‌کند که به توسعه‌دهندگان امکان می‌دهد به‌طور خودکار ارائه‌های PowerPoint ساختارمند را از ورودی‌های متنی ساده‌ای مانند توصیف موضوع، خلاصه‌ها، نقل‌قول‌ها یا نکات بولت‌دار ایجاد کنند.

کاربران می‌توانند سطح جزئیات محتوا را تنظیم کنند و به‌صورت اختیاری یک الگوی سفارشی ارائه اعمال کنند تا طراحی بصری را تعریف نمایند.

در حال حاضر، AI Presentation Generator محتوا را با استفاده از بلوک‌های متنی، فهرست‌های بولت‌دار و جداول ساختار می‌دهد. تولید تصویر هنوز پشتیبانی نمی‌شود؛ اما می‌توان به‌راحتی بعداً با استفاده از ابزارهای Aspose.Slides یا به‌صورت دستی تصاویر را اضافه کرد.

خروجی یک ارائه کامل PowerPoint است که می‌تواند به‌صورت مستقیم استفاده شود یا به هر فرمت پشتیبانی‌شده توسط API Aspose.Slides صادر شود. اگرچه ژنراتور نتایج با کیفیت بالا تولید می‌کند، ممکن است برای برآورده کردن نیازهای خاص، ویرایش جزئی پس از تولید لازم باشد.

## **چگونه کار می‌کند**

Aspose.Slides شامل مدل‌های هوش مصنوعی داخلی نیست؛ در عوض، با سرویس‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این یکپارچه‌سازی توسط کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesaiagent/) مدیریت می‌شود.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی استفاده کنید که به API OpenAI متصل می‌شود. Aspose.Slides تمام ارتباط با سرویس هوش مصنوعی را مدیریت می‌کند و پاسخ‌های AI را پردازش می‌نماید تا اسلایدها را تولید کند. توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی نیاز به حساب کاربری و کلید API دارید.

## **بیایید کد بنویسیم**

### **مثال 1**

این مثال نشان می‌دهد چگونه می‌توان یک ارائه درباره موضوع Aspose.Slides را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی تولید کرد.

```js
// یک نمونه از OpenAIWebClient ایجاد کنید، پیاده‌سازی داخلی مشتری وب OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // یک نمونه از SlidesAIAgent ایجاد کنید که دسترسی به ویژگی‌های مبتنی بر هوش مصنوعی را فراهم می‌کند.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // دستورالعمل برای تولید ارائه را تعریف کنید.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // یک ارائه با میزان محتوا متوسط بر اساس دستورالعمل تولید کنید.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // ارائه تولید شده را به‌عنوان فایل PowerPoint (.pptx) در دیسک محلی ذخیره کنید.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **مثال 2**

مثال زیر overloadهای متد [generatePresentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) را نشان می‌دهد. در این حالت، یک نمونه [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) مدیریت‌شده به‌صورت خارجی و `master presentation` کاربر استفاده می‌شود.

به طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی یک نمونه داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار کنترل می‌نماید. اما اگر ترجیح می‌دهید [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را خودتان مدیریت کنید—مثلاً هنگام استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) برای بهبود مدیریت منابع و کارایی—می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/)، نمونه خودتان از [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را فراهم کنید.

```js
// HttpURLConnection را به سازنده OpenAIWebClient منتقل کنید.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // یک نمونه از SlidesAIAgent ایجاد کنید.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // دستورالعمل برای تولید ارائه را تعریف کنید.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // یک ارائه اصلی را از دیسک محلی بارگذاری کنید تا به‌عنوان قالب طراحی استفاده شود.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // یک ارائه دقیق را با استفاده از دستورالعمل و قالب اصلی تولید کنید.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // ارائه تولید شده را به‌صورت PDF ذخیره کنید.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **مزایای کلیدی**

ژنراتور جدید AI Presentation Generator در Aspose.Slides روشی سریع و انعطاف‌پذیر برای تولید مجموعه اسلایدهای ساختارمند از ورودی‌های متنی ساده فراهم می‌کند. با پشتیبانی از قالب‌های سفارشی و نمونه‌های [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) مدیریت‌شده به‌صورت خارجی، می‌تواند به‌سلاست در طیف وسیعی از برنامه‌ها یکپارچه شود.

موارد استفاده معمول شامل ایجاد ارائه‌های بازاریابی، مواد آموزشی، گزارش‌های مشتری و مجموعه اسلایدهای داخلی است. اگرچه تولید تصویر هنوز پشتیبانی نمی‌شود، این ابزار در حال حاضر پایه‌ای قوی برای خودکارسازی ایجاد ارائه‌ها فراهم می‌کند و انتظار می‌رود در آینده بهبودهای بیشتری دریافت کند.