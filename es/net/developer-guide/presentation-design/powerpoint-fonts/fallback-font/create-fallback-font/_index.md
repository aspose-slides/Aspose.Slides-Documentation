---
title: Crear Fuente de Reemplazo
type: docs
weight: 10
url: /net/create-fallback-font/
keywords: "Fuentes, fuente de reemplazo, presentación de PowerPoint C#, Csharp, Aspose.Slides para .NET"
description: "Fuente de reemplazo en PowerPoint en C# o .NET"
---

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) para especificar las reglas para aplicar una fuente de reemplazo. La clase [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener glifos adecuados:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Usando múltiples formas, puedes agregar una lista de fuentes:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



También es posible [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) una fuente de reemplazo o [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) a un objeto existente [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) puede ser utilizado para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule), cuando hay necesidad de especificar reglas de reemplazo de fuente de reemplazo para múltiples rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear Colección de Fuentes de Reemplazo](/slides/net/create-fallback-fonts-collection/)
{{% /alert %}}