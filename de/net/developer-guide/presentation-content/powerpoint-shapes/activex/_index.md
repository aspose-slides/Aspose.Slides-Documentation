---
title: ActiveX-Steuerelemente in Präsentationen in .NET verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/net/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX bearbeiten
- Media-Player
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "ActiveX-Textfelder und -Schaltflächen bearbeiten, Steuerelement-Vorschauen aktualisieren und ein Windows-Media-Player-Steuerelement in PowerPoint-Präsentationen mit Aspose.Slides für .NET wiederverwenden."
---
## **Einleitung**

ActiveX‑Steuerelemente geben einer PowerPoint‑Folie interaktive Elemente wie Textfelder, Schaltflächen und Media‑Player. Aspose.Slides für .NET stellt die Steuerelemente einer Folie über [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, es auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX‑Steuerelementen und deren gespeicherten Eigenschaften**

Um eine unbekannte Vorlage zu untersuchen, öffnen Sie sie zum Lesen und iterieren über die Steuerelemente jeder Folie. Das Beispiel gibt die Foliennummer, den Steuerelementnamen, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) und jedes Schlüssel‑Wert‑Paar in [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) aus. Es liest die Präsentation, ohne Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Die ausgewählte Ausgabe von `ActiveX.pptm` zeigt ein Textfeld und eine Schaltfläche.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaftensammlung erscheint als `[]`. Für Steuerelemente, die binäre Speicherung verwenden, kann `Properties` `null` zurückgeben, angezeigt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie nach dem Null‑Check [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/). Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX‑Steuerelemente bearbeiten**

Das Beispiel erwartet eine makroaktivierte Präsentation mit einem Textfeld namens `TextBox1` und einer Schaltfläche namens `CommandButton1` auf der ersten Folie. Es verwendet die [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/), um den Textfeldwert und die Beschriftung der Schaltfläche zu ändern. Jedes Steuerelement hat außerdem eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Erscheinungsbild zeigt. Das Beispiel weist diese Bilder über [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es dessen [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) ändert. Es speichert die bearbeitete Präsentation im PPTM‑Format und verwendet dann [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/), um eine zweite Kopie zu speichern, in der alle ActiveX‑Steuerelemente von dieser Folie entfernt sind.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Ein ActiveX‑Media‑Player‑Steuerelement hinzufügen**

Um ein konfiguriertes Windows‑Media‑Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einer Vorlage, deren erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, sodass Sie einen Pfad wählen sollten, auf den der Player während der Wiedergabe zugreifen kann.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kann Aspose.Slides ActiveX‑Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich ihrer Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten?**

ActiveX‑Steuerelemente ermöglichen es Benutzern, mit einer Folie zu interagieren, beispielsweise durch Eingabe von Text oder Klicken einer Schaltfläche. Ein [OLE‑Objekt](/slides/de/net/manage-ole/) lässt eine Folie Inhalte enthalten oder darauf verlinken, die von einer anderen Anwendung verwaltet werden, zum Beispiel ein Excel‑Arbeitsblatt.

**Werden ActiveX‑Ereignisse weiterhin VBA‑Makros auslösen, nachdem ich eine Präsentation mit Aspose.Slides gespeichert habe?**

Speichern Sie die Präsentation in einem makroaktivierten Format wie PPTM, um ihr VBA‑Projekt beizubehalten. PowerPoint für Windows kann die vorhandenen Ereignishandler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.