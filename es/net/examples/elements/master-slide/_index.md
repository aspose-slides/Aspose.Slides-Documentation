---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/net/examples/elements/master-slide/
keywords:
- ejemplo de diapositiva maestra
- agregar diapositiva maestra
- acceder a diapositiva maestra
- eliminar diapositiva maestra
- diapositiva maestra no utilizada
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administre diapositivas maestras en C# con Aspose.Slides: cree, edite, clone y formatee temas, fondos y marcadores de posición para unificar diapositivas en PowerPoint y OpenDocument."
---

Las diapositivas maestras forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva maestra** define elementos de diseño comunes, como fondos, logotipos y formato de texto. Las **diapositivas de diseño** heredan de las diapositivas maestras, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y administrar diapositivas maestras usando Aspose.Slides para .NET.

## **Agregar una diapositiva maestra**

Este ejemplo muestra cómo crear una nueva diapositiva maestra clonando la predeterminada. Luego agrega una pancarta con el nombre de la empresa a todas las diapositivas mediante la herencia de diseño.

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
````

> 💡 **Consejo 1:** Las diapositivas maestras proporcionan una forma de aplicar una marca o elementos de diseño compartidos de manera constante en todas las diapositivas. Cualquier cambio realizado en la maestra se reflejará automáticamente en las diapositivas de diseño y normales dependientes.

> 💡 **Consejo 2:** Cualquier forma o formato añadido a una diapositiva maestra se hereda en las diapositivas de diseño y, a su vez, en todas las diapositivas normales que usan esos diseños.  
> La imagen a continuación ilustra cómo un cuadro de texto añadido en una diapositiva maestra se representa automáticamente en la diapositiva final.

![Master Inheritance Example](master-slide-banner.png)

## **Acceder a una diapositiva maestra**

Puedes acceder a las diapositivas maestras usando la colección `Presentation.Masters`. Así es como se recuperan y se trabaja con ellas:

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Eliminar una diapositiva maestra**

Las diapositivas maestras pueden eliminarse por índice o por referencia.

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## **Eliminar diapositivas maestras no utilizadas**

Algunas presentaciones contienen diapositivas maestras que no se usan. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **Consejo:** Usa `RemoveUnused(true)` para limpiar las diapositivas maestras no utilizadas y minimizar el tamaño de la presentación.