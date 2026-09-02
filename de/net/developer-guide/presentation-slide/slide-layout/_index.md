---
title: Folienlayouts in .NET anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/net/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- nicht verwendetes Layout
- Fußzeilen‑Sichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnitts‑Überschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- PowerPoint
- OpenDocument
- Präsentation
- C#
- .NET
- Aspose.Slides
description: "Folienlayouts in Aspose.Slides für .NET anwenden, erstellen und bearbeiten, Platzhalter hinzufügen, nicht verwendete Layouts entfernen und die Fußzeilen‑Sichtbarkeit steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und das Format von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die gebräuchlichsten Layouts sind:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeinen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verständnis der Layout‑Vererbung**

Eine Präsentation hat drei miteinander verbundene Ebenen:

1. Eine [Master‑Folie](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) definiert das Design, geteilte Formatierung, Hintergründe und gemeinsame Objekte.  
1. Eine [Layout‑Folie](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.  
1. Eine [normale Folie](https://reference.aspose.com/slides/de/net/aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine normale Folie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer normalen Folie gesetzter Wert überschreibt den vererbten Wert auf dieser Ebene. Beim Erstellen einer normalen Folie werden die Platzhalter‑Formen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur normalen Folie gehört.

Fügen Sie erforderliche Platzhalter zu einem Layout hinzu, bevor Sie Folien daraus erzeugen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalter‑Form zu bereits vorhandenen normalen Folien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern vererbter Formatierungen oder vorhandener Platzhalter‑Geometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Prüfen Sie vor dem Bearbeiten eines bereits genutzten Layouts die abhängigen Folien und überprüfen Sie die resultierende Präsentation.  
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur nicht genutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Slide Master](/slides/de/net/slide-master/).

## **Auswählen und Anwenden eines Folienlayouts**

Verwenden Sie einen Layout‑Typ, wenn die Präsentation den standardmäßigen PowerPoint‑Layout‑Definitionen folgt. Layout‑Namen können vom Benutzer bearbeitet und lokalisiert werden, sodass eine Auswahl nach Namen weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Wenn dieses Layout nicht verfügbar ist, greift es bewusst auf **Leer** zurück. Die zweite Null‑Prüfung ist nötig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [ISlide.LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/layoutslide/)‑Eigenschaft auf die erste normale Folie angewendet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Platzhalterpositionen, vererbte Formatierungen und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können sich jedoch ändern, daher sollten Sie die Ausgabe prüfen, wenn Sie zwischen erheblich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layout‑Folie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/masterlayoutslidecollection/add/)‑Methode der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine normale Folie darauf basierend. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage wirklich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein passendes Layout, wählen Sie dieses aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layout‑Folie hinzufügen**

Die [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/placeholdermanager/)‑Eigenschaft stellt einen [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalter‑Formen zu einem Layout bereit.

| PowerPoint‑Platzhalter               | `ILayoutPlaceholderManager` Methode |
| ------------------------------------ | ----------------------------------- |
| ![Inhalt](content.png)               | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Inhalt (vertikal)](contentV.png)   | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                    | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (vertikal)](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Bild](picture.png)                 | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagramm](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabelle](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Medium](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online‑Bild](onlineImage.png)      | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt dann eine normale Folie, die das geänderte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die normale Folie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalter‑Formen auf dieser Folie erzeugen kann.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Platzhalter auf der Layout‑Folie](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Das Ändern vererbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bereits vorhandene normale Folien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen nicht genutzter Layout‑Folien**

Verwenden Sie die [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑Methode, um Layouts zu entfernen, auf die keine normale Folie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Um ein bestimmtes Layout zu entfernen, prüfen Sie zuerst dessen [HasDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/hasdependingslides/)‑Eigenschaft oder die [GetDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/getdependingslides/)‑Methode. Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [ILayoutSlide.Remove](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/remove/) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layout‑Folie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummern‑ und Datum‑Zeit‑Platzhalter. Nutzen Sie die [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/headerfootermanager/)‑Eigenschaft, um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen zeigen sollen, Titelfolien jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht seine Fußzeilen‑Elemente sichtbar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und seinen untergeordneten Layouts**

Um konsistente Fußzeilen‑Einstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/headerfootermanager/)‑Eigenschaft. Die Propagations‑Methoden von [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normal‑Folien; sie richten sich nicht nur an eine einzelne normale Folie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Eine Master‑Folie definiert das Design und die geteilte Formatierung der Präsentation. Eine Layout‑Folie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normale Folien verwenden diese Layouts und speichern den folienspezifischen Inhalt.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie eine Kopie zur Ziel‑Sammlung mit der [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/globallayoutslidecollection/addclone/)‑Methode hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und weitere Ressourcen des Quell‑Layouts überprüfen.

**Was geschieht, wenn ich ein bereits genutztes Layout bearbeite?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschreiben. Die Geometrie von Platzhaltern und vererbte Stile können daher gleichzeitig auf vielen Folien geändert werden. Nutzen Sie [GetDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/getdependingslides/), um die betroffenen Folien vor dem Bearbeiten des Layouts zu identifizieren.

**Was passiert, wenn ich ein noch genutztes Layout entferne?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception/). Ordnen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), um nur nicht referenzierte Layouts zu entfernen.