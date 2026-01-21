---
title: تكوين مجموعات خطوط الفولباك في Java
linktitle: مجموعة خطوط الفولباك
type: docs
weight: 20
url: /ar/java/create-fallback-fonts-collection/
keywords:
- خط الفولباك
- قاعدة الفولباك
- مجموعة الخطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إعداد مجموعة خطوط الفولباك في Aspose.Slides للـ Java لضمان تماسك النص ووضوحه في العروض التقديمية PowerPoint وOpenDocument."
---

## **تطبيق قواعد الفولباك**

يمكن تنظيم كائنات من فئة [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) التي تُنفّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection] لفئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) التي تُعيد نسخة خاصة من فئة [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الفولباك وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  
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


بعد تهيئة FontsManager بمجموعة خطوط الفولباك، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد الفولباك في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الفولباك هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل يتم تطبيق الفولباك على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص داخل هذه العناصر.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية بالكامل.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والفولباك للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توافر الخطوط ([replacement](/slides/ar/java/font-replacement/)/[substitution](/slides/ar/java/font-substitution/))، ثم يملأ الفولباك الفجوات للرموز المفقودة في الخطوط المتاحة.