---
title: Administrar párrafos de texto de PowerPoint en PHP
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/php-java/manage-paragraph/
keywords:
- agregar texto
- agregar párrafo
- administrar texto
- administrar párrafo
- administrar viñeta
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
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina el formato de párrafos con Aspose.Slides para PHP vía Java — optimiza la alineación, el espaciado y el estilo en presentaciones PPT, PPTX y ODP."
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) para permitirle añadir objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o varios párrafos (cada párrafo se crea mediante un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) para permitirle añadir objetos que representan porciones. Un objeto `IParagraph` puede tener una o varias porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) para permitirle añadir objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar varios párrafos con varias porciones**

Estos pasos le muestran cómo añadir un marco de texto que contenga 3 párrafos y cada párrafo contenga 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada un rectángulo [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Obtenga el ITextFrame asociado al [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) y añádalos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y añada cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Defina algún texto para cada porción.
8. Aplique sus características de formato preferidas a cada porción usando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

Este código PHP es una implementación de los pasos para añadir párrafos que contienen porciones:
```php
# Instanciar una clase Presentation que representa un archivo PPTX
$pres = new Presentation();
try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar una AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Acceder al TextFrame de la AutoShape
    $tf = $ashp->getTextFrame();
    # Crear párrafos y porciones con diferentes formatos de texto
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
    # Guardar PPTX en disco
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Administrar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información rápida y eficientemente. Los párrafos con viñetas siempre son más fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Establezca el `Type` de viñeta del párrafo a `Symbol` y establezca el carácter de viñeta.
8. Defina el `Text` del párrafo.
9. Establezca la `Indent` del párrafo para la viñeta.
10. Asigne un color a la viñeta.
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
    # Añade y accede a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto de la autoshape
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
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// establecer IsBulletHardColor a true para usar un color de viñeta propio

    # Define la altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Añade el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # Crea el segundo párrafo
    $para2 = new Paragraph();
    # Define el tipo y estilo de viñeta del párrafo
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Añade el texto del párrafo
    $para2->setText("This is numbered bullet");
    # Define la sangría de la viñeta
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// establecer IsBulletHardColor a true para usar un color de viñeta propio

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


## **Administrar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información rápida y eficientemente. Los párrafos con imágenes son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta a [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) y establezca la imagen.
9. Defina el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Asigne un color a la viñeta.
12. Defina una altura para la viñeta.
13. Añada el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Añada el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

Este código PHP le muestra cómo añadir y administrar viñetas de imagen:
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
    # Añade y accede a Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto de la autoshape
    $textFrame = $autoShape->getTextFrame();
    # Elimina el párrafo predeterminado
    $textFrame->getParagraphs()->removeAt(0);
    # Crea un nuevo párrafo
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Define el estilo de viñeta del párrafo y la imagen
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


## **Administrar viñetas multinivel**

Las listas con viñetas le ayudan a organizar y presentar información rápida y eficientemente. Las viñetas multinivel son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) y establezca la profundidad en 0.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 1.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 2.
9. Cree la cuarta instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 3.
10. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código PHP le muestra cómo añadir y administrar viñetas multinivel:
```php
# Instancia una clase Presentation que representa un archivo PPTX
$pres = new Presentation();
try {
    # Accede a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añade y accede a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accede al marco de texto del autoshape creado
    $text = $aShp->addTextFrame("");
    # Borra el párrafo predeterminado
    $text->getParagraphs()->clear();
    # Añade el primer párrafo
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establece el nivel de viñeta
    $para1->getParagraphFormat()->setDepth(0);
    # Añade el segundo párrafo
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establece el nivel de viñeta
    $para2->getParagraphFormat()->setDepth(1);
    # Añade el tercer párrafo
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establece el nivel de viñeta
    $para3->getParagraphFormat()->setDepth(2);
    # Añade el cuarto párrafo
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establece el nivel de viñeta
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


## **Administrar un párrafo con una lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) y otras que le permiten gestionar párrafos con numeración o formato personalizado.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la autoshape.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en 2.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 3.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 7.
9. Añada los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código PHP le muestra cómo añadir y administrar párrafos con numeración o formato personalizado:
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


## **Establecer sangría de párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
1. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) rectangular a la diapositiva.
1. Añada un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) con tres párrafos a la autoshape rectangular.
1. Oculte las líneas del rectángulo.
1. Establezca la sangría para cada [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) a través de su propiedad `BulletOffset`.
1. Escriba la presentación modificada como un archivo PPT.

