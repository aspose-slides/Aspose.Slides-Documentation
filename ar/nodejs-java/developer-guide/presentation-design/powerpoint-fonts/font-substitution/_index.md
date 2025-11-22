---
title: استبدال الخط - PowerPoint JavaScript API
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/nodejs-java/font-substitution/
keywords: "خط, استبدال الخط, عرض تقديمي PowerPoint, Java, Aspose.Slides لـ Node.js عبر Java"
description: "استبدال الخط في PowerPoint باستخدام JavaScript"
---

## **تحديد قواعد استبدال الخطوط**

يتيح لك Aspose.Slides تعيين قواعد للخطوط التي تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. تحميل العرض التقديمي المناسب.
2. تحميل الخط الذي سيُستبدل.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. إنشاء صورة الشريحة لملاحظة التأثير.

هذا كود JavaScript يوضح عملية استبدال الخطوط:
```javascript
// يحمل عرضًا تقديميًا
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // يحمل الخط المصدر الذي سيُستبدل
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // يحمل الخط الجديد
    var destFont = new aspose.slides.FontData("Arial");
    // يضيف قاعدة خط لاستبدال الخط
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // يضيف القاعدة إلى مجموعة قواعد استبدال الخطوط
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // يضيف مجموعة قواعد الخط إلى قائمة القواعد
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // سيُستخدم خط Arial بدلاً من SomeRareFont عندما يكون الأخير غير متاح
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // يحفظ الصورة على القرص بتنسيق JPEG
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
قد ترغب في الاطلاع على [**استبدال الخط**](/slides/ar/nodejs-java/font-replacement/).
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط واستبدال الخط (البديل)؟**

[استبدال](/slides/ar/nodejs-java/font-replacement/) هو تجاوز قوي لخط بآخر عبر العرض التقديمي بأكمله. البديل هو قاعدة تُفعَّل تحت شرط محدد، على سبيل المثال عندما يكون الخط الأصلي غير متاح، ثم يُستخدم خط احتياطي محدد.

**متى تُطبق قواعد الاستبدال بالضبط؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/nodejs-java/font-selection-sequence/) القياسي الذي يتم تقييمه أثناء التحميل، العرض، والتحويل؛ إذا كان الخط المختار غير متاح، يُطبق الاستبدال أو البديل.

**ما السلوك الافتراضي إذا لم يتم تكوين استبدال ولا بديل وكان الخط مفقودًا في النظام؟**

المكتبة ستحاول اختيار أقرب خط متاح في النظام، مشابهًا لسلوك PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة في وقت التشغيل لتجنب الاستبدال؟**

نعم. يمكنك [إضافة الخطوط الخارجية](/slides/ar/nodejs-java/custom-font/) أثناء وقت التشغيل حتى تأخذ المكتبة هذه الخطوط في الاعتبار للاختيار والعرض، بما في ذلك التحويلات اللاحقة.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. لا توزع Aspose أي خطوط مدفوعة أو مجانية؛ أنت تضيف وتستخدم الخطوط وفقًا لتقديرك ومسؤوليتك.

**هل هناك اختلافات في سلوك الاستبدال على Windows وLinux وmacOS؟**

نعم. يبدأ اكتشاف الخطوط من دلائل نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف بين الأنظمة، مما يؤثر على التوفر والحاجة إلى الاستبدال.

**كيف يجب أن أعد البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الدفعة؟**

قم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/nodejs-java/custom-font/) المطلوبة للمستندات الناتجة، و[دمج الخطوط](/slides/ar/nodejs-java/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا حتى تكون الخطوط المختارة متاحة أثناء العرض.