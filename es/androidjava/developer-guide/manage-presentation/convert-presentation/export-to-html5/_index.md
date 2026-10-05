---
title: Convertir presentaciones a HTML5 en Android
linktitle: Presentación a HTML5
type: docs
weight: 40
url: /es/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para Android mediante Java. Conservar formato, animaciones e interactividad."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a HTML5 usando Aspose.Slides para Android a través de Java. Cubre la exportación básica, el control de animaciones de formas y transiciones de diapositivas, y el diseño de comentarios. También compara la salida HTML5 con la salida basada en SVG de la exportación HTML estándar.

## **Exportar PowerPoint a HTML5**

El siguiente ejemplo carga una presentación desde el directorio de trabajo y la guarda en formato HTML5. Utiliza la configuración de exportación predeterminada; el siguiente ejemplo muestra cómo controlar la reproducción de animaciones de forma explícita. Reemplace la ruta de entrada con la ruta a su presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Además del documento HTML, la exportación escribe archivos CSS y JavaScript de soporte para el estilo de diapositivas, animaciones, efectos y navegación. Mantenga estos archivos junto al documento HTML al mover o publicar la salida. La página generada también carga jQuery y Anime.js desde CDNs públicas; sin ellos, la navegación de diapositivas y las animaciones no se ejecutan.
{{% /alert %}}

Para exportar sin reproducir animaciones de formas ni transiciones de diapositivas, pase `false` a [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) en [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Estas configuraciones son independientes, por lo que puede habilitar una mientras deshabilita la otra. El ejemplo exporta la presentación con ambos tipos de animación desactivados en la página generada.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Exportar PowerPoint a HTML**

La exportación HTML estándar utiliza un enfoque de renderizado diferente: el contenido de la diapositiva se representa mediante SVG dentro de una página HTML. El siguiente ejemplo convierte una presentación a un documento HTML usando este enfoque de renderizado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

El marcado simplificado a continuación ilustra la estructura de la página generada. El elemento SVG contiene el contenido renderizado de la diapositiva; el texto del marcador de posición representa ese contenido y no es la salida literal de la exportación.

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
La exportación basada en SVG no expone las formas de PowerPoint como elementos HTML individuales. Utilice la exportación HTML5 cuando necesite las opciones de animación de formas y transiciones de diapositivas demostradas en este artículo.
{{% /alert %}}

## **Exportar PowerPoint a la vista de diapositivas HTML5**

La exportación HTML5 genera una página para ver y navegar por las diapositivas de la presentación en un navegador. Este ejemplo habilita tanto [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) como [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) para que la vista de diapositivas exportada pueda reproducir los efectos de la presentación original.

Utilice una presentación que ya contenga animaciones de formas y transiciones de diapositivas para ver el efecto de estas configuraciones. Habilitarlas no añade nuevos efectos a las diapositivas que no los tengan. Después de la exportación, abra el documento HTML5 generado en un navegador con sus archivos de soporte disponibles.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Convertir una presentación a un documento HTML5 con comentarios**

Puede incluir los comentarios de diapositivas existentes en la salida HTML5 para que los lectores vean la retroalimentación junto al contenido de la diapositiva. El ejemplo en esta sección supone que la presentación de origen contiene comentarios, como se ilustra a continuación. Exporta esos comentarios; no crea nuevos.

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Pase un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) al método [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) de [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Utilice [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) para seleccionar `Right` de la enumeración [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) y colocar los comentarios a la derecha de cada diapositiva.

El siguiente ejemplo exporta la presentación a HTML5 con este diseño de comentarios. Una presentación sin comentarios no tendrá texto de comentario que mostrar.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Excluir hipervínculos JavaScript durante la exportación**

Supongamos que `hyperlinks.pptx` contiene texto enlazado con un destino `javascript:alert('Hello')` y un enlace ordinario `https://example.com/`. Para excluir el hipervínculo JavaScript durante la exportación, pase `true` a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). El valor predeterminado es `false`, por lo que estos enlaces no se filtran a menos que active la opción.

El siguiente ejemplo carga la presentación desde el directorio de trabajo y la exporta usando [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

El archivo exportado omite el hipervínculo JavaScript mientras conserva su texto y el enlace HTTPS ordinario. La presentación de origen permanece sin cambios.

Esta opción filtra los hipervínculos JavaScript; no elimina todos los scripts u otro contenido activo, ni garantiza el cumplimiento de CSP. Por ejemplo, la salida HTML5 sigue incluyendo scripts para la navegación y animaciones de diapositivas.

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, la exportación HTML5 ofrece opciones separadas para habilitar o deshabilitar [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**¿Se admiten los comentarios, y dónde pueden ubicarse respecto a la diapositiva?**

Sí, los comentarios existentes pueden incluirse en la salida HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante los [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para notas y comentarios.

**¿Puedo omitir enlaces que invoquen JavaScript por razones de seguridad o CSP?**

Sí, la configuración [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) permite omitir los hipervínculos con llamadas JavaScript durante el guardado. El valor predeterminado es `false`. Consulte [Exclude JavaScript Hyperlinks During Export](/slides/es/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) para un ejemplo de exportación HTML5 y el alcance del filtro. Esta configuración no elimina el JavaScript utilizado por el visor HTML5 para la navegación y animaciones.