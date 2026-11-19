---
title: Verwalten von Präsentations-Hyperlinks in .NET
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
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET hinzufügen, formatieren, aktualisieren und entfernen, anhand von C#-Beispielen."
---
## **Einführung**

Ein Hyperlink verbindet die Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnen einer Website von Text, einer Form oder einem Medienrahmen.
* Navigieren zu einer anderen Folie, zum Beispiel aus einem Inhaltsverzeichnis.

Aspose.Slides für .NET ermöglicht das Hinzufügen dieser Links, das Steuern ihres Aussehens und Klangs, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachstehenden Beispiele zeigen, wie man mit Hyperlinks an einzelnen Elementen arbeitet und wie man Hyperlinks auf Präsentations-, Folien- oder Text‑Frame‑Ebene abruft.

{{% alert color="info" title="Note" %}}
Sie können Präsentationen auch mit dem [kostenlosen Online‑Aspose‑PowerPoint‑Editor](https://products.aspose.app/slides/editor) bearbeiten.
{{% /alert %}}

## **URL‑Hyperlinks hinzufügen**

Sie können einer Text, einer Form oder einem Medienrahmen eine Website‑URL zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den klickbaren Bereich: Ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

Für Präsentationen mit relativen Hyperlinks siehe [Manage the Hyperlink Base](/slides/de/net/presentation-properties/#manage-the-hyperlink-base), um die dokumentweite Basis zu lesen, zu ändern oder zu löschen.

### **URL‑Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verlinken, weisen Sie dem [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) der Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) des Textabschnitts zu, wie unten gezeigt. Nur dieser Textabschnitt wird klickbar.

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

Weisen Sie dem Rechteck die URL über die Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) zu, um dessen gesamte Fläche klickbar zu machen. Der [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) gibt dem Leser einen Hinweis auf das Ziel, wenn er über das Rechteck fährt. Die gleichen Eigenschaften gelten für Bild‑, Audio‑ und Video‑Frames.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es Lesern, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/), um den Text „Page 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

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

Sie können die Farbe des verlinkten Textes ändern, einen Ton abspielen oder stoppen, wenn ein Leser einen Link aktiviert, und den Tooltip festlegen, der beim Darüberfahren angezeigt wird.

### **Farbe**

Die Eigenschaft [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) von [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen wenden diese Einstellung nicht an.

Im folgenden Beispiel bewirkt das Setzen von [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) beim ersten Link, dass dessen Text rot angezeigt wird. Der zweite Link behält die Hyperlink‑Farbe der Präsentation bei.

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

Ein Hyperlink kann beim Aktivieren einen Ton abspielen oder einen bereits laufenden Ton stoppen. Verwenden Sie die folgenden Eigenschaften, um dieses Verhalten zu konfigurieren:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) gibt das dem Hyperlink zugeordnete Audio an.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) steuert, ob das Aktivieren des Hyperlinks den vorherigen Ton stoppt.

#### **Hyperlink‑Sound hinzufügen**

Der Button auf der ersten Folie verwendet [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) , um Audio aus einer WAV‑Datei abzuspielen, wenn der Leser zum Weiterblättern klickt. Auf der zweiten Folie verwendet ein separater Button [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/), um die Wiedergabe zu stoppen und den Leser auf dieser Folie zu halten.

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

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest das Hyperlink‑Audio der ersten Form mithilfe von [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) und [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) in den Speicher.

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

Sie können die folgenden [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)‑Eigenschaften aktualisieren, nachdem Sie einem Text oder einer Form einen Hyperlink zugewiesen haben:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) legt den Text fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) gibt, falls zutreffend, den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) steuert, ob das Aktivieren des Links dessen Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) steuert, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/), um Hyperlink‑Container, einschließlich Text‑Abschnitt‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) bzw. [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) auf; das Entfernen einer Klick‑Aktion entfernt nicht die dazugehörige Mouse‑Over‑Aktion.

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

Für eine bedingungslose Entfernung entfernt [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), beide Aktivierungstypen im ausgewählten Bereich in einem Aufruf. Für eine selektive Bereinigung und Abdeckung von Master‑Folien, Layouts und Notizen siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Hyperlinks vor dem Ersetzen von SmartArt‑Text löschen**

