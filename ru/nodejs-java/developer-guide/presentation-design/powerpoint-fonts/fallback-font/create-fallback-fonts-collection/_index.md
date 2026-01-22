---
title: Настройка коллекций резервных шрифтов в JavaScript
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/nodejs-java/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в JavaScript с помощью Aspose.Slides для Node.js, чтобы обеспечить согласованность и чёткость текста в презентациях PowerPoint и OpenDocument."
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection), который реализует класс [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации.

У каждого [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) есть метод [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) определённой презентации:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


После того как FontsManager инициализирован коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Render Presentation with Fallback Font](/slides/ru/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видимы в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно, принимая на себя ответственность.

**Можно ли одновременно использовать замену/подстановку отсутствующих шрифтов и резервный шрифт для отсутствующих глифов?**

Да. Это независимые стадии одного процесса разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/nodejs-java/font-replacement/)/[substitution](/slides/ru/nodejs-java/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.