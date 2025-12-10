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
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для Java, чтобы обеспечить согласованность и чёткость текста в презентациях PowerPoint и OpenDocument."
---

## **Применение правил резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) можно организовать в [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), которая реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection). Можно добавлять и удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/java/about-fontsmanager-and-fontsloader/).

Каждый [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) со своим собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) определённой презентации:  
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


После того как FontsManager инициализирован коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отрисовать презентацию с резервным шрифтом](/slides/ru/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервного шрифта — это настройки рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту в SmartArt, WordArt, диаграммах и таблицах?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?**

Нет. Шрифты добавляете и используете вы, полностью отвечая за них.

**Можно ли использовать замену/подстановку отсутствующих шрифтов и резервный шрифт для отсутствующих глифов одновременно?**

Да. Это независимые этапы одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/java/font-replacement/)/[substitution](/slides/ru/java/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.