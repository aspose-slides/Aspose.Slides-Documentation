---
title: تكوين استبدال الخطوط في العروض التقديمية على Android
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "تمكين استبدال الخطوط الأمثل في Aspose.Slides لنظام Android عبر Java عند تحويل عروض PowerPoint و OpenDocument إلى تنسيقات ملفات أخرى."
---

## **تعيين قواعد استبدال الخطوط**

تتيح لك Aspose.Slides تعيين قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (مثلاً عندما لا يمكن الوصول إلى الخط) بهذه الطريقة:

1. تحميل العرض التقديمي المناسب.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. إنشاء صورة الشريحة لملاحظة التأثير.

يوضح هذا الشيفرة Java عملية استبدال الخطوط:
```java
// يحمّل عرضًا تقديميًا
Presentation pres = new Presentation("Fonts.pptx");
try {
    // يحمّل الخط المصدر الذي سيُستبدل
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // يحمّل الخط الجديد
    IFontData destFont = new FontData("Arial");
    
    // يضيف قاعدة خط لاستبدال الخط
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // يضيف القاعدة إلى مجموعة قواعد استبدال الخطوط
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // يضيف مجموعة قواعد الخط إلى قائمة القواعد
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // سيُستخدم خط Arial بدلًا من SomeRareFont عندما يكون الأخير غير يمكن الوصول إليه
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // يحفظ الصورة على القرص بصيغة JPEG
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

قد ترغب في مشاهدة [**استبدال الخط**](/slides/ar/androidjava/font-replacement/).

{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[الاستبدال](/slides/ar/androidjava/font-replacement/) هو إلغاء قسري لخط واحد واستبداله بآخر عبر العرض التقديمي بالكامل. الاستبدال هو قاعدة تُفعَّل تحت شرط معين، مثل عندما يكون الخط الأصلي غير متوفر، ثم يُستخدم خط احتياطي محدد.

**متى تُطبق قواعد الاستبدال بالضبط؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/androidjava/font-selection-sequence/) القياسي الذي يتم تقييمه أثناء التحميل، وعرض الشرائح، والتحويل؛ إذا كان الخط المختار غير متوفر، يتم تطبيق الاستبدال أو الاستبدال.

**ما السلوك الافتراضي إذا لم يتم تكوين الاستبدال أو الاستبدال وكانت الخط غير موجود على النظام؟**

سوف تحاول المكتبة اختيار أقرب خط نظام متاح، مشابه للطريقة التي يتصرف بها PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة أثناء التشغيل لتجنب الاستبدال؟**

نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/androidjava/custom-font/) أثناء التشغيل حتى تأخذ المكتبة هذه الخطوط في الاعتبار للاختيار وعرضها، بما في ذلك التحويلات اللاحقة.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. لا تقوم Aspose بتوزيع خطوط مدفوعة أو مجانية؛ أنت تقوم بإضافة واستخدام الخطوط وفقًا لتقديرك ومسؤوليتك.

**هل هناك اختلافات في سلوك الاستبدال على Windows و Linux و macOS؟**

نعم. يبدأ اكتشاف الخطوط من أدلة الخطوط في نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف بين المنصات، مما يؤثر على التوافر والحاجة إلى الاستبدال.

**كيف يجب أن أعد البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الدفعة؟**

قم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/androidjava/custom-font/) المطلوبة للمستندات الناتجة، و[ادمج الخطوط](/slides/ar/androidjava/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا حتى تتوفر الخطوط المختارة أثناء العرض.