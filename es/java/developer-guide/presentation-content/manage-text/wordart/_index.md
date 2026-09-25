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
- efecto de reflejo
- efecto de brillo
- transformación WordArt
- efecto 3D
- efecto de sombra externa
- efecto de sombra interna
- Java
- Aspose.Slides
description: "Cree y personalice efectos WordArt en Aspose.Slides for Java. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional en Java."
---
## **Visión general**

Los efectos de WordArt le permiten dar estilo al texto con rellenos, contornos, sombras, reflejos, brillo, transformaciones y formato 3D. Este artículo explica cómo crear y personalizar estos efectos en presentaciones de PowerPoint usando Aspose.Slides for Java, sin necesidad de tener Microsoft Office instalado.

## **Crear una plantilla WordArt sencilla y aplicarla al texto**

Los siguientes ejemplos crean un estilo WordArt sencillo configurando el texto, la fuente, el relleno de patrón y el contorno.

Cada ejemplo crea una nueva presentación y añade un rectángulo a su primera diapositiva; no se necesita ningún archivo de entrada. El primer ejemplo establece el texto a "Aspose.Slides". La posición y las dimensiones de la forma se miden en puntos:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Establezca la fuente a Arial Black a 36 puntos para que el formato sea más visible:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Aplicar un patrón [SmallGrid](https://reference.aspose.com/slides/es/java/com.aspose.slides/patternstyle/#SmallGrid) con un primer plano naranja oscuro y un fondo blanco, y luego añadir un contorno de texto negro con un ancho de 1 punto:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

El texto resultante:

![La plantilla WordArt sencilla](WordArt_template.png)

## **Aplicar otros efectos WordArt**

Los siguientes ejemplos demuestran cómo aplicar sombras, reflejos, brillo, transformaciones y efectos 3D al texto.

### **Aplicar efectos de sombra externa**

Una sombra externa añade profundidad colocando una sombra detrás del texto. Puede personalizar su color, dirección, distancia, radio de desenfoque, escala y sesgo.

Este ejemplo llama a [enableOuterShadowEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) y establece una sombra negra con un radio de desenfoque de 4 puntos, una dirección de 230 grados y una distancia de 30 puntos. Los valores de escala de 100 conservan el tamaño de la sombra, mientras que el sesgo horizontal la inclina 20 grados. La transformación alfa establece su opacidad al 32%:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

El texto resultante:

![El efecto de sombra externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Cuando se usan juntas sombras externas y sombras predefinidas, solo se aplica la sombra externa.
- Si se usan simultáneamente sombras externas e internas, el efecto resultante depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica, mientras que en PowerPoint 2007 solo se aplica la sombra externa.
{{% /alert %}}

### **Aplicar efectos de reflejo**

Un reflejo crea una copia espejo del texto. Ajuste su posición, escala, desenfoque y opacidad para controlar su apariencia.

Este ejemplo llama a [enableReflectionEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/effectformat/#enableReflectionEffect--) y voltea el reflejo verticalmente con una escala de -100 %. Utiliza un radio de desenfoque de 0,5 puntos y una distancia de 4,72 puntos. La opacidad disminuye del 60 % al 0,9 % entre las posiciones 0 % y 60 % a lo largo del reflejo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

El texto resultante:

![El efecto de reflejo](reflection_effect.png)

### **Aplicar efectos de brillo**

Un brillo añade un contorno suave y coloreado alrededor del texto. Ajuste su color, opacidad y radio para controlar el efecto.

Este ejemplo llama a [enableGlowEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/effectformat/#enableGlowEffect--) y aplica un brillo rojo con una opacidad del 54 % y un radio de 7 puntos:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

El texto resultante:

![El efecto de brillo](glow_effect.png)

### **Aplicar transformaciones WordArt**

Las transformaciones WordArt doblan, estiran o deforman un bloque de texto.

Establezca [setTransform](https://reference.aspose.com/slides/es/java/com.aspose.slides/textframeformat/#setTransform-int-) a [ArchUpPour](https://reference.aspose.com/slides/es/java/com.aspose.slides/textshapetype/#ArchUpPour) para curvar todo el marco de texto hacia arriba:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

El texto resultante:

![La transformación WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java proporciona un conjunto de [tipos de transformación](https://reference.aspose.com/slides/es/java/com.aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar efectos 3D a formas y texto**

Puede aplicar efectos 3D a una forma o a su texto. Los biseles, la extrusión, la iluminación y la configuración de la cámara controlan la apariencia resultante.

El siguiente ejemplo usa [ThreeDFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/threedformat/) para añadir biseles circulares, extrusión naranja y un contorno rojo oscuro al rectángulo. Las dimensiones del bisel, la altura de la extrusión, el ancho y la profundidad del contorno se miden en puntos. Un material plástico, una iluminación equilibrada girada 40 grados alrededor del eje Z y una cámara en perspectiva definen su apariencia:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

La forma resultante:

![El efecto 3D de la forma](shape_3D_effect.png)

Este ejemplo aplica un formato 3D similar al texto mediante [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Biseles más pequeños moldean los bordes de las letras, mientras que la extrusión y la iluminación le dan profundidad al texto:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

El texto resultante:

![El efecto 3D del texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
La aplicación de efectos 3D al texto o a sus formas —y la interacción entre estos efectos— está regida por reglas específicas. Considere una escena que involucre tanto el texto como la forma que lo contiene. Un efecto 3D incluye la representación 3D del objeto y la escena en la que se sitúa.

- Si se establece una escena tanto para la forma como para el texto, la escena de la forma tiene prioridad y la escena del texto se ignora.
- Si la forma no tiene su propia escena pero posee una representación 3D, se utiliza la escena del texto.
- Si la forma no tiene ningún efecto 3D, se trata como plana y el efecto 3D se aplica solo al texto.

Estos comportamientos se relacionan con los métodos [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/es/java/com.aspose.slides/threedformat/#getLightRig--) y [ThreeDFormat.getCamera](https://reference.aspose.com/slides/es/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Para mantener el texto plano y legible mientras se conserva el formato 3D de su forma, consulte [Mantener el texto plano en una forma 3D](/slides/es/java/3d-presentation/) para una comparación de ambas configuraciones y un ejemplo Java completo.

## **Preguntas frecuentes**

**¿Puedo usar los efectos WordArt con diferentes fuentes o escrituras (p.ej., árabe, chino)?**

Sí, Aspose.Slides for Java admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos WordArt como sombra, relleno y contorno se pueden aplicar independientemente del idioma, aunque la disponibilidad de la fuente y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos WordArt a los elementos de la diapositiva maestra?**

Sí, puede aplicar efectos WordArt a las formas en las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos WordArt afectan al tamaño del archivo de la presentación?**

Levemente. Los efectos WordArt como sombras, brillos y rellenos degradados pueden incrementar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos WordArt sin guardar la presentación?**

Sí, puede renderizar diapositivas que contengan WordArt a imágenes (p. ej., PNG, JPEG) usando [ISlide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getImage--), o renderizar formas individuales usando [IShape.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getImage--). Esto le permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.