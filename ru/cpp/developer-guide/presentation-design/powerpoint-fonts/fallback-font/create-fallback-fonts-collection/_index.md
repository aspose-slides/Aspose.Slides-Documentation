---
title: Настройка коллекций резервных шрифтов в C++
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/cpp/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Настройте коллекцию резервных шрифтов в Aspose.Slides для C++, чтобы текст был согласованным и чётким в презентациях PowerPoint и OpenDocument."
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно передать методу [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) класса [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/). FontsManager управляет шрифтами во всей презентации.

У каждого [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) есть метод [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/), который возвращает собственный экземпляр класса FontsManager.

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её FontsManager определённой презентации:
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отображение презентации с резервным шрифтом](/slides/ru/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видимы в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно и несёте за это ответственность.

**Можно ли одновременно использовать замену/подстановку отсутствующих шрифтов и резервный шрифт для отсутствующих глифов?**

Да. Это независимые этапы одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/cpp/font-replacement/)/[substitution](/slides/ru/cpp/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.