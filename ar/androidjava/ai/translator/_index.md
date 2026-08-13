---
title: مترجم عروض تقديمية مدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides للأندرويد باستخدام Java. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط—سريع ومناسب للمطورين. جرّبه."
---
## **المقدمة**

Aspose.Slides هو API قوي لإدارة عروض PowerPoint برمجيًا. بالإضافة إلى إنشاء الشرائح وتحريرها وتحويلها، فإنه يقدم ميزات مدفوعة بالذكاء الاصطناعي - مثل Presentation Translation API لمحتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة لكنه يدمج مع نماذج ذكاء اصطناعي خارجية عبر الإنترنت. تُظهر هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا للواجهة [IAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/) المضمن للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ واجهة [IAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaiwebclient/) الخاصة بك لاستخدام موفر ذكاء اصطناعي مختلف أو نموذج لغة آخر.

يتولى Aspose.Slides التعامل مع الاتصال، ويحليل استجابات الذكاء الاصطناعي، ويُدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلية.

{{% alert color="info" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI خدمة مدفوعة، لذلك ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/) المضمن مع نموذج OpenAI المحدد.

```java
import com.aspose.slides.*;

// تحميل عرض تقديمي للترجمة.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاص بك.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ترجمة العرض التقديمي إلى اليابانية.
    aiAgent.translate(presentation, "japanese");

    // حفظ العرض التقديمي المترجم كملف PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/) المضمن بإنشاء وإدارة مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) داخلي خاص به، مع معالجة دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضِّل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — أساسًا لتكوين إعدادات أساسية مثل الوكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة الموارد بشكل أفضل وأداء أعلى — يمكنك توفير مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // قم بتكوين مثيل HttpURLConnection بنفسك (مثلاً، مع مهلات مخصصة، إعدادات الوكيل، إلخ).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // مرّر الاتصال إلى مُنشئ OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **المزايا الرئيسية**

توفر واجهة برمجة تطبيقات Aspose.Slides لترجمة العروض حلًا مدفوعًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، فإنه يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، تمكنك هذه الواجهة من إنشاء عروض جذابة ومُحلية للجمهور العالمي — مما يوسع نطاق وصولك ويحسن التواصل.