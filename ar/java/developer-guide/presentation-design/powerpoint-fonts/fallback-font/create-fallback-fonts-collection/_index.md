---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /java/create-fallback-fonts-collection/
---

يمكن تنظيم مثيلات [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) التي تنفذ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) واجهة. من الممكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) طريقة من [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) الفئة. يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/java/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لديها طريقة [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) مع مثيل خاص بها من [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) الفئة.

فيما يلي أمثلة حول كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) لعرض تقديمي معين:  

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

بعد تهيئة FontsManager مع مجموعة خطوط احتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض العرض التقديمي بخط احتياطي](/slides/java/render-presentation-with-fallback-font/).
{{% /alert %}}