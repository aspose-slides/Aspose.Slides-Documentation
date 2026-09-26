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
## **Aspose.Slides Evaluación**

Puede descargar Aspose.Slides para evaluación. El paquete de evaluación es idéntico al paquete adquirido; se licencia después de que añada unas pocas líneas de código para aplicar la licencia.

Sin una licencia, Aspose.Slides ofrece su funcionalidad completa en modo de evaluación, con dos limitaciones: añade un cuadro de texto con marca de agua de evaluación a cada diapositiva de cada presentación que guarda, y el texto que su código lee de una presentación se trunca a sus primeros caracteres, seguido de un aviso sobre la limitación de evaluación. El texto que su código escribe se guarda completo.

![Una diapositiva con la marca de agua de evaluación](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para obtener más información.
{{% /alert %}}

## **Instalar el Paquete de Evaluación**

```bash
dotnet add package Aspose.Slides.NET
```

En Linux y macOS, puede usar el paquete Aspose.Slides.NET6.CrossPlatform en su lugar; consulte [Instalación](/slides/es/net/installation/).

## **Aplicar una Licencia**

Estas son las "pocas líneas de código" que convierten el paquete de evaluación en uno licenciado. Aplique la
licencia una vez al iniciar la aplicación, antes de crear cualquier objeto `Presentation` — una presentación
construida antes mantiene la marca de agua de evaluación.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` también acepta un `Stream`, que es la mejor opción cuando la licencia se entrega como un recurso incrustado
en lugar de un archivo en disco. Si la ruta es incorrecta o el archivo ha expirado la llamada lanza una excepción, de modo que
los fallos aparecen inmediatamente al iniciar la aplicación en lugar de volver silenciosamente al modo de evaluación.

Una vez aplicada la licencia, las presentaciones guardadas ya no llevan la marca de agua y el texto se lee completo.

## **Preguntas frecuentes**

### ¿Puedo probar múltiples presentaciones en paralelo en diferentes hilos en modo de evaluación?

Sí. Puede procesar diferentes documentos en paralelo; no debe compartir el mismo objeto de presentación [entre hilos](/slides/es/net/multithreading/). El modo de evaluación no afecta a esto.

### ¿Necesito instalar Microsoft PowerPoint para evaluar la biblioteca en un servidor o en CI?

No. Aspose.Slides es un motor independiente y no requiere que PowerPoint esté instalado ni para evaluación ni para producción.

### ¿Puedo probar completamente la conversión de PPT/PPTX a PDF e imágenes en modo de evaluación?

Sí. Los [conversores](/slides/es/net/convert-presentation/) funcionan; la salida incluirá una marca de agua.

### ¿Puedo usar una licencia temporal para pruebas de carga sin marca de agua?

Sí. Una licencia temporal de 30 días elimina las limitaciones del modo de evaluación y permite realizar pruebas sin marca de agua.