---
title: WordArt
type: docs
weight: 110
url: /es/nodejs-java/wordart/
---

## **¿Acerca de WordArt?**

WordArt o Word Art es una característica que permite aplicar efectos a los textos para que destaquen. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), añadirle efectos 3D, etc. También puedes inclinar, doblar y estirar la forma de un texto. 

{{% alert color="primary" %}} 

WordArt le permite tratar un texto como lo haría con un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales aplicadas a los textos para hacerlos más atractivos o notorios. 

{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debe seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o a su forma. 

**WordArt en Aspose.Slides**

En Aspose.Slides para Node.js a través de Java 20.10, implementamos soporte para WordArt y mejoramos la funcionalidad en versiones posteriores de Aspose.Slides para Node.js a través de Java. 

Con Aspose.Slides para Node.js a través de Java, puede crear fácilmente su propia plantilla de WordArt (un efecto o combinación de efectos) en JavaScript y aplicarla a los textos. 

## **Creación de una Plantilla Simple de WordArt y su Aplicación a un Texto**

**Uso de Aspose.Slides** 

Primero, creamos un texto simple usando este código JavaScript:
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

Ahora, establecemos la altura de fuente del texto a un valor mayor para que el efecto sea más notorio mediante este código:
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Uso de Microsoft PowerPoint**

Vaya al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

En el menú de la derecha, puede elegir un efecto de WordArt predefinido. En el menú de la izquierda, puede especificar la configuración de un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Uso de Aspose.Slides**

Aquí, aplicamos el color de patrón [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) al texto y añadimos un borde de texto negro de ancho 1 mediante este código:
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

## **Aplicación de Otros Efectos de WordArt**

**Uso de Microsoft PowerPoint**

Desde la clase del programa, puede aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Resplandor pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Bordes Suaves puede aplicarse a un objeto Forma (todavía tiene efecto cuando no se establece la propiedad Formato 3D). 

### **Aplicación de Efectos de Sombra**

Aquí, pretendemos establecer solo las propiedades relacionadas con un texto. Aplicamos el efecto de sombra a un texto usando este código en JavaScript:
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


La API de Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow. 

Con PresetShadow, puede aplicar una sombra a un texto (utilizando valores predefinidos). 

**Uso de Microsoft PowerPoint**

En PowerPoint, puede usar un tipo de sombra. Aquí hay un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Uso de Aspose.Slides**

Aspose.Slides en realidad le permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se usan OuterShadow y PresetShadow juntos, solo se aplica el efecto OuterShadow. 
- Si OuterShadow e InnerShadow se usan simultáneamente, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow. 

### **Aplicación de Visualización a Textos**

Añadimos visualización al texto mediante este ejemplo de código en JavaScript:
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


### **Aplicación del Efecto Resplandor a Textos**

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

Puede cambiar los parámetros de sombra, visualización y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 

{{% /alert %}} 

### **Uso de Transformaciones en WordArt**

Utilizamos la propiedad Transform (inherente a todo el bloque de texto) mediante este código:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para Node.js a través de Java proporcionan una serie de tipos de transformación predefinidos.

{{% /alert %}} 

**Uso de PowerPoint**

Para acceder a los tipos de transformación predefinidos, vaya a: **Formato** → **Efecto de texto** → **Transformar**

**Uso de Aspose.Slides**

Para seleccionar un tipo de transformación, use el enum TextShapeType. 

### **Aplicación de efectos 3D a Textos y Formas**

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

La aplicación de efectos 3D a textos o a sus formas y las interacciones entre los efectos se basan en ciertas reglas. 

Considere una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se coloca el objeto. 

- Cuando la escena está configurada tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad y la escena del texto se ignora. 
- Cuando la figura no tiene su propia escena pero posee representación 3D, se usa la escena del texto. 
- De lo contrario, cuando la forma originalmente no tiene efecto 3D, la forma es plana y el efecto 3D solo se aplica al texto. 

Estas descripciones están relacionadas con los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Aplicar Efectos de Sombra Externa a Textos**

Aspose.Slides para Node.js a través de Java proporciona las clases [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IOuterShadow) y [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IInnerShadow) que permiten aplicar efectos de sombra a un texto contenido en [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame). Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
2. Obtenga la referencia de una diapositiva usando su índice. 
3. Añada un AutoShape de tipo Rectángulo a la diapositiva. 
4. Acceda al TextFrame asociado con el AutoShape. 
5. Establezca el FillType del AutoShape a NoFill. 
6. Instancie la clase OuterShadow 
7. Establezca el BlurRadius de la sombra. 
8. Establezca la Direction de la sombra 
9. Establezca la Distance de la sombra. 
10. Establezca el RectanglelAlign a TopLeft. 
11. Establezca el PresetColor de la sombra a Black. 
12. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) . 

Este código de ejemplo en Java —una implementación de los pasos anteriores— muestra cómo aplicar el efecto de sombra externa a un texto:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtener referencia de la diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir una AutoShape del tipo Rectángulo
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Añadir TextFrame al Rectángulo
    ashp.addTextFrame("Aspose TextBox");
    // Desactivar el relleno de la forma por si queremos obtener la sombra del texto
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Añadir sombra externa y establecer todos los parámetros necesarios
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


## **Aplicar Efecto de Sombra Interna a Formas**

Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
2. Obtenga una referencia de la diapositiva. 
3. Añada un AutoShape del tipo Rectángulo. 
4. Habilite InnerShadowEffect. 
5. Establezca todos los parámetros necesarios. 
6. Establezca el ColorType como Scheme. 
7. Establezca el Scheme Color. 
8. Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) . 

Este código de ejemplo (basado en los pasos anteriores) muestra cómo añadir un conector entre dos formas en JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtener referencia de la diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregar una AutoShape del tipo Rectángulo
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
    // Establecer color del esquema
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Guardar la presentación
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo usar los efectos de WordArt con diferentes fuentes o escrituras (p. ej., árabe, chino)?**

Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos de WordArt como sombra, relleno y contorno pueden aplicarse independientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar los efectos de WordArt a los elementos del patrón de diapositivas?**

Sí, puede aplicar efectos de WordArt a formas en las diapositivas maestra, incluidos los marcadores de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?**

Levemente. Los efectos de WordArt como sombras, resplandores y rellenos degradados pueden incrementar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?**

Sí, puede renderizar diapositivas que contienen WordArt a imágenes (p. ej., PNG, JPEG) usando el método `getImage` de las clases [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.