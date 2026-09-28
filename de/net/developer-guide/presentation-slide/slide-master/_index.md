---
title: Verwalten von Folienmastern in .NET
linktitle: Folienmaster
type: docs
weight: 80
url: /de/net/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten von Folienmastern in Aspose.Slides für .NET: Zugriff, Bearbeitung, Klonen, Vergleichen und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Themen‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides for .NET unterstützt dasselbe Modell. Eine Präsentation kann eine oder mehrere Masterfolien enthalten, und jede Masterfolie kann mehrere Layoutfolien enthalten. Normalfolien verweisen in der Regel nicht direkt auf eine Masterfolie. Stattdessen verwendet eine Normalfolie eine Layoutfolie, und diese Layoutfolie gehört zu einer Masterfolie.

Die Hierarchie ist:

1. **Folienmaster** – definiert das gemeinsame Design und das Theme.  
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normalfolie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Masterfolien, Layoutfolien und Normalfolien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch das Interface [IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) dargestellt. Alle Masterfolien einer Präsentation sind über die Sammlung [Presentation.Masters](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/masters/) zugänglich, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/) implementiert.

{{% alert color="info" title="Inheritance" %}}

Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispielsweise wird bei einer Masterfolie und einer Layoutfolie, die beide einen Hintergrund definieren, der auf der Layoutfolie basierende Folien den Layout‑Hintergrund verwenden. Weitere Informationen zu Layoutfolien finden Sie unter [Layoutfolien anwenden oder ändern](/slides/de/net/slide-layout/).

{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `Masters`, um Masterfolien zuzugreifen:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Sie können auch die Masterfolie, die von einer Normalfolie verwendet wird, über deren Layout abrufen:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Was ein Folienmaster enthält**

Eine Masterfolie ist ein folienähnliches Objekt. Sie implementiert [IBaseSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/), sodass sie viele der gleichen Folieneigenschaften bereitstellt, die von Normal‑ und Layoutfolien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) aufgelistet.

Häufig verwendete Masterfolien‑Mitglieder sind:

| Mitglied | Zweck |
| --- | --- |
| `Background` | Legt den Folienhintergrund auf Masterebene fest. |
| `Shapes` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `LayoutSlides` | Speichert die Layoutfolien, die zum Master gehören. |
| `ThemeManager` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `HeaderFooterManager` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Foliennummern für den Master und seine untergeordneten Layouts. |
| `GetDependingSlides` | Gibt Normalfolien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einer Masterfolie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederholte Bildelemente.

Das folgende Beispiel fügt dem ersten Master eine Logo‑Grafik hinzu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Weitere Informationen zu Bildrahmen finden Sie unter [Bildrahmen](/slides/de/net/picture-frame/).

## **Die Sichtbarkeit von Mastergrafiken steuern**

Verwenden Sie [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/showmastershapes/), um geerbte Mastergrafiken, wie Logos oder dekorative Formen, auszublenden, ohne sie vom Master zu löschen. Setzen Sie [Slide.ShowMasterShapes](https://reference.aspose.com/slides/de/net/aspose.slides/slide/showmastershapes/) auf `false` für die Folie, die diese Grafiken weglassen soll, und auf `true` für Folien, die sie anzeigen sollen.

Das folgende eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabe‑Präsentation oder Bild ist erforderlich.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Das Beispiel nutzt das **Blank**‑Layout, das einer neuen Präsentation beiläufig ist, und entfernt die eigenen Platzhalter der Ausgangsfolie.

### **Den Geltungsbereich der Einstellung wählen**

Eine Normalfolie verwendet ihren Master über [ISlide.LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/layoutslide/) und [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/masterslide/). Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf diese Folie. Das Setzen von [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/de/net/aspose.slides/layoutslide/showmastershapes/) auf `false` blendet Mastergrafiken für alle Folien aus, die dieses geteilte Layout benutzen, selbst wenn deren eigene Einstellung `true` ist. Um Grafiken nur auf einer Folie auszublenden, ändern Sie die Folieneigenschaft und lassen das geteilte Layout unverändert.

Die Einstellung wird nicht als Sichtbarkeitssteuerung auf der Masterfolie selbst unterstützt. Auf einem Master liefert sie stets `false`, und das Zuweisen von `true` löst eine `NotSupportedException` aus. Wenden Sie sie stattdessen auf eine Normalfolie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Operation | Auswirkung |
| --- | --- |
| Mastergrafiken ausblenden | Steuert die Sichtbarkeit geerbter Masterformen, ohne sie zu löschen oder die eigenen Formen der Folie zu verändern. |
| Folienhintergrundfüllung ändern | Ändert die Hintergrundfarbe, den Farbverlauf oder das Bild. Mastergrafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Präsentationshintergrund](/slides/de/net/presentation-background/). |
| Eine Form vom Master löschen | Entfernt die gemeinsam genutzte Quellform, sodass sie für keine Folie mehr verfügbar ist, die diesen Master verwendet. |

## **Mit Platzhaltern arbeiten**

Platzhalter werden normalerweise auf Layoutfolien definiert. Die Masterfolie liefert den geteilten Stil und das Theme, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Sie können auch vorhandene Platzhalterformen auf einer Masterfolie formatieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Formatierter Titelplatzhalter, der von Normalfolien geerbt wird](slide-master_8.png)

Weitere Optionen zur Platzhalter‑ und Textformatierung finden Sie unter [Platzhalter‑Text festlegen](/slides/de/net/manage-placeholder/) und [Textformatierung](/slides/de/net/text-formatting/).

## **Den Folienmaster‑Hintergrund ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel legt für die erste Masterfolie eine einheitliche Hintergrundfarbe fest:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Verwandte Themen finden Sie unter [Präsentationshintergrund](/slides/de/net/presentation-background/) und [Präsentationstheme](/slides/de/net/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection/addclone/), um eine Masterfolie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Falls Sie Normalfolien zusammen mit ihrem Master klonen müssen, siehe [Folien klonen](/slides/de/net/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Masterfolien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Marken‑, Seiten‑ oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Masterfolien können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/) geerbten `Equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, etwa Formen, Text, Formatierung, Animationen und andere Foliensettings. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```csharp
using Aspose.Slides;

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

Weitere Informationen finden Sie unter [Präsentationsfolien vergleichen](/slides/de/net/compare-slides/).

## **Folienmaster‑Ansicht als Standard‑Ansicht festlegen**

Verwenden Sie die Eigenschaft `LastView` auf [ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Weitere Ansichtseinstellungen finden Sie unter [Präsentation speichern](/slides/de/net/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Masterfolien, die von keiner Normalfolie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/de/net/aspose.slides/masterslidecollection/removeunused/), um unbenutzte Master aus der Sammlung `Masters` zu entfernen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Sie können auch die Low‑Code‑Methode [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) nutzen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layoutfolie?**

Ein Folienmaster definiert gemeinsam genutzte Designeinstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine Normalfolie verwendet eine Layoutfolie, sodass sie sowohl vom Layout als auch vom Master erbt.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn unterschiedliche Abschnitte verschiedene visuelle Systeme oder Marken benötigen.

**Soll ich Platzhalter zu einer Masterfolie oder zu einer Layoutfolie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Gemeinsame visuelle Elemente und Formatierungen gehören zur Masterfolie, während Inhalts‑Platzhalter auf den Layouts platziert werden, die von Normalfolien verwendet werden.

**Kann ich eine Masterfolie löschen, die noch verwendet wird?**

Nein. Eine Masterfolie, die abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode, die nur ungenutzte Master entfernt.