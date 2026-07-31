---
title: تغيير حجم شريحة العرض في .NET
linktitle: حجم الشريحة
type: docs
weight: 70
url: /ar/net/slide-size/
keywords:
- حجم الشريحة
- نسبة العرض إلى الارتفاع
- قياسي
- واسع الشاشة
- 4:3
- 16:9
- تعيين حجم الشريحة
- تغيير حجم الشريحة
- حجم شريحة مخصص
- حجم شريحة خاص
- حجم شريحة فريد
- شريحة بحجم كامل
- نوع الشاشة
- عدم التحجيم
- ضمان الملاءمة
- تكبير
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تغيير حجم الشرائح بسرعة في ملفات PPT و PPTX و ODP باستخدام .NET و Aspose.Slides، وحسّن العروض التقديمية لأي شاشة دون فقدان الجودة."
---
## **المقدمة**

توفر Aspose.Slides for .NET أدوات شاملة لضبط حجم الشريحة ونسبة العرض إلى الارتفاع في عروض PowerPoint التقديمية، وهو أمر حيوي لكل من الطباعة والعرض على الشاشة. 

الأحجام والنسب الشائعة للشرائح:

- **Standard (4:3 Aspect Ratio)**: مثالية للشاشات والأجهزة القديمة.
- **Widescreen (16:9 Aspect Ratio)**: يُنصح بها لأجهزة العرض الحديثة والشاشات.

احرص على الحفاظ على التناسق طوال عرضك حيث يُطبق حجم شريحة واحد ونسبة عرض إلى ارتفاع واحدة على جميع الشرائح. للحصول على أفضل النتائج، عيّن أبعاد الشريحة في بداية عملية إنشاء العرض لتجنب التعقيدات.

{{% alert color="primary" %}} 
بشكل افتراضي، تستخدم العروض التي يتم إنشاؤها باستخدام Aspose.Slides النسبة القياسية 4:3.
{{% /alert %}}

## **How to Change the Slide Size in a Presentation**

هذا المثال يوضح كيفية تغيير حجم شريحة العرض باستخدام Aspose.Slides في C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Specify Custom Slide Sizes**

تخصيص حجم الشريحة وفقًا لاحتياجاتك الخاصة، مثل تخطيطات الورق الفريدة أو مواصفات الشاشات، يمكن أن يكون مفيدًا. إليك كيفية تعيين حجم شريحة مخصص باستخدام Aspose.Slides for .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // حجم ورق A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Handle Slide Content After Resizing**

بعد تغيير الحجم، قد يتشوه محتوى الشريحة. يمكنك التحكم في كيفية إدارة Aspose.Slides لهذا التغيير:

- **`DoNotScale`**: الحفاظ على الكائنات بأحجامها الأصلية لتجنب التحجيم.
- **`EnsureFit`**: تحجيم الكائنات لتناسب الشرائح الأصغر، مما يمنع فقدان المحتوى.
- **`Maximize`**: تكبير الكائنات لتناسب الشرائح الأكبر لتحقيق تناسق جمالي.

مثال على استخدام إعداد `Maximize` لضبط حجم الشريحة:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**هل يمكنني تحديد حجم شريحة مخصص باستخدام وحدات غير البوصة (على سبيل المثال، النقاط أو المليمترات)؟**

نعم. تستخدم Aspose.Slides النقاط داخليًا، حيث يساوي 1 نقطة 1/72 من البوصة. يمكنك تحويل أي وحدة (مثل المليمترات أو السنتيمترات) إلى نقاط واستخدام القيم المحولّة لتحديد عرض الشريحة وارتفاعها.

**هل سيؤثر حجم شريحة مخصص كبير جدًا على الأداء واستهلاك الذاكرة أثناء العرض؟**

نعم. تؤدي الأبعاد الكبيرة للشريحة (بالنقاط) مع مقياس عرض أعلى إلى زيادة استهلاك الذاكرة وزيادة زمن المعالجة. احرص على اختيار حجم شريحة عملي واضبط مقياس العرض فقط حسب الحاجة لتحقيق جودة الإخراج المطلوبة.

**هل يمكنني تعريف حجم شريحة غير قياسي ثم دمج شرائح من عروض ذات أحجام مختلفة؟**

لا يمكنك [merge presentations](/slides/ar/net/merge-presentation/) بينما تكون الأحجام مختلفة — يجب أولاً تعديل حجم أحد العروض ليتطابق مع الآخر. عند تغيير حجم الشريحة، يمكنك اختيار كيفية معالجة المحتوى الموجود عبر خيار [SlideSizeScaleType](https://reference.aspose.com/slides/ar/net/aspose.slides/slidesizescaletype/). بعد مطابقة الأحجام، يمكنك دمج الشرائح مع الحفاظ على التنسيق.

**هل يمكنني إنشاء صور مصغرة لأشكال فردية أو مناطق محددة من الشريحة، وهل ستحترم حجم الشريحة الجديد؟**

نعم. يمكن لـ Aspose.Slides إنشاء صور مصغرة لـ [entire slides](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage/) وكذلك لـ [selected shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getimage/). تعكس الصور الناتجة حجم الشريحة الحالي ونسبة العرض إلى الارتفاع، مما يضمن تأطيرًا وتناسقًا هندسيًا ثابتًا.