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
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides لنظام Android باستخدام Java. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط — سريع ومناسب للمطورين. جرّبه."
---

## **Aspose.Slides API لترجمة العروض التقديمية: ترجمة شرائح متعددة اللغات مدعومة بالذكاء الاصطناعي**

Aspose.Slides هي API قوية لإدارة عروض PowerPoint برمجيًا. بالإضافة إلى إنشاء وتحرير وتحويل الشرائح، توفر ميزات مدفوعة بالذكاء الاصطناعي - مثل API ترجمة العروض التقديمية لمحتوى الشرائح متعدد اللغات.

## **كيف تعمل**

Aspose.Slides لا تشمل قدرات الذكاء الاصطناعي المدمجة ولكنها تتكامل مع نماذج الذكاء الاصطناعي الخارجية عبر الإنترنت. يتم تقديم هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) الخاص بك لاستخدام مزود ذكاء اصطناعي مختلف أو نموذج لغة آخر.

تتعامل Aspose.Slides مع التواصل، وتحلل استجابات الذكاء الاصطناعي، وتدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلية.

{{% alert color="primary" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI خدمة مدفوعة، لذلك سيتعين عليك إنشاء حساب وتقديم مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI المحدد.
```java
// تحميل عرض تقديمي للترجمة.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل AI باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API.
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


بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) المدمج بإنشاء وإدارة مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) الداخلي الخاص به، ويتعامل مع دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — أساسًا لتكوين إعدادات أساسية مثل وكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لتحسين إدارة الموارد والأداء — يمكنك توفير مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// افترض أن لديك مثيل HttpURLConnection مُكوَّن مسبقًا (مثلاً، مع مهلات مخصصة، إعدادات بروكسي، إلخ.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **الفوائد الرئيسية**

توفر Aspose.Slides API لترجمة العروض التقديمية حلًا مدفوعًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، يتيح لك هذا API إنشاء عروض تقديمية جذابة ومُحلية للجماهير العالمية - مما يوسع نطاق وصولك ويحسن التواصل.