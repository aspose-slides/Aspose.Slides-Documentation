---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /ar/nodejs-java/create-fallback-fonts-collection/
---

## **تطبيق قواعد التحويل الاحتياطي**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) في مجموعة [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection)، التي تُنفّذ فئة [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/nodejs-java/about-fontsmanager-and-fontsloader/).

لكل [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) طريقة [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة من فئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  
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


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط احتياطي](/slides/ar/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتداولة**

**هل سيتم دمج قواعد التحويل الاحتياطي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد التحويل الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق التحويل الاحتياطي على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية كاملة.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والتحويل الاحتياطي للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/nodejs-java/font-replacement/)/[substitution](/slides/ar/nodejs-java/font-substitution/))، ثم يقوم التحويل الاحتياطي بملء الفجوات للرموز المفقودة في الخطوط المتاحة.