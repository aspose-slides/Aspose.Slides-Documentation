---
title: مترجم ارائه‌دار با هوش مصنوعی
linktitle: مترجم هوش مصنوعی
type: docs
weight: 20
url: /fa/nodejs-java/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- قابلیت مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- قابلیت‌های هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Node.js ترجمه کنید. فایل‌های PPT، PPTX و ODP را همزمان با حفظ طرح‌بندی محلی‌سازی کنید — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی ارائه می‌دهد - مانند API ترجمه ارائه برای محتوای چند زبانه اسلایدها.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesaiagent/) برای ارتباط با سرویس‌های هوش مصنوعی در دسترس قرار می‌گیرد.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید.

Aspose.Slides ارتباط را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌صورت هوشمند محتواهای ترجمه‌شده را وارد می‌نماید در حالی که چیدمان و قالب‌بندی اسلاید اصلی حفظ می‌شود.

{{% alert color="info" title="Note" %}}
توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کرده و کلید API خود را فراهم کنید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی و یک [مدل](https://platform.openai.com/docs/models) مشخص از OpenAI ترجمه می‌کنیم.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک ارائه را برای ترجمه بارگذاری کنید.
let presentation = new aspose.slides.Presentation("sample.pptx");

// یک کلاینت هوش مصنوعی با OpenAIWebClient ایجاد کنید، مدل و کلید API خود را مشخص کنید.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // ارائه را به ژاپنی ترجمه کنید.
    aiAgent.translate(presentation, "japanese");

    // ارائه ترجمه‌شده را به‌صورت PDF ذخیره کنید.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

به‌ طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/) داخلی یک نمونه [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلی ایجاد و مدیریت می‌کند و چرخه‌زندگی آن را به‌صورت خودکار اداره می‌نماید. با این حال، اگر ترجیح می‌دهید خودتان [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) را مدیریت کنید — عمدتاً برای تنظیمات ضروری مانند پروکسی، یا استفاده از [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) یا یک [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) متفاوت برای مدیریت بهتر منابع و عملکرد — می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaiwebclient/)، نمونه `HttpURLConnection` خود را ارائه دهید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **مثال Azure OpenAI**

می‌توانید مترجم را طوری تنظیم کنید که از استقرار Azure OpenAI شما با استفاده از [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/openaicompatiblewebclient/) استفاده کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

این قطعه کد نشان می‌دهد که چگونه یک ارائه را با استفاده از نقطهٔ پایان Azure OpenAI شما ترجمه کنید. مقادیر جایگزین‌کننده را با نام استقرار، کلید API و URL نقطهٔ پایان خود جایگزین کنید.

## **مزایای کلیدی**

API ترجمه ارائه Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های چند زبانه PowerPoint فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان صرفه‌جویی می‌کند و نسبت به فرآیندهای دستی خطاها را به‌حداقل می‌رساند. چه توسعه‌دهنده، مدرس یا متخصص کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید — که دامنهٔ دستیابی شما را گسترش داده و ارتباطات را بهبود می‌بخشد.