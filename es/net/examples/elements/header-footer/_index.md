---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/net/examples/elements/elements/header-footer/
keywords:
- ejemplo de encabezado y pie de página
- agregar encabezado y pie de página
- actualizar encabezado y pie de página
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Controla los encabezados y pies de página en C# con Aspose.Slides: agrega o edita fecha/hora, números de diapositiva y texto del pie de página, muestra u oculta los marcadores de posición en PPT, PPTX y ODP."
---

Muestra cómo agregar pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for .NET**.

## **Agregar un pie de página**

Agrega texto al área del pie de página de una diapositiva y hazlo visible.
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## **Actualizar fecha y hora**

Modifica el marcador de posición de fecha y hora en una diapositiva.
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
