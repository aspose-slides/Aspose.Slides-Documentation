---
title: Convertir presentaciones de PowerPoint a XML en Java
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en Java con Aspose.Slides for Java."
---
## **Resumen**

Aspose.Slides for Java puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar resultados en pruebas automatizadas o integrarse con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Utilice el método [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-) con el valor `Xml` de la clase [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/). Puede escribir el resultado directamente a un archivo o a un flujo.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una PowerPoint XML Presentation. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o los archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.
{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación de origen con la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y luego pase la ruta de salida y `SaveFormat.Xml` a [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-). El origen puede ser cualquier formato de presentación compatible para cargar, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX a un archivo XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Escribir la salida XML a un flujo**

Utilice la sobrecarga de flujo de [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) cuando el XML debe permanecer en memoria o enviarse a otro componente, como un servicio web, proveedor de almacenamiento o canal de procesamiento XML. El siguiente ejemplo escribe el resultado en un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) y obtiene el XML resultante como una matriz de bytes:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Pasar xmlData al siguiente componente en el flujo de trabajo.
} finally {
    presentation.dispose();
}
```

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se utilizará el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Inspección de la estructura, solución de problemas, comparación de resultados generados y integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario heredado | Compatibilidad con flujos de trabajo de PowerPoint antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición habitual de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegadores y publicación web |

A diferencia de PPT y PPTX, la salida XML está destinada principalmente a inspecciones y flujos de trabajo orientados a datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar las diapositivas como páginas o recursos visuales. La tabla de [formatos de archivo admitidos](/slides/es/java/supported-file-formats/) enumera todos los formatos que Aspose.Slides puede cargar, importar, guardar o renderizar.

## **Preguntas frecuentes**

**¿Es `SaveFormat.Xml` lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat.Xml` crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo de escritura a [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Por ejemplo, utilice un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar de nuevo el archivo XML exportado?**

Sí. Pase el archivo XML o un flujo al constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSourceFormat--) entonces devuelve `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) informa `LoadFormat.Unknown` para este formato, por lo que no debe usarse para decidir si un archivo XML puede abrirse.

**¿La conversión a XML representa cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Utilice PDF o TIFF para una salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.