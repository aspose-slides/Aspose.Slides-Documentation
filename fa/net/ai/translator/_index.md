---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/net/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- ویژگی هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- مشتری وب
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای پاورپوینت را با هوش مصنوعی و استفاده از Aspose.Slides برای .NET ترجمه کنید. محلی‌سازی PPT، PPTX و ODP در حالی که طرح حفظ می‌شود—سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی مانند [Presentation Translation API](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/) را برای محتوای چندزبانه ارائه می‌دهد.

## **نحوه کارکرد**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد اما از طریق اینترنت با مدل‌های هوش مصنوعی خارجی یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent) افشا می‌شود که از یک پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient) پیش‌فرض برای اتصال به API اوپن‌ای‌آی استفاده کنید یا پیاده‌سازی خودتان از [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient) را برای استفاده از ارائه‌دهنده یا مدل زبانی متفاوت پیاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌نماید و به‌صورت هوشمندانه محتوای ترجمه‌شده را در حالی که طرح و قالب‌بندی اسلاید اصلی را حفظ می‌کند، درج می‌کند.

{{% alert color="info" title="نکته" %}}
نکته این است که API اوپن‌ای‌آی یک سرویس پرداختی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient) باید یک حساب کاربری ایجاد کنید و کلید API خود را ارائه دهید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient) پیش‌فرض و یک [model](https://platform.openai.com/docs/models) مشخص اوپن‌ای‌آی به زبان ژاپنی ترجمه می‌کنیم.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// یک ارائه را برای ترجمه بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// یک کلاینت هوش مصنوعی با OpenAIWebClient ایجاد کنید و مدل و کلید API خود را مشخص کنید.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
var aiAgent = new SlidesAIAgent(aiWebClient);

// ارائه را به زبان ژاپنی ترجمه کنید.
await aiAgent.TranslateAsync(presentation, "japanese");

// ارائه ترجمه‌شده را به عنوان PDF ذخیره کنید.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient) یک نمونه داخلی [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ایجاد و مدیریت می‌کند و چرخه عمر و حذف آن را به‌صورت خودکار انجام می‌دهد. با این حال، اگر ترجیح می‌دهید خودتان [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) را مدیریت کنید—مثلاً هنگام استفاده از یک [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) برای مدیریت بهتر منابع و کارایی—می‌توانید نمونه `HttpClient` خود را هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient) فراهم کنید.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// از یک HttpClient که خودتان مدیریت می‌کنید استفاده کنید - برای مثال، یکی که توسط IHttpClientFactory ایجاد شده است
// تزریق شده از طریق تزریق وابستگی.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides معمولاً در محیط‌های همزمان استفاده می‌شود. برای پشتیبانی از این موضوع، کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent/) هر دو متد همزمان و ناهمزمان را ارائه می‌دهد—به‌طوری که می‌توانید رویکرد مناسب برای جریان کاری برنامه خود را انتخاب کنید.

### **مثال Azure OpenAI**

Aspose.Slides برای .NET از ارائه‌دهندگان سازگار با OpenAI، از جمله Azure OpenAI، پشتیبانی می‌کند. می‌توانید مترجم را برای استفاده از استقرار داخلی Azure خود با [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaicompatiblewebclient) تنظیم کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

این کد نمونه نشان می‌دهد که چگونه یک ارائه را با استفاده از نقطه انتهایی Azure OpenAI خود ترجمه کنید. مقادیر جایگزین را با نام استقرار، کلید API و URL نقطه انتهایی خود جایگزین کنید.

## **فواید کلیدی**

API [Presentation Translation API](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/) در Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که طرح و طراحی را حفظ می‌کند، زمان را صرفه‌جویی کرده و نسبت به کارهای دستی خطاها را به حداقل می‌رساند. چه توسعه‌دهنده، معلم یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبین جهانی ایجاد کنید—دسترس‌پذیری خود را گسترش داده و ارتباطات را بهبود می‌بخشد.