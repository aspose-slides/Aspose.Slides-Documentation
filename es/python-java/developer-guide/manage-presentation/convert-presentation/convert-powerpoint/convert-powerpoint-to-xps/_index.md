---
title: Convertir presentaciones de PowerPoint a XPS en Python
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/python-java/convert-powerpoint-to-xps/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir PPT
- convertir PPTX
- PowerPoint a XPS
- presentación a XPS
- PPT a XPS
- PPTX a XPS
- guardar PPT como XPS
- guardar PPTX como XPS
- exportar PPT a XPS
- exportar PPTX a XPS
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones PowerPoint PPT y PPTX a XPS en Python usando Aspose.Slides for Python via Java, con configuraciones de exportación predeterminadas o personalizadas."
---
## **Visión general**

Aspose.Slides for Python via Java le permite convertir presentaciones de PowerPoint a XPS guardando un archivo PPT o PPTX en formato XPS. Este artículo explica cuándo puede ser útil XPS y muestra cómo exportar una presentación usando la configuración predeterminada o una configuración personalizada de [XpsOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xpsoptions/).

## **Acerca de XPS**

XPS (XML Paper Specification) es un formato de documento basado en XML desarrollado por Microsoft. Describe páginas fijas, preservando el diseño del texto y los gráficos para su visualización e impresión con software compatible.

## **Cuándo usar el formato Microsoft XPS**

Utilice XPS cuando un flujo de trabajo documental requiera archivos de diseño fijo para compartir o imprimir mediante herramientas compatibles con XPS. Los destinatarios necesitan software que admita XPS. Si su flujo de trabajo requiere PDF en su lugar, consulte [Convert PowerPoint to PDF](/slides/es/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Para probar la conversión de una presentación PPT o PPTX a XPS, use el [convertidor en línea gratuito](https://products.aspose.app/slides/es/conversion).
{{% /alert %}}

| Presentación PowerPoint de entrada | Documento XPS de salida |
| --- | --- |
| ![Presentación PowerPoint original](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentación convertida a XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Conversión a XPS con Aspose.Slides**

Utilice el método [save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) con [SaveFormat.Xps](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Xps) para exportar una presentación. Puede usar la configuración de exportación predeterminada o proporcionar [XpsOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xpsoptions/) para personalizar la salida.

Cada ejemplo a continuación inicia la máquina virtual Java si es necesario y libera la presentación después de su uso. Reemplace el nombre del archivo de entrada con la ruta a su archivo PPT o PPTX.

### **Convertir presentaciones a XPS usando la configuración predeterminada**

El siguiente código Python convierte una presentación a XPS usando la configuración predeterminada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Guardar la presentación como documento XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Convertir presentaciones a XPS usando configuración personalizada**

El siguiente ejemplo utiliza [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/es/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) para guardar los metaficheros como imágenes PNG en el documento XPS resultante:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Guardar la presentación con la configuración XPS personalizada.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo guardar XPS en un flujo en lugar de un archivo?**

Sí. El método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) tiene sobrecargas que aceptan un flujo de salida Java. Con Python a través de Java, use un flujo Java compatible mediante JPype, como un flujo de salida de matriz de bytes Java, para mantener los datos exportados en memoria.

**¿Se incluyen las diapositivas ocultas en la salida XPS?**

Las diapositivas ocultas se excluyen por defecto. Para incluirlas, establezca [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) a `True` antes de guardar.

**¿Se conservan las animaciones y transiciones de diapositivas en XPS?**

No. XPS contiene páginas fijas, por lo que las diapositivas exportadas no reproducen animaciones ni efectos de transición.