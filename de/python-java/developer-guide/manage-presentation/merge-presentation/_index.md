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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Python via Java zusammenführen, indem Sie Folien klonen, Master und Layouts steuern, Folieninhalte skalieren, Abschnitte beibehalten und geschützte oder große Dateien verarbeiten."
---
## **Übersicht**

Aspose.Slides for Python via Java fügt Präsentationen zusammen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) in eine andere geklont werden. Die Hauptoperation ist [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone), die entweder die Formatierung der Quellfolie erhalten oder die geklonte Folie an einen Master oder ein Layout in der Zielpräsentation anhängen kann.

Dieser Artikel behandelt die gängigsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei deren Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑Ende‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Aussehens von ihrem Layout und Master. Deshalb bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) auf eine der folgenden Arten:

- `addClone(source_slide)` — Behalte das Layout und die Formatierung der Quellfolie bei. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — Hänge die geklonte Folie an einen bestimmten Ziel-[MasterSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/). Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(source_slide, destination_layout)` — Hänge die geklonte Folie direkt an ein bestimmtes Ziel-[LayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/) an.

Der an eine `addClone`‑Überladung übergebene Master oder das Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quell‑Präsentation in die Ziel‑Präsentation. Dies ist die richtige Wahl, wenn die importierten Folien ihr ursprüngliches Thema, den Master und die Layout‑Beziehungen behalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Ziel‑Präsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quell‑Formatierung bewusst beibehalten wird.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Im folgenden Beispiel werden nur ausgewählte Folienindizes aus der Quell‑Präsentation importiert.

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

Verwenden Sie die [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Ziel‑Präsentation gehört.

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

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master, indem es den Layout‑Typ oder -Namen der Quell‑Folien vergleicht. Existiert kein geeignetes Layout und `allow_clone_missing_layout` ist `True`, wird das Quell‑Layout geklont, damit die Folie hinzugefügt werden kann. Ist es `False`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `False`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

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

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quell‑Folien nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die geerbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, jedoch gestaltet das Klonen einer Folie in eine Präsentation mit anderer Foliengröße deren Inhalt nicht automatisch für die neue Leinwand neu. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs liegen.

Ein praktikabler Ansatz ist, die Quell‑Präsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#setSize) kann vorhandene Inhalte skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/) skaliert Inhalte, um in die gewünschte Größe zu passen.

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

Das Ändern der Größe modifiziert das Quell‑Präsentations‑Objekt im Speicher. Wenn die ursprüngliche Quell‑Präsentation für andere Vorgänge unverändert bleiben muss, öffnen Sie für das Zusammenführen eine separate Instanz.

## **Folien in einen Präsentations‑Abschnitt zusammenführen**

Die grundlegende Klon‑Schleife erstellt die Abschnittshierarchie der Quell‑Präsentation nicht neu. Wenn Abschnitte in der Ausgabe wichtig sind, erstellen oder wählen Sie Abschnitte in der Ziel‑Präsentation und klonen Sie Folien explizit mit [SlideCollection.addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) in diese.

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

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, enumerieren Sie [Presentation.getSections](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSections), holen Sie die aktuellen Folien jedes Quell‑Abschnitts mit [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSlidesListOfSection), erstellen Sie die Abschnitte in der Ziel‑Präsentation neu und klonen Sie jede zurückgegebene Folie in den entsprechenden Ziel‑Abschnitt. Siehe [Manage Slide Sections](/slides/de/python-java/slide-section/) für ein vollständiges Beispiel zur Abschnitts‑Enumeration, inklusive leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑Ende‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur solange geöffnet, wie sie kopiert wird, und speichert die endgültige Datei am Schluss.

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

Dies ist ein nützliches Grundgerüst, um die Quell‑Formatierung importierter Folien zu erhalten. Wenn Ihre Ausgabe ein einheitliches Ziel‑Thema verwenden muss, ersetzen Sie den einfachen Aufruf `addClone(slide)` durch die zuvor gezeigte Ziel‑Master‑ oder Ziel‑Layout‑Überladung.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folienklonen kann einen benötigten Quell‑Master automatisch in die Ziel‑Präsentation bringen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein mehrfaches Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden nicht von diesem Register erfasst, vermeiden Sie also das Vor‑Klonen von Mastern, sofern Sie keine explizite Kontrolle über die Master‑Struktur benötigen.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell identisch sind. Wenn ein Corporate‑Template das endgültige Aussehen bestimmen muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit und prüfen Sie das Ergebnis nach dem Zusammenführen.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie mitkopiert. Aspose.Slides stellt zudem spezielle APIs für [presentation notes](/slides/de/python-java/presentation-notes/) und [presentation comments](/slides/de/python-java/presentation-comments/) bereit.

Falls das Format der Notizenseite wichtig ist, überprüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie zudem die Kommentar‑Autoren und verschachtelten Kommentare nach dem Kombinieren von Dateien unterschiedlicher Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst, anstatt nur ihre sichtbaren Formen zu kopieren, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Testen Sie die Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies ist jedoch keine generelle Garantie, dass identische binäre Ressourcen aus unverknüpften Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, inspizieren Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Wenn die Typografie auf verschiedenen Maschinen konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien sicherstellt, dass jede benötigte Schrift im Ziel‑Umfeld verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) prüfen und das Einbetten wie in [Embed Fonts in Presentations](/slides/de/python-java/embedded-font/) beschrieben explizit verwalten.

Stellen Sie außerdem sicher, dass Sie berechtigt sind, die in den Quell‑Dateien verwendeten Schriften einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort übergeben Sie über [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword).

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
    # Arbeiten Sie mit der entschlüsselten Präsentation.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Ziel‑Präsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binärobjekten können erheblichen Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](/slides/de/python-java/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien laden Sie nach Möglichkeit über Dateipfade, entsorgen jede Quell‑Präsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Checkpoints erfordert.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz nicht gleichzeitig aus mehreren Threads. Beschränken Sie jede Präsentations‑Instanz auf einen Merge‑Vorgang. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und folgen Sie der [Aspose.Slides multithreading guidance](/slides/de/python-java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quell‑Präsentation bei?**

Verwenden Sie [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Thema verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Ziel‑Präsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout nutzen soll. Verwenden Sie einen Master, wenn Aspose.Slides anhand des Layout‑Typs oder -Namens der Quelle unter den Layouts dieses Masters auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Ziel‑Abmessungen neu gestaltet. Skalieren Sie die Quell‑Präsentation zuerst, wenn Sie vorhersehbare Platzierungen benötigen, zum Beispiel mit [SlideSize.setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#setSize) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quell‑Präsentation, klonen Sie die benötigten Folien in eine Ziel‑Präsentation und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da die Präsentationsformate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Zusammenführungen. Siehe [Supported File Formats](/slides/de/python-java/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Erstellen Sie die erforderlichen Abschnitte in der Ziel‑Präsentation neu und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addClone), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen involvieren.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus jeder Quelle im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftbereitstellung. Prüfen Sie die eingebetteten Schriften der Ziel‑Präsentation und verwalten Sie das Einbetten oder die externe Verfügbarkeit von Schriften explizit, wenn Typografie wichtig ist.

**Wie klone ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword) und klonen Sie anschließend ihre Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie das BLOB‑Management, wenn große Binärobjekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quell‑Präsentationen umgehend und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation auf eigene Präsentations‑Instanzen beschränkt.