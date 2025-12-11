---
title: Configurar colecciones de fuentes de respaldo en С++
linktitle: Colección de fuentes de respaldo
type: docs
weight: 20
url: /es/cpp/create-fallback-fonts-collection/
keywords:
- fuente de respaldo
- regla de respaldo
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- С++
- Aspose.Slides
description: "Configure una colección de fuentes de respaldo en Aspose.Slides para С++ para mantener el texto coherente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de respaldo**

Instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection). Es posible añadir o eliminar reglas de la colección.

Luego esta colección puede pasarse al método [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) de la clase [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager). FontsManager controla las fuentes en toda la presentación. Lea más [Acerca de FontsManager y FontsLoader](/slides/es/cpp/about-fontsmanager-and-fontsloader/).

Cada [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) tiene un método [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a) con su propia instancia de la clase FontsManager.

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de respaldo y asignarla al FontsManager de una presentación determinada:  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


Después de que FontsManager se inicializa con la colección de fuentes de respaldo, las fuentes de respaldo se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Lea más sobre cómo [Renderizar presentación con fuente de respaldo](/slides/es/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de respaldo en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de respaldo son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿El respaldo se aplica al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Usted agrega y usa fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden usar juntos la sustitución/reemplazo de fuentes faltantes y el respaldo para glifos faltantes?**

Sí. Son etapas independientes del mismo pipeline de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/cpp/font-replacement/)/[substitution](/slides/es/cpp/font-substitution/)), luego el respaldo llena los vacíos de glifos faltantes en las fuentes disponibles.