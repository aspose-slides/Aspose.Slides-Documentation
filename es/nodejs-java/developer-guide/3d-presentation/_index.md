---
title: Presentación 3D
type: docs
weight: 232
url: /es/nodejs-java/3d-presentation/
---

## **Visión general**

Desde Aspose.Slides for Java 20.9 es posible crear 3D en presentaciones. PowerPoint 3D es una forma de dar vida a las presentaciones. Muestra objetos del mundo real con una presentación 3D, demuestra un modelo 3D de tu futuro proyecto empresarial, un modelo 3D del edificio o su interior, un modelo 3D del personaje de un juego, o simplemente una representación 3D de tus datos. 

Los modelos 3D de PowerPoint se pueden crear a partir de formas 2D, aplicándoles efectos como: rotación 3D, profundidad y extrusión 3D, degradado 3D, texto 3D, etc. La lista de funciones 3D aplicadas a las formas se encuentra en la clase **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. La instancia de la clase se puede obtener mediante:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getThreeDFormat--)** método para crear un modelo 3D de PowerPoint.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** método para crear un texto 3D (WordArt).

Todos los efectos implementados en **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** pueden usarse tanto para formas como para texto. Echemos un vistazo rápido a los principales métodos de la clase **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. En el siguiente ejemplo creamos una forma rectangular 2D con texto. Al obtener la vista de cámara sobre la forma, cambiamos su rotación y logramos que se vea como un modelo 3D. Configurar una luz plana y su dirección hacia la parte superior del modelo 3D aporta más volumen al modelo. Los materiales modificados, la altura de extrusión y el color hacen que el modelo 3D parezca más vivo.  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("sandbox_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Este es el modelo 3D resultante:

![todo:image_alt_text](img_01_01.png)

## **Rotación 3D**

La rotación del modelo 3D en PowerPoint puede realizarse mediante el menú:

![todo:image_alt_text](img_02_01.png)

Para rotar un modelo 3D con la API de Aspose.Slides, utilice el método **[ThreeDFormat.getCamera()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getCamera--)**, establezca la rotación de la cámara en relación con la forma 3D:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... establecer otros parámetros de la escena 3D
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


## **Profundidad y Extrusión 3D**

Los métodos **[ThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** y **[ThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** se utilizan para crear extrusión en una forma:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 128, 0, 128));
// ... establecer otros parámetros de la escena 3D
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


En PowerPoint, la profundidad de la forma se establece mediante:

![todo:image_alt_text](img_02_02.png)

## **Degradado 3D**

El degradado 3D puede aportar más volumen a la forma 3D de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Así es como se ve:

![todo:image_alt_text](img_02_03.png)
  
También puede crear un degradado de imagen:
```javascript
shape.getFillFormat().setFillType(java.newByte(java.newByteaspose.slides.FillType.Picture));
var picture;
var image = aspose.slides.Images.fromFile("image.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) {
        image.dispose();
    }
}
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
// .. configurar 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propiedades
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


Este es el resultado:

![todo:image_alt_text](img_02_04.png)

## **Texto 3D (WordArt)**

Para crear un texto 3D (WordArt), haga lo siguiente:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");
    var portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
    var textFrame = shape.getTextFrame();
    // configurar efecto de transformación WordArt "Arch Up"
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("text3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Este es el resultado:

![todo:image_alt_text](img_02_05.png)

## **Preguntas frecuentes**

**¿Se conservarán los efectos 3D al exportar una presentación a imágenes/PDF/HTML?**

Sí. El motor 3D de Slides renderiza los efectos 3D al exportar a formatos compatibles ([images](/slides/es/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), etc.).

**¿Puedo obtener los valores "efectivos" (finales) de los parámetros 3D que tienen en cuenta temas, herencia, etc.?**

Sí. Slides ofrece APIs para [leer valores efectivos](/slides/es/nodejs-java/shape-effective-properties/) (incluidos los de 3D—iluminación, biseles, etc.) para que pueda ver la configuración final aplicada.

**¿Los efectos 3D funcionan al convertir una presentación a video?**

Sí. Al [generar los fotogramas para el video](/slides/es/nodejs-java/convert-powerpoint-to-video/), los efectos 3D se renderizan de la misma manera que para las [imágenes exportadas](/slides/es/nodejs-java/convert-powerpoint-to-png/).