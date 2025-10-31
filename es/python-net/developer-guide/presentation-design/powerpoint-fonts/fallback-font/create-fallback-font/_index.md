---
title: Especificar fuentes de respaldo para presentaciones en Python
linktitle: Fuente de respaldo
type: docs
weight: 10
url: /es/python-net/create-fallback-font/
keywords:
- fuente de respaldo
- regla de respaldo
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo perdido
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domine Aspose.Slides para Python mediante .NET para establecer fuentes de respaldo en archivos PPT, PPTX y ODP, garantizando una visualización de texto consistente en cualquier dispositivo o sistema operativo."
---

## **Especificar fuentes de respaldo**

Aspose.Slides admite la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) y la clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) para especificar las reglas que aplican una fuente de respaldo. La clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) representa una asociación entre el rango Unicode especificado, usado para buscar glifos perdidos, y una lista de fuentes que pueden contener los glifos correctos:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Using multiple ways you can add fonts list:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

También es posible [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) una fuente de respaldo o [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) se puede usar para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) cuando se necesita especificar reglas de sustitución de fuentes de respaldo para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de respaldo](/slides/es/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre una fuente de respaldo, sustitución de fuente e incrustación de fuente?**

Una fuente de respaldo se usa solo para los caracteres que faltan en la fuente principal. La [sustitución de fuente](/slides/es/python-net/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [incrustación de fuente](/slides/es/python-net/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de respaldo durante exportaciones como PDF, PNG o SVG, o solo en el renderizado en pantalla?**

Sí. La fuente de respaldo afecta todas las [operaciones de renderizado y exportación](/slides/es/python-net/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Cambiar la configuración de respaldo modifica el archivo de presentación y persiste la configuración en futuras aperturas?**

No. Las reglas de respaldo son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de respaldo?**

Sí. El motor resuelve fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/python-net/custom-font/) que usted proporcione. Si una fuente no está disponible físicamente, una regla que la haga referencia no podrá aplicarse.

**¿El respaldo funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres faltantes.