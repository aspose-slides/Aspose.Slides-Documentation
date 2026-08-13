---
title: مترجم العروض التقديمية بالذكاء الاصطناعي
linktitle: مترجم مدعم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/net/ai/translator/
keywords:
- مترجم عروض تقديمية بالذكاء الاصطناعي
- مترجم شرائح بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض تقديمي متعدد اللغات
- شريحة متعددة اللغات
- ترجمة العرض التقديمي
- ترجمة الشريحة
- ميزات مدفوعة بالذكاء الاصطناعي
- قدرات الذكاء الاصطناعي
- وكيل الذكاء الاصطناعي
- عميل الويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي مع Aspose.Slides لـ .NET. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط—بسرعة وسهولة للمطورين. جرّبها."
---
## **المقدمة**

Aspose.Slides هي واجهة برمجة تطبيقات قوية لإدارة عروض PowerPoint برمجيًا. بالإضافة إلى إنشاء وتحرير وتحويل الشرائح، تقدم ميزات مدفوعة بالذكاء الاصطناعي - مثل [Presentation Translation API](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/) لمحتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا تتضمن قدرات ذكاء اصطناعي مدمجة ولكنها تتكامل مع نماذج ذكاء اصطناعي خارجية عبر الإنترنت. يتم إتاحة هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/slidesaiagent) التي تستخدم تنفيذًا للواجهة [IAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ واجهتك الخاصة [IAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/iaiwebclient/) لاستخدام مزود ذكاء اصطناعي أو نموذج لغة مختلف.

يتولى Aspose.Slides عملية التواصل، وتحليل استجابات الذكاء الاصطناعي، وإدراج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشريحة الأصلي وتنسيقه.

{{% alert color="info" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/) المدمج مع نموذج OpenAI محدد.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// تحميل عرض تقديمي للترجمة.
using var presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، وتحديد النموذج ومفتاح API الخاصين بك.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
var aiAgent = new SlidesAIAgent(aiWebClient);

// ترجمة العرض التقديمي إلى اللغة اليابانية.
await aiAgent.TranslateAsync(presentation, "japanese");

// حفظ العرض التقديمي المترجم كملف PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/) بإنشاء وإدارة مثيل داخلي من `HttpClient` الخاص به، مع معالجة دورة حياته والتخلص منه تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة `HttpClient` بنفسك - مثلًا عند استخدام [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) لإدارة الموارد وتحسين الأداء - يمكنك تمرير مثيل `HttpClient` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// استخدم HttpClient تديره بنفسك - على سبيل المثال، أحد التي تم إنشاؤها بواسطة IHttpClientFactory
// تم حقنه عبر حقن الاعتماديات.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

عادةً ما يُستخدم Aspose.Slides في بيئات متزامنة. لدعم ذلك، تُوفر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/slidesaiagent/) كلًا من الأساليب المتزامنة وغير المتزامنة - مما يتيح لك اختيار النهج الأنسب لسير عمل تطبيقك.

## **الفوائد الرئيسية**

توفر Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/ar/net/aspose.slides.ai/) حلاً مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، يمكّنك هذا API من إنشاء عروض جذابة ومُعربة للجمهور العالمي - مما يوسع نطاق وصولك ويحسن التواصل.