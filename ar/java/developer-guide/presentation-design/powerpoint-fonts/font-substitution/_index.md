---
title: استبدال الخط - واجهة برمجة تطبيقات PowerPoint Java
linktitle: استبدال الخط
type: docs
weight: 70
url: /java/font-substitution/
keywords: "خط، استبدال الخط، عرض PowerPoint، Java، Aspose.Slides for Java"
description: "استبدال الخط في PowerPoint بلغة Java"
---

يسمح لك Aspose.Slides بتحديد قواعد للخطوط التي تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. قم بتحميل العرض التقديمي المعني.
2. قم بتحميل الخط الذي سيتم استبداله.
3. قم بتحميل الخط الجديد.
4. أضف قاعدة للاستبدال.
5. أضف القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. قم بإنشاء صورة الشريحة لملاحظة التأثير.

يوضح هذا الكود بلغة Java عملية استبدال الخط:

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
    
    // سيتم استخدام خط Arial بدلاً من SomeRareFont عندما يكون الأخير غير متاح
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // حفظ الصورة على القرص في تنسيق JPEG
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

قد ترغب في رؤية [**استبدال الخط**](/slides/java/font-replacement/). 

{{% /alert %}}