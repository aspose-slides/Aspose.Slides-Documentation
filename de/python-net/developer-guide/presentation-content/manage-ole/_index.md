---
title: Manage OLE in Presentations Using Python
linktitle: Manage OLE
type: docs
weight: 40
url: /de/python-net/manage-ole/
keywords:
- OLE object
- Object Linking & Embedding
- add OLE
- embed OLE
- add object
- embed object
- add file
- embed file
- linked object
- linked file
- change OLE
- OLE icon
- OLE title
- extact OLE
- extract object
- extract file
- PowerPoint 
- presentation
- Python
- Aspose.Slides
description: "Optimize OLE object management in PowerPoint and OpenDocument files with Aspose.Slides for Python via .NET. Embed, update, and export OLE content seamlessly."
---

## **Übersicht**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen Anwendung zu verknüpfen oder einzubetten.

{{% /alert %}}

Ein Beispiel ist ein Diagramm, das in Microsoft Excel erstellt und auf einer PowerPoint‑Folie platziert wird – dies ist ein OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. Beim Doppelklick auf das Symbol wird das Objekt in der zugehörigen Anwendung (z. B. Excel) geöffnet oder es wird ein Dialog angezeigt, in dem Sie eine Anwendung zum Öffnen bzw. Bearbeiten auswählen können.
- Ein OLE‑Objekt kann seinen Inhalt anzeigen (z. B. ein Diagramm). In diesem Fall aktiviert PowerPoint das eingebettete Objekt, lädt die Diagrammschnittstelle und ermöglicht die Bearbeitung der Diagrammdaten direkt in PowerPoint.

Aspose.Slides for Python ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑Objekte zu Folien hinzufügen**

Wenn Sie bereits ein Diagramm in Microsoft Excel erstellt haben und es mithilfe von Aspose.Slides for Python als OLE‑Objekt‑Frame in einer Folie einbetten möchten, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Lesen Sie die Excel‑Datei in ein Byte‑Array ein.
1. Fügen Sie der Folie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzu und übergeben Sie das Byte‑Array sowie weitere OLE‑Objekt‑Details.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) in eine Folie eingebettet.

**Hinweis:** Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) erwartet als zweiten Parameter die Dateierweiterung des einzubettenden Objekts. PowerPoint verwendet diese Erweiterung, um den Dateityp zu ermitteln und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Daten für das OLE‑Objekt vorbereiten.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # OLE‑Objekt‑Frame zur Folie hinzufügen.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Verknüpfte OLE‑Objekte hinzufügen**

Aspose.Slides for Python ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), das zu einer Datei verlinkt ist, anstatt deren Daten einzubetten.

Das folgende Python‑Beispiel zeigt, wie ein mit einer Excel‑Datei verknüpfter [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Folie hinzugefügt wird:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # OLE‑Objekt‑Frame mit verknüpfter Excel‑Datei hinzufügen.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf OLE‑Objekte zugreifen**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie wie folgt darauf zugreifen:

1. Laden Sie die Präsentation, die das eingebettete OLE‑Objekt enthält, indem Sie eine Instanz der Presentation‑Klasse erstellen.
1. Holen Sie sich die Referenz auf die Folie über ihren Index.
1. Greifen Sie auf die OleObjectFrame‑Form zurück.
1. Sobald Sie den OLE‑Objekt‑Frame besitzen, führen Sie die gewünschten Operationen aus.

Das folgende Beispiel greift auf den OLE‑Objekt‑Frame – ein eingebettetes Excel‑Diagramm – zu und liest die Dateidaten aus. In diesem Beispiel verwenden wir eine PPTX‑Datei, die auf der ersten Folie nur ein einziges Shape enthält.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Eingebettete Dateidaten abrufen.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Dateierweiterung der eingebetteten Datei ermitteln.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Eigenschaften verknüpfter OLE‑Objekte auslesen**

Aspose.Slides ermöglicht das Auslesen der Eigenschaften eines verknüpften OLE‑Objekt‑Frames.

Das nachfolgende Python‑Beispiel prüft, ob ein OLE‑Objekt verknüpft ist, und gibt, falls dies zutrifft, den Pfad zur verknüpften Datei aus:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Prüfen, ob das OLE‑Objekt verknüpft ist.
        if ole_frame.is_object_link:
            # Vollständigen Pfad zur verknüpften Datei ausgeben.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
            # Nur .ppt‑Präsentationen können einen relativen Pfad enthalten.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE‑Objektdaten ändern**

{{% alert color="primary" %}}

In diesem Abschnitt wird das Code‑Beispiel für [Aspose.Cells for Python via .NET](/cells/python-net/) verwendet.

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es wie folgt lesen und die Daten ändern:

1. Laden Sie die Präsentation, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse erstellen.
1. Holen Sie sich die Ziel‑Folien‑Instanz über ihren Index.
1. Greifen Sie auf das [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)‑Shape zu.
1. Sobald Sie den OLE‑Objekt‑Frame besitzen, führen Sie die gewünschten Operationen aus.
1. Erstellen Sie ein `Workbook`‑Objekt und lesen Sie die OLE‑Daten ein.
1. Öffnen Sie das gewünschte `Worksheet` und bearbeiten Sie die Daten.
1. Speichern Sie das aktualisierte `Workbook` in einen Stream.
1. Ersetzen Sie die OLE‑Objektdaten mithilfe dieses Streams.

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein eingebettetes Excel‑Diagramm) ausgelesen und dessen Dateidaten so geändert, dass das Diagramm aktualisiert wird. Die Beispiel‑PPTX enthält auf der ersten Folie ein einzelnes Shape.

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
            # OLE‑Objektdaten als Workbook‑Objekt einlesen.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Arbeitsblattdaten ändern.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE‑Frame‑Objektdaten ändern.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dateien in Folien einbetten**

