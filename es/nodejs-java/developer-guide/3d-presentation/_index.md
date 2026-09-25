---
title: Crear efectos 3D en presentaciones usando Node.js
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- Presentación 3D
- Rotación 3D
- Profundidad 3D
- Extrusión 3D
- Degradado 3D
- Texto 3D
- PowerPoint
- Presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en Node.js con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Descripción general**

Aspose.Slides for Node.js via Java puede crear, editar, preservar y representar el formato 3D estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos degradados o de imagen, y texto 3D.

{{% alert color="info" title="Note" %}}

Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exporta una diapositiva a una imagen, PDF o HTML, Aspose.Slides representa esos efectos 3D en la salida 2D exportada.

{{% /alert %}}

## **Conceptos de formato 3D**

Utilice el método [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getThreeDFormat) para aplicar formato 3D a una forma. El método devuelve [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/), que controla la escena 3D de esa forma.

Para texto, utilice el método [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los miembros de API más importantes son:

| Miembro de API | Qué controla | Cuándo usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getCamera) | Punto de vista, tipo de cámara preestablecida, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un preajuste de rotación 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getLightRig) | Luz preestablecida, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getMaterial) y [setMaterial](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setMaterial) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) y [setExtrusionHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Cuán lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [getExtrusionColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color del lado con el relleno frontal. |
| [getDepth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getDepth) y [setDepth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setDepth) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad de formas o texto, especialmente junto con biseles y material. |
| [getBevelTop](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getBevelTop) y [getBevelBottom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Bordes elevados o redondeados en las caras frontal y trasera. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [getContourColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getContourWidth) y [setContourWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contorno alrededor del objeto 3D. | Resaltar el borde del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de ajustes antes de que parezca convincentemente 3D:

- Ajustes de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Ajustes de luz, porque la iluminación hace que las caras y los lados sean legibles.
- Ajustes de material, porque la superficie afecta cómo se renderiza la luz.
- Ajustes de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal y aplica formato 3D. Los valores de rotación de la cámara están en grados y la altura de extrusión es de 100 puntos. El ejemplo representa la diapositiva en una imagen PNG al doble de sus dimensiones predeterminadas y guarda la presentación como PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel 3‑D Rotation. Los valores de rotación X, Y y Z corresponden a la rotación que establece a través de la API de cámara.

![Panel 3‑D Rotation de PowerPoint con valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, acceda a la cámara mediante [ThreeDFormat.getCamera](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getCamera). Este ejemplo crea un rectángulo, selecciona una vista frontal ortográfica y establece sus rotaciones X, Y y Z en 20, 30 y 40 grados, respectivamente. Configura la forma en memoria sin guardar un archivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Utilice la cámara cuando necesite cambiar cómo el observador ve el objeto. No cambia la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D utilizado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad define este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint vinculados a las propiedades de color y altura de extrusión](img_02_02.png)

Utilice [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) para establecer el grosor y [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) para acceder al color lateral. Este ejemplo da a un rectángulo una extrusión de 100 puntos con lados púrpuras y rota la cámara para revelar su grosor. Configura la forma en memoria sin guardar un archivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

El método [ThreeDFormat.setDepth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setDepth) define la profundidad de una forma 3D. El método [setExtrusionHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) controla la altura del efecto de extrusión, como se muestra en este ejemplo.

## **Usar rellenos degradados o de imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puede aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un degradado azul‑a‑naranja a la cara frontal y un color naranja oscuro a la extrusión de 150 puntos. Las paradas del degradado en 0 y 100 marcan el inicio y el final del degradado. Los valores de rotación de la cámara están en grados. La diapositiva se representa en una imagen PNG al doble de sus dimensiones predeterminadas:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

La salida renderizada mantiene el degradado en la cara frontal y representa la extrusión por separado:

![Rectángulo 3D renderizado con relleno degradado azul‑a‑naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añada la imagen a la presentación y asígnela al relleno de la forma. Este ejemplo requiere un archivo existente llamado “image.jpg” en el directorio de trabajo. Estira la imagen para llenar el rectángulo, aplica una extrusión de 150 puntos y establece la rotación de la cámara en grados. Configura la forma en memoria sin guardar ni renderizar un archivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

La imagen se representa en la cara frontal, mientras que la extrusión se representa como la superficie lateral 3D:

![Rectángulo 3D renderizado con relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las propias letras necesitan extrusión, material, iluminación y ajustes de cámara.

El siguiente ejemplo crea texto con un patrón de cuadrícula naranja‑blanco, aplica un arco ascendente y configura ajustes 3D mediante [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). La altura de extrusión y la profundidad están en puntos, y la rotación de la luz está en grados. El relleno y el contorno de la forma están ocultos para que solo sea visible el texto. El ejemplo representa una imagen PNG al doble de las dimensiones predeterminadas de la diapositiva y guarda la presentación como PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El texto se representa como letras 3D curvadas y extruidas:

![Texto 3D renderizado con transformación de WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Mantener el texto plano en una forma 3D**

Para que el texto siga siendo legible conservando la apariencia 3D de la forma, llame a [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) a través de [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Cuando el valor es `true`, el texto permanece fuera de la escena 3D. Cuando es `false`, el texto participa en la escena y sigue su orientación 3D.

Este ajuste no elimina el formato 3D de la forma: su cámara, iluminación, material y extrusión siguen configurados mediante [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getThreeDFormat). También difiere de la rotación ordinaria. [Shape.setRotation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#setRotation) rota la forma en el plano de la diapositiva, mientras que [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) controla la rotación personalizada del texto dentro de su cuadro delimitador. Mantener el texto fuera de la escena 3D no restablece ninguno de esos ángulos.

El siguiente ejemplo autónomo crea un rectángulo azul con texto y lo clona junto al original. Ambas formas tienen el mismo formato 3D; solo difiere el ajuste de texto: `false` a la izquierda y `true` a la derecha. Los ángulos de cámara están en grados y la altura de extrusión es de 40 puntos. El ejemplo guarda la presentación como PPTX y representa la diapositiva de comparación en PNG al doble de sus dimensiones predeterminadas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

A la izquierda, el texto sigue la orientación 3D. A la derecha, permanece plano y es más fácil de leer. Ambos rectángulos conservan la misma extrusión visible y orientación 3D.

![Rectángulos 3D lado a lado: el texto sigue la orientación 3D a la izquierda y permanece plano a la derecha](keep_text_flat.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderiza diapositivas a [PNG](/slides/es/nodejs-java/convert-powerpoint-to-png/), exporta a [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), exporta a [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), o genera fotogramas para la [conversión de video](/slides/es/nodejs-java/convert-powerpoint-to-video/).

Tenga en cuenta los siguientes puntos:

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede ser rotado por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, rig de luz, material, extrusión, relleno y escala de la diapositiva.
- Si necesita inspeccionar valores de formato heredados o basados en temas, lea las [propiedades efectivas de la forma](/slides/es/nodejs-java/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y representa efectos 3D de PowerPoint para formas y texto. No convierte imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D permanece editable en PowerPoint donde el formato lo soporta.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es formato aplicado a una forma o texto normal de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre efectos 3D.

**¿Qué ajustes son necesarios para una forma 3D visible?**

Como mínimo, establezca una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configure un rig de luz y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Utilice [Shape.getThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getThreeDFormat) para el cuerpo de la forma y [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?**

Sí. Aspose.Slides representa los efectos 3D al producir imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para la conversión de vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores finales 3D después de aplicar herencia y ajustes de tema?**

Sí. Utilice las API de formato efectivo descritas en [Propiedades efectivas de la forma](/slides/es/nodejs-java/shape-effective-properties/) para leer la cámara final, rig de luz, bisel y valores 3D relacionados.