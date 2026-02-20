---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/php-java/examples/elements/layout-slide/
keywords:
- diapositiva de diseño
- añadir diapositiva de diseño
- acceder a diapositiva de diseño
- eliminar diapositiva de diseño
- diapositiva de diseño sin usar
- clonar diapositiva de diseño
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Utilice PHP para gestionar diapositivas de diseño con Aspose.Slides: crear, aplicar, clonar, renombrar y personalizar marcadores de posición y temas en presentaciones para PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con **Layout Slides** en Aspose.Slides para PHP a través de Java. Una diapositiva de diseño define el diseño y formato heredados por las diapositivas normales. Puede agregar, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las no utilizadas para reducir el tamaño de la presentación.

## **Añadir una diapositiva de diseño**

Puede crear una diapositiva de diseño personalizada para definir un formato reutilizable. Por ejemplo, podría añadir un cuadro de texto que aparezca en todas las diapositivas que usen este diseño.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Crear una diapositiva de diseño con un tipo de diseño en blanco y un nombre personalizado.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puede definir los elementos comunes una vez y reutilizarlos en muchas diapositivas.

> 💡 **Tip 2:** Cuando añada formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrarán automáticamente ese contenido compartido.  
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Diapositivas heredando contenido de diseño](layout-slide-result.png)


## **Acceder a una diapositiva de diseño**

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (p. ej., `Blank`, `Title`, `SectionHeader`, etc.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Acceder por índice.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Acceder por tipo de diseño.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una diapositiva de diseño**

Puede eliminar una diapositiva de diseño específica si ya no es necesaria.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Obtener una diapositiva de diseño por tipo y eliminarla.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar diapositivas de diseño no usadas**

Para reducir el tamaño de la presentación, es posible que desee eliminar las diapositivas de diseño que no son usadas por ninguna diapositiva normal.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Elimina automáticamente todas las diapositivas de diseño que no están referenciadas por ninguna diapositiva.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clonar una diapositiva de diseño**

Puede duplicar una diapositiva de diseño mediante el método `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Obtener una diapositiva de diseño existente por tipo.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Clonar la diapositiva de diseño al final de la colección de diapositivas de diseño.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Summary:** Las diapositivas de diseño son herramientas potentes para gestionar un formato coherente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de las diapositivas de diseño.