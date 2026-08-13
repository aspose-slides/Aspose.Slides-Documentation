---
title: عرض العروض التقديمية باستخدام الخطوط الاحتياطية في .NET
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
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام الخطوط الاحتياطية في Aspose.Slides لـ .NET – الحفاظ على تناسق النص عبر PPT و PPTX و ODP مع أمثلة شفرة C# خطوة بخطوة."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بعرض العروض التقديمية باستخدام قواعد الخطوط الاحتياطية. يوضح هذا المقال كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية، تعديل قواعدها بإزالة أو إضافة خطوط احتياطية، وتعيين المجموعة إلى الخاصية `FontsManager.FontFallBackRulesCollection`.

بمجرد تعيين مجموعة قواعد الخطوط الاحتياطية إلى `FontsManager` في العرض التقديمي، تُطبق القواعد أثناء عمليات مثل الحفظ، العرض، وتحويل العرض. يوضح المثال كيفية استخدام القواعد المكوَّنة عند عرض صورة مصغرة لشريحة وحفظها كصورة PNG.

## **عرض شريحة باستخدام قواعد الخطوط الاحتياطية**

يتضمن المثال التالي الخطوات التالية:

1. نقوم بـ[إنشاء مجموعة قواعد الخطوط الاحتياطية](/slides/ar/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/ar/net/aspose.slides/fontfallbackrule/methods/remove) قاعدة خط احتياطي و[AddFallBackFonts()](https://reference.aspose.com/slides/ar/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) إلى قاعدة أخرى.
1. ضبط مجموعة القواعد إلى خاصية [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. باستخدام طريقة [Presentation.Save()](https://reference.aspose.com/slides/ar/net/aspose.slides.presentation/save/methods/4) يمكن حفظ العرض التقديمي بنفس الصيغة، أو حفظه بصيغة أخرى. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى FontsManager، تُطبق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

```c#
using Aspose.Slides;

// إنشاء مثيل جديد لمجموعة القواعد
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// إنشاء عدد من القواعد
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// محاولة إزالة الخط الاحتياطي "Tahoma" من القواعد المحملة
	fallBackRule.Remove("Tahoma");

	// وتحديث القواعد للنطاق المحدد
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة، مع الحفاظ على قاعدة واحدة على الأقل للعرض
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // تعيين قائمة القواعد المعدة للاستخدام
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // عرض الصورة المصغرة باستخدام مجموعة القواعد المهيئة وحفظها كـ PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="info" %}} 
اقرأ المزيد عن [الحفظ والتحويل في العرض التقديمي](/slides/ar/net/convert-powerpoint-to-png/).
{{% /alert %}}