Este código PHP le muestra cómo establecer una sangría de párrafo:
```php
# Instanciar la clase Presentation
$pres = new Presentation();
try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir una forma rectangular
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Añadir TextFrame al rectángulo
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # Ajustar el texto para que quepa en la forma
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Ocultar las líneas del rectángulo
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Obtener el primer párrafo en el TextFrame y establecer su sangría
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Configurar el estilo de viñeta del párrafo y el símbolo
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Obtener el segundo párrafo en el TextFrame y establecer su sangría
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Obtener el tercer párrafo en el TextFrame y establecer su sangría
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Guardar la presentación en disco
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Establecer sangría colgante para un párrafo**

Este código PHP le muestra cómo establecer la sangría colgante para un párrafo:
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Administrar propiedades de ejecución al final del párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva que contiene el párrafo mediante su posición.
1. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) rectangular a la diapositiva.
1. Añada un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) con dos párrafos al rectángulo.
1. Establezca `FontHeight` y el tipo de fuente para los párrafos.
1. Establezca las propiedades de fin para los párrafos.
1. Escriba la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo establecer las propiedades de fin para los párrafos en PowerPoint:
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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Añada y acceda al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la `autoshape`.
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Añada el contenido del archivo HTML leído por el TextReader a la [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

Este código PHP es una implementación de los pasos para importar textos HTML en párrafos:
```php
# Crear instancia vacía de presentación
$pres = new Presentation();
try {
    # Acceder a la primera diapositiva predeterminada de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir el AutoShape para acomodar el contenido HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Añadir marco de texto a la forma
    $ashape->addTextFrame("");
    # Borrar todos los párrafos del marco de texto añadido
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Cargar el archivo HTML usando StreamReader
    $tr = new StreamReader("file.html");
    # Añadir texto del stream reader HTML al marco de texto
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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y añada el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte los párrafos que prefiera.

Este código PHP le muestra cómo exportar textos de párrafos de PowerPoint a HTML:
```php
# Cargar el archivo de presentación
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Acceder a la primera diapositiva predeterminada de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Índice deseado
    $index = 0;
    # Acceder a la forma añadida
    $ashape = $slide->getShapes()->get_Item($index);
    # Crear archivo HTML de salida
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraer el primer párrafo como HTML
    # Escribir los datos de los párrafos a HTML proporcionando el índice de inicio del párrafo y el total de párrafos a copiar
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

En esta sección, exploraremos dos ejemplos que demuestran cómo guardar un párrafo de texto, representado por la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/), como una imagen. Ambos ejemplos incluyen obtener la imagen de una forma que contiene el párrafo usando los métodos `getImage` de la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), calcular los límites del párrafo dentro de la forma y exportarlo como una imagen de mapa de bits. Estos enfoques le permiten extraer partes específicas del texto de presentaciones de PowerPoint y guardarlas como imágenes separadas, lo que puede ser útil para reutilizarlas en diversos escenarios.

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Ejemplo 1**

En este ejemplo, obtenemos el segundo párrafo como una imagen. Para ello, extraemos la imagen de la forma de la primera diapositiva de la presentación y luego calculamos los límites del segundo párrafo en el marco de texto de la forma. El párrafo se vuelve a dibujar en una nueva imagen de mapa de bits, que se guarda en formato PNG. Este método es especialmente útil cuando necesita guardar un párrafo específico como una imagen independiente conservando las dimensiones y el formato exactos del texto.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Guardar la forma en memoria como un mapa de bits.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crear un mapa de bits de la forma desde la memoria.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcular los límites del segundo párrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Calcular las coordenadas y el tamaño para la imagen de salida (tamaño mínimo - 1x1 píxel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recortar el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


El resultado:

![The paragraph image](paragraph_to_image_output.png)

**Ejemplo 2**

En este ejemplo, ampliamos el enfoque anterior añadiendo factores de escala a la imagen del párrafo. La forma se extrae de la presentación y se guarda como una imagen con un factor de escala de `2`. Esto permite una salida de mayor resolución al exportar el párrafo. Los límites del párrafo se calculan considerando la escala. La escala puede ser particularmente útil cuando se necesita una imagen más detallada, por ejemplo, para materiales impresos de alta calidad.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Guardar la forma en memoria como un mapa de bits con escalado.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crear un mapa de bits de la forma desde la memoria.
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

    // Recortar el mapa de bits de la forma para obtener solo el mapa de bits del párrafo.
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

Sí. Utilice la configuración de ajuste del marco de texto ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Puede recuperar el rectángulo delimitador del párrafo (e incluso de una sola porción) para conocer su posición y tamaño precisos en la diapositiva.

**¿Dónde se controla la alineación del párrafo (izquierda/derecha/centrado/justificado)?**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) es una configuración a nivel de párrafo en [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); se aplica a todo el párrafo sin importar el formato individual de las porciones.

**¿Puedo establecer un idioma de corrección ortográfica solo para una parte del párrafo (por ejemplo, una palabra)?**

Sí. El idioma se establece a nivel de porción ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)), por lo que pueden coexistir varios idiomas dentro de un mismo párrafo.