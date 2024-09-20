---
title: Создание коллекции запасных шрифтов
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), который реализует [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection) интерфейс. Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно передать в метод [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)класса [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). FontsManager управляет шрифтами в презентации. Читать далее [О FontsManager и FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/).

Каждая [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)имеет метод [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)с собственным экземпляром класса FontsManager.

Вот пример того, как создать коллекцию правил запасных шрифтов и назначить её в FontsManager определённой презентации:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

После инициализации FontsManager запасной коллекцией шрифтов, запасные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Читать далее, как [Рендерить презентацию с запасным шрифтом](/slides/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}