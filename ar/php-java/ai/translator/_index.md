---
title: مترجم العروض التقديمية المدعم بالذكاء الاصطناعي
linktitle: مترجم مدعم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/php-java/ai/translator/
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
- عميل ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "ترجمة شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides للـ PHP. محلية ملفات PPT و PPTX و ODP مع الحفاظ على التخطيط — سريع وصديق للمطورين. جرّبه."
---

## **Aspose.Slides Presentation Translation API: ترجمة الشرائح متعددة اللغات باستخدام الذكاء الاصطناعي**

Aspose.Slides هي واجهة برمجية قوية لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء الشرائح وتحريرها وتحويلها، تُقدِّم ميزات مدعومة بالذكاء الاصطناعي – مثل Presentation Translation API لمحتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يتكامل مع نماذج الذكاء الاصطناعي الخارجية عبر الإنترنت. يتم الكشف عن هذه الوظيفة من خلال الفئة [SlidesAIAgent](https://reference.aspose.com/slides/php-java/aspose.slides/slidesaiagent/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI.

Aspose.Slides يتولى التعامل مع الاتصال، ويُحلِّل ردود الذكاء الاصطناعي، ويدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلي.

{{% alert color="primary" %}}
ملاحظة أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI المحدد [model](https://platform.openai.com/docs/models).
```php
// تحميل عرض تقديمي للترجمة.
$presentation = new Presentation("sample.pptx");

// إنشاء عميل AI باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاص بك.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // ترجمة العرض التقديمي إلى اليابانية.
    $aiAgent->translate($presentation, "japanese");

    // حفظ العرض المترجم كملف PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```


بشكل افتراضي، يُنشئ [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) ويُدير مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلي خاص به، مع التعامل مع دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضِّل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — غالبًا لتكوين إعدادات أساسية مثل الوكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة الموارد والأداء — يمكنك تزويد مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/).
```php
// افترض أنه لديك مثيل HttpURLConnection مُسبق الإعداد (على سبيل المثال، مع مهلات مخصصة، إعدادات الوكيل، إلخ.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```


## **الفوائد الرئيسية**

توفر Aspose.Slides Presentation Translation API حلاً مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواءً كنت مطورًا أو معلمًا أو محترفًا في الأعمال، تمكّنك هذه الواجهة من إنشاء عروض تقديمية جذابة ومُحلية للجماهير العالمية — مما يُوسِّع نطاق وصولك ويحسّن التواصل.