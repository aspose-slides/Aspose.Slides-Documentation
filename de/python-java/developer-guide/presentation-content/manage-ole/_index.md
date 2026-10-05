---
title: OLE in Präsentationen mit Python verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/python-java/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung und -einbettung
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbetten
- Verknüpftes Objekt
- Verknüpfte Datei
- OLE ändern
- OLE-Symbol
- OLE-Titel
- OLE extrahieren
- Objekt extrahieren
- Datei extrahieren
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---
## **Einleitung**

{{% alert color="info" title="Hinweis" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen Anwendung über Verknüpfung oder Einbettung zu platzieren.

{{% /alert %}}

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm gilt als OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet bzw. Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE‑Objekt kann seinen eigentlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides für Python via Java](https://products.aspose.com/slides/python-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **OLE‑Objektrahmen zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides für Python via Java als OLE‑Objekt‑Frame in einer Folie einbetten, dann geht das folgendermaßen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse.
2. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
3. Lesen Sie die Excel‑Datei als Byte‑Array.
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) zur Folie hinzu und übergeben Sie das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objekt‑Frame in eine Folie eingefügt, wobei Aspose.Slides für Python via Java verwendet wurde. **Hinweis** dass der [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/)‑Konstruktor die Erweiterung des einbettbaren Objekts als zweiten Parameter erwartet. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen des OLE‑Objekts zu wählen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Daten für das OLE-Objekt vorbereiten.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # OLE-Objektrahmen zur Folie hinzufügen.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Verknüpfte OLE‑Objektrahmen hinzufügen**

Aspose.Slides für Python via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) mit einem Link zur Datei anstelle eingebetteter Daten.

Der nachstehende Python‑Code zeigt, wie Sie einem [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) ein verknüpftes Excel‑File zu einer Folie hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # OLE-Objektrahmen mit verknüpfter Excel-Datei hinzufügen.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zugriff auf OLE‑Objektrahmen**

Falls ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse erzeugen.
2. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)‑Form. In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die auf der ersten Folie nur eine Form enthält. Wir haben dann geprüft, dass das Objekt ein [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) ist. Dies war das gewünschte OLE‑Objekt‑Frame, auf das zugegriffen werden soll.
4. Sobald das OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im folgenden Beispiel werden ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) und seine Dateidaten abgerufen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Die eingebetteten Dateidaten abrufen.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Die Erweiterung der eingebetteten Datei abrufen.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Verknüpfte OLE‑Objektrahmen‑Eigenschaften zugreifen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objektrahmen.

Der nachstehende Python‑Code zeigt, wie Sie prüfen können, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Prüfen, ob das OLE-Objekt verknüpft ist.
        if ole_frame.isObjectLink():
            # Den vollständigen Pfad zur verknüpften Datei ausgeben.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Den relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
            # Nur PPT-Präsentationen können den relativen Pfad enthalten.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE‑Objektdaten ändern**

{{% alert color="info" title="Hinweis" %}}

In diesem Abschnitt verwendet das untenstehende Code‑Beispiel [Aspose.Cells für Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Falls ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt einfach zugreifen und dessen Daten wie folgt ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) Klasse erzeugen.
2. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
3. Greifen Sie auf die OLE‑Objekt‑Frame‑Form zu. In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die eine Form auf der ersten Folie enthält. Wir haben dann geprüft, dass das Objekt ein [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) ist. Dies war das gewünschte OLE‑Objekt‑Frame, auf das zugegriffen werden soll.
4. Sobald das OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.
5. Erzeugen Sie ein [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie auf das gewünschte [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachstehenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        #   Die OLE-Objektdaten als Workbook-Objekt lesen.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        #   Die Workbook-Daten ändern.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        #   Die OLE-Frame-Objektdaten ändern.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen erlaubt Aspose.Slides für Python via Java das Einbetten weiterer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelt anklickt, wird es automatisch im zugehörigen Programm geöffnet oder der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen.

Der nachstehende Python‑Code zeigt, wie HTML und ZIP in eine Folie eingebettet werden:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dateitypen für eingebettete Objekte festlegen**

Bei der Arbeit mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides für Python via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Rahmendaten oder dessen Erweiterung aktualisieren können.

Der nachstehende Python‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Dateityp zu ZIP ändern.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nachdem ein OLE‑Objekt eingebettet wurde, wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau ist das, was Benutzer sehen, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für Python via Java festlegen.

Der nachstehende Python‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Bild zu den Präsentationsressourcen hinzufügen.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Titel und Bild für die OLE‑Vorschau festlegen.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verhindern, dass ein OLE‑Objektrahmen in der Größe geändert und neu positioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Durch Klicken auf die Schaltfläche „Update Links“ kann die Größe und Position des OLE‑Objekt‑Frames geändert werden, weil PowerPoint die Daten aus dem verknüpften OLE‑Objekt aktualisiert und die Objektvorschau neu rendert. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, rufen Sie die [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)‑Methode der [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)‑Klasse mit `False` auf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides für Python via Java ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)‑Formen zu.
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Objekt‑Frames zu und schreiben Sie sie auf die Festplatte.

Der nachstehende Python‑Code zeigt, wie Sie Dateien, die als OLE‑Objekte in einer Folie eingebettet sind, extrahieren:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Auf der Folie angezeigte Inhalte werden gerendert – das Symbol‑ bzw. Ersatzbild (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie Ihr eigenes Vorschau‑Bild festlegen, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.

Um die eingebettete Datei außerdem als PDF‑Anhang zu erhalten, rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `True` auf. Diese Option ist standardmäßig deaktiviert. Ein Beispiel und Anweisungen zum Überprüfen des Anhangs finden Sie unter [Eingebettete OLE‑Dateien als PDF‑Anhänge beibehalten](/slides/de/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [shape‑level locks](/slides/de/python-java/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die im [Working Solution for Worksheet Resizing](/slides/de/python-java/working-solution-for-worksheet-resizing/) beschriebenen Praktiken befolgen – entweder den Rahmen an den Bereich anpassen oder den Bereich an einen festen Rahmen skalieren und ein geeignetes Ersatzbild setzen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten?**

In PPTX ist die Information zu „relativen Pfaden“ nicht verfügbar – nur der vollständige Pfad wird gespeichert. Relative Pfade kommen im älteren PPT‑Format vor. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder Einbettungen verwenden.