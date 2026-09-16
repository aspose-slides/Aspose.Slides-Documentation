---
title: Verwalten von Präsentations‑Hyperlinks in .NET
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/net/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text‑Hyperlink
- Folie‑Hyperlink
- Form‑Hyperlink
- Bild‑Hyperlink
- Video‑Hyperlink
- Veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Hyperlinks in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET hinzufügen, formatieren, aktualisieren und entfernen, anhand von C#‑Beispielen."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Eine Website aus Text, einer Form oder einem Medienrahmen öffnen.
* Zu einer anderen Folie navigieren, zum Beispiel von einem Inhaltsverzeichnis.

Aspose.Slides für .NET ermöglicht das Hinzufügen dieser Links, die Steuerung von Aussehen und Klang, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachstehenden Beispiele zeigen, wie man mit Hyperlinks an einzelnen Elementen arbeitet und wie man Hyperlinks auf Präsentations‑, Folien‑ oder Text‑Frame‑Ebene zugreift.

{{% alert color="info" title="Hinweis" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online‑Aspose‑PowerPoint‑Editor](https://products.aspose.app/slides/de/editor) bearbeiten.
{{% /alert %}} 

## **URL‑Hyperlinks hinzufügen**

Sie können einer Text, einer Form oder einem Medienrahmen eine Website‑URL zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verlinken, weisen Sie dem Textabschnitt die [Hyperlink](https://reference.aspose.com/slides/de/net/aspose.slides/hyperlink/)-Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/portionformat/hyperlinkclick/) zu, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **URL‑Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, setzen Sie deren [HyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/shape/hyperlinkclick/)-Eigenschaft. Der Hyperlink gehört zum Objekt selbst und nicht zu einem darin enthaltenen Textabschnitt.

Der gleiche Ansatz gilt für Bild-, Audio‑ und Video‑Frames: Weisen Sie dem Frame den Hyperlink zu und setzen Sie bei Bedarf das [Tooltip](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/tooltip/)-Attribut des Links.

Das folgende Beispiel macht ein Rechteck anklickbar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Hyperlinks verwenden, um ein Inhaltsverzeichnis zu erstellen**

Interne Hyperlinks ermöglichen es dem Leser, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [SetInternalHyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/), um den Text „Seite 2“ auf der ersten Folie mit der zweiten Folie zu verlinken.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Hyperlinks formatieren**

### **Farbe**

Die [ColorSource](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/colorsource/)-Eigenschaft von [IHyperlink](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen übernehmen diese Einstellung nicht.

Das folgende Beispiel fügt derselben Folie zwei Text‑Hyperlinks hinzu. Der erste verwendet eine rote Textfüllung, während der zweite die Standard‑Hyperlink‑Farbe beibehält.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **Sound**

Ein Hyperlink kann beim Aktivieren einen Sound abspielen oder einen bereits spielenden Sound stoppen. Verwenden Sie die folgenden Eigenschaften, um dieses Verhalten zu konfigurieren:

- [IHyperlink.Sound](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/sound/) gibt das dem Hyperlink zugeordnete Audio an.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/stopsoundonclick/) steuert, ob das Aktivieren des Hyperlinks den vorherigen Sound stoppt.

#### **Hyperlink‑Sound hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft es mit einem Button auf der ersten Folie. Ein Klick auf den Button spielt den Sound ab und navigiert zur nächsten Folie. Eine zweite Form auf dieser Folie stoppt den vorherigen Sound beim Klicken, ohne eine Navigationsaktion auszuführen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Hyperlink‑Sound extrahieren**

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest das Hyperlink‑Audio der ersten Form mithilfe von [Sound](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/sound/) und [BinaryData](https://reference.aspose.com/slides/de/net/aspose.slides/iaudio/binarydata/) in den Speicher.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip‑ und Interaktionseinstellungen**

Sie können die folgenden [IHyperlink](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/)-Eigenschaften aktualisieren, nachdem Sie einem Text oder einer Form einen Hyperlink zugewiesen haben:

- [Tooltip](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/tooltip/) legt den Text fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [TargetFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/targetframe/) gibt das Zielframe innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [History](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/history/) steuert, ob das Aktivieren des Links sein Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [HighlightClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/highlightclick/) bestimmt, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [GetAnyHyperlinks](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/), um Hyperlink‑Container, einschließlich Text‑Abschnitt‑Links, zu sammeln, bevor Sie Änderungen vornehmen. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [RemoveHyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) bzw. [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) auf; das Entfernen einer Klick‑Aktion entfernt nicht die zugehörige Mouse‑Over‑Aktion.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Für bedingungslose Entfernung entfernt [RemoveAllHyperlinks](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), beide Aktivierungstypen im ausgewählten Geltungsbereich in einem Aufruf. Für selektive Bereinigung und Abdeckung von Master‑Folien, Layouts und Notizen siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verbreiten, erfassen Sie deren interaktive Aktionen sowie Web‑Links. [GetAnyHyperlinks](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) liefert [IHyperlinkContainer](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkcontainer/)‑Objekte, nicht eine flache Liste von URL‑Zeichenketten. Untersuchen Sie sowohl [HyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) als auch [HyperlinkMouseOver](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) in jedem Container. Sie sind unabhängig: Derselbe Container kann beide Aktionen enthalten, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container erfordert.

Das Scannen nur von Hyperlinks auf Form‑Ebene kann Links überspringen, die an Textabschnitten hängen. Fragen Sie stattdessen den entsprechenden Geltungsbereich ab und bewahren Sie die zurückgegebenen Container, sodass Sie deren Aktionen später aktualisieren oder entfernen können.

### **Präsentations‑, Folien‑ und Text‑Frame‑Geltungsbereiche abfragen**

Die Schnittstelle [IHyperlinkQueries](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/) ist über [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/hyperlinkqueries/) und [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/hyperlinkqueries/) verfügbar. Jeder Geltungsbereich unterstützt dieselben Abfragen:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) gibt Container mit einer Klick‑Aktion zurück.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) gibt Container mit einer Mouse‑Over‑Aktion zurück.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) gibt Container mit einer oder beiden Aktionen zurück.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Mouse‑Over‑Link, einer internen Folien‑Navigation, einem Text‑Mouse‑Over‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Geltungsbereich; die Zählungen beschreiben Container, nicht die Gesamtzahl der Aktionen. Der Text‑Frame‑Geltungsbereich schließt die eigenen Links der umgebenden Form aus.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Für dieses Beispiel melden die Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Mouse‑Over‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet jeweils einen Container pro Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [IHyperlink.ActionType](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/actiontype/), um eine Aktion zu interpretieren, bevor Sie ihr Ziel interpretieren. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/net/aspose.slides/hyperlinkactiontype/) umfassen mehr als die Web‑Navigation:

