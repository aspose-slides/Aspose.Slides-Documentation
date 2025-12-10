---
title: Administrar temas de presentación en .NET
linktitle: Tema de presentación
type: docs
weight: 10
url: /es/net/presentation-theme/
keywords:
- Tema de PowerPoint
- Tema de presentación
- Tema de diapositiva
- Establecer tema
- Cambiar tema
- Gestionar tema
- Color del tema
- Paleta adicional
- Fuente del tema
- Estilo del tema
- Efecto del tema
- PowerPoint
- OpenDocument
- Presentación
- .NET
- C#
- Aspose.Slides
description: "Domina los temas de presentación en Aspose.Slides para .NET para crear, personalizar y convertir archivos PowerPoint con una imagen de marca coherente."
---

Un tema de presentación define las propiedades de los elementos de diseño. Cuando seleccionas un tema de presentación, esencialmente estás eligiendo un conjunto específico de elementos visuales y sus propiedades.

En PowerPoint, un tema incluye colores, [fuentes](/slides/es/net/powerpoint-fonts/), [estilos de fondo](/slides/es/net/presentation-background/), y efectos.

![theme-constituents](theme-constituents.png)

## **Cambiar color del tema**

Un tema de PowerPoint utiliza un conjunto específico de colores para diferentes elementos en una diapositiva. Si no te gustan los colores, los cambias aplicando nuevos colores al tema. Para que puedas seleccionar un nuevo color de tema, Aspose.Slides proporciona valores en la enumeración [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) .

Este código C# muestra cómo cambiar el color de acento para un tema:
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


Para demostrar más la operación de cambio de color, creamos otro elemento y le asignamos el color de acento (de la operación inicial). Luego cambiamos el color en el tema:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


El nuevo color se aplica automáticamente en ambos elementos.

### **Establecer color del tema desde una paleta adicional**

Cuando aplicas transformaciones de luminancia al color principal del tema(1), se forman colores de la paleta adicional(2). Entonces puedes establecer y obtener esos colores del tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Colores principales del tema  

**2** - Colores de la paleta adicional.

Este código C# demuestra una operación donde se obtienen colores de la paleta adicional a partir del color principal del tema y luego se usan en formas:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Acento 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Acento 4, más claro 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Acento 4, más claro 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Acento 4, más claro 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Acento 4, más oscuro 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Acento 4, más oscuro 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```


## **Cambiar fuente del tema**

Para que puedas seleccionar fuentes para temas y otros propósitos, Aspose.Slides utiliza estos identificadores especiales (similares a los usados en PowerPoint):

* **+mn-lt** - Fuente del cuerpo Latin (Fuente Latin menor)
* **+mj-lt** - Fuente del encabezado Latin (Fuente Latin mayor)
* **+mn-ea** - Fuente del cuerpo Este Asiático (Fuente Este Asiático menor)
* **+mj-ea** - Fuente del cuerpo Este Asiático (Fuente Este Asiático menor)

Este código C# muestra cómo asignar la fuente Latin a un elemento del tema:
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


Este código C# muestra cómo cambiar la fuente del tema de la presentación:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


La fuente en todos los cuadros de texto se actualizará.

{{% alert color="primary" title="TIP" %}} 
Puede que quieras ver [Fuentes de PowerPoint](/slides/es/net/powerpoint-fonts/).
{{% /alert %}}

## **Cambiar estilo de fondo del tema**

Por defecto, la aplicación PowerPoint proporciona 12 fondos predefinidos, pero solo 3 de esos 12 fondos se guardan en una presentación típica. 

![todo:image_alt_text](presentation-design_8.png)

Por ejemplo, después de guardar una presentación en la aplicación PowerPoint, puedes ejecutar este código C# para averiguar el número de fondos predefinidos en la presentación:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
Usando la propiedad [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) de la clase [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/), puedes agregar o acceder al estilo de fondo en un tema de PowerPoint. 
{{% /alert %}}

Este código C# muestra cómo establecer el fondo para una presentación:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**Guía de índices**: 0 se usa para sin relleno. El índice comienza en 1.

{{% alert color="primary" title="TIP" %}} 
Puede que quieras ver [Fondo de PowerPoint](/slides/es/net/presentation-background/).
{{% /alert %}}

## **Cambiar efecto del tema**

Un tema de PowerPoint normalmente contiene 3 valores para cada matriz de estilo. esas matrices se combinan en estos 3 efectos: sutil, moderado e intenso. Por ejemplo, este es el resultado cuando los efectos se aplican a una forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propiedades ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) de la clase [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) puedes cambiar los elementos en un tema (incluso de forma más flexible que las opciones en PowerPoint).

Este código C# muestra cómo cambiar un efecto del tema alterando partes de los elementos:
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


Los cambios resultantes en el color de relleno, tipo de relleno, efecto de sombra, etc.:

![todo:image_alt_text](presentation-design_11.png)

## **Preguntas frecuentes**

**¿Puedo aplicar un tema a una sola diapositiva sin cambiar la maestra?**

Sí. Aspose.Slides admite sobrescrituras de tema a nivel de diapositiva, por lo que puedes aplicar un tema local solo a esa diapositiva mientras mantienes intacto el tema maestro (a través del [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**¿Cuál es la forma más segura de transferir un tema de una presentación a otra?**

[Clonar diapositivas](/slides/es/net/clone-slides/) junto con su maestra en la presentación de destino. Esto conserva la maestra original, los diseños y el tema asociado, de modo que la apariencia permanece consistente.

**¿Cómo puedo ver los valores "efectivos" después de toda la herencia y sobrescritura?**

Utiliza las ["vistas efectivas"](/slides/es/net/shape-effective-properties/) de la API para tema/color/fuente/efecto. Estas devuelven las propiedades resueltas y finales después de aplicar la maestra más cualquier sobrescritura local.