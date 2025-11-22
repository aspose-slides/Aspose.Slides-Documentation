---
title: Tema de Presentación
type: docs
weight: 10
url: /es/nodejs-java/presentation-theme/
keywords: "Tema, tema de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para Node.js mediante Java"
description: "Tema de presentación de PowerPoint en JavaScript"
---

Un tema de presentación define las propiedades de los elementos de diseño. Cuando seleccionas un tema de presentación, esencialmente eliges un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema comprende colores, [fuentes](/slides/es/nodejs-java/powerpoint-fonts/), [estilos de fondo](/slides/es/nodejs-java/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar color del tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, los cambias aplicando nuevos colores al tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SchemeColor).

Este código JavaScript muestra cómo cambiar el color de acento de un tema:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Puedes determinar el valor efectivo del color resultante de esta manera:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Para demostrar aún más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


El nuevo color se aplica automáticamente en ambos elementos.

### **Establecer color del tema desde la paleta adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Luego puedes establecer y obtener esos colores del tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Colores principales del tema

**2** - Colores de la paleta adicional.

Este código JavaScript demuestra una operación donde los colores de la paleta adicional se obtienen del color principal del tema y luego se usan en formas:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Acento 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Acento 4, más claro 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Acento 4, más claro 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Acento 4, más claro 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Acento 4, más oscuro 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Acento 4, más oscuro 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Cambiar fuente del tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los usados en PowerPoint):

* **+mn-lt** - Fuente de cuerpo Latin (Fuente Latin menor)
* **+mj-lt** - Fuente de encabezado Latin (Fuente Latin mayor)
* **+mn-ea** - Fuente de cuerpo East Asian (Fuente East Asian menor)
* **+mj-ea** - Fuente de cuerpo East Asian (Fuente East Asian mayor)

Este código JavaScript muestra cómo asignar la fuente Latin a un elemento del tema:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


Este código JavaScript muestra cómo cambiar la fuente del tema de la presentación:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


La fuente en todos los cuadros de texto será actualizada.

{{% alert color="primary" title="CONSEJO" %}} 
Puede que quieras ver [Fuentes de PowerPoint](/slides/es/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Cambiar estilo de fondo del tema**

Por defecto, la aplicación PowerPoint ofrece 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica.

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación PowerPoint, puedes ejecutar este código JavaScript para descubrir el número de fondos predefinidos en la presentación:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 
Utilizando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) del la clase [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme), puedes añadir o acceder al estilo de fondo en un tema de PowerPoint.
{{% /alert %}} 

Este código JavaScript muestra cómo establecer el fondo para una presentación:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Guía de índices**: 0 se usa para sin relleno. El índice comienza en 1.

{{% alert color="primary" title="CONSEJO" %}} 
Puede que quieras ver [Fondo de PowerPoint](/slides/es/nodejs-java/presentation-background/).
{{% /alert %}}

## **Cambiar efecto del tema**

Un tema de PowerPoint generalmente contiene 3 valores para cada matriz de estilo. esas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando los efectos se aplican a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) de la clase [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) puedes cambiar los elementos en un tema (aún más flexible que las opciones en PowerPoint).

Este código JavaScript muestra cómo cambiar un efecto del tema modificando partes de los elementos:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc:
![todo:image_alt_text](presentation-design_11.png)

## **Preguntas frecuentes**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar la maestra?**

Sí. Aspose.Slides admite anulaciones de tema a nivel de diapositiva, por lo que puedes aplicar un tema local solo a esa diapositiva mientras mantienes intacto el tema maestro (a través del [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)).

**¿Cuál es la manera más segura de trasladar un tema de una presentación a otra?**

[Clonar diapositivas](/slides/es/nodejs-java/clone-slides/) junto con su maestra en la presentación de destino. Esto conserva la maestra original, los diseños y el tema asociado, de modo que la apariencia se mantiene coherente.

**¿Cómo puedo ver los valores "efectivos" después de toda la herencia y sobrescrituras?**

Utiliza las ["vistas efectivas"](/slides/es/nodejs-java/shape-effective-properties/) de la API para tema/color/fuente/efecto. Estas devuelven las propiedades resueltas y finales después de aplicar la maestra y cualquier sobrescritura local.