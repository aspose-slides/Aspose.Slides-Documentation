---
title: OLE in Präsentationen mit Python verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/python-net/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & Einbettung
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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via .NET. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---

## **Übersicht**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** ist eine Microsoft‑Technologie, die es ermöglicht, Daten und in einer Anwendung erstellte Objekte in einer anderen zu verknüpfen oder einzubetten.

{{% /alert %}}

Zum Beispiel ist ein in Microsoft Excel erstelltes Diagramm, das auf einer PowerPoint‑Folie platziert wird, ein OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. Durch Doppelklicken auf das Symbol wird das Objekt in der zugehörigen Anwendung (z. B. Excel) geöffnet oder es wird aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten auszuwählen.
- Ein OLE‑Objekt kann seinen Inhalt anzeigen (z. B. ein Diagramm). In diesem Fall aktiviert PowerPoint das eingebettete Objekt, lädt die Diagrammschnittstelle und ermöglicht das Bearbeiten der Diagrammdaten direkt in PowerPoint.

Aspose.Slides for Python ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑Objekte zu Folien hinzufügen**

Wenn Sie bereits ein Diagramm in Microsoft Excel erstellt haben und es mithilfe von Aspose.Slides for Python als OLE‑Objekt‑Frame in einer Folie einbetten möchten, gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
1. Lesen Sie die Excel‑Datei in ein Byte‑Array ein.
1. Fügen Sie der Folie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzu und übergeben Sie das Byte‑Array sowie weitere OLE‑Objektdetails.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel wird ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) in einer Folie eingebettet.

**Hinweis:** Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) erwartet als zweiten Parameter die Dateierweiterung des einzubettenden Objekts. PowerPoint verwendet diese Erweiterung, um den Dateityp zu bestimmen und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.
```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Daten für das OLE-Objekt vorbereiten.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # OLE-Objekt-Frame zur Folie hinzufügen.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **Verknüpfte OLE‑Objekte hinzufügen**

Mit Aspose.Slides for Python können Sie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzufügen, das auf eine Datei verweist, anstatt deren Daten einzubetten.

Das folgende Python‑Beispiel zeigt, wie ein auf eine Excel‑Datei verknüpftes [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) auf einer Folie hinzugefügt wird:
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # OLE-Objekt-Frame mit verknüpfter Excel-Datei hinzufügen.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Zugriff auf OLE‑Objekte**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie wie folgt darauf zugreifen:

1. Laden Sie die Präsentation, die das eingebettete OLE‑Objekt enthält, indem Sie eine Instanz der Klasse Presentation erstellen.
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
1. Greifen Sie auf die OleObjectFrame‑Form zu.
1. Sobald Sie den OLE‑Objekt‑Frame haben, führen Sie die gewünschten Operationen darauf aus.

Im nachstehenden Beispiel wird auf den OLE‑Objekt‑Frame – ein eingebettetes Excel‑Diagramm – zugegriffen und dessen Dateidaten werden abgerufen. In diesem Beispiel verwenden wir ein PPTX mit einer einzigen Form auf der ersten Folie.
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Eingebettete Dateidaten abrufen.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Erweiterung der eingebetteten Datei abrufen.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```


### **Eigenschaften verknüpfter OLE‑Objekte abrufen**

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften eines verknüpften OLE‑Objekt‑Frames.

Das folgende Python‑Beispiel prüft, ob ein OLE‑Objekt verknüpft ist, und ermittelt, falls ja, den Pfad zur verknüpften Datei:
```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Prüfen, ob das OLE-Objekt verknüpft ist.
        if ole_frame.is_object_link:
            # Vollständigen Pfad zur verknüpften Datei ausgeben.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
            # Nur .ppt-Präsentationen können einen relativen Pfad enthalten.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```


## **OLE‑Objektdaten ändern**

{{% alert color="primary" %}}

