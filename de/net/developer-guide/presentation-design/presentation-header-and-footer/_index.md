---
title: Verwalten von Präsentationskopf- und -fußzeilen in .NET
linktitle: Kopfzeile und Fußzeile
type: docs
weight: 140
url: /de/net/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile setzen
- Fußzeile setzen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fußzeilen-, Datum-Uhrzeit-, Folien-Nummer- und Kopfzeilen-Platzhalter auf Folien, Notizseiten und Handzetteln mit Aspose.Slides für .NET verwalten."
---
## **Übersicht**

PowerPoint verwendet je nach Folientyp unterschiedliche Platzhalter für Kopf‑ und Fußzeilen. Aspose.Slides für .NET ermöglicht es Ihnen, den Text und die Sichtbarkeit dieser Platzhalter über die Kopf‑/Fußzeilen‑Manager‑Schnittstellen zu steuern.

Die verfügbaren Platzhalter hängen vom Geltungsbereich ab:

| Geltungsbereich | Kopfzeile | Fußzeile | Datum/Uhrzeit | Folien‑/Seitenzahl |
|---|---|---|---|---|
| Standardfolie | Nein | Ja | Ja | Ja |
| Notiz‑Master | Ja | Ja | Ja | Ja |
| Notizfolie | Ja | Ja | Ja | Ja |
| Handzettel‑Master | Ja | Ja | Ja | Ja |

Eine reguläre Präsentationsfolie besitzt keinen Kopfzeilen‑Platzhalter. Kopfzeilen sind auf Notizseiten und Handzetteln verfügbar. Für reguläre Folien verwenden Sie stattdessen die Platzhalter für Fußzeile, Datum/Uhrzeit und Folien‑Nummer.

Der Geltungsbereich einer Änderung hängt vom verwendeten Manager ab. Die [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/islideheaderfootermanager/)‑Schnittstelle steuert eine einzelne Standardfolie. Die [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/inotesslideheaderfootermanager/)‑Schnittstelle steuert eine einzelne Notizfolie. Master‑ und Layout‑Manager können Einstellungen ebenfalls auf abhängige Folien übertragen, während die [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/imasterhandoutslideheaderfootermanager/)‑Schnittstelle den Handzettel‑Master steuert.

## **Fußzeile, Datum/Uhrzeit und Folien‑Nummern auf regulären Folien setzen**

Für reguläre Folien besteht der grundlegende Ablauf darin, den Kopf‑/Fußzeilen‑Manager jeder Folie aufzurufen, den Text für Fußzeile und Datum/Uhrzeit zu setzen, die erforderlichen Platzhalter zu aktivieren und die Präsentation zu speichern. Folien‑Nummern werden von der Präsentation erzeugt, sodass Sie nur deren Sichtbarkeit steuern müssen.

