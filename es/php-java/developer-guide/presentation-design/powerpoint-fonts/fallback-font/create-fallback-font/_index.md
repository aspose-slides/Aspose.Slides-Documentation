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
- glifo faltante
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina Aspose.Slides para PHP mediante Java para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización constante del texto en cualquier dispositivo o sistema operativo."
---

## **Reglas de sustitución**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos adecuados:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Usando varias formas puedes añadir la lista de fuentes:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);

```


También es posible [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) la fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule), cuando es necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de reserva, la sustitución de fuentes y la incrustación de fuentes?**

Una fuente de reserva se utiliza solo para los caracteres que faltan en la fuente primaria. La [font substitution](/slides/es/php-java/font-substitution/) reemplaza la fuente especificada completa por otra fuente. La [font embedding](/slides/es/php-java/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en el renderizado en pantalla?**

Sí. La reserva afecta a todas las [rendering and export operations](/slides/es/php-java/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar la reserva modifica el propio archivo de presentación, y persistirá la configuración en futuras aperturas?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en tu código; no se guardan dentro del .pptx y no aparecen en PowerPoint.

**¿Influyen el sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes en la selección de la reserva?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y de cualquier [additional paths](/slides/es/php-java/custom-font/) que proporciones. Si una fuente no está disponible físicamente, una regla que la haga referencia no podrá aplicarse.

**¿Funciona la reserva para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres faltantes.