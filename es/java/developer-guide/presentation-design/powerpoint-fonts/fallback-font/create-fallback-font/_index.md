---
title: Especificar fuentes de respaldo para presentaciones en Java
linktitle: Fuente de respaldo
type: docs
weight: 10
url: /es/java/create-fallback-font/
keywords:
- fuente de respaldo
- regla de respaldo
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo faltante
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Domine Aspose.Slides para Java para establecer fuentes de respaldo en archivos PPT, PPTX y ODP, garantizando una visualización de texto consistente en cualquier dispositivo o sistema operativo."
---

## **Reglas de respaldo**

Aspose.Slides soporta la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) para especificar las reglas que se aplican a una fuente de respaldo. La clase [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, usado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos correctos:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando múltiples formas puedes agregar una lista de fuentes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


También es posible [remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) la fuente de respaldo o [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) se puede usar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule), cuando es necesario especificar reglas de sustitución de fuentes de respaldo para múltiples rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de respaldo](/slides/es/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de respaldo, sustitución de fuentes y incrustación de fuentes?**

Una fuente de respaldo se utiliza solo para los caracteres que faltan en la fuente primaria. La [sustitución de fuentes](/slides/es/java/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [incrustación de fuentes](/slides/es/java/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de respaldo durante exportaciones como PDF, PNG o SVG, o solo en la renderización en pantalla?**

Sí. La fuente de respaldo afecta a todas las [operaciones de renderizado y exportación](/slides/es/java/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar la fuente de respaldo cambia el archivo de presentación en sí, y persistirá la configuración en futuras aperturas?**

No. Las reglas de respaldo son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de respaldo?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/java/custom-font/) que proporcione. Si una fuente no está físicamente disponible, una regla que la referencie no podrá aplicarse.

**¿La fuente de respaldo funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.