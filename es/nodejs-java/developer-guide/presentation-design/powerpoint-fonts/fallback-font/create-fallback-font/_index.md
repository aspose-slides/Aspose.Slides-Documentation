---
title: Crear fuente de reserva
type: docs
weight: 10
url: /es/nodejs-java/create-fallback-font/
---

## **Reglas de fuentes de reserva**

Aspose.Slides admite la clase [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) para especificar las reglas para aplicar una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos perdidos, y una lista de fuentes que pueden contener los glifos adecuados:
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Usando múltiples formas puedes agregar la lista de fuentes:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


También es posible [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) la fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule), cuando se necesita especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Create Fallback Fonts Collection](/slides/es/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre una fuente de reserva, sustitución de fuentes y la incrustación de fuentes?**

Una fuente de reserva se usa solo para los caracteres que faltan en la fuente primaria. La [Font substitution](/slides/es/nodejs-java/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [Font embedding](/slides/es/nodejs-java/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios vean el texto tal como se pretende.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en el renderizado en pantalla?**

Sí. La fuente de reserva afecta todas las [rendering and export operations](/slides/es/nodejs-java/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar la fuente de reserva cambia el archivo de la presentación en sí, y la configuración persistirá en futuras aperturas?**

No. Las reglas de fuente de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de la fuente de reserva?**

Sí. El motor resuelve fuentes a partir de las carpetas del sistema disponibles y cualquier [additional paths](/slides/es/nodejs-java/custom-font/) que usted proporcione. Si una fuente no está físicamente disponible, una regla que la haga referencia no podrá surtir efecto.

**¿La fuente de reserva funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.