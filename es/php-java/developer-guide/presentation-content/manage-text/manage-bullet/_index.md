---
title: Administrar listas con viñetas y numeradas en presentaciones usando PHP
linktitle: Administrar listas
type: docs
weight: 60
url: /es/php-java/manage-bullet/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta de imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo administrar listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java. Guía paso a paso."
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas del mismo modo que lo haces en Word y otros editores de texto. **Aspose.Slides for PHP via Java** también permite usar viñetas y números en las diapositivas de tus presentaciones.

## **¿Por qué usar listas con viñetas?**

Las listas con viñetas te ayudan a organizar y presentar la información de forma rápida y eficaz. 

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores a información importante
- permite que tus lectores o espectadores escaneen fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

## **¿Por qué usar listas numeradas?**

Las listas numeradas también ayudan a organizar y presentar la información. Idealmente, deberías usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada debe ser referenciada (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (del paso 1 al paso 15) en el procedimiento **Creating Bullets** a continuación:

1. Crea una instancia de la clase de presentación. 
2. Realiza varias tareas (del paso 3 al paso 14).
3. Guarda la presentación. 

## **Crear viñetas**
Este tema también forma parte de la serie de temas sobre la gestión de párrafos de texto. Esta página ilustrará cómo gestionar las viñetas de los párrafos. Las viñetas son más útiles cuando algo debe describirse en pasos. Además, el texto se ve bien organizado con el uso de viñetas. Los párrafos con viñetas siempre son más fáciles de leer y comprender. Veremos cómo los desarrolladores pueden usar esta característica pequeña pero poderosa de Aspose.Slides for PHP via Java. Sigue los pasos a continuación para gestionar las viñetas de los párrafos usando Aspose.Slides for PHP via Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) de la forma añadida.
1. Elimina el párrafo predeterminado en el TextFrame.
1. Crea la primera instancia de párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph).
1. Establece el tipo de viñeta del párrafo.
1. Establece el tipo de viñeta a [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) y define el carácter de la viñeta.
1. Establece el texto del párrafo.
1. Establece la sangría del párrafo para definir la viñeta.
1. Define el color de la viñeta.
1. Define la altura de las viñetas.
1. Añade el párrafo creado a la colección de párrafos del TextFrame.
1. Añade el segundo párrafo y repite el proceso indicado en los pasos **7 a 13**.
1. Guarda la presentación.

