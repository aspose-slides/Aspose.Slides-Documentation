---
title: عرض العروض التقديمية باستخدام خطوط احتياطية في C++
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/cpp/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام خطوط احتياطية في Aspose.Slides لـ C++ – احفظ النص متسقًا عبر PPT و PPTX و ODP باستخدام عينات كود C++ خطوة بخطوة."
---

المثال التالي يتضمن الخطوات التالية:

1. نحن [إنشاء مجموعة قواعد الخط الاحتياطي](/slides/ar/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/) قاعدة خط احتياطي و[AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) إلى قاعدة أخرى.
1. مرّر مجموعة القواعد إلى [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) .
1. باستخدام طريقة [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) يمكننا حفظ العرض التقديمي بنفس التنسيق أو حفظه بتنسيق آخر. بعد ضبط مجموعة قواعد الخط الاحتياطي في FontsManager، تُطبق هذه القواعد خلال أي عملية على العرض التقديمي: الحفظ، أو العرض، أو التحويل، إلخ.
``` cpp
// إنشاء نسخة جديدة من مجموعة القواعد
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// إنشاء عدد من القواعد
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
	fallBackRule->Remove(u"Tahoma");

	// ولتحديث القواعد للنطاق المحدد
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [تحويل شرائح PowerPoint إلى PNG في C++](/slides/ar/cpp/convert-powerpoint-to-png/).
{{% /alert %}}