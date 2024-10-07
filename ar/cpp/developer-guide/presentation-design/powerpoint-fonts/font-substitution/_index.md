---
title: استبدال الخطوط
type: docs
weight: 70
url: /cpp/font-substitution/
keywords: "خط, استبدال الخط, عرض PowerPoint, C++, CPP, Aspose.Slides for C++"
description: "استبدال الخط في PowerPoint باستخدام C++"
---

يتيح لك Aspose.Slides تحديد قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط ما) بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. توليد صورة الشريحة لملاحظة التأثير.

يعرض هذا الكود بلغة C++ عملية استبدال الخط:

```c++
// المسار إلى دليل الوثائق.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل عرض تقديمي
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// تحديد الخط الذي سيتم استبداله والخط الجديد
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// إضافة قاعدة خط لاستبدال الخط
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// إضافة مجموعة قواعد الخطوط إلى قائمة القواعد
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

قد ترغب في مشاهدة [**استبدال الخط**](/slides/cpp/font-replacement/). 

{{% /alert %}}