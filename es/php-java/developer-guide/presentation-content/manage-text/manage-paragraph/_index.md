---
title: Gestionar párrafos de texto de PowerPoint en PHP
linktitle: Gestionar párrafo
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
  - propiedades del párrafo
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
description: "Aprenda a crear y dar formato a párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides para PHP vía Java."
---
## **Visión general**

Aspose.Slides for PHP via Java representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) representa un párrafo dentro de un marco de texto y proporciona acceso a sus porciones y al formato a nivel de párrafo.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y demás formatos mediante el uso de varias porciones.

## **Crear y dar formato a los párrafos**

Cree párrafos en el marco de texto de una forma y utilice porciones para dar formato a ejecuciones de texto individuales. Esta sección muestra cómo combinar varias porciones dentro de cada párrafo y aplicar distintos colores, tamaños de fuente y estilos.

### **Crear párrafos con varias porciones**

El siguiente ejemplo en PHP crea tres párrafos, cada uno con tres ejecuciones de texto en la colección devuelta por [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions). Reutiliza el párrafo predeterminado y su porción vacía, y luego añade los párrafos y porciones restantes. El formato se aplica mediante [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat): la primera porción de cada párrafo es roja, en negrita y de 15 puntos; la segunda es azul, en cursiva y de 18 puntos. La tercera porción conserva su formato predeterminado:

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

## **Crear listas con viñetas y numeración**

Organice el texto de los párrafos en listas con símbolos, números o imágenes personalizadas. Los ejemplos de esta sección cubren el formato de viñetas, listas multinivel y números de inicio personalizados.

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la lectura de elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

Este ejemplo en PHP añade una viñeta de símbolo y un elemento numerado al mismo marco de texto. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) selecciona el tipo de viñeta, mientras que [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) proporciona el símbolo y [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) selecciona el estilo de numeración. Ambos elementos utilizan viñetas negras con una altura del 100 por ciento y una sangría de párrafo de 25 puntos:

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

### **Usar viñetas de imagen**

Las viñetas de imagen le permiten usar una imagen personalizada en lugar de un símbolo o número.

Este ejemplo en PHP añade una imagen a la colección de imágenes de la presentación como un [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) y la utiliza como viñeta de párrafo. Llama a [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) para usar una viñeta de imagen y asigna la imagen mediante [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) se establece al 100 por ciento para dimensionar la viñeta en relación con el texto del párrafo:

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

Establezca [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

Este ejemplo en PHP asigna valores de [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) de 0 a 3 a cuatro párrafos, creando una jerarquía dentro de un mismo marco de texto. Cada párrafo utiliza una viñeta de símbolo, con [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) alternando entre una viñeta circular y un guion para distinguir los niveles adyacentes:

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

### **Iniciar elementos de lista numerada con valores personalizados**

Utilice [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) para establecer el número inicial que se muestra en un párrafo numerado.

Este ejemplo en PHP establece [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) para usar numeración en tres párrafos y asigna valores de [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) de 2, 3 y 7. El valor de inicio se configura por separado para cada párrafo, permitiendo que los números mostrados omitan valores:

```php
use aspose\slides\BulletType;
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

## **Controlar la distribución del párrafo y sus propiedades finales**

Ajuste los márgenes y sangrías del párrafo para controlar la posición de la primera línea y de las líneas continuas. También puede dar formato al signo de fin de párrafo de forma independiente del texto visible.

### **Establecer sangría de primera línea**

Utilice el método [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) para controlar la sangría de la primera línea de un párrafo. Esta configuración desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo mueve la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Use [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) cuando necesite mover todo el párrafo. Use [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) cuando necesite mover solo la primera línea.

El siguiente ejemplo asigna a tres párrafos el mismo [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) de 20 puntos y valores de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) de 0, 20 y 40 puntos. Las primeras líneas empiezan en desplazamientos progresivamente mayores, mientras que las líneas continuas conservan el mismo margen izquierdo:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Establecer sangría colgante**

Una sangría colgante es una disposición de párrafo en la que la primera línea comienza a la izquierda de las líneas restantes. En Aspose.Slides, crea este efecto con la propiedad [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent). Establezca `Indent` a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un valor positivo en `MarginLeft` y un valor negativo en `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas continuas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

El siguiente ejemplo en PHP combina valores de [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) de 40 y 60 puntos con valores de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) de -20 y -30 puntos. En cada párrafo, la primera línea comienza a la izquierda de las líneas continuas; el segundo párrafo tiene una sangría colgante más profunda:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Establecer propiedades del final del párrafo**

El método [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) controla el formato del signo de fin de párrafo. El siguiente ejemplo crea un [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) con [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) establecido en 48 puntos y [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) establecido en Times New Roman. Asigna este formato al signo de fin del segundo párrafo, dejando sin cambios las porciones de texto visibles:

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

## **Contar líneas renderizadas**

