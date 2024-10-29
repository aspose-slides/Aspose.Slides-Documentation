---
title: Gestionar Viñetas
type: docs
weight: 60
url: /es/php-java/manage-bullet/
keywords: "Viñetas, Listas de viñetas, Números, Listas numeradas, Viñetas con imágenes, viñetas multinivel, Presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Crea listas de viñetas y numeradas en una presentación de PowerPoint"
---

En **Microsoft PowerPoint**, puedes crear listas de viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides para PHP a través de Java** también te permite usar viñetas y números en las diapositivas de tus presentaciones.

## ¿Por qué usar listas de viñetas?

Las listas de viñetas te ayudan a organizar y presentar información de manera rápida y eficiente.

**Ejemplo de lista de viñetas**

En la mayoría de los casos, una lista de viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores sobre información importante
- permite a tus lectores o espectadores buscar fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

## ¿Por qué usar listas numeradas?

Las listas numeradas también ayudan a organizar y presentar información. Idealmente, debes usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada necesita ser referenciada (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (paso 1 al paso 15) en el procedimiento de **Crear viñetas** a continuación:

1. Crea una instancia de la clase de presentación.
2. Realiza varias tareas (paso 3 al paso 14).
3. Guarda la presentación.

## Crear viñetas
Este tema también forma parte de la serie de temas sobre la gestión de párrafos de texto. Esta página ilustrará cómo podemos gestionar las viñetas de los párrafos. Las viñetas son más útiles donde algo se debe describir en pasos. Además, el texto se ve bien organizado con el uso de viñetas. Los párrafos con viñetas son siempre más fáciles de leer y entender. Veremos cómo los desarrolladores pueden usar esta pequeña pero poderosa característica de Aspose.Slides para PHP a través de Java. Sigue los pasos a continuación para gestionar las viñetas de los párrafos utilizando Aspose.Slides para PHP a través de Java:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Agrega una [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) de la forma añadida.
1. Elimina el párrafo predeterminado en el TextFrame.
1. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph).
1. Establece el tipo de viñeta del párrafo.
1. Establece el tipo de viñeta a [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) y establece el carácter de la viñeta.
1. Establece el texto del párrafo.
1. Establece la sangría del párrafo para establecer la viñeta.
1. Establece el color de la viñeta.
1. Establece la altura de las viñetas.
1. Agrega el párrafo creado en la colección de párrafos del TextFrame.
1. Agrega el segundo párrafo y repite el proceso dado en los pasos **7 a 13**.
1. Guarda la presentación.

Este código de ejemplo —una implementación de los pasos anteriores—te muestra cómo crear una lista de viñetas en una diapositiva:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregando y accediendo a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto de la autoshape creada
    $txtFrm = $aShp->getTextFrame();
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->removeAt(0);
    # Creando un párrafo
    $para = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y símbolo
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Estableciendo el texto del párrafo
    $para->setText("Bienvenido a Aspose.Slides");
    # Estableciendo la sangría de la viñeta
    $para->getParagraphFormat()->setIndent(25);
    # Estableciendo el color de la viñeta
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # establecer IsBulletHardColor en true para usar el propio color de la viñeta
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Estableciendo la altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Agregando el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # guardando la presentación como un archivo PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## Crear viñetas con imágenes

Aspose.Slides para PHP a través de Java te permite cambiar las viñetas en listas de viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizadas. Si deseas agregar un interés visual a una lista o llamar aún más la atención sobre las entradas de una lista, puedes usar tu propia imagen como la viñeta.

{{% alert color="primary" %}} 

Idealmente, si tienes la intención de reemplazar el símbolo de viñeta regular con una imagen, es posible que desees seleccionar una imagen gráfica simple con un fondo transparente. Tales imágenes funcionan mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas se reducirá a un tamaño muy pequeño, por lo que te recomendamos encarecidamente que selecciones una imagen que se vea bien (como un reemplazo del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class
1. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)
1. Agrega una autoshape en la diapositiva seleccionada
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forma añadida
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. Crea la primera instancia de párrafo utilizando la clase Paragraph
1. Carga una imagen del disco en [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)
1. Establece el tipo de viñeta a Picture y establece la imagen
1. Establece el texto del párrafo
1. Establece la sangría del párrafo para establecer la viñeta
1. Establece el color de la viñeta
1. Establece la altura de las viñetas
1. Agrega el párrafo creado en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. Agrega el segundo párrafo y repite el proceso dado en los pasos anteriores
1. Guarda la presentación

Este código PHP te muestra cómo crear una viñeta con imagen en una diapositiva:

```php
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Instanciar la imagen para viñetas
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agregando y accediendo a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto de la autoshape creada
    $txtFrm = $aShp->getTextFrame();
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->removeAt(0);
    # Creando nuevo párrafo
    $para = new Paragraph();
    $para->setText("Bienvenido a Aspose.Slides");
    # Estableciendo el estilo de viñeta del párrafo e imagen
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Estableciendo la altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Agregando el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # Escribiendo la presentación como un archivo PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Crear viñetas multinivel

Para crear una lista de viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista principal de viñetas—sigue estos pasos:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Agrega una autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Crea la primera instancia de párrafo utilizando la clase Paragraph y con la profundidad establecida en 0.
1. Crea la segunda instancia de párrafo utilizando la clase Paragraph y con la profundidad establecida en 1.
1. Crea la tercera instancia de párrafo utilizando la clase Paragraph y con la profundidad establecida en 2.
1. Crea la cuarta instancia de párrafo utilizando la clase Paragraph y con la profundidad establecida en 3.
1. Agrega los párrafos creados en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Guarda la presentación.

Este código, que es una implementación de los pasos anteriores, te muestra cómo crear una lista de viñetas multinivel:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregando y accediendo a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto de la autoshape creada
    $txtFrm = $aShp->addTextFrame("");
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->clear();
    # Creando el primer párrafo
    $para1 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y símbolo
    $para1->setText("Contenido");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de la viñeta
    $para1->getParagraphFormat()->setDepth(0);
    # Creando el segundo párrafo
    $para2 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y símbolo
    $para2->setText("Segundo nivel");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de la viñeta
    $para2->getParagraphFormat()->setDepth(1);
    # Creando el tercer párrafo
    $para3 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y símbolo
    $para3->setText("Tercer nivel");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de la viñeta
    $para3->getParagraphFormat()->setDepth(2);
    # Creando el cuarto párrafo
    $para4 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y símbolo
    $para4->setText("Cuarto nivel");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de la viñeta
    $para4->getParagraphFormat()->setDepth(3);
    # Agregando el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # guardando la presentación como un archivo PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Crear lista numerada personalizada
Aspose.Slides para PHP a través de Java proporciona una API simple para gestionar párrafos con formato de números personalizados. Para agregar una lista de números personalizados en un párrafo, sigue los pasos a continuación:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) object.
1. Agrega una autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Crea la primera instancia de párrafo utilizando la clase Paragraph y establece **NumberedBulletStartWith** en 2.
1. Crea la segunda instancia de párrafo utilizando la clase Paragraph y establece **NumberedBulletStartWith** en 3.
1. Crea la tercera instancia de párrafo utilizando la clase Paragraph y establece **NumberedBulletStartWith** en 7.
1. Agrega los párrafos creados en la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Guarda la presentación.

Este código PHP te muestra cómo crear una lista numerada en una diapositiva:

```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregando y accediendo a Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto de la autoshape creada
    $txtFrm = $aShp->addTextFrame("");
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->clear();
    # Primera lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("viñeta 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("viñeta 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Segunda lista
    $paragraph5 = new Paragraph();
    $paragraph5->setText("viñeta 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```