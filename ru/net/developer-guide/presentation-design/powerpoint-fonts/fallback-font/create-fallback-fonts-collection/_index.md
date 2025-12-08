---
title: Создание коллекции резервных шрифтов
type: docs
weight: 20
url: /ru/net/create-fallback-fonts-collection/
keywords: "Коллекция резервных шрифтов, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Коллекция резервных шрифтов в PowerPoint на C# или .NET"
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить свойству [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) класса [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). FontsManager контролирует шрифты во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/net/about-fontsmanager-and-fontsloader/).

Каждый [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) имеет свойство [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) со своей собственной копией класса FontsManager.

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в FontsManager определённой презентации:  
```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются при рендеринге презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отобразить презентацию с резервным шрифтом](/slides/ru/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для текста в этих объектах используется тот же механизм замены глифов.

**Поставляется ли с библиотекой какие‑либо шрифты от Aspose?**

Нет. Вы добавляете и используете шрифты самостоятельно, неся за это ответственность.

**Можно ли использовать замену/подстановку недостающих шрифтов и резервный шрифт для отсутствующих глифов одновременно?**

Да. Это независимые этапы одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/net/font-replacement/)/[substitution](/slides/ru/net/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.