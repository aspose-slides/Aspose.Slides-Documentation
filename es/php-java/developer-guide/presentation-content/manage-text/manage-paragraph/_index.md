---
title: Administrar párrafos de texto de PowerPoint en PHP
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades de párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a crear y dar formato a párrafos, fragmentos, viñetas, listas numeradas, sangrías, contenido HTML e imágenes de párrafos con Aspose.Slides para PHP a través de Java."
---
## **Visión general**

Aspose.Slides para PHP a través de Java representa el texto como una jerarquía de marcos de texto, párrafos y fragmentos:

* [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) representa un párrafo en un marco de texto y proporciona acceso a sus fragmentos y al formato a nivel de párrafo.
* [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/) representa una ejecución de texto dentro de un párrafo. Cada fragmento puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varios fragmentos.

## **Crear y dar formato a párrafos**

### **Crear párrafos con múltiples porciones**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres fragmentos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Accede a la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape] rectangular a la diapositiva.
4. Accede al [TextFrame] de la forma.
5. Utiliza el párrafo predeterminado y añade dos objetos [Paragraph] más al marco de texto.
6. Añade suficientes objetos [Portion] para que cada párrafo contenga tres fragmentos. El párrafo predeterminado ya contiene una porción vacía.
7. Establece el texto de cada porción.
8. Aplica formato a nivel de carácter mediante [Portion::getPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getPortionFormat--).
9. Guarda la presentación modificada.

Este ejemplo en PHP implementa los pasos:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Crear listas con viñetas y numeradas**

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la lectura de elementos relacionados. En Aspose.Slides, la configuración de listas se define mediante [BulletFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/).

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Accede a la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape] a la diapositiva seleccionada.
4. Accede al [TextFrame] de la forma.
5. Elimina el párrafo predeterminado del marco de texto.
6. Crea un [Paragraph] para una viñeta de símbolo.
7. Establece [BulletFormat::setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType::Symbol](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/) y especifica el carácter de la viñeta.
8. Establece el texto del párrafo, la sangría, el color y la altura de la viñeta.
9. Añade el párrafo al marco de texto.
10. Crea un segundo párrafo y establece [BulletFormat::setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType::Numbered](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/).
11. Configura el estilo de viñeta numerada y añade el párrafo al marco de texto.
12. Guarda la presentación.

Este ejemplo en PHP crea una viñeta de símbolo y una viñeta numerada:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Utilizar viñetas con imagen**

Las viñetas con imagen permiten usar una imagen personalizada en lugar de un símbolo o número.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Accede a la diapositiva correspondiente mediante su índice.
3. Añade una [AutoShape] y accede a su [TextFrame].
4. Elimina el párrafo predeterminado del marco de texto.
5. Carga la imagen de la viñeta y añádela a la colección de imágenes de la presentación como [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/).
6. Crea un [Paragraph] y establece su texto.
7. Establece [BulletFormat::setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setType-int-) a [BulletType::Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/).
8. Asigna la imagen mediante [BulletFormat::getPicture](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#getPicture--) y establece la altura de la viñeta.
9. Añade el párrafo al marco de texto.
10. Guarda la presentación modificada.

Este ejemplo en PHP crea una viñeta con imagen:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Crear una lista multinivel**

Establece [ParagraphFormat::setDepth](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setDepth-short-) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Crea una [Presentation] y accede a una diapositiva.
2. Añade una [AutoShape] y elimina el párrafo predeterminado de su marco de texto.
3. Crea cuatro párrafos y configura sus símbolos de viñeta.
4. Establece sus valores de [ParagraphFormat::setDepth](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setDepth-short-) a `0`, `1`, `2` y `3`.
5. Añade los párrafos al marco de texto y guarda la presentación.

Este ejemplo en PHP crea una lista con viñetas de cuatro niveles:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Iniciar ítems de lista numerada con valores personalizados**

Utiliza [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) para establecer el número inicial que se muestra en un párrafo numerado.

1. Crea una [Presentation] y añade una [AutoShape] a una diapositiva.
2. Elimina el párrafo predeterminado del marco de texto de la forma.
3. Crea tres párrafos numerados.
4. Establece [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) a `2`, `3` y `7` para los respectivos párrafos.
5. Añade los párrafos al marco de texto y guarda la presentación.

Este ejemplo en PHP asigna un número de inicio personalizado a cada párrafo:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar el diseño de párrafos y propiedades de fin**

### **Establecer una sangría de primera línea**

Utiliza [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-) para controlar la sangría de la primera línea de un párrafo. Este método mueve solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de líneas permanece alineado al cuerpo del párrafo.

Utiliza [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) cuando necesites mover todo el párrafo. Usa [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-) cuando solo necesites mover la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-) para demostrar cómo la sangría de la primera línea afecta al diseño del párrafo.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Accede a la diapositiva objetivo.
3. Añade una [AutoShape] rectangular a la diapositiva.
4. Accede al [TextFrame] de la forma y elimina el párrafo predeterminado.
5. Crea varios párrafos y establece diferentes valores de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-) para ellos.
6. Añade los párrafos al marco de texto.
7. Guarda la presentación modificada.

