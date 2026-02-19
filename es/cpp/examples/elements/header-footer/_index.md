---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/cpp/examples/elements/header-footer/
keywords:
- ejemplo de código
- encabezado
- pie de página
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Controla los encabezados y pies de página de las diapositivas con Aspose.Slides para C++: agrega fechas, números de diapositiva y texto personalizado en PPT, PPTX y ODP con ejemplos en C++."
---
Este artículo muestra cómo agregar pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for C++**.

## **Agregar un pie de página**

Añade texto al área del pie de página de una diapositiva y hazlo visible.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Actualizar fecha y hora**

Modifica el marcador de posición de fecha y hora en una diapositiva.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```