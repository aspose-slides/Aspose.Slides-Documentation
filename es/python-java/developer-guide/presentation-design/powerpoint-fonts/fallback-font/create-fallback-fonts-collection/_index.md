---
title: Configurar colecciones de fuentes de sustitución en Python vía Java
linktitle: Colección de fuentes de sustitución
type: docs
weight: 20
url: /es/python-java/create-fallback-fonts-collection/
keywords:
- fuente de sustitución
- regla de sustitución
- colección de fuentes
- configurar fuente
- establecer fuente
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Configure una colección de fuentes de sustitución en Aspose.Slides para Python vía Java para mantener el texto consistente y nítido en presentaciones de PowerPoint y OpenDocument."
---
## **Descripción general**

Aspose.Slides permite configurar una colección de reglas de sustitución de fuentes para una presentación. Cada regla de sustitución está representada por la clase [FontFallBackRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/) y puede añadirse a una [FontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrulescollection/).

Después de crear la colección, puedes asignarla mediante el método [setFontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) del [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) de la presentación. El [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) controla las fuentes en toda la presentación, y cada instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) dispone de su propio [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/).

Una vez que el [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) se inicializa con la colección de fuentes de sustitución, las fuentes especificadas se aplican durante la renderización de la presentación.

## **Aplicar reglas de sustitución**

Las instancias de la clase [FontFallBackRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrule/) pueden organizarse en una [FontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontfallbackrulescollection/). Puedes añadir o eliminar reglas de la colección.

Esta colección puede asignarse mediante el método [setFontFallBackRulesCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) de la clase [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/), que controla las fuentes en toda la presentación.

Cada [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) dispone de un método [getFontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getFontsManager) que devuelve su propia instancia de la clase [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/).

El siguiente ejemplo muestra cómo crear una colección de reglas de sustitución de fuentes y asignarla al [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) de una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Después de que el [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) se inicialice con la colección de fuentes de sustitución, las fuentes de respaldo se aplican durante la renderización de la presentación.

{{% alert color="info" title="Nota" %}}
Lee más sobre cómo [renderizar una presentación con una fuente de respaldo](/slides/es/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se incorporarán mis reglas de sustitución en el archivo PPTX y serán visibles en PowerPoint después de guardar?**

No. Las reglas de sustitución son configuraciones de renderizado en tiempo de ejecución; no se serializan en el PPTX y no aparecerán en la interfaz de PowerPoint.

**¿La sustitución se aplica al texto dentro de SmartArt, WordArt, gráficos y tablas?**

Sí. El mismo mecanismo de sustitución de glifos se utiliza para cualquier texto en esos objetos.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Tú añades y utilizas las fuentes por tu cuenta y bajo tu propia responsabilidad.

**¿Se pueden usar conjuntamente el reemplazo/sustitución de fuentes faltantes y la sustitución para glifos ausentes?**

Sí. Son etapas independientes del mismo proceso de resolución de fuentes: primero el motor resuelve la disponibilidad de fuentes ([replacement](/slides/es/python-java/font-replacement/)/[substitution](/slides/es/python-java/font-substitution/)), luego la sustitución cubre los huecos de glifos que faltan en las fuentes disponibles.