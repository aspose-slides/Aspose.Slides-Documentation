---
title: Especificar fuentes de reserva para presentaciones en C++
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/cpp/create-fallback-font/
keywords:
- fuente de reserva
- regla de reserva
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo perdido
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domine Aspose.Slides para C++ para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto constante en cualquier dispositivo o sistema operativo."
---
## **Resumen**

Aspose.Slides permite especificar fuentes de reserva para la representación y exportación de presentaciones. Las fuentes de reserva se utilizan cuando la fuente primaria no contiene glifos para caracteres concretos.

El comportamiento de reserva se configura mediante reglas de reserva. Cada regla asocia un rango Unicode con una o más fuentes que pueden contener los glifos necesarios. Puede definir reglas para diferentes rangos de caracteres, añadir o eliminar fuentes de reserva de reglas existentes y organizar varias reglas en una colección de reglas de fuentes de reserva.

Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución. No modifican el archivo de la presentación y no se almacenan dentro del archivo PPTX.

## **Reglas de Reserva**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontfallbackrule/) y la clase [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) representa una asociación entre el rango Unicode especificado, usado para buscar glifos perdidos, y una lista de fuentes que pueden contener los glifos adecuados:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Usando varias formas puedes añadir la lista de fuentes:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

También es posible [Remove()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontfallbackrule/remove/) una fuente de reserva o [AddFallBackFonts()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrulescollection/) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) cuando sea necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="info" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cuál es la diferencia entre una fuente de reserva, la sustitución de fuentes y la incrustación de fuentes?

Una fuente de reserva se utiliza solo para los caracteres que faltan en la fuente primaria. La [sustitución de fuentes](/slides/es/cpp/font-substitution/) reemplaza la fuente especificada completa por otra fuente. La [incrustación de fuentes](/slides/es/cpp/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los receptores puedan ver el texto tal como se pretende.

### ¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en el renderizado en pantalla?

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/cpp/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente original.

### ¿Configurar la reserva modifica el archivo de la presentación y la configuración persistirá en futuras aperturas?

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

### ¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes influyen en la selección de reserva?

Sí. El motor resuelve fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/cpp/custom-font/) que usted proporcione. Si una fuente no está físicamente disponible, una regla que la referencie no podrá aplicarse.

### ¿La reserva funciona para WordArt, SmartArt y gráficos?

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres que faltan.