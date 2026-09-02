---
title: Effizient Präsentationen mit Python zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/python-net/merge-presentation/
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
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Python durch Klonen von Folien, Steuern von Mastern und Layouts, Ändern der Foliengröße, Beibehalten von Abschnitten und Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für Python über .NET kombiniert Präsentationen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) in eine andere geklont werden. Die Hauptoperation ist [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/), die das Format der Quellfolie erhalten oder die geklonte Folie einem Master oder Layout in der Zieldatei zuordnen kann.

Dieser Artikel beschreibt die gängigsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei das Quellformat beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zieldatei anwenden;
- Ein bestimmtes Layout aus der Zieldatei anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie übernimmt einen Großteil ihres Erscheinungsbilds von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Klon‑Überladung, wie die zusammengeführte Folie in die Zieldatei integriert wird.

Verwenden Sie [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) auf eine der folgenden Arten:

- `add_clone(source_slide)` — das Layout und die Formatierung der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zieldatei geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, nicht jedes Mal einen neuen Master klonen.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — die geklonte Folie an einen bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/) anhängen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `add_clone(source_slide, destination_layout)` — die geklonte Folie direkt an ein bestimmtes Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/ilayoutslide/) anhängen.

Der an eine `add_clone`‑Überladung übergebene Master oder Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Der einfachste Merge kopiert jede Folie der Quell‑Präsentation in die Ziel‑Präsentation. Dies ist die passende Wahl, wenn die importierten Folien ihr ursprüngliches Theme, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quelle und Ziel unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst beibehalten wird.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quell‑Präsentation.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Ziel‑Präsentation gehört.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides wählt unter dem angegebenen Master ein passendes Layout aus, das dem Typ oder Namen des Quell‑Layouts entspricht. Existiert kein geeignetes Layout und ist `allow_clone_missing_layout` `True`, wird das Quell‑Layout geklont, damit die Folie hinzugefügt werden kann. Ist es `False`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `False`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/)‑Überladung, wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass das vererbte Format und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet deren Inhalt nicht automatisch für die neue Leinwand neu. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs liegen.

Ein praktischer Ansatz besteht darin, die Quell‑Präsentation vor dem Klonen zu skalieren. Die [SlideSize.set_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/set_size/)‑Methode kann vorhandene Inhalte skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesizescaletype/) skaliert Inhalte, damit sie in die gewünschte Größe passen.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Das Ändern der Größe verändert das Quell‑Präsentationsobjekt im Speicher. Wenn Sie die ursprüngliche Quell‑Präsentation für andere Vorgänge unverändert benötigen, öffnen Sie eine separate Instanz für den Merge.

## **Folien in einen Präsentationsabschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife reproduziert nicht die Abschnittshierarchie der Quell‑Präsentation. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Ziel‑Präsentation und klonen Sie Folien explizit mit [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) in diese.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, reproduzieren Sie diese im Ziel mit [SectionCollection.append_empty_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/append_empty_section/) und ordnen Sie jede Quell‑Folie dem entsprechenden Ziel‑Abschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur geöffnet, solange sie kopiert wird, und speichert die endgültige Datei ein einziges Mal.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Dies ist ein nützlicher Ausgangspunkt, um die Quellformatierung importierter Folien beizubehalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Theme nutzen muss, ersetzen Sie den einfachen Aufruf `add_clone(slide)` durch die zuvor gezeigte Überladung für Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folienklon kann erforderliche Quell‑Master automatisch in die Ziel‑Präsentation bringen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu vermeiden, dass derselbe Master mehrfach geklont wird. Manuell geklonte Master werden von diesem Register nicht erfasst, vermeiden Sie also das Vor‑Klonen von Master, sofern Sie nicht explizit die Master‑Struktur steuern müssen.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell äquivalent sind. Müssen Corporate‑Templates das endgültige Aussehen kontrollieren, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folien‑Kommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie kopiert. Aspose.Slides stellt zudem dedizierte APIs für [presentation notes](https://docs.aspose.com/slides/de/python-net/presentation-notes/) und [presentation comments](https://docs.aspose.com/slides/de/python-net/presentation-comments/) bereit.

