---
title: "Anwenden oder Ändern von Folienlayouts in .NET"
linktitle: "Folienlayout"
type: docs
weight: 60
url: /de/net/slide-layout/
keywords:
- "Folienlayout"
- "Inhaltslayout"
- "Platzhalter"
- "Präsentationsdesign"
- "Foliendesign"
- "unbenutztes Layout"
- "Fußzeilen‑Sichtbarkeit"
- "Titelfolie"
- "Titel und Inhalt"
- "Abschnitts‑Überschrift"
- "Zwei Inhalte"
- "Vergleich"
- "Nur Titel"
- "Leeres Layout"
- "Inhalt mit Beschriftung"
- "Bild mit Beschriftung"
- "Titel und vertikaler Text"
- "Vertikaler Titel und Text"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Anwenden, Erstellen und Ändern von Folienlayouts in Aspose.Slides für .NET, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und die Formatierung von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts gibt Folien eine einheitliche Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die gebräuchlichsten Layouts sind:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemein nutzbaren Inhaltsplatzhalter.
- **Leer**: Enthält keine Inhaltsplatzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Layoutvererbung verstehen**

Eine Präsentation hat drei verwandte Ebenen:

1. Ein [Masterfolie](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) definiert das Design, die gemeinsame Formatierung, Hintergründe und allgemeine Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [Standardfolie](https://reference.aspose.com/slides/de/net/aspose.slides/islide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Standardfolie erbt Thema und Formatierung von ihrem Layout, und das Layout erbt vom zugehörigen Master. Ein direkt auf einer Standardfolie festgelegter Wert überschreibt den geerbten Wert auf dieser Ebene. Wenn eine Standardfolie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout erzeugt, während der in diese Platzhalter eingegebene Inhalt zur Standardfolie gehört.

Fügen Sie erforderliche Platzhalter zu einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalterform zu bereits vorhandenen Standardfolien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern der geerbten Formatierung oder der vorhandenen Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts sollten Sie dessen abhängige Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie zunächst seine abhängigen Folien einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Für weitere Informationen zur obersten Ebene dieser Hierarchie siehe [Folienmaster](/slides/de/net/slide-master/).

Um geerbte Logos oder dekorative Masterformen auf einer Folie oder über ein gemeinsames Layout auszublenden, siehe [Steuern der Sichtbarkeit von Mastergrafiken](/slides/de/net/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den Standard‑PowerPoint‑Layoutdefinitionen folgt. Layoutnamen können vom Benutzer bearbeitet und lokalisiert werden, sodass die Auswahl nach Namen weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** zurückgegriffen. Die zweite Nullprüfung ist erforderlich, weil eine Präsentation ausschließlich benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [ISlide.LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/layoutslide/)‑Eigenschaft auf die erste Standardfolie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die normalen Formen, die direkt zur Folie hinzugefügt wurden. Allerdings können Platzhalterpositionen, geerbte Formatierungen und die Übereinstimmung zwischen bestehenden Platzhaltern und dem neuen Layout geändert werden; prüfen Sie daher die Ausgabe, wenn Sie zwischen erheblich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind separate Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die Methode [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/masterlayoutslidecollection/add/) auf der Layoutsammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt immer ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine Standardfolie, die darauf basiert. Layoutnamen müssen innerhalb der Sammlung eindeutig sein.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein passendes Layout, wählen Sie dieses aus und verwenden es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die Eigenschaft [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/placeholdermanager/) stellt einen [ILayoutPlaceholderManager](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout bereit.

| PowerPoint‑Platzhalter               | `ILayoutPlaceholderManager` Method |
| ------------------------------------ | ---------------------------------- |
| Inhalt                               | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| Inhalt (vertikal)                    | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| Text                                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| Text (vertikal)                      | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| Bild                                 | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| Diagramm                             | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| Tabelle                              | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| SmartArt                             | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| Medium                               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| Online‑Bild                          | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Das folgende Beispiel überprüft, ob das **Leer**‑Layout vorhanden ist, fügt ihm vier Platzhalter hinzu und erstellt dann eine Standardfolie, die das geänderte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Standardfolie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie generieren kann.

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

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Das Ändern der geerbten Formatierung oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bestehende Standardfolien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Unbenutzte Layoutfolien entfernen**

Verwenden Sie die Methode [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) , um Layouts zu entfernen, auf die keine Standardfolie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Um ein bestimmtes Layout zu entfernen, verwenden Sie zuerst dessen Eigenschaft [HasDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/hasdependingslides/) oder die Methode [GetDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/getdependingslides/). Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [ILayoutSlide.Remove](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/remove/) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout hat eigene Fußzeilen-, Folienzahl‑ und Datum‑Uhr‑Platzhalter. Verwenden Sie die Eigenschaft [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/headerfootermanager/) , um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn z. B. Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilenelemente sichtbar:

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

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die Eigenschaft [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/headerfootermanager/). Die Propagationsmethoden von [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Standardfolien; sie richten sich nicht nur an eine einzelne Standardfolie.

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

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Design und die gemeinsame Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Standardfolien verwenden diese Layouts und speichern folienbezogenen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/globallayoutslidecollection/addclone/) eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und andere vom Quell‑Layout verwendete Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschreiben. Die Platzhaltergeometrie und die geerbten Stile können sich daher auf vielen Folien gleichzeitig ändern. Verwenden Sie [GetDependingSlides](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/getdependingslides/), um die betroffenen Folien vor der Bearbeitung des Layouts zu ermitteln.

**Was passiert, wenn ich ein noch verwendetes Layout entferne?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception/). Ordnen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), um nur nicht referenzierte Layouts zu entfernen.