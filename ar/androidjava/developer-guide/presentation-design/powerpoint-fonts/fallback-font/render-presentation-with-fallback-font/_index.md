---
title: عرض تقديمي مع خط احتياطي
type: docs
weight: 30
url: /ar/androidjava/render-presentation-with-fallback-font/
---

يتضمن المثال التالي هذه الخطوات:

1. نحن [نقوم بإنشاء مجموعة قواعد الخطوط الاحتياطية](/slides/ar/androidjava/create-fallback-fonts-collection/).
1. [إزالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط احتياطي و[إضافة خطوط احتياطية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
1. ضبط مجموعة القواعد على [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) طريقة.
1. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه في تنسيق آخر. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)، يتم تطبيق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

```java
// إنشاء مثيل جديد من مجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // محاولة إزالة خط الاحتياطي "Tahoma" من القواعد المحملة
    fallBackRule.remove("Tahoma");

    // وتحديث القواعد للنطاق المحدد
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // تعيين قائمة القواعد المعدة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // عرض الصورة المصغرة باستخدام مجموعة القواعد المعينة وحفظها بصيغة JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // حفظ الصورة على القرص بصيغة JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
اقرأ المزيد حول [الحفظ والتحويل في العرض التقديمي](/slides/ar/androidjava/creating-saving-and-converting-a-presentation/).
{{% /alert %}}