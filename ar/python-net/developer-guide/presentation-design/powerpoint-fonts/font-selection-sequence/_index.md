---
title: متسلسل اختيار الخطوط في Aspose.Slides لبايثون
linktitle: اختيار الخط
type: docs
weight: 80
url: /ar/python-net/font-selection-sequence/
keywords:
- اختيار الخط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- خط متاح
- خط مفقود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف يقوم Aspose.Slides لبايثون عبر .NET باختيار الخطوط، مما يضمن عرضًا واضحًا ومتسقًا لملفات PPT و PPTX و ODP — حسّن شرائحك الآن."
---

## **اختيار الخط**

تنطبق قواعد معينة على الخطوط في العرض التقديمي عندما يتم تحميل العرض، أو عرضه، أو تحويله إلى تنسيق آخر. على سبيل المثال، عند محاولة تحويل عرض تقديمي (شرائحه) إلى صور، يتم فحص خطوط العرض للتأكد من أن الخطوط المختارة متوفرة في نظام التشغيل. إذا تأكد أن الخطوط مفقودة، يتم استبدالها — انظر [**استبدال الخط**](https://docs.aspose.com/slides/python-net/font-replacement/) و[**استبدال الخط**](https://docs.aspose.com/slides/python-net/font-substitution/).

هذه هي العملية التي يتبعها Aspose.Slides عند التعامل مع الخطوط:

1. يبحث Aspose.Slides عن الخطوط في نظام التشغيل لإيجاد الخط الذي يطابق الخط المختار في العرض.
2. إذا تم العثور على الخط المختار، يستخدمه Aspose.Slides. وإلا، يستخدم خطًا بديلًا قريبًا قدر الإمكان مما سيستخدمه PowerPoint.
3. إذا تم تعيين قواعد استبدال الخط عبر [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/)، يتم تطبيقها.

يتيح لك Aspose.Slides إضافة خطوط إلى وقت تشغيل التطبيق ثم استخدام تلك الخطوط. انظر [**خطوط مخصصة**](https://docs.aspose.com/slides/python-net/custom-font/).

عند وضع خطوط إضافية داخل العرض، تُسمى [**الخطوط المضمّنة**](https://docs.aspose.com/slides/python-net/embedded-font/).

يتيح لك Aspose.Slides إضافة خطوط تُطبق على *فقط* المستندات الناتجة. على سبيل المثال، إذا كان العرض الذي ترغب في تحويله إلى PDF يحتوي على خطوط مفقودة من نظامك والخطوط المضمّنة، يمكنك إضافة أو تحميل الخطوط المطلوبة كـ **خطوط خارجية**.

{{% alert title="Note" color="primary" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني تحديد الخطوط المستخدمة فعليًا في عرض تقديمي قبل التحويل؟**

يتيح لك Aspose.Slides فحص الخطوط المستخدمة عبر [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/)، بحيث يمكنك اتخاذ قرار سواءً بـ [تضمين](/slides/ar/python-net/embedded-font/)، أو [استبدال](/slides/ar/python-net/font-replacement/)، أو إضافة [مصادر خارجية](/slides/ar/python-net/custom-font/). يساعدك ذلك على منع الاستبدالات غير المرغوبة أثناء العرض والتصدير.

**هل يمكنني إضافة أدلة خطوط إضافية دون تثبيتها على نظام التشغيل؟**

نعم. يمكنك تسجيل [مصادر خطوط خارجية](/slides/ar/python-net/custom-font/) مثل المجلدات أو تدفقات الذاكرة للتصوير والتصدير. يزيل ذلك الاعتماد على خطوط نظام المضيف ويحافظ على تخطيط predictable.

**كيف أمنع الانتقال الصامت إلى خط غير مناسب عندما يكون رمزًا مفقودًا؟**

عرّف مسبقًا [استبدال الخط](/slides/ar/python-net/font-replacement/) وقواعد [الرجوع](/slides/ar/python-net/fallback-font/). من خلال تحليل الخطوط المستخدمة وتحديد أولوية محكومة للبدائل، تضمن طباعًا ثابتًا وتتجنب النتائج غير المتوقعة.