---
title: Crear y aplicar efectos WordArt en JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /es/nodejs-java/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto sombra
- efecto de visualización
- efecto resplandor
- transformación WordArt
- efecto 3D
- efecto sombra exterior
- efecto sombra interior
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear y personalizar efectos WordArt en Aspose.Slides para Node.js. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional."
---

## **¿Qué es WordArt?**

WordArt o Word Art es una característica que permite aplicar efectos a los textos para que destaquen. Con WordArt, por ejemplo, puedes trazar un contorno a un texto o rellenarlo con un color (o degradado), añadir efectos 3D, etc. También puedes inclinar, doblar y estirar la forma de un texto. 

{{% alert color="primary" %}} 
WordArt permite tratar un texto como lo harías con un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales aplicadas a los textos para que resulten más atractivos o llamativos. 
{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplica a un texto o a su forma. 

**WordArt en Aspose.Slides**

En Aspose.Slides for Node.js via Java 20.10, implementamos compatibilidad con WordArt y mejoramos la función en versiones posteriores de Aspose.Slides for Node.js via Java. 

Con Aspose.Slides for Node.js via Java, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o combinación de efectos) en JavaScript y aplicarla a los textos. 

## **Crear una plantilla de WordArt sencilla y aplicarla a un texto**

**Usando Aspose.Slides** 

Primero, creamos un texto sencillo usando este código JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ahora, establecemos la altura de la fuente del texto a un valor mayor para que el efecto sea más visible mediante este código:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Usando Microsoft PowerPoint**

Ve al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

En el menú de la derecha, puedes elegir un efecto de WordArt predefinido. En el menú de la izquierda, puedes especificar la configuración de un WordArt nuevo. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color de patrón [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) al texto y añadimos un borde negro de ancho 1 al texto usando este código:
```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```


El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicar otros efectos de WordArt**

**Usando Microsoft PowerPoint**

Desde la clase del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma u otro elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Resplandor pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Borde Suave puede aplicarse a un Objeto Forma (aún tiene efecto cuando no se establece la propiedad Formato 3D). 

### **Aplicar efectos de Sombra**

Aquí, pretendemos establecer únicamente las propiedades relacionadas con un texto. Aplicamos el efecto de sombra a un texto usando este código en JavaScript:
```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```


La API Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow.  
Con PresetShadow, puedes aplicar una sombra a un texto (usando valores predefinidos).  

**Uso de Microsoft PowerPoint**

En PowerPoint, puedes usar un tipo de sombra. Aquí tienes un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Uso de Aspose.Slides**

Aspose.Slides en realidad permite aplicar dos tipos de sombras simultáneamente: InnerShadow y PresetShadow.  

**Notas:**

- Cuando se usan OuterShadow y PresetShadow juntos, solo se aplica el efecto OuterShadow.  
- Si se usan OuterShadow e InnerShadow simultáneamente, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow.  

### **Aplicar Display a los textos**

Añadimos display al texto mediante este ejemplo de código en JavaScript:
```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```


### **Aplicar efecto de Resplandor a los textos**

Aplicamos el efecto de resplandor al texto para que brille o destaque usando este código:
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Puedes cambiar los parámetros de sombra, display y resplandor. Las propiedades de los efectos se establecen por separado en cada porción del texto. 
{{% /alert %}} 

### **Usar Transformaciones en WordArt**

Utilizamos la propiedad Transform (inherente a todo el bloque de texto) mediante este código:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Tanto Microsoft PowerPoint como Aspose.Slides for Node.js via Java proporcionan un número determinado de tipos de transformación predefinidos. 
{{% /alert %}} 

**Uso de PowerPoint**

Para acceder a los tipos de transformación predefinidos, navega a: **Formato** -> **Efecto de texto** -> **Transformar**  

**Uso de Aspose.Slides**

Para seleccionar un tipo de transformación, utiliza el enum TextShapeType.  

### **Aplicar efectos 3D a textos y formas**

Establecemos un efecto 3D a una forma de texto usando este código de ejemplo:
```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


El texto resultante y su forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código JavaScript:
```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
La aplicación de efectos 3D a textos o a sus formas y la interacción entre efectos se basa en ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se coloca el objeto. 

- Cuando la escena está configurada tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad—se ignora la escena del texto.  
- Cuando la figura no tiene su propia escena pero dispone de representación 3D, se usa la escena del texto.  
- En caso contrario—cuando la forma originalmente no tiene efecto 3D—la forma es plana y el efecto 3D sólo se aplica al texto.  

Estas descripciones están relacionadas con los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Aplicar efectos de Sombra Exterior a los textos**

Aspose.Slides for Node.js via Java proporciona las clases [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/) y [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/innershadow/) que permiten aplicar efectos de sombra a un texto contenido en [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/). Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. Obtén la referencia de una diapositiva usando su índice.  
3. Añade un AutoShape de tipo Rectángulo a la diapositiva.  
4. Accede al TextFrame asociado al AutoShape.  
5. Establece el FillType del AutoShape a NoFill.  
6. Instancia la clase OuterShadow.  
7. Establece el BlurRadius de la sombra.  
8. Establece la Direction de la sombra.  
9. Establece la Distance de la sombra.  
10. Establece el RectanglelAlign a TopLeft.  
11. Establece el PresetColor de la sombra a Black.  
12. Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Este código de ejemplo en Java—una implementación de los pasos anteriores—muestra cómo aplicar el efecto de sombra exterior a un texto:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtener referencia de la diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo Rectángulo
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Añadir TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");
    // Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Añadir sombra exterior y establecer todos los parámetros necesarios
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Guardar la presentación en disco
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Aplicar efecto de Sombra Interior a formas**

Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
2. Obtén una referencia de la diapositiva.  
3. Añade un AutoShape del tipo Rectángulo.  
4. Habilita InnerShadowEffect.  
5. Establece todos los parámetros necesarios.  
6. Establece ColorType como Scheme.  
7. Establece el Scheme Color.  
8. Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Este código de ejemplo (basado en los pasos anteriores) muestra cómo añadir un conector entre dos formas en JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtener referencia de la diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregar un AutoShape de tipo Rectángulo
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Agregar TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Habilitar InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Establecer todos los parámetros necesarios
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Establecer ColorType como Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Establecer Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Guardar presentación
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo usar efectos de WordArt con diferentes fuentes o escrituras (p. ej., árabe, chino)?**

Sí, Aspose.Slides es compatible con Unicode y funciona con todas las fuentes y escrituras principales. Los efectos de WordArt como sombra, relleno y contorno pueden aplicarse independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.  

**¿Puedo aplicar efectos de WordArt a elementos de la diapositiva maestra?**

Sí, puedes aplicar efectos de WordArt a las formas en las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.  

**¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?**

Un poco. Los efectos de WordArt como sombras, resplandores y rellenos degradados pueden incrementar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.  

**¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?**

Sí, puedes renderizar diapositivas que contengan WordArt a imágenes (p. ej., PNG, JPEG) usando el método `getImage` de las clases [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/). Esto te permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.