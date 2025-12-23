---
title: Combinar presentaciones de forma eficiente en PHP
linktitle: Combinar presentaciones
type: docs
weight: 40
url: /es/php-java/merge-presentation/
keywords:
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- PHP
- Aspose.Slides
description: "Fusiona sin esfuerzo presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para PHP via Java, optimizando tu flujo de trabajo."
---

## **Fusión de presentaciones**

Cuando combina una presentación con otra, está combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), sin embargo, le permite combinar presentaciones de diferentes maneras. Puede combinar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos.

**Ver también**

[Clonar diapositivas](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Qué se puede combinar**

Con Aspose.Slides, usted puede combinar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Note" color="warning" %}} 

Además de presentaciones, Aspose.Slides le permite combinar otros archivos:

* [Imágenes](https://products.aspose.com/slides/php-java/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/), [JPG a PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de fusión**

Puede aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para combinar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--), por lo que puede llamar al método `AddClone` desde la presentación a la que desea combinar diapositivas.

El método `AddClone` devuelve un objeto `ISlide`, que es una copia de la diapositiva original. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puede realizar cambios en las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparse de que las presentaciones de origen se vean afectadas. 

## **Combinar presentaciones** 

Aspose.Slides proporciona el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) que le permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados).

Este código PHP le muestra cómo combinar presentaciones:
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


## **Combinar presentaciones con una diapositiva maestra** 

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) que le permite combinar diapositivas aplicando una plantilla de presentación maestra de diapositivas. De esta forma, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida.

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

El diseño de diapositiva para la diapositiva maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` se establece en true, se utiliza el diseño de la diapositiva de origen. De lo contrario, se lanzará [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, use el método [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) en su lugar al combinar.

## **Combinar diapositivas específicas de presentaciones** 

Combinar diapositivas específicas de varias presentaciones es útil para crear paquetes de diapositivas personalizados. Aspose.Slides for PHP via Java le permite seleccionar e importar solo las diapositivas que necesita. La API conserva el formato, el diseño y la apariencia de las diapositivas originales.

El siguiente código PHP crea una nueva presentación, agrega diapositivas de título de dos presentaciones diferentes y guarda el resultado en un archivo:
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


## **Combinar presentaciones con un diseño de diapositiva** 

Este código PHP le muestra cómo combinar diapositivas de presentaciones aplicando su diseño de diapositiva preferido para obtener una presentación de salida:
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


## **Combinar presentaciones con diferentes tamaños de diapositiva** 

{{% alert title="Note" color="warning" %}} 

No se pueden combinar presentaciones con diferentes tamaños de diapositiva. 

{{% /alert %}}

Para combinar 2 presentaciones con diferentes tamaños de diapositiva, debe cambiar el tamaño de una de las presentaciones para que coincida con el tamaño de la otra presentación. 

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


## **Combinar diapositivas en una sección de presentación** 

Este código PHP le muestra cómo combinar una diapositiva específica en una sección de una presentación:
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


La diapositiva se agrega al final de la sección. 

## **Ver también**


Aspose ofrece un [Creador de collages gratuito en línea](https://products.aspose.app/slides/collage). Con este servicio en línea, puede combinar imágenes [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid) y más.

Visite el [Combínador gratuito en línea de Aspose](https://products.aspose.app/slides/merger). Le permite combinar presentaciones de PowerPoint en el mismo formato (por ejemplo, PPT a PPT, PPTX a PPTX) o entre diferentes formatos (por ejemplo, PPT a PPTX, PPTX a ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **Preguntas frecuentes**

**¿Hay limitaciones en la cantidad de diapositivas al combinar presentaciones?**

No hay limitaciones estrictas. Aspose.Slides puede manejar archivos grandes, pero el rendimiento depende del tamaño y de los recursos del sistema. Para presentaciones muy grandes, se recomienda usar una JVM de 64 bits y asignar suficiente memoria heap.

**¿Puedo combinar presentaciones con video o audio incrustados?**

Sí, Aspose.Slides conserva el contenido multimedia incrustado en las diapositivas, pero la presentación final puede volverse significativamente más grande.

**¿Se preservarán las fuentes al combinar presentaciones?**

Sí. Las fuentes utilizadas en las presentaciones de origen se conservan en el archivo de salida, siempre que estén instaladas en el sistema o [incrustadas](/slides/es/php-java/embedded-font/).