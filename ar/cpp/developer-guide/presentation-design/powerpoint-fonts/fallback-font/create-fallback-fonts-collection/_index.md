---
title: تكوين مجموعات خطوط الرجوع الاحتياطي في C++
linktitle: مجموعة خطوط الرجوع الاحتياطي
type: docs
weight: 20
url: /ar/cpp/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطي
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- С++
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لـ C++ للحفاظ على تناسق النص ووضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الرجوع الاحتياطي**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) داخل [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) التي تنفذ الواجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تمرير هذه المجموعة إلى طريقة [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) في فئة [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) يحتوي على طريقة [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) مع نسخة خاصة من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الرجوع وتعيينها في FontsManager لعرض تقديمي معين:  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


بعد تهيئة FontsManager بمجموعة خطوط الرجوع، يتم تطبيق خطوط الرجوع أثناء عرض تقديم العرض.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط احتياطي](/slides/ar/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الرجوع في ملف PPTX وتظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الرجوع هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولا تظهر في واجهة PowerPoint.

**هل ينطبق الرجوع على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الأحرف لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط بنفسك وتكون مسؤولاً عنها.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والرجوع للأحرف المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/cpp/font-replacement/)/[substitution](/slides/ar/cpp/font-substitution/))، ثم يملأ الرجوع الفجوات للأحرف المفقودة في الخطوط المتاحة.