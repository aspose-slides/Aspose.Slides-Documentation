---
title: Effizientes Zusammenführen von Präsentationen in Python via Java
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/python-java/merge-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Python via Java durch das Klonen von Folien, die Steuerung von Mastern und Layouts, das Ändern der Foliengröße, das Beibehalten von Abschnitten und den Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für Python über Java fügt Präsentationen zusammen, indem Folien von einer [Präsentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone), der die Formatierung der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zieldatei zuordnen kann.

Dieser Artikel behandelt die häufigsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei deren Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zieldatei anwenden;
- Ein bestimmtes Layout aus der Zieldatei anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte verarbeiten.

## **Wie die Folienklonung Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Aussehens von ihrem Layout und Master. Aus diesem Grund bestimmt die gewählte Klon‑Überladung, wie die zusammengeführte Folie in die Zieldatei integriert wird.

Verwenden Sie [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) auf eine der folgenden Arten:

- `addClone(source_slide)` — die Layout‑ und Formatierung der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zieldatei geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — die geklonte Folie an ein bestimmtes Ziel‑[MasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/). Aspose.Slides sucht unter diesem Master nach einem passenden Layout, anhand des Layout‑Typs oder Namens.
- `addClone(source_slide, destination_layout)` — die geklonte Folie direkt an ein bestimmtes Ziel‑[LayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/) zuweisen.

Der dem `addClone`‑Aufruf übergebene Master oder das Layout muss zur **Zieldatei**, nicht zur Quelldatei gehören.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quellpräsentation in die Zieldatei. Diese Vorgehensweise ist geeignet, wenn die importierten Folien ihr ursprüngliches Design, ihren Master und ihre Layout‑Beziehungen behalten sollen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zieldatei unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst beibehalten wird.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folien‑Indizes aus der Quellpräsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Zieldatei gehört.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master aus, indem es den Layout‑Typ oder -Namen der Quellfolie abgleicht. Existiert kein geeignetes Layout und `allow_clone_missing_layout` ist `True`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `False`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `False`, wenn die Zusammenführung fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone)‑Überladung, wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Das Anwenden eines Ziel‑Layouts ändert die vererbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die vererbte Formatierung und das Platzhalter‑Verhalten passen.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit verschiedenen Folienabmessungen können zusammengeführt werden, jedoch gestaltet das Klonen einer Folie in eine Präsentation mit anderer Foliengröße deren Inhalt nicht automatisch für die neue Leinwand um. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs liegen.

Ein praktikabler Ansatz ist, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#setSize) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Das Skalieren ändert das Quellpräsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für andere Vorgänge unverändert benötigen, öffnen Sie für das Zusammenführen eine separate Instanz.

## **Folien in einen Abschnitt einer Präsentation einfügen**

Die grundlegende Schleife zum Klonen von Folien recreiert nicht die Abschnittshierarchie der Quellpräsentation. Wenn Abschnitte im Ergebnis von Bedeutung sind, erstellen oder wählen Sie Abschnitte in der Zieldatei aus und klonen Sie Folien explizit mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) in diese.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, enumerieren Sie [Presentation.getSections](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSections), rufen Sie die aktuellen Folien jedes Quellabschnitts mit [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSlidesListOfSection) ab, erstellen Sie die Abschnitte in der Zieldatei neu und klonen Sie jede zurückgegebene Folie in den entsprechenden Zielabschnitt. Siehe [Manage Slide Sections](/slides/de/python-java/slide-section/) für ein vollständiges Beispiel zur Abschnitts‑Enumeration, einschließlich leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur solange geöffnet, wie sie kopiert wird, und speichert die Datei am Ende.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

Dies ist eine nützliche Basis, um die Quellformatierung importierter Folien zu bewahren. Wenn Ihr Ergebnis ein einheitliches Ziel‑Theme verwenden soll, ersetzen Sie den einfachen Aufruf `addClone(slide)` durch die zuvor gezeigte Ziel‑Master‑ oder Ziel‑Layout‑Überladung.

## **Praktische Überlegungen**

### **Master, Layouts und Formatierungstreue**

Das Standard‑Klonen von Folien kann den benötigten Quell‑Master automatisch in die Zieldatei übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein wiederholtes Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden von diesem Register nicht erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell identisch sind. Wenn eine Unternehmensvorlage das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout ausdrücklich und überprüfen Sie das Ergebnis nach dem Zusammenführen.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folien‑Kommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie mitkopiert. Aspose.Slides stellt zudem dedizierte APIs für [presentation notes](/slides/de/python-java/presentation-notes/) und [presentation comments](/slides/de/python-java/presentation-comments/) bereit.

Ist das Format der Notizenseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows sollten Sie zudem die Autoren der Kommentare und Thread‑Kommentare überprüfen, nachdem Dateien von verschiedenen Autoren oder Vorlagen kombiniert wurden.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten referenzieren. Klonen Sie die gesamte Folie und nicht nur die sichtbaren Shapes, damit Aspose.Slides die Beziehungen zu den Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sind unterschiedlich zu behandeln. Ein verknüpftes Audio‑, Video‑, OLE‑Objekt‑ oder Hyperlink bleibt abhängig von seinem externen Ziel; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Testen Sie Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies sollte jedoch nicht als generelle Garantie angesehen werden, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, inspizieren Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Wenn die Typografie auf verschiedenen Rechnern konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede erforderliche Schrift im Ziel verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/python-java/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie die Berechtigung besitzen, die in den Quell‑Dateien verwendeten Schriften einzubetten. Schrift‑Lizenzen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor deren Folien geklont werden können. Das Passwort übergeben Sie mittels [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # Arbeiten mit der entschlüsselten Präsentation.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Zieldatei an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können viel Speicher belegen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](/slides/de/python-java/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien bevorzugen Sie das Laden über Dateipfade, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Checkpoints erfordert.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Instanz nicht gleichzeitig aus mehreren Threads. Halten Sie jede Präsentationsinstanz auf einen Zusammenführungs‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und folgen Sie den [Aspose.Slides Multithreading‑Richtlinien](/slides/de/python-java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master bei Bedarf automatisch klonen.

**Wie lasse ich importierte Folien das Zieldesign verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zieldatei, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie exakt dasselbe Layout verwenden soll. Verwenden Sie einen Master, wenn Aspose.Slides basierend auf dem Layout‑Typ oder -Namen der Quellfolie automatisch ein passendes Layout auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, jedoch wird der Folieninhalt nicht automatisch für die Zielabmessungen neu gestaltet. Skalieren Sie die Quellpräsentation vorher, etwa mit [SlideSize.setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#setSize) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen in einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die gewünschten Folien in eine Zieldatei und speichern Sie das Ergebnis in einem unterstützten Ausgabe‑Format. Da die Formate nicht exakt dieselben Funktionsumfänge bieten, prüfen Sie komplexe Inhalte nach Format‑übergreifenden Zusammenführungen. Siehe [Supported File Formats](/slides/de/python-java/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Erstellen Sie die erforderlichen Abschnitte in der Zieldatei neu und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare übernommen?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen involvieren.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Zusammenführen weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aller Quellen im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht allein auf das Folien‑Klonen für die Schrift‑Bereitstellung. Prüfen Sie die eingebetteten Schriften im Ziel und verwalten Sie das Einbetten bzw. die externe Verfügbarkeit von Schriften explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen zeitnah und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Zusammenführungs‑Operation auf eigene Präsentations‑Instanzen beschränkt.