---
title: تكوين مجموعات خطوط الاحتياطي في .NET
linktitle: مجموعة خطوط الاحتياطي
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
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لـ .NET لجعل النص متسقًا وواضحًا في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تكوين مجموعة من قواعد الخطوط الاحتياطية للعروض التقديمية. يتم تمثيل كل قاعدة احتياطية بالفئة `FontFallBackRule` ويمكن إضافتها إلى `FontFallBackRulesCollection`، التي تنفذ الواجهة `IFontFallBackRulesCollection`.

بعد إنشاء المجموعة، يمكنك تعيينها إلى الخاصية `FontFallBackRulesCollection` في `FontsManager` الخاص بالعرض التقديمي. يتحكم `FontsManager` في الخطوط عبر العرض التقديمي، ولكل كائن `Presentation` مثاله الخاص من `FontsManager`.

بمجرد أن يتم تهيئة `FontsManager` بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية المحددة أثناء عرض العرض التقديمي.

## **تطبيق قواعد الاحتياطي**

يمكن تنظيم مثيلات الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/net/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/fontfallbackrulescollection)‏، التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontfallbackrulescollection)‏. يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection ](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) في فئة [FontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager)‏. يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)‏ يمتلك خاصية [FontsManager ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/properties/fontsmanager)‏ تحتوي على مثيلها الخاص من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في FontsManager لعرض تقديمي معين:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="info" %}} 
اقرأ المزيد حول كيفية [عرض العرض التقديمي بخط احتياطي](/slides/ar/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

### هل سيتم تضمين قواعد الاحتياطي في ملف PPTX وتظهر في PowerPoint بعد الحفظ؟

لا. قواعد الاحتياطي هي إعدادات عرض أثناء وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

### هل يتم تطبيق الاحتياطي على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

### هل توزع Aspose أي خطوط مع المكتبة؟

لا. أنت تضيف وتستخدم الخطوط على جانبك وتكون مسؤولاً عنها.

### هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والاحتياطي للرموز المفقودة معاً؟

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخط عبر [replacement](/slides/ar/net/font-replacement/)/[substitution](/slides/ar/net/font-substitution/)، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.