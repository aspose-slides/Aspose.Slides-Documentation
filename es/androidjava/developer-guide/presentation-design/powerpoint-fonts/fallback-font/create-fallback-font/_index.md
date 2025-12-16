---
title: Especificar fuentes de sustitución para presentaciones en Android
linktitle: Fuente de sustitución
type: docs
weight: 10
url: /es/androidjava/create-fallback-font/
keywords:
- fuente de sustitución
- regla de sustitución
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
description: "Domine Aspose.Slides para Android mediante Java para establecer fuentes de sustitución en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---

## **Reglas de sustitución**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) para especificar las reglas que aplican una fuente de respaldo. La clase [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) representa una asociación entre el rango Unicode especificado, usado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos adecuados:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


También es posible [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) una fuente de respaldo o [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) se puede usar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) cuando sea necesario especificar reglas de sustitución de fuentes de respaldo para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de respaldo](/slides/es/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre una fuente de respaldo, sustitución de fuentes y incrustación de fuentes?**

Una fuente de respaldo se usa solo para los caracteres que faltan en la fuente primaria. La [sustitución de fuentes](/slides/es/androidjava/font-substitution/) reemplaza la fuente especificada completa por otra fuente. La [incrustación de fuentes](/slides/es/androidjava/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de respaldo durante exportaciones como PDF, PNG o SVG, o solo en la representación en pantalla?**

Sí. El respaldo afecta a todas las [operaciones de renderizado y exportación](/slides/es/androidjava/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente original.

**¿Configurar el respaldo cambia el propio archivo de presentación, y la configuración persistirá en aperturas futuras?**

No. Las reglas de respaldo son configuraciones de renderizado en tiempo de ejecución en tu código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes influyen en la selección del respaldo?**

Sí. El motor resuelve fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/androidjava/custom-font/) que proporciones. Si una fuente no está físicamente disponible, una regla que la referencie no podrá tener efecto.

**¿El respaldo funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres faltantes.