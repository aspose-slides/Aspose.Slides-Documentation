---
title: "إنشاء مجموعة خطوط بديلة"
type: docs
weight: 20
url: /ar/net/create-fallback-fonts-collection/
keywords: "مجموعة خطوط بديلة، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "مجموعة خطوط بديلة في PowerPoint باستخدام C# أو .NET"
---

## **تطبيق قواعد البديل**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). يمكن إضافة القواعد أو إزالتها من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى الخاصية [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) في فئة [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد حول [About FontsManager and FontsLoader](/slides/ar/net/about-fontsmanager-and-fontsloader/).

يحتوي كل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) على خاصية [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) مع نسخة خاصة من فئة FontsManager.

فيما يلي مثال لإنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى FontsManager في عرض تقديمي معين:  
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، تُطبق الخطوط الاحتياطية أثناء عرض تقديم العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاحتياطي الخاصة بي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياطي هي إعدادات عرض وقت التشغيل؛ لا تُسجل في ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاحتياطي على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية.

**هل يمكن استخدام استبدال/استبدال الخطوط المفقودة والبديل للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً تقوم المحرك بحل توفر الخط (الاستبدال/الاستبدال)، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.