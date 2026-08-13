---
title: Crear efectos 3D en presentaciones en Android
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en Android con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides for Android via Java puede crear, editar, conservar y renderizar el formato 3D al estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos de degradado o imagen y texto 3D.

{{% alert color="info" %}}

Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No trata sobre la inserción o edición de archivos de modelo 3D independientes. Cuando exporta una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.

{{% /alert %}}

## **Conceptos de formato 3D**

Utilice el método [IShape.getThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para aplicar formato 3D a una forma. El método devuelve [IThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/), que controla la escena 3D para esa forma.

Para texto, utilice el método [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los miembros de API más importantes son:

| Miembro de API | Qué controla | Cuándo usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Punto de vista, tipo de cámara predeterminada, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un preajuste de rotación 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Preajuste de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los brillos y sombras en la superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) y [setMaterial](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) y [setExtrusionHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Qué tan lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [getExtrusionColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color lateral con el relleno frontal. |
| [getDepth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getDepth--) y [setDepth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profundidad 3D adicional usada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad para formas o texto, especialmente junto con biseles y material. |
| [getBevelTop](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) y [getBevelBottom](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordes elevados o redondeados en las caras frontal y posterior. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [getContourColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), y [setContourWidth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno alrededor del objeto 3D. | Resaltar el borde del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma suele necesitar cuatro tipos de ajustes antes de parecer convincentemente 3D:

- Configuraciones de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuraciones de luz, porque la iluminación hace que las caras y los lados sean legibles.
- Configuraciones de material, porque la superficie afecta cómo se renderiza la luz.
- Configuraciones de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal, aplica formato 3D, guarda la presentación como PPTX y renderiza la diapositiva a una imagen PNG.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel Rotación 3‑D. Los valores de rotación X, Y y Z corresponden a la rotación que establece a través de la API de cámara.

![Panel Rotación 3‑D de PowerPoint con los valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, establezca el tipo de cámara y la rotación mediante [IThreeDFormat.getCamera](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Utilice la cámara cuando necesite cambiar cómo el espectador ve el objeto. No cambia la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D usado por PowerPoint y por Aspose.Slides al renderizar.

## **Agregar extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint mapeados a las propiedades de color de extrusión y altura de extrusión](img_02_02.png)

Establezca [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) para el grosor y [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) para el color lateral:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Utilice [IThreeDFormat.setDepth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) cuando necesite trabajar directamente con el valor de profundidad de PowerPoint o combinar profundidad con bisel, material y efectos de texto. En muchos escenarios de forma, `setExtrusionHeight` es la opción más clara porque expresa directamente la extrusión visible.

## **Usar rellenos de degradado o imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puede aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y ajustes de extrusión.

Este ejemplo aplica un relleno de degradado a la forma y un color de extrusión más oscuro a los lados:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

La salida renderizada conserva el degradado en la cara frontal y renderiza la extrusión por separado:

![Rectángulo 3D renderizado con un relleno de degradado azul‑a‑naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, añada la imagen a la presentación y asígnela al relleno de la forma:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

La imagen se renderiza en la cara frontal, mientras que la extrusión se muestra como la superficie lateral 3D:

![Rectángulo 3D renderizado con un relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las letras mismas necesitan extrusión, material, iluminación y configuración de cámara.

El siguiente ejemplo crea texto con un relleno de patrón, aplica una transformación WordArt y configura los ajustes 3D en [ITextFrameFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/):

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El texto se renderiza como letras 3D curvadas y extruidas:

![Texto 3D renderizado con una transformación WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto ocurre cuando renderiza diapositivas a [PNG](/slides/es/androidjava/convert-powerpoint-to-png/), exporta a [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), exporta a [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), o genera fotogramas para [conversión de vídeo](/slides/es/androidjava/convert-powerpoint-to-video/).

Tenga en cuenta estos puntos:

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede rotarse por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, conjunto de luces, material, extrusión, relleno y escala de la diapositiva.
- Si necesita inspeccionar valores de formato heredados o basados en el tema, lea las [propiedades efectivas de la forma](/slides/es/androidjava/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

### ¿Puede Aspose.Slides crear presentaciones 3D interactivas?

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que un espectador pueda rotar. En PPTX, el formato 3D permanece editable en PowerPoint donde el formato lo permite.

### ¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto de PowerPoint convencional, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre efectos 3D.

### ¿Qué ajustes son necesarios para que una forma 3D sea visible?

Como mínimo, establezca una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configure un conjunto de luces y material para que las caras renderizadas tengan brillos y sombras claros.

### ¿Puedo aplicar efectos 3D tanto a formas como a texto?

Sí. Utilice [IShape.getThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para el cuerpo de la forma y [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) para el texto.

### ¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de vídeo?

Sí. Aspose.Slides renderiza los efectos 3D al producir imágenes de diapositivas, salida PDF, salida HTML y fotogramas utilizados para la conversión a vídeo. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

### ¿Puedo leer los valores 3D finales después de aplicar herencia y ajustes de tema?

Sí. Utilice las API de formato efectivo descritas en [Propiedades efectivas de la forma](/slides/es/androidjava/shape-effective-properties/) para leer la cámara final, conjunto de luces, bisel y valores 3D relacionados.