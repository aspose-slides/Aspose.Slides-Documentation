---
title: تسلسل اختيار الخط في Aspose.Slides لنظام Android عبر Java
linktitle: اختيار الخط
type: docs
weight: 80
url: /ar/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف يختار Aspose.Slides لنظام Android عبر Java الخطوط، مما يضمن عرضًا واضحًا ومتسقًا لملفات PPT و PPTX و ODP — حسّن شرائحك الآن."
---
## **نظرة عامة**

عند تحميل عرض تقديمي أو عرضه أو تحويله إلى تنسيق آخر، يتحقق Aspose.Slides مما إذا كانت الخطوط المستخدمة في العرض متوفرة في نظام التشغيل. إذا كان الخط المطلوب مفقودًا، يختار Aspose.Slides خطًا بديلاً قريبًا قدر الإمكان من الخط الذي سيستخدمه PowerPoint.

يبحث Aspose.Slides أولاً عن الخط المحدد في نظام التشغيل. إذا تم العثور على الخط، يُستخدم. إذا لم يُعثر عليه، يتم تطبيق خط بديل مناسب. عندما يتم تعريف قواعد استبدال الخطوط عبر `FontSubstRule`، تُؤخذ تلك القواعد في الاعتبار أيضًا.

يمكنك أيضًا إضافة خطوط في وقت تشغيل التطبيق، أو استخدام الخطوط المضمنة من العرض، أو تحميل خطوط خارجية للمستندات الناتجة مثل ملفات PDF.

## **اختيار الخط**

تنطبق قواعد معينة على الخطوط في العرض عندما يتم تحميله أو عرضه أو تحويله إلى تنسيق آخر. على سبيل المثال، عند محاولة تحويل عرض (شرائحه) إلى صور، يتم فحص خطوط العرض للتحقق من توفر الخطوط المختارة في نظام التشغيل. إذا تأكد أن الخطوط مفقودة، يتم استبدالها — انظر إلى [**استبدال الخط**](https://docs.aspose.com/slides/ar/androidjava/font-replacement/) و[**استبدال الخطوط**](https://docs.aspose.com/slides/ar/androidjava/font-substitution/).

هذه هي العملية التي يتبعها Aspose.Slides عند التعامل مع الخطوط:

1. يبحث Aspose.Slides عن الخطوط في نظام التشغيل للعثور على الخط الذي يتطابق مع الخط المختار في العرض.  
2. إذا تم العثور على الخط المختار، يستخدمه Aspose.Slides. وإلا، يستخدم خطًا بديلاً قريبًا قدر الإمكان مما يستخدمه PowerPoint.  
3. إذا تم ضبط قواعد استبدال الخطوط عبر [FontSubstRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsubstrule/)، فسيتم تطبيقها.

يتيح لك Aspose.Slides إضافة خطوط إلى وقت تشغيل التطبيق ثم استخدام تلك الخطوط. راجع [**الخطوط المخصصة**](https://docs.aspose.com/slides/ar/androidjava/custom-font/).

عندما تُضع خطوط إضافية داخل العرض، تُطلق عليها تسمية [**الخطوط المضمنة**](https://docs.aspose.com/slides/ar/androidjava/embedded-font/).

يتيح لك Aspose.Slides إضافة خطوط تُطبق *فقط* على المستندات الناتجة. على سبيل المثال، إذا كان العرض الذي تحاول تحويله إلى PDF يحتوي على خطوط مفقودة من نظامك والخطوط المضمنة، يمكنك إضافة أو تحميل الخطوط اللازمة كـ **خطوط خارجية**.

{{% alert title="Note" color="info" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **الأسئلة المتكررة**

### كيف يمكنني تحديد الخطوط المستخدمة فعليًا في العرض التقديمي قبل التحويل؟

يتيح لك Aspose.Slides فحص الخطوط المستخدمة عبر [مدير الخطوط](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsmanager/)، بحيث يمكنك اتخاذ قرار بـ [تضمين](/slides/ar/androidjava/embedded-font/)، [استبدال](/slides/ar/androidjava/font-replacement/)، أو إضافة [مصادر خارجية](/slides/ar/androidjava/custom-font/). يساعدك هذا على منع الاستبدالات غير المرغوب فيها أثناء العرض والتصدير.

### هل يمكنني إضافة دلائل خطوط إضافية دون تثبيتها على نظام التشغيل؟

نعم. يمكنك تسجيل [مصادر الخطوط الخارجية](/slides/ar/androidjava/custom-font/) مثل المجلدات أو التدفقات الذاكرةية للعرض والتصدير. يزيل ذلك الاعتماد على خطوط نظام المضيف ويحافظ على استقرار التخطيط.

### كيف أُجنب الانتقال الصامت إلى خط غير مناسب عندما يكون الحرف مفقودًا؟

حدد مسبقًا [استبدال الخط](/slides/ar/androidjava/font-replacement/) وقواعد [الخط الاحتياطي](/slides/ar/androidjava/fallback-font/). من خلال تحليل الخطوط المستخدمة وتحديد أولوية محكومة للبدائل، تضمن طباعة متسقة وتتفادى النتائج غير المتوقعة.