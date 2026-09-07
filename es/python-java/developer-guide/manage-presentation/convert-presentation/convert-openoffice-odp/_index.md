---
title: Convertir presentaciones OpenDocument en Python
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /es/python-java/convert-openoffice-odp/
keywords:
- convertir ODP
- ODP a PDF
- ODP a HTML
- ODP a TIFF
- ODP a PPT
- ODP a PPTX
- ODP a XPS
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones OpenDocument (ODP) a PDF, HTML y otros formatos con Aspose.Slides para Python vía Java, sin instalar OpenOffice ni LibreOffice."
---
## **Introducción**

Aspose.Slides for Python via Java le permite convertir presentaciones OpenDocument (ODP) a formatos como PDF, HTML, TIFF, XPS, PPT y PPTX. La conversión de ODP utiliza la misma API que la conversión de PowerPoint: cargue el archivo origen con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y seleccione el formato de salida con [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/).

## **Convertir ODP a PDF**

Siga las [instrucciones de instalación](/slides/es/python-java/installation/) antes de ejecutar el ejemplo. Coloque una presentación ODP llamada `pres.odp` en el directorio de trabajo. El código siguiente inicia la JVM si es necesario, carga la presentación y la guarda como `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Presentación OpenDocument en Diferentes Aplicaciones**

Una presentación ODP puede verse diferente en PowerPoint y LibreOffice/OpenOffice Impress porque estas aplicaciones admiten distintas funciones de presentación y comportamientos de renderizado. Revise las presentaciones convertidas cuando su diseño dependa de un formato complejo.

Las diferencias de compatibilidad pueden afectar a:
- Tablas, incluido su orden de apilamiento respecto a otras formas y la compatibilidad con rellenos de imagen.
- Rotación y alineación del texto.
- Rellenos de imagen, degradado y patrón aplicados al texto.
- Listas numeradas y con viñetas.

La imagen a continuación muestra una lista creada en LibreOffice Impress:

![Ejemplo de lista ODP en LibreOffice Impress](odp-list-example.png)

Aspose.Slides guarda las listas ODP para compatibilidad con LibreOffice/OpenOffice Impress.

Para obtener detalles sobre la compatibilidad de funciones, vea la [Guía de Microsoft sobre el formato de presentación OpenDocument](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**¿Qué pasa si el formato de mi archivo ODP cambia después de la conversión?**

ODP y PowerPoint utilizan diferentes modelos de presentación. Las tablas, fuentes y estilos de relleno pueden renderizarse de forma distinta. Verifique que las fuentes requeridas estén disponibles, revise el resultado y ajuste el diseño o formato si es necesario.

**¿Necesito tener OpenOffice o LibreOffice instalados para convertir archivos ODP?**

No. Aspose.Slides for Python via Java procesa presentaciones sin ninguna de esas aplicaciones. Se requiere un tiempo de ejecución de Java compatible y el paquete de Python.

**¿Puedo personalizar la salida PDF al convertir una presentación ODP?**

Sí. Utilice [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/) para configurar las opciones de exportación a PDF, como la calidad de imagen y la compresión.

**¿Puedo convertir presentaciones ODP en un servidor o en un contenedor?**

Sí. Instale el paquete de Python, un tiempo de ejecución de Java compatible y las fuentes necesarias para sus presentaciones en el entorno de destino. No se necesita ninguna aplicación de oficina.