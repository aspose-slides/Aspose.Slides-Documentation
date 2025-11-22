---
title: Zugriff auf Folie in Präsentation
type: docs
weight: 20
url: /de/net/access-slide-in-presentation/
keywords: "PowerPoint-Präsentation zugreifen, Folie zugreifen, Folieneigenschaften bearbeiten, Folienposition ändern, Foliennummer festlegen, Index, ID, Position  C#, Csharp, .NET, Aspose.Slides"
description: "Zugriff auf PowerPoint-Folie nach Index, ID oder Position in C# oder .NET. Folieneigenschaften bearbeiten"
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: nach Index und nach ID.

## **Zugriff auf Folie nach Index**

Alle Folien in einer Präsentation sind numerisch nach ihrer Position angeordnet, beginnend bei 0. Die erste Folie ist über Index 0 zugänglich; die zweite Folie über Index 1; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als eine [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) Objekten) bereit. Dieser C#‑Code zeigt, wie Sie über den Index auf eine Folie zugreifen:
```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Gets a slide's reference through its index
ISlide slide = presentation.Slides[0];
```


## **Zugriff auf Folie nach ID**

Jede Folie in einer Präsentation hat eine eindeutige ID. Sie können die Methode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) verwenden, um diese ID anzusprechen. Dieser C#‑Code zeigt, wie Sie eine gültige Folien‑ID angeben und über die Methode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) auf die Folie zugreifen:
```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Ruft eine Folien-ID ab
uint id = presentation.Slides[0].SlideId;

// Greift auf die Folie über ihre ID zu
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Folienposition ändern**
Aspose.Slides ermöglicht das Ändern einer Folienposition. Beispielsweise können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Holen Sie die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index
3. Setzen Sie eine neue Position für die Folie über die Eigenschaft [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) .
4. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code demonstriert einen Vorgang, bei dem die Folie an Position 1 nach Position 2 verschoben wird:
```c#
// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Holt die Folie, deren Position geändert wird
    ISlide sld = pres.Slides[0];

    // Setzt die neue Position für die Folie
    sld.SlideNumber = 2;

    // Speichert die geänderte Präsentation
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Foliennummer festlegen**
Mit der Eigenschaft [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) können Sie für die erste Folie einer Präsentation eine neue Nummer festlegen. Dieser Vorgang führt dazu, dass die anderen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Holen Sie die Foliennummer.
3. Setzen Sie die Foliennummer.
4. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code demonstriert einen Vorgang, bei dem die erste Foliennummer auf 10 gesetzt wird:
```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Ruft die Foliennummer ab
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Setzt die Foliennummer
    presentation.FirstSlideNumber=10;
    
    // Speichert die geänderte Präsentation
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden), so:
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

    // Blendet die Foliennummer für die erste Folie aus
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Speichert die geänderte Präsentation
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Stimmt die von einem Benutzer gesehenen Foliennummer mit dem nullbasierten Index der Sammlung überein?**

Die auf einer Folie angezeigte Nummer kann bei einem beliebigen Wert beginnen (z. B. 10) und muss nicht dem Index entsprechen; die Beziehung wird durch die Einstellung [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indexierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indexierung berücksichtigt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfügungen, Löschungen und Verschiebungen neu berechnet.