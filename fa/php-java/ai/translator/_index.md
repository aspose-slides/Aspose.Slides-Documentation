---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/php-java/ai/translator/
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
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای PHP، اسلایدهای پاورپوینت را با هوش مصنوعی ترجمه کنید. PPT، PPTX و ODP را در حین حفظ چیدمان بومی‌سازی کنید — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی مانند Presentation Translation API را برای محتوای چندزبانه اسلاید ارائه می‌دهد.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesaiagent/) برای ارتباط با سرویس‌های هوش مصنوعی در دسترس است.

شما می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) پیش‌ساخته برای اتصال به API شرکت OpenAI استفاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌صورت هوشمند محتواهای ترجمه‌شده را وارد می‌کند در حالی که چیدمان و قالب‌بندی اصلی اسلایدها حفظ می‌شود.

{{% alert color="info" title="Note" %}}
توجه داشته باشید که API شرکت OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) باید حساب کاربری ایجاد کنید و کلید API خود را فراهم نمایید.
{{% /alert %}}

## **مثال**

در این مثال، ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) و یک [model](https://platform.openai.com/docs/models) مشخص OpenAI به زبان ژاپنی ترجمه می‌کنیم.

```php
// یک ارائه را برای ترجمه بارگذاری کنید.
$presentation = new Presentation("sample.pptx");

// یک کلاینت هوش مصنوعی با OpenAIWebClient ایجاد کنید، مدل و کلید API خود را مشخص کنید.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // ارائه را به زبان ژاپنی ترجمه کنید.
    $aiAgent->translate($presentation, "japanese");

    // ارائه ترجمه‌شده را به عنوان PDF ذخیره کنید.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) داخلی یک نمونه [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار کنترل می‌کند. با این حال، اگر ترجیح می‌دهید خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید — به‌ویژه برای پیکربندی تنظیمات ضروری مانند پروکسی، یا برای استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای مدیریت بهینه منابع و عملکرد — می‌توانید نمونه `HttpURLConnection` خود را هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) ارائه دهید.

```php
// یک نمونه HttpURLConnection خود را ایجاد و پیش‌پیکربندی کنید (زمان‌های انتظار سفارشی، تنظیمات پروکسی، و غیره).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// اتصال را به کلاینت هوش مصنوعی پاس دهید.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **مثال Azure OpenAI**

می‌توانید مترجم را برای استفاده از استقرار Azure OpenAI خود با [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaicompatiblewebclient/) پیکربندی کنید.

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

این قطعه کد نشان می‌دهد که چگونه یک ارائه را با نقطه پایان Azure OpenAI خود ترجمه کنید. مقادیر جایگزین را با نام استقرار، کلید API و URL نقطه پایان خود جایگزین کنید.

## **مزایای کلیدی**

API Presentation Translation Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های چندزبانه PowerPoint ارائه می‌دهد. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان صرفه‌جویی می‌کند و خطاها را نسبت به جریان کار دستی به‌حداقل می‌رساند. چه توسعه‌دهنده، معلم یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌سازی‌شده برای مخاطبان جهانی ایجاد کنید — دامنهٔ دسترسی‌تان را گسترش داده و ارتباطات را بهبود می‌بخشد.