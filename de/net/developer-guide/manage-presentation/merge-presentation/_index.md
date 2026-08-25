---
title: Effizientes Zusammenführen von Präsentationen in .NET
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in .NET durch Klonen von Folien, Steuerung von Mastern und Layouts, Anpassen der Foliengröße, Erhalt von Abschnitten und den Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für .NET fügt Präsentationen zusammen, indem es Folien von einer [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) in eine andere klont. Die Hauptoperation ist [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/), die die Formatierung der Quellfolie beibehalten oder die geklonte Folie an einen Master oder ein Layout in der Zielpräsentation anhängen kann.

Dieser Artikel behandelt die gängigsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei ihre Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑to‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie übernimmt einen Großteil ihres Erscheinungsbildes von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection.AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) auf eine der folgenden Arten:

- `AddClone(sourceSlide)` — Beibehaltung des Layouts und der Formatierung der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — Anhängen der geklonten Folie an einen bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslide/). Aspose.Slides sucht nach einem passenden Layout unter diesem Master anhand des Layout‑Typs oder Namens.
- `AddClone(sourceSlide, destinationLayout)` — Direktes Anhängen der geklonten Folie an ein bestimmtes Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/ilayoutslide/).

Der Master oder das Layout, das an eine `AddClone`‑Überladung übergeben wird, muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie aus der Quellpräsentation in die Zielpräsentation. Dies ist die richtige Wahl, wenn die importierten Folien ihr ursprüngliches Theme, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quelle und Ziel unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung absichtlich beibehalten wird.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quellpräsentation.

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

Verwenden Sie die [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

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

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master aus, indem es den Typ oder Namen des Quell‑Layouts abgleicht. Wenn kein geeignetes Layout existiert und `allowCloneMissingLayout` **true** ist, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es **false**, wird eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie **false**, wenn die Zusammenführung fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/)‑Überladung, wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

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

Das Anwenden eines Ziel‑Layouts ändert die vererbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Wenn Quell‑ und Ziel‑Layouts unterschiedliche Platzhalterstrukturen besitzen, prüfen Sie das Ergebnis, um sicherzustellen, dass die vererbte Formatierung und das Platzhalterverhalten angemessen sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet den Inhalt nicht automatisch für die neue Leinwand um. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs liegen.

Ein praktischer Ansatz besteht darin, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.SetSize](https://reference.aspose.com/slides/de/net/aspose.slides/slidesize/setsize/) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/) skaliert den Inhalt, um in die angeforderte Größe zu passen.

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

Die Größenänderung verändert das Quellpräsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für andere Vorgänge unverändert benötigen, öffnen Sie für die Zusammenführung eine separate Instanz.

## **Folien in einen Präsentationsabschnitt zusammenführen**

Die grundlegende Schleife zum Klonen von Folien stellt die Abschnittshierarchie der Quellpräsentation nicht wieder her. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation und klonen Sie Folien explizit mit [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/).

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

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, enumerieren Sie [Presentation.Sections](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sections/), rufen Sie die aktuellen Folien jedes Quellabschnitts mit [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/de/net/aspose.slides/isection/getslideslistofsection/) ab, erzeugen Sie die Abschnitte im Ziel neu und klonen Sie jede zurückgegebene Folie in den entsprechenden Zielabschnitt. Siehe [Manage Slide Sections](/slides/de/net/slide-section/) für ein vollständiges Beispiel zur Abschnitt‑Enumeration, einschließlich leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑to‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur geöffnet, solange sie kopiert wird, und speichert die endgültige Datei einmal.

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

Dies ist ein nützliches Grundgerüst, um die Quellformatierung importierter Folien zu erhalten. Wenn Ihr Ergebnis ein einzelnes Ziel‑Theme verwenden muss, ersetzen Sie den einfachen Aufruf `AddClone(slide)` durch die zuvor gezeigte Überladung für Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folienklonen kann automatisch einen erforderlichen Quell‑Master in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein wiederholtes Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden von diesem Register nicht erfasst; klonen Sie also Master nicht vorher, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell äquivalent sind. Wenn ein Corporate‑Template das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Layout ausdrücklich und prüfen Sie das Ergebnis nach dem Zusammenführen.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie mitkopiert. Aspose.Slides stellt zudem dedizierte APIs für [presentation notes](/slides/de/net/presentation-notes/) und [presentation comments](/slides/de/net/presentation-comments/) bereit.

Ist die Formatierung der Notizenseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie zudem Autoren und Thread‑Kommentare nach dem Kombinieren von Dateien verschiedener Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst statt nur ihrer sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen beibehalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt einen externen Link nicht in eingebetteten Inhalt. Testen Sie Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, das sollte jedoch nicht als generelle Garantie verstanden werden, dass identische binäre Ressourcen aus unabhängigen Quellpräsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis statt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Wenn die Typografie auf verschiedenen Maschinen konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schrift im Zielsystem verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getembeddedfonts/) inspizieren und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/net/embedded-font/) beschrieben.

