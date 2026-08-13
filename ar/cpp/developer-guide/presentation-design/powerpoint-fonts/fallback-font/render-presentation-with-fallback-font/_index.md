---
title: عرض العروض باستخدام خطوط احتياطية في C++
linktitle: عرض العروض
type: docs
weight: 30
url: /ar/cpp/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- تقديم PowerPoint
- تقديم عرض
- تقديم شريحة
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "عرض العروض باستخدام خطوط احتياطية في Aspose.Slides للـ C++ – حافظ على اتساق النص عبر ملفات PPT و PPTX و ODP مع نماذج كود C++ خطوة بخطوة."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تقديم العروض باستخدام قواعد الخطوط الاحتياطية. يوضح هذا المقال كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية، وتعديل قواعدها عن طريق إزالة أو إضافة خطوط احتياطية، وتعيين المجموعة باستخدام طريقة `FontsManager::set_FontFallBackRulesCollection`.

بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى `FontsManager` الخاص بالعرض، يتم تطبيق القواعد أثناء عمليات مثل حفظ العرض، وتقديمه، وتحويله. يوضح المثال كيفية استخدام القواعد المكوَّنة عند تقديم صورة مصغرة للشريحة وحفظها كصورة PNG.

## **تقديم شريحة باستخدام قواعد الخطوط الاحتياطية**

المثال التالي يتضمن هذه الخطوات:

1. نقوم [بإنشاء مجموعة قواعد الخطوط الاحتياطية](/slides/ar/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/remove/) قاعدة خط احتياطية و[AddFallBackFonts()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) إلى قاعدة أخرى.
1. مرّر مجموعة القواعد إلى طريقة [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. باستخدام طريقة [Presentation::Save()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) يمكننا حفظ العرض بنفس الصيغة، أو حفظه بصيغة أخرى. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى FontsManager، تُطبق هذه القواعد خلال أي عمليات على العرض: الحفظ، والتقديم، والتحويل، إلخ.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// إنشاء نسخة جديدة من مجموعة القواعد
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// إنشاء عدد من القواعد
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
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

// تقديم صورة مصغرة باستخدام مجموعة القواعد المُهيأة وحفظها كـ PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
اقرأ المزيد حول كيفية [تحويل شرائح PowerPoint إلى PNG باستخدام C++](/slides/ar/cpp/convert-powerpoint-to-png/).
{{% /alert %}}