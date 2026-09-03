---
title: Gestionar cuadros de texto en presentaciones usando PHP
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/php-java/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear, identificar, dar formato y actualizar cuadros de texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java."
---
## **Introducción**

En Aspose.Slides para PHP a través de Java, el texto de una diapositiva se almacena en marcos de texto que pertenecen a formas. La clase [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) representa la forma con texto más común y expone su texto mediante el método [AutoShape::getTextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Todas las autoformas derivan de [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/), pero no todas las formas son una autoforma ni admiten un marco de texto. Al procesar una presentación existente, use `java_instanceof` para comprobar que una forma es una [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) antes de acceder a su texto.
{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada una autoforma a una diapositiva, añada texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Las coordenadas y dimensiones pasadas a [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/#addAutoShape) se miden en puntos. [AutoShape::addTextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/#addTextFrame) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice el método [AutoShape::isTextBox](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/#isTextBox) para determinar si una autoforma se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto autoformas con texto como autoformas puramente gráficas.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada autoforma en una presentación:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Una autoforma recién añadida no se considera un cuadro de texto hasta que contenga texto no vacío. Puede suministrar ese texto mediante [AutoShape::addTextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/#addTextFrame) o [TextFrame::setText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#setText). Añadir o asignar una cadena vacía deja que [AutoShape::isTextBox](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/#isTextBox) devuelva `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Las dos primeras llamadas imprimen `true`; las dos últimas imprimen `false`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) sin saber qué objeto de la presentación lo contiene. Utilice el método de solo lectura [TextFrame::getParentShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentShape) para volver a su [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) propietario.

Para un marco de texto propiedad de una autoforma u otra forma con texto, [TextFrame::getParentShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentShape) devuelve el propietario y [TextFrame::getParentCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentCell) devuelve `null`. Verifique el valor devuelto con `java_is_null` antes de acceder a él. Para identificar tanto los propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos SmartArt, consulte [Search and Replace Text](/slides/es/php-java/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

El método [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setColumnCount) divide el marco de texto en columnas, mientras que [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setColumnSpacing) establece el espacio entre columnas en puntos. Ambas configuraciones pertenecen a [TextFrameFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/) y pueden modificarse a través del marco de texto de un cuadro de texto existente. El texto se redistribuye entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee la configuración almacenada del archivo de salida:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Extraer texto de columnas individuales**

Utilice [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#splitTextByColumns) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por cada columna, en orden de lectura basado en columnas. Un marco de texto de una sola columna produce una matriz con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto sin formato; el formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer texto preservando su orden de lectura por columnas.
- Indexar o comparar el contenido de diapositivas con varias columnas.
- Exportar cada columna a un archivo separado, campo de base de datos u otro destino.
- Inspeccionar cómo se redistribuye el texto tras cambiar el recuento de columnas con [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setColumnCount), el espaciado con [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setColumnSpacing), la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) actual; no hace que el texto fluya automáticamente entre formas o cuadros de texto separados. La distribución de columnas puede depender de las fuentes disponibles y de otras configuraciones de diseño de texto, así que asegúrese de que las fuentes necesarias estén presentes cuando los resultados consistentes sean importantes.

El siguiente ejemplo carga una presentación, encuentra la primera autoforma de varias columnas con un marco de texto, lee su recuento de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Actualizar texto**

Para actualizar el texto en toda la presentación, recorra las diapositivas y las formas, seleccione autoformas y luego edite sus porciones de texto. Trabajar a nivel de porción le permite cambiar tanto el texto como el formato de caracteres.

El siguiente ejemplo reemplaza cada aparición de `years` por `months` en el texto de autoformas y pone en negrita cada porción afectada:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Este recorrido actualiza el texto solo en autoformas. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere recorrer las colecciones propias de esos objetos.

## **Agregar un cuadro de texto con hipervínculo**

Se puede asignar un hipervínculo a una porción de texto específica, de modo que solo ese texto actúe como enlace clicable. Use [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) para asociar la porción con una URL externa.

El siguiente ejemplo crea texto enlazado y lo guarda en una presentación:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [placeholder](/slides/es/php-java/manage-placeholder/) puede heredar su posición y formato de una [master slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) o [layout slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/). Un cuadro de texto normal es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando el diseño cambia.

**¿Cómo puedo reemplazar texto sin cambiar el texto en gráficos, tablas o SmartArt?**

Limite el recorrido a objetos [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objeto, por lo que no se modifican con ese bucle.