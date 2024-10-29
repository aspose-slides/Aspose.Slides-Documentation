---
title: تسلسل اختيار الخط في Java
linktitle: تسلسل اختيار الخط في Java
type: docs
weight: 80
url: /ar/androidjava/font-selection-sequence/
keywords:
- خط
- اختيار الخط
- استبدال الخط
- تعويض الخط
- عرض تقديمي في PowerPoint
- Java
- Aspose.Slides for Android via Java
description: تسلسل اختيار الخط في PowerPoint في Java
---

## اختيار الخط

تنطبق قواعد معينة على الخطوط في العرض التقديمي عندما يتم تحميل العرض أو تقديمه أو تحويله إلى تنسيق آخر. على سبيل المثال، عندما تحاول تحويل عرض تقديمي (شرائحه) إلى صور، يتم فحص خطوط العرض للتأكد من أن الخطوط المختارة متاحة في نظام التشغيل. إذا تم التأكد من أن الخطوط مفقودة، يتم استبدالها — انظر [**استبدال الخط**](https://docs.aspose.com/slides/androidjava/font-replacement/) و [**تعويض الخط**](https://docs.aspose.com/slides/androidjava/font-substitution/).

هذه هي العملية التي تتبعها Aspose.Slides عند التعامل مع الخطوط:

1. تبحث Aspose.Slides عن الخطوط في نظام التشغيل لإيجاد الخط الذي يتطابق مع الخط المختار في العرض التقديمي.
2. إذا تم العثور على الخط المختار، تستخدمه Aspose.Slides. أما إذا لم يكن متوفرًا، فتستخدم Aspose.Slides خطًا بديلاً يكون قريبًا قدر الإمكان مما ستستخدمه PowerPoint.
3. إذا تم تحديد قواعد استبدال الخطوط من خلال [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/)، يتم تطبيقها.

تتيح لك Aspose.Slides إضافة خطوط إلى بيئة وقت تشغيل التطبيق ثم استخدام تلك الخطوط. انظر [**خطوط مخصصة**](https://docs.aspose.com/slides/androidjava/custom-font/).

عندما يتم وضع خطوط إضافية داخل عرض تقديمي، تُسمى [**خطوط مدمجة**](https://docs.aspose.com/slides/androidjava/embedded-font/).

تسمح لك Aspose.Slides بإضافة خطوط تُطبق فقط على المستندات الناتجة. على سبيل المثال، إذا كان العرض التقديمي الذي ترغب في تحويله إلى PDF يحتوي على خطوط مفقودة من نظامك وخطوط مدمجة، يمكنك إضافة أو تحميل الخطوط اللازمة كـ **خطوط خارجية**.

{{% alert title="ملاحظة" color="primary" %}} 
نحن لا نوزع أي خطوط، سواء كانت مدفوعة أو مجانية. تتيح لك واجهة برمجة التطبيقات (API) الخاصة بنا تحميل خطوط خارجية وإدراجها في المستندات، لكنك تفعل ذلك بخطوط تكون بتقديرك ومسؤوليتك.
{{% /alert %}}