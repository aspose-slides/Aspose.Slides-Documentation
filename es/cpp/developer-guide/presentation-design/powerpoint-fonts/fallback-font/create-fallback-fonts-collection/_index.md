---
title: Crear Colección de Fuentes de Respaldo
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

Las instancias de [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) pueden ser organizadas en [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection). Es posible añadir o eliminar reglas de la colección.

Luego, esta colección puede ser pasada al método [set_FontFallBackRulesCollection() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)de la clase [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). FontsManager controla las fuentes a través de la presentación. Lee más [Sobre FontsManager y FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/).

Cada [Presentation ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)tiene un método [get_FontsManager() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)con su propia instancia de la clase FontsManager.

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de respaldo y asignarla al FontsManager de una presentación determinada:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Después de que FontsManager se inicializa con la colección de fuentes de respaldo, las fuentes de respaldo se aplican durante la representación de la presentación.

{{% alert color="primary" %}} 
Lee más sobre cómo [Renderizar Presentación con Fuente de Respaldo](/slides/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}