Ist die Formatierung der Notizenseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notiz‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie außerdem die Kommentar‑Autor*innen und verschachtelten Kommentare nach dem Zusammenführen von Dateien verschiedener Autor*innen oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten referenzieren. Klonen Sie die Folie selbst statt nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Testen Sie Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt explizit automatisch geklonte Master, dies sollte jedoch nicht als generelle Garantie verstanden werden, dass identische Binär‑Ressourcen aus unabhängigen Quell‑Präsentationen immer dedupliziert werden. Ist die Dateigröße wichtig, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Müssen typografische Vorgaben über verschiedene Maschinen hinweg konsistent bleiben, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schrift im Ziel‑Umfeld verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) inspizieren und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](https://docs.aspose.com/slides/de/python-net/embedded-font/) beschrieben.

Prüfen Sie zudem, ob Sie die Lizenz für das Einbetten der in den Quell‑Dateien verwendeten Schriften besitzen. Schrift‑Lizenzen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor deren Folien geklont werden können. Das Passwort geben Sie über [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/) an.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Ziel‑Präsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/blob_management_options/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Manage Presentation BLOBs](https://docs.aspose.com/slides/de/python-net/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien bevorzugen Sie das Laden über Dateipfade, schließen Sie jede Quell‑Präsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Checkpoints erfordert. Die Verwendung von `with slides.Presentation(...)` stellt sicher, dass Präsentations‑Ressourcen beim Verlassen des Kontextes freigegeben werden.

### **Thread‑Sicherheit**

Laden, speichern oder klonen Sie keine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation ein‑threadig. Wenn Sie unabhängige Merge‑Jobs parallelisieren, nutzen Sie separate ein‑threadige Prozesse und unabhängige Präsentations‑Instanzen, wie in der [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/de/python-net/multithreading/) beschrieben.

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [`add_clone(source_slide)`](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den erforderlichen Quell‑Master automatisch klonen, wenn die importierte Folie ihn benötigt.

**Wie lässt sich erreichen, dass importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Ziel‑Präsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein spezifisches Layout, wenn jede importierte Folie ein bekanntes Layout nutzen soll. Nutzen Sie einen Master, wenn Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts zwischen den Layouts dieses Masters auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Ziel‑Abmessungen neu gestaltet. Skalieren Sie die Quell‑Präsentation zuerst, wenn Sie vorhersehbare Positionen benötigen, zum Beispiel mit [SlideSize.set_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/set_size/) und [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP‑Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quell‑Präsentation, klonen Sie die benötigten Folien in eine Ziel‑Präsentation und speichern Sie das Ergebnis in einem unterstützten Ausgabeformat. Da die Formate nicht exakt die gleichen Funktionen bieten, prüfen Sie komplexe Inhalte nach plattformübergreifenden Zusammenführungen. Siehe [Supported File Formats](https://docs.aspose.com/slides/de/python-net/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Reproduzieren Sie die erforderlichen Abschnitte im Ziel und nutzen Sie die Abschnitt‑Überladung von [add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die von der Stilistik des Notiz‑Masters, den Kommentar‑Autor*innen oder verschachtelten Review‑Daten abhängen, prüfen Sie das Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Ebenen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus allen Quellen im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftbereitstellung. Inspizieren Sie die eingebetteten Schriften im Ziel und verwalten Sie das Einbetten bzw. die Verfügbarkeit externer Schriften explizit, wenn Typografie wichtig ist.

**Wie füge ich eine passwortgeschützte Datei zusammen?**

Öffnen Sie sie mit dem korrekten [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Setzen Sie BLOB‑Management ein, wenn große Binär‑Objekte den Speicher stark beanspruchen, laden Sie große Dateien bevorzugt über Dateipfade, schließen Sie Quell‑Präsentationen sofort nach dem Merge und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Laden, speichern oder klonen Sie keine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanzen gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation ein‑threadig; nutzen Sie unabhängige ein‑threadige Prozesse, wenn Sie separate Merge‑Jobs parallelisieren müssen.