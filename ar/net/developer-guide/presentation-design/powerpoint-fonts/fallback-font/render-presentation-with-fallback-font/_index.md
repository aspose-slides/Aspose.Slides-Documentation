---
title: عرض العرض التقديمي بخط احتياطي
type: docs
weight: 30
url: /ar/net/render-presentation-with-fallback-font/
keywords: 
- خط احتياطي
- عرض PowerPoint
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "عرض PowerPoint بخط احتياطي في C# أو .NET"
---

يتضمن المثال التالي هذه الخطوات:

1. نحن [ننشئ مجموعة قواعد الخط الاحتياطي](/slides/ar/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) قاعدة خط احتياطي و [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) لقانون آخر.
1. تعيين مجموعة القواعد إلى خاصية [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. مع [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه في تنسيق آخر. بعد تعيين مجموعة قواعد الخط الاحتياطي إلى FontsManager، يتم تطبيق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

```c#
// إنشاء مثيل جديد من مجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//محاولة لإزالة خط الاحتياطي "Tahoma" من القواعد المحملة
	fallBackRule.Remove("Tahoma");

	//وتحديث القواعد للنطاق المحدد
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//كما يمكننا إزالة أي قواعد موجودة من القائمة
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //تعيين قائمة القواعد المعدة للاستخدام
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // عرض الصورة المصغرة باستخدام مجموعة القواعد المهيأة وحفظها بتنسيق PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
اقرأ المزيد عن [الحفظ والتحويل في العرض التقديمي](/slides/ar/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}