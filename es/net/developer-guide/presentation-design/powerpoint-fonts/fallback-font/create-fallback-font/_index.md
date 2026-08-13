---
title: Especificar fuentes de reserva para presentaciones en .NET
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/net/create-fallback-font/
keywords:
- fuente de reserva
- regla de reserva
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo faltante
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domine Aspose.Slides para .NET para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización coherente del texto en cualquier dispositivo o sistema operativo."
---
## **Descripción general**

Aspose.Slides permite especificar fuentes de reserva para la renderización y las operaciones de exportación de presentaciones. Las fuentes de reserva se utilizan cuando la fuente principal no contiene glifos para caracteres concretos.

El comportamiento de reserva se configura mediante reglas de reserva. Cada regla asocia un rango Unicode con una o más fuentes que pueden contener los glifos necesarios. Puede definir reglas para diferentes rangos de caracteres, añadir o eliminar fuentes de reserva de reglas existentes y organizar varias reglas en una colección de reglas de fuentes de reserva.

Las reglas de reserva son configuraciones de renderización en tiempo de ejecución. No modifican el archivo de la presentación y no se guardan dentro del archivo PPTX.

## **Reglas de reserva**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/es/net/aspose.slides/iFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/es/net/aspose.slides/FontFallBackRule) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/es/net/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, usado para buscar glifos no encontrados, y una lista de fuentes que pueden contener los glifos adecuados:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Usando varias formas puedes añadir una lista de fuentes:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



También es posible [Remove()](https://reference.aspose.com/slides/es/net/aspose.slides/ifontfallbackrule/methods/remove) la fuente de reserva o [AddFallBackFonts()](https://reference.aspose.com/slides/es/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/es/net/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/es/net/aspose.slides/fontfallbackrulescollection) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/es/net/aspose.slides/FontFallBackRule), cuando sea necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="info" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cuál es la diferencia entre una fuente de reserva, la sustitución de fuentes y la incrustación de fuentes?

Una fuente de reserva se utiliza solo para los caracteres que faltan en la fuente principal. La [Sustitución de fuentes](/slides/es/net/font-substitution/) sustituye toda la fuente especificada por otra fuente. La [Incrustación de fuentes](/slides/es/net/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

### ¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en la renderización en pantalla?

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/net/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente original.

### ¿La configuración de la reserva modifica el archivo de la presentación y la configuración persistirá en futuras aperturas?

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecen en PowerPoint.

### ¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de la reserva?

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y de cualquier [ruta adicional](/slides/es/net/custom-font/) que usted proporcione. Si una fuente no está disponible físicamente, una regla que la referencie no podrá aplicarse.

### ¿Funciona la reserva para WordArt, SmartArt y gráficos?

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.