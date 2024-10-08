---
title: WordArt
type: docs
weight: 110
url: /es/java/wordart/
---


## **¿Qué es WordArt?**
WordArt o Word Art es una función que te permite aplicar efectos a los textos para que se destaquen. Con WordArt, por ejemplo, puedes contornear un texto o llenarlo con un color (o degradado), agregarle efectos 3D, etc. También puedes distorsionar, doblar y estirar la forma de un texto.

{{% alert color="primary" %}} 

WordArt te permite tratar un texto como lo harías con un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales realizadas a los textos para hacerlos más atractivos o notorios.

{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, tienes que seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o su forma.

**WordArt en Aspose.Slides**

En Aspose.Slides para Java 20.10, implementamos soporte para WordArt y realizamos mejoras en la función en lanzamientos posteriores de Aspose.Slides para Java.

Con Aspose.Slides para Java, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o combinación de efectos) en Java y aplicarla a textos.

## Crear una Plantilla de WordArt Simple y Aplicarla a un Texto

**Usando Aspose.Slides** 

Primero, creamos un texto simple usando este código Java: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Ahora, establecemos la altura de la fuente del texto a un valor mayor para hacer el efecto más notable a través de este código:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Usando Microsoft PowerPoint**

Ve al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Desde el menú de la derecha, puedes elegir un efecto de WordArt predefinido. Desde el menú de la izquierda, puedes especificar los ajustes para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color de patrón [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) al texto y agregamos un borde de texto negro de 1 de ancho usando este código:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## Aplicando Otros Efectos de WordArt

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, se pueden aplicar efectos de Sombra, Reflejo y Resplandor a un texto; efectos de Formato 3D y Rotación 3D se pueden aplicar a un bloque de texto; la propiedad de Bordes Suaves se puede aplicar a un Objeto de Forma (todavía tiene un efecto cuando no se establece la propiedad de Formato 3D).

### Aplicando Efectos de Sombra

Aquí, pretendemos establecer las propiedades relacionadas solo con un texto. Aplicamos el efecto de sombra a un texto usando este código en Java:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API soporta tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow.

Con PresetShadow, puedes aplicar una sombra a un texto (usando valores preestablecidos).

**Usando Microsoft PowerPoint**

En PowerPoint, puedes usar un tipo de sombra. Aquí hay un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides en realidad te permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando OuterShadow y PresetShadow se usan juntos, solo se aplica el efecto OuterShadow. 
- Si OuterShadow y InnerShadow se utilizan simultáneamente, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow.

### Aplicando Efectos de Reproducción a Textos

Agregamos el efecto de reproducción al texto a través de este código de muestra en Java:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### Aplicando Efecto de Resplandor a Textos

Aplicamos el efecto de resplandor al texto para hacerlo brillar o destacarse usando este código:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puedes cambiar los parámetros para sombra, reproducción y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 

{{% /alert %}} 

### Usando Transformaciones en WordArt

Utilizamos la propiedad Transform (inherente en todo el bloque de texto) a través de este código:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para Java proporcionan una cierta cantidad de tipos de transformación predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, pasa por: **Formato** -> **Efecto de Texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, utiliza el enumerador TextShapeType. 

### Aplicando efectos 3D a Textos y Formas

Establecemos un efecto 3D a una forma de texto usando este código de muestra:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

El texto resultante y su forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código Java:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

La aplicación de efectos 3D a textos o sus formas y las interacciones entre efectos se basan en ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se colocó el objeto. 

- Cuando la escena se establece tanto para la figura como para el texto, la escena de la figura tiene la mayor prioridad; la escena del texto se ignora. 
- Cuando la figura carece de su propia escena pero tiene representación 3D, se utiliza la escena del texto. 
- De lo contrario, cuando la forma originalmente no tiene efecto 3D, la forma es plana y el efecto 3D solo se aplica al texto. 

Estas descripciones están conectadas a los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera().

{{% /alert %}} 

## **Aplicar Efectos de Sombra Exterior a Textos**
Aspose.Slides para Java proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) y [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow) que te permiten aplicar efectos de sombra a un texto llevado por [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame). Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Obtén la referencia de una diapositiva usando su índice.
3. Agrega un AutoShape de tipo Rectángulo a la diapositiva.
4. Accede al TextFrame asociado con el AutoShape.
5. Establece el FillType del AutoShape a NoFill.
6. Instancia la clase OuterShadow.
7. Establece el BlurRadius de la sombra.
8. Establece la Dirección de la sombra.
9. Establece la Distancia de la sombra.
10. Establece el RectangleAlign a ArribaIzquierda.
11. Establece el PresetColor de la sombra a Negro.
12. Escribe la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

Este código de muestra en Java —una implementación de los pasos anteriores— te muestra cómo aplicar el efecto de sombra exterior a un texto:

```java
Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectángulo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Agregar TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");

    // Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Agregar sombra exterior y establecer todos los parámetros necesarios
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Escribir la presentación en el disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar Efecto de Sombra Interior a Formas**
Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Obtén una referencia de la diapositiva.
3. Agrega un AutoShape de tipo Rectángulo.
4. Habilita InnerShadowEffect.
5. Establece todos los parámetros necesarios.
6. Establece el ColorType como Esquema.
7. Establece el Color del Esquema.
8. Escribe la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Este código de muestra (basado en los pasos anteriores) te muestra cómo agregar un conector entre dos formas en Java:

```java
Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectángulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Agregar TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Habilitar InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Establecer todos los parámetros necesarios
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Establecer ColorType como Esquema
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Establecer Color del Esquema
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Guardar Presentación
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```