| Werte | Bedeutung für die Prüfung |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; prüfen Sie die URL und ihr Schema. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Diashow‑Navigation, im Diashow‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Beendet die aktuelle Show oder startet eine benutzerdefinierte Show. |
| `StartMacro` | Ein Makro ausführen. |
| `StartProgram` | Ein Programm starten. |
| `OpenFile`, `OpenPresentation` | Eine Datei oder eine andere Präsentation öffnen; getrennt von Web‑URLs prüfen. |
| `StartStopMedia` | Medienwiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion oder eine nicht erkannte Aktion, die geprüft werden muss. |

Lesen Sie externe Ziele aus [ExternalUrl](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/externalurl/) und spezifische interne Ziele aus [TargetSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/targetslide/). Interne Aktionen und eingebaute Befehle können keine externe URL haben; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie [ExternalUrlOriginal](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/externalurloriginal/) auf, wenn sie von der normalisierten URL abweicht, und fügen Sie das [Tooltip](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlink/tooltip/) hinzu, sofern vorhanden.

### **Hyperlinks prüfen, bereinigen und verifizieren**

Das folgende .NET 6+-Beispiel liest eine bestehende Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen zu prüfen. Es sammelt die Container, bevor sie geändert werden, und verwendet Referenzgleichheit, um eine doppelte Verarbeitung desselben Containers zu vermeiden. Präsentations‑Abfragen decken normale Folien ab; für ein paketweites Inventar werden zudem explizit Master‑Folien, Layouts, Notizen sowie die Notiz‑ und Handzettel‑Master abgefragt, falls vorhanden.

