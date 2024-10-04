---
title: Tema de Presentación
type: docs
weight: 10
url: /androidjava/presentation-theme/
keywords: "Tema, tema de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Tema de presentación de PowerPoint en Java"
---

Un tema de presentación define las propiedades de los elementos de diseño. Al seleccionar un tema de presentación, esencialmente estás eligiendo un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema comprende colores, [fuentes](/slides/androidjava/powerpoint-fonts/), [estilos de fondo](/slides/androidjava/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar el Color del Tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, puedes cambiarlos aplicando nuevos colores para el tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor).

Este código Java muestra cómo cambiar el color de acento para un tema:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Puedes determinar el valor efectivo del color resultante de esta manera:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Para demostrar aún más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

El nuevo color se aplica automáticamente en ambos elementos.

### **Establecer el Color del Tema desde una Paleta Adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Luego puedes establecer y obtener esos colores del tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Colores del tema principal

**2** - Colores de la paleta adicional.

Este código Java demuestra una operación donde se obtienen los colores de la paleta adicional del color principal del tema y luego se utilizan en formas:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Acento 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Acento 4, Más claro 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Acento 4, Más claro 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Acento 4, Más claro 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Acento 4, Más oscuro 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Acento 4, Más oscuro 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Cambiar la Fuente del Tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los utilizados en PowerPoint):

* **+mn-lt** - Fuente del Cuerpo Latino (Fuente Menor Latina)
* **+mj-lt** - Fuente de Encabezado Latino (Fuente Mayor Latina)
* **+mn-ea** - Fuente del Cuerpo Este Asiático (Fuente Menor Este Asiático)
* **+mj-ea** - Fuente de Encabezado Este Asiático (Fuente Mayor Este Asiático)

Este código Java muestra cómo asignar la fuente latina a un elemento del tema:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Formato de texto del tema");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPorportionFormat().setLatinFont(new FontData("+mn-lt"));
```

Este código Java muestra cómo cambiar la fuente del tema de presentación:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="CONSEJO" %}} 

Es posible que desees ver [fuentes de PowerPoint](/slides/androidjava/powerpoint-fonts/).

{{% /alert %}}

## **Cambiar el Estilo de Fondo del Tema**

De forma predeterminada, la aplicación PowerPoint proporciona 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica. 

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación PowerPoint, puedes ejecutar este código Java para averiguar el número de fondos predefinidos en la presentación:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("El número de estilos de relleno de fondo para el tema es " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Usando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) de la clase [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme), puedes añadir o acceder al estilo de fondo en un tema de PowerPoint.

{{% /alert %}} 

Este código Java muestra cómo establecer el fondo para una presentación:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guía de índices**: 0 se utiliza para sin relleno. El índice comienza desde 1.

{{% alert color="primary" title="CONSEJO" %}} 

Es posible que desees ver [Fondo de PowerPoint](/slides/androidjava/presentation-background/).

{{% /alert %}}

## **Cambiar el Efecto del Tema**

Un tema de PowerPoint generalmente contiene 3 valores para cada matriz de estilo. Estas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando se aplican los efectos a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) de la clase [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) puedes cambiar los elementos en un tema (incluso de manera más flexible que las opciones en PowerPoint).

Este código Java muestra cómo cambiar un efecto de tema al alterar partes de los elementos:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc:

![todo:image_alt_text](presentation-design_11.png)