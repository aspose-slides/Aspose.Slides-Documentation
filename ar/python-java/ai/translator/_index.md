---
title: مترجم العروض المدعوم بالذكاء الاصطناعي
linktitle: مترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/python-java/ai/translator/
keywords:
- مترجم العروض باستخدام الذكاء الاصطناعي
- مترجم الشرائح باستخدام الذكاء الاصطناعي
- عرض متعدد اللغات
- ترجمة العروض
- ترجمة الشرائح
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "ترجم العروض باستخدام الذكاء الاصطناعي عبر Aspose.Slides للغة Python عبر Java. قم بتوطين نص الشرائح واحفظ العرض المترجم كملف PowerPoint أو PDF."
---
## **المقدمة**

Aspose.Slides for Python via Java يوفر واجهة برمجة تطبيقات AI لترجمة العروض لتوطين محتوى الشرائح. ترجم عرضًا موجودًا إلى لغة محددة، ثم احفظ النسخة المترجمة بالتنسيق الذي يحتاجه جمهورك.

## **كيف يعمل**

[SlidesAIAgent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesaiagent/) يتواصل مع خدمة AI خارجية عبر عميل AI. تستخدم الأمثلة العميل المدمج [OpenAIWebClient](https://reference.aspose.com/slides/ar/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesaiagent/#translate) يحدث العرض الممرَّر إليه. Aspose.Slides يعالج ردود AI ويستبدل نص الشريحة مع الحفاظ على التخطيط والتنسيق الحالي. راجع النتيجة: قد يكون النص المترجم أطول من الأصلي ويتطلب تعديل التخطيط.

## **المتطلبات المسبقة**

اتبع [Installation](/slides/ar/python-java/installation/) لتكوين المكتبة ووقت تشغيلها. اضبط متغيرات البيئة `OPENAI_API_KEY` و `OPENAI_MODEL` قبل تشغيل الأمثلة. اختر نموذجًا مدعومًا من العميل المدمج ومتوفرًا لحساب API الخاص بك.

{{% alert color="info" title="Note" %}}

الترجمة تتطلب اتصالًا بالإنترنت وتُرسل نص العرض إلى خدمة AI المُكوَّنة. تكاليف وصول API واستخدامه منفصلة عن ترخيص Aspose.Slides الخاص بك.

{{% /alert %}}

تعيد الأمثلة استخدام JVM نشط أو تشغّله إذا لزم الأمر. راجع [JVM lifecycle guidance](/slides/ar/python-java/limitations-and-api-differences/#import-the-library) لاستخدامه في دفاتر الملاحظات.

## **ترجمة عرض تقديمي**

ضع `sample.pptx` في دليل العمل. هذا المثال يحمل الملف باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، يترجم نصه إلى اليابانية، ويحفظ النتيجة كملف PDF. يحرّر العرض ويغلق عميل AI حتى إذا فشلت العملية.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **تكوين اتصال HTTP**

بشكل افتراضي، [OpenAIWebClient](https://reference.aspose.com/slides/ar/python-java/aspose.slides/openaiwebclient/) يدير اتصال HTTP داخليًا. يُقبل مُنشئه بأربعة معلمات أيضًا اتصال Java خارجي من نوع [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). استخدم هذا التحميل عندما تحتاج إلى تكوين وكيل أو مهلات الاتصال.

المثال التالي ينشئ وكيل HTTP Java باستخدام [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) ويفتح اتصالًا عبر [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). استبدل `proxy.example.com` والمنفذ بإعدادات الوكيل الخاصة بك. يتم تمرير الاتصال مباشرة عبر JPype؛ لا يمكن استخدام جلسة Python HTTP بدلاً منه.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **الفوائد الرئيسية**

الترجمة الآلية تساعد في إعداد مواد تدريبية متعددة اللغات، عروض منتجات، وتقارير عملاء مع إعادة استخدام تصميم الشريحة الحالي. احفظ عرضًا تقديميًا قابلاً للتحرير للمراجعة الإضافية أو صدّر PDF للتوزيع.

## **الأسئلة الشائعة**

**هل تنشئ الترجمة كائن عرض تقديمي منفصل؟**

لا. [SlidesAIAgent.translate](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesaiagent/#translate) تعديل العرض المزوَّد. احفظه باسم ملف جديد للحفاظ على الملف الأصلي دون تغيير.

**كيف أحدد اللغة المستهدفة؟**

مرّر اسم اللغة، مثل `"Japanese"` أو `"Spanish"`، كالمعامل الثاني. جودة الترجمة وتغطية اللغة تعتمد على النموذج المحدد.

**هل يمكنني الترجمة دون استخدام وكيل؟**

نعم. استخدم مُنشئ العميل بثلاث معلمات الموضح في المثال الأول. مثال الاتصال المخصص مطلوب فقط عندما يتطلب تطبيقك إعدادات اتصال صريحة.