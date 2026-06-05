---
title: "Verwalten von Folienmastern in .NET"
linktitle: "Folienmaster"
type: docs
weight: 80
url: /de/net/slide-master/
keywords:
- "Folienmaster"
- "Masterfolie"
- "PPT-Masterfolie"
- "mehrere Masterfolien"
- "Masterfolien vergleichen"
- "Hintergrund"
- "Platzhalter"
- "Masterfolie klonen"
- "Masterfolie kopieren"
- "Masterfolie duplizieren"
- "unbenutzte Masterfolie"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Verwalten Sie Folienmaster in Aspose.Slides für .NET: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument‑Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert geteilte Design‑Einstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Theme‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides for .NET unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layoutfolien enthalten. Normale Folien verweisen in der Regel nicht direkt auf einen Folienmaster. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einem Folienmaster.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das geteilte Design und das Thema.  
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und layoutbezogener Formatierung.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Folienmastern, Layoutfolien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch das Interface [IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) repräsentiert. Alle Folienmaster in einer Präsentation sind über die Sammlung [Presentation.Masters](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/masters/) verfügbar, die das Interface [IMasterSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/) implementiert.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Zum Beispiel, wenn ein Folienmaster und eine Layoutfolie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layoutfolien finden Sie unter [Anwenden oder Ändern von Folienlayouts](/slides/de/net/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die `Masters`‑Sammlung, um auf Folienmaster zuzugreifen:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Sie können den von einer normalen Folie verwendeten Folienmaster auch über deren Layout abrufen:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Was ein Folienmaster enthält**

Ein Folienmaster ist ein folienähnliches Objekt. Es implementiert [IBaseSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/), sodass es viele der gleichen Folieneigenschaften bereitstellt, die bei normalen und Layoutfolien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) aufgeführt.

Häufig genutzte Folienmaster‑Mitglieder umfassen:

| Mitglied | Zweck |
| --- | --- |
| `Background` | Legt den Folienmaster‑Hintergrund fest. |
| `Shapes` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `LayoutSlides` | Speichert die Layoutfolien, die zum Master gehören. |
| `ThemeManager` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `HeaderFooterManager` | Steuert Kopf‑ und Fußzeilen, Datum und Foliennummern für den Master und seine untergeordneten Layouts. |
| `GetDependingSlides` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Folienmaster ein Logo hinzu:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Für weitere Informationen zu Bildrahmen siehe [Bildrahmen](/slides/de/net/picture-frame/).

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layoutfolien definiert. Der Folienmaster stellt den gemeinsamen Stil und das Theme bereit, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalterbefehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Sie können auch Platzhalterformen, die bereits auf einem Folienmaster existieren, formatieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet einen linearen Farbverlauf an:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Für weitere Optionen zur Platzhalter‑ und Textformatierung siehe [Prompt‑Text im Platzhalter festlegen](/slides/de/net/manage-placeholder/) und [Textformatierung](/slides/de/net/text-formatting/).

## **Folienmaster‑Hintergrund ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einheitliche Hintergrundfarbe für den ersten Folienmaster:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Verwandte Themen finden Sie unter [Präsentationshintergrund](/slides/de/net/presentation-background/) und [Präsentationsthema](/slides/de/net/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/), um einen Folienmaster in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Falls Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Folien klonen](/slides/de/net/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Folienmaster vergleichen**

Folienmaster können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/) geerbten `Equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statische Inhalte, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Identifikatoren, wie Folien‑IDs, oder dynamische Platzhalterwerte, wie das aktuelle Datum.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Für weitere Informationen siehe [Präsentationsfolien vergleichen](/slides/de/net/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Eigenschaft `LastView` von [ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Für weitere Ansichtseinstellungen siehe [Präsentation speichern](/slides/de/net/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner normalen Folie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/de/net/aspose.slides/masterslidecollection/removeunused/), um unbenutzte Master aus der `Masters`‑Sammlung zu entfernen:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Sie können außerdem die Low‑Code‑Methode [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwenden:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layoutfolie?**

Ein Folienmaster definiert gemeinsame Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenauftritte benötigen.

**Sollte ich Platzhalter zu einem Folienmaster oder zu einer Layoutfolie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Platzieren Sie gemeinsam genutzte visuelle Elemente und Formatierungen auf dem Folienmaster und legen Sie die Inhalts‑Platzhalter auf den Layouts fest, die von normalen Folien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Aufräummethode für unbenutzte Master, die nur Master entfernt, die nicht verwendet werden.