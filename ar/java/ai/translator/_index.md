---
title: مترجم العروض المدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/java/ai/translator/
keywords:
- مترجم العروض بالذكاء الاصطناعي
- مترجم الشرائح بالذكاء الاصطناعي
- ميزة مدعومة بالذكاء الاصطناعي
- عرض متعدد اللغات
- شريحة متعددة اللغات
- ترجمة العرض
- ترجمة الشريحة
- ميزات مدفوعة بالذكاء الاصطناعي
- قدرات الذكاء الاصطناعي
- وكيل الذكاء الاصطناعي
- عميل ويب
- PowerPoint
- OpenDocument
- العرض
- Java
- Aspose.Slides
description: "ترجمة شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides for Java. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط—سريع ومناسب للمطورين. جرّبه."
---
## **مقدمة**

Aspose.Slides هو API قوي لإدارة عروض PowerPoint برمجيًا. بالإضافة إلى إنشاء وتعديل وتحويل الشرائح، فإنه يقدم ميزات مدعومة بالذكاء الاصطناعي - مثل Presentation Translation API لمحتوى الشرائح متعدد اللغات.

## **كيفية العمل**

Aspose.Slides لا يحتوي على قدرات ذكاء اصطناعي مدمجة ولكنه يدمج نماذج ذكاء اصطناعي خارجية عبر الإنترنت. يتم تو expose هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة OpenAI API أو تنفيذ مستندك الخاص من [IAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaiwebclient/) لاستخدام موفر ذكاء اصطناعي أو نموذج لغة مختلف.

Aspose.Slides يتعامل مع التواصل، ويحلل ردود الذكاء الاصطناعي، ويُدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشريحة الأصلي وتنسيقه.

{{% alert color="info" title="Note" %}}
لاحظ أن واجهة OpenAI API خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI محدد.

```java
import com.aspose.slides.*;

// تحميل عرض للترجمة.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاص بك.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ترجمة العرض إلى اللغة اليابانية.
    aiAgent.translate(presentation, "japanese");

    // حفظ العرض المترجم كملف PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) بإنشاء وإدارة مثيل داخلي من [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)، ويتعامل مع دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — خاصةً لتكوين إعدادات أساسية مثل الوكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة الموارد والأداء — يمكنك توفير مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// ضبط مثيل HttpURLConnection بنفسك (مهلات مخصصة، إعدادات الوكيل، إلخ).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **مثال Azure OpenAI**

يمكنك تكوين المترجم لاستخدام نشر Azure OpenAI الخاص بك مع [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

يظهر هذا المقتطف كيفية ترجمة عرض باستخدام نقطة النهاية Azure OpenAI الخاصة بك. استبدل القيم النائبة باسم النشر، ومفتاح API، وعنوان URL لنقطة النهاية.

## **الفوائد الرئيسية**

تقدم Aspose.Slides Presentation Translation API حلًا مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، يتيح لك هذا API إنشاء عروض جذابة ومُعربة للجمهور العالمي — مما يوسع نطاق وصولك ويحسّن التواصل.