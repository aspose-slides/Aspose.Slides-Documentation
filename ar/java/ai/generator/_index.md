---
title: مولد شرائح متعدد اللغات مدعوم بالذكاء الاصطناعي
linktitle: المولد المدعم بالذكاء الاصطناعي
type: docs
weight: 40
url: /ar/java/ai/generator/
keywords:
- عرض متعدد اللغات
- شريحة متعددة اللغات
- مولد عرض تقديمي بالذكاء الاصطناعي
- مولد شرائح بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- وكيل الذكاء الاصطناعي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء شرائح متعددة اللغات من النص باستخدام Aspose.Slides for Java. تطبيق القالب الخاص بك وتصدير العروض المصقولة إلى PowerPoint وOpenDocument. تعرف على المزيد."
---

## **Aspose.Slides Presentation AI API: مولد الشرائح المدعوم بالذكاء الاصطناعي**

تقدم Aspose.Slides ميزة جديدة تعتمد على الذكاء الاصطناعي، مولد العروض التقديمية، والتي تمكّن المطورين من إنشاء عروض PowerPoint ذات هيكل جيد تلقائيًا من مدخلات نصية بسيطة مثل أوصاف الموضوع، الملخصات، الاقتباسات، أو القوائم النقطية.

يمكن للمستخدمين تعديل مستوى تفاصيل المحتوى وتطبيق قالب عرض تقديمي مخصص اختياريًا لتحديد التصميم البصري.

حاليًا، يقوم مولد العروض التقديمية بالذكاء الاصطناعي بترتيب المحتوى باستخدام كتل نصية، قوائم نقطية، وجداول. لا يزال إنشاء الصور غير مدعوم؛ ومع ذلك، يمكن إضافة الصور بسهولة لاحقًا باستخدام أدوات Aspose.Slides أو يدويًا.

الناتج هو عرض PowerPoint كامل يمكن استخدامه كما هو أو تصديره إلى أي تنسيق يدعمه Aspose.Slides API. بينما ينتج المولد نتائج عالية الجودة، قد يتطلب تحرير بسيط بعد الإنشاء لتلبية المتطلبات الخاصة.

## **كيفية العمل**

لا تتضمن Aspose.Slides نماذج ذكاء اصطناعي مدمجة؛ بل تتكامل مع خدمات ذكاء اصطناعي خارجية عبر الإنترنت. يتم التعامل مع هذا التكامل من خلال الفئة [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) للتواصل مع نموذج الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) المدمج، الذي يتصل بواجهة برمجة تطبيقات OpenAI، أو توفير تنفيذ مخصص لـ [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) للعمل مع موفر ذكاء اصطناعي آخر أو نموذج لغة مختلف. تدير Aspose.Slides جميع التواصل مع خدمة الذكاء الاصطناعي وتُعالِج استجاباتها لتوليد الشرائح. لاحظ أن واجهة OpenAI API خدمة مدفوعة، لذلك يتطلب وجود حساب ومفتاح API عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) المدمج.

## **هيا نبرمج**

### **مثال 1**

يوضح هذا المثال كيفية إنشاء عرض تقديمي حول موضوع Aspose.Slides باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) المدمج.
```java
// إنشاء نسخة من OpenAIWebClient، التنفيذ المدمج لعميل الويب OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // إنشاء نسخة من SlidesAIAgent، التي توفر الوصول إلى الميزات المدعومة بالذكاء الاصطناعي.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // تعريف التعليمات لتوليد العرض التقديمي.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // توليد عرض تقديمي بكمية محتوى متوسطة بناءً على التعليمات.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
        // حفظ العرض التقديمي المُولَّد إلى القرص المحلي كملف PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **مثال 2**

يوضح المثال التالي التحميلات الزائدة لطريقة [generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). في هذه الحالة، يتم استخدام نسخة من [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) تتم إدارتها خارجيًا وعرض المستخدم `master presentation`.

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) بإنشاء وإدارة نسخة داخلية من [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) الخاصة به، مع معالجة دورة حياتها تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — على سبيل المثال عند استخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) لتحسين إدارة الموارد والأداء — يمكنك تزويد نسخة من [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// تمرير HttpURLConnection إلى مُنشئ OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // إنشاء نسخة من SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // تعريف التعليمات لتوليد العرض التقديمي.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // تحميل عرض تقديمي رئيسي من القرص المحلي لاستخدامه كقالب تصميم.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // إنشاء عرض تقديمي مفصل باستخدام التعليمات والقالب الرئيسي.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // حفظ العرض التقديمي المُولَّد كملف PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **الفوائد الرئيسية**

يوفر مولد العروض التقديمية بالذكاء الاصطناعي الجديد في Aspose.Slides طريقة سريعة ومرنة لإنتاج مجموعات شرائح منظمة من أوامر نصية بسيطة. مع دعم القوالب المخصصة ونسخ [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) التي يتم إدارتها خارجيًا، يمكن دمجه بسهولة في مجموعة واسعة من التطبيقات.

تشمل حالات الاستخدام النموذجية إنشاء عروض تسويقية، مواد تعليمية، تقارير عملاء، ومجموعات شرائح داخلية. على الرغم من أن إنشاء الصور غير مدعوم بعد، إلا أن الأداة توفر قاعدة قوية لأتمتة إنشاء العروض التقديمية، مع توقع تحسينات إضافية في المستقبل.