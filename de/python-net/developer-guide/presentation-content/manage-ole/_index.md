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
description: "Optimieren Sie die OLE-Objektverwaltung in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via .NET. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---
## **Einleitung**

{{% alert color="info" title="Hinweis" %}}

**OLE (Object Linking & Embedding)** ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen zu verlinken oder zu embedden.

{{% /alert %}}

Zum Beispiel ist ein in Microsoft Excel erstelltes Diagramm, das auf einer PowerPoint‑Folie platziert wird, ein OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol erscheinen. Durch Doppelklick auf das Symbol wird das Objekt in seiner zugehörigen Anwendung (z. B. Excel) geöffnet oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten auszuwählen.
- Ein OLE‑Objekt kann seinen Inhalt anzeigen (z. B. ein Diagramm). In diesem Fall aktiviert PowerPoint das eingebettete Objekt, lädt die Diagrammschnittstelle und ermöglicht Ihnen, die Diagrammdaten innerhalb von PowerPoint zu bearbeiten.

Aspose.Slides für Python ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑Objekte zu Folien hinzufügen**

Wenn Sie bereits ein Diagramm in Microsoft Excel erstellt haben und es als OLE‑Objektrahmen in einer Folie einbetten möchten, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
1. Lesen Sie die Excel‑Datei in ein Byte‑Array ein.
1. Fügen Sie der Folie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) hinzu und übergeben Sie das Byte‑Array sowie weitere OLE‑Objektdetails.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel wird ein Diagramm aus einer Excel‑Datei als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) in einer Folie eingebettet.

**Hinweis:** Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) erhält die Dateierweiterung des zu embedden Objekts als zweiten Parameter. PowerPoint verwendet diese Erweiterung, um den Dateityp zu identifizieren und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Daten für das OLE-Objekt vorbereiten.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Ein OLE-Objektrahmen zur Folie hinzufügen.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Verknüpfte OLE‑Objekte hinzufügen**

Aspose.Slides für Python ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/), das zu einer Datei verlinkt ist, anstatt deren Daten einzubetten.

Das folgende Python‑Beispiel zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) zu einer Excel‑Datei auf einer Folie verknüpft wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ein OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzufügen.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf OLE‑Objekte**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie darauf wie folgt zugreifen:

1. Laden Sie die Präsentation, die das eingebettete OLE‑Objekt enthält, indem Sie eine Instanz der Presentation‑Klasse erstellen.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
1. Greifen Sie auf die OleObjectFrame‑Form zu.
1. Sobald Sie den OLE‑Objektrahmen haben, führen Sie die gewünschten Operationen aus.

Das untenstehende Beispiel greift auf den OLE‑Objektrahmen – ein eingebettetes Excel‑Diagramm – zu und ruft dessen Dateidaten ab. In diesem Beispiel verwenden wir eine PPTX‑Datei, die auf der ersten Folie eine einzelne Form enthält.

```py
import aspose.slides as slides

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

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften eines verknüpften OLE‑Objektrahmens.

Das nachfolgende Python‑Beispiel prüft, ob ein OLE‑Objekt verknüpft ist, und gibt – falls ja – den Pfad zur verknüpften Datei zurück:

```py
import aspose.slides as slides

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

## **OLE‑Objektdaten ändern**

{{% alert color="info" title="Hinweis" %}}

In diesem Abschnitt verwendet das untenstehende Codebeispiel [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie darauf zugreifen und seine Daten wie folgt ändern:

1. Laden Sie die Präsentation, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse erstellen.
1. Holen Sie die Ziel‑Folie anhand ihres Index.
1. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)‑Form zu.
1. Sobald Sie den OLE‑Objektrahmen haben, führen Sie die erforderlichen Operationen aus.
1. Erzeugen Sie ein `Workbook`‑Objekt und lesen Sie die OLE‑Daten.
1. Öffnen Sie das gewünschte `Worksheet` und bearbeiten Sie die Daten.
1. Speichern Sie das aktualisierte `Workbook` in einen Stream.
1. Ersetzen Sie die OLE‑Objektdaten mithilfe dieses Streams.

