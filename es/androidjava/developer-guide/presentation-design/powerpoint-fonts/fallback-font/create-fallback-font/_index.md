---
title: Especificar fuentes de reserva para presentaciones en Android
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "Domina Aspose.Slides para Android mediante Java para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---
## **Visión general**

Aspose.Slides permite especificar fuentes de reserva para la representación y operaciones de exportación de presentaciones. Las fuentes de reserva se utilizan cuando la fuente primaria no contiene glifos para determinados caracteres.

El comportamiento de reserva se configura mediante reglas de reserva. Cada regla asocia un rango Unicode con una o más fuentes que pueden contener los glifos necesarios. Puedes definir reglas para diferentes rangos de caracteres, añadir o eliminar fuentes de reserva de reglas existentes y organizar varias reglas en una colección de reglas de fuentes de reserva.

Las reglas de reserva son configuraciones de representación en tiempo de ejecución. No modifican el archivo de presentación y no se almacenan dentro del archivo PPTX.

## **Reglas de reserva**

Aspose.Slides soporta la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos perdidos, y una lista de fuentes que pueden contener los glifos adecuados:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando varias formas puedes añadir la lista de fuentes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

También es posible [remove](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) la fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRulesCollection) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontFallBackRule), cuando sea necesario especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="info" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cuál es la diferencia entre una fuente de reserva, sustitución de fuentes e incrustación de fuentes?

Una fuente de reserva se utiliza solo para los caracteres que faltan en la fuente primaria. La [sustitución de fuentes](/slides/es/androidjava/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [incrustación de fuentes](/slides/es/androidjava/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

### ¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en la representación en pantalla?

Sí. La reserva afecta a todas las [operaciones de representación y exportación](/slides/es/androidjava/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente fuente.

### ¿Configurar la reserva cambia el propio archivo de presentación y la configuración persistirá en futuras aperturas?

No. Las reglas de reserva son configuraciones de representación en tiempo de ejecución en tu código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

### ¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de reserva?

Sí. El motor resuelve fuentes de las carpetas del sistema disponibles y de cualquier [ruta adicional](/slides/es/androidjava/custom-font/) que proporciones. Si una fuente no está disponible físicamente, una regla que la referencie no podrá surtir efecto.

### ¿La reserva funciona para WordArt, SmartArt y gráficos?

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres que faltan.