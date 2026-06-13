---
title: مترجم ارائه‌های مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/net/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- قابلیت مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های هدایت‌شده توسط هوش مصنوعی
- توانایی‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی و با استفاده از Aspose.Slides برای .NET ترجمه کنید. فایل‌های PPT، PPTX و ODP را در حالی که چیدمان حفظ می‌شود، بومی‌سازی کنید — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **معرفی**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی ارائه می‌دهد ‑ مانند [Presentation Translation API](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/) برای محتوای چندزبانه اسلاید.

## **نحوه کار**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد، اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent) ارائه می‌شود که از یک پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید یا پیاده‌سازی خودتان از [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) را برای استفاده از یک ارائه‌دهنده هوش مصنوعی یا مدل زبانی دیگر بنویسید.

Aspose.Slides ارتباط را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌کند و به صورت هوشمند محتواهای ترجمه‌شده را درج می‌کند در حالی که چیدمان و قالب‌بندی اصلی اسلاید حفظ می‌شود.

{{% alert color="primary" %}}

توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) باید یک حساب کاربری ایجاد کنید و کلید API خود را فراهم کنید.

{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی و یک [مدل](https://platform.openai.com/docs/models) مشخص OpenAI به زبان ژاپنی ترجمه می‌کنیم.

```csharp
// یک ارائه برای ترجمه بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// یک کلاینت هوش مصنوعی با OpenAIWebClient ایجاد کنید و مدل و کلید API خود را مشخص کنید.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// SlidesAIAgent را با کلاینت هوش مصنوعی مقداردهی اولیه کنید.
var aiAgent = new SlidesAIAgent(aiWebClient);

// ارائه را به ژاپنی ترجمه کنید.
await aiAgent.TranslateAsync(presentation, "japanese");

// ارائه ترجمه‌شده را به‌صورت PDF ذخیره کنید.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

به‌صورت پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی یک نمونه داخلی از `HttpClient` ایجاد و مدیریت می‌کند و به‌صورت خودکار دورهٔ حیات و حذف آن را کنترل می‌نماید. اما اگر مایل باشید خودتان `HttpClient` را مدیریت کنید ‑ برای مثال هنگام استفاده از یک [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) برای بهبود مدیریت منابع و کارایی ‑ می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/)، نمونهٔ `HttpClient` خود را به‌عنوان پارامتر فراهم کنید.

```csharp
// فرض کنید یک نمونه IHttpClientFactory دارید (مثلاً از طریق تزریق وابستگی).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides عمدتاً در محیط‌های همزمان استفاده می‌شود. برای پشتیبانی از این امر، کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent/) روش‌های همزمان و غیرهمزمان را ارائه می‌دهد ‑ به‌طوری که بتوانید رویکرد مناسب برای جریان کاری برنامه‌تان را انتخاب کنید.

## **مزایای کلیدی**

API [Presentation Translation API](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/) از Aspose.Slides یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکار کردن ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان را صرفه‌جویی کرده و خطاها را نسبت به روش‌های دستی کاهش می‌دهد. چه توسعه‌دهنده، معلم یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌سازی‌شده برای مخاطبان جهانی ایجاد کنید ‑ که دسترسی شما را گسترش داده و ارتباطات را بهبود می‌بخشد.