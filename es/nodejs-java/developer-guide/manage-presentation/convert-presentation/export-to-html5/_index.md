---
title: Convertir presentaciones a HTML5 en JavaScript
linktitle: Presentación a HTML5
type: docs
weight: 40
url: /es/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporta presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para Node.js. Conserva el formato, las animaciones y la interactividad."
---

Aspose.Slides admite la exportación a HTML5. El proceso de exportación a HTML5 aquí le permite convertir PowerPoint a HTML sin extensiones web ni dependencias. De esta manera, usando sus propias plantillas, puede aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y los atributos de animación resultantes. 

## **Exportar PowerPoint a HTML5**

Este código JavaScript muestra cómo exportar una presentación a HTML5 sin extensiones web ni dependencias:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
En este caso, obtienes HTML limpio. 
{{% /alert %}}

Es posible que desee especificar la configuración de animaciones de formas y transiciones de diapositivas de esta manera:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Exportar PowerPoint a HTML**

Este JavaScript demuestra el proceso estándar de exportación de PowerPoint a HTML:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
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
Al usar este método para exportar PowerPoint a HTML, debido a la renderización SVG, no podrá aplicar estilos ni animar elementos específicos. 
{{% /alert %}}

## **Exportar PowerPoint a vista de diapositivas HTML5**

**Aspose.Slides** permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verá la presentación en modo vista de diapositiva en una página web. 

Este código JavaScript demuestra el proceso de exportación de PowerPoint a vista de diapositivas HTML5:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir una presentación a un documento HTML5 con comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias u observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puede especificar fácilmente si incluir los comentarios de la presentación en el documento de salida. Para ello, debe especificar los parámetros de visualización de los comentarios en la propiedad `notes_comments_layouting` de la clase [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, HTML5 ofrece opciones separadas para habilitar o deshabilitar [animaciones de formas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) y [transiciones de diapositivas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**¿Se admite la salida de comentarios, y dónde pueden colocarse respecto a la diapositiva?**

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante los [ajustes de diseño](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) de notas y comentarios.

**¿Puedo omitir los enlaces que invocan JavaScript por motivos de seguridad o CSP?**

Sí, existe una [configuración](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) que permite omitir los hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.