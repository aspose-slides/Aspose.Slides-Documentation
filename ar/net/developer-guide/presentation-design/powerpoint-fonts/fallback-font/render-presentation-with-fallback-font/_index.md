---
title: عرض العروض التقديمية باستخدام خطوط احتياطية في .NET
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/net/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام خطوط احتياطية في Aspose.Slides لـ .NET – حافظ على تناسق النص عبر PPT و PPTX و ODP مع أمثلة كود C# خطوة بخطوة."
---

تتضمن المثال التالي هذه الخطوات:

1. نقوم بـ[إنشاء مجموعة قواعد خطوط الاحتياطي](/slides/ar/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) قاعدة خطوط احتياطي و[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) إلى قاعدة أخرى.
1. قم بتعيين مجموعة القواعد إلى خاصية [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. باستخدام طريقة [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه بتنسيق آخر. بعد تعيين مجموعة قواعد خطوط الاحتياطي إلى FontsManager، تُطبق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.
```c#
// إنشاء مثيل جديد لمجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
	fallBackRule.Remove("Tahoma");

	// وتحديث القواعد للنطاق المحدد
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // تعيين قائمة القواعد المعدة للاستخدام
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // إنشاء صورة مصغرة باستخدام مجموعة القواعد المُهيأة وحفظها كملف PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
اقرأ المزيد حول [Save and Convertion in Presentation](/slides/ar/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}