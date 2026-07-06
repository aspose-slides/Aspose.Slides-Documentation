---
title: Obtener los límites de la porción de texto en presentaciones con PHP
linktitle: Límites de Porción
type: docs
weight: 47
url: /es/php-java/portion-bounds/
keywords:
- límites de porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a recuperar los límites de una porción de texto en presentaciones de PowerPoint usando Aspose.Slides para PHP a través de Java."
---
## **Visión general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando es necesario obtener los límites de un fragmento de texto, aplicar formato solo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción mediante [Portion::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/getrect/). También muestra cómo obtener las coordenadas del inicio de una porción mediante [Portion::getCoordinates](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/getcoordinates/). Además, resalta escenarios comunes relacionados con las porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la porción, el párrafo, el marco de texto y la herencia del tema, y manejar casos en los que una fuente especificada no está disponible.

## **Obtener los límites de una porción de texto**

Utiliza [Portion::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/getrect/) para obtener el rectángulo delimitador de una porción de texto:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Obtener las coordenadas de una porción de texto**

Utiliza [Portion::getCoordinates](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/getcoordinates/) para obtener las coordenadas del inicio de una porción de texto:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un único párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/php-java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clickable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una porción y qué se toma de un párrafo o marco de texto?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/), Aspose.Slides la toma de la [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/). Si tampoco está establecida allí, Aspose.Slides utiliza el estilo del [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/es/php-java/aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una porción no está presente en la máquina o servidor de destino?**

Se aplican las [Reglas de sustitución de fuentes](/slides/es/php-java/font-selection-sequence/). El texto puede refluenciar: las métricas, la guionización y el ancho pueden cambiar, lo que afecta al posicionamiento preciso.

**¿Puedo establecer la transparencia o un degradado de relleno de texto específico de una porción independientemente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/) pueden diferir de los fragmentos adyacentes.