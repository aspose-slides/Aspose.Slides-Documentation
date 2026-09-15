---
title: مترجم العروض التقديمية المدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/nodejs-java/ai/translator/
keywords:
- مترجم عرض بالذكاء الاصطناعي
- مترجم شريحة بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض متعدد اللغات
- شريحة متعددة اللغات
- ترجمة عرض تقديمي
- ترجمة شريحة
- ميزات مدفوعة بالذكاء الاصطناعي
- قدرات الذكاء الاصطناعي
- وكيل الذكاء الاصطناعي
- عميل ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "ترجمة شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides لـ Node.js. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط — سريع وسهل للمطورين. جرّب ذلك."
---
## **مقدمة**

Aspose.Slides هو API قوي لإدارة عروض PowerPoint برمجيًا. بالإضافة إلى إنشاء وتحرير وتحويل الشرائح، فإنه يقدم ميزات مدفوعة بالذكاء الاصطناعي - مثل Presentation Translation API لمحتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يدمج نماذج ذكاء اصطناعي خارجية عبر الإنترنت. تُعرض هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesaiagent/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI.

يتولى Aspose.Slides التعامل مع الاتصال، ويفسر استجابات الذكاء الاصطناعي، ويُدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشرائح الأصلي وتنسيقه.

{{% alert color="info" title="Note" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذلك سيتعين عليك إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI المحدد.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// تحميل عرض تقديمي للترجمة.
let presentation = new aspose.slides.Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // ترجمة العرض التقديمي إلى اللغة اليابانية.
    aiAgent.translate(presentation, "japanese");

    // حفظ العرض المترجم كملف PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/openaiwebclient/) المدمج بإنشاء وإدارة مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلي خاص به، ويتولى دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — خاصةً لتكوين إعدادات أساسية مثل الوكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة الموارد وتحسين الأداء — يمكنك توفير مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء وتكوين مسبق لمثيل HttpURLConnection (مثال: مع مهلات مخصصة، إعدادات الوكيل، إلخ.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **مثال Azure OpenAI**

يمكنك تكوين المترجم لاستخدام نشر Azure OpenAI الخاص بك عبر [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

يعرض هذا المقتطف كيفية ترجمة عرض باستخدام نقطة نهاية Azure OpenAI الخاصة بك. استبدل القيم النائبة باسم النشر ومفتاح API وعنوان URL للنقطة النهائية.

## **الفوائد الرئيسية**

توفر Aspose.Slides Presentation Translation API حلاً مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، فإنه يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواءً كنت مطورًا أو معلمًا أو محترفًا في مجال الأعمال، يتيح لك هذا API إنشاء عروض جذابة ومُحلية للجمهور العالمي - مما يوسع نطاق وصولك ويحسن التواصل.