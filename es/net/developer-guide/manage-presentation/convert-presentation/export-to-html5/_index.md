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
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para .NET. Conservar el formato, las animaciones y la interactividad."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a HTML5 usando Aspose.Slides para .NET. Cubre la exportación básica, el control de animaciones de formas y transiciones de diapositivas, y la disposición de comentarios. También compara la salida HTML5 con la salida basada en SVG de la exportación HTML estándar.

## **Exportar PowerPoint a HTML5**

El siguiente ejemplo carga una presentación desde el directorio de trabajo y la guarda en formato HTML5. Utiliza la configuración de exportación predeterminada; el próximo ejemplo muestra cómo controlar la reproducción de animaciones de forma explícita. Reemplace la ruta de entrada con la ruta a su presentación.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Además del documento HTML, la exportación escribe archivos CSS y JavaScript de soporte para el estilo de diapositivas, animaciones, efectos y navegación. Mantenga estos archivos con el documento HTML al mover o publicar la salida. La página generada también carga jQuery y Anime.js desde CDNs públicos; sin ellos, la navegación de diapositivas y las animaciones no se ejecutan.
{{% /alert %}}

Para exportar sin reproducir animaciones de formas ni transiciones de diapositivas, establezca [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) y [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) a `false` en [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Estas configuraciones son independientes, por lo que puede habilitar una mientras deshabilita la otra. El ejemplo exporta la presentación con ambos tipos de animación desactivados en la página generada.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Exportar PowerPoint a HTML**

La exportación HTML estándar utiliza un enfoque de renderizado diferente: el contenido de la diapositiva se representa mediante SVG dentro de una página HTML. El siguiente ejemplo convierte una presentación a un documento HTML usando este enfoque de renderizado.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

El marcado simplificado a continuación ilustra la estructura de la página generada. El elemento SVG contiene el contenido de la diapositiva renderizada; el texto del marcador de posición representa ese contenido y no es la salida literal de la exportación.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
La exportación basada en SVG no expone las formas de PowerPoint como elementos HTML individuales. Use la exportación HTML5 cuando necesite las opciones de animación de forma y transición de diapositiva demostradas en este artículo.
{{% /alert %}}

## **Exportar PowerPoint a vista de diapositivas HTML5**

La exportación HTML5 produce una página para ver y navegar por las diapositivas de la presentación en un navegador. Este ejemplo habilita tanto [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) como [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) para que la vista de diapositivas exportada pueda reproducir los efectos de la presentación original.

Utilice una presentación que ya contenga animaciones de forma y transiciones de diapositivas para ver el efecto de estas configuraciones. Habilitarlas no añade nuevos efectos a las diapositivas que no los tengan. Después de la exportación, abra el documento HTML5 generado en un navegador con sus archivos de soporte disponibles.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Convertir una presentación a un documento HTML5 con comentarios**

Puede incluir los comentarios de diapositiva existentes en la salida HTML5 para que los lectores vean la retroalimentación junto al contenido de la diapositiva. El ejemplo en esta sección asume que la presentación fuente contiene comentarios, como se ilustra a continuación. Exporta esos comentarios; no crea nuevos.

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Asigne un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) a la propiedad [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) de [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Establezca [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) a `Right` desde la enumeración [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) para colocar los comentarios a la derecha de cada diapositiva.

El siguiente ejemplo exporta la presentación a HTML5 con este diseño de comentarios. Una presentación sin comentarios no tendrá texto de comentario que mostrar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

La imagen a continuación muestra el documento HTML5 exportado con los comentarios mostrados junto a la diapositiva.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Excluir hipervínculos JavaScript durante la exportación**

Suponga que `hyperlinks.pptx` contiene texto enlazado con un objetivo `javascript:alert('Hello')` y un enlace ordinario `https://example.com/`. Para excluir el hipervínculo JavaScript durante la exportación, establezca [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) a `true`. El valor predeterminado es `false`, por lo que estos enlaces no se filtran a menos que habilite la opción.

El siguiente ejemplo carga la presentación desde el directorio de trabajo y la exporta usando [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

El archivo exportado omite el hipervínculo JavaScript mientras conserva su texto y el enlace HTTPS ordinario. La presentación fuente permanece sin cambios.

Esta opción filtra los hipervínculos JavaScript; no elimina todos los scripts ni otro contenido activo, ni garantiza el cumplimiento de CSP. Por ejemplo, la salida HTML5 sigue incluyendo scripts para la navegación de diapositivas y animaciones.

## **Preguntas frecuentes**

**¿Puedo controlar si se reproducen las animaciones de objetos y las transiciones de diapositivas en HTML5?**

Sí, la exportación HTML5 ofrece opciones independientes para habilitar o deshabilitar las [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) y las [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**¿Se admiten los comentarios y dónde pueden situarse respecto a la diapositiva?**

Sí, los comentarios existentes pueden incluirse en la salida HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante la [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) para notas y comentarios.

**¿Puedo omitir los enlaces que invocan JavaScript por razones de seguridad o CSP?**

Sí, la configuración [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) le permite omitir los hipervínculos con llamadas JavaScript durante el guardado. El valor predeterminado es `false`. Consulte [Exclude JavaScript Hyperlinks During Export](/slides/es/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) para un ejemplo sencillo de exportación a HTML, HTML5 y PDF y el alcance del filtro. Esta configuración no elimina el JavaScript utilizado por el visor HTML5 para la navegación y las animaciones.