Im nachfolgenden Beispiel wird ein OLE‑Objektrahmen (ein eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten modifiziert, um das Diagramm zu aktualisieren. Das Beispiel verwendet eine zuvor erstellte PPTX‑Datei, die auf der ersten Folie eine einzelne Form enthält.

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
            # Die Arbeitsmappendaten ändern.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Die OLE-Rahmen-Objektdaten ändern.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dateien in Folien einbetten**

Zusätzlich zu Excel‑Diagrammen ermöglicht Aspose.Slides für Python das Einbetten anderer Dateitypen in Folien. Sie können beispielsweise HTML-, PDF- und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer ein eingefügtes Objekt doppelklickt, wird es automatisch in der zugehörigen Anwendung geöffnet oder der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen.

Dieses Python‑Code‑Beispiel zeigt, wie HTML‑ und ZIP‑Dateien in einer Folie eingebettet werden:

```py
import aspose.slides as slides

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

Beim Arbeiten mit Präsentationen kann es erforderlich sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu substituieren. Aspose.Slides für Python ermöglicht das Festlegen des Dateityps eines eingebetteten Objekts, sodass Sie die OLE‑Rahmendaten oder dessen Dateierweiterung aktualisieren können.

Dieses Python‑Beispiel zeigt, wie der Dateityp des eingebetteten OLE‑Objekts auf `zip` gesetzt wird:

```py
import aspose.slides as slides

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

Nachdem Sie ein OLE‑Objekt eingebettet haben, wird automatisch eine symbolbasierte Vorschau hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE‑Objekt zugreifen oder es öffnen. Wenn Sie ein bestimmtes Bild und einen bestimmten Text in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für Python festlegen.

Dieses Python‑Code‑Beispiel zeigt, wie das Symbolbild und der Titel für ein eingebettetes Objekt gesetzt werden:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Bild zur Präsentationsressource hinzufügen.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Titel und Bild für die OLE-Vorschau festlegen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhindern, dass OLE‑Objektrahmen skaliert und verschoben werden**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Folie hinzugefügt haben, kann PowerPoint beim Öffnen der Präsentation auffordern, Links zu aktualisieren. Das Auswählen von „Links aktualisieren“ kann die Größe und Position des OLE‑Objektrahmens ändern, weil PowerPoint die Vorschau mit Daten des verknüpften Objekts neu lädt. Um zu verhindern, dass PowerPoint Sie auffordert, die Objektdaten zu aktualisieren, setzen Sie die Eigenschaft `update_automatic` der [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)‑Klasse auf `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides für Python ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse, die die OLE‑Objekte enthält, die Sie extrahieren möchten.
1. Durchlaufen Sie alle Formen in der Präsentation und suchen Sie die OleObjectFrame‑Formen.
1. Lesen Sie die eingebetteten Dateidaten jeder [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) aus und schreiben Sie sie auf die Festplatte.

Das folgende Python‑Beispiel zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:

```py
import aspose.slides as slides

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

Es wird das, was auf der Folie sichtbar ist, gerendert – das Symbol/Ersetzungssymbol (Vorschau). Der „Live“-OLE‑Inhalt wird während des Renderings nicht ausgeführt. Falls nötig, setzen Sie Ihr eigenes Vorschau‑Bild, um das gewünschte Erscheinungsbild im exportierten PDF sicherzustellen.

Um die eingebettete Datei auch als PDF‑Anhang zu erhalten, setzen Sie [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) auf `True`. Diese Option ist standardmäßig deaktiviert. Ein Beispiel und Anweisungen zum Prüfen des Anhangs finden Sie unter [Preserve Embedded OLE Files as PDF Attachments](/slides/de/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑ebene Sperren](/slides/de/python-net/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den Praktiken der [Working Solution for Worksheet Resizing](/slides/de/python-net/working-solution-for-worksheet-resizing/) – passen Sie den Rahmen entweder an den Bereich an oder skalieren Sie den Bereich in einen festen Rahmen und setzen ein geeignetes Ersetzungssymbol.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format gibt es keine „relativen Pfad“-Informationen – nur den vollständigen Pfad. Relative Pfade finden sich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/erreichbare URIs oder das Einbetten bevorzugen.