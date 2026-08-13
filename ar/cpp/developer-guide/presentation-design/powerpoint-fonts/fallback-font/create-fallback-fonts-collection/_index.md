---
title: تكوين مجموعات خطوط الاحتياطي في C++
linktitle: مجموعة خطوط الاحتياطي
type: docs
weight: 20
url: /ar/cpp/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطية
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides للغة C++ لضمان تناسق النص وجودته في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

Aspose.Slides تتيح لك تكوين مجموعة من قواعد الخط الاحتياطي لعروض تقديمية. كل قاعدة احتياطية تمثلها الفئة `FontFallBackRule` ويمكن إضافتها إلى `FontFallBackRulesCollection` التي تُنفذ الواجهة `IFontFallBackRulesCollection`.

بعد إنشاء المجموعة، يمكنك تعيينها باستخدام طريقة `set_FontFallBackRulesCollection` الخاصة بـ `FontsManager` في العرض التقديمي. يتحكم `FontsManager` في الخطوط عبر العرض التقديمي، ولكل كائن `Presentation` نسخة خاصة به من `FontsManager`.

بمجرد أن يتم تهيئة `FontsManager` بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية المحددة أثناء عرض العرض التقديمي.

## **تطبيق قواعد الخط الاحتياطي**

يمكن تنظيم كائنات فئة[FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) في[FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrulescollection/) التي تُنفذ واجهة[IFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تمرير هذه المجموعة إلى طريقة[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) في فئة[FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل[Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) يحتوي على طريقة[get_FontsManager()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_fontsmanager/) مع نسخة خاصة به من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى FontsManager في عرض تقديمي معين:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

بعد أن يتم تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="info" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط احتياطي](/slides/ar/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

### هل سيتم تضمين قواعد الخط الاحتياطي في ملف PPTX وتكون مرئية في PowerPoint بعد الحفظ؟

لا. قواعد الخط الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

### هل ينطبق الخط الاحتياطي على النص داخل SmartArt وWordArt والمخططات والجداول؟

نعم. يُستخدم نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

### هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل مسؤوليتها.

### هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والاحتياطي للرموز المفقودة معًا؟

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/cpp/font-replacement/)/[substitution](/slides/ar/cpp/font-substitution/))، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.