Wenn Sie einen Absatz in einem bestehenden SmartArt‑Knoten ersetzen, kann das Löschen seiner Textabschnitte einen alten Hyperlink wirksam lassen. Rufen Sie den Absatz über [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/) ab. Bevor Sie seine Abschnitte löschen, rufen Sie [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) über [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) im Text‑Frame der Knotenform auf, die den Absatz anzeigt. Dadurch werden alle Hyperlinks in diesem Frame entfernt, einschließlich Links in anderen Absätzen.

Das Beispiel geht davon aus, dass die dritte Form auf der ersten Folie eine SmartArt‑Grafik ist. Es ersetzt den ersten Absatz des vierten Knotens. In dieser Präsentation zeigt die erste Form des Knotens diesen Absatz an.

Nach dem Hinzufügen beider Abschnitte liest das Beispiel deren wirksame Formatierung mit [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). Die wirksame Eigenschaft [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) gibt den neuen Hyperlink für den ersten Abschnitt und `null` für den zweiten zurück.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **Komplettes Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verteilen, erfassen Sie deren interaktive Aktionen sowie deren Web‑Links. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) liefert Objekte vom Typ [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), nicht eine flache Liste von URL‑Zeichenketten. Untersuchen Sie sowohl [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) als auch [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) in jedem Container. Sie sind unabhängig: derselbe Container kann beide Aktionen enthalten, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das Scannen nur von Hyperlinks auf Form‑Ebene kann Links, die an Textabschnitten hängen, übersehen. Fragen Sie stattdessen den entsprechenden Umfang ab und bewahren Sie die zurückgegebenen Container auf, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Abfrage von Präsentations‑, Folien‑ und Text‑Frame‑Bereichen**

Das Interface [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) ist über [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) und [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) verfügbar. Jeder Umfang unterstützt dieselben Abfragen:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) gibt Container mit einer Klick‑Aktion zurück.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) gibt Container mit einer Mouse‑Over‑Aktion zurück.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) gibt Container mit einer oder beiden Aktionen zurück.

Dieses Beispiel weist einer Form und ihrem Text Klick‑ und Mouse‑Over‑Aktionen zu und einer separaten Schaltfläche eine Makro‑Aktion. Es vergleicht die von [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zurückgegebenen Container mit den Zählungen für jeden Aktivierungstyp. Eine Text‑Frame‑Abfrage zählt nur Links im Text. Die eigenen Aktionen der umgebenden Form erscheinen in den Folien‑ und Präsentations‑Abfragen.

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

Für dieses Beispiel melden die Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Mouse‑Over‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Frame‑Abfrage meldet einen Container in jeder Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/), um eine Aktion zu interpretieren, bevor Sie ihr Ziel auswerten. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) umfassen mehr als nur Web‑Navigation:

| Werte | Bedeutung für die Prüfung |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; prüfen Sie die URL und ihr Schema. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Diashow‑Navigation, im Diashow‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Beendet die aktuelle Show oder startet eine benutzerdefinierte Show. |
| `StartMacro` | Führt ein Makro aus. |
| `StartProgram` | Startet ein Programm. |
| `OpenFile`, `OpenPresentation` | Öffnet eine Datei oder eine andere Präsentation; getrennt von Web‑URLs prüfen. |
| `StartStopMedia` | Startet oder stoppt die Medienwiedergabe. |
| `NoAction`, `Unknown` | Keine Navigationsaktion oder eine nicht erkannte Aktion, die überprüft werden muss. |

Lesen Sie externe Ziele aus [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) und spezifische interne Ziele aus [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Interne Aktionen und eingebaute Befehle können keine externe URL besitzen; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) auf, wenn sie von der normalisierten URL abweicht, und fügen Sie den [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) hinzu, sofern verfügbar.

### **Hyperlinks melden, bereinigen und verifizieren**

