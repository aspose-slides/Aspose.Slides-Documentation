---
title: Especificar fuentes de sustitución para presentaciones en Python
linktitle: Fuente de sustitución
type: docs
weight: 10
url: /es/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Domine Aspose.Slides para Python mediante .NET para establecer fuentes de sustitución en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---

## **Especificar fuentes de sustitución**

Aspose.Slides admite la clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) para especificar las reglas para aplicar una fuente de sustitución. La clase [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) representa una asociación entre el rango Unicode especificado, usado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos adecuados:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Usando varias formas puedes añadir la lista de fuentes:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```




También es posible [eliminar](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/remove/) la fuente de sustitución o [add_fall_back_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) cuando se necesite especificar reglas de sustitución de fuentes para varios rangos Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/es/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de sustitución, la sustitución de fuentes y la incrustación de fuentes?**

Una fuente de sustitución se usa solo para los caracteres que faltan en la fuente principal. La [Sustitución de fuentes](/slides/es/python-net/font-substitution/) reemplaza toda la fuente especificada por otra fuente. La [Incrustación de fuentes](/slides/es/python-net/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto como se pretende.

**¿Se aplican las fuentes de sustitución durante exportaciones como PDF, PNG o SVG, o solo al renderizado en pantalla?**

Sí. La sustitución afecta a todas las [operaciones de renderizado y exportación](/slides/es/python-net/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente de origen.

**¿Configurar la sustitución cambia el propio archivo de presentación y persistirá la configuración en futuras aperturas?**

No. Las reglas de sustitución son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿Influye el sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes en la selección de sustitución?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y cualquier [rutas adicionales](/slides/es/python-net/custom-font/) que proporcione. Si una fuente no está disponible físicamente, una regla que la referencia no podrá aplicarse.

**¿Funciona la sustitución para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para representar los caracteres faltantes.