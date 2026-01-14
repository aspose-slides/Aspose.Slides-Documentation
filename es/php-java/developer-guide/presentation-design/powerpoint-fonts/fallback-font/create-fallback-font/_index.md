---
title: Especificar fuentes de reserva para presentaciones en PHP
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/php-java/create-fallback-font/
keywords:
- fuente de reserva
- regla de reserva
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo omitido
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina Aspose.Slides para PHP a través de Java para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto consistente en cualquier dispositivo o sistema operativo."
---

## **Reglas de fuentes de reserva**

Aspose.Slides admite la clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) para especificar las reglas que se aplican a una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos adecuados:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Usando varias formas puedes añadir la lista de fuentes:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


También es posible [remove](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/remove/) una fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) se puede usar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), cuando es necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Create Fallback Fonts Collection](/slides/es/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de reserva, sustitución de fuentes e incrustación de fuentes?**

Una fuente de reserva se usa solo para los caracteres que faltan en la fuente principal. La [font substitution](/slides/es/php-java/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [font embedding](/slides/es/php-java/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los receptores puedan ver el texto como se pretende.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en la representación en pantalla?**

Sí. La reserva afecta a todas las [rendering and export operations](/slides/es/php-java/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar la reserva cambia el propio archivo de presentación, y el ajuste persistirá en futuras aperturas?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de reserva?**

Sí. El motor resuelve fuentes desde las carpetas del sistema disponibles y cualquier [additional paths](/slides/es/php-java/custom-font/) que usted proporcione. Si una fuente no está físicamente disponible, una regla que la referencie no podrá surtir efecto.

**¿La reserva funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres faltantes.