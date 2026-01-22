---
title: عرض العروض التقديمية مع الخطوط البديلة في JavaScript
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/nodejs-java/render-presentation-with-fallback-font/
keywords:
- خط بديل
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "عرض العروض التقديمية مع الخطوط البديلة في Aspose.Slides لـ Node.js – حافظ على تناسق النص عبر PPT و PPTX و ODP مع عينات شفرة JavaScript خطوة بخطوة."
---

التعليمات التالية تشمل هذه الخطوات:

1. نقوم ب[إنشاء مجموعة قواعد الخطوط البديلة](/slides/ar/nodejs-java/create-fallback-fonts-collection/).
1. [إزالة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) قاعدة خط بديلة و[addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى قاعدة أخرى.
1. ضبط مجموعة القواعد إلى طريقة [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. باستخدام طريقة [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه بتنسيق آخر. بعد ضبط مجموعة قواعد الخطوط البديلة إلى [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)، تُطبق هذه القواعد خلال أي عمليات على العرض التقديمي: حفظ، تصيير، تحويل، إلخ.
```javascript
// إنشاء نسخة جديدة من مجموعة القواعد
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// إنشاء عدد من القواعد
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // محاولة إزالة الخط البديل "Tahoma" من القواعد المحملة
    fallBackRule.remove("Tahoma");
    // وتحديث القواعد للنطاق المحدد
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // تعيين قائمة القواعد المُعدة للاستخدام
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // إنشاء صورة مصغرة باستخدام مجموعة القواعد المهيأة وحفظها كملف JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // حفظ الصورة على القرص بصيغة JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
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


{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [تحويل PPT و PPTX إلى JPG في JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}