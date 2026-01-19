---
title: تكوين مجموعات الخطوط الاحتياطية في .NET
linktitle: مجموعة الخطوط الاحتياطية
type: docs
weight: 20
url: /ar/net/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطية
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لـ .NET للحفاظ على تناسق النص ووضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد النسخ الاحتياطي**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)، التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) في فئة [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). تقوم FontsManager بالتحكم في الخطوط عبر العرض التقديمي.

كل [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) لديها خاصية [FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) مع مثيل خاص بها من فئة FontsManager.

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


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد النسخ الاحتياطي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد النسخ الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق النسخ الاحتياطي على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الأحرف لأي نص داخل هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة الخطوط واستخدامها من جانبك وتتحمل المسؤولية بالكامل.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والنسخ الاحتياطي للأحرف المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخط ([replacement](/slides/ar/net/font-replacement/)/[substitution](/slides/ar/net/font-substitution/))، ثم يملأ النسخ الاحتياطي الفجوات للأحرف المفقودة في الخطوط المتوفرة.