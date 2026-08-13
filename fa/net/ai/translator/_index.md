---
title: مترجم ارائه هوشمند مبتنی بر هوش مصنوعی
linktitle: مترجم هوشمند مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای .NET ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان حفظ می‌شود — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **معرفی**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی ارائه می‌دهد - مانند [Presentation Translation API](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/) برای محتوای چندزبانه اسلاید.

## **نحوه کارکرد**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد، اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent) در دسترس قرار می‌گیرد که از یک پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) برای برقراری ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی برای اتصال به API شرکت OpenAI استفاده کنید یا خودتان یک پیاده‌سازی از [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) ایجاد کنید تا از ارائه‌دهنده یا مدل زبانی هوش مصنوعی دیگری استفاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به‌طور هوشمند محتویات ترجمه‌شده را وارد می‌سازد در حالی که چیدمان و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="info" %}}
توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را فراهم کنید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به زبان ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی و یک مدل مشخص OpenAI ترجمه می‌کنیم.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// یک ارائه برای ترجمه بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// یک مشتری هوش مصنوعی با OpenAIWebClient ایجاد کنید و مدل و کلید API خود را مشخص کنید.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// SlidesAIAgent را با مشتری هوش مصنوعی مقداردهی اولیه کنید.
var aiAgent = new SlidesAIAgent(aiWebClient);

// ارائه را به زبان ژاپنی ترجمه کنید.
await aiAgent.TranslateAsync(presentation, "japanese");

// ارائه ترجمه‌شده را به‌صورت PDF ذخیره کنید.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

به‌طور پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی یک نمونه داخلی [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ایجاد و مدیریت می‌کند و چرخه‌زندگی و تخلیه آن را به‌صورت خودکار انجام می‌دهد. اما اگر ترجیح می‌دهید خودتان [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) را مدیریت کنید - برای مثال هنگام استفاده از [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) برای مدیریت منابع و عملکرد بهتر - می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) نمونه `HttpClient` خود را فراهم کنید.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// از HttpClient که خودتان مدیریت می‌کنید استفاده کنید - برای مثال، موردی که توسط IHttpClientFactory ایجاد شده است
// از طریق تزریق وابستگی وارد شده است.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides معمولاً در محیط‌های همزمان استفاده می‌شود. برای پشتیبانی از این وضعیت، کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent/) هر دو متد همزمان و ناهمزمان را ارائه می‌دهد - به‌طوری که بتوانید روشی را انتخاب کنید که بهترین تطابق را با جریان کار برنامه شما داشته باشد.

## **مزایای کلیدی**

API [Presentation Translation API](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/) در Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی را حفظ می‌کند، زمان را ذخیره کرده و نسبت به روش‌های دستی خطاها را کاهش می‌دهد. چه شما یک توسعه‌دهنده، معلم یا حرفه‌ای تجاری باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید - دامنه دسترسی شما را گسترش داده و ارتباطات را بهبود می‌بخشد.