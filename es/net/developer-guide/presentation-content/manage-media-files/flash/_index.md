---
title: Flash
type: docs
weight: 10
url: /es/net/flash/
keywords: "Extraer flash, presentación PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Extraer objeto flash de una presentación PowerPoint en C# o .NET"
---

## **Extraer objetos Flash de la presentación**
Aspose.Slides for .NET provee una funcionalidad para extraer objetos flash de la presentación. Puede acceder al control flash por nombre y extraerlo de la presentación, incluyendo el almacenamiento de datos de objetos SWF.
```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```


## **Preguntas frecuentes**

**¿Qué formatos de presentación son compatibles al extraer contenido Flash?**

[Aspose.Slides admite](/slides/es/net/supported-file-formats/) los principales formatos de PowerPoint, como PPT y PPTX, ya que puede cargar estos contenedores y acceder a sus controles, incluidos los elementos ActiveX relacionados con Flash.

**¿Puedo convertir una presentación con Flash a HTML5 y conservar la interactividad de Flash?**

No. Aspose.Slides no ejecuta contenido SWF ni convierte su interactividad. Aunque la exportación a [HTML](/slides/es/net/convert-powerpoint-to-html/)/[HTML5](/slides/es/net/export-to-html5/) es compatible, Flash no se reproducirá en los navegadores modernos debido al fin de su soporte. La ruta recomendada es reemplazar Flash por alternativas como video o animaciones HTML5 antes de la exportación.

**Desde una perspectiva de seguridad, ¿Aspose.Slides ejecuta archivos SWF al leer una presentación?**

No. Aspose.Slides trata Flash como datos binarios incrustados en el archivo y no ejecuta contenido SWF durante el procesamiento.

**¿Cómo debo manejar presentaciones que incluyen Flash junto con otros archivos incrustados mediante OLE?**

Aspose.Slides admite [extraer objetos OLE incrustados](/slides/es/net/manage-ole/), por lo que puede procesar todo el contenido incrustado relacionado en una sola pasada, manejando controles Flash y otros documentos incrustados mediante OLE juntos.