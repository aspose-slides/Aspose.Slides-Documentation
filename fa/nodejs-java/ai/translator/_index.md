---
title: مترجم ارائه‌ای مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Node.js ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان حفظ می‌شود - سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **معرفی**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌ای ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، این API ویژگی‌های مبتنی بر هوش مصنوعی را ارائه می‌دهد - مانند Presentation Translation API برای محتوای چندزبانه اسلایدها.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت ادغام می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesaiagent/) برای ارتباط با سرویس‌های هوش مصنوعی در دسترس است.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی برای اتصال به API شرکت OpenAI استفاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌صورت هوشمند محتویات ترجمه‌شده را درج می‌نماید در حالی که چیدمان و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="primary" %}}
توجه داشته باشید که API شرکت OpenAI یک سرویس پرداختی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را ارائه دهید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به زبان ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی و یک مدل مشخص OpenAI ترجمه می‌کنیم.

```js
// یک ارائه برای ترجمه بارگیری کنید.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // ارائه را به زبان ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه‌شده را به صورت PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی یک نمونه `HttpURLConnection` داخلی ایجاد و مدیریت می‌کند و چرخه حیات آن را به‌صورت خودکار اداره می‌نماید. اما اگر ترجیح می‌دهید `HttpURLConnection` را خودتان مدیریت کنید — عمدتاً برای پیکربندی تنظیمات اساسی مانند پراکسی، یا برای استفاده از `URLStreamHandlerFactory` یا یک `HttpClient` متفاوت برای بهبود مدیریت منابع و عملکرد — می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/)، نمونه `HttpURLConnection` خود را ارائه دهید.

```js
// فرض کنید یک نمونه HttpURLConnection پیش‌پیکربندی‌شده دارید (مثلاً با زمان‌سنجی‌های سفارشی، تنظیمات پراکسی، و غیره).
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **مزایای کلیدی**

API Presentation Translation Aspose.Slides یک راهکار مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی را حفظ می‌کند، زمان را ذخیره می‌کند و خطاها را نسبت به گردش کارهای دستی به حداقل می‌رساند. چه توسعه‌دهنده، مدرس یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید — که دامنه دسترسی شما را گسترش و ارتباطات را بهبود می‌بخشد.