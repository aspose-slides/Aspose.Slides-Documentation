---
title: استبدال الخط - PowerPoint Java API
linktitle: استبدال الخط
type: docs
weight: 70
url: /androidjava/font-substitution/
keywords: "خط، استبدال الخط، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "استبدال الخط في PowerPoint باستخدام Java"
---

Aspose.Slides يتيح لك تعيين قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. توليد صورة الشريحة لملاحظة التأثير.

هذا رمز Java يوضح عملية استبدال الخط:

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
    
    // إضافة القاعدة إلى مجموعة قواعد استبدال الخط
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // إضافة مجموعة قواعد الخط إلى قائمة القواعد
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يصبح غير متاح
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // حفظ الصورة على القرص في format JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

قد ترغب في الاطلاع على [**استبدال الخط**](/slides/androidjava/font-replacement/).

{{% /alert %}}