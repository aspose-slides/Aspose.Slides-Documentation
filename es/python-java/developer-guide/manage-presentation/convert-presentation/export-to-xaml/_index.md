---
title: Exportar presentaciones a XAML en Python mediante Java
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/python-java/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- PowerPoint a XAML
- OpenDocument a XAML
- presentación a XAML
- PPT a XAML
- PPTX a XAML
- ODP a XAML
- guardar PPT como XAML
- guardar PPTX como XAML
- guardar ODP como XAML
- exportar PPT a XAML
- exportar PPTX a XAML
- exportar ODP a XAML
- Python
- Java
- Aspose.Slides
description: "Exporta presentaciones de PowerPoint y OpenDocument a XAML con Aspose.Slides para Python mediante Java. Usa opciones predeterminadas o incluye diapositivas ocultas."
---
## **Visión general**

Este artículo explica cómo exportar presentaciones de PowerPoint y OpenDocument a XAML usando Aspose.Slides for Python via Java. Introduce XAML, muestra cómo exportar con la configuración predeterminada y demuestra cómo incluir diapositivas ocultas con [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/).

Los ejemplos requieren Aspose.Slides for Python via Java y un runtime de Java compatible. Coloque `pres.pptx` en el directorio de trabajo actual. Cada ejemplo inicia la JVM solo si no está ya en ejecución.

## **Acerca de XAML**

XAML (Extensible Application Markup Language) es un lenguaje basado en XML para describir interfaces de usuario. Es utilizado por frameworks como Windows Presentation Foundation (WPF). Puede crear y editar XAML con un diseñador visual o un editor de texto.

## **Exportar presentaciones a XAML con opciones predeterminadas**

Cree una [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) a partir del archivo de entrada, luego pase [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/) a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para exportar con la configuración predeterminada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Exportar presentaciones a XAML con opciones personalizadas**

Utilice [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/) para configurar la exportación. Para incluir diapositivas ocultas, llame a [setExportHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `True` antes de guardar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cómo puedo elegir una fuente alternativa cuando la fuente original no está disponible?**

Utilice [setDefaultRegularFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) en su objeto [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/) para especificar una fuente alternativa. Asegúrese de que la fuente seleccionada esté disponible en el entorno de exportación.

**¿Puedo usar el marcado exportado en cualquier framework XAML?**

Los frameworks XAML difieren en los elementos y características que admiten. Pruebe el marcado exportado en su framework de destino antes de integrarlo en una aplicación.

**¿Se exportan las diapositivas ocultas por defecto?**

No. Para incluirlas, llame a [setExportHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `True`. Manténgalo en `False` para excluirlas.