---
title: مترجم العروض التقديمية المدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/java/ai/translator/
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
- عامل الذكاء الاصطناعي
- عميل ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "ترجم شرائح PowerPoint باستخدام الذكاء الاصطناعي و Aspose.Slides للغة Java. قم بترجمة PPT و PPTX و ODP مع الحفاظ على التخطيط—سريع وسهل للمطورين. جرّبه."
---
## **مقدمة**

Aspose.Slides هي واجهة برمجة تطبيقات قوية لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء وتعديل وتحويل الشرائح، فهي تقدم ميزات مدعومة بالذكاء الاصطناعي – مثل واجهة برمجة تطبيقات ترجمة العرض لتوفير محتوى شرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يتكامل مع نماذج الذكاء الاصطناعي الخارجية عبر الإنترنت. يتم الكشف عن هذه الوظيفة من خلال الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidesaiagent/) التي تستخدم تنفيذًا لواجهة [IAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ [IAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaiwebclient/) الخاص بك لاستخدام مزود ذكاء اصطناعي أو نموذج لغة مختلف.

تتعامل Aspose.Slides مع التواصل، وتحلل ردود الذكاء الاصطناعي، وتدرج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلي.

{{% alert color="info" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI خدمة مدفوعة، لذا ستحتاج إلى إنشاء حساب وتوفير مفتاح API الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) .
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) المدمج مع نموذج OpenAI المحدد [النموذج](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// تحميل عرض تقديمي للترجمة.
Presentation presentation = new Presentation("sample.pptx");

// إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاص بك.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
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

افتراضيًا، يقوم [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) المدمج بإنشاء وإدارة مثيل [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) الداخلي الخاص به، ويتعامل مع دورة حياته تلقائيًا. ومع ذلك، إذا كنت تفضل إدارة [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) بنفسك — أساسًا لتكوين إعدادات أساسية مثل بروكسي، أو لاستخدام [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) أو [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) مختلف لتحسين إدارة الموارد والأداء — يمكنك توفير مثيل `HttpURLConnection` الخاص بك عند إنشاء [OpenAIWebClient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/openaiwebclient/) .

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// تكوين مثيل HttpURLConnection بنفسك (مهلات مخصصة، إعدادات بروكسي، إلخ).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **الفوائد الرئيسية**

توفر واجهة برمجة تطبيقات ترجمة العرض في Aspose.Slides حلًا مدعومًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو مدرّسًا أو محترفًا في الأعمال، تمكّنك هذه الواجهة من إنشاء عروض جذابة ومُحلية للجماهير العالمية – مما يوسّع نطاقك ويحسّن التواصل.