Neben Excel‑Diagrammen können Sie mit Aspose.Slides for Python weitere Dateitypen in Folien einbetten, etwa HTML-, PDF‑ oder ZIP‑Dateien. Wenn ein Benutzer ein eingefügtes Objekt doppelklickt, wird es automatisch in der zugehörigen Anwendung geöffnet bzw. es wird ein Dialog zur Auswahl einer passenden Anwendung angezeigt.

Der folgende Python‑Code demonstriert, wie HTML‑ und ZIP‑Dateien in einer Folie eingebettet werden:

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

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for Python ermöglicht das Festlegen des Dateityps eines eingebetteten Objekts, sodass Sie die OLE‑Frame‑Daten oder deren Dateierweiterung aktualisieren können.

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

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine symbolbasierte Vorschau hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen. Möchten Sie ein bestimmtes Bild und einen bestimmten Text in der Vorschau verwenden, können Sie Bild und Titel über Aspose.Slides for Python einstellen.

Der folgende Python‑Code demonstriert, wie das Symbolbild und der Titel für ein eingebettetes Objekt gesetzt werden:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Bild zu den Präsentationsressourcen hinzufügen.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Titel und Bild für die OLE‑Vorschau festlegen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhindern, dass OLE‑Objekt‑Frames skaliert und neu positioniert werden**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Folie hinzugefügt haben, kann PowerPoint beim Öffnen der Präsentation auffordern, Verknüpfungen zu aktualisieren. Das Auswählen von „Links aktualisieren“ kann Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Vorschau mit Daten des verknüpften Objekts aktualisiert. Um zu verhindern, dass PowerPoint Sie zur Aktualisierung der Objektdaten auffordert, setzen Sie die Eigenschaft `update_automatic` der [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)-Klasse auf `False`:

```py
ole_frame.update_automatic = False
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides for Python ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, die die zu extrahierenden OLE‑Objekte enthält.
1. Durchlaufen Sie alle Shapes der Präsentation und ermitteln Sie die OleObjectFrame‑Shapes.
1. Lesen Sie die eingebetteten Dateidaten jedes [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) aus und schreiben Sie sie auf die Festplatte.

Der folgende Python‑Code zeigt, wie Dateien aus einer Folie als OLE‑Objekte extrahiert werden:

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

**Wird der OLE‑Inhalt beim Exportieren von Folien in PDF/Bilder gerendert?**

Auf der Folie wird das, was sichtbar ist, gerendert – also das Symbol bzw. das Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschau‑Bild festlegen, um das erwartete Aussehen im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es nicht verschieben/bearbeiten können?**

Form sperren: Aspose.Slides stellt [Sperren auf Form-Ebene](/slides/de/python-net/applying-protection-to-presentation/) bereit. Dies ist keine Verschlüsselung, verhindert aber effektiv unbeabsichtigte Änderungen und Bewegungen.

**Warum springt ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die im Artikel beschriebenen Vorgehensweisen zur **Worksheet‑Resizing** befolgen – entweder den Frame an den Datenbereich anpassen oder den Datenbereich in einen festen Frame skalieren und ein passendes Ersatzbild setzen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten?**

Im PPTX‑Format stehen keine Informationen zu „relativen Pfaden“ zur Verfügung – nur der vollständige Pfad wird gespeichert. Relative Pfade finden sich ausschließlich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.