---
title: مترجم العروض التقديمية المدعم بالذكاء الاصطناعي
linktitle: المترجم المدعم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/net/ai/translator/
keywords:
- مترجم عرض تقديمي بالذكاء الاصطناعي
- مترجم شريحة بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض تقديمي متعدد اللغات
- شريحة متعددة اللغات
- ترجمة العرض التقديمي
- ترجمة الشريحة
- ميزات مدفوعة بالذكاء الاصطناعي
- قدرات الذكاء الاصطناعي
- وكيل الذكاء الاصطناعي
- عميل ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides لـ .NET. قم بتعريب ملفات PPT و PPTX و ODP مع الحفاظ على التخطيط — سريع ومناسب للمطورين. جرّبه."
---

## **API ترجمة العروض التقديمية Aspose.Slides: ترجمة شرائح متعددة اللغات مدعومة بالذكاء الاصطناعي**

Aspose.Slides هو API قوي لإدارة عروض PowerPoint برمجيًا. بالإضافة إلى إنشاء وتعديل وتحويل الشرائح، يقدم ميزات مدعومة بالذكاء الاصطناعي - مثل [Presentation Translation API](https://reference.aspose.com/slides/net/aspose.slides.ai/) لمحتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يندمج مع نماذج ذكاء اصطناعي خارجية عبر الإنترنت. يتم كشف هذه الوظيفة من خلال الفئة [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ واجهة [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) الخاصة بك لاستخدام موفر ذكاء اصطناعي أو نموذج لغوي مختلف.

Aspose.Slides يتولى التواصل، وتحليل ردود الذكاء الاصطناعي، وإدراج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلي.

{{% alert color="primary" %}}
ملاحظة أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذا سيتعين عليك إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نترجم عرض PowerPoint إلى اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) المدمج مع نموذج OpenAI محدد.

```csharp
// Load a presentation to translate.
using var presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialize SlidesAIAgent with the AI client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Translate the presentation to Japanese.
await aiAgent.TranslateAsync(presentation, "japanese");

// Save the translated presentation as a PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

افتراضيًا، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) بإنشاء وإدارة مثيل داخلي من [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) الخاص به، مع معالجة دورة حياته وتفريغه تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) بنفسك - مثلًا عند استخدام [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) لتحسين إدارة الموارد والأداء - يمكنك تزويد مثيل `HttpClient` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Assume you have an IHttpClientFactory instance (e.g., injected via dependency injection).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides يُستخدم عادةً في بيئات متزامنة. لدعم ذلك، توفر فئة [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) كلًا من الأساليب المتزامنة وغير المتزامنة - مما يتيح لك اختيار النهج الذي يناسب سير عمل تطبيقك.

## **الفوائد الرئيسية**

API ترجمة العروض التقديمية Aspose.Slides يقدم حلًا مدعومًا بالذكاء الاصطناعي لتسليم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا في الأعمال، يتيح لك هذا API إنشاء عروض تقديمية جذابة وم lokalized للجماهير العالمية - مما يوسع نطاق وصولك ويحسن التواصل.