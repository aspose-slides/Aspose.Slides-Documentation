---
title: "تكوين مجموعات الخطوط البديلة في C++"
linktitle: "مجموعة الخطوط البديلة"
type: docs
weight: 20
url: /ar/cpp/create-fallback-fonts-collection/
keywords:
- "خط بديل"
- "قاعدة بديلة"
- "مجموعة خطوط"
- "تكوين الخط"
- "إعداد الخط"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "قم بإعداد مجموعة خطوط بديلة في Aspose.Slides للغة C++ لضمان تناسق النص ووضوحه في عروض PowerPoint و OpenDocument التقديمية."
---
## **نظرة عامة**

يتيح لك Aspose.Slides تكوين مجموعة من قواعد الخطوط البديلة لعرض تقديمي. كل قاعدة بديلة يتم تمثيلها بواسطة الفئة `FontFallBackRule` ويمكن إضافتها إلى `FontFallBackRulesCollection`، التي تنفّذ الواجهة `IFontFallBackRulesCollection`.

بعد إنشاء المجموعة، يمكنك تعيينها باستخدام الطريقة `set_FontFallBackRulesCollection` لكائن `FontsManager` الخاص بالعرض التقديمي. يتحكم `FontsManager` في الخطوط عبر العرض التقديمي، ولكل كائن `Presentation` مثيله الخاص من `FontsManager`.

بمجرد تهيئة `FontsManager` بمجموعة الخطوط البديلة، يتم تطبيق الخطوط البديلة المحددة أثناء عرض تقديمي.

## **تطبيق قواعد الخطوط البديلة**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrulescollection/)، التي تنفّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تمرير هذه المجموعة إلى الطريقة [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) في الفئة [FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) يحتوي على طريقة [get_FontsManager()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_fontsmanager/) مع مثيلها الخاص من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط البديلة وتعيينها في FontsManager لعرض تقديمي معين:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

بعد تهيئة FontsManager بمجموعة الخطوط البديلة، يتم تطبيق الخطوط البديلة أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط بديل](/slides/ar/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد الخطوط البديلة في ملف PPTX وتكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الخطوط البديلة هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل يتم تطبيق الخطوط البديلة على النص داخل SmartArt، WordArt، الرسوم البيانية، والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص موجود في هذه العناصر.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤوليتك الكاملة.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والبديل للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط معالجة حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/cpp/font-replacement/)/[substitution](/slides/ar/cpp/font-substitution/))، ثم يملأ البديل الفجوات للرموز المفقودة في الخطوط المتاحة.