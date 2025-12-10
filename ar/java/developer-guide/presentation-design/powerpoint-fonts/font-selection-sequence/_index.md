---
title: تسلسل اختيار الخط في Aspose.Slides لل Java
linktitle: اختيار الخط
type: docs
weight: 80
url: /ar/java/font-selection-sequence/
keywords:
- اختيار الخط
- استبدال الخط
- تبديل الخط
- قاعدة الاستبدال
- خط متاح
- خط مفقود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيف يختار Aspose.Slides لل Java الخطوط، مما يضمن عرضاً واضحاً ومتسقاً لملفات PPT و PPTX و ODP — حسّن شرائحك الآن."
---

## **اختيار الخط**

تطبق قواعد معينة على الخطوط في عرض تقديمي عندما يتم تحميل العرض أو عرضه أو تحويله إلى صيغة أخرى. على سبيل المثال، عندما تحاول تحويل عرض تقديمي (شرائحه) إلى صور، يتم فحص خطوط العرض للتحقق من توفر الخطوط المختارة في نظام التشغيل. إذا تم التأكد من أن الخطوط مفقودة، يتم استبدالها — راجع [**Font Replacement**](https://docs.aspose.com/slides/java/font-replacement/) و[**Font Substitution**](https://docs.aspose.com/slides/java/font-substitution/).

هذه هي العملية التي يتبعها Aspose.Slides عند التعامل مع الخطوط:

1. يبحث Aspose.Slides عن الخطوط في نظام التشغيل للعثور على الخط الذي يطابق الخط المختار في العرض. 
2. إذا تم العثور على الخط المختار، يستخدمه Aspose.Slides. وإلا، يستخدم Aspose.Slides خطاً بديلاً يكون أقرب ما يمكن إلى ما يستخدمه PowerPoint. 
3. إذا تم تعيين قواعد استبدال الخطوط عبر [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/)، يتم تطبيقها. 

يتيح Aspose.Slides لك إضافة خطوط إلى زمن تشغيل التطبيق ثم استخدام تلك الخطوط. راجع [**Custom fonts**](https://docs.aspose.com/slides/java/custom-font/). 

عند وضع خطوط إضافية داخل عرض تقديمي، يُطلق عليها اسم [**Embedded fonts**](https://docs.aspose.com/slides/java/embedded-font/).

يتيح Aspose.Slides لك إضافة خطوط تُطبق فقط على مستندات الإخراج. على سبيل المثال، إذا كان عرض تقديمي تريد تحويله إلى PDF يحتوي على خطوط مفقودة من نظامك وخطوط مضمَّنة، يمكنك إضافة أو تحميل الخطوط المطلوبة كـ **external fonts**. 

{{% alert title="ملاحظة" color="primary" %}} 
نحن لا نوزع أي خطوط، سواء كانت مدفوعة أو مجانية. يتيح لك API الخاص بنا تحميل خطوط خارجية وتضمينها في المستندات، لكنك تقوم بذلك باستخدام الخطوط وفقاً لتقديرك ومسؤوليتك.
{{% /alert %}}

## **FAQ**

**كيف يمكنني تحديد الخطوط الفعلية المستخدمة في عرض تقديمي قبل التحويل؟**

يتيح Aspose.Slides لك فحص الخطوط المستخدمة عبر [font manager](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/)، حتى تتمكن من اتخاذ قرار ما إذا كنت ستقوم بـ [embed](/slides/ar/java/embedded-font/)، أو [replace](/slides/ar/java/font-replacement/)، أو إضافة [external sources](/slides/ar/java/custom-font/). يساعدك ذلك على منع الاستبدالات غير المرغوب فيها أثناء العرض والتصدير.

**هل يمكنني إضافة دلائل خطوط إضافية دون تثبيتها على نظام التشغيل؟**

نعم. يمكنك تسجيل [external font sources](/slides/ar/java/custom-font/) مثل المجلدات أو التدفقات في الذاكرة لأغراض العرض والتصدير. هذا يزيل الاعتماد على خطوط نظام المضيف ويحافظ على توقع تخطيط الصفحات.

**كيف يمكنني منع الانتقال الصامت إلى خط غير مناسب عندما يكون هناك حرف مفقود؟**

عرِّف صراحةً [font replacement](/slides/ar/java/font-replacement/) وقواعد [fallback-font](/slides/ar/java/fallback-font/) مسبقاً. من خلال تحليل الخطوط المستخدمة وتحديد أولوية محكومة للبدائل، تضمن طباعة متسقة وتجنب النتائج غير المتوقعة.