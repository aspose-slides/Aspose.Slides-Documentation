---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /ar/androidjava/create-fallback-fonts-collection/
---

يمكن تنظيم نسخ من [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection)، التي تنفذ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) واجهة. من الممكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى طريقة [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) في [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) المصنف. يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/androidjava/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لديه طريقة [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) مع نسخته الخاصة من [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) المصنف.

إليك مثالاً عن كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  

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

بعد أن يتم تهيئة FontsManager مع مجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض العرض التقديمي بخط احتياطي](/slides/ar/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}