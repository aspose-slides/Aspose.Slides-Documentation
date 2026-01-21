---
title: Настройка коллекций резервных шрифтов в Java
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/java/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте коллекцию резервных шрифтов в Aspose.Slides для Java, чтобы текст оставался согласованным и чётким в презентациях PowerPoint и OpenDocument."
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации.

Каждый [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) определённой презентации:  
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


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Render Presentation with Fallback Font](/slides/ru/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видимы в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм замены глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Шрифты добавляются и используются вами самостоятельно, на вашу ответственность.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов?**

Да. Это независимые этапы одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/java/font-replacement/)/[substitution](/slides/ru/java/font-substitution/)), затем резервный шрифт заполняет пробелы недостающих глифов в доступных шрифтах.