---
title: عرض العروض التقديمية باستخدام الخطوط الاحتياطية في Java
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/java/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض عرض تقديمي
- عرض شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام الخطوط الاحتياطية في Aspose.Slides للغة Java – الحفاظ على تناسق النص عبر ملفات PPT و PPTX و ODP مع أمثلة كود Java خطوة بخطوة."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بعرض العروض التقديمية باستخدام قواعد الخطوط الاحتياطية. يوضح هذا المقال كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية، تعديل قواعدها بإزالة أو إضافة خطوط احتياطية، وتعيين المجموعة باستخدام طريقة `FontsManager.setFontFallBackRulesCollection`.

بمجرد تعيين مجموعة قواعد الخطوط الاحتياطية إلى `FontsManager` الخاص بالعرض التقديمي، تُطبق القواعد أثناء عمليات مثل الحفظ، العرض، وتحويل العرض التقديمي. يوضح المثال كيفية استخدام القواعد المُكوَّنة عند عرض صورة مصغرة للشريحة وحفظها كصورة JPEG.

## **عرض شريحة باستخدام قواعد الخطوط الاحتياطية**

المثال التالي يتضمن الخطوات التالية:

1. نقوم ب[إنشاء مجموعة قواعد الخطوط الاحتياطية](/slides/ar/java/create-fallback-fonts-collection/).
2. [إزالة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط احتياطية و[addFallBackFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
3. قم بتعيين مجموعة القواعد إلى [getFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) طريقة.
4. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس الصيغة، أو حفظه بصيغة أخرى. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى [FontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsManager)، تُطبق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

```java
import com.aspose.slides.*;

// إنشاء نسخة جديدة من مجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
    fallBackRule.remove("Tahoma");

    // و لتحديث القواعد للنطاق المحدد
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة، مع الحفاظ على قاعدة واحدة على الأقل للعرض مع
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // تعيين قائمة القواعد المُجهزة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // عرض الصورة المصغرة باستخدام مجموعة القواعد المُهيأة وحفظها بصيغة JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // حفظ الصورة إلى القرص بصيغة JPEG
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
اقرأ المزيد حول كيفية [تحويل PPT و PPTX إلى JPG في Java](/slides/ar/java/convert-powerpoint-to-jpg/).
{{% /alert %}}