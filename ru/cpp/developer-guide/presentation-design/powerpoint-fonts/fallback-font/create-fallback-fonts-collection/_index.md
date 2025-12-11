---
title: Настройка коллекций резервных шрифтов в С++
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
- С++
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для С++, чтобы текст в презентациях PowerPoint и OpenDocument оставался согласованным и чётким."
---

## **Применить правила резервных шрифтов**

Экземпляры [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) класса могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), который реализует [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection) интерфейс. Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно передать в метод [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) класса [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). FontsManager контролирует шрифты во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/cpp/about-fontsmanager-and-fontsloader/).

Каждый [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) имеет метод [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a) с собственным экземпляром класса FontsManager.

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в FontsManager определённой презентации:   ``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробности о том, как [Визуализировать презентацию с резервным шрифтом](/slides/ru/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли мои правила резервных шрифтов внедрены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не появятся в интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Тот же механизм замены глифов используется для любого текста в этих объектах.

**Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно и несёте за это ответственность.

**Можно ли одновременно использовать замену/подстановку недоступных шрифтов и резервный шрифт для недостающих глифов?**

Да. Это независимые стадии одного конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/cpp/font-replacement/)/[substitution](/slides/ru/cpp/font-substitution/)), затем резервный шрифт заполняет пробелы недостающих глифов в доступных шрифтах.