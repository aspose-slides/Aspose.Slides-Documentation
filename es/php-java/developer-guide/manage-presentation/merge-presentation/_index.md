---
title: Fusionar presentaciones de forma eficiente en PHP
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/php-java/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- PHP
- Aspose.Slides
description: "Fusiona sin esfuerzo presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para PHP mediante Java, optimizando tu flujo de trabajo."
---

## **Fusión de Presentaciones**

Cuando fusionas una presentación con otra, estás combinando sus diapositivas en una única presentación para obtener un solo archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), sin embargo, permite fusionar presentaciones de diferentes maneras. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparte por la pérdida de calidad o datos.

**See also**

[Clone Slides](/slides/es/php-java/clone-slides/).

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puedes fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Note" color="warning" %}} 

Además de presentaciones, Aspose.Slides permite fusionar otros archivos:

* [Images](https://products.aspose.com/slides/php-java/merger/image-to-image/), como [JPG to JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) o [PNG to PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Documents, como [PDF to PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) o [HTML to HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Y dos archivos diferentes, como [image to PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) o [JPG to PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) o [TIFF to PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de fusión**

Puedes aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona los métodos [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) (de la clase [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)). Hay varias implementaciones de los métodos `addClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección de `slide`, por lo que puedes invocar un método `addClone` desde la presentación a la que deseas fusionar diapositivas.

El método `addClone` devuelve un objeto `Slide`, que es una copia de la diapositiva origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puedes modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparte de que las presentaciones origen se vean afectadas. 

## **Fusionar presentaciones** 

Aspose.Slides proporciona el método [addClone(Slide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) que permite combinar diapositivas manteniendo sus diseños y estilos (parámetros predeterminados).

Este código PHP muestra cómo fusionar presentaciones:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


## **Fusionar presentaciones con una diapositiva maestra**

Aspose.Slides proporciona el método [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) que permite combinar diapositivas aplicando una plantilla maestra de presentación. De este modo, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida.

Este código demuestra la operación descrita:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 

El diseño de diapositiva para la diapositiva maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `addClone` está establecido a true, se utiliza el diseño de la diapositiva origen. De lo contrario, se lanzará [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza el método [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) al fusionar.

## **Fusionar diapositivas específicas de presentaciones**

Fusionar diapositivas específicas de varias presentaciones es útil para crear conjuntos de diapositivas personalizados. Aspose.Slides para PHP mediante Java permite seleccionar e importar solo las diapositivas que necesitas. La API preserva el formato, diseño y estilo de las diapositivas originales.

El siguiente código PHP crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **Fusionar presentaciones con un diseño de diapositiva**

Este código PHP muestra cómo combinar diapositivas de presentaciones aplicando el diseño de diapositiva que prefieras para obtener una única presentación de salida:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


## **Fusionar presentaciones con diferentes tamaños de diapositiva**

{{% alert title="Note" color="warning" %}} 

No puedes fusionar presentaciones con diferentes tamaños de diapositiva. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositiva, debes redimensionar una de ellas para que su tamaño coincida con el de la otra presentación. 

Este código de ejemplo demuestra la operación descrita:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


## **Fusionar diapositivas a una sección de presentación**

Este código PHP muestra cómo fusionar una diapositiva específica en una sección de una presentación:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


La diapositiva se añade al final de la sección. 

## **Véase también**


Aspose ofrece un Creador de Collage en línea GRATUITO. Con este servicio en línea, puedes combinar imágenes JPG a JPG o PNG a PNG, crear cuadrículas de fotos y más.

Echa un vistazo al Fusionador en línea GRATUITO de Aspose. Permite fusionar presentaciones PowerPoint en el mismo formato (p. ej., PPT a PPT, PPTX a PPTX) o entre diferentes formatos (p. ej., PPT a PPTX, PPTX a ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **Preguntas frecuentes**

**¿Existe alguna limitación en el número de diapositivas al fusionar presentaciones?**

No hay limitaciones estrictas. Aspose.Slides puede manejar archivos grandes, pero el rendimiento depende del tamaño y los recursos del sistema. Para presentaciones muy grandes, se recomienda usar una JVM de 64 bits y asignar suficiente memoria heap.

**¿Puedo fusionar presentaciones con video o audio incrustados?**

Sí, Aspose.Slides conserva el contenido multimedia incrustado en las diapositivas, aunque la presentación final puede volverse significativamente más grande.

**¿Se conservarán las fuentes al fusionar presentaciones?**

Sí. Las fuentes utilizadas en las presentaciones origen se conservan en el archivo de salida, siempre que estén instaladas en el sistema o [incrustadas](/slides/es/php-java/embedded-font/).