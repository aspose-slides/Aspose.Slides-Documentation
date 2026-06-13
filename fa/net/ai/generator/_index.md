---
title: ژنراتور اسلاید چندزبانه مبتنی بر هوش مصنوعی
linktitle: ژنراتور مبتنی بر هوش مصنوعی
type: docs
weight: 40
url: /fa/net/ai/generator/
keywords:
- ارائه چندزبانه
- اسلاید چندزبانه
- ژنراتور ارائه هوش مصنوعی
- ژنراتور اسلاید هوش مصنوعی
- ویژگی مبتنی بر هوش مصنوعی
- عامل هوش مصنوعی
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای چندزبانه را از متن با Aspose.Slides برای .NET تولید کنید. قالب خود را اعمال کنید و دک‌های صیقلی را به PowerPoint و OpenDocument صادر کنید. برای اطلاعات بیشتر مطالعه کنید."
---
## **معرفی**

Aspose.Slides ویژگی جدیدی با قابلیت هوش مصنوعی به نام Presentation Generator معرفی می‌کند که به توسعه‌دهندگان امکان می‌دهد به‌صورت خودکار ارائه‌های PowerPoint به‌صورت ساختار یافته را از ورودی‌های متن ساده مانند توصیف موضوع، خلاصه‌ها، نقل‌قول‌ها یا نکات گلوله‌ای ایجاد کنند.

کاربران می‌توانند سطح جزئیات محتوا را تنظیم کنند و به‌صورت اختیاری یک قالب ارائه سفارشی را برای تعریف طرح بصری اعمال نمایند.

در حال حاضر، Presentation Generator محتوا را با استفاده از بلوک‌های متنی، فهرست‌های گلوله‌ای و جداول ساختار می‌دهد. تولید تصویر هنوز پشتیبانی نمی‌شود؛ اما می‌توانید پس از آن به‌راحتی با ابزارهای Aspose.Slides یا به‌صورت دستی تصاویر را اضافه کنید.

خروجی یک ارائه کامل PowerPoint است که می‌توان به‌صورت مستقیم استفاده کرد یا به هر فرمتی که API Aspose.Slides پشتیبانی می‌کند صادر شد. اگرچه Generator نتایج با کیفیت بالایی تولید می‌کند، ممکن است برای رفع نیازهای خاص ویرایش‌های جزئی بعدی لازم باشد.

## **چگونه کار می‌کند**

Aspose.Slides مدل‌های هوش مصنوعی داخلی را شامل نمی‌شود؛ در عوض، با سرویس‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این یکپارچه‌سازی توسط کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent/) مدیریت می‌شود که از پیاده‌سازی رابط [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) برای ارتباط با مدل هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی که به API OpenAI وصل می‌شود استفاده کنید، یا یک پیاده‌سازی سفارشی از [IAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/iaiwebclient/) برای کار با فراهم‌کننده هوش مصنوعی یا مدل زبانی دیگر ارائه دهید. Aspose.Slides تمام ارتباطات با سرویس هوش مصنوعی را مدیریت کرده و پاسخ‌های هوش مصنوعی را پردازش می‌کند تا اسلایدها را تولید کند. توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) باید حساب کاربری و کلید API داشته باشید.

## **بیایید کدنویسی کنیم**

### **مثال ۱**

این مثال نشان می‌دهد چگونه می‌توان یک ارائه در مورد Aspose.Slides با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی تولید کرد.

```csharp
// یک نمونه از OpenAIWebClient ایجاد کنید، پیاده‌سازی داخلی مشتری وب OpenAI.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// یک نمونه از SlidesAIAgent ایجاد کنید، که دسترسی به ویژگی‌های مبتنی بر هوش مصنوعی را فراهم می‌کند.
var aiAgent = new SlidesAIAgent(aiWebClient);

// دستورالعمل برای تولید ارائه را تعریف کنید.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// بر پایه دستورالعمل، ارائه‌ای با مقدار محتوا متوسط تولید کنید.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// ارائه تولید شده را به عنوان فایل PowerPoint (.pptx) در دیسک محلی ذخیره کنید.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **مثال ۲**

مثال زیر بارگذاری‌های (overloads) متد [GeneratePresentation](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent/generatepresentation/) را نشان می‌دهد. در این حالت، یک نمونه [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) که به‌صورت خارجی مدیریت می‌شود و `master presentation` کاربر استفاده می‌شود.

به‌صورت پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) داخلی یک نمونه داخلی [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ایجاد و مدیریت می‌کند و چرخه حیات و حذف آن را به‌صورت خودکار انجام می‌دهد. اما اگر ترجیح می‌دهید خودتان [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) را مدیریت کنید—به‌عنوان مثال هنگام استفاده از [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) برای بهبود مدیریت منابع و عملکرد—می‌توانید هنگام ساختن [OpenAIWebClient](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/openaiwebclient/) نمونه خودتان از [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) را ارائه دهید.

```csharp
// یک نمونه HttpClient که به‌صورت خارجی مدیریت می‌شود ایجاد کنید.
using var httpClient = new HttpClient();

// HttpClient را به سازنده OpenAIWebClient منتقل کنید.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// یک نمونه از SlidesAIAgent ایجاد کنید.
var aiAgent = new SlidesAIAgent(aiWebClient);

// دستورالعمل برای تولید ارائه را تعریف کنید.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// یک ارائه اصلی را از دیسک محلی بارگذاری کنید تا به‌عنوان قالب طراحی استفاده شود.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// با استفاده از دستورالعمل و قالب اصلی یک ارائه دقیق تولید کنید.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// ارائه تولید شده را به‌صورت PDF ذخیره کنید.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

شایان ذکر است که بسیاری از مشتریان از Aspose.Slides در زمینه‌های همزمان (synchronous) استفاده می‌کنند. برای پشتیبانی از این، کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/net/aspose.slides.ai/slidesaiagent/) هر دو روش همزمان و ناهمزمان را فراهم می‌کند تا بتوانید رویکردی که بهترین تطابق را با جریان کاری برنامه‌تان دارد انتخاب کنید.

## **مزایای کلیدی**

Generator ارائه هوش مصنوعی جدید در Aspose.Slides روشی سریع و انعطاف‌پذیر برای تولید مجموعه اسلایدهای ساختار یافته از درخواست‌های متنی ساده فراهم می‌کند. با پشتیبانی از قالب‌های سفارشی، نمونه‌های [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) به‌صورت خارجی مدیریت‌شده و هر دو جریان کاری همزمان و ناهمزمان، می‌تواند به‌سادگی در طیف وسیعی از برنامه‌ها یکپارچه شود.

موارد استفاده معمول شامل ایجاد ارائه‌های بازاریابی، مطالب آموزشی، گزارش‌های مشتری و مجموعه اسلایدهای داخلی است. اگرچه تولید تصویر هنوز پشتیبانی نمی‌شود، این ابزار پیش‌زمینه قوی‌ای برای خودکارسازی ایجاد ارائه‌ها ارائه می‌دهد و به‌روزرسانی‌های بیشتری در آینده انتظار می‌رود.