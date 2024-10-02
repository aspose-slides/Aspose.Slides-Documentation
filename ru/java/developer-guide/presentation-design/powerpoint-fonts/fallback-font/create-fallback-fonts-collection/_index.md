---
title: Создание коллекции резервных шрифтов
type: docs
weight: 20
url: /ru/java/create-fallback-fonts-collection/
---

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). Возможно добавлять или удалять правила из коллекции.

Затем эта коллекция может быть назначена методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). FontsManager управляет шрифтами в презентации. Читать далее [О FontsManager и FontsLoader](/slides/ru/java/about-fontsmanager-and-fontsloader/).

Каждая [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--), который содержит свои собственные экземпляры класса [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

Вот пример как создать коллекцию правил резервных шрифтов и назначить её в [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) определенной презентации:

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

После инициализации FontsManager с коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Читать далее о том, как [Рендерить презентацию с резервным шрифтом](/slides/ru/java/render-presentation-with-fallback-font/).
{{% /alert %}}