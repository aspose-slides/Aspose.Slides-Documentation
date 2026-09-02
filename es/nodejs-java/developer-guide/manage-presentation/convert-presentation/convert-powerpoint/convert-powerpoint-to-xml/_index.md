---
title: Convertir presentaciones de PowerPoint a XML en JavaScript
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/nodejs-java/convert-powerpoint-to-xml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en JavaScript con Aspose.Slides for Node.js via Java."
---
## **Resumen**

Aspose.Slides for Node.js via Java puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar resultados en pruebas automatizadas o integrarse con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Utilice el método [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) con el valor `Xml` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/). Puede escribir el resultado directamente en un archivo o en un flujo.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una PowerPoint XML Presentation. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.
{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación de origen con la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/), y luego pase la ruta de salida y `SaveFormat.Xml` a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save). El origen puede ser cualquier formato de presentación admitido para carga, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX en un archivo XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Escribir la salida XML a un flujo**

Utilice la sobrecarga de flujo de [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) cuando el XML debe permanecer en memoria o ser pasado a otro componente, como un servicio web, proveedor de almacenamiento o canal de procesamiento XML. El siguiente ejemplo escribe el resultado en un `ByteArrayOutputStream` de Java y copia los datos generados a un `Buffer` de Node.js:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Pasa xmlBuffer al siguiente componente en el flujo de trabajo.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se utilizará el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentación PowerPoint XML | Inspección de la estructura, solución de problemas, comparación de la salida generada e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario heredado | Compatibilidad con flujos de trabajo de PowerPoint antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición regular de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegador y publicación web |

A diferencia de PPT y PPTX, la salida XML está pensada principalmente para la inspección y flujos de trabajo orientados a datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de [formatos de archivo admitidos](/slides/es/nodejs-java/supported-file-formats/) indica que PowerPoint XML Presentation es un formato solo de guardado, por lo que no lo utilice cuando un flujo de trabajo necesite cargar el archivo exportado nuevamente en Aspose.Slides para continuar editando.

## **FAQ**

**¿Es `SaveFormat.Xml` lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat.Xml` crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo writable a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save). Por ejemplo, use un `ByteArrayOutputStream` de Java y copie sus datos a un `Buffer` de Node.js para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar nuevamente el archivo XML exportado?**

No. PowerPoint XML Presentation está actualmente soportado solo para guardado, no para carga. Utilice PPTX u otro formato de presentación admitido cuando sea necesario una edición bidireccional.

**¿La conversión a XML renderiza cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Utilice PDF o TIFF para salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.