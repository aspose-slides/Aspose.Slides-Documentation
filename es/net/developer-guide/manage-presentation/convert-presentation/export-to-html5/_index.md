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
description: "Exporta presentaciones de PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para .NET. Conserva el formato, las animaciones y la interactividad."
---
## **Descripción general**

Este artículo explica cómo convertir presentaciones de PowerPoint a HTML5 usando Aspose.Slides. Cubre la exportación básica a HTML5, así como opciones para controlar las animaciones de formas y las transiciones de diapositivas. El artículo también muestra el proceso estándar de exportación de PowerPoint a HTML, explica cómo generar una salida HTML5 en modo vista de diapositivas y demuestra cómo incluir comentarios en el documento exportado configurando su disposición.

## **Exportar PowerPoint a HTML5**

Este código C# muestra cómo exportar una presentación a HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
Además del documento HTML, la exportación escribe los archivos de soporte a los que hace referencia: `pres.css`, `master.css`, `animation.js`, `effects.js` y `navigation.js`. La página generada también carga jQuery y Anime.js desde CDNs públicos; sin ellos, la navegación de diapositivas y las animaciones no se ejecutan. 
{{% /alert %}}

Puede que desee especificar la configuración de animaciones de formas y transiciones de diapositivas de esta manera:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

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
Cuando utiliza este método para exportar PowerPoint a HTML, debido a la renderización SVG, no podrá aplicar estilos ni animar elementos específicos. 
{{% /alert %}}

## **Exportar PowerPoint a vista de diapositivas HTML5**

**Aspose.Slides** permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verá la presentación en modo vista de diapositiva en una página web. 

Este código C# demuestra el proceso de exportación de PowerPoint a vista de diapositivas HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios sobre las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias u observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puede especificar fácilmente si se incluyen los comentarios de la presentación en el documento de salida. Para ello, debe especificar los parámetros de visualización de los comentarios en la propiedad `NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
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

### ¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducen en HTML5?

Sí, HTML5 ofrece opciones separadas para habilitar o deshabilitar las [animaciones de formas](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/animateshapes/) y las [transiciones de diapositivas](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/animatetransitions/).

### ¿Se admite la salida de comentarios y dónde pueden ubicarse respecto a la diapositiva?

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante la [configuración de disposición](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/notescommentslayouting/) de notas y comentarios.

### ¿Puedo omitir enlaces que invoquen JavaScript por motivos de seguridad o CSP?

Sí, existe una [configuración](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) que permite omitir hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.