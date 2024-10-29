---
title: Crear Fuente de Reserva
type: docs
weight: 10
url: /es/php-java/create-fallback-font/
---

Aspose.Slides soporta la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) para especificar las reglas para aplicar una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos correctos:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Usando múltiples formas, puedes agregar una lista de fuentes:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);

```

También es posible [remover](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) la fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a un objeto existente de [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) puede ser utilizada para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), cuando hay necesidad de especificar reglas de reemplazo de fuente de reserva para múltiples rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear Colección de Fuentes de Reserva](/slides/es/php-java/create-fallback-fonts-collection/)
{{% /alert %}}