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
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لـ PHP عبر Java لضمان ثبات النص ووضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الفولباك**

يمكن تنظيم مثيلات فئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) مع مثيل خاص به من فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الفولباك وتعيينها في [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) لعرض تقديمي معين:  
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


بعد تهيئة FontsManager بمجموعة خطوط الفولباك، تُطبق خطوط الفولباك أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط الفولباك](/slides/ar/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الفولباك في ملف PPTX وتكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الفولباك هي إعدادات عرض وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الفولباك على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص في هذه العناصر.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. أنت تضيف وتستخدم الخطوط على جانبك وتتحمل المسؤولية كاملة.

**هل يمكن استخدام الاستبدال/الاستعاضة عن الخطوط المفقودة والفولباك للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بتحديد توفر الخطوط ([الاستبدال](/slides/ar/php-java/font-replacement/)/[الاستعاضة](/slides/ar/php-java/font-substitution/))، ثم يملأ الفولباك الفجوات للرموز المفقودة في الخطوط المتاحة.