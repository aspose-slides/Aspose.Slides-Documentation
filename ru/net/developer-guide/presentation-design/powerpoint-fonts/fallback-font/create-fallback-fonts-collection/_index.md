---
title: Настройка коллекций резервных шрифтов в .NET
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/net/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для .NET, чтобы текст оставался согласованным и чётким в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

Aspose.Slides позволяет вам настроить набор правил резервных шрифтов для презентации. Каждое правило резервного шрифта представлено классом `FontFallBackRule` и может быть добавлено в `FontFallBackRulesCollection`, который реализует интерфейс `IFontFallBackRulesCollection`.

После создания коллекции вы можете назначить её свойству `FontFallBackRulesCollection` класса `FontsManager` презентации. `FontsManager` управляет шрифтами во всей презентации, и каждый экземпляр `Presentation` имеет собственный `FontsManager`.

После инициализации `FontsManager` коллекцией резервных шрифтов указанные резервные шрифты применяются при рендеринге презентации.

## **Применение правил резервных шрифтов**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/ru/net/aspose.slides/FontFallBackRule) можно организовать в [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/fontfallbackrulescollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontfallbackrulescollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить свойству [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) класса [FontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager). FontsManager управляет шрифтами во всей презентации.

Каждый [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) имеет свойство [FontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/properties/fontsmanager) со своей собственной instance класса FontsManager.

Ниже приведён пример создания коллекции правил резервных шрифтов и назначения её в FontsManager определённой презентации:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

После инициализации FontsManager коллекцией резервных шрифтов резервные шрифты применяются при рендеринге презентации.

{{% alert color="info" %}} 
Подробнее, как [Render Presentation with Fallback Font](/slides/ru/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Будут ли мои правила резервных шрифтов встроены в файл PPTX и видимы в PowerPoint после сохранения?

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

### Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?

Да. Для любого текста в этих объектах используется тот же механизм замены глифов.

### Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?

Нет. Шрифты добавляются и используются вами самостоятельно и на вашей ответственности.

### Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов?

Да. Они являются независимыми этапами одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/net/font-replacement/)/[substitution](/slides/ru/net/font-substitution/)), затем резервный шрифт заполняет пробелы для недостающих глифов в доступных шрифтах.