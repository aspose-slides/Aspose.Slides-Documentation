---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /ar/net/create-fallback-fonts-collection/
keywords: "مجموعة خطوط احتياطية، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "مجموعة خطوط احتياطية في باوربوينت بلغة C# أو .NET"
---

يمكن تنظيم حالات [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)، التي تنفذ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) واجهة. من الممكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) من فئة [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد عن [FontsManager و FontsLoader](/slides/ar/net/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يمتلك خاصية [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) مع مثيل خاص به من فئة FontsManager.

إليك مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى FontsManager لعرض تقديمي معين:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

بعد تهيئة FontsManager مع مجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد عن كيفية [عرض العرض التقديمي باستخدام خط احتياطي](/slides/ar/net/render-presentation-with-fallback-font/).
{{% /alert %}}