---
title: تكوين مجموعات خطوط التعويض على Android
linktitle: مجموعة خطوط التعويض
type: docs
weight: 20
url: /ar/androidjava/create-fallback-fonts-collection/
keywords:
- خط تعويض
- قاعدة تعويض
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "إعداد مجموعة خطوط تعويض في Aspose.Slides لنظام Android عبر Java للحفاظ على اتساق النص ووضوحه في عروض PowerPoint وOpenDocument."
---

## **تطبيق قواعد التعويض**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) التي تُطبق [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) كمجموعة. يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [About FontsManager and FontsLoader](/slides/ar/androidjava/about-fontsmanager-and-fontsloader/).

لكل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) طريقة [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) مع نسخة خاصة من فئة [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

فيما يلي مثال على إنشاء مجموعة قواعد خطوط التعويض وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  
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


بعد تهيئة FontsManager بمجموعة خطوط التعويض، تُطبَّق خطوط التعويض أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول [Render Presentation with Fallback Font](/slides/ar/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد التعويض في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد التعويض هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل يتطبق التعويض على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. تُستخدم نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط بنفسك وتكون مسؤوليتك بالكامل.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والتعويض عن الرموز الغائبة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يُحلّ المحرك توفر الخط ([replacement](/slides/ar/androidjava/font-replacement/)/[substitution](/slides/ar/androidjava/font-substitution/))، ثم يملأ التعويض الفجوات للرموز الغائبة في الخطوط المتوفرة.