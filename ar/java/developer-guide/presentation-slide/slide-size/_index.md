---
title: حجم الشريحة
type: docs
weight: 70
url: /ar/java/slide-size/

---

## أحجام الشرائح في عروض PowerPoint

تتيح لك Aspose.Slides لـ Java تغيير حجم الشريحة أو نسبة العرض إلى الارتفاع في عروض PowerPoint. إذا كنت تخطط لطباعة عرضك أو عرض شرائحه على الشاشة، يجب أن تولي اهتمامًا لحجم الشريحة أو نسبة العرض إلى الارتفاع.

هذه هي أكثر أحجام الشرائح ونسب العرض إلى الارتفاع شيوعًا:

- **قياسي (نسبة عرض إلى ارتفاع 4:3)**

  إذا كان سيتم عرض عرضك أو مشاهدته على أجهزة أو شاشات قديمة نسبيًا، فقد ترغب في استخدام هذا الإعداد.

- **عريض (نسبة عرض إلى ارتفاع 16:9)** 

  إذا كان سيتم عرض عرضك على أجهزة عرض أو شاشات حديثة، فقد ترغب في استخدام هذا الإعداد.

لا يمكنك استخدام إعدادات حجم الشريحة متعددة في عرض تقديمي واحد. عند اختيار حجم شريحة لعرض تقديمي، يتم تطبيق إعداد حجم الشريحة هذا على جميع الشرائح في العرض التقديمي.

إذا كنت تفضل استخدام حجم شريحة خاص لعروضك التقديمية، نوصي بشدة أن تقوم بذلك مبكرًا. من الناحية المثالية، يجب أن تحدد حجم الشريحة المفضل لديك في البداية، أي عندما تكون بصدد إعداد العرض التقديمي، قبل إضافة أي محتوى إلى العرض. بهذه الطريقة، يمكنك تجنب التعقيدات التي قد تنجم عن التغييرات (المستقبلية) التي تم إجراؤها على حجم الشرائح.

{{% alert color="primary" %}} 

 عند استخدام Aspose.Slides لإنشاء عرض تقديمي، يتم تلقائيًا تعيين جميع الشرائح في العرض التقديمي على الحجم القياسي أو نسبة عرض إلى ارتفاع 4:3.

{{% /alert %}} 

## تغيير حجم الشريحة في العروض التقديمية

يوضح لك هذا الكود النموذجي كيفية تغيير حجم الشريحة في عرض تقديمي باستخدام Aspose.Slides في Java:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## تحديد أحجام الشرائح المخصصة في العروض التقديمية

إذا وجدت أن أحجام الشرائح الشائعة (4:3 و 16:9) غير مناسبة لعملك، فقد تقرر استخدام حجم شريحة محدد أو فريد. على سبيل المثال، إذا كنت تخطط لطباعة شرائح بالحجم الكامل من عرضك التقديمي على تخطيط صفحة مخصص أو إذا كنت تنوي عرض عرضك التقديمي على أنواع معينة من الشاشات، فمن المحتمل أن تستفيد من استخدام إعداد حجم مخصص لعروضك التقديمية.

يوضح لك هذا الكود النموذجي كيفية استخدام Aspose.Slides لـ Java لتحديد حجم شريحة مخصص لعرض تقديمي في Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // حجم ورقة A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## التعامل مع القضايا عند تغيير حجم الشرائح في العروض التقديمية

بعد تغيير حجم الشريحة لعرض تقديمي، قد تتشوه محتويات الشرائح (مثل الصور أو الكائنات). بشكل افتراضي، يتم تغيير حجم الكائنات تلقائيًا لتناسب حجم الشريحة الجديد. ومع ذلك، عند تغيير حجم شريحة العرض التقديمي، يمكنك تحديد إعداد يحدد كيفية تعامل Aspose.Slides مع المحتويات على الشرائح.

بناءً على ما تنوي القيام به أو تحقيقه، يمكنك استخدام أي من هذه الإعدادات:

- `DoNotScale`

  إذا كنت لا تريد تغيير حجم الكائنات في الشرائح، استخدم هذا الإعداد.

- `EnsureFit`

  إذا كنت تريد تغيير الحجم إلى حجم شريحة أصغر وتحتاج إلى أن تقوم Aspose.Slides بتقليص كائنات الشرائح لضمان ملاءمتها جميعًا في الشرائح (وبهذه الطريقة، تتجنب فقدان المحتوى)، استخدم هذا الإعداد.

- `Maximize`

  إذا كنت تريد تغيير الحجم إلى حجم شريحة أكبر وتحتاج إلى أن تقوم Aspose.Slides بتكبير كائنات الشرائح لجعلها متناسبة مع حجم الشريحة الجديد، استخدم هذا الإعداد.

يوضح لك هذا الكود النموذجي كيفية استخدام إعداد `Maximize` عند تغيير حجم شريحة عرض تقديمي:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```