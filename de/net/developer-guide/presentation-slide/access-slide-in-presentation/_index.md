---
title: Zugriff auf Präsentationsfolien in .NET
linktitle: Zugriff auf Folie
type: docs
weight: 20
url: /de/net/access-slide-in-presentation/
keywords:
- Folie zugreifen
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für .NET Folien in PowerPoint- und OpenDocument-Präsentationen zugreifen und verwalten können. Steigern Sie die Produktivität mit Codebeispielen."
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: über den Index und über die ID.

## **Zugriff auf eine Folie über den Index**

Alle Folien in einer Präsentation sind numerisch nach ihrer Position angeordnet, beginnend bei 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie über den Index 1; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als eine [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)-Objekten) bereit. Dieser C#‑Code zeigt, wie Sie über den Index auf eine Folie zugreifen:
```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Holt die Referenz einer Folie über ihren Index
ISlide slide = presentation.Slides[0];
```


## **Zugriff auf eine Folie über die ID**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die Methode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) verwenden, um diese ID anzusprechen. Dieser C#‑Code zeigt, wie Sie eine gültige Folien‑ID angeben und über die Methode [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) auf die Folie zugreifen:
```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Holt eine Folien-ID
uint id = presentation.Slides[0].SlideId;

// Greift über die ID auf die Folie zu
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Folienposition ändern**
Aspose.Slides ermöglicht das Ändern einer Folienposition. Zum Beispiel können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie die Referenz der Folie (dessen Position Sie ändern möchten) über ihren Index
1. Setzen Sie über die Eigenschaft [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) eine neue Position für die Folie.
1. Speichern Sie die geänderte Präsentation.

```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Erhält die Folie, deren Position geändert wird
    ISlide sld = pres.Slides[0];

    // Setzt die neue Position für die Folie
    sld.SlideNumber = 2;

    // Speichert die geänderte Präsentation
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Foliennummer festlegen**
Mit der Eigenschaft [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (bereitgestellt von der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang führt dazu, dass die Nummern der anderen Folien neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie die Foliennummer.
1. Setzen Sie die Foliennummer.
1. Speichern Sie die geänderte Präsentation.

```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Holt die Foliennummer
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Setzt die Foliennummer
    presentation.FirstSlideNumber=10;
    
    // Speichert die geänderte Präsentation
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) wie folgt:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Setzt die Nummer für die erste Folie der Präsentation
    presentation.FirstSlideNumber = 0;

    // Zeigt Foliennummern für alle Folien an
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Versteckt die Foliennummer für die erste Folie
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Speichert die geänderte Präsentation
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Entspricht die vom Benutzer sichtbare Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann bei einem beliebigen Wert beginnen (z. B. 10) und muss nicht dem Index entsprechen; die Beziehung wird durch die Einstellung [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indexierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indexierung gezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge-, Lösch‑ und Verschiebevorgängen neu berechnet.