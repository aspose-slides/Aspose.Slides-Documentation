---
title: تقديم العرض مع خط احتياطي
type: docs
weight: 30
url: /ar/java/render-presentation-with-fallback-font/
---

يتضمن المثال التالي هذه الخطوات:

1. نحن [ننشئ مجموعة قواعد الخطوط الاحتياطية](/slides/ar/java/create-fallback-fonts-collection/).
1. [إزالة](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط احتياطي و [إضافة خطوط احتياطية](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) لقواعد أخرى.
1. تعيين مجموعة القواعد إلى [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) الطريقة.
1. باستخدام [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض بنفس التنسيق، أو حفظه في تنسيق آخر. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)، يتم تطبيق هذه القواعد أثناء أي عمليات على العرض: حفظ، عرض، تحويل، إلخ.

```java
// إنشاء حالة جديدة من مجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //محاولة إزالة خط الاحتياطي "Tahoma" من القواعد المحملة
    fallBackRule.remove("Tahoma");

    // وتحديث القواعد لنطاق محدد
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //تعيين قائمة القواعد المعدة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // عرض الصورة المصغرة باستخدام مجموعة القواعد المحددة وحفظها بتنسيق JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //حفظ الصورة على القرص بتنسيق JPEG
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
اقرأ المزيد عن [الحفظ والتحويل في العرض](/slides/ar/java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}