Im folgenden Abschnitt verwendet das Code‑Beispiel [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie wie folgt darauf zugreifen und seine Daten ändern:

1. Laden Sie die Präsentation, indem Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) erstellen.
1. Holen Sie die Ziel‑Folie anhand ihres Index.
1. Greifen Sie auf die Form [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu.
1. Sobald Sie den OLE‑Objekt‑Frame haben, führen Sie die gewünschten Operationen darauf aus.
1. Erzeugen Sie ein `Workbook`‑Objekt und lesen Sie die OLE‑Daten.
1. Öffnen Sie das gewünschte `Worksheet` und editieren Sie die Daten.
1. Speichern Sie das aktualisierte `Workbook` in einen Stream.
1. Ersetzen Sie die OLE‑Objektdaten mithilfe dieses Streams.

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein eingebettetes Excel‑Diagramm) aufgerufen und dessen Dateidaten werden geändert, um das Diagramm zu aktualisieren. Das Beispiel verwendet ein zuvor erstelltes PPTX mit einer einzigen Form auf der ersten Folie.
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
            # Workbook-Daten ändern.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE-Frame-Objektdaten ändern.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Dateien in Folien einbetten**

Zusätzlich zu Excel‑Diagrammen ermöglicht Aspose.Slides for Python das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer ein eingefügtes Objekt doppelklickt, wird es automatisch in der zugehörigen Anwendung geöffnet oder der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen.

Der folgende Python‑Code zeigt, wie HTML‑ und ZIP‑Dateien in einer Folie eingebettet werden:
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

Bei der Arbeit mit Präsentationen kann es erforderlich sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for Python ermöglicht das Festlegen des Dateityps eines eingebetteten Objekts, sodass Sie die OLE‑Framedaten oder die Dateierweiterung aktualisieren können.

Der folgende Python‑Code zeigt, wie der Dateityp des eingebetteten OLE‑Objekts auf `zip` gesetzt wird:
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Dateityp zu ZIP ändern.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nachdem Sie ein OLE‑Objekt eingebettet haben, wird automatisch eine auf einem Symbol basierende Vorschau hinzugefügt. Diese Vorschau wird den Benutzern angezeigt, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Wenn Sie ein bestimmtes Bild und einen Text in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Python festlegen.

Der folgende Python‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt festgelegt werden:
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Bild zu den Präsentationsressourcen hinzufügen.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Titel und Bild für die OLE-Vorschau festlegen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Verhindern, dass OLE‑Objekt‑Frames in Größe und Position geändert werden**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Folie hinzugefügt haben, kann PowerPoint beim Öffnen der Präsentation auffordern, Verknüpfungen zu aktualisieren. Das Auswählen von „Verknüpfungen aktualisieren“ kann Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Vorschau mit Daten des verknüpften Objekts aktualisiert. Um zu verhindern, dass PowerPoint Sie auffordert, die Objektdaten zu aktualisieren, setzen Sie die Eigenschaft `update_automatic` der Klasse [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) auf `False`:
```py
ole_frame.update_automatic = False
```


## **Eingebettete Dateien extrahieren**

Aspose.Slides for Python ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), die die zu extrahierenden OLE‑Objekte enthält.
1. Durchlaufen Sie alle Formen in der Präsentation und suchen Sie die OLEObjectFrame‑Formen.
1. Rufen Sie die eingebetteten Dateidaten jeder [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ab und schreiben Sie sie auf die Festplatte.

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

Es wird das sichtbar auf der Folie – das Symbol/Ersetzungbild (Vorschau) – gerendert. Der „Live‑“ OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschaubild festlegen, um das erwartete Erscheinungsbild im exportierten PDF zu gewährleisten.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, damit Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑spezifische Sperren](/slides/de/python-net/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Verschiebungen.

**Warum springt ein verknüpftes Excel‑Objekt beim Öffnen der Präsentation oder ändert seine Größe?**

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die bewährten Vorgehensweisen aus der [Lösung für die Größenanpassung von Arbeitsblättern](/slides/de/python-net/working-solution-for-worksheet-resizing/) befolgen – entweder den Frame an den Bereich anpassen oder den Bereich an einen festen Frame skalieren und ein geeignetes Ersetzungbild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format ist die Information zu „relativen Pfaden“ nicht verfügbar – nur der vollständige Pfad wird gespeichert. Relative Pfade kommen im älteren PPT‑Format vor. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.