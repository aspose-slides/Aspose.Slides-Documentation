---
title: Gestionar párrafos de texto de PowerPoint en PHP
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/php-java/manage-paragraph/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangrado de párrafo
- sangrado colgante
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
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para PHP mediante Java — optimiza alineación, espaciado y estilo en presentaciones PPT, PPTX y ODP."
---
Aspose.Slides proporciona todas las clases que necesita para trabajar con textos, párrafos y fragmentos de PowerPoint.

* Aspose.Slides proporciona la clase [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) para permitirle añadir objetos que representan un párrafo. Un objeto `TextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) para permitirle añadir objetos que representan fragmentos. Un objeto `Paragraph` puede tener uno o varios fragmentos (colección de objetos fragmento).
* Aspose.Slides proporciona la clase [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/) para permitirle añadir objetos que representan textos y sus propiedades de formato.

Un objeto `Paragraph` es capaz de manejar textos con distintas propiedades de formato mediante sus objetos subyacentes `Portion`.

## **Añadir múltiples párrafos que contienen múltiples fragmentos**

Estos pasos le muestran cómo añadir un marco de texto que contiene 3 párrafos y cada párrafo contiene 3 fragmentos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Obtenga el ITextFrame asociado al [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/).
5. Cree dos objetos [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) y añádalos a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/).
6. Cree tres objetos [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/) para cada nuevo `Paragraph` (dos objetos Portion para el párrafo predeterminado) y añada cada objeto `Portion` a la colección de fragmentos de cada `Paragraph`.
7. Asigne texto a cada fragmento.
8. Aplique las características de formato que prefiera a cada fragmento mediante las propiedades de formato expuestas por el objeto `Portion`.
9. Guarde la presentación modificada.

Este código PHP es una implementación de los pasos para añadir párrafos que contienen fragmentos:

```php
# Instanciar una clase Presentation que representa un archivo PPTX
$pres = new Presentation();
try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir un AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Acceder al TextFrame del AutoShape
    $tf = $ashp->getTextFrame();
    # Crear párrafos y fragmentos con diferentes formatos de texto
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Guardar el PPTX en disco
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gestionar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado del `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/).
7. Establezca el `Type` de viñeta del párrafo a `Symbol` y defina el carácter de la viñeta.
8. Asigne el `Text` al párrafo.
9. Defina la `Indent` del párrafo para la viñeta.
10. Establezca un color para la viñeta.
11. Defina una altura para la viñeta.
12. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Añada el segundo párrafo y repita el proceso descrito en los pasos 7 a 13.
14. Guarde la presentación.

Este código PHP le muestra cómo añadir una viñeta de párrafo:

```php
# Instancia una clase Presentation que representa un archivo PPTX
$pres = new Presentation();
try {
    # Accede a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añade y accede al AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto del autoshape
    $txtFrm = $aShp->getTextFrame();
    # Elimina el párrafo predeterminado
    $txtFrm->getParagraphs()->removeAt(0);
    # Crea un párrafo
    $para = new Paragraph();
    # Define el estilo y símbolo de viñeta del párrafo
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Define el texto del párrafo
    $para->setText("Welcome to Aspose.Slides");
    # Define la sangría de la viñeta
    $para->getParagraphFormat()->setIndent(25);
    # Define el color de la viñeta
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// establecer IsBulletHardColor a true para usar el color propio de la viñeta

    # Define la altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Añade el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # Crea el segundo párrafo
    $para2 = new Paragraph();
    # Define el tipo y estilo de viñeta del párrafo
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Añade texto al párrafo
    $para2->setText("This is numbered bullet");
    # Define la sangría de la viñeta
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// establecer IsBulletHardColor a true para usar el color propio de la viñeta

    # Define la altura de la viñeta
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Añade el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para2);
    # Guarda la presentación modificada
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gestionar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Los párrafos con imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado del `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/).
7. Cargue la imagen en [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/bullettype/#Picture) y asigne la imagen.
9. Defina el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Defina un color para la viñeta.
12. Defina una altura para la viñeta.
13. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añada el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

Este código PHP le muestra cómo añadir y gestionar viñetas de imagen:

```php
# Instancia una clase Presentation que representa un archivo PPTX
$presentation = new Presentation();
try {
    # Accede a la primera diapositiva
    $slide = $presentation->getSlides()->get_Item(0);
    # Instancia la imagen para viñetas
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Añade y accede al AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto del autoshape
    $textFrame = $autoShape->getTextFrame();
    # Elimina el párrafo predeterminado
    $textFrame->getParagraphs()->removeAt(0);
    # Crea un nuevo párrafo
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Define el estilo y la imagen de la viñeta del párrafo
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Define la altura de la viñeta
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Añade el párrafo al marco de texto
    $textFrame->getParagraphs()->add($paragraph);
    # Guarda la presentación como archivo PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Guarda la presentación como archivo PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gestionar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar información de forma rápida y eficiente. Las viñetas multinivel son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado del `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) y establezca la profundidad a 0.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 1.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 2.
9. Cree la cuarta instancia de párrafo mediante la clase `Paragraph` y establezca la profundidad a 3.
10. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código PHP le muestra cómo añadir y gestionar viñetas multinivel:

```php
# Instancia una clase Presentation que representa un archivo PPTX
$pres = new Presentation();
try {
    # Accede a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añade y accede al AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto del AutoShape creado
    $text = $aShp->addTextFrame("");
    # Elimina el párrafo predeterminado
    $text->getParagraphs()->clear();
    # Añade el primer párrafo
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Define el nivel de la viñeta
    $para1->getParagraphFormat()->setDepth(0);
    # Añade el segundo párrafo
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Define el nivel de la viñeta
    $para2->getParagraphFormat()->setDepth(1);
    # Añade el tercer párrafo
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Define el nivel de la viñeta
    $para3->getParagraphFormat()->setDepth(2);
    # Añade el cuarto párrafo
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Define el nivel de la viñeta
    $para4->getParagraphFormat()->setDepth(3);
    # Añade los párrafos a la colección
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Guarda la presentación como archivo PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gestionar un párrafo con una lista numerada personalizada**

La clase [BulletFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/) proporciona el método [setNumberedBulletStartWith](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) y otros que le permiten gestionar párrafos con numeración o formato personalizados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) del autoshape.
5. Elimine el párrafo predeterminado del `TextFrame`.
6. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/es/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) a 2.
7. Cree la segunda instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 3.
8. Cree la tercera instancia de párrafo mediante la clase `Paragraph` y establezca `NumberedBulletStartWith` a 7.
9. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código PHP le muestra cómo añadir y gestionar párrafos con numeración o formato personalizados:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto del autoshape creado
    $textFrame = $shape->getTextFrame();
    # Elimina el párrafo predeterminado existente
    $textFrame->getParagraphs()->removeAt(0);
    # Primera lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Establecer sangrado de primera línea para un párrafo**

Utilice el método [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setindent/) para controlar el sangrado de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de líneas permanece alineado con el cuerpo del párrafo.

Utilice [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setmarginleft/) cuando necesite mover todo el párrafo. Utilice [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setindent/) cuando necesite mover solo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de sangrado para demostrar cómo el sangrado de primera línea afecta la disposición del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) vacío al shape y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [Indent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setindent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

Este código le muestra cómo establecer el sangrado de un párrafo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

![El sangrado de primera línea de los párrafos](first_line_indent.png)

## **Establecer sangrado colgante para un párrafo**

Un sangrado colgante es una disposición de párrafo en la que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con el método [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setindent/). Establezca el sangrado a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setmarginleft/) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat::setIndent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setindent/) define la posición de la primera línea respecto a ese margen. Para crear un sangrado colgante, establezca un valor positivo en `MarginLeft` y un valor negativo en `Indent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo en lugar de bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Añada un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) vacío al shape y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [MarginLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setmarginleft/) para cada párrafo.
6. Establezca un valor negativo de [Indent](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setindent/) para crear el efecto de sangrado colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

