---
title: Convertir presentaciones de PowerPoint a XML en Python mediante Java
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/python-java/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint a XML
- convertir presentación a XML
- PPT a XML
- PPTX a XML
- ODP a XML
- Presentación PowerPoint XML
- SaveFormat.Xml
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos PowerPoint XML en Python mediante Java con Aspose.Slides para Python mediante Java."
---
## **Visión general**

Aspose.Slides para Python a través de Java puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar resultados en pruebas automatizadas o integrarse con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Utilice el método Presentation.save con el valor Xml de la clase SaveFormat. Puede escribir el resultado directamente en un archivo o en un flujo.

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Xml) crea una PowerPoint XML Presentation. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o los archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.

{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación de origen con la clase Presentation y luego pase la ruta de salida y SaveFormat.Xml a Presentation.save. El origen puede ser cualquier formato de presentación compatible para cargar, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX a un archivo XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Escribir la salida XML en un flujo**

Utilice la sobrecarga de flujo de Presentation.save cuando el XML debe permanecer en memoria o ser pasado a otro componente, como un servicio web, proveedor de almacenamiento o canal de procesamiento XML. El siguiente ejemplo escribe el resultado en un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) y obtiene el XML resultante como un objeto bytes de Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Pasar xml_data al siguiente componente del flujo de trabajo.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se utilizará el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Inspección de la estructura, solución de problemas, comparación de resultados generados e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario heredado | Compatibilidad con flujos de trabajo de PowerPoint más antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición regular de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imágenes |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegadores y publicación web |

A diferencia de PPT y PPTX, la salida XML está pensada principalmente para inspección y flujos de trabajo basados en datos. A diferencia de PDF, TIFF, HTML y los formatos de imágenes de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de formatos de archivo compatibles enumera PowerPoint XML Presentation como un formato solo de guardado, por lo que no lo use cuando un flujo de trabajo necesite cargar el archivo exportado nuevamente en Aspose.Slides para seguir editándolo.

## **Preguntas frecuentes**

**¿La exportación a XML es lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que SaveFormat.Xml crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo de salida Java escribible a Presentation.save. Por ejemplo, use un ByteArrayOutputStream para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar nuevamente el archivo XML exportado?**

No. PowerPoint XML Presentation actualmente se admite solo para guardado y no para carga. Utilice PPTX u otro formato de presentación compatible cuando se requiera una edición bidireccional.

**¿La conversión a XML representa cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Utilice PDF o TIFF para una salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.