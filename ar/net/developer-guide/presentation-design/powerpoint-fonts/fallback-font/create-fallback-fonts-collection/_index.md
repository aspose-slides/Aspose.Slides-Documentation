---
title: تكوين مجموعات خطوط الرجوع في .NET
linktitle: مجموعة خطوط الرجوع
type: docs
weight: 20
url: /ar/net/create-fallback-fonts-collection/
keywords:
- خط رجوع
- قاعدة رجوع
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إعداد مجموعة خطوط الرجوع في Aspose.Slides لـ .NET للحفاظ على تناسق النص ووضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الرجوع**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) التي تنفِّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). يمكن إضافة القواعد أو إزالتها من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) في فئة [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/net/about-fontsmanager-and-fontsloader/).

لكل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) خاصية [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) تحتوي على نسخة خاصة من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في FontsManager لعرض تقديمي معين:
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض الشرائح.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط احتياطي](/slides/ar/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الرجوع الخاصة بي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الرجوع هي إعدادات عرض وقت التشغيل؛ لا يتم تسلسلها إلى PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الرجوع على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استعمال نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط بنفسك وتتحمل مسؤوليتها.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والرجوع للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولًا يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/net/font-replacement/)/[substitution](/slides/ar/net/font-substitution/))، ثم يُملأ الرجوع الفجوات للرموز المفقودة في الخطوط المتاحة.