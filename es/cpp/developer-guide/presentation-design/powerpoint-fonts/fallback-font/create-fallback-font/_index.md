---
title: Especificar fuentes de reserva para presentaciones en С++
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
- glifo faltante
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- С++
- Aspose.Slides
description: "Domine Aspose.Slides para С++ para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---

## **Reglas de reserva**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) y la clase [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) representa una asociación entre el rango Unicode especificado, usado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos adecuados:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


También es posible [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) la fuente de reserva o [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/), cuando es necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de reserva, la sustitución de fuentes y la incrustación de fuentes?**

Una fuente de reserva se usa solo para los caracteres que faltan en la fuente primaria. La [Sustitución de fuentes](/slides/es/cpp/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [Incrustación de fuentes](/slides/es/cpp/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en el renderizado en pantalla?**

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/cpp/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente original.

**¿Configurar la reserva modifica el archivo de la presentación en sí, y la configuración persistirá en futuras aperturas?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes influyen en la selección de la reserva?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/cpp/custom-font/) que proporcione. Si una fuente no está disponible físicamente, una regla que la haga referencia no podrá aplicarse.

**¿Funciona la reserva para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.