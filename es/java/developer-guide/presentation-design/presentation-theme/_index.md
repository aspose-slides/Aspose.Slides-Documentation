---
title: Gestionar temas de presentación en Java
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/java/presentation-theme/
keywords:
- Tema de PowerPoint
- tema de presentación
- tema de diapositiva
- establecer tema
- cambiar tema
- gestionar tema
- color del tema
- paleta adicional
- fuente del tema
- estilo del tema
- efecto del tema
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para Java para crear, personalizar y convertir archivos PowerPoint con una imagen de marca coherente."
---
Un tema de presentación define las propiedades de los elementos de diseño. Cuando seleccionas un tema de presentación, esencialmente estás eligiendo un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema incluye colores, [fuentes](/slides/es/java/powerpoint-fonts/), [estilos de fondo](/slides/es/java/presentation-background/), y efectos.

![componentes del tema](theme-constituents.png)

## **Cambiar color del tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, los cambias aplicando nuevos colores al tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/SchemeColor).

Este código Java muestra cómo cambiar el color de acento de un tema:

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

El nuevo color se aplica automáticamente a ambos elementos.

### **Establecer color del tema a partir de una paleta adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Entonces puedes establecer y obtener esos colores del tema.

![colores de la paleta adicional](additional-palette-colors.png)

**1** - Colores principales del tema

**2** - Colores de la paleta adicional.

Este código Java demuestra una operación donde los colores de la paleta adicional se obtienen a partir del color principal del tema y luego se usan en formas:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Acento 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Acento 4, más claro 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Acento 4, más claro 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Acento 4, más claro 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Acento 4, más oscuro 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Acento 4, más oscuro 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapear `SchemeColor` a colores de `IColorScheme`**

Al trabajar con [SchemeColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/schemecolor/), puede que notes que contiene los siguientes valores de color del tema: `Background1`, `Background2`, `Text1` y `Text2`.

Sin embargo, `Presentation.getMasterTheme().getColorScheme()` devuelve [IColorScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/icolorscheme/), que expone los colores correspondientes como: `Dark1`, `Dark2`, `Light1` y `Light2`.

Esta diferencia es solo en la denominación. Estos valores se refieren a los mismos espacios de color del tema y el mapeo es fijo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

No hay conversión dinámica entre `Text`/`Background` y `Dark`/`Light`. Son simplemente nombres alternativos para los mismos colores del tema.

Esta diferencia de nombres proviene de la terminología de Microsoft Office. Las versiones anteriores de Office utilizaban `Dark 1`, `Light 1`, `Dark 2` y `Light 2`, mientras que las versiones más recientes de la interfaz muestran los mismos espacios como `Text 1`, `Background 1`, `Text 2` y `Background 2`.

## **Cambiar fuente del tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los usados en PowerPoint):

* **+mn-lt** - Fuente del cuerpo Latin (Fuente Latin Menor)
* **+mj-lt** - Fuente del encabezado Latin (Fuente Latin Mayor)
* **+mn-ea** - Fuente del cuerpo East Asian (Fuente East Asian Menor)
* **+mj-ea** - Fuente del cuerpo East Asian (Fuente East Asian Mayor)

Este código Java muestra cómo asignar la fuente Latin a un elemento del tema:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Este código Java muestra cómo cambiar la fuente del tema de la presentación:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="TIP" %}} 
Puede que quieras ver [fuentes de PowerPoint](/slides/es/java/powerpoint-fonts/).
{{% /alert %}}

## **Cambiar estilo de fondo del tema**

Por defecto, la aplicación PowerPoint proporciona 12 fondos predefinidos pero solo 3 de esos 12 fondos se guardan en una presentación típica.

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación PowerPoint, puedes ejecutar este código Java para descubrir el número de fondos predefinidos en la presentación:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Usando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) del clase [FormatScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/FormatScheme), puedes añadir o acceder al estilo de fondo en un tema de PowerPoint. 
{{% /alert %}} 

Este código Java muestra cómo establecer el fondo para una presentación:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Guía de índices**: 0 se usa para sin relleno. El índice comienza en 1.

{{% alert color="primary" title="TIP" %}} 
Puede que quieras ver [Fondo de PowerPoint](/slides/es/java/presentation-background/).
{{% /alert %}}

## **Cambiar efecto del tema**

Un tema de PowerPoint normalmente contiene 3 valores para cada matriz de estilo. esas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando se aplican los efectos a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/es/java/com.aspose.slides/FormatScheme#getEffectStyles--)) de la clase [FormatScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/FormatScheme) puedes cambiar los elementos de un tema (incluso con mayor flexibilidad que las opciones de PowerPoint).

Este código Java muestra cómo cambiar un efecto del tema modificando partes de los elementos:

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

## **FAQ**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar el maestro?**

Sí. Aspose.Slides admite sobrescrituras de tema a nivel de diapositiva, por lo que puedes aplicar un tema local solo a esa diapositiva manteniendo intacto el tema maestro (a través del [SlideThemeManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidethememanager/)).

**¿Cuál es la forma más segura de trasladar un tema de una presentación a otra?**

[Clonar diapositivas](/slides/es/java/clone-slides/) junto con su maestro en la presentación de destino. Esto conserva el maestro original, los diseños y el tema asociado, de modo que la apariencia sigue siendo consistente.

**¿Cómo puedo ver los valores «efectivos» después de toda la herencia y sobrescrituras?**

Utiliza las ["vistas efectivas"](/slides/es/java/shape-effective-properties/) de la API para tema/color/fuente/efecto. Estas devuelven las propiedades resueltas y finales después de aplicar el maestro y cualquier sobrescritura local.