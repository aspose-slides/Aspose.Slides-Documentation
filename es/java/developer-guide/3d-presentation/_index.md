---
title: Crear presentaciones 3D en Java
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Genera presentaciones 3D interactivas en Java con Aspose.Slides sin esfuerzo. Exporta rápidamente a formatos PowerPoint y OpenDocument para uso versátil."
---

## Descripción general
Desde Aspose.Slides Java 20.9 es posible crear 3D en presentaciones. PowerPoint 3D es una forma de dar vida a las presentaciones. Muestra objetos del mundo real con una presentación 3D, demuestra el modelo 3D de tu futuro proyecto empresarial, el modelo 3D del edificio o su interior, el modelo 3D del personaje del juego, o simplemente una representación 3D de tus datos.

Los modelos 3D de PowerPoint pueden crearse a partir de formas 2D, aplicándoles efectos como: rotación 3D, profundidad y extrusión 3D, degradado 3D, texto 3D, etc. La lista de características 3D aplicables a las formas se encuentra en la clase **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. La instancia de la clase puede obtenerse mediante:

- el método **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getThreeDFormat--)** para crear un modelo 3D de PowerPoint.
- el método **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** para crear texto 3D (WordArt).

Todos los efectos implementados en **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)** pueden usarse tanto para formas como para texto. Veamos rápidamente los métodos principales de la clase **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**. En el siguiente ejemplo creamos una forma rectangular 2D con texto. Al obtener la vista de cámara sobre la forma, cambiamos su rotación y la hacemos parecer un modelo 3D. Al configurar una luz plana y su dirección hacia la parte superior del modelo 3D, le damos más volumen. Los materiales cambiados, la altura de extrusión y el color hacen que el modelo 3D parezca más vivo.  
``` java 
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("sandbox_3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```


Aquí está el modelo 3D resultante:

![todo:image_alt_text](img_01_01.png)

## Rotación 3D
La rotación del modelo 3D en PowerPoint se puede hacer mediante el menú:

![todo:image_alt_text](img_02_01.png)

Para rotar el modelo 3D con la API Aspose.Slides, use el método **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getCamera--)**, estableciendo la rotación de la cámara respecto a la forma 3D:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... establecer otros parámetros de escena 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


## Profundidad y extrusión 3D
Los métodos **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** y **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** se utilizan para crear extrusión en la forma:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... establecer otros parámetros de escena 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


En PowerPoint, la profundidad de la forma se configura mediante:

![todo:image_alt_text](img_02_02.png)

## Degradado 3D
El degradado 3D puede aportar más volumen a la forma 3D de PowerPoint:
``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getFillFormat().setFillType(FillType.Gradient);
shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.dispose();
```


Así es como se ve:

![todo:image_alt_text](img_02_03.png)
  
También puede crear un degradado de imagen:
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... configurar 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propiedades

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


Este es el resultado:

![todo:image_alt_text](img_02_04.png)

## Texto 3D (WordArt)
Para crear un texto 3D (WordArt), haga lo siguiente:
``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getFillFormat().setFillType(FillType.NoFill);
shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
shape.getTextFrame().setText("3D Text");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// establecer el efecto de transformación WordArt "Arch Up"
textFrameFormat.setTransform(TextShapeType.ArchUp);

textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
textFrameFormat.getThreeDFormat().setDepth(3);
textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("text3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("text3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```


Este es el resultado:

![todo:image_alt_text](img_02_05.png)

## No compatible - Próximamente
Las siguientes características 3D de PowerPoint aún no son compatibles:
- Bisel
- Material
- Contorno
- Iluminación