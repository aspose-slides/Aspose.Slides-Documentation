---
title: عرض العروض التقديمية باستخدام خطوط احتياطية على Android
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/androidjava/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام خطوط احتياطية في Aspose.Slides لنظام Android – الحفاظ على تناسق النص عبر ملفات PPT و PPTX و ODP مع أمثلة شيفرة Java خطوة بخطوة."
---

المثال التالي يتضمن هذه الخطوات:

1. نقوم ب[إنشاء مجموعة قواعد الخط الاحتياطي](/slides/ar/androidjava/create-fallback-fonts-collection/).
1. [إزالة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط احتياطي و[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) لقاعدة أخرى.
1. تعيين مجموعة القواعد إلى طريقة [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس الصيغة، أو حفظه بصيغة أخرى. بعد تعيين مجموعة قواعد الخط الاحتياطي إلى [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)، يتم تطبيق هذه القواعد أثناء أي عمليات على العرض التقديمي: الحفظ، العرض، التحويل، إلخ.
```java
// إنشاء مثال جديد لمجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
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
    // تعيين قائمة القواعد المُعدّة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // إنشاء صورة مصغرة باستخدام مجموعة القواعد المهيأة وحفظها كملف JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // حفظ الصورة على القرص بتنسيق JPEG
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
اقرأ المزيد حول [تحويل PPT و PPTX إلى JPG على Android](/slides/ar/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}