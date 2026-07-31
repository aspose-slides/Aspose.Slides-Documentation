---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/net/examples/elements/header-footer/
aliases:
  - /net/examples/elementos/elementos/encabezado-pie/
keywords:
  - encabezado y pie de página
  - añadir encabezado y pie de página
  - actualizar encabezado y pie de página
  - ejemplo de código
  - PowerPoint
  - OpenDocument
  - presentación
  - .NET
  - C#
  - Aspose.Slides
description: "Controla los encabezados y pies de página de las diapositivas con Aspose.Slides para .NET: añade fechas, números de diapositiva y texto personalizado en PPT, PPTX y ODP con ejemplos en C#."
---
Este artículo muestra cómo añadir pies de página y actualizar los marcadores de posición de fecha y hora utilizando **Aspose.Slides for .NET**.

## **Añadir un pie de página**

Añade texto al área del pie de página de una diapositiva y hazlo visible.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Actualizar fecha y hora**

Modifica el marcador de posición de fecha y hora en una diapositiva.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```