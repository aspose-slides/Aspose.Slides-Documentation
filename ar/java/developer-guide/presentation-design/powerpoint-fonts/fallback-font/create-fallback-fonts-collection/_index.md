---
title: تكوين مجموعات خطوط الاحتياطي في Java
linktitle: مجموعة خطوط الاحتياطي
type: docs
weight: 20
url: /ar/java/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطي
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لجهة Java للحفاظ على النص متسقًا وواضحًا في عروض PowerPoint وOpenDocument."
---

## **تطبيق قواعد الاحتياطي**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) التي تُنفّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). يمكن إضافة أو إزالة القواعد من المجموعة.

يمكن بعد ذلك تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد حول [عن FontsManager و FontsLoader](/slides/ar/java/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة به من فئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الاحتياطي وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  
```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```


بعد تهيئة FontsManager بمجموعة خطوط الاحتياطي، تُطبَّق خطوط الاحتياطي أثناء معالجة العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط احتياطي](/slides/ar/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم دمج قواعد الاحتياطي الخاصة بي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل يُطبق الاحتياطي على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال القوالب لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية الكاملة.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والاحتياطي للقوالب (glyphs) المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/java/font-replacement/)/[substitution](/slides/ar/java/font-substitution/))، ثم يملء الاحتياطي الفجوات للقوالب المفقودة في الخطوط المتوفرة.