Este fragmento de código —una implementación de los pasos anteriores— muestra cómo crear una lista con viñetas en una diapositiva:
```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadiendo y accediendo al AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto del AutoShape creado
    $txtFrm = $aShp->getTextFrame();
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->removeAt(0);
    # Creando un párrafo
    $para = new Paragraph();
    # Estableciendo el estilo y símbolo de viñeta del párrafo
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Estableciendo el texto del párrafo
    $para->setText("Welcome to Aspose.Slides");
    # Estableciendo la sangría de la viñeta
    $para->getParagraphFormat()->setIndent(25);
    # Estableciendo el color de la viñeta
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # Establecer IsBulletHardColor a true para usar un color de viñeta propio
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Estableciendo la altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Añadiendo el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # Guardando la presentación como un archivo PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Crear viñetas con imagen**

Aspose.Slides for PHP via Java te permite cambiar las viñetas en listas con viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizadas. Si deseas añadir interés visual a una lista o llamar aún más la atención a las entradas, puedes usar tu propia imagen como viñeta.

{{% alert color="primary" %}} 

Idealmente, si pretendes reemplazar el símbolo de viñeta regular por una imagen, deberías seleccionar un gráfico simple con fondo transparente. Estas imágenes funcionan mejor como símbolos de viñeta personalizados. 

En cualquier caso, la imagen que elijas será reducida a un tamaño muy pequeño, por lo que recomendamos encarecidamente que selecciones una imagen que se vea bien (como reemplazo del símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)
1. Añade un autoshape en la diapositiva seleccionada
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forma añadida
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. Crea la primera instancia de párrafo usando la clase Paragraph
1. Carga la imagen desde el disco en [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)
1. Establece el tipo de viñeta a Picture y define la imagen
1. Establece el texto del párrafo
1. Establece la sangría del párrafo para definir la viñeta
1. Define el color de la viñeta
1. Define la altura de las viñetas
1. Añade el párrafo creado al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) colección de párrafos
1. Añade el segundo párrafo y repite el proceso indicado en los pasos anteriores
1. Guarda la presentación

Este código PHP muestra cómo crear una viñeta con imagen en una diapositiva:
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
    # Añadiendo y accediendo al AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto del AutoShape creado
    $txtFrm = $aShp->getTextFrame();
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->removeAt(0);
    # Creando un nuevo párrafo
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # Configurando el estilo de viñeta del párrafo y la imagen
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Configurando la altura de la viñeta
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Añadiendo el párrafo al marco de texto
    $txtFrm->getParagraphs()->add($para);
    # Guardando la presentación como un archivo PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Crear viñetas multinivel**

Para crear una lista con viñetas que contenga elementos en diferentes niveles —listas adicionales bajo la lista principal— sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Añade un autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Crea la primera instancia de párrafo usando la clase Paragraph y con profundidad establecida a 0.
1. Crea la segunda instancia de párrafo usando la clase Paragraph y con profundidad establecida a 1.
1. Crea la tercera instancia de párrafo usando la clase Paragraph y con profundidad establecida a 2.
1. Crea la cuarta instancia de párrafo usando la clase Paragraph y con profundidad establecida a 3.
1. Añade los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Guarda la presentación.

Este código, que implementa los pasos anteriores, muestra cómo crear una lista con viñetas multinivel:
```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadiendo y accediendo al AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto del AutoShape creado
    $txtFrm = $aShp->addTextFrame("");
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->clear();
    # Creando el primer párrafo
    $para1 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y el símbolo
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de viñeta
    $para1->getParagraphFormat()->setDepth(0);
    # Creando el segundo párrafo
    $para2 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y el símbolo
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de viñeta
    $para2->getParagraphFormat()->setDepth(1);
    # Creando el tercer párrafo
    $para3 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y el símbolo
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de viñeta
    $para3->getParagraphFormat()->setDepth(2);
    # Creando el cuarto párrafo
    $para4 = new Paragraph();
    # Estableciendo el estilo de viñeta del párrafo y el símbolo
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Estableciendo el nivel de viñeta
    $para4->getParagraphFormat()->setDepth(3);
    # Añadiendo el párrafo al marco de texto
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


## **Crear listas numeradas personalizadas**
Aspose.Slides for PHP via Java ofrece una API sencilla para gestionar párrafos con formato de números personalizado. Para añadir una lista numerada personalizada en un párrafo, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Accede a la diapositiva deseada en la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. Añade un autoshape en la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) de la forma añadida.
1. Elimina el párrafo predeterminado en el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Crea la primera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** a 2
1. Crea la segunda instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** a 3
1. Crea la tercera instancia de párrafo usando la clase Paragraph y establece **NumberedBulletStartWith** a 7
1. Añade los párrafos creados a la colección de párrafos del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Guarda la presentación.

Este código PHP muestra cómo crear una lista numerada en una diapositiva:
```php
  # Instanciar una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadiendo y accediendo al AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accediendo al marco de texto del AutoShape creado
    $txtFrm = $aShp->addTextFrame("");
    # Eliminando el párrafo predeterminado existente
    $txtFrm->getParagraphs()->clear();
    # Primera lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Segunda lista
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
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


## **FAQ**

**¿Pueden exportarse las listas con viñetas y numeradas creadas con Aspose.Slides a otros formatos como PDF o imágenes?**

Sí, Aspose.Slides conserva totalmente el formato y la estructura de las listas con viñetas y numeradas cuando las presentaciones se exportan a formatos como PDF, imágenes y otros, garantizando resultados consistentes.

**¿Es posible importar listas con viñetas o numeradas desde presentaciones existentes?**

Sí, Aspose.Slides permite importar y editar listas con viñetas o numeradas de presentaciones existentes mientras se preserva su formato y apariencia originales.

**¿Aspose.Slides admite listas con viñetas y numeradas en presentaciones creadas en varios idiomas?**

Sí, Aspose.Slides soporta plenamente presentaciones multilingües, permitiendo crear listas con viñetas y numeradas en cualquier idioma, incluido el uso de caracteres especiales o no latinos.