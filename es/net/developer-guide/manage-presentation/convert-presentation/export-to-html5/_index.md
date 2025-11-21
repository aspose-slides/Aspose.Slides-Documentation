---
title: Convertir presentaciones a HTML5 en .NET
linktitle: Presentación a HTML5
type: docs
weight: 40
url: /es/net/export-to-html5/
keywords:
- PowerPoint a HTML5
- OpenDocument a HTML5
- presentación a HTML5
- diapositiva a HTML5
- PPT a HTML5
- PPTX a HTML5
- ODP a HTML5
- guardar PPT como HTML5
- guardar PPTX como HTML5
- guardar ODP como HTML5
- exportar PPT a HTML5
- exportar PPTX a HTML5
- exportar ODP a HTML5
- .NET
- C#
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para .NET. Conservar el formato, animaciones e interactividad."
---

{{% alert title="Información" color="info" %}}

En [Aspose.Slides 21.9](/slides/es/net/aspose-slides-for-net-21-9-release-notes/), implementamos soporte para la exportación a HTML5. Sin embargo, si prefieres exportar tu PowerPoint a HTML usando WebExtensions, consulta [este artículo](/slides/es/net/web-extensions/) en su lugar. 

{{% /alert %}} 

El proceso de exportación a HTML5 aquí permite convertir PowerPoint a HTML sin extensiones web ni dependencias. De esta forma, usando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y atributos de animación resultantes. 

## **Exportar PowerPoint a HTML5**

Este código C# muestra cómo exportar una presentación a HTML5 sin extensiones web ni dependencias:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

En este caso, obtienes HTML limpio. 

{{% /alert %}}

Puedes especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:
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


## **Exportar PowerPoint a HTML**

Este C# demuestra el proceso estándar de PowerPoint a HTML:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


En este caso, el contenido de la presentación se renderiza mediante SVG en una forma como esta:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Nota" color="warning" %}} 

Cuando usas este método para exportar PowerPoint a HTML, debido al renderizado SVG, no podrás aplicar estilos ni animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a vista de diapositivas HTML5**

**Aspose.Slides** permite convertir una presentación PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verás la presentación en modo vista de diapositiva en una página web. 

Este código C# demuestra el proceso de exportación a vista de diapositiva HTML5:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```


## **Convertir una presentación a un documento HTML5 con comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden agregar sus sugerencias o observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, facilitando el seguimiento de quién dejó la observación.

Supongamos que tenemos la siguiente presentación PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación PowerPoint a un documento HTML5, puedes especificar fácilmente si deseas incluir los comentarios de la presentación en el documento de salida. Para ello, debes definir los parámetros de visualización de los comentarios en la propiedad `NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). 

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
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

## **FAQ**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, HTML5 ofrece opciones independientes para habilitar o deshabilitar [animaciones de formas](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) y [transiciones de diapositivas](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**¿Se admite la salida de comentarios y dónde pueden ubicarse respecto a la diapositiva?**

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante la [configuración de diseño](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) para notas y comentarios.

**¿Puedo omitir enlaces que invoquen JavaScript por motivos de seguridad o CSP?**

Sí, existe una [configuración](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) que permite omitir hipervínculos con llamadas a JavaScript al guardar. Esto ayuda a cumplir con políticas de seguridad estrictas.