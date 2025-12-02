---
title: تسلسل اختيار الخطوط في Aspose.Slides للبايثون
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
description: "اكتشف كيف يختار Aspose.Slides للبايثون عبر .NET الخطوط، لضمان عرض واضح ومتسق لملفات PPT و PPTX و ODP—حسّن شرائحاتك الآن."
---

## **اختيار الخط**

تنطبق قواعد معينة على الخطوط في عرض تقديمي عندما يتم تحميل العرض أو عرضه أو تحويله إلى تنسيق آخر. على سبيل المثال، عند محاولة تحويل عرض تقديمي (شرائحه) إلى صور، يتم فحص خطوط العرض للتحقق من أن الخطوط المختارة متوفرة في نظام التشغيل. إذا تم التأكد أن الخطوط غير موجودة، يتم استبدالها — راجع [**Font Replacement**](https://docs.aspose.com/slides/python-net/font-replacement/) و[**Font Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

هذه هي العملية التي يتبعها Aspose.Slides عند التعامل مع الخطوط:

1. يبحث Aspose.Slides عن الخطوط في نظام التشغيل لإيجاد الخط الذي يطابق الخط المختار في العرض التقديمي.  
2. إذا تم العثور على الخط المختار، يستخدمه Aspose.Slides. وإلا، يستخدم Aspose.Slides خطاً بديلاً يكون أقرب ما يمكن إلى ما يستخدمه PowerPoint.  
3. إذا تم ضبط قواعد استبدال الخطوط عبر [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/)، يتم تطبيقها.  

يسمح لك Aspose.Slides بإضافة خطوط إلى وقت تشغيل التطبيق ثم استخدام تلك الخطوط. راجع [**Custom fonts**](https://docs.aspose.com/slides/python-net/custom-font/).  

عند وضع خطوط إضافية داخل عرض تقديمي، تُسمى هذه الخطوط [**Embedded fonts**](https://docs.aspose.com/slides/python-net/embedded-font/).  

يسمح لك Aspose.Slides بإضافة خطوط تُطبق *فقط* على مستندات الإخراج. على سبيل المثال، إذا كان العرض الذي تريد تحويله إلى PDF يحتوي على خطوط مفقودة من نظامك وخطوط مدمجة، يمكنك إضافة أو تحميل الخطوط اللازمة كـ **external fonts**.  

{{% alert title="Note" color="primary" %}} 
نحن لا نقوم بتوزيع أي خطوط، سواء كانت مدفوعة أو مجانية. تتيح لك واجهة برمجة التطبيقات تحميل الخطوط الخارجية وتضمينها في المستندات، ولكنك تقوم بذلك وفقًا لاختيارك ومسؤوليتك. 
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني تحديد الخطوط المستخدمة فعليًا في عرض تقديمي قبل التحويل؟**

يتيح لك Aspose.Slides فحص الخطوط المستخدمة عبر [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/)، بحيث يمكنك اتخاذ قرار بـ [embed](/slides/ar/python-net/embedded-font/)، [replace](/slides/ar/python-net/font-replacement/)، أو إضافة [external sources](/slides/ar/python-net/custom-font/). يساعدك هذا في منع الاستبدالات غير المرغوبة أثناء العرض والتصدير.  

**هل يمكنني إضافة دلائل خطوط إضافية دون تثبيتها على نظام التشغيل؟**

نعم. يمكنك تسجيل [external font sources](/slides/ar/python-net/custom-font/) مثل المجلدات أو تدفقات الذاكرة للعرض والتصدير. يُزيل ذلك الاعتماد على خطوط النظام المضيف ويجعل التخطيط قابلاً للتنبؤ.  

**كيف أمنع الانتقال الصامت إلى خط غير مناسب عندما يكون هناك حرف غير موجود؟**

عرّف [font replacement](/slides/ar/python-net/font-replacement/) صريحة وقواعد [fallBack](/slides/ar/python-net/fallback-font/) للخطوط مسبقًا. من خلال تحليل الخطوط المستخدمة وتحديد أولوية مُتحكم فيها للبدائل، تضمن طباعة ثابتة وتتجنب النتائج غير المتوقعة.