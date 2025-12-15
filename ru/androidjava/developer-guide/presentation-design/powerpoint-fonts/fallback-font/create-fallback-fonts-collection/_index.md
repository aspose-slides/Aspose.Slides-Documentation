---
title: Настройка коллекций запасных шрифтов на Android
linktitle: Коллекция запасных шрифтов
type: docs
weight: 20
url: /ru/androidjava/create-fallback-fonts-collection/
keywords:
- запасный шрифт
- правило запасного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Создайте коллекцию запасных шрифтов в Aspose.Slides для Android с помощью Java, чтобы текст был согласованным и чётким в презентациях PowerPoint и OpenDocument."
---

## **Применить правила запасных шрифтов**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) могут быть упорядочены в [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection), которая реализует [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) интерфейс. Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/androidjava/about-fontsmanager-and-fontsloader/).

У каждого [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) есть метод [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

Ниже приведён пример создания коллекции правил запасных шрифтов и назначения её в [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) определённой презентации:  
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


После инициализации FontsManager коллекцией запасных шрифтов, запасные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее как [Отобразить презентацию с запасным шрифтом](/slides/ru/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила запасных шрифтов встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила запасных шрифтов — это настройки рендеринга во время выполнения; они не сериализуются в PPTX и не появятся в пользовательском интерфейсе PowerPoint.

**Применяются ли запасные шрифты к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм замены глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно, полностью беря на себя ответственность.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и запасные шрифты для отсутствующих глифов?**

Да. Это независимые этапы единого конвейера разрешения шрифтов: сначала движок определяет наличие шрифта ([replacement](/slides/ru/androidjava/font-replacement/)/[substitution](/slides/ru/androidjava/font-substitution/)), затем запасные шрифты заполняют пробелы для недостающих глифов в доступных шрифтах.