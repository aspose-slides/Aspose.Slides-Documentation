---
title: Especificar fuentes de respaldo para presentaciones en .NET
linktitle: Fuente de respaldo
type: docs
weight: 10
url: /es/net/create-fallback-font/
keywords:
- fuente de respaldo
- regla de respaldo
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo perdido
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domine Aspose.Slides para .NET para establecer fuentes de respaldo en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---

## **Reglas de sustitución**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) para especificar las reglas que se aplican a una fuente de respaldo. La clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos adecuados:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando múltiples formas puedes agregar la lista de fuentes:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


También es posible [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) la fuente de respaldo o [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), cuando sea necesario especificar reglas de sustitución de fuentes de respaldo para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de respaldo](/slides/es/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de respaldo, sustitución de fuentes y incrustación de fuentes?**

Una fuente de respaldo se usa solo para los caracteres que faltan en la fuente principal. [Font substitution](/slides/es/net/font-substitution/) reemplaza toda la fuente especificada por otra fuente. [Font embedding](/slides/es/net/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de respaldo durante exportaciones como PDF, PNG o SVG, o solo en la renderización en pantalla?**

Sí. La sustitución de fuentes afecta a todas las [rendering and export operations](/slides/es/net/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar la sustitución de fuentes modifica el archivo de presentación en sí, y persistirá la configuración en aperturas futuras?**

No. Las reglas de sustitución son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de sustitución?**

Sí. El motor resuelve fuentes a partir de las carpetas del sistema disponibles y cualquier [additional paths](/slides/es/net/custom-font/) que usted proporcione. Si una fuente no está disponible físicamente, una regla que la referencia no podrá aplicarse.

**¿La sustitución funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.