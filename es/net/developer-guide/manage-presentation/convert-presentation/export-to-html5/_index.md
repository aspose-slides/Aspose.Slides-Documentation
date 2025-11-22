---
title: Exportar a HTML5
type: docs
weight: 40
url: /es/net/export-to-html5/
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

En [Aspose.Slides 21.9](/slides/es/net/aspose-slides-for-net-21-9-release-notes/), implementamos soporte para la exportación a HTML5. Sin embargo, si prefiere exportar su PowerPoint a HTML usando WebExtensions, consulte [este artículo](/slides/es/net/web-extensions/) en su lugar.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí le permite convertir PowerPoint a HTML sin extensiones web ni dependencias. De esta forma, usando sus propias plantillas, puede aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y atributos de animación resultantes. 

## **Exportar PowerPoint a HTML5**

Este código C# muestra cómo exportar una presentación a HTML5 sin extensiones web ni dependencias:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

En este caso, obtiene HTML limpio. 

{{% /alert %}}

Puede que desee especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:
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

Este C# demuestra el proceso estándar de exportación de PowerPoint a HTML:
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


{{% alert title="Note" color="warning" %}} 

Al usar este método para exportar PowerPoint a HTML, debido a la renderización SVG, no podrá aplicar estilos ni animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a Vista de Diapositivas HTML5**

**Aspose.Slides** le permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositivas. En este caso, al abrir el archivo HTML5 resultante en un navegador, verá la presentación en modo vista de diapositivas en una página web. 

Este código C# demuestra el proceso de exportación a Vista de Diapositivas HTML5:
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


## **Convertir una Presentación a un Documento HTML5 con Comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden agregar sus sugerencias u observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puede especificar fácilmente si incluir los comentarios de la presentación en el documento de salida. Para ello, debe especificar los parámetros de visualización de los comentarios en la propiedad `NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/).

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

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, HTML5 ofrece opciones separadas para habilitar o deshabilitar [animaciones de formas](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) y [transiciones de diapositivas](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**¿Se admite la salida de comentarios y dónde pueden colocarse respecto a la diapositiva?**

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante los [ajustes de diseño](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) para notas y comentarios.

**¿Puedo omitir los enlaces que invocan JavaScript por razones de seguridad o CSP?**

Sí, existe una [configuración](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) que permite omitir los hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.