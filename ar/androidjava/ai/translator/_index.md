---
title: مترجم العروض التقديمية المدعوم بالذكاء الاصطناعي
linktitle: المترجم المدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/androidjava/ai/translator/
keywords:
- مترجم العروض التقديمية بالذكاء الاصطناعي
- مترجم الشرائح بالذكاء الاصطناعي
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
- Android
- Java
- Aspose.Slides
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides لنظام Android بلغة Java. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط — سريع وسهل للمطورين. جرّب ذلك."
---

## **Aspose.Slides Presentation Translation API: ترجمة شرائح متعددة اللغات مدعومة بالذكاء الاصطناعي**

## **كيف يعمل**

لا يحتوي Aspose.Slides على قدرات ذكاء اصطناعي مدمجة ولكنه يدمج نماذج ذكاء اصطناعي خارجية عبر الإنترنت. يتم توفير هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا للواجهة [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ واجهة [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) الخاصة بك لاستخدام موفر ذكاء اصطناعي مختلف أو نموذج لغة مختلف.

يتولى Aspose.Slides معالجة الاتصالات، وتحليل ردود الذكاء الاصطناعي، وإدراج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشريحة الأصلي وتنسيقه.

{{% alert color="primary" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، وبالتالي ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI المحدد.
```java
// تحميل عرض تقديمي للترجمة.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل AI باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاص بك.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل AI.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ترجمة العرض التقديمي إلى اللغة اليابانية.
    aiAgent.translate(presentation, "japanese");

    // حفظ العرض التقديمي المترجم كملف PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) المدمج بإنشاء وإدارة مثيل داخلي من [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) خاصة به، ويعالج دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — خاصة لتكوين إعدادات أساسية مثل الوكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة الموارد والأداء بشكل أفضل — يمكنك تقديم مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// افترض أن لديك مثيل HttpURLConnection مكوّن مسبقاً (مثال: مع مهلات مخصصة، إعدادات البروكسي، إلخ)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **الفوائد الرئيسية**

توفر واجهة برمجة تطبيقات ترجمة العروض التقديمية Aspose.Slides حلاً مدفوعًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، توفر الوقت وتقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، تمكّنك هذه الواجهة من إنشاء عروض تقديمية جذابة ومُعربة للجماهير العالمية — ما يوسّع نطاق وصولك ويحسّن التواصل.