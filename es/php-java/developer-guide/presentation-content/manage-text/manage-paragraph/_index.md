---
title: Gestionar el párrafo de PowerPoint
type: docs
weight: 40
url: /php-java/manage-paragraph/
keywords: "Agregar párrafo de PowerPoint, Gestionar párrafos, Sangría de párrafo, Propiedades del párrafo, Texto HTML, Exportar texto de párrafo, Presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Crear y gestionar párrafos, texto, sangrías y propiedades en presentaciones de PowerPoint"
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) para permitirle agregar objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o múltiples párrafos (cada párrafo se crea a través de un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) para permitirle agregar objetos que representan porciones. Un objeto `IParagraph` puede tener una o múltiples porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) para permitirle agregar objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar múltiples párrafos que contengan múltiples porciones**

Estos pasos le muestran cómo agregar un marco de texto que contenga 3 párrafos y cada párrafo contenga 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una forma rectangular [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Obtenga el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) y agréguelos a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Porción para el párrafo predeterminado) y agregue cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca algún texto para cada porción.
8. Aplique sus características de formato preferidas a cada porción utilizando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

Este código PHP es una implementación de los pasos para agregar párrafos que contienen porciones:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar una forma automática de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Acceder al TextFrame de la forma automática
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
    # Escribir PPTX en disco
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gestionar viñetas de párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas son siempre más fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una [forma automática](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la forma automática.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Establezca el `Type` de viñeta del párrafo en `Symbol` y establezca el carácter de viñeta.
8. Establezca el `Text` del párrafo.
9. Establezca la `Indent` del párrafo para la viñeta.
10. Establezca un color para la viñeta.
11. Establezca una altura para la viñeta.
12. Agregue el nuevo párrafo a la colección de párrafos en el `TextFrame`.
13. Agregue el segundo párrafo y repita el proceso dado en los pasos 7 a 13.
14. Guarde la presentación.

Este código PHP le muestra cómo agregar una viñeta de párrafo:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar y acceder a la forma automática
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acceder al marco de texto de la forma automática
    $txtFrm = $aShp->getTextFrame();
    # Eliminar el párrafo predeterminado
    $txtFrm->getParagraphs()->removeAt(0);
    # Crear un párrafo
    $para = new Paragraph();
    # Establecer un estilo de viñeta y símbolo para el párrafo
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Establecer el texto del párrafo
    $para->setText("Bienvenido a Aspose.Slides");
    # Establecer la indentación de la viñeta
    $para->getParagraphFormat()->setIndent(25);
    # Establecer color de la viñeta
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// establecer IsBulletHardColor en verdadero para usar el color de viñeta propio

    # Establecer altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Agregar párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # Crear el segundo párrafo
    $para2 = new Paragraph();
    # Establecer tipo y estilo de viñeta del párrafo
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Agregar texto al párrafo
    $para2->setText("Esta es una viñeta numerada");
    # Establecer la indentación de la viñeta
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// establecer IsBulletHardColor en verdadero para usar el color de viñeta propio

    # Establecer altura de la viñeta
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Agregar párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para2);
    # Guardar la presentación modificada
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gestionar viñetas de imagen**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos de imágenes son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una [forma automática](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la forma automática.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta en [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) y establezca la imagen.
9. Establezca el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Establezca un color para la viñeta.
12. Establezca una altura para la viñeta.
13. Agregue el nuevo párrafo a la colección de párrafos en el `TextFrame`.
14. Agregue el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

Este código PHP le muestra cómo agregar y gestionar viñetas de imagen:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $presentation = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $presentation->getSlides()->get_Item(0);
    # Instanciar la imagen para las viñetas
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agregar y acceder a la forma automática
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acceder al marco de texto de la forma automática
    $textFrame = $autoShape->getTextFrame();
    # Eliminar el párrafo predeterminado
    $textFrame->getParagraphs()->removeAt(0);
    # Crear un nuevo párrafo
    $paragraph = new Paragraph();
    $paragraph->setText("Bienvenido a Aspose.Slides");
    # Establecer estilo de viñeta del párrafo y imagen
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Establecer altura de la viñeta
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Agregar párrafo al marco de texto
    $textFrame->getParagraphs()->add($paragraph);
    # Escribir la presentación como un archivo PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Escribir la presentación como un archivo PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Gestionar viñetas de múltiples niveles**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Las viñetas de múltiples niveles son fáciles de leer y comprender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una [forma automática](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la forma automática.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) y establezca la profundidad en 0.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 1.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 2.
9. Cree la cuarta instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 3.
10. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código PHP le muestra cómo agregar y gestionar viñetas de múltiples niveles:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar y acceder a la forma automática
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acceder al marco de texto de la forma automática creada
    $text = $aShp->addTextFrame("");
    # Limpiar el párrafo predeterminado
    $text->getParagraphs()->clear();
    # Agregar el primer párrafo
    $para1 = new Paragraph();
    $para1->setText("Contenido");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establecer el nivel de viñeta
    $para1->getParagraphFormat()->setDepth(0);
    # Agregar el segundo párrafo
    $para2 = new Paragraph();
    $para2->setText("Segundo Nivel");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establecer el nivel de viñeta
    $para2->getParagraphFormat()->setDepth(1);
    # Agregar el tercer párrafo
    $para3 = new Paragraph();
    $para3->setText("Tercer Nivel");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establecer el nivel de viñeta
    $para3->getParagraphFormat()->setDepth(2);
    # Agregar el cuarto párrafo
    $para4 = new Paragraph();
    $para4->setText("Cuarto Nivel");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establecer el nivel de viñeta
    $para4->getParagraphFormat()->setDepth(3);
    # Agregar párrafos a la colección
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Escribir la presentación como un archivo PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Gestionar párrafos con lista numerada personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) proporciona la propiedad [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) y otras que le permiten gestionar párrafos con numeración o formato personalizado.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Agregue una [forma automática](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la forma automática.
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) y establezca [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) en 2.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 3.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 7.
9. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código PHP le muestra cómo agregar y gestionar párrafos con numeración o formato personalizado:

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acceder al marco de texto de la forma automática creada
    $textFrame = $shape->getTextFrame();
    # Eliminar el párrafo predeterminado existente
    $textFrame->getParagraphs()->removeAt(0);
    # Primera lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("viñeta 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("viñeta 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("viñeta 7");
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


