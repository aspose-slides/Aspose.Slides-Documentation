---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/php-java/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- ویژگی مجهز به هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های هدایت‌شده توسط هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدهای PowerPoint را با استفاده از هوش مصنوعی و Aspose.Slides برای PHP ترجمه کنید. PPT، PPTX و ODP را به‌صورت بومی‌سازی کنید در حالی که چیدمان حفظ می‌شود—سرعت بالا و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌ای ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی مانند API ترجمه ارائه برای محتوای اسلایدهای چند زبانه را نیز ارائه می‌دهد.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت ادغام می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesaiagent/) در دسترس است تا با سرویس‌های AI ارتباط برقرار کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید.

Aspose.Slides ارتباط را مدیریت می‌کند، پاسخ‌های AI را تجزیه می‌کند و به‌صورت هوشمند محتوی ترجمه‌شده را وارد می‌نماید در حالی که چیدمان و قالب‌بندی اولیه اسلاید حفظ می‌شود.

{{% alert color="primary" %}}
توجه داشته باشید که API OpenAI یک سرویس پرداختی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را فراهم نمایید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) داخلی به زبان ژاپنی ترجمه می‌کنیم، با مشخص کردن مدل OpenAI [مدل](https://platform.openai.com/docs/models).

```php
// یک ارائه را برای ترجمه بارگذاری کنید.
$presentation = new Presentation("sample.pptx");

// یک مشتری هوش مصنوعی با OpenAIWebClient ایجاد کنید و مدل و کلید API خود را مشخص کنید.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با مشتری هوش مصنوعی مقداردهی اولیه کنید.
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

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) داخلی یک نمونه داخلی [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار مدیریت می‌نماید. با این حال، اگر ترجیح می‌دهید خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید — عمدتاً برای پیکربندی تنظیمات ضروری مانند پروکسی، یا استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای مدیریت بهتر منابع و کارایی — می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/php-java/aspose.slides/openaiwebclient/) نمونه `HttpURLConnection` خود را ارائه دهید.

```php
// فرض کنید یک نمونه HttpURLConnection پیش‌پیکربندی شده دارید (مثلاً با زمان‌سنجی‌های سفارشی، تنظیمات پراکسی و غیره).
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **فواید کلیدی**

API ترجمه ارائه Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چند زبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان را صرفه‌جویی می‌کند و خطاها را نسبت به جریان‌های کاری دستی به حداقل می‌رساند. چه توسعه‌دهنده، مدرس یا حرفه‌ای کسب‌وکار باشید، این API امکان ایجاد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی را فراهم می‌آورد — دامنهٔ شما را گسترش می‌دهد و ارتباطات را بهبود می‌بخشد.