---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/net/examples/elements/master-slide/
keywords:
- diapositiva maestra
- añadir diapositiva maestra
- acceder a diapositiva maestra
- eliminar diapositiva maestra
- diapositiva maestra no utilizada
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Explora ejemplos de diapositivas maestras de Aspose.Slides para .NET: crea, edita y diseña maestros, marcadores de posición y temas en PPT, PPTX y ODP con código C# claro."
---
Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes, como fondos, logotipos y formato de texto. Las **diapositivas de diseño** heredan de las diapositivas maestras, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y administrar diapositivas maestras usando Aspose.Slides para .NET.

## **Añadir una diapositiva maestra**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada. Luego añade una pancarta con el nombre de la empresa a todas las diapositivas mediante la herencia de diseño.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Clona la diapositiva maestra predeterminada.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Añade una pancarta con el nombre de la empresa en la parte superior de la diapositiva maestra.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Asigna la nueva diapositiva maestra a una diapositiva de diseño.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Asigna la diapositiva de diseño a la primera diapositiva de la presentación.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Nota 1:** Las diapositivas maestras proporcionan una manera de aplicar una identidad visual coherente o elementos de diseño compartidos en todas las diapositivas. Cualquier cambio realizado en la maestra se reflejará automáticamente en las diapositivas de diseño y normales dependientes.

> 💡 **Nota 2:** Cualquier forma o formato añadido a una diapositiva maestra se hereda en las diapositivas de diseño y, a su vez, en todas las diapositivas normales que usan esos diseños.  
> La imagen a continuación ilustra cómo un cuadro de texto añadido en una diapositiva maestra se muestra automáticamente en la diapositiva final.

![Ejemplo de herencia de maestro](master-slide-banner.png)

## **Acceder a una diapositiva maestra**

Puedes acceder a las diapositivas maestras mediante la colección `Presentation.Masters`. Aquí se muestra cómo recuperarlas y trabajar con ellas:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Accede a la primera diapositiva maestra.
    var firstMasterSlide = presentation.Masters[0];

    // Cambia el tipo de fondo.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Eliminar una diapositiva maestra**

Las diapositivas maestras pueden eliminarse ya sea por índice o por referencia.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Elimina una diapositiva maestra por índice.
    presentation.Masters.RemoveAt(0);

    // Elimina una diapositiva maestra por referencia.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Eliminar diapositivas maestras no utilizadas**

Algunas presentaciones contienen diapositivas maestras que no se utilizan. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Elimina todas las diapositivas maestras no utilizadas (incluso las marcadas como Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```