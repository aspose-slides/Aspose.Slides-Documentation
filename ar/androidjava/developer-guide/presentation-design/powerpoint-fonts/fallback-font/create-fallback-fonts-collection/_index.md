---
title: "تكوين مجموعات الخطوط الاحتياطية على Android"
linktitle: "مجموعة الخطوط الاحتياطية"
type: docs
weight: 20
url: /ar/androidjava/create-fallback-fonts-collection/
keywords:
- "خط احتياطي"
- "قاعدة احتياطية"
- "مجموعة خطوط"
- "تكوين الخط"
- "إعداد الخط"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Android"
- "Java"
- "Aspose.Slides"
description: "قم بإعداد مجموعة خطوط احتياطية في Aspose.Slides لنظام Android عبر Java للحفاظ على النص متسقًا وواضحًا في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تكوين مجموعة من قواعد الخط الاحتياطي لعرض تقديمي. يتم تمثيل كل قاعدة احتياطية بواسطة الفئة `FontFallBackRule` ويمكن إضافتها إلى `FontFallBackRulesCollection`، والتي تنفّذ الواجهة `IFontFallBackRulesCollection`.

بعد إنشاء المجموعة، يمكنك تعيينها إلى خاصية `FontFallBackRulesCollection` في `FontsManager` الخاص بالعرض التقديمي. يتحكم `FontsManager` في الخطوط عبر العرض التقديمي، ولكل مثيل `Presentation` مدير خطوط خاص به (`FontsManager`).

بمجرد تهيئة `FontsManager` بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية المحددة أثناء عملية عرض التقديم.

## **تطبيق قواعد الاحتياطي**

يمكن تنظيم كائنات الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRulesCollection)‏، التي تنفّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IFontFallBackRulesCollection)‏. يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontsManager)‏. يتحكم `FontsManager` في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يمتلك طريقة [getFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getFontsManager--) مع مثيل خاص به من فئة [FontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontsManager)‏.

فيما يلي مثال لكيفية إنشاء مجموعة قواعد خطوط الاحتياطي وتعيينها في [FontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  

```java
import com.aspose.slides.*;

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

بعد تهيئة `FontsManager` بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض التقديم.

{{% alert color="info" %}} 
اقرأ المزيد حول كيفية [عرض تقديم مع خط احتياطي](/slides/ar/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل سيتم تضمين قواعد الاحتياطي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

### هل يتم تطبيق الاحتياطي على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

### هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية الكاملة.

### هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والاحتياطي للرموز المفقودة معًا؟

نعم. إنهما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توافر الخطوط ([replacement](/slides/ar/androidjava/font-replacement/)/[substitution](/slides/ar/androidjava/font-substitution/))، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.