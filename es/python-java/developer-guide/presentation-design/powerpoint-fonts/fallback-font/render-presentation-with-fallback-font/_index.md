---
title: Renderizar presentaciones con fuentes de reserva en Python mediante Java
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/python-java/render-presentation-with-fallback-font/
keywords:
- fuente de reserva
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Renderizar presentaciones con fuentes de reserva en Aspose.Slides para Python mediante Java – mantenga el texto coherente en PPT, PPTX y ODP con ejemplos de código Python paso a paso."
---
## **Descripción general**

Aspose.Slides le permite renderizar presentaciones usando reglas de fuentes de reserva. Este artículo muestra cómo crear una colección de reglas de fuentes de reserva, modificar sus reglas eliminando o añadiendo fuentes de reserva, y asignar la colección mediante el método [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Una vez que la colección de reglas de fuentes de reserva se asigna al [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) de la presentación, las reglas se aplican durante operaciones como guardar, renderizar y convertir la presentación. El ejemplo demuestra cómo usar las reglas configuradas al renderizar una miniatura de diapositiva y guardarla como imagen JPEG.

## **Renderizar una diapositiva usando reglas de fuentes de reserva**

El siguiente ejemplo incluye estos pasos:

1. [Crear una colección de reglas de fuentes de reserva](/slides/es/python-java/create-fallback-fonts-collection/).
1. [Eliminar](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/#remove) una fuente de reserva de una regla y [añadir fuentes de reserva](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) a otra regla.
1. Asignar la colección de reglas usando [setFontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) en el gestor de fuentes devuelto por [getFontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getFontsManager).
1. Utilizar el método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para guardar la presentación en el mismo formato o en otro formato. Después de que la colección de reglas de fuentes de reserva se asigna a [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/), estas reglas se aplican durante operaciones sobre la presentación: guardar, renderizar, convertir, etc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Crear una nueva colección de reglas.
fallback_rules = FontFallBackRulesCollection()

# Crear varias reglas.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Intentar eliminar la fuente de reserva "Tahoma" de las reglas.
    fallback_rule.remove("Tahoma")

    # Actualizar las reglas para el rango especificado.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Eliminar una regla existente, manteniendo al menos una regla para el renderizado.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Asignar la colección de reglas preparada.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Renderizar una miniatura usando la colección de reglas configurada.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Guardar la imagen en disco en formato JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Obtenga más información sobre cómo [convertir PPT y PPTX a JPG en Python mediante Java](/slides/es/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}