---
title: تكوين استبدال الخط في العروض التقديمية باستخدام С++
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/cpp/font-substitution/
keywords:
- خط
- استبدال الخط
- استبدال الخطوط
- استبدال الخط
- استبدال الخطوط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- С++
- Aspose.Slides
description: "تمكين استبدال الخط المثالي في Aspose.Slides للـ С++ عند تحويل عروض PowerPoint و OpenDocument إلى صيغ ملفات أخرى."
---

## **قواعد استبدال الخطوط**

Aspose.Slides يتيح لك تعيين قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. حمّل العرض التقديمي المناسب.
2. حمّل الخط الذي سيتم استبداله.
3. حمّل الخط الجديد.
4. أضف قاعدة للاستبدال.
5. أضف القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض.
6. أنشئ صورة الشريحة لملاحظة النتيجة.

هذا الكود C++ يوضح عملية استبدال الخطوط:
```c++
// مسار دليل المستندات.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// يقوم بتحميل عرض تقديمي
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// يحدد الخط الذي سيُستبدَل والخط الجديد
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
	// يضيف قاعدة خط لاستبدال الخط
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// يضيف القاعدة إلى مجموعة قواعد استبدال الخطوط
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// يضيف مجموعة قواعد الخط إلى قائمة القواعد
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// يحفظ ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 
قد ترغب في مشاهدة [**استبدال الخط**](/slides/ar/cpp/font-replacement/). 
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[الاستبدال](/slides/ar/cpp/font-replacement/) هو فرض استبدال خط بآخر عبر كامل العرض التقديمي. الاستبدال (substitution) هو قاعدة تُفعَّل تحت شرط معين، مثل عدم توفر الخط الأصلي، ثم يُستخدم خط بديل محدد.

**متى تُطبق قواعد الاستبدال بالضبط؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/cpp/font-selection-sequence/) القياسي الذي يُقيَّم أثناء التحميل، والتصيير، والتحويل؛ إذا كان الخط المختار غير متوفر، يُطبق الاستبدال أو الاستبدال (substitution).

**ما السلوك الافتراضي إذا لم يتم تكوين استبدال ولا استبدال (substitution) وكان الخط مفقوداً على النظام؟**

المكتبة ستحاول اختيار أقرب خط نظام متاح، كما تفعل PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة أثناء التشغيل لتجنب الاستبدال؟**

نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/cpp/custom-font/) أثناء التشغيل حتى تعتبرها المكتبة للاختيار والتصيير، بما في ذلك عمليات التحويل اللاحقة.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. Aspose لا توزع خطوطاً مدفوعة أو مجانية؛ أنت تضيف وتستخدم الخطوط على مسؤوليتك الخاصة.

**هل هناك اختلافات في سلوك الاستبدال بين Windows وLinux وmacOS؟**

نعم. يبدأ اكتشاف الخطوط من أدلة الخطوط في نظام التشغيل. مجموعة الخطوط المتاحة افتراضياً ومسارات البحث تختلف بين الأنظمة، مما يؤثر على التوافر والحاجة إلى الاستبدال.

**كيف أُعد البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الدفعة؟**

قُم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/cpp/custom-font/) المطلوبة للمستندات الناتجة، و[دمج الخطوط](/slides/ar/cpp/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا حتى تكون الخطوط المختارة متاحة أثناء التصيير.