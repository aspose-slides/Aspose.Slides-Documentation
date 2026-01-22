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
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para Android mediante Java. Conservar el formato, las animaciones y la interactividad."
---

Aspose.Slides admite la exportación a HTML5. El proceso de exportación a HTML5 aquí le permite convertir PowerPoint a HTML sin extensiones web ni dependencias. De esta forma, usando sus propias plantillas, puede aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y los atributos de animación resultantes. 

## **Exportar PowerPoint a HTML5**

Este código Java muestra cómo exportar una presentación a HTML5 sin extensiones web ni dependencias:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
En este caso, obtiene HTML limpio. 
{{% /alert %}}

Es posible que desee especificar la configuración de animaciones de formas y transiciones de diapositivas de esta manera:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exportar PowerPoint a HTML**

Este Java demuestra el proceso estándar de PowerPoint a HTML:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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

**Aspose.Slides** permite convertir una presentación PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verá la presentación en modo vista de diapositiva en una página web. 

Este código Java demuestra el proceso de exportación de PowerPoint a vista de diapositivas HTML5:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Convertir una presentación a un documento HTML5 con comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias o observaciones a elementos específicos de la diapositiva sin modificar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación PowerPoint a un documento HTML5, puede especificar fácilmente si se incluyen los comentarios de la presentación en el documento de salida. Para ello, debe especificar los parámetros de visualización de los comentarios en el método `getNotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). 

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**  
Sí, HTML5 ofrece opciones independientes para habilitar o deshabilitar [animaciones de formas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y [transiciones de diapositivas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**¿Se admite la salida de comentarios y dónde pueden colocarse respecto a la diapositiva?**  
Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante [configuración de diseño](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para notas y comentarios.

**¿Puedo omitir enlaces que invoquen JavaScript por razones de seguridad o CSP?**  
Sí, existe una [configuración](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) que permite omitir hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.