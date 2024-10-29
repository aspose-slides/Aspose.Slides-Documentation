---
title: عرض العرض التقديمي باستخدام خط احتياطي
type: docs
weight: 30
url: /ar/cpp/render-presentation-with-fallback-font/
keywords: 
- خط احتياطي
- عرض PowerPoint
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides for C++
description: "عرض PowerPoint باستخدام خط احتياطي في C++"
---

يتضمن المثال التالي هذه الخطوات:

1. نحن [منشئون مجموعة قواعد الخطوط الاحتياطية](/slides/ar/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) قاعدة خط احتياطي و [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) إلى قاعدة أخرى.
1. تعيين مجموعة القواعد إلى [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) الخاصية.
1. باستخدام [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) الطريقة، يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه في تنسيق آخر. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى FontsManager، يتم تطبيق هذه القواعد خلال أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

``` cpp
// إنشاء مثيل جديد من مجموعة القواعد
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// إنشاء عدد من القواعد
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// محاولة إزالة خط الاحتياطي "Tahoma" من القواعد المحملة
	fallBackRule->Remove(u"Tahoma");

	// وتحديث القواعد للنطاق المحدد
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
// تعيين قائمة القواعد المعدة للاستخدام
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// عرض الصورة المصغرة باستخدام مجموعة القواعد المهيأة وحفظها إلى PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
اقرأ المزيد عن [الحفظ والتحويل في العرض التقديمي](/slides/ar/cpp/creating-saving-and-converting-a-presentation/).
{{% /alert %}}