---
title: Formato de formas
type: docs
weight: 20
url: /php-java/shape-formatting/
keywords: "Formato de forma, formato de líneas, estilos de unión, relleno degradado, relleno de patrón, relleno de imagen, relleno de color sólido, rotar formas, efectos de bisel 3d, efecto de rotación 3d, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Formato de formas en una presentación de PowerPoint"
---

En PowerPoint, puedes agregar formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes formatear las formas modificando o aplicando ciertos efectos a sus líneas constitutivas. Además, puedes formatear las formas especificando configuraciones que determinan cómo se rellenan (el área en ellas).

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides para PHP a través de Java** proporciona interfaces y propiedades que te permiten formatear formas según las opciones conocidas en PowerPoint.

## **Formato de Líneas**

Utilizando Aspose.Slides, puedes especificar tu estilo de línea preferido para una forma. Estos pasos describen dicho procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Establece un color para las líneas de la forma.
5. Establece el ancho para las líneas de la forma.
6. Establece el [estilo de línea](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) para la línea de la forma.
7. Establece el [estilo de guion](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) para la línea de la forma.
8. Escribe la presentación modificada como un archivo PPTX.

Este código PHP demuestra una operación donde formateamos un rectángulo `AutoShape`:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega una autoshape de tipo rectángulo
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # Establece el color de relleno para la forma de rectángulo
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Aplica algún formateo a las líneas del rectángulo
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # Establece el color para la línea del rectángulo
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Escribe el archivo PPTX en disco
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formato de Estilos de Unión**
Estas son las 3 opciones de tipo de unión:

* Redondeada
* Corte
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (o en la esquina de una forma), utiliza la configuración **Redondeada**. Sin embargo, si deseas dibujar una forma con ángulos muy agudos, es posible que desees seleccionar **Corte**.

![join-style-powerpoint](join-style-powerpoint.png)

Este Java demuestra una operación donde se crearon 3 rectángulos (la imagen de arriba) con los ajustes de tipo de unión Miter, Bevel y Round:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega 3 autoshapes de rectángulo
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # Establece el color de relleno para la forma de rectángulo
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Establece el ancho de la línea
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # Establece el color para la línea del rectángulo
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Establece el estilo de unión
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # Agrega texto a cada rectángulo
    $shp1->getTextFrame()->setText("Estilo de Unión Miter");
    $shp2->getTextFrame()->setText("Estilo de Unión Bevel");
    $shp3->getTextFrame()->setText("Estilo de Unión Redondeada");
    # Escribe el archivo PPTX en disco
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Relleno Degradado**
En PowerPoint, el Relleno Degradado es una opción de formateo que te permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores en una configuración donde un color se desvanece gradualmente y cambia a otro color.

Así es como utilizas Aspose.Slides para aplicar un relleno degradado a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forma a `Gradient`.
5. Agrega tus 2 colores preferidos con posiciones definidas utilizando los métodos `Add` expuestos por la colección `GradientStops` asociada con la clase `GradientFormat`.
6. Escribe la presentación modificada como un archivo PPTX.

Este código PHP demuestra una operación donde se utilizó el efecto de relleno degradado en una elipse:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega una autoshape elíptica
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # Aplica el formato degradado a la elipse
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # Establece la dirección del degradado
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # Agrega 2 paradas de degradado
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # Escribe el archivo PPTX en disco
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Relleno de Patrón**
En PowerPoint, el Relleno de Patrón es una opción de formateo que te permite aplicar un diseño de dos colores compuesto de puntos, rayas, tramas cruzadas o cuadros a una forma. Además, puedes seleccionar tus colores preferidos para el primer plano y el fondo de tu patrón.

Aspose.Slides proporciona más de 45 estilos predefinidos que pueden utilizarse para formatear formas y enriquecer presentaciones. Incluso después de elegir un patrón predefinido, aún puedes especificar los colores que debe contener el patrón.

