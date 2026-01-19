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
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для .NET, чтобы обеспечить согласованность и чёткость текста в презентациях PowerPoint и OpenDocument."
---

## **Применение правил резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), реализующий интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить свойству [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) класса [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). FontsManager управляет шрифтами во всей презентации.

Каждая [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) имеет свойство [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) со своим собственным экземпляром класса FontsManager.

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её FontsManager конкретной презентации:  
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отобразить презентацию с резервным шрифтом](/slides/ru/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Вопросы и ответы**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервного шрифта — это настройки рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм замены глифов.

**Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?**

Нет. Шрифты вы добавляете и используете самостоятельно, неся за это ответственность.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для отсутствующих глифов?**

Да. Это независимые этапы единого конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/net/font-replacement/)/[substitution](/slides/ru/net/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.