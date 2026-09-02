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
description: "Evalúa Aspose.Slides para .NET y descubre las funcionalidades de la API para presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP); comienza tu prueba gratuita."
---
## **Evaluación de Aspose.Slides**

Puedes descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación se convierte en una versión con licencia simplemente añadiendo unas cuantas líneas de código para aplicar la licencia. 

La versión de evaluación de Aspose.Slides (sin especificar una licencia) ofrece la funcionalidad completa del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. Además, estás limitado a una diapositiva al extraer textos de las diapositivas de la presentación.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 

Si deseas probar Aspose.Slides sin las limitaciones de la versión de evaluación, puedes solicitar una **Licencia Temporal de 30 Días**. Consulta [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Instalar el paquete de evaluación**

```bash
dotnet add package Aspose.Slides.NET
```

## **Aplicar una licencia**

Estas son las "pocas líneas de código" que convierten el paquete de evaluación en uno con licencia. Aplica la
licencia una vez al iniciar la aplicación, antes de crear cualquier objeto `Presentation` — una presentación
construida antes mantiene la marca de agua de evaluación.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` también acepta un `Stream`, que es la mejor opción cuando la licencia se envía como un recurso incrustado
en lugar de un archivo en disco. Si la ruta es incorrecta o el archivo ha expirado, la llamada lanza una excepción, por lo que
los fallos aparecen inmediatamente al iniciar en lugar de volver silenciosamente al modo de evaluación.

Una vez aplicada la licencia la marca de agua desaparece y se elimina el límite de extracción de texto a una sola diapositiva.

## **Preguntas frecuentes**

### ¿Puedo probar varias presentaciones en paralelo en diferentes hilos en modo de evaluación?

Sí. Puedes procesar diferentes documentos en paralelo; no deberías compartir el mismo objeto de presentación [entre hilos](/slides/es/net/multithreading/). El modo de evaluación no afecta a esto.

### ¿Necesito instalar Microsoft PowerPoint para evaluar la biblioteca en un servidor o en CI?

No. Aspose.Slides es un motor autónomo y no requiere PowerPoint instalado, ni para evaluación ni para producción.

### ¿Puedo probar completamente la conversión de PPT/PPTX a PDF e imágenes en modo de evaluación?

Sí. Los [convertidores](/slides/es/net/convert-presentation/) funcionan; la salida incluirá una marca de agua.

### ¿Puedo usar una licencia temporal para pruebas de carga sin marca de agua?

Sí. Una licencia temporal de 30 días elimina las limitaciones del modo de evaluación y permite probar sin marca de agua.