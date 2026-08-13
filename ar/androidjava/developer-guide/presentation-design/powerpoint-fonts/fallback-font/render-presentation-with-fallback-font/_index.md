---
title: عرض العروض التقديمية باستخدام خطوط احتياطية على Android
linktitle: عرض العروض
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
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام خطوط احتياطية في Aspose.Slides لـ Android – حافظ على تناسق النص عبر PPT و PPTX و ODP مع أمثلة شفرة Java خطوة بخطوة."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بعرض العروض التقديمية باستخدام قواعد الخط الاحتياطي. توضح هذه المقالة كيفية إنشاء مجموعة قواعد الخط الاحتياطي، تعديل قواعدها بإزالة أو إضافة خطوط احتياطية، وتعيين المجموعة باستخدام طريقة `FontsManager.setFontFallBackRulesCollection`.

بمجرد تعيين مجموعة قواعد الخط الاحتياطي إلى `FontsManager` الخاص بالعرض التقديمي، تُطبق القواعد خلال عمليات مثل الحفظ، العرض، وتحويل العرض. يوضح المثال كيفية استخدام القواعد المكوّنة عند عرض صورة مصغرة للشريحة وحفظها كصورة JPEG.

## **عرض شريحة باستخدام قواعد الخط الاحتياطي**

يتضمن المثال التالي هذه الخطوات:

1. نقوم بـ[إنشاء مجموعة قواعد الخط الاحتياطي](/slides/ar/androidjava/create-fallback-fonts-collection/).
1. [إزالة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط احتياطي و[addFallBackFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
1. قم بتعيين مجموعة القواعد إلى [getFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) طريقة.
1. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه بتنسيق آخر. بعد تعيين مجموعة قواعد الخط الاحتياطي إلى [FontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontsManager)، تُطبق هذه القواعد خلال أي عملية على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

```java
import com.aspose.slides.*;

// إنشاء نسخة جديدة من مجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
    fallBackRule.remove("Tahoma");

    //وتحديث القواعد للنطاق المحدد
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//يمكننا أيضًا إزالة أي قواعد موجودة من القائمة، مع إبقاء قاعدة واحدة على الأقل للعرض
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //تعيين قائمة القواعد المعدّة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    //إنشاء صورة مصغرة باستخدام مجموعة القواعد المبدئية وحفظها كملف JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //حفظ الصورة إلى القرص بصيغة JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
اقرأ المزيد حول [تحويل PPT و PPTX إلى JPG على Android](/slides/ar/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}