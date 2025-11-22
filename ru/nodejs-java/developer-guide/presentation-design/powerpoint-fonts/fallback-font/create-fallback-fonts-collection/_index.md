---
title: Создать коллекцию резервных шрифтов
type: docs
weight: 20
url: /ru/nodejs-java/create-fallback-fonts-collection/
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection), который реализует класс [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/nodejs-java/about-fontsmanager-and-fontsloader/).

Каждая [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) со своим собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) определённой презентации:  
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


После инициализации FontsManager коллекцией правил резервных шрифтов, резервные шрифты применяются при рендеринге презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отобразить презентацию с резервным шрифтом](/slides/ru/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видимы в PowerPoint после сохранения?**

Нет. Правила резервного шрифта — это параметры рендеринга во время выполнения; они не сериализуются в PPTX и не появятся в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Шрифты добавляются и используются вами, и вы несёте за это полную ответственность.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов?**

Да. Это независимые стадии одного и того же конвейера поиска шрифтов: сначала движок решает проблему доступности шрифтов ([replacement](/slides/ru/nodejs-java/font-replacement/)/[substitution](/slides/ru/nodejs-java/font-substitution/)), затем резервный шрифт заполняет пробелы недостающих глифов в доступных шрифтах.