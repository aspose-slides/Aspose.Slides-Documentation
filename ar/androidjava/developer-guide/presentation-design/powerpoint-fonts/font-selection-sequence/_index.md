---
title: سلسلة اختيار الخط في Aspose.Slides لنظام Android عبر Java
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
description: "اكتشف كيف يقوم Aspose.Slides لنظام Android عبر Java باختيار الخطوط، مما يضمن عرضًا واضحًا ومتسقًا لملفات PPT و PPTX و ODP — حسّن شرائحك الآن."
---

## **اختيار الخط**

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced — see [**استبدال الخط**](https://docs.aspose.com/slides/androidjava/font-replacement/) and [**استبدال الخطوط**](https://docs.aspose.com/slides/androidjava/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. تقوم Aspose.Slides بالبحث عن الخطوط في نظام التشغيل للعثور على الخط الذي يتطابق مع الخط المختار في العرض التقديمي. 
2. إذا تم العثور على الخط المختار، تستخدمه Aspose.Slides. وإلا، تستخدم Aspose.Slides خط استبدالي يكون أقرب ما يمكن إلى ما سيستخدمه PowerPoint.
3. إذا تم تعيين قواعد استبدال الخط عبر [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)، فإنها تُطبق.

Aspose.Slides تسمح لك بإضافة الخطوط إلى وقت تشغيل التطبيق ثم استخدامها. راجع [**خطوط مخصصة**](https://docs.aspose.com/slides/androidjava/custom-font/).

عند وضع خطوط إضافية داخل العرض التقديمي، تُسمى [**خطوط مدمجة**](https://docs.aspose.com/slides/androidjava/embedded-font/).

Aspose.Slides تسمح لك بإضافة خطوط تُطبّق على المستندات الناتجة *فقط*. على سبيل المثال، إذا كان العرض التقديمي الذي تريد تحويله إلى PDF يحتوي على خطوط مفقودة من نظامك والخطوط المدمجة، يمكنك إضافة أو تحميل الخطوط المطلوبة كـ **خطوط خارجية**. 

{{% alert title="Note" color="primary" %}} 
نحن لا نقوم بتوزيع أي خطوط، سواء كانت مدفوعة أو مجانية. تسمح لك واجهة برمجة التطبيقات بتحميل الخطوط الخارجية وتضمينها في المستندات، ولكن تقوم بذلك وفقًا لتقديرك ومسؤوليتك بشأن الخطوط.
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني تحديد الخطوط المستخدمة فعليًا في عرض تقديمي قبل التحويل؟**

تتيح لك Aspose.Slides فحص الخطوط المستخدمة عبر [font manager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/)، بحيث يمكنك اتخاذ القرار سواءً بـ [تضمين](/slides/ar/androidjava/embedded-font/)، أو [استبدال](/slides/ar/androidjava/font-replacement/)، أو إضافة [مصادر خارجية](/slides/ar/androidjava/custom-font/). يساعدك ذلك على منع الاستبدالات غير المرغوب فيها أثناء العرض والتصدير.

**هل يمكنني إضافة دلائل خطوط إضافية دون تثبيتها على نظام التشغيل؟**

نعم. يمكنك تسجيل [مصادر خطوط خارجية](/slides/ar/androidjava/custom-font/) مثل المجلدات أو التدفقات في الذاكرة للتصوير والتصدير. يزيل هذا الاعتمادية على خطوط نظام المضيف ويحافظ على استقرار التخطيط.

**كيف يمكنني منع الانتقال الصامت إلى خط غير مناسب عندما يكون رمز غير متوفر؟**

حدد [استبدال الخط](/slides/ar/androidjava/font-replacement/) و[قواعد احتياطي الخط](/slides/ar/androidjava/fallback-font/) بشكل صريح مسبقًا. عبر تحليل الخطوط المستخدمة وتحديد أولوية مُتحكم فيها للبدائل، تضمن طباعة متسقة وتتجنب النتائج غير المتوقعة.