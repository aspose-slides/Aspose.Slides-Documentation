---
title: Formato de Formas
type: docs
weight: 20
url: /es/androidjava/shape-formatting/
keywords: "Formato de formas, formato de líneas, estilos de unión, relleno degradado, relleno de patrones, relleno de imágenes, relleno de color sólido, rotar formas, efectos de bisel 3d, efecto de rotación 3d, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Formato de formas en presentación de PowerPoint en Java"
---

En PowerPoint, puedes agregar formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes formatear formas modificando o aplicando ciertos efectos a sus líneas constitutivas. Además, puedes formatear formas especificando configuraciones que determinan cómo se rellenan (el área en ellas).

![formato-forma-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides para Android a través de Java** proporciona interfaces y propiedades que te permiten formatear formas basadas en opciones conocidas en PowerPoint.

## **Formato de Líneas**

Usando Aspose.Slides, puedes especificar tu estilo de línea preferido para una forma. Estos pasos describen tal procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Establece un color para las líneas de la forma.
5. Establece el ancho para las líneas de la forma.
6. Establece el [estilo de línea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) para la línea de la forma.
7. Establece el [estilo de guiones](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) para la línea de la forma.
8. Escribe la presentación modificada como un archivo PPTX.

Este código Java demuestra una operación en la que formateamos un `AutoShape` rectangular:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega autoshape de tipo rectángulo
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Establece el color de relleno para la forma rectangular
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // Aplica algún formato a las líneas del rectángulo
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Establece el color para la línea del rectángulo
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Escribe el archivo PPTX en el disco
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formato de Estilos de Unión**
Estas son las 3 opciones de tipo de unión:

* Redondeada
* Canto
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (o la esquina de una forma), utiliza la configuración **Redondeada**. Sin embargo, si deseas dibujar una forma con ángulos muy agudos, puedes querer seleccionar **Canto**.

![estilo-de-unión-powerpoint](join-style-powerpoint.png)

Este Java demuestra una operación donde se crearon 3 rectángulos (la imagen arriba) con las configuraciones de tipo de unión Canto, Bisel y Redondeada:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {

    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega 3 autoshapes de rectángulo
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // Establece el color de relleno para la forma rectangular
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Establece el ancho de la línea
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // Establece el color para la línea del rectángulo
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Establece el Estilo de Unión
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Agrega texto a cada rectángulo
    ((IAutoShape)shp1).getTextFrame().setText("Estilo de Unión Canto");
    ((IAutoShape)shp2).getTextFrame().setText("Estilo de Unión Bisel");
    ((IAutoShape)shp3).getTextFrame().setText("Estilo de Unión Redondeada");

    // Escribe el archivo PPTX en el disco
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Relleno Degradado**
En PowerPoint, el Relleno Degradado es una opción de formato que te permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores en una configuración donde un color se desvanece gradualmente y se transforma en otro color. 

Así es como usas Aspose.Slides para aplicar un relleno degradado a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forma a `Gradient`.
5. Agrega tus 2 colores preferidos con posiciones definidas utilizando los métodos `Add` expuestos por la colección `GradientStops` asociada con la clase `GradientFormat`.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Java demuestra una operación donde se utilizó el efecto de relleno degradado en una elipse:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega una autoshape de elipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Aplica el formato degradado a la elipse
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Establece la dirección del degradado
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Agrega 2 puntos de degradado
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Escribe el archivo PPTX en el disco
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Relleno de Patrones**
En PowerPoint, el Relleno de Patrones es una opción de formato que te permite aplicar un diseño de dos colores compuesto por puntos, rayas, sombreados cruzados o cuadros a una forma. Además, puedes seleccionar los colores que prefieras para el primer plano y el fondo de tu patrón. 

Aspose.Slides proporciona más de 45 estilos predefinidos que se pueden utilizar para formatear formas y enriquecer presentaciones. Incluso después de elegir un patrón predefinido, aún puedes especificar los colores que debe contener el patrón.

Así es como usas Aspose.Slides para aplicar un relleno de patrón a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forma a `Pattern`.
5. Establece tu estilo de patrón preferido para la forma. 
6. Establece el [Color de Fondo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--) para el [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
7. Establece el [Color de Primer Plano](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--) para el [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat).
8. Escribe la presentación modificada como un archivo PPTX.

Este código Java demuestra una operación donde se utilizó un relleno de patrones para embellecer un rectángulo: 

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega una autoshape de rectángulo
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Establece el tipo de relleno a Patrón
    shp.getFillFormat().setFillType(FillType.Pattern);

    // Establece el estilo del patrón
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Establece los colores de fondo y primer plano del patrón
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Escribe el archivo PPTX en el disco
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Relleno de Imágenes**
En PowerPoint, el Relleno de Imágenes es una opción de formato que te permite colocar una imagen dentro de una forma. Esencialmente, puedes usar una imagen como fondo de una forma. 

Así es como usas Aspose.Slides para rellenar una forma con una imagen:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forma a `Picture`.
5. Establece el modo de relleno de imagen a Tile.
6. Crea un objeto `IPPImage` usando la imagen que se utilizará para rellenar la forma.
7. Establece la propiedad `Picture.Image` del objeto `PictureFillFormat` al `IPPImage` recién creado.
8. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo rellenar una forma con una imagen:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega una autoshape de rectángulo
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // Establece el tipo de relleno a Imagen
    shp.getFillFormat().setFillType(FillType.Picture);

    // Establece el modo de relleno de imagen
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Establece la imagen
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Escribe el archivo PPTX en el disco
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Relleno de Color Sólido**
En PowerPoint, el Relleno de Color Sólido es una opción de formato que te permite rellenar una forma con un solo color. El color elegido es típicamente un color puro. El color se aplica al fondo de la forma sin ningún efecto especial o modificaciones. 

Así es como usas Aspose.Slides para aplicar un relleno de color sólido a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) de la forma a `Solid`.
5. Establece tu color preferido para la forma.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo aplicar el relleno de color sólido a una caja en PowerPoint:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega una autoshape de rectángulo
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Establece el tipo de relleno a Sólido
    shape.getFillFormat().setFillType(FillType.Solid);

    // Establece el color para el rectángulo
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Escribe el archivo PPTX en el disco
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Transparencia**

En PowerPoint, cuando rellenas formas con colores sólidos, degradados, imágenes o texturas, puedes especificar el nivel de transparencia que determina la opacidad de un relleno. De esta manera, por ejemplo, si estableces un bajo nivel de transparencia, el objeto o fondo de la diapositiva detrás (de la forma) se ve a través. 

Aspose.Slides te permite establecer el nivel de transparencia para una forma de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Usa `new Color` con el componente alfa establecido.
5. Guarda el objeto como un archivo de PowerPoint. 

Este código Java demuestra el proceso:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega una forma sólida
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // Agrega una forma transparente sobre la forma sólida
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // Escribe el archivo PPTX en el disco
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rotar Formas**
Aspose.Slides te permite rotar una forma añadida a una diapositiva de esta manera: 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Rota la forma por los grados necesarios. 
5. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo rotar una forma 90 grados:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega una autoshape de rectángulo
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Rota la forma 90 grados
    shp.setRotation(90);

    // Escribe el archivo PPTX en el disco
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Efectos de Bisel 3D**
Aspose.Slides te permite agregar efectos de bisel 3D a una forma modificando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Establece tus parámetros preferidos para las propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) de la forma.
5. Escribe la presentación en el disco.

Este código Java te muestra cómo agregar efectos de bisel 3D a una forma:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega una forma a la diapositiva
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Establece las propiedades ThreeDFormat de la forma
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Escribe la presentación como un archivo PPTX
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Efecto de Rotación 3D**
Aspose.Slides te permite aplicar efectos de rotación 3D a una forma modificando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) a la diapositiva.
4. Especifica tus figuras preferidas para [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--) y [LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--).
5. Escribe la presentación en disco. 

Este código Java te muestra cómo aplicar efectos de rotación 3D a una forma:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Escribe la presentación como un archivo PPTX
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Restablecer Formato**

Este código Java te muestra cómo restablecer el formato en una diapositiva y revertir la posición, tamaño y formato de cada forma que tiene un marcador de posición en la [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutSlide) a sus valores predeterminados:

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // cada forma en la diapositiva que tiene un marcador de posición en el diseño será revertida
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```