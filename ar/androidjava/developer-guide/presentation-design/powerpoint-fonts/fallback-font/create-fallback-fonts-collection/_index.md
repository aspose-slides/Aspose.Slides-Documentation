---
title: تكوين مجموعات خطوط الاحتياطي على Android
linktitle: مجموعة خطوط الاحتياطي
type: docs
weight: 20
url: /ar/androidjava/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطي
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لنظام Android عبر Java للحفاظ على تناسق النص وجعله واضحًا وحادًا في عروض PowerPoint وOpenDocument."
---

## **تطبيق قواعد الاحتياط**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة من فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) لعروض تقديمية معينة:  
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


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض الشرائح.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض العرض التقديمي بخط احتياطي](/slides/ar/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاحتياط في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياط هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاحتياط على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤولاً عنها.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والاحتياط للرموز المفقودة معًا؟**

نعم. إنها مراحل مستقلة من نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/androidjava/font-replacement/)/[substitution](/slides/ar/androidjava/font-substitution/))، ثم يملأ الاحتياط الفجوات للرموز المفقودة في الخطوط المتاحة.