## **Establecer sangría del párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una forma rectangular [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) con tres párrafos a la forma rectangular.
5. Oculte las líneas del rectángulo.
6. Establezca la sangría para cada [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) a través de su propiedad BulletOffset.
7. Escriba la presentación modificada como un archivo PPT.

Este código PHP le muestra cómo establecer una sangría de párrafo:

```php
  # Instanciar clase Presentation
  $pres = new Presentation();
  try {
    # Obtener primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar forma rectangular
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Agregar TextFrame al Rectángulo
    $tf = $rect->addTextFrame("Esta es la primera línea \rEsta es la segunda línea \rEsta es la tercera línea");
    # Establecer el texto para que se ajuste a la forma
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Ocultar las líneas del Rectángulo
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Obtener el primer párrafo en el TextFrame y establecer su sangría
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Establecer estilo y símbolo de viñeta para el párrafo
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
    # Escribir la presentación en el disco
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer sangría colgante para el párrafo**

Este código PHP le muestra cómo establecer la sangría colgante para un párrafo:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Ejemplo");
    $para2 = new Paragraph();
    $para2->setText("Establecer Sangría Colgante para Párrafo");
    $para3 = new Paragraph();
    $para3->setText("Este código C# muestra cómo establecer la sangría colgante para un párrafo: ");
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

## **Gestionar propiedades de ejecución final del párrafo para el párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenga la referencia para la diapositiva que contiene el párrafo a través de su posición.
3. Agregue una [forma automática](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) con dos párrafos al Rectángulo.
5. Establezca el `FontHeight` y el tipo de fuente para los párrafos.
6. Establezca las propiedades de finalización para los párrafos.
7. Escriba la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo establecer las propiedades de finalización para los párrafos en PowerPoint:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Texto de ejemplo"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Texto de ejemplo 2"));
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

Aspose.Slides proporciona un soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una [forma automática](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue y acceda al `autoshape` [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML de origen en un TextReader.
7. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Agregue el contenido del archivo HTML en el TextReader leído a la [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) del TextFrame.
9. Guarde la presentación modificada.

Este código PHP es una implementación de los pasos para importar textos HTML en párrafos:

```php
  # Crear instancia de presentación vacía
  $pres = new Presentation();
  try {
    # Accesar la primera diapositiva predeterminada de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar la forma automática para acomodar el contenido HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Agregar marco de texto a la forma
    $ashape->addTextFrame("");
    # Limpiar todos los párrafos en el marco de texto agregado
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Cargar el archivo HTML usando stream reader
    $tr = new StreamReader("file.html");
    # Agregar texto desde el lector de flujos HTML en el marco de texto
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Guardar presentación
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exportar texto de párrafos a HTML**

Aspose.Slides proporciona un soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y agregue el nuevo archivo HTML.
6. Proporcione un índice inicial al StreamWriter y exporte sus párrafos preferidos.

Este código PHP le muestra cómo exportar los textos de párrafos de PowerPoint a HTML:

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
    # Extraer primer párrafo como HTML
    # Escribir los datos de párrafos en HTML proporcionando el índice inicial del párrafo, el total de párrafos que se copiarán
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```