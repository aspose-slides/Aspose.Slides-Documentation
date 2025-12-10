---
title: تهيئة استبدال الخطوط في العروض التقديمية باستخدام Java
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /ar/java/font-substitution/
keywords:
- خط
- خط بديل
- استبدال الخط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تمكين استبدال الخطوط الأمثل في Aspose.Slides لـ Java عند تحويل عروض PowerPoint و OpenDocument إلى صيغ ملفات أخرى."
---

## **تعيين قواعد استبدال الخطوط**

تتيح لك Aspose.Slides تعيين قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى الخط) بهذه الطريقة:

1. تحميل العرض التقديمي ذو الصلة.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. إنشاء صورة الشريحة لملاحظة التأثير.

هذا الكود Java يوضح عملية استبدال الخطوط:
```java
// تحميل عرض تقديمي
Presentation pres = new Presentation("Fonts.pptx");
try {
    // تحميل الخط المصدر الذي سيتم استبداله
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // تحميل الخط الجديد
    IFontData destFont = new FontData("Arial");
    
    // إضافة قاعدة خط لاستبدال الخط
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // إضافة مجموعة قواعد الخط إلى قائمة القواعد
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون الأخير غير قابل للوصول
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // حفظ الصورة إلى القرص بصيغة JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

قد ترغب في الاطلاع على [**استبدال الخط**](/slides/ar/java/font-replacement/). 

{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو الفرق بين استبدال الخط واستبدال الخط المؤقت؟**

[الاستبدال](/slides/ar/java/font-replacement/) هو إلغاء إجباري لخط واحد بآخر عبر العرض التقديمي بأكمله. الاستبدال المؤقت هو قاعدة تُفعَّل تحت شرط معين، مثل عدم توفر الخط الأصلي، ثم يُستخدم خط احتياطي محدد.

**متى يتم تطبيق قواعد الاستبدال المؤقت بالضبط؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/java/font-selection-sequence/) القياسي الذي يتم تقييمه أثناء التحميل، والعرض، والتحويل؛ إذا كان الخط المختار غير متوفر، يتم تطبيق الاستبدال أو الاستبدال المؤقت.

**ما السلوك الافتراضي إذا لم يتم تكوين استبدال ولا استبدال مؤقت وكان الخط مفقودًا على النظام؟**

ستحاول المكتبة اختيار أقرب خط نظام متاح، مشابه لما تفعله PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة أثناء التشغيل لتجنب الاستبدال المؤقت؟**

نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/java/custom-font/) أثناء التشغيل بحيث تأخذ المكتبة هذه الخطوط في الاعتبار للاختيار والعرض، بما في ذلك التحويلات اللاحقة.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. لا توزع Aspose خطوطًا مدفوعة أو مجانية؛ تقوم بإضافة واستخدام الخطوط حسب discretion والمسؤولية الخاصة بك.

**هل هناك اختلافات في سلوك الاستبدال المؤقت على Windows وLinux وmacOS؟**

نعم. يبدأ اكتشاف الخطوط من أدلة الخطوط في نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف بين الأنظمة، مما يؤثر على التوافر والحاجة إلى الاستبدال المؤقت.

**كيف يجب أن أعد البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الدفعة؟**

قم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/java/custom-font/) المطلوبة للمستندات الناتجة، و[ضمن الخطوط](/slides/ar/java/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا حتى تكون الخطوط المختارة متاحة أثناء العرض.