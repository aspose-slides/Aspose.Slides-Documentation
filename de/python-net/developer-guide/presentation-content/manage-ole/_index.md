---
title: "Verwalten von OLE in Präsentationen mit Python"
linktitle: "OLE verwalten"
type: docs
weight: 40
url: /de/python-net/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & -Einbettung
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbetten
- verknüpftes Objekt
- verknüpfte Datei
- OLE ändern
- OLE-Symbol
- OLE-Titel
- OLE extrahieren
- Objekt extrahieren
- Datei extrahieren
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via .NET. Betten Sie OLE-Inhalte ein, aktualisieren Sie sie und exportieren Sie sie nahtlos."
---

## **Übersicht**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen zu verknüpfen oder einzubetten.

{{% /alert %}}

Ein Beispiel: Ein Diagramm, das in Microsoft Excel erstellt und auf einer PowerPoint‑Folie platziert wurde, ist ein OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. Durch Doppelklick auf das Symbol wird das Objekt in der zugehörigen Anwendung (z. B. Excel) geöffnet oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten auszuwählen.  
- Ein OLE‑Objekt kann seinen Inhalt anzeigen (z. B. ein Diagramm). In diesem Fall aktiviert PowerPoint das eingebettete Objekt, lädt die Diagrammschnittstelle und ermöglicht es Ihnen, die Diagrammdaten direkt in PowerPoint zu bearbeiten.

Aspose.Slides for Python ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE-Objekte zu Folien hinzufügen**

Wenn Sie bereits ein Diagramm in Microsoft Excel erstellt haben und es mithilfe von Aspose.Slides for Python als OLE‑Objekt‑Frame in eine Folie einbetten möchten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich eine Referenz zur Folie anhand ihres Index.
3. Lesen Sie die Excel‑Datei in ein Byte‑Array ein.
4. Fügen Sie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zur Folie hinzu und übergeben Sie das Byte‑Array sowie weitere OLE‑Objektdetails.
5. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) in eine Folie eingebettet.

**Hinweis:** Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) erwartet die Dateierweiterung des einbettbaren Objekts als zweiten Parameter. PowerPoint verwendet diese Erweiterung, um den Dateityp zu identifizieren und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Daten für das OLE-Objekt vorbereiten.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Ein OLE-Objekt-Frame zur Folie hinzufügen.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Verknüpfte OLE-Objekte hinzufügen**

Aspose.Slides for Python ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), das zu einer Datei verlinkt ist, anstatt deren Daten einzubetten.

Das folgende Python‑Beispiel zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Excel‑Datei auf einer Folie verknüpft wird:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ein OLE-Objekt-Frame mit einer verknüpften Excel-Datei hinzufügen.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf OLE-Objekte**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie wie folgt darauf zugreifen:

1. Laden Sie die Präsentation, die das eingebettete OLE‑Objekt enthält, indem Sie eine Instanz der Presentation‑Klasse erstellen.
2. Holen Sie sich eine Referenz zur Folie anhand ihres Index.
3. Greifen Sie auf die OleObjectFrame‑Form zu.
4. Sobald Sie das OLE‑Objekt‑Frame haben, führen Sie die gewünschten Vorgänge aus.

Das folgende Beispiel greift auf das OLE‑Objekt‑Frame – ein eingebettetes Excel‑Diagramm – zu und liest dessen Dateidaten aus. In diesem Beispiel wird eine PPTX‑Datei verwendet, die auf der ersten Folie ein einzelnes Shape enthält.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Eingebettete Dateidaten abrufen.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Dateierweiterung der eingebetteten Datei abrufen.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Eigenschaften verknüpfter OLE-Objekte abrufen**

Aspose.Slides ermöglicht das Abrufen der Eigenschaften eines verknüpften OLE‑Objekt‑Frames.

Das folgende Python‑Beispiel prüft, ob ein OLE‑Objekt verknüpft ist, und gibt – falls ja – den Pfad zur verknüpften Datei aus:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Prüfen, ob das OLE-Objekt verknüpft ist.
        if ole_frame.is_object_link:
            # Den vollständigen Pfad zur verknüpften Datei ausgeben.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Den relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
            # Nur .ppt-Präsentationen können einen relativen Pfad enthalten.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE-Objektdaten ändern**

{{% alert color="primary" %}}

