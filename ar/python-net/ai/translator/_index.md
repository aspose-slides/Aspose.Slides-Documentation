---
title: مترجم العروض التقديمية مدعوم بالذكاء الاصطناعي
linktitle: المترجم مدعوم بالذكاء الاصطناعي
type: docs
weight: 20
url: /ar/python-net/ai/translator/
keywords:
- مترجم عرض مدعوم بالذكاء الاصطناعي
- مترجم شريحة بالذكاء الاصطناعي
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
- Python
- Aspose.Slides
description: "ترجمة شرائح PowerPoint باستخدام الذكاء الاصطناعي عبر Aspose.Slides للغة Python. تحسين ملفات PPT و PPTX و ODP مع الحفاظ على التخطيط—سريع وصديق للمطورين. جرّبه."
---
## **مقدمة**

Aspose.Slides هي واجهة برمجة تطبيقات قوية لإدارة عروض PowerPoint برمجياً. بالإضافة إلى إنشاء وتحرير وتحويل الشرائح، فهي تقدم ميزات مدفوعة بالذكاء الاصطناعي - مثل [Presentation Translation API](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/) لمحتوى الشرائح متعدد اللغات.

## **كيف يعمل**

Aspose.Slides لا يتضمن قدرات ذكاء اصطناعي مدمجة ولكنه يتكامل مع نماذج ذكاء اصطناعي خارجية عبر الإنترنت. يتم كشف هذه الوظيفة عبر الفئة [SlidesAIAgent](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/slidesaiagent/)، التي تستخدم الفئات الفرعية [IAIWebClient](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/iaiwebclient/) للتواصل مع خدمات الذكاء الاصطناعي.

يمكنك استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/openaiwebclient/) المدمج للاتصال بواجهة برمجة تطبيقات OpenAI أو تنفيذ فئتك الخاصة [IAIWebClient](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/iaiwebclient/) لاستخدام موفر ذكاء اصطناعي أو نموذج لغة مختلف.

Aspose.Slides يتولى التواصل، وتحليل استجابات الذكاء الاصطناعي، وإدراج المحتوى المترجم بذكاء مع الحفاظ على تخطيط وتنسيق الشريحة الأصلي.

{{% alert color="info" %}}
لاحظ أن واجهة برمجة تطبيقات OpenAI هي خدمة مدفوعة، لذلك سيتعين عليك إنشاء حساب وتزويد المفتاح الخاص بك عند استخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **مثال**

في هذا المثال، نقوم بترجمة عرض PowerPoint إلى اللغة اليابانية باستخدام [OpenAIWebClient](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/openaiwebclient/) المدمج مع نموذج OpenAI محدد.

```py
import aspose.slides as slides

# حمّل عرضًا لتتم ترجمته.
with slides.Presentation("sample.pptx") as presentation:

    # إنشاء عميل ذكاء اصطناعي باستخدام OpenAIWebClient، مع تحديد النموذج ومفتاح API الخاصين بك.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # تهيئة SlidesAIAgent باستخدام عميل الذكاء الاصطناعي.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # ترجمة العرض إلى اللغة اليابانية.
        ai_agent.translate(presentation, "japanese")

        # حفظ العرض المترجم كملف PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **مثال Azure OpenAI**

منذ الإصدار **26.7.0**، تدعم Aspose.Slides لـ Python عبر .NET مزودي خدمة متوافقين مع OpenAI، بما في ذلك Azure OpenAI. يمكنك تكوين المترجم لاستخدام نشر Azure الخاص بك عبر [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```
هذا المقتطف يوضح ترجمة عرض باستخدام نقطة النهاية Azure OpenAI الخاصة بك. استبدل القيم الافتراضية باسم النشر، ومفتاح API، وعنوان URL للنقطة النهاية.

## **الفوائد الرئيسية**

توفر Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ai/) حلًا مدفوعًا بالذكاء الاصطناعي لتقديم عروض PowerPoint متعددة اللغات. من خلال أتمتة الترجمة مع الحفاظ على التخطيط والتصميم، يوفر الوقت ويقلل الأخطاء مقارنةً بالعمليات اليدوية. سواء كنت مطورًا أو معلمًا أو محترفًا تجاريًا، تمكّنك هذه الواجهة من إنشاء عروض جذابة ومُحلية للجماهير العالمية - مما يوسع نطاق وصولك ويحسّن التواصل.