Este código le muestra cómo establecer un sangrado colgante para un párrafo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

![El sangrado colgante de los párrafos](hanging_indent.png)

## **Gestionar propiedades de ejecución al final del párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva que contiene el párrafo mediante su posición.
1. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) rectangular a la diapositiva.
1. Añada un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) con dos párrafos al rectángulo.
1. Establezca la altura de la fuente y el tipo de fuente para los párrafos.
1. Establezca las propiedades End para los párrafos.
1. Guarde la presentación modificada como archivo PPTX.

Este código PHP le muestra cómo establecer las propiedades End para los párrafos en PowerPoint:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Importar texto HTML en párrafos**

Aspose.Slides proporciona soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) a la diapositiva.
4. Añada y acceda al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) de `AutoShape`.
5. Elimine el párrafo predeterminado del `TextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la primera instancia de párrafo mediante la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/).
8. Añada el contenido del archivo HTML leído con TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

Este código PHP es una implementación de los pasos para importar textos HTML en párrafos:

```php
# Crear instancia vacía de presentación
$pres = new Presentation();
try {
    # Acceder a la diapositiva predeterminada (primera) de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir el AutoShape para alojar el contenido HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Añadir marco de texto a la forma
    $ashape->addTextFrame("");
    # Vaciar todos los párrafos del marco de texto añadido
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Cargar el archivo HTML usando un lector de flujo
    $tr = new StreamReader("file.html");
    # Añadir texto del lector de flujo HTML al marco de texto
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Guardar la presentación
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Exportar texto de párrafo a HTML**

Aspose.Slides proporciona soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a la forma que contiene el texto que será exportado a HTML.
4. Acceda a la [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y añada el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte los párrafos que prefiera.

Este código PHP le muestra cómo exportar los textos de párrafos de PowerPoint a HTML:

```php
# Cargar el archivo de presentación
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Acceder a la diapositiva predeterminada (primera) de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Índice deseado
    $index = 0;
    # Acceder a la forma añadida
    $ashape = $slide->getShapes()->get_Item($index);
    # Crear archivo HTML de salida
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraer el primer párrafo como HTML
    # Escribir los datos de los párrafos a HTML proporcionando el índice de inicio del párrafo, el número total de párrafos a copiar
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Guardar un párrafo como imagen**

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la clase [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/), como una imagen. Ambos ejemplos incluyen obtener la imagen de una forma que contiene el párrafo mediante los métodos `getImage` de la clase [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/), calcular los límites del párrafo dentro de la forma y exportarlo como una imagen bitmap. Estos enfoques le permiten extraer partes específicas del texto de presentaciones PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil para su uso posterior en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como imagen. Para hacerlo, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar sobre una nueva imagen bitmap, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen separada conservando las dimensiones y el formato exactos del texto.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Guardar la forma en memoria como un bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crear un bitmap de forma desde la memoria.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala al imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite obtener una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan teniendo en cuenta la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para su uso en materiales impresos de alta calidad.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Guardar la forma en memoria como un bitmap con escalado.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crear un bitmap de forma desde la memoria.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Calcular las coordenadas y el tamaño de la imagen de salida (tamaño mínimo - 1x1 píxel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recortar el bitmap de la forma para obtener solo el bitmap del párrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Utilice la configuración de ajuste del marco de texto ([setWrapText](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/setwraptext/)) para desactivar el ajuste de modo que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede obtener el rectángulo delimitador del párrafo (e incluso de un solo fragmento) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setalignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/); se aplica a todo el párrafo sin importar el formato de los fragmentos individuales.

**¿Puedo establecer un idioma de corrección ortográfica solo para parte de un párrafo (p. ej., una palabra)?**

Sí. El idioma se establece a nivel de fragmento ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.