---
title: Especificar fuentes de reserva para presentaciones en Java
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/java/create-fallback-font/
keywords:
- fuente de reserva
- regla de reserva
- aplicar fuente
- reemplazar fuente
- intervalo Unicode
- glifo faltante
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Domina Aspose.Slides para Java para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto consistente en cualquier dispositivo o sistema operativo."
---
## **Visión general**

Aspose.Slides le permite especificar fuentes de reserva para la renderización y exportación de presentaciones. Las fuentes de reserva se utilizan cuando la fuente principal no contiene glifos para determinados caracteres.

El comportamiento de reserva se configura mediante reglas de reserva. Cada regla asocia un intervalo Unicode con una o más fuentes que pueden contener los glifos necesarios. Puede definir reglas para diferentes intervalos de caracteres, agregar o eliminar fuentes de reserva de reglas existentes y organizar varias reglas en una colección de reglas de fuentes de reserva.

Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución. No modifican el archivo de la presentación y no se almacenan dentro del archivo PPTX.

## **Reglas de reserva**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/es/java/com.aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule) para especificar las reglas que aplican una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule) representa una asociación entre el intervalo Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos correctos:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando varias formas puedes agregar la lista de fuentes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

También es posible [remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) la fuente de reserva o [addFallBackFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRulesCollection) se puede utilizar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/es/java/com.aspose.slides/FontFallBackRule), cuando sea necesario especificar reglas de sustitución de fuentes de reserva para varios intervalos Unicode.

{{% alert color="info" title="Ver también" %}} 
- [Create Fallback Fonts Collection](/slides/es/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cuál es la diferencia entre una fuente de reserva, una sustitución de fuentes y una incrustación de fuentes?

Una fuente de reserva se utiliza solo para los caracteres que faltan en la fuente principal. La [Sustitución de fuentes](/slides/es/java/font-substitution/) sustituye toda la fuente especificada por otra fuente. La [Incrustación de fuentes](/slides/es/java/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

### ¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en la renderización en pantalla?

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/java/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente original.

### ¿La configuración de la reserva modifica el archivo de la presentación y persistirá la configuración en aperturas futuras?

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

### ¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de reserva?

Sí. El motor busca fuentes en las carpetas del sistema disponibles y en cualquier [rutas adicionales](/slides/es/java/custom-font/) que usted proporcione. Si una fuente no está disponible físicamente, una regla que la referencie no podrá aplicarse.

### ¿La reserva funciona para WordArt, SmartArt y gráficos?

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.