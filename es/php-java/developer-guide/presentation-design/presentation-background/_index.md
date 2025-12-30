---
title: Gestionar fondos de presentación en PHP
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/php-java/presentation-background/
keywords:
- fondo de presentación
- fondo de diapositiva
- color sólido
- color degradado
- fondo de imagen
- transparencia del fondo
- propiedades del fondo
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprende a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para PHP mediante Java, con consejos de código para mejorar tus presentaciones."
---

## **Visión general**

Los colores sólidos, los degradados y las imágenes se utilizan habitualmente como fondos de diapositiva. Puedes establecer el fondo para una **diapositiva normal** (una sola diapositiva) o para una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![Fondo de PowerPoint](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides permite establecer un color sólido como fondo de una diapositiva específica en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica únicamente a la diapositiva seleccionada.

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase.
2. Establece el [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositiva en `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) del fondo de la diapositiva en `Solid`.
4. Utiliza el método [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) en [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para especificar el color de fondo sólido.
5. Guarda la presentación modificada.

El siguiente ejemplo en PHP muestra cómo establecer un color azul sólido como fondo de una diapositiva normal:
```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Establecer el color de fondo de la diapositiva a azul.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Guardar la presentación en disco.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Establecer un fondo de color sólido para una diapositiva maestra**

Aspose.Slides permite establecer un color sólido como fondo de la diapositiva maestra en una presentación. La diapositiva maestra actúa como plantilla que controla el formato de todas las diapositivas, de modo que, al elegir un color sólido para el fondo de la diapositiva maestra, se aplica a cada diapositiva.

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase.
2. Establece el [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `getMasters`) en `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) del fondo de la diapositiva maestra en `Solid`.
4. Utiliza el método [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) para especificar el color de fondo sólido.
5. Guarda la presentación modificada.

El siguiente ejemplo en PHP muestra cómo establecer un color verde sólido como fondo de una diapositiva maestra:
```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Establecer el color de fondo de la diapositiva maestra a verde bosque.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Guardar la presentación en disco.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se utiliza como fondo de diapositiva, los degradados pueden hacer que las presentaciones parezcan más artísticas y profesionales. Aspose.Slides permite establecer un color degradado como fondo de diapositivas.

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase.
2. Establece el [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositiva en `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) del fondo de la diapositiva en `Gradient`.
4. Utiliza el método [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) en [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para configurar los ajustes de degradado que prefieras.
5. Guarda la presentación modificada.

El siguiente ejemplo en PHP muestra cómo establecer un color degradado como fondo de una diapositiva:
```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aplicar un efecto degradado al fondo.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Guardar la presentación en disco.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides permite usar imágenes como fondos de diapositiva.

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase.
2. Establece el [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositiva en `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) del fondo de la diapositiva en `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Añade la imagen a la colección de imágenes de la presentación.
6. Utiliza el método [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) en [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarda la presentación modificada.

El siguiente ejemplo en PHP muestra cómo establecer una imagen como fondo de una diapositiva:
```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Establecer propiedades de la imagen de fondo.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Cargar la imagen.
    $image = Images::fromFile("Tulips.jpg");
    // Añadir la imagen a la colección de imágenes de la presentación.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Guardar la presentación en disco.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar sus propiedades de teselado:
```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Establecer la imagen utilizada para el relleno de fondo.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Establecer el modo de relleno de imagen a Mosaico y ajustar las propiedades del mosaico.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}

Leer más: [**Tile Picture As Texture**](/slides/es/php-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Puede que necesites ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la misma destaque. El siguiente código PHP muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:
```php
$transparencyValue = 30; // Por ejemplo.

// Obtener la colección de operaciones de transformación de imagen.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Buscar un efecto de transparencia de porcentaje fijo existente.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Establecer el nuevo valor de transparencia.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la clase `BackgroundEffectiveData` para recuperar los valores efectivos del fondo de una diapositiva. Esta clase expone el [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) y el [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) efectivos.

Utilizando el método `getBackground` de la clase [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/), puedes obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en PHP muestra cómo obtener el valor efectivo del fondo de una diapositiva:
```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Recuperar el fondo efectivo, teniendo en cuenta master, layout y tema.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**¿Puedo restablecer un fondo personalizado y restaurar el fondo del tema/disposición?**

Sí. Elimina el relleno personalizado de la diapositiva y el fondo se heredará nuevamente de la diapositiva de [disposición](/slides/es/php-java/slide-layout/)/[maestra](/slides/es/php-java/slide-master/) correspondiente (es decir, del [fondo del tema](/slides/es/php-java/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más adelante?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda de la [disposición](/slides/es/php-java/slide-layout/)/[maestra](/slides/es/php-java/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/php-java/presentation-theme/).