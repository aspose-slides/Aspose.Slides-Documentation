---
title: Fusionar Presentación
type: docs
weight: 40
url: /php-java/merge-presentation/
keywords: "Fusionar PowerPoint, PPTX, PPT, combinar PowerPoint, fusionar presentación, combinar presentación, Java"
description: "Fusionar o combinar presentación de PowerPoint"
---


{{% alert  title="Consejo" color="primary" %}} 

Es posible que desee consultar la **aplicación Merger en línea gratuita de Aspose** [Merger app](https://products.aspose.app/slides/merger). Permite a las personas fusionar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y fusionar presentaciones en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusión de Presentaciones**

Cuando fusiona una presentación con otra, está combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo.

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera.

[**Aspose.Slides para PHP a través de Java**](https://products.aspose.com/slides/php-java/), sin embargo, le permite fusionar presentaciones de diferentes maneras. Puede fusionar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc., sin tener que preocuparse por la pérdida de calidad o datos.

**Ver también**

[Clonar Diapositivas](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Qué se Puede Fusionar**

Con Aspose.Slides, puede fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Nota" color="warning" %}} 

Además de presentaciones, Aspose.Slides le permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/php-java/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Y dos archivos diferentes, como [imagen a PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de Fusión**

Puede aplicar opciones que determinan si

* cada diapositiva en la presentación de salida retiene un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (del interfaz [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) , por lo que puede llamar a un método `AddClone` desde la presentación a la que desea fusionar las diapositivas.

El método `AddClone` devuelve un objeto `ISlide`, que es un clon de la diapositiva fuente. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puede realizar cambios en las diapositivas resultantes (por ejemplo, aplicar estilos o opciones de formato o diseños) sin preocuparse de que las presentaciones fuente se vean afectadas.

## **Fusionar Presentaciones** 

Aspose.Slides proporciona el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) que le permite combinar diapositivas mientras las diapositivas retienen sus diseños y estilos (parámetros por defecto).

Este código PHP le muestra cómo fusionar presentaciones:

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

## **Fusionar Presentaciones con Patrón de Diapositivas**

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) que le permite combinar diapositivas mientras aplica una plantilla de presentación de patrón de diapositivas. De esta manera, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida.

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

{{% alert title="Nota" color="warning" %}} 

El diseño de la diapositiva para el patrón de diapositivas se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` se establece en verdadero, se utiliza el diseño de la diapositiva fuente. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utilice el método [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) en su lugar al fusionar.

## **Fusionar Diapositivas Específicas de Presentaciones**

Este código PHP le muestra cómo seleccionar y combinar diapositivas específicas de diferentes presentaciones para obtener una presentación de salida:

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

## **Fusionar Presentaciones Con Diseño de Diapositivas**

Este código PHP le muestra cómo combinar diapositivas de presentaciones aplicando su diseño de diapositivas preferido a ellas para obtener una presentación de salida:

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

## **Fusionar Presentaciones Con Tamaños de Diapositiva Diferentes**

{{% alert title="Nota" color="warning" %}} 

No puede fusionar presentaciones con tamaños de diapositiva diferentes. 

{{% /alert %}}

Para fusionar 2 presentaciones con tamaños de diapositiva diferentes, debe cambiar el tamaño de una de las presentaciones para que su tamaño coincida con el de la otra presentación.

Este código de muestra demuestra la operación descrita:

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

## **Fusionar Diapositivas a una Sección de Presentación**

Este código PHP le muestra cómo fusionar una diapositiva específica a una sección en una presentación:

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

{{% alert title="Consejo" color="primary" %}}

Aspose ofrece una [aplicación web Collage GRATUITA](https://products.aspose.app/slides/collage). Usando este servicio en línea, puede fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y mucho más. 

{{% /alert %}}