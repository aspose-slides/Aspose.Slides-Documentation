---
title: Präsentationen in .NET effizient zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/net/merge-presentation/
keywords:
- PowerPoint zusammenführen
- Präsentationen zusammenführen
- Folien zusammenführen
- PPT zusammenführen
- PPTX zusammenführen
- ODP zusammenführen
- PowerPoint kombinieren
- Präsentationen kombinieren
- Folien kombinieren
- PPT kombinieren
- PPTX kombinieren
- ODP kombinieren
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument‑Präsentationen in .NET durch das Klonen von Folien, die Steuerung von Mastern und Layouts, das Anpassen der Foliengröße, das Beibehalten von Abschnitten sowie den Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für .NET fügt Präsentationen zusammen, indem Folien von einer [Präsentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/), der die Formatierung der Quellfolie erhalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuweisen kann.

Dieser Artikel behandelt die gängigsten Zusammenführungs‑Workflows:

- alle Folien zusammenführen und dabei die Quellformatierung beibehalten;
- ausgewählte Folien zusammenführen;
- einen Master aus der Zielpräsentation anwenden;
- ein bestimmtes Layout aus der Zielpräsentation anwenden;
- unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- geklonte Folien zu einem Abschnitt hinzufügen;
- mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Erscheinungsbildes von ihrem Layout und Master. Deshalb bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) auf eine der folgenden Arten:

- `AddClone(sourceSlide)` — Erhält das Layout und die Formatierung der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — Weist die geklonte Folie einem bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/) zu. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `AddClone(sourceSlide, destinationLayout)` — Weist die geklonte Folie direkt einem bestimmten Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/) zu.

Der an eine `AddClone`‑Überladung übergebene Master oder Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quell‑Präsentation in die Ziel‑Präsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Design, Master und Layout‑Beziehungen behalten sollen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Ziel‑Präsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst erhalten bleibt.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quell‑Präsentation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die Überladung [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/), wenn importierte Folien einem Master folgen sollen, der bereits zur Ziel‑Präsentation gehört.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master, indem es den Typ oder Namen des Quell‑Layouts abgleicht. Existiert kein geeignetes Layout und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die Überladung [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/), wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es redesigniert den Inhalt der Quellfolie nicht. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die geerbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit verschiedenen Folienabmessungen können zusammengeführt werden, doch das Klonen einer Folie in eine Präsentation mit anderer Foliengröße redesigniert den Inhalt nicht automatisch für die neue Leinwand. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs liegen.

Ein praktischer Ansatz ist, die Quell‑Präsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.SetSize](https://reference.aspose.com/slides/de/net/aspose.slides/slidesize/setsize/) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/) skaliert den Inhalt, um in die gewünschte Größe zu passen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Das Skalieren ändert das Quell‑Präsentations‑Objekt im Speicher. Wenn die ursprüngliche Quell‑Präsentation für weitere Vorgänge unverändert bleiben muss, öffnen Sie eine separate Instanz für den Merge.

## **Folien in einen Präsentations‑Abschnitt einfügen**

Die grundlegende Folien‑Klon‑Schleife reproduziert die Abschnittshierarchie der Quell‑Präsentation nicht. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Ziel‑Präsentation und klonen Sie Folien explizit mit [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, erstellen Sie diese Abschnitte in der Ziel‑Präsentation und ordnen jeder Quell‑Folie den entsprechenden Ziel‑Abschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur geöffnet, solange sie kopiert wird, und speichert die endgültige Datei einmalig.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Dies ist ein nützliches Grundgerüst, um die Quellformatierung importierter Folien zu erhalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Design verwenden muss, ersetzen Sie den einfachen Aufruf `AddClone(slide)` durch die zuvor gezeigte Ziel‑Master‑ bzw. Ziel‑Layout‑Überladung.

## **Praktische Überlegungen**

### **Master, Layouts und Formatierungstreue**

Das Standard‑Klonen von Folien kann einen erforderlichen Quell‑Master automatisch in die Ziel‑Präsentation einbringen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein mehrfaches Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden von diesem Register nicht erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell identisch sind. Wenn ein Unternehmens‑Template das endgültige Erscheinungsbild bestimmen muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout ausdrücklich und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Redner‑Notizen und Folien‑Kommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie mitkopiert. Aspose.Slides stellt außerdem dedizierte APIs für [Präsentations‑Notizen](https://docs.aspose.com/slides/de/net/presentation-notes/) und [Präsentations‑Kommentare](https://docs.aspose.com/slides/de/net/presentation-comments/) bereit.

Wenn die Formatierung der Notizenseite wichtig ist, überprüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie zudem die Autoren der Kommentare und verschachtelte Kommentare nach dem Zusammenführen von Dateien unterschiedlicher Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst statt nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verlinkte Ressourcen sollten unterschiedlich behandelt werden. Ein verlinktes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt einen externen Link nicht in eingebetteten Inhalt. Testen Sie Pfade und URLs verlinkter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies ist jedoch keine generelle Garantie, dass identische Binär‑Ressourcen aus nicht verwandten Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplizierung zu verlassen.

### **Eingebettete Schriftarten und Schriftartenverfügbarkeit**

Schriftarten werden auf Präsentations‑Ebene verwaltet. Wenn Typografie über verschiedene Geräte hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede erforderliche Schriftart in der Zielumgebung verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getembeddedfonts/) inspizieren und das Einbetten explizit verwalten, wie in [Schriftarten in Präsentationen einbetten](https://docs.aspose.com/slides/de/net/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie die Berechtigung besitzen, die in den Quell‑Dateien verwendeten Schriftarten einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort wird über [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) übergeben.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Ziel‑Präsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/blobmanagementoptions/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Präsentations‑BLOBs verwalten](https://docs.aspose.com/slides/de/net/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien laden Sie nach Möglichkeit über Dateipfade, entsorgen Sie jede Quell‑Präsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Checkpoints.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentations‑Instanz auf einen Merge‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und beachten Sie die [Aspose.Slides‑Multithreading‑Richtlinien](https://docs.aspose.com/slides/de/net/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quell‑Präsentation bei?**

Verwenden Sie [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Zielfarbschema verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Ziel‑Präsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout nutzen soll. Verwenden Sie einen Master, wenn Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts ein geeignetes Layout des Masters auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, jedoch wird der Folieninhalt nicht automatisch für die Ziel‑Abmessungen redesigniert. Skalieren Sie zuerst die Quell‑Präsentation, wenn Sie eine vorhersehbare Positionierung benötigen, beispielsweise mit [SlideSize.SetSize](https://reference.aspose.com/slides/de/net/aspose.slides/slidesize/setsize/) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quell‑Präsentation, klonen Sie die benötigten Folien in ein Ziel und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da die Präsentationsformate nicht exakt denselben Funktionsumfang unterstützen, prüfen Sie komplexe Inhalte nach formatübergreifenden Merges. Siehe [Supported File Formats](https://docs.aspose.com/slides/de/net/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch beibehalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Replizieren Sie die erforderlichen Abschnitte in der Ziel‑Präsentation und verwenden Sie die Abschnitt‑Überladung von [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Redner‑Notizen und Kommentare beibehalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten berücksichtigen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien ebenfalls Präsentations‑ebene Strukturen umfassen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus jeder Quelle im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftauslieferung. Prüfen Sie die eingebetteten Schriftarten der Ziel‑Präsentation und verwalten Sie das Einbetten oder die Verfügbarkeit externer Schriftarten explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Verwenden Sie das BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade bei sehr großen Dateien, entsorgen Sie Quell‑Präsentationen umgehend und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation auf eigene Präsentations‑Instanzen beschränkt.