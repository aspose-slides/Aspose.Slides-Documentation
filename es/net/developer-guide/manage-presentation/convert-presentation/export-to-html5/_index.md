---
title: Exportar a HTML5
type: docs
weight: 40
url: /es/net/exportar-a-html5/
keywords:
- PowerPoint a HTML
- diapositivas a HTML
- HTML5
- exportación HTML
- exportar presentación
- convertir presentación
- convertir diapositivas
- C#
- Csharp
- Aspose.Slides para .NET
description: "Exportar PowerPoint a HTML5 en C# o .NET"
---

{{% alert title="Info" color="info" %}}

En [Aspose.Slides 21.9](/slides/es/net/aspose-slides-for-net-21-9-release-notes/), implementamos soporte para la exportación a HTML5. Sin embargo, si prefieres exportar tu PowerPoint a HTML usando WebExtensions, consulta [este artículo](/slides/es/net/web-extensions/) en su lugar.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí te permite convertir PowerPoint a HTML sin extensiones web o dependencias. De esta manera, usando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y atributos de animación resultantes.

## **Exportar PowerPoint a HTML5**

Este código C# muestra cómo exportar una presentación a HTML5 sin extensiones web y dependencias:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

En este caso, obtienes HTML limpio. 

{{% /alert %}}

Es posible que desees especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

#### **Exportar PowerPoint a HTML**

Este C# demuestra el proceso estándar de PowerPoint a HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

En este caso, el contenido de la presentación se renderiza a través de SVG en un formato como este:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> EL CONTENIDO DE LA DIAPOSITIVA VA AQUÍ </g>
     </svg>
</div>
</body>
```

{{% alert title="Nota" color="warning" %}} 

Cuando utilizas este método para exportar PowerPoint a HTML, debido al renderizado SVG, no podrás aplicar estilos o animar elementos específicos.

{{% /alert %}}

## **Exportar PowerPoint a HTML5 Vista de Diapositivas**

**Aspose.Slides** te permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en un modo de vista de diapositivas. En este caso, al abrir el archivo HTML5 resultante en un navegador, verás la presentación en modo de vista de diapositivas en una página web.

Este código C# demuestra el proceso de exportación de PowerPoint a HTML5 Vista de Diapositivas:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-vista-diapositive.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## Convertir una Presentación a un Documento HTML5 con Comentarios

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o feedback en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden agregar sus sugerencias o observaciones a elementos específicos de las diapositivas sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita hacer un seguimiento de quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Cuando conviertes una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si deseas incluir comentarios de la presentación en el documento de salida. Para hacer esto, necesitas especificar los parámetros de visualización para los comentarios en la propiedad `NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con comentarios mostrados a la derecha de las diapositivas.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)