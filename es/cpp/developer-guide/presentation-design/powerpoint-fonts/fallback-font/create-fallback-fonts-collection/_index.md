---
title: Configurar colecciones de fuentes de reserva en C++
linktitle: Colección de fuentes de reserva
type: docs
weight: 20
url: /es/cpp/create-fallback-fonts-collection/
keywords:
- fuente de reserva
- regla de reserva
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Configura una colección de fuentes de reserva en Aspose.Slides para C++ para mantener el texto coherente y nítido en presentaciones de PowerPoint y OpenDocument."
---

## **Aplicar reglas de reserva**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) pueden organizarse en [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/), que implementa la interfaz [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/). Es posible añadir o eliminar reglas de la colección.

Luego, esta colección puede pasarse al método [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) de la clase [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/). FontsManager controla las fuentes en toda la presentación.

Cada [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) tiene un método [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) con su propia instancia de la clase FontsManager.

Aquí hay un ejemplo de cómo crear una colección de reglas de fuentes de reserva y asignarla al FontsManager de una presentación determinada:  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


Una vez que FontsManager se inicializa con la colección de fuentes de reserva, las fuentes de reserva se aplican durante la renderización de la presentación.

{{% alert color="primary" %}} 
Obtenga más información sobre cómo [Renderizar presentación con fuente de reserva](/slides/es/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incrustarán mis reglas de reserva en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿Se aplica la reserva al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. Se utiliza el mismo mecanismo de sustitución de glifos para cualquier texto en estos objetos.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Usted añade y utiliza fuentes por su cuenta y bajo su propia responsabilidad.

**¿Se pueden combinar el reemplazo/sustitución de fuentes faltantes y la reserva de glifos faltantes?**

Sí. Son etapas independientes del mismo pipeline de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/cpp/font-replacement/)/[substitution](/slides/es/cpp/font-substitution/)), luego la reserva rellena los vacíos de glifos faltantes en las fuentes disponibles.