Der Bericht zeichnet einen einbasierten Folien‑Index und [SlideId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/slideid/) auf, sofern verfügbar. [ISlideComponent.Slide](https://reference.aspose.com/slides/de/net/aspose.slides/islidecomponent/slide/) liefert die zugehörige Folie für unterstützte Container. Master‑Folien, Layouts und Notizen besitzen keinen gewöhnlichen Folien‑Index und werden anhand ihres Geltungsbereichs identifiziert. Form‑Container und Text‑Abschnitt‑Formatierungs‑Container werden getrennt gekennzeichnet; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, damit seine beiden Aktionen korreliert werden können.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folienziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Diashow‑Aktionen, unbekannte Aktionen und andere URL‑Schemata. Diese Ablehnungen sind Richtlinien‑Entscheidungen, kein Sicherheitsurteil von Aspose.Slides. HTTPS allein begründet kein Vertrauen: Fügen Sie Host‑Whitelist‑Einträge und weitere Prüfungen für Ihre Anwendung hinzu. Sowohl die originalen als auch die normalisierten externen URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt der Container‑[HyperlinkManager](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) und [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Zielseite ersetzt; andere verbotene Klicks und verbotene Mouse‑Over‑Aktionen werden unabhängig entfernt. Setzen Sie `replaceExternalClicks` auf `false`, um stattdessen alle Richtlinienverstöße zu entfernen. Wählen Sie vor der Bereitstellung eine von der Anwendung bereitgestellte Ersatzseite.

Die Export‑Kennzeichnung des Berichts verwendet eine konservative PDF‑Überprüfungspolicy: Mouse‑Over‑Aktionen und alles außer einem externen Link oder einem spezifischen Folien‑Sprung werden als potenziell nicht unterstützt markiert. Es ist ein Hinweis zur Überprüfung, kein Funktionstest oder eine Garantie, dass nicht markierte Links den Export überstehen. Unterstützte [PDF](/slides/de/net/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/net/convert-powerpoint-to-html/)‑Exporte können Hyperlinks je nach Aktion, Export‑Optionen und Viewer erhalten. Raster‑[Bilder](/slides/de/net/convert-powerpoint-to-png/) und [Video](/slides/de/net/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; markieren Sie jede Aktion bei der Prüfung für diese Ausgaben.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Mit dem oben erstellten Eingabedokument enthält der Bericht fünf Aktionszeilen. Der Datei‑Mouse‑Over‑Link und der Makro‑Klick werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifizierung gibt null verbotene Aktionen aus. Ein Eingabedokument mit einer verbotenen externen Klick‑URL testet ebenfalls den Ersetzungszweig. Ein Container mit einem erlaubten Klick und einem verbotenen Mouse‑Over behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [RemoveAllHyperlinks](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), das beide Aktivierungstypen im gesamten gewählten Geltungsbereich unabhängig von der Richtlinie entfernt. Die Verifizierung prüft hier nur Hyperlink‑Aktionen; sie entfernt keine eingebetteten VBA‑Projekte, OLE‑Objekte oder andere aktive Inhalte und valide nicht eine exportierte PDF‑ oder HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um eine Navigation zu einem Abschnitt zu erstellen, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einen Hyperlink an Elemente der Master‑Folien anhängen, damit er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Bildschirmerkennung auf Folien, die den entsprechenden Master oder das Layout verwenden, zur Verfügung.

**Werden Hyperlinks beim Exportieren zu PDF, HTML, Bildern oder Video beibehalten?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks beibehalten; Raster‑Bilder und Videos können dies nicht. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).