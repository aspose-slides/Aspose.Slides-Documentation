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
description: "Настройте коллекцию резервных шрифтов в Aspose.Slides для Android через Java, чтобы текст в презентациях PowerPoint и OpenDocument был согласованным и чётким."
---
## **Обзор**

Aspose.Slides позволяет настроить набор правил резервных шрифтов для презентации. Каждое правило резервного шрифта представлено классом `FontFallBackRule` и может быть добавлено в `FontFallBackRulesCollection`, который реализует интерфейс `IFontFallBackRulesCollection`.

После создания коллекции её можно назначить свойству `FontFallBackRulesCollection` объекта `FontsManager` презентации. `FontsManager` управляет шрифтами во всей презентации, и каждый экземпляр `Presentation` имеет собственный `FontsManager`.

После того как `FontsManager` инициализирован коллекцией резервных шрифтов, указанные резервные шрифты применяются во время рендеринга презентации.

## **Применить правила резервных шрифтов**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRulesCollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации.

Каждый [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getFontsManager--) , который возвращает собственный экземпляр класса [FontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в [FontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getFontsManager--) определённой презентации:  

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 
Подробнее о том, как [Render Presentation with Fallback Font](/slides/ru/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Будут ли мои правила резервного шрифта внедрены в файл PPTX и видимы в PowerPoint после сохранения?

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

### Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

### Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?

Нет. Вы добавляете и используете шрифты самостоятельно и несёте за это полную ответственность.

### Можно ли использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов одновременно?

Да. Они являются независимыми этапами одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([замена](/slides/ru/androidjava/font-replacement/)/[подстановка](/slides/ru/androidjava/font-substitution/)), затем резервный шрифт заполняет пробелы для недостающих глифов в доступных шрифтах.