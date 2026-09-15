---
title: مترجم عروض مدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/androidjava/ai/translator/
keywords:
- مترجم عروض بالذكاء الاصطناعي
- مترجم شرائح بالذكاء الاصطناعي
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
- عرض
- Android
- Java
- Aspose.Slides
description: "ترجمة شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides لنظام Android باستخدام Java. ترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط — سريع ومناسب للمطورين. جرّبه."
---
## **المقدمة**

Aspose.Slides هي واجهة برمجة تطبيقات قوية لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء وتحرير وتحويل الشرائح، فإنها توفر ميزات مدعومة بالذكاء الاصطناعي - مثل واجهة برمجة تطبيقات ترجمة العروض لتوفير محتوى شرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا تتضمن قدرات ذكاء اصطناعي مدمجة لكنها تتكامل مع نماذج الذكاء الاصطناعي الخارجية عبر الإنترنت. يتم توفير هذه الوظيفة عبر فئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ [IAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaiwebclient/) الخاص بك لاستخدام موفر ذكاء اصطناعي أو نموذج لغة مختلف.

تتعامل Aspose.Slides مع الاتصال، وت解析 استجابات الذكاء الاصطناعي، وتدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط الشرائح الأصلي وتنسيقه.

{{% alert color="info" title="ملاحظة" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI خدمة مدفوعة، لذلك ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/) المدمج مع [نموذج](https://platform.openai.com/docs/models) محدد من OpenAI.

```java
import com.aspose.slides.*;

// تحميل عرض لتتم ترجمته.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاصين بك.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent بعميل الذكاء الاصطناعي.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // ترجمة العرض إلى اليابانية.
    aiAgent.translate(presentation, "japanese");

    // حفظ العرض المترجم بصيغة PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

بشكل افتراضي، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/) المدمج بإنشاء ومعالجة مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) الداخلي الخاص به، ويتعامل مع دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — أساسًا لتكوين إعدادات أساسية مثل الوكيل، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لإدارة موارد أفضل وأداء أعلى — يمكنك توفير مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // قم بتهيئة كائن HttpURLConnection بنفسك (مثلاً، مع مهلات مخصصة، إعدادات الوكيل، إلخ).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // مرّر الاتصال إلى مُنشئ OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **مثال Azure OpenAI**

يمكنك تهيئة المترجم لاستخدام نشر Azure OpenAI الخاص بك عبر [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/openaicompatiblewebclient/).

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

توضح هذه الشريحة ترجمة عرض باستخدام نقطة النهاية Azure OpenAI الخاصة بك. استبدل القيم النائبة باسم النشر، ومفتاح API، وعنوان URL لنقطة النهاية.

## **الفوائد الرئيسية**

توفر واجهة برمجة تطبيقات ترجمة العروض Aspose.Slides حلاً مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، فإنها توفر الوقت وتقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، تمكّنك هذه الواجهة من إنشاء عروض جذابة ومُحلية للجمهور العالمي - مما يوسع نطاق وصولك ويحسن التواصل.