Así es como utilizas Aspose.Slides para aplicar un relleno de patrón a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forma a `Pattern`.
5. Establece tu estilo de patrón preferido para la forma. 
6. Establece el [Color de Fondo](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--) para el [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
7. Establece el [Color de Primer Plano](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) para el [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
8. Escribe la presentación modificada como un archivo PPTX.

Este código PHP demuestra una operación donde se utilizó un relleno de patrón para embellecer un rectángulo:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega una autoshape de rectángulo
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Establece el tipo de relleno a Patrón
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # Establece el estilo de patrón
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # Establece los colores de fondo y primer plano del patrón
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # Escribe el archivo PPTX en disco
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Relleno de Imagen**
En PowerPoint, el Relleno de Imagen es una opción de formateo que te permite colocar una imagen dentro de una forma. Esencialmente, puedes usar una imagen como fondo de una forma.

Así es como utilizas Aspose.Slides para rellenar una forma con una imagen:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forma a `Picture`.
5. Establece el Modo de Relleno de Imagen a Tile.
6. Crea un objeto `IPPImage` usando la imagen que se utilizará para rellenar la forma.
7. Establece la propiedad `Picture.Image` del objeto `PictureFillFormat` al `IPPImage` creado recientemente.
8. Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo llenar una forma con una imagen:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega una autoshape de rectángulo
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Establece el tipo de relleno a Imagen
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # Establece el modo de relleno de imagen
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # Establece la imagen
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Escribe el archivo PPTX en disco
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Relleno de Color Sólido**
En PowerPoint, el Relleno de Color Sólido es una opción de formateo que te permite llenar una forma con un solo color. El color elegido es típicamente un color plano. El color se aplica al fondo de la forma sin efectos o modificaciones especiales.

Así es como utilizas Aspose.Slides para aplicar un relleno de color sólido a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forma a `Solid`.
5. Establece tu color preferido para la forma.
6. Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo aplicar el relleno de color sólido a un cuadro en PowerPoint:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agrega una autoshape de rectángulo
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Establece el tipo de relleno a Sólido
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # Establece el color para el rectángulo
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Escribe el archivo PPTX en disco
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Transparencia**

En PowerPoint, cuando rellenas formas con colores sólidos, degradados, imágenes o texturas, puedes especificar el nivel de transparencia que determina la opacidad de un relleno. De esta manera, por ejemplo, si estableces un nivel de transparencia bajo, el objeto de la diapositiva o el fondo detrás (la forma) se muestra.

Aspose.Slides te permite establecer el nivel de transparencia para una forma de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Usa `new Color` con el componente alfa establecido.
5. Guarda el objeto como un archivo de PowerPoint.

Este código PHP demuestra el proceso:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Agrega una forma sólida
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # Agrega una forma transparente sobre la forma sólida
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # Escribe el archivo PPTX en disco
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rotar Formas**
Aspose.Slides te permite rotar una forma añadida a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
4. Rota la forma por los grados necesarios. 
5. Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo rotar una forma 90 grados:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega una autoshape de rectángulo
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Rota la forma 90 grados
    $shp->setRotation(90);
    # Escribe el archivo PPTX en disco
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Efectos de Biseles 3D**
Aspose.Slides te permite agregar efectos de bisel 3D a una forma modificando sus propiedades de [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
3. Establece tus parámetros preferidos para las propiedades de [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) de la forma.
4. Escribe la presentación en disco.

Este código PHP te muestra cómo agregar efectos de bisel 3D a una forma:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Agrega una forma a la diapositiva
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # Establece las propiedades de ThreeDFormat de la forma
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # Escribe la presentación como un archivo PPTX
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Efecto de Rotación 3D**
Aspose.Slides te permite aplicar efectos de rotación 3D a una forma modificando sus propiedades de [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) a la diapositiva.
3. Especifica tus figuras preferidas para [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) y [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--).
4. Escribe la presentación en disco. 

Este código PHP te muestra cómo aplicar efectos de rotación 3D a una forma:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # Escribe la presentación como un archivo PPTX
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Restablecer Formateo**

Este código PHP te muestra cómo restablecer el formateo en una diapositiva y revertir la posición, tamaño y formateo de cada forma que tiene un marcador de posición en el [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide) a sus valores predeterminados:

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # cada forma en la diapositiva que tiene un marcador de posición en el diseño será revertida
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```