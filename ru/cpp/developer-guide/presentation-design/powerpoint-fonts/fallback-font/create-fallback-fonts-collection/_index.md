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
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для C++, чтобы обеспечить согласованность и чёткость текста в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

Aspose.Slides позволяет настроить коллекцию правил резервных шрифтов для презентации. Каждое правило резервного шрифта представлено классом `FontFallBackRule` и может быть добавлено в `FontFallBackRulesCollection`, который реализует интерфейс `IFontFallBackRulesCollection`.

После создания коллекции её можно назначить с помощью метода `set_FontFallBackRulesCollection` менеджера шрифтов `FontsManager` презентации. `FontsManager` управляет шрифтами во всей презентации, и каждый экземпляр `Presentation` имеет свой собственный `FontsManager`.

После того как `FontsManager` инициализирован коллекцией резервных шрифтов, указанные резервные шрифты применяются во время рендеринга презентации.

## **Применить правила резервных шрифтов**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrule/) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontfallbackrulescollection/), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontfallbackrulescollection/). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно передать в метод [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) класса [FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/). `FontsManager` управляет шрифтами во всей презентации.

Каждый объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) имеет метод [get_FontsManager()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_fontsmanager/), возвращающий собственный экземпляр класса `FontsManager`.

Ниже приведён пример, как создать коллекцию правил резервных шрифтов и назначить её в `FontsManager` определённой презентации:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

После того как `FontsManager` инициализирован коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="info" %}} 
Узнайте больше, как [Отрисовка презентации с резервным шрифтом](/slides/ru/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Будут ли мои правила резервных шрифтов встроены в файл PPTX и видимы в PowerPoint после сохранения?

Нет. Правила резервного шрифта — это настройки рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

### Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

### Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?

Нет. Шрифты вы добавляете и используете самостоятельно, беря на себя всю ответственность.

### Можно ли одновременно использовать замену/подстановку отсутствующих шрифтов и резервный шрифт для отсутствующих глифов?

Да. Они являются независимыми этапами одного и того же конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([замена](/slides/ru/cpp/font-replacement/)/[подстановка](/slides/ru/cpp/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.