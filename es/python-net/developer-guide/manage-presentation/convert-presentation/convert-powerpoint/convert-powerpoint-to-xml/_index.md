---
title: Convertir presentaciones de PowerPoint a XML en Python
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/python-net/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint a XML
- convertir presentación a XML
- PPT a XML
- PPTX a XML
- ODP a XML
- Presentación PowerPoint XML
- SaveFormat.XML
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- Python
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos PowerPoint XML en Python con Aspose.Slides."
---
## **Descripción general**

Aspose.Slides para Python mediante .NET puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar resultados en pruebas automatizadas o integrar con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Utilice el método [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) con el valor `XML` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/). Puede escribir el resultado directamente a un archivo o a un flujo.

{{% alert color="info" title="Note" %}}

`SaveFormat.XML` crea una PowerPoint XML Presentation. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.

{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Utilice la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) para cargar una presentación de origen y, a continuación, pase la ruta de salida y `SaveFormat.XML` a [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/). El origen puede ser cualquier formato de presentación soportado para carga, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX en un archivo XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Escribir la salida XML en un flujo**

Use la sobrecarga de flujo de [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) cuando el XML debe permanecer en memoria o ser pasado a otro componente, como un servicio web, un proveedor de almacenamiento o una canalización de procesamiento XML. El siguiente ejemplo escribe el resultado en un flujo [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) y lo rebobina para su lectura posterior:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Pasar xml_stream al siguiente componente del flujo de trabajo.
```

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se vaya a usar el resultado:

| Formato | Salida | Uso habitual |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentación PowerPoint XML | Inspección de la estructura, solución de problemas, comparación de la salida generada e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario legado | Compatibilidad con flujos de trabajo de PowerPoint más antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición habitual de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivo |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegador y publicación web |

A diferencia de PPT y PPTX, la salida XML está pensada principalmente para inspección y flujos de trabajo orientados a datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de [formatos de archivo compatibles](/slides/es/python-net/supported-file-formats/) indica que PowerPoint XML Presentation es un formato solo de guardado, por lo que no lo utilice cuando un flujo de trabajo necesite cargar el archivo exportado nuevamente en Aspose.Slides para seguir editándolo.

## **Preguntas frecuentes**

**¿`SaveFormat.XML` es lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat.XML` crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo con capacidad de escritura a [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/). Por ejemplo, use un flujo [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar de nuevo el archivo XML exportado?**

No. Actualmente PowerPoint XML Presentation solo se admite para guardado y no para carga. Use PPTX u otro formato de presentación compatible cuando sea necesario editar en ambas direcciones.

**¿La conversión a XML renderiza cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Use PDF o TIFF para salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.