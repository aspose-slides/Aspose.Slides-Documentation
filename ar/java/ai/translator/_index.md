---
title: مترجم العروض التقديمية المدعوم بالذكاء الاصطناعي
linktitle: المترجم المدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/java/ai/translator/
keywords:
- مترجم العروض التقديمية بالذكاء الاصطناعي
- مترجم الشرائح بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض تقديمي متعدد اللغات
- شريحة متعددة اللغات
- ترجمة العروض التقديمية
- ترجمة الشرائح
- ميزات مدفوعة بالذكاء الاصطناعي
- إمكانات الذكاء الاصطناعي
- عميل الذكاء الاصطناعي
- عميل ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بترجمة شرائح PowerPoint باستخدام الذكاء الاصطناعي مع Aspose.Slides للـ Java. قم بتوطين ملفات PPT و PPTX و ODP مع الحفاظ على التخطيط—سريع وسهل الاستخدام للمطورين. جرّبه."
---

## **Aspose.Slides API لترجمة العروض التقديمية: ترجمة الشرائح متعددة اللغات مدعومة بالذكاء الاصطناعي**

Aspose.Slides هو API قوي لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء الشرائح وتحريرها وتحويلها، يقدّم ميزات مدفوعة بالذكاء الاصطناعي – مثل Presentation Translation API لمحتوى الشرائح متعدد اللغات.

## **كيف تعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يندمج مع نماذج الذكاء الاصطناعي الخارجية عبر الإنترنت. تُعرَض هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ واجهتك الخاصة [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) لاستخدام مزود ذكاء اصطناعي مختلف أو نموذج لغة آخر.

يتولى Aspose.Slides عملية التواصل، ويُحلل ردود الذكاء الاصطناعي، ويُدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشرائح الأصلي وتنسيقه.

{{% alert color="primary" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتزويد المفتاح الخاص بواجهة برمجة التطبيقات عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI المحدد [model](https://platform.openai.com/docs/models).
```java
// تحميل عرض تقديمي للترجمة.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ترجمة العرض التقديمي إلى اليابانية.
    aiAgent.translate(presentation, "japanese");

    // حفظ العرض المترجم بصيغة PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


افتراضيًا، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) المدمج بإنشاء وإدارة مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلي خاص به، مع التعامل مع دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضّل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — خاصةً لتكوين إعدادات أساسية مثل وكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة الموارد والأداء بشكل أفضل — يمكنك تقديم مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// افترض أنك تمتلك مثيل HttpURLConnection مُسبق التكوين (مثلاً مع مهلات مخصصة، إعدادات الوكيل، إلخ)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **الفوائد الرئيسية**

توفر Aspose.Slides Presentation Translation API حلًا مدفوعًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا في الأعمال، يمكن لهذا الـ API أن يُساعدك في إنشاء عروض تقديمية جذابة ومُحلية للجمهور العالمي — مما يوسّع نطاق وصولك ويحسّن التواصل.