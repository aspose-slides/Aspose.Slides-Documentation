---
title: Crear presentaciones 3D en PHP
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- presentación 3D
- rotación 3D
- profundidad 3D
- extrusión 3D
- degradado 3D
- texto 3D
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Genere presentaciones 3D interactivas en PHP con Aspose.Slides sin esfuerzo. Exporte rápidamente a formatos PowerPoint y OpenDocument para un uso versátil."
---

## **Descripción general**
Desde Aspose.Slides Java 20.9 es posible crear 3D en presentaciones. PowerPoint 3D es una forma de dar vida a las presentaciones. Muestra objetos del mundo real con presentaciones 3D, demuestra un modelo 3D de tu futuro proyecto empresarial, un modelo 3D del edificio o su interior, un modelo 3D del personaje de un juego, o simplemente una representación 3D de tus datos.

Los modelos 3D de PowerPoint pueden crearse a partir de formas 2D, aplicando efectos como: rotación 3D, profundidad y extrusión 3D, degradado 3D, texto 3D, etc. La lista de características 3D aplicadas a las formas se encuentra en la clase **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. La instancia de la clase puede obtenerse mediante:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** método para crear un modelo 3D de PowerPoint.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** método para crear texto 3D (WordArt).

Todos los efectos implementados en **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** pueden usarse tanto para formas como para texto. Veamos rápidamente los principales métodos de la clase **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. En el siguiente ejemplo creamos una forma rectangular 2D con texto. Al obtener la vista de cámara sobre la forma, cambiamos su rotación y la hacemos parecer un modelo 3D. Configurar una luz plana y su dirección hacia la parte superior del modelo 3D aporta más volumen al modelo. Cambiar materiales, altura de extrusión y color hacen que el modelo 3D parezca más vivo.  
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Este es el modelo 3D resultante:

![todo:image_alt_text](img_01_01.png)

## **Rotación 3D**
La rotación del modelo 3D en PowerPoint se puede realizar mediante el menú:

![todo:image_alt_text](img_02_01.png)

Para rotar un modelo 3D con la API de Aspose.Slides, use el método **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**, establezca la rotación de la cámara respecto a la forma 3D:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... establecer otros parámetros de escena 3D

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **Profundidad y extrusión 3D**
Los métodos **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** y **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** se utilizan para crear extrusión en una forma:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... establecer otros parámetros de escena 3D

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


En PowerPoint, la profundidad de la forma se establece mediante:

![todo:image_alt_text](img_02_02.png)

## **Degradado 3D**
El degradado 3D puede aportar más volumen a la forma 3D de PowerPoint:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```


Así es como se ve:

![todo:image_alt_text](img_02_03.png)
  
También puede crear un degradado de imagen:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... configurar 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propiedades

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


Este es el resultado:

![todo:image_alt_text](img_02_04.png)

## **Texto 3D (WordArt)**
Para crear texto 3D (WordArt), haga lo siguiente:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# configurar efecto de transformación WordArt "Arch Up"
$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Este es el resultado:

![todo:image_alt_text](img_02_05.png)

## **Preguntas frecuentes**

**¿Se conservan los efectos 3D al exportar una presentación a imágenes/PDF/HTML?**

Sí. El motor 3D de Slides renderiza los efectos 3D al exportar a formatos compatibles ([images](/slides/es/php-java/convert-powerpoint-to-png/), [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/es/php-java/convert-powerpoint-to-html/), etc.).

**¿Puedo obtener los valores "efectivos" (finales) de los parámetros 3D que tienen en cuenta temas, herencia, etc.?**

Sí. Slides proporciona API para [leer valores efectivos](/slides/es/php-java/shape-effective-properties/) (incluidos los de 3D — iluminación, biseles, etc.) para que pueda ver la configuración final aplicada.

**¿Funcionan los efectos 3D al convertir una presentación a video?**

Sí. Al [generar fotogramas para el video](/slides/es/php-java/convert-powerpoint-to-video/), los efectos 3D se renderizan de la misma manera que para las [imágenes exportadas](/slides/es/php-java/convert-powerpoint-to-png/).