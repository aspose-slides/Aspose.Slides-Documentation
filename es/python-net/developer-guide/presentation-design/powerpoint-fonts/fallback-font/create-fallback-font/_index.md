---
title: Crear Fuente de Respaldo
type: docs
weight: 10
url: /python-net/create-fallback-font/
keywords: "Fuentes, fuente de respaldo, presentación de PowerPoint Python, Aspose.Slides para Python a través de .NET"
description: "Fuente de respaldo en PowerPoint en Python"
---

Aspose.Slides soporta la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) y la clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) para especificar las reglas para aplicar una fuente de respaldo. La clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos perdidos, y una lista de fuentes que pueden contener glifos adecuados:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Utilizando múltiples formas puedes agregar una lista de fuentes:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



También es posible [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) la fuente de respaldo o [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) en un objeto existente [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) se puede usar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/), cuando hay necesidad de especificar reglas de reemplazo de fuente de respaldo para múltiples rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear Colección de Fuentes de Respaldo](/slides/python-net/create-fallback-fonts-collection/)
{{% /alert %}}