Verwenden Sie [`SetFooterText`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) und [`SetDateTimeText`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/), um den Text zu setzen, und [`SetFooterVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) sowie [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/), um die entsprechenden Platzhalter anzuzeigen.

Das folgende End‑to‑End‑Beispiel wendet dieselbe Fußzeile, denselben Datum/Uhrzeit‑Text und dieselbe Sichtbarkeit der Folien‑Nummer auf alle regulären Folien an:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Möchten Sie nur eine Folie aktualisieren, greifen Sie direkt über die [`Slides`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/slides/de/)‑Sammlung auf diese Folie zu, anstatt die gesamte Sammlung zu durchlaufen.

## **Kopf‑ und Fußzeilen im Notiz‑Master setzen**

Der Notiz‑Master definiert einheitliche Formatierung und Platzhalter‑Verhalten für Notizseiten. Verwenden Sie die [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslideheaderfootermanager/)‑Schnittstelle, wenn Sie ausschließlich den Notiz‑Master ändern möchten.

Das folgende Beispiel setzt Kopfzeile, Fußzeile und Datum/Uhrzeit‑Text im Notiz‑Master und macht alle unterstützten Platzhalter auf diesem Master sichtbar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Die [`MasterNotesSlide`](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslidemanager/masternotesslide/)‑Eigenschaft gibt `null` zurück, wenn die Präsentation keinen Notiz‑Master enthält.

## **Einstellungen des Notiz‑Masters auf untergeordnete Notizfolien anwenden**

Ein Notiz‑Master kann Kopf‑ und Fußzeilen‑Einstellungen sowohl auf sich selbst als auch auf alle abhängigen Notizfolien anwenden. Verwenden Sie die dedizierten Propagations‑Methoden der [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslideheaderfootermanager/), wenn dieselben Einstellungen über die gesamte Notiz‑Hierarchie hinweg gelten sollen.

Beispielsweise aktualisieren [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) und [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) die Kopfzeile des Notiz‑Masters und aller untergeordneten Kopfzeilen. Entsprechende Methoden stehen für Fußzeilen, Datum/Uhrzeit und Folien‑Nummern zur Verfügung.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Die oben verwendeten Propagations‑Methoden sind [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) und [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Kopf‑ und Fußzeilen einer einzelnen Notizfolie setzen**

Eine Notizfolie gehört zu einer bestimmten regulären Folie. Verwenden Sie deren [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/inotesslideheaderfootermanager/)‑Schnittstelle, wenn Sie ausschließlich diese Notizseite anpassen möchten.

Die [`AddNotesSlide`](https://reference.aspose.com/slides/de/net/aspose.slides/inotesslidemanager/addnotesslide/)‑Methode gibt die Notizfolie zur aktuellen Folie zurück und erstellt sie, falls sie noch nicht existiert. Das folgende Beispiel konfiguriert die Notizseite, die der ersten Präsentationsfolie zugeordnet ist:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Wenn Sie zuerst Einstellungen vom Notiz‑Master propagieren und anschließend eine einzelne Notizfolie ändern, ermöglichen die nachträglichen Folien‑Einstellungen eine unabhängige Anpassung dieser Notizseite.

## **Kopf‑ und Fußzeilen im Handzettel‑Master setzen**

Handzettel‑Seiten verwenden den Handzettel‑Master für ihre Kopf‑, Fuß‑, Datum/Uhrzeit‑ und Seiten‑Nummer‑Platzhalter. Im Gegensatz zu Notizseiten werden Handzettel‑Einstellungen über den Handzettel‑Master und nicht über einzelne Handzettel‑Folien verwaltet.

Verwenden Sie die [`MasterHandoutSlide`](https://reference.aspose.com/slides/de/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/)‑Eigenschaft, um auf den Handzettel‑Master zuzugreifen. Falls er nicht vorhanden ist, rufen Sie [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/de/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) auf, um den Standard‑Handzettel‑Master zu erstellen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Geltungsbereich und Vererbung verstehen**

Wählen Sie den Kopf‑/Fußzeilen‑Manager, der dem gewünschten Geltungsbereich entspricht:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/islideheaderfootermanager/) ändert Fußzeile, Datum/Uhrzeit und Folien‑Nummer‑Einstellungen für eine reguläre Folie.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslideheaderfootermanager/) steuert ein Layout und kann unterstützte Einstellungen auf abhängige Folien übertragen.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslideheaderfootermanager/) steuert einen regulären Folien‑Master und kann unterstützte Einstellungen auf abhängige Folien übertragen.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslideheaderfootermanager/) steuert den Notiz‑Master und kann Einstellungen auf alle abhängigen Notizfolien übertragen.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/inotesslideheaderfootermanager/) ändert eine Notizfolie und unterstützt neben Fußzeile, Datum/Uhrzeit und Folien‑Nummer auch einen Kopfzeilen‑Platzhalter.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/de/net/aspose.slides/imasterhandoutslideheaderfootermanager/) ändert den Handzettel‑Master und unterstützt alle vier Platzhaltertypen.

Verwenden Sie die Propagation von einem Master oder Layout, wenn dieselbe Einstellung für die gesamte Hierarchie gelten soll. Nutzen Sie einen einzelnen Folien‑ oder Notiz‑Slide‑Manager, wenn Sie eine lokale Einstellung für eine Seite benötigen.

## **FAQ**

**Kann ich einer regulären Folie eine Kopfzeile hinzufügen?**

Nein. PowerPoint definiert keinen Kopfzeilen‑Platzhalter für reguläre Folien. Auf regulären Folien verwenden Sie die Fußzeilen‑, Datum/Uhrzeit‑ und Folien‑Nummer‑Platzhalter. Kopfzeilen‑Platzhalter stehen auf Notizseiten und Handzetteln zur Verfügung.

**Was tun, wenn ein Fußzeilen‑, Datum/Uhrzeit‑ oder Folien‑Nummer‑Platzhalter nicht sichtbar ist?**

Verwenden Sie den entsprechenden Kopf‑/Fußzeilen‑Manager, um die Sichtbarkeit zu prüfen und bei Bedarf zu aktivieren. Beispielsweise gibt [`IsFooterVisible`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) an, ob ein Fußzeilen‑Platzhalter vorhanden ist, und [`SetFooterVisibility`](https://reference.aspose.com/slides/de/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ändert dessen Sichtbarkeit.

**Wie beginne ich die Folien‑Nummerierung mit einem anderen Wert als 1?**

Setzen Sie die [`FirstSlideNumber`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/firstslidenumber/)‑Eigenschaft der Präsentation. Die Folien‑Nummer‑Platzhalter verwenden dann die aktualisierte Nummerierungssequenz.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren nach PDF, Bildern oder HTML?**

Sichtbare Kopf‑ und Fußzeilen‑Elemente werden zusammen mit dem restlichen Präsentationsinhalt im Ausgabeformat gerendert. Ihr Aussehen hängt vom zu exportierenden Seitentyp und den entsprechenden Platzhalter‑Sichtbarkeitseinstellungen ab.