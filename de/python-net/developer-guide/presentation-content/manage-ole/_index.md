---
title: OLE in Präsentationen mit Python verwalten
linktitle: OLE verwalten
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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via .NET. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---

## **Übersicht**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen zu verknüpfen oder einzubetten.

{{% /alert %}}

Beispielsweise ist ein Diagramm, das in Microsoft Excel erstellt und auf einer PowerPoint‑Folie platziert wird, ein OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. Ein Doppelklick auf das Symbol öffnet das Objekt in der zugehörigen Anwendung (z. B. Excel) oder fordert Sie auf, eine Anwendung zum Öffnen oder Bearbeiten auszuwählen.
- Ein OLE‑Objekt kann seinen Inhalt anzeigen (z. B. ein Diagramm). In diesem Fall aktiviert PowerPoint das eingebettete Objekt, lädt die Diagrammschnittstelle und ermöglicht es Ihnen, die Diagrammdaten direkt in PowerPoint zu bearbeiten.

Aspose.Slides for Python lets you insert OLE objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑Objekte zu Folien hinzufügen**

Wenn Sie bereits ein Diagramm in Microsoft Excel erstellt haben und es mit Aspose.Slides for Python als OLE‑Objekt‑Frame in eine Folie einbetten möchten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
1. Lesen Sie die Excel‑Datei in ein Byte‑Array ein.
1. Fügen Sie der Folie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzu und übergeben dabei das Byte‑Array sowie weitere OLE‑Objektdetails.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) in eine Folie eingebettet.

**Hinweis:** Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) nimmt die Dateierweiterung des einbettbaren Objekts als zweiten Parameter entgegen. PowerPoint verwendet diese Erweiterung, um den Dateityp zu erkennen und die geeignete Anwendung zum Öffnen des OLE‑Objekts auszuwählen.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Verknüpfte OLE‑Objekte hinzufügen**

Aspose.Slides for Python lets you add an [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) that links to a file instead of embedding its data.

Der folgende Python‑Code zeigt, wie man ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzufügt, das zu einer Excel‑Datei auf einer Folie verlinkt:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE‑Objekte zugreifen**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie wie folgt darauf zugreifen:

1. Laden Sie die Präsentation, die das eingebettete OLE‑Objekt enthält, indem Sie eine Instanz der Klasse Presentation erstellen.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
1. Greifen Sie auf die OleObjectFrame‑Form zu.
1. Sobald Sie den OLE‑Objekt‑Frame haben, führen Sie die gewünschten Vorgänge aus.

Das folgende Beispiel greift auf den OLE‑Objekt‑Frame – ein eingebettetes Excel‑Diagramm – zu und ruft dessen Dateidaten ab. In diesem Beispiel verwenden wir ein PPTX mit einer einzigen Form auf der ersten Folie.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Eigenschaften verknüpfter OLE‑Objekte zugreifen**

Aspose.Slides lets you access the properties of a linked OLE object frame.

Das untenstehende Python‑Beispiel prüft, ob ein OLE‑Objekt verlinkt ist, und gibt, falls ja, den Pfad zur verlinkten Datei zurück:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE‑Objektdaten ändern**

{{% alert color="primary" %}}

In diesem Abschnitt verwendet das untenstehende Code‑Beispiel Aspose.Cells für Python via .NET.

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es wie folgt zugreifen und seine Daten ändern:

1. Laden Sie die Präsentation, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse erstellen.
1. Holen Sie das Ziel‑Slide anhand seines Index.
1. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.
1. Sobald Sie den OLE‑Objekt‑Frame haben, führen Sie die gewünschten Vorgänge aus.
1. Erstellen Sie ein `Workbook`‑Objekt und lesen Sie die OLE‑Daten.
1. Öffnen Sie das gewünschte `Worksheet` und bearbeiten Sie die Daten.
1. Speichern Sie das aktualisierte `Workbook` in einen Stream.
1. Ersetzen Sie die OLE‑Objektdaten mithilfe dieses Streams.

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein eingebettetes Excel‑Diagramm) geöffnet und dessen Dateidaten geändert, um das Diagramm zu aktualisieren. Das Beispiel verwendet ein zuvor erstelltes PPTX mit einer einzigen Form auf der ersten Folie.

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
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dateien in Folien einbetten**

Zusätzlich zu Excel‑Diagrammen ermöglicht Aspose.Slides für Python das Einbetten weiterer Dateitypen in Folien. Sie können beispielsweise HTML-, PDF- und ZIP-Dateien als Objekte einfügen. Wenn ein Benutzer ein eingefügtes Objekt doppelklickt, wird es automatisch in der zugehörigen Anwendung geöffnet, bzw. der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen.

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

Bei der Arbeit mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes auszutauschen. Aspose.Slides für Python ermöglicht es, den Dateityp eines eingebetteten Objekts festzulegen, sodass Sie die OLE‑Frame‑Daten oder die Dateierweiterung aktualisieren können.

Der folgende Python‑Code zeigt, wie man den Dateityp des eingebetteten OLE‑Objekts auf `zip` setzt:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Symboldbilder und Titel für eingebettete Objekte festlegen**

Nachdem Sie ein OLE‑Objekt eingebettet haben, wird automatisch eine symbolbasierte Vorschau hinzugefügt. Diese Vorschau sehen die Benutzer, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen Text in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für Python festlegen.

Der folgende Python‑Code zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt festgelegt werden:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhindern, dass OLE‑Objekt‑Frames skaliert und neu positioniert werden**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Folie hinzugefügt haben, kann PowerPoint beim Öffnen der Präsentation auffordern, die Verknüpfungen zu aktualisieren. Die Auswahl von „Verknüpfungen aktualisieren“ kann die Größe und Position des OLE‑Objekt‑Frames ändern, da PowerPoint die Vorschau mit Daten aus dem verknüpften Objekt aktualisiert. Um zu verhindern, dass PowerPoint Sie zur Aktualisierung der Objektdaten auffordert, setzen Sie die Eigenschaft `update_automatic` der Klasse [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) auf `False`:

```py
ole_frame.update_automatic = False
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides für Python ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die zu extrahierenden OLE‑Objekte enthält.
1. Durchlaufen Sie alle Formen in der Präsentation und lokalisieren Sie die OleObjectFrame‑Formen.
1. Rufen Sie die eingebetteten Dateidaten jeder [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ab und schreiben Sie sie auf die Festplatte.

Der folgende Python‑Code zeigt, wie Dateien, die als OLE‑Objekte in einer Folie eingebettet sind, extrahiert werden:

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

Was auf der Folie sichtbar ist, wird gerendert – das Symbol bzw. das Ersatzbild (Vorschau). Der „Live“-OLE‑Inhalt wird beim Rendern nicht ausgeführt. Falls nötig, setzen Sie ein eigenes Vorschaubild, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Form sperren: Aspose.Slides bietet [Formularebene‑Sperren](/slides/de/python-net/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert aber effektiv versehentliche Änderungen und Verschiebungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert die Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den Praktiken der [Lösung für Arbeitsblatt‑Skalierung](/slides/de/python-net/working-solution-for-worksheet-resizing/) – entweder den Frame an den Bereich anpassen oder den Bereich an einen festen Frame skalieren und ein geeignetes Ersatzbild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format sind keine Informationen zu „relativen Pfaden“ vorhanden – nur der vollständige Pfad. Relative Pfade gibt es im alten PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.