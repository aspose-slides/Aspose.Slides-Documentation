---
title: Crear Fuente de Reserva
type: docs
weight: 10
url: /java/create-fallback-font/
---

Aspose.Slides soporta la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) para especificar las reglas para aplicar una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener glifos adecuados:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando múltiples formas, puedes agregar una lista de fuentes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

También es posible [remover](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto existente de [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) se puede usar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), cuando hay necesidad de especificar reglas de reemplazo de fuentes de reserva para múltiples rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear Colección de Fuentes de Reserva](/slides/java/create-fallback-fonts-collection/)
{{% /alert %}}