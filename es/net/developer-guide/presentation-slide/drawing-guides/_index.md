---
title: Gestionar guías de dibujo en presentaciones en .NET
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/net/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- maestro de notas
- maestro de folletos
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Añadir, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint utilizando Aspose.Slides para .NET."
---
## **Visión general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma coherente mientras editan una presentación en PowerPoint. Son especialmente útiles cuando una aplicación genera una presentación que luego será refinada manualmente: la aplicación puede guardar los mismos auxiliares de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación o en la salida renderizada. Aspose.Slides for .NET las expone a través de la interfaz [IDrawingGuidesCollection](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguidescollection/). Una guía se representa mediante [IDrawingGuide](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o la diapositiva maestra correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Añadir guías a la vista de diapositiva**

Utilice [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/es/net/aspose.slides/icommonslideviewproperties/drawingguides/) para gestionar las guías que se muestran mientras se editan diapositivas normales. Llame a [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguidescollection/add/) con un valor de [Orientation](https://reference.aspose.com/slides/es/net/aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo añade una guía vertical a la derecha del centro de la diapositiva y una guía horizontal debajo de ella:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Acceder a las guías de dibujo**

La propiedad [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguidescollection/count/) y el indexador permiten acceder a las guías existentes. Las propiedades [IDrawingGuide.Orientation](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguide/position/) y [IDrawingGuide.Color](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguide/color/) pueden leerse o modificarse.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada anteriormente:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Añadir guías a diapositivas maestra y de diseño**

Una diapositiva maestra y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/drawingguides/) para una diapositiva maestra y [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/drawingguides/) para una diapositiva de diseño.

El siguiente ejemplo añade una guía vertical a la primera diapositiva maestra y una guía horizontal a la primera diapositiva de diseño:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Añadir guías a los maestros de notas y de folletos**

Los maestros de notas y los maestros de folletos también admiten guías de dibujo. Utilice [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslide/drawingguides/) y [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/es/net/aspose.slides/imasterhandoutslide/drawingguides/) para acceder a sus colecciones. Si una presentación no contiene alguno de estos maestros, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) o [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) crea el maestro predeterminado y lo devuelve.

El siguiente ejemplo añade una guía horizontal a un maestro de notas y una guía vertical a un maestro de folletos:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Eliminar guías de dibujo**

Llame a [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/es/net/aspose.slides/idrawingguidescollection/clear/) para eliminar todas las guías de una colección determinada. Limpiar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo elimina las guías de la vista de diapositiva y todas las guías en los maestros de diapositiva, las diapositivas de diseño, el maestro de notas y el maestro de folletos sin crear maestros faltantes:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Aparecen las guías de dibujo en una presentación o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías separadas para los maestros de diapositivas, las diapositivas de diseño, los maestros de notas y los maestros de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las posiciones horizontales se miden desde el borde superior.

**¿Eliminar las guías de dibujo borra formas o modifica el contenido de la diapositiva?**

No. El método `Clear` elimina solo las guías de la colección seleccionada. Las formas y demás contenido de la diapositiva permanecen sin cambios.