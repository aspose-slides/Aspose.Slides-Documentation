---
title: مترجم العروض التقديمية المدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/net/ai/translator/
keywords:
- مترجم عروض تقديمية بالذكاء الاصطناعي
- مترجم شرائح بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض تقديمي متعدد اللغات
- شريحة متعددة اللغات
- ترجمة العروض التقديمية
- ترجمة الشرائح
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
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي مع Aspose.Slides لـ .NET. قم بترجمة PPT و PPTX و ODP مع الحفاظ على النسق—سريع وصديق للمطورين. جرّبه."
---
## **المقدمة**

Aspose.Slides هو واجهة برمجة تطبيقات قوية لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء الشرائح وتحريرها وتحويلها، يوفر ميزات مدعومة بالذكاء الاصطناعي - مثل [Presentation Translation API](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/) لمحتوى الشرائح متعدد اللغات.

## **كيفية العمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يتكامل مع نماذج ذكاء اصطناعي خارجية عبر الإنترنت. يتم كشف هذه الوظيفة عبر فئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/slidesaiagent) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ واجهة [IAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/iaiwebclient/) الخاصة بك لاستخدام مزود ذكاء اصطناعي أو نموذج لغة مختلف.

يتولى Aspose.Slides التعامل مع الاتصال، وتحليل ردود الذكاء الاصطناعي، وإدراج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشريحة الأصلي وتنسيقه.

{{% alert color="info" title="ملاحظة" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نترجم عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/) المدمج مع نموذج OpenAI المحدد.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// تحميل عرض تقديمي للترجمة.
using var presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاصين بك.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
var aiAgent = new SlidesAIAgent(aiWebClient);

// ترجمة العرض التقديمي إلى اللغة اليابانية.
await aiAgent.TranslateAsync(presentation, "japanese");

// حفظ العرض المترجم كملف PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/) بإنشاء وإدارة نسخة داخلية من [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) الخاصة به، مع التعامل مع دورة حياته وتصريفه تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) بنفسك - مثلًا عند استخدام [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) لإدارة الموارد وتحسين الأداء - يمكنك توفير نسخة `HttpClient` الخاصة بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// استخدم HttpClient تديره بنفسك - على سبيل المثال، أحد الأنشاء عبر IHttpClientFactory
// تم حقنه عبر حقن الاعتمادية.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

غالبًا ما يُستخدم Aspose.Slides في بيئات متزامنة. لدعم ذلك، تُقدِّم فئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/slidesaiagent/) طرقًا متزامنة وغير متزامنة - مما يتيح لك اختيار النهج الذي يناسب سير عمل تطبيقك.

### **مثال Azure OpenAI**

يدعم Aspose.Slides لـ .NET مزودي خدمات متوافقين مع OpenAI، بما في ذلك Azure OpenAI. يمكنك تكوين المترجم لاستخدام نشر Azure الداخلي الخاص بك عبر [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaicompatiblewebclient/).

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

يعرض هذا المقتطف كيفية ترجمة عرض باستخدام نقطة نهاية Azure OpenAI الخاصة بك. استبدل القيم الوهمية باسم النشر، ومفتاح API، وعنوان URL للنقطة النهاية.

## **الفوائد الرئيسية**

توفر [Presentation Translation API](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/) من Aspose.Slides حلًا مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التصميم والتنسيق، يوفر الوقت ويقلل من الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا في الأعمال، يتيح لك هذا API إنشاء عروض جذابة ومُحَلية للجماهير العالمية - ما يُوسع من نطاق وصولك ويحسن التواصل.