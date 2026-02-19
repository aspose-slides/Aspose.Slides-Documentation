---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/net/examples/elements/layout-slide/
keywords:
- diapositiva de diseño
- agregar diapositiva de diseño
- acceder a diapositiva de diseño
- eliminar diapositiva de diseño
- diapositiva de diseño no utilizada
- clonar diapositiva de diseño
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Diapositivas maestras en Aspose.Slides para .NET: elija, aplique y personalice diseños de diapositivas, marcadores de posición y maestras con ejemplos en C# para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con **Layout Slides** en Aspose.Slides para .NET. Una diapositiva de diseño define el diseño y formato heredados por las diapositivas normales. Puede agregar, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las no utilizadas para reducir el tamaño de la presentación.

## **Agregar una diapositiva de diseño**

Puede crear una diapositiva de diseño personalizada para definir un formato reutilizable. Por ejemplo, podría añadir un cuadro de texto que aparezca en todas las diapositivas que usan este diseño.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Crear una diapositiva de diseño con un tipo de diseño en blanco y un nombre personalizado.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Añadir un cuadro de texto a la diapositiva de diseño.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Añadir dos diapositivas usando este diseño; ambas heredarán el texto del diseño.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Nota 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puede definir elementos comunes una vez y reutilizarlos en muchas diapositivas.
> 💡 **Nota 2:** Cuando añade formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrarán automáticamente este contenido compartido.
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Diapositivas heredando contenido de diseño](layout-slide-result.png)

## **Acceder a una diapositiva de diseño**

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (p. ej., `Blank`, `Title`, `SectionHeader`, etc.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Acceder a una diapositiva de diseño por índice.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Acceder a una diapositiva de diseño por tipo.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Eliminar una diapositiva de diseño**

Puede eliminar una diapositiva de diseño específica si ya no es necesaria.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Obtener una diapositiva de diseño por tipo y eliminarla.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Eliminar diapositivas de diseño no utilizadas**

Para reducir el tamaño de la presentación, puede que desee eliminar las diapositivas de diseño que no son usadas por ninguna diapositiva normal.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Elimina automáticamente todas las diapositivas de diseño que no están referenciadas por ninguna diapositiva.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Clonar una diapositiva de diseño**

Puede duplicar una diapositiva de diseño usando el método `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Obtener una diapositiva de diseño existente por tipo.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clonar la diapositiva de diseño al final de la colección de diapositivas de diseño.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Resumen:** Las diapositivas de diseño son herramientas potentes para gestionar un formato coherente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de diapositivas de diseño.