---
title: Exportar a HTML5
type: docs
weight: 40
url: /es/androidjava/export-to-html5/
keywords:
- PowerPoint a HTML
- diapositivas a HTML
- HTML5
- exportación a HTML
- exportar presentación
- convertir presentación
- convertir diapositivas
- Java
- Aspose.Slides para Android a través de Java
description: "Exportar PowerPoint a HTML5 en Java"
---

{{% alert title="Info" color="info" %}}

En [Aspose.Slides 21.9](/slides/es/androidjava/aspose-slides-for-java-21-9-release-notes/), implementamos soporte para la exportación a HTML5.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí te permite convertir PowerPoint a HTML sin extensiones web o dependencias. De esta manera, utilizando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y los atributos resultantes de HTML, CSS, JavaScript y animaciones. 

## **Exportar PowerPoint a HTML5**

Este código Java muestra cómo exportar una presentación a HTML5 sin extensiones web y dependencias:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

En este caso, obtienes HTML limpio. 

{{% /alert %}}

Puedes querer especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:

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

Este ejemplo en Java demuestra el proceso estándar de PowerPoint a HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

En este caso, el contenido de la presentación se renderiza a través de SVG en una forma como esta:

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

Cuando utilizas este método para exportar PowerPoint a HTML, debido al renderizado en SVG, no podrás aplicar estilos o animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a HTML5 en Vista de Diapositiva**

**Aspose.Slides** te permite convertir una presentación de PowerPoint a un documento HTML5 en el cual las diapositivas se presentan en un modo de vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verás la presentación en modo de vista de diapositiva en una página web. 

Este código Java demuestra el proceso de exportación de PowerPoint a vista de diapositiva HTML5:

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

## Convertir una Presentación a un Documento HTML5 con Comentarios

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o retroalimentación en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde múltiples personas pueden agregar sus sugerencias o comentarios a elementos específicos de las diapositivas sin alterar el contenido principal. Cada comentario muestra el nombre del autor, facilitando el seguimiento de quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si incluir o no los comentarios de la presentación en el documento de salida. Para hacer esto, necesitas especificar los parámetros de visualización para los comentarios en el método `getNotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/).

El siguiente ejemplo de código convierte una presentación en un documento HTML5 con comentarios mostrados a la derecha de las diapositivas.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)