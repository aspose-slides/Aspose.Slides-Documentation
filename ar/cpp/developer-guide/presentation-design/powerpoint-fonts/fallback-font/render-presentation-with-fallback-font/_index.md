---
title: "عرض العروض التقديمية باستخدام خطوط احتياطية في C++"
linktitle: "عرض العروض التقديمية"
type: docs
weight: 30
url: /ar/cpp/render-presentation-with-fallback-font/
keywords:
- "خط احتياطي"
- "عرض PowerPoint"
- "عرض عرض تقديمي"
- "عرض شريحة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "عرض العروض التقديمية باستخدام خطوط احتياطية في Aspose.Slides للغة C++ – الحفاظ على تناسق النص عبر ملفات PPT و PPTX و ODP مع أمثلة شفرة C++ خطوة بخطوة."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بعرض العروض التقديمية باستخدام قواعد الخط الاحتياطي. يوضح هذا المقال كيفية إنشاء مجموعة قواعد الخط الاحتياطي، تعديل قواعدها بإزالة أو إضافة خطوط احتياطية، وتعيين المجموعة باستخدام طريقة `FontsManager::set_FontFallBackRulesCollection`.

بمجرد تعيين مجموعة قواعد الخط الاحتياطي إلى `FontsManager` الخاص بالعرض التقديمي، يتم تطبيق القواعد أثناء عمليات مثل الحفظ، والعرض، وتحويل العرض التقديمي. يوضح المثال كيفية استخدام القواعد التي تم تكوينها عند عرض صورة مصغرة للشريحة وحفظها كصورة PNG.

## **عرض شريحة باستخدام قواعد الخط الاحتياطي**

يتضمن المثال التالي هذه الخطوات:

1. نحن [إنشاء مجموعة قواعد الخط الاحتياطي](/slides/ar/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/remove/) قاعدة خط احتياطية و[AddFallBackFonts()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) لقاعدة أخرى.
3. تمرير مجموعة القواعد إلى طريقة [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. باستخدام طريقة [Presentation::Save()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) يمكننا حفظ العرض التقديمي بنفس الصيغة، أو حفظه بصيغة أخرى. بعد تعيين مجموعة قواعد الخط الاحتياطي إلى FontsManager، يتم تطبيق هذه القواعد أثناء أي عمليات على العرض التقديمي: حفظ، عرض، تحويل، إلخ.

``` cpp
// إنشاء مثيل جديد لمجموعة القواعد
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// إنشاء عدد من القواعد
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// محاولة إزالة الخط الاحتياطي "Tahoma" من القواعد المحمَّلة
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
// تعيين قائمة القواعد المُعدة للاستخدام
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// عرض الصورة المصغرة باستخدام مجموعة القواعد المهيأة وحفظها كـ PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [تحويل شرائح PowerPoint إلى PNG باستخدام C++](/slides/ar/cpp/convert-powerpoint-to-png/).
{{% /alert %}}