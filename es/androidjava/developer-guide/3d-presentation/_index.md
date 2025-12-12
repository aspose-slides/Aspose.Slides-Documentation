---
title: Crear presentaciones 3D en Android
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
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Cree presentaciones 3D interactivas en Java con Aspose.Slides para Android sin esfuerzo. Exporte rápidamente a formatos PowerPoint y OpenDocument para un uso versátil."
---

## **Visión general**
Desde Aspose.Slides Java 20.9 es posible crear 3D en presentaciones. PowerPoint 3D es una forma de dar vida a las presentaciones. Muestra objetos del mundo real con presentaciones 3D, demuestra un modelo 3D de tu futuro proyecto empresarial, un modelo 3D del edificio o su interior, un modelo 3D del personaje del juego, o simplemente una representación 3D de tus datos. 

Los modelos 3D de PowerPoint pueden crearse a partir de formas 2D, aplicando efectos como: rotación 3D, profundidad y extrusión 3D, degradado 3D, texto 3D, etc. La lista de funciones 3D aplicables a las formas se encuentra en la clase **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. La instancia de la clase se puede obtener mediante:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** para crear un modelo 3D de PowerPoint.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** para crear un Texto 3D (WordArt).

Todos los efectos implementados en **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** pueden usarse tanto para formas como para texto. Veamos rápidamente los principales métodos de la clase **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**. En el siguiente ejemplo creamos una forma rectangular 2D con texto. Al obtener una vista de cámara sobre la forma, cambiamos su rotación y la hacemos ver como un modelo 3D. Configurando una luz plana y su dirección hacia la parte superior del modelo 3D, se aporta más volumen al modelo. Cambiar los materiales, la altura de extrusión y el color hacen que el modelo 3D parezca más vivo.  
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

## **Rotación 3D**
La rotación del modelo 3D en PowerPoint puede hacerse mediante el menú:

![todo:image_alt_text](img_02_01.png)

Para rotar un modelo 3D con la API de Aspose.Slides, use el método **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**, estableciendo la rotación de la cámara en relación con la forma 3D:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... establece otros parámetros de la escena 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


## **Profundidad y extrusión 3D**
Los métodos **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** y **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** se usan para crear extrusión en la forma:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... establece otros parámetros de la escena 3D

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


En PowerPoint, la profundidad de la forma se establece mediante:

![todo:image_alt_text](img_02_02.png)

## **Degradado 3D**
El degradado 3D puede aportar más volumen a una forma 3D de PowerPoint:
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

## **Texto 3D (WordArt)**
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
// set the "Arch Up" WordArt transform effect
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

## **FAQ**

**¿Se conservarán los efectos 3D al exportar una presentación a imágenes/PDF/HTML?**

Sí. El motor 3D de Slides renderiza los efectos 3D al exportar a formatos compatibles ([imágenes](/slides/es/androidjava/convert-powerpoint-to-png/), [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), etc.).

**¿Puedo obtener los valores "efectivos" (finales) de los parámetros 3D que tienen en cuenta temas, herencia, etc.?**

Sí. Slides ofrece API para [leer valores efectivos](/slides/es/androidjava/shape-effective-properties/) (incluidos los de 3D—iluminación, biseles, etc.) para que pueda ver la configuración final aplicada.

**¿Funcionan los efectos 3D al convertir una presentación a video?**

Sí. Al [generar fotogramas para el video](/slides/es/androidjava/convert-powerpoint-to-video/), los efectos 3D se renderizan igual que en las [imágenes exportadas](/slides/es/androidjava/convert-powerpoint-to-png/).