Este código PHP muestra cómo establecer una sangría de párrafo:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría colgante**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crear este efecto se realiza con [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-). Pasa un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, pasa un valor positivo a `setMarginLeft` y un valor negativo a `setIndent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo en lugar de bajo el primer carácter de la primera línea.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Accede a la diapositiva objetivo.
3. Añade una [AutoShape] rectangular a la diapositiva.
4. Accede al [TextFrame] de la forma y elimina el párrafo predeterminado.
5. Crea párrafos y pasa un valor positivo a [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) para cada párrafo.
6. Pasa un valor negativo a [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setIndent-float-) para crear el efecto de sangría colgante.
7. Añade los párrafos al marco de texto.
8. Guarda la presentación modificada.

Este código PHP muestra cómo establecer una sangría colgante para un párrafo:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución al final del párrafo**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) controla el formato del signo de fin de párrafo. El siguiente ejemplo en PHP asigna un tamaño de fuente y una fuente latina al signo de fin del segundo párrafo:

1. Carga una [Presentation] y accede a una diapositiva.
2. Añade una [AutoShape] y elimina su párrafo predeterminado.
3. Crea dos párrafos y añade fragmentos de texto a ellos.
4. Crea un [PortionFormat] para el signo de fin del segundo párrafo.
5. Establece [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) y [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Asigna el formato con [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) y guarda la presentación.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Utiliza [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) para convertir marcado HTML en párrafos y fragmentos en un marco de texto.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Accede a una diapositiva y añade una [AutoShape].
3. Accede al [TextFrame] de la forma y elimina su párrafo predeterminado.
4. Lee el archivo HTML fuente.
5. Pasa la cadena HTML a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Guarda la presentación modificada.

Este ejemplo en PHP importa HTML en un marco de texto:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Exportar texto de párrafo a HTML**

Utiliza [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) para exportar un rango seleccionado de párrafos como HTML.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y carga la presentación deseada.
2. Accede a la diapositiva y encuentra la [AutoShape] que contiene el texto.
3. Accede al [TextFrame] de la forma.
4. Llama a [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) con el índice del párrafo inicial y el número de párrafos a exportar.
5. Escribe la cadena HTML devuelta en un archivo.

Este ejemplo en PHP exporta todos los párrafos del primer cuadro de texto:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Representar un párrafo como una imagen**

[Paragraph::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getImage--) representa directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/). Guarda el resultado en un archivo o flujo con [IImage::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/#save-java.lang.String-int-). No necesitas representar la forma contenedora ni recortar un mapa de bits manualmente.

[Paragraph::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getImage--) puede devolver `null` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no puede renderizarse. Comprueba el resultado antes de guardarlo y libera la imagen devuelta después de usarla.

#### **Representar un párrafo a escala predeterminada**

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo en PHP representa el segundo párrafo en una forma de texto normal a escala predeterminada y guarda la imagen devuelta en formato PNG. El bloque `finally` asegura que la imagen se libere correctamente.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

#### **Representar un párrafo en una celda de tabla con escalado**

Utiliza la sobrecarga de [Paragraph::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getImage-float-float-) que acepta los parámetros `$scaleX` y `$scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo en PHP crea una tabla, representa el párrafo en su primera celda al doble de su ancho y altura predeterminados, y guarda el resultado como una imagen PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones predeterminadas, lo que resulta en cuatro veces más píxeles. Los factores mayores suelen producir texto más nítido para ampliaciones o salida de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores por debajo de `1` generan imágenes más pequeñas con menos detalle. Usa factores iguales para conservar la proporción del párrafo; factores horizontales y verticales diferentes estiran la salida de forma independiente.

Representar una forma completa con [Shape::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getImage--) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen solo del párrafo, usa [Paragraph::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getImage--).

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establece [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setWrapText-byte-) para desactivar el ajuste de modo que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utiliza [Paragraph::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/#getRect--) para obtener el rectángulo delimitador del párrafo. [Portion::getRect](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getRect--) proporciona los límites de un fragmento individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/#setAlignment-int-) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de los fragmentos individuales.

**¿Puedo establecer el idioma de revisión para parte de un párrafo?**

Sí. Establece [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) para fragmentos individuales, de modo que un párrafo pueda contener texto en varios idiomas.