---
title: مولد شرائح متعدد اللغات مدعوم بالذكاء الاصطناعي
linktitle: مولد مدعوم بالذكاء الاصطناعي
type: docs
weight: 40
url: /ar/net/ai/generator/
keywords:
- عرض متعدد اللغات
- شريحة متعددة اللغات
- مولد عروض تقديمية بالذكاء الاصطناعي
- مولد شرائح بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- وكيل ذكاء اصطناعي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء شرائح متعددة اللغات من النص باستخدام Aspose.Slides for .NET. تطبيق القالب الخاص بك وتصدير العروض المصقولة إلى PowerPoint وOpenDocument. تعرف على المزيد."
---

## **Aspose.Slides Presentation AI API: مُولِّد الشرائح المدعوم بالذكاء الاصطناعي**

تقدم Aspose.Slides ميزة جديدة مدعومة بالذكاء الاصطناعي، مُولِّد العروض التقديمية، التي تمكن المطورين من إنشاء عروض PowerPoint منظمة تلقائيًا من إدخالات نصية بسيطة مثل أوصاف المواضيع، والملخصات، والاقتباسات، أو القوائم النقطية.

يمكن للمستخدمين تعديل مستوى تفاصيل المحتوى وتطبيق قالب عرض تقديمي مخصص اختياريًا لتحديد التصميم المرئي.

حاليًا، يقوم مُولِّد العروض التقديمية بالذكاء الاصطناعي بترتيب المحتوى باستخدام كتل نصية، وقوائم نقطية، وجداول. توليد الصور غير مدعوم بعد؛ ومع ذلك، يمكن إضافة الصور بسهولة لاحقًا باستخدام أدوات Aspose.Slides أو يدويًا.

الناتج هو عرض PowerPoint مكتمل يمكن استخدامه كما هو أو تصديره إلى أي تنسيق يدعمه Aspose.Slides API. بينما ينتج المُولِّد نتائج عالية الجودة، قد يلزم بعض التعديل بعد الإنشاء لتلبية المتطلبات المحددة.

## **كيف يعمل**

لا يتضمن Aspose.Slides نماذج ذكاء اصطناعي مدمجة؛ بل يتكامل مع خدمات ذكاء اصطناعي خارجية عبر الإنترنت. يتم التعامل مع هذا التكامل بواسطة الفئة [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/)، التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) للتواصل مع نموذج الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) المدمج، الذي يتصل بواجهة برمجة تطبيقات OpenAI، أو تزويد تنفيذ مخصص لواجهة [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) للعمل مع مزود ذكاء اصطناعي آخر أو نموذج لغة مختلف. تدير Aspose.Slides جميع الاتصالات مع خدمة الذكاء الاصطناعي وتعالج استجاباتها لإنشاء الشرائح. لاحظ أن واجهة OpenAI API خدمة مدفوعة، لذا يتطلب وجود حساب ومفتاح API عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) المدمج.

## **لنكتب الكود**

### **مثال 1**

يوضح هذا المثال كيفية إنشاء عرض تقديمي حول موضوع Aspose.Slides باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) المدمج.

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **مثال 2**

يوضح المثال التالي التحميلات المتعددة للطريقة [GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/). في هذه الحالة، يتم استخدام نسخة من [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) يتم إدارتها خارجيًا وعرض `master presentation` الخاص بالمستخدم.

افتراضيًا، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) بإنشاء وإدارة نسخة داخلية من [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) الخاصة به، مع معالجة دورة حياتها وإتلافها تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) بنفسك—على سبيل المثال عند استخدام [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) لتحسين إدارة الموارد والأداء—يمكنك توفير نسخة من [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

جدير بالذكر أن العديد من العملاء يستخدمون Aspose.Slides في سياقات متزامنة. لدعم ذلك، توفر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) كلًا من الطرق المتزامنة واللا متزامنة، مما يتيح لك اختيار النهج الأنسب لتدفق عمل تطبيقك.

## **الفوائد الرئيسية**

يقدم مُولِّد العروض التقديمية بالذكاء الاصطناعي الجديد في Aspose.Slides طريقة سريعة ومرنة لإنتاج مجموعات شرائح منظمة من موجهات نصية بسيطة. مع دعم القوالب المخصصة، وإدارة خارجية لنسخ [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)، والطرق المتزامنة واللا متزامنة، يمكن دمجه بسلاسة في مجموعة واسعة من التطبيقات.

تشمل الحالات النموذجية الاستخدام إنشاء عروض تسويقية، مواد تعليمية، تقارير عملاء، ومجموعات شرائح داخلية. على الرغم من أن توليد الصور غير مدعوم بعد، إلا أن الأداة توفر بالفعل أساسًا قويًا لأتمتة إنشاء العروض التقديمية، ومن المتوقع تحسينات إضافية في المستقبل.