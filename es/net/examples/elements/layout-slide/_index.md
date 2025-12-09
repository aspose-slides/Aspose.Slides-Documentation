---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/net/examples/elements/layout-slide/
keywords:
- ejemplo de diapositiva de diseño
- agregar diapositiva de diseño
- acceder a diapositiva de diseño
- eliminar diapositiva de diseño
- diapositiva de diseño sin usar
- clonar diapositiva de diseño
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Use C# para administrar diapositivas de diseño con Aspose.Slides: crear, aplicar, clonar, renombrar y personalizar marcadores de posición y temas en presentaciones para PPT, PPTX y ODP."
---

Este artículo muestra cómo trabajar con **Layout Slides** en Aspose.Slides para .NET. Una diapositiva de diseño define el diseño y formato heredado por las diapositivas normales. Puedes agregar, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las no utilizadas para reducir el tamaño de la presentación.

## Agregar una diapositiva de diseño

Puedes crear una diapositiva de diseño personalizada para definir un formato reutilizable. Por ejemplo, podrías agregar un cuadro de texto que aparezca en todas las diapositivas que usen este diseño.

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Create a layout slide with a blank layout type and a custom name
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
````

> 💡 **Consejo 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puedes definir elementos comunes una vez y reutilizarlos en muchas diapositivas.

> 💡 **Consejo 2:** Cuando agregas formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrará este contenido compartido automáticamente.
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Slides Inheriting Layout Content](layout-slide-result.png)


## Acceder a una diapositiva de diseño

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (p.ej., `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Access by index
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // Access by layout type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## Eliminar una diapositiva de diseño

Puedes eliminar una diapositiva de diseño específica si ya no se necesita.

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## Eliminar diapositivas de diseño no utilizadas

Para reducir el tamaño de la presentación, puede que desees eliminar diapositivas de diseño que no son usadas por ninguna diapositiva normal.

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## Clonar una diapositiva de diseño

Puedes duplicar una diapositiva de diseño utilizando el método `AddClone`.

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Get an existing layout slide by type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Resumen:** Las diapositivas de diseño son herramientas poderosas para gestionar un formato consistente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de las diapositivas de diseño.