---
title: Especificar fuentes de reserva para presentaciones en Python mediante Java
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Domine Aspose.Slides para Python mediante Java para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto coherente en cualquier dispositivo o sistema operativo."
---
## **Visión general**

Aspose.Slides le permite especificar fuentes de reserva para la representación y exportación de presentaciones. Las fuentes de reserva se utilizan cuando la fuente principal no contiene glifos para caracteres concretos.

El comportamiento de reserva se configura mediante reglas de reserva. Cada regla asocia un rango Unicode con una o varias fuentes que pueden contener los glifos necesarios. Puede definir reglas para diferentes rangos de caracteres, añadir o eliminar fuentes de reserva de reglas existentes y organizar varias reglas en una colección de reglas de fuentes de reserva.

Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución. No modifican el archivo de la presentación y no se almacenan dentro del archivo PPTX.

## **Reglas de reserva**

Aspose.Slides proporciona la clase [FontFallBackRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/) para especificar reglas de aplicación de fuentes de reserva. Esta clase representa una asociación entre un rango Unicode utilizado para buscar glifos faltantes y una lista de fuentes que pueden contener los glifos requeridos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Utilice varias formas para especificar una lista de fuentes.
font_names = jpArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

También puede eliminar una fuente de reserva usando [remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/#remove) o añadir fuentes de reserva usando [addFallBackFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrulescollection/) puede organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/) cuando necesita especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="info" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de reserva, sustitución de fuentes y incrustación de fuentes?**

Una fuente de reserva se utiliza únicamente para los caracteres que faltan en la fuente principal. [Font substitution](/slides/es/python-java/font-substitution/) sustituye toda la fuente especificada por otra fuente. [Font embedding](/slides/es/python-java/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto según lo previsto.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en la representación en pantalla?**

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/python-java/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente origen.

**¿Configurar la reserva modifica el archivo de la presentación y persistirá la configuración en futuras aperturas?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en su código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de reserva?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/python-java/custom-font/) que proporcione. Si una fuente no está disponible físicamente, una regla que la haga referencia no podrá aplicarse.

**¿La reserva funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.