Para reglas de párrafo que afectan el ajuste automático y la puntuación al final de la línea, consulte [Control Line Breaking](/slides/es/php-java/text-formatting/#control-line-breaking) y [Control Hanging Punctuation](/slides/es/php-java/text-formatting/#control-hanging-punctuation).

Utilice [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) para contar las líneas ocupadas por un párrafo después del diseño del texto, incluido el ajuste automático. Esto es útil al comprobar la longitud del texto y el diseño en plantillas de presentación.

Un párrafo es un elemento en [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) y puede ocupar varias líneas renderizadas. Un salto de línea explícito dentro de un párrafo fuerza una nueva línea sin crear otro párrafo. El ajuste automático crea líneas según el ancho disponible sin insertar saltos de línea explícitos en el texto. Por lo tanto, contar párrafos o caracteres de salto de línea no proporciona el recuento de líneas renderizadas.

El siguiente ejemplo crea una forma de texto, cuenta sus líneas, estrecha la forma y luego reemplaza el texto por una cadena más corta. El ejemplo habilita el ajuste mediante [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) y deshabilita el autofit con [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) para que el ancho de la forma controle el ajuste sin reducir automáticamente el texto ni redimensionar la forma. Cada medida usa [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount). Las dimensiones de la forma están en puntos. Finalmente, el ejemplo añade otro párrafo y suma los recuentos de líneas de todo el marco de texto.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Con este texto y estas dimensiones, estrechar la forma aumenta el recuento de líneas, mientras que sustituir el texto por la cadena corta lo reduce. Los recuentos exactos pueden variar según la disponibilidad y sustitución de fuentes, el tamaño de fuente, márgenes, sangría, ajuste y configuraciones de autofit. Use las fuentes y opciones de diseño previstas para el entorno de destino al comprobar una plantilla.

El recuento de líneas por sí solo no determina si el texto se desborda del contenedor. También importan la altura disponible, la altura de línea, el espaciado de párrafo y línea, y el comportamiento de autofit; incluso una sola línea puede superar el ancho disponible cuando el ajuste está desactivado.

## **Importar y exportar contenido de párrafos**

Utilice HTML para introducir texto en una presentación o exportar párrafos existentes para usarlos fuera de ella. Esta sección también muestra cómo renderizar párrafos individuales como imágenes, incluidos los párrafos en celdas de tabla.

### **Importar texto HTML en párrafos**

Use [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) para convertir marcado HTML en párrafos y porciones dentro de un marco de texto.

Este ejemplo en PHP lee HTML de un archivo y pasa el marcado a [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml). Limpia el párrafo predeterminado del marco de texto para que el marco contenga solo el contenido importado. La forma rectangular deja un margen de 10 puntos en cada lado de la diapositiva:

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

### **Exportar texto del párrafo a HTML**

Use [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) para exportar un rango seleccionado de párrafos como HTML. Cuando reutilice el texto de una presentación en un sitio web, puede querer conservar el énfasis local sin trasladar la fuente, el tamaño o los estilos de cuadro de texto de la presentación. Establezca [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) para controlar hasta dónde sigue el exportador la herencia de formato.

Descargue [la presentación de ejemplo](text-inheritance.pptx) y colóquela en el directorio de trabajo de la aplicación. Su primera diapositiva contiene una forma de texto con el texto “Inherited text; explicit red 18pt”. La entrada utiliza deliberadamente varios niveles de formato:

- El estilo de texto predeterminado de la presentación suministra Calibri y un tamaño de 28 pt.
- El estilo de texto de primer nivel del marco de texto suministra texto azul e itálica.
- El párrafo establece explícitamente texto en negrita.
- La segunda porción, “explicit red 18pt”, establece explícitamente texto rojo y un tamaño de 18 pt.

El siguiente ejemplo completo exporta los mismos párrafos tres veces. Pasa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) al método de exportación y escribe cada resultado en un archivo HTML UTF‑8 separado:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

El HTML generado contiene el siguiente CSS para la primera porción, “Inherited text;”. La tabla enumera las declaraciones relevantes; otras propiedades generadas se omiten por claridad.

| Output | CSS relevante para la primera porción | Apariencia |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, negrita, itálica a 28 pt en Calibri, si esa fuente está disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texto azul, negrita, itálica; la página o el navegador suministran la familia y el tamaño de fuente. |
| `ParagraphOnly.html` | `font-weight:bold` | Texto en negrita; la página o el navegador suministran familia, tamaño, color y estilo itálico. |

La segunda porción conserva `color:#ff0000`, `font-size:18pt` y `font-weight:bold` en los tres resultados. También conserva la itálica en `All` y `TextBox`, pero no en `ParagraphOnly`. Limitar la herencia, por tanto, no elimina el formato asignado explícitamente a un párrafo o a una porción.

Abra los archivos en el mismo navegador para compararlos. En los dos modos restringidos, las propiedades CSS omitidas se resuelven mediante los estilos de la página de destino o los valores predeterminados del navegador, de modo que la apariencia resultante depende de dónde se utilice el HTML.

### **Renderizar un párrafo como una imagen**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). No es necesario renderizar la forma contenedora ni recortar manualmente un mapa de bits.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) puede devolver `null` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no puede renderizarse. Compruebe el resultado antes de guardarlo y libere la imagen devuelta tras su uso.

#### **Renderizar un párrafo a escala predeterminada**

El ejemplo usa una presentación con una diapositiva cuya primera forma es un cuadro de texto que contiene tres párrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

El siguiente ejemplo selecciona el segundo párrafo en el índice 1 y llama a [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) sin parámetros de escala. Comprueba que la forma contiene el párrafo requerido y que la renderización devuelve una imagen antes de invocar [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) para guardarla en formato PNG. El bloque `finally` libera la imagen tras su uso.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escalado**

Utilice la sobrecarga de [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) que acepta los parámetros `$scaleX` y `$scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su anchura y altura predeterminadas y guarda el resultado como una imagen PNG.

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

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones predeterminadas, lo que da cuatro veces más píxeles. Factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Factores inferiores a `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para conservar la proporción del párrafo; factores diferentes en horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen solo del párrafo, use [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utilice [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) para obtener el rectángulo delimitador del párrafo. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de las porciones individuales.

Para alinear verticalmente porciones con diferentes tamaños de fuente dentro de cada línea, consulte [Align Fonts Within a Line](/slides/es/php-java/text-formatting/#align-fonts-within-a-line).

**¿Puedo establecer el idioma de revisión para una parte de un párrafo?**

Sí. Establezca [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.