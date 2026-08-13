---
title: Evaluar Aspose.Slides
type: docs
weight: 120
url: /es/net/evaluate-aspose-slides/
keywords:
- evaluar Aspose.Slides
- evaluación de Aspose.Slides
- versión de evaluación
- funcionalidad completa
- marca de agua de evaluación
- comprar Aspose.Slides
- limitación
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Evalúe Aspose.Slides para .NET y explore las características de la API para presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP); inicie su prueba gratuita."
---
## **Evaluación de Aspose.Slides**

Puede descargar fácilmente Aspose.Slides para su evaluación. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente pasa a estar licenciada después de añadir unas pocas líneas de código para aplicar la licencia. 

La versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. Además, está limitado a una diapositiva al extraer texto de las diapositivas de la presentación.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para obtener más información.

{{% /alert %}}

## **Instalar el paquete de evaluación**

```bash
dotnet add package Aspose.Slides.NET
```

## **Aplicar una licencia**

Estas son las “pocas líneas de código” que convierten el paquete de evaluación en uno con licencia. Aplique la licencia una sola vez al iniciar la aplicación, antes de crear cualquier objeto `Presentation`; una presentación creada antes conserva la marca de agua de evaluación.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` también acepta un `Stream`, que es la opción más adecuada cuando la licencia se distribuye como un recurso incrustado en lugar de un archivo en disco. Si la ruta es incorrecta o el archivo ha caducado, la llamada lanza una excepción, por lo que los errores se detectan inmediatamente al iniciar la aplicación en lugar de volver silenciosamente al modo de evaluación.

Una vez aplicada la licencia, la marca de agua desaparece y se elimina la limitación de extracción de texto a una sola diapositiva.

## **Preguntas frecuentes**

### ¿Puedo probar múltiples presentaciones en paralelo en diferentes hilos en modo de evaluación?

Sí. Puede procesar diferentes documentos en paralelo; no debe compartir el mismo objeto de presentación [a través de hilos](/slides/es/net/multithreading/). El modo de evaluación no afecta esto.

### ¿Necesito instalar Microsoft PowerPoint para evaluar la biblioteca en un servidor o en CI?

No. Aspose.Slides es un motor independiente y no requiere PowerPoint instalado ni para la evaluación ni para la producción.

### ¿Puedo probar completamente la conversión de PPT/PPTX a PDF e imágenes en modo de evaluación?

Sí. Los [convertidores](/slides/es/net/convert-presentation/) funcionan; la salida incluirá una marca de agua.

### ¿Puedo usar una licencia temporal para pruebas de carga sin marca de agua?

Sí. Una licencia temporal de 30 días elimina las limitaciones del modo de evaluación y permite probar sin marca de agua.