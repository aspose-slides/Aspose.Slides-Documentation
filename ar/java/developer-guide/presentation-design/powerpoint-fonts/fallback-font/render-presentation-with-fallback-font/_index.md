---
title: عرض العروض التقديمية مع خطوط احتياطية في Java
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/java/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "عرض العروض التقديمية مع خطوط احتياطية في Aspose.Slides لـ Java – الحفاظ على تناسق النص عبر PPT و PPTX و ODP مع نماذج شيفرة Java خطوة بخطوة."
---

المثال التالي يتضمن هذه الخطوات:

1. نحن [ننشئ مجموعة قواعد الخطوط الاحتياطية](/slides/ar/java/create-fallback-fonts-collection/).
1. [إزالة](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط احتياطية وإضافة [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
1. ضبط مجموعة القواعد إلى طريقة [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) الطريقة.
1. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس الصيغة، أو حفظه بصيغة أخرى. بعد ضبط مجموعة قواعد الخطوط الاحتياطية إلى [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)، تُطبق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.
```java
// إنشاء مثيل جديد لمجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // محاولة إزالة خط FallBack "Tahoma" من القواعد المحمَّلة
    fallBackRule.remove("Tahoma");

    // ولتحديث القواعد للنطاق المحدد
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // تعيين قائمة القواعد المُعدة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // إنشاء صورة مصغرة باستخدام مجموعة القواعد المبدئية وحفظها كـ JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // حفظ الصورة إلى القرص بتنسيق JPEG
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
اقرأ المزيد حول كيفية [تحويل PPT و PPTX إلى JPG في Java](/slides/ar/java/convert-powerpoint-to-jpg/).
{{% /alert %}}