---
title: تسلسل اختيار الخط
linktitle: تسلسل اختيار الخط
type: docs
weight: 80
url: /php-java/font-selection-sequence/
keywords: "خط, اختيار خط, استبدال خط, استبدال الخط, عرض PowerPoint, Java, Aspose.Slides لـ PHP عبر Java"
description: تسلسل اختيار الخط في PowerPoint
---

## اختيار الخط

تطبق قواعد معينة على الخطوط في عرض تقديمي عند تحميل العرض التقديمي أو عرضه أو تحويله إلى تنسيق آخر. على سبيل المثال، عند محاولة تحويل عرض تقديمي (شرائحه) إلى صور، يتم التحقق من خطوط العرض للتأكد من أن الخطوط المختارة متاحة في نظام التشغيل. إذا تم تأكيد عدم توفر الخطوط، يتم استبدالها—انظر [**استبدال الخط**](https://docs.aspose.com/slides/php-java/font-replacement/) و [**استبدال الخط**](https://docs.aspose.com/slides/php-java/font-substitution/).

هذه هي العملية التي تتبعها Aspose.Slides عند التعامل مع الخطوط:

1. تبحث Aspose.Slides عن الخطوط في نظام التشغيل للعثور على الخط الذي يتطابق مع الخط المختار في العرض التقديمي.
2. إذا تم العثور على الخط المختار، تستخدمه Aspose.Slides. وإلا، تستخدم Aspose.Slides خطاً بديلاً يكون قريباً جداً مما ستستخدمه PowerPoint.
3. إذا تم تعيين قواعد استبدال الخطوط من خلال [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/)، يتم تطبيقها.

تسمح لك Aspose.Slides بإضافة خطوط إلى وقت تشغيل Aspose ثم استخدام تلك الخطوط. انظر [**خطوط مخصصة**](https://docs.aspose.com/slides/php-java/custom-font/).

عندما يتم وضع خطوط إضافية ضمن عرض تقديمي، تُسمى [**خطوط متضمنة**](https://docs.aspose.com/slides/php-java/embedded-font/).

تسمح لك Aspose.Slides بإضافة خطوط تُطبق على *فقط* مستندات الإخراج. على سبيل المثال، إذا كان العرض التقديمي الذي تسعى لتحويله إلى PDF يحتوي على خطوط مفقودة من نظامك وخطوط متضمنة، يمكنك إضافة أو تحميل الخطوط المطلوبة كـ **خطوط خارجية**.