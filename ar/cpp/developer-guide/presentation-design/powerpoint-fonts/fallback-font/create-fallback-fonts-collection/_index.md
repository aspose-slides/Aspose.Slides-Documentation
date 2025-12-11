---
title: تكوين مجموعات خطوط الاحتياط في C++
linktitle: مجموعة خطوط الاحتياط
type: docs
weight: 20
url: /ar/cpp/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياط
- مجموعة خطوط
- تهيئة الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- С++
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides للـ C++ لضمان ثبات النص وضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الاحتياط**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)، التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تمرير هذه المجموعة إلى طريقة [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) في فئة [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). يتحكم FontsManager في الخطوط عبر العرض. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/cpp/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لديها طريقة [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a) مع مثيل خاص بها من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الاحتياط وتعيينها في FontsManager لعرض معين:  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


بعد تهيئة FontsManager بمجموعة خطوط الاحتياط، تُطبق خطوط الاحتياط أثناء عرض الشرائح.

{{% alert color="primary" %}} 
اقرأ المزيد حول [Render Presentation with Fallback Font](/slides/ar/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاحتياط الخاصة بي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياط هي إعدادات عرض أثناء التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاحتياط على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤولاً عنها.

**هل يمكن استخدام الاستبدال/التعويض عن الخطوط المفقودة والاحتياط عن الحروف المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توافر الخطوط ([replacement](/slides/ar/cpp/font-replacement/)/[substitution](/slides/ar/cpp/font-substitution/))، ثم يملأ الاحتياط الفجوات للرموز المفقودة في الخطوط المتاحة.