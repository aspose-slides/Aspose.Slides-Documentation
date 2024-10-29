---
title: Zugriff auf Folie in der Präsentation
type: docs
weight: 20
url: /de/net/access-slide-in-presentation/
keywords: "Zugriff auf PowerPoint-Präsentation, Zugriff auf Folie, Folieneigenschaften bearbeiten, Folienposition ändern, Foliennummer, Index, ID, Position C#, Csharp, .NET, Aspose.Slides"
description: "Zugriff auf PowerPoint-Folie nach Index, ID oder Position in C# oder .NET. Folieneigenschaften bearbeiten"
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: nach Index und nach ID.

## **Zugriff auf Folie nach Index**

Alle Folien in einer Präsentation sind numerisch basierend auf der Folienposition angeordnet, beginnend mit 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 erreicht; etc.

Die Presentation-Klasse, die eine Präsentationsdatei darstellt, gibt alle Folien als eine [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) Objekten) frei. Dieser C#-Code zeigt Ihnen, wie Sie auf eine Folie über ihren Index zugreifen:

```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Erhält die Referenz einer Folie über ihren Index
ISlide slide = presentation.Slides[0];
```

## **Zugriff auf Folie nach ID**

Jede Folie in einer Präsentation hat eine eindeutige ID, die mit ihr verbunden ist. Sie können die [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) Methode (die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellt wird) verwenden, um diese ID anzusprechen. Dieser C#-Code zeigt Ihnen, wie Sie eine gültige Folien-ID angeben und auf diese Folie über die [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) Methode zugreifen:

```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Erhält die Folien-ID
uint id = presentation.Slides[0].SlideId;

// Greift auf die Folie über ihre ID zu
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Folie position ändern**
Aspose.Slides ermöglicht Ihnen, die Position einer Folie zu ändern. Sie können beispielsweise angeben, dass die erste Folie die zweite Folie werden soll.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz der Folie (dessen Position Sie ändern möchten) über ihren Index.
1. Setzen Sie eine neue Position für die Folie über die [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) Eigenschaft. 
1. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code veranschaulicht eine Operation, bei der die Folie an Position 1 auf Position 2 verschoben wird:

```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Erhält die Folie, deren Position geändert werden soll
    ISlide sld = pres.Slides[0];

    // Setzt die neue Position für die Folie
    sld.SlideNumber = 2;

    // Speichert die modifizierte Präsentation
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden andere Folien automatisch angepasst.

## **Folie nummer setzen**
Mit der [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) Eigenschaft (die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellt wird) können Sie eine neue Nummer für die erste Folie in einer Präsentation angeben. Diese Operation führt dazu, dass andere Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:

```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Erhält die Foliennummer
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Setzt die Foliennummer
    presentation.FirstSlideNumber=10;
    
    // Speichert die modifizierte Präsentation
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Wenn Sie es bevorzugen, die erste Folie zu überspringen, können Sie die Nummerierung von der zweiten Folie beginnen (und die Nummerierung für die erste Folie so ausblenden):

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Setzt die Nummer für die erste Präsentationsfolie
    presentation.FirstSlideNumber = 0;

    // Zeigt die Foliennummern für alle Folien an
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Versteckt die Foliennummer für die erste Folie
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Speichert die modifizierte Präsentation
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```