---
title: Crear y aplicar efectos WordArt en Java
linktitle: WordArt
type: docs
weight: 110
url: /es/java/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto de sombra
- efecto de visualización
- efecto de resplandor
- transformación WordArt
- efecto 3D
- efecto de sombra externa
- efecto de sombra interna
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Cree y personalice efectos WordArt en Aspose.Slides para Java. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en Java."
---
## **Visión general**

Los efectos WordArt le permiten añadir texto estilizado y visualmente atractivo a sus presentaciones de PowerPoint. Con Aspose.Slides, los desarrolladores pueden crear, personalizar y gestionar WordArt de forma programática como en Microsoft PowerPoint, sin necesidad de tener Office instalado. Este artículo ofrece una visión general del uso de WordArt, incluyendo cómo aplicar transformaciones de texto, estilos de relleno, contornos, sombras y otras opciones de formato para que el contenido de su presentación sea más expresivo y atractivo. WordArt le permite tratar el texto como un objeto gráfico. Consiste en efectos o modificaciones especiales aplicadas al texto para hacerlo más atractivo o visible.

## **Crear una plantilla WordArt simple y aplicarla a un texto**

**Uso de Aspose.Slides** 

Primero, creamos un texto simple usando este código Java: 

``` java
import com.aspose.slides.*;

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
Ahora, establecemos la altura de fuente del texto a un valor mayor para que el efecto sea más visible mediante este código:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Uso de Microsoft PowerPoint**

Acceda al menú de efectos WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

En el menú de la derecha, puede elegir un efecto WordArt predefinido. En el menú de la izquierda, puede especificar los ajustes para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Uso de Aspose.Slides**

Aquí, aplicamos el color de patrón [SmallGrid](https://reference.aspose.com/slides/es/java/com.aspose.slides/PatternStyle#SmallGrid) al texto y añadimos un contorno negro de ancho 1 al texto usando este código:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicar otros efectos WordArt**

**Uso de Microsoft PowerPoint**

Desde la interfaz del programa, puede aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Resplandor pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Bordes suaves puede aplicarse a un objeto Forma (todavía tiene efecto cuando no se establece la propiedad Formato 3D). 

### **Aplicar efectos de sombra**

Aquí, pretendemos establecer únicamente las propiedades relacionadas con un texto. Aplicamos el efecto de sombra a un texto usando este código en Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

La API Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow. 

Con PresetShadow, puede aplicar una sombra a un texto (usando valores predefinidos). 

**Uso de Microsoft PowerPoint**

En PowerPoint, puede usar un tipo de sombra. Aquí tienes un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Uso de Aspose.Slides**

Aspose.Slides realmente permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se usan juntos OuterShadow y PresetShadow, solo se aplica el efecto OuterShadow. 
- Si se utilizan simultáneamente OuterShadow e InnerShadow, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow. 

### **Aplicar visualización a textos**

Añadimos visualización al texto mediante este ejemplo de código en Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Aplicar efecto de resplandor a textos**

Aplicamos el efecto de resplandor al texto para que brille o destaque usando este código:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

Puede cambiar los parámetros de sombra, visualización y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 

{{% /alert %}} 

### **Uso de transformaciones en WordArt**

Usamos la propiedad Transform (inherente a todo el bloque de texto) mediante este código:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para Java proporcionan un número determinado de tipos de transformación predefinidos. 

{{% /alert %}} 

**Uso de PowerPoint**

Para acceder a los tipos de transformación predefinidos, siga: **Formato** -> **Efecto de texto** -> **Transformar**

**Uso de Aspose.Slides**

Para seleccionar un tipo de transformación, use el enumerado TextShapeType. 

### **Aplicar efectos 3D a textos y formas**

Establecemos un efecto 3D en una forma de texto usando este código de ejemplo:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

El texto resultante y su forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

La aplicación de efectos 3D a textos o sus formas y las interacciones entre efectos se basan en ciertas reglas. 

Considere una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se coloca el objeto. 

- Cuando la escena está establecida tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad—la escena del texto se ignora. 
- Cuando la figura no tiene su propia escena pero tiene representación 3D, se usa la escena del texto. 
- En caso contrario—cuando la forma originalmente no tiene efecto 3D—la forma es plana y el efecto 3D solo se aplica al texto. 

Estas descripciones están vinculadas a los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Aplicar efectos de sombra externa a textos**

Aspose.Slides para Java proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/es/java/com.aspose.slides/ioutershadow/) y [**IInnerShadow**](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinnershadow/) que permiten aplicar efectos de sombra a un texto contenido en [TextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/textframe/). Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).  
2. Obtenga la referencia de una diapositiva usando su índice.  
3. Añada un AutoShape de tipo Rectángulo a la diapositiva.  
4. Acceda al TextFrame asociado al AutoShape.  
5. Establezca el FillType del AutoShape a NoFill.  
6. Instancie la clase OuterShadow  
7. Establezca el BlurRadius de la sombra.  
8. Establezca la Direction de la sombra  
9. Establezca la Distance de la sombra.  
10. Establezca el RectanglelAlign a TopLeft.  
11. Establezca el PresetColor de la sombra a Black.  
12. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) file.  

Este código de ejemplo en Java—una implementación de los pasos anteriores—le muestra cómo aplicar el efecto de sombra externa a un texto:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectángulo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Añadir TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");

    // Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Añadir sombra externa y establecer todos los parámetros necesarios
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Guardar la presentación en disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar efecto de sombra interna a formas**

Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).  
2. Obtenga una referencia de la diapositiva.  
3. Añada un AutoShape del tipo Rectángulo.  
4. Active InnerShadowEffect.  
5. Establezca todos los parámetros necesarios.  
6. Establezca el ColorType como Scheme.  
7. Establezca el Scheme Color.  
8. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Este código de ejemplo (basado en los pasos anteriores) le muestra cómo aplicar el efecto de sombra interna al texto dentro de una forma en Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectángulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Añadir TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Activar InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Establecer todos los parámetros necesarios
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Establecer ColorType como Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Establecer Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Guardar presentación
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**

### ¿Puedo usar efectos WordArt con diferentes fuentes o escrituras (p.ej., árabe, chino)?

Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos WordArt como sombra, relleno y contorno pueden aplicarse independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

### ¿Puedo aplicar efectos WordArt a elementos del patrón de diapositivas?

Sí, puede aplicar efectos WordArt a formas en las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

### ¿Afectan los efectos WordArt al tamaño del archivo de la presentación?

Un poco. Los efectos WordArt como sombras, resplandores y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

### ¿Puedo previsualizar el resultado de los efectos WordArt sin guardar la presentación?

Sí, puede renderizar diapositivas que contengan WordArt a imágenes (p.ej., PNG, JPEG) usando el método `getImage` de las interfaces [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.