Prüfen Sie außerdem, ob Sie die Lizenz besitzen, die in den Quell‑Dateien verwendeten Schriften einzubetten. Schriftlizenzen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort wird über [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) übergeben.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binärobjekten können erheblichen Speicher beanspruchen. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/blobmanagementoptions/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](/slides/de/net/manage-blob/) für Strategien zum Umgang mit großen Dateien.

Bei großen Dateien laden Sie vorzugsweise über Dateipfade, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Checkpoints erfordert.

### **Thread‑Sicherheit**

Laden, modifizieren, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentations‑Instanz auf einen Zusammenführungs‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und folgen Sie den [Aspose.Slides Multithreading‑Richtlinien](/slides/de/net/multithreading/).

## **FAQ**

**Wie halte ich das ursprüngliche Design jeder Quellpräsentation bei?**  
Verwenden Sie [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**  
Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folien zu einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**  
Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout verwenden soll. Verwenden Sie einen Master, wenn Sie Aspose.Slides die Auswahl unter den Layouts dieses Masters anhand des Quell‑Layout‑Typs oder Namens überlassen möchten.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**  
Ja, aber der Folieninhalt wird nicht automatisch für die Zielabmessungen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, zum Beispiel mit [SlideSize.SetSize](https://reference.aspose.com/slides/de/net/aspose.slides/slidesize/setsize/) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/net/aspose.slides/slidesizescaletype/).

**Kann ich PPT-, PPTX‑ und ODP‑Präsentationen in einer Datei zusammenführen?**  
Ja. Laden Sie jede Quellpräsentation, klonen Sie die benötigten Folien in eine Zielpräsentation und speichern Sie das Ergebnis in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Zusammenführungen. Siehe [Supported File Formats](/slides/de/net/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**  
Nicht durch eine einfache Schleife, die nur Folien klont. Erstellen Sie die erforderlichen Abschnitte im Ziel und verwenden Sie die Abschnitt‑Überladung von [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare übernommen?**  
Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder Thread‑Review‑Daten betreffen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien Präsentations‑ und nicht nur Folien‑Strukturen betreffen.

**Was geschieht mit Audio, Video, OLE‑Objekten und Hyperlinks?**  
Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass ihre Ziel‑Dateien oder URLs nach dem Zusammenführen weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus allen Quellen im zusammengeführten Dokument garantiert verfügbar?**  
Verlassen Sie sich nicht allein auf das Klonen von Folien für die Schriftbereitstellung. Prüfen Sie die eingebetteten Schriften im Ziel und verwalten Sie das Einbetten oder die Verfügbarkeit externer Schriften explizit, wenn Typografie wichtig ist.

**Wie führe ich eine passwortgeschützte Datei zusammen?**  
Öffnen Sie sie mit dem korrekten [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/), klonen Sie dann ihre Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**  
Nutzen Sie BLOB‑Verwaltung, wenn große Binärobjekte den Speicher stark belasten, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen sofort nach dem Kopieren und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**  
Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Zusammenführungs‑Operation in eigenen Präsentations‑Instanzen isoliert.