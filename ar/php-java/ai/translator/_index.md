---
title: مترجم العروض المدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/php-java/ai/translator/
keywords:
- مترجم عرض بالذكاء الاصطناعي
- مترجم شريحة بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض متعدد اللغات
- شريحة متعددة اللغات
- ترجمة العرض
- ترجمة الشريحة
- ميزات مدفوعة بالذكاء الاصطناعي
- إمكانات الذكاء الاصطناعي
- وكيل الذكاء الاصطناعي
- عميل ويب
- PowerPoint
- OpenDocument
- عرض
- PHP
- Aspose.Slides
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي مع Aspose.Slides للـ PHP. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط—سريع ومناسب للمطورين. جرّبه."
---
## **المقدمة**

Aspose.Slides هي API قوية لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء وتحرير وتحويل الشرائح، فإنها تقدم ميزات مدفوعة بالذكاء الاصطناعي - مثل واجهة برمجة تطبيقات ترجمة العروض لتوفير محتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا تتضمن قدرات ذكاء اصطناعي مدمجة ولكنها تتكامل مع نماذج الذكاء الاصطناعي الخارجية عبر الإنترنت. يتم عرض هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesaiagent/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI.

تتعامل Aspose.Slides مع الاتصال، وتُحلل استجابات الذكاء الاصطناعي، وتدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلي.

{{% alert color="info" title="Note" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/openaiwebclient/) المدمج.
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/openaiwebclient/) المدمج مع [نموذج OpenAI](https://platform.openai.com/docs/models).

```php
// تحميل عرض لتترجمه.
$presentation = new Presentation("sample.pptx");

// إنشاء عميل AI باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاصين بك.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // ترجمة العرض إلى اللغة اليابانية.
    $aiAgent->translate($presentation, "japanese");

    // حفظ العرض المترجم كملف PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/openaiwebclient/) المدمج بإنشاء وإدارة نسخة داخلية من [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) الخاصة به، ويتعامل مع دورة حياتها تلقائياً. ولكن إذا كنت تفضّل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — خاصةً لتكوين إعدادات أساسية مثل وكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لتحسين إدارة الموارد والأداء — يمكنك توفير نسخة `HttpURLConnection` الخاصة بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/openaiwebclient/).

```php
// إنشاء وتكوين مسبقًا مثيل HttpURLConnection الخاص بك (مهلات مخصصة، إعدادات وكيل، إلخ).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// تمرير الاتصال إلى عميل AI.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **مثال Azure OpenAI**

يمكنك تكوين المترجم لاستخدام نشر Azure OpenAI الخاص بك عبر [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

يوضح هذا المقتطف كيفية ترجمة عرض باستخدام نقطة نهاية Azure OpenAI الخاصة بك. استبدل القيم النائبة باسم النشر، ومفتاح API، وعنوان URL لنقطة النهاية.

## **الفوائد الرئيسية**

توفر واجهة برمجة تطبيقات ترجمة العروض من Aspose.Slides حلاً مدعوماً بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، توفر الوقت وتقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو مربيًا أو محترفًا تجاريًا، تمكّنك هذه الواجهة من إنشاء عروض جذابة ومُحلية للجماهير العالمية - مما يوسع نطاقك ويحسّن التواصل.