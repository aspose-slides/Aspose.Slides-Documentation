---
title: تكوين مجموعات الخطوط الاحتياطية في PHP
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
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لـ PHP عبر Java للحفاظ على النص متسقًا وواضحًا في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد التعويض**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) في مجموعة [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). يمكن إضافة القواعد أو إزالتها من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/php-java/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) مع نسخة خاصة به من فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط التعويض وتعيينها في [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) لعرض تقديمي معين:  
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


بعد أن يتم تهيئة FontsManager بمجموعة خطوط التعويض، تُطبق خطوط التعويض أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض التقديم مع الخط الاحتياطي](/slides/ar/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد التعويض الخاصة بي في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد التعويض هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل يطبق التعويض على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية الكاملة.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة وتعويض الحروف المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/php-java/font-replacement/)/[substitution](/slides/ar/php-java/font-substitution/))، ثم يملأ التعويض الفجوات للحروف المفقودة في الخطوط المتاحة.