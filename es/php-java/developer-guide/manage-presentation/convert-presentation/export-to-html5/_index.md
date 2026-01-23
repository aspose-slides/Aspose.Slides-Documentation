---
title: Convertir presentaciones a HTML5 en PHP
linktitle: Presentación a HTML5
type: docs
weight: 40
url: /es/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exporta presentaciones de PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para PHP mediante Java. Conserva el formato, las animaciones y la interactividad."
---

Aspose.Slides admite la exportación a HTML5. El proceso de exportación a HTML5 aquí le permite convertir PowerPoint a HTML sin extensiones web ni dependencias. De esta manera, usando sus propias plantillas, puede aplicar opciones muy flexibles que definen el proceso de exportación y los atributos resultantes de HTML, CSS, JavaScript y animación. 

## **Exportar PowerPoint a HTML5**

Este código PHP muestra cómo exportar una presentación a HTML5 sin extensiones web ni dependencias:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

En este caso, obtiene HTML limpio. 

{{% /alert %}}

Puede especificar la configuración para animaciones de forma y transiciones de diapositiva de esta manera:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exportar PowerPoint a HTML**

Este Java demuestra el proceso estándar de PowerPoint a HTML:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
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
```php

```


{{% alert title="Nota" color="warning" %}} 

Al usar este método para exportar PowerPoint a HTML, debido a la renderización SVG, no podrá aplicar estilos ni animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a vista de diapositivas HTML5**

**Aspose.Slides** le permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositivas. En este caso, al abrir el archivo HTML5 resultante en un navegador, verá la presentación en modo vista de diapositivas en una página web. 

Este código PHP demuestra el proceso de exportación de PowerPoint a vista de diapositivas HTML5:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Convertir presentaciones a documentos HTML5 con comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias o observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo “sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puede especificar fácilmente si incluir los comentarios de la presentación en el documento de salida. Para ello, debe especificar los parámetros de visualización de los comentarios en el método `getNotesCommentsLayouting` de la clase `Html5Options`.

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


El documento “output.html” se muestra en la imagen a continuación.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**¿Puedo controlar si se reproducen las animaciones de objetos y las transiciones de diapositiva en HTML5?**

Sí, HTML5 proporciona opciones separadas para habilitar o deshabilitar [animaciones de forma](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) y [transiciones de diapositiva](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/).

**¿Se admiten los comentarios en la salida y dónde pueden situarse respecto a la diapositiva?**

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante la [configuración de diseño](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) para notas y comentarios.

**¿Puedo omitir enlaces que invocan JavaScript por motivos de seguridad o CSP?**

Sí, existe una [configuración](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) que permite omitir hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.