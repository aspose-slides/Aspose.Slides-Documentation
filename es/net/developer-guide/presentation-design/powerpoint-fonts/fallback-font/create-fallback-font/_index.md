---
title: Crear fuente de reserva
type: docs
weight: 10
url: /es/net/create-fallback-font/
keywords: "Fuentes, fuente de reserva, presentación PowerPoint C#, Csharp, Aspose.Slides for .NET"
description: "Fuente de reserva en PowerPoint en C# o .NET"
---

## **Reglas de reserva**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, usado para buscar glifos ausentes, y una lista de fuentes que pueden contener los glifos adecuados:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando diversas formas puedes agregar la lista de fuentes:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


También es posible [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) la fuente de reserva o [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) puede usarse para organizar una lista de [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) objetos, cuando sea necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de reserva, sustitución de fuentes y incrustación de fuentes?**

Una fuente de reserva se utiliza solo para los caracteres que faltan en la fuente principal. [Font substitution](/slides/es/net/font-substitution/) reemplaza toda la fuente especificada por otra fuente. [Font embedding](/slides/es/net/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en la renderización en pantalla?**

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/net/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Cambiar la configuración de reserva modifica el archivo de presentación y persiste para aperturas futuras?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecen en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes influyen en la selección de reserva?**

Sí. El motor resuelve fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/net/custom-font/) que proporcione. Si una fuente no está físicamente disponible, una regla que la referencia no puede aplicarse.

**¿Funciona la reserva para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.