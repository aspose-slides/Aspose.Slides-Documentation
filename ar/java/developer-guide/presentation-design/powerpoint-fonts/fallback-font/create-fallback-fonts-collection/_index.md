---
title: تكوين مجموعات الخطوط الاحتياطية في Java
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
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لجافا للحفاظ على تناسق النص وحدته في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بتكوين مجموعة من قواعد الخط الاحتياطي للعرض التقديمي. كل قاعدة احتياطي تمثلها الفئة `FontFallBackRule` ويمكن إضافتها إلى `FontFallBackRulesCollection`، والتي تنفّذ الواجهة `IFontFallBackRulesCollection`.

بعد إنشاء المجموعة، يمكنك تعيينها إلى الخاصية `FontFallBackRulesCollection` في `FontsManager` للعرض التقديمي. يتحكم `FontsManager` في الخطوط عبر العرض التقديمي، ولكل مثال `Presentation` خاصيته الخاصة `FontsManager`.

بمجرد تهيئة `FontsManager` بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية المحددة أثناء عرض الرسم التقديمي.

## **تطبيق قواعد الاحتياطي**

يمكن تنظيم كائنات الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRulesCollection) التي تنفّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IFontFallBackRulesCollection). يمكن إضافة قواعد أو إزالتها من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) يحتوي على طريقة [getFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة من فئة [FontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsManager).

فيما يلي مثال حول كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في [FontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:

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

بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض الرسم التقديمي.

{{% alert color="info" %}} 
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل سيتم تضمين قواعد الاحتياطي في ملف PPTX وتظهر في PowerPoint بعد الحفظ؟

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

### هل ينطبق الاحتياطي على النص داخل SmartArt أو WordArt أو المخططات أو الجداول؟

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

### هل توزع Aspose أي خطوط مع المكتبة؟

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤولاً عنها.

### هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والاحتياطي للرموز المفقودة معاً؟

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/java/font-replacement/)/[substitution](/slides/ar/java/font-substitution/))، ثم يقوم الاحتياطي بملء الفجوات للرموز المفقودة في الخطوط المتاحة.