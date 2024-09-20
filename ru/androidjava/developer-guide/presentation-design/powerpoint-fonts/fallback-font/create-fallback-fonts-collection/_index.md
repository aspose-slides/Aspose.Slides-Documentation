---
title: Создание коллекции запасных шрифтов
type: docs
weight: 20
url: /androidjava/create-fallback-fonts-collection/
---

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection). В коллекцию можно добавлять или удалять правила.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). FontsManager управляет шрифтами в презентации. Читать подробнее [О FontsManager и FontsLoader](/slides/androidjava/about-fontsmanager-and-fontsloader/).

Каждая [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

Вот пример того, как создать коллекцию правил запасных шрифтов и назначить ее в [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) конкретной презентации:  

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

После инициализации FontsManager с коллекцией запасных шрифтов, запасные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Читать больше о том, как [Рендерить презентацию с запасным шрифтом](/slides/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}