---
title: Tema de Presentación
type: docs
weight: 10
url: /es/net/presentation-theme/
keywords: "Tema, tema de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Tema de presentación de PowerPoint en C# o .NET"
---

Un tema de presentación define las propiedades de los elementos de diseño. Cuando seleccionas un tema de presentación, en esencia estás eligiendo un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema comprende colores, [fuentes](/slides/es/net/powerpoint-fonts/), [estilos de fondo](/slides/es/net/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar el Color del Tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, puedes cambiarlos aplicando nuevos colores al tema. Para permitirte seleccionar un nuevo color de tema, Aspose.Slides proporciona valores bajo la enumeración [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

Este código C# te muestra cómo cambiar el color de acento para un tema:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Puedes determinar el valor efectivo del color resultante de esta manera:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Para demostrar aún más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

El nuevo color se aplica automáticamente a ambos elementos.

### **Establecer el Color del Tema desde la Paleta Adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Luego puedes establecer y obtener esos colores del tema. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Colores principales del tema

**2** - Colores de la paleta adicional.

Este código C# demuestra una operación donde se obtienen colores de la paleta adicional a partir del color principal del tema y luego se utilizan en formas:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Acento 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Acento 4, Más Claro 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Acento 4, Más Claro 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Acento 4, Más Claro 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Acento 4, Más Oscuro 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Acento 4, Más Oscuro 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

## **Cambiar la Fuente del Tema**

Para permitirte seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los utilizados en PowerPoint):

* **+mn-lt** - Fuente del Cuerpo Latino (Fuente Menor Latina)
* **+mj-lt** - Fuente del Encabezado Latino (Fuente Mayor Latina)
* **+mn-ea** - Fuente del Cuerpo Este Asiático (Fuente Menor Este Asiático)
* **+mj-ea** - Fuente del Cuerpo Este Asiático (Fuente Menor Este Asiático)

Este código C# te muestra cómo asignar la fuente latina a un elemento del tema:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Formato de texto del tema");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Este código C# te muestra cómo cambiar la fuente del tema de presentación:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="CONSEJO" %}} 

Puede que quieras ver [fuentes de PowerPoint](/slides/es/net/powerpoint-fonts/).

{{% /alert %}}

## **Cambiar el Estilo de Fondo del Tema**

Por defecto, la aplicación de PowerPoint proporciona 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica. 

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación de PowerPoint, puedes ejecutar este código C# para averiguar el número de fondos predefinidos en la presentación:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"El número de estilos de relleno de fondo para el tema es {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

Usando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) de la clase [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/), puedes agregar o acceder al estilo de fondo en un tema de PowerPoint. 

{{% /alert %}}

Este código C# te muestra cómo establecer el fondo para una presentación:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Guía de índices**: 0 se usa para ningún relleno. El índice comienza desde 1.

{{% alert color="primary" title="CONSEJO" %}} 

Puede que quieras ver [Fondo de PowerPoint](/slides/es/net/presentation-background/).

{{% /alert %}}

## **Cambiar el Efecto del Tema**

Un tema de PowerPoint generalmente contiene 3 valores para cada matriz de estilo. Esas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando se aplican los efectos a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) de la clase [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) puedes cambiar los elementos en un tema (incluso más flexiblemente que las opciones en PowerPoint).

Este código C# te muestra cómo cambiar un efecto del tema alterando partes de los elementos:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc:

![todo:image_alt_text](presentation-design_11.png)