In diesem Abschnitt verwendet das Code‑Beispiel [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie darauf zugreifen und die Daten wie folgt ändern:

1. Laden Sie die Präsentation, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse erstellen.
2. Holen Sie sich die Ziel‑Folien anhand ihres Index.
3. Greifen Sie auf das [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)-Shape zu.
4. Sobald Sie das OLE‑Objekt‑Frame haben, führen Sie die erforderlichen Vorgänge aus.
5. Erstellen Sie ein `Workbook`‑Objekt und lesen Sie die OLE‑Daten.
6. Öffnen Sie das gewünschte `Worksheet` und bearbeiten Sie die Daten.
7. Speichern Sie das aktualisierte `Workbook` in einen Stream.
8. Ersetzen Sie die OLE‑Objektdaten mit diesem Stream.

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um das Diagramm zu aktualisieren. Das Beispiel verwendet eine zuvor erstellte PPTX‑Datei, die auf der ersten Folie ein einzelnes Shape enthält.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # OLE-Objektdaten als Workbook-Objekt lesen.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Die Workbook-Daten ändern.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Die Daten des OLE-Frames ändern.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dateien in Folien einbetten**

Zusätzlich zu Excel‑Diagrammen ermöglicht Aspose.Slides for Python das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer ein eingefügtes Objekt doppelklickt, wird es automatisch in der zugehörigen Anwendung geöffnet bzw. der Benutzer wird aufgefordert, ein geeignetes Programm zu wählen.

Der folgende Python‑Code zeigt, wie HTML‑ und ZIP‑Dateien in eine Folie eingebettet werden:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen müssen Sie möglicherweise alte OLE‑Objekte durch neue ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes austauschen. Aspose.Slides for Python ermöglicht das Festlegen des Dateityps eines eingebetteten Objekts, sodass Sie die OLE‑Frame‑Daten oder dessen Dateierweiterung aktualisieren können.

Der folgende Python‑Code zeigt, wie der Dateityp des eingebetteten OLE‑Objekts auf `zip` gesetzt wird:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Dateityp auf ZIP ändern.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nachdem Sie ein OLE‑Objekt eingebettet haben, wird automatisch eine Symbol‑Vorschau hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen Text in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Python festlegen.

Der folgende Python‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt gesetzt werden:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Ein Bild zu den Präsentationsressourcen hinzufügen.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Einen Titel und das Bild für die OLE-Vorschau festlegen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhindern, dass OLE-Objekt-Frames in Größe und Position geändert werden**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Folie hinzugefügt haben, kann PowerPoint beim Öffnen der Präsentation auffordern, Links zu aktualisieren. Das Aktualisieren von Links kann die Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Vorschau mit Daten des verknüpften Objekts aktualisiert. Um zu verhindern, dass PowerPoint Sie auffordert, die Objektdaten zu aktualisieren, setzen Sie die `update_automatic`‑Eigenschaft der [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)-Klasse auf `False`:

```py
ole_frame.update_automatic = False
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides for Python ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, die die zu extrahierenden OLE‑Objekte enthält.
2. Durchlaufen Sie alle Shapes in der Präsentation und suchen Sie die OleObjectFrame‑Shapes.
3. Lesen Sie die eingebetteten Dateidaten jedes [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) aus und schreiben Sie sie auf die Festplatte.

Der folgende Python‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**  
Auf der Folie wird das Symbol bzw. das Ersatzbild (Vorschau) gerendert. Der „Live“-OLE‑Inhalt wird beim Rendern nicht ausgeführt. Falls nötig, setzen Sie ein eigenes Vorschaubild, um das erwartete Aussehen im exportierten PDF zu gewährleisten.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**  
Sperren Sie das Shape: Aspose.Slides bietet [Shape‑Ebene Sperren](/slides/de/python-net/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert aber effektiv versehentliche Bearbeitungen und Verschiebungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**  
PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die Praktiken aus der [Lösung für Tabellenblatt‑Größenanpassung](/slides/de/python-net/working-solution-for-worksheet-resizing/) befolgen – entweder den Frame an den Datenbereich anpassen oder den Datenbereich an einen festen Frame skalieren und ein geeignetes Ersatzbild setzen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten bleiben?**  
Im PPTX‑Format gibt es keine Information zu „relativen Pfaden“ – nur den vollständigen Pfad. Relative Pfade existieren nur im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten selbst bevorzugen.