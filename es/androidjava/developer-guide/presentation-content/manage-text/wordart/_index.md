---
title: Crear y aplicar efectos de WordArt en Android
linktitle: WordArt
type: docs
weight: 110
url: /es/androidjava/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla de WordArt
- efecto de WordArt
- efecto de sombra
- efecto de visualización
- efecto de resplandor
- transformación de WordArt
- efecto 3D
- efecto de sombra externa
- efecto de sombra interna
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Crear y personalizar efectos de WordArt en Aspose.Slides para Android. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en Java."
---

## **¿Acerca de WordArt?**
WordArt o Word Art es una característica que permite aplicar efectos al texto para que destaque. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), añadirle efectos 3D, etc. También puedes sesgar, doblar y estirar la forma de un texto. 

{{% alert color="primary" %}} 
WordArt le permite tratar un texto como si fuera un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales aplicadas al texto para que sea más atractivo o llamativo. 
{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o a su forma. 

**WordArt en Aspose.Slides**

En Aspose.Slides for Android via Java 20.10, implementamos la compatibilidad con WordArt y mejoramos la función en versiones posteriores de Aspose.Slides for Android via Java.  
Con Aspose.Slides for Android via Java, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o combinación de efectos) en Java y aplicarla a textos.

## **Crear una plantilla simple de WordArt y aplicarla al texto**

**Usando Aspose.Slides** 

Primero, creamos un texto sencillo usando este código Java: 
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

Ahora, establecemos la altura de la fuente del texto a un valor mayor para que el efecto sea más visible mediante este código:
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Usando Microsoft PowerPoint**

Vaya al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

En el menú de la derecha, puedes elegir un efecto de WordArt predefinido. En el menú de la izquierda, puedes especificar la configuración de un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color de patrón [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) al texto y añadimos un borde negro de texto con ancho 1 mediante este código:
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

## **Aplicar otros efectos de WordArt**

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Resplandor pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Borde Suave puede aplicarse a un objeto Forma (sigue teniendo efecto cuando no se establece la propiedad Formato 3D). 

### **Aplicar efectos de sombra**

Aquí, pretendemos establecer solo las propiedades relacionadas con un texto. Aplicamos el efecto de sombra a un texto usando este código en Java:
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


La API de Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow.  
Con PresetShadow, puedes aplicar una sombra a un texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

En PowerPoint, puedes usar un tipo de sombra. Aquí tienes un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides en realidad permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.  

**Notas:**
- Cuando se usan OuterShadow y PresetShadow juntos, solo se aplica el efecto OuterShadow.  
- Si se usan OuterShadow e InnerShadow simultáneamente, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow.  

### **Aplicar efectos de reflexión al texto**

Añadimos un efecto de reflexión al texto mediante este ejemplo de código en Java:
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


### **Aplicar efectos de resplandor al texto**

Aplicamos el efecto de resplandor al texto para que brille o destaque usando este código:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Puedes cambiar los parámetros de sombra, reflexión y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 
{{% /alert %}} 

### **Usar transformaciones en WordArt**

Usamos la propiedad Transform (inherente a todo el bloque de texto) mediante este código:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Tanto Microsoft PowerPoint como Aspose.Slides for Android via Java ofrecen una serie de tipos de transformación predefinidos. 
{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, ve a: **Formato** -> **Efecto de texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, utiliza el enum TextShapeType. 

### **Aplicar efectos 3D al texto y a las formas**

Establecemos un efecto 3D a una forma de texto usando este código de ejemplo:
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
Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se coloca el objeto.  
- Cuando la escena está establecida tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad—la escena del texto se ignora.  
- Cuando la figura no tiene su propia escena pero posee representación 3D, se usa la escena del texto.  
- De lo contrario—cuando la forma originalmente no tiene efecto 3D—la forma es plana y el efecto 3D solo se aplica al texto.  
Estas descripciones están relacionadas con los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Aplicar efectos de sombra externa al texto**
Aspose.Slides for Android via Java proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/) y [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinnershadow/) que permiten aplicar efectos de sombra a un texto contenido en [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/). Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Obtén la referencia de una diapositiva usando su índice.  
3. Añade una AutoShape de tipo Rectángulo a la diapositiva.  
4. Accede al TextFrame asociado a la AutoShape.  
5. Establece el FillType de la AutoShape a NoFill.  
6. Instancia la clase OuterShadow.  
7. Establece el BlurRadius de la sombra.  
8. Establece la Direction de la sombra.  
9. Establece la Distance de la sombra.  
10. Establece el RectanglelAlign a TopLeft.  
11. Establece el PresetColor de la sombra a Black.  
12. Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Este código de ejemplo en Java—una implementación de los pasos anteriores—muestra cómo aplicar el efecto de sombra externa a un texto:
```java
Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectángulo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Añadir TextFrame al rectángulo
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

    //Guardar la presentación en disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Aplicar efectos de sombra interna a formas**
Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Obtén una referencia de la diapositiva.  
3. Añade una AutoShape de tipo Rectángulo.  
4. Habilita InnerShadowEffect.  
5. Establece todos los parámetros necesarios.  
6. Establece ColorType como Scheme.  
7. Establece el Scheme Color.  
8. Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Este código de ejemplo (basado en los pasos anteriores) muestra cómo añadir un conector entre dos formas en Java:
```java
Presentation pres = new Presentation();
try {
    // Obtener referencia de la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectángulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Añadir TextFrame al rectángulo
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

    // Establecer ColorType como Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Establecer Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Guardar la presentación
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo usar los efectos de WordArt con diferentes fuentes o escrituras (p. ej., árabe, chino)?**  
Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos de WordArt como sombra, relleno y contorno pueden aplicarse independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos de WordArt a los elementos de la diapositiva maestra?**  
Sí, puedes aplicar efectos de WordArt a las formas en diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?**  
Ligeramente. Los efectos de WordArt como sombras, resplandores y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?**  
Sí, puedes renderizar las diapositivas que contienen WordArt a imágenes (p. ej., PNG, JPEG) usando el método `getImage` de las interfaces [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/). Esto te permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.