Dieses .NET 6+‑Beispiel öffnet die Präsentation aus dem vorherigen Beispiel und schreibt einen JSON‑Datensatz pro Aktion. Es verwendet [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) , um Container auf normalen Folien, Master‑Folien, Layouts und Notizen zu sammeln, einschließlich der Notiz‑ und Handout‑Master, sofern vorhanden. Es verwendet Referenzgleichheit, um jeden Container einmal zu zählen, wendet die nachfolgend beschriebene Richtlinie an und öffnet die gespeicherte Präsentation erneut, um sowohl Klick‑ als auch Mouse‑Over‑Aktionen zu prüfen.

Der Bericht zeichnet einen einsbasierten Folien‑Index und, falls verfügbar, die [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) auf. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) liefert die zugehörige Folie für unterstützte Container. Master‑Folien, Layouts und Notizen besitzen keinen normalen Folien‑Index und werden anhand ihres Umfangs identifiziert. Form‑Container und Text‑Abschnitt‑Formatierungs‑Container werden separat benannt; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichtslokale ID, sodass seine beiden Aktionen korreliert werden können.

Diese bewusst restriktive Anwendungsrichtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folienziele. Sie verwirft Makros, Programme, Datei‑Aktionen, andere Diashow‑Aktionen, unbekannte Aktionen und andere URL‑Schemen. Diese Ablehnungen sind Richtlinien‑Entscheidungen, kein Sicherheitsurteil von Aspose.Slides. HTTPS allein schafft kein Vertrauen: Ergänzen Sie Host‑Whitelist‑ und weitere Prüfungen für Ihre Anwendung. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt der Container‑[HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) und [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Mouse‑Over‑Aktionen werden separat entfernt. Setzen Sie `replaceExternalClicks` auf `false`, um alle Verstöße gegen die Richtlinie zu entfernen. Wählen Sie vor der Bereitstellung eine von der Anwendung bereitgestellte Ersatz‑Seite.

Das Export‑Flag des Berichts verwendet eine konservative PDF‑Überprüfungsrichtlinie: Mouse‑Over‑Aktionen und alles außer einem externen Link oder einem spezifischen Folien‑Sprung werden als potenziell nicht unterstützt gekennzeichnet. Es ist ein Hinweis für die Prüfung, kein Funktionstest oder Garantie, dass nicht gekennzeichnete Links den Export überstehen. Unterstützte [PDF](/slides/de/net/convert-powerpoint-to-pdf/)‑ und [HTML](/slides/de/net/convert-powerpoint-to-html/)‑Exporte können Hyperlinks erhalten, abhängig von der Aktion, den Exportoptionen und dem Viewer. Raster‑[images](/slides/de/net/convert-powerpoint-to-png/) und [video](/slides/de/net/convert-powerpoint-to-video/) können keine interaktiven Hyperlinks bewahren; kennzeichnen Sie jede Aktion, wenn Sie für diese Ausgaben prüfen.

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

Mit dem oben erstellten Input enthält der Bericht fünf Aktions‑Zeilen. Der Dateimouse‑Over‑Link und der Makro‑Klick werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifikation gibt null verbotene Aktionen aus. Ein Input, der eine verbotene externe Klick‑URL enthält, nutzt ebenfalls den Ersetzungs‑Zweig. Ein Container mit einem erlaubten Klick und einem verbotenen Mouse‑Over behält seine Klick‑Aktion.

Diese selektive Bereinigung unterscheidet sich von [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), das beide Aktivierungstypen im gesamten ausgewählten Umfang unabhängig von der Richtlinie entfernt. Die Verifikation prüft hier nur Hyperlink‑Aktionen; sie entfernt keine eingebetteten VBA‑Projekte, OLE‑Objekte oder anderen aktiven Inhalt und validiert weder eine exportierte PDF‑ noch HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink richtet sich an eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einen Hyperlink an Master‑Folienelementen anbringen, damit er auf allen Folien funktioniert?**

Ja. Master‑Folien‑ und Layout‑Elemente unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Diashow auf Folien, die den entsprechenden Master oder das Layout verwenden, zur Verfügung.

**Werden Hyperlinks beim Exportieren nach PDF, HTML, Bildern oder Video beibehalten?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks beibehalten; Raster‑Bilder und Video können dies nicht. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).