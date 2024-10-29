---
title: Exportar a HTML5
type: docs
weight: 40
url: /es/php-java/export-to-html5/
keywords:
- PowerPoint a HTML
- diapositivas a HTML
- HTML5
- exportación HTML
- exportar presentación
- convertir presentación
- convertir diapositivas
- PHP
- Aspose.Slides para PHP a través de Java
description: "Exportar PowerPoint a HTML5 en PHP"
---

{{% alert title="Info" color="info" %}}

En [Aspose.Slides 21.9](/slides/es/php-java/aspose-slides-for-java-21-9-release-notes/), implementamos soporte para la exportación a HTML5.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí permite convertir PowerPoint a HTML sin extensiones web o dependencias. De esta manera, utilizando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y los atributos resultantes de HTML, CSS, JavaScript y animación. 

## **Exportar PowerPoint a HTML5**

Este código PHP muestra cómo exportar una presentación a HTML5 sin extensiones web y dependencias:

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

En este caso, obtienes HTML limpio. 

{{% /alert %}}

Puedes especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:

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

En este caso, el contenido de la presentación se genera a través de SVG en una forma como esta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> EL CONTENIDO DE LA DIAPOSITIVA VA AQUÍ </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Nota" color="warning" %}} 

Cuando usas este método para exportar PowerPoint a HTML, debido al renderizado SVG, no podrás aplicar estilos o animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a HTML5 Vista de Diapositivas**

**Aspose.Slides** te permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en un modo de vista de diapositivas. En este caso, cuando abres el archivo HTML5 resultante en un navegador, ves la presentación en modo de vista de diapositivas en una página web. 

Este código PHP demuestra el proceso de exportación de PowerPoint a HTML5 Vista de Diapositivas:

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

## Convertir una Presentación a un Documento HTML5 con Comentarios

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios sobre las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden agregar sus sugerencias o comentarios a elementos de diapositivas específicos sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita seguir quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Cuando conviertes una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si incluir comentarios de la presentación en el documento de salida. Para hacer esto, necesitas especificar los parámetros de visualización para los comentarios en el método `getNotesCommentsLayouting` de la clase `Html5Options`.

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con comentarios mostrados a la derecha de las diapositivas.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)