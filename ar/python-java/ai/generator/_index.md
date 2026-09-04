---
title: مولّد الشرائح متعدد اللغات المدعوم بالذكاء الاصطناعي
linktitle: مولّد مدعوم بالذكاء الاصطناعي
type: docs
weight: 40
url: /ar/python-java/ai/generator/
keywords:
- عرض تقديمي متعدد اللغات
- شريحة متعددة اللغات
- مولّد عرض تقديمي بالذكاء الاصطناعي
- مولّد شريحة بالذكاء الاصطناعي
- قالب عرض تقديمي
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "إنشاء عروض تقديمية متعددة اللغات من النص باستخدام Aspose.Slides للغة Python عبر Java. اختر مستوى تفصيل المحتوى، طبق قالبًا، وصَدِّر إلى PowerPoint أو PDF."
---
## **المقدمة**

يقوم مولّد العروض التقديمية الذكي في Aspose.Slides للغة Python عبر Java بإنشاء عروض تقديمية من أوصاف المواضيع أو الملخصات أو الاقتباسات أو النقاط ذات التعداد. حدّد اللغة المطلوبة في طلبك، واختر مقدار المحتوى، ويمكنك أيضًا تزويد قالب عرض لتحديد التخطيط والتصميم.

يقوم المُولّد بتنظيم المحتوى باستخدام كتل نصية، قوائم نقطية وجداول. لا يولّد صورًا؛ يمكنك إضافة الصور إلى العرض الناتج بعد ذلك. راجع المحتوى والتخطيط المُولَّد قبل مشاركة العرض التقديمي.

## **كيف يعمل**

يستخدم [SlidesAIAgent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesaiagent/) عميلًا ذكيًا للتواصل مع نموذج خارجي. تستخدم الأمثلة أدناه [OpenAIWebClient](https://reference.aspose.com/slides/ar/python-java/aspose.slides/openaiwebclient/) المدمج. تقوم Aspose.Slides بمعالجة ردود النموذج وتُنشئ عرضًا تقديميًا يمكنك تحريره أو تصديره.

استخدم [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesaiagent/#generatePresentation) مع وصف نصي وقيمة [PresentationContentAmountType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationcontentamounttype/). التحميل الزائد مع معلمة ثالثة يقبل عرضًا لاستخدامه كقالب تصميم.

## **المتطلبات المسبقة**

اتبع [Installation](/slides/ar/python-java/installation/) لتكوين Python وJava وJPype وAspose.Slides. اضبط متغيرات البيئة `OPENAI_API_KEY` و `OPENAI_MODEL` قبل تشغيل الأمثلة. اختر نموذجًا مدعومًا من العميل المدمج ومتوفرًا لحساب API الخاص بك.

{{% alert color="info" title="Note" %}}
يتطلب خدمة الذكاء الاصطناعي اتصالًا بالإنترنت ووصولًا منفصلًا إلى API. تُرسل المطالبات إلى الخدمة المُكوَّنة، وتُطبق رسوم الاستخدام الخاصة بها بشكل مستقل عن ترخيص Aspose.Slides الخاص بك.
{{% /alert %}}

كل مثال يبدأ تشغيل JVM فقط إذا لم يكن قيد التشغيل بالفعل ويتركه متاحًا للعمليات اللاحقة. راجع [JVM lifecycle guidance](/slides/ar/python-java/limitations-and-api-differences/#import-the-library) عند تعديل الكود للدفاتر.

## **إنشاء عرض تقديمي من نص**

هذا المثال يُنشئ عرضًا تقديميًا باللغة الإنجليزية بمقدار محتوى [Medium](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationcontentamounttype/#Medium) ويحفظه كملف PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **إنشاء عرض تقديمي باستخدام قالب**

ضع `masterPresentation.pptx` في دليل العمل. يحمل هذا المثال الملف باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، وينشئ عرضًا تقديميًا بالإسبانية بمحتوى [Detailed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationcontentamounttype/#Detailed)، ويصدّره إلى PDF. يُطلق سراح القالب والعرض المُنشأ، حتى إذا فشل الإنشاء أو الحفظ.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

إذا احتجت إلى تكوين خادم وسيط أو مهلات اتصال، راجع [Configure the HTTP Connection](/slides/ar/python-java/ai/translator/#configure-the-http-connection). يمكنك أيضًا تمرير العميل الناتج إلى المُولّد.

## **الفوائد الرئيسية**

يمكن للإنشاء أن يقلل من الجهد الأولي لإعداد المواد التدريبية، نظرات عامة على المنتج، تقارير العملاء، والعروض التقديمية الداخلية. تتحكم المطالبات في الموضوع واللغة، بينما يسمح القالب بإعادة استخدام تصميم عرض تقديمي موجود.

## **الأسئلة الشائعة**

**كيف يمكنني التحكم في طول العرض التقديمي المُنشأ؟**

اختر [Brief](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationcontentamounttype/#Brief)، [Medium](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationcontentamounttype/#Medium)، أو [Detailed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationcontentamounttype/#Detailed). تؤثر هذه الإعدادات على عدد الشرائح وتفصيل كل شريحة؛ فهي لا تحدد عددًا دقيقًا من الشرائح.

**هل يمكنني إنشاء شرائح بلغة أخرى؟**

نعم. ضمّن اللغة المطلوبة في وصف النص. النتيجة تعتمد على قدرات اللغة للنموذج المختار.

**هل يمكنني الاحتفاظ بنسخة قابلة للتحرير عند التصدير إلى PDF؟**

نعم. قبل إتلاف العرض المُنشأ، احفظه أيضًا كملف PPTX باستخدام النهج الموجود في المثال الأول.