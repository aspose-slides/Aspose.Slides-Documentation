---
title: Especificar fuentes de respaldo para presentaciones en C++
linktitle: Fuente de respaldo
type: docs
weight: 10
url: /es/cpp/create-fallback-font/
keywords:
- fuente de respaldo
- regla de respaldo
- aplicar fuente
- sustituir fuente
- rango Unicode
- glifo faltante
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina Aspose.Slides para C++ para establecer fuentes de respaldo en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---
## **Visión general**

Aspose.Slides le permite especificar fuentes de respaldo para la renderización y exportación de presentaciones. Las fuentes de respaldo se utilizan cuando la fuente principal no contiene glifos para caracteres concretos.

El comportamiento de respaldo se configura mediante reglas de respaldo. Cada regla asocia un rango Unicode con una o más fuentes que pueden contener los glifos necesarios. Puede definir reglas para diferentes rangos de caracteres, añadir o eliminar fuentes de respaldo de reglas existentes y organizar múltiples reglas en una colección de reglas de fuentes de respaldo.

Las reglas de respaldo son configuraciones de renderización en tiempo de ejecución. No modifican el archivo de la presentación y no se almacenan dentro del archivo PPTX.

## **Reglas de fuentes de respaldo**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontfallbackrule/) y la clase [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) para especificar las reglas que aplican una fuente de respaldo. La clase [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) representa una asociación entre el rango Unicode especificado, usado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos correctos:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Usando varias formas puedes añadir la lista de fuentes:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



También es posible [Remove()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontfallbackrule/remove/) una fuente de respaldo o [AddFallBackFonts()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrulescollection/) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontfallbackrule/) cuando sea necesario especificar reglas de sustitución de fuentes de respaldo para varios rangos Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/es/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de respaldo, la sustitución de fuentes y la incrustación de fuentes?**

Una fuente de respaldo se usa solo para los caracteres que faltan en la fuente principal. La [sustitución de fuentes](/slides/es/cpp/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [incrustación de fuentes](/slides/es/cpp/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de respaldo durante exportaciones como PDF, PNG o SVG, o solo en la renderización en pantalla?**

Sí. El respaldo afecta a todas las [operaciones de renderización y exportación](/slides/es/cpp/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar el respaldo cambia el propio archivo de presentación y la configuración persistirá en futuras aperturas?**

No. Las reglas de respaldo son configuraciones de renderización en tiempo de ejecución en su código; no se guardan dentro del .pptx y no aparecen en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes influyen en la selección del respaldo?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/cpp/custom-font/) que usted proporcione. Si una fuente no está físicamente disponible, una regla que la referencie no podrá aplicarse.

**¿El respaldo funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.