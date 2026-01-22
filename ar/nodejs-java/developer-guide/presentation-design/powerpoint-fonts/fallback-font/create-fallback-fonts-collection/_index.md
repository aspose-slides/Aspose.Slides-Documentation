---
title: تكوين مجموعات الخطوط الاحتياطية في JavaScript
linktitle: مجموعة الخطوط الاحتياطية
type: docs
weight: 20
url: /ar/nodejs-java/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قواعد الاحتياطي
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بإعداد مجموعة خطوط احتياطية في JavaScript باستخدام Aspose.Slides لـ Node.js لضمان تماسك النص وحدة وضوحه في العروض التقديمية على PowerPoint وOpenDocument."
---

## **تطبيق قواعد الاحتياط**

يمكن تنظيم مثيلات فئة [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) ، التي تنفذ فئة [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) . يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن إسناد هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) . يدير FontsManager الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة به من فئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) لعروض تقديمية معينة:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، تُطبق الخطوط الاحتياطية أثناء عرض الشرائح.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض الشرائح مع الخط الاحتياطي](/slides/ar/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد الاحتياطي الخاصة بي في ملف PPTX وتكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التنفيذ؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاحتياطي على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص داخل هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط بنفسك وتتحمل المسؤولية.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والاحتياطي للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توافر الخطوط ([replacement](/slides/ar/nodejs-java/font-replacement/)/[substitution](/slides/ar/nodejs-java/font-substitution/))، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.