---
title: Convertir presentaciones de PowerPoint a XML en Android
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/androidjava/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint a XML
- convertir presentación a XML
- PPT a XML
- PPTX a XML
- ODP a XML
- Presentación XML de PowerPoint
- SaveFormat.Xml
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- Android
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en Android con Aspose.Slides."
---
## **Visión general**

Aspose.Slides for Android via Java puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar resultados en pruebas automáticas o integrarse con un flujo de trabajo que consuma XML en lugar de un paquete de presentación.

Use el método [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) con [SaveFormat.Xml](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/#Xml). Puede escribir el resultado directamente a un archivo o a un flujo.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una Presentación XML de PowerPoint. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.
{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación de origen con la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y luego pase la ruta de salida y [SaveFormat.Xml](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/#Xml) a [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). La fuente puede ser cualquier formato de presentación compatible para carga, como PPT, PPTX u ODP.

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

Utilice la sobrecarga de flujo de [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) cuando el XML deba permanecer en memoria o pasarse a otro componente, como un servicio web, proveedor de almacenamiento o canal de procesamiento XML. El siguiente ejemplo escribe el resultado a un [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) y obtiene el XML generado como un arreglo de bytes:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Pasar xmlData al siguiente componente en el flujo de trabajo.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se vaya a usar el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentación XML de PowerPoint | Inspección de la estructura, solución de problemas, comparación de salida generada e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario legado | Compatibilidad con flujos de trabajo de PowerPoint antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición regular de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegador y publicación web |

A diferencia de PPT y PPTX, la salida XML está pensada principalmente para inspección y flujos de trabajo orientados a datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o activos visuales. La tabla de [formatos de archivo compatibles](/slides/es/androidjava/supported-file-formats/) enumera PowerPoint XML Presentation como un formato solo de guardado, por lo que no debe usarse cuando un flujo de trabajo necesite cargar el archivo exportado nuevamente en Aspose.Slides para continuar editándolo.

## **Preguntas frecuentes**

**¿Es `SaveFormat.Xml` lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat.Xml` crea un archivo de Presentación XML de PowerPoint.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo de escritura a [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Por ejemplo, use un [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar de nuevo el archivo XML exportado?**

No. La Presentación XML de PowerPoint se admite actualmente solo para guardado, no para carga. Use PPTX u otro formato de presentación admitido cuando se requiera edición bidireccional.

**¿La conversión a XML representa cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Use PDF o TIFF para salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.