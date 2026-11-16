---
title: Recuperar y actualizar propiedades de vista de la presentación en PHP
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/php-java/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajuste del divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Utilice Aspose.Slides para PHP a través de Java para configurar la disposición de la vista normal, el zoom de diapositivas y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva se muestra entre un panel lateral para miniaturas o un esquema y un panel de notas debajo. Aspose.Slides para PHP a través de Java expone las preferencias de edición guardadas de la presentación mediante [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Estos incluyen la disposición de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Acerca de NormalViewProperties**

Utilice [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) para acceder a la clase [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) controla si aparecen iconos junto a los títulos de diapositiva en el esquema. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo reduce. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) indica una preferencia por mostrar un solo panel en la ventana completa.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) controla el divisor entre el panel lateral y la diapositiva. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) controla el divisor sobre el panel de notas. Ambos aceptan un valor de [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` o `Restored`.

## **Acerca de restaurar NormalViewProperties**

Cuando se restaura un divisor, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) proporciona el tamaño guardado del panel lateral y [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) proporciona el tamaño guardado del área superior de la diapositiva. Ambos exponen [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Su método [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) acepta un porcentaje de 0 a 100, y [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) controla si el editor ajusta el tamaño cuando la ventana se redimensiona.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece el tamaño devuelto por [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) al 80% con el ajuste automático activado, y maximiza el divisor vertical. También llama a [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) para mostrar iconos en la vista de esquema.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el valor de zoom predeterminado**

Los métodos [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) y [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de la exportación de imágenes.

Este ejemplo abre una presentación existente y llama a [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) para ajustar la diapositiva a la ventana de edición. Para la página de notas, desactiva el escalado automático y llama a [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) para establecer un zoom fijo del 80%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el espaciado de la cuadrícula**

El método `setGridSpacing` de [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) establece la distancia entre las líneas de cuadrícula de edición en toda la presentación. Recibe un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada estableciendo el intervalo a 18 puntos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La cuadrícula se repite a intervalos fijos. [Drawing guides](/slides/es/php-java/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambas son ayudas de edición y aparecen solo en los editores que las muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG las omiten.

## **Mostrar u ocultar comentarios al abrir una presentación**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) almacena una preferencia que los editores compatibles usan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También llama a [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) para que la copia se abra en la vista de diapositiva.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ocultar los comentarios preserva su texto, autores, posiciones, respuestas y estados. Para modificar los propios comentarios, consulte [Presentation Comments](/slides/es/php-java/presentation-comments/). La configuración de exportación controla si los comentarios aparecen en PDF, HTML, imágenes, notas o folletos.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula está oculta cuando vuelvo a abrir la presentación?**  
La presentación guarda el intervalo de la cuadrícula. Para verla, habilite la visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**  
No. Añadir, mover o eliminar una guía deja el intervalo de la cuadrícula sin cambios.

**¿Pueden diferentes secciones de una presentación tener distintas configuraciones de vista?**  
No. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) se aplica a toda la presentación.

**¿Puedo guardar distintas configuraciones de vista para diferentes usuarios?**  
El archivo almacena un único conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales de un usuario.

**¿Puedo guardar configuraciones de vista en una plantilla?**  
Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.