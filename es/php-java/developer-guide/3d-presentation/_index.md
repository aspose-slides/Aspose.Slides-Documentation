---
title: Crear efectos 3D en presentaciones usando PHP
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
- presentación
- PHP
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en PHP con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides for PHP via Java puede crear, editar, conservar y renderizar formato 3D al estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos de degradado o imagen, y texto 3D.

{{% alert color="info" title="Note" %}}
Este artículo trata sobre los efectos de formato 3D en las formas y el texto de PowerPoint. No se trata de insertar o editar archivos de modelos 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Utiliza el método [Shape::getThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getThreeDFormat--) para aplicar formato 3D a una forma. El método devuelve [ThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/), que controla la escena 3D para esa forma.

Para texto, utiliza el método [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los miembros de API más importantes son:

| Miembro de API | Qué controla | Cuándo usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getCamera--) | Punto de vista, tipo de cámara predefinida, rotación, zoom y perspectiva. | Rotar el objeto en espacio 3D o coincidir con un preset de rotación 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getLightRig--) | Preajuste de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los realces y sombras en la superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getMaterial--) y [setMaterial](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getExtrusionHeight--) y [setExtrusionHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Cuán lejos la forma se extiende hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [getExtrusionColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color lateral con el relleno frontal. |
| [getDepth](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getDepth--) y [setDepth](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setDepth-double-) | Profundidad 3D adicional usada por el formato 3D de PowerPoint. | Afinar la profundidad de formas o texto, especialmente junto con los ajustes de bisel y material. |
| [getBevelTop](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getBevelTop--) y [getBevelBottom](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getBevelBottom--) | Bordes elevados o redondeados en las caras frontal y posterior. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [getContourColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getContourColor--) y [getContourWidth](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getContourWidth--) y [setContourWidth](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Contorno alrededor del objeto 3D. | Resaltar el límite del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de configuraciones antes de parecer convincentemente 3D:

- Configuración de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuración de luz, porque la iluminación hace que las caras y los lados sean visibles.
- Configuración de material, porque la superficie afecta cómo se renderiza la luz.
- Configuración de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal y aplica formato 3D. Los valores de rotación de la cámara están en grados, y la altura de extrusión es de 100 puntos. El ejemplo renderiza la diapositiva a una imagen PNG con el doble de sus dimensiones predeterminadas y guarda la presentación como PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel Rotación 3‑D. Los valores de rotación X, Y y Z corresponden a la rotación que estableces mediante la API de cámara.

![Panel Rotación 3‑D de PowerPoint con valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, accede a la cámara mediante [ThreeDFormat::getCamera](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getCamera--). Este ejemplo crea un rectángulo, selecciona una vista frontal ortográfica y establece sus rotaciones X, Y y Z a 20, 30 y 40 grados, respectivamente. Configura la forma en memoria sin guardar un archivo:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Utiliza la cámara cuando necesites cambiar cómo el espectador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D utilizado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint asignados al color de extrusión y a las propiedades de altura de extrusión](img_02_02.png)

Utiliza [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) para establecer el grosor y [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#getExtrusionColor--) para acceder al color de los laterales. Este ejemplo da a un rectángulo una extrusión de 100 puntos con lados púrpuras y rota la cámara para revelar su grosor. Configura la forma en memoria sin guardar un archivo:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

El método [ThreeDFormat::setDepth](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setDepth-double-) establece la profundidad de una forma 3D. El método [setExtrusionHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) controla la altura del efecto de extrusión, como se muestra en este ejemplo.

## **Utilizar rellenos de degradado o imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando los mismos ajustes de cámara, luz, material y extrusión.

Este ejemplo aplica un degradado de azul a naranja a la cara frontal y un color naranja oscuro a la extrusión de 150 puntos. Las paradas del degradado en 0 y 100 indican el inicio y el final del degradado. Los valores de rotación de la cámara están en grados. La diapositiva se renderiza a una imagen PNG con el doble de sus dimensiones predeterminadas:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![Rectángulo 3D renderizado con relleno de degradado azul‑a‑naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añade la imagen a la presentación y asígnala al relleno de la forma. Este ejemplo requiere un archivo existente llamado "image.jpg" en el directorio de trabajo. Estira la imagen para llenar el rectángulo, aplica una extrusión de 150 puntos y establece la rotación de la cámara en grados. Configura la forma en memoria sin guardar ni renderizar un archivo:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

![Rectángulo 3D renderizado con relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de una forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las propias letras necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un patrón de cuadrícula naranja y blanco, aplica un arco ascendente y configura los ajustes 3D mediante [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#getThreeDFormat--). La altura de extrusión y la profundidad están en puntos, y la rotación de la luz está en grados. El relleno y contorno de la forma están ocultos para que solo sea visible el texto. El ejemplo renderiza una imagen PNG al doble de las dimensiones predeterminadas de la diapositiva y guarda la presentación como PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Texto 3D renderizado con transformación de WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Mantener el texto plano en una forma 3D**

Para mantener el texto legible mientras se preserva la apariencia 3D de una forma, llama a [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) a través de [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getTextFrameFormat--). Cuando el valor es `true`, el texto permanece fuera de la escena 3D. Cuando es `false`, el texto participa en la escena y sigue su orientación 3D.

Este ajuste no elimina el formato 3D de la forma: su cámara, iluminación, material y extrusión siguen configurados mediante [Shape::getThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getThreeDFormat--). También es diferente de la rotación ordinaria. [Shape::setRotation](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#setRotation-float-) rota la forma en el plano de la diapositiva, mientras que [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) controla la rotación personalizada del texto dentro de su cuadro delimitador. Mantener el texto fuera de la escena 3D no restablece ninguno de esos ángulos.

El siguiente ejemplo autónomo crea un rectángulo azul con texto y lo clona al lado del original. Ambas formas tienen el mismo formato 3D; solo difiere el ajuste de texto: `false` a la izquierda y `true` a la derecha. Los ángulos de la cámara están en grados y la altura de extrusión es de 40 puntos. El ejemplo guarda la presentación como PPTX y renderiza la diapositiva comparativa a PNG con el doble de sus dimensiones predeterminadas.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![Rectángulos 3D lado a lado: el texto sigue la orientación 3D a la izquierda y permanece plano a la derecha](keep_text_flat.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderizas diapositivas a [PNG](/slides/es/php-java/convert-powerpoint-to-png/), exportas a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), exportas a [HTML](/slides/es/php-java/convert-powerpoint-to-html/), o generas fotogramas para [conversión de video](/slides/es/php-java/convert-powerpoint-to-video/).

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede ser rotado por el espectador después de la exportación.
- El aspecto final depende de la combinación de cámara, conjunto de luces, material, extrusión, relleno y escalado de la diapositiva.
- Si necesitas inspeccionar valores de formato heredados o basados en el tema, lee las [propiedades efectivas de la forma](/slides/es/php-java/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de conservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte las imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D sigue siendo editable en PowerPoint cuando el formato lo permite.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto normal de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre los efectos 3D.

**¿Qué configuraciones son necesarias para una forma 3D visible?**

Como mínimo, establece una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configura un conjunto de luces y material para que las caras renderizadas tengan realces y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Utiliza [Shape::getThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getThreeDFormat--) para el cuerpo de la forma y [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/#getThreeDFormat--) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?**

Sí. Aspose.Slides renderiza los efectos 3D al producir imágenes de diapositivas, salida PDF, salida HTML y fotogramas utilizados para la conversión a vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores 3D finales después de aplicar la herencia y la configuración del tema?**

Sí. Utiliza las APIs de formato efectivo descritas en [Propiedades efectivas de la forma](/slides/es/php-java/shape-effective-properties/) para leer la cámara, conjunto de luces, bisel y los valores 3D relacionados finales.