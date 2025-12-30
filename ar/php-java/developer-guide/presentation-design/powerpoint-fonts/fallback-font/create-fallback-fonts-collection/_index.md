---
title: تهيئة مجموعات الخطوط الاحتياطية في PHP
linktitle: مجموعة الخطوط الاحتياطية
type: docs
weight: 20
url: /ar/php-java/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطية
- مجموعة خطوط
- تهيئة الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لـ PHP عبر Java للحفاظ على اتساق النص ووضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الاستبدال الاحتياطي**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن إسناد هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/php-java/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة من فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الاستبدال الاحتياطي وتعيينها داخل [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  
```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


بعد تهيئة FontsManager بمجموعة خطوط الاستبدال الاحتياطي، يتم تطبيق خطوط الاستبدال أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض العرض التقديمي بخط احتياطي](/slides/ar/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاستبدال الاحتياطي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الاستبدال الاحتياطي هي إعدادات تصيير وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاستبدال على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يُستخدم نفس آلية استبدال الحروف لأي نص في هذه العناصر.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط بنفسك وتتحمل مسؤوليتها.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والاستبدال الاحتياطي للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولاً يحل المحرك مسألة توفر الخطوط ([replacement](/slides/ar/php-java/font-replacement/)/[substitution](/slides/ar/php-java/font-substitution/))، ثم يملأ الاستبدال الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.