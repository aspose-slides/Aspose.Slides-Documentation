---
title: Fondo de Presentación
type: docs
weight: 20
url: /es/php-java/presentation-background/
keywords: "fondo de PowerPoint, establecer fondo"
description: "Establecer fondo en la presentación de PowerPoint"
---

Los colores sólidos, colores en degradado e imágenes se utilizan a menudo como imágenes de fondo para las diapositivas. Puedes establecer el fondo tanto para una **diapositiva normal** (diapositiva única) como para una **diapositiva maestra** (varias diapositivas a la vez).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Establecer Color Sólido como Fondo para Diapositiva Normal**

Aspose.Slides te permite establecer un color sólido como fondo para una diapositiva específica en una presentación (incluso si esa presentación contiene una diapositiva maestra). El cambio de fondo afecta solo a la diapositiva seleccionada.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) para la diapositiva a `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) para el fondo de la diapositiva a `Solid`.
4. Usa la propiedad [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) expuesta por [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código PHP te muestra cómo establecer un color sólido (azul) como fondo para una diapositiva normal:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Establece el color de fondo para el primer ISlide a Azul
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Escribe la presentación en el disco
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Color Sólido como Fondo para Diapositiva Maestra**

Aspose.Slides te permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que contiene y controla los ajustes de formato para todas las diapositivas. Por lo tanto, cuando seleccionas un color sólido como fondo para la diapositiva maestra, ese nuevo fondo se utilizará para todas las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) para la diapositiva maestra (`Masters`) a `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) para el fondo de la diapositiva maestra a `Solid`.
4. Usa la propiedad [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) expuesta por [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código PHP te muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra en una presentación:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Establece el color de fondo para el Master ISlide a Verde Bosque
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Escribe la presentación en el disco
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Color en Degradado como Fondo para Diapositiva**

Un degradado es un efecto gráfico basado en un cambio gradual de color. Los colores en degradado, cuando se usan como fondos para diapositivas, hacen que las presentaciones se vean artísticas y profesionales. Aspose.Slides te permite establecer un color en degradado como fondo para las diapositivas en las presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) para la diapositiva a `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) para el fondo de la diapositiva maestra a `Gradient`.
4. Usa la propiedad [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) expuesta por [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para especificar tu configuración de degradado preferida.
5. Guarda la presentación modificada.

Este código PHP te muestra cómo establecer un color en degradado como fondo para una diapositiva:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Aplica efecto de degradado al fondo
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # Escribe la presentación en el disco
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Imagen como Fondo para Diapositiva**

Además de colores sólidos y colores en degradado, Aspose.Slides también te permite establecer imágenes como fondo para las diapositivas en las presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) para la diapositiva a `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) para el fondo de la diapositiva maestra a `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Agrega la imagen a la colección de imágenes de la presentación.
6. Usa la propiedad [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) expuesta por [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para establecer la imagen como fondo.
7. Guarda la presentación modificada.

Este código PHP te muestra cómo establecer una imagen como fondo para una diapositiva:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Establece condiciones para la imagen de fondo
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Carga la imagen
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega imagen a la colección de imágenes de la presentación
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # Escribe la presentación en el disco
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Cambiar la Transparencia de la Imagen de Fondo**

Puede que desees ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva resalte. Este código PHP te muestra cómo cambiar la transparencia para una imagen de fondo de diapositiva:

```php
  $transparencyValue = 30; // por ejemplo

  # Obtiene una colección de operaciones de transformación de imagen
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # Encuentra un efecto de transparencia con porcentaje fijo.
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # Establece el nuevo valor de transparencia.
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **Obtener Valor del Fondo de Diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) para permitirte obtener los valores efectivos de los fondos de diapositivas. Esta interfaz contiene información sobre el [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) efectivo y el [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Usando la propiedad [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) de la clase [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/), puedes obtener el valor efectivo para un fondo de diapositiva.

Este código PHP te muestra cómo obtener el valor de fondo efectivo de una diapositiva:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("Color de relleno: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("Tipo de relleno: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```