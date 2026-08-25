---
title: Effizientes Zusammenführen von Präsentationen mit Python
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Python durch Klonen von Folien, Steuerung von Mastern und Layouts, Größenanpassung von Folieninhalten, Erhaltung von Abschnitten und Umgang mit geschützten oder großen Dateien zusammenführen können."
---
## **Übersicht**

Aspose.Slides for Python via .NET fügt Präsentationen zusammen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/), der die Formatierung der Quellfolie beibehalten oder die geklonte Folie an einen Master oder ein Layout in der Zielpräsentation anhängen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei die Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Anforderungen behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen großen Teil ihres Erscheinungsbilds von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) auf eine der folgenden Arten:

- `add_clone(source_slide)` — die Layout‑ und Formatierung der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — die geklonte Folie an einem bestimmten Ziel-[IMasterSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/imasterslide/) anhängen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `add_clone(source_slide, destination_layout)` — die geklonte Folie direkt an einem bestimmten Ziel-[ILayoutSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/ilayoutslide/) anhängen.

Der an eine `add_clone`‑Überladung übergebene Master oder Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Der einfachste Merge kopiert jede Folie der Quellpräsentation in die Zielpräsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Design, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst erhalten bleibt.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quellpräsentation.

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

Verwenden Sie die [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides wählt ein geeignetes Layout unter dem angegebenen Master aus, indem es den Typ oder Namen des Quell‑Layouts vergleicht. Wenn kein passendes Layout existiert und `allow_clone_missing_layout` `True` ist, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `False`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxeditexception/) ausgelöst.

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

Die Anwendung eines Ziel‑Layouts ändert die ererbte Layout‑Beziehung; sie gestaltet den Inhalt der Quellfolie nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die vererbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit verschiedenen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet den Inhalt nicht automatisch für die neue Leinwand um. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktischer Ansatz ist, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.set_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/set_size/) kann bestehenden Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

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

Das Skalieren ändert das Quellpräsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für andere Vorgänge unverändert benötigen, öffnen Sie für den Merge eine separate Instanz.

## **Folien in einen Präsentations‑Abschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife reproduziert nicht die Abschnittshierarchie der Quellpräsentation. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation und klonen Sie Folien explizit mit [SlideCollection.add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) in diese.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, enumerieren Sie [Presentation.sections](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sections/), rufen Sie die aktuellen Folien jedes Quellabschnitts mit [Section.get_slides_list_of_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/get_slides_list_of_section/) ab, erstellen Sie die Abschnitte in der Zielpräsentation neu und klonen Sie jede zurückgegebene Folie in den entsprechenden Ziel‑Abschnitt. Siehe [Manage Slide Sections](/slides/de/python-net/slide-section/) für ein vollständiges Beispiel zur Abschnitts‑Enumeration, inklusive leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur so lange geöffnet, wie sie kopiert wird, und speichert die endgültige Datei anschließend.

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

Dies ist ein nützliches Grundgerüst, um die Quellformatierung importierter Folien zu bewahren. Wenn Ihre Ausgabe ein einheitliches Ziel‑Design verwenden muss, ersetzen Sie den einfachen Aufruf `add_clone(slide)` durch die zuvor gezeigte Überladung mit Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Format‑Treue**

Das Standard‑Klonen von Folien kann einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu vermeiden, dass derselbe Master mehrfach geklont wird. Manuell geklonte Master werden nicht von diesem Register erfasst, vermeiden Sie also das Vor‑Klonen von Mastern, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell identisch sind. Wenn ein Unternehmens‑Template das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie übernommen. Aspose.Slides bietet zudem dedizierte APIs für [presentation notes](/slides/de/python-net/presentation-notes/) und [presentation comments](/slides/de/python-net/presentation-comments/).

Ist die Formatierung der Notizenseite wichtig, überprüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie zudem Autor‑Informationen und verschachtelte Kommentare nach dem Kombinieren von Dateien verschiedener Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst statt nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen zu den Ressourcen beibehalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpfter Audio‑, Video‑, OLE‑Objekt‑ oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt einen externen Link nicht in eingebetteten Inhalt. Testen Sie verknüpfte Pfade und URLs in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, aber das ist keine generelle Garantie, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, inspizieren Sie das zusammengeführte Package und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriftarten und Schriftarten‑Verfügbarkeit**

Schriftarten werden auf Präsentations‑Ebene verwaltet. Wenn Typografie über verschiedene Geräte hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schriftart in der Zielumgebung verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/python-net/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie das Recht haben, die in den Quell‑Dateien verwendeten Schriftarten einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort übergeben Sie über [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können erhebliche Speichermengen beanspruchen. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/blob_management_options/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](/slides/de/python-net/manage-blob/) für Strategien bei großen Dateien.

Für große Dateien bevorzugen Sie das Laden über Dateipfade, schließen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Checkpoints erfordert. Die Verwendung von `with slides.Presentation(...)` stellt sicher, dass Präsentations‑Ressourcen beim Verlassen des Kontextes freigegeben werden.

### **Thread‑Sicherheit**

Laden, speichern oder klonen Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz nicht gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation ein‑threadig. Wenn Sie unabhängige Merge‑Jobs parallelisieren, verwenden Sie separate ein‑threadige Prozesse und unabhängige Präsentations‑Instanzen, wie in der [Aspose.Slides multithreading guidance](/slides/de/python-net/multithreading/) beschrieben.

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout verwenden soll. Verwenden Sie einen Master, wenn Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts unter diesem Master das passende Layout auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Zielabmessungen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, etwa mit [SlideSize.set_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/set_size/) und [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die benötigten Folien in eine Zielpräsentation und speichern Sie die Zieldatei in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Merges. Siehe [Supported File Formats](/slides/de/python-net/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Erstellen Sie die erforderlichen Abschnitte in der Zielpräsentation und nutzen Sie die Abschnitt‑Überladung von [add_clone](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_clone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare übernommen?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen berühren.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass ihre Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus jeder Quelle in der zusammengeführten Präsentation garantiert verfügbar?**

Verlassen Sie sich nicht allein auf das Folienklonen für die Schriftart‑Bereitstellung. Prüfen Sie die eingebetteten Schriftarten der Zieldatei und verwalten Sie das Einbetten oder die externe Verfügbarkeit von Schriftarten explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem richtigen [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Verwenden Sie BLOB‑Management, wenn große Binär‑Objekte den Speicher belasten, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, schließen Sie Quellpräsentationen zügig und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Laden, speichern oder klonen Sie [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanzen nicht in mehreren Threads gleichzeitig. Halten Sie jede Merge‑Operation ein‑threadig; verwenden Sie unabhängige ein‑threadige Prozesse, wenn Sie separate Merge‑Jobs parallelisieren.