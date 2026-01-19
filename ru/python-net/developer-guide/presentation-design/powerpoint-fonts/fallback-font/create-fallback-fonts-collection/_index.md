---
title: Настройка коллекций резервных шрифтов в Python
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/python-net/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте коллекцию резервных шрифтов в Aspose.Slides для Python через .NET, чтобы текст в презентациях PowerPoint и OpenDocument оставался согласованным и четким."
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить свойству [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) класса [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager управляет шрифтами во всей презентации.

Каждая [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) имеет свойство [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), содержащее собственный экземпляр класса FontsManager.

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в FontsManager определённой презентации:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Узнайте больше о том, как [Отобразить презентацию с резервным шрифтом](/slides/ru/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и отображаться в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?**

Нет. Шрифты добавляются и используются вами самостоятельно, на вашу ответственность.

**Можно ли использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов одновременно?**

Да. Это независимые этапы одного конвейера определения шрифтов: сначала движок определяет наличие шрифтов ([replacement](/slides/ru/python-net/font-replacement/)/[substitution](/slides/ru/python-net/font-substitution/)), затем резервный шрифт заполняет пробелы для недостающих глифов в доступных шрифтах.