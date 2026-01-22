---
title: Настройка коллекций резервных шрифтов на Android
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/androidjava/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для Android через Java, чтобы обеспечить согласованность и четкость текста в презентациях PowerPoint и OpenDocument."
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) можно организовать в [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Можно добавлять и удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации.

У каждого объекта [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) есть метод [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её объекту [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) определённой презентации:  
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
Узнайте подробнее, как [Отображение презентации с резервным шрифтом](/slides/ru/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Does Aspose distribute any fonts with the library?**

Нет. Шрифты добавляются и используются вами, и это ваша ответственность.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Да. Они являются независимыми этапами одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([замена](/slides/ru/androidjava/font-replacement/)/[подстановка](/slides/ru/androidjava/font-substitution/)), затем резервный шрифт заполняет пробелы